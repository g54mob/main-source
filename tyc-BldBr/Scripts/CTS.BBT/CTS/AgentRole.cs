using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "AgentRole", menuName = "BBT/Statistics/Agent Role")]
	public class AgentRole : ScriptableObject
	{
		[SerializeField]
		protected StatisticsCollection[] _collections;

		public virtual void AddStatisticsAndBehaviours(AgentStatistics agentStatistics)
		{
			AddCollection(agentStatistics, _collections);
		}

		protected void AddCollection(AgentStatistics agentStatistics, StatisticsCollection[] collections)
		{
			for (int i = 0; i < collections.Length; i++)
			{
				collections[i].AddStatisticsAndBehaviours(agentStatistics);
			}
		}
	}
}
