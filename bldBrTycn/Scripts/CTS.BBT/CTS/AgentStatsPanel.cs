using CTS.BBT.AI;
using CTS.Core.StatisticsSystem;
using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class AgentStatsPanel : AbsAgentPanel
	{
		[SerializeField]
		private StatBar _satisfactionBar;

		[SerializeField]
		private StatBar _alcoholBar;

		[Header("Color")]
		[SerializeField]
		private Image _background;

		[SerializeField]
		private PaletteData _workerColor;

		[SerializeField]
		private PaletteData _humanColor;

		[SerializeField]
		private PaletteData _vampireColor;

		[SerializeField]
		private PaletteData _workerColorBGStats;

		[SerializeField]
		private PaletteData _workerColorFrontStats;

		[SerializeField]
		private PaletteData _vampireColorBGStats;

		[SerializeField]
		private PaletteData _vampireColorFrontStats;

		[SerializeField]
		private PaletteData _humanColorBGStats;

		[SerializeField]
		private PaletteData _humanColorFrontStats;

		private void Start()
		{
		}

		public override void ClearAgentInfo()
		{
		}

		public override void SetAgentInfo()
		{
			if (base._agent.Statistics.TryGetNumericStatistic(EAgentStatistics.Satisfaction, out var numericStatistic))
			{
				AssignStatisticToBar(_satisfactionBar, numericStatistic);
			}
			if (base._agent.Statistics.TryGetNumericStatistic(EAgentStatistics.Alcohol, out var numericStatistic2))
			{
				AssignStatisticToBar(_alcoholBar, numericStatistic2);
			}
			_background.color = ((base._agent is Worker) ? _workerColor : (base._agent.IsHuman ? _humanColor : _vampireColor));
			ShowTraitStats();
		}

		public void ShowTraitStats()
		{
			SetBarActive(_satisfactionBar, value: true);
			SetBarActive(_alcoholBar, value: true);
		}

		private void SetBarActive(StatBar bar, bool value)
		{
			if ((bool)bar)
			{
				if (bar.EditorOnly && !Application.isEditor)
				{
					bar.gameObject.SetActive(value: false);
				}
				else
				{
					bar.gameObject.SetActive(value);
				}
			}
		}

		private void AssignStatisticToBar(StatBar bar, NumericStatistic statistic)
		{
			if ((bool)bar && (bool)base._agent)
			{
				Color colorFG = ((base._agent is Worker) ? _workerColorFrontStats : (base._agent.IsHuman ? _humanColorFrontStats : _vampireColorFrontStats));
				Color colorBG = ((base._agent is Worker) ? _workerColorBGStats : (base._agent.IsHuman ? _humanColorBGStats : _vampireColorBGStats));
				bar.AssignColor(colorBG, colorFG);
				bar.AssignAgentStatistic(statistic);
			}
		}
	}
}
