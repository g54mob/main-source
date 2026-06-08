using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class ExistingObjectReplicationStatus : ConstantClass
	{
		public static readonly ExistingObjectReplicationStatus Enabled = new ExistingObjectReplicationStatus("Enabled");

		public static readonly ExistingObjectReplicationStatus Disabled = new ExistingObjectReplicationStatus("Disabled");

		public ExistingObjectReplicationStatus(string value)
			: base(value)
		{
		}

		public static ExistingObjectReplicationStatus FindValue(string value)
		{
			return ConstantClass.FindValue<ExistingObjectReplicationStatus>(value);
		}

		public static implicit operator ExistingObjectReplicationStatus(string value)
		{
			return FindValue(value);
		}
	}
}
