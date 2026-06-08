namespace Amazon.S3.Model
{
	public class GetBucketMetadataTableConfigurationResult
	{
		private MetadataTableConfigurationResult metadataTableConfigurationResult;

		private string metadataTableStatus;

		private ErrorDetails errorDetails;

		public MetadataTableConfigurationResult MetadataTableConfigurationResult
		{
			get
			{
				return metadataTableConfigurationResult;
			}
			set
			{
				metadataTableConfigurationResult = value;
			}
		}

		public string Status
		{
			get
			{
				return metadataTableStatus;
			}
			set
			{
				metadataTableStatus = value;
			}
		}

		public ErrorDetails Error
		{
			get
			{
				return errorDetails;
			}
			set
			{
				errorDetails = value;
			}
		}
	}
}
