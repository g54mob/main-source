using UnityEngine;

public class LEQISlotDragHandler : QIElementDragHandlerBase
{
	protected override Canvas GetParentCanvas()
	{
		return GUIManager.Instance.LEQuickInventoryView.ParentCanvas;
	}

	protected override void OnEndDragHandler(int oldElementIndex, int newElementIndex)
	{
		int selectedTabIndex = GUIManager.Instance.LEQuickInventoryController.model.SelectedTabIndex;
		GUIManager.Instance.LEQuickInventoryController.model.SwapItem(selectedTabIndex, oldElementIndex, newElementIndex);
		AudioClip slotDropInClip = GameManager.Instance.GameStylesData.slotDropInClip;
		GameManager.Instance.UIAudioEffectsManager.PlayAudio(slotDropInClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
	}
}
