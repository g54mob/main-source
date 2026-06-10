using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NSMedieval.View
{
	public class DragDetection : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
	{
		public event Action<Vector3> BeginDrag;

		public event Action<Vector3> Drag;

		public event Action<Vector3> EndDrag;

		public void OnBeginDrag(PointerEventData eventData)
		{
			this.BeginDrag?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
		}

		public void OnDrag(PointerEventData eventData)
		{
			this.Drag?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			this.EndDrag?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
		}

		private void OnDestroy()
		{
			this.BeginDrag = null;
			this.Drag = null;
			this.EndDrag = null;
		}
	}
}
