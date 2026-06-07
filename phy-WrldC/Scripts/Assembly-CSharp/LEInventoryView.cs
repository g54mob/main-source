using UnityEngine;

public class LEInventoryView : InventoryViewBase<Transform, CustomLevelObjectsModel>
{
	private GameObject levelObjectsParent;

	protected override void ActionBeforeClearAllTabsAndSlots()
	{
	}

	protected override void ActionBeforeRemoveSlot(InventorySlotBase<Transform, CustomLevelObjectsModel> slot)
	{
	}

	protected override void ActionBeforeRemoveOldItemView()
	{
	}

	protected override Transform SetSelectedItemModelHandler(CustomLevelObjectsModel selectedItemModel)
	{
		string text = selectedItemModel.Name;
		string text2 = selectedItemModel.Name;
		string sourceText = selectedItemModel.Description;
		if (selectedItemModel.Origin == CustomLevelObjectsModel.OriginEnum.Part)
		{
			text2 = LanguagesManager.Instance.GetText("leveleditor.object.name." + text, text);
			sourceText = LanguagesManager.Instance.GetText("leveleditor.object.description." + text, text);
		}
		itemNameText.SetText(text2);
		descriptionText.SetText(sourceText);
		levelObjectsParent = LevelEditorUtil.InstantiateLevelObjectsForUI(selectedItemModel, itemParentFolder.transform, referenceBlockObject);
		if (selectedItemModel.Origin == CustomLevelObjectsModel.OriginEnum.UserPart)
		{
			deleteItemButton.gameObject.SetActive(value: true);
		}
		else
		{
			deleteItemButton.gameObject.SetActive(value: false);
		}
		return levelObjectsParent.transform;
	}
}
