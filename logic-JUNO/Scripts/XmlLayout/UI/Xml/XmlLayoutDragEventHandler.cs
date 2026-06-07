using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Xml
{
	[ExecuteInEditMode]
	public class XmlLayoutDragEventHandler : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
	{
		public bool IsBeingDragged;

		private Vector2 OriginalPivotOnDragStart = Vector2.zero;

		private Vector2 OriginalPositionOnDragStart = Vector2.zero;

		private RectTransform rectTransform;

		private XmlElement xmlElement;

		private float uiScale = 1f;

		private void OnEnable()
		{
			rectTransform = GetComponent<RectTransform>();
			xmlElement = GetComponent<XmlElement>();
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			if (!xmlElement.AllowDragging || eventData == null)
			{
				return;
			}
			XmlElement.ElementCurrentlyBeingDragged = xmlElement;
			if (!IsBeingDragged)
			{
				OriginalPivotOnDragStart = xmlElement.rectTransform.pivot;
				OriginalPositionOnDragStart = xmlElement.rectTransform.anchoredPosition3D;
				if (!xmlElement.RestrictDraggingToParentBounds)
				{
					rectTransform.SetParent(xmlElement.xmlLayoutInstance.XmlElement.rectTransform);
				}
				xmlElement.CanvasGroup.blocksRaycasts = false;
				uiScale = GetComponentInParent<CanvasScaler>()?.scaleFactor ?? 1f;
			}
			rectTransform.anchoredPosition += eventData.delta / uiScale;
			if (xmlElement.RestrictDraggingToParentBounds)
			{
				RectTransform obj = xmlElement.parentElement.rectTransform;
				Vector3 localPosition = obj.localPosition;
				Vector3 vector = obj.rect.min - rectTransform.rect.min;
				Vector3 vector2 = obj.rect.max - rectTransform.rect.max;
				localPosition.x = Mathf.Clamp(rectTransform.localPosition.x, vector.x, vector2.x);
				localPosition.y = Mathf.Clamp(rectTransform.localPosition.y, vector.y, vector2.y);
				rectTransform.localPosition = localPosition;
			}
			IsBeingDragged = true;
			xmlElement.OnDrag(eventData);
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (IsBeingDragged)
			{
				if (xmlElement == XmlElement.ElementCurrentlyBeingDragged)
				{
					XmlElement.ElementCurrentlyBeingDragged = null;
				}
				IsBeingDragged = false;
				rectTransform.SetParent(xmlElement.parentElement.rectTransform);
				if (xmlElement.ReturnToOriginalPositionWhenReleased)
				{
					rectTransform.pivot = OriginalPivotOnDragStart;
					rectTransform.anchoredPosition3D = OriginalPositionOnDragStart;
				}
				xmlElement.CanvasGroup.blocksRaycasts = true;
				xmlElement.OnEndDrag(eventData);
			}
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			xmlElement.OnBeginDrag(eventData);
		}
	}
}
