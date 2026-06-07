using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InstructionSlotDragHandler : InstructionDragHandlerBase
{
	private CanvasGroup draggedSlotCanvasGroup;

	public event Action<int, int, InstructionDropZone> OnInstructionEndDragEvent;

	protected override void Awake()
	{
		base.Awake();
		draggedSlotObject = base.gameObject.transform.GetComponentInParent<CanvasGroup>().gameObject;
		draggedSlotCanvasGroup = draggedSlotObject.GetComponent<CanvasGroup>();
	}

	public override void OnBeginDrag(PointerEventData eventData)
	{
		base.OnBeginDrag(eventData);
		dropZoneObject = draggedSlotObject.transform.parent.gameObject;
		oldElementIndex = draggedSlotObject.transform.GetSiblingIndex();
		parentTransform = draggedSlotObject.transform.parent;
		draggedSlotObject.transform.SetParent(base.ParentCanvas.transform);
		draggedSlotCanvasGroup.blocksRaycasts = false;
		draggedSlotCanvasGroup.alpha = 0.25f;
		placeholderElementObject = UnityEngine.Object.Instantiate(placeholderElementPrefab);
		placeholderElementObject.transform.SetParent(dropZoneObject.transform);
		placeholderElementObject.transform.localScale = Vector3.one;
		placeholderElementObject.transform.SetLocalPositionZ(0f);
		placeholderElementObject.transform.SetSiblingIndex(oldElementIndex);
		draggedSlotHeight = draggedSlotObject.GetComponent<RectTransform>().rect.height;
		placeholderElementObject.GetComponent<LayoutElement>().minHeight = draggedSlotHeight;
		selectedInstructionDropZone = dropZoneObject.GetComponent<InstructionDropZone>();
	}

	public override void OnDrag(PointerEventData eventData)
	{
		base.OnDrag(eventData);
		DraggingZonesChecks();
	}

	public override void OnEndDrag(PointerEventData eventData)
	{
		base.OnEndDrag(eventData);
		placeholderElementObject.transform.SetParent(null);
		UnityEngine.Object.Destroy(placeholderElementObject);
		draggedSlotObject.transform.SetParent(parentTransform, worldPositionStays: false);
		draggedSlotObject.transform.SetLocalPositionZ(0f);
		draggedSlotCanvasGroup.blocksRaycasts = true;
		draggedSlotCanvasGroup.alpha = 1f;
		draggedSlotObject.transform.SetSiblingIndex(oldElementIndex);
		AudioClip slotDropInClip = GameManager.Instance.GameStylesData.slotDropInClip;
		GameManager.Instance.UIAudioEffectsManager.PlayAudio(slotDropInClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
		this.OnInstructionEndDragEvent?.Invoke(oldElementIndex, newElementIndex, selectedInstructionDropZone);
	}
}
