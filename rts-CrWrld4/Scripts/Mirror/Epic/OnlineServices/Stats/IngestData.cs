namespace Epic.OnlineServices.Stats
{
	public class IngestData : ISettable
	{
		public string StatName { get; set; }

		public int IngestAmount { get; set; }

		internal void Set(IngestDataInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
