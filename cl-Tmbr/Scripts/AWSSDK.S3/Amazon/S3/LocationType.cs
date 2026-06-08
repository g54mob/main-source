using Amazon.Runtime;

namespace Amazon.S3
{
	public class LocationType : ConstantClass
	{
		public static readonly LocationType AvailabilityZone = new LocationType("AvailabilityZone");

		public static readonly LocationType LocalZone = new LocationType("LocalZone");

		public LocationType(string value)
			: base(value)
		{
		}

		public static LocationType FindValue(string value)
		{
			return ConstantClass.FindValue<LocationType>(value);
		}

		public static implicit operator LocationType(string value)
		{
			return FindValue(value);
		}
	}
}
