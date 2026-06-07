using System;
using System.Collections.Generic;
using UnityEngine;

public class StateManager
{
	public float numWorkersAssigned;

	private float overallMultiplier;

	public double inputAmountMultiplier;

	public float outputAmountMultiplier;

	public float xpAmountMultiplier;

	public double potentialWorkUnits;

	public double actualWorkUnits;

	public double actualRecipeUnits;

	public double workUnitsAttempted;

	public double productionRatio;

	private double minInputSupplyRatio;

	private double minOutputCapacityRatio;

	public double inputSupplyRatio;

	public double outputCapacityRatio;

	public double rateCapacityRatio;

	public float baseProductionRate;

	public bool hasZeroInput;

	public bool onlyConsumesSurplus;

	public bool isPassiveProduction;

	public readonly List<ItemRateData> input = new List<ItemRateData>();

	public readonly List<ItemRateData> output = new List<ItemRateData>();

	public float manualProgress;

	public double unitProgress;

	public double cumulativeUnitProgressPrev;

	public double cumulativeUnitProgress;

	public double recipeUnitsPerWorkUnit;

	public double primaryOutputUnitsPerWorkUnit;

	public double workUnitsNeededToAchieveTargetPrimaryOutputRate;

	public ProductionConfig appliedProductionLimit;

	public AffordabilityState inputAffordabilityState;

	public AffordabilityState outputCapacityState;

	public AffordabilityState rateCapacityState;

	public Skill skill;

	public readonly AssignableState localSettings = new AssignableState();

	public bool appliedAutoAssign;

	public bool appliedAutoClaim;

	public bool isInAlertState;

	public bool isLocked;

	public StatePriority appliedPriority;

	public Town parentTown;

	public OverrideState appliedPauseState;

	public readonly List<ProductionModifier> productionSpeedModifiers = new List<ProductionModifier>();

	public List<ProductionModifier> productionAmountModifiers;

	public List<ProductionModifier> inputAmountModifiers;

	public List<ProductionModifier> xpModifiers;

	public bool isUnitProgressHardCapped;

	public bool didAutoAssign;

	public bool ignoreSkillIncrement;

	private bool isLimitedByInput;

	private const float CompletionThreshold = 0.9999f;

	public ItemRateData primaryOutput;

	public ItemRateData limitingFactor;

	public bool recipeDebug;

	public bool autoAssignDebug;

	protected int inputCount;

	protected int outputCount;

	public float recipeMaxRate;

	public double appliedMaxRate;

	public double surplusMaxRate;

	public const float MinTargetRate = 0.1f;

	public const float MinTargetDemandPercent = 0.01f;

	public const float DefaultDemandPercent = 1f;

	public const float DefaultTargetRate = 1f;

	private int autoAssignCountdown;

	private int consecutiveAutoAssignDirection;

	private const int maxWorkToAdd = 5;

	private const int maxWorkToRemove = 5;

	public bool debugAutoTrade;

	public OverrideState localAutoAssign => localSettings.autoAssign.value;

	public OverrideState localAutoClaim => localSettings.autoClaim.value;

	public BuildingState producingBuilding { get; private set; }

	public bool activePauseState { get; protected set; }

	public double displayedProductionRatio
	{
		get
		{
			if (inputAffordabilityState != AffordabilityState.CanFullyProduce)
			{
				return inputSupplyRatio;
			}
			if (outputCapacityState != AffordabilityState.CanFullyProduce)
			{
				if (outputCapacityRatio > 0.0)
				{
					return 1.0 / outputCapacityRatio;
				}
				return 0.0;
			}
			if (rateCapacityState != AffordabilityState.CanFullyProduce)
			{
				if (rateCapacityRatio > 0.0)
				{
					return 1.0 / rateCapacityRatio;
				}
				return 0.0;
			}
			if (appliedProductionLimit.type == ProductionLimitType.TargetRate && workUnitsNeededToAchieveTargetPrimaryOutputRate > 0.0 && TimeManager.SimulationDelta > 0f)
			{
				double num = workUnitsNeededToAchieveTargetPrimaryOutputRate * (double)TimeManager.SimulationDelta;
				return workUnitsAttempted / num;
			}
			return rateCapacityRatio;
		}
	}

	public float displayedRecipeUnitRate
	{
		get
		{
			if (TimeManager.SimulationDelta <= 0f)
			{
				return 0f;
			}
			return GameUtility.AsFloat(actualRecipeUnits / (double)TimeManager.SimulationDelta);
		}
	}

	public float displayedOutputRate
	{
		get
		{
			if (TimeManager.SimulationDelta <= 0f)
			{
				return 0f;
			}
			if (primaryOutput != null)
			{
				return GameUtility.AsFloat(actualWorkUnits * primaryOutput.deltaPerWorkUnit / (double)TimeManager.SimulationDelta);
			}
			return GameUtility.AsFloat(actualRecipeUnits / (double)TimeManager.SimulationDelta);
		}
	}

	public float displayedPotentialRateForPrimaryOutput
	{
		get
		{
			if (TimeManager.SimulationDelta <= 0f)
			{
				return 0f;
			}
			if (primaryOutput != null)
			{
				return GameUtility.AsFloat(potentialWorkUnits * primaryOutput.deltaPerWorkUnit / (double)TimeManager.SimulationDelta);
			}
			return GameUtility.AsFloat(potentialWorkUnits * recipeUnitsPerWorkUnit / (double)TimeManager.SimulationDelta);
		}
	}

	public virtual void Reset()
	{
		isLocked = true;
		localSettings.Reset();
		isInAlertState = false;
		unitProgress = 0.0;
		numWorkersAssigned = 0f;
		activePauseState = false;
		isUnitProgressHardCapped = false;
		cumulativeUnitProgress = 0.0;
		manualProgress = 0f;
		onlyConsumesSurplus = false;
	}

	protected void Initialize()
	{
		localSettings.productionLimit.linkedState = this;
		localSettings.productionLimit.restrictOptions = this is ConstructionState || this is ResearchState;
	}

	protected virtual void ResetMethodB()
	{
	}

	protected void ResetMethodA()
	{
		if (this is SellState sellState)
		{
			sellState.actualSalesPerSecond = 0.0;
		}
	}

