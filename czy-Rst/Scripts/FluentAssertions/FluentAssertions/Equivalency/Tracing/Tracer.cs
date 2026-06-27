using System;

namespace FluentAssertions.Equivalency.Tracing
{
	public class Tracer
	{
		private readonly INode currentNode;

		private readonly ITraceWriter traceWriter;

		internal Tracer(INode currentNode, ITraceWriter traceWriter)
		{
			this.currentNode = currentNode;
			this.traceWriter = traceWriter;
		}

		public void WriteLine(GetTraceMessage getTraceMessage)
		{
			traceWriter?.AddSingle(getTraceMessage(currentNode));
		}

		public IDisposable WriteBlock(GetTraceMessage getTraceMessage)
		{
			if (traceWriter != null)
			{
				return traceWriter.AddBlock(getTraceMessage(currentNode));
			}
			return new Disposable(delegate
			{
			});
		}

		public override string ToString()
		{
			if (traceWriter == null)
			{
				return string.Empty;
			}
			return traceWriter.ToString();
		}
	}
}
