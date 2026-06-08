using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class OptionalObjectAttributes : ConstantClass
	{
		public static readonly OptionalObjectAttributes RestoreStatus = new OptionalObjectAttributes("RestoreStatus");

		public OptionalObjectAttributes(string value)
			: base(value)
		{
		}

		public static OptionalObjectAttributes FindValue(string value)
		{
			return ConstantClass.FindValue<OptionalObjectAttributes>(value);
		}

		public static implicit operator OptionalObjectAttributes(string value)
		{
			return FindValue(value);
		}
	}
}
