using System;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetObjectAttributesResponse : AmazonWebServiceResponse
	{
		private Checksum _checksum;

		private bool? _deleteMarker;

		private string _eTag;

		private DateTime? _lastModified;

		private GetObjectAttributesParts _objectParts;

		private long? _objectSize;

		private RequestCharged _requestCharged;

		private S3StorageClass _storageClass;

		private string _versionId;

		public Checksum Checksum
		{
			get
			{
				return _checksum;
			}
			set
			{
				_checksum = value;
			}
		}

		public bool? DeleteMarker
		{
			get
			{
				return _deleteMarker;
			}
			set
			{
				_deleteMarker = value;
			}
		}

		public string ETag
		{
			get
			{
				return _eTag;
			}
			set
			{
				_eTag = value;
			}
		}

		public DateTime? LastModified
		{
			get
			{
				return _lastModified;
			}
			set
			{
				_lastModified = value;
			}
		}

		public GetObjectAttributesParts ObjectParts
		{
			get
			{
				return _objectParts;
			}
			set
			{
				_objectParts = value;
			}
		}

		public long? ObjectSize
		{
			get
			{
				return _objectSize;
			}
			set
			{
				_objectSize = value;
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

		public S3StorageClass StorageClass
		{
			get
			{
				return _storageClass;
			}
			set
			{
				_storageClass = value;
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

		internal bool IsSetChecksum()
		{
			return _checksum != null;
		}

		internal bool IsSetDeleteMarker()
		{
			return _deleteMarker.HasValue;
		}

		internal bool IsSetETag()
		{
			return _eTag != null;
		}

		internal bool IsSetLastModified()
		{
			return _lastModified.HasValue;
		}

		internal bool IsSetObjectParts()
		{
			return _objectParts != null;
		}

		internal bool IsSetObjectSize()
		{
			return _objectSize.HasValue;
		}

		internal bool IsSetRequestCharged()
		{
			return _requestCharged != null;
		}

		internal bool IsSetStorageClass()
		{
			return _storageClass != null;
		}

		internal bool IsSetVersionId()
		{
			return _versionId != null;
		}
	}
}
