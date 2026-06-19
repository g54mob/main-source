using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Protocol;

namespace Sentry
{
	public class TransactionTracer : IBaseTracer, ITraceContextInternal, ITransactionTracer, ITransactionData, ISpanData, ITraceContext, IHasTags, IHasExtra, ITransactionContext, IEventLike, ISpan
	{
		private class LastActiveSpanTracker
		{
			private readonly object _lock = new object();

			private readonly Lazy<Stack<ISpan>> _trackedSpans = new Lazy<Stack<ISpan>>();

			private Stack<ISpan> TrackedSpans => _trackedSpans.Value;

			public void Push(ISpan span)
			{
				lock (_lock)
				{
					TrackedSpans.Push(span);
				}
			}

			public ISpan? PeekActive()
			{
				lock (_lock)
				{
					while (TrackedSpans.Count > 0)
					{
						ISpan span = TrackedSpans.Peek();
						if (!span.IsFinished)
						{
							return span;
						}
						TrackedSpans.Pop();
					}
					return null;
				}
			}

			public void Clear()
			{
				lock (_lock)
				{
					TrackedSpans.Clear();
				}
			}
		}

		private readonly IHub _hub;

		private readonly SentryOptions? _options;

		private readonly Timer? _idleTimer;

		private long _cancelIdleTimeout;

		private readonly SentryStopwatch _stopwatch = SentryStopwatch.StartNew();

		private readonly Instrumenter _instrumenter;

		private SentryRequest? _request;

		private readonly SentryContexts _contexts = new SentryContexts();

		private SentryUser? _user;

		private IReadOnlyList<string>? _fingerprint;

		private readonly ConcurrentBag<Breadcrumb> _breadcrumbs = new ConcurrentBag<Breadcrumb>();

		private readonly ConcurrentDictionary<string, object?> _extra = new ConcurrentDictionary<string, object>();

		private readonly ConcurrentDictionary<string, string> _tags = new ConcurrentDictionary<string, string>();

		private ConcurrentBag<ISpan> _spans = new ConcurrentBag<ISpan>();

		private readonly ConcurrentDictionary<string, Measurement> _measurements = new ConcurrentDictionary<string, Measurement>();

		private readonly Lazy<MetricsSummaryAggregator> _metricsSummary = new Lazy<MetricsSummaryAggregator>();

		private readonly LastActiveSpanTracker _activeSpanTracker = new LastActiveSpanTracker();

		bool IBaseTracer.IsOtelInstrumenter => _instrumenter == Instrumenter.OpenTelemetry;

		public SpanId SpanId
		{
			get
			{
				return Contexts.Trace.SpanId;
			}
			private set
			{
				Contexts.Trace.SpanId = value;
			}
		}

		public SpanId? ParentSpanId { get; }

		public SentryId TraceId
		{
			get
			{
				return Contexts.Trace.TraceId;
			}
			private set
			{
				Contexts.Trace.TraceId = value;
			}
		}

		public string Name { get; set; }

		public TransactionNameSource NameSource { get; set; }

		public bool? IsParentSampled { get; set; }

		public string? Platform { get; set; } = "csharp";

		public string? Release { get; set; }

		public string? Distribution { get; set; }

		public DateTimeOffset StartTimestamp { get; internal set; }

		public DateTimeOffset? EndTimestamp { get; internal set; }

		public string Operation
		{
			get
			{
				return Contexts.Trace.Operation;
			}
			set
			{
				Contexts.Trace.Operation = value;
			}
		}

		public string? Description { get; set; }

		public SpanStatus? Status
		{
			get
			{
				return Contexts.Trace.Status;
			}
			set
			{
				Contexts.Trace.Status = value;
			}
		}

		public bool? IsSampled
		{
			get
			{
				return Contexts.Trace.IsSampled;
			}
			internal set
			{
				Contexts.Trace.IsSampled = value;
				if (!SampleRate.HasValue)
				{
					double? num = (SampleRate = ((!value.HasValue) ? ((double?)null) : new double?(value.Value ? 1.0 : 0.0)));
				}
			}
		}

		public double? SampleRate { get; internal set; }

		public SentryLevel? Level { get; set; }

		public SentryRequest Request
		{
			get
			{
				return _request ?? (_request = new SentryRequest());
			}
			set
			{
				_request = value;
			}
		}

		public SentryContexts Contexts
		{
			get
			{
				return _contexts;
			}
			set
			{
				_contexts.ReplaceWith(value);
			}
		}

		public SentryUser User
		{
			get
			{
				return _user ?? (_user = new SentryUser());
			}
			set
			{
				_user = value;
			}
		}

		public string? Environment { get; set; }

		string? IEventLike.TransactionName
		{
			get
			{
				return Name;
			}
			set
			{
				Name = value ?? "";
			}
		}

		public SdkVersion Sdk { get; internal set; } = new SdkVersion();

		public IReadOnlyList<string> Fingerprint
		{
			get
			{
				return _fingerprint ?? Array.Empty<string>();
			}
			set
			{
				_fingerprint = value;
			}
		}

		public IReadOnlyCollection<Breadcrumb> Breadcrumbs => _breadcrumbs;

		public IReadOnlyDictionary<string, object?> Extra => _extra;

