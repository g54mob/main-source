using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace UI
{
	public class KeyBindDropdownLR : KeyBindDropdown
	{
		[SerializeField]
		private InputActionReference _targetActionL;

		[SerializeField]
		private InputActionReference _targetActionR;

		[SerializeField]
		private InputActionReference _targetActionLTrigger;

		[SerializeField]
		private InputActionReference _targetActionRTrigger;

		public override void Init(InputAction inputAction, int bindingIndex, UnityAction<InputAction, int, int> onChangeVelueAction, List<string> itemList = null, int selectedValue = 0)
		{
		}
	}
}
