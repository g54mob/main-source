namespace Amazon.S3.Model
{
	public class ExistingObjectReplication
	{
		public ExistingObjectReplicationStatus Status { get; set; }

		internal bool IsSetExistingObjectReplicationStatus()
		{
			return Status != null;
		}
	}
}
