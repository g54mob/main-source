using System.Collections.Generic;
using CTS.Core;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(fileName = "StatisticBonusFactory", menuName = "BBT/Passives/Statistic Bonus Factory")]
	public class StatisticBonusFactory : ScriptableObject
	{
		[SerializeField]
		private SerializableDictionary<EAgentStatistics, float> _changes = new SerializableDictionary<EAgentStatistics, float>();

		[field: SerializeField]
		public LocalizedString Name { get; private set; }

		[field: SerializeField]
		public LocalizedString Description { get; private set; }

		[field: SerializeField]
		public Sprite Icon { get; private set; }

		public StatisticBonus AddNewPassiveInstance(AgentStatistics agentStatistics)
		{
			StatisticBonus statisticBonus = agentStatistics.gameObject.AddComponent<StatisticBonus>();
			foreach (KeyValuePair<EAgentStatistics, float> change in _changes)
			{
				statisticBonus.AddBonus(change.Key, change.Value);
			}
			return statisticBonus;
		}
	}
}
