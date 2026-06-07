using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class AlphaTransitions : TransitionStateCollection<float>
	{
		[Serializable]
		public class AlphaTransitionState : TransitionState
		{
			public AlphaTransitionState(string name, float stateObject)
				: base((string)null, (float)default(_00210))
			{
			}//IL_0010: Expected F4, but got O

		}

		[SerializeField]
		private Graphic target;

		[SerializeField]
		private float fadeDuration;

		[SerializeField]
		private List<AlphaTransitionState> states;

		public override UnityEngine.Object Target => null;

		public float FadeDurtaion
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public AlphaTransitions(params string[] stateNames)
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
