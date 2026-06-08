using Amazon.Runtime;

namespace Amazon.S3
{
	public class DataRedundancy : ConstantClass
	{
		public static readonly DataRedundancy SingleAvailabilityZone = new DataRedundancy("SingleAvailabilityZone");

		public static readonly DataRedundancy SingleLocalZone = new DataRedundancy("SingleLocalZone");

		public DataRedundancy(string value)
			: base(value)
		{
		}

		public static DataRedundancy FindValue(string value)
		{
			return ConstantClass.FindValue<DataRedundancy>(value);
		}

		public static implicit operator DataRedundancy(string value)
		{
			return FindValue(value);
		}
	}
}
