using Sentry.Protocol;

namespace Sentry
{
	public class TransactionContext : SpanContext, ITransactionContext, ITraceContext
	{
		public string Name { get; set; }

		public TransactionNameSource NameSource { get; set; }

		public bool? IsParentSampled { get; }

		public TransactionContext(string name, string operation, SpanId? spanId = null, SpanId? parentSpanId = null, SentryId? traceId = null, string? description = "", SpanStatus? status = null, bool? isSampled = null, bool? isParentSampled = null, TransactionNameSource nameSource = TransactionNameSource.Custom)
			: base(operation, spanId, parentSpanId, traceId, description, status, isSampled)
		{
			Name = name;
			IsParentSampled = isParentSampled;
			NameSource = nameSource;
		}

		internal TransactionContext(string name, string operation, SentryTraceHeader traceHeader)
			: this(name, operation, SpanId.Create(), traceHeader.SpanId, traceHeader.TraceId, "", null, traceHeader.IsSampled, traceHeader.IsSampled)
		{
		}
	}
}
