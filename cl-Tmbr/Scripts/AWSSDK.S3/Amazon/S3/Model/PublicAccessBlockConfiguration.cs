namespace Amazon.S3.Model
{
	public class PublicAccessBlockConfiguration
	{
		private bool? blockPublicAcls;

		private bool? ignorePublicAcls;

		private bool? blockPublicPolicy;

		private bool? restrictPublicBuckets;

		public bool? BlockPublicAcls
		{
			get
			{
				return blockPublicAcls;
			}
			set
			{
				blockPublicAcls = value;
			}
		}

		public bool? IgnorePublicAcls
		{
			get
			{
				return ignorePublicAcls;
			}
			set
			{
				ignorePublicAcls = value;
			}
		}

		public bool? BlockPublicPolicy
		{
			get
			{
				return blockPublicPolicy;
			}
			set
			{
				blockPublicPolicy = value;
			}
		}

		public bool? RestrictPublicBuckets
		{
			get
			{
				return restrictPublicBuckets;
			}
			set
			{
				restrictPublicBuckets = value;
			}
		}

		internal bool IsSetBlockPublicAcls()
		{
			return blockPublicAcls.HasValue;
		}

		internal bool IsSetIgnorePublicAcls()
		{
			return ignorePublicAcls.HasValue;
		}

		internal bool IsSetBlockPublicPolicy()
		{
			return blockPublicPolicy.HasValue;
		}

		internal bool IsSetRestrictPublicBuckets()
		{
			return restrictPublicBuckets.HasValue;
		}
	}
}
