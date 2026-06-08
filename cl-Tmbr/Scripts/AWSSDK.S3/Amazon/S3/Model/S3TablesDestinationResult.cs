namespace Amazon.S3.Model
{
	public class S3TablesDestinationResult
	{
		private string tableBucketArn;

		private string tableArn;

		private string tableName;

		private string tableNamespace;

		public string TableBucketArn
		{
			get
			{
				return tableBucketArn;
			}
			set
			{
				tableBucketArn = value;
			}
		}

		public string TableArn
		{
			get
			{
				return tableArn;
			}
			set
			{
				tableArn = value;
			}
		}

		public string TableName
		{
			get
			{
				return tableName;
			}
			set
			{
				tableName = value;
			}
		}

		public string TableNamespace
		{
			get
			{
				return tableNamespace;
			}
			set
			{
				tableNamespace = value;
			}
		}
	}
}
