using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(fileName = "CustomerRole", menuName = "BBT/Statistics/Customer Role")]
	public class CustomerRole : AgentRole
	{
		[SerializeField]
		protected StatisticsCollection[] _humansSpecificCollections;

		[SerializeField]
		protected StatisticsCollection[] _vampireSpecificCollections;

		public override void AddStatisticsAndBehaviours(AgentStatistics agentStatistics)
		{
			base.AddStatisticsAndBehaviours(agentStatistics);
			if (agentStatistics.GetComponent<Agent>() is Customer customer)
			{
				AddCollection(agentStatistics, customer.IsVampire ? _vampireSpecificCollections : _humansSpecificCollections);
			}
		}
	}
}
