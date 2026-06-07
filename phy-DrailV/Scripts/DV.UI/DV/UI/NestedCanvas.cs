using UnityEngine;

namespace DV.UI
{
	public class NestedCanvas : MonoBehaviour
	{
		public Canvas canvas;

		public void ResetRectTransform()
		{
			if ((bool)canvas)
			{
				RectTransform component = canvas.GetComponent<RectTransform>();
				component.anchorMin = Vector2.zero;
				component.anchorMax = Vector2.one;
				component.anchoredPosition = Vector2.zero;
				component.offsetMax = Vector2.zero;
				component.offsetMin = Vector2.zero;
				component.localScale = Vector3.one;
				component.localRotation = Quaternion.identity;
			}
		}
	}
}
