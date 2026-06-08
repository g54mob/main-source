using System;

namespace Amazon.Runtime.Telemetry.Tracing
{
	public abstract class TraceSpan : IDisposable
	{
		public string Name { get; protected set; }

		public abstract void EmitEvent(string name, Attributes attributes = null);

		public abstract void SetAttribute(string key, object value);

		public abstract void SetStatus(SpanStatus status);

		public abstract void RecordException(Exception exception, Attributes attributes = null);

		public abstract void End();

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
