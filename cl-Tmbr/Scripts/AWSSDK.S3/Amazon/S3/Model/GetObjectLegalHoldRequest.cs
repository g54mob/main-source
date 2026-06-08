using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetObjectLegalHoldRequest : AmazonWebServiceRequest
	{
		private string _bucketName;

		private string expectedBucketOwner;

		private string _key;

		private RequestPayer _requestPayer;

		private string _versionId;

		public string BucketName
		{
			get
			{
				return _bucketName;
			}
			set
			{
				_bucketName = value;
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

		public string Key
		{
			get
			{
				return _key;
			}
			set
			{
				_key = value;
			}
		}

		public RequestPayer RequestPayer
		{
			get
			{
				return _requestPayer;
			}
			set
			{
				_requestPayer = value;
			}
		}

		public string VersionId
		{
			get
			{
				return _versionId;
			}
			set
			{
				_versionId = value;
			}
		}

		internal bool IsSetBucketName()
		{
			return !string.IsNullOrEmpty(_bucketName);
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}

		internal bool IsSetKey()
		{
			return !string.IsNullOrEmpty(_key);
		}

		internal bool IsSetRequestPayer()
		{
			return _requestPayer != null;
		}

		internal bool IsSetVersionId()
		{
			return !string.IsNullOrEmpty(_versionId);
		}
	}
}
