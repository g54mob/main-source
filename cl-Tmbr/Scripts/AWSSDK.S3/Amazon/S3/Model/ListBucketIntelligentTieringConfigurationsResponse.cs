using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class ListBucketIntelligentTieringConfigurationsResponse : AmazonWebServiceResponse
	{
		private string continuationToken;

		private List<IntelligentTieringConfiguration> intelligentTieringConfigurationList = (AWSConfigs.InitializeCollections ? new List<IntelligentTieringConfiguration>() : null);

		private bool? isTruncated;

		private string nextContinuationToken;

		public string ContinuationToken
		{
			get
			{
				return continuationToken;
			}
			set
			{
				continuationToken = value;
			}
		}

		public List<IntelligentTieringConfiguration> IntelligentTieringConfigurationList
		{
			get
			{
				return intelligentTieringConfigurationList;
			}
			set
			{
				intelligentTieringConfigurationList = value;
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
				return nextContinuationToken;
			}
			set
			{
				nextContinuationToken = value;
			}
		}

		internal bool IsSetToken()
		{
			return !string.IsNullOrEmpty(continuationToken);
		}

		public bool IsSetIntelligentTieringConfigurationList()
		{
			if (intelligentTieringConfigurationList != null)
			{
				if (intelligentTieringConfigurationList.Count <= 0)
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
			return !string.IsNullOrEmpty(nextContinuationToken);
		}
	}
}
