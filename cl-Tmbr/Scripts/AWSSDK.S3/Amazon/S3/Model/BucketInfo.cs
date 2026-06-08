namespace Amazon.S3.Model
{
	public class BucketInfo
	{
		private DataRedundancy _dataRedundancy;

		private BucketType _type;

		public DataRedundancy DataRedundancy
		{
			get
			{
				return _dataRedundancy;
			}
			set
			{
				_dataRedundancy = value;
			}
		}

		public BucketType Type
		{
			get
			{
				return _type;
			}
			set
			{
				_type = value;
			}
		}

		internal bool IsSetDataRedundancy()
		{
			return _dataRedundancy != null;
		}

		internal bool IsSetType()
		{
			return _type != null;
		}
	}
}
