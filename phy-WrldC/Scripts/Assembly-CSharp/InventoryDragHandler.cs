using UnityEngine;

public class InventoryDragHandler : InventoryDragHandlerBase<CreationView, CreationModel>
{
	protected override Canvas GetParentCanvas()
	{
		return GUIManager.Instance.QuickInventoryView.ParentCanvas;
	}

	protected override void OnEndDragHandler()
	{
		AudioClip slotDropOutClip = GameManager.Instance.GameStylesData.slotDropOutClip;
		GameManager.Instance.UIAudioEffectsManager.PlayAudio(slotDropOutClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
	}
}
