using System;
using System.Collections.Generic;
using DG.Tweening;
using FullSerializer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinigamePanel : MinigamePanelParent
{
	public TextMeshProUGUI rewardLabel;

	public MinigameFooter minigameFooter;

	[NonSerialized]
	public ItemType rewardItem;

	protected double rewardAmount;

	protected int numPendingAnimations;

	public GridLayoutGroup attemptsGroup;

	public bool hasDisplayedFinalResult;

	public string instructionsLocalizationKey;

	private readonly List<MiningDirectoryIcon> attemptIcons = new List<MiningDirectoryIcon>();

	protected int maxNumAttempts;

	protected int numAttemptsMade;

	public ItemType attemptItemType;

	public override void Initialize()
	{
		base.Initialize();
		minigameFooter.Initialize();
	}

	public override void Show()
	{
		base.Show();
		if (rewardItem == ItemType.None)
		{
			selectionPanel.SelectNaturalResourceButton();
		}
	}

	public override void CreateItems()
	{
		if (null != selectionPanel)
		{
			selectionPanel.LoadPanel(this);
		}
		if (null != selectionPanel && energyTracker != null)
		{
			selectionPanel.energyCostIcon.LoadStaticCost(energyTracker, 10.0);
		}
		if (null != minigameHeader && energyTracker != null)
		{
			minigameHeader.energyCapacityRegion.iconImage.sprite = IconManager.SpriteForItem(energyTracker.energyType);
		}
		minigameFooter.CreateItems(this);
		base.CreateItems();
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		if (null != selectionPanel)
		{
			selectionPanel.ReloadLabels();
		}
		minigameFooter.ReloadLabels();
	}

	protected override void LoadNewMinigame()
	{
		base.LoadNewMinigame();
		if (null != selectionPanel)
		{
			selectionPanel.gameObject.SetActive(value: false);
		}
	}

	protected float MultiplierForPerfect()
	{
		return 2f;
	}

	protected override void UpdateDynamicDisplay()
	{
		base.UpdateDynamicDisplay();
		minigameFooter.UpdateDynamicDisplay();
		minigameHeader.UpdateDynamicDisplay();
		if (minigameState == MinigameState.RewardSelection && null != selectionPanel)
		{
			selectionPanel.UpdateDynamicDisplay();
		}
	}

	protected override void UpdateItemAvailability()
	{
		base.UpdateItemAvailability();
		selectionPanel.UpdateItemAvailability();
	}

	public void OnBeginPressed()
	{
		ResetMinigame();
		LoadNewMinigame();
	}

	public void OnClaimRewardPressed()
	{
		ClaimReward();
		FinalizeAndRestart();
	}

	public override void ResetMinigame()
	{
		base.ResetMinigame();
		numAttemptsMade = 0;
		minigameFooter.ResetMinigame();
		numPendingAnimations = 0;
		hasDisplayedFinalResult = false;
		rewardAmount = 0.0;
	}

	protected virtual void SetPerfect()
	{
	}

	private void ClaimReward()
	{
	}

	protected void AnimateItemGain(Transform startTransform, float value, int numIcons = 1, ItemType item = ItemType.None)
	{
		numPendingAnimations += numIcons;
		RectTransform rectTransform = minigameFooter.rewardSection.iconImage.rectTransform;
		Vector3 position = startTransform.position;
		Vector3 position2 = rectTransform.position;
		if (item == ItemType.None)
		{
			item = rewardItem;
		}
		MenuManager.Instance.AnimateItem(EntityId.FromItem(item), numIcons, value, position, position2, OnAnimatedIconFinished);
	}

	protected virtual bool IsReadyToDisplayFinalResult()
	{
		if ((minigameState == MinigameState.Failure || minigameState == MinigameState.Success) && numPendingAnimations == 0)
		{
			return !hasDisplayedFinalResult;
		}
		return false;
	}

	protected virtual void OnRewardAnimationFinished(AnimatedIcon i)
	{
		numPendingAnimations--;
		MenuPanel.gm.activeTown.EarnItem(rewardItem, i.animatedValue);
		minigameFooter.rewardSection.AnimateAddition(i.animatedValue);
		if (IsReadyToDisplayFinalResult())
		{
			DisplayFinalCompletionState();
		}
	}

	protected virtual void OnAnimatedIconFinished(AnimatedIcon i)
	{
		numPendingAnimations--;
		minigameFooter.rewardSection.AnimateAddition(i.animatedValue);
		if (IsReadyToDisplayFinalResult())
		{
			DisplayFinalCompletionState();
		}
	}

	protected virtual void DisplayFinalCompletionState()
	{
		hasDisplayedFinalResult = true;
		minigameFooter.resetButton.buttonState = CustomButtonState.HighlightFlashing;
		CalcReward();
		if (IsPerfect())
		{
			SetPerfect();
		}
	}

	protected virtual bool IsPerfect()
	{
		return false;
	}

	protected virtual void CalcReward()
	{
	}

	public virtual void DisplayAttemptIcons(int num)
	{
		foreach (MiningDirectoryIcon attemptIcon in attemptIcons)
		{
			attemptIcon.gameObject.SetActive(value: false);
		}
		for (int i = 0; i < num; i++)
		{
			MiningDirectoryIcon miningDirectoryIcon = null;
			if (i < attemptIcons.Count)
			{
				miningDirectoryIcon = attemptIcons[i];
			}
			else
			{
				miningDirectoryIcon = MenuManager.GetMenuObject(MenuManager.Instance.attemptIconPrefab, attemptsGroup.transform).GetComponent<MiningDirectoryIcon>();
				attemptIcons.Add(miningDirectoryIcon);
			}
			miningDirectoryIcon.gameObject.SetActive(value: true);
			miningDirectoryIcon.shapeImage.sprite = IconManager.SpriteForItem(attemptItemType);
			miningDirectoryIcon.checkmark.sprite = IconManager.Instance.invalidSlash;
			miningDirectoryIcon.checkmark.gameObject.SetActive(value: false);
		}
	}

	public void DisplayNumAttemptsTaken()
	{
		for (int i = 0; i < numAttemptsMade && i < attemptIcons.Count; i++)
		{
			attemptIcons[i].checkmark.gameObject.SetActive(value: true);
		}
	}

	public void ConsumeAttempt()
	{
		numAttemptsMade++;
		int num = numAttemptsMade - 1;
		if (num < attemptIcons.Count)
		{
			MiningDirectoryIcon miningDirectoryIcon = attemptIcons[num];
			Image checkmark = miningDirectoryIcon.checkmark;
			checkmark.gameObject.SetActive(value: true);
			float num2 = 0.2f;
			float num3 = 0.5f;
			Sequence s = DOTween.Sequence();
			miningDirectoryIcon.transform.DOShakePosition(0.5f, new Vector3(10f, 0f, 0f));
			s.Append(miningDirectoryIcon.transform.DOScale(1.5f, num2));
			s.AppendInterval(num3);
			s.Append(miningDirectoryIcon.transform.DOScale(1f, num2));
			checkmark.transform.DOScale(1.5f, num3).From().SetDelay(num2);
			checkmark.DOColor(Color.clear, num3).From().SetDelay(num2);
		}
		if (numAttemptsMade >= maxNumAttempts)
		{
			DeclareFailure();
		}
	}

	protected override void LoadFromDictionary(Dictionary<string, fsData> dataDict)
	{
		base.LoadFromDictionary(dataDict);
		SaveFile.TryLoadInt(dataDict, "attempts", ref numAttemptsMade);
		SaveFile.TryLoadInt(dataDict, "maxAttempts", ref maxNumAttempts);
		SaveFile.TryLoadIntOut(dataDict, "rewardType", out var targetInt);
		SaveFile.TryLoadDoubleOut(dataDict, "rewardCount", out rewardAmount);
		rewardItem = (ItemType)targetInt;
		DisplayAttemptIcons(maxNumAttempts);
		DisplayNumAttemptsTaken();
		SetReward(rewardItem);
	}

	public override void StoreCommonData(Dictionary<string, fsData> dataDict)
	{
		base.StoreCommonData(dataDict);
		dataDict["attempts"] = new fsData(numAttemptsMade);
		dataDict["maxAttempts"] = new fsData(maxNumAttempts);
		dataDict["rewardType"] = new fsData((long)rewardItem);
		dataDict["rewardCount"] = new fsData(rewardAmount);
	}

	public void EarnReward(double amount)
	{
		rewardAmount += amount;
		MenuPanel.gm.activeTown.EarnItem(rewardItem, amount);
	}

	protected override void PostProcessLoadedData()
	{
		if (minigameState == MinigameState.Success)
		{
			DisplayFinalCompletionState();
		}
		else if (minigameState == MinigameState.Failure)
		{
			DisplayFinalCompletionState();
		}
		else
		{
			minigameFooter.ResetRewardSection();
			CalcReward();
			minigameFooter.rewardSection.SetValue(GameUtility.AsFloat(rewardAmount));
		}
		if (null != selectionPanel)
		{
			selectionPanel.gameObject.SetActive(minigameState == MinigameState.RewardSelection);
		}
		ReloadLabels();
	}

	public void SetReward(ItemType t)
	{
		rewardItem = t;
		CalcYield();
		if (null != minigameHeader)
		{
			minigameHeader.SetReward(t);
		}
		if (null != minigameFooter)
		{
			minigameFooter.SetReward(t);
		}
	}

	protected override void CalcYield()
	{
		yieldBaseline = GameUtility.AsFloat(rewardEntities.Count(rewardItem));
	}
}
