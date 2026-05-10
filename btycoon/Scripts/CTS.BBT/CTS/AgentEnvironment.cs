using System;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.StatisticsSystem;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class AgentEnvironment : CTSBehaviour
	{
		private enum ENeedStatus
		{
			Bad = 0,
			Middle = 1,
			Good = 2
		}

		[Inject(false)]
		[SerializeField]
		private Agent _agent;

		[SerializeField]
		private StringKey _satisfactionLossKey = "NeedEnvironmentLoss";

		[SerializeField]
		private StringKey _satisfactionGainKey = "NeedEnvironmentGain";

		private int _nextEnvironmentCheck;

		protected override void OnEnabled()
		{
			if (_agent is Customer)
			{
				_nextEnvironmentCheck = 0;
				CalendarHandlers.NewDay += OnNewDay;
			}
		}

		protected override void OnDisabled()
		{
			CalendarHandlers.NewDay -= OnNewDay;
		}

		private void OnNewDay()
		{
			if (_agent.Tags.HasTag(EAgentTag.IsInside))
			{
				if (_nextEnvironmentCheck > 0)
				{
					_nextEnvironmentCheck--;
					return;
				}
				ResetEnvironmentCheckCooldown();
				CalculateEnvironmentStatus();
			}
		}

		public void CalculateEnvironmentStatus()
		{
			Customer customer = _agent.Cast<Customer>();
			if (customer == null)
			{
				return;
			}
			PrestigeLevelData agentPrestigeLevel = GetAgentPrestigeLevel(customer.SpawnParameters.MinimumPrestigeRequired);
			if (agentPrestigeLevel == null)
			{
				throw new Exception("Couldn't find a suitable prestige level for agent");
			}
			int minimumPrestigeRequired = customer.SpawnParameters.MinimumPrestigeRequired;
			int num = (int)Prestige.CurrentPrestigeData.GetNextStepFrom(agentPrestigeLevel);
			NumericStatistic numericStatistic = _agent.Statistics.GetNumericStatistic(EAgentStatistics.NeedsThresholds);
			NumericStatistic numericStatistic2 = _agent.Statistics.GetNumericStatistic(EAgentStatistics.Environment);
			float t = Math.Max(0f, MonoSingleton<Prestige>.Instance.CurrentPrestige - MonoSingleton<Prestige>.Instance.TotalReviewsValue).InverseLerpUnclamped(minimumPrestigeRequired, num);
			float num2 = Mathf.LerpUnclamped(numericStatistic.InitializationRange.x, numericStatistic.InitializationRange.y, t);
			ENeedStatus needStatus = GetNeedStatus(numericStatistic2.UnitInterval, numericStatistic.InitializationRange.x, numericStatistic.InitializationRange.y);
			numericStatistic2.SetValueFromUnitInterval(num2);
			ENeedStatus needStatus2 = GetNeedStatus(num2, numericStatistic.InitializationRange.x, numericStatistic.InitializationRange.y);
			if (needStatus2 != needStatus)
			{
				switch (needStatus2)
				{
				case ENeedStatus.Bad:
					_agent.Satisfaction.AddFlatValue(_satisfactionLossKey);
					break;
				case ENeedStatus.Good:
					_agent.Satisfaction.AddFlatValue(_satisfactionGainKey);
					break;
				}
			}
		}

		private ENeedStatus GetNeedStatus(float value, float min, float max)
		{
			if (value < min)
			{
				return ENeedStatus.Bad;
			}
			if (value >= max)
			{
				return ENeedStatus.Good;
			}
			return ENeedStatus.Middle;
		}

		private void ResetEnvironmentCheckCooldown()
		{
			if (_agent.Statistics.TryGetNumericStatistic(EAgentStatistics.EnvironmentCheck, out var numericStatistic))
			{
				_nextEnvironmentCheck = (int)UnityEngine.Random.Range(numericStatistic.InitializationRange.x, numericStatistic.InitializationRange.y);
			}
		}

		private PrestigeLevelData GetAgentPrestigeLevel(int minimumPrestigeRequired)
		{
			PrestigeLevelsData currentPrestigeData = Prestige.CurrentPrestigeData;
			float num = 0f;
			foreach (PrestigeLevelData prestigeStep in currentPrestigeData.PrestigeSteps)
			{
				num += prestigeStep.PrestigeRequired;
				if (!(num < (float)minimumPrestigeRequired))
				{
					return prestigeStep;
				}
			}
			return null;
		}
	}
}
