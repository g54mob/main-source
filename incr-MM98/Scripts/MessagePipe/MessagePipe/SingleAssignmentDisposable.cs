using System;

namespace MessagePipe
{
	public sealed class SingleAssignmentDisposable : IDisposable
	{
		private IDisposable inner;

		private bool isDisposed;

		private readonly object gate = new object();

		public IDisposable Disposable
		{
			set
			{
				lock (gate)
				{
					if (isDisposed)
					{
						value.Dispose();
						return;
					}
					if (inner == null)
					{
						inner = value;
						return;
					}
					throw new InvalidOperationException("Set IDisposable twice is invalid.");
				}
			}
		}

		public void Dispose()
		{
			if (isDisposed)
			{
				return;
			}
			lock (gate)
			{
				isDisposed = true;
				if (inner != null)
				{
					inner.Dispose();
					inner = null;
				}
			}
		}
	}
}
