using UnityEngine;
using UnityEngine.EventSystems;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/UI/VRTK_UIDropZone")]
	public class VRTK_UIDropZone : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		protected VRTK_UIDraggableItem droppableItem;

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			if (eventData.pointerDrag != null)
			{
				VRTK_UIDraggableItem component = eventData.pointerDrag.GetComponent<VRTK_UIDraggableItem>();
				if (component != null && component.restrictToDropZone)
				{
					component.validDropZone = base.gameObject;
					droppableItem = component;
				}
			}
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
			if (droppableItem != null)
			{
				droppableItem.validDropZone = null;
			}
			droppableItem = null;
		}
	}
}
