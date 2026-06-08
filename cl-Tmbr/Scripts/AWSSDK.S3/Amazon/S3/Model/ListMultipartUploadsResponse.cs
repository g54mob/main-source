using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class ListMultipartUploadsResponse : AmazonWebServiceResponse
	{
		private string _bucketName;

		private string keyMarker;

		private string uploadIdMarker;

		private string nextKeyMarker;

		private string nextUploadIdMarker;

		private int? maxUploads;

		private RequestCharged _requestCharged;

		private bool? isTruncated;

		private List<MultipartUpload> multipartUploads = (AWSConfigs.InitializeCollections ? new List<MultipartUpload>() : null);

		private string delimiter;

		private List<string> commonPrefixes = (AWSConfigs.InitializeCollections ? new List<string>() : null);

		private string prefix;

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

		public string UploadIdMarker
		{
			get
			{
				return uploadIdMarker;
			}
			set
			{
				uploadIdMarker = value;
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

		public string NextUploadIdMarker
		{
			get
			{
				return nextUploadIdMarker;
			}
			set
			{
				nextUploadIdMarker = value;
			}
		}

		public int? MaxUploads
		{
			get
			{
				return maxUploads;
			}
			set
			{
				maxUploads = value;
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

		public List<MultipartUpload> MultipartUploads
		{
			get
			{
				return multipartUploads;
			}
			set
			{
				multipartUploads = value;
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

		internal bool IsSetBucketName()
		{
			return _bucketName != null;
		}

		internal bool IsSetKeyMarker()
		{
			return keyMarker != null;
		}

		internal bool IsSetUploadIdMarker()
		{
			return uploadIdMarker != null;
		}

		internal bool IsSetNextKeyMarker()
		{
			return nextKeyMarker != null;
		}

		internal bool IsSetNextUploadIdMarker()
		{
			return nextUploadIdMarker != null;
		}

		internal bool IsSetMaxUploads()
		{
			return maxUploads.HasValue;
		}

		internal bool IsSetIsTruncated()
		{
			return isTruncated.HasValue;
		}

		internal bool IsSetRequestCharged()
		{
			return _requestCharged != null;
		}
	}
}
