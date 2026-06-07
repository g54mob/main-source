using UnityEngine;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public static class RawImageAttributes
	{
		public static AttributeSet Set { get; private set; }

		static RawImageAttributes()
		{
			Set = new AttributeSet();
			WidgetAttributes.Generate(Set);
			Generate(Set);
		}

		public static void Generate(AttributeSet set)
		{
			set.AddColor("color", delegate(RawImageWidget w, Color x)
			{
				w.Color.Base = x;
			}, (RawImageWidget w) => w.Color.Base);
			set.AddFloat("colorAlpha", delegate(RawImageWidget w, float x)
			{
				w.Color.Alpha = x;
			}, (RawImageWidget w) => w.Color.Alpha);
			set.AddFloat("colorMultiply", delegate(RawImageWidget w, float x)
			{
				w.Color.Multiply = x;
			}, (RawImageWidget w) => w.Color.Multiply);
			set.AddString("texture", delegate(RawImageWidget w, string x)
			{
				w.Texture = w.Context.ResourceLoader.LoadTexture(x);
			});
			set.AddBool("raycastTarget", delegate(RawImageWidget w, bool x)
			{
				w.Image.raycastTarget = x;
			});
			set.AddRectOffset("raycastPadding", delegate(RawImageWidget w, RectOffset x)
			{
				w.Image.raycastPadding = RectHelper.RectOffsetToVector4Padding(x);
			});
			set.AddBool("preserveAspect", delegate(RawImageWidget w, bool x)
			{
				w.PreserveAspect = x;
			});
			set.AddVector2("uvRectMin", delegate(RawImageWidget w, Vector2 x)
			{
				Rect uvRect = w.Image.uvRect;
				uvRect.min = x;
				w.Image.uvRect = uvRect;
			});
			set.AddVector2("uvRectMax", delegate(RawImageWidget w, Vector2 x)
			{
				Rect uvRect = w.Image.uvRect;
				uvRect.max = x;
				w.Image.uvRect = uvRect;
			});
		}
	}
}
