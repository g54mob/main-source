using System;
using Amazon.Runtime.Internal;

namespace Amazon.Runtime.EventStreams
{
	public class EventInputStreamContext : IDisposable
	{
		private bool _disposedValue;

		public IHttpRequestStreamHandle RequestStreamHandle { get; set; }

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposedValue)
			{
				if (disposing)
				{
					RequestStreamHandle?.Dispose();
					RequestStreamHandle = null;
				}
				_disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
