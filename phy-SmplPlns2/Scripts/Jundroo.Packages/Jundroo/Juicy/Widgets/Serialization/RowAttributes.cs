using UnityEngine;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public static class RowAttributes
	{
		public static AttributeSet Set { get; private set; }

		static RowAttributes()
		{
			Set = new AttributeSet();
			WidgetAttributes.Generate(Set);
			Generate(Set);
		}

		public static void Generate(AttributeSet set)
		{
			set.AddInt("numColumns", delegate(RowWidget w, int x)
			{
				w.NumColumns = x;
			});
			set.AddRectOffset("padding", delegate(RowWidget w, RectOffset x)
			{
				w.Padding = x;
			});
			set.AddInt("padding-top", delegate(RowWidget w, int x)
			{
				w.Padding.top = x;
			});
			set.AddInt("padding-right", delegate(RowWidget w, int x)
			{
				w.Padding.right = x;
			});
			set.AddInt("padding-bottom", delegate(RowWidget w, int x)
			{
				w.Padding.bottom = x;
			});
			set.AddInt("padding-left", delegate(RowWidget w, int x)
			{
				w.Padding.left = x;
			});
			set.AddFloat("spacing", delegate(RowWidget w, float x)
			{
				w.CellPadding = x;
			});
		}
	}
}
