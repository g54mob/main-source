namespace ZLinq.Linq
{
	internal struct FromEnumerableContent
	{
		public object Source;

		public int Index;

		public FromEnumerableContent(object source)
		{
			Source = null;
			Index = 0;
		}

		public void ThrowIfNoEnumerable()
		{
		}
	}
}
