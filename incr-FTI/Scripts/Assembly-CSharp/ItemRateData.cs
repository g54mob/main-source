using System;

public class ItemRateData
{
	public ConsumableState state;

	public readonly StateManager parentState;

	private float rateMultiplier;

	public AffordabilityState displayedAffordabilityState;

	public bool isRounded;

	public double framePotentialAmount;

	public double framePotentialDuringInput;

	public double frameRequestAmount;

	public double actualFrameDelta;

	public double nextFrameReduction;

	public float displayedPercentPotential;

	public double displayedPotentialRate;

	public double totalAmount;

	public double baseAmount { get; private set; }

	public float baseProductionRate { get; private set; }

	public double deltaPerWorkUnit { get; private set; }

	public double amountMultiplier { get; private set; }

	public float totalRate => baseProductionRate * rateMultiplier;

	public double effectiveDemandRate
	{
		get
		{
			if (this == parentState.limitingFactor)
			{
				return parentState.potentialWorkUnits * deltaPerWorkUnit / (double)TimeManager.SimulationDelta;
			}
			return parentState.actualWorkUnits * deltaPerWorkUnit / (double)TimeManager.SimulationDelta;
		}
	}

	protected ItemRateData()
	{
	}

	public ItemRateData(ConsumableState s, double baseAmount, float baseRatePerWorkUnit, StateManager parent)
	{
		state = s;
		parentState = parent;
		this.baseAmount = baseAmount;
		baseProductionRate = baseRatePerWorkUnit;
		displayedAffordabilityState = AffordabilityState.CanFullyProduce;
		amountMultiplier = 1.0;
		CalcTotalAmount();
		rateMultiplier = 1f;
		CalcPerSecond();
	}

	public void ResetProduction()
	{
		framePotentialAmount = 0.0;
		frameRequestAmount = 0.0;
		actualFrameDelta = 0.0;
	}

	public void SetAmountMultiplier(double a)
	{
		amountMultiplier = a;
		CalcTotalAmount();
		CalcPerSecond();
	}

	public void SetProductionMultiplier(float m)
	{
		rateMultiplier = m;
		CalcPerSecond();
	}

	public void CalcTotalAmount()
	{
		if (isRounded)
		{
			totalAmount = Math.Ceiling(baseAmount * amountMultiplier);
		}
		else
		{
			totalAmount = baseAmount * amountMultiplier;
		}
		if (totalAmount > GameUtility.MaxDouble)
		{
			totalAmount = GameUtility.MaxDouble;
		}
	}

	public void CalcPerSecond()
	{
		if (state.postProcessMultiplier > 0.0)
		{
			deltaPerWorkUnit = totalAmount * (double)totalRate * state.postProcessMultiplier;
		}
		else
		{
			deltaPerWorkUnit = totalAmount * (double)totalRate;
		}
	}

	public bool IsCurrency()
	{
		if (state is ItemState itemState)
		{
			return Item.IsCurrency(itemState.type);
		}
		return false;
	}

	public bool IsResearch()
	{
		if (state is ItemState itemState)
		{
			return itemState.type == ItemType.ResearchTomeGeneral;
		}
		return false;
	}

	public void CalcDisplayedRates()
	{
		if (GameUtility.IsNearlyZero(TimeManager.SimulationDelta))
		{
			displayedPotentialRate = 0.0;
			displayedPercentPotential = 0f;
			return;
		}
		double num = Math.Abs(actualFrameDelta / (double)TimeManager.SimulationDelta);
		if (this is PassiveStateModifier passiveStateModifier)
		{
			displayedPotentialRate = passiveStateModifier.rate;
			if (GameUtility.IsNotZero(displayedPotentialRate))
			{
				displayedPercentPotential = GameUtility.AsTruncatedFloat(num / displayedPotentialRate);
			}
		}
		else if (parentState == null || parentState.isLocked)
		{
			displayedPotentialRate = 0.0;
			displayedPercentPotential = 0f;
		}
		else
		{
			if (parentState is SellState { recipeMaxRate: >0f, recipeMaxRate: var recipeMaxRate })
			{
				displayedPotentialRate = (double)recipeMaxRate * deltaPerWorkUnit / parentState.primaryOutputUnitsPerWorkUnit;
			}
			else
			{
				displayedPotentialRate = parentState.potentialWorkUnits * deltaPerWorkUnit / (double)TimeManager.SimulationDelta;
			}
			displayedPercentPotential = GameUtility.AsTruncatedFloat(parentState.displayedProductionRatio);
		}
	}
}
