using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class CreateBucketMetadataTableConfigurationRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private ChecksumAlgorithm checksumAlgorithm;

		private string contentMD5;

		private MetadataTableConfiguration metadataTableConfiguration;

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

		public ChecksumAlgorithm ChecksumAlgorithm
		{
			get
			{
				return checksumAlgorithm;
			}
			set
			{
				checksumAlgorithm = value;
			}
		}

		public string ContentMD5
		{
			get
			{
				return contentMD5;
			}
			set
			{
				contentMD5 = value;
			}
		}

		public MetadataTableConfiguration MetadataTableConfiguration
		{
			get
			{
				return metadataTableConfiguration;
			}
			set
			{
				metadataTableConfiguration = value;
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

		internal bool IsSetChecksumAlgorithm()
		{
			return checksumAlgorithm != null;
		}

		internal bool IsSetContentMD5()
		{
			return !string.IsNullOrEmpty(contentMD5);
		}

		internal bool IsSetMetadataTableConfiguration()
		{
			return metadataTableConfiguration != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}
	}
}
