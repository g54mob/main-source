using Presentation.Locators;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Presentation.UI.ButtonHelpers
{
	public class InputFieldInputConsumption : MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField _inputField;

		[SerializeField]
		private InputActionAsset _inputActionAsset;

		[SerializeField]
		private UIMenuManagerLocator _uiMenuManagerLocator;

		[SerializeField]
		private Button _confirmButton;

		private bool _inputsBeingConsumed;

		private bool[] _actionMapStateBeforeConsumption;

		private void OnEnable()
		{
			_actionMapStateBeforeConsumption = new bool[_inputActionAsset.actionMaps.Count];
			_inputField.onSelect.AddListener(TurnOffInputs);
			_inputField.onDeselect.AddListener(TurnOnInputs);
			_inputField.onEndEdit.AddListener(HandleOnEndEdit);
		}

		private void OnDisable()
		{
			_inputField.onSelect.RemoveListener(TurnOffInputs);
			_inputField.onDeselect.RemoveListener(TurnOnInputs);
			_inputField.onEndEdit.RemoveListener(HandleOnEndEdit);
			TurnOnInputs();
		}

		private void HandleOnEndEdit(string _)
		{
			if (!EventSystem.current.alreadySelecting)
			{
				EventSystem.current.SetSelectedGameObject(_confirmButton.gameObject);
			}
		}

		private void TurnOffInputs(string _)
		{
			if (_inputsBeingConsumed)
			{
				return;
			}
			_actionMapStateBeforeConsumption = new bool[_inputActionAsset.actionMaps.Count];
			for (int i = 0; i < _inputActionAsset.actionMaps.Count; i++)
			{
				_actionMapStateBeforeConsumption[i] = _inputActionAsset.actionMaps[i].enabled;
				if (_inputActionAsset.actionMaps[i].enabled)
				{
					_inputActionAsset.actionMaps[i].Disable();
				}
			}
			_inputActionAsset.FindActionMap("System").Enable();
			_inputsBeingConsumed = true;
		}

		private void TurnOnInputs(string _ = null)
		{
			if (!_inputsBeingConsumed)
			{
				return;
			}
			for (int i = 0; i < _inputActionAsset.actionMaps.Count; i++)
			{
				if (_actionMapStateBeforeConsumption[i])
				{
					_inputActionAsset.actionMaps[i].Enable();
				}
				else
				{
					_inputActionAsset.actionMaps[i].Disable();
				}
			}
			_inputsBeingConsumed = false;
		}
	}
}
