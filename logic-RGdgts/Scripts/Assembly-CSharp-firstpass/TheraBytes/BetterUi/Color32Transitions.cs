using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	[Serializable]
	public class Color32Transitions : TransitionStateCollection<Color32>
	{
		[Serializable]
		public class Color32TransitionState : TransitionState
		{
			public Color32TransitionState(string name, Color32 stateObject)
				: base((string)null, (Color32)default(_00210))
			{
			}
		}

		[SerializeField]
		private Graphic target;

		[SerializeField]
		private float fadeDuration;

		[SerializeField]
		private List<Color32TransitionState> states;

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

		public Color32Transitions(params string[] stateNames)
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
