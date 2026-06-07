using Cysharp.Text;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace LitMotion.Extensions
{
	public static class LitMotionUIToolkitExtensions
	{
		public static MotionHandle BindToStyleLeft<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(float x, VisualElement target)
			{
				target.style.left = x;
			});
		}

		public static MotionHandle BindToStyleRight<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(float x, VisualElement target)
			{
				target.style.right = x;
			});
		}

		public static MotionHandle BindToStyleTop<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(float x, VisualElement target)
			{
				target.style.top = x;
			});
		}

		public static MotionHandle BindToStyleBottom<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(float x, VisualElement target)
			{
				target.style.bottom = x;
			});
		}

		public static MotionHandle BindToStyleWidth<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(float x, VisualElement target)
			{
				target.style.width = x;
			});
		}

		public static MotionHandle BindToStyleHeight<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(float x, VisualElement target)
			{
				target.style.height = x;
			});
		}

		public static MotionHandle BindToStyleColor<TOptions, TAdapter>(this MotionBuilder<Color, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Color, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(Color x, VisualElement target)
			{
				target.style.color = x;
			});
		}

		public static MotionHandle BindToStyleColorR<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(float x, VisualElement target)
			{
				Color value = target.style.color.value;
				value.r = x;
				target.style.color = value;
			});
		}

		public static MotionHandle BindToStyleColorG<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(float x, VisualElement target)
			{
				Color value = target.style.color.value;
				value.g = x;
				target.style.color = value;
			});
		}

		public static MotionHandle BindToStyleColorB<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(float x, VisualElement target)
			{
				Color value = target.style.color.value;
				value.b = x;
				target.style.color = value;
			});
		}

		public static MotionHandle BindToStyleColorA<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(float x, VisualElement target)
			{
				Color value = target.style.color.value;
				value.a = x;
				target.style.color = value;
			});
		}

		public static MotionHandle BindToStyleBackgroundColor<TOptions, TAdapter>(this MotionBuilder<Color, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Color, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(Color x, VisualElement target)
			{
				target.style.backgroundColor = x;
			});
		}

		public static MotionHandle BindToStyleBackgroundColorR<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(float x, VisualElement target)
			{
				Color value = target.style.backgroundColor.value;
				value.r = x;
				target.style.backgroundColor = value;
			});
		}

		public static MotionHandle BindToStyleBackgroundColorG<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(float x, VisualElement target)
			{
				Color value = target.style.backgroundColor.value;
				value.g = x;
				target.style.backgroundColor = value;
			});
		}

		public static MotionHandle BindToStyleBackgroundColorB<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(float x, VisualElement target)
			{
				Color value = target.style.backgroundColor.value;
				value.b = x;
				target.style.backgroundColor = value;
			});
		}

		public static MotionHandle BindToStyleBackgroundColorA<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(float x, VisualElement target)
			{
				Color value = target.style.backgroundColor.value;
				value.a = x;
				target.style.backgroundColor = value;
			});
		}

		public static MotionHandle BindToStyleOpacity<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(float x, VisualElement target)
			{
				target.style.opacity = x;
			});
		}

		public static MotionHandle BindToStyleFontSize<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(float x, VisualElement target)
			{
				target.style.fontSize = x;
			});
		}

		public static MotionHandle BindToStyleWordSpacing<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(float x, VisualElement target)
			{
				target.style.wordSpacing = x;
			});
		}

		public static MotionHandle BindToStyleTranslate<TOptions, TAdapter>(this MotionBuilder<Vector3, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector3, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(Vector3 x, VisualElement target)
			{
				target.style.translate = new Translate(x.x, x.y, x.z);
			});
		}

		public static MotionHandle BindToStyleTranslate<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(Vector2 x, VisualElement target)
			{
				target.style.translate = new Translate(x.x, x.y);
			});
		}

		public static MotionHandle BindToStyleRotate<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, VisualElement visualElement, AngleUnit angleUnit = AngleUnit.Degree) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(float x, VisualElement target)
			{
				target.style.rotate = new Rotate(new Angle(x, angleUnit));
			});
		}

		public static MotionHandle BindToStyleScale<TOptions, TAdapter>(this MotionBuilder<Vector3, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector3, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(Vector3 x, VisualElement target)
			{
				target.style.scale = new Scale(x);
			});
		}

		public static MotionHandle BindToStyleTransformOrigin<TOptions, TAdapter>(this MotionBuilder<Vector3, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector3, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(Vector3 x, VisualElement target)
			{
				target.style.transformOrigin = new TransformOrigin(x.x, x.y, x.z);
			});
		}

		public static MotionHandle BindToStyleTransformOrigin<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, VisualElement visualElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(visualElement);
			return builder.Bind(visualElement, delegate(Vector2 x, VisualElement target)
			{
				target.style.transformOrigin = new TransformOrigin(x.x, x.y);
			});
		}

		public static MotionHandle BindToProgressBar<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, AbstractProgressBar progressBar) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(progressBar);
			return builder.Bind(progressBar, delegate(float x, AbstractProgressBar target)
			{
				target.value = x;
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<FixedString32Bytes, TOptions, TAdapter> builder, TextElement textElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<FixedString32Bytes, TOptions>
		{
			Error.IsNull(textElement);
			return builder.Bind(textElement, delegate(FixedString32Bytes x, TextElement target)
			{
				target.text = FixedStringMethods.ConvertToString(ref x);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<FixedString64Bytes, TOptions, TAdapter> builder, TextElement textElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<FixedString64Bytes, TOptions>
		{
			Error.IsNull(textElement);
			return builder.Bind(textElement, delegate(FixedString64Bytes x, TextElement target)
			{
				target.text = FixedStringMethods.ConvertToString(ref x);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<FixedString128Bytes, TOptions, TAdapter> builder, TextElement textElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<FixedString128Bytes, TOptions>
		{
			Error.IsNull(textElement);
			return builder.Bind(textElement, delegate(FixedString128Bytes x, TextElement target)
			{
				target.text = FixedStringMethods.ConvertToString(ref x);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<FixedString512Bytes, TOptions, TAdapter> builder, TextElement textElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<FixedString512Bytes, TOptions>
		{
			Error.IsNull(textElement);
			return builder.Bind(textElement, delegate(FixedString512Bytes x, TextElement target)
			{
				target.text = FixedStringMethods.ConvertToString(ref x);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<FixedString4096Bytes, TOptions, TAdapter> builder, TextElement textElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<FixedString4096Bytes, TOptions>
		{
			Error.IsNull(textElement);
			return builder.Bind(textElement, delegate(FixedString4096Bytes x, TextElement target)
			{
				target.text = FixedStringMethods.ConvertToString(ref x);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<int, TOptions, TAdapter> builder, TextElement textElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<int, TOptions>
		{
			Error.IsNull(textElement);
			return builder.Bind(textElement, delegate(int x, TextElement target)
			{
				target.text = x.ToString();
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<int, TOptions, TAdapter> builder, TextElement textElement, string format) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<int, TOptions>
		{
			Error.IsNull(textElement);
			return builder.Bind(textElement, format, delegate(int x, TextElement textElement2, string format2)
			{
				textElement2.text = ZString.Format(format2, x);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<long, TOptions, TAdapter> builder, TextElement textElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<long, TOptions>
		{
			Error.IsNull(textElement);
			return builder.Bind(textElement, delegate(long x, TextElement target)
			{
				target.text = x.ToString();
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<long, TOptions, TAdapter> builder, TextElement textElement, string format) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<long, TOptions>
		{
			Error.IsNull(textElement);
			return builder.Bind(textElement, format, delegate(long x, TextElement textElement2, string format2)
			{
				textElement2.text = ZString.Format(format2, x);
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TextElement textElement) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(textElement);
			return builder.Bind(textElement, delegate(float x, TextElement target)
			{
				target.text = x.ToString();
			});
		}

		public static MotionHandle BindToText<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, TextElement textElement, string format) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(textElement);
			return builder.Bind(textElement, format, delegate(float x, TextElement textElement2, string format2)
			{
				textElement2.text = ZString.Format(format2, x);
			});
		}
	}
}
