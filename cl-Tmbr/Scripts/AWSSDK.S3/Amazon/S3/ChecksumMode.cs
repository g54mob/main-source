using Amazon.Runtime;

namespace Amazon.S3
{
	public class ChecksumMode : ConstantClass
	{
		public static readonly ChecksumMode ENABLED = new ChecksumMode("ENABLED");

		public ChecksumMode(string value)
			: base(value)
		{
		}

		public static ChecksumMode FindValue(string value)
		{
			return ConstantClass.FindValue<ChecksumMode>(value);
		}

		public static implicit operator ChecksumMode(string value)
		{
			return FindValue(value);
		}
	}
}
