using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
	public class ContextMenuManager : MonoBehaviour
	{
		[SerializeField]
		public Canvas mainCanvas;

		public GameObject contextButton;

		public GameObject contextContent;

		public Animator contextAnimator;

		public bool isContextMenuOn;

		public int vBorderTop = -10;

		public int vBorderBottom = 10;

		public int hBorderLeft = 15;

		public int hBorderRight = -15;

		private Vector2 uiPos;

		private Vector3 cursorPos;

		private Vector3 contentPos = new Vector3(0f, 0f, 0f);

		private Vector3 contextVelocity = Vector3.zero;

		private RectTransform contextRect;

		private void Start()
		{
			if (mainCanvas == null)
			{
				mainCanvas = base.gameObject.GetComponentInParent<Canvas>();
			}
			if (contextAnimator == null)
			{
				contextAnimator = base.gameObject.GetComponent<Animator>();
			}
			contextRect = base.gameObject.GetComponent<RectTransform>();
			contentPos = new Vector3(vBorderTop, hBorderLeft, 0f);
			base.gameObject.transform.SetAsLastSibling();
		}

		public void CheckForBounds()
		{
			if (uiPos.x <= -100f)
			{
				contentPos = new Vector3(hBorderLeft, contentPos.y, 0f);
				contextContent.GetComponent<RectTransform>().pivot = new Vector2(0f, contextContent.GetComponent<RectTransform>().pivot.y);
			}
			if (uiPos.x >= 100f)
			{
				contentPos = new Vector3(hBorderRight, contentPos.y, 0f);
				contextContent.GetComponent<RectTransform>().pivot = new Vector2(1f, contextContent.GetComponent<RectTransform>().pivot.y);
			}
			if (uiPos.y <= -75f)
			{
				contentPos = new Vector3(contentPos.x, vBorderBottom, 0f);
				contextContent.GetComponent<RectTransform>().pivot = new Vector2(contextContent.GetComponent<RectTransform>().pivot.x, 0f);
			}
			if (uiPos.y >= 75f)
			{
				contentPos = new Vector3(contentPos.x, vBorderTop, 0f);
				contextContent.GetComponent<RectTransform>().pivot = new Vector2(contextContent.GetComponent<RectTransform>().pivot.x, 1f);
			}
		}

		public void SetContextMenuPosition()
		{
			cursorPos = Input.mousePosition;
			uiPos = contextRect.anchoredPosition;
			CheckForBounds();
			if (mainCanvas.renderMode == RenderMode.ScreenSpaceCamera || mainCanvas.renderMode == RenderMode.WorldSpace)
			{
				cursorPos.z = base.gameObject.transform.position.z;
				contextRect.position = Camera.main.ScreenToWorldPoint(cursorPos);
				contextContent.transform.localPosition = Vector3.SmoothDamp(contextContent.transform.localPosition, contentPos, ref contextVelocity, 0f);
			}
			else if (mainCanvas.renderMode == RenderMode.ScreenSpaceOverlay)
			{
				contextRect.position = cursorPos;
				contextContent.transform.position = new Vector3(cursorPos.x + contentPos.x, cursorPos.y + contentPos.y, 0f);
			}
		}

		public void CloseOnClick()
		{
			contextAnimator.Play("Menu Out");
			isContextMenuOn = false;
		}
	}
}
