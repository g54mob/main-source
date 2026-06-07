using System;

namespace R3
{
	public sealed class SingleAssignmentDisposable : IDisposable
	{
		private SingleAssignmentDisposableCore core;

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
