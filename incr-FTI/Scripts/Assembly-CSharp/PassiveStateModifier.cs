using System.Collections.Generic;

public class PassiveStateModifier : ItemRateData
{
	public float baselineRate;

	public float rate;

	public EntityId tooltipEntity;

	public List<ProductionModifier> productionModifiers;

	public PassiveStateModifier(ConsumableState stateToModify)
	{
		state = stateToModify;
		state.outputRequesters.Add(this);
	}

	public void LoadModifiers(Town parentTown)
	{
		if (productionModifiers == null)
		{
			productionModifiers = new List<ProductionModifier>();
		}
		float countMultiplier = 0.05f;
		if (state is ResourceState { type: NaturalResource.Tree })
		{
			countMultiplier = 0.01f;
		}
		productionModifiers.Add(new ProductionModifierCountable(parentTown.landState, countMultiplier));
		if (GameManager.Instance.globalPerks.TryGetValue(PerkType.ResourceRegen, out var value))
		{
			productionModifiers.Add(new ProductionModifierPerk(value));
		}
		if (parentTown.research.TryGetValue(ResearchType.InfiniteResourceRegeneration, out var value2))
		{
			productionModifiers.Add(new ProductionModifierResearch(value2));
		}
		if (GameManager.Instance.gameModifierDifficulty == GameModifier.EasyMode)
		{
			productionModifiers.Add(new ProductionModifierGameModifier(GameModifier.EasyMode, 4f));
		}
		else if (GameManager.Instance.gameModifierDifficulty == GameModifier.HardMode)
		{
			productionModifiers.Add(new ProductionModifierGameModifier(GameModifier.EasyMode, 0.5f));
		}
	}

	public void AddModifier(BiomeType b, BiomeModifier m)
	{
		if (productionModifiers == null)
		{
			productionModifiers = new List<ProductionModifier>();
		}
		productionModifiers.Add(new ProductionModifierBiome(b, m));
		CalcRate();
	}

	public void SetBaselineRate(float r)
	{
		baselineRate = r;
		CalcRate();
	}

	public void CalcRate()
	{
		rate = baselineRate;
		if (productionModifiers == null)
		{
			return;
		}
		foreach (ProductionModifier productionModifier in productionModifiers)
		{
			productionModifier.CalcMultiplier();
			rate *= productionModifier.multiplier;
		}
	}

	public void ApplyDelta()
	{
		float num = rate * TimeManager.SimulationDelta;
		frameRequestAmount = num;
		if (GameUtility.IsNearlyZero(num))
		{
			return;
		}
		if (num > 0f)
		{
			state.didProcess = true;
			state.frameAttemptDelta += num;
			state.frameLocalProduced += num;
			_ = state.debug;
			double num2 = state.ProcessAdd(num);
			state.frameStatsAdded = num2;
			state.queuedStatValue += num2;
			actualFrameDelta = num2;
			state.ClampToMax();
		}
		else if (state.currentCount <= 0.0)
		{
			actualFrameDelta = 0.0;
		}
		else
		{
			float num3 = 0f - num;
			state.frameAttemptDelta -= num3;
			state.frameLocalConsumed += num3;
			state.activeFrameConsumption += num3;
			double num4 = state.ProcessSubtract(num3);
			if (TimeManager.SimulationDelta > 0f)
			{
				actualFrameDelta = 0.0 - num4;
			}
			else
			{
				actualFrameDelta = 0.0;
			}
		}
	}
}
