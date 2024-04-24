using Playwright_Automation_Framework.Config;

namespace Playwright_Automation_Framework.Driver;

public interface IPlaywrightDriverInitializer
{
    Task<IBrowser> GetChromeDriver(TestSettings testSettings);
    Task<IBrowser> GetChromiumDriver(TestSettings testSettings);
    Task<IBrowser> GetEdgeDriver(TestSettings testSettings);
    Task<IBrowser> GetFirefoxDriver(TestSettings testSettings);
    Task<IBrowser> GetWebKitDriver(TestSettings testSettings);
}