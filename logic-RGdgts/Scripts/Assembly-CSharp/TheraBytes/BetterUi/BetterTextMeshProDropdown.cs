using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
	public class BetterTextMeshProDropdown : TMP_Dropdown, IBetterTransitionUiElement
	{
		[SerializeField]
		private List<Transitions> betterTransitions;

		[SerializeField]
		private List<Transitions> showHideTransitions;

		public List<Transitions> BetterTransitions => null;

		public List<Transitions> ShowHideTransitions => null;

		protected override void DoStateTransition(SelectionState state, bool instant)
		{
		}

		protected override GameObject CreateDropdownList(GameObject template)
		{
			return null;
		}

		protected override void DestroyDropdownList(GameObject dropdownList)
		{
		}
	}
}
