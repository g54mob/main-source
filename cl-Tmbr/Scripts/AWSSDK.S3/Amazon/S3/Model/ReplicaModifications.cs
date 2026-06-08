namespace Amazon.S3.Model
{
	public class ReplicaModifications
	{
		private ReplicaModificationsStatus status;

		public ReplicaModificationsStatus Status
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
