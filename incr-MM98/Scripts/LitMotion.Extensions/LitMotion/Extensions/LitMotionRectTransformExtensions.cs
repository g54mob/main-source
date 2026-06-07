using UnityEngine;

namespace LitMotion.Extensions
{
	public static class LitMotionRectTransformExtensions
	{
		public static MotionHandle BindToAnchoredPosition<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, RectTransform rectTransform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(rectTransform);
			return builder.Bind(rectTransform, delegate(Vector2 x, RectTransform target)
			{
				target.anchoredPosition = x;
			});
		}

		public static MotionHandle BindToAnchoredPositionX<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, RectTransform rectTransform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(rectTransform);
			return builder.Bind(rectTransform, delegate(float x, RectTransform target)
			{
				Vector2 anchoredPosition = target.anchoredPosition;
				anchoredPosition.x = x;
				target.anchoredPosition = anchoredPosition;
			});
		}

		public static MotionHandle BindToAnchoredPositionY<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, RectTransform rectTransform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(rectTransform);
			return builder.Bind(rectTransform, delegate(float x, RectTransform target)
			{
				Vector2 anchoredPosition = target.anchoredPosition;
				anchoredPosition.y = x;
				target.anchoredPosition = anchoredPosition;
			});
		}

		public static MotionHandle BindToAnchoredPosition3D<TOptions, TAdapter>(this MotionBuilder<Vector3, TOptions, TAdapter> builder, RectTransform rectTransform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector3, TOptions>
		{
			Error.IsNull(rectTransform);
			return builder.Bind(rectTransform, delegate(Vector3 x, RectTransform target)
			{
				target.anchoredPosition3D = x;
			});
		}

		public static MotionHandle BindToAnchoredPosition3DX<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, RectTransform rectTransform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(rectTransform);
			return builder.Bind(rectTransform, delegate(float x, RectTransform target)
			{
				Vector3 anchoredPosition3D = target.anchoredPosition3D;
				anchoredPosition3D.x = x;
				target.anchoredPosition3D = anchoredPosition3D;
			});
		}

		public static MotionHandle BindToAnchoredPosition3DY<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, RectTransform rectTransform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(rectTransform);
			return builder.Bind(rectTransform, delegate(float x, RectTransform target)
			{
				Vector3 anchoredPosition3D = target.anchoredPosition3D;
				anchoredPosition3D.y = x;
				target.anchoredPosition3D = anchoredPosition3D;
			});
		}

		public static MotionHandle BindToAnchoredPosition3DZ<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, RectTransform rectTransform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(rectTransform);
			return builder.Bind(rectTransform, delegate(float x, RectTransform target)
			{
				Vector3 anchoredPosition3D = target.anchoredPosition3D;
				anchoredPosition3D.z = x;
				target.anchoredPosition3D = anchoredPosition3D;
			});
		}

		public static MotionHandle BindToAnchorMin<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, RectTransform rectTransform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(rectTransform);
			return builder.Bind(rectTransform, delegate(Vector2 x, RectTransform target)
			{
				target.anchorMin = x;
			});
		}

		public static MotionHandle BindToAnchorMax<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, RectTransform rectTransform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(rectTransform);
			return builder.Bind(rectTransform, delegate(Vector2 x, RectTransform target)
			{
				target.anchorMax = x;
			});
		}

		public static MotionHandle BindToSizeDelta<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, RectTransform rectTransform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(rectTransform);
			return builder.Bind(rectTransform, delegate(Vector2 x, RectTransform target)
			{
				target.sizeDelta = x;
			});
		}

		public static MotionHandle BindToSizeDeltaX<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, RectTransform rectTransform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(rectTransform);
			return builder.Bind(rectTransform, delegate(float x, RectTransform target)
			{
				Vector2 sizeDelta = target.sizeDelta;
				sizeDelta.x = x;
				target.sizeDelta = sizeDelta;
			});
		}

		public static MotionHandle BindToSizeDeltaY<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, RectTransform rectTransform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(rectTransform);
			return builder.Bind(rectTransform, delegate(float x, RectTransform target)
			{
				Vector2 sizeDelta = target.sizeDelta;
				sizeDelta.y = x;
				target.sizeDelta = sizeDelta;
			});
		}

		public static MotionHandle BindToPivot<TOptions, TAdapter>(this MotionBuilder<Vector2, TOptions, TAdapter> builder, RectTransform rectTransform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<Vector2, TOptions>
		{
			Error.IsNull(rectTransform);
			return builder.Bind(rectTransform, delegate(Vector2 x, RectTransform target)
			{
				target.pivot = x;
			});
		}

		public static MotionHandle BindToPivotX<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, RectTransform rectTransform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(rectTransform);
			return builder.Bind(rectTransform, delegate(float x, RectTransform target)
			{
				Vector2 pivot = target.pivot;
				pivot.x = x;
				target.pivot = pivot;
			});
		}

		public static MotionHandle BindToPivotY<TOptions, TAdapter>(this MotionBuilder<float, TOptions, TAdapter> builder, RectTransform rectTransform) where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<float, TOptions>
		{
			Error.IsNull(rectTransform);
			return builder.Bind(rectTransform, delegate(float x, RectTransform target)
			{
				Vector2 pivot = target.pivot;
				pivot.y = x;
				target.pivot = pivot;
			});
		}
	}
}
