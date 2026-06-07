using UnityEngine;

public class LEQuickInventoryDropHandler : QuickInventoryDropHandlerBase<Transform, CustomLevelObjectsModel>
{
	protected override void OnDropHandler(int inventorySlotIndex)
	{
		CustomLevelObjectsModel item = GameManager.Instance.LECategoriesModel.GetSelectedCategory().GetItem(inventorySlotIndex);
		int selectedTabIndex = GUIManager.Instance.LEQuickInventoryController.model.SelectedTabIndex;
		GameManager.Instance.LEQuickInventoryModel.InsertItem(selectedTabIndex, base.DroppedSlotIndex, item);
		AudioClip slotDropInClip = GameManager.Instance.GameStylesData.slotDropInClip;
		GameManager.Instance.UIAudioEffectsManager.PlayAudio(slotDropInClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
	}
}
