using System.Collections.Generic;
using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class GetObjectAttributesRequest : AmazonWebServiceRequest
	{
		private string _bucketName;

		private string _expectedBucketOwner;

		private string _key;

		private int? _maxParts;

		private List<ObjectAttributes> _objectAttributes = (AWSConfigs.InitializeCollections ? new List<ObjectAttributes>() : null);

		private int? _partNumberMarker;

		private RequestPayer _requestPayer;

		private string _sseCustomerAlgorithm;

		private string _sseCustomerKey;

		private string _sseCustomerKeyMD5;

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

		public int? MaxParts
		{
			get
			{
				return _maxParts;
			}
			set
			{
				_maxParts = value;
			}
		}

		public List<ObjectAttributes> ObjectAttributes
		{
			get
			{
				return _objectAttributes;
			}
			set
			{
				_objectAttributes = value;
			}
		}

		public int? PartNumberMarker
		{
			get
			{
				return _partNumberMarker;
			}
			set
			{
				_partNumberMarker = value;
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
			return _expectedBucketOwner != null;
		}

		internal bool IsSetKey()
		{
			return _key != null;
		}

		internal bool IsSetMaxParts()
		{
			return _maxParts.HasValue;
		}

		internal bool IsSetObjectAttributes()
		{
			if (_objectAttributes != null)
			{
				if (_objectAttributes.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetPartNumberMarker()
		{
			return _partNumberMarker.HasValue;
		}

		internal bool IsSetRequestPayer()
		{
			return _requestPayer != null;
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

		internal bool IsSetVersionId()
		{
			return _versionId != null;
		}
	}
}
