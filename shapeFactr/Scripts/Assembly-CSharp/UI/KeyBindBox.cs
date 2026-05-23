using InputControl;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace UI
{
	public class KeyBindBox : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private TMP_Text text;

		[SerializeField]
		private CursorUIItem cursorUIItem;

		private UnityAction<InputAction, int> _onClickAction;

		private UnityAction<InputAction, int> _onRightClickAction;

		private UnityAction<RectTransform, bool> _onMouseOverAction;

		private InputAction _inputAction;

		private int _bindingIndex;

		private bool _isKeyBinding;

		private bool _canDeleteBind;

		private bool _isPadKey;

		public CursorUIItem CursorUIItem => null;

		public void Init(InputAction inputAction, int bindingIndex, bool isPadKey, UnityAction<InputAction, int> onClickAction, UnityAction<InputAction, int> onRightClickAction, UnityAction<RectTransform, bool> onMouseOverAction)
		{
		}

		private void UpdateDisplay()
		{
		}

		private string GetDisplayString()
		{
			return null;
		}

		private string GetDisplayString(InputBinding binding)
		{
			return null;
		}

		public void OnClickButton()
		{
		}

		public void OnSwitchButton()
		{
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}

		public void OnPointerEnter()
		{
		}

		public void OnPointerExit()
		{
		}
	}
}
