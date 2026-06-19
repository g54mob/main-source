namespace Sentry.Protocol.Metrics
{
	internal enum MetricType : byte
	{
		Counter = 0,
		Gauge = 1,
		Distribution = 2,
		Set = 3
	}
}
