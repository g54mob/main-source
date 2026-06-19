using System;

namespace Sentry
{
	public class SentryTraceHeader
	{
		internal const string HttpHeaderName = "sentry-trace";

		internal static readonly SentryTraceHeader Empty = new SentryTraceHeader(SentryId.Empty, SpanId.Empty, null);

		public SentryId TraceId { get; }

		public SpanId SpanId { get; }

		public bool? IsSampled { get; }

		public SentryTraceHeader(SentryId traceId, SpanId spanSpanId, bool? isSampled)
		{
			TraceId = traceId;
			SpanId = spanSpanId;
			IsSampled = isSampled;
		}

		public override string ToString()
		{
			bool? isSampled = IsSampled;
			if (isSampled.HasValue)
			{
				bool valueOrDefault = isSampled == true;
				return $"{TraceId}-{SpanId}-{(valueOrDefault ? 1 : 0)}";
			}
			return $"{TraceId}-{SpanId}";
		}

		public static SentryTraceHeader Parse(string value)
		{
			string[] array = PolyfillExtensions.Split(value, '-', StringSplitOptions.RemoveEmptyEntries);
			if (array.Length < 2)
			{
				throw new FormatException("Invalid Sentry trace header: " + value + ".");
			}
			SentryId traceId = SentryId.Parse(array[0]);
			SpanId spanSpanId = SpanId.Parse(array[1]);
			bool? isSampled = ((array.Length >= 3) ? new bool?(string.Equals(array[2], "1", StringComparison.OrdinalIgnoreCase)) : ((bool?)null));
			return new SentryTraceHeader(traceId, spanSpanId, isSampled);
		}
	}
}
