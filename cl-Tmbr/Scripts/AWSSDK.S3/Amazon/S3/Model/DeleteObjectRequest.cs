using System;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class DeleteObjectRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private bool? bypassGovernanceRetention;

		private string expectedBucketOwner;

		private string key;

		private MfaCodes mfaCodes;

		private RequestPayer requestPayer;

		private string versionId;

		private string ifMatch;

		private DateTime? ifMatchLastModifiedTime;

		private long? ifMatchSize;

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

		public bool? BypassGovernanceRetention
		{
			get
			{
				return bypassGovernanceRetention;
			}
			set
			{
				bypassGovernanceRetention = value;
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

		public MfaCodes MfaCodes
		{
			get
			{
				return mfaCodes;
			}
			set
			{
				mfaCodes = value;
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

		public string VersionId
		{
			get
			{
				return versionId;
			}
			set
			{
				versionId = value;
			}
		}

		public string IfMatch
		{
			get
			{
				return ifMatch;
			}
			set
			{
				ifMatch = value;
			}
		}

		public DateTime? IfMatchLastModifiedTime
		{
			get
			{
				return ifMatchLastModifiedTime;
			}
			set
			{
				ifMatchLastModifiedTime = value;
			}
		}

		public long IfMatchSize
		{
			get
			{
				return ifMatchSize.GetValueOrDefault();
			}
			set
			{
				ifMatchSize = value;
			}
		}

		internal bool IsSetBucketName()
		{
			return bucketName != null;
		}

		internal bool IsSetBypassGovernanceRetention()
		{
			return bypassGovernanceRetention.HasValue;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}

		internal bool IsSetKey()
		{
			return key != null;
		}

		internal bool IsSetMfaCodes()
		{
			if (mfaCodes != null && !string.IsNullOrEmpty(MfaCodes.SerialNumber))
			{
				return !string.IsNullOrEmpty(MfaCodes.AuthenticationValue);
			}
			return false;
		}

		internal bool IsSetRequestPayer()
		{
			return requestPayer != null;
		}

		internal bool IsSetVersionId()
		{
			return !string.IsNullOrEmpty(versionId);
		}

		internal bool IsSetIfMatch()
		{
			return !string.IsNullOrEmpty(ifMatch);
		}

		internal bool IsSetIfMatchLastModifiedTime()
		{
			return ifMatchLastModifiedTime.HasValue;
		}

		internal bool IsSetIfMatchSize()
		{
			return ifMatchSize.HasValue;
		}
	}
}
