using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class FishCaughtAlert : MonoBehaviour
{
	[Header("UI References")]
	public SuperTextMesh fishNameText;

	public SuperTextMesh fishNameTextShadow;

	public Image fishIconImage;

	public OutlineConfig outlineConfig;

	private Material instancedIconMaterial;

	[Header("Rarity References")]
	public SuperTextMesh rarityText;

	public Transform rarityBadgeTransform;

	public Transform starRatingParent;

	public Image xpBarFillImage;

	public Image xpBarBackgroundImage;

	public TMP_Text levelText;

	public TMP_Text goldValueText;

	public RectTransform mainPanel;

	public Color currencySymbolColor = Color.yellow;

	public TMP_Text perfectCatchText;

	[Header("Double Catch FX")]
	public Transform doubleCatchText;

	public Transform doubleCatchGlow;

	public TMP_Text catchBonusText;

	[Tooltip("Angle in degrees for the text (e.g. 15 or 45)")]
	public float textTiltAngle = 15f;

	public TMP_Text currentLevelXpBarText;

	public TMP_Text nextLevelXpBarText;

	[Header("Level Up UI")]
	[Tooltip("Prefab for each odds text entry (e.g. '+ Uncommon')")]
	public GameObject rarityBonusTextPrefab;

	[Tooltip("Parent object with a Horizontal Layout Group")]
	public Transform rarityTextParent;

	[Header("Level Up Stamp")]
	[Tooltip("The 'LEVEL UP!' text/image stamp shown over the fish portrait")]
	public Transform levelUpStamp;

	public TMP_Text levelUpStampText;

	[Tooltip("Optional background sprite/glow for the Level Up stamp that will spin")]
	public Transform levelUpStampGlow;

	[Tooltip("CanvasGroup to optionally fade out the stamp. Optional.")]
	public CanvasGroup levelUpStampCanvasGroup;

	[Header("Animation Settings")]
	public float slideDuration = 0.35f;

	public float displayDuration = 4f;

	public float finalCatchDisplayDuration = 0.5f;

	public float countUpDuration = 1f;

	public float starAnimDelay = 0.08f;

	private Vector2 initialEditorPosition;

	private double currentBonusGold;

	[Header("Rarity Delta Symbol Colors")]
	public Color increaseSymbolColor = new Color(0.25f, 1f, 0.25f);

	public Color decreaseSymbolColor = new Color(1f, 0.25f, 0.25f);

	public static FishCaughtAlert Instance { get; private set; }

	public static bool IsVisible { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		initialEditorPosition = mainPanel.anchoredPosition;
		if (fishIconImage != null && fishIconImage.material != null)
		{
			instancedIconMaterial = new Material(fishIconImage.material);
			fishIconImage.material = instancedIconMaterial;
		}
		if (rarityTextParent != null)
		{
			rarityTextParent.gameObject.SetActive(value: false);
		}
		if (levelUpStamp != null)
		{
			levelUpStamp.gameObject.SetActive(value: false);
		}
		if (levelUpStampGlow != null)
		{
			levelUpStampGlow.gameObject.SetActive(value: false);
		}
		if (perfectCatchText != null)
		{
			perfectCatchText.gameObject.SetActive(value: false);
		}
		if (doubleCatchText != null)
		{
			doubleCatchText.gameObject.SetActive(value: false);
		}
		if (doubleCatchGlow != null)
		{
			doubleCatchGlow.gameObject.SetActive(value: false);
		}
		base.gameObject.SetActive(value: false);
	}

	public static void TriggerAlert(CaughtFish fish, int fishLevel, float oldXp, int xpToNextLevel, bool isFinalCatch)
	{
		if (Instance != null)
		{
			IsVisible = true;
			Instance.gameObject.SetActive(value: true);
			Instance.ShowAlert(fish, fishLevel, oldXp, xpToNextLevel, isFinalCatch);
		}
	}

	public void ShowAlert(CaughtFish fish, int fishLevel, float oldXp, int xpToNextLevel, bool isFinalCatch)
	{
		IsVisible = true;
		StopAllCoroutines();
		mainPanel.DOKill(complete: true);
		if (doubleCatchGlow != null)
		{
			doubleCatchGlow.DOKill();
		}
		if (doubleCatchText != null)
		{
			doubleCatchText.DOKill();
		}
		if (levelUpStamp != null)
		{
			levelUpStamp.DOKill();
		}
		if (levelUpStampGlow != null)
		{
			levelUpStampGlow.DOKill();
		}
		base.gameObject.SetActive(value: true);
		if (rarityTextParent != null)
		{
			rarityTextParent.gameObject.SetActive(value: false);
			foreach (Transform item in rarityTextParent)
			{
				if (item.name != "BackGround")
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
			}
		}
		Vector2 targetOnScreenPos = initialEditorPosition;
		Vector2 vector = new Vector2(targetOnScreenPos.x - mainPanel.rect.width - 50f, targetOnScreenPos.y);
		mainPanel.anchoredPosition = vector;
		levelText.transform.localScale = Vector3.one;
		fishIconImage.transform.localScale = Vector3.zero;
		if (rarityBadgeTransform != null)
		{
			rarityBadgeTransform.localScale = Vector3.zero;
		}
		if (levelUpStamp != null)
		{
			levelUpStamp.gameObject.SetActive(value: false);
			if (levelUpStampCanvasGroup != null)
			{
				levelUpStampCanvasGroup.alpha = 1f;
			}
		}
		if (levelUpStampGlow != null)
		{
			levelUpStampGlow.gameObject.SetActive(value: false);
		}
		foreach (Transform item2 in starRatingParent)
		{
			item2.gameObject.SetActive(value: false);
			item2.localScale = Vector3.zero;
		}
		fishNameText.text = "<w=once>" + fish.fish.LocalizedName;
		fishNameTextShadow.text = "<w=once>" + fish.fish.LocalizedName;
		if (fish.isDoubleCatch || fish.isTripleCatch)
		{
			if (doubleCatchText != null)
			{
				doubleCatchText.gameObject.SetActive(value: true);
				doubleCatchText.transform.localScale = Vector3.zero;
				doubleCatchText.transform.localRotation = Quaternion.Euler(0f, 0f, 0f - textTiltAngle);
			}
			if (doubleCatchGlow != null)
			{
				doubleCatchGlow.gameObject.SetActive(value: true);
				doubleCatchGlow.localScale = Vector3.zero;
				doubleCatchGlow.localRotation = Quaternion.identity;
			}
			LocalizedString localizedString = new LocalizedString("Skills", "#ui.text.triple.catch");
			LocalizedString localizedString2 = new LocalizedString("Skills", "#ui.text.double.catch");
			if (fish.isTripleCatch && catchBonusText != null)
			{
				catchBonusText.text = localizedString.GetLocalizedString();
			}
			else if (fish.isDoubleCatch && catchBonusText != null)
			{
				catchBonusText.text = localizedString2.GetLocalizedString();
			}
		}
		else
		{
			if (doubleCatchText != null)
			{
				doubleCatchText.gameObject.SetActive(value: false);
			}
			if (doubleCatchGlow != null)
			{
				doubleCatchGlow.gameObject.SetActive(value: false);
			}
		}
		fishIconImage.sprite = fish.artwork;
		if (outlineConfig != null && instancedIconMaterial != null)
		{
			instancedIconMaterial.SetColor("_Color", outlineConfig.GetColor(fish.rarityData.rarity));
			instancedIconMaterial.SetFloat("_Thickness", outlineConfig.GetLineThickness(fish.rarityData.rarity));
		}
		rarityText.text = "<c=" + fish.rarityName + "><j>" + fish.rarityData.rarity.GetLocalizedText();
		LocalizedString localizedString3 = new LocalizedString("Skills", "#ui.text.level.simple");
		levelText.text = localizedString3.GetLocalizedString(fishLevel);
		float fillAmount = oldXp / (float)xpToNextLevel;
		xpBarFillImage.fillAmount = fillAmount;
		string text = ColorUtility.ToHtmlStringRGB(currencySymbolColor);
		double num = PlayerStats.Instance.FishValueMultiplier;
		double num2 = PlayerStats.Instance.GetFishValueZoneSynergyMultiplier(GameManager.Instance.currentZone.currentLevel);
		double num3 = Math.Round(fish.value * num * num2);
		if (fish.isPerfectCatch)
		{
			currentBonusGold = Math.Round(num3 * (double)(PlayerStats.Instance.perfectCatchBonusMultiplier - 1f));
			LocalizedString localizedString4 = new LocalizedString("Skills", "#ui.text.value");
			LocalizedString localizedString5 = new LocalizedString("Skills", "#ui.unit.gold");
			goldValueText.text = localizedString4.GetLocalizedString() + ": 0<color=#" + text + "> " + localizedString5.GetLocalizedString() + "</color> (+0<color=#" + text + "> " + localizedString5.GetLocalizedString() + "</color>)";
			if (perfectCatchText != null)
			{
				perfectCatchText.gameObject.SetActive(value: true);
				LocalizedString localizedString6 = new LocalizedString("Skills", "#ui.text.perfect.catch");
				perfectCatchText.text = localizedString6.GetLocalizedString();
				perfectCatchText.transform.localScale = Vector3.zero;
				perfectCatchText.transform.localRotation = Quaternion.identity;
			}
		}
		else
		{
			currentBonusGold = 0.0;
			LocalizedString localizedString7 = new LocalizedString("Skills", "#ui.text.value");
			LocalizedString localizedString8 = new LocalizedString("Skills", "#ui.unit.gold");
			goldValueText.text = localizedString7.GetLocalizedString() + ": 0<color=#" + text + "> " + localizedString8.GetLocalizedString() + "</color> ";
			if (perfectCatchText != null)
			{
				perfectCatchText.gameObject.SetActive(value: false);
			}
		}
		if (fish.isDoubleCatch)
		{
			currentBonusGold *= 2.0;
		}
		float num4 = (isFinalCatch ? finalCatchDisplayDuration : displayDuration);
		StartCoroutine(AnimateAlert(fish, fishLevel, oldXp, xpToNextLevel, targetOnScreenPos, vector, num4, isFinalCatch));
	}

	private IEnumerator AnimateAlert(CaughtFish fish, float initialLevel, float initialXp, int xpToNextLevel, Vector2 targetOnScreenPos, Vector2 targetOffScreenPos, float displayDuration, bool isFinalCatch)
	{
		SoundManager.PlaySound("Slide");
		mainPanel.DOAnchorPos(targetOnScreenPos, 0.35f).SetEase(Ease.OutBack);
		LocalizedString levelLoc = new LocalizedString("Skills", "#ui.text.level.short");
		if (currentLevelXpBarText != null)
		{
			currentLevelXpBarText.text = levelLoc.GetLocalizedString(initialLevel);
		}
		if (nextLevelXpBarText != null)
		{
			nextLevelXpBarText.text = levelLoc.GetLocalizedString(initialLevel + 1f);
		}
		if (!isFinalCatch)
		{
			yield return new WaitForSeconds(0.2f);
		}
		else
		{
			yield return new WaitForSeconds(0.05f);
		}
		fishIconImage.transform.DOScale(1f, 0.35f).SetEase(Ease.OutBack);
		if ((fish.isDoubleCatch || fish.isTripleCatch) && doubleCatchText != null)
		{
			SoundManager.PlaySound("LevelUp");
			if (doubleCatchGlow != null)
			{
				doubleCatchGlow.localScale = Vector3.zero;
				doubleCatchGlow.DOScale(1.2f, 0.5f).SetEase(Ease.OutBack);
				doubleCatchGlow.DORotate(new Vector3(0f, 0f, -360f), 20f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
			}
			doubleCatchText.DOScale(1f, 0.5f).SetEase(Ease.OutBack).OnComplete(delegate
			{
				doubleCatchText.DOScale(1.1f, 0.6f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
			});
		}
		if (perfectCatchText != null)
		{
			perfectCatchText.DOKill();
			if (fish.isPerfectCatch)
			{
				yield return new WaitForSeconds(0.1f);
				perfectCatchText.gameObject.SetActive(value: true);
				LocalizedString localizedString = new LocalizedString("Skills", "#ui.text.perfect.catch");
				perfectCatchText.text = localizedString.GetLocalizedString();
				Color color = perfectCatchText.color;
				color.a = 1f;
				perfectCatchText.color = color;
				perfectCatchText.alpha = 1f;
				SoundManager.PlaySound("LevelUp");
				perfectCatchText.transform.DOScale(1f, 0.35f).SetEase(Ease.OutBack);
				perfectCatchText.transform.DOPunchRotation(new Vector3(0f, 0f, -15f), 0.35f);
			}
			else
			{
				perfectCatchText.alpha = 0f;
				perfectCatchText.gameObject.SetActive(value: false);
			}
		}
		int rarityValue = (int)(fish.rarityData.rarity + 1);
		for (int i = 0; i < rarityValue; i++)
		{
			Transform child = starRatingParent.GetChild(i);
			child.gameObject.SetActive(value: true);
			SoundManager.PlaySound("SmallChime", 0.1f + (float)i * 0.03f, 0.8f + (float)i * 0.04f);
			child.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
			yield return new WaitForSeconds(starAnimDelay);
		}
		if (rarityBadgeTransform != null)
		{
			rarityBadgeTransform.DOScale(1f, 0.35f).SetEase(Ease.OutBack);
		}
		double targetGold = 0.0;
		double targetBonusGold = 0.0;
		string currencyColorHex = ColorUtility.ToHtmlStringRGB(currencySymbolColor);
		double num = PlayerStats.Instance.FishValueMultiplier;
		double num2 = PlayerStats.Instance.GetFishValueZoneSynergyMultiplier(GameManager.Instance.currentZone.currentLevel);
		targetGold = Math.Round(fish.value * num * num2);
		if (fish.isDoubleCatch)
		{
			targetGold *= 2.0;
		}
		else if (fish.isTripleCatch)
		{
			targetGold *= 3.0;
		}
		targetBonusGold = currentBonusGold;
		string cachedValueString = new LocalizedString("Skills", "#ui.text.value").GetLocalizedString();
		string cachedMoneyUnit = new LocalizedString("Skills", "#ui.unit.gold").GetLocalizedString();
		float goldAnimProgress = 0f;
		float bonusAnimProgress = 0f;
		DOTween.To(() => goldAnimProgress, delegate(float x)
		{
			goldAnimProgress = x;
		}, 1f, countUpDuration).OnUpdate(delegate
		{
			double number = targetGold * (double)goldAnimProgress;
			double number2 = targetBonusGold * (double)bonusAnimProgress;
			if (currentBonusGold > 0.0)
			{
				goldValueText.text = cachedValueString + ": " + CurrencyFormatter.FormatMoney(number) + "<color=#" + currencyColorHex + "> " + cachedMoneyUnit + "</color> (+" + CurrencyFormatter.FormatMoney(number2) + "<color=#" + currencyColorHex + "> " + cachedMoneyUnit + "</color>)";
			}
			else
			{
				goldValueText.text = cachedValueString + ": " + CurrencyFormatter.FormatMoney(number) + "<color=#" + currencyColorHex + "> " + cachedMoneyUnit + "</color> ";
			}
		});
		if (currentBonusGold > 0.0)
		{
			DOTween.To(() => bonusAnimProgress, delegate(float x)
			{
				bonusAnimProgress = x;
			}, 1f, countUpDuration * 0.8f).SetDelay(countUpDuration * 0.2f);
		}
		float totalXpGained = fish.xpValue;
		if (fish.isPerfectCatch)
		{
			totalXpGained *= PlayerStats.Instance.perfectCatchBonusMultiplier;
		}
		if (fish.isDoubleCatch)
		{
			totalXpGained *= 2f;
		}
		else if (fish.isTripleCatch)
		{
			totalXpGained *= 3f;
		}
		totalXpGained = Mathf.RoundToInt(totalXpGained);
		if (totalXpGained <= 0f)
		{
			totalXpGained = 1f;
		}
		float xpRemainingToAnimate = totalXpGained;
		float xpAnimationTimeBudget = 0.6f;
		float currentBarXp = initialXp;
		int currentBarLevel = (int)initialLevel;
		int xpToNextForBar = xpToNextLevel;
		bool levelUpOccurred = false;
		while (xpRemainingToAnimate > 0f)
		{
			float b = (float)xpToNextForBar - currentBarXp;
			float xpThisCycle = Mathf.Min(xpRemainingToAnimate, b);
			float endValue = (currentBarXp + xpThisCycle) / (float)xpToNextForBar;
			float a = xpAnimationTimeBudget * (xpThisCycle / totalXpGained);
			a = Mathf.Max(a, 0.1f);
			xpBarFillImage.DOFillAmount(endValue, a).SetEase(Ease.Linear);
			yield return new WaitForSeconds(a);
			xpRemainingToAnimate -= xpThisCycle;
			currentBarXp += xpThisCycle;
			if (currentBarXp >= (float)xpToNextForBar)
			{
				SoundManager.PlaySound("Fish_LevelUp");
				levelUpOccurred = true;
				xpBarFillImage.DOColor(Color.white, 0.05f).SetLoops(2, LoopType.Yoyo);
				levelText.transform.DOPunchScale(Vector3.one * 1.1f, 0.5f).OnComplete(delegate
				{
					levelText.transform.localScale = Vector3.one;
				});
				currentBarLevel++;
				currentBarXp = 0f;
				levelText.text = levelLoc.GetLocalizedString(currentBarLevel);
				if (currentLevelXpBarText != null)
				{
					currentLevelXpBarText.text = levelLoc.GetLocalizedString(currentBarLevel);
				}
				if (nextLevelXpBarText != null)
				{
					nextLevelXpBarText.text = levelLoc.GetLocalizedString(currentBarLevel + 1);
				}
				xpToNextForBar = fish.fish.GetXpForNextLevel(currentBarLevel);
				xpBarFillImage.fillAmount = 0f;
			}
		}
		if (levelUpOccurred)
		{
			SoundManager.PlaySound("Fish_LevelUp");
			if (levelUpStamp != null)
			{
				levelUpStamp.gameObject.SetActive(value: true);
				levelUpStamp.localScale = Vector3.zero;
				if (levelUpStampText != null)
				{
					LocalizedString localizedString2 = new LocalizedString("Skills", "#ui.text.level.up");
					levelUpStampText.text = localizedString2.GetLocalizedString();
				}
				levelUpStamp.DOScale(1f, 0.5f).SetEase(Ease.OutBack).OnComplete(delegate
				{
					levelUpStamp.DOScale(1.1f, 0.6f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
				});
				if (levelUpStampCanvasGroup != null)
				{
					levelUpStampCanvasGroup.DOFade(0f, 0.5f).SetDelay(2f);
				}
			}
			if (levelUpStampGlow != null)
			{
				levelUpStampGlow.gameObject.SetActive(value: true);
				levelUpStampGlow.localScale = Vector3.zero;
				levelUpStampGlow.localRotation = Quaternion.identity;
				levelUpStampGlow.DOScale(1.2f, 0.5f).SetEase(Ease.OutBack);
				levelUpStampGlow.DORotate(new Vector3(0f, 0f, -360f), 50f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
			}
			if (rarityTextParent != null)
			{
				rarityTextParent.gameObject.SetActive(value: true);
			}
			Dictionary<FishRarity, float> levelModifiedRarityWeights = fish.fish.GetLevelModifiedRarityWeights((int)initialLevel);
			Dictionary<FishRarity, float> levelModifiedRarityWeights2 = fish.fish.GetLevelModifiedRarityWeights(currentBarLevel);
			float num3 = levelModifiedRarityWeights.Values.Sum();
			float num4 = levelModifiedRarityWeights2.Values.Sum();
			bool flag = false;
			foreach (FishRarity value in Enum.GetValues(typeof(FishRarity)))
			{
				float valueOrDefault = levelModifiedRarityWeights.GetValueOrDefault(value);
				float valueOrDefault2 = levelModifiedRarityWeights2.GetValueOrDefault(value);
				FishRarity rarity = value;
				float num5 = ((num3 > 0f) ? (valueOrDefault / num3 * 100f) : 0f);
				float num6 = ((num4 > 0f) ? (valueOrDefault2 / num4 * 100f) : 0f) - num5;
				if (Mathf.Abs(num6) > 0.01f && rarityBonusTextPrefab != null)
				{
					flag = true;
					GameObject gameObject = UnityEngine.Object.Instantiate(rarityBonusTextPrefab, rarityTextParent);
					TMP_Text component = gameObject.GetComponent<TMP_Text>();
					string raritySymbol = GetRaritySymbol(num6);
					string text = ColorizeDeltaSymbol(raritySymbol, num6);
					component.text = "<size=110%><size=150%>" + text + "</size> " + rarity.GetLocalizedText() + "</size>";
					component.color = GetRarityColor(rarity);
					gameObject.transform.localScale = Vector3.zero;
					gameObject.transform.DOScale(1f, 0.3f).SetEase(Ease.OutBack);
				}
			}
			if (flag)
			{
				if (rarityTextParent != null)
				{
					LayoutRebuilder.ForceRebuildLayoutImmediate(rarityTextParent.GetComponent<RectTransform>());
				}
				SoundManager.PlaySound("Tooltip_Pop");
				yield return new WaitForSeconds(0.15f);
			}
		}
		if (!isFinalCatch)
		{
			yield return new WaitForSeconds(displayDuration);
		}
		if (fish.isPerfectCatch && perfectCatchText != null)
		{
			perfectCatchText.DOFade(0f, 0.3f);
		}
		SoundManager.PlaySound("Slide");
		mainPanel.DOAnchorPos(targetOffScreenPos, slideDuration).SetEase(Ease.InBack);
		yield return new WaitForSeconds(slideDuration);
		IsVisible = false;
		base.gameObject.SetActive(value: false);
	}

	private string ColorizeDeltaSymbol(string symbol, float deltaPercentage)
	{
		Color color = ((deltaPercentage >= 0f) ? increaseSymbolColor : decreaseSymbolColor);
		return "<color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + symbol + "</color>";
	}

	private Color GetRarityColor(FishRarity rarity)
	{
		return rarity switch
		{
			FishRarity.Common => new Color(0.6f, 0.6f, 0.6f), 
			FishRarity.Uncommon => new Color(0.5f, 0.8f, 0.5f), 
			FishRarity.Rare => new Color(0.5f, 0.6f, 0.9f), 
			FishRarity.Epic => new Color(0.7f, 0.5f, 0.8f), 
			FishRarity.Legendary => new Color(0.9f, 0.5f, 0.5f), 
			_ => Color.white, 
		};
	}

	private string GetRaritySymbol(float percentage)
	{
		if (percentage <= 0f)
		{
			return "-";
		}
		if (percentage < 4f)
		{
			return "+";
		}
		if (percentage < 10f)
		{
			return "++";
		}
		if (percentage < 25f)
		{
			return "+++";
		}
		if (percentage < 50f)
		{
			return "++++";
		}
		return "+++++";
	}

	public void ForceHide()
	{
		if (IsVisible || base.gameObject.activeSelf)
		{
			StopAllCoroutines();
			mainPanel.DOKill(complete: true);
			if (doubleCatchGlow != null)
			{
				doubleCatchGlow.DOKill();
			}
			if (doubleCatchText != null)
			{
				doubleCatchText.DOKill();
			}
			if (levelUpStamp != null)
			{
				levelUpStamp.DOKill();
			}
			if (levelUpStampGlow != null)
			{
				levelUpStampGlow.DOKill();
			}
			if (perfectCatchText != null)
			{
				perfectCatchText.DOKill();
			}
			IsVisible = false;
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnDisable()
	{
		IsVisible = false;
	}

	private void OnDestroy()
	{
		if (instancedIconMaterial != null)
		{
			UnityEngine.Object.Destroy(instancedIconMaterial);
		}
	}
}
