using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class CustomTransitions : TransitionStateCollection<UnityEvent>
	{
		[Serializable]
		public class CustomTransitionState : TransitionState
		{
			public CustomTransitionState(string name)
				: base((string)null, (UnityEvent)default(_00210))
			{
			}
		}

		[SerializeField]
		private List<CustomTransitionState> states;

		public override UnityEngine.Object Target => null;

		public CustomTransitions(params string[] stateNames)
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
