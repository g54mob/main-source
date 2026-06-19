using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class WindowDragger : UIBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IPointerClickHandler
	{
		[Header("Resources")]
		public RectTransform dragArea;

		public RectTransform dragObject;

		private Vector2 originalLocalPointerPosition;

		private Vector3 originalPanelLocalPosition;

		[HideInInspector]
		public WindowManager wManager;

		private RectTransform dragObjectInternal
		{
			get
			{
				if (dragObject == null)
				{
					return base.transform as RectTransform;
				}
				return dragObject;
			}
		}

		private RectTransform dragAreaInternal
		{
			get
			{
				if (dragArea == null)
				{
					RectTransform rectTransform = base.transform as RectTransform;
					while (rectTransform.parent != null && rectTransform.parent is RectTransform)
					{
						rectTransform = rectTransform.parent as RectTransform;
					}
					return rectTransform;
				}
				return dragArea;
			}
		}

		public new void Start()
		{
			if (dragArea == null)
			{
				Canvas canvas = Object.FindObjectsByType<Canvas>(FindObjectsSortMode.None)[0];
				dragArea = canvas.GetComponent<RectTransform>();
			}
			if (base.gameObject.GetComponent<Image>() == null)
			{
				Image image = base.gameObject.AddComponent<Image>();
				image.color = new Color(0f, 0f, 0f, 0f);
				image.raycastTarget = true;
			}
		}

		public void OnBeginDrag(PointerEventData data)
		{
			if (!(wManager != null) || !wManager.isFullscreen)
			{
				originalPanelLocalPosition = dragObjectInternal.localPosition;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(dragAreaInternal, data.position, data.pressEventCamera, out originalLocalPointerPosition);
			}
		}

		public void OnDrag(PointerEventData data)
		{
			if (!(wManager != null) || !wManager.isFullscreen)
			{
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle(dragAreaInternal, data.position, data.pressEventCamera, out var localPoint))
				{
					Vector3 vector = localPoint - originalLocalPointerPosition;
					dragObjectInternal.localPosition = originalPanelLocalPosition + vector;
				}
				ClampToArea();
			}
		}

		public void ClampToArea()
		{
			Vector3 localPosition = dragObjectInternal.localPosition;
			Vector3 vector = dragAreaInternal.rect.min - dragObjectInternal.rect.min;
			Vector3 vector2 = dragAreaInternal.rect.max - dragObjectInternal.rect.max;
			localPosition.x = Mathf.Clamp(dragObjectInternal.localPosition.x, vector.x, vector2.x);
			localPosition.y = Mathf.Clamp(dragObjectInternal.localPosition.y, vector.y, vector2.y);
			dragObjectInternal.localPosition = localPosition;
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (!(wManager == null))
			{
				if (wManager.allowGestures && eventData.clickCount == 2)
				{
					wManager.FullscreenWindow();
				}
				wManager.FocusToWindow();
			}
		}
	}
}
