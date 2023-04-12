using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowSample.Domain.PageObjects;

public class MainPageObjects
{
    private readonly WebDriver _driver;

    public MainPageObjects(WebDriver driver) => this._driver = driver;

    public IWebElement Search => this._driver.FindElement(By.Id("searchInput"));

    public SelectElement SearchLanguage => new SelectElement(this._driver.FindElement(By.Id("searchLanguage")));

    public IWebElement SearchBtn => this._driver.FindElement(By.CssSelector("#search-form button"));
}