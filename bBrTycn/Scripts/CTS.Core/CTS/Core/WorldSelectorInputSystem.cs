using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS.Core
{
	public class WorldSelectorInputSystem : WorldSelectorInputBase
	{
		[SerializeField]
		private InputActionReference _selectAction;

		[SerializeField]
		private InputActionReference _deselectAction;

		[SerializeField]
		private InputActionReference _multiSelectionAction;

		private void OnEnable()
		{
			if ((bool)_selectAction)
			{
				_selectAction.action.performed += OnSelectPressed;
			}
			if ((bool)_deselectAction)
			{
				_deselectAction.action.performed += OnDeselectPressed;
			}
		}

		private void OnDisable()
		{
			if ((bool)_selectAction)
			{
				_selectAction.action.performed -= OnSelectPressed;
			}
			if ((bool)_deselectAction)
			{
				_deselectAction.action.performed -= OnDeselectPressed;
			}
		}

		private void OnSelectPressed(InputAction.CallbackContext ctx)
		{
			SendSelectInput();
		}

		private void OnDeselectPressed(InputAction.CallbackContext ctx)
		{
			SendDeselectInput();
		}

		public override bool IsMultiSelectionPressed()
		{
			return (bool)_multiSelectionAction & _multiSelectionAction.action.IsPressed();
		}
	}
}
