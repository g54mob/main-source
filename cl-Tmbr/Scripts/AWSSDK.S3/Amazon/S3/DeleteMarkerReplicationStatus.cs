using Amazon.Runtime;

namespace Amazon.S3
{
	public sealed class DeleteMarkerReplicationStatus : ConstantClass
	{
		public static readonly DeleteMarkerReplicationStatus Enabled = new DeleteMarkerReplicationStatus("Enabled");

		public static readonly DeleteMarkerReplicationStatus Disabled = new DeleteMarkerReplicationStatus("Disabled");

		public DeleteMarkerReplicationStatus(string value)
			: base(value)
		{
		}

		public static DeleteMarkerReplicationStatus FindValue(string value)
		{
			return ConstantClass.FindValue<DeleteMarkerReplicationStatus>(value);
		}

		public static implicit operator DeleteMarkerReplicationStatus(string value)
		{
			return FindValue(value);
		}
	}
}
