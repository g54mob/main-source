using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class ObjectLockEnabled : ConstantClass
	{
		public static readonly ObjectLockEnabled Enabled = new ObjectLockEnabled("Enabled");

		public ObjectLockEnabled(string value)
			: base(value)
		{
		}

		public static ObjectLockEnabled FindValue(string value)
		{
			return ConstantClass.FindValue<ObjectLockEnabled>(value);
		}

		public static implicit operator ObjectLockEnabled(string value)
		{
			return FindValue(value);
		}
	}
}
