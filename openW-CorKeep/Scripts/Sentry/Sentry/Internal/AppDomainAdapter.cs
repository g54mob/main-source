using System;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Threading.Tasks;

namespace Sentry.Internal
{
	internal sealed class AppDomainAdapter : IAppDomain
	{
		public static AppDomainAdapter Instance { get; } = new AppDomainAdapter();

		public event UnhandledExceptionEventHandler? UnhandledException;

		public event EventHandler? ProcessExit;

		public event EventHandler<UnobservedTaskExceptionEventArgs>? UnobservedTaskException;

		private AppDomainAdapter()
		{
			AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
			AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
			TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
		}

		private void OnProcessExit(object? sender, EventArgs e)
		{
			this.ProcessExit?.Invoke(sender, e);
		}

		[HandleProcessCorruptedStateExceptions]
		[SecurityCritical]
		private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			this.UnhandledException?.Invoke(this, e);
		}

		[HandleProcessCorruptedStateExceptions]
		[SecurityCritical]
		private void OnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
		{
			this.UnobservedTaskException?.Invoke(this, e);
		}
	}
}
