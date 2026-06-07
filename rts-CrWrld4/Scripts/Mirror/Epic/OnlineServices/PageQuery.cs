namespace Epic.OnlineServices
{
	public class PageQuery : ISettable
	{
		public int StartIndex { get; set; }

		public int MaxCount { get; set; }

		internal void Set(PageQueryInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}
