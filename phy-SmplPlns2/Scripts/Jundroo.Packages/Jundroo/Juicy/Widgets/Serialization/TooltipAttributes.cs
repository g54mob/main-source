namespace Jundroo.Juicy.Widgets.Serialization
{
	public static class TooltipAttributes
	{
		public static AttributeSet Set { get; private set; }

		static TooltipAttributes()
		{
			Set = new AttributeSet();
			WidgetAttributes.Generate(Set);
			LayoutAttributes.Generate(Set);
			Generate(Set);
		}

		public static void Generate(AttributeSet set)
		{
			set.AddFloat("tooltipDuration", delegate(TooltipWidget w, float x)
			{
				w.TooltipDuration = x;
			});
			set.AddFloat("distance", delegate(TooltipWidget w, float x)
			{
				w.Distance = x;
			});
		}
	}
}