	public void ResetProduction()
	{
		actualRecipeUnits = 0.0;
		actualWorkUnits = 0.0;
		potentialWorkUnits = 0.0;
		productionRatio = 0.0;
		inputSupplyRatio = 0.0;
		outputCapacityRatio = 0.0;
		rateCapacityRatio = 0.0;
		minInputSupplyRatio = 0.0;
		minOutputCapacityRatio = 0.0;
		if (this is TradingState { isUseSurplusStale: not false } tradingState)
		{
			tradingState.CalcUseSurplusFlag();
		}
		debugAutoTrade = this is TradingState tradingState2 && tradingState2.itemType == StartupManager.Instance.debugTradeItemType && tradingState2.parentTown == GameManager.Instance.activeTown;
		if (GameManager.DebugResetMethod)
		{
			ResetMethodB();
		}
		else
		{
			ResetMethodA();
		}
		limitingFactor = null;
		inputAffordabilityState = AffordabilityState.None;
		outputCapacityState = AffordabilityState.None;
		rateCapacityState = AffordabilityState.None;
		didAutoAssign = false;
		cumulativeUnitProgressPrev = cumulativeUnitProgress;
		for (int i = 0; i < outputCount; i++)
		{
			output[i].ResetProduction();
		}
		for (int j = 0; j < inputCount; j++)
		{
			input[j].ResetProduction();
		}
	}

	public void AddSkill(SkillType t)
	{
		skill = new Skill(t, SkillEntity());
		parentTown.AddSkill(skill);
		skill.levelUpDelegate = PerformCalcSpeed;
	}

	public void SetProductionBuilding(BuildingState b)
	{
		producingBuilding = b;
		if (!b.dependentStates.Contains(this))
		{
			b.dependentStates.Add(this);
		}
	}

	public void AppendSkill(Skill s)
	{
		skill = s;
		skill.levelUpDelegate = PerformCalcSpeed;
	}

	public virtual void CalcPotentialWorkPerSimulationPass()
	{
		productionRatio = 0.0;
		hasZeroInput = false;
		if (activePauseState)
		{
			potentialWorkUnits = 0.0;
		}
		else if (this is TradingState { activeTradeMode: TradeMode.Off })
		{
			potentialWorkUnits = 0.0;
		}
		else
		{
			potentialWorkUnits = TimeManager.SimulationDelta * numWorkersAssigned;
		}
		double num = potentialWorkUnits / (double)TimeManager.SimulationDelta;
		for (int i = 0; i < outputCount; i++)
		{
			ItemRateData itemRateData = output[i];
			itemRateData.framePotentialAmount = itemRateData.deltaPerWorkUnit * num;
		}
		for (int j = 0; j < inputCount; j++)
		{
			ItemRateData itemRateData2 = input[j];
			itemRateData2.framePotentialAmount = (0.0 - itemRateData2.deltaPerWorkUnit) * num;
		}
		_ = recipeDebug;
	}

	public void RequestOutputCapacity()
	{
		if (!(workUnitsAttempted > 0.0))
		{
			return;
		}
		for (int i = 0; i < outputCount; i++)
		{
			ItemRateData itemRateData = output[i];
			double num = itemRateData.deltaPerWorkUnit * workUnitsAttempted;
			if (num > 0.0)
			{
				ConsumableState state = itemRateData.state;
				state.passOutputCapacityRequested += num;
				_ = state.debug;
			}
			itemRateData.frameRequestAmount = num;
			_ = recipeDebug;
		}
	}

	public void FinalizeOutputRatio()
	{
		outputCapacityState = AffordabilityState.CanFullyProduce;
		minOutputCapacityRatio = 3.4028234663852886E+38;
		for (int i = 0; i < outputCount; i++)
		{
			ItemRateData itemRateData = output[i];
			itemRateData.displayedAffordabilityState = AffordabilityState.CanFullyProduce;
			if (itemRateData.deltaPerWorkUnit <= 0.0)
			{
				continue;
			}
			ConsumableState state = itemRateData.state;
			if (state.passOutputSupplyRatio < minOutputCapacityRatio)
			{
				if (state.passOutputSupplyRatio < 1.0)
				{
					SetLimitingFactor(itemRateData, state.passOutputCapacityState);
				}
				minOutputCapacityRatio = state.passOutputSupplyRatio;
				outputCapacityRatio = state.passOutputSupplyRatio;
			}
			_ = recipeDebug;
			if (state.passOutputCapacityState < outputCapacityState)
			{
				outputCapacityState = itemRateData.state.passOutputCapacityState;
			}
		}
		outputCapacityRatio = minOutputCapacityRatio;
		if (outputCapacityState != AffordabilityState.CanFullyProduce)
		{
			inputSupplyRatio = 1.0;
			inputAffordabilityState = AffordabilityState.CanFullyProduce;
			rateCapacityRatio = 1.0;
			rateCapacityState = AffordabilityState.CanFullyProduce;
			_ = autoAssignDebug;
		}
		if (minOutputCapacityRatio < 1.0)
		{
			workUnitsAttempted *= minOutputCapacityRatio;
			_ = recipeDebug;
		}
	}

