using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT.AI
{
	public class AgentSatisfaction : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private Agent _agent;

		private Dictionary<StringKey, int> _currentModifiers = new Dictionary<StringKey, int>();

		private static readonly Resource<VFXData> _satisfactionUpVFX = "Scriptables/VFX/VFX_SatisfactionUp";

		private static readonly Resource<VFXData> _satisfactionDownVFX = "Scriptables/VFX/VFX_SatisfactionDown";

		private int _rawSatisfaction;

		[field: SerializeField]
		public AgentSatisfactionPoints PointList { get; private set; }

		public IReadOnlyDictionary<StringKey, int> CurrentModifiers => _currentModifiers;

		public int Satisfaction
		{
			get
			{
				if (_agent.Statistics.TryGetStatisticIntValue(EAgentStatistics.Satisfaction, out var statisticValue))
				{
					return statisticValue;
				}
				return 0;
			}
		}

		public int RawSatisfaction => _rawSatisfaction;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_agent.Spawned += OnAgentSpawned;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_agent.Spawned -= OnAgentSpawned;
		}

		private void OnAgentSpawned()
		{
			_agent.Spawned -= OnAgentSpawned;
			_agent.Statistics.TryGetStatisticIntValue(EAgentStatistics.Satisfaction, out _rawSatisfaction);
		}

		public bool SetModifier(StringKey key, int? valueOverride = null)
		{
			int num = valueOverride ?? PointList.GetPointValue(key);
			if (_currentModifiers.TryGetValue(key, out var value) && value == num)
			{
				return false;
			}
			_currentModifiers[key] = num;
			RecalculateSatisfaction();
			return true;
		}

		public void RemoveModifier(StringKey key)
		{
			if (_currentModifiers.ContainsKey(key))
			{
				_currentModifiers.Remove(key);
				RecalculateSatisfaction();
			}
		}

		public void AddToModifier(StringKey key, int value)
		{
			if (_currentModifiers.ContainsKey(key))
			{
				_currentModifiers[key] += value;
				RecalculateSatisfaction();
			}
			else
			{
				SetModifier(key, value);
			}
		}

		public void AddFlatValue(StringKey pointListKey)
		{
			AddFlatValue(PointList.GetPointValue(pointListKey));
		}

		public void AddFlatValue(int value)
		{
			_rawSatisfaction += value;
			RecalculateSatisfaction();
		}

		public void ApplyModifier(StringKey key)
		{
			if (_currentModifiers.Remove(key, out var value))
			{
				AddFlatValue(value);
			}
		}

		public void ApplyAllModifiers()
		{
			foreach (var (_, num2) in _currentModifiers)
			{
				_rawSatisfaction += num2;
			}
			_currentModifiers.Clear();
			RecalculateSatisfaction();
		}

		private void RecalculateSatisfaction()
		{
			if (!_agent.Statistics.TryGetNumericStatistic(EAgentStatistics.Satisfaction, out var numericStatistic))
			{
				return;
			}
			int intValue = numericStatistic.IntValue;
			int num = _rawSatisfaction;
			foreach (KeyValuePair<StringKey, int> currentModifier in _currentModifiers)
			{
				num += currentModifier.Value;
			}
			_agent.Statistics.SetStatisticValue(EAgentStatistics.Satisfaction, num);
			Transform boneTransform2;
			if (numericStatistic.IntValue < intValue)
			{
				if (_agent.SkeletonData.TryGetBone(EBone.Head, out var boneTransform))
				{
					_agent.VFXManager.Play(_satisfactionDownVFX, boneTransform);
				}
			}
			else if (numericStatistic.IntValue > intValue && _agent.SkeletonData.TryGetBone(EBone.Head, out boneTransform2))
			{
				_agent.VFXManager.Play(_satisfactionUpVFX, boneTransform2);
			}
		}
	}
}
