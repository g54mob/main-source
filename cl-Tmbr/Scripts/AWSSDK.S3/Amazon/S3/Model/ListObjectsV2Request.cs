using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class ListObjectsV2Request : AmazonWebServiceRequest
	{
		private string bucketName;

		private string continuationToken;

		private string delimiter;

		private EncodingType encoding;

		private string expectedBucketOwner;

		private bool? fetchOwner;

		private int? maxKeys;

		private List<string> _optionalObjectAttributes = (AWSConfigs.InitializeCollections ? new List<string>() : null);

		private string prefix;

		private RequestPayer requestPayer;

		private string startAfter;

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

		public bool? FetchOwner
		{
			get
			{
				return fetchOwner;
			}
			set
			{
				fetchOwner = value;
			}
		}

		public int? MaxKeys
		{
			get
			{
				return maxKeys;
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
				return requestPayer;
			}
			set
			{
				requestPayer = value;
			}
		}

		public string StartAfter
		{
			get
			{
				return startAfter;
			}
			set
			{
				startAfter = value;
			}
		}

		internal bool IsSetBucketName()
		{
			return bucketName != null;
		}

		internal bool IsSetContinuationToken()
		{
			return continuationToken != null;
		}

		internal bool IsSetDelimiter()
		{
			return delimiter != null;
		}

		internal bool IsSetEncoding()
		{
			return encoding != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}

		internal bool IsSetFetchOwner()
		{
			return fetchOwner.HasValue;
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
			return requestPayer != null;
		}

		internal bool IsSetStartAfter()
		{
			return StartAfter != null;
		}
	}
}
