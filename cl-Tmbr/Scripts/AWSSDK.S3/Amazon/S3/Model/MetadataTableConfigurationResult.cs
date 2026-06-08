namespace Amazon.S3.Model
{
	public class MetadataTableConfigurationResult
	{
		private S3TablesDestinationResult s3TablesDestinationResult;

		public S3TablesDestinationResult S3TablesDestinationResult
		{
			get
			{
				return s3TablesDestinationResult;
			}
			set
			{
				s3TablesDestinationResult = value;
			}
		}
	}
}
