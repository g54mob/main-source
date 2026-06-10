using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using UnityEngine.UI;

public class SkillTooltip : MonoBehaviour
{
	public TMP_Text titleText;

	public TMP_Text descriptionText;

	public TMP_Text statsText;

	public TMP_Text costText;

	public TMP_Text levelText;

	public Image iconImage;

	[Header("Configuration")]
	public Vector3 positionOffset = new Vector3(-1f, 2f, 0f);

	public Vector3 flippedPositionOffset = new Vector3(1f, -2f, 0f);

	public Color valueColor = Color.green;

	public Color baseValueColor = Color.grey;

	[Tooltip("Color for the Cost/Level text when the skill is Maxed")]
	public Color maxedColor = new Color(1f, 0.84f, 0f);

	public int maxLineCharacters = 35;

	private Skill currentSkillData;

	private Transform targetNode;

	private RectTransform rectTransform;

	private Canvas rootCanvas;

	private Camera uiCamera;

	[Header("Animation Settings")]
	public float showDuration = 0.3f;

	public float hideDuration = 0.2f;

	public float rotationAmount = -10f;

	private CanvasGroup canvasGroup;

	[Header("Shake Settings")]
	public float shakeDuration = 0.3f;

	public float shakeStrength = 30f;

	public int shakeVibrato = 20;

