using OpenQA.Selenium;

namespace SpecFlowSample.Domain.PageObjects;

public class ArticlePageObjects
{
    private readonly WebDriver _driver;

    public ArticlePageObjects(WebDriver driver) => _driver = driver;

    public IWebElement Title => _driver.FindElement(By.ClassName("mw-page-title-main"));
}