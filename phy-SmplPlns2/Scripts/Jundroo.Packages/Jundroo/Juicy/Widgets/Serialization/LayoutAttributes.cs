using UnityEngine;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public static class LayoutAttributes
	{
		public static AttributeSet Set { get; private set; }

		static LayoutAttributes()
		{
			Set = new AttributeSet();
			WidgetAttributes.Generate(Set);
			Generate(Set);
		}

		public static void Generate(AttributeSet set)
		{
			set.AddEnum("childAlignment", delegate(LayoutWidget w, TextAnchor x)
			{
				w.LayoutGroup.childAlignment = x;
			});
			set.AddBool("childForceExpandWidth", delegate(LayoutWidget w, bool x)
			{
				w.LayoutGroup.childForceExpandWidth = x;
			});
			set.AddBool("childForceExpandHeight", delegate(LayoutWidget w, bool x)
			{
				w.LayoutGroup.childForceExpandHeight = x;
			});
			set.AddBool("childControlWidth", delegate(LayoutWidget w, bool x)
			{
				w.LayoutGroup.childControlWidth = x;
			});
			set.AddBool("childControlHeight", delegate(LayoutWidget w, bool x)
			{
				w.LayoutGroup.childControlHeight = x;
			});
			set.AddBool("childScaleWidth", delegate(LayoutWidget w, bool x)
			{
				w.LayoutGroup.childScaleWidth = x;
			});
			set.AddBool("childScaleHeight", delegate(LayoutWidget w, bool x)
			{
				w.LayoutGroup.childScaleHeight = x;
			});
			set.AddString("itemTemplate", delegate(LayoutWidget w, string x)
			{
				w.ItemTemplate = x;
			});
			set.AddString("items", delegate(LayoutWidget w, string x)
			{
				w.ItemsModelBindingPath = x;
			});
			set.AddRectOffset("padding", delegate(LayoutWidget w, RectOffset x)
			{
				w.LayoutGroup.padding = x;
			});
			set.AddInt("padding-top", delegate(LayoutWidget w, int x)
			{
				w.LayoutGroup.padding.top = x;
			});
			set.AddInt("padding-right", delegate(LayoutWidget w, int x)
			{
				w.LayoutGroup.padding.right = x;
			});
			set.AddInt("padding-bottom", delegate(LayoutWidget w, int x)
			{
				w.LayoutGroup.padding.bottom = x;
			});
			set.AddInt("padding-left", delegate(LayoutWidget w, int x)
			{
				w.LayoutGroup.padding.left = x;
			});
			set.AddFloat("spacing", delegate(LayoutWidget w, float x)
			{
				w.LayoutGroup.spacing = x;
			});
			set.AddEnum("sizeFitter", delegate(LayoutWidget w, LayoutWidget.SizeFitterOption x)
			{
				w.SizeFitter = x;
			});
			set.AddFloat("maxWidth", delegate(LayoutWidget w, float x)
			{
				w.MaxWidth = x;
			}, (LayoutWidget w) => w.MaxWidth);
			set.AddFloat("maxHeight", delegate(LayoutWidget w, float x)
			{
				w.MaxHeight = x;
			}, (LayoutWidget w) => w.MaxHeight);
		}
	}
}
