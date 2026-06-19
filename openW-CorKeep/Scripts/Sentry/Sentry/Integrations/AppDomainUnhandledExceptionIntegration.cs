using System;
using System.Runtime.ExceptionServices;
using System.Security;
using Sentry.Extensibility;
using Sentry.Internal;

namespace Sentry.Integrations
{
	internal class AppDomainUnhandledExceptionIntegration : ISdkIntegration
	{
		private readonly IAppDomain _appDomain;

		private IHub? _hub;

		private SentryOptions? _options;

		internal AppDomainUnhandledExceptionIntegration(IAppDomain? appDomain = null)
		{
			_appDomain = appDomain ?? AppDomainAdapter.Instance;
		}

		public void Register(IHub hub, SentryOptions options)
		{
			_hub = hub;
			_options = options;
			_appDomain.UnhandledException += Handle;
		}

		[HandleProcessCorruptedStateExceptions]
		[SecurityCritical]
		internal void Handle(object sender, UnhandledExceptionEventArgs e)
		{
			_options?.LogDebug("AppDomain Unhandled Exception");
			if (e.ExceptionObject is Exception ex)
			{
				ex.SetSentryMechanism("AppDomain.UnhandledException", "This exception was caught by the .NET Application Domain global error handler. The application likely crashed as a result of this exception.", false);
				_hub?.CaptureExceptionInternal(ex);
			}
			if (e.IsTerminating)
			{
				_hub?.Flush(_options.ShutdownTimeout);
			}
		}
	}
}
