using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class ObjectLockMode : ConstantClass
	{
		public static readonly ObjectLockMode Governance = new ObjectLockMode("GOVERNANCE");

		public static readonly ObjectLockMode Compliance = new ObjectLockMode("COMPLIANCE");

		public ObjectLockMode(string value)
			: base(value)
		{
		}

		public static ObjectLockMode FindValue(string value)
		{
			return ConstantClass.FindValue<ObjectLockMode>(value);
		}

		public static implicit operator ObjectLockMode(string value)
		{
			return FindValue(value);
		}
	}
}
