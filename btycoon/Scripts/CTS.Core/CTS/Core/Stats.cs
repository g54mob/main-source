using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core
{
	public class Stats : CTSBehaviour
	{
		[SerializeField]
		private List<StatList> _defaultStats = new List<StatList>();

		private Dictionary<StringKey, IStatistic> _instancedStatistics = new Dictionary<StringKey, IStatistic>();

		private Dictionary<StringKey, StatisticData> _statisticsDatas = new Dictionary<StringKey, StatisticData>();

		private Dictionary<StringKey, List<StatModifierData>> _statModifiers = new Dictionary<StringKey, List<StatModifierData>>();

		protected override void OnEnabled()
		{
			base.OnEnabled();
			foreach (StatList defaultStat in _defaultStats)
			{
				AddStatList(defaultStat);
			}
		}

		public void AddStatList(StatList statList)
		{
			foreach (StatisticData statistic in statList.Statistics)
			{
				_statisticsDatas.TryAdd(statistic, statistic);
			}
			foreach (var (stringKey2, item) in statList.Modifiers)
			{
				if (!_statModifiers.TryGetValue(stringKey2, out var value))
				{
					value = new List<StatModifierData>();
					_statModifiers[stringKey2] = value;
				}
				if (!value.Contains(item))
				{
					value.Add(item);
				}
			}
			foreach (StringKey key in _statModifiers.Keys)
			{
				_statModifiers[key].Sort();
			}
		}

		public float Get(StringKey key)
		{
			float num = 0f;
			StatisticData value2;
			if (_instancedStatistics.TryGetValue(key, out var value))
			{
				num = value.FloatValue;
			}
			else if (_statisticsDatas.TryGetValue(key, out value2))
			{
				num = value2.FloatValue;
			}
			if (_statModifiers.TryGetValue(key, out var value3))
			{
				foreach (StatModifierData item in value3)
				{
					if (item.ShouldModifyGet())
					{
						num = item.Modify(num);
					}
				}
			}
			return num;
		}

		public int GetRounded(StringKey key)
		{
			return Mathf.RoundToInt(Get(key));
		}

		public int GetCeiled(StringKey key)
		{
			return Mathf.CeilToInt(Get(key));
		}

		public int GetFloored(StringKey key)
		{
			return Mathf.FloorToInt(Get(key));
		}

		public void ClearStatistics()
		{
			_instancedStatistics.Clear();
			_statisticsDatas.Clear();
			_statModifiers.Clear();
		}
	}
}
