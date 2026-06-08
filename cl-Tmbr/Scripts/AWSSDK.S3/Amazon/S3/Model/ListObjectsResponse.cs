using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class ListObjectsResponse : AmazonWebServiceResponse
	{
		private bool? isTruncated;

		private string nextMarker;

		private List<S3Object> contents = (AWSConfigs.InitializeCollections ? new List<S3Object>() : null);

		private string name;

		private string prefix;

		private int? maxKeys;

		private List<string> commonPrefixes = (AWSConfigs.InitializeCollections ? new List<string>() : null);

		private string delimiter;

		private RequestCharged _requestCharged;

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

		public string NextMarker
		{
			get
			{
				if (string.IsNullOrEmpty(nextMarker) && isTruncated == true)
				{
					List<S3Object> s3Objects = S3Objects;
					if (s3Objects != null && s3Objects.Count > 0)
					{
						int index = S3Objects.Count - 1;
						nextMarker = S3Objects[index].Key;
					}
				}
				return nextMarker;
			}
			set
			{
				nextMarker = value;
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

		internal bool IsSetIsTruncated()
		{
			return isTruncated.HasValue;
		}

		internal bool IsSetNextMarker()
		{
			return nextMarker != null;
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

		internal bool IsSetName()
		{
			return name != null;
		}

		internal bool IsSetPrefix()
		{
			return prefix != null;
		}

		internal bool IsSetRequestCharged()
		{
			return _requestCharged != null;
		}

		internal bool IsSetMaxKeys()
		{
			return maxKeys.HasValue;
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
	}
}
