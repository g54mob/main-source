using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui
{
	public interface IDraggableItem
	{
		bool CanDrag { get; }

		GameObject DragElement { get; }

		Transform DragParent { get; }

		bool ShowReadyForDragIndication { get; set; }

		void OnBeginDrag(PointerEventData eventData);

		void OnDrag(PointerEventData eventData);

		void OnEndDrag(PointerEventData eventData);
	}
}
