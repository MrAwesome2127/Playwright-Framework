
namespace Playwright_Automation_Framework.Driver
{
    public interface IPlaywrightDriver
    {
        Task<IBrowser> Browser { get; }
        Task<IBrowserContext> BrowserContext { get; }
        Task<IPage> Page { get; }
    }
}