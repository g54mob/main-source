using System;

namespace K4os.Compression.LZ4.Internal
{
	public abstract class UnmanagedResources : IDisposable
	{
		private int _disposed;

		public bool IsDisposed => false;

		protected void ThrowIfDisposed()
		{
		}

		protected virtual void ReleaseUnmanaged()
		{
		}

		protected virtual void ReleaseManaged()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public void Dispose()
		{
		}

		~UnmanagedResources()
		{
		}
	}
}
