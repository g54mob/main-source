namespace Amazon.S3.Model
{
	public class DeleteMarkerReplication
	{
		private DeleteMarkerReplicationStatus status;

		public DeleteMarkerReplicationStatus Status
		{
			get
			{
				return status;
			}
			set
			{
				status = value;
			}
		}

		internal bool IsSetStatus()
		{
			return status != null;
		}
	}
}
