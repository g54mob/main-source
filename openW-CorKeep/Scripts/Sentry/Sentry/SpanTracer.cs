using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Sentry.Internal;
using Sentry.Protocol;

namespace Sentry
{
	public class SpanTracer : IBaseTracer, ITraceContextInternal, ISpan, ISpanData, ITraceContext, IHasTags, IHasExtra
	{
		private readonly IHub _hub;

		private readonly SentryStopwatch _stopwatch = SentryStopwatch.StartNew();

		private readonly Instrumenter _instrumenter;

		private readonly Lazy<MetricsSummaryAggregator> _metricsSummary = new Lazy<MetricsSummaryAggregator>();

		private readonly ConcurrentDictionary<string, object?> _data = new ConcurrentDictionary<string, object>();

		private string? _origin;

		bool IBaseTracer.IsOtelInstrumenter => _instrumenter == Instrumenter.OpenTelemetry;

		internal TransactionTracer Transaction { get; }

		internal MetricsSummaryAggregator MetricsSummary => _metricsSummary.Value;

		internal bool HasMetrics => _metricsSummary.IsValueCreated;

		public SpanId SpanId { get; internal set; }

		public SpanId? ParentSpanId { get; internal set; }

		public SentryId TraceId { get; }

		public DateTimeOffset StartTimestamp { get; internal set; }

		public DateTimeOffset? EndTimestamp { get; internal set; }

		public bool IsFinished => EndTimestamp.HasValue;

		internal Dictionary<string, Measurement>? InternalMeasurements { get; private set; }

		public IReadOnlyDictionary<string, Measurement> Measurements => InternalMeasurements ?? (InternalMeasurements = new Dictionary<string, Measurement>());

		public string Operation { get; set; }

		public string? Description { get; set; }

		public SpanStatus? Status { get; set; }

		internal bool IsSentryRequest { get; set; }

		public bool? IsSampled { get; internal set; }

		internal ConcurrentDictionary<string, string>? InternalTags { get; private set; }

		public IReadOnlyDictionary<string, string> Tags => InternalTags ?? (InternalTags = new ConcurrentDictionary<string, string>());

		public IReadOnlyDictionary<string, object?> Extra => _data;

		internal Func<bool>? IsFiltered { get; set; }

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

		public void SetMeasurement(string name, Measurement measurement)
		{
			(InternalMeasurements ?? (InternalMeasurements = new Dictionary<string, Measurement>()))[name] = measurement;
		}

		public void SetTag(string key, string value)
		{
			(InternalTags ?? (InternalTags = new ConcurrentDictionary<string, string>()))[key] = value;
		}

		public void UnsetTag(string key)
		{
			(InternalTags ?? (InternalTags = new ConcurrentDictionary<string, string>())).TryRemove(key, out string _);
		}

		public void SetExtra(string key, object? value)
		{
			_data[key] = value;
		}

		public SpanTracer(IHub hub, TransactionTracer transaction, SpanId? parentSpanId, SentryId traceId, string operation)
		{
			_hub = hub;
			Transaction = transaction;
			SpanId = SpanId.Create();
			ParentSpanId = parentSpanId;
			TraceId = traceId;
			Operation = operation;
			StartTimestamp = _stopwatch.StartDateTimeOffset;
		}

		internal SpanTracer(IHub hub, TransactionTracer transaction, SpanId spanId, SpanId? parentSpanId, SentryId traceId, string operation, Instrumenter instrumenter = Instrumenter.Sentry)
		{
			_hub = hub;
			_instrumenter = instrumenter;
			Transaction = transaction;
			SpanId = spanId;
			ParentSpanId = parentSpanId;
			TraceId = traceId;
			Operation = operation;
			StartTimestamp = _stopwatch.StartDateTimeOffset;
		}

		public ISpan StartChild(string operation)
		{
			return Transaction.StartChild(null, SpanId, operation);
		}

		internal void Unfinish()
		{
			Status = null;
			EndTimestamp = null;
		}

		public void Finish()
		{
			SpanStatus? status = Status;
			SpanStatus valueOrDefault = status.GetValueOrDefault();
			if (!status.HasValue)
			{
				valueOrDefault = SpanStatus.Ok;
				SpanStatus? status2 = valueOrDefault;
				Status = status2;
			}
			DateTimeOffset? endTimestamp = EndTimestamp;
			DateTimeOffset valueOrDefault2 = endTimestamp.GetValueOrDefault();
			if (!endTimestamp.HasValue)
			{
				valueOrDefault2 = _stopwatch.CurrentDateTimeOffset;
				DateTimeOffset? endTimestamp2 = valueOrDefault2;
				EndTimestamp = endTimestamp2;
			}
		}

		public void Finish(SpanStatus status)
		{
			Status = status;
			Finish();
		}

		public void Finish(Exception exception, SpanStatus status)
		{
			_hub.BindException(exception, this);
			Finish(status);
		}

		public void Finish(Exception exception)
		{
			Finish(exception, SpanStatusConverter.FromException(exception));
		}

		public SentryTraceHeader GetTraceHeader()
		{
			return new SentryTraceHeader(TraceId, SpanId, IsSampled);
		}
	}
}
