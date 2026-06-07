using System;
using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	[Serializable]
	public struct TabletopScoreRewardChart
	{
		[SerializeField]
		private EnumValues<ETabletopXPRewardEvent, Calculation> m_rewards;

		public Calculation this[ETabletopXPRewardEvent simulatorXpRewardEvent] => GetRewardCalculation(simulatorXpRewardEvent);

		private Calculation GetRewardCalculation(ETabletopXPRewardEvent simulatorXpRewardEvent)
		{
			return m_rewards[simulatorXpRewardEvent];
		}
	}
}
