using System;
using System.Threading.Tasks;

namespace Sentry
{
	public interface ISentryScopeManager
	{
		void ConfigureScope(Action<Scope> configureScope);

		Task ConfigureScopeAsync(Func<Scope, Task> configureScope);

		void BindClient(ISentryClient client);

		IDisposable PushScope();

		IDisposable PushScope<TState>(TState state);
	}
}
