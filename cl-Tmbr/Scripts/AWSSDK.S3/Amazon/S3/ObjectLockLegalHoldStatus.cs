using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class ObjectLockLegalHoldStatus : ConstantClass
	{
		public static readonly ObjectLockLegalHoldStatus On = new ObjectLockLegalHoldStatus("ON");

		public static readonly ObjectLockLegalHoldStatus Off = new ObjectLockLegalHoldStatus("OFF");

		public ObjectLockLegalHoldStatus(string value)
			: base(value)
		{
		}

		public static ObjectLockLegalHoldStatus FindValue(string value)
		{
			return ConstantClass.FindValue<ObjectLockLegalHoldStatus>(value);
		}

		public static implicit operator ObjectLockLegalHoldStatus(string value)
		{
			return FindValue(value);
		}
	}
}
