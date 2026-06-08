using System;

namespace Amazon.S3.Model
{
	public class S3Bucket
	{
		private DateTime? creationDate;

		private string bucketName;

		private string _bucketRegion;

		public DateTime? CreationDate
		{
			get
			{
				return creationDate;
			}
			set
			{
				creationDate = value;
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

		public string BucketRegion
		{
			get
			{
				return _bucketRegion;
			}
			set
			{
				_bucketRegion = value;
			}
		}

		internal bool IsSetCreationDate()
		{
			return creationDate.HasValue;
		}

		internal bool IsSetBucketName()
		{
			return bucketName != null;
		}

		internal bool IsSetBucketRegion()
		{
			return _bucketRegion != null;
		}
	}
}
