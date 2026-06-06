using UnityEngine;

[CreateAssetMenu(menuName = "Data/Simulation/Growth", fileName = "GrowthSimulation")]
public class GrowthSimulation : ScriptableObject, IIncrementalSimulation
{
	public void Registered(UIRegistry? _)
	{
	}

	public void Unregistered()
	{
	}

	public void OnUpdateSimulation(float deltaTime)
	{
		if (Database.State.Game.Launched.Value)
		{
			double num = CalculateFansGain() + CalculatePlayersGain() + CalculateDatacenterBonusGrowth(deltaTime) + CalculateCompilePatchBonusGrowth(deltaTime);
			if (num < 0.01)
			{
				num = 0.0;
			}
			double value = num * (double)deltaTime;
			Database.State.Resources.Players.AddValue(value);
			double money = (CalculateMoneyPerSecond(num) + CalculateMoneyPassivePlayers() + CalculateMoneyPassivePreviousReleases()) * (double)deltaTime;
			Database.Commands.Resource.ReceiveMoney(money);
		}
	}

	private double CalculateFansGain()
	{
		float num = ModifierType.LaunchDuration.Float();
		if (Database.State.Game.Time.Value > (double)num)
		{
			return 0.0;
		}
		return Database.State.Prestige.Fans.Value / (double)num;
	}

	private double CalculatePlayersGain()
	{
		float value = Database.State.Resources.Hype.Value;
		float num = ModifierType.Hype.Float();
		float num2 = Mathf.Max(num + 0.01f, ModifierType.HypeMaximum.Float());
		float num3 = Mathf.Clamp01(Mathf.Max(0f, value - num) / (num2 - num));
		float num4 = 1f + num3 * 0.5f;
		double num5 = (double)(ModifierType.PlayersGrowthRate.Float() * value * num4) * MathUtility.Resistance(Database.State.Resources.Players.Value, Database.Derived.MarketCapacity.CurrentValue);
		if (Database.State.Resources.Load.Value <= ModifierType.LoadSoftCapacity.Float())
		{
			return num5;
		}
		if (Database.State.Resources.Load.Value >= ModifierType.LoadHardCapacity.Float())
		{
			return 0.0;
		}
		return num5 * (double)Mathf.SmoothStep(1f, 0f, (Database.State.Resources.Load.Value - ModifierType.LoadSoftCapacity.Float()) / (ModifierType.LoadHardCapacity.Float() - ModifierType.LoadSoftCapacity.Float()));
	}

	private double CalculateDatacenterBonusGrowth(float deltaTime)
	{
		if (!Database.State.Datacenters.BonusGrowthTimer.Value.IsActive)
		{
			return 0.0;
		}
		Database.State.Datacenters.BonusGrowthTimer.AdvanceTimer(deltaTime);
		return ModifierType.DatacenterUnlockGrowthBoost.Double();
	}

	private double CalculateCompilePatchBonusGrowth(float deltaTime)
	{
		if (!Database.State.Debugger.BonusGrowthTimer.Value.IsActive)
		{
			return 0.0;
		}
		Database.State.Debugger.BonusGrowthTimer.AdvanceTimer(deltaTime);
		return Database.State.Debugger.BonusGrowthRate.CurrentValue;
	}

	private double CalculateMoneyPerSecond(double playersPerSecond)
	{
		int num = ((!(Random.value <= ModifierType.SellDoubleChance.Float())) ? 1 : 2);
		double num2 = (double)ModifierType.PricePerCopy.Float() + ModifierType.BonusSalePrice.Double() * (double)ModifierType.BonusSaleChance.Float();
		return playersPerSecond * num2 * (double)ModifierType.RevenueMultiplier.Float() * (double)num;
	}

	private double CalculateMoneyPassivePlayers()
	{
		return Database.State.Resources.Players.Value * (double)ModifierType.RevenuePassivePlayers.Float();
	}

	private double CalculateMoneyPassivePreviousReleases()
	{
		return Database.Derived.HistoryRevenue.CurrentValue * (double)ModifierType.RevenuePassivePreviousReleases.Float();
	}
}
