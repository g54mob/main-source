using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class ListVersionsRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private string delimiter;

		private string keyMarker;

		private int? maxKeys;

		private string prefix;

		private List<string> _optionalObjectAttributes = (AWSConfigs.InitializeCollections ? new List<string>() : null);

		private RequestPayer _requestPayer;

		private string versionIdMarker;

		private EncodingType encoding;

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

		public string Delimiter
		{
			get
			{
				return delimiter;
			}
			set
			{
				delimiter = value;
			}
		}

		public string KeyMarker
		{
			get
			{
				return keyMarker;
			}
			set
			{
				keyMarker = value;
			}
		}

		public int? MaxKeys
		{
			get
			{
				return maxKeys.GetValueOrDefault();
			}
			set
			{
				maxKeys = value;
			}
		}

		public List<string> OptionalObjectAttributes
		{
			get
			{
				return _optionalObjectAttributes;
			}
			set
			{
				_optionalObjectAttributes = value;
			}
		}

		public string Prefix
		{
			get
			{
				return prefix;
			}
			set
			{
				prefix = value;
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

		public string VersionIdMarker
		{
			get
			{
				return versionIdMarker;
			}
			set
			{
				versionIdMarker = value;
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

		internal bool IsSetBucketName()
		{
			return bucketName != null;
		}

		internal bool IsSetDelimiter()
		{
			return delimiter != null;
		}

		internal bool IsSetKeyMarker()
		{
			return keyMarker != null;
		}

		internal bool IsSetMaxKeys()
		{
			return maxKeys.HasValue;
		}

		internal bool IsSetOptionalObjectAttributes()
		{
			if (_optionalObjectAttributes != null)
			{
				if (_optionalObjectAttributes.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetPrefix()
		{
			return prefix != null;
		}

		internal bool IsSetRequestPayer()
		{
			return _requestPayer != null;
		}

		internal bool IsSetVersionIdMarker()
		{
			return versionIdMarker != null;
		}

		internal bool IsSetEncoding()
		{
			return encoding != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}
	}
}
