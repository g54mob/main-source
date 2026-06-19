using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoalsGUIManager : MonoBehaviour
{
	public List<GoalObject> goalOrder;

	public List<int> goalIndices;

	public CursorUpdateArea goalsListUpdateArea;

	public Transform goalListContentHolder;

	public GameObject goalListObjectPrefab;

	public TextMeshProUGUI selectedGoalNameText;

	public Image selectedGoalRewardImage;

	public GameObject selectedGoalRewardMystery;

	public TextMeshProUGUI selectedGoalDescriptionText;

	public TextMeshProUGUI selectedGoalProgressText;

	public TextMeshProUGUI selectedGoalRewardCountText;

	public GameObject selectedGoalInProgressHolder;

	public GameObject selectedGoalUnclaimedHolder;

	public GameObject selectedGoalClaimedHolder;

	public TextMeshProUGUI completionPercentageText;

	public GameObject iconBouncer;

	public TextMeshProUGUI newUnlockText;

	public GameObject unlockPopup;

	public Image unlockIconHolder;

	public TextMeshProUGUI unlockNameText;

	public TextMeshProUGUI unlockSecondaryText;

	public TextMeshProUGUI unlockStandaloneDescriptionText;

	public GameObject loadingDogText;

	public GameObject dogTexture;

	public Transform dogRotationAreaTransform;

	public Sprite newRoomSprite;

	private string claimUnlockSound = "goalClaim";

	private string closeUnlockPopupSound = "unlockPopupClose";

	private string panelOpenSound = "goalsPanel_open";

	private string panelCloseSound = "goalsPanel_close";

	private string mysteryGoalNameString = "????";

	private string mysteryGoalDescriptionString = "??????????";

	private int currentlySelectedGoalIndex = -1;

	private List<GoalListItem> goalListItems = new List<GoalListItem>();

	private List<string> goalListItemIndexToIDList = new List<string>();

	private bool guiClosed;

	private DogHome homeRef;

	private Inchworm inchwormRef;

	private DogRegistration dogRegRef;

	private ResearchManager researchRef;

	private PlayerInventory inventoryRef;

	public void OnGUIOpened()
	{
		guiClosed = false;
		SFXOverlord.LockInWorldSFX(LockReason.DOG_GOALS_GUI);
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		homeRef = registrationScript.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		inchwormRef = registrationScript.GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		researchRef = registrationScript.GetGlobalComponent<ResearchManager>(GlobalObject.RESEARCH_MANAGER);
		inventoryRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).playerInventory;
		unlockPopup.SetActive(value: false);
		LoadGoals();
		UpdateCompletionText();
		AudioController.Play(panelOpenSound);
	}

	private void Update()
	{
		if (GameControls.actions.CloseMenu.WasPressed)
		{
			if (unlockPopup.activeSelf)
			{
				CloseUnlockPopup();
			}
			else
			{
				CloseGUI();
			}
		}
	}

	private void OnDestroy()
	{
		AudioController.Play(panelCloseSound);
		SFXOverlord.UnlockInWorldSFX(LockReason.DOG_GOALS_GUI);
	}

	public void CloseGUI()
	{
		if (!guiClosed)
		{
			guiClosed = true;
			ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI).OnGoalsGUIClosed();
		}
	}

	public void ClaimSelectedGoal()
	{
		if (currentlySelectedGoalIndex < 0)
		{
			Debug.LogError("Invalid goal selected!");
			return;
		}
		GoalObject goalForID = GoalsController.GetGoalForID(goalListItemIndexToIDList[currentlySelectedGoalIndex]);
		GoalsController.SetGoalClaimed(goalForID.GetID());
		dogTexture.SetActive(value: false);
		loadingDogText.SetActive(value: false);
		unlockSecondaryText.gameObject.SetActive(value: false);
		unlockStandaloneDescriptionText.gameObject.SetActive(value: false);
		unlockIconHolder.sprite = goalForID.GetRewardSprite(this);
		unlockIconHolder.SetNativeSize();
		if (goalForID.rewardType == GoalRewardType.INVENTORY_ITEM)
		{
			newUnlockText.text = ScriptLocalization.GUI.GUI_GOALS_ITEMREC;
			unlockNameText.text = goalForID.itemReward.itemNameLocalized;
			inventoryRef.AddObjectToIventory(goalForID.itemReward, goalForID.rewardCount);
			if (goalForID.itemReward.type == ItemType.TOY)
			{
				inventoryRef.MarkItemAsNew(goalForID.itemReward);
			}
			if (goalForID.rewardCount > 1)
			{
				unlockNameText.text += " x" + goalForID.rewardCount;
			}
		}
		else if (goalForID.rewardType == GoalRewardType.DOG_EGG)
		{
			newUnlockText.text = ScriptLocalization.GUI.GUI_GOALS_ITEMREC;
			unlockNameText.text = goalForID.itemReward.itemNameLocalized;
			for (int i = 0; i < goalForID.rewardCount; i++)
			{
				SaveableDogEgg egg = new SaveableDogEgg(null, null, fertilizedStatus: false, null, newEmptyGut: false);
				inventoryRef.AddEggToInventory(egg);
			}
			if (goalForID.rewardCount > 1)
			{
				unlockNameText.text += " x" + goalForID.rewardCount;
			}
		}
		else if (goalForID.rewardType == GoalRewardType.RESEARCHABLE)
		{
			newUnlockText.text = ScriptLocalization.GUI.GUI_GOALS_OBJUNLOCKED;
			researchRef.UnlockSpecificResearch(goalForID.researchReward);
			if (goalForID.researchReward.roomCustomizationObjectUnlock != null)
			{
				unlockNameText.text = goalForID.researchReward.roomCustomizationObjectUnlock.GetName();
			}
			else if (goalForID.researchReward.inventoryItemUnlock != null)
			{
				unlockNameText.text = goalForID.researchReward.inventoryItemUnlock.itemNameLocalized;
			}
			else
			{
				unlockNameText.text = "Error!";
			}
		}
		else if (goalForID.rewardType == GoalRewardType.DOG)
		{
			newUnlockText.text = ScriptLocalization.GUI.GUI_GOALS_NEWDOG;
			string gUI_GOALS_DOGWAITING = ScriptLocalization.GUI.GUI_GOALS_DOGWAITING;
			int length = gUI_GOALS_DOGWAITING.IndexOf("[");
			int num = gUI_GOALS_DOGWAITING.IndexOf("]");
			unlockNameText.text = gUI_GOALS_DOGWAITING.Substring(0, length) + goalForID.dogRewardProfile.defaultName + gUI_GOALS_DOGWAITING.Substring(num + 1);
			SaveableDogGene copy = goalForID.dogRewardGene.GetCopy();
			MasterDogGene.MigrateSaveableDogGene(copy);
			SaveableDogProfile saveableDogProfile = new SaveableDogProfile(goalForID.dogRewardProfile);
			dogRegRef.RequestNewDog(new Vector3(0f, 0f, -100f), Quaternion.identity, copy, null, manualDog: false, dogProfile: saveableDogProfile, customDogAge: goalForID.dogRewardAge, customDogPersonality: goalForID.dogRewardPersonality, callback: RewardDogCreatedCallback, playerOwned: true, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: false, dummyDog: false, customDogAgeProgress: 0f, traitsAllowed: true, useTemporaryID: false, customFloraPool: null, respectMaxDogs: false);
		}
		else if (goalForID.rewardType == GoalRewardType.FOOD_TYPE)
		{
			newUnlockText.text = ScriptLocalization.GUI.GUI_GOALS_NEWFOOD;
			unlockNameText.text = goalForID.foodUnlockReward.itemNameLocalized;
			inventoryRef.UnlockFood(goalForID.foodUnlockReward);
			unlockSecondaryText.gameObject.SetActive(value: true);
			string gUI_GOALS_FORUSE = ScriptLocalization.GUI.GUI_GOALS_FORUSE;
			int length2 = gUI_GOALS_FORUSE.IndexOf("[");
			int num2 = gUI_GOALS_FORUSE.IndexOf("]");
			unlockSecondaryText.text = gUI_GOALS_FORUSE.Substring(0, length2) + goalForID.requiredItem.GetName() + gUI_GOALS_FORUSE.Substring(num2 + 1);
		}
		else if (goalForID.rewardType == GoalRewardType.ROOM)
		{
			newUnlockText.text = ScriptLocalization.GUI.GUI_GOALS_ADDPEN;
			unlockNameText.text = ScriptLocalization.GUI.GUI_GOALS_WOW;
			homeRef.UnlockAdditionalPens();
		}
		else if (goalForID.rewardType == GoalRewardType.GAMEPLAY)
		{
			newUnlockText.text = goalForID.gameplayUnlockText;
			unlockNameText.text = "";
			unlockStandaloneDescriptionText.gameObject.SetActive(value: true);
			unlockStandaloneDescriptionText.text = goalForID.gameplayUnlockDescription;
		}
		goalListItems[currentlySelectedGoalIndex].SetGoalIndexAndID(currentlySelectedGoalIndex, goalListItemIndexToIDList[currentlySelectedGoalIndex]);
		goalListItems[currentlySelectedGoalIndex].OnGoalSelected();
		UpdateCompletionText();
		unlockPopup.SetActive(value: true);
		AudioController.Play(claimUnlockSound);
		TextScaleInEffect.ScaleInText(newUnlockText);
		if (goalForID.dogRewardGene == null)
		{
			iconBouncer.transform.localScale = Vector3.zero;
			inchwormRef.RequestEaseToScale(iconBouncer, Vector3.one, 0.5f, Inchworm.EaseStyle.EaseOutBounce);
		}
	}

	public void CloseUnlockPopup()
	{
		unlockPopup.SetActive(value: false);
		AudioController.Play(closeUnlockPopupSound);
	}

	private void RewardDogCreatedCallback(GameObject newDog)
	{
		Object.Destroy(newDog);
	}

	public void SelectGoal(int index)
	{
		if (currentlySelectedGoalIndex >= 0)
		{
			goalListItems[currentlySelectedGoalIndex].OnGoalDeselected();
			goalListItems[currentlySelectedGoalIndex].gameObject.SetActive(value: false);
			goalListItems[currentlySelectedGoalIndex].gameObject.SetActive(value: true);
		}
		currentlySelectedGoalIndex = index;
		GoalObject goalForID = GoalsController.GetGoalForID(goalListItemIndexToIDList[index]);
		selectedGoalNameText.text = goalForID.localizedName;
		selectedGoalDescriptionText.text = goalForID.localizedDesc;
		selectedGoalProgressText.text = goalForID.GetProgressText();
		if (goalForID.rewardCount > 1 && goalForID.rewardType == GoalRewardType.INVENTORY_ITEM)
		{
			selectedGoalRewardCountText.gameObject.SetActive(value: true);
			selectedGoalRewardCountText.text = ("x" + goalForID.rewardCount) ?? "";
		}
		else
		{
			selectedGoalRewardCountText.gameObject.SetActive(value: false);
		}
		GoalStatus statusForID = GoalsController.GetStatusForID(goalListItemIndexToIDList[index]);
		selectedGoalInProgressHolder.SetActive(statusForID == GoalStatus.INCOMPLETE);
		selectedGoalUnclaimedHolder.SetActive(statusForID == GoalStatus.UNCLAIMED);
		selectedGoalClaimedHolder.SetActive(statusForID == GoalStatus.CLAIMED);
		if (goalForID.conditionCount <= 1)
		{
			selectedGoalInProgressHolder.SetActive(value: false);
		}
		Sprite sprite = goalForID.GetRewardSprite(this);
		selectedGoalRewardImage.sprite = sprite;
		selectedGoalRewardImage.SetNativeSize();
		if ((statusForID == GoalStatus.INCOMPLETE || statusForID == GoalStatus.UNCLAIMED) && goalForID.mysteryUnlock)
		{
			sprite = null;
		}
		if (statusForID == GoalStatus.INCOMPLETE && goalForID.mysteryNameDescription)
		{
			selectedGoalDescriptionText.text = mysteryGoalDescriptionString;
			selectedGoalProgressText.text = mysteryGoalNameString;
		}
		if (sprite == null)
		{
			selectedGoalRewardMystery.SetActive(value: true);
			selectedGoalRewardImage.gameObject.SetActive(value: false);
		}
		else
		{
			selectedGoalRewardMystery.SetActive(value: false);
			selectedGoalRewardImage.gameObject.SetActive(value: true);
		}
	}

	private void LoadGoals()
	{
		goalListItems.Clear();
		goalListItemIndexToIDList.Clear();
		int num = 0;
		for (int i = 0; i < goalOrder.Count; i++)
		{
			string iD = goalOrder[i].GetID();
			if (GoalsController.GetStatusForID(iD) == GoalStatus.UNCLAIMED)
			{
				GoalListItem component = Object.Instantiate(goalListObjectPrefab, goalListContentHolder).GetComponent<GoalListItem>();
				component.SetGoalName(goalOrder[i].localizedName);
				component.SetGoalIndexAndID(num, iD);
				component.SetGoalsGUIRef(this, goalsListUpdateArea);
				goalListItems.Add(component);
				goalListItemIndexToIDList.Add(iD);
				num++;
			}
		}
		for (int j = 0; j < goalOrder.Count; j++)
		{
			string iD2 = goalOrder[j].GetID();
			if (GoalsController.GetStatusForID(iD2) == GoalStatus.INCOMPLETE)
			{
				GoalListItem component2 = Object.Instantiate(goalListObjectPrefab, goalListContentHolder).GetComponent<GoalListItem>();
				component2.SetGoalName(goalOrder[j].localizedName);
				component2.SetGoalIndexAndID(num, iD2);
				component2.SetGoalsGUIRef(this, goalsListUpdateArea);
				goalListItems.Add(component2);
				goalListItemIndexToIDList.Add(iD2);
				num++;
			}
		}
		for (int k = 0; k < goalOrder.Count; k++)
		{
			string iD3 = goalOrder[k].GetID();
			if (GoalsController.GetStatusForID(iD3) == GoalStatus.CLAIMED)
			{
				GoalListItem component3 = Object.Instantiate(goalListObjectPrefab, goalListContentHolder).GetComponent<GoalListItem>();
				component3.SetGoalName(goalOrder[k].localizedName);
				component3.SetGoalIndexAndID(num, iD3);
				component3.SetGoalsGUIRef(this, goalsListUpdateArea);
				goalListItems.Add(component3);
				goalListItemIndexToIDList.Add(iD3);
				num++;
			}
		}
		if (goalListItems.Count > 0)
		{
			goalListItems[0].OnGoalSelected();
		}
	}

	private void UpdateCompletionText()
	{
		string gUI_GOALS_COMPLETION = ScriptLocalization.GUI.GUI_GOALS_COMPLETION;
		int length = gUI_GOALS_COMPLETION.IndexOf("[");
		int num = gUI_GOALS_COMPLETION.IndexOf("]");
		completionPercentageText.text = gUI_GOALS_COMPLETION.Substring(0, length) + GoalsController.GetCompletionPercentageAsString() + gUI_GOALS_COMPLETION.Substring(num + 1);
	}
}
