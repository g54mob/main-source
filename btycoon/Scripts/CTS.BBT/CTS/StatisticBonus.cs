using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class StatisticBonus : MonoBehaviour
	{
		[SerializeField]
		private AgentStatistics _agentStatistics;

		[SerializeField]
		private SerializableDictionary<EAgentStatistics, float> _changes = new SerializableDictionary<EAgentStatistics, float>();

		public AgentStatistics AgentStatistics
		{
			get
			{
				if (!_agentStatistics)
				{
					_agentStatistics = GetComponent<AgentStatistics>();
				}
				return _agentStatistics;
			}
		}

		public void AddBonus(EAgentStatistics statisticToChange, float bonus)
		{
			_changes.Add(statisticToChange, bonus);
			EnableBonus(statisticToChange, bonus, enable: true);
		}

		private void OnEnable()
		{
			foreach (KeyValuePair<EAgentStatistics, float> change in _changes)
			{
				EnableBonus(change.Key, change.Value, enable: true);
			}
		}

		private void OnDisable()
		{
			foreach (KeyValuePair<EAgentStatistics, float> change in _changes)
			{
				EnableBonus(change.Key, change.Value, enable: false);
			}
		}

		private void EnableBonus(EAgentStatistics statisticToChange, float bonus, bool enable)
		{
			if ((bool)AgentStatistics && AgentStatistics.TryGetNumericStatistic(statisticToChange, out var numericStatistic))
			{
				numericStatistic.AddToValue(enable ? bonus : (0f - bonus));
			}
		}
	}
}
