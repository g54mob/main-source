using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Internal.Extensions;
using Sentry.Protocol;
using Sentry.Protocol.Metrics;

namespace Sentry
{
	public class SentryTransaction : ITransactionData, ISpanData, ITraceContext, IHasTags, IHasExtra, ITransactionContext, IEventLike, ISentryJsonSerializable, ITraceContextInternal
	{
		private Dictionary<string, Measurement>? _measurements;

		private SentryRequest? _request;

		private readonly SentryContexts _contexts = new SentryContexts();

		private SentryUser? _user;

		private IReadOnlyList<string>? _fingerprint;

		private List<Breadcrumb> _breadcrumbs = new List<Breadcrumb>();

		private Dictionary<string, object?> _extra = new Dictionary<string, object>();

		private Dictionary<string, string> _tags = new Dictionary<string, string>();

		private SentrySpan[] _spans = Array.Empty<SentrySpan>();

		private readonly MetricsSummary? _metricsSummary;

		public SentryId EventId { get; private set; }

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

		public string? Origin
		{
			get
			{
				return Contexts.Trace.Origin;
			}
			private set
			{
				Contexts.Trace.Origin = value;
			}
		}

		public SpanId? ParentSpanId
		{
			get
			{
				return Contexts.Trace.ParentSpanId;
			}
			private set
			{
				Contexts.Trace.ParentSpanId = value;
			}
		}

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

		public string Name { get; private set; }

		public TransactionNameSource NameSource { get; }

		public bool? IsParentSampled { get; set; }

		public string? Platform { get; set; } = "csharp";

		public string? Release { get; set; }

		public string? Distribution { get; set; }

		public DateTimeOffset StartTimestamp { get; private set; } = DateTimeOffset.UtcNow;

		public DateTimeOffset? EndTimestamp { get; internal set; }

		public IReadOnlyDictionary<string, Measurement> Measurements => _measurements ?? (_measurements = new Dictionary<string, Measurement>());

		public string Operation
		{
			get
			{
				return Contexts.Trace.Operation;
			}
			private set
			{
				Contexts.Trace.Operation = value;
			}
		}

		public string? Description
		{
			get
			{
				return Contexts.Trace.Description;
			}
			set
			{
				Contexts.Trace.Description = value;
			}
		}

