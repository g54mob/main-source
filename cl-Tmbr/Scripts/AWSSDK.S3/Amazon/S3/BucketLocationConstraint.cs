using Amazon.Runtime;

namespace Amazon.S3
{
	public class BucketLocationConstraint : ConstantClass
	{
		public static readonly BucketLocationConstraint AfSouth1 = new BucketLocationConstraint("af-south-1");

		public static readonly BucketLocationConstraint ApEast1 = new BucketLocationConstraint("ap-east-1");

		public static readonly BucketLocationConstraint ApNortheast1 = new BucketLocationConstraint("ap-northeast-1");

		public static readonly BucketLocationConstraint ApNortheast2 = new BucketLocationConstraint("ap-northeast-2");

		public static readonly BucketLocationConstraint ApNortheast3 = new BucketLocationConstraint("ap-northeast-3");

		public static readonly BucketLocationConstraint ApSouth1 = new BucketLocationConstraint("ap-south-1");

		public static readonly BucketLocationConstraint ApSouth2 = new BucketLocationConstraint("ap-south-2");

		public static readonly BucketLocationConstraint ApSoutheast1 = new BucketLocationConstraint("ap-southeast-1");

		public static readonly BucketLocationConstraint ApSoutheast2 = new BucketLocationConstraint("ap-southeast-2");

		public static readonly BucketLocationConstraint ApSoutheast3 = new BucketLocationConstraint("ap-southeast-3");

		public static readonly BucketLocationConstraint ApSoutheast4 = new BucketLocationConstraint("ap-southeast-4");

		public static readonly BucketLocationConstraint ApSoutheast5 = new BucketLocationConstraint("ap-southeast-5");

		public static readonly BucketLocationConstraint CaCentral1 = new BucketLocationConstraint("ca-central-1");

		public static readonly BucketLocationConstraint CaWest1 = new BucketLocationConstraint("ca-west-1");

		public static readonly BucketLocationConstraint CnNorth1 = new BucketLocationConstraint("cn-north-1");

		public static readonly BucketLocationConstraint CnNorthwest1 = new BucketLocationConstraint("cn-northwest-1");

		public static readonly BucketLocationConstraint EU = new BucketLocationConstraint("EU");

		public static readonly BucketLocationConstraint EuCentral1 = new BucketLocationConstraint("eu-central-1");

		public static readonly BucketLocationConstraint EuCentral2 = new BucketLocationConstraint("eu-central-2");

		public static readonly BucketLocationConstraint EuNorth1 = new BucketLocationConstraint("eu-north-1");

		public static readonly BucketLocationConstraint EuSouth1 = new BucketLocationConstraint("eu-south-1");

		public static readonly BucketLocationConstraint EuSouth2 = new BucketLocationConstraint("eu-south-2");

		public static readonly BucketLocationConstraint EuWest1 = new BucketLocationConstraint("eu-west-1");

		public static readonly BucketLocationConstraint EuWest2 = new BucketLocationConstraint("eu-west-2");

		public static readonly BucketLocationConstraint EuWest3 = new BucketLocationConstraint("eu-west-3");

		public static readonly BucketLocationConstraint IlCentral1 = new BucketLocationConstraint("il-central-1");

		public static readonly BucketLocationConstraint MeCentral1 = new BucketLocationConstraint("me-central-1");

		public static readonly BucketLocationConstraint MeSouth1 = new BucketLocationConstraint("me-south-1");

		public static readonly BucketLocationConstraint SaEast1 = new BucketLocationConstraint("sa-east-1");

		public static readonly BucketLocationConstraint UsEast2 = new BucketLocationConstraint("us-east-2");

		public static readonly BucketLocationConstraint UsGovEast1 = new BucketLocationConstraint("us-gov-east-1");

		public static readonly BucketLocationConstraint UsGovWest1 = new BucketLocationConstraint("us-gov-west-1");

		public static readonly BucketLocationConstraint UsWest1 = new BucketLocationConstraint("us-west-1");

		public static readonly BucketLocationConstraint UsWest2 = new BucketLocationConstraint("us-west-2");

		public BucketLocationConstraint(string value)
			: base(value)
		{
		}

		public static BucketLocationConstraint FindValue(string value)
		{
			return ConstantClass.FindValue<BucketLocationConstraint>(value);
		}

		public static implicit operator BucketLocationConstraint(string value)
		{
			return FindValue(value);
		}
	}
}
