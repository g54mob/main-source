using UnityEngine;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets.Serialization
{
	public static class ImageAttributes
	{
		public enum PpuTargetType
		{
			None = 0,
			Width = 1,
			Height = 2
		}

		public static AttributeSet Set { get; private set; }

		static ImageAttributes()
		{
			Set = new AttributeSet();
			WidgetAttributes.Generate(Set);
			Generate(Set);
		}

		public static void Generate(AttributeSet set)
		{
			set.AddColor("color", delegate(ImageWidget w, Color x)
			{
				w.Color.Base = x;
			}, (ImageWidget w) => w.Color.Base);
			set.AddFloat("colorAlpha", delegate(ImageWidget w, float x)
			{
				w.Color.Alpha = x;
			}, (ImageWidget w) => w.Color.Alpha);
			set.AddFloat("colorMultiply", delegate(ImageWidget w, float x)
			{
				w.Color.Multiply = x;
			}, (ImageWidget w) => w.Color.Multiply);
			set.AddFloat("ppuMultiplier", delegate(ImageWidget w, float x)
			{
				w.Image.pixelsPerUnitMultiplier = x;
			}, (ImageWidget w) => w.Image.pixelsPerUnitMultiplier);
			set.AddEnum("ppuTarget", delegate(ImageWidget w, PpuTargetType x)
			{
				TargetPpu(w, x, w.Width, w.Height);
			});
			set.AddEnum("mask", delegate(ImageWidget w, ImageWidgetMaskType x)
			{
				w.MaskType = x;
			});
			set.AddBool("preserveAspect", delegate(ImageWidget w, bool x)
			{
				w.Image.preserveAspect = x;
			});
			set.AddBool("raycastTarget", delegate(ImageWidget w, bool x)
			{
				w.Image.raycastTarget = x;
			});
			set.AddString("sprite", delegate(ImageWidget w, string x)
			{
				w.Image.sprite = w.Context.ResourceLoader.LoadSprite(x);
			});
			set.AddRectOffset("raycastPadding", delegate(ImageWidget w, RectOffset x)
			{
				w.Image.raycastPadding = RectHelper.RectOffsetToVector4Padding(x);
			});
			set.AddEnum("type", delegate(ImageWidget w, Image.Type x)
			{
				w.Image.type = x;
			});
			set.AddFloat("fillAmount", delegate(ImageWidget w, float x)
			{
				w.Image.fillAmount = x;
			});
			set.AddEnum("fillMethod", delegate(ImageWidget w, Image.FillMethod x)
			{
				w.Image.fillMethod = x;
			});
			set.AddInt("fillOrigin", delegate(ImageWidget w, int x)
			{
				w.Image.fillOrigin = x;
			});
			set.AddBool("fillCenter", delegate(ImageWidget w, bool x)
			{
				w.Image.fillCenter = x;
			});
			set.AddBool("setNativeSize", delegate(ImageWidget w, bool x)
			{
				if (x)
				{
					w.Image.SetNativeSize();
				}
			});
		}

		private static void TargetPpu(ImageWidget w, PpuTargetType targetType, float? width, float? height)
		{
			if (targetType == PpuTargetType.Width && width.HasValue)
			{
				w.Image.pixelsPerUnitMultiplier = w.Image.sprite.rect.width / width.Value;
			}
			else if (targetType == PpuTargetType.Height && height.HasValue)
			{
				w.Image.pixelsPerUnitMultiplier = w.Image.sprite.rect.height / height.Value;
			}
		}
	}
}
