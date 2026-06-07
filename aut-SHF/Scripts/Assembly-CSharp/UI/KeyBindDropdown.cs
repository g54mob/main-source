using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace UI
{
	public class KeyBindDropdown : MonoBehaviour
	{
		[SerializeField]
		private TMP_Dropdown dropdown;

		private UnityAction<InputAction, int, int> onChangeVelueAction;

		protected InputAction inputAction;

		protected int bindingIndex;

		protected int selectedValue;

		private bool _createdItems;

		protected List<string> itemList;

		public int GetValue()
		{
			return 0;
		}

		public virtual void Init(InputAction inputAction, int bindingIndex, UnityAction<InputAction, int, int> onChangeVelueAction, List<string> itemList = null, int selectedValue = 0)
		{
		}

		private void InitItems()
		{
		}

		protected virtual void CreateItems()
		{
		}

		protected virtual void InitSelectedValue()
		{
		}

		private void UpdateDisplay()
		{
		}

		public void OnChangeValue(int value)
		{
		}

		protected string GetDisplayString(InputBinding binding)
		{
			return null;
		}
	}
}