	public float shakeScale = 0.15f;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
		if (canvasGroup == null)
		{
			canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
		}
		if (base.transform.parent != null)
		{
			rootCanvas = base.transform.GetComponentInParent<Canvas>().rootCanvas;
		}
		if (rootCanvas != null)
		{
			if (rootCanvas.renderMode == RenderMode.ScreenSpaceCamera)
			{
				uiCamera = rootCanvas.worldCamera;
			}
			else if (rootCanvas.renderMode == RenderMode.WorldSpace)
			{
				uiCamera = Camera.main;
			}
		}
		else
		{
			uiCamera = Camera.main;
		}
	}

	private void Update()
	{
		if (base.gameObject.activeSelf && currentSkillData != null)
		{
			SetData(currentSkillData);
		}
	}

	private void LateUpdate()
	{
		if (targetNode != null)
		{
			base.transform.position = targetNode.position + positionOffset;
			if (IsClippingTop())
			{
				base.transform.position = targetNode.position + flippedPositionOffset;
			}
			AdjustPositionToScreenBounds();
		}
	}

	public void SetData(Skill skillData)
	{
		if (skillData == null)
		{
			return;
		}
		currentSkillData = skillData;
		int skillLevel = SkillManager.Instance.GetSkillLevel(currentSkillData.ID);
		bool flag = skillLevel >= currentSkillData.MaxLevel;
		titleText.text = currentSkillData.LocalizedName;
		iconImage.sprite = currentSkillData.icon;
		statsText.gameObject.SetActive(value: true);
		statsText.text = GetFormattedStats(currentSkillData, skillLevel, flag);
		statsText.gameObject.SetActive(!string.IsNullOrEmpty(statsText.text));
		if (levelText != null)
		{
			if (currentSkillData.MaxLevel > 1)
			{
				levelText.gameObject.SetActive(value: true);
				LocalizedString localizedString = new LocalizedString("Skills", "#ui.text.level");
				levelText.text = localizedString.GetLocalizedString(skillLevel, currentSkillData.MaxLevel);
			}
			else
			{
				levelText.gameObject.SetActive(value: false);
			}
		}
		if (string.IsNullOrEmpty(currentSkillData.LocalizedDescription))
		{
			descriptionText.text = "No description available.";
		}
		else
		{
			string text = currentSkillData.LocalizedDescription;
			string text2 = ColorUtility.ToHtmlStringRGB(valueColor);
			string text3 = currentSkillData.bonusValue.ToString("G", CultureInfo.InvariantCulture);
			string text4 = "[effectValue]";
			if (text.Contains(text4))
			{
				string oldValue = text4;
				string text5 = text3;
				int num = text.IndexOf(text4);
				if (num > 0 && text[num - 1] == '+')
				{
					oldValue = "+" + text4;
					text5 = "+" + text5;
				}
				string newValue = "<color=#" + text2 + ">" + text5 + "</color>";
				text = text.Replace(oldValue, newValue);
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num2 = 0;
			while (num2 < text.Length)
			{
				int num3 = text.IndexOf('[', num2);
				if (num3 == -1)
				{
					stringBuilder.Append(text.Substring(num2));
					break;
				}
				int num4 = text.IndexOf(']', num3);
				if (num4 == -1)
				{
					stringBuilder.Append(text.Substring(num2));
					break;
				}
				stringBuilder.Append(text.Substring(num2, num3 - num2));
				string text6 = text.Substring(num3 + 1, num4 - num3 - 1);
				stringBuilder.Append("<color=#" + text2 + ">" + text6 + "</color>");
				num2 = num4 + 1;
			}
			string text7 = InsertNewLines(stringBuilder.ToString(), maxLineCharacters);
			descriptionText.text = text7;
		}
		if (flag)
		{
			LocalizedString localizedString2 = new LocalizedString("Skills", "#ui.text.maxlevel");
			costText.text = localizedString2.GetLocalizedString();
			costText.color = maxedColor;
		}
		else
		{
			string text8 = CurrencyFormatter.FormatMoney(SkillManager.Instance.CalculateUpgradeCost(currentSkillData));
			LocalizedString localizedString3 = new LocalizedString("Skills", "#ui.text.cost");
			costText.text = localizedString3.GetLocalizedString(text8);
			costText.color = Color.white;
		}
	}

	private string InsertNewLines(string text, int lineLength)
	{
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}
		string[] array = text.Split(' ');
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		foreach (string text2 in array)
		{
			int length = Regex.Replace(text2, "<.*?>", "").Length;
			if (num > 0 && num + length + 1 > lineLength)
			{
				stringBuilder.Append("\n");
				num = 0;
			}
			if (num > 0)
			{
				stringBuilder.Append(" ");
				num++;
			}
			stringBuilder.Append(text2);
			num += length;
		}
		return stringBuilder.ToString();
	}

	public void Show(Transform nodeTransform)
	{
		targetNode = nodeTransform;
		base.transform.DOKill();
		canvasGroup.DOKill();
		SoundManager.PlaySound("Tooltip_Pop");
		base.transform.position = nodeTransform.position + positionOffset;
		base.gameObject.SetActive(value: true);
		canvasGroup.alpha = 0f;
		base.transform.rotation = Quaternion.Euler(0f, 0f, rotationAmount);
		canvasGroup.DOFade(1f, showDuration).SetEase(Ease.OutQuad);
		base.transform.DORotate(Vector3.zero, showDuration).SetEase(Ease.OutBack);
	}

	public void Shake()
	{
		base.transform.DOKill(complete: true);
		base.transform.rotation = Quaternion.identity;
		base.transform.localScale = Vector3.one;
		base.transform.DOPunchRotation(new Vector3(0f, 0f, shakeStrength), shakeDuration, shakeVibrato);
		base.transform.DOPunchScale(Vector3.one * shakeScale, shakeDuration, shakeVibrato);
	}

	private float SanitizeFloat(float val)
	{
		return (float)Math.Round(val, 4, MidpointRounding.AwayFromZero);
	}

	private string GetLocalizedStatName(SkillBonusType type)
	{
		string key = "#ui.stat." + type.ToString().Replace("_", ".");
		StringTableEntry stringTableEntry = LocalizationSettings.StringDatabase.GetTable("Skills")?.GetEntry(key);
		if (stringTableEntry != null && !string.IsNullOrEmpty(stringTableEntry.GetLocalizedString()))
		{
			return stringTableEntry.GetLocalizedString();
		}
		return GetStatNameFromType_Fallback(type);
	}

	private string GetStatNameFromType_Fallback(SkillBonusType type)
	{
		string input = type.ToString().Replace("add_", "").Replace("mult_", "");
		input = Regex.Replace(input, "(\\B[A-Z])", " $1");
		input = Regex.Replace(input, "_", " ");
		return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input);
	}

	private string GetLocalizedUnit(string unitKeySuffix)
	{
		string key = "#ui.unit." + unitKeySuffix;
		StringTableEntry stringTableEntry = LocalizationSettings.StringDatabase.GetTable("Skills")?.GetEntry(key);
		if (stringTableEntry != null && !string.IsNullOrEmpty(stringTableEntry.GetLocalizedString()))
		{
			return stringTableEntry.GetLocalizedString();
		}
		return unitKeySuffix switch
		{
			"gold" => "G", 
			"gold_per_sec" => " G/s", 
			"sec" => "s", 
			"per_sec" => "/s", 
			"xp" => " XP", 
			"percent" => "%", 
			_ => "", 
		};
	}

	private string GetFormattedStats(Skill skill, int currentLevel, bool isMaxed)
	{
		string statName = GetLocalizedStatName(skill.bonusType);
		string maxLabel = LocalizationSettings.StringDatabase.GetLocalizedString("Skills", "#ui.text.max", null, FallbackBehavior.UseProjectSettings);
		if (maxLabel.StartsWith("#") || string.IsNullOrEmpty(maxLabel))
		{
			maxLabel = "(Max)";
		}
		string localizedUnit = GetLocalizedUnit("sec");
		string localizedUnit2 = GetLocalizedUnit("per_sec");
		string unitPercent = GetLocalizedUnit("percent");
		string localizedUnit3 = GetLocalizedUnit("xp");
		string localizedUnit4 = GetLocalizedUnit("gold_per_sec");
		string colorHex = ColorUtility.ToHtmlStringRGB(valueColor);
		string baseColorHex = ColorUtility.ToHtmlStringRGB(baseValueColor);
		float bonusValue = skill.bonusValue;
		float num = 0f;
		if (GameManager.Instance != null && GameManager.Instance.allZones != null)
		{
			foreach (ZoneData allZone in GameManager.Instance.allZones)
			{
				num += allZone.GetCurrentPassiveIncome();
			}
		}
		switch (skill.bonusType)
		{
		case SkillBonusType.add_click_power:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.ReelInClickPower);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatCurrencyLine(num2, next, bonusValue);
		}
		case SkillBonusType.mult_click_power:
		{
			float num2 = PlayerStats.Instance.ClickPowerMultiplier;
			if (num2 < 0.01f)
			{
				num2 = 1f;
			}
			float next = CalculateNextValueForMultiplicative(num2, bonusValue, currentLevel);
			return FormatMultiplier(num2, next, bonusValue);
		}
		case SkillBonusType.add_reaction_time:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.ReactionTime);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatLine(num2, next, bonusValue, localizedUnit);
		}
		case SkillBonusType.add_crit_click_chance:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.CritClickChance);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatPercentage(num2, next, bonusValue);
		}
		case SkillBonusType.mult_clicks_required:
		{
			float num2 = PlayerStats.Instance.ClicksRequiredMultiplier;
			float next = CalculateNextValueForMultiplicative(num2, bonusValue, currentLevel);
			return FormatReduction(num2, next);
		}
		case SkillBonusType.add_crit_click_mult:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.CritClickMultiplier);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatLine(num2, next, bonusValue).Replace(": ", ": x").Replace(" (+", " (+");
		}
		case SkillBonusType.add_passive_clicks:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.PassiveClicks);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatLine(num2, next, bonusValue);
		}
		case SkillBonusType.add_passive_click_strength:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.PassiveClickStrength);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatCurrencyLine(num2, next, bonusValue);
		}
		case SkillBonusType.mult_passive_click_strength:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.PassiveClickStrength);
			float num16 = ((bonusValue >= 1f) ? bonusValue : (1f + bonusValue));
			float next = SanitizeFloat(Mathf.CeilToInt(num2 * num16));
			return FormatCurrencyLine(num2, next, next - num2);
		}
		case SkillBonusType.add_passive_click_speed:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.PassiveClickSpeed);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatLine(num2, next, bonusValue, localizedUnit2);
		}
		case SkillBonusType.add_auto_hook_chance:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.AutoHookChance);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatPercentage(num2, next, bonusValue);
		}
		case SkillBonusType.add_rare_fish_chance:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.RareFishChanceBonus);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatPercentage(num2, next, bonusValue, "F2");
		}
		case SkillBonusType.mult_rare_fish_chance:
		{
			float num2 = PlayerStats.Instance.RareFishChanceMultiplier;
			float next = CalculateNextValueForMultiplicative(num2, bonusValue, currentLevel);
			return FormatMultiplier(num2, next, bonusValue, "F3");
		}
		case SkillBonusType.mult_fish_value:
		{
			float num2 = PlayerStats.Instance.FishValueMultiplier;
			float next = CalculateNextValueForMultiplicative(num2, bonusValue, currentLevel);
			return FormatMultiplier(num2, next, bonusValue);
		}
		case SkillBonusType.mult_pond_unlock_cost:
		{
			float num2 = PlayerStats.Instance.PondUnlockCostMultiplier;
			float next = CalculateNextValueForMultiplicative(num2, bonusValue, currentLevel);
			return FormatReduction(num2, next);
		}
		case SkillBonusType.mult_skill_cost:
		{
			float num2 = PlayerStats.Instance.SkillCostMultiplier;
			float next = CalculateNextValueForMultiplicative(num2, bonusValue, currentLevel);
			return FormatReduction(num2, next);
		}
		case SkillBonusType.mult_all_costs:
		{
			float num2 = PlayerStats.Instance.AllCostsMultiplier;
			float next = CalculateNextValueForMultiplicative(num2, bonusValue, currentLevel);
			return FormatReduction(num2, next);
		}
		case SkillBonusType.add_sponsorship_bonus:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.SponsorshipAdditive);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatPercentage(num2, next, bonusValue);
		}
		case SkillBonusType.mult_sponsorship_bonus:
		{
			float num2 = PlayerStats.Instance.SponsorshipMultiplier;
			float next = CalculateNextValueForMultiplicative(num2, bonusValue, currentLevel);
			return FormatMultiplier(num2, next, bonusValue);
		}
		case SkillBonusType.add_passive_income:
		{
			float passiveIncomeMultiplier2 = PlayerStats.Instance.PassiveIncomeMultiplier;
			float passiveIncomeAdditive2 = PlayerStats.Instance.PassiveIncomeAdditive;
			float curr = num * passiveIncomeMultiplier2 + passiveIncomeAdditive2;
			float next2 = num * passiveIncomeMultiplier2 + SanitizeFloat(passiveIncomeAdditive2 + bonusValue);
			return FormatCurrencyLine(curr, next2, bonusValue, localizedUnit4);
		}
		case SkillBonusType.mult_passive_income:
		{
			float passiveIncomeMultiplier = PlayerStats.Instance.PassiveIncomeMultiplier;
			float passiveIncomeAdditive = PlayerStats.Instance.PassiveIncomeAdditive;
			float num7 = num * passiveIncomeMultiplier + passiveIncomeAdditive;
			float num8 = CalculateNextValueForMultiplicative(passiveIncomeMultiplier, bonusValue, currentLevel);
			float num9 = num * num8 + passiveIncomeAdditive;
			return FormatCurrencyLine(num7, num9, num9 - num7, localizedUnit4);
		}
		case SkillBonusType.add_fish_catch_experience:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.FishCatchExperienceAdditive);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatLine(num2, next, bonusValue, localizedUnit3);
		}
		case SkillBonusType.mult_fish_catch_experience:
		{
			float num2 = PlayerStats.Instance.FishCatchExperienceMultiplier;
			float next = CalculateNextValueForMultiplicative(num2, bonusValue, currentLevel);
			return FormatMultiplier(num2, next, bonusValue);
		}
		case SkillBonusType.add_pond_experience:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.PondExperienceAdditive);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatLine(num2, next, bonusValue, localizedUnit3);
		}
		case SkillBonusType.mult_pond_experience:
		{
			float num2 = PlayerStats.Instance.PondExperienceMultiplier;
			float next = CalculateNextValueForMultiplicative(num2, bonusValue, currentLevel);
			return FormatMultiplier(num2, next, bonusValue);
		}
		case SkillBonusType.add_time_refund_on_perfect_catch:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.PerfectCatchTimeRefund);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatLine(num2, next, bonusValue, localizedUnit);
		}
		case SkillBonusType.mult_fish_value_based_on_zone_level:
		{
			float num17 = bonusValue;
			float num18 = num17 * 100f;
			int num19 = ((!(GameManager.Instance.currentZone != null)) ? 1 : GameManager.Instance.currentZone.currentLevel);
			float num20 = 1f + PlayerStats.Instance.FishValueZoneSynergyBonus * (float)num19;
			float num21 = 1f + (PlayerStats.Instance.FishValueZoneSynergyBonus + num17) * (float)num19;
			string localizedString3 = new LocalizedString("Skills", "#ui.text.zone.lvl").GetLocalizedString();
			string localizedString4 = new LocalizedString("Skills", "#ui.text.total").GetLocalizedString();
			if (isMaxed)
			{
				return $"{statName}: <color=#{colorHex}>+{num18:F0}{unitPercent}</color> / {localizedString3} ({localizedString4}: <color=#{colorHex}>x{num20:F2}</color>)";
			}
			return $"{statName}: <color=#{baseColorHex}>+{num18:F0}{unitPercent}</color> / {localizedString3} (x{num20:F2} > x{num21:F2})";
		}
		case SkillBonusType.mult_rare_chance_based_on_zone_level:
		{
			float num11 = bonusValue;
			float num12 = num11 * 100f;
			int num13 = ((!(GameManager.Instance.currentZone != null)) ? 1 : GameManager.Instance.currentZone.currentLevel);
			float num14 = 1f + PlayerStats.Instance.RareChanceZoneSynergyBonus * (float)num13;
			float num15 = 1f + (PlayerStats.Instance.RareChanceZoneSynergyBonus + num11) * (float)num13;
			string localizedString = new LocalizedString("Skills", "#ui.text.zone.lvl").GetLocalizedString();
			string localizedString2 = new LocalizedString("Skills", "#ui.text.total").GetLocalizedString();
			if (isMaxed)
			{
				return $"{statName}: <color=#{colorHex}>+{num12:F0}{unitPercent}</color> / {localizedString} ({localizedString2}: <color=#{colorHex}>x{num14:F2}</color>)";
			}
			return $"{statName}: <color=#{baseColorHex}>+{num12:F0}{unitPercent}</color> / {localizedString} (x{num14:F2} > x{num15:F2})";
		}
		case SkillBonusType.mult_experience_gain:
		{
			float num2 = PlayerStats.Instance.ExperienceGainMultiplier;
			float next = CalculateNextValueForMultiplicative(num2, bonusValue, currentLevel);
			return FormatMultiplier(num2, next, bonusValue);
		}
		case SkillBonusType.add_faster_catching:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.FasterCatchingBonus);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatLine(num2, next, bonusValue, localizedUnit);
		}
		case SkillBonusType.add_double_catch_chance:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.DoubleCatchChance);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatPercentage(num2, next, bonusValue, "F1");
		}
		case SkillBonusType.add_triple_catch_chance:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.TripleCatchChance);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatPercentage(num2, next, bonusValue);
		}
		case SkillBonusType.add_tracker_pulse_speed:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.TrackerPulseSpeedBonus * 100f);
			float next = SanitizeFloat((PlayerStats.Instance.TrackerPulseSpeedBonus + bonusValue) * 100f);
			float bonus2 = SanitizeFloat(bonusValue * 100f);
			return FormatPercentage(num2, next, bonus2);
		}
		case SkillBonusType.add_perfect_catch_time:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.PerfectCatchTimeWindow - PlayerStats.Instance.basePerfectCatchTime);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatLine(num2, next, bonusValue, localizedUnit);
		}
		case SkillBonusType.add_clicking_time:
		case SkillBonusType.add_catch_time:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.ReelInTimeLimit);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatLine(num2, next, bonusValue, localizedUnit);
		}
		case SkillBonusType.add_hold_click_rate:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.HoldClickRate);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatLine(num2, next, bonusValue, localizedUnit2);
		}
		case SkillBonusType.add_time_per_crit:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.TimePerCrit);
			float next = SanitizeFloat(num2 + bonusValue);
			return FormatLine(num2, next, bonusValue, localizedUnit);
		}
		case SkillBonusType.add_perfect_start_progress:
		{
			float num2 = SanitizeFloat(PlayerStats.Instance.PerfectStartProgressBonus * 100f);
			float next = SanitizeFloat((PlayerStats.Instance.PerfectStartProgressBonus + bonusValue) * 100f);
			float bonus = SanitizeFloat(bonusValue * 100f);
			return FormatPercentage(num2, next, bonus, "F1");
		}
		case SkillBonusType.enable_tracker_tier2:
		case SkillBonusType.enable_tracker_tier3:
		case SkillBonusType.add_fish_tracker_tier:
		{
			int fishTrackerTier = PlayerStats.Instance.FishTrackerTier;
			int num10 = fishTrackerTier;
			if (skill.bonusType == SkillBonusType.add_fish_tracker_tier)
			{
				num10 += (int)bonusValue;
			}
			else if (skill.bonusType == SkillBonusType.enable_tracker_tier2)
			{
				num10 = 2;
			}
			else if (skill.bonusType == SkillBonusType.enable_tracker_tier3)
			{
				num10 = 3;
			}
			string trackerTierName = GetTrackerTierName(fishTrackerTier);
			string trackerTierName2 = GetTrackerTierName(num10);
			if (isMaxed || num10 <= fishTrackerTier)
			{
				return statName + ": <color=#" + colorHex + ">" + trackerTierName + "</color> (" + maxLabel + ")";
			}
			return statName + ": <color=#" + baseColorHex + ">" + trackerTierName + "</color> -> <color=#" + colorHex + ">" + trackerTierName2 + "</color>";
		}
		case SkillBonusType.add_bobber_synergy:
		{
			float num3 = SanitizeFloat(PlayerStats.Instance.AutoHookChance);
			float num4 = SanitizeFloat(num3 + bonusValue);
			float num5 = SanitizeFloat(PlayerStats.Instance.DoubleCatchChance);
			float num6 = SanitizeFloat(num5 + bonusValue);
			string localizedStatName = GetLocalizedStatName(SkillBonusType.add_auto_hook_chance);
			string localizedStatName2 = GetLocalizedStatName(SkillBonusType.add_double_catch_chance);
			string text;
			string text2;
			if (isMaxed)
			{
				text = $"{localizedStatName}: <color=#{colorHex}>{num3:F1}{unitPercent}</color> ({maxLabel})";
				text2 = $"{localizedStatName2}: <color=#{colorHex}>{num5:F1}{unitPercent}</color> ({maxLabel})";
			}
			else
			{
				text = $"{localizedStatName}: <color=#{baseColorHex}>{num3:F1}{unitPercent}</color> -> <color=#{colorHex}>{num4:F1}{unitPercent}</color> (+{bonusValue:F1}{unitPercent})";
				text2 = $"{localizedStatName2}: <color=#{baseColorHex}>{num5:F1}{unitPercent}</color> -> <color=#{colorHex}>{num6:F1}{unitPercent}</color> (+{bonusValue:F1}{unitPercent})";
			}
			return text + "\n" + text2;
		}
		case SkillBonusType.enable_frenzy_mode:
			if (PlayerStats.Instance.IsFrenzyModeEnabled || isMaxed)
			{
				return statName + ": <color=#" + colorHex + ">Enabled</color> (" + maxLabel + ")";
			}
			return statName + ": <color=#" + baseColorHex + ">Disabled</color> -> <color=#" + colorHex + ">Enabled</color>";
		case SkillBonusType.enable_hold_to_reel:
			if (PlayerStats.Instance.IsHoldToReelEnabled || isMaxed)
			{
				return statName + ": <color=#" + colorHex + ">Enabled</color> (" + maxLabel + ")";
			}
			return statName + ": <color=#" + baseColorHex + ">Disabled</color> -> <color=#" + colorHex + ">Enabled</color>";
		case SkillBonusType.init_skill:
			return "";
		default:
			statsText.gameObject.SetActive(value: false);
			descriptionText.text = skill.description.Replace("[effectValue]", $"<color=#{colorHex}>{skill.bonusValue}</color>");
			return "";
		}
		string FormatCurrencyLine(float num22, float num23, float num24, string unit = "")
		{
			string text3 = CurrencyFormatter.FormatMoney(num22);
			string text4 = CurrencyFormatter.FormatMoney(num23);
			string text5 = CurrencyFormatter.FormatMoney(num24);
			if (isMaxed)
			{
				return statName + ": <color=#" + colorHex + ">" + text3 + unit + "</color> (" + maxLabel + ")";
			}
			return statName + ": <color=#" + baseColorHex + ">" + text3 + unit + "</color> -> <color=#" + colorHex + ">" + text4 + unit + "</color> (+" + text5 + unit + ")";
		}
		string FormatLine(float num22, float num23, float num24, string unit = "", string format = "F2")
		{
			if (isMaxed)
			{
				return statName + ": <color=#" + colorHex + ">" + num22.ToString(format) + unit + "</color> (" + maxLabel + ")";
			}
			return statName + ": <color=#" + baseColorHex + ">" + num22.ToString(format) + unit + "</color> -> <color=#" + colorHex + ">" + num23.ToString(format) + unit + "</color> (+" + num24.ToString(format) + unit + ")";
		}
		string FormatMultiplier(float num22, float num23, float num24, string format = "F2")
		{
			if (isMaxed)
			{
				return statName + ": <color=#" + colorHex + ">x" + num22.ToString(format) + "</color> (" + maxLabel + ")";
			}
			return statName + ": <color=#" + baseColorHex + ">x" + num22.ToString(format) + "</color> -> <color=#" + colorHex + ">x" + num23.ToString(format) + "</color> (x" + num24.ToString(format) + ")";
		}
		string FormatPercentage(float num22, float num23, float num24, string format = "F0")
		{
			if (isMaxed)
			{
				return statName + ": <color=#" + colorHex + ">" + num22.ToString(format) + unitPercent + "</color> (" + maxLabel + ")";
			}
			return statName + ": <color=#" + baseColorHex + ">" + num22.ToString(format) + unitPercent + "</color> -> <color=#" + colorHex + ">" + num23.ToString(format) + unitPercent + "</color> (+" + num24.ToString(format) + unitPercent + ")";
		}
		string FormatReduction(float currMult, float nextMult)
		{
			float num22 = SanitizeFloat((1f - currMult) * 100f);
			float num23 = SanitizeFloat((1f - nextMult) * 100f);
			float f = SanitizeFloat(num23 - num22);
			string text3 = ((Mathf.Abs(f) < 1f) ? "F1" : "F0");
			if (isMaxed)
			{
				return statName + ": <color=#" + colorHex + ">-" + num22.ToString(text3) + unitPercent + "</color> (" + maxLabel + ")";
			}
			return statName + ": <color=#" + baseColorHex + ">-" + num22.ToString(text3) + unitPercent + "</color> -> <color=#" + colorHex + ">-" + num23.ToString(text3) + unitPercent + "</color> (-" + f.ToString(text3) + unitPercent + ")";
		}
	}

	private string GetStatNameFromType(SkillBonusType type)
	{
		string text = type.ToString();
		text = text.Replace("add_", "").Replace("mult_", "");
		text = Regex.Replace(text, "(\\B[A-Z])", " $1");
		text = Regex.Replace(text, "_", " ");
		return new CultureInfo("en-US", useUserOverride: false).TextInfo.ToTitleCase(text);
	}

	private float CalculateNextValueForMultiplicative(float currentValue, float bonusValue, int currentLevel)
	{
		float num = bonusValue - 1f;
		return currentValue + num;
	}

	public void Hide()
	{
		base.transform.DOKill();
		canvasGroup.DOKill();
		canvasGroup.DOFade(0f, hideDuration).SetEase(Ease.InQuad).OnComplete(delegate
		{
			base.gameObject.SetActive(value: false);
			currentSkillData = null;
			targetNode = null;
		});
	}

	private void GetStableWorldCorners(Vector3[] corners)
	{
		Vector3 localScale = base.transform.localScale;
		Quaternion localRotation = base.transform.localRotation;
		base.transform.localScale = Vector3.one;
		base.transform.localRotation = Quaternion.identity;
		rectTransform.GetWorldCorners(corners);
		base.transform.localScale = localScale;
		base.transform.localRotation = localRotation;
	}

	private void AdjustPositionToScreenBounds()
	{
		if (rootCanvas == null || this.rectTransform == null)
		{
			return;
		}
		RectTransform rectTransform = rootCanvas.transform as RectTransform;
		if (rectTransform == null)
		{
			return;
		}
		Vector3[] array = new Vector3[4];
		GetStableWorldCorners(array);
		Vector3 vector = new Vector3(float.MaxValue, float.MaxValue);
		Vector3 vector2 = new Vector3(float.MinValue, float.MinValue);
		for (int i = 0; i < 4; i++)
		{
			Vector3 vector3 = RectTransformUtility.WorldToScreenPoint(uiCamera, array[i]);
			vector.x = Mathf.Min(vector.x, vector3.x);
			vector.y = Mathf.Min(vector.y, vector3.y);
			vector2.x = Mathf.Max(vector2.x, vector3.x);
			vector2.y = Mathf.Max(vector2.y, vector3.y);
		}
		Vector3 zero = Vector3.zero;
		if (vector2.x > (float)Screen.width)
		{
			zero.x = (float)Screen.width - vector2.x;
		}
		if (vector.x < 0f)
		{
			zero.x = 0f - vector.x;
		}
		if (vector.y < 0f)
		{
			zero.y = 0f - vector.y;
		}
		if (!(zero == Vector3.zero))
		{
			Vector3 vector4 = (Vector3)RectTransformUtility.WorldToScreenPoint(uiCamera, base.transform.position) + zero;
			if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, vector4, uiCamera, out var worldPoint))
			{
				base.transform.position = worldPoint;
			}
		}
	}

	private bool IsClippingTop()
	{
		if (rectTransform == null)
		{
			return false;
		}
		Vector3[] array = new Vector3[4];
		GetStableWorldCorners(array);
		for (int i = 0; i < 4; i++)
		{
			if (((Vector3)RectTransformUtility.WorldToScreenPoint(uiCamera, array[i])).y > (float)Screen.height)
			{
				return true;
			}
		}
		return false;
	}

	private string GetTrackerTierName(int tier)
	{
		string text = ((tier >= 0 && tier <= 3) ? $"#ui.stat.tracker.tier.{tier}" : "#ui.text.max");
		string localizedString = new LocalizedString("Skills", text).GetLocalizedString();
		if (!string.IsNullOrEmpty(localizedString) && !localizedString.StartsWith("#"))
		{
			return localizedString;
		}
		return tier switch
		{
			0 => "None", 
			1 => "Discovery (Presence)", 
			2 => "Advanced (Habitats)", 
			3 => "Expert (Hotspots)", 
			_ => "Max", 
		};
	}
}
