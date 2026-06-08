using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class S3Region : ConstantClass
	{
		public static readonly S3Region AFSouth1 = new S3Region("af-south-1");

		public static readonly S3Region APEast1 = new S3Region("ap-east-1");

		public static readonly S3Region APNortheast1 = new S3Region("ap-northeast-1");

		public static readonly S3Region APNortheast2 = new S3Region("ap-northeast-2");

		public static readonly S3Region APNortheast3 = new S3Region("ap-northeast-3");

		public static readonly S3Region APSouth1 = new S3Region("ap-south-1");

		public static readonly S3Region APSouth2 = new S3Region("ap-south-2");

		public static readonly S3Region APSoutheast1 = new S3Region("ap-southeast-1");

		public static readonly S3Region APSoutheast2 = new S3Region("ap-southeast-2");

		public static readonly S3Region APSoutheast3 = new S3Region("ap-southeast-3");

		public static readonly S3Region APSoutheast4 = new S3Region("ap-southeast-4");

		public static readonly S3Region APSoutheast5 = new S3Region("ap-southeast-5");

		public static readonly S3Region APSoutheast7 = new S3Region("ap-southeast-7");

		public static readonly S3Region CACentral1 = new S3Region("ca-central-1");

		public static readonly S3Region CAWest1 = new S3Region("ca-west-1");

		public static readonly S3Region EUCentral1 = new S3Region("eu-central-1");

		public static readonly S3Region EUCentral2 = new S3Region("eu-central-2");

		public static readonly S3Region EUNorth1 = new S3Region("eu-north-1");

		public static readonly S3Region EUSouth1 = new S3Region("eu-south-1");

		public static readonly S3Region EUSouth2 = new S3Region("eu-south-2");

		public static readonly S3Region EUWest1 = new S3Region("EU");

		public static readonly S3Region EUWest2 = new S3Region("eu-west-2");

		public static readonly S3Region EUWest3 = new S3Region("eu-west-3");

		public static readonly S3Region ILCentral1 = new S3Region("il-central-1");

		public static readonly S3Region MECentral1 = new S3Region("me-central-1");

		public static readonly S3Region MESouth1 = new S3Region("me-south-1");

		public static readonly S3Region MXCentral1 = new S3Region("mx-central-1");

		public static readonly S3Region SAEast1 = new S3Region("sa-east-1");

		public static readonly S3Region USEast1 = new S3Region("");

		public static readonly S3Region USEast2 = new S3Region("us-east-2");

		public static readonly S3Region USWest1 = new S3Region("us-west-1");

		public static readonly S3Region USWest2 = new S3Region("us-west-2");

		public static readonly S3Region CNNorth1 = new S3Region("cn-north-1");

		public static readonly S3Region CNNorthWest1 = new S3Region("cn-northwest-1");

		public static readonly S3Region USGovCloudEast1 = new S3Region("us-gov-east-1");

		public static readonly S3Region USGovCloudWest1 = new S3Region("us-gov-west-1");

		public static readonly S3Region USIsoEast1 = new S3Region("us-iso-east-1");

		public static readonly S3Region USIsoWest1 = new S3Region("us-iso-west-1");

		public static readonly S3Region USIsobEast1 = new S3Region("us-isob-east-1");

		public static readonly S3Region EUIsoeWest1 = new S3Region("eu-isoe-west-1");

		public static readonly S3Region USIsofEast1 = new S3Region("us-isof-east-1");

		public static readonly S3Region USIsofSouth1 = new S3Region("us-isof-south-1");

		public static readonly S3Region EUSCDeEast1 = new S3Region("eusc-de-east-1");

		public S3Region(string value)
			: base(value)
		{
		}

		public static S3Region FindValue(string value)
		{
			if (value == null)
			{
				return USEast1;
			}
			return ConstantClass.FindValue<S3Region>(value);
		}

		public static implicit operator S3Region(string value)
		{
			return FindValue(value);
		}
	}
}
