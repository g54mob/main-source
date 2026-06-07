using System.Collections;
using ModApi;
using ModApi.Common.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.PlanetStudio.Flyouts
{
	public class ElementDragHandlerScript : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
	{
		private GameObject _draggingObject;

		private IDragDropElement _element;

		private Vector2 _grabDelta;

		private bool _waitingForDelayedDrag;

		public IDragDropContainer Container { get; private set; }

		public bool IsDragging { get; private set; }

		public void Initialize(IDragDropElement element, IDragDropContainer container)
		{
			_element = element;
			Container = container;
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (!_waitingForDelayedDrag)
			{
				IsDragging = true;
				_element.ShowReadyForDragIndication = true;
				GameObject gameObject = _element.GameObject;
				_draggingObject = Object.Instantiate(gameObject);
				_draggingObject.transform.SetParent(Container.DragParent, worldPositionStays: true);
				RectTransform component = _draggingObject.GetComponent<RectTransform>();
				component.anchorMin = new Vector2(0.5f, 0.5f);
				component.anchorMax = new Vector2(0.5f, 0.5f);
				Rect rect = gameObject.GetComponent<RectTransform>().rect;
				component.sizeDelta = new Vector2(rect.width, rect.height);
				ElementDragHandlerScript[] componentsInChildren = _draggingObject.GetComponentsInChildren<ElementDragHandlerScript>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].enabled = false;
				}
				Graphic[] componentsInChildren2 = _draggingObject.GetComponentsInChildren<Graphic>();
				for (int i = 0; i < componentsInChildren2.Length; i++)
				{
					componentsInChildren2[i].raycastTarget = false;
				}
				_draggingObject.AddMissingComponent<CanvasGroup>().alpha = 0.5f;
				Vector2 vector = RectTransformUtility.WorldToScreenPoint(null, gameObject.transform.position);
				_grabDelta = vector - eventData.position;
				Container.StartDrag(_element);
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
				Container.Dragging(eventData);
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
				Container.EndDrag(_element);
				IsDragging = false;
				_element.ShowReadyForDragIndication = false;
			}
			else
			{
				ExecuteEvents.ExecuteHierarchy(base.transform.parent.gameObject, eventData, ExecuteEvents.endDragHandler);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (Device.IsMobileBuild)
			{
				_waitingForDelayedDrag = true;
				StartCoroutine(StartDragDelayed());
			}
			else
			{
				_element.ShowReadyForDragIndication = true;
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_element.ShowReadyForDragIndication = false;
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
				_element.ShowReadyForDragIndication = true;
			}
		}
	}
}