	public void ApplyMaxOutput()
	{
		workUnitsAttempted = potentialWorkUnits;
		double num = double.MaxValue;
		appliedMaxRate = double.MaxValue;
		surplusMaxRate = double.MaxValue;
		rateCapacityRatio = 1.0;
		rateCapacityState = AffordabilityState.CanFullyProduce;
		if (this is TradingState tradingState && onlyConsumesSurplus)
		{
			if (tradingState.activeTradeMode == TradeMode.Export)
			{
				surplusMaxRate = tradingState.localItemState.lastFrameSurplus / (double)TimeManager.SimulationDelta;
				if (!debugAutoTrade)
				{
				}
			}
			else if (tradingState.activeTradeMode == TradeMode.Import)
			{
				surplusMaxRate = tradingState.globalWarehouseState.lastFrameSurplus / (double)TimeManager.SimulationDelta;
				_ = debugAutoTrade;
			}
		}
		if (surplusMaxRate < appliedMaxRate)
		{
			appliedMaxRate = surplusMaxRate;
		}
		if (recipeMaxRate > 0f && (double)recipeMaxRate < appliedMaxRate)
		{
			appliedMaxRate = recipeMaxRate;
		}
		if (appliedProductionLimit.type == ProductionLimitType.TargetRate)
		{
			if ((double)appliedProductionLimit.targetRate < appliedMaxRate)
			{
				appliedMaxRate = appliedProductionLimit.targetRate;
				if (appliedMaxRate <= 0.10000000149011612)
				{
					appliedMaxRate = 0.10000000149011612;
				}
			}
		}
		else if (appliedProductionLimit.type == ProductionLimitType.MeetDemand)
		{
			double num2 = ((!(this is SellState sellState)) ? ((double)DemandForPrimaryOutput()) : ((double)sellState.happinessRate));
			num2 = ((!GameUtility.NearlyEquals(appliedProductionLimit.targetDemandPercent, 1f)) ? (num2 * (double)appliedProductionLimit.targetDemandPercent) : (num2 * 1.0001));
			if (num2 < appliedMaxRate)
			{
				appliedMaxRate = num2;
				if (!debugAutoTrade)
				{
				}
			}
		}
		else
		{
			_ = appliedProductionLimit.type;
			_ = 3;
		}
		if (appliedMaxRate < 0.0)
		{
			num = 0.0;
			appliedMaxRate = 0.0;
		}
		else
		{
			num = appliedMaxRate * (double)TimeManager.SimulationDelta;
		}
		if (num < double.MaxValue)
		{
			float num3 = GameUtility.AsFloat(potentialWorkUnits * primaryOutputUnitsPerWorkUnit);
			if (!recipeDebug)
			{
				_ = debugAutoTrade;
			}
			if ((double)num3 > num && num3 > 0f)
			{
				rateCapacityRatio = GameUtility.AsFloat(num / (double)num3);
				rateCapacityState = AffordabilityState.CanPartiallyProduce;
				workUnitsAttempted = potentialWorkUnits * rateCapacityRatio;
				if (!recipeDebug)
				{
					_ = debugAutoTrade;
				}
				if (this is SellState sellState2)
				{
					foreach (ItemRateData item in sellState2.output)
					{
						if (!item.state.isOutputCapacityInfinite)
						{
							SetLimitingFactor(item, rateCapacityState);
							break;
						}
					}
				}
			}
		}
		if (workUnitsAttempted <= 0.0)
		{
			rateCapacityRatio = 0.0;
			rateCapacityState = AffordabilityState.CanNotProduce;
		}
	}

	public void CalcProductionRatio()
	{
		if (inputAffordabilityState != AffordabilityState.CanFullyProduce)
		{
			productionRatio = inputSupplyRatio;
		}
		else if (outputCapacityState != AffordabilityState.CanFullyProduce)
		{
			productionRatio = outputCapacityRatio;
		}
		else if (rateCapacityState != AffordabilityState.CanFullyProduce)
		{
			productionRatio = rateCapacityRatio;
		}
		else if (appliedProductionLimit.type == ProductionLimitType.TargetRate && workUnitsNeededToAchieveTargetPrimaryOutputRate > 0.0 && TimeManager.SimulationDelta > 0f)
		{
			double num = workUnitsNeededToAchieveTargetPrimaryOutputRate * (double)TimeManager.SimulationDelta;
			productionRatio = GameUtility.AsFloat(workUnitsAttempted / num);
			_ = recipeDebug;
		}
		else
		{
			productionRatio = rateCapacityRatio;
		}
	}

	public void RequestInputSupply()
	{
		if (!(workUnitsAttempted > 0.0))
		{
			return;
		}
		for (int i = 0; i < inputCount; i++)
		{
			ItemRateData itemRateData = input[i];
			double num = itemRateData.deltaPerWorkUnit * workUnitsAttempted;
			if (itemRateData.nextFrameReduction > 0.0)
			{
				_ = itemRateData.state.debug;
				num *= 1.0 - itemRateData.nextFrameReduction;
			}
			if (num > 0.0)
			{
				ConsumableState state = itemRateData.state;
				state.passInputSupplyRequested += num;
				_ = state.debug;
			}
			itemRateData.frameRequestAmount = 0.0 - num;
			_ = recipeDebug;
		}
	}

	private void SetLimitingFactor(ItemRateData next, AffordabilityState nextState)
	{
		if (limitingFactor != null)
		{
			limitingFactor.displayedAffordabilityState = AffordabilityState.CanFullyProduce;
		}
		limitingFactor = next;
		limitingFactor.displayedAffordabilityState = nextState;
	}

	public void FinalizeInputRatio()
	{
		inputAffordabilityState = AffordabilityState.CanFullyProduce;
		_ = autoAssignDebug;
		_ = recipeDebug;
		minInputSupplyRatio = 1.0;
		for (int i = 0; i < inputCount; i++)
		{
			ItemRateData itemRateData = input[i];
			itemRateData.displayedAffordabilityState = AffordabilityState.CanFullyProduce;
			ConsumableState state = itemRateData.state;
			_ = recipeDebug;
			if (state.passInputSupplyRatio < minInputSupplyRatio)
			{
				SetLimitingFactor(itemRateData, state.passInputAffordabilityState);
				minInputSupplyRatio = state.passInputSupplyRatio;
				inputSupplyRatio = state.passInputSupplyRatio;
				_ = recipeDebug;
				if (state.isInputSupplyZero)
				{
					hasZeroInput = true;
				}
			}
			inputSupplyRatio = minInputSupplyRatio;
			_ = state.debug;
			if (state.passInputAffordabilityState < inputAffordabilityState)
			{
				inputAffordabilityState = state.passInputAffordabilityState;
				_ = autoAssignDebug;
			}
		}
		if (inputAffordabilityState != AffordabilityState.CanFullyProduce)
		{
			outputCapacityRatio = 1.0;
			rateCapacityRatio = 1.0;
			outputCapacityState = AffordabilityState.CanFullyProduce;
			rateCapacityState = AffordabilityState.CanFullyProduce;
		}
		if (minInputSupplyRatio < 1.0)
		{
			workUnitsAttempted *= minInputSupplyRatio;
			_ = recipeDebug;
		}
	}

