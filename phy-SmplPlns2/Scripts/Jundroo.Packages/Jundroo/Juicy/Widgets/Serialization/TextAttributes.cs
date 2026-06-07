using TMPro;
using UnityEngine;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public static class TextAttributes
	{
		public static AttributeSet Set { get; private set; }

		static TextAttributes()
		{
			Set = new AttributeSet();
			WidgetAttributes.Generate(Set);
			Generate(Set);
		}

		public static void Generate(AttributeSet set)
		{
			set.AddEnum("alignment", delegate(TextWidget w, TextAlignmentOptions x)
			{
				w.TextMeshPro.alignment = x;
			});
			set.AddBool("autoSize", delegate(TextWidget w, bool x)
			{
				w.TextMeshPro.enableAutoSizing = x;
			});
			set.AddBool("allowLinks", delegate(TextWidget w, bool x)
			{
				w.AllowLinks = x;
			});
			set.AddInt("characterLimit", delegate(TextWidget w, int x)
			{
				w.CharacterLimit = x;
			});
			set.AddColor("color", delegate(TextWidget w, Color x)
			{
				w.Color.Base = x;
			}, (TextWidget w) => w.Color.Base);
			set.AddFloat("colorAlpha", delegate(TextWidget w, float x)
			{
				w.Color.Alpha = x;
			}, (TextWidget w) => w.Color.Alpha);
			set.AddFloat("colorMultiply", delegate(TextWidget w, float x)
			{
				w.Color.Multiply = x;
			}, (TextWidget w) => w.Color.Multiply);
			set.AddString("font", delegate(TextWidget w, string s)
			{
				w.TextMeshPro.font = w.Context.ResourceLoader.LoadFont(s);
			});
			set.AddString("fontMaterial", delegate(TextWidget w, string s)
			{
				w.TextMeshPro.fontMaterial = w.Context.ResourceLoader.LoadMaterial(s);
			});
			set.AddFloat("fontSize", delegate(TextWidget w, float x)
			{
				w.TextMeshPro.fontSize = x;
			});
			set.AddFloat("fontSizeMin", delegate(TextWidget w, float x)
			{
				w.TextMeshPro.fontSizeMin = x;
			});
			set.AddFloat("fontSizeMax", delegate(TextWidget w, float x)
			{
				w.TextMeshPro.fontSizeMax = x;
			});
			set.AddEnum("fontStyle", delegate(TextWidget w, FontStyles x)
			{
				w.TextMeshPro.fontStyle = x;
			}, combineList: true);
			set.AddEnum("overflow", delegate(TextWidget w, TextOverflowModes x)
			{
				w.TextMeshPro.overflowMode = x;
			});
			set.AddBool("raycastTarget", delegate(TextWidget w, bool x)
			{
				w.TextMeshPro.raycastTarget = x;
			});
			set.AddBool("allowRichText", delegate(TextWidget w, bool x)
			{
				w.TextMeshPro.richText = x;
			});
			set.AddString("text", delegate(TextWidget w, string x)
			{
				w.SetText(x, setStyle: false);
			});
			set.AddString("richText", delegate(TextWidget w, string x)
			{
				w.RichText = x;
			});
			set.AddBool("wordWrapping", delegate(TextWidget w, bool x)
			{
				w.TextMeshPro.textWrappingMode = (x ? TextWrappingModes.Normal : TextWrappingModes.NoWrap);
			});
		}
	}
}
