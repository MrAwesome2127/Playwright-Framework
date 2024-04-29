using Playwright_Automation_Framework.Config;

namespace Playwright_Automation_Framework.Driver;

public class PlaywrightDriver : IDisposable, IPlaywrightDriver
{
    private readonly AsyncTask<IPage> _page;
    private readonly AsyncTask<IBrowser> _browser;
    private readonly AsyncTask<IBrowserContext> _browserContext;
    private readonly TestSettings _testSettings;
    private readonly IPlaywrightDriverInitializer _playwrightDriverInitializer;
    private bool _isDisposed;

    public PlaywrightDriver(TestSettings testSettings, IPlaywrightDriverInitializer playwrightDriverInitializer)
    {
        _testSettings = testSettings;
        _playwrightDriverInitializer = playwrightDriverInitializer;
        _page = new AsyncTask<IPage>(CreatePageAsync);
        _browser = new AsyncTask<IBrowser>(InitializePlaywright);
        _browserContext = new AsyncTask<IBrowserContext>(CreateBrowserContext);
    }

    public Task<IPage> Page => _page.Value;
    public Task<IBrowser> Browser => _browser.Value;
    public Task<IBrowserContext> BrowserContext => _browserContext.Value;

    private async Task<IBrowser> InitializePlaywright()
    {
        return _testSettings.DriverType switch
        {
            DriverType.Chromium => await _playwrightDriverInitializer.GetChromiumDriver(_testSettings),
            DriverType.Chrome => await _playwrightDriverInitializer.GetChromeDriver(_testSettings),
            DriverType.Edge => await _playwrightDriverInitializer.GetEdgeDriver(_testSettings),
            DriverType.Firefox => await _playwrightDriverInitializer.GetFirefoxDriver(_testSettings),
            _ => await _playwrightDriverInitializer.GetChromiumDriver(_testSettings)
        };
    }

    private async Task<IBrowserContext> CreateBrowserContext()
    {
        return await (await _browser).NewContextAsync();
    }

    private async Task<IPage> CreatePageAsync()
    {
        return await (await _browserContext).NewPageAsync();
    }

    public void Dispose()
    {
        if (!_isDisposed) return;

        if (_browser.IsValueCreated)
        {
            Task.Run(async () =>
            {
                await (await Browser).CloseAsync();
                await (await Browser).DisposeAsync();
            });
        }
        _isDisposed = true;
    }
}