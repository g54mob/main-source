using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class ListObjectsV2Response : AmazonWebServiceResponse
	{
		private List<string> commonPrefixes = (AWSConfigs.InitializeCollections ? new List<string>() : null);

		private List<S3Object> contents = (AWSConfigs.InitializeCollections ? new List<S3Object>() : null);

		private string continuationToken;

		private string delimiter;

		private EncodingType encoding;

		private bool? isTruncated;

		private int? keyCount;

		private int? maxKeys;

		private string name;

		private string nextContinuationToken;

		private string prefix;

		private RequestCharged _requestCharged;

		private string startAfter;

		public List<string> CommonPrefixes
		{
			get
			{
				return commonPrefixes;
			}
			set
			{
				commonPrefixes = value;
			}
		}

		public List<S3Object> S3Objects
		{
			get
			{
				return contents;
			}
			set
			{
				contents = value;
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

		public int? KeyCount
		{
			get
			{
				return keyCount;
			}
			set
			{
				keyCount = value;
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

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public string NextContinuationToken
		{
			get
			{
				return nextContinuationToken;
			}
			set
			{
				nextContinuationToken = value;
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

		public RequestCharged RequestCharged
		{
			get
			{
				return _requestCharged;
			}
			set
			{
				_requestCharged = value;
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

		internal bool IsSetCommonPrefixes()
		{
			if (commonPrefixes != null)
			{
				if (commonPrefixes.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetContents()
		{
			if (contents != null)
			{
				if (contents.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetContinuationToken()
		{
			return continuationToken != null;
		}

		internal bool IsSetEncoding()
		{
			return encoding != null;
		}

		internal bool IsSetIsTruncated()
		{
			return isTruncated.HasValue;
		}

		internal bool IsSetKeyCount()
		{
			return keyCount.HasValue;
		}

		internal bool IsSetMaxKeys()
		{
			return maxKeys.HasValue;
		}

		internal bool IsSetName()
		{
			return name != null;
		}

		internal bool IsSetNextContinuationToken()
		{
			return nextContinuationToken != null;
		}

		internal bool IsSetPrefix()
		{
			return prefix != null;
		}

		internal bool IsSetRequestCharged()
		{
			return _requestCharged != null;
		}

		internal bool IsSetStartAfter()
		{
			return startAfter != null;
		}
	}
}
