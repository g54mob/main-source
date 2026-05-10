using CTS.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS.UI
{
	public class ButtonInput : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private CTSButton _button;

		[SerializeField]
		private InputActionReference _input;

		[SerializeField]
		private CanvasGroupController _canvasLock;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			if ((bool)_input && _input.action != null)
			{
				_input.action.performed += OnInput;
			}
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			if ((bool)_input && _input.action != null)
			{
				_input.action.performed -= OnInput;
			}
		}

		private void OnInput(InputAction.CallbackContext context)
		{
			if (!UIUtility.InInputField() && !_button.ObjectLock.IsLocked() && !ToggleInput.ObjectLock.IsLocked)
			{
				CanvasGroupController canvasLock = _canvasLock;
				if (!canvasLock || !canvasLock.ObjectLock.IsLocked())
				{
					_button.OnSubmit(null);
				}
			}
		}
	}
}
