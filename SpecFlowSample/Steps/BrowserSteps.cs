using NUnit.Framework;
using SpecFlowSample.Domain.Enums;
using SpecFlowSample.Domain.Extensions;
using SpecFlowSample.Domain.Helpers;
using SpecFlowSample.Domain.Pages;
using SpecFlowSample.Drivers;

namespace SpecFlowSample.Steps;

[Binding]
public class BrowserSteps
{
    private readonly ScenarioContext _scenarioContext;

    public BrowserSteps(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

    [Given("open site (.*)")]
    public void GivenOpenSite(string url)
    {
        WebDriverManager.WebDriver.Navigate().GoToUrl(url);
        ScenarioContextHelper.Main = new MainPage(WebDriverManager.WebDriver);
    }

    [Then("title browser page is '(.*)'")]
    public void ThenTitleBrowserPageIs(string title)
    {
        var browserTabTitle = WebDriverManager.WebDriver.Title;
        Assert.AreEqual(title, browserTabTitle);
    }

    [Then("title page is '(.*)'")]
    public void ThenTitlePageIs(string title)
    {
        var articleTitle = ScenarioContextHelper.ArticlePage!.GetTitle();
        Assert.AreEqual(title, articleTitle);
    }

    [Given("set browser (Chrome|FireFox)")]
    public void GivenSetBrowserChrome(string browserName) => 
        WebDriverManager.InitDriver(EnumExtension.GetEnumByName<WebDriversType>(browserName));

    [Given("write to search '(.*)'")]
    public void GivenWriteToSearch(string text) => 
        ScenarioContextHelper.Main!.WriteTextToSearch(text);

    [Given("click search button")]
    public void GivenClickSearchButton() => 
        ScenarioContextHelper.ArticlePage = ScenarioContextHelper.Main!.PressSearchButton();

    [Given("choose language '(.*)'")]
    public void GivenChooseLanguage(string language) => 
        ScenarioContextHelper.Main!.SelectLanguage(language);

    [Given("set save screenshots (true|false)")]
    public void GivenSetSaveScreenshots(bool value) => 
        ScenarioContextHelper.SaveScreenshotEveryTime = value;
}