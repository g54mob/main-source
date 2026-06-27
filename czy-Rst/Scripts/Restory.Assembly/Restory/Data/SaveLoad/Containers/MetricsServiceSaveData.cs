using Restory.Data.Metrics;

namespace Restory.Data.SaveLoad.Containers
{
	public class MetricsServiceSaveData
	{
		public struct MetricProgressSaveData
		{
			public MetricInfo Metric;

			public int Points;
		}

		public MetricProgressSaveData[] Progress;
	}
}
