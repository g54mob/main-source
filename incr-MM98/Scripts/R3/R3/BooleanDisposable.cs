using System;

namespace R3
{
	public sealed class BooleanDisposable : IDisposable
	{
		private BooleanDisposableCore core;

		public bool IsDisposed => core.IsDisposed;

		public void Dispose()
		{
			core.Dispose();
		}
	}
}
