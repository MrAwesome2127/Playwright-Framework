using Playwright_Automation_Framework.Driver;

namespace Playwright_Automation_Framework.Config;

public class TestSettings
{
    public float? Timeout = PlaywrightDriverInitializer.DEFAULT_TIMEOUT;
    public string ApplicationURL { get; set; }
    public string[]? Args { get; set; }
    public bool? Headless { get; set; }
    public float? SlowMo { get; set; }
    public DriverType DriverType { get; set; }
}

public enum DriverType
{
    Chrome,
    Chromium,
    Edge,
    Firefox,
    WebKit
}
