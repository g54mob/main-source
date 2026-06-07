namespace Epic.OnlineServices.Presence
{
	public class DataRecord : ISettable
	{
		public string Key { get; set; }

		public string Value { get; set; }

		internal void Set(DataRecordInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
