using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class ObjectActivenessTransitions : TransitionStateCollection<bool>
	{
		[Serializable]
		public class ActiveTransitionState : TransitionState
		{
			public ActiveTransitionState(string name, bool stateObject)
				: base((string)null, (byte)(int)default(_00210) != 0)
			{
			}//IL_0010: Expected I4, but got O

		}

		[SerializeField]
		private GameObject target;

		[SerializeField]
		private List<ActiveTransitionState> states;

		public override UnityEngine.Object Target => null;

		public ObjectActivenessTransitions(params string[] stateNames)
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
