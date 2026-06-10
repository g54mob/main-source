using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class AchievementsPanel : MonoBehaviour
{
	[Header("List References")]
	public AchievementEntryUI achievementEntryPrefab;

	public Transform contentParent;

	public ScrollRect scrollRect;

	[Header("Hidden State Setup")]
	public Sprite hiddenRewardSprite;

	[TextArea]
	public string hiddenTooltipText = "A mysterious reward awaits...";

	[Header("Bottom Detail Panel — Core")]
	public GameObject detailPanel;

	public Image detailIcon;

	public TMP_Text detailNameText;

	public TMP_Text detailDescriptionText;

	public Image detailProgressFill;

	public TMP_Text detailProgressText;

	[Header("Bottom Detail Panel — Reward Badge")]
	[Tooltip("The coin + reward badge group — shown when the achievement is visible to the player.")]
	public GameObject detailRewardBadge;

	[Tooltip("The number text inside the detail reward badge.")]
	public TMP_Text detailRewardBadgeText;

	[Tooltip("The actual image component to display the detail reward category icon.")]
	public Image detailRewardIcon;

	[Header("Bottom Detail Panel — Checkmark")]
	[Tooltip("The checkmark Image in the detail panel. Full opacity when completed/claimed, low opacity when in-progress.")]
	public Image detailCheckmark;

	[Tooltip("Opacity of the checkmark when the achievement is NOT yet completed.")]
	[Range(0f, 1f)]
	public float incompleteCheckmarkAlpha = 0.2f;

	[Header("Bottom Detail Panel — Claim Button")]
	[Tooltip("Optional claim button inside the detail panel itself.")]
	public Button detailClaimButton;

	private readonly List<AchievementEntryUI> spawnedEntries = new List<AchievementEntryUI>();

	private AchievementEntryUI selectedEntry;

	public void Refresh()
	{
		AchievementManager.Instance?.RefreshCompletionStatus();
		PopulateList();
		if (AchievementManager.Instance != null)
		{
			AchievementManager.Instance.OnAchievementCompleted -= OnAchievementStateChanged;
			AchievementManager.Instance.OnAchievementClaimed -= OnAchievementStateChanged;
			AchievementManager.Instance.OnAchievementCompleted += OnAchievementStateChanged;
			AchievementManager.Instance.OnAchievementClaimed += OnAchievementStateChanged;
		}
	}

	private void OnDisable()
	{
		if (AchievementManager.Instance != null)
		{
			AchievementManager.Instance.OnAchievementCompleted -= OnAchievementStateChanged;
			AchievementManager.Instance.OnAchievementClaimed -= OnAchievementStateChanged;
		}
	}

	private void OnAchievementStateChanged(Achievement ach)
	{
		PopulateList();
	}

	public void PopulateList()
	{
		if (AchievementManager.Instance == null || achievementEntryPrefab == null || contentParent == null)
		{
			return;
		}
		foreach (AchievementEntryUI spawnedEntry in spawnedEntries)
		{
			if (spawnedEntry != null)
			{
				Object.Destroy(spawnedEntry.gameObject);
			}
		}
		spawnedEntries.Clear();
		foreach (Achievement item in (from ach in AchievementManager.Instance.allAchievements
			orderby GetSortOrder(ach), ach.displayOrder
			select ach).ToList())
		{
			AchievementEntryUI achievementEntryUI = Object.Instantiate(achievementEntryPrefab, contentParent);
			bool isCompleted = AchievementManager.Instance.IsAchievementCompleted(item.ID);
			bool isClaimed = AchievementManager.Instance.IsAchievementClaimed(item.ID);
			float progress = AchievementManager.Instance.GetProgress(item);
			achievementEntryUI.Setup(item, isCompleted, isClaimed, progress);
			achievementEntryUI.OnSelected += OnEntrySelected;
			spawnedEntries.Add(achievementEntryUI);
		}
		if (spawnedEntries.Count > 0)
		{
			OnEntrySelected(spawnedEntries[0]);
		}
		else
		{
			HideDetailPanel();
		}
		if (scrollRect != null)
		{
			StartCoroutine(ResetScrollNextFrame());
		}
	}

	private int GetSortOrder(Achievement ach)
	{
		bool flag = AchievementManager.Instance.IsAchievementCompleted(ach.ID);
		bool flag2 = AchievementManager.Instance.IsAchievementClaimed(ach.ID);
		if (flag2)
		{
			return 2;
		}
		if (flag && !flag2)
		{
			return 0;
		}
		return 1;
	}

	private void OnEntrySelected(AchievementEntryUI entry)
	{
		if (selectedEntry != null)
		{
			selectedEntry.SetSelected(selected: false);
		}
		selectedEntry = entry;
		entry.SetSelected(selected: true);
		ShowDetailPanel(entry);
	}

	private void ShowDetailPanel(AchievementEntryUI entry)
	{
		if (detailPanel == null)
		{
			return;
		}
		Achievement ach = entry.Achievement;
		bool isCompleted = entry.IsCompleted;
		bool isClaimed = entry.IsClaimed;
		bool flag = isCompleted && !isClaimed;
		bool flag2 = isCompleted || isClaimed || !ach.isHidden;
		detailPanel.SetActive(value: true);
		if (detailIcon != null)
		{
			if (ach.icon != null)
			{
				detailIcon.sprite = ach.icon;
			}
			detailIcon.color = (isCompleted ? Color.white : Color.black);
		}
		if (detailNameText != null)
		{
			string localizedString = new LocalizedString("Skills", "#ui.achievements.mysterious_reward").GetLocalizedString();
			string text = ((!string.IsNullOrEmpty(localizedString) && !localizedString.StartsWith("#")) ? localizedString : "???");
			detailNameText.text = (flag2 ? ach.GetLocalizedName() : text);
		}
		if (detailDescriptionText != null)
		{
			string localizedString2 = new LocalizedString("Skills", "#ui.achievements.hidden_desc").GetLocalizedString();
			string text2 = ((!string.IsNullOrEmpty(localizedString2) && !localizedString2.StartsWith("#")) ? localizedString2 : "Complete other achievements to reveal this one.");
			detailDescriptionText.text = (flag2 ? ach.GetLocalizedDescription() : text2);
		}
		if (detailRewardBadge != null)
		{
			detailRewardBadge.SetActive(value: true);
			SetupTooltip(detailRewardBadge, ach, flag2);
		}
		if (detailRewardBadgeText != null)
		{
			string localizedString3 = new LocalizedString("Skills", "#ui.achievements.mysterious_reward").GetLocalizedString();
			string text3 = ((!string.IsNullOrEmpty(localizedString3) && !localizedString3.StartsWith("#")) ? localizedString3 : "?");
			detailRewardBadgeText.text = (flag2 ? FormatRewardAmountText(ach) : text3);
		}
		if (detailRewardIcon != null)
		{
			if (flag2)
			{
				Sprite rewardIcon = AchievementManager.Instance.GetRewardIcon(ach.rewardBonusType);
				if (rewardIcon != null)
				{
					detailRewardIcon.sprite = rewardIcon;
				}
			}
			else if (hiddenRewardSprite != null)
			{
				detailRewardIcon.sprite = hiddenRewardSprite;
			}
			SetupTooltip(detailRewardIcon.gameObject, ach, flag2);
		}
		if (detailCheckmark != null)
		{
			float a = ((isCompleted || isClaimed) ? 1f : incompleteCheckmarkAlpha);
			Color color = detailCheckmark.color;
			color.a = a;
			detailCheckmark.color = color;
			SimpleTooltipTrigger component = detailCheckmark.GetComponent<SimpleTooltipTrigger>();
			if (component != null)
			{
				component.enabled = false;
			}
		}
		if (detailClaimButton != null)
		{
			detailClaimButton.gameObject.SetActive(flag);
			if (flag)
			{
				detailClaimButton.onClick.RemoveAllListeners();
				detailClaimButton.onClick.AddListener(delegate
				{
					AchievementManager.Instance?.ClaimAchievement(ach.ID);
				});
				SetupTooltip(detailClaimButton.gameObject, ach, flag2);
			}
		}
		if (detailProgressFill != null)
		{
			detailProgressFill.fillAmount = ((isCompleted || isClaimed) ? 1f : entry.Progress);
		}
		if (detailProgressText != null)
		{
			if (isClaimed)
			{
				string localizedString4 = new LocalizedString("Skills", "#ui.achievements.claimed").GetLocalizedString();
				detailProgressText.text = ((!string.IsNullOrEmpty(localizedString4) && !localizedString4.StartsWith("#")) ? localizedString4 : "Claimed!");
			}
			else if (isCompleted)
			{
				string localizedString5 = new LocalizedString("Skills", "#ui.achievements.ready_to_claim.progress").GetLocalizedString();
				string format = ((!string.IsNullOrEmpty(localizedString5) && !localizedString5.StartsWith("#")) ? localizedString5 : "{0} / {1} — Ready to claim!");
				detailProgressText.text = ach.GetLocalizedRequirementType() + " - " + string.Format(format, ach.requirementValue, ach.requirementValue);
			}
			else if (flag2)
			{
				int num = Mathf.RoundToInt(entry.Progress * (float)ach.requirementValue);
				detailProgressText.text = $"{ach.GetLocalizedRequirementType()} - {num} / {ach.requirementValue}";
			}
			else
			{
				string localizedString6 = new LocalizedString("Skills", "#ui.achievements.mysterious_reward").GetLocalizedString();
				detailProgressText.text = ((!string.IsNullOrEmpty(localizedString6) && !localizedString6.StartsWith("#")) ? localizedString6 : "???");
			}
		}
	}

	private IEnumerator ResetScrollNextFrame()
	{
		yield return null;
		scrollRect.verticalNormalizedPosition = 1f;
	}

	private void HideDetailPanel()
	{
		if (detailPanel != null)
		{
			detailPanel.SetActive(value: false);
		}
	}

	private SimpleTooltipTrigger SetupTooltip(GameObject badgeObj, Achievement ach, bool reveal)
	{
		if (badgeObj == null)
		{
			return null;
		}
		SimpleTooltipTrigger simpleTooltipTrigger = badgeObj.GetComponent<SimpleTooltipTrigger>();
		if (simpleTooltipTrigger == null)
		{
			simpleTooltipTrigger = badgeObj.AddComponent<SimpleTooltipTrigger>();
		}
		string localizedString = new LocalizedString("Skills", "#ui.achievements.hidden_tooltip").GetLocalizedString();
		string text = ((!string.IsNullOrEmpty(localizedString) && !localizedString.StartsWith("#")) ? localizedString : hiddenTooltipText);
		simpleTooltipTrigger.tooltipText = (reveal ? FormatRewardDescriptionText(ach) : text);
		simpleTooltipTrigger.showHeaderText = false;
		return simpleTooltipTrigger;
	}

	private string FormatRewardAmountText(Achievement ach)
	{
		if (ach.rewardBonusType == SkillBonusType.None)
		{
			return Mathf.RoundToInt(ach.rewardValue).ToString();
		}
		string text = (Mathf.Approximately(Mathf.RoundToInt(ach.rewardValue), ach.rewardValue) ? ach.rewardValue.ToString() : ach.rewardValue.ToString("0.##"));
		if (ach.rewardBonusType.ToString().StartsWith("mult_"))
		{
			return "x" + text;
		}
		return "+" + text;
	}

	private string FormatRewardDescriptionText(Achievement ach)
	{
		if (ach.rewardBonusType == SkillBonusType.None)
		{
			string localizedString = new LocalizedString("Skills", "#ui.achievements.reward.money").GetLocalizedString();
			if (string.IsNullOrEmpty(localizedString) || localizedString.StartsWith("#"))
			{
				return "Money";
			}
			return localizedString;
		}
		string text = ach.rewardBonusType.ToString();
		string text2 = "#ui.stat." + text.Replace("_", ".");
		if (ach.rewardBonusType == SkillBonusType.add_fish_tracker_tier || ach.rewardBonusType == SkillBonusType.enable_tracker_tier2 || ach.rewardBonusType == SkillBonusType.enable_tracker_tier3)
		{
			text2 = "#ui.stat.tracker.tier";
		}
		string text3 = new LocalizedString("Skills", text2).GetLocalizedString();
		if (string.IsNullOrEmpty(text3) || text3.StartsWith("#"))
		{
			string text4 = text.Replace("add_", "").Replace("mult_", "").Replace("enable_", "")
				.Replace("_", " ");
			text3 = char.ToUpper(text4[0]) + text4.Substring(1);
		}
		if (text.StartsWith("add_"))
		{
			string localizedString2 = new LocalizedString("Skills", "#ui.achievements.reward.increases").GetLocalizedString();
			return string.Format((!string.IsNullOrEmpty(localizedString2) && !localizedString2.StartsWith("#")) ? localizedString2 : "Increases {0}", text3);
		}
		if (text.StartsWith("mult_"))
		{
			string localizedString3 = new LocalizedString("Skills", "#ui.achievements.reward.multiplies").GetLocalizedString();
			return string.Format((!string.IsNullOrEmpty(localizedString3) && !localizedString3.StartsWith("#")) ? localizedString3 : "Multiplies {0}", text3);
		}
		if (text.StartsWith("enable_"))
		{
			string localizedString4 = new LocalizedString("Skills", "#ui.achievements.reward.enables").GetLocalizedString();
			return string.Format((!string.IsNullOrEmpty(localizedString4) && !localizedString4.StartsWith("#")) ? localizedString4 : "Enables {0}", text3);
		}
		return text3;
	}
}
