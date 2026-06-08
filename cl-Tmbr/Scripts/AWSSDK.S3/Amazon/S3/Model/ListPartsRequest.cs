using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class ListPartsRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private EncodingType encoding;

		private string expectedBucketOwner;

		private string key;

		private int? maxParts;

		private string partNumberMarker;

		private RequestPayer requestPayer;

		private string _sseCustomerAlgorithm;

		private string _sseCustomerKey;

		private string _sseCustomerKeyMD5;

		private string uploadId;

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

		public EncodingType Encoding
		{
			get
			{
				return encoding;
			}
			set
			{
				encoding = value;
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
				return key;
			}
			set
			{
				key = value;
			}
		}

		public int? MaxParts
		{
			get
			{
				return maxParts;
			}
			set
			{
				maxParts = value;
			}
		}

		public string PartNumberMarker
		{
			get
			{
				return partNumberMarker;
			}
			set
			{
				partNumberMarker = value;
			}
		}

		public RequestPayer RequestPayer
		{
			get
			{
				return requestPayer;
			}
			set
			{
				requestPayer = value;
			}
		}

		public string SSECustomerAlgorithm
		{
			get
			{
				return _sseCustomerAlgorithm;
			}
			set
			{
				_sseCustomerAlgorithm = value;
			}
		}

		public string SSECustomerKey
		{
			get
			{
				return _sseCustomerKey;
			}
			set
			{
				_sseCustomerKey = value;
			}
		}

		public string SSECustomerKeyMD5
		{
			get
			{
				return _sseCustomerKeyMD5;
			}
			set
			{
				_sseCustomerKeyMD5 = value;
			}
		}

		public string UploadId
		{
			get
			{
				return uploadId;
			}
			set
			{
				uploadId = value;
			}
		}

		internal bool IsSetBucketName()
		{
			return bucketName != null;
		}

		internal bool IsSetEncoding()
		{
			return encoding != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}

		internal bool IsSetKey()
		{
			return key != null;
		}

		internal bool IsSetMaxParts()
		{
			return maxParts.HasValue;
		}

		internal bool IsSetPartNumberMarker()
		{
			return partNumberMarker != null;
		}

		internal bool IsSetRequestPayer()
		{
			return requestPayer != null;
		}

		internal bool IsSetSSECustomerAlgorithm()
		{
			return _sseCustomerAlgorithm != null;
		}

		internal bool IsSetSSECustomerKey()
		{
			return _sseCustomerKey != null;
		}

		internal bool IsSetSSECustomerKeyMD5()
		{
			return _sseCustomerKeyMD5 != null;
		}

		internal bool IsSetUploadId()
		{
			return uploadId != null;
		}
	}
}
