using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	public class TEMP_StatsPanelDispatcher : AbsAgentPanel
	{
		[Header("Stats Info")]
		[SerializeField]
		private StatBar speedBar;

		[SerializeField]
		private StatBar intelligenceBar;

		[SerializeField]
		private StatBar charmismaBar;

		public void ShowTraitStats()
		{
			speedBar.gameObject.SetActive(base._agent is Worker);
			intelligenceBar.gameObject.SetActive(base._agent is Worker);
			charmismaBar.gameObject.SetActive(base._agent is Worker);
		}

		public void ShowLifeStats()
		{
			speedBar.gameObject.SetActive(value: false);
			intelligenceBar.gameObject.SetActive(value: false);
			charmismaBar.gameObject.SetActive(value: false);
		}

		private void SetWorkerStatsVisual(Worker worker)
		{
			AssignStatisticToBar(speedBar, worker, EAgentStatistics.Speed);
			if (base._agent.Statistics.TryGetNumericStatistic(EAgentStatistics.Intellect, out var _))
			{
				AssignStatisticToBar(intelligenceBar, worker, EAgentStatistics.Intellect);
			}
			if (base._agent.Statistics.TryGetNumericStatistic(EAgentStatistics.Charisma, out var _))
			{
				AssignStatisticToBar(charmismaBar, worker, EAgentStatistics.Charisma);
			}
		}

		private void AssignStatisticToBar(StatBar bar, Worker worker, EAgentStatistics statistic)
		{
			if ((bool)bar && (bool)worker && worker.Statistics.TryGetNumericStatistic(statistic, out var numericStatistic))
			{
				bool flag = false;
				flag = worker.Characteristics.IsSpecialized && worker.Characteristics.SpecializedStat == statistic;
				bar.AssignAgentStatistic(numericStatistic, flag);
			}
		}

		public override void SetAgentInfo()
		{
			if (base._agent is Worker workerStatsVisual)
			{
				SetWorkerStatsVisual(workerStatsVisual);
			}
		}

		public override void ClearAgentInfo()
		{
		}
	}
}
