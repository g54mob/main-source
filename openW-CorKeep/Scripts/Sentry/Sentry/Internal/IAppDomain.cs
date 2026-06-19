using System;
using System.Threading.Tasks;

namespace Sentry.Internal
{
	internal interface IAppDomain
	{
		event UnhandledExceptionEventHandler UnhandledException;

		event EventHandler ProcessExit;

		event EventHandler<UnobservedTaskExceptionEventArgs> UnobservedTaskException;
	}
}
