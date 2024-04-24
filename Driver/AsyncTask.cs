using System.Runtime.CompilerServices;

namespace Playwright_Automation_Framework.Driver;

public class AsyncTask<T> : Lazy<Task<T>>
{
    public AsyncTask(Func<Task<T>> taskFactory)
        : base(() => Task.Factory.StartNew(taskFactory).Unwrap())
    {

    }

    public TaskAwaiter<T> GetAwaiter()
    {
        return Value.GetAwaiter();
    }
}
