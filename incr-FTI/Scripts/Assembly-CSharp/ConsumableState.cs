using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ConsumableState : CountableState
{
	public bool wasFrameInputAvailable;

	public bool wasOutputCapacityAvailable;

	public double frameInputAvailable;

	public double frameSurplusAvailable;

	public double frameOutputCapacityAvailable;

	public double bonusCapacityToApply;

	public double lastFrameDemand;

	public double lastFrameSurplus;

	public bool frameIsLimitingInput;

	public bool frameIsLimitingOutput;

	public double passOutputCapacityRequested;

	public double passOutputSupplyRatio;

	public double passInputSupplyRequested;

	public double passInputSupplyRatio;

	public double flexStorage;

	public bool isInputSupplyInfinite;

	public bool isOutputCapacityInfinite;

	public bool isInputSupplyZero;

	public bool isPotentiallyProduced;

	public bool isOutputCapacityZero;

	public AffordabilityState passInputAffordabilityState;

	public AffordabilityState passOutputCapacityState;

	public double frameDelta;

	public double frameStatsAdded;

	public double frameAttemptDelta;

	public double frameLocalConsumed;

	public double activeFrameConsumption;

	public double frameImported;

	public double frameExported;

	public double maxConsumePerSecond;

	public double frameLocalProduced;

	public bool didProcess;

	public double frameAdded;

	public double frameSubtracted;

	public double perSecondAttemptedDelta;

	public bool isLocked;

	public double queuedStatValue;

	public readonly List<FloatProperty> spendStats = new List<FloatProperty>();

	public bool isInAlertState;

	public FloatProperty townProductionStat;

	public FloatProperty globalProductionStat;

	[NonSerialized]
	public List<ItemRateData> outputRequesters = new List<ItemRateData>();

	[NonSerialized]
	public List<ItemRateData> inputRequesters = new List<ItemRateData>();

	private double warningMargin;

	private int countOfDecreaseFrames;

	public bool showDecreaseWarning;

	public bool shouldSaveDemandData;

	public double postProcessMultiplier;

	public bool debug;

	public bool hasUnlimitedCapacity => maxCount >= double.MaxValue;

	public void ClearFrameRequestState()
	{
		if (TimeManager.IsProcessingSimulation)
		{
			perSecondAttemptedDelta = 0.0;
			frameDelta = 0.0;
			frameStatsAdded = 0.0;
			frameAttemptDelta = 0.0;
			frameLocalProduced = 0.0;
			frameLocalConsumed = 0.0;
			activeFrameConsumption = 0.0;
			frameImported = 0.0;
			frameExported = 0.0;
			frameAdded = 0.0;
			frameSubtracted = 0.0;
		}
		frameIsLimitingInput = false;
		frameIsLimitingOutput = false;
		_ = debug;
	}

	[Conditional("UNITY_EDITOR")]
	public void TrySetDebug()
	{
		bool flag = this is ItemState itemState && itemState.type == StartupManager.Instance.debugTradeItemType && ((StartupManager.Instance.isItemDebugGlobal && itemState.parentTown == null) || (!StartupManager.Instance.isItemDebugGlobal && itemState.parentTown == GameManager.Instance.activeTown));
		debug = flag;
	}

	public void PreparePassRequest(int priorityIndex)
	{
		passOutputCapacityRequested = 0.0;
		passOutputSupplyRatio = double.MaxValue;
		passInputSupplyRequested = 0.0;
		passInputSupplyRatio = 1.0;
	}

	public void CalcFrameAvailability()
	{
		frameInputAvailable = currentCount;
		wasFrameInputAvailable = currentCount > 0.0;
		frameSurplusAvailable = lastFrameSurplus;
		double num = maxCount - currentCount;
		if (num <= 0.0)
		{
			num = 0.0;
		}
		frameOutputCapacityAvailable = num + bonusCapacityToApply;
		_ = debug;
		wasOutputCapacityAvailable = currentCount < maxCount;
		if (GameUtility.IsNearlyZero(frameOutputCapacityAvailable))
		{
			passOutputCapacityState = AffordabilityState.CanNotProduce;
			isOutputCapacityZero = true;
		}
		else
		{
			passOutputCapacityState = AffordabilityState.CanFullyProduce;
			isOutputCapacityZero = false;
		}
		if (GameUtility.IsNearlyZero(frameInputAvailable))
		{
			passInputAffordabilityState = AffordabilityState.CanNotProduce;
			if (isPotentiallyProduced)
			{
				isInputSupplyZero = false;
			}
			else
			{
				isInputSupplyZero = true;
			}
		}
		else
		{
			passInputAffordabilityState = AffordabilityState.CanFullyProduce;
			isInputSupplyZero = false;
		}
	}

	public void CalcPassOutputRatio()
	{
		double num = frameOutputCapacityAvailable;
		if (isOutputCapacityInfinite || passOutputCapacityRequested <= 0.0)
		{
			passOutputSupplyRatio = double.MaxValue;
		}
		else if (num <= 0.0)
		{
			passOutputSupplyRatio = 0.0;
		}
		else
		{
			passOutputSupplyRatio = num / passOutputCapacityRequested;
		}
		if (passOutputSupplyRatio >= 1.0)
		{
			passOutputCapacityState = AffordabilityState.CanFullyProduce;
		}
		else if (passOutputSupplyRatio > 0.0)
		{
			passOutputCapacityState = AffordabilityState.CanPartiallyProduce;
		}
		else
		{
			passOutputCapacityState = AffordabilityState.CanNotProduce;
		}
		_ = debug;
	}

	public void CalcPassInputRatio()
	{
		double num = frameInputAvailable;
		if (isInputSupplyInfinite || passInputSupplyRequested <= 0.0)
		{
			passInputSupplyRatio = 1.0;
		}
		else if (num <= 0.0)
		{
			passInputSupplyRatio = 0.0;
		}
		else
		{
			passInputSupplyRatio = num / passInputSupplyRequested;
		}
		if (passInputSupplyRatio > 0.99)
		{
			passInputAffordabilityState = AffordabilityState.CanFullyProduce;
		}
		else if (passInputSupplyRatio > 0.0)
		{
			passInputAffordabilityState = AffordabilityState.CanPartiallyProduce;
		}
		else
		{
			passInputAffordabilityState = AffordabilityState.CanNotProduce;
		}
		_ = debug;
	}

	public bool IsEmpty()
	{
		if (isInputSupplyInfinite)
		{
			return false;
		}
		return currentCount <= 0.0;
	}

	public double ProcessAdd(double amount)
	{
		if (amount > 0.0)
		{
			didProcess = true;
		}
		currentCount += amount;
		frameOutputCapacityAvailable -= amount;
		if (this is ItemState itemState && isLocked)
		{
			itemState.CalcAvailability();
		}
		frameAdded += amount;
		frameDelta += amount;
		return amount;
	}

	public void IncrementStats()
	{
		if (queuedStatValue > 0.0)
		{
			townProductionStat?.Add(queuedStatValue);
			globalProductionStat?.Add(queuedStatValue);
			queuedStatValue = 0.0;
		}
	}

	public double ProcessSubtract(double amount)
	{
		if (amount > 0.0)
		{
			didProcess = true;
		}
		if (!isInputSupplyInfinite && currentCount - amount < minCount)
		{
			amount = currentCount - minCount;
		}
		currentCount -= amount;
		for (int i = 0; i < spendStats.Count; i++)
		{
			spendStats[i].value += amount;
		}
		frameSubtracted += amount;
		frameDelta -= amount;
		frameInputAvailable -= amount;
		_ = debug;
		return amount;
	}

	public void AddManualCurrency(double amount)
	{
		currentCount += amount;
	}

	public void Add(double amount)
	{
		_ = debug;
		if (!isOutputCapacityInfinite)
		{
			double num = maxCount - currentCount;
			if (amount > num)
			{
				amount = num;
				_ = 0.0;
			}
		}
		currentCount += amount;
		_ = debug;
	}

	public void CalcFinalFrameStats()
	{
		double num = maxCount + bonusCapacityToApply;
		if (isOutputCapacityInfinite)
		{
			bonusCapacityToApply = 0.0;
		}
		else
		{
			bonusCapacityToApply = activeFrameConsumption;
		}
		lastFrameDemand = activeFrameConsumption;
		lastFrameSurplus = frameLocalProduced - activeFrameConsumption;
		if (debug && currentCount > num)
		{
			_ = currentCount;
			_ = frameAdded;
		}
		if (TimeManager.SimulationDelta > 0f)
		{
			double num2 = activeFrameConsumption / (double)TimeManager.SimulationDelta;
			if (num2 > maxConsumePerSecond)
			{
				maxConsumePerSecond = num2;
				CalcCapacity();
			}
		}
	}

	public override void AssignMaxCapacity()
	{
		if (parentTown == null)
		{
			if (CountableState.gm.isTradingStorageInfinite)
			{
				isOutputCapacityInfinite = true;
			}
		}
		else if (CountableState.gm.isTownStorageInfinite)
		{
			isOutputCapacityInfinite = true;
		}
		base.AssignMaxCapacity();
	}

	public void CalcCapacity()
	{
		AssignMaxCapacity();
		if (isOutputCapacityInfinite)
		{
			return;
		}
		if (this is ResourceState { def: var def } resourceState)
		{
			maxCount = (double)(def.capacityPerLand * resourceState.biomeCapacityMultiplier) * parentTown.landState.maxCount;
			maxCount *= parentTown.MultiplierForPerk(PerkType.NaturalResourceCapacity);
			maxCount *= parentTown.MultiplierForResearch(ResearchType.InfiniteNaturalResourceCapacity);
		}
		else if (this is ItemState itemState && (Item.IsCurrency(itemState.type) || itemState.type == ItemType.UtilityQuestCoin || itemState.type == ItemType.UtilityPrestigePoint))
		{
			double num = double.MaxValue;
			maxCount = num;
			OnMaxCountChanged();
			return;
		}
		EntityId key = AsEntity();
		if (parentTown != null)
		{
			if (Crafting.cachedStorageByEntity.TryGetValue(key, out var value))
			{
				foreach (BuildingType item in value)
				{
					maxCount += parentTown.StorageByBuildingType(item);
				}
			}
			maxCount += maxConsumePerSecond * CountableState.gm.ValuePerStorageBoostPerkLevel() * (double)parentTown.LevelOfPerk(PerkType.StorageBoost);
		}
		else
		{
			double num2 = 0.0;
			double num3 = CountableState.gm.ValuePerRailDepot();
			double num4 = 0.0;
			foreach (Town town in CountableState.gm.towns)
			{
				if (town != null)
				{
					num2 += town.StorageByBuildingType(BuildingType.TradingPost);
					num2 += town.StorageByBuildingType(BuildingType.RailDepot);
					num4 += (double)town.NumBuildingsOfType(BuildingType.RailDepot);
				}
			}
			if (num2 <= 0.0)
			{
				num2 = 100.0;
			}
			num2 += num3 * maxConsumePerSecond * num4;
			num2 += maxConsumePerSecond * (double)CountableState.gm.MultiplierForGlobalPerk(PerkType.GlobalTradingCapacity);
			maxCount = num2;
		}
		OnMaxCountChanged();
	}

	public void CalcDisplayStats()
	{
		double num = frameLocalConsumed + frameLocalProduced + frameExported + frameImported;
		if (num > 0.0 && Math.Abs(frameAttemptDelta) / num < 0.01)
		{
			perSecondAttemptedDelta = 0.0;
		}
		else
		{
			perSecondAttemptedDelta = frameAttemptDelta / (double)TimeManager.SimulationDelta;
		}
		if (perSecondAttemptedDelta < 0.0)
		{
			if (countOfDecreaseFrames >= 0)
			{
				showDecreaseWarning = true;
			}
			else
			{
				countOfDecreaseFrames++;
			}
		}
		else
		{
			countOfDecreaseFrames = 0;
			showDecreaseWarning = false;
		}
	}

	public void ClampToMax()
	{
		double num = maxCount + bonusCapacityToApply;
		if (currentCount > num)
		{
			currentCount = num;
		}
	}

	public new virtual void Subtract(double amount)
	{
		currentCount -= amount;
		if (currentCount < minCount)
		{
			currentCount = minCount;
		}
	}

	public override void Reset()
	{
		base.Reset();
		isOutputCapacityInfinite = false;
		isLocked = true;
		flexStorage = 0.0;
		ClearFrameRequestState();
		isInAlertState = false;
		queuedStatValue = 0.0;
		shouldSaveDemandData = false;
	}

	public virtual bool ShouldBeUnlocked()
	{
		if (townProductionStat != null)
		{
			return Math.Floor(townProductionStat.value) >= 0.9900000095367432;
		}
		return true;
	}

	public void Unlock()
	{
		isLocked = false;
		if (GameManager.Instance.gameState == GameState.InGame)
		{
			isInAlertState = true;
			if (parentTown == CountableState.gm.activeTown)
			{
				MenuManager.Instance.OnStateBecameAvailableInActiveTownDuringGame(this);
				CountableState.gm.TryAddUnlock(AsEntity());
			}
		}
	}

	public StateIndicator CurrentStateIndicator()
	{
		_ = debug;
		double num = 1E-05;
		if (perSecondAttemptedDelta > num)
		{
			return StateIndicator.GrowingOrFull;
		}
		if (perSecondAttemptedDelta < 0.0 - num)
		{
			if (frameIsLimitingInput)
			{
				return StateIndicator.Starved;
			}
			return StateIndicator.Decreasing;
		}
		return StateIndicator.Neutral;
	}

	public Color TextColor()
	{
		return CurrentStateIndicator() switch
		{
			StateIndicator.Neutral => ColorManager.positiveRate, 
			StateIndicator.GrowingOrFull => ColorManager.positiveRate, 
			StateIndicator.Decreasing => ColorManager.inventoryDecrease, 
			StateIndicator.Starved => ColorManager.negativeRateFill, 
			_ => Color.white, 
		};
	}

	public Color FillColor()
	{
		return CurrentStateIndicator() switch
		{
			StateIndicator.Neutral => ColorManager.positiveRateFill, 
			StateIndicator.GrowingOrFull => ColorManager.positiveRateFill, 
			StateIndicator.Decreasing => ColorManager.inventoryDecrease, 
			StateIndicator.Starved => ColorManager.negativeRateFill, 
			_ => Color.white, 
		};
	}

	public void OnMaxCountChanged()
	{
		warningMargin = maxCount / 10000.0;
	}

	public bool GetHasPotentialSupply()
	{
		if (currentCount > 0.0)
		{
			return true;
		}
		_ = debug;
		foreach (ItemRateData outputRequester in outputRequesters)
		{
			_ = debug;
			if (outputRequester.parentState != null && outputRequester.parentState.appliedProductionLimit.type == ProductionLimitType.MeetDemand && (outputRequester.parentState.numWorkersAssigned > 0f || outputRequester.parentState.appliedAutoAssign))
			{
				return true;
			}
		}
		return false;
	}

	public void RepeatLastSimulation()
	{
		if (currentCount > 0.0 && !isOutputCapacityInfinite)
		{
			double num = frameDelta / currentCount;
			if (num > 0.01)
			{
				currentCount += frameDelta * (double)TimeManager.repeatSimulationsToRun;
			}
			else if (num < -0.01)
			{
				currentCount += frameDelta * (double)TimeManager.repeatSimulationsToRun;
				if (currentCount < 0.0)
				{
					currentCount = 0.0;
				}
			}
		}
		else if (frameDelta > 0.01)
		{
			currentCount += frameDelta * (double)TimeManager.repeatSimulationsToRun;
		}
		else if (frameDelta < -0.01)
		{
			currentCount += frameDelta * (double)TimeManager.repeatSimulationsToRun;
			if (currentCount < 0.0)
			{
				currentCount = 0.0;
			}
		}
		queuedStatValue += frameStatsAdded * (double)TimeManager.repeatSimulationsToRun;
	}
}
