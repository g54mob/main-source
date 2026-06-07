namespace Jundroo.Juicy.Widgets.Serialization
{
	public static class CanvasAttributes
	{
		public static AttributeSet Set { get; private set; }

		static CanvasAttributes()
		{
			Set = new AttributeSet();
			WidgetAttributes.Generate(Set);
		}

		public static void Generate(AttributeSet set)
		{
		}
	}
}