	public void Produce()
	{
		_ = recipeDebug;
		if (TimeManager.SimulationDelta <= 0f)
		{
			for (int i = 0; i < inputCount; i++)
			{
				input[i].actualFrameDelta = 0.0;
			}
			for (int j = 0; j < outputCount; j++)
			{
				output[j].actualFrameDelta = 0.0;
			}
			return;
		}
		actualWorkUnits = workUnitsAttempted;
		actualRecipeUnits = workUnitsAttempted * recipeUnitsPerWorkUnit;
		_ = actualRecipeUnits;
		_ = 0.0;
		bool flag = false;
		if (isUnitProgressHardCapped && unitProgress + actualRecipeUnits > 1.0)
		{
			_ = unitProgress;
			_ = actualRecipeUnits;
			double num = actualRecipeUnits;
			actualRecipeUnits = 1.0 - unitProgress;
			flag = true;
			double num2 = actualRecipeUnits / num;
			actualWorkUnits *= num2;
		}
		for (int k = 0; k < inputCount; k++)
		{
			ItemRateData itemRateData = input[k];
			double num3 = actualWorkUnits * itemRateData.deltaPerWorkUnit;
			double amount = potentialWorkUnits * itemRateData.deltaPerWorkUnit;
			ConsumableState state = itemRateData.state;
			_ = state.debug;
			if (itemRateData == limitingFactor)
			{
				ProcessConsume(state, amount);
				state.frameIsLimitingInput = true;
				itemRateData.nextFrameReduction = 0.0;
				if (!state.debug)
				{
				}
			}
			else
			{
				ProcessConsume(state, num3);
				if (inputAffordabilityState != AffordabilityState.CanFullyProduce && inputSupplyRatio < 1.0)
				{
					itemRateData.nextFrameReduction = 1.0 - inputSupplyRatio;
				}
				else
				{
					itemRateData.nextFrameReduction = 0.0;
				}
				_ = state.debug;
			}
			_ = state.debug;
			double num4 = state.ProcessSubtract(num3);
			itemRateData.actualFrameDelta = 0.0 - num4;
			if (this is SellState { marketSellStat: not null } sellState)
			{
				sellState.marketSellStat.value += num3;
			}
			_ = recipeDebug;
		}
		for (int l = 0; l < outputCount; l++)
		{
			ItemRateData itemRateData2 = output[l];
			double amount2 = actualWorkUnits * itemRateData2.deltaPerWorkUnit;
			double amount3 = potentialWorkUnits * itemRateData2.deltaPerWorkUnit;
			ConsumableState state2 = itemRateData2.state;
			_ = state2.debug;
			if (itemRateData2 == limitingFactor)
			{
				ProcessProduce(state2, amount3);
				state2.frameIsLimitingOutput = true;
				if (!state2.debug)
				{
				}
			}
			else
			{
				ProcessProduce(state2, amount2);
			}
			_ = state2.debug;
			_ = state2.debug;
			double num5 = state2.ProcessAdd(amount2);
			if (!(this is TradingState))
			{
				_ = recipeDebug;
				state2.frameStatsAdded = num5;
				state2.queuedStatValue += num5;
			}
			itemRateData2.actualFrameDelta = num5;
			_ = recipeDebug;
		}
		if (!ignoreSkillIncrement && skill != null)
		{
			double num6 = ((primaryOutput == null) ? (actualWorkUnits * (double)outputAmountMultiplier) : (primaryOutput.deltaPerWorkUnit * actualWorkUnits));
			skill.Increment(num6);
			skill.lastSkillGained = num6;
		}
		unitProgress += actualRecipeUnits;
		if (this is SellState sellState2)
		{
			sellState2.actualSalesPerSecond = actualRecipeUnits / (double)TimeManager.SimulationDelta;
		}
		if (this is ConstructionState constructionState)
		{
			cumulativeUnitProgress = constructionState.parentBuildingState.currentCount + unitProgress;
			if (GameUtility.IsNearlyZero(cumulativeUnitProgressPrev))
			{
				cumulativeUnitProgressPrev = constructionState.parentBuildingState.currentCount;
			}
		}
		else if (inputAffordabilityState == AffordabilityState.CanPartiallyProduce && actualRecipeUnits > 0.10000000149011612)
		{
			cumulativeUnitProgress += 0.10000000149011612;
		}
		else if (actualRecipeUnits > 1.0)
		{
			cumulativeUnitProgress += 1.0;
		}
		else
		{
			cumulativeUnitProgress += actualRecipeUnits;
		}
		if (unitProgress >= 1.0 || flag)
		{
			if (unitProgress < 1.0)
			{
				unitProgress = 1.0;
			}
			OnUnitCompleted();
		}
		else if (unitProgress < 0.0)
		{
			unitProgress = 0.0;
		}
	}

	private void ProcessProduce(ConsumableState consumable, double amount)
	{
		consumable.frameAttemptDelta += amount;
		if (this is TradingState && consumable.parentTown != null)
		{
			consumable.frameImported = amount;
		}
		else
		{
			consumable.frameLocalProduced += amount;
		}
		_ = consumable.debug;
	}

	private void ProcessConsume(ConsumableState consumable, double amount)
	{
		consumable.frameAttemptDelta -= amount;
		if (!onlyConsumesSurplus)
		{
			consumable.activeFrameConsumption += amount;
		}
		if (this is TradingState && consumable.parentTown != null)
		{
			consumable.frameExported = amount;
		}
		else
		{
			consumable.frameLocalConsumed += amount;
		}
		_ = consumable.debug;
	}

	public void RepeatLastSimulation()
	{
		double num = actualRecipeUnits * (double)TimeManager.repeatSimulationsToRun;
		if (num <= 0.0)
		{
			return;
		}
		if (TimeManager.isTestingRepeatCapacity)
		{
			if (unitProgress + num > 1.0)
			{
				TimeManager.repeatSimulationsToRun = GameUtility.AsTruncatedFloat((1.0 - unitProgress) / actualRecipeUnits);
			}
			return;
		}
		unitProgress += num;
		if (unitProgress >= 1.0)
		{
			unitProgress = 1.0;
			OnUnitCompleted();
		}
	}

	protected virtual void OnUnitCompleted()
	{
		unitProgress %= 1.0;
	}

	public bool CanBeginCraft()
	{
		for (int i = 0; i < input.Count; i++)
		{
			if (input[i].state.IsEmpty())
			{
				return false;
			}
		}
		return true;
	}

	private void ManualProductionClear()
	{
		for (int i = 0; i < input.Count; i++)
		{
			input[i].state.ClearFrameRequestState();
		}
		for (int j = 0; j < output.Count; j++)
		{
			output[j].state.ClearFrameRequestState();
		}
	}

	public void AutoAssignNumWorkers(float nextValue)
	{
		autoAssignCountdown = 0;
		didAutoAssign = true;
		bool num = GameUtility.IsNearlyZero(numWorkersAssigned);
		float num2 = nextValue - numWorkersAssigned;
		numWorkersAssigned = nextValue;
		if (num != GameUtility.IsNearlyZero(numWorkersAssigned))
		{
			parentTown.SetMetadataFlag(2048);
			parentTown.SetMetadataFlag(4096);
		}
		if (producingBuilding != null)
		{
			producingBuilding.numAvailable -= num2;
			if (!parentTown.numWorkersChangedMetadataQueue.Contains(producingBuilding))
			{
				parentTown.numWorkersChangedMetadataQueue.Add(producingBuilding);
			}
		}
		if (GameUtility.IsNearlyZero(numWorkersAssigned))
		{
			ResetAffordability();
		}
	}

