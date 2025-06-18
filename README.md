# SpecFlowSample

This is a lightweight UI test automation framework based on **SpecFlow** and **Selenium WebDriver**, designed for behavior-driven testing of websites.  
The current sample focuses on testing [www.wikipedia.org](https://www.wikipedia.org) across multiple browsers and input scenarios.

## 🧪 Features

- **SpecFlow + Selenium WebDriver**
- Multi-browser support (Chrome, Firefox)
- Page Object + Page Factory pattern
- Parameterized scenarios (Scenario Outline)
- Optional screenshot capture

## 📋 Example Test Scenarios

- Check the main page title of Wikipedia in different browsers
- Search for a term and verify the title of the result page
- Use different languages and verify internationalization

```gherkin
Scenario Outline: Open site, check title and close
  Given set browser <browser>
  And set save screenshots true
  And open site https://www.wikipedia.org/
  Then title browser page is 'Wikipedia'

Examples:
  | browser  |
  | Chrome   |
  | FireFox  |