		public SpanStatus? Status
		{
			get
			{
				return Contexts.Trace.Status;
			}
			private set
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

		public IReadOnlyCollection<SentrySpan> Spans => _spans;

		public bool IsFinished => EndTimestamp.HasValue;

		internal DynamicSamplingContext? DynamicSamplingContext { get; set; }

		internal ITransactionProfiler? TransactionProfiler { get; set; }

		public void SetMeasurement(string name, Measurement measurement)
		{
			(_measurements ?? (_measurements = new Dictionary<string, Measurement>()))[name] = measurement;
		}

		private SentryTransaction(string name, TransactionNameSource nameSource)
		{
			EventId = SentryId.Create();
			Name = name;
			NameSource = nameSource;
		}

		public SentryTransaction(string name, string operation)
			: this(name, TransactionNameSource.Custom)
		{
			SpanId = SpanId.Create();
			TraceId = SentryId.Create();
			Operation = operation;
		}

		public SentryTransaction(string name, string operation, TransactionNameSource nameSource)
			: this(name, nameSource)
		{
			SpanId = SpanId.Create();
			TraceId = SentryId.Create();
			Operation = operation;
		}

		public SentryTransaction(ITransactionTracer tracer)
			: this(tracer.Name, tracer.NameSource)
		{
			Contexts = tracer.Contexts;
			ParentSpanId = tracer.ParentSpanId;
			SpanId = tracer.SpanId;
			TraceId = tracer.TraceId;
			Operation = tracer.Operation;
			Platform = tracer.Platform;
			Release = tracer.Release;
			Distribution = tracer.Distribution;
			StartTimestamp = tracer.StartTimestamp;
			EndTimestamp = tracer.EndTimestamp;
			Description = tracer.Description;
			Status = tracer.Status;
			IsSampled = tracer.IsSampled;
			Level = tracer.Level;
			Request = tracer.Request;
			User = tracer.User;
			Environment = tracer.Environment;
			Sdk = tracer.Sdk;
			Fingerprint = tracer.Fingerprint;
			_breadcrumbs = tracer.Breadcrumbs.ToList();
			_extra = tracer.Extra.ToDict();
			_tags = tracer.Tags.ToDict();
			_spans = FromTracerSpans(tracer);
			_measurements = tracer.Measurements.ToDict();
			if (tracer is TransactionTracer transactionTracer)
			{
				SampleRate = transactionTracer.SampleRate;
				DynamicSamplingContext = transactionTracer.DynamicSamplingContext;
				TransactionProfiler = transactionTracer.TransactionProfiler;
				if (transactionTracer.HasMetrics)
				{
					_metricsSummary = new MetricsSummary(transactionTracer.MetricsSummary);
				}
			}
		}

		internal static SentrySpan[] FromTracerSpans(ITransactionTracer tracer)
		{
			IEnumerable<ISpan> source = tracer.Spans.Where((ISpan s) => !(s is SpanTracer spanTracer3) || !spanTracer3.IsSentryRequest);
			if (!(tracer is IBaseTracer { IsOtelInstrumenter: not false }))
			{
				return source.Select((ISpan s) => new SentrySpan(s)).ToArray();
			}
			Dictionary<SpanId, SpanId?> dictionary = new Dictionary<SpanId, SpanId?>();
			List<ISpan> list = source.ToList();
			ISpan[] array = list.ToArray();
			for (int num = 0; num < array.Length; num++)
			{
				if (array[num] is SpanTracer spanTracer)
				{
					Func<bool>? isFiltered = spanTracer.IsFiltered;
					if (isFiltered != null && isFiltered())
					{
						dictionary.Add(spanTracer.SpanId, spanTracer.ParentSpanId);
						list.Remove(spanTracer);
					}
				}
			}
			foreach (ISpan item in list)
			{
				if (item is SpanTracer spanTracer2)
				{
					SpanId? value;
					while (spanTracer2.ParentSpanId.HasValue && dictionary.TryGetValue(spanTracer2.ParentSpanId.Value, out value))
					{
						spanTracer2.ParentSpanId = value;
					}
				}
			}
			return list.Select((ISpan s) => new SentrySpan(s)).ToArray();
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
			_tags.Remove(key);
		}

		public SentryTraceHeader GetTraceHeader()
		{
			return new SentryTraceHeader(TraceId, SpanId, IsSampled);
		}

		internal void Redact()
		{
			Description = Description?.RedactUrl();
			foreach (Breadcrumb breadcrumb in Breadcrumbs)
			{
				breadcrumb.Redact();
			}
			foreach (SentrySpan span in Spans)
			{
				span.Redact();
			}
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteString("type", "transaction");
			writer.WriteSerializable("event_id", EventId, logger);
			writer.WriteStringIfNotWhiteSpace("level", Level?.ToString().ToLowerInvariant());
			writer.WriteStringIfNotWhiteSpace("platform", Platform);
			writer.WriteStringIfNotWhiteSpace("release", Release);
			writer.WriteStringIfNotWhiteSpace("dist", Distribution);
			writer.WriteStringIfNotWhiteSpace("transaction", Name);
			writer.WritePropertyName("transaction_info");
			writer.WriteStartObject();
			writer.WritePropertyName("source");
			writer.WriteStringValue(NameSource.ToString().ToLowerInvariant());
			writer.WriteEndObject();
			writer.WriteString("start_timestamp", StartTimestamp);
			writer.WriteStringIfNotNull("timestamp", EndTimestamp);
			writer.WriteSerializableIfNotNull("request", _request, logger);
			writer.WriteSerializableIfNotNull("contexts", _contexts.NullIfEmpty(), logger);
			writer.WriteSerializableIfNotNull("user", _user, logger);
			writer.WriteStringIfNotWhiteSpace("environment", Environment);
			writer.WriteSerializable("sdk", Sdk, logger);
			writer.WriteStringArrayIfNotEmpty("fingerprint", _fingerprint);
			writer.WriteArrayIfNotEmpty("breadcrumbs", _breadcrumbs, logger);
			writer.WriteDictionaryIfNotEmpty("extra", _extra, logger);
			writer.WriteStringDictionaryIfNotEmpty("tags", _tags);
			writer.WriteArrayIfNotEmpty("spans", _spans, logger);
			writer.WriteDictionaryIfNotEmpty("measurements", _measurements, logger);
			writer.WriteSerializableIfNotNull("_metrics_summary", _metricsSummary, logger);
			writer.WriteEndObject();
		}

		public static SentryTransaction FromJson(JsonElement json)
		{
			SentryId eventId = json.GetPropertyOrNull("event_id")?.Pipe(SentryId.FromJson) ?? SentryId.Empty;
			string stringOrThrow = json.GetProperty("transaction").GetStringOrThrow();
			TransactionNameSource valueOrDefault = (json.GetPropertyOrNull("transaction_info")?.GetPropertyOrNull("source")?.GetString()?.ParseEnum<TransactionNameSource>()).GetValueOrDefault();
			DateTimeOffset dateTimeOffset = json.GetProperty("start_timestamp").GetDateTimeOffset();
			DateTimeOffset? endTimestamp = json.GetPropertyOrNull("timestamp")?.GetDateTimeOffset();
			SentryLevel? level = json.GetPropertyOrNull("level")?.GetString()?.ParseEnum<SentryLevel>();
			string platform = json.GetPropertyOrNull("platform")?.GetString();
			string release = json.GetPropertyOrNull("release")?.GetString();
			string distribution = json.GetPropertyOrNull("dist")?.GetString();
			SentryRequest request = json.GetPropertyOrNull("request")?.Pipe(SentryRequest.FromJson);
			SentryContexts contexts = json.GetPropertyOrNull("contexts")?.Pipe(SentryContexts.FromJson) ?? new SentryContexts();
			SentryUser user = json.GetPropertyOrNull("user")?.Pipe(SentryUser.FromJson);
			string environment = json.GetPropertyOrNull("environment")?.GetString();
			SdkVersion sdk = json.GetPropertyOrNull("sdk")?.Pipe(SdkVersion.FromJson) ?? new SdkVersion();
			JsonElement? propertyOrNull = json.GetPropertyOrNull("fingerprint");
			string[] fingerprint = (propertyOrNull.HasValue ? (from j in propertyOrNull.GetValueOrDefault().EnumerateArray()
				select j.GetString()).ToArray() : null);
			propertyOrNull = json.GetPropertyOrNull("breadcrumbs");
			List<Breadcrumb> breadcrumbs = (propertyOrNull.HasValue ? propertyOrNull.GetValueOrDefault().EnumerateArray().Select(Breadcrumb.FromJson)
				.ToList() : null) ?? new List<Breadcrumb>();
			Dictionary<string, object> extra = json.GetPropertyOrNull("extra")?.GetDictionaryOrNull() ?? new Dictionary<string, object>();
			Dictionary<string, string> tags = json.GetPropertyOrNull("tags")?.GetStringDictionaryOrNull()?.WhereNotNullValue().ToDict() ?? new Dictionary<string, string>();
			Dictionary<string, Measurement> measurements = json.GetPropertyOrNull("measurements")?.GetDictionaryOrNull(Measurement.FromJson) ?? new Dictionary<string, Measurement>();
			propertyOrNull = json.GetPropertyOrNull("spans");
			SentrySpan[] spans = (propertyOrNull.HasValue ? propertyOrNull.GetValueOrDefault().EnumerateArray().Select(SentrySpan.FromJson)
				.ToArray() : null) ?? Array.Empty<SentrySpan>();
			return new SentryTransaction(stringOrThrow, valueOrDefault)
			{
				EventId = eventId,
				StartTimestamp = dateTimeOffset,
				EndTimestamp = endTimestamp,
				Level = level,
				Platform = platform,
				Release = release,
				Distribution = distribution,
				_request = request,
				Contexts = contexts,
				_user = user,
				Environment = environment,
				Sdk = sdk,
				_fingerprint = fingerprint,
				_breadcrumbs = breadcrumbs,
				_extra = extra,
				_tags = tags,
				_measurements = measurements,
				_spans = spans
			};
		}
	}
}
