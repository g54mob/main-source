using System.Collections.Generic;
using UnityEngine;

namespace Animancer
{
	public class TimeSynchronizer<T>
	{
		public T CurrentGroup { get; set; }

		public bool SynchronizeDefaultGroup { get; set; }

		public double NormalizedTime { get; set; }

		public TimeSynchronizer()
		{
		}

		public TimeSynchronizer(T group, bool synchronizeDefaultGroup = false)
		{
			CurrentGroup = group;
			SynchronizeDefaultGroup = synchronizeDefaultGroup;
		}

		public void StoreTime(AnimancerLayer layer)
		{
			StoreTime(layer.CurrentState);
		}

		public void StoreTime(AnimancerState state)
		{
			NormalizedTime = state?.NormalizedTimeD ?? 0.0;
		}

		public bool SyncTime(AnimancerLayer layer, T group)
		{
			return SyncTime(layer.CurrentState, group, Time.deltaTime);
		}

		public bool SyncTime(AnimancerLayer layer, T group, float deltaTime)
		{
			return SyncTime(layer.CurrentState, group, deltaTime);
		}

		public bool SyncTime(AnimancerState state, T group)
		{
			return SyncTime(state, group, Time.deltaTime);
		}

		public bool SyncTime(AnimancerState state, T group, float deltaTime)
		{
			if (state == null || !EqualityComparer<T>.Default.Equals(CurrentGroup, group) || (!SynchronizeDefaultGroup && EqualityComparer<T>.Default.Equals(default(T), group)))
			{
				CurrentGroup = group;
				return false;
			}
			state.TimeD = NormalizedTime * (double)state.Length + (double)(deltaTime * state.EffectiveSpeed);
			return true;
		}
	}
}
