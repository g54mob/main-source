namespace Jundroo.Juicy.Widgets.Serialization
{
	public static class ButtonAttributes
	{
		public static AttributeSet Set { get; private set; }

		static ButtonAttributes()
		{
			Set = new AttributeSet();
			WidgetAttributes.Generate(Set);
			ImageAttributes.Generate(Set);
			SelectableAttributes.Generate(Set);
			Generate(Set);
		}

		public static void Generate(AttributeSet set)
		{
		}
	}
}
