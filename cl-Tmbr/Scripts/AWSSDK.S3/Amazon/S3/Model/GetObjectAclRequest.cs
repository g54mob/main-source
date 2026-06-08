using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class GetObjectAclRequest : AmazonWebServiceRequest
	{
		private string _bucketName;

		private string _expectedBucketOwner;

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
				return _expectedBucketOwner;
			}
			set
			{
				_expectedBucketOwner = value;
			}
		}

		[AWSProperty(Required = true, Min = 1L)]
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
			return _bucketName != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(_expectedBucketOwner);
		}

		internal bool IsSetKey()
		{
			return _key != null;
		}

		internal bool IsSetRequestPayer()
		{
			return !string.IsNullOrEmpty(_requestPayer);
		}

		internal bool IsSetVersionId()
		{
			return _versionId != null;
		}
	}
}
