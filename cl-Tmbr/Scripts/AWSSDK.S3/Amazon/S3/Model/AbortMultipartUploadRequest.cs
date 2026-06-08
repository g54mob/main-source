using System;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class AbortMultipartUploadRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private string key;

		private string uploadId;

		private RequestPayer requestPayer;

		private string expectedBucketOwner;

		private DateTime? ifMatchInitiatedTime;

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

		public DateTime? IfMatchInitiatedTime
		{
			get
			{
				return ifMatchInitiatedTime;
			}
			set
			{
				ifMatchInitiatedTime = value;
			}
		}

		internal bool IsSetBucketName()
		{
			return bucketName != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}

		internal bool IsSetKey()
		{
			return key != null;
		}

		internal bool IsSetRequestPayer()
		{
			return requestPayer != null;
		}

		internal bool IsSetUploadId()
		{
			return uploadId != null;
		}

		internal bool IsSetIfMatchInitiatedTime()
		{
			return ifMatchInitiatedTime.HasValue;
		}
	}
}
