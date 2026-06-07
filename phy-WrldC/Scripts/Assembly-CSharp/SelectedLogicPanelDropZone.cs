using UnityEngine;
using UnityEngine.EventSystems;

public class SelectedLogicPanelDropZone : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private InstructionDropZone rootInstructionDropZone;

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null && rootInstructionDropZone != null)
		{
			InstructionInventorySlotDragHandler component = eventData.pointerDrag.GetComponent<InstructionInventorySlotDragHandler>();
			if (component != null)
			{
				component.RootInstructionDropZone = rootInstructionDropZone;
			}
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (eventData.pointerDrag != null && rootInstructionDropZone != null)
		{
			InstructionInventorySlotDragHandler component = eventData.pointerDrag.GetComponent<InstructionInventorySlotDragHandler>();
			if (component != null)
			{
				component.RootInstructionDropZone = null;
			}
		}
	}
}
