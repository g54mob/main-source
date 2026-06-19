using System;
using System.Collections.Generic;
using UnityEngine;

namespace NekoLab.Stats
{
	[Serializable]
	public class StatContainer<E> where E : Enum
	{
		[Serializable]
		protected struct StatWrapper
		{
			public E Name;

			public Stat Stat;

			public bool Tick;

			public StatWrapper(E name, Stat stat, bool tick)
			{
				Name = name;
				Stat = stat;
				Tick = tick;
			}
		}

		protected Dictionary<E, Stat> _stats = new Dictionary<E, Stat>();

		[SerializeField]
		protected List<StatWrapper> _statList = new List<StatWrapper>();

		public virtual void Clear()
		{
			_stats?.Clear();
			_statList?.Clear();
		}

		public virtual void Tick()
		{
			for (int i = 0; i < _statList.Count; i++)
			{
				StatWrapper statWrapper = _statList[i];
				if (statWrapper.Tick)
				{
					statWrapper.Stat.Tick();
				}
			}
		}

		public virtual void ResetStats()
		{
			foreach (Stat value in _stats.Values)
			{
				value.Reset();
			}
		}

		public virtual Stat Get(E statType)
		{
			if (_stats.TryGetValue(statType, out var value))
			{
				return value;
			}
			return null;
		}

		public virtual bool TryGet(E statType, out Stat stat)
		{
			return _stats.TryGetValue(statType, out stat);
		}

		public virtual Stat RegisterStat(E statType, float value, bool tick = true)
		{
			if (!TryGet(statType, out var stat))
			{
				stat = new Stat(value);
				AddStat(statType, stat, tick);
			}
			else
			{
				stat.BaseValue = value;
				stat.InitialValue = value;
			}
			return stat;
		}

		public virtual Stat RegisterResourceStat(E statType, float value, E upperBoundStatType, bool tick = true)
		{
			Stat stat = RegisterStat(statType, value, tick);
			if (statType.Equals(upperBoundStatType))
			{
				Debug.LogError("Cannot assign a stat as its own upper bound.");
				return stat;
			}
			if (TryGet(upperBoundStatType, out var stat2))
			{
				stat.SetUpperBound(stat2);
			}
			else
			{
				Debug.LogError("Upper bound stat not found wile registering resource stat.\nMake sure to register upper bound stat before registering the resource stat.");
			}
			return stat;
		}

		protected virtual void AddStat(E statType, Stat stat, bool observe = true)
		{
			_stats.Add(statType, stat);
			_statList.Add(new StatWrapper(statType, stat, observe));
		}
	}
}
