using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class LocationAnimationTransitions : TransitionStateCollection<string>
	{
		[Serializable]
		public class LocationAnimationTransitionState : TransitionState
		{
			public LocationAnimationTransitionState(string name, string stateObject)
				: base((string)null, (string)null)
			{
			}
		}

		[SerializeField]
		private LocationAnimations target;

		[SerializeField]
		private List<LocationAnimationTransitionState> states;

		public override UnityEngine.Object Target => null;

		public LocationAnimationTransitions(params string[] stateNames)
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
