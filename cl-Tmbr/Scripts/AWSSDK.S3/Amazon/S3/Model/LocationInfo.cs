namespace Amazon.S3.Model
{
	public class LocationInfo
	{
		private string _name;

		private LocationType _type;

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public LocationType Type
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

		internal bool IsSetName()
		{
			return _name != null;
		}

		internal bool IsSetType()
		{
			return _type != null;
		}
	}
}
