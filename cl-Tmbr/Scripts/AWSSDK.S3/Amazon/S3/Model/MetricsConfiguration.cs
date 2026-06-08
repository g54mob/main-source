namespace Amazon.S3.Model
{
	public class MetricsConfiguration
	{
		private MetricsFilter metricsFilter;

		private string metricsId;

		public MetricsFilter MetricsFilter
		{
			get
			{
				return metricsFilter;
			}
			set
			{
				metricsFilter = value;
			}
		}

		public string MetricsId
		{
			get
			{
				return metricsId;
			}
			set
			{
				metricsId = value;
			}
		}

		internal bool IsSetMetricsFilter()
		{
			return metricsFilter != null;
		}

		internal bool IsSetMetricsId()
		{
			return metricsId != null;
		}
	}
}
