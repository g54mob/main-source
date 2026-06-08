namespace Amazon.S3.Model
{
	public class PartitionedPrefix
	{
		private PartitionDateSource _partitionDateSource;

		public PartitionDateSource PartitionDateSource
		{
			get
			{
				return _partitionDateSource;
			}
			set
			{
				_partitionDateSource = value;
			}
		}

		internal bool IsSetPartitionDateSource()
		{
			return _partitionDateSource != null;
		}
	}
}
