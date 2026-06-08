using System;

namespace Amazon.Runtime.Telemetry.Metrics
{
	public abstract class Meter : IDisposable
	{
		public abstract UpDownCounter<T> CreateUpDownCounter<T>(string name, string units = null, string description = null) where T : struct;

		public abstract MonotonicCounter<T> CreateMonotonicCounter<T>(string name, string units = null, string description = null) where T : struct;

		public abstract Histogram<T> CreateHistogram<T>(string name, string units = null, string description = null) where T : struct;

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
		}
	}
}
