using Libs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputControl
{
	public class InputDeviceModeSwitcher : SingletonMonoBehaviour<InputDeviceModeSwitcher>
	{
		[SerializeField]
		private InputActionAsset inputActions;

		private float _inputTypeSwitchDelay;

		private int _mousePositionContinuousFrames;

		private int _lastMousePositionFrame;

		private bool _pendingMousePositionSwitch;

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		private void InitializeInputActions()
		{
		}

		private void UnsubscribeFromInputActions()
		{
		}

		private void OnMousePositionPerformed(InputAction.CallbackContext context)
		{
		}

		private void OnActionStarted(InputAction.CallbackContext context)
		{
		}

		private void UpdateMousePositionContinuity()
		{
		}

		private void ResetMousePositionTracking()
		{
		}

		private void SetInputMode(PadInputManager.InputType mode)
		{
		}

		private void UpdateInputTypeSwitchDelay()
		{
		}
	}
}
