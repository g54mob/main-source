using System;
using System.Collections.Generic;
using Sentry.Internal.ScopeStack;

namespace Sentry.Internal
{
	internal interface IInternalScopeManager : ISentryScopeManager, IDisposable
	{
		IScopeStackContainer ScopeStackContainer { get; }

		KeyValuePair<Scope, ISentryClient> GetCurrent();

		void RestoreScope(Scope savedScope);
	}
}
