using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetBucketAccelerateConfigurationRequest : AmazonWebServiceRequest
	{
		private string _bucketName;

		private string _expectedBucketOwner;

		private RequestPayer _requestPayer;

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
				return _expectedBucketOwner;
			}
			set
			{
				_expectedBucketOwner = value;
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

		internal bool IsSetBucketName()
		{
			return _bucketName != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(_expectedBucketOwner);
		}

		internal bool IsSetRequestPayer()
		{
			return _requestPayer != null;
		}
	}
}
