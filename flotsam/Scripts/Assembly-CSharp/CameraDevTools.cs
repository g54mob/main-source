using System;
using UnityEngine;
using UnityEngine.UI;

public class CameraDevTools : MonoBehaviour, IUIFlagsProvider
{
	[SerializeField]
	private RecordingCameraController _recordingCameraControllerPrefab;

	[SerializeField]
	private LabelledButton _presetButtonPrefab;

	[SerializeField]
	private Transform _presetButtonParent;

	[Header("Camera Properties")]
	[SerializeField]
	private Slider _fovSlider;

	[SerializeField]
	private Slider _movementSpeedSlider;

	[SerializeField]
	private Slider _rotationSpeedSlider;

	[Header("Turn around camera")]
	[SerializeField]
	private Toggle _turnaroundToggle;

	[SerializeField]
	private Slider _turnaroundSpeedSlider;

	[SerializeField]
	private Slider _turnaroundAngleSlider;

	[SerializeField]
	private Slider _turnaroundRadiusSlider;

	[SerializeField]
	private Slider _turnaroundOffsetSlider;

	[Header("Debug")]
	[SerializeField]
	private Toggle _debugCinematicLock;

	private static CameraDevTools _instance;

	private RecordingCameraController _recordingCameraController;

	private Camera _mainCamera;

	private Camera _uiCamera;

	private LabelledButton[] _presetButtons;

	public static bool CinematicCameraIsActive { get; private set; }

	public PanelContainerFlags Flags => PanelContainerFlags.BlockCursorContext;

	public bool BlockCancel => false;

	public static bool DebugCinematicLock
	{
		get
		{
			if (Application.isEditor && (bool)_instance && (bool)_instance._debugCinematicLock)
			{
				return _instance._debugCinematicLock.isOn;
			}
			return false;
		}
	}

	private void Awake()
	{
		if ((bool)_instance)
		{
			Debug.LogException(new Exception("Multiple CameraDevTools instances are active!"));
		}
		_instance = this;
		_mainCamera = CameraController.Instance.Camera;
		_uiCamera = CameraController.Instance.UICamera;
		_recordingCameraController = UnityEngine.Object.Instantiate(_recordingCameraControllerPrefab);
		_recordingCameraController.Camera.enabled = false;
		_presetButtons = new LabelledButton[_recordingCameraController.SavedCameras.Count];
		for (int i = 0; i < _recordingCameraController.SavedCameras.Count; i++)
		{
			LabelledButton labelledButton = UnityEngine.Object.Instantiate(_presetButtonPrefab, _presetButtonParent);
			labelledButton.Label.text = _recordingCameraController.SavedCameras[i].name;
			int index = i;
			labelledButton.onClick.AddListener(delegate
			{
				SetPreset(index);
			});
			_presetButtons[i] = labelledButton;
		}
		_fovSlider.value = _recordingCameraController.Camera.fieldOfView;
		_fovSlider.onValueChanged.AddListener(SetCameraFOV);
		_movementSpeedSlider.value = _recordingCameraController.MoveSpeed;
		_movementSpeedSlider.onValueChanged.AddListener(SetCameraMoveSpeed);
		_rotationSpeedSlider.value = _recordingCameraController.RotationSpeed;
		_rotationSpeedSlider.onValueChanged.AddListener(SetCameraRotationSpeed);
		_turnaroundToggle.onValueChanged.AddListener(ToggleTurnaround);
		_turnaroundSpeedSlider.value = _recordingCameraController.TurnaroundSpeed;
		_turnaroundSpeedSlider.onValueChanged.AddListener(SetTurnaroundSpeed);
		_turnaroundAngleSlider.value = _recordingCameraController.TurnaroundVerticalAngle;
		_turnaroundAngleSlider.onValueChanged.AddListener(SetTurnaroundAngle);
		_turnaroundRadiusSlider.value = _recordingCameraController.TurnaroundRadius;
		_turnaroundRadiusSlider.onValueChanged.AddListener(SetTurnaroundRadius);
		_turnaroundOffsetSlider.value = _recordingCameraController.TurnaroundHeightOffset;
		_turnaroundOffsetSlider.onValueChanged.AddListener(SetTurnaroundOffset);
		GameEventDispatcher.AddListener(GameEventType.ActiveInputUpdated, OnActiveInputUpdated);
	}

