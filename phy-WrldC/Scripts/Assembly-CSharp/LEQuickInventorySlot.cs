using TMPro;
using UnityEngine;

public class LEQuickInventorySlot : QuickInventorySlotBase<Transform, CustomLevelObjectsModel>
{
	private TextMeshProUGUI activeIcon;

	private TextMeshProUGUI buttonIcon;

	private LevelObjectTooltipTrigger levelObjectTooltip;

	private GameObject levelObjectsParent;

	protected override void Awake()
	{
		base.Awake();
		activeIcon = base.transform.FindComponent<TextMeshProUGUI>("ActiveIcon", isRecursively: true);
		buttonIcon = base.transform.FindComponent<TextMeshProUGUI>("ButtonIcon", isRecursively: true);
		levelObjectTooltip = GetComponent<LevelObjectTooltipTrigger>();
		activeIcon.gameObject.SetActive(value: false);
		buttonIcon.gameObject.SetActive(value: false);
	}

	protected override void ActionBeforeRemoveOldItemView()
	{
	}

	protected override Transform SetConfigurationHandler(CustomLevelObjectsModel itemModel)
	{
		levelObjectsParent = LevelEditorUtil.InstantiateLevelObjectsForUI(itemModel, base.ItemFolder.transform, referenceBlockObject);
		levelObjectTooltip.CustomLevelObjectsModel = itemModel;
		if (itemModel.Origin == CustomLevelObjectsModel.OriginEnum.Part)
		{
			LevelObjectView componentInChildren = levelObjectsParent.GetComponentInChildren<LevelObjectView>();
			if (componentInChildren.LogicType == LevelObjectLogicType.Input)
			{
				activeIcon.gameObject.SetActive(value: true);
			}
			else if (componentInChildren.LogicType == LevelObjectLogicType.Output)
			{
				buttonIcon.gameObject.SetActive(value: true);
			}
		}
		userIcon.gameObject.SetActive(itemModel.Origin == CustomLevelObjectsModel.OriginEnum.UserPart);
		itemScalableTransform = levelObjectsParent.transform;
		itemOriginalScale = levelObjectsParent.transform.localScale;
		return levelObjectsParent.transform;
	}
}
