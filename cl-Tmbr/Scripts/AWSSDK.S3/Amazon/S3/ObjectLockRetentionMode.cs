using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class ObjectLockRetentionMode : ConstantClass
	{
		public static readonly ObjectLockRetentionMode Governance = new ObjectLockRetentionMode("GOVERNANCE");

		public static readonly ObjectLockRetentionMode Compliance = new ObjectLockRetentionMode("COMPLIANCE");

		public ObjectLockRetentionMode(string value)
			: base(value)
		{
		}

		public static ObjectLockRetentionMode FindValue(string value)
		{
			return ConstantClass.FindValue<ObjectLockRetentionMode>(value);
		}

		public static implicit operator ObjectLockRetentionMode(string value)
		{
			return FindValue(value);
		}
	}
}
