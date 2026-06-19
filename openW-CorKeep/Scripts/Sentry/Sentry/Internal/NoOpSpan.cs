using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Sentry.Protocol;

namespace Sentry.Internal
{
	internal class NoOpSpan : ISpan, ISpanData, ITraceContext, IHasTags, IHasExtra, ITraceContextInternal
	{
		public static ISpan Instance { get; } = new NoOpSpan();

		public SpanId SpanId => SpanId.Empty;

		public SpanId? ParentSpanId => SpanId.Empty;

		public SentryId TraceId => SentryId.Empty;

		public bool? IsSampled => null;

		public IReadOnlyDictionary<string, string> Tags => ImmutableDictionary<string, string>.Empty;

		public IReadOnlyDictionary<string, object?> Extra => ImmutableDictionary<string, object>.Empty;

		public DateTimeOffset StartTimestamp => default(DateTimeOffset);

		public DateTimeOffset? EndTimestamp => null;

		public bool IsFinished => false;

		public string Operation
		{
			get
			{
				return string.Empty;
			}
			set
			{
			}
		}

		public string? Description
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SpanStatus? Status
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IReadOnlyDictionary<string, Measurement> Measurements => ImmutableDictionary<string, Measurement>.Empty;

		public string? Origin { get; set; }

		protected NoOpSpan()
		{
		}

		public ISpan StartChild(string operation)
		{
			return this;
		}

		public void Finish()
		{
		}

		public void Finish(SpanStatus status)
		{
		}

		public void Finish(Exception exception, SpanStatus status)
		{
		}

		public void Finish(Exception exception)
		{
		}

		public void SetTag(string key, string value)
		{
		}

		public void UnsetTag(string key)
		{
		}

		public void SetExtra(string key, object? value)
		{
		}

		public SentryTraceHeader GetTraceHeader()
		{
			return SentryTraceHeader.Empty;
		}

		public void SetMeasurement(string name, Measurement measurement)
		{
		}
	}
}
