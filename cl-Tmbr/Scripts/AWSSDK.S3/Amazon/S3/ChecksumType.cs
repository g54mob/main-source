using Amazon.Runtime;

namespace Amazon.S3
{
	public class ChecksumType : ConstantClass
	{
		public static readonly ChecksumType COMPOSITE = new ChecksumType("COMPOSITE");

		public static readonly ChecksumType FULL_OBJECT = new ChecksumType("FULL_OBJECT");

		public ChecksumType(string value)
			: base(value)
		{
		}

		public static ChecksumType FindValue(string value)
		{
			return ConstantClass.FindValue<ChecksumType>(value);
		}

		public static implicit operator ChecksumType(string value)
		{
			return FindValue(value);
		}
	}
}
