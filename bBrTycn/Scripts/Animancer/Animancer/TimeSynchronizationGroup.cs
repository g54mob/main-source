using System.Collections.Generic;
using UnityEngine;

namespace Animancer
{
	public class TimeSynchronizationGroup : HashSet<object>
	{
		private AnimancerComponent _Animancer;

		public AnimancerComponent Animancer
		{
			get
			{
				return _Animancer;
			}
			set
			{
				_Animancer = value;
				NormalizedTime = null;
			}
		}

		public float? NormalizedTime { get; set; }

		public TimeSynchronizationGroup(AnimancerComponent animancer)
		{
			Animancer = animancer;
		}

		public bool StoreTime(object key)
		{
			return StoreTime(key, Animancer.States.Current);
		}

		public bool StoreTime(object key, AnimancerState state)
		{
			if (state != null && Contains(key))
			{
				NormalizedTime = state.NormalizedTime;
				return true;
			}
			NormalizedTime = null;
			return false;
		}

		public bool SyncTime(object key)
		{
			return SyncTime(key, Time.deltaTime);
		}

		public bool SyncTime(object key, float deltaTime)
		{
			return SyncTime(key, Animancer.States.Current, deltaTime);
		}

		public bool SyncTime(object key, AnimancerState state)
		{
			return SyncTime(key, state, Time.deltaTime);
		}

		public bool SyncTime(object key, AnimancerState state, float deltaTime)
		{
			if (!NormalizedTime.HasValue || state == null || !Contains(key))
			{
				return false;
			}
			state.Time = NormalizedTime.Value * state.Length + deltaTime * state.EffectiveSpeed;
			return true;
		}
	}
}
