using System;
using Sentry.Internal;
using Sentry.Protocol;

namespace Sentry
{
	public class SpanContext : ITraceContext, ITraceContextInternal
	{
		private string? _origin;

		public SpanId SpanId { get; }

		public SpanId? ParentSpanId { get; }

		public SentryId TraceId { get; }

		public string Operation { get; set; }

		public string? Description { get; }

		public SpanStatus? Status { get; }

		public bool? IsSampled { get; }

		public Instrumenter Instrumenter { get; internal set; }

		public string? Origin
		{
			get
			{
				return _origin;
			}
			internal set
			{
				if (!OriginHelper.IsValidOrigin(value))
				{
					throw new ArgumentException("Invalid origin");
				}
				_origin = value;
			}
		}

		public SpanContext(string operation, SpanId? spanId = null, SpanId? parentSpanId = null, SentryId? traceId = null, string? description = null, SpanStatus? status = null, bool? isSampled = null)
		{
			SpanId = spanId ?? SpanId.Create();
			ParentSpanId = parentSpanId;
			TraceId = traceId ?? SentryId.Create();
			Operation = operation;
			Description = description;
			Status = status;
			IsSampled = isSampled;
		}
	}
}
