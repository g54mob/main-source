namespace Amazon.S3.Model
{
	public class S3TablesDestination
	{
		private string tableBucketArn;

		private string tableName;

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

		internal bool IsSetTableBucketArn()
		{
			return !string.IsNullOrEmpty(tableBucketArn);
		}

		internal bool IsSetTableName()
		{
			return !string.IsNullOrEmpty(tableName);
		}
	}
}