	public void OnNumWorkersChanged(float nextValue)
	{
		didAutoAssign = false;
		if (MenuManager.Instance.isHighlightingWorkerAssignment && nextValue > (float)Quest.NumWorkersToAssign)
		{
			MenuManager.Instance.isHighlightingWorkerAssignment = false;
		}
		bool num = GameUtility.IsNearlyZero(numWorkersAssigned);
		numWorkersAssigned = nextValue;
		if (num != GameUtility.IsNearlyZero(numWorkersAssigned))
		{
			parentTown.SetMetadataFlag(2048);
			parentTown.SetMetadataFlag(4096);
		}
		if (producingBuilding != null)
		{
			parentTown.CalcUnassignedBuildings(producingBuilding);
			producingBuilding.CacheRemovalState(UserInput.activeGlobalIncrement);
		}
		if (GameUtility.IsNearlyZero(numWorkersAssigned))
		{
			ResetAffordability();
		}
	}

	public virtual void CalcOptimalWorkers()
	{
		if (autoAssignCountdown > 0)
		{
			autoAssignCountdown--;
			return;
		}
		autoAssignCountdown = 5;
		if (activePauseState || isLocked || TimeManager.SimulationDelta <= 0f)
		{
			return;
		}
		double num = 0.0;
		if (producingBuilding != null)
		{
			num = producingBuilding.numAvailable;
		}
		if (this is ResearchState researchState)
		{
			float num2 = researchState.CurrentMaxWorkers() - numWorkersAssigned;
			if ((double)num2 < num && num2 >= 0f)
			{
				num = num2;
			}
		}
		_ = autoAssignDebug;
		float num3 = 1f;
		if (this is TradingState { activeTradeMode: TradeMode.Off })
		{
			consecutiveAutoAssignDirection = 0;
			if (numWorkersAssigned > 0f)
			{
				AutoAssignNumWorkers(0f);
			}
		}
		else if (inputAffordabilityState == AffordabilityState.CanNotProduce)
		{
			consecutiveAutoAssignDirection = 0;
			if (numWorkersAssigned <= 0f || !hasZeroInput)
			{
				return;
			}
			foreach (ItemRateData item in input)
			{
				if (item.state.GetHasPotentialSupply())
				{
					_ = autoAssignDebug;
					return;
				}
			}
			_ = autoAssignDebug;
			AutoAssignNumWorkers(0f);
		}
		else if (outputCapacityState == AffordabilityState.CanNotProduce)
		{
			consecutiveAutoAssignDirection = 0;
			if (!(numWorkersAssigned <= 0f))
			{
				_ = autoAssignDebug;
				AutoAssignNumWorkers(0f);
			}
		}
		else if (rateCapacityState == AffordabilityState.CanNotProduce)
		{
			consecutiveAutoAssignDirection = 0;
			if (!(numWorkersAssigned <= 0f))
			{
				_ = autoAssignDebug;
				AutoAssignNumWorkers(0f);
			}
		}
		else if (numWorkersAssigned <= 0f)
		{
			if (this is TradingState { appliedTradeMode: TradeMode.AutoTradeGlobalBalance, activeTradeMode: TradeMode.Import } tradingState2 && tradingState2.globalWarehouseState.lastFrameSurplus <= 0.0)
			{
				_ = autoAssignDebug;
			}
			else
			{
				if (!(num >= (double)num3))
				{
					return;
				}
				foreach (ItemRateData item2 in input)
				{
					if (autoAssignDebug)
					{
						foreach (ItemRateData outputRequester in item2.state.outputRequesters)
						{
							_ = outputRequester;
						}
					}
					if (!item2.state.GetHasPotentialSupply())
					{
						_ = autoAssignDebug;
						consecutiveAutoAssignDirection = 0;
						return;
					}
				}
				foreach (ItemRateData item3 in output)
				{
					if (autoAssignDebug)
					{
						_ = item3.state.isOutputCapacityInfinite;
					}
					if (item3.state.currentCount >= item3.state.maxCount * 0.9999)
					{
						if (autoAssignDebug)
						{
							_ = item3.state.isOutputCapacityInfinite;
						}
						consecutiveAutoAssignDirection = 0;
						return;
					}
				}
				if (appliedProductionLimit.type == ProductionLimitType.MeetDemand && DemandForPrimaryOutput() <= 0f)
				{
					_ = autoAssignDebug;
					consecutiveAutoAssignDirection = 0;
				}
				else
				{
					_ = autoAssignDebug;
					AutoAssignNumWorkers(numWorkersAssigned + num3);
				}
			}
		}
		else if (rateCapacityState != AffordabilityState.CanFullyProduce)
		{
			RemoveWorkersToMatchRatio(rateCapacityRatio);
		}
		else if (outputCapacityState != AffordabilityState.CanFullyProduce)
		{
			RemoveWorkersToMatchRatio(outputCapacityRatio);
		}
		else if (inputAffordabilityState != AffordabilityState.CanFullyProduce)
		{
			RemoveWorkersToMatchRatio(inputSupplyRatio);
		}
		else
		{
			if (!(num >= (double)num3))
			{
				return;
			}
			if (autoAssignDebug)
			{
				foreach (ItemRateData item4 in input)
				{
					_ = item4;
				}
			}
			int num4 = Mathf.FloorToInt(GameUtility.AsFloat(num));
			if (num4 > 5)
			{
				num4 = 5;
			}
			int num5 = 1;
			if (outputCapacityRatio > 1.0)
			{
				double num6 = outputCapacityRatio - 1.0;
				if (num6 * (double)numWorkersAssigned < (double)num4)
				{
					num5 = Mathf.CeilToInt(GameUtility.AsTruncatedFloat(num6 * (double)numWorkersAssigned));
					if (!autoAssignDebug)
					{
					}
				}
				else
				{
					num5 = num4;
					_ = autoAssignDebug;
				}
			}
			_ = autoAssignDebug;
			if (num5 > 0)
			{
				if (consecutiveAutoAssignDirection <= 0)
				{
					ClampAutoAssignRepeats();
					_ = autoAssignDebug;
					consecutiveAutoAssignDirection++;
					return;
				}
				if (num5 > consecutiveAutoAssignDirection)
				{
					num5 = consecutiveAutoAssignDirection;
					_ = autoAssignDebug;
				}
				if (numWorkersAssigned < 20f)
				{
					num5 = 1;
				}
				else if (numWorkersAssigned < 50f && num5 > 2)
				{
					num5 = 2;
				}
				AutoAssignNumWorkers(numWorkersAssigned + (float)num5);
				consecutiveAutoAssignDirection++;
			}
			else
			{
				consecutiveAutoAssignDirection = 0;
			}
		}
	}

