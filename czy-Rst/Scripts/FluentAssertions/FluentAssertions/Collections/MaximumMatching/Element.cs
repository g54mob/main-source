namespace FluentAssertions.Collections.MaximumMatching
{
	internal class Element<TValue>
	{
		public int Index { get; }

		public TValue Value { get; }

		public Element(TValue value, int index)
		{
			Index = index;
			Value = value;
		}
	}
}
