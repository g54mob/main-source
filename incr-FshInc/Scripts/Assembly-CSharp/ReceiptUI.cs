using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class ReceiptUI : MonoBehaviour
{
	[Header("Receipt Header")]
	public TextMeshProUGUI receiptDayCounterText;

	[Header("Fish Caught Section")]
	public Transform fishEntryParent;

	public GameObject fishEntryPrefab;

	[Header("Summary Elements")]
	public TextMeshProUGUI basePricesMoneyText;

	public TextMeshProUGUI perfectCatchCountText;

	public TextMeshProUGUI perfectCatchBonusMoneyText;

	public TextMeshProUGUI otherBonusesMoneyText;

	public GameObject summarySectionHeaderParent;

	public GameObject basePricesEntryParent;

	public GameObject perfectCatchBonusEntryParent;

	public GameObject otherBonusesEntryParent;

	[Header("Total Earnings")]
	public GameObject totalEarningsPanelParent;

	public TextMeshProUGUI totalEarningsMoneyText;

	public TextMeshProUGUI totalEarningsText;

	[Header("Animation Settings")]
	public float fishEntryAnimDuration = 0.25f;

	public float fishEntryStaggerDelay = 0.1f;

	public float summaryAnimDuration = 0.3f;

	public float summaryStaggerDelay = 0.1f;

	public float totalEarningsAnimDuration = 0.5f;

	public float sectionDelay = 0.3f;

	public TextMeshProUGUI fishCaughtHeading;

	private int _maxDotLength = 8;

	private Sequence _receiptAnimationSequence;

	private void Awake()
	{
		EnsureCanvasGroup(receiptDayCounterText?.gameObject);
		EnsureCanvasGroup(fishCaughtHeading?.gameObject);
		EnsureCanvasGroup(summarySectionHeaderParent);
		EnsureCanvasGroup(basePricesEntryParent);
		EnsureCanvasGroup(perfectCatchBonusEntryParent);
		EnsureCanvasGroup(otherBonusesEntryParent);
		EnsureCanvasGroup(totalEarningsPanelParent);
		HideAllElementsForAnimation();
	}

	private void HideAllElementsForAnimation()
	{
		EnsureCanvasGroup(receiptDayCounterText?.gameObject);
		EnsureCanvasGroup(fishCaughtHeading?.gameObject);
		EnsureCanvasGroup(summarySectionHeaderParent);
		EnsureCanvasGroup(basePricesEntryParent);
		EnsureCanvasGroup(perfectCatchBonusEntryParent);
		EnsureCanvasGroup(otherBonusesEntryParent);
		EnsureCanvasGroup(totalEarningsPanelParent);
		if (receiptDayCounterText != null)
		{
			receiptDayCounterText.GetComponent<CanvasGroup>().alpha = 0f;
		}
		if (fishCaughtHeading != null)
		{
			fishCaughtHeading.GetComponent<CanvasGroup>().alpha = 0f;
		}
		if (summarySectionHeaderParent != null)
		{
			summarySectionHeaderParent.GetComponent<CanvasGroup>().alpha = 0f;
		}
		if (basePricesEntryParent != null)
		{
			basePricesEntryParent.GetComponent<CanvasGroup>().alpha = 0f;
		}
		if (perfectCatchBonusEntryParent != null)
		{
			perfectCatchBonusEntryParent.GetComponent<CanvasGroup>().alpha = 0f;
		}
		if (otherBonusesEntryParent != null)
		{
			otherBonusesEntryParent.GetComponent<CanvasGroup>().alpha = 0f;
		}
		if (totalEarningsPanelParent != null)
		{
			totalEarningsPanelParent.GetComponent<CanvasGroup>().alpha = 0f;
		}
		if (totalEarningsPanelParent != null)
		{
			totalEarningsPanelParent.transform.localScale = Vector3.one;
		}
	}

	public double GenerateReceipt(List<CaughtFish> caughtFish, float otherBonuses = 0f)
	{
		ClearReceipt();
		LocalizedString localizedString = new LocalizedString("Skills", "#ui.receipt.day.counter");
		receiptDayCounterText.text = localizedString.GetLocalizedString(GameManager.Instance.CurrentDay);
		Dictionary<string, ReceiptLineItem> dictionary = new Dictionary<string, ReceiptLineItem>();
		double num = 0.0;
		double num2 = 0.0;
		int num3 = 0;
		LocalizedString localizedString2 = new LocalizedString("Skills", "#ui.receipt.fish.caught.title");
		fishCaughtHeading.text = localizedString2.GetLocalizedString();
		foreach (CaughtFish item in caughtFish)
		{
			string key = item.fishName + "_" + item.rarityName;
			if (!dictionary.ContainsKey(key))
			{
				dictionary[key] = new ReceiptLineItem
				{
					fishName = item.fish.LocalizedName,
					rarityName = item.rarityData.rarity.GetLocalizedText()
				};
			}
			ReceiptLineItem receiptLineItem = dictionary[key];
			int num4 = 1;
			if (item.isTripleCatch)
			{
				num4 = 3;
			}
			else if (item.isDoubleCatch)
			{
				num4 = 2;
			}
			double num5 = PlayerStats.Instance.GetFishValueZoneSynergyMultiplier(GameManager.Instance.currentZone.currentLevel);
			double num6 = Math.Round(item.value * (double)PlayerStats.Instance.FishValueMultiplier * num5);
			double num7 = (item.isPerfectCatch ? Math.Round(num6 * (double)PlayerStats.Instance.perfectCatchBonusMultiplier - num6) : 0.0);
			receiptLineItem.quantity += num4;
			receiptLineItem.totalBaseValue += num6 * (double)num4;
			receiptLineItem.totalPerfectBonus += num7 * (double)num4;
			if (item.isPerfectCatch)
			{
				receiptLineItem.perfectCatchCount += num4;
				num3 += num4;
			}
			num += num6 * (double)num4;
			num2 += num7 * (double)num4;
		}
		_receiptAnimationSequence = DOTween.Sequence().SetAutoKill(autoKillOnCompletion: false);
		if (receiptDayCounterText != null)
		{
			CanvasGroup component = receiptDayCounterText.GetComponent<CanvasGroup>();
			receiptDayCounterText.transform.localScale = Vector3.one * 0.5f;
			_receiptAnimationSequence.AppendCallback(delegate
			{
				PlayReceiptPrintSound();
			}).Append(component.DOFade(1f, fishEntryAnimDuration)).Join(receiptDayCounterText.transform.DOScale(1f, fishEntryAnimDuration).SetEase(Ease.OutBack))
				.AppendInterval(fishEntryStaggerDelay);
		}
		if (fishCaughtHeading != null)
		{
			CanvasGroup component2 = fishCaughtHeading.GetComponent<CanvasGroup>();
			_receiptAnimationSequence.AppendCallback(delegate
			{
				PlayReceiptPrintSound();
			}).Append(component2.DOFade(1f, fishEntryAnimDuration)).AppendInterval(fishEntryStaggerDelay);
		}
		foreach (ReceiptLineItem value in dictionary.Values)
		{
			FishEntryUI component3 = UnityEngine.Object.Instantiate(fishEntryPrefab, fishEntryParent).GetComponent<FishEntryUI>();
			string fishName = ((value.quantity > 1) ? $"{value.quantity}x {value.fishName}" : value.fishName);
			bool isPerfectCatch = value.perfectCatchCount > 0;
			component3.Setup(fishName, value.rarityName, (int)Math.Min(value.totalBaseValue, 2147483647.0), isPerfectCatch, (int)Math.Min(value.totalPerfectBonus, 2147483647.0));
			_receiptAnimationSequence.AppendCallback(delegate
			{
				PlayReceiptPrintSound();
			}).Append(component3.AnimateIn(fishEntryAnimDuration)).AppendInterval(fishEntryStaggerDelay);
		}
		double num8 = num + num2;
		double num9 = 0.0;
		double num10 = 0.0;
		if (GameManager.Instance.currentZone != null)
		{
			double num11 = GameManager.Instance.currentZone.GetCurrentGoldBonusPercent();
			num9 = Math.Round(num8 * num11);
		}
		if (otherBonuses > 0f)
		{
			num10 = Math.Round(num8 * ((double)PlayerStats.Instance.SponsorshipAdditive * 0.01));
			num10 *= Math.Round(PlayerStats.Instance.SponsorshipMultiplier);
		}
		double num12 = num10 + num9;
		_receiptAnimationSequence = DOTween.Sequence().SetAutoKill(autoKillOnCompletion: false);
		_receiptAnimationSequence.AppendInterval(sectionDelay);
		LocalizedString localizedString3 = new LocalizedString("Skills", "#ui.receipt.base.prices");
		LocalizedString localizedString4 = new LocalizedString("Skills", "#ui.receipt.other.bonuses");
		LocalizedString localizedString5 = new LocalizedString("Skills", "#ui.receipt.perfect.catch.bonus");
		basePricesMoneyText.text = "> " + localizedString3.GetLocalizedString() + FormatMoneyWithDots(num, 7);
		perfectCatchCountText.text = "> " + localizedString5.GetLocalizedString();
		perfectCatchBonusMoneyText.text = num3 + "X" + FormatMoneyWithDots(num2, 16);
		otherBonusesMoneyText.text = "> " + localizedString4.GetLocalizedString() + FormatMoneyWithDots(num12, 5);
		_receiptAnimationSequence.AppendCallback(delegate
		{
			PlayReceiptPrintSound();
		}).Append(summarySectionHeaderParent.GetComponent<CanvasGroup>().DOFade(1f, summaryAnimDuration)).AppendInterval(summaryStaggerDelay);
		_receiptAnimationSequence.AppendCallback(delegate
		{
			PlayReceiptPrintSound();
		}).Append(basePricesEntryParent.GetComponent<CanvasGroup>().DOFade(1f, summaryAnimDuration)).AppendInterval(summaryStaggerDelay);
		_receiptAnimationSequence.AppendCallback(delegate
		{
			PlayReceiptPrintSound();
		}).Append(perfectCatchBonusEntryParent.GetComponent<CanvasGroup>().DOFade(1f, summaryAnimDuration)).AppendInterval(summaryStaggerDelay);
		_receiptAnimationSequence.AppendCallback(delegate
		{
			PlayReceiptPrintSound();
		}).Append(otherBonusesEntryParent.GetComponent<CanvasGroup>().DOFade(1f, summaryAnimDuration)).AppendInterval(summaryStaggerDelay);
		LocalizedString localizedString6 = new LocalizedString("Skills", "#ui.unit.gold");
		LocalizedString localizedString7 = new LocalizedString("Skills", "#ui.receipt.total.earnings");
		double num13 = num + num2 + num12;
		totalEarningsMoneyText.text = CurrencyFormatter.FormatMoney(num13) + " " + localizedString6.GetLocalizedString();
		totalEarningsText.text = localizedString7.GetLocalizedString();
		_receiptAnimationSequence.AppendInterval(sectionDelay);
		_receiptAnimationSequence.AppendCallback(delegate
		{
			PlayReceiptPrintSound();
		}).Append(totalEarningsPanelParent.GetComponent<CanvasGroup>().DOFade(1f, totalEarningsAnimDuration * 0.5f)).Join(totalEarningsPanelParent.transform.DOScale(1.1f, totalEarningsAnimDuration * 0.5f).SetEase(Ease.OutBack))
			.Append(totalEarningsPanelParent.transform.DOScale(1f, totalEarningsAnimDuration * 0.5f).SetEase(Ease.OutQuad));
		_receiptAnimationSequence.Play();
		return num13;
	}

	private void PlayReceiptPrintSound()
	{
		SoundManager.PlaySound("ReceiptPrint");
	}

	public void ClearForNewDay()
	{
		ClearReceipt();
		if (receiptDayCounterText != null)
		{
			receiptDayCounterText.text = "";
			receiptDayCounterText.transform.localScale = Vector3.one;
		}
		HideAllElementsForAnimation();
	}

	private void ClearReceipt()
	{
		foreach (Transform item in fishEntryParent)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
	}

	private void EnsureCanvasGroup(GameObject go)
	{
		if (go != null && go.GetComponent<CanvasGroup>() == null)
		{
			go.AddComponent<CanvasGroup>();
		}
	}

	private string FormatMoneyWithDots(double money, int dotLength = 0)
	{
		LocalizedString localizedString = new LocalizedString("Skills", "#ui.unit.gold");
		string text = CurrencyFormatter.FormatMoney(money) + " " + localizedString.GetLocalizedString();
		string text2 = "";
		text2 = ((dotLength <= 0) ? new string('.', Mathf.Max(0, _maxDotLength - text.Length)) : new string('.', Mathf.Max(0, dotLength - text.Length)));
		return text2 + " " + text;
	}

	public void SkipAnimation()
	{
		if (_receiptAnimationSequence != null && _receiptAnimationSequence.IsPlaying())
		{
			_receiptAnimationSequence.Complete(withCallbacks: true);
			PlayReceiptPrintSound();
		}
	}
}
