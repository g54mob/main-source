using System;
using Amazon.Util;

namespace Amazon.Runtime.Telemetry.Metrics
{
	internal static class MetricsUtilities
	{
		private class DurationMetricsMeasurer : IDisposable
		{
			private readonly Histogram<double> _histogram;

			private readonly Attributes _attributes;

			private readonly DateTime _startTime;

			public DurationMetricsMeasurer(Meter meter, string metricName, Attributes attributes)
			{
				_histogram = meter.CreateHistogram<double>(metricName, "s");
				_attributes = attributes;
				_startTime = AWSSDKUtils.CorrectedUtcNow;
			}

			public void Dispose()
			{
				double value = (double)(AWSSDKUtils.CorrectedUtcNow - _startTime).Ticks / 10000000.0;
				_histogram.Record(value, _attributes);
			}
		}

		public static void RecordError(IRequestContext requestContext, Exception exception)
		{
			Attributes attributes = new Attributes();
			attributes.Set("exception.type", exception.GetType().Name);
			AddMonotonicCounterValue(requestContext, "client.call.errors", "{error}", 1L, attributes);
		}

		public static void AddMonotonicCounterValue(IRequestContext requestContext, string metricName, string unit, long value = 1L, Attributes initialAttributes = null)
		{
			string serviceId = requestContext.ClientConfig.ServiceId;
			if (initialAttributes == null)
			{
				initialAttributes = new Attributes();
			}
			string value2 = AWSSDKUtils.ExtractOperationName(requestContext.RequestName);
			initialAttributes.Set("rpc.method", value2);
			initialAttributes.Set("rpc.system", "aws-api");
			initialAttributes.Set("rpc.service", serviceId);
			string scope = "AWSSDK." + serviceId;
			requestContext.ClientConfig.TelemetryProvider.MeterProvider.GetMeter(scope).CreateMonotonicCounter<long>(metricName, unit).Add(value, initialAttributes);
		}

		public static IDisposable MeasureDuration(IRequestContext requestContext, string metricName, Attributes initialAttributes = null)
		{
			if (initialAttributes == null)
			{
				initialAttributes = new Attributes();
			}
			string value = AWSSDKUtils.ExtractOperationName(requestContext.RequestName);
			initialAttributes.Set("rpc.method", value);
			return MeasureDuration(requestContext.ClientConfig, metricName, initialAttributes);
		}

		public static IDisposable MeasureDuration(IClientConfig config, string metricName, Attributes attributes = null)
		{
			string serviceId = config.ServiceId;
			if (attributes == null)
			{
				attributes = new Attributes();
			}
			attributes.Set("rpc.service", serviceId);
			attributes.Set("rpc.system", "aws-api");
			string scope = "AWSSDK." + serviceId;
			return new DurationMetricsMeasurer(config.TelemetryProvider.MeterProvider.GetMeter(scope), metricName, attributes);
		}
	}
}
