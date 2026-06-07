using System.Collections;
using ModApi;
using ModApi.Common.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Ui
{
	public class DragHandlerScript : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
	{
		private GameObject _draggingObject;

		private Vector2 _grabDelta;

		private bool _waitingForDelayedDrag;

		public bool IsDragging { get; private set; }

		public IDraggableItem Item { get; set; }

		public bool UseHorizontalDragToStart { get; set; }

		public bool WaitForDelayedDrag { get; set; } = Device.IsMobileBuild;

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left && Item.CanDrag && !_waitingForDelayedDrag && (!UseHorizontalDragToStart || Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y)))
			{
				IsDragging = true;
				GameObject dragElement = Item.DragElement;
				_draggingObject = Object.Instantiate(dragElement);
				_draggingObject.transform.SetParent(Item.DragParent, worldPositionStays: true);
				RectTransform component = _draggingObject.GetComponent<RectTransform>();
				component.anchorMin = new Vector2(0.5f, 0.5f);
				component.anchorMax = new Vector2(0.5f, 0.5f);
				Rect rect = dragElement.GetComponent<RectTransform>().rect;
				component.sizeDelta = new Vector2(rect.width, rect.height);
				DragHandlerScript[] componentsInChildren = _draggingObject.GetComponentsInChildren<DragHandlerScript>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].enabled = false;
				}
				Graphic[] componentsInChildren2 = _draggingObject.GetComponentsInChildren<Graphic>();
				for (int i = 0; i < componentsInChildren2.Length; i++)
				{
					componentsInChildren2[i].raycastTarget = false;
				}
				CanvasGroup canvasGroup = _draggingObject.AddMissingComponent<CanvasGroup>();
				if (canvasGroup != null)
				{
					canvasGroup.alpha = 0.85f;
				}
				Vector2 vector = RectTransformUtility.WorldToScreenPoint(null, dragElement.transform.position);
				_grabDelta = vector - eventData.position;
				Item.OnBeginDrag(eventData);
				Item.ShowReadyForDragIndication = true;
			}
			else
			{
				_waitingForDelayedDrag = false;
				ExecuteEvents.ExecuteHierarchy(base.transform.parent.gameObject, eventData, ExecuteEvents.beginDragHandler);
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (IsDragging)
			{
				Vector3 position = _draggingObject.transform.position;
				position.x = eventData.position.x + _grabDelta.x;
				position.y = eventData.position.y + _grabDelta.y;
				_draggingObject.transform.position = position;
				Item.OnDrag(eventData);
			}
			else
			{
				ExecuteEvents.ExecuteHierarchy(base.transform.parent.gameObject, eventData, ExecuteEvents.dragHandler);
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (IsDragging)
			{
				Object.Destroy(_draggingObject);
				_draggingObject = null;
				Item.OnEndDrag(eventData);
				IsDragging = false;
				Item.ShowReadyForDragIndication = false;
			}
			else
			{
				ExecuteEvents.ExecuteHierarchy(base.transform.parent.gameObject, eventData, ExecuteEvents.endDragHandler);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (WaitForDelayedDrag)
			{
				_waitingForDelayedDrag = true;
				StartCoroutine(StartDragDelayed());
			}
			else
			{
				Item.ShowReadyForDragIndication = true;
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			Item.ShowReadyForDragIndication = false;
			if (Device.IsMobileBuild)
			{
				_waitingForDelayedDrag = false;
			}
		}

		private IEnumerator StartDragDelayed()
		{
			yield return new WaitForSeconds(0.4f);
			if (_waitingForDelayedDrag)
			{
				_waitingForDelayedDrag = false;
				Item.ShowReadyForDragIndication = true;
			}
		}
	}
}
