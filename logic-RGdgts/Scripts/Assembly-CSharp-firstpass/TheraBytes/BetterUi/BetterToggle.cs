using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	public class BetterToggle : Toggle, IBetterTransitionUiElement
	{
		[Serializable]
		public class ToggleGraphics
		{
			public ToggleTransition ToggleTransition;

			public Graphic Graphic;

			public float FadeDuration;
		}

		[SerializeField]
		private List<Transitions> betterTransitions;

		[SerializeField]
		private List<Transitions> betterToggleTransitions;

		public List<Transitions> BetterTransitions => null;

		public List<Transitions> BetterToggleTransitions => null;

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected override void DoStateTransition(SelectionState state, bool instant)
		{
		}

		private void ValueChanged(bool on)
		{
		}

		private void ValueChanged(bool on, bool immediate)
		{
		}
	}
}
