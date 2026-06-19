using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Sentry.Protocol.Metrics;

namespace Sentry
{
	internal class MetricsSummaryAggregator
	{
		private Lazy<ConcurrentDictionary<string, SpanMetric>> LazyMeasurements { get; } = new Lazy<ConcurrentDictionary<string, SpanMetric>>();

		internal ConcurrentDictionary<string, SpanMetric> Measurements => LazyMeasurements.Value;

		public void Add(MetricType ty, string key, double value = 1.0, MeasurementUnit? unit = null, IDictionary<string, string>? tags = null)
		{
			MeasurementUnit valueOrDefault = unit.GetValueOrDefault();
			if (!unit.HasValue)
			{
				valueOrDefault = MeasurementUnit.None;
				unit = valueOrDefault;
			}
			string metricBucketKey = MetricHelper.GetMetricBucketKey(ty, key, unit.Value, tags);
			Measurements.AddOrUpdate(metricBucketKey, (string _) => new SpanMetric(ty, key, value, unit.Value, tags), delegate(string _, SpanMetric metric)
			{
				lock (metric)
				{
					metric.Add(value);
					return metric;
				}
			});
		}
	}
}
