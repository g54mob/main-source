using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.GuiNew
{
	public class MarginScript : MonoBehaviour
	{
		public bool useMarginBottom;

		public bool useMarginLeft;

		public bool useMarginRight;

		public bool useMarginTop;

		protected virtual void Awake()
		{
			RectTransform component = GetComponent<RectTransform>();
			Vector2 anchoredPosition = component.anchoredPosition;
			RectOffset margins = UserInterfaceScaleScript.Margins;
			if (useMarginBottom)
			{
				anchoredPosition.y += margins.bottom;
			}
			if (useMarginTop)
			{
				anchoredPosition.y -= margins.top;
			}
			if (useMarginRight)
			{
				anchoredPosition.x -= margins.right;
			}
			if (useMarginLeft)
			{
				anchoredPosition.x += margins.left;
			}
			component.anchoredPosition = anchoredPosition;
		}
	}
}
