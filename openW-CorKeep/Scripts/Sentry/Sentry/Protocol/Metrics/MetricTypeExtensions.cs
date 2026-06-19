using System;

namespace Sentry.Protocol.Metrics
{
	internal static class MetricTypeExtensions
	{
		internal static string ToStatsdType(this MetricType type)
		{
			return type switch
			{
				MetricType.Counter => "c", 
				MetricType.Gauge => "g", 
				MetricType.Distribution => "d", 
				MetricType.Set => "s", 
				_ => throw new ArgumentOutOfRangeException("type", type, null), 
			};
		}
	}
}
