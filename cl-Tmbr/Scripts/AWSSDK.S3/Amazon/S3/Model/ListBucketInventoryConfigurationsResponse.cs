using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class ListBucketInventoryConfigurationsResponse : AmazonWebServiceResponse
	{
		private string token;

		private List<InventoryConfiguration> inventoryConfigurationList = (AWSConfigs.InitializeCollections ? new List<InventoryConfiguration>() : null);

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

		public List<InventoryConfiguration> InventoryConfigurationList
		{
			get
			{
				return inventoryConfigurationList;
			}
			set
			{
				inventoryConfigurationList = value;
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

		public bool IsSetInventoryConfigurationList()
		{
			if (inventoryConfigurationList != null)
			{
				if (inventoryConfigurationList.Count <= 0)
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
