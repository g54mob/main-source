using Jundroo.Juicy.Widgets.Extra;
using UnityEngine;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public static class SliderAttributes
	{
		public static AttributeSet Set { get; private set; }

		static SliderAttributes()
		{
			Set = new AttributeSet();
			WidgetAttributes.Generate(Set);
			SelectableAttributes.Generate(Set);
			Generate(Set);
		}

		public static void Generate(AttributeSet set)
		{
			set.AddColor("backgroundColor", delegate(SliderWidget w, Color x)
			{
				w.BackgroundColor.Base = x;
			}, (SliderWidget w) => w.BackgroundColor.Base);
			set.AddFloat("backgroundColorAlpha", delegate(SliderWidget w, float x)
			{
				w.BackgroundColor.Alpha = x;
			}, (SliderWidget w) => w.BackgroundColor.Alpha);
			set.AddFloat("backgroundColorMultiply", delegate(SliderWidget w, float x)
			{
				w.BackgroundColor.Multiply = x;
			}, (SliderWidget w) => w.BackgroundColor.Multiply);
			set.AddColor("fillColor", delegate(SliderWidget w, Color x)
			{
				w.FillColor.Base = x;
			}, (SliderWidget w) => w.FillColor.Base);
			set.AddFloat("fillColorAlpha", delegate(SliderWidget w, float x)
			{
				w.FillColor.Alpha = x;
			}, (SliderWidget w) => w.FillColor.Alpha);
			set.AddFloat("fillColorMultiply", delegate(SliderWidget w, float x)
			{
				w.FillColor.Multiply = x;
			}, (SliderWidget w) => w.FillColor.Multiply);
			set.AddString("fillSprite", delegate(SliderWidget w, string x)
			{
				w.FillImage.sprite = w.Context.ResourceLoader.LoadSprite(x);
			});
			set.AddColor("handleColor", delegate(SliderWidget w, Color x)
			{
				w.HandleColor.Base = x;
			}, (SliderWidget w) => w.HandleColor.Base);
			set.AddFloat("handleColorAlpha", delegate(SliderWidget w, float x)
			{
				w.HandleColor.Alpha = x;
			}, (SliderWidget w) => w.HandleColor.Alpha);
			set.AddFloat("handleColorMultiply", delegate(SliderWidget w, float x)
			{
				w.HandleColor.Multiply = x;
			}, (SliderWidget w) => w.HandleColor.Multiply);
			set.AddString("handleSprite", delegate(SliderWidget w, string x)
			{
				w.HandleImage.sprite = w.Context.ResourceLoader.LoadSprite(x);
			});
			set.AddVector2("handleScale", delegate(SliderWidget w, Vector2 x)
			{
				w.HandleScale = x;
			}, (SliderWidget w) => w.HandleScale);
			set.AddRectOffset("handleRaycastPadding", delegate(SliderWidget w, RectOffset x)
			{
				w.HandleImage.raycastPadding = RectHelper.RectOffsetToVector4Padding(x);
			});
			set.AddRectOffset("raycastPadding", delegate(SliderWidget w, RectOffset x)
			{
				w.BackgroundImage.raycastPadding = RectHelper.RectOffsetToVector4Padding(x);
			});
			set.AddSound("valueChangedSound", delegate(SliderWidget w, SoundData x)
			{
				w.SoundValueChanged = x;
			});
		}
	}
}
