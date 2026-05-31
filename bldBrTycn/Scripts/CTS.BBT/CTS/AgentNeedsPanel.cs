using CTS.BBT.AI;
using CTS.Core.StatisticsSystem;
using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class AgentNeedsPanel : AbsAgentPanel
	{
		[SerializeField]
		private StatBar _thirstHumanBar;

		[SerializeField]
		private StatBar _thirstVampireBar;

		[SerializeField]
		private StatBar _funBar;

		[SerializeField]
		private StatBar _toiletBar;

		[SerializeField]
		private StatBar _environmentBar;

		[SerializeField]
		private GameObject _clientsNeed;

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

		[SerializeField]
		private GameObject _footerEndVampire;

		private void Start()
		{
		}

		public override void ClearAgentInfo()
		{
		}

		public override void SetAgentInfo()
		{
			OnAgentChanging();
			if (base._agent.Statistics.TryGetNumericStatistic(EAgentStatistics.Thirst, out var numericStatistic))
			{
				AssignStatisticToBar(_thirstHumanBar, numericStatistic);
			}
			if (base._agent.Statistics.TryGetNumericStatistic(EAgentStatistics.Hunger, out var numericStatistic2))
			{
				AssignStatisticToBar(_thirstVampireBar, numericStatistic2);
			}
			if (base._agent.Statistics.TryGetNumericStatistic(EAgentStatistics.Fun, out var numericStatistic3))
			{
				AssignStatisticToBar(_funBar, numericStatistic3);
			}
			if (base._agent.Statistics.TryGetNumericStatistic(EAgentStatistics.Bladder, out var numericStatistic4))
			{
				AssignStatisticToBar(_toiletBar, numericStatistic4);
			}
			if (base._agent.Statistics.TryGetNumericStatistic(EAgentStatistics.Environment, out var numericStatistic5))
			{
				AssignStatisticToBar(_environmentBar, numericStatistic5);
			}
			_background.color = ((base._agent is Worker) ? _workerColor : (base._agent.IsHuman ? _humanColor : _vampireColor));
			ShowTraitStats();
		}

		public void ShowTraitStats()
		{
			SetBarActive(_thirstHumanBar, base.Agent is Customer && ((Customer)base.Agent).IsHuman);
			SetBarActive(_thirstVampireBar, base.Agent is Worker || (base.Agent is Customer && !((Customer)base.Agent).IsHuman));
			SetBarActive(_funBar, value: true);
			SetBarActive(_toiletBar, base.Agent is Customer && ((Customer)base.Agent).IsHuman);
			SetBarActive(_environmentBar, base.Agent is Customer);
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

		private void OnAgentChanging()
		{
			if (!(base._agent == null))
			{
				_footerEndVampire.SetActive(!(base._agent is Worker) && !base._agent.IsHuman);
				_clientsNeed.SetActive(!(base._agent is Worker));
			}
		}
	}
}