	private void ClampAutoAssignRepeats()
	{
		consecutiveAutoAssignDirection = Mathf.Clamp(consecutiveAutoAssignDirection, -2, 2);
	}

	private void RemoveWorkersToMatchRatio(double ratio)
	{
		_ = autoAssignDebug;
		if (numWorkersAssigned <= 1f || ratio >= 1.0)
		{
			_ = autoAssignDebug;
			consecutiveAutoAssignDirection = 0;
			return;
		}
		int num = Mathf.FloorToInt(GameUtility.AsTruncatedFloat((1.0 - ratio) * (double)numWorkersAssigned) - 0.05f);
		_ = autoAssignDebug;
		int num2 = Mathf.RoundToInt(numWorkersAssigned - 1f);
		if (num > num2)
		{
			num = num2;
		}
		_ = autoAssignDebug;
		if (num > 5)
		{
			num = 5;
		}
		if (num > 0)
		{
			_ = autoAssignDebug;
			_ = autoAssignDebug;
			if (consecutiveAutoAssignDirection >= 0)
			{
				ClampAutoAssignRepeats();
				consecutiveAutoAssignDirection--;
				_ = autoAssignDebug;
				return;
			}
			int num3 = -consecutiveAutoAssignDirection;
			if (num > num3)
			{
				num = num3;
				_ = autoAssignDebug;
			}
			if (numWorkersAssigned < 20f)
			{
				num = 1;
			}
			else if (numWorkersAssigned < 50f && num > 2)
			{
				num = 2;
			}
			AutoAssignNumWorkers(numWorkersAssigned - (float)num);
			consecutiveAutoAssignDirection--;
		}
		else
		{
			consecutiveAutoAssignDirection = 0;
		}
	}

	private void ResetAffordability()
	{
		for (int i = 0; i < input.Count; i++)
		{
			input[i].displayedAffordabilityState = AffordabilityState.CanFullyProduce;
		}
		for (int j = 0; j < output.Count; j++)
		{
			output[j].displayedAffordabilityState = AffordabilityState.CanFullyProduce;
		}
	}

	public virtual EntityId AsEntity()
	{
		return EntityId.None;
	}

	public virtual EntityId SkillEntity()
	{
		return EntityId.None;
	}

	public virtual bool IsWorkerAssignment()
	{
		return producingBuilding == null;
	}

	public void CalcAvailability()
	{
		if (isLocked && ShouldBeAvailable())
		{
			Unlock();
		}
	}

	protected virtual bool ShouldBeAvailable()
	{
		return false;
	}

	public override string ToString()
	{
		return AsEntity().ToString();
	}

	public float UnitProgressPercent()
	{
		return GameUtility.AsFloat(Math.Floor(unitProgress * 100.0) / 100.0);
	}

	public AssignableState DerivedParentAssignable()
	{
		if (producingBuilding != null)
		{
			return producingBuilding.settings;
		}
		if (IsWorkerAssignment())
		{
			return parentTown.workerState.settings;
		}
		return null;
	}

	public void Unlock()
	{
		isLocked = false;
		if (GameManager.Instance.gameState == GameState.InGame && !parentTown.suppressUnlockNotifications)
		{
			OnBecameAvailableDuringGame();
		}
		parentTown?.SetMetadataFlag(2048);
	}

	protected virtual void OnBecameAvailableDuringGame()
	{
		isInAlertState = true;
		parentTown?.SetMetadataFlag(65536);
		parentTown?.SetMetadataFlag(2048);
		GameManager.Instance.TryAddUnlock(AsEntity());
		if (parentTown == GameManager.Instance.activeTown)
		{
			MenuManager.Instance.OnStateBecameAvailableInActiveTownDuringGame(this);
		}
	}

	public virtual void StoreItemStateCache()
	{
		RemoveSelfFromRequesters();
		input.Clear();
		output.Clear();
		inputCount = 0;
		outputCount = 0;
		if (skill != null)
		{
			skill.skillGainSpeedResearch = parentTown.research[ResearchType.InfiniteSkillGainSpeed];
			switch (skill.skillType)
			{
			case SkillType.Harvesting:
				skill.productionUpgrade = parentTown.upgrades[UpgradeType.SkillEffectHarvesting];
				break;
			case SkillType.Crafting:
				skill.productionUpgrade = parentTown.upgrades[UpgradeType.SkillEffectCrafting];
				break;
			case SkillType.Cultivation:
				skill.productionUpgrade = parentTown.upgrades[UpgradeType.SkillEffectCultivation];
				break;
			case SkillType.Prospecting:
				skill.productionUpgrade = parentTown.upgrades[UpgradeType.SkillEffectProspecting];
				break;
			}
			skill.skillGainSpeedUpgrade = parentTown.upgrades[UpgradeType.SkillGainSpeed];
		}
	}

	protected void StoreItemStateCacheRecipe(Recipe r)
	{
		RemoveSelfFromRequesters();
		input.Clear();
		output.Clear();
		inputCount = 0;
		outputCount = 0;
		primaryOutput = null;
		baseProductionRate = r.GetBaseProductionRate();
		foreach (KeyValuePair<ItemType, double> item in r.inputs.items)
		{
			if (parentTown.inventory.TryGetValue(item.Key, out var value))
			{
				AddInput(value, item.Value, baseProductionRate);
			}
		}
		foreach (KeyValuePair<ItemType, double> item2 in r.outputs.items)
		{
			if (parentTown.inventory.TryGetValue(item2.Key, out var value2))
			{
				AddOutput(value2, item2.Value, baseProductionRate);
			}
		}
		if (outputCount == 1)
		{
			primaryOutput = output[0];
		}
		double num = 0.0;
		foreach (KeyValuePair<ItemType, double> item3 in r.outputs.items)
		{
			num += Crafting.SpecifiedXPValue(item3.Key) * item3.Value;
		}
		ItemState cachedTownXPState = parentTown.cachedTownXPState;
		AddOutput(cachedTownXPState, num, baseProductionRate, isRounded: true);
	}

	protected void AddInput(ConsumableState s, double baseAmount, float baseRatePerWorkUnit)
	{
		ItemRateData i = new ItemRateData(s, baseAmount, baseRatePerWorkUnit, this);
		AddInput(i);
	}

