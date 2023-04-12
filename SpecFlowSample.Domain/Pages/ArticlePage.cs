using OpenQA.Selenium;
using SpecFlowSample.Domain.PageObjects;

namespace SpecFlowSample.Domain.Pages;

public class ArticlePage : BasePage
{
    private readonly ArticlePageObjects _pageObjects;

    public ArticlePage(WebDriver driver)
        : base(driver)
    {
        this._pageObjects = new ArticlePageObjects(driver);
    }

    public string? GetTitle() => this._pageObjects.Title.Text;
}