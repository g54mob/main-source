using System;

namespace R3
{
	public sealed class SerialDisposable : IDisposable
	{
		private SerialDisposableCore core;

		public bool IsDisposed => core.IsDisposed;

		public IDisposable? Disposable
		{
			get
			{
				return core.Disposable;
			}
			set
			{
				core.Disposable = value;
			}
		}

		public void Dispose()
		{
			core.Dispose();
		}
	}
}
