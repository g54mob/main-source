using UnityEngine;

public class QuickInventoryDropHandler : QuickInventoryDropHandlerBase<CreationView, CreationModel>
{
	protected override void OnDropHandler(int inventorySlotIndex)
	{
		CreationModel item = GameManager.Instance.CategoriesModel.GetSelectedCategory().GetItem(inventorySlotIndex);
		int selectedTabIndex = GameManager.Instance.QuickInventoryController.model.SelectedTabIndex;
		GameManager.Instance.QuickInventoryController.model.InsertItem(selectedTabIndex, base.DroppedSlotIndex, item);
		AudioClip slotDropInClip = GameManager.Instance.GameStylesData.slotDropInClip;
		GameManager.Instance.UIAudioEffectsManager.PlayAudio(slotDropInClip, GameManager.Instance.GameStylesData.volumeStylesData.uiVolume);
	}
}
