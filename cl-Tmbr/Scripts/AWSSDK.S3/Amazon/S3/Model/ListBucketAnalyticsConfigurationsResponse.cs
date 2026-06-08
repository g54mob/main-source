using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class ListBucketAnalyticsConfigurationsResponse : AmazonWebServiceResponse
	{
		private string token;

		private List<AnalyticsConfiguration> analyticsConfigurationList = (AWSConfigs.InitializeCollections ? new List<AnalyticsConfiguration>() : null);

		private bool? isTruncated;

		private string nextToken;

		public string ContinuationToken
		{
			get
			{
				return token;
			}
			set
			{
				token = value;
			}
		}

		public List<AnalyticsConfiguration> AnalyticsConfigurationList
		{
			get
			{
				return analyticsConfigurationList;
			}
			set
			{
				analyticsConfigurationList = value;
			}
		}

		public bool? IsTruncated
		{
			get
			{
				return isTruncated;
			}
			set
			{
				isTruncated = value;
			}
		}

		public string NextContinuationToken
		{
			get
			{
				return nextToken;
			}
			set
			{
				nextToken = value;
			}
		}

		internal bool IsSetToken()
		{
			return !string.IsNullOrEmpty(token);
		}

		public bool IsSetAnalyticsConfigurationList()
		{
			if (analyticsConfigurationList != null)
			{
				if (analyticsConfigurationList.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetIsTruncated()
		{
			return isTruncated.HasValue;
		}

		internal bool IsSetNextToken()
		{
			return !string.IsNullOrEmpty(nextToken);
		}
	}
}
