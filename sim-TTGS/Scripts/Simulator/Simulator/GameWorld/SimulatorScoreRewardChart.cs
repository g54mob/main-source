using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Serializable]
	public struct SimulatorScoreRewardChart
	{
		[SerializeField]
		private EnumValues<ESimulatorXPRewardEvent, Calculation> m_rewards;

		public Calculation this[ESimulatorXPRewardEvent simulatorXpRewardEvent] => GetRewardCalculation(simulatorXpRewardEvent);

		private Calculation GetRewardCalculation(ESimulatorXPRewardEvent simulatorXpRewardEvent)
		{
			return m_rewards[simulatorXpRewardEvent];
		}
	}
}
