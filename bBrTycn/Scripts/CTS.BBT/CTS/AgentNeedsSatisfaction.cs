using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.StatisticsSystem;
using UnityEngine;

namespace CTS
{
	public class AgentNeedsSatisfaction : CTSBehaviour
	{
		[Serializable]
		private class NeedSurveyor
		{
			[SerializeField]
			private StringKey _satisfactionDownKey;

			[SerializeField]
			private bool _addSatisfactionOnMaxed;

			[SerializeField]
			private StringKey _satisfactionUpKey;

			private Agent _agent;

			private NumericStatistic _statistic;

			private Vector2 _thresholds;

			private EAgentStatistics _stat;

			public void Setup(Agent agent, NumericStatistic statistic, Vector2 thresholds, EAgentStatistics stat)
			{
				_agent = agent;
				_statistic = statistic;
				_thresholds = thresholds;
				_stat = stat;
			}

			public void SetActive(bool active)
			{
				if ((bool)_agent)
				{
					_statistic.UnitIntervalChanged -= OnNeedChanged;
					if (active)
					{
						_statistic.UnitIntervalChanged += OnNeedChanged;
						OnNeedChanged(_statistic.UnitInterval);
					}
				}
			}

			private void OnNeedChanged(float unitInterval)
			{
				if (unitInterval >= 1f && _addSatisfactionOnMaxed)
				{
					_agent.Satisfaction.AddFlatValue(_satisfactionUpKey);
					AgentNeedsSatisfaction.SatisfactionTriggered?.Invoke(new StatSatisfactionEvent(_agent, isGood: true, _stat));
				}
				else if (unitInterval < _thresholds.x)
				{
					if (_agent.Satisfaction.SetModifier(_satisfactionDownKey))
					{
						AgentNeedsSatisfaction.SatisfactionTriggered?.Invoke(new StatSatisfactionEvent(_agent, isGood: false, _stat));
					}
				}
				else
				{
					_agent.Satisfaction.ApplyModifier(_satisfactionDownKey);
				}
			}
		}

		[Inject(false)]
		private Agent _agent;

		[SerializeField]
		private SerializableDictionary<EAgentStatistics, NeedSurveyor> _statisticsToCheck = new SerializableDictionary<EAgentStatistics, NeedSurveyor>();

		public static event Action<StatSatisfactionEvent> SatisfactionTriggered;

		private void Start()
		{
			if (!_agent.Statistics.TryGetNumericStatistic(EAgentStatistics.NeedsThresholds, out var numericStatistic))
			{
				return;
			}
			foreach (KeyValuePair<EAgentStatistics, NeedSurveyor> item in _statisticsToCheck)
			{
				if (_agent.Statistics.TryGetNumericStatistic(item.Key, out var numericStatistic2))
				{
					item.Value.Setup(_agent, numericStatistic2, numericStatistic.InitializationRange, item.Key);
					item.Value.SetActive(active: true);
				}
			}
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_agent.Spawned += OnAgentSpawned;
		}

		private void OnAgentSpawned()
		{
			_agent.Spawned -= OnAgentSpawned;
			foreach (KeyValuePair<EAgentStatistics, NeedSurveyor> item in _statisticsToCheck)
			{
				item.Value.SetActive(_agent.Statistics.HasStatistic(item.Key));
			}
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_agent.Spawned -= OnAgentSpawned;
			foreach (KeyValuePair<EAgentStatistics, NeedSurveyor> item in _statisticsToCheck)
			{
				item.Value.SetActive(active: false);
			}
		}
	}
}
