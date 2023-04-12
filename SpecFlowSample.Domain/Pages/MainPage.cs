using OpenQA.Selenium;
using SpecFlowSample.Domain.PageObjects;

namespace SpecFlowSample.Domain.Pages;

public class MainPage : BasePage
{
    private readonly WebDriver _driver;
    private readonly MainPageObjects _pageObjects;

    public MainPage(WebDriver driver)
        : base(driver)
    {
        this._driver = driver;
        this._pageObjects = new MainPageObjects(driver);
    }

    public void WriteTextToSearch(string text) => this._pageObjects.Search.SendKeys(text);

    public void SelectLanguage(string language) => this._pageObjects.SearchLanguage.SelectByText(language);

    public ArticlePage PressSearchButton()
    {
        this._pageObjects.SearchBtn.Click();
        return new ArticlePage(this._driver);
    }
}