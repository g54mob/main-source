using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GroupCampaignView : BaseGUIView
{
	public const string PlayLevelEvent = "GroupCampaignView.PlayLevelEvent";

	public const string LevelLeaderboardsEvent = "GroupCampaignView.LevelLeaderboardsEvent";

	public const string BackButtonEvent = "GroupCampaignView.BackButtonEvent";

	[SerializeField]
	private GameObject levelGroupSlotPrefab;

	private TextMeshProUGUI levelsCountText;

	private GameObject levelGroupsPagePanel;

	private ToggleGroup levelSlotToggleGroup;

	private Button backButton;

	private GroupLevelDetailSlot groupLevelDetailSlot;

	private Scrollbar verticalScrollbar;

	private List<LevelGroupSlot> levelGroupSlots;

	private int lastGroupIndex;

	private int lastSlotIndex;

	public override void Initialize()
	{
		levelsCountText = mainPanel.transform.FindComponent<TextMeshProUGUI>("LevelsCountText", isRecursively: true);
		levelGroupsPagePanel = mainPanel.transform.FindChildRecursively("LevelGroupsPagePanel").gameObject;
		groupLevelDetailSlot = mainPanel.transform.FindComponent<GroupLevelDetailSlot>("LevelDetailPanel", isRecursively: true);
		levelSlotToggleGroup = mainPanel.transform.FindComponent<ToggleGroup>("LevelGroupsPagePanel", isRecursively: true);
		backButton = mainPanel.transform.FindComponent<Button>("BackButton", isRecursively: true);
		verticalScrollbar = mainPanel.transform.FindComponent<Scrollbar>("Scrollbar Vertical", isRecursively: true);
		backButton.onClick.AddListener(delegate
		{
			NotifyChange("GroupCampaignView.BackButtonEvent");
		});
		groupLevelDetailSlot.OnPlayButtonEvent += delegate(LevelModel levelModel)
		{
			NotifyChange("GroupCampaignView.PlayLevelEvent", levelModel);
		};
		groupLevelDetailSlot.OnLeaderboardsButtonEvent += delegate(LevelModel levelModel)
		{
			NotifyChange("GroupCampaignView.LevelLeaderboardsEvent", levelModel);
		};
		levelGroupSlots = new List<LevelGroupSlot>();
		lastGroupIndex = -1;
		lastSlotIndex = -1;
		ClearAllSlots();
	}

	public void ClearAllSlots()
	{
		levelGroupSlots.Clear();
		levelGroupsPagePanel.transform.RemoveAllChildren();
	}

	public void RefreshPages()
	{
	}

	public void AddLevelLoadSlot(int groupIndex, int slotIndex, LevelModel levelModel)
	{
		if (groupIndex >= levelGroupSlots.Count)
		{
			AddLevelGroupSlot(groupIndex, levelGroupsPagePanel.transform);
		}
		levelGroupSlots[groupIndex].SetLevelLoadSlot(slotIndex, levelModel, levelSlotToggleGroup);
	}

	private void AddLevelGroupSlot(int groupIndex, Transform pageTransform)
	{
		LevelGroupSlot component = Util.InstantiateForGUI(levelGroupSlotPrefab, pageTransform, "LevelGroup_" + groupIndex).GetComponent<LevelGroupSlot>();
		component.SetGroupIndex(groupIndex);
		component.OnSlotSelectedEvent += delegate(int slotIndex, LevelModel levelModel)
		{
			SlotSelectedHandler(groupIndex, slotIndex, levelModel);
		};
		levelGroupSlots.Add(component);
	}

	public void SelectLevelSlot(int groupIndex, int slotIndex, LevelModel levelModel)
	{
		SlotSelectedHandler(groupIndex, slotIndex, levelModel);
		levelGroupSlots[groupIndex].GetGroupLevelLoadSlot(slotIndex).SetToggleValue(isOn: true);
	}

	public void UpdateLevelsCountText(int levelsCompleted, int levelsTotal, int collectablesTotal, int bothPickedUp, int goldPickedUp, int silverPickedUp)
	{
		string text = $"<#F7EC3D>\uf046 <#FFFFFF>{levelsCompleted}/{levelsTotal}";
		string text2 = $"<#787878>\uf005 <#FFFFFF>{silverPickedUp}/{collectablesTotal}";
		string text3 = $"<#F7EC3D>\uf005 <#FFFFFF>{goldPickedUp}/{collectablesTotal}";
		string text4 = $"<#F7EC3D>\uf005<#787878>\uf005 <#FFFFFF>{bothPickedUp}/{collectablesTotal}";
		levelsCountText.SetText(text + "     " + text2 + "     " + text3 + "     " + text4);
	}

	public void UpdateLevelLoadSlotInfos(int groupIndex, int slotIndex, LevelModel levelModel)
	{
		GroupLevelLoadSlot groupLevelLoadSlot = levelGroupSlots[groupIndex].GetGroupLevelLoadSlot(slotIndex);
		groupLevelLoadSlot.SetLevelCompleteness(levelModel.IsLevelCompleted);
		groupLevelLoadSlot.SetLevelCollectables(levelModel.IsThereCollectables, levelModel.LevelStatus);
		if (levelModel == groupLevelDetailSlot.SelectedLevelModel)
		{
			groupLevelDetailSlot.SetConfiguration(levelModel);
		}
	}

	public void UpdateLevelGroupStatus(int groupIndex, int levelsToUnlockDelta, bool isGroupCompleted, bool isAllBoth, bool isAllGold, bool isAllSiver)
	{
		levelGroupSlots[groupIndex].SetLockedState(levelsToUnlockDelta);
		levelGroupSlots[groupIndex].SetGroupCompletenessStatus(isGroupCompleted, isAllBoth, isAllGold, isAllSiver);
	}

	public void UpdateLevelGroupName(int groupIndex, string groupName)
	{
		levelGroupSlots[groupIndex].SetGroupNameText(groupName);
	}

	private void SlotSelectedHandler(int groupIndex, int slotIndex, LevelModel levelModel)
	{
		groupLevelDetailSlot.SetConfiguration(levelModel);
		if (lastGroupIndex >= 0)
		{
			GroupLevelLoadSlot groupLevelLoadSlot = levelGroupSlots[lastGroupIndex].GetGroupLevelLoadSlot(lastSlotIndex);
			if (!groupLevelLoadSlot.gameObject.activeInHierarchy)
			{
				groupLevelLoadSlot.SetToggleValue(isOn: false);
			}
		}
		lastGroupIndex = groupIndex;
		lastSlotIndex = slotIndex;
	}
}