		public IReadOnlyDictionary<string, string> Tags => _tags;

		public IReadOnlyCollection<ISpan> Spans => _spans;

		public IReadOnlyDictionary<string, Measurement> Measurements => _measurements;

		internal MetricsSummaryAggregator MetricsSummary => _metricsSummary.Value;

		internal bool HasMetrics => _metricsSummary.IsValueCreated;

		public bool IsFinished => EndTimestamp.HasValue;

		internal DynamicSamplingContext? DynamicSamplingContext { get; set; }

		internal ITransactionProfiler? TransactionProfiler { get; set; }

		internal bool IsSentryRequest { get; set; }

		public string? Origin
		{
			get
			{
				return Contexts.Trace.Origin;
			}
			internal set
			{
				Contexts.Trace.Origin = value;
			}
		}

		public TransactionTracer(IHub hub, ITransactionContext context)
			: this(hub, context, null)
		{
		}

		internal TransactionTracer(IHub hub, string name, string operation, TransactionNameSource nameSource = TransactionNameSource.Custom)
		{
			_hub = hub;
			_options = _hub.GetSentryOptions();
			Name = name;
			NameSource = nameSource;
			SpanId = SpanId.Create();
			TraceId = SentryId.Create();
			Operation = operation;
			StartTimestamp = _stopwatch.StartDateTimeOffset;
		}

		internal TransactionTracer(IHub hub, ITransactionContext context, TimeSpan? idleTimeout = null)
		{
			_hub = hub;
			_options = _hub.GetSentryOptions();
			Name = context.Name;
			NameSource = context.NameSource;
			Operation = context.Operation;
			SpanId = context.SpanId;
			ParentSpanId = context.ParentSpanId;
			TraceId = context.TraceId;
			Description = context.Description;
			Status = context.Status;
			IsSampled = context.IsSampled;
			StartTimestamp = _stopwatch.StartDateTimeOffset;
			if (context is TransactionContext transactionContext)
			{
				_instrumenter = transactionContext.Instrumenter;
				Origin = transactionContext.Origin;
			}
			if (!idleTimeout.HasValue)
			{
				return;
			}
			_cancelIdleTimeout = 1L;
			_idleTimer = new Timer(delegate(object state)
			{
				if (!(state is TransactionTracer transactionTracer))
				{
					_options?.LogDebug("Idle timeout callback received nor non-TransactionTracer state. Unable to finish transaction automatically.");
				}
				else
				{
					transactionTracer.Finish(Status.GetValueOrDefault());
				}
			}, this, idleTimeout.Value, Timeout.InfiniteTimeSpan);
		}

		public void AddBreadcrumb(Breadcrumb breadcrumb)
		{
			_breadcrumbs.Add(breadcrumb);
		}

		public void SetExtra(string key, object? value)
		{
			_extra[key] = value;
		}

		public void SetTag(string key, string value)
		{
			_tags[key] = value;
		}

		public void UnsetTag(string key)
		{
			_tags.TryRemove(key, out string _);
		}

		public void SetMeasurement(string name, Measurement measurement)
		{
			_measurements[name] = measurement;
		}

		public ISpan StartChild(string operation)
		{
			return StartChild(null, SpanId, operation);
		}

		internal ISpan StartChild(SpanId? spanId, SpanId parentSpanId, string operation, Instrumenter instrumenter = Instrumenter.Sentry)
		{
			SpanTracer spanTracer = new SpanTracer(_hub, this, SpanId.Create(), parentSpanId, TraceId, operation, instrumenter);
			if (spanId.HasValue)
			{
				SpanId valueOrDefault = spanId.GetValueOrDefault();
				spanTracer.SpanId = valueOrDefault;
			}
			AddChildSpan(spanTracer);
			return spanTracer;
		}

		private void AddChildSpan(SpanTracer span)
		{
			bool flag = _spans.Count >= 1000;
			span.IsSampled = (flag ? new bool?(false) : IsSampled);
			if (!flag)
			{
				_spans.Add(span);
				_activeSpanTracker.Push(span);
			}
		}

		public ISpan? GetLastActiveSpan()
		{
			return _activeSpanTracker.PeekActive();
		}

		public void Finish()
		{
			_options?.LogDebug("Attempting to finish Transaction {0}.", SpanId);
			if (Interlocked.Exchange(ref _cancelIdleTimeout, 0L) == 1)
			{
				_options?.LogDebug("Disposing of idle timer for Transaction {0}.", SpanId);
				_idleTimer?.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
				_idleTimer?.Dispose();
			}
			if (IsSentryRequest)
			{
				_options?.LogDebug("Transaction {0} is a Sentry Request. Don't complete.", SpanId);
				return;
			}
			TransactionProfiler?.Finish();
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
			_options?.LogDebug("Finished Transaction {0}.", SpanId);
			_hub.ConfigureScope(delegate(Scope scope)
			{
				scope.ResetTransaction(this);
			});
			_hub.CaptureTransaction(new SentryTransaction(this));
			ReleaseSpans();
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

		private void ReleaseSpans()
		{
			_spans = new ConcurrentBag<ISpan>();
			_activeSpanTracker.Clear();
		}
	}
}
