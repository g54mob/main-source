namespace Amazon.S3.Model
{
	public class AnalyticsConfiguration
	{
		private string analyticsId;

		private AnalyticsFilter analyticsFilter;

		private StorageClassAnalysis storageClassAnalysis;

		public AnalyticsFilter AnalyticsFilter
		{
			get
			{
				return analyticsFilter;
			}
			set
			{
				analyticsFilter = value;
			}
		}

		public string AnalyticsId
		{
			get
			{
				return analyticsId;
			}
			set
			{
				analyticsId = value;
			}
		}

		public StorageClassAnalysis StorageClassAnalysis
		{
			get
			{
				return storageClassAnalysis;
			}
			set
			{
				storageClassAnalysis = value;
			}
		}

		internal bool IsSetAnalyticsFilter()
		{
			return analyticsFilter != null;
		}

		internal bool IsSetAnalyticsId()
		{
			return !string.IsNullOrEmpty(analyticsId);
		}

		internal bool IsSetStorageClassAnalysis()
		{
			return storageClassAnalysis != null;
		}
	}
}
