using UnityEngine;
using UnityEngine.EventSystems;

namespace Michsky.DreamOS
{
	public class WindowResizeAnchor : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
	{
		[Header("Resources")]
		public RectTransform targetRect;

		[Header("Settings")]
		public Vector2 minSize;

		public Vector2 maxSize;

		private Vector2 currentPointerPosition;

		private Vector2 previousPointerPosition;

		private Vector2 sizeDelta;

		private Vector2 resizeValue;

		private bool invertDeltaX;

		public void SetMinSize(int value)
		{
			int num = 1920 * value / 100;
			minSize.x = -(1920 - num);
			int num2 = 1080 * value / 100;
			minSize.y = -(1080 - num2);
		}

		public void SetAnchor(WindowManager.ResizeAnchor anchor)
		{
			RectTransform component = GetComponent<RectTransform>();
			switch (anchor)
			{
			case WindowManager.ResizeAnchor.BottomLeft:
				component.anchorMin = new Vector2(0f, 0f);
				component.anchorMax = new Vector2(0f, 0f);
				WindowManager.SetPivot(component, new Vector2(0f, 0f));
				WindowManager.SetPivot(targetRect, new Vector2(1f, 1f));
				invertDeltaX = true;
				break;
			case WindowManager.ResizeAnchor.BottomRight:
				component.anchorMin = new Vector2(1f, 0f);
				component.anchorMax = new Vector2(1f, 0f);
				WindowManager.SetPivot(component, new Vector2(1f, 0f));
				WindowManager.SetPivot(targetRect, new Vector2(0f, 1f));
				invertDeltaX = false;
				break;
			}
			component.anchoredPosition = new Vector2(0f, 0f);
		}

		public void OnPointerDown(PointerEventData data)
		{
			if (!(targetRect == null))
			{
				targetRect.SetAsLastSibling();
				RectTransformUtility.ScreenPointToLocalPointInRectangle(targetRect, data.position, data.pressEventCamera, out previousPointerPosition);
			}
		}

		public void OnDrag(PointerEventData data)
		{
			if (!(targetRect == null))
			{
				sizeDelta = targetRect.sizeDelta;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(targetRect, data.position, data.pressEventCamera, out currentPointerPosition);
				resizeValue = currentPointerPosition - previousPointerPosition;
				if (!invertDeltaX)
				{
					sizeDelta += new Vector2(resizeValue.x, 0f - resizeValue.y);
				}
				else
				{
					sizeDelta += new Vector2(0f - resizeValue.x, 0f - resizeValue.y);
				}
				sizeDelta = new Vector2(Mathf.Clamp(sizeDelta.x, minSize.x, maxSize.x), Mathf.Clamp(sizeDelta.y, minSize.y, maxSize.y));
				targetRect.sizeDelta = sizeDelta;
				previousPointerPosition = currentPointerPosition;
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			WindowDragger componentInChildren = base.transform.parent.GetComponentInChildren<WindowDragger>();
			if (componentInChildren != null)
			{
				componentInChildren.ClampToArea();
			}
		}
	}
}
