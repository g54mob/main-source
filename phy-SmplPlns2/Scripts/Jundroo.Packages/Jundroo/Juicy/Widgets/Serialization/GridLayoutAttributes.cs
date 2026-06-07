using UnityEngine;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public static class GridLayoutAttributes
	{
		public static AttributeSet Set { get; private set; }

		static GridLayoutAttributes()
		{
			Set = new AttributeSet();
			WidgetAttributes.Generate(Set);
			Generate(Set);
		}

		public static void Generate(AttributeSet set)
		{
			set.AddVector2("cellSize", delegate(GridLayoutWidget w, Vector2 x)
			{
				w.GridLayout.cellSize = x;
			});
			set.AddEnum("childAlignment", delegate(GridLayoutWidget w, TextAnchor x)
			{
				w.GridLayout.childAlignment = x;
			});
			set.AddEnum("constraint", delegate(GridLayoutWidget w, GridLayoutGroup.Constraint x)
			{
				w.GridLayout.constraint = x;
			});
			set.AddInt("constraintCount", delegate(GridLayoutWidget w, int x)
			{
				w.GridLayout.constraintCount = x;
			});
			set.AddRectOffset("padding", delegate(GridLayoutWidget w, RectOffset x)
			{
				w.GridLayout.padding = x;
			});
			set.AddInt("padding-top", delegate(GridLayoutWidget w, int x)
			{
				w.GridLayout.padding.top = x;
			});
			set.AddInt("padding-right", delegate(GridLayoutWidget w, int x)
			{
				w.GridLayout.padding.right = x;
			});
			set.AddInt("padding-bottom", delegate(GridLayoutWidget w, int x)
			{
				w.GridLayout.padding.bottom = x;
			});
			set.AddInt("padding-left", delegate(GridLayoutWidget w, int x)
			{
				w.GridLayout.padding.left = x;
			});
			set.AddVector2("spacing", delegate(GridLayoutWidget w, Vector2 x)
			{
				w.GridLayout.spacing = x;
			});
			set.AddEnum("startCorner", delegate(GridLayoutWidget w, GridLayoutGroup.Corner x)
			{
				w.GridLayout.startCorner = x;
			});
			set.AddEnum("startAxis", delegate(GridLayoutWidget w, GridLayoutGroup.Axis x)
			{
				w.GridLayout.startAxis = x;
			});
			set.AddEnum("sizeFitter", delegate(GridLayoutWidget w, LayoutWidget.SizeFitterOption x)
			{
				w.SizeFitter = x;
			});
		}
	}
}
