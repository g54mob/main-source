using System;
using System.Threading;

namespace Loxodon.Framework.Messaging
{
	public interface ISubscription<T> : IDisposable
	{
		ISubscription<T> ObserveOn(SynchronizationContext context);
	}
}
