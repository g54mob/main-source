using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class ListVersionsResponse : AmazonWebServiceResponse
	{
		private bool? isTruncated;

		private string keyMarker;

		private string versionIdMarker;

		private string nextKeyMarker;

		private string nextVersionIdMarker;

		private List<S3ObjectVersion> versions = (AWSConfigs.InitializeCollections ? new List<S3ObjectVersion>() : null);

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

		public string NextKeyMarker
		{
			get
			{
				return nextKeyMarker;
			}
			set
			{
				nextKeyMarker = value;
			}
		}

		public string NextVersionIdMarker
		{
			get
			{
				return nextVersionIdMarker;
			}
			set
			{
				nextVersionIdMarker = value;
			}
		}

		public List<S3ObjectVersion> Versions
		{
			get
			{
				return versions;
			}
			set
			{
				versions = value;
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

		internal bool IsSetKeyMarker()
		{
			return keyMarker != null;
		}

		internal bool IsSetVersionIdMarker()
		{
			return versionIdMarker != null;
		}

		internal bool IsSetNextKeyMarker()
		{
			return nextKeyMarker != null;
		}

		internal bool IsSetNextVersionIdMarker()
		{
			return nextVersionIdMarker != null;
		}

		internal bool IsSetVersions()
		{
			if (versions != null)
			{
				if (versions.Count <= 0)
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
