using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;
using UnityEngine.UI;

public class AchievementEntryUI : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Header("References — Shared")]
	public Image iconImage;

	public TMP_Text nameText;

	public Image progressFillImage;

	public TMP_Text progressText;

	public Image rowBackground;

	[Header("References — In-Progress State")]
	[Tooltip("The coin + reward-number badge shown on the RIGHT when the achievement is in progress.")]
	public GameObject inProgressRewardBadge;

	[Tooltip("The reward number text inside the in-progress right badge.")]
	public TMP_Text inProgressRewardText;

	[Tooltip("The actual image component to display the reward category icon.")]
	public Image inProgressRewardIcon;

	[Header("References — Claimable State")]
	[Tooltip("The pink coin + reward-number badge shown on the LEFT when ready to claim (replaces the icon).")]
	public GameObject claimableLeftBadge;

	[Tooltip("The reward number text inside the claimable left badge.")]
	public TMP_Text claimableRewardText;

	[Tooltip("The actual image component to display the reward category icon.")]
	public Image claimableRewardIcon;

	[Tooltip("Checkmark shown on the RIGHT when the achievement is ready to claim or already claimed.")]
	public GameObject rightCheckmark;

	public Button claimButton;

	[Header("References — Claimed State")]
	[Tooltip("Optional badge/overlay displayed after the reward has been collected.")]
	public GameObject claimedBadge;

	[Tooltip("Full-panel Image used as a dimming overlay. Hidden normally, dark+semi-transparent when claimable, darker when claimed.")]
	public Image cardOverlay;

	[Header("Selection")]
	public Button selectButton;

	public GameObject selectionHighlight;

	[Header("Colors")]
	public Color claimableRowColor = new Color(0.85f, 0.15f, 0.55f, 1f);

	public Color defaultRowColor = new Color(0.1f, 0.14f, 0.18f, 1f);

	public Color claimedRowColor = new Color(0.1f, 0.14f, 0.18f, 1f);

	public Color claimedIconColor = Color.white;

	public Color completedIconColor = Color.white;

	public Color lockedIconColor = Color.black;

	[Tooltip("Alpha of the dark overlay when the achievement is ready to claim (0–1).")]
	[Range(0f, 1f)]
	public float claimableOverlayAlpha = 0.45f;

	[Tooltip("Alpha of the dark overlay when the achievement has already been claimed (0–1).")]
	[Range(0f, 1f)]
	public float claimedOverlayAlpha = 0.65f;

	[Header("Hover Animation")]
	[Tooltip("Punch scale strength on hover-enter (e.g. 0.06 = 6% pop).")]
	public float hoverPunchStrength = 0.06f;

	[Tooltip("Duration of the punch animation.")]
	public float hoverPunchDuration = 0.3f;

	[Tooltip("Scale factor held while cursor is on the row.")]
	public float hoverHoldScale = 1.04f;

	[Tooltip("Duration of the scale-back on hover-exit.")]
	public float hoverExitDuration = 0.12f;

	[Header("Hidden State")]
	public Sprite hiddenRewardSprite;

	[TextArea]
	public string hiddenTooltipText = "A mysterious reward awaits...";

	private Achievement _ach;

	private bool _isCompleted;

	private bool _isClaimed;

	private float _progress;

	private Vector3 _originalScale;

	private bool _isHovered;

	public Achievement Achievement => _ach;

	public bool IsCompleted => _isCompleted;

	public bool IsClaimed => _isClaimed;

	public float Progress => _progress;

	public event Action<AchievementEntryUI> OnSelected;

	private void Awake()
	{
		_originalScale = base.transform.localScale;
	}

	private void OnDisable()
	{
		DOTween.Kill(base.transform);
		base.transform.localScale = _originalScale;
	}

	public void Setup(Achievement ach, bool isCompleted, bool isClaimed, float progress)
	{
		_ach = ach;
		_isCompleted = isCompleted;
		_isClaimed = isClaimed;
		_progress = progress;
		_originalScale = base.transform.localScale;
		bool flag = isCompleted || isClaimed || !ach.isHidden;
		bool flag2 = isCompleted && !isClaimed;
		if (rowBackground != null)
		{
			if (flag2)
			{
				rowBackground.color = claimableRowColor;
			}
			else if (isClaimed)
			{
				rowBackground.color = claimedRowColor;
			}
			else
			{
				rowBackground.color = defaultRowColor;
			}
		}
		if (cardOverlay != null)
		{
			cardOverlay.raycastTarget = false;
			if (flag2)
			{
				cardOverlay.gameObject.SetActive(value: true);
				cardOverlay.color = new Color(0f, 0f, 0f, claimableOverlayAlpha);
			}
			else if (isClaimed)
			{
				cardOverlay.gameObject.SetActive(value: true);
				cardOverlay.color = new Color(0f, 0f, 0f, claimedOverlayAlpha);
			}
			else
			{
				cardOverlay.gameObject.SetActive(value: false);
			}
		}
		if (nameText != null)
		{
			string localizedString = new LocalizedString("Skills", "#ui.achievements.mysterious_reward").GetLocalizedString();
			string text = ((!string.IsNullOrEmpty(localizedString) && !localizedString.StartsWith("#")) ? localizedString : "???");
			nameText.text = (flag ? ach.GetLocalizedName() : text);
		}
		if (iconImage != null)
		{
			iconImage.gameObject.SetActive(value: true);
			if (ach.icon != null)
			{
				iconImage.sprite = ach.icon;
			}
			if (isClaimed)
			{
				iconImage.color = claimedIconColor;
			}
			else if (isCompleted)
			{
				iconImage.color = completedIconColor;
			}
			else
			{
				iconImage.color = lockedIconColor;
			}
		}
		if (claimableLeftBadge != null)
		{
			claimableLeftBadge.SetActive(flag2 || isClaimed);
			SimpleTooltipTrigger simpleTooltipTrigger = SetupTooltip(claimableLeftBadge, ach);
			if (simpleTooltipTrigger != null)
			{
				simpleTooltipTrigger.enabled = false;
			}
		}
		if (claimableRewardText != null)
		{
			claimableRewardText.text = FormatRewardAmountText(ach);
		}
		if (claimableRewardIcon != null && AchievementManager.Instance != null)
		{
			Sprite rewardIcon = AchievementManager.Instance.GetRewardIcon(ach.rewardBonusType);
			if (rewardIcon != null)
			{
				claimableRewardIcon.sprite = rewardIcon;
			}
			SimpleTooltipTrigger component = claimableRewardIcon.GetComponent<SimpleTooltipTrigger>();
			if (component != null)
			{
				component.enabled = false;
			}
		}
		if (inProgressRewardBadge != null)
		{
			inProgressRewardBadge.SetActive(!flag2 && !isClaimed);
			SimpleTooltipTrigger simpleTooltipTrigger2 = SetupTooltip(inProgressRewardBadge, ach, flag);
			if (simpleTooltipTrigger2 != null)
			{
				simpleTooltipTrigger2.enabled = !flag2 && !isClaimed;
			}
			Image component2 = inProgressRewardBadge.GetComponent<Image>();
			if (component2 != null)
			{
				component2.raycastTarget = !flag2 && !isClaimed;
			}
		}
		if (inProgressRewardText != null)
		{
			string localizedString2 = new LocalizedString("Skills", "#ui.achievements.mysterious_reward").GetLocalizedString();
			string text2 = ((!string.IsNullOrEmpty(localizedString2) && !localizedString2.StartsWith("#")) ? localizedString2 : "?");
			inProgressRewardText.text = (flag ? FormatRewardAmountText(ach) : text2);
		}
		if (inProgressRewardIcon != null && AchievementManager.Instance != null)
		{
			if (flag)
			{
				inProgressRewardIcon.gameObject.SetActive(value: true);
				Sprite rewardIcon2 = AchievementManager.Instance.GetRewardIcon(ach.rewardBonusType);
				if (rewardIcon2 != null)
				{
					inProgressRewardIcon.sprite = rewardIcon2;
				}
				SimpleTooltipTrigger simpleTooltipTrigger3 = SetupTooltip(inProgressRewardIcon.gameObject, ach, flag);
				if (simpleTooltipTrigger3 != null)
				{
					simpleTooltipTrigger3.enabled = !flag2 && !isClaimed;
				}
				inProgressRewardIcon.raycastTarget = !flag2 && !isClaimed;
			}
			else
			{
				inProgressRewardIcon.gameObject.SetActive(value: true);
				if (hiddenRewardSprite != null)
				{
					inProgressRewardIcon.sprite = hiddenRewardSprite;
				}
				SimpleTooltipTrigger simpleTooltipTrigger4 = SetupTooltip(inProgressRewardIcon.gameObject, ach, flag);
				if (simpleTooltipTrigger4 != null)
				{
					simpleTooltipTrigger4.enabled = !flag2 && !isClaimed;
				}
				inProgressRewardIcon.raycastTarget = !flag2 && !isClaimed;
			}
		}
		if (rightCheckmark != null)
		{
			rightCheckmark.SetActive(flag2 || isClaimed);
			SimpleTooltipTrigger simpleTooltipTrigger5 = SetupTooltip(rightCheckmark, ach);
			if (simpleTooltipTrigger5 != null)
			{
				simpleTooltipTrigger5.enabled = isClaimed;
			}
		}
		if (progressFillImage != null)
		{
			progressFillImage.fillAmount = ((isCompleted || isClaimed) ? 1f : progress);
		}
		if (progressText != null)
		{
			if (isClaimed)
			{
				string localizedString3 = new LocalizedString("Skills", "#ui.achievements.claimed").GetLocalizedString();
				progressText.text = ((!string.IsNullOrEmpty(localizedString3) && !localizedString3.StartsWith("#")) ? localizedString3 : "Claimed!");
			}
			else if (isCompleted)
			{
				progressText.text = $"{ach.GetLocalizedRequirementType()} - {ach.requirementValue} / {ach.requirementValue}";
			}
			else if (flag)
			{
				int num = Mathf.RoundToInt(progress * (float)ach.requirementValue);
				progressText.text = $"{ach.GetLocalizedRequirementType()} - {num} / {ach.requirementValue}";
			}
			else
			{
				string localizedString4 = new LocalizedString("Skills", "#ui.achievements.mysterious_reward").GetLocalizedString();
				progressText.text = ((!string.IsNullOrEmpty(localizedString4) && !localizedString4.StartsWith("#")) ? localizedString4 : "???");
			}
		}
		if (claimButton != null)
		{
			claimButton.gameObject.SetActive(flag2);
			if (flag2)
			{
				claimButton.onClick.RemoveAllListeners();
				claimButton.onClick.AddListener(OnClaimClicked);
				SetupTooltip(claimButton.gameObject, ach);
			}
		}
		if (claimedBadge != null)
		{
			claimedBadge.SetActive(isClaimed);
		}
		if (selectButton != null)
		{
			selectButton.onClick.RemoveAllListeners();
			selectButton.onClick.AddListener(delegate
			{
				this.OnSelected?.Invoke(this);
			});
		}
		SetSelected(selected: false);
	}

	public void SetSelected(bool selected)
	{
		if (selectionHighlight != null)
		{
			selectionHighlight.SetActive(selected);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!_isHovered)
		{
			_isHovered = true;
			DOTween.Kill(base.transform);
			base.transform.localScale = _originalScale;
			base.transform.DOScale(_originalScale * hoverHoldScale, 0.15f).SetEase(Ease.OutBack);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_isHovered = false;
		DOTween.Kill(base.transform);
		base.transform.DOScale(_originalScale, hoverExitDuration).SetEase(Ease.OutQuad);
	}

	private void OnClaimClicked()
	{
		if (!(_ach == null))
		{
			AchievementManager.Instance?.ClaimAchievement(_ach.ID);
		}
	}

	private SimpleTooltipTrigger SetupTooltip(GameObject badgeObj, Achievement ach, bool reveal = true)
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
