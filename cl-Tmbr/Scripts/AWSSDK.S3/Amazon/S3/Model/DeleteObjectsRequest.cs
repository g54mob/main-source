using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class DeleteObjectsRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private bool? bypassGovernanceRetention;

		private ChecksumAlgorithm _checksumAlgorithm;

		private List<KeyVersion> objects = (AWSConfigs.InitializeCollections ? new List<KeyVersion>() : null);

		private bool? quiet;

		private MfaCodes mfaCodes;

		private RequestPayer requestPayer;

		private string expectedBucketOwner;

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

		public List<KeyVersion> Objects
		{
			get
			{
				return objects;
			}
			set
			{
				objects = value;
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

		public bool? Quiet
		{
			get
			{
				return quiet;
			}
			set
			{
				quiet = value;
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

		internal bool IsSetChecksumAlgorithm()
		{
			return _checksumAlgorithm != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}

		internal bool IsSetObjects()
		{
			if (objects != null)
			{
				if (objects.Count <= 0)
				{
					return !AWSConfigs.InitializeCollections;
				}
				return true;
			}
			return false;
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

		internal bool IsSetQuiet()
		{
			return quiet.HasValue;
		}

		public void AddKey(string key)
		{
			AddKey(new KeyVersion
			{
				Key = key
			});
		}

		public void AddKey(string key, string version)
		{
			AddKey(new KeyVersion
			{
				Key = key,
				VersionId = version
			});
		}

		private void AddKey(KeyVersion keyVersion)
		{
			if (Objects == null)
			{
				Objects = new List<KeyVersion>();
			}
			Objects.Add(keyVersion);
		}
	}
}
