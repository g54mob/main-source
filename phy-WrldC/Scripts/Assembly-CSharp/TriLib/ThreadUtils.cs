using System;
using System.Threading;

namespace TriLib
{
	public static class ThreadUtils
	{
		public static Thread RunThread(Action action, Action onComplete)
		{
			Dispatcher.CheckInstance();
			Thread thread = new Thread((ThreadStart)delegate
			{
				try
				{
					action();
					Dispatcher.InvokeAsync(onComplete);
				}
				catch (Exception ex)
				{
					Exception ex2 = ex;
					Exception exception = ex2;
					Dispatcher.InvokeAsync(delegate
					{
						throw exception;
					});
				}
			});
			thread.Start();
			return thread;
		}
	}
}
