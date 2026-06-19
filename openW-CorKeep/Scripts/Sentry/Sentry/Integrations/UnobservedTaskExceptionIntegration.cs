using System;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Threading.Tasks;
using Sentry.Internal;

namespace Sentry.Integrations
{
	internal class UnobservedTaskExceptionIntegration : ISdkIntegration
	{
		internal const string MechanismKey = "UnobservedTaskException";

		private readonly IAppDomain _appDomain;

		private IHub _hub;

		internal UnobservedTaskExceptionIntegration(IAppDomain? appDomain = null)
		{
			_appDomain = appDomain ?? AppDomainAdapter.Instance;
		}

		public void Register(IHub hub, SentryOptions _)
		{
			_hub = hub;
			_appDomain.UnobservedTaskException += Handle;
		}

		[HandleProcessCorruptedStateExceptions]
		[SecurityCritical]
		internal void Handle(object? sender, UnobservedTaskExceptionEventArgs e)
		{
			AggregateException exception = e.Exception;
			exception.SetSentryMechanism("UnobservedTaskException", "This exception was thrown from a task that was unobserved, such as from an async void method, or a Task.Run that was not awaited. This exception was unhandled, but likely did not crash the application.", false);
			_hub.CaptureExceptionInternal(exception);
		}
	}
}
