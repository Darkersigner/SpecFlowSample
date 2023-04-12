using System;
using System.Runtime.CompilerServices;
using OpenQA.Selenium;
using SpecFlowSample.Domain.Helpers;
using SpecFlowSample.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowSample.Hooks
{
    [Binding]
    public class Hooks
    {
        [AfterScenario()]
        public void EndScenario()
        {
            try
            {
                if (ScenarioContextHelper.Context.ScenarioExecutionStatus == ScenarioExecutionStatus.OK &&
                    !ScenarioContextHelper.SaveScreenshotEveryTime)
                    return;
                var screenshot = WebDriverManager.WebDriver.GetScreenshot();
                var fileName = $"{ScenarioContextHelper.Context.ScenarioInfo.Title}-{DateTime.UtcNow.Ticks}.png";
                var pathToFolder = Path.Join(Directory.GetCurrentDirectory(), "Screenshots");
                var filePath = Path.Join(pathToFolder, fileName);
                if (!Directory.Exists(pathToFolder))
                    Directory.CreateDirectory(pathToFolder);
                Console.WriteLine("Save screenshot as '" + filePath + "'");
                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
            }
            finally
            {
                WebDriverManager.CloseWebDriver();
            }
        }

        [BeforeScenario()]
        public void InitScenarioContextHelper(ScenarioContext? scenarioContext)
        {
            ScenarioContextHelper.Context = scenarioContext;
            ScenarioContextHelper.SaveScreenshotEveryTime = false;
        }
    }
}