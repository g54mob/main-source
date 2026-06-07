using UnityEngine;

[CreateAssetMenu(menuName = "Data/Simulation/Hype", fileName = "HypeSimulation")]
public class HypeSimulation : ScriptableObject, IIncrementalSimulation
{
	public void Registered(UIRegistry? _)
	{
	}

	public void Unregistered()
	{
	}

	public void OnUpdateSimulation(float deltaTime)
	{
		float value = ModifierType.Hype.Float() + CalculateLowLoadBonus() - CalculatePingImpact() - CalculateBugImpact() + CalculateAuctionHouseImpact();
		Database.State.Resources.TargetHype.SetValue(Mathf.Clamp(value, ModifierType.HypeMinimum.Float(), ModifierType.HypeMaximum.Float()));
		if (Database.State.Game.Launched.Value)
		{
			Database.State.Resources.Hype.SetValue(Mathf.MoveTowards(Database.State.Resources.Hype.Value, Database.State.Resources.TargetHype.Value, ModifierType.HypeChangeSpeed.Float() * deltaTime));
		}
		else
		{
			Database.State.Resources.Hype.SetValue(Database.State.Resources.TargetHype.Value);
		}
	}

	private float CalculateLowLoadBonus()
	{
		float value = Database.State.Resources.Load.Value;
		if (value >= 0.7f)
		{
			return 0f;
		}
		float num = 1f - Mathf.InverseLerp(0f, 0.7f, value);
		return ModifierType.HypeLowLoadBonus.Float() * num * num;
	}

	private float CalculatePingImpact()
	{
		float value = Database.State.Resources.Ping.Value;
		float num = ModifierType.HypePingMinorTolerance.Float();
		if (value <= num)
		{
			float t = Mathf.Clamp01(value / num);
			return Mathf.Lerp(0f - ModifierType.HypePingLowBonus.Float(), 0f, t);
		}
		float num2 = ModifierType.HypePingMajorTolerance.Float();
		if (value <= num2)
		{
			float t2 = Mathf.InverseLerp(num, num2, value);
			return Mathf.Lerp(0f, ModifierType.HypePingMinorImpact.Float(), t2);
		}
		float num3 = value - num2;
		float num4 = num3 / Mathf.Max(1f, ModifierType.HypePingMajorImpact.Float());
		return ModifierType.HypePingMinorImpact.Float() + num4 * (1f + num3 / Mathf.Max(1f, num2));
	}

	private float CalculateBugImpact()
	{
		float num = Database.Derived.BugSoftCapacity.CurrentValue * ModifierType.HypeBugBonusThreshold.Float();
		if (num > 0f && Database.State.Resources.Bugs.Value <= num)
		{
			float num2 = 1f - Database.State.Resources.Bugs.Value / num;
			return (0f - num2 * num2) * ModifierType.HypeBugBonus.Float();
		}
		return MathUtility.Pressure(Database.State.Resources.Bugs.Value, ModifierType.HypeBugTolerance) * ModifierType.HypeBugPenalty.Float();
	}

	private float CalculateAuctionHouseImpact()
	{
		if (!Database.State.Research.IsUnlocked(ResearchNode.AuctionHouse))
		{
			return 0f;
		}
		return AuctionUtility.GetHypeOffsetFromAlignment(Database.State.Auction);
	}
}
