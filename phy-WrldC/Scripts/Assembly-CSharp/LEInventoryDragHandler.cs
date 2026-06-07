using UnityEngine;

public class LEInventoryDragHandler : InventoryDragHandlerBase<Transform, CustomLevelObjectsModel>
{
	protected override Canvas GetParentCanvas()
	{
		return GUIManager.Instance.LEQuickInventoryView.ParentCanvas;
	}

	protected override void OnEndDragHandler()
	{
		AudioClip slotDropOutClip = GameManager.Instance.GameStylesData.slotDropOutClip;
		GameManager.Instance.UIAudioEffectsManager.PlayAudio(slotDropOutClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
	}
}
