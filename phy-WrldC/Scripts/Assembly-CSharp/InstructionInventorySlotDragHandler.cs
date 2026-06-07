using UnityEngine;
using UnityEngine.EventSystems;

public class InstructionInventorySlotDragHandler : InstructionDragHandlerBase
{
	[SerializeField]
	private InstructionType type;

	public InstructionDropZone RootInstructionDropZone { get; set; }

	public InstructionType InstructionType => type;

	public override void OnBeginDrag(PointerEventData eventData)
	{
		base.OnBeginDrag(eventData);
		draggedSlotObject = Object.Instantiate(base.gameObject);
		draggedSlotObject.transform.SetParent(base.ParentCanvas.transform);
		draggedSlotObject.transform.localScale = Vector3.one;
		draggedSlotObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
		(draggedSlotObject.transform as RectTransform).sizeDelta = (base.gameObject.transform as RectTransform).sizeDelta;
		draggedSlotHeight = draggedSlotObject.GetComponent<RectTransform>().rect.height;
		RootInstructionDropZone = null;
	}

	public override void OnDrag(PointerEventData eventData)
	{
		base.OnDrag(eventData);
		draggedSlotObject.transform.position = Util.ConvertMousePositionToRectTransform(base.ParentCanvas);
		draggedSlotObject.transform.SetLocalPositionZ(-400f);
		if (RootInstructionDropZone != null)
		{
			if (placeholderElementObject == null)
			{
				dropZoneObject = RootInstructionDropZone.gameObject;
				placeholderElementObject = Object.Instantiate(placeholderElementPrefab);
				placeholderElementObject.transform.SetParent(dropZoneObject.transform);
				placeholderElementObject.transform.localScale = Vector3.one;
				placeholderElementObject.transform.SetLocalPositionZ(0f);
				selectedInstructionDropZone = RootInstructionDropZone;
			}
			DraggingZonesChecks();
		}
		else if (placeholderElementObject != null)
		{
			Object.Destroy(placeholderElementObject);
		}
	}

	public override void OnEndDrag(PointerEventData eventData)
	{
		base.OnEndDrag(eventData);
		Object.Destroy(draggedSlotObject);
		if (placeholderElementObject != null)
		{
			GUIManager.Instance.LogicEditorView.LogicEditorSelectedLogicView.AddNewInstructionSlotHandler(type, selectedInstructionDropZone.InstructionsList, selectedInstructionDropZone.transform, newElementIndex);
			AudioClip slotDropInClip = GameManager.Instance.GameStylesData.slotDropInClip;
			GameManager.Instance.UIAudioEffectsManager.PlayAudio(slotDropInClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
			Object.Destroy(placeholderElementObject);
		}
		else
		{
			AudioClip slotDropOutClip = GameManager.Instance.GameStylesData.slotDropOutClip;
			GameManager.Instance.UIAudioEffectsManager.PlayAudio(slotDropOutClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
		}
	}
}
