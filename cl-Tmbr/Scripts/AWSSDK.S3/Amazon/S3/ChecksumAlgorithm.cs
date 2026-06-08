using Amazon.Runtime;

namespace Amazon.S3
{
	public class ChecksumAlgorithm : ConstantClass
	{
		public static readonly ChecksumAlgorithm CRC32 = new ChecksumAlgorithm("CRC32");

		public static readonly ChecksumAlgorithm CRC32C = new ChecksumAlgorithm("CRC32C");

		public static readonly ChecksumAlgorithm CRC64NVME = new ChecksumAlgorithm("CRC64NVME");

		public static readonly ChecksumAlgorithm SHA1 = new ChecksumAlgorithm("SHA1");

		public static readonly ChecksumAlgorithm SHA256 = new ChecksumAlgorithm("SHA256");

		public ChecksumAlgorithm(string value)
			: base(value)
		{
		}

		public static ChecksumAlgorithm FindValue(string value)
		{
			return ConstantClass.FindValue<ChecksumAlgorithm>(value);
		}

		public static implicit operator ChecksumAlgorithm(string value)
		{
			return FindValue(value);
		}
	}
}
