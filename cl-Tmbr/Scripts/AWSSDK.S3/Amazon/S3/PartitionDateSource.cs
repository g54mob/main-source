using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class PartitionDateSource : ConstantClass
	{
		public static readonly PartitionDateSource DeliveryTime = new PartitionDateSource("DeliveryTime");

		public static readonly PartitionDateSource EventTime = new PartitionDateSource("EventTime");

		public PartitionDateSource(string value)
			: base(value)
		{
		}

		public static PartitionDateSource FindValue(string value)
		{
			return ConstantClass.FindValue<PartitionDateSource>(value);
		}

		public static implicit operator PartitionDateSource(string value)
		{
			return FindValue(value);
		}
	}
}
