using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class ColorTransitions : TransitionStateCollection<Color>
	{
		[Serializable]
		public class ColorTransitionState : TransitionState
		{
			public ColorTransitionState(string name, Color stateObject)
				: base((string)null, (Color)default(_00210))
			{
			}
		}

		[SerializeField]
		private Graphic target;

		[SerializeField]
		private float colorMultiplier;

		[SerializeField]
		private float fadeDuration;

		[SerializeField]
		private List<ColorTransitionState> states;

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

		public ColorTransitions(params string[] stateNames)
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
