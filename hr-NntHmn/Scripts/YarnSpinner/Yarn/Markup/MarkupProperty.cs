namespace Yarn.Markup
{
	public struct MarkupProperty
	{
		public string Name { get; private set; }

		public MarkupValue Value { get; private set; }

		internal MarkupProperty(string name, MarkupValue value)
		{
			Name = null;
			Value = default(MarkupValue);
		}
	}
}