	protected void AddOutput(ConsumableState s, double baseAmount, float baseRatePerWorkUnit, bool isRounded = false)
	{
		ItemRateData itemRateData = new ItemRateData(s, baseAmount, baseRatePerWorkUnit, this);
		itemRateData.isRounded = false;
		itemRateData.CalcTotalAmount();
		AddOutput(itemRateData);
	}

	protected void AddInput(ItemRateData i)
	{
		i.state.inputRequesters.Add(i);
		input.Add(i);
		inputCount = input.Count;
	}

	protected void AddOutput(ItemRateData o)
	{
		o.state.outputRequesters.Add(o);
		output.Add(o);
		outputCount = output.Count;
	}

	public virtual void LoadModifiers()
	{
		if (skill != null)
		{
			AddModifier(skill);
		}
		AddModifier(PerkType.GlobalXPBoost, ModifierType.XP);
		AddModifier(PerkType.TownXPBoost, ModifierType.XP);
		AddModifier(BuildingType.MagicObelisk, ModifierType.XP);
		if (GameManager.Instance.gameModifierDifficulty == GameModifier.EasyMode)
		{
			AddModifier(GameModifier.EasyMode, 2f, ModifierType.XP);
		}
		else if (GameManager.Instance.gameModifierDifficulty == GameModifier.HardMode)
		{
			AddModifier(GameModifier.HardMode, 0.5f, ModifierType.XP);
		}
	}

	protected void AddModifier(Skill s)
	{
		ProductionModifierSkill item = new ProductionModifierSkill(s);
		productionSpeedModifiers.Add(item);
	}

	protected void AddModifier(PerkType t)
	{
		PerkState value2;
		if (Perk.IsGlobal(t))
		{
			if (GameManager.Instance.globalPerks.TryGetValue(t, out var value))
			{
				ProductionModifierPerk item = new ProductionModifierPerk(value);
				productionSpeedModifiers.Add(item);
			}
		}
		else if (parentTown.townPerks.TryGetValue(t, out value2))
		{
			ProductionModifierPerk item2 = new ProductionModifierPerk(value2);
			productionSpeedModifiers.Add(item2);
		}
	}

	protected void AddModifier(BuildingType t, ModifierType modifierType)
	{
		List<ProductionModifier> list = TargetListForModifierType(modifierType);
		ProductionModifierBuildingCount item = new ProductionModifierBuildingCount(parentTown, t);
		list.Add(item);
	}

	protected void AddModifier(ResearchType t, ModifierType modifierType)
	{
		List<ProductionModifier> list = TargetListForModifierType(modifierType);
		if (parentTown.research.TryGetValue(t, out var value))
		{
			ProductionModifierResearch item = new ProductionModifierResearch(value);
			list.Add(item);
		}
	}

	private List<ProductionModifier> TargetListForModifierType(ModifierType type)
	{
		return type switch
		{
			ModifierType.InputAmount => inputAmountModifiers ?? (inputAmountModifiers = new List<ProductionModifier>()), 
			ModifierType.OutputAmount => productionAmountModifiers ?? (productionAmountModifiers = new List<ProductionModifier>()), 
			ModifierType.XP => xpModifiers ?? (xpModifiers = new List<ProductionModifier>()), 
			ModifierType.Speed => productionSpeedModifiers, 
			_ => productionSpeedModifiers, 
		};
	}

	protected void AddModifier(PerkType t, ModifierType type = ModifierType.Speed)
	{
		if (t == PerkType.None)
		{
			Debug.LogError("Tried to add None upgrade to " + this);
		}
		List<ProductionModifier> list = TargetListForModifierType(type);
		PerkState value2;
		if (Perk.IsGlobal(t))
		{
			if (GameManager.Instance.globalPerks.TryGetValue(t, out var value))
			{
				ProductionModifierPerk item = new ProductionModifierPerk(value);
				list.Add(item);
			}
		}
		else if (parentTown.townPerks.TryGetValue(t, out value2))
		{
			ProductionModifierPerk item2 = new ProductionModifierPerk(value2);
			list.Add(item2);
		}
	}

	protected void AddModifier(GameModifier t, float effect, ModifierType type = ModifierType.Speed)
	{
		List<ProductionModifier> list = TargetListForModifierType(type);
		ProductionModifierGameModifier item = new ProductionModifierGameModifier(t, effect);
		list.Add(item);
	}

	protected void AddModifier(UpgradeType t, ModifierType type = ModifierType.Speed)
	{
		if (t == UpgradeType.None)
		{
			Debug.LogError("Tried to add None upgrade to " + this);
		}
		List<ProductionModifier> list = TargetListForModifierType(type);
		if (parentTown.upgrades.TryGetValue(t, out var value))
		{
			ProductionModifierUpgrade item = new ProductionModifierUpgrade(value);
			list.Add(item);
		}
	}

	protected void AddModifier(BiomeModifierType modifierType, ProductionModifier m)
	{
		switch (modifierType)
		{
		case BiomeModifierType.CraftingSpeed:
			productionSpeedModifiers.Add(m);
			break;
		case BiomeModifierType.CultivationProductivity:
		case BiomeModifierType.ProspectingProductivity:
		case BiomeModifierType.RecipeProductivity:
		case BiomeModifierType.UniqueResource:
			AddOutputAmountModifier(m);
			break;
		}
	}

	protected void AddInputAmountModifier(ProductionModifier m)
	{
		if (inputAmountModifiers == null)
		{
			inputAmountModifiers = new List<ProductionModifier>();
		}
		inputAmountModifiers.Add(m);
	}

	protected void AddOutputAmountModifier(ProductionModifier m)
	{
		if (productionAmountModifiers == null)
		{
			productionAmountModifiers = new List<ProductionModifier>();
		}
		productionAmountModifiers.Add(m);
	}

	protected void AddModifier(BuildingType t)
	{
		ProductionModifierBuildingCount item = new ProductionModifierBuildingCount(parentTown, t);
		productionSpeedModifiers.Add(item);
	}

	public void AddBiomeModifier(BiomeType b, BiomeModifier m)
	{
		ProductionModifierBiome m2 = new ProductionModifierBiome(b, m);
		AddModifier(m.effect, m2);
	}

	public void PerformCalcSpeed()
	{
		CalcSpeed();
		ApplySpeedToRecipe();
	}

