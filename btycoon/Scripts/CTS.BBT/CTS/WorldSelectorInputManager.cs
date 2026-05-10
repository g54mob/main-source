using CTS.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	public class WorldSelectorInputManager : WorldSelectorInputBase
	{
		[SerializeField]
		private InputActionReference _multiSelectionInput;

		private void OnEnable()
		{
			InputManager.game.select.onComplete += OnInputSelect;
			InputManager.game.unselect.onComplete += OnInputDeselect;
		}

		private void OnDisable()
		{
			InputManager.game.select.onComplete -= OnInputSelect;
			InputManager.game.unselect.onComplete -= OnInputDeselect;
		}

		private void OnInputSelect(InputAction.CallbackContext ctx)
		{
			SendSelectInput();
		}

		private void OnInputDeselect(InputAction.CallbackContext ctx)
		{
			SendDeselectInput();
		}

		public override bool IsMultiSelectionPressed()
		{
			if ((bool)_multiSelectionInput)
			{
				return _multiSelectionInput.action.IsPressed();
			}
			return false;
		}
	}
}
