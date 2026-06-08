namespace Amazon.S3.Model
{
	public class S3BucketVersioningConfig
	{
		private bool? enableMfaDelete;

		private VersionStatus status = "Off";

		public bool? EnableMfaDelete
		{
			get
			{
				return enableMfaDelete;
			}
			set
			{
				enableMfaDelete = value;
			}
		}

		public VersionStatus Status
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

		internal bool IsSetEnableMfaDelete()
		{
			return enableMfaDelete.HasValue;
		}

		internal bool IsSetStatus()
		{
			if (status != null)
			{
				return status != VersionStatus.Off;
			}
			return false;
		}
	}
}
