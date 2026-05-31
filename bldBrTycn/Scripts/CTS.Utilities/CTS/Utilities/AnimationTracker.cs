using System.Collections;
using Animancer;
using UnityEngine;

namespace CTS.Utilities
{
	public class AnimationTracker : CoroutineTracker
	{
		private AnimancerState _state;

		public float GetNormalizedTime => _state.NormalizedTime;

		protected AnimationTracker(MonoBehaviour behaviour, AnimancerState state)
			: base(behaviour)
		{
			_state = state;
		}

		public static AnimationTracker Start(MonoBehaviour behaviour, IEnumerator coroutine, AnimancerState state)
		{
			AnimationTracker animationTracker = new AnimationTracker(behaviour, state);
			animationTracker.Start(coroutine);
			return animationTracker;
		}
	}
}
