namespace Amazon.S3.Model
{
	public class PutBucketRequest : PutWithACLRequest
	{
		private string bucketName;

		private S3Region bucketRegion;

		private string bucketRegionName;

		private bool useClientRegion = true;

		private S3CannedACL cannedAcl;

		private bool? _objectLockEnabledForBucket;

		private ObjectOwnership _objectOwnership;

		private PutBucketConfiguration _putBucketConfiguration;

		public S3CannedACL CannedACL
		{
			get
			{
				return cannedAcl;
			}
			set
			{
				cannedAcl = value;
			}
		}

		public bool UseClientRegion
		{
			get
			{
				return useClientRegion;
			}
			set
			{
				useClientRegion = value;
			}
		}

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

		public S3Region BucketRegion
		{
			get
			{
				return bucketRegion;
			}
			set
			{
				bucketRegion = value;
			}
		}

		public string BucketRegionName
		{
			get
			{
				return bucketRegionName;
			}
			set
			{
				bucketRegionName = value;
			}
		}

		public PutBucketConfiguration PutBucketConfiguration
		{
			get
			{
				return _putBucketConfiguration;
			}
			set
			{
				_putBucketConfiguration = value;
			}
		}

		public bool? ObjectLockEnabledForBucket
		{
			get
			{
				return _objectLockEnabledForBucket;
			}
			set
			{
				_objectLockEnabledForBucket = value;
			}
		}

		public ObjectOwnership ObjectOwnership
		{
			get
			{
				return _objectOwnership;
			}
			set
			{
				_objectOwnership = value;
			}
		}

		internal bool IsSetCannedACL()
		{
			if (cannedAcl != null)
			{
				return cannedAcl != S3CannedACL.NoACL;
			}
			return false;
		}

		internal bool IsSetBucketName()
		{
			return bucketName != null;
		}

		internal bool IsSetBucketRegion()
		{
			return bucketRegion != null;
		}

		internal bool IsSetPutBucketConfiguration()
		{
			return _putBucketConfiguration != null;
		}

		internal bool IsSetBucketRegionName()
		{
			return !string.IsNullOrEmpty(bucketRegionName);
		}

		internal bool IsSetObjectLockEnabledForBucket()
		{
			return _objectLockEnabledForBucket.HasValue;
		}

		internal bool IsSetObjectOwnership()
		{
			return _objectOwnership != null;
		}
	}
}
