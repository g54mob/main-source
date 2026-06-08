using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class CompleteMultipartUploadRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private string _checksumCRC32;

		private string _checksumCRC32C;

		private string _checksumCRC64NVME;

		private string _checksumSHA1;

		private string _checksumSHA256;

		private ChecksumType checksumType;

		private long? mpuObjectSize;

		private string key;

		private List<PartETag> partETags = (AWSConfigs.InitializeCollections ? new List<PartETag>() : null);

		private string uploadId;

		private RequestPayer requestPayer;

		private string _sseCustomerAlgorithm;

		private string _sseCustomerKey;

		private string _sseCustomerKeyMD5;

		private string expectedBucketOwner;

		private string _ifNoneMatch;

		private string _ifMatch;

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

		public string ChecksumCRC32
		{
			get
			{
				return _checksumCRC32;
			}
			set
			{
				_checksumCRC32 = value;
			}
		}

		public string ChecksumCRC32C
		{
			get
			{
				return _checksumCRC32C;
			}
			set
			{
				_checksumCRC32C = value;
			}
		}

		public string ChecksumCRC64NVME
		{
			get
			{
				return _checksumCRC64NVME;
			}
			set
			{
				_checksumCRC64NVME = value;
			}
		}

		public string ChecksumSHA1
		{
			get
			{
				return _checksumSHA1;
			}
			set
			{
				_checksumSHA1 = value;
			}
		}

		public string ChecksumSHA256
		{
			get
			{
				return _checksumSHA256;
			}
			set
			{
				_checksumSHA256 = value;
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

		public long MpuObjectSize
		{
			get
			{
				return mpuObjectSize.GetValueOrDefault();
			}
			set
			{
				mpuObjectSize = value;
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

		public string IfNoneMatch
		{
			get
			{
				return _ifNoneMatch;
			}
			set
			{
				_ifNoneMatch = value;
			}
		}

		public string IfMatch
		{
			get
			{
				return _ifMatch;
			}
			set
			{
				_ifMatch = value;
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

		public List<PartETag> PartETags
		{
			get
			{
				return partETags;
			}
			set
			{
				partETags = value;
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

		internal bool IsSetChecksumCRC32()
		{
			return _checksumCRC32 != null;
		}

		internal bool IsSetChecksumCRC32C()
		{
			return _checksumCRC32C != null;
		}

		internal bool IsSetChecksumCRC64NVME()
		{
			return _checksumCRC64NVME != null;
		}

		internal bool IsSetChecksumSHA1()
		{
			return _checksumSHA1 != null;
		}

		internal bool IsSetChecksumSHA256()
		{
			return _checksumSHA256 != null;
		}

		internal bool IsSetChecksumType()
		{
			return checksumType != null;
		}

		internal bool IsSetMpuObjectSize()
		{
			return mpuObjectSize.HasValue;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}

		internal bool IsSetIfNoneMatch()
		{
			return !string.IsNullOrEmpty(_ifNoneMatch);
		}

		internal bool IsSetIfMatch()
		{
			return !string.IsNullOrEmpty(_ifMatch);
		}

		internal bool IsSetKey()
		{
			return key != null;
		}

		public void AddPartETags(params PartETag[] partETags)
		{
			if (partETags != null)
			{
				foreach (PartETag item in partETags)
				{
					PartETags.Add(item);
				}
			}
		}

		public void AddPartETags(IEnumerable<PartETag> partETags)
		{
			if (partETags == null)
			{
				partETags = new List<PartETag>();
			}
			foreach (PartETag partETag in partETags)
			{
				PartETags.Add(partETag);
			}
		}

		public void AddPartETags(params UploadPartResponse[] responses)
		{
			if (PartETags == null)
			{
				PartETags = new List<PartETag>();
			}
			foreach (UploadPartResponse uploadPartResponse in responses)
			{
				PartETags.Add(new PartETag(uploadPartResponse, copyChecksums: false));
			}
		}

		public void AddPartETags(IEnumerable<UploadPartResponse> responses)
		{
			if (PartETags == null)
			{
				PartETags = new List<PartETag>();
			}
			foreach (UploadPartResponse response in responses)
			{
				PartETags.Add(new PartETag(response, copyChecksums: false));
			}
		}

		public void AddPartETagsAndChecksums(params UploadPartResponse[] responses)
		{
			if (PartETags == null)
			{
				PartETags = new List<PartETag>();
			}
			foreach (UploadPartResponse uploadPartResponse in responses)
			{
				PartETags.Add(new PartETag(uploadPartResponse, copyChecksums: true));
			}
		}

		public void AddPartETagsAndChecksums(IEnumerable<UploadPartResponse> responses)
		{
			if (PartETags == null)
			{
				PartETags = new List<PartETag>();
			}
			foreach (UploadPartResponse response in responses)
			{
				PartETags.Add(new PartETag(response, copyChecksums: true));
			}
		}

		public void AddPartETags(params CopyPartResponse[] responses)
		{
			if (PartETags == null)
			{
				PartETags = new List<PartETag>();
			}
			foreach (CopyPartResponse copyPartResponse in responses)
			{
				PartETags.Add(new PartETag(copyPartResponse, copyChecksums: false));
			}
		}

		public void AddPartETags(IEnumerable<CopyPartResponse> responses)
		{
			if (PartETags == null)
			{
				PartETags = new List<PartETag>();
			}
			foreach (CopyPartResponse response in responses)
			{
				PartETags.Add(new PartETag(response, copyChecksums: false));
			}
		}

		public void AddPartETagsAndChecksums(params CopyPartResponse[] responses)
		{
			if (PartETags == null)
			{
				PartETags = new List<PartETag>();
			}
			foreach (CopyPartResponse copyPartResponse in responses)
			{
				PartETags.Add(new PartETag(copyPartResponse, copyChecksums: true));
			}
		}

		public void AddPartETagsAndChecksums(IEnumerable<CopyPartResponse> responses)
		{
			if (PartETags == null)
			{
				PartETags = new List<PartETag>();
			}
			foreach (CopyPartResponse response in responses)
			{
				PartETags.Add(new PartETag(response, copyChecksums: true));
			}
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
