using System;
using System.Collections.Generic;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Serializable]
	public struct XPRewardChart<T, E> where T : Enum where E : Enum
	{
		[Serializable]
		private struct XPReward
		{
			[SerializeField]
			public int[] m_values;
		}

		[SerializeField]
		private XPReward[] m_rewards;

		public readonly IEnumerable<(int, int)> GetRewardsForEvent(E rewardEvent)
		{
			int eventType = Convert.ToInt32(rewardEvent);
			if (!m_rewards.IsIndexValid(eventType))
			{
				yield break;
			}
			for (int i = 0; i < m_rewards[eventType].m_values.Length; i++)
			{
				if (m_rewards[eventType].m_values[i] > 0)
				{
					yield return (i, m_rewards[eventType].m_values[i]);
				}
			}
		}
	}
}
