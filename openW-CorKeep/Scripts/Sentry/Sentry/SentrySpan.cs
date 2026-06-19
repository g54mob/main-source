using System;
using System.Collections.Generic;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Internal.Extensions;
using Sentry.Protocol;
using Sentry.Protocol.Metrics;

namespace Sentry
{
	public class SentrySpan : ISpanData, ITraceContext, IHasTags, IHasExtra, ISentryJsonSerializable, ITraceContextInternal
	{
		private Dictionary<string, Measurement>? _measurements;

		private Dictionary<string, string>? _tags;

		private Dictionary<string, object?>? _extra;

		private readonly MetricsSummary? _metricsSummary;

		private string? _origin;

		public SpanId SpanId { get; private set; }

		public SpanId? ParentSpanId { get; private set; }

		public SentryId TraceId { get; private set; }

		public DateTimeOffset StartTimestamp { get; private set; } = DateTimeOffset.UtcNow;

		public DateTimeOffset? EndTimestamp { get; private set; }

		public bool IsFinished => EndTimestamp.HasValue;

		public IReadOnlyDictionary<string, Measurement> Measurements => _measurements ?? (_measurements = new Dictionary<string, Measurement>());

		public string Operation { get; set; }

		public string? Description { get; set; }

		public SpanStatus? Status { get; set; }

		public bool? IsSampled { get; internal set; }

		public IReadOnlyDictionary<string, string> Tags => _tags ?? (_tags = new Dictionary<string, string>());

		public IReadOnlyDictionary<string, object?> Extra => _extra ?? (_extra = new Dictionary<string, object>());

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
			(_measurements ?? (_measurements = new Dictionary<string, Measurement>()))[name] = measurement;
		}

		public void SetTag(string key, string value)
		{
			(_tags ?? (_tags = new Dictionary<string, string>()))[key] = value;
		}

		public void UnsetTag(string key)
		{
			(_tags ?? (_tags = new Dictionary<string, string>())).Remove(key);
		}

		public void SetExtra(string key, object? value)
		{
			(_extra ?? (_extra = new Dictionary<string, object>()))[key] = value;
		}

		public SentrySpan(SpanId? parentSpanId, string operation)
		{
			SpanId = SpanId.Create();
			ParentSpanId = parentSpanId;
			TraceId = SentryId.Create();
			Operation = operation;
		}

		public SentrySpan(ISpan tracer)
			: this(tracer.ParentSpanId, tracer.Operation)
		{
			SpanId = tracer.SpanId;
			TraceId = tracer.TraceId;
			StartTimestamp = tracer.StartTimestamp;
			EndTimestamp = tracer.EndTimestamp;
			Description = tracer.Description;
			Status = tracer.Status;
			IsSampled = tracer.IsSampled;
			_extra = tracer.Extra.ToDict();
			if (tracer is SpanTracer spanTracer)
			{
				_measurements = spanTracer.InternalMeasurements?.ToDict();
				_tags = spanTracer.InternalTags?.ToDict();
				if (spanTracer.HasMetrics)
				{
					_metricsSummary = new MetricsSummary(spanTracer.MetricsSummary);
				}
			}
			else
			{
				_measurements = tracer.Measurements.ToDict();
				_tags = tracer.Tags.ToDict();
			}
		}

		public SentryTraceHeader GetTraceHeader()
		{
			return new SentryTraceHeader(TraceId, SpanId, IsSampled);
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteSerializable("span_id", SpanId, logger);
			writer.WriteSerializableIfNotNull("parent_span_id", ParentSpanId, logger);
			writer.WriteSerializable("trace_id", TraceId, logger);
			writer.WriteStringIfNotWhiteSpace("op", Operation);
			writer.WriteStringIfNotWhiteSpace("description", Description);
			writer.WriteStringIfNotWhiteSpace("status", Status?.ToString().ToSnakeCase());
			writer.WriteString("start_timestamp", StartTimestamp);
			writer.WriteStringIfNotNull("timestamp", EndTimestamp);
			writer.WriteStringDictionaryIfNotEmpty("tags", _tags);
			writer.WriteDictionaryIfNotEmpty("data", _extra, logger);
			writer.WriteDictionaryIfNotEmpty("measurements", _measurements, logger);
			writer.WriteSerializableIfNotNull("_metrics_summary", _metricsSummary, logger);
			writer.WriteEndObject();
		}

		public static SentrySpan FromJson(JsonElement json)
		{
			SpanId spanId = json.GetPropertyOrNull("span_id")?.Pipe(SpanId.FromJson) ?? SpanId.Empty;
			SpanId? parentSpanId = json.GetPropertyOrNull("parent_span_id")?.Pipe(SpanId.FromJson);
			SentryId traceId = json.GetPropertyOrNull("trace_id")?.Pipe(SentryId.FromJson) ?? SentryId.Empty;
			DateTimeOffset dateTimeOffset = json.GetProperty("start_timestamp").GetDateTimeOffset();
			DateTimeOffset? endTimestamp = json.GetPropertyOrNull("timestamp")?.GetDateTimeOffset();
			string operation = json.GetPropertyOrNull("op")?.GetString() ?? "unknown";
			string description = json.GetPropertyOrNull("description")?.GetString();
			SpanStatus? status = json.GetPropertyOrNull("status")?.GetString()?.Replace("_", "").ParseEnum<SpanStatus>();
			bool? isSampled = json.GetPropertyOrNull("sampled")?.GetBoolean();
			Dictionary<string, string> tags = json.GetPropertyOrNull("tags")?.GetStringDictionaryOrNull()?.ToDict();
			Dictionary<string, Measurement> measurements = json.GetPropertyOrNull("measurements")?.GetDictionaryOrNull(Measurement.FromJson);
			Dictionary<string, object> extra = json.GetPropertyOrNull("data")?.GetDictionaryOrNull()?.ToDict();
			return new SentrySpan(parentSpanId, operation)
			{
				SpanId = spanId,
				TraceId = traceId,
				StartTimestamp = dateTimeOffset,
				EndTimestamp = endTimestamp,
				Description = description,
				Status = status,
				IsSampled = isSampled,
				_tags = tags,
				_extra = extra,
				_measurements = measurements
			};
		}

		internal void Redact()
		{
			Description = Description?.RedactUrl();
		}
	}
}
