using System.Collections.Generic;
using CTS.Core;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class WorkerPassives : CTSBehaviour
	{
		public enum EPassiveHabilities
		{
			Genius = 0,
			Quick = 1,
			Strong = 2,
			Mermaid = 3,
			SpeedLearning = 4,
			Doctor = 5,
			AncientBlood = 6,
			Optimist = 7,
			Frugal = 8,
			Ascetic = 9,
			Robust = 10,
			Stealthy = 11
		}

		[SerializeField]
		[Inject(false)]
		private AgentStatistics _agentStatistics;

		private List<StatisticBonus> _currentPassives = new List<StatisticBonus>();

		[field: SerializeField]
		public WorkerPassivesData WorkerPassivesData { get; private set; }

		public List<StatisticBonusFactory> CurrentPassives { get; private set; } = new List<StatisticBonusFactory>();

		public void SpawnInitialization()
		{
			ClearPassives();
			if (WorkerPassivesData == null || WorkerPassivesData.PassivesGroupsWeight.Count == 0)
			{
				return;
			}
			int num = WorkerPassivesData.PassivesAmountRange.RandomInRangeInclusive();
			Dictionary<GroupedStatisticBonusFactory, float> dictionary = new Dictionary<GroupedStatisticBonusFactory, float>(WorkerPassivesData.PassivesGroupsWeight.Dict);
			for (int i = 0; i < num; i++)
			{
				GroupedStatisticBonusFactory groupedStatisticBonusFactory = dictionary.DrawWeightedRandom();
				if (!(groupedStatisticBonusFactory == null))
				{
					StatisticBonusFactory item = groupedStatisticBonusFactory.SelectPassive();
					CurrentPassives.Add(item);
					dictionary.Remove(groupedStatisticBonusFactory);
				}
			}
			InstantiatePassives();
		}

		public void ReloadPassives()
		{
			RemovePassivesComponents();
			InstantiatePassives();
		}

		private void InstantiatePassives()
		{
			foreach (StatisticBonusFactory currentPassife in CurrentPassives)
			{
				_currentPassives.Add(currentPassife.AddNewPassiveInstance(_agentStatistics));
			}
		}

		private void RemovePassivesComponents()
		{
			foreach (StatisticBonus currentPassife in _currentPassives)
			{
				Object.Destroy(currentPassife);
			}
			_currentPassives.Clear();
		}

		public void ClearPassives()
		{
			RemovePassivesComponents();
			CurrentPassives.Clear();
		}
	}
}
