using System;
using Loxodon.Framework.Asynchronous;

namespace Loxodon.Framework.Execution
{
	public interface IScheduledExecutor : IDisposable
	{
		void Start();

		void Stop();

		IAsyncResult<TResult> Schedule<TResult>(Func<TResult> command, long delay);

		IAsyncResult<TResult> Schedule<TResult>(Func<TResult> command, TimeSpan delay);

		Loxodon.Framework.Asynchronous.IAsyncResult Schedule(Action command, long delay);

		Loxodon.Framework.Asynchronous.IAsyncResult Schedule(Action command, TimeSpan delay);

		Loxodon.Framework.Asynchronous.IAsyncResult ScheduleAtFixedRate(Action command, long initialDelay, long period);

		Loxodon.Framework.Asynchronous.IAsyncResult ScheduleAtFixedRate(Action command, TimeSpan initialDelay, TimeSpan period);

		Loxodon.Framework.Asynchronous.IAsyncResult ScheduleWithFixedDelay(Action command, long initialDelay, long delay);

		Loxodon.Framework.Asynchronous.IAsyncResult ScheduleWithFixedDelay(Action command, TimeSpan initialDelay, TimeSpan delay);
	}
}