	private void Update()
	{
		_turnaroundToggle.interactable = Selector.Selection != null;
		if (!_turnaroundToggle.interactable)
		{
			_turnaroundToggle.isOn = false;
		}
	}

	private void OnDestroy()
	{
		LabelledButton[] presetButtons = _presetButtons;
		for (int i = 0; i < presetButtons.Length; i++)
		{
			presetButtons[i].onClick.RemoveAllListeners();
		}
		_fovSlider.onValueChanged.RemoveListener(SetCameraFOV);
		_movementSpeedSlider.onValueChanged.RemoveListener(SetCameraMoveSpeed);
		_rotationSpeedSlider.onValueChanged.RemoveListener(SetCameraRotationSpeed);
		_turnaroundToggle.onValueChanged.RemoveListener(ToggleTurnaround);
		_turnaroundSpeedSlider.onValueChanged.RemoveListener(SetTurnaroundSpeed);
		_turnaroundAngleSlider.onValueChanged.RemoveListener(SetTurnaroundAngle);
		_turnaroundRadiusSlider.onValueChanged.RemoveListener(SetTurnaroundRadius);
		_turnaroundOffsetSlider.onValueChanged.RemoveListener(SetTurnaroundOffset);
		_instance = null;
	}

	public void OverwriteCurrentCamera()
	{
		_recordingCameraController.OverwriteCurrentCamera();
	}

	private void SetPreset(int index)
	{
		_recordingCameraController.SetSavedCamera(index);
	}

	public void ToggleCinematicCamera(bool active)
	{
		_mainCamera.enabled = !active;
		_uiCamera.enabled = !active;
		if (active)
		{
			UIManager.AddFlagsProvider(this);
		}
		else
		{
			UIManager.RemoveFlagsProvider(this);
		}
		_recordingCameraController.Camera.enabled = active;
		if (active)
		{
			_recordingCameraController.ResetCurrentCamera();
		}
		CinematicCameraIsActive = active;
		OnActiveInputUpdated();
	}

	public void ToggleUI(bool active)
	{
		if (active)
		{
			GameManager.UIManager.EnableUI();
		}
		else
		{
			GameManager.UIManager.DisableUI();
		}
	}

	public void SetUseLocalAxis(bool value)
	{
		_recordingCameraController.UseLocalUpAxis = value;
	}

	private void SetCameraFOV(float value)
	{
		_recordingCameraController.Camera.fieldOfView = value;
	}

	private void SetCameraMoveSpeed(float value)
	{
		_recordingCameraController.MoveSpeed = value;
	}

	private void SetCameraRotationSpeed(float value)
	{
		_recordingCameraController.RotationSpeed = value;
	}

	private void ToggleTurnaround(bool value)
	{
		ToggleCinematicCamera(value);
		ToggleUI(!value);
		if (value)
		{
			_recordingCameraController.TurnaroundGameObject = Selector.Selection.ObjectToSelect;
		}
		else
		{
			_recordingCameraController.TurnaroundGameObject = null;
		}
	}

	private void SetTurnaroundSpeed(float value)
	{
		_recordingCameraController.TurnaroundSpeed = value;
	}

	private void SetTurnaroundAngle(float value)
	{
		_recordingCameraController.TurnaroundVerticalAngle = value;
	}

	private void SetTurnaroundRadius(float value)
	{
		_recordingCameraController.TurnaroundRadius = value;
	}

	private void SetTurnaroundOffset(float value)
	{
		_recordingCameraController.TurnaroundHeightOffset = value;
	}

	private void OnActiveInputUpdated(GameEvent gameEvent = null)
	{
		if (FlotsamInputManager.HasActiveInput(InputFlags.Joystick) && _recordingCameraController.Camera.enabled)
		{
			UIManager.AddFlagsProvider(this);
		}
		else
		{
			UIManager.RemoveFlagsProvider(this);
		}
	}
}
