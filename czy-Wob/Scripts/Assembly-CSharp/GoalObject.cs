using I2.Loc;
using UnityEngine;

[CreateAssetMenu(fileName = "GoalObject", menuName = "Goal", order = 1)]
public class GoalObject : ScriptableObject
{
	public string goalName;

	public string hiddenIDModifier;

	public string steamID;

	public LocalizedString localizedName;

	public LocalizedString localizedDesc;

	public RoomCustomizationObject requiredItem;

	public bool mysteryNameDescription;

	public bool mysteryUnlock;

	public GoalCondition condition;

	public int conditionCount = 1;

	public GoalRewardType rewardType;

	public int rewardCount = 1;

	public InventoryItem itemReward;

	public Researchable researchReward;

	public DogAge dogRewardAge;

	public SaveableDogGene dogRewardGene;

	public DogProfile dogRewardProfile;

	public SaveableDogPersonality dogRewardPersonality;

	public Sprite customDogRewardSprite;

	public InventoryItem foodUnlockReward;

	public LocalizedString gameplayUnlockText;

	public LocalizedString gameplayUnlockDescription;

	public string GetID()
	{
		return goalName + hiddenIDModifier;
	}

	public string GetProgressText()
	{
		return Mathf.Min(GoalsController.GetCounterForCondition(condition), conditionCount) + "/" + conditionCount;
	}

	public Sprite GetRewardSprite(GoalsGUIManager guiRef)
	{
		if (rewardType == GoalRewardType.INVENTORY_ITEM || rewardType == GoalRewardType.DOG_EGG)
		{
			return GetItemRewardSprite();
		}
		if (rewardType == GoalRewardType.RESEARCHABLE)
		{
			return GetResearchRewardSprite();
		}
		if (rewardType == GoalRewardType.DOG)
		{
			return GetDogRewardSprite();
		}
		if (rewardType == GoalRewardType.FOOD_TYPE)
		{
			return GetFoodRewardSprite();
		}
		if (rewardType == GoalRewardType.ROOM)
		{
			return guiRef.newRoomSprite;
		}
		if (rewardType == GoalRewardType.GAMEPLAY)
		{
			return GetGameplayRewardSprite();
		}
		return null;
	}

	public Sprite GetItemRewardSprite()
	{
		return itemReward.icon;
	}

	public Sprite GetResearchRewardSprite()
	{
		if (researchReward.inventoryItemUnlock != null)
		{
			return researchReward.inventoryItemUnlock.icon;
		}
		if (researchReward.roomCustomizationObjectUnlock != null)
		{
			return researchReward.roomCustomizationObjectUnlock.icon;
		}
		return null;
	}

	public Sprite GetDogRewardSprite()
	{
		return customDogRewardSprite;
	}

	public Sprite GetGameplayRewardSprite()
	{
		return customDogRewardSprite;
	}

	public Sprite GetFoodRewardSprite()
	{
		return foodUnlockReward.icon;
	}
}
