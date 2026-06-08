using Amazon.Runtime.Telemetry.Metrics.NoOp;
using Amazon.Runtime.Telemetry.Tracing.NoOp;

namespace Amazon.Runtime.Telemetry
{
	public class DefaultTelemetryProvider : TelemetryProvider
	{
		public DefaultTelemetryProvider()
			: base(new NoOpMeterProvider(), new NoOpTracerProvider())
		{
		}
	}
}
