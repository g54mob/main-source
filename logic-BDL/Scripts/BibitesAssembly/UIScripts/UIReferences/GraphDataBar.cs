using Shapes;
using UIScripts.InfoHandles;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.UIReferences
{
	[ExecuteAlways]
	public class GraphDataBar : MonoBehaviour
	{
		[SerializeField]
		private Rectangle bar;

		[SerializeField]
		private TooltipTrigger tooltip;

		[SerializeField]
		private LayoutElement elem;

		[SerializeField]
		private RectTransform rt;

		private FloatValueFormat formatting;

		public void UpdateFormat(FloatValueFormat format)
		{
			formatting = format;
		}

		public void UpdateValue(float height, int value, float percentage, Vector2 minMax)
		{
			elem.preferredHeight = height;
			tooltip.UpdateText("[" + formatting.Format(minMax.x) + " : " + formatting.Format(minMax.y) + "]", $"count: {value} ({percentage * 100f:F1}%)");
		}

		private void OnRectTransformDimensionsChange()
		{
			Rect rect = rt.rect;
			bar.Width = rect.width - 2f;
			bar.Height = rect.height;
		}
	}
}
