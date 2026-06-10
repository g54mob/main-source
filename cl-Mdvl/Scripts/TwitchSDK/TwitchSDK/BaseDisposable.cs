using System;

namespace TwitchSDK
{
	public abstract class BaseDisposable : IDisposable
	{
		private bool disposedValue;

		protected virtual void DisposeManaged()
		{
		}

		protected virtual void DisposeUnmanaged()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					DisposeManaged();
				}
				DisposeUnmanaged();
				disposedValue = true;
			}
		}

		~BaseDisposable()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
