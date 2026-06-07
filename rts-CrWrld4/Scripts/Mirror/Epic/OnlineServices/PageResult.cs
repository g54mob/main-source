namespace Epic.OnlineServices
{
	public class PageResult : ISettable
	{
		public int StartIndex { get; set; }

		public int Count { get; set; }

		public int TotalCount { get; set; }

		internal void Set(PageResultInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