	protected virtual void CalcSpeed()
	{
		CalcAppliedPauseState();
		overallMultiplier = 1f;
		inputAmountMultiplier = 1.0;
		outputAmountMultiplier = 1f;
		xpAmountMultiplier = 1f;
		foreach (ProductionModifier productionSpeedModifier in productionSpeedModifiers)
		{
			productionSpeedModifier.CalcMultiplier();
			overallMultiplier *= productionSpeedModifier.multiplier;
		}
		if (inputAmountModifiers != null)
		{
			foreach (ProductionModifier inputAmountModifier in inputAmountModifiers)
			{
				inputAmountModifier.CalcMultiplier();
				inputAmountMultiplier *= GameUtility.RoundedDoubleFromFloat(inputAmountModifier.multiplier);
			}
		}
		if (productionAmountModifiers != null)
		{
			foreach (ProductionModifier productionAmountModifier in productionAmountModifiers)
			{
				productionAmountModifier.CalcMultiplier();
				outputAmountMultiplier *= productionAmountModifier.multiplier;
			}
		}
		if (xpModifiers == null)
		{
			return;
		}
		foreach (ProductionModifier xpModifier in xpModifiers)
		{
			xpModifier.CalcMultiplier();
			xpAmountMultiplier *= xpModifier.multiplier;
		}
	}

	public void ApplySpeedToRecipe()
	{
		foreach (ItemRateData item in input)
		{
			item.SetProductionMultiplier(overallMultiplier);
			bool flag = this is TradingState;
			if (item.state is ItemState itemState && !flag && (itemState.type == ItemType.Fire || itemState.type == ItemType.Steam || itemState.type == ItemType.Power))
			{
				item.SetAmountMultiplier(inputAmountMultiplier * (double)parentTown.MultiplierForUpgrade(UpgradeType.FuelEfficiency));
			}
			else
			{
				item.SetAmountMultiplier(inputAmountMultiplier);
			}
		}
		foreach (ItemRateData item2 in output)
		{
			item2.SetProductionMultiplier(overallMultiplier);
			if (item2.state is ItemState { type: ItemType.TownExperiencePoint })
			{
				if (this is SellState)
				{
					item2.SetAmountMultiplier(xpAmountMultiplier);
				}
				else
				{
					item2.SetAmountMultiplier(xpAmountMultiplier * outputAmountMultiplier);
				}
			}
			else
			{
				item2.SetAmountMultiplier(outputAmountMultiplier);
			}
		}
		recipeUnitsPerWorkUnit = baseProductionRate * overallMultiplier;
		if (this is SellState)
		{
			primaryOutputUnitsPerWorkUnit = recipeUnitsPerWorkUnit;
		}
		else if (primaryOutput != null)
		{
			primaryOutputUnitsPerWorkUnit = GameUtility.AsFloat(primaryOutput.deltaPerWorkUnit);
		}
		else
		{
			primaryOutputUnitsPerWorkUnit = recipeUnitsPerWorkUnit * (double)outputAmountMultiplier;
		}
		if (primaryOutputUnitsPerWorkUnit > 0.0 && appliedProductionLimit.type == ProductionLimitType.TargetRate)
		{
			workUnitsNeededToAchieveTargetPrimaryOutputRate = (double)appliedProductionLimit.targetRate / primaryOutputUnitsPerWorkUnit;
		}
	}

	public void CyclePriority()
	{
		localSettings.CyclePriority();
	}

	public void CalcAppliedPauseState()
	{
		appliedPauseState = localSettings.DerivedPause();
		activePauseState = appliedPauseState == OverrideState.On;
	}

	public void CalcAppliedAutoClaim()
	{
		appliedAutoClaim = localSettings.DerivedAutoClaim() == OverrideState.On;
		if (GameManager.GameState == GameState.InGame && appliedAutoClaim && this is ResearchState { isReadyToClaim: not false } researchState)
		{
			researchState.Claim();
		}
	}

	public void CalcAppliedAutoAssign()
	{
		if (isLocked)
		{
			appliedAutoAssign = false;
		}
		else if (this is ResearchState researchState && (researchState.isReadyToClaim || researchState.availability != BuildObjectAvailability.Available))
		{
			appliedAutoAssign = false;
		}
		else
		{
			appliedAutoAssign = localSettings.DerivedAutoAssign() == OverrideState.On;
		}
	}

	public void CalcAppliedProductionLimit()
	{
		appliedProductionLimit = localSettings.DerivedProductionConfig();
	}

	public void CalcAppliedPriority()
	{
		appliedPriority = localSettings.DerivedPriority();
	}

	public bool AreAllInputsPositive()
	{
		return true;
	}

	public bool AcceptsWorkers()
	{
		if (this is AutoHarvestState)
		{
			return false;
		}
		if (this is ResearchState { availability: not BuildObjectAvailability.Available })
		{
			return false;
		}
		return true;
	}

	public float DemandForPrimaryOutput()
	{
		if (this is SellState sellState)
		{
			return sellState.happinessRate;
		}
		if (primaryOutput == null || TimeManager.SimulationDelta <= 0f)
		{
			_ = debugAutoTrade;
			return 0f;
		}
		primaryOutput.state.shouldSaveDemandData = true;
		return GameUtility.AsFloat(primaryOutput.state.lastFrameDemand / (double)TimeManager.SimulationDelta);
	}

	public void RemoveSelfFromRequesters()
	{
		foreach (ItemRateData item in input)
		{
			item.state.inputRequesters.RemoveAll((ItemRateData x) => x.parentState == this);
		}
		foreach (ItemRateData item2 in output)
		{
			item2.state.outputRequesters.RemoveAll((ItemRateData x) => x.parentState == this);
		}
	}

	public bool HideInTooltip()
	{
		if (isLocked)
		{
			return true;
		}
		if (this is ResearchState researchState)
		{
			if (researchState.availability != BuildObjectAvailability.Available)
			{
				return true;
			}
			if (researchState.numWorkersAssigned <= 0f)
			{
				return true;
			}
		}
		else if (this is ConstructionState { numWorkersAssigned: <=0f })
		{
			return true;
		}
		return false;
	}

	public bool ContainsInputOrOutput(ConsumableState testState)
	{
		foreach (ItemRateData item in input)
		{
			if (item.state == testState)
			{
				return true;
			}
		}
		foreach (ItemRateData item2 in output)
		{
			if (item2.state == testState)
			{
				return true;
			}
		}
		return false;
	}

	public void RecalcXP()
	{
		foreach (ItemRateData item in output)
		{
			if (item.state is ItemState { type: ItemType.TownExperiencePoint })
			{
				item.CalcPerSecond();
			}
		}
	}
}
