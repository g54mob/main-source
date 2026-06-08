using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class ListBucketMetricsConfigurationsResponse : AmazonWebServiceResponse
	{
		private string token;

		private List<MetricsConfiguration> metricsConfigurationList = (AWSConfigs.InitializeCollections ? new List<MetricsConfiguration>() : null);

		private bool? isTruncated;

		private string nextToken;

		public string Token
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

		public List<MetricsConfiguration> MetricsConfigurationList
		{
			get
			{
				return metricsConfigurationList;
			}
			set
			{
				metricsConfigurationList = value;
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

		public string NextToken
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

		public bool IsSetMetricsConfigurationList()
		{
			if (metricsConfigurationList != null)
			{
				if (metricsConfigurationList.Count <= 0)
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
