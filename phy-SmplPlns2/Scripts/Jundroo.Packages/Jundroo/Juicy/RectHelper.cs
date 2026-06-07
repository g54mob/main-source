using UnityEngine;

namespace Jundroo.Juicy
{
	public static class RectHelper
	{
		public static void ApplyAnchor(RectTransform rect, AnchorPreset anchor)
		{
			switch (anchor)
			{
			case AnchorPreset.TopLeft:
				rect.anchorMin = new Vector2(0f, 1f);
				rect.anchorMax = new Vector2(0f, 1f);
				rect.pivot = new Vector2(0f, 1f);
				break;
			case AnchorPreset.TopCenter:
				rect.anchorMin = new Vector2(0.5f, 1f);
				rect.anchorMax = new Vector2(0.5f, 1f);
				rect.pivot = new Vector2(0.5f, 1f);
				break;
			case AnchorPreset.TopRight:
				rect.anchorMin = new Vector2(1f, 1f);
				rect.anchorMax = new Vector2(1f, 1f);
				rect.pivot = new Vector2(1f, 1f);
				break;
			case AnchorPreset.MiddleLeft:
				rect.anchorMin = new Vector2(0f, 0.5f);
				rect.anchorMax = new Vector2(0f, 0.5f);
				rect.pivot = new Vector2(0f, 0.5f);
				break;
			case AnchorPreset.MiddleCenter:
				rect.anchorMin = new Vector2(0.5f, 0.5f);
				rect.anchorMax = new Vector2(0.5f, 0.5f);
				rect.pivot = new Vector2(0.5f, 0.5f);
				break;
			case AnchorPreset.MiddleRight:
				rect.anchorMin = new Vector2(1f, 0.5f);
				rect.anchorMax = new Vector2(1f, 0.5f);
				rect.pivot = new Vector2(1f, 0.5f);
				break;
			case AnchorPreset.BottomLeft:
				rect.anchorMin = new Vector2(0f, 0f);
				rect.anchorMax = new Vector2(0f, 0f);
				rect.pivot = new Vector2(0f, 0f);
				break;
			case AnchorPreset.BottomCenter:
				rect.anchorMin = new Vector2(0.5f, 0f);
				rect.anchorMax = new Vector2(0.5f, 0f);
				rect.pivot = new Vector2(0.5f, 0f);
				break;
			case AnchorPreset.BottomRight:
				rect.anchorMin = new Vector2(1f, 0f);
				rect.anchorMax = new Vector2(1f, 0f);
				rect.pivot = new Vector2(1f, 0f);
				break;
			case AnchorPreset.StretchLeft:
				rect.anchorMin = new Vector2(0f, 0f);
				rect.anchorMax = new Vector2(0f, 1f);
				rect.pivot = new Vector2(0f, 0.5f);
				break;
			case AnchorPreset.StretchCenter:
				rect.anchorMin = new Vector2(0.5f, 0f);
				rect.anchorMax = new Vector2(0.5f, 1f);
				rect.pivot = new Vector2(0.5f, 0.5f);
				break;
			case AnchorPreset.StretchRight:
				rect.anchorMin = new Vector2(1f, 0f);
				rect.anchorMax = new Vector2(1f, 1f);
				rect.pivot = new Vector2(1f, 0.5f);
				break;
			case AnchorPreset.TopStretch:
				rect.anchorMin = new Vector2(0f, 1f);
				rect.anchorMax = new Vector2(1f, 1f);
				rect.pivot = new Vector2(0.5f, 1f);
				break;
			case AnchorPreset.MiddleStretch:
				rect.anchorMin = new Vector2(0f, 0.5f);
				rect.anchorMax = new Vector2(1f, 0.5f);
				rect.pivot = new Vector2(0.5f, 0.5f);
				break;
			case AnchorPreset.BottomStretch:
				rect.anchorMin = new Vector2(0f, 0f);
				rect.anchorMax = new Vector2(1f, 0f);
				rect.pivot = new Vector2(0.5f, 0f);
				break;
			case AnchorPreset.Stretch:
				rect.anchorMin = new Vector2(0f, 0f);
				rect.anchorMax = new Vector2(1f, 1f);
				rect.pivot = new Vector2(0.5f, 0.5f);
				break;
			}
		}

		public static Vector4 RectOffsetToVector4Padding(RectOffset o)
		{
			return new Vector4(o.left, o.bottom, o.right, o.top);
		}
	}
}
