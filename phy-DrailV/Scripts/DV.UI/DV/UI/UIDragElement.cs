using UnityEngine;
using UnityEngine.EventSystems;

namespace DV.UI
{
	public class UIDragElement : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
	{
		public delegate void DragStartDelegate(PointerEventData eventData);

		public delegate void DragOngoingDelegate(PointerEventData eventData);

		public delegate void DragEndDelegate(PointerEventData eventData, bool forced);

		private PointerEventData draggingPointerEventData;

		private bool dragForceStopped;

		public bool IsDragging { get; private set; }

		public event DragStartDelegate DragStarted;

		public event DragOngoingDelegate DragOngoing;

		public event DragEndDelegate DragEnded;

		public void ForceEndInteraction()
		{
			if (IsDragging && draggingPointerEventData != null)
			{
				PointerEventData pointerEventData = draggingPointerEventData;
				dragForceStopped = true;
				ExecuteEvents.Execute(pointerEventData.pointerDrag, pointerEventData, ExecuteEvents.endDragHandler);
				ExecuteEvents.Execute(pointerEventData.pointerDrag, pointerEventData, ExecuteEvents.dropHandler);
				ExecuteEvents.Execute(pointerEventData.pointerDrag, pointerEventData, ExecuteEvents.pointerUpHandler);
				pointerEventData.pointerDrag = null;
				pointerEventData.pointerPress = null;
				dragForceStopped = false;
			}
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			draggingPointerEventData = eventData;
			IsDragging = true;
			this.DragStarted?.Invoke(eventData);
		}

		public void OnDrag(PointerEventData eventData)
		{
			draggingPointerEventData = eventData;
			this.DragOngoing?.Invoke(eventData);
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			draggingPointerEventData = null;
			IsDragging = false;
			this.DragEnded?.Invoke(eventData, dragForceStopped);
		}
	}
}
