using System.Collections.Generic;
using InputControl;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace UI
{
	public class KeyConfigCell : MonoBehaviour
	{
		[SerializeField]
		private GameObject separate;

		[SerializeField]
		private TMP_Text actionNameText;

		[SerializeField]
		private RectTransform keyListParent;

		[SerializeField]
		private KeyBindBox bindBoxKey;

		[SerializeField]
		private KeyBindBox bindBoxMouse;

		[SerializeField]
		private KeyBindDropdownLR bindDropdownLR;

		[SerializeField]
		private KeyBindDropdownControlType bindDropdownControlType;

		[SerializeField]
		private Color defaultColor;

		[SerializeField]
		private Color errorColor;

		private List<KeyBindBox> createdKeyBindBox;

		private MstGameActionEntities entities;

		private UnityAction<InputAction, int> onClickAction;

		private UnityAction<InputAction, int> onRightClickAction;

		private UnityAction<RectTransform, bool> onMouseOverAction;

		private UnityAction<InputAction, int, int> onValueChangedAction;

		public IEnumerable<CursorUIBase> CursorUIItemList => null;

		public void Init(bool showSeparate, MstGameActionEntities gameAction, UnityAction<InputAction, int> onClickAction, UnityAction<InputAction, int> onRightClickAction, UnityAction<RectTransform, bool> onMouseOverAction)
		{
		}

		public void Init(bool showSeparate, MstGameActionEntities gameAction, UnityAction<InputAction, int, int> onValueChangedAction)
		{
		}

		public void UpdateDisplay(List<(InputAction inputAction, int bindingIndex)> duplicateActions = null)
		{
		}

		public List<(InputAction, int)> GetInputActions()
		{
			return null;
		}
	}
}
