namespace Epic.OnlineServices.Sessions
{
	public class AttributeData : ISettable
	{
		public string Key { get; set; }

		public AttributeDataValue Value { get; set; }

		internal void Set(AttributeDataInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
