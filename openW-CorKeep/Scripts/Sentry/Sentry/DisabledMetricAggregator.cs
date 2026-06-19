using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sentry
{
	internal class DisabledMetricAggregator : IMetricAggregator, IDisposable
	{
		public void Increment(string key, double value = 1.0, MeasurementUnit? unit = null, IDictionary<string, string>? tags = null, DateTimeOffset? timestamp = null, int stackLevel = 1)
		{
		}

		public void Gauge(string key, double value = 1.0, MeasurementUnit? unit = null, IDictionary<string, string>? tags = null, DateTimeOffset? timestamp = null, int stackLevel = 1)
		{
		}

		public void Distribution(string key, double value = 1.0, MeasurementUnit? unit = null, IDictionary<string, string>? tags = null, DateTimeOffset? timestamp = null, int stackLevel = 1)
		{
		}

		public void Set(string key, int value, MeasurementUnit? unit = null, IDictionary<string, string>? tags = null, DateTimeOffset? timestamp = null, int stackLevel = 1)
		{
		}

		public void Set(string key, string value, MeasurementUnit? unit = null, IDictionary<string, string>? tags = null, DateTimeOffset? timestamp = null, int stackLevel = 1)
		{
		}

		public void Timing(string key, double value, MeasurementUnit.Duration unit = MeasurementUnit.Duration.Second, IDictionary<string, string>? tags = null, DateTimeOffset? timestamp = null, int stackLevel = 1)
		{
		}

		public IDisposable StartTimer(string key, MeasurementUnit.Duration unit = MeasurementUnit.Duration.Second, IDictionary<string, string>? tags = null, int stackLevel = 1)
		{
			return NoOpDisposable.Instance;
		}

		public Task FlushAsync(bool force = true, CancellationToken cancellationToken = default(CancellationToken))
		{
			return Task.CompletedTask;
		}

		public void Dispose()
		{
		}
	}
}
