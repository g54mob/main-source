using System;
using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class ListPartsResponse : AmazonWebServiceResponse
	{
		private string bucketName;

		private ChecksumAlgorithm _checksumAlgorithm;

		private string key;

		private string uploadId;

		private Owner owner;

		private Initiator initiator;

		private S3StorageClass storageClass;

		private int? partNumberMarker;

		private int? nextPartNumberMarker;

		private int? maxParts;

		private bool? isTruncated;

		private List<PartDetail> parts = (AWSConfigs.InitializeCollections ? new List<PartDetail>() : null);

		private DateTime? abortDate;

		private string abortRuleId;

		private RequestCharged requestCharged;

		private ChecksumType checksumType;

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

		public ChecksumAlgorithm ChecksumAlgorithm
		{
			get
			{
				return _checksumAlgorithm;
			}
			set
			{
				_checksumAlgorithm = value;
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

		public int? PartNumberMarker
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

		public int? NextPartNumberMarker
		{
			get
			{
				return nextPartNumberMarker;
			}
			set
			{
				nextPartNumberMarker = value;
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

		public List<PartDetail> Parts
		{
			get
			{
				return parts;
			}
			set
			{
				parts = value;
			}
		}

		public Initiator Initiator
		{
			get
			{
				return initiator;
			}
			set
			{
				initiator = value;
			}
		}

		public Owner Owner
		{
			get
			{
				return owner;
			}
			set
			{
				owner = value;
			}
		}

		public string StorageClass
		{
			get
			{
				return storageClass;
			}
			set
			{
				storageClass = value;
			}
		}

		public DateTime? AbortDate
		{
			get
			{
				return abortDate;
			}
			set
			{
				abortDate = value;
			}
		}

		public string AbortRuleId
		{
			get
			{
				return abortRuleId;
			}
			set
			{
				abortRuleId = value;
			}
		}

		public RequestCharged RequestCharged
		{
			get
			{
				return requestCharged;
			}
			set
			{
				requestCharged = value;
			}
		}

		public ChecksumType ChecksumType
		{
			get
			{
				return checksumType;
			}
			set
			{
				checksumType = value;
			}
		}

		internal bool IsSetBucketName()
		{
			return bucketName != null;
		}

		internal bool IsSetChecksumAlgorithm()
		{
			return _checksumAlgorithm != null;
		}

		internal bool IsSetKey()
		{
			return key != null;
		}

		internal bool IsSetUploadId()
		{
			return uploadId != null;
		}

		internal bool IsSetPartNumberMarker()
		{
			return partNumberMarker.HasValue;
		}

		internal bool IsSetNextPartNumberMarker()
		{
			return nextPartNumberMarker.HasValue;
		}

		internal bool IsSetMaxParts()
		{
			return maxParts.HasValue;
		}

		internal bool IsSetIsTruncated()
		{
			return isTruncated.HasValue;
		}

		internal bool IsSetParts()
		{
			if (parts != null)
			{
				if (parts.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
		}

		internal bool IsSetInitiator()
		{
			return initiator != null;
		}

		internal bool IsSetOwner()
		{
			return owner != null;
		}

		internal bool IsSetStorageClass()
		{
			return storageClass != null;
		}

		internal bool IsSetAbortDate()
		{
			return abortDate.HasValue;
		}

		internal bool IsSetAbortRuleId()
		{
			return abortRuleId != null;
		}

		internal bool IsSetRequestCharged()
		{
			return requestCharged != null;
		}

		internal bool IsSetChecksumType()
		{
			return checksumType != null;
		}
	}
}
