using System;
using System.Collections.Generic;
using FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class MinigamePanelParent : MenuPanel
{
	protected bool hasInitialized;

	public EnergyTracker energyTracker;

	public LevelStat levelStat;

	[NonSerialized]
	public MinigameState minigameState;

	public MinigameState debugMinigameState;

	public MinigameRewardSelectionPanel selectionPanel;

	public const int energyCost = 10;

	public MinigameHeader minigameHeader;

	public float yieldMultiplier;

	[NonSerialized]
	public readonly ItemList rewardEntities = new ItemList();

	[NonSerialized]
	public float yieldBaseline;

	[NonSerialized]
	public float yieldBaselineUpgraded;

	public ScrollRect scrollRect;

	public override void Initialize()
	{
		base.Initialize();
		minigameHeader.Initialize();
		if (null != scrollRect)
		{
			scrollRect.scrollSensitivity = 40f;
			scrollRect.verticalScrollbarSpacing = -1f;
		}
	}

	public override void Show()
	{
		base.Show();
		if (!hasInitialized)
		{
			ConfigureAsNewGame();
		}
	}

	public virtual void ConfigureAsNewGame()
	{
		FinalizeAndRestart();
	}

	public override void CreateLayoutForActiveTown()
	{
		base.CreateLayoutForActiveTown();
		minigameHeader.OnActiveTownChanged();
		if (null != selectionPanel)
		{
			selectionPanel.OnActiveTownChanged();
		}
	}

	protected void FinalizeAndRestart()
	{
		ResetMinigame();
		if (null != selectionPanel)
		{
			EnterSelectionState();
			return;
		}
		LoadNewMinigame();
		CalcMetadata();
	}

	public virtual void EnterSelectionState()
	{
		minigameState = MinigameState.RewardSelection;
		selectionPanel.EnterSelectionState();
	}

	public override void ReloadLabels()
	{
		base.ReloadLabels();
		if (null != minigameHeader)
		{
			minigameHeader.ReloadLabels();
		}
	}

	public virtual void CalcMetadata()
	{
		yieldMultiplier = GameUtility.ExponentGrowth(1f, levelStat.level, 0.2f);
	}

	public override void CreateItems()
	{
		base.CreateItems();
		if (null != minigameHeader)
		{
			minigameHeader.LoadPanel(this);
		}
	}

	public virtual void ResetMinigame()
	{
	}

	protected virtual void LoadNewMinigame()
	{
		hasInitialized = true;
		minigameState = MinigameState.Running;
	}

	protected virtual void DeclareVictory()
	{
		minigameState = MinigameState.Success;
	}

	protected virtual void DeclareFailure()
	{
		minigameState = MinigameState.Failure;
	}

	public virtual fsData GetData()
	{
		return null;
	}

	public virtual void StoreCommonData(Dictionary<string, fsData> dataDict)
	{
		dataDict["Energy"] = new fsData(energyTracker.currentCount);
		dataDict["gameState"] = new fsData((long)minigameState);
		dataDict["Level"] = new fsData(levelStat.level);
		dataDict["xp"] = new fsData(levelStat.points);
	}

	protected virtual void LoadFromDictionary(Dictionary<string, fsData> dataDict)
	{
		if (dataDict.TryGetValue("Energy", out var value))
		{
			energyTracker.currentCount = (float)value.AsDouble;
		}
		if (dataDict.TryGetValue("Level", out var value2) && value2.TryAsInt(out var i))
		{
			levelStat.SetLevel(i);
		}
		if (dataDict.TryGetValue("xp", out var value3) && value3.TryAsDouble(out var f))
		{
			levelStat.SetPoints((float)f);
		}
		SaveFile.TryLoadIntOut(dataDict, "gameState", out var targetInt);
		minigameState = (MinigameState)targetInt;
	}

	public void LoadFromData(fsData data)
	{
		if (data.TryAsDictionary(out var result))
		{
			LoadFromDictionary(result);
		}
		PostProcessLoadedData();
		hasInitialized = true;
	}

	protected virtual void PostProcessLoadedData()
	{
	}

	public override bool ShouldBecomeInactiveOnHide()
	{
		return true;
	}

	protected override void OnBecameAvailableDuringGame()
	{
		base.OnBecameAvailableDuringGame();
		MenuManager.Instance.minigameSelectionPanel.OnChildPanelBecameAvailbleDuringGame(this);
	}

	protected void AnimateToExperience(Transform startTransform, ItemType t, float amount, int numIcons = 0)
	{
		if (numIcons == 0)
		{
			numIcons = UnityEngine.Random.Range(3, 6);
		}
		Vector3 position = startTransform.position;
		Vector3 position2 = minigameHeader.xpLevelDisplay.transform.position;
		MenuManager.Instance.AnimateItem(EntityId.FromItem(t), numIcons, amount, position, position2, OnAnimatedExpFinished);
	}

	private void OnAnimatedExpFinished(AnimatedIcon i)
	{
		levelStat.GainPoints(i.animatedValue);
	}

	protected virtual void CalcYield()
	{
		yieldBaseline = 0f;
	}
}
