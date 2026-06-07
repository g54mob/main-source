using UnityEngine;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public static class ToggleAttributes
	{
		public static AttributeSet Set { get; private set; }

		static ToggleAttributes()
		{
			Set = new AttributeSet();
			WidgetAttributes.Generate(Set);
			SelectableAttributes.Generate(Set);
			Generate(Set);
		}

		public static void Generate(AttributeSet set)
		{
			set.AddBool("isOn", delegate(ToggleWidget w, bool x)
			{
				w.IsOn = x;
			});
			set.AddString("onClass", delegate(ToggleWidget w, string x)
			{
				w.OnClass = x;
			});
			set.AddColor("backgroundColor", delegate(ToggleWidget w, Color x)
			{
				w.BackgroundColor.Base = x;
			}, (ToggleWidget w) => w.BackgroundColor.Base);
			set.AddFloat("backgroundColorAlpha", delegate(ToggleWidget w, float x)
			{
				w.BackgroundColor.Alpha = x;
			}, (ToggleWidget w) => w.BackgroundColor.Alpha);
			set.AddFloat("backgroundColorMultiply", delegate(ToggleWidget w, float x)
			{
				w.BackgroundColor.Multiply = x;
			}, (ToggleWidget w) => w.BackgroundColor.Multiply);
			set.AddColor("checkColor", delegate(ToggleWidget w, Color x)
			{
				w.CheckColor.Base = x;
			}, (ToggleWidget w) => w.CheckColor.Base);
			set.AddFloat("checkColorAlpha", delegate(ToggleWidget w, float x)
			{
				w.CheckColor.Alpha = x;
			}, (ToggleWidget w) => w.CheckColor.Alpha);
			set.AddFloat("checkColorMultiply", delegate(ToggleWidget w, float x)
			{
				w.CheckColor.Multiply = x;
			}, (ToggleWidget w) => w.CheckColor.Multiply);
		}
	}
}
