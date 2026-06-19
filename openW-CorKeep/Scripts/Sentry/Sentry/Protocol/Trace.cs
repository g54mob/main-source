using System;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Internal.Extensions;

namespace Sentry.Protocol
{
	public class Trace : ITraceContext, ITraceContextInternal, ISentryJsonSerializable, ICloneable<Trace>, IUpdatable<Trace>, IUpdatable
	{
		public const string Type = "trace";

		private string? _origin;

		public SpanId SpanId { get; set; }

		public SpanId? ParentSpanId { get; set; }

		public SentryId TraceId { get; set; }

		public string Operation { get; set; } = "";

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

		public string? Description { get; set; }

		public SpanStatus? Status { get; set; }

		public bool? IsSampled { get; internal set; }

		internal Trace Clone()
		{
			return ((ICloneable<Trace>)this).Clone();
		}

		Trace ICloneable<Trace>.Clone()
		{
			return new Trace
			{
				SpanId = SpanId,
				ParentSpanId = ParentSpanId,
				TraceId = TraceId,
				Operation = Operation,
				Origin = Origin,
				Status = Status,
				IsSampled = IsSampled
			};
		}

		internal void UpdateFrom(Trace source)
		{
			((IUpdatable<Trace>)this).UpdateFrom(source);
		}

		void IUpdatable.UpdateFrom(object source)
		{
			if (source is Trace source2)
			{
				((IUpdatable<Trace>)this).UpdateFrom(source2);
			}
		}

		void IUpdatable<Trace>.UpdateFrom(Trace source)
		{
			SpanId = ((SpanId == default(SpanId)) ? source.SpanId : SpanId);
			if (!ParentSpanId.HasValue)
			{
				SpanId? spanId = (ParentSpanId = source.ParentSpanId);
			}
			TraceId = ((TraceId == default(SentryId)) ? source.TraceId : TraceId);
			Operation = (string.IsNullOrWhiteSpace(Operation) ? source.Operation : Operation);
			if (!Status.HasValue)
			{
				SpanStatus? spanStatus = (Status = source.Status);
			}
			if (!IsSampled.HasValue)
			{
				bool? flag = (IsSampled = source.IsSampled);
			}
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteString("type", "trace");
			writer.WriteSerializableIfNotNull("span_id", SpanId.NullIfDefault(), logger);
			writer.WriteSerializableIfNotNull("parent_span_id", ParentSpanId?.NullIfDefault(), logger);
			writer.WriteSerializableIfNotNull("trace_id", TraceId.NullIfDefault(), logger);
			writer.WriteStringIfNotWhiteSpace("op", Operation);
			writer.WriteString("origin", Origin ?? "manual");
			writer.WriteStringIfNotWhiteSpace("description", Description);
			writer.WriteStringIfNotWhiteSpace("status", Status?.ToString().ToSnakeCase());
			writer.WriteEndObject();
		}

		public static Trace FromJson(JsonElement json)
		{
			SpanId spanId = json.GetPropertyOrNull("span_id")?.Pipe(SpanId.FromJson) ?? SpanId.Empty;
			SpanId? parentSpanId = json.GetPropertyOrNull("parent_span_id")?.Pipe(SpanId.FromJson);
			SentryId traceId = json.GetPropertyOrNull("trace_id")?.Pipe(SentryId.FromJson) ?? SentryId.Empty;
			string operation = json.GetPropertyOrNull("op")?.GetString() ?? "";
			string origin = OriginHelper.TryParse(json.GetPropertyOrNull("origin")?.GetString() ?? "");
			string description = json.GetPropertyOrNull("description")?.GetString();
			SpanStatus? status = json.GetPropertyOrNull("status")?.GetString()?.Replace("_", "").ParseEnum<SpanStatus>();
			bool? isSampled = json.GetPropertyOrNull("sampled")?.GetBoolean();
			return new Trace
			{
				SpanId = spanId,
				ParentSpanId = parentSpanId,
				TraceId = traceId,
				Operation = operation,
				Origin = origin,
				Description = description,
				Status = status,
				IsSampled = isSampled
			};
		}
	}
}
