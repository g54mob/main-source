using UnityEngine;

public class EditableSlotDragHandler : QIElementDragHandlerBase
{
	protected override Canvas GetParentCanvas()
	{
		return GUIManager.Instance.QuickInventoryView.ParentCanvas;
	}

	protected override void OnEndDragHandler(int oldElementIndex, int newElementIndex)
	{
		int selectedTabIndex = GameManager.Instance.QuickInventoryController.model.SelectedTabIndex;
		GameManager.Instance.QuickInventoryController.model.SwapItem(selectedTabIndex, oldElementIndex, newElementIndex);
		AudioClip slotDropInClip = GameManager.Instance.GameStylesData.slotDropInClip;
		GameManager.Instance.UIAudioEffectsManager.PlayAudio(slotDropInClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
	}
}
