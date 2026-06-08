using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class CompressionType : ConstantClass
	{
		public static readonly CompressionType None = new CompressionType("NONE");

		public static readonly CompressionType Gzip = new CompressionType("GZIP");

		public static readonly CompressionType Bzip2 = new CompressionType("BZIP2");

		public CompressionType(string value)
			: base(value)
		{
		}

		public static CompressionType FindValue(string value)
		{
			return ConstantClass.FindValue<CompressionType>(value);
		}

		public static implicit operator CompressionType(string value)
		{
			return FindValue(value);
		}
	}
}
