using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	public class BetterScrollbar : Scrollbar, IBetterTransitionUiElement
	{
		[SerializeField]
		private List<Transitions> betterTransitions;

		public List<Transitions> BetterTransitions => null;

		protected override void DoStateTransition(SelectionState state, bool instant)
		{
		}
	}
}
