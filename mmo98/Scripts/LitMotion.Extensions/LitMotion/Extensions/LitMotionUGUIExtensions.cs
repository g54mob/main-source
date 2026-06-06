using Cysharp.Text;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace LitMotion.Extensions
{
	public static class LitMotionUGUIExtensions
	{
		public static MotionHandle BindToColor<TOptions, TAdapter>(this MotionBuilder<Color, TOptions, TAdapter> builder, Graphic graphic) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Color, TOptions>
		{
			Error.IsNull(graphic);
			return builder.Bind(graphic, delegate(Color x, Graphic target)
			{
				target.color = x;
			});
		}

		public static MotionHandle BindToColorR<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Graphic graphic) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(graphic);
			return builder.Bind(graphic, delegate(float x, Graphic target)
			{
				Color color = target.color;
				color.r = x;
				target.color = color;
			});
		}

		public static MotionHandle BindToColorG<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Graphic graphic) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(graphic);
			return builder.Bind(graphic, delegate(float x, Graphic target)
			{
				Color color = target.color;
				color.g = x;
				target.color = color;
			});
		}

		public static MotionHandle BindToColorB<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Graphic graphic) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(graphic);
			return builder.Bind(graphic, delegate(float x, Graphic target)
			{
				Color color = target.color;
				color.b = x;
				target.color = color;
			});
		}

		public static MotionHandle BindToColorA<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Graphic graphic) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(graphic);
			return builder.Bind(graphic, delegate(float x, Graphic target)
			{
				Color color = target.color;
				color.a = x;
				target.color = color;
			});
		}

		public static MotionHandle BindToFillAmount<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Image image) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(image);
			return builder.Bind(image, delegate(float x, Image target)
			{
				target.fillAmount = x;
			});
		}

		public static MotionHandle BindToAlpha<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, CanvasGroup canvasGroup) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(canvasGroup);
			return builder.Bind(canvasGroup, delegate(float x, CanvasGroup target)
			{
				target.alpha = x;
			});
		}

		public static MotionHandle BindToFontSize<TOptions, TAdapter>(this MotionBuilder<int, TOptions, TAdapter> builder, Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<int, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(int x, Text target)
			{
				target.fontSize = x;
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<FixedString32Bytes, TOptions, TAdapter> builder, Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<FixedString32Bytes, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(FixedString32Bytes x, Text target)
			{
				target.text = FixedStringMethods.ConvertToString(ref x);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<FixedString64Bytes, TOptions, TAdapter> builder, Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<FixedString64Bytes, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(FixedString64Bytes x, Text target)
			{
				target.text = FixedStringMethods.ConvertToString(ref x);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<FixedString128Bytes, TOptions, TAdapter> builder, Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<FixedString128Bytes, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(FixedString128Bytes x, Text target)
			{
				target.text = FixedStringMethods.ConvertToString(ref x);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<FixedString512Bytes, TOptions, TAdapter> builder, Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<FixedString512Bytes, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(FixedString512Bytes x, Text target)
			{
				target.text = FixedStringMethods.ConvertToString(ref x);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<FixedString4096Bytes, TOptions, TAdapter> builder, Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<FixedString4096Bytes, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(FixedString4096Bytes x, Text target)
			{
				target.text = FixedStringMethods.ConvertToString(ref x);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<int, TOptions, TAdapter> builder, Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<int, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(int x, Text target)
			{
				target.text = x.ToString();
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<int, TOptions, TAdapter> builder, Text text, string format) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<int, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, format, delegate(int x, Text text2, string format2)
			{
				text2.text = ZString.Format(format2, x);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<long, TOptions, TAdapter> builder, Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<long, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(long x, Text target)
			{
				target.text = x.ToString();
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<long, TOptions, TAdapter> builder, Text text, string format) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<long, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, format, delegate(long x, Text text2, string format2)
			{
				text2.text = ZString.Format(format2, x);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Text text) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, delegate(float x, Text target)
			{
				target.text = x.ToString();
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, Text text, string format) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(text);
			return builder.Bind(text, format, delegate(float x, Text text2, string format2)
			{
				text2.text = ZString.Format(format2, x);
			});
		}
	}
}
