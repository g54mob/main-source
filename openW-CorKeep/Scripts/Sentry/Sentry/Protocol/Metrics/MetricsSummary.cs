using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.Json;
using Sentry.Extensibility;

namespace Sentry.Protocol.Metrics
{
	internal class MetricsSummary : ISentryJsonSerializable
	{
		private readonly IDictionary<string, List<SpanMetric>> _measurements;

		public MetricsSummary(MetricsSummaryAggregator aggregator)
		{
			Dictionary<string, List<SpanMetric>> dictionary = new Dictionary<string, List<SpanMetric>>();
			foreach (KeyValuePair<string, SpanMetric> measurement in aggregator.Measurements)
			{
				PolyfillExtensions.Deconstruct(measurement, out var _, out var value);
				SpanMetric spanMetric = value;
				string exportKey = spanMetric.ExportKey;
				if (!dictionary.ContainsKey(exportKey))
				{
					dictionary.Add(exportKey, new List<SpanMetric>());
				}
				dictionary[exportKey].Add(spanMetric);
			}
			_measurements = dictionary.ToImmutableSortedDictionary();
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			foreach (var (propertyName, source) in _measurements)
			{
				writer.WritePropertyName(propertyName);
				writer.WriteStartArray();
				foreach (SpanMetric item in source.OrderBy((SpanMetric x) => MetricHelper.GetMetricBucketKey(x.MetricType, x.Key, x.Unit, x.Tags)))
				{
					item.WriteTo(writer, logger);
				}
				writer.WriteEndArray();
			}
			writer.WriteEndObject();
		}
	}
}
