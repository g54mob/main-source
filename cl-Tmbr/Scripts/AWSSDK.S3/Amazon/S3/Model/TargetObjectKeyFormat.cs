namespace Amazon.S3.Model
{
	public class TargetObjectKeyFormat
	{
		private PartitionedPrefix _partitionedPrefix;

		private SimplePrefix _simplePrefix;

		public PartitionedPrefix PartitionedPrefix
		{
			get
			{
				return _partitionedPrefix;
			}
			set
			{
				_partitionedPrefix = value;
			}
		}

		public SimplePrefix SimplePrefix
		{
			get
			{
				return _simplePrefix;
			}
			set
			{
				_simplePrefix = value;
			}
		}

		internal bool IsSetPartitionedPrefix()
		{
			return _partitionedPrefix != null;
		}

		internal bool IsSetSimplePrefix()
		{
			return _simplePrefix != null;
		}
	}
}
