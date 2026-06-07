using System;

namespace Reactivity
{
	public class DisposableAction : IDisposable
	{
		private readonly Action _disposeAction;

		private bool _disposed;

		public DisposableAction(Action disposeAction)
		{
		}

		public void Dispose()
		{
		}
	}
}
