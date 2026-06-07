using UnityEngine;

public class LEClipboardSlot : ClipboardSlotBase<Transform, CustomLevelObjectsModel>
{
	private GameObject levelObjectsParent;

	protected override void ActionBeforeRemoveOldItemView()
	{
	}

	protected override Transform SetConfigurationHandler(CustomLevelObjectsModel itemModel)
	{
		levelObjectsParent = LevelEditorUtil.InstantiateLevelObjectsForUI(itemModel, base.ItemFolder.transform, referenceBlockObject);
		return levelObjectsParent.transform;
	}
}
