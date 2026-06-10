using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class EndOfDayPanel : MonoBehaviour
{
	private struct FishGrowthData
	{
		public CaughtFish fishData;

		public int oldLevel;

		public int newLevel;

		public float xpPercent;
	}

	[Header("UI Structure")]
	public RectTransform mainPanelRect;

	public CanvasGroup mainCanvasGroup;

	public Image backgroundImage;

	[Header("Left Panel - Zone Progression")]
	public TMP_Text zoneNameText;

	public TMP_Text zoneLevelText;

	public TMP_Text zoneCurrentLevelText;

	public TMP_Text zoneIncomeText;

	public Image zoneXpBar;

	public SuperTextMesh zoneLevelUpBadge;

	[Header("Left Panel - Fish Mastery List")]
	public Transform masteryListParent;

	public GameObject fishMasteryRowPrefab;

	[Header("Right Panel - Receipt")]
	public ReceiptUI fishingReceiptUI;

	public TMP_Text totalGoldText;

	[Header("Buttons")]
	public Button startNewDayButton;

	public Button returnToMenuButton;

	public Button replayDayButton;

	private PlayerManager playerManager;

	private Inventory currentInventory;

	private double _finalTotalEarnings;

	private Coroutine _zoneXpRoutine;

	private const float MaxZoneXpAnimTime = 3f;

	public static bool IsVisible { get; private set; }

	private void Awake()
	{
		startNewDayButton.onClick.AddListener(delegate
		{
			playerManager.StartNewDay();
		});
		returnToMenuButton.onClick.AddListener(delegate
		{
			playerManager.ReturnToMenu();
		});
		replayDayButton.onClick.AddListener(delegate
		{
			playerManager.ReplayDay();
		});
		base.gameObject.SetActive(value: false);
		IsVisible = false;
		if ((bool)zoneLevelUpBadge)
		{
			zoneLevelUpBadge.gameObject.SetActive(value: false);
		}
	}

	private void OnDisable()
	{
		IsVisible = false;
	}

	public void ShowPanel(PlayerManager pm, Inventory inv)
	{
		playerManager = pm;
		currentInventory = inv;
		Transform parent = base.transform;
		while (parent.parent != null)
		{
			if (!parent.parent.gameObject.activeSelf)
			{
				parent.parent.gameObject.SetActive(value: true);
			}
			parent = parent.parent;
		}
		fishingReceiptUI.ClearForNewDay();
		base.gameObject.SetActive(value: true);
		IsVisible = true;
		try
		{
			CalculateAndSetupZoneUI(inv);
		}
		catch (Exception arg)
		{
			Debug.LogError($"[EndOfDayPanel] CalculateAndSetupZoneUI failed: {arg}");
		}
		List<FishGrowthData> list = new List<FishGrowthData>();
		try
		{
			list = GenerateFishReport(inv);
			SetupFishMasteryList(list);
		}
		catch (Exception arg2)
		{
			Debug.LogError($"[EndOfDayPanel] Fish report generation failed: {arg2}");
		}
		int currentLevel = GameManager.Instance.currentZone.currentLevel;
		StartCoroutine(AnimatePanel(list, currentLevel));
	}

	private void CalculateAndSetupZoneUI(Inventory inv)
	{
		LocalizedString localizedString = new LocalizedString("Skills", "#ui.text.level.short");
		ZoneData currentZone = GameManager.Instance.currentZone;
		zoneCurrentLevelText.text = localizedString.GetLocalizedString(currentZone.currentLevel);
		float castUsageFraction = GetCastUsageFraction();
		int num = inv.CalculateTotalXp(castUsageFraction);
		int currentLevel = currentZone.currentLevel;
		float totalPassiveIncome = GetTotalPassiveIncome(currentLevel);
		int currentXp = currentZone.currentXp;
		int xpForNextLevel = currentZone.GetXpForNextLevel();
		if (xpForNextLevel > 0)
		{
			zoneXpBar.fillAmount = (float)currentXp / (float)xpForNextLevel;
		}
		else
		{
			zoneXpBar.fillAmount = 0f;
		}
		int num2 = currentLevel;
		int num3 = currentXp + num;
		while (num3 >= xpForNextLevel)
		{
			num3 -= xpForNextLevel;
			num2++;
		}
		float totalPassiveIncome2 = GetTotalPassiveIncome(num2);
		string text = currentZone.zoneName.ToLowerInvariant().Replace(" ", ".");
		string text2 = "#ui.zone." + text + ".title";
		string localizedString2 = new LocalizedString("Skills", text2).GetLocalizedString();
		if (string.IsNullOrEmpty(localizedString2) || localizedString2.StartsWith("#"))
		{
			zoneNameText.text = currentZone.zoneName.ToUpper();
		}
		else
		{
			zoneNameText.text = localizedString2.ToUpper();
		}
		LayoutRebuilder.ForceRebuildLayoutImmediate(zoneNameText.transform.parent.transform as RectTransform);
		if (num2 > currentLevel)
		{
			zoneLevelText.text = $"{localizedString.GetLocalizedString(currentZone.currentLevel)} -> <color=#FFD700>{num2}</color>";
			LocalizedString localizedString3 = new LocalizedString("Skills", "#ui.unit.per_sec");
			LocalizedString localizedString4 = new LocalizedString("Skills", "#ui.zone.income");
			float income = totalPassiveIncome2 - totalPassiveIncome;
			string text3 = FormatPassiveIncome(totalPassiveIncome);
			zoneIncomeText.text = localizedString4.GetLocalizedString(text3) + localizedString3.GetLocalizedString() + " -> <color=#00FF00>" + FormatPassiveIncome(totalPassiveIncome2) + localizedString3.GetLocalizedString() + " (+" + FormatPassiveIncome(income) + ")</color>";
			LocalizedString localizedString5 = new LocalizedString("Skills", "#ui.text.up");
			zoneLevelUpBadge.text = "<c=rainbow><w> " + localizedString5.GetLocalizedString();
			if ((bool)zoneLevelUpBadge)
			{
				zoneLevelUpBadge.gameObject.SetActive(value: true);
			}
		}
		else
		{
			zoneLevelText.text = localizedString.GetLocalizedString(currentLevel + 1);
			string text4 = FormatPassiveIncome(totalPassiveIncome);
			LocalizedString localizedString6 = new LocalizedString("Skills", "#ui.unit.per_sec");
			LocalizedString localizedString7 = new LocalizedString("Skills", "#ui.zone.income");
			zoneIncomeText.text = localizedString7.GetLocalizedString(text4) + localizedString6.GetLocalizedString();
			if ((bool)zoneLevelUpBadge)
			{
				zoneLevelUpBadge.gameObject.SetActive(value: false);
			}
		}
	}

	private List<FishGrowthData> GenerateFishReport(Inventory inv)
	{
		List<FishGrowthData> list = new List<FishGrowthData>();
		foreach (IGrouping<string, CaughtFish> item in from f in inv.caughtFish
			group f by f.fishName)
		{
			CaughtFish caughtFish = item.First();
			int num = item.Count();
			float num2 = caughtFish.xpValue * num;
			if (PlayerStats.Instance != null)
			{
				num2 = (num2 + PlayerStats.Instance.FishCatchExperienceAdditive) * PlayerStats.Instance.FishCatchExperienceMultiplier;
			}
			FishLogManager.LevelPrediction levelPrediction = FishLogManager.Instance.PredictLevelUp(caughtFish.fishName, num2);
			list.Add(new FishGrowthData
			{
				fishData = caughtFish,
				oldLevel = FishLogManager.Instance.GetFishLevel(caughtFish.fishName),
				newLevel = levelPrediction.newLevel,
				xpPercent = levelPrediction.xpFillAmount
			});
		}
		return list;
	}

	private void SetupFishMasteryList(List<FishGrowthData> report)
	{
		foreach (Transform item in masteryListParent)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		foreach (FishGrowthData item2 in report)
		{
			FishMasteryRowUI component = UnityEngine.Object.Instantiate(fishMasteryRowPrefab, masteryListParent).GetComponent<FishMasteryRowUI>();
			if (component != null)
			{
				component.Setup(item2.fishData, item2.oldLevel, item2.newLevel, item2.xpPercent);
			}
		}
	}

	private IEnumerator AnimatePanel(List<FishGrowthData> fishReport, int startLevel)
	{
		mainPanelRect.localScale = Vector3.one * 0.9f;
		mainCanvasGroup.alpha = 0f;
		totalGoldText.text = "0 G";
		startNewDayButton.gameObject.SetActive(value: false);
		returnToMenuButton.gameObject.SetActive(value: false);
		replayDayButton.gameObject.SetActive(value: false);
		mainCanvasGroup.DOFade(1f, 0.3f);
		mainPanelRect.DOScale(1f, 0.4f).SetEase(Ease.OutBack);
		yield return new WaitForSeconds(0.4f);
		List<CaughtFish> caughtFish = currentInventory.caughtFish;
		float otherBonuses = ((PlayerStats.Instance != null) ? PlayerStats.Instance.SponsorShipBonus : 0f);
		_finalTotalEarnings = fishingReceiptUI.GenerateReceipt(caughtFish, otherBonuses);
		float displayProgress = 0f;
		SoundManager.PlaySound("Coins_Bag");
		DOTween.To(() => displayProgress, delegate(float x)
		{
			displayProgress = x;
		}, 1f, 1f).OnUpdate(delegate
		{
			double number = _finalTotalEarnings * (double)displayProgress;
			totalGoldText.text = CurrencyFormatter.FormatMoney(number) + " G";
		}).SetEase(Ease.OutCubic);
		GameManager.Instance.AddEarnings(_finalTotalEarnings, "EndOfDay");
		yield return new WaitForSeconds(0.6f);
		foreach (Transform item in masteryListParent)
		{
			FishMasteryRowUI component = item.GetComponent<FishMasteryRowUI>();
			if (component != null)
			{
				component.AnimateIn();
				SoundManager.PlaySound("SmallUI_Pop");
				yield return new WaitForSeconds(0.1f);
			}
		}
		yield return new WaitForSeconds(0.3f);
		ZoneData currentZone = GameManager.Instance.currentZone;
		float castUsageFraction = GetCastUsageFraction();
		int xpEarned = currentInventory.CalculateTotalXp(castUsageFraction);
		int currentXp = currentZone.currentXp;
		if (_zoneXpRoutine != null)
		{
			StopCoroutine(_zoneXpRoutine);
		}
		_zoneXpRoutine = StartCoroutine(AnimateZoneXpGain(startLevel, currentXp, xpEarned));
		yield return _zoneXpRoutine;
		GameManager.Instance.AddXpToCurrentZone(xpEarned);
		yield return new WaitForSeconds(0.2f);
		startNewDayButton.gameObject.SetActive(value: true);
		returnToMenuButton.gameObject.SetActive(value: true);
		replayDayButton.gameObject.SetActive(value: true);
		CanvasGroup canvasGroup = startNewDayButton.transform.parent.GetComponent<CanvasGroup>();
		if (canvasGroup == null)
		{
			canvasGroup = startNewDayButton.transform.parent.gameObject.AddComponent<CanvasGroup>();
		}
		canvasGroup.alpha = 0f;
		canvasGroup.DOFade(1f, 0.4f);
		LogAnalytics(Inventory.Instance.caughtFish);
	}

	private void LogAnalytics(List<CaughtFish> caughtFishData)
	{
		List<AnalyticsLogger.CaughtFishData> list = new List<AnalyticsLogger.CaughtFishData>();
		foreach (CaughtFish caughtFishDatum in caughtFishData)
		{
			list.Add(new AnalyticsLogger.CaughtFishData
			{
				Name = caughtFishDatum.fishName,
				Rarity = caughtFishDatum.rarityName,
				Level = FishLogManager.Instance.GetFishLevel(caughtFishDatum.fishName)
			});
		}
		ZoneData currentZone = GameManager.Instance.currentZone;
		AnalyticsLogger.Instance.LogEndOfDay(currentZone.zoneName, 0, list, _finalTotalEarnings, currentZone.currentLevel, GameManager.Instance.totalMoney);
	}

	private int GetXpForNextLevelAt(int level)
	{
		return Mathf.FloorToInt(100f * Mathf.Pow(1.2f, level - 1));
	}

	private IEnumerator AnimateZoneXpGain(int startLevel, int startXp, int xpEarned)
	{
		_ = GameManager.Instance.currentZone;
		LocalizedString LVLString = new LocalizedString("Skills", "#ui.text.level.short");
		zoneXpBar.DOKill();
		int animLevel = startLevel;
		int animXp = startXp;
		int remaining = xpEarned;
		zoneCurrentLevelText.text = LVLString.GetLocalizedString(animLevel);
		zoneLevelText.text = LVLString.GetLocalizedString(animLevel + 1);
		int req = GetXpForNextLevelAt(animLevel);
		zoneXpBar.fillAmount = ((req > 0) ? ((float)animXp / (float)req) : 0f);
		while (remaining > 0)
		{
			int b = req - animXp;
			int step = Mathf.Min(remaining, b);
			_ = zoneXpBar.fillAmount;
			float endValue = ((req > 0) ? ((float)(animXp + step) / (float)req) : 0f);
			float value = 3f * ((float)step / Mathf.Max(1f, xpEarned));
			value = Mathf.Clamp(value, 0.08f, 0.6f);
			zoneXpBar.DOFillAmount(endValue, value).SetEase(Ease.OutQuad);
			yield return new WaitForSeconds(value);
			animXp += step;
			remaining -= step;
			if (animXp >= req)
			{
				animLevel++;
				animXp = 0;
				zoneCurrentLevelText.text = LVLString.GetLocalizedString(animLevel);
				zoneLevelText.text = LVLString.GetLocalizedString(animLevel + 1);
				zoneLevelText.transform.DOPunchScale(Vector3.one * 0.15f, 0.25f, 8);
				SoundManager.PlaySound("Fish_LevelUp", 0.05f);
				zoneXpBar.DOKill();
				zoneXpBar.fillAmount = 0f;
				req = GetXpForNextLevelAt(animLevel);
			}
		}
		req = GetXpForNextLevelAt(animLevel);
		zoneXpBar.DOKill();
		zoneXpBar.fillAmount = ((req > 0) ? ((float)animXp / (float)req) : 0f);
	}

	private string FormatPassiveIncome(float income)
	{
		if (income >= 1000f)
		{
			return CurrencyFormatter.FormatMoney(income);
		}
		return income.ToString("F1");
	}

	private float GetTotalPassiveIncome(int currentZoneLevel)
	{
		float num = 0f;
		ZoneData currentZone = GameManager.Instance.currentZone;
		foreach (ZoneData allZone in GameManager.Instance.allZones)
		{
			if (allZone.isUnlocked)
			{
				num = ((!(allZone == currentZone)) ? (num + allZone.GetCurrentPassiveIncome()) : (num + allZone.GetCurrentPassiveIncome(currentZoneLevel)));
			}
		}
		if (PlayerStats.Instance != null)
		{
			num *= PlayerStats.Instance.PassiveIncomeMultiplier;
			num += PlayerStats.Instance.PassiveIncomeAdditive;
		}
		return num;
	}

	private float GetCastUsageFraction()
	{
		if (playerManager == null || PlayerStats.Instance == null)
		{
			return 0f;
		}
		int num = Mathf.Max(0, PlayerStats.Instance.MaxEnergy - playerManager.currentEnergy);
		int num2 = Mathf.Max(1, PlayerStats.Instance.EnergyCostPerCast);
		return Mathf.Clamp01((float)Mathf.Clamp(num / num2, 0, 4) / 4f);
	}
}
