using System.Runtime.CompilerServices;
using SpecFlowSample.Domain.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowSample.Domain.Helpers;

public static class ScenarioContextHelper
{
    private static ScenarioContext? _context;
    private static MainPage? _main;
    private const string MainPageKey = "MainPageKey";
    private static ArticlePage? _articlePage;
    private const string ArticlePageKey = "ArticlePageKey";
    private const string SaveScreenshotEveryTimeKey = "SaveScreenshotEveryTimeKey";
    private static bool _saveScreenshotEveryTime;

    public static ScenarioContext Context
    {
        get => _context != null
            ? _context
            : throw new Exception("Should setup Scenario context");
        set => _context = value;
    }

    public static MainPage? Main
    {
        get => GetObjectFromScenarioContext<MainPage>("MainPageKey");
        set => CreateOrUpdateValueByKey<MainPage>("MainPageKey", value, ref _main);
    }

    public static ArticlePage? ArticlePage
    {
        get => GetObjectFromScenarioContext<ArticlePage>("ArticlePageKey");
        set => CreateOrUpdateValueByKey<ArticlePage>("ArticlePageKey", value, ref _articlePage);
    }

    public static bool SaveScreenshotEveryTime
    {
        get => GetObjectFromScenarioContext<bool>("SaveScreenshotEveryTimeKey");
        set => CreateOrUpdateValueByKey("SaveScreenshotEveryTimeKey", value,
            ref _saveScreenshotEveryTime);
    }

    private static T GetObjectFromScenarioContext<T>(string key)
    {
        if (!Context.TryGetValue(key, out var value))
            throw new ArgumentException("ScenarioContext doesn't have key = '" + key + "'", key);
        if (value is T fromScenarioContext)
            return fromScenarioContext;
        throw new ArgumentException($"Value in ScenarioContext with key = '{key}' is not '{typeof(T)}'", key);
    }

    private static void CreateOrUpdateValueByKey<T>(string key, T value, ref T refValue)
    {
        Context[key] = value;
        refValue = value;
    }
}