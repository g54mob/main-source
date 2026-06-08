namespace Amazon.S3.Model
{
	public class PutBucketConfiguration
	{
		private BucketInfo _bucketInfo;

		private LocationInfo _location;

		private BucketLocationConstraint _bucketLocationConstraint;

		public BucketLocationConstraint LocationConstraint
		{
			get
			{
				return _bucketLocationConstraint;
			}
			set
			{
				_bucketLocationConstraint = value;
			}
		}

		public BucketInfo BucketInfo
		{
			get
			{
				return _bucketInfo;
			}
			set
			{
				_bucketInfo = value;
			}
		}

		public LocationInfo Location
		{
			get
			{
				return _location;
			}
			set
			{
				_location = value;
			}
		}

		internal bool IsSetLocationConstraint()
		{
			return _bucketLocationConstraint != null;
		}

		internal bool IsSetBucketInfo()
		{
			return _bucketInfo != null;
		}

		internal bool IsSetLocation()
		{
			return _location != null;
		}
	}
}
