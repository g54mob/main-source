using System;
using Amazon.Runtime.Telemetry.Metrics;
using Amazon.Runtime.Telemetry.Tracing;

namespace Amazon.Runtime.Telemetry
{
	public abstract class TelemetryProvider
	{
		public MeterProvider MeterProvider { get; private set; }

		public TracerProvider TracerProvider { get; private set; }

		public TelemetryProvider(MeterProvider meterProvider, TracerProvider tracerProvider)
		{
			if (meterProvider == null)
			{
				throw new ArgumentNullException("meterProvider");
			}
			MeterProvider = meterProvider;
			if (tracerProvider == null)
			{
				throw new ArgumentNullException("tracerProvider");
			}
			TracerProvider = tracerProvider;
		}

		public virtual void RegisterMeterProvider(MeterProvider meterProvider)
		{
			if (meterProvider == null)
			{
				throw new ArgumentNullException("meterProvider");
			}
			MeterProvider = meterProvider;
		}

		public virtual void RegisterTracerProvider(TracerProvider tracerProvider)
		{
			if (tracerProvider == null)
			{
				throw new ArgumentNullException("tracerProvider");
			}
			TracerProvider = tracerProvider;
		}
	}
}
