using System;
using System.Threading;

namespace R3
{
	internal sealed class AnonymousDisposable : IDisposable
	{
		private volatile Action? onDisposed;

		public AnonymousDisposable(Action onDisposed)
		{
			this.onDisposed = onDisposed;
		}

		public void Dispose()
		{
			Interlocked.Exchange(ref onDisposed, null)?.Invoke();
		}
	}
	internal sealed class AnonymousDisposable<T> : IDisposable
	{
		private T state;

		private volatile Action<T>? onDisposed;

		public AnonymousDisposable(T state, Action<T> onDisposed)
		{
			this.state = state;
			this.onDisposed = onDisposed;
		}

		public void Dispose()
		{
			Interlocked.Exchange(ref onDisposed, null)?.Invoke(state);
			state = default(T);
		}
	}
}
