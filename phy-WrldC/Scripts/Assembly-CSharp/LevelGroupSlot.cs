using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelGroupSlot : MonoBehaviour
{
	private TextMeshProUGUI groupNameText;

	private TextMeshProUGUI lockedText;

	private TextMeshProUGUI completedIcon;

	private TextMeshProUGUI starsIcon;

	private GameObject levelsPanel;

	private GroupLevelLoadSlot[] levelLoadSlots;

	private int toUnlockTotal;

	public int GroupIndex { get; private set; }

	public string LevelToUnlockTextBegin { get; set; }

	public string LevelToUnlockTextEnd { get; set; }

	public event Action<int, LevelModel> OnSlotSelectedEvent;

	private void Awake()
	{
		groupNameText = base.transform.FindComponent<TextMeshProUGUI>("GroupNameText", isRecursively: true);
		lockedText = base.transform.FindComponent<TextMeshProUGUI>("LockedText", isRecursively: true);
		completedIcon = base.transform.FindComponent<TextMeshProUGUI>("CompletedIcon", isRecursively: true);
		starsIcon = base.transform.FindComponent<TextMeshProUGUI>("StarsIcon", isRecursively: true);
		levelsPanel = base.transform.Find("LevelsPanel").gameObject;
		levelLoadSlots = levelsPanel.GetComponentsInChildren<GroupLevelLoadSlot>(includeInactive: true);
		int num = 0;
		GroupLevelLoadSlot[] array = levelLoadSlots;
		foreach (GroupLevelLoadSlot obj in array)
		{
			obj.Initialize();
			int fixedSlotIndex = num;
			obj.OnSlotSelectedEvent += delegate(LevelModel levelModel)
			{
				this.OnSlotSelectedEvent?.Invoke(fixedSlotIndex, levelModel);
			};
			obj.gameObject.SetActive(value: false);
			num++;
		}
		LevelToUnlockTextBegin = "Complete more";
		LevelToUnlockTextEnd = "levels to unlock";
	}

	public void SetGroupNameText(string groupName)
	{
		groupNameText.SetText(" - " + groupName);
	}

	public void SetGroupIndex(int groupIndex)
	{
		GroupIndex = groupIndex;
	}

	public void SetLevelLoadSlot(int index, LevelModel levelModel, ToggleGroup toggleGroup)
	{
		if (index < levelLoadSlots.Length)
		{
			GroupLevelLoadSlot obj = levelLoadSlots[index];
			string levelIndexText = (GroupIndex * 5 + (index + 1)).ToString();
			obj.gameObject.SetActive(value: true);
			obj.SetConfiguration(levelModel, levelIndexText, toggleGroup);
		}
	}

	public GroupLevelLoadSlot GetGroupLevelLoadSlot(int slotIndex)
	{
		return levelLoadSlots[slotIndex];
	}

	public void SetLockedState(int toUnlockTotal)
	{
		this.toUnlockTotal = toUnlockTotal;
		if (toUnlockTotal > 0)
		{
			groupNameText.color = GameManager.Instance.GameStylesData.lightBackground;
			starsIcon.gameObject.SetActive(value: false);
			levelsPanel.SetActive(value: false);
			lockedText.gameObject.SetActive(value: true);
			lockedText.SetText(LevelToUnlockTextBegin + " " + toUnlockTotal + " " + LevelToUnlockTextEnd);
		}
		else
		{
			groupNameText.color = GameManager.Instance.GameStylesData.brightText;
			starsIcon.gameObject.SetActive(value: true);
			levelsPanel.SetActive(value: true);
			lockedText.gameObject.SetActive(value: false);
		}
	}

	public void SetGroupCompletenessStatus(bool isGroupCompleted, bool isAllBoth, bool isAllGold, bool isAllSilver)
	{
		completedIcon.SetText(isGroupCompleted ? "\uf046" : "\uf096");
		completedIcon.color = (isGroupCompleted ? Util.HexToColor("#F7EC3DFF") : Util.HexToColor("#787878FF"));
		var (text, text2) = Util.GetLevelStarsDefaultIcons(isAllBoth, isAllGold, isAllSilver);
		starsIcon.SetText(text + text2);
	}

	public void RefreshLabels()
	{
		lockedText.SetText(LevelToUnlockTextBegin + " " + toUnlockTotal + " " + LevelToUnlockTextEnd);
	}
}
