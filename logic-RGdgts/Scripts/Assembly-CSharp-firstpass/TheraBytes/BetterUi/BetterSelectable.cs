using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	public class BetterSelectable : Selectable, IBetterTransitionUiElement
	{
		[SerializeField]
		private List<Transitions> betterTransitions;

		public List<Transitions> BetterTransitions => null;

		protected override void DoStateTransition(SelectionState state, bool instant)
		{
		}
	}
}
