using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	public class BetterInputField : InputField, IBetterTransitionUiElement
	{
		[SerializeField]
		private List<Transitions> betterTransitions;

		[SerializeField]
		private List<Graphic> additionalPlaceholders;

		public List<Transitions> BetterTransitions => null;

		public List<Graphic> AdditionalPlaceholders => null;

		protected override void DoStateTransition(SelectionState state, bool instant)
		{
		}

		public override void OnUpdateSelected(BaseEventData eventData)
		{
		}

		private void DisplayPlaceholders(string input)
		{
		}
	}
}
