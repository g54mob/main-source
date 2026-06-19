using System.Collections.Generic;
using System.Threading;

namespace Sentry.Internal.ScopeStack
{
	internal class AsyncLocalScopeStackContainer : IScopeStackContainer
	{
		private readonly AsyncLocal<KeyValuePair<Scope, ISentryClient>[]?> _asyncLocalScope = new AsyncLocal<KeyValuePair<Scope, ISentryClient>[]>();

		public KeyValuePair<Scope, ISentryClient>[]? Stack
		{
			get
			{
				return _asyncLocalScope.Value;
			}
			set
			{
				_asyncLocalScope.Value = value;
			}
		}
	}
}
