using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.StatisticsSystem;

namespace CTS
{
	public class AgentSpeed : CTSBehaviour
	{
		[Inject(false)]
		private Agent _agent;

		private NumericStatistic _speedStat;

		private static readonly StringKey _speedModifierKey = "SpeedStat";

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_agent.Statistics.StatisticUpdated += UpdateStat;
			UpdateStat();
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_agent.Statistics.StatisticUpdated -= UpdateStat;
			if (_speedStat != null)
			{
				_speedStat.ValueChanged -= OnSpeedStatChanged;
			}
		}

		private void UpdateStat()
		{
			if (_speedStat != null)
			{
				_speedStat.ValueChanged -= OnSpeedStatChanged;
			}
			_speedStat = null;
			if (_agent.Statistics.TryGetNumericStatistic(EAgentStatistics.Speed, out var numericStatistic))
			{
				_speedStat = numericStatistic;
				_speedStat.ValueChanged += OnSpeedStatChanged;
			}
			OnSpeedStatChanged();
		}

		private void OnSpeedStatChanged(float value = 0f)
		{
			float speedMultiplier = _agent.GetSpeedMultiplier();
			_agent.Movement.AddSpeedModifier(_speedModifierKey, speedMultiplier);
		}
	}
}
