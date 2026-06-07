using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace UI
{
	public class KeyBindDropdownControlType : KeyBindDropdown
	{
		public override void Init(InputAction inputAction, int bindingIndex, UnityAction<InputAction, int, int> onChangeVelueAction, List<string> itemList = null, int selectedValue = 0)
		{
		}
	}
}
