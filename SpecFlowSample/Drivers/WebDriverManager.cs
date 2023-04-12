using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SpecFlowSample.Domain.Enums;
using SpecFlowSample.Domain.Extensions;

namespace SpecFlowSample.Drivers;

public static class WebDriverManager
{
    private static WebDriver? _webDriver;

    private static WebDriversType DefaultDriverType => WebDriversType.Chrome;

    public static WebDriver WebDriver
    {
        get
        {
            if (_webDriver == null)
            {
                _webDriver = InitDriver(DefaultDriverType);
            }

            return _webDriver;
        }
        set => _webDriver = value;
    }

    public static WebDriver InitDriver(WebDriversType driverType)
    {
        _webDriver?.Dispose();
        switch (driverType)
        {
            case WebDriversType.Chrome:
                _webDriver = InitChrome();
                break;
            case WebDriversType.FireFox:
                _webDriver = InitFireFox();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(driverType), driverType,
                    "Cannot init WebDriver with value '" + driverType.GetStringValue() + "'");
        }

        return _webDriver;
    }

    private static ChromeDriver InitChrome() => new(new ChromeOptions());

    private static FirefoxDriver InitFireFox() => new(new FirefoxOptions());

    public static void CloseWebDriver() => WebDriver.Dispose();
}