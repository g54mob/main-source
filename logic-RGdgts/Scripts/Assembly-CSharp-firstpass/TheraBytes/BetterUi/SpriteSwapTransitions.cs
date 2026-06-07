using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class SpriteSwapTransitions : TransitionStateCollection<Sprite>
	{
		[Serializable]
		public class SpriteSwapTransitionState : TransitionState
		{
			public SpriteSwapTransitionState(string name, Sprite stateObject)
				: base((string)null, (Sprite)default(_00210))
			{
			}
		}

		[SerializeField]
		private Image target;

		[SerializeField]
		private List<SpriteSwapTransitionState> states;

		public override UnityEngine.Object Target => null;

		public SpriteSwapTransitions(params string[] stateNames)
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
