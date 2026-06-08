using Amazon.Runtime;

namespace Amazon.S3
{
	public class BucketType : ConstantClass
	{
		public static readonly BucketType Directory = new BucketType("Directory");

		public BucketType(string value)
			: base(value)
		{
		}

		public static BucketType FindValue(string value)
		{
			return ConstantClass.FindValue<BucketType>(value);
		}

		public static implicit operator BucketType(string value)
		{
			return FindValue(value);
		}
	}
}
