using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Simulation/Auction Log", fileName = "AuctionLogSimulation")]
public class AuctionLogSimulation : ScriptableObject, IIntervalIncrementalSimulation, IIncrementalSimulation
{
	public float UpdateInterval => 0.5f;

	public void Registered(UIRegistry? registry)
	{
	}

	public void Unregistered()
	{
	}

	public void OnUpdateSimulation(float deltaTime)
	{
		AuctionUtility.TickHiddenSentiment(Database.State.Auction, deltaTime);
		if (Database.State.Game.Launched.Value)
		{
			double value = Database.State.Prestige.Fans.Value;
			double num = Math.Max(0.0, Database.State.Resources.Players.Value - value);
			float participationMultiplierFromAlignment = AuctionUtility.GetParticipationMultiplierFromAlignment(Database.State.Auction);
			bool num2 = (double)BiteRandom.NextFloat() > (double)(ModifierType.AuctionFansParticipation.Float() * participationMultiplierFromAlignment) * value;
			bool flag = (double)BiteRandom.NextFloat() > (double)(ModifierType.AuctionPlayerParticipation.Float() * participationMultiplierFromAlignment) * num;
			if (!(num2 && flag))
			{
				Database.Commands.Auction.SellRandom();
			}
		}
	}
}
