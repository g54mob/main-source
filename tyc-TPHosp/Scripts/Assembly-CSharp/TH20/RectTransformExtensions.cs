using UnityEngine;

namespace TH20
{
	public static class RectTransformExtensions
	{
		public static void SetAlignment(this RectTransform source, AnchorPresets allign, PivotPresets preset, Vector2 sizeDelta, int offsetX = 0, int offsetY = 0)
		{
			source.SetPivot(preset);
			source.SetAnchor(allign, offsetX, offsetY);
			source.sizeDelta = sizeDelta;
		}

		public static void SetAnchor(this RectTransform source, AnchorPresets allign, int offsetX = 0, int offsetY = 0)
		{
			source.anchoredPosition = new Vector3(offsetX, offsetY, 0f);
			switch (allign)
			{
			case AnchorPresets.TopLeft:
				source.anchorMin = new Vector2(0f, 1f);
				source.anchorMax = new Vector2(0f, 1f);
				break;
			case AnchorPresets.TopCenter:
				source.anchorMin = new Vector2(0.5f, 1f);
				source.anchorMax = new Vector2(0.5f, 1f);
				break;
			case AnchorPresets.TopRight:
				source.anchorMin = new Vector2(1f, 1f);
				source.anchorMax = new Vector2(1f, 1f);
				break;
			case AnchorPresets.MiddleLeft:
				source.anchorMin = new Vector2(0f, 0.5f);
				source.anchorMax = new Vector2(0f, 0.5f);
				break;
			case AnchorPresets.MiddleCenter:
				source.anchorMin = new Vector2(0.5f, 0.5f);
				source.anchorMax = new Vector2(0.5f, 0.5f);
				break;
			case AnchorPresets.MiddleRight:
				source.anchorMin = new Vector2(1f, 0.5f);
				source.anchorMax = new Vector2(1f, 0.5f);
				break;
			case AnchorPresets.BottomLeft:
				source.anchorMin = new Vector2(0f, 0f);
				source.anchorMax = new Vector2(0f, 0f);
				break;
			case AnchorPresets.BottonCenter:
				source.anchorMin = new Vector2(0.5f, 0f);
				source.anchorMax = new Vector2(0.5f, 0f);
				break;
			case AnchorPresets.BottomRight:
				source.anchorMin = new Vector2(1f, 0f);
				source.anchorMax = new Vector2(1f, 0f);
				break;
			case AnchorPresets.HorStretchTop:
				source.anchorMin = new Vector2(0f, 1f);
				source.anchorMax = new Vector2(1f, 1f);
				break;
			case AnchorPresets.HorStretchMiddle:
				source.anchorMin = new Vector2(0f, 0.5f);
				source.anchorMax = new Vector2(1f, 0.5f);
				break;
			case AnchorPresets.HorStretchBottom:
				source.anchorMin = new Vector2(0f, 0f);
				source.anchorMax = new Vector2(1f, 0f);
				break;
			case AnchorPresets.VertStretchLeft:
				source.anchorMin = new Vector2(0f, 0f);
				source.anchorMax = new Vector2(0f, 1f);
				break;
			case AnchorPresets.VertStretchCenter:
				source.anchorMin = new Vector2(0.5f, 0f);
				source.anchorMax = new Vector2(0.5f, 1f);
				break;
			case AnchorPresets.VertStretchRight:
				source.anchorMin = new Vector2(1f, 0f);
				source.anchorMax = new Vector2(1f, 1f);
				break;
			case AnchorPresets.StretchAll:
				source.anchorMin = new Vector2(0f, 0f);
				source.anchorMax = new Vector2(1f, 1f);
				break;
			case AnchorPresets.BottomStretch:
				break;
			}
		}

		public static void SetPivot(this RectTransform source, PivotPresets preset)
		{
			switch (preset)
			{
			case PivotPresets.TopLeft:
				source.pivot = new Vector2(0f, 1f);
				break;
			case PivotPresets.TopCenter:
				source.pivot = new Vector2(0.5f, 1f);
				break;
			case PivotPresets.TopRight:
				source.pivot = new Vector2(1f, 1f);
				break;
			case PivotPresets.MiddleLeft:
				source.pivot = new Vector2(0f, 0.5f);
				break;
			case PivotPresets.MiddleCenter:
				source.pivot = new Vector2(0.5f, 0.5f);
				break;
			case PivotPresets.MiddleRight:
				source.pivot = new Vector2(1f, 0.5f);
				break;
			case PivotPresets.BottomLeft:
				source.pivot = new Vector2(0f, 0f);
				break;
			case PivotPresets.BottomCenter:
				source.pivot = new Vector2(0.5f, 0f);
				break;
			case PivotPresets.BottomRight:
				source.pivot = new Vector2(1f, 0f);
				break;
			}
		}
	}
}
