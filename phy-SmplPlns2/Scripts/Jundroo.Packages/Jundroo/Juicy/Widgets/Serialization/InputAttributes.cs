using TMPro;
using UnityEngine;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public static class InputAttributes
	{
		public static AttributeSet Set { get; private set; }

		static InputAttributes()
		{
			Set = new AttributeSet();
			WidgetAttributes.Generate(Set);
			ImageAttributes.Generate(Set);
			SelectableAttributes.Generate(Set);
			Generate(Set);
		}

		public static void Generate(AttributeSet set)
		{
			set.AddBool("allowDragEventToBubble", delegate(InputWidget w, bool x)
			{
				w.Input.AllowDragEventToBubble = x;
			});
			set.AddString("text", delegate(InputWidget w, string x)
			{
				w.Text = x;
			});
			set.AddString("placeholderText", delegate(InputWidget w, string x)
			{
				w.Placeholder.text = x;
			});
			set.AddEnum("alignment", delegate(InputWidget w, TextAlignmentOptions x)
			{
				w.TextMeshPro.alignment = x;
				w.Placeholder.alignment = x;
			});
			set.AddString("font", delegate(InputWidget w, string s)
			{
				w.Input.fontAsset = w.Context.ResourceLoader.LoadFont(s);
			});
			set.AddFloat("fontSize", delegate(InputWidget w, float x)
			{
				w.Input.pointSize = x;
			});
			set.AddRectOffset("padding", delegate(InputWidget w, RectOffset x)
			{
				w.Padding = x;
			});
			set.AddInt("padding-top", delegate(InputWidget w, int x)
			{
				RectOffset padding = w.Padding;
				padding.top = x;
				w.Padding = padding;
			});
			set.AddInt("padding-right", delegate(InputWidget w, int x)
			{
				RectOffset padding = w.Padding;
				padding.right = x;
				w.Padding = padding;
			});
			set.AddInt("padding-bottom", delegate(InputWidget w, int x)
			{
				RectOffset padding = w.Padding;
				padding.bottom = x;
				w.Padding = padding;
			});
			set.AddInt("padding-left", delegate(InputWidget w, int x)
			{
				RectOffset padding = w.Padding;
				padding.left = x;
				w.Padding = padding;
			});
			set.AddColor("textColor", delegate(InputWidget w, Color x)
			{
				w.TextColor.Base = x;
			}, (InputWidget w) => w.TextColor.Base);
			set.AddFloat("textColorAlpha", delegate(InputWidget w, float x)
			{
				w.TextColor.Alpha = x;
			}, (InputWidget w) => w.TextColor.Alpha);
			set.AddFloat("textColorMultiply", delegate(InputWidget w, float x)
			{
				w.TextColor.Multiply = x;
			}, (InputWidget w) => w.TextColor.Multiply);
			set.AddColor("placeholderColor", delegate(InputWidget w, Color x)
			{
				w.PlaceholderColor.Base = x;
			}, (InputWidget w) => w.PlaceholderColor.Base);
			set.AddFloat("placeholderColorAlpha", delegate(InputWidget w, float x)
			{
				w.PlaceholderColor.Alpha = x;
			}, (InputWidget w) => w.PlaceholderColor.Alpha);
			set.AddFloat("placeholderColorMultiply", delegate(InputWidget w, float x)
			{
				w.PlaceholderColor.Multiply = x;
			}, (InputWidget w) => w.PlaceholderColor.Multiply);
			set.AddColor("backgroundColor", delegate(InputWidget w, Color x)
			{
				w.BackgroundColor.Base = x;
			}, (InputWidget w) => w.BackgroundColor.Base);
			set.AddFloat("backgroundColorAlpha", delegate(InputWidget w, float x)
			{
				w.BackgroundColor.Alpha = x;
			}, (InputWidget w) => w.BackgroundColor.Alpha);
			set.AddFloat("backgroundColorMultiply", delegate(InputWidget w, float x)
			{
				w.BackgroundColor.Multiply = x;
			}, (InputWidget w) => w.BackgroundColor.Multiply);
			set.AddEnum("lineType", delegate(InputWidget w, TMP_InputField.LineType x)
			{
				w.Input.lineType = x;
			});
			set.AddEnum("contentType", delegate(InputWidget w, TMP_InputField.ContentType x)
			{
				w.Input.contentType = x;
			});
			set.AddString("validationRegex", delegate(InputWidget w, string x)
			{
				w.ValidationRegex = x;
			});
			set.AddEnum("overflow", delegate(InputWidget w, TextOverflowModes x)
			{
				w.TextMeshPro.overflowMode = x;
				w.Placeholder.overflowMode = x;
			});
			set.AddBool("wordWrapping", delegate(InputWidget w, bool x)
			{
				w.TextMeshPro.textWrappingMode = (x ? TextWrappingModes.Normal : TextWrappingModes.NoWrap);
				w.Placeholder.textWrappingMode = (x ? TextWrappingModes.Normal : TextWrappingModes.NoWrap);
			});
			set.AddBool("enableSubLayout", delegate(InputWidget w, bool x)
			{
				w.EnableSubLayout = x;
			});
		}
	}
}
