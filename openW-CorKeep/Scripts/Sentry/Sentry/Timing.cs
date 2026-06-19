using System;
using System.Collections.Generic;
using System.Diagnostics;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Protocol.Metrics;

namespace Sentry
{
	internal class Timing : IDisposable
	{
		internal const string OperationName = "metric.timing";

		public const string MetricsOrigin = "auto.metrics";

		private readonly SentryOptions _options;

		private readonly MetricAggregator _metricAggregator;

		private readonly string _key;

		private readonly MeasurementUnit.Duration _unit;

		private readonly IDictionary<string, string>? _tags;

		internal readonly Stopwatch _stopwatch = new Stopwatch();

		private readonly ISpan _span;

		internal readonly DateTime _startTime = DateTime.UtcNow;

		internal Timing(MetricAggregator metricAggregator, IMetricHub metricHub, SentryOptions options, string key, MeasurementUnit.Duration unit, IDictionary<string, string>? tags, int stackLevel)
		{
			_options = options;
			_metricAggregator = metricAggregator;
			_key = key;
			_unit = unit;
			_tags = tags;
			_stopwatch.Start();
			_span = metricHub.StartSpan("metric.timing", key);
			_span.SetOrigin("auto.metrics");
			if (tags != null)
			{
				_span.SetTags(tags);
			}
			_metricAggregator.RecordCodeLocation(MetricType.Distribution, key, unit, stackLevel + 1, _startTime);
		}

		public void Dispose()
		{
			_stopwatch.Stop();
			DisposeInternal(_stopwatch.Elapsed);
		}

		internal void DisposeInternal(TimeSpan elapsed)
		{
			try
			{
				double value = _unit switch
				{
					MeasurementUnit.Duration.Week => elapsed.TotalDays / 7.0, 
					MeasurementUnit.Duration.Day => elapsed.TotalDays, 
					MeasurementUnit.Duration.Hour => elapsed.TotalHours, 
					MeasurementUnit.Duration.Minute => elapsed.TotalMinutes, 
					MeasurementUnit.Duration.Second => elapsed.TotalSeconds, 
					MeasurementUnit.Duration.Millisecond => elapsed.TotalMilliseconds, 
					MeasurementUnit.Duration.Microsecond => elapsed.TotalMilliseconds * 1000.0, 
					MeasurementUnit.Duration.Nanosecond => elapsed.TotalMilliseconds * 1000000.0, 
					_ => throw new ArgumentOutOfRangeException("_unit", _unit, null), 
				};
				_metricAggregator.Timing(_key, value, _unit, _tags, _startTime);
			}
			catch (Exception exception)
			{
				_options.LogError(exception, "Error capturing timing '{0}'", _key);
			}
			finally
			{
				_span?.Finish();
			}
		}
	}
}
