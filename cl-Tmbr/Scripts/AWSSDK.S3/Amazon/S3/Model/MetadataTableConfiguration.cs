namespace Amazon.S3.Model
{
	public class MetadataTableConfiguration
	{
		private S3TablesDestination s3TablesDestination;

		public S3TablesDestination S3TablesDestination
		{
			get
			{
				return s3TablesDestination;
			}
			set
			{
				s3TablesDestination = value;
			}
		}

		internal bool IsSetS3TablesDestination()
		{
			return s3TablesDestination != null;
		}
	}
}
