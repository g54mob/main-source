using Events.Generic;
using NaughtyAttributes;
using Presentation.CameraView;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControllerSwitcher : MonoBehaviour
{
	[SerializeField]
	private CameraControllerSwitcherLocator _cameraControllerSwitcherLocator;

	[SerializeField]
	private CameraView _cameraView;

	[SerializeField]
	private FreeCameraView _freeCameraView;

	[SerializeField]
	private InputActionReference _toggleCameraInputAction;

	[SerializeField]
	private BoolEvent _cameraModeChangedEvent;

	private void Awake()
	{
		_cameraControllerSwitcherLocator.SetCameraControllerSwitcher(this);
		_toggleCameraInputAction.action.performed += HandleToggleCameraInput;
	}

	private void OnDestroy()
	{
		_toggleCameraInputAction.action.performed -= HandleToggleCameraInput;
	}

	private void HandleToggleCameraInput(InputAction.CallbackContext obj)
	{
		ToggleCamera();
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ToggleCamera()
	{
		if (_cameraView.enabled)
		{
			_cameraView.enabled = false;
			_freeCameraView.enabled = true;
			_cameraModeChangedEvent.Fire(data: true);
		}
		else
		{
			_freeCameraView.enabled = false;
			_cameraView.enabled = true;
			_cameraModeChangedEvent.Fire(data: false);
		}
	}
}
