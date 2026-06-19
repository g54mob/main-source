namespace Sentry.Protocol
{
	public interface ITraceContext
	{
		SpanId SpanId { get; }

		SpanId? ParentSpanId { get; }

		SentryId TraceId { get; }

		string Operation { get; }

		string? Description { get; }

		SpanStatus? Status { get; }

		bool? IsSampled { get; }
	}
}
