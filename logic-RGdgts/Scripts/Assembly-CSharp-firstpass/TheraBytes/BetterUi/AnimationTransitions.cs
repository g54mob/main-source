using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class AnimationTransitions : TransitionStateCollection<string>
	{
		[Serializable]
		public class AnimationTransitionState : TransitionState
		{
			public AnimationTransitionState(string name, string stateObject)
				: base((string)null, (string)null)
			{
			}
		}

		[SerializeField]
		private Animator target;

		[SerializeField]
		private List<AnimationTransitionState> states;

		public override UnityEngine.Object Target => null;

		public AnimationTransitions(params string[] stateNames)
			: base((string[])null)
		{
		}

		protected override void ApplyState(TransitionState state, bool instant)
		{
		}

		internal override void AddStateObject(string stateName)
		{
		}

		protected override IEnumerable<TransitionState> GetTransitionStates()
		{
			return null;
		}

		internal override void SortStates(string[] sortedOrder)
		{
		}
	}
}
