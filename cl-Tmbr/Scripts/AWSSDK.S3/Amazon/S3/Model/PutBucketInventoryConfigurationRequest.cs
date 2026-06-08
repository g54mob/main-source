using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutBucketInventoryConfigurationRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private string inventoryId;

		private InventoryConfiguration inventoryConfiguration;

		private string expectedBucketOwner;

		public string BucketName
		{
			get
			{
				return bucketName;
			}
			set
			{
				bucketName = value;
			}
		}

		public string InventoryId
		{
			get
			{
				return inventoryId;
			}
			set
			{
				inventoryId = value;
			}
		}

		public InventoryConfiguration InventoryConfiguration
		{
			get
			{
				return inventoryConfiguration;
			}
			set
			{
				inventoryConfiguration = value;
			}
		}

		public string ExpectedBucketOwner
		{
			get
			{
				return expectedBucketOwner;
			}
			set
			{
				expectedBucketOwner = value;
			}
		}

		internal bool IsSetBucketName()
		{
			return !string.IsNullOrEmpty(bucketName);
		}

		internal bool IsSetInventoryId()
		{
			return !string.IsNullOrEmpty(inventoryId);
		}

		internal bool IsSetInventoryConfiguration()
		{
			return inventoryConfiguration != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}
	}
}
