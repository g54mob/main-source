using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class HeadBucketResponse : AmazonWebServiceResponse
	{
		private bool? _accessPointAlias;

		private string _bucketLocationName;

		private LocationType _bucketLocationType;

		private string _bucketRegion;

		public bool? AccessPointAlias
		{
			get
			{
				return _accessPointAlias;
			}
			set
			{
				_accessPointAlias = value;
			}
		}

		public string BucketLocationName
		{
			get
			{
				return _bucketLocationName;
			}
			set
			{
				_bucketLocationName = value;
			}
		}

		public LocationType BucketLocationType
		{
			get
			{
				return _bucketLocationType;
			}
			set
			{
				_bucketLocationType = value;
			}
		}

		[AWSProperty(Min = 0L, Max = 20L)]
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

		internal bool IsSetAccessPointAlias()
		{
			return _accessPointAlias.HasValue;
		}

		internal bool IsSetBucketLocationName()
		{
			return _bucketLocationName != null;
		}

		internal bool IsSetBucketLocationType()
		{
			return _bucketLocationType != null;
		}

		internal bool IsSetBucketRegion()
		{
			return _bucketRegion != null;
		}
	}
}
