using DG.Tweening;
using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
	public class TooltipManager : MonoBehaviour
	{
		public Canvas mainCanvas;

		public UIManagerTooltip tooltip;

		public GameObject tooltipContent;

		public float tooltipSmoothness = 0.1f;

		public bool allowUpdating;

		public int vBorderTop = -115;

		public int vBorderBottom = 100;

		public int hBorderLeft = 230;

		public int hBorderRight = -210;

		private Vector2 uiPos;

		private Vector3 cursorPos;

		private RectTransform tooltipRect;

		private RectTransform tooltipZHelper;

		private Vector3 contentPos = new Vector3(0f, 0f, 0f);

		private Vector3 tooltipVelocity = Vector3.zero;

		private void Start()
		{
			tooltipContent.GetComponent<RectTransform>().pivot = new Vector2(0f, tooltipContent.GetComponent<RectTransform>().pivot.y);
			tooltipContent.GetComponent<RectTransform>().pivot = new Vector2(tooltipContent.GetComponent<RectTransform>().pivot.x, 0f);
			if (mainCanvas == null)
			{
				mainCanvas = base.gameObject.GetComponentInParent<Canvas>();
			}
			tooltipZHelper = base.gameObject.GetComponentInParent<RectTransform>();
			tooltipRect = tooltip.GetComponent<RectTransform>();
			contentPos = new Vector3(vBorderTop, hBorderLeft, 0f);
			base.gameObject.transform.SetAsLastSibling();
			ShortcutExtensions.DOScale(tooltip.transform, Vector3.zero, 0f);
		}

		private void Update()
		{
			if (allowUpdating)
			{
				cursorPos = Input.mousePosition;
				cursorPos.z = tooltipZHelper.position.z;
				uiPos = tooltipRect.anchoredPosition;
				CheckForBounds();
				if (mainCanvas.renderMode == RenderMode.ScreenSpaceCamera || mainCanvas.renderMode == RenderMode.WorldSpace)
				{
					tooltipRect.position = Camera.main.ScreenToWorldPoint(cursorPos);
					tooltipContent.transform.localPosition = Vector3.SmoothDamp(tooltipContent.transform.localPosition, contentPos, ref tooltipVelocity, tooltipSmoothness);
				}
				else if (mainCanvas.renderMode == RenderMode.ScreenSpaceOverlay)
				{
					tooltipRect.position = cursorPos;
					tooltipContent.transform.position = cursorPos + contentPos;
				}
			}
		}

		public void CheckForBounds()
		{
			if (uiPos.x <= -400f)
			{
				contentPos = new Vector3(hBorderLeft, contentPos.y, 0f);
				tooltipContent.GetComponent<RectTransform>().pivot = new Vector2(0f, tooltipContent.GetComponent<RectTransform>().pivot.y);
			}
			if (uiPos.x >= 400f)
			{
				contentPos = new Vector3(hBorderRight, contentPos.y, 0f);
				tooltipContent.GetComponent<RectTransform>().pivot = new Vector2(1f, tooltipContent.GetComponent<RectTransform>().pivot.y);
			}
			if (uiPos.y <= -325f)
			{
				contentPos = new Vector3(contentPos.x, vBorderBottom, 0f);
				tooltipContent.GetComponent<RectTransform>().pivot = new Vector2(tooltipContent.GetComponent<RectTransform>().pivot.x, 0f);
			}
			if (uiPos.y >= 325f)
			{
				contentPos = new Vector3(contentPos.x, vBorderTop, 0f);
				tooltipContent.GetComponent<RectTransform>().pivot = new Vector2(tooltipContent.GetComponent<RectTransform>().pivot.x, 1f);
			}
		}

		public void UpdateTooltipPos()
		{
			Update();
		}
	}
}
