using System;
using System.Collections;
using FMODUnity;
using PajamaLlama.Debugs;
using PajamaLlama.Generic;
using PajamaLlama.Math;
using Rewired;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(CameraZoomController))]
public class CameraController : MonoBehaviour, IUIFlagsProvider
{
	public enum CameraActions
	{
		Move = 0,
		HorizontalRotate = 1,
		VerticalRotate = 2,
		Zoom = 3,
		LockOn = 4,
		CenterOnTownheart = 6,
		ResetCamera = 7
	}

	public enum TargetFocusOrientationType
	{
		LookAtTarget = 0,
		FaceTarget = 1,
		FollowTarget = 2,
		TargetRotation = 31,
		CameraRotation = 32
	}

	[SerializeField]
	private CameraPresetProperties _preset;

	[SerializeField]
	private InputFlags _blockableInputs = InputFlags.Joystick;

	[Header("Speed")]
	[SerializeField]
	private float _moveSpeed = 200f;

	[SerializeField]
	private float _verticalRotationInterval = 8.75f;

	[SerializeField]
	private float _verticalRotationIntervalSmoothness = 0.75f;

	[Header("Limits")]
	[MinMaxRangeFloat(1f, 89f)]
	[SerializeField]
	private RangedFloat _intervalVerticalAngleLimits = new RangedFloat
	{
		Minimum = 27.5f,
		Maximum = 61.25f
	};

	[Header("Audio")]
	public StudioListener FMODListener;

	[Header("Components")]
	[SerializeField]
	private Transform _swivel;

	[SerializeField]
	[FormerlySerializedAs("_zoom")]
	private Transform _zoomTransform;

	public Camera Camera;

	public Camera UICamera;

	[Header("Other")]
	[SerializeField]
	private AnimationCurve _cameraPanCurve;

	[Space]
	[SerializeField]
	private bool _allowHDROnStart;

	[Header("Tweening")]
	[SerializeField]
	private TransformPositionTweener _centerOnTownheartTween;

	[NonSerialized]
	public Vector3 CameraPosition;

	private bool _initialized;

	private float _desiredVerticalAngle;

	private float _verticalRotationTimer;

	private Transform _lockedTransform;

	private bool _isCinematicLocked;

	private Coroutine _centerOnTownheartCoroutine;

	private IEnumerator _centerOnTransformCoroutine;

	private Player _rewiredPlayer;

	private CameraControllerGrab _grabber;

	private CameraZoomController _zoomController;

	public CameraActions CurrentCameraAction { get; private set; }

	public static CameraController Instance
	{
		get
		{
			if (_instance == null)
			{
				SetInstance(UnityEngine.Object.FindAnyObjectByType<CameraController>());
			}
			return _instance;
		}
	}

	private static CameraController _instance { get; set; }

	public float UnscaledDeltaTime => GameSpeedManager.UnscaledDeltaTime;

	public static Camera MainCamera { get; private set; }

	public static Vector3 MainCameraPosition { get; private set; }

	public float CurrentZoomLevel => _zoomController.CurrentZoomLevel;

	public float DesiredZoomLevel => _zoomController.DesiredZoomLevel;

	PanelContainerFlags IUIFlagsProvider.Flags => PanelContainerFlags.BlockCameraInput;

	bool IUIFlagsProvider.BlockCancel => false;

	public static void SetInstance(CameraController instance)
	{
		_instance = instance;
	}

	private void Start()
	{
		Initialize();
	}

	public void Initialize()
	{
		if (!_initialized)
		{
			if (Camera == null)
			{
				Debugger.Error("Camera reference not set. Trying to get it from components.", this);
				Camera = GetComponentInChildren<Camera>();
			}
			_zoomController = GetComponent<CameraZoomController>();
			Camera.allowHDR = _allowHDROnStart;
			LoadPreset();
			_desiredVerticalAngle = _swivel.localEulerAngles.x;
			CameraPosition = base.transform.position;
			_rewiredPlayer = FlotsamInputManager.RewiredPlayer;
			_grabber = new CameraControllerGrab(Camera);
			_initialized = true;
			UpdateMainCamera();
		}
	}

	private void Update()
	{
		UpdateMainCamera();
		if (CameraDevTools.CinematicCameraIsActive || _isCinematicLocked)
		{
			return;
		}
		if (_zoomController.IsPlayerZooming)
		{
			CurrentCameraAction = CameraActions.Zoom;
		}
		if (ReturnHandleInput())
		{
			float horizontalMoveAxis = 0f;
			float verticalMoveAxis = 0f;
			float horizontalRotateAxis = 0f;
			float verticalRotateAxis = 0f;
			GameObject lockObject = null;
			Vector3 movement = _grabber.GetMovement();
			base.transform.position += movement;
			if (movement != Vector3.zero)
			{
				CameraGameEvent.DispatchManualMovement(movement, movement.magnitude);
			}
			KeyboardLayoutKeyMapping(ref horizontalMoveAxis, ref verticalMoveAxis, ref horizontalRotateAxis, ref verticalRotateAxis, ref lockObject);
			EdgeScrollingInput(ref horizontalMoveAxis, ref verticalMoveAxis);
			Vector2 movementInput = new Vector2(horizontalMoveAxis, verticalMoveAxis);
			MovementControls(movementInput);
			HorizontalRotationControls(horizontalRotateAxis);
			SmoothedVerticalRotationControls(verticalRotateAxis);
			movementInput += movement.Vector2TopDown();
			LockControls(lockObject, movementInput);
		}
		InterpolateVerticalAngle();
		FollowLockedObject();
		LimitCameraDistance();
		CameraPosition = base.transform.position;
	}

	private void KeyboardLayoutKeyMapping(ref float horizontalMoveAxis, ref float verticalMoveAxis, ref float horizontalRotateAxis, ref float verticalRotateAxis, ref GameObject lockObject)
	{
		lockObject = null;
		if (_rewiredPlayer != null)
		{
			Vector4 cameraInput = FlotsamInputManager.GetCameraInput(FlotsamInputManager.Layouts.World);
			horizontalMoveAxis = cameraInput.x;
			verticalMoveAxis = cameraInput.y;
			horizontalRotateAxis = cameraInput.z;
			verticalRotateAxis = 0f;
			if (FlotsamInputManager.GetButtonDown(23))
			{
				verticalRotateAxis += 1f;
			}
			if (FlotsamInputManager.GetButtonDown(34))
			{
				verticalRotateAxis -= 1f;
			}
			if (Selector.Selection != null && FlotsamInputManager.GetButtonDown(39))
			{
				lockObject = Selector.Selection.ObjectToSelect;
			}
		}
	}

	private void EdgeScrollingInput(ref float horizontalMoveAxis, ref float verticalMoveAxis)
	{
		if (Settings.Instance.GameplayPlayerData.EdgeScrolling && Application.isFocused)
		{
			if (FlotsamInputManager.MousePosition.y <= 0f && Mathf.Approximately(verticalMoveAxis, 0f))
			{
				verticalMoveAxis = -1f;
			}
			if (FlotsamInputManager.MousePosition.y >= (float)(Screen.height - 1) && Mathf.Approximately(verticalMoveAxis, 0f))
			{
				verticalMoveAxis = 1f;
			}
			if (FlotsamInputManager.MousePosition.x <= 0f && Mathf.Approximately(horizontalMoveAxis, 0f))
			{
				horizontalMoveAxis = -1f;
			}
			if (FlotsamInputManager.MousePosition.x >= (float)(Screen.width - 1) && Mathf.Approximately(horizontalMoveAxis, 0f))
			{
				horizontalMoveAxis = 1f;
			}
		}
	}

	private void MovementControls(Vector2 movementInput)
	{
		if (!Mathf.Approximately(movementInput.x, 0f) || !Mathf.Approximately(movementInput.y, 0f))
		{
			LandmarkBehaviour.IsCameraLocked = false;
			float multiplier = _zoomController.ReturnMovementSpeedMultiplier() * Settings.Instance.GameplayPlayerData.MovementSensitivity;
			float x = ReturnMovement(movementInput.x, multiplier);
			float z = ReturnMovement(movementInput.y, multiplier);
			CurrentCameraAction = CameraActions.Move;
			Vector3 vector = new Vector3(x, 0f, z);
			base.transform.Translate(vector, Space.Self);
			CameraGameEvent.DispatchManualMovement(vector, vector.magnitude);
		}
	}

	private void HorizontalRotationControls(float rotationInput)
	{
		if (TryReturnRotation(out var rotation, rotationInput, Settings.Instance.GameplayPlayerData.InvertHorizontalRotation))
		{
			base.transform.Rotate(Vector3.up * rotation, Space.World);
			CurrentCameraAction = CameraActions.HorizontalRotate;
			CameraGameEvent.DispatchManualRotation(rotation);
		}
	}

	private void SmoothedVerticalRotationControls(float rotationInput)
	{
		if (!Mathf.Approximately(rotationInput, 0f))
		{
			LandmarkBehaviour.IsCameraLocked = false;
			if (Settings.Instance.GameplayPlayerData.InvertVerticalRotation)
			{
				rotationInput *= -1f;
			}
			_desiredVerticalAngle += rotationInput * _verticalRotationInterval;
			_desiredVerticalAngle = Mathf.Clamp(_desiredVerticalAngle, _intervalVerticalAngleLimits.Minimum, _intervalVerticalAngleLimits.Maximum);
			SetCameraVerticalRotation(_desiredVerticalAngle, _verticalRotationIntervalSmoothness);
		}
	}

	private void LockControls(GameObject lockObject, Vector2 movementInput)
	{
		if (_isCinematicLocked)
		{
			return;
		}
		if (lockObject == null)
		{
			if (!Mathf.Approximately(movementInput.x, 0f) || !Mathf.Approximately(movementInput.y, 0f))
			{
				LandmarkBehaviour.IsCameraLocked = false;
				Unlock();
			}
		}
		else
		{
			Lock(lockObject);
		}
	}

	private void LimitCameraDistance()
	{
		if (!WorldManager.IsInInteractionRadius(base.transform.position))
		{
			Vector3 townheartPosition = Construction.TownheartPosition;
			Vector3 vector = base.transform.position - townheartPosition;
			vector.Normalize();
			vector *= (float)GameSettings.Instance.GameplaySettings.InteractionRadius;
			base.transform.position = vector + townheartPosition;
		}
	}

	private void InterpolateVerticalAngle()
	{
		if (!(_verticalRotationTimer <= 0f))
		{
			_verticalRotationTimer -= UnscaledDeltaTime;
			float x = Mathf.Lerp(_swivel.localEulerAngles.x, _desiredVerticalAngle, 1f - _verticalRotationTimer / _verticalRotationIntervalSmoothness);
			_swivel.localEulerAngles = new Vector3(x, _swivel.localEulerAngles.y, _swivel.localEulerAngles.z);
		}
	}

	private void SetCameraVerticalRotation(float desiredAngle, float smoothness)
	{
		_verticalRotationTimer = smoothness;
		_desiredVerticalAngle = desiredAngle;
	}

	public void Lock(GameObject lockObject, float zoomLevel = 0f)
	{
		Lock(lockObject.transform, zoomLevel);
	}

	public void Lock(Transform target, float zoomLevel)
	{
		if (!_isCinematicLocked)
		{
			_zoomController.SetZoom(zoomLevel, overwriteDesiredZoom: true);
			_lockedTransform = target.transform;
		}
	}

	public void SetZoom(float level, bool overwriteDesiredZoom)
	{
		if (!_isCinematicLocked)
		{
			_zoomController.SetZoom(level, overwriteDesiredZoom);
		}
	}

	public void Unlock()
	{
		if (!_isCinematicLocked)
		{
			_lockedTransform = null;
			StartCoroutine(GroundCameraCoroutine());
		}
	}

	public void Unlock(GameObject unlockObject)
	{
		if (_lockedTransform == unlockObject.transform)
		{
			if (_isCinematicLocked)
			{
				UnlockCinematicLock(centerOnTransform: true);
			}
			else
			{
				Unlock();
			}
		}
	}

	private void FollowLockedObject()
	{
		if (!(_lockedTransform == null))
		{
			Vector3 vector = _lockedTransform.position - _swivel.localPosition;
			base.transform.position = vector.SetY(Mathf.Clamp(vector.y, 0f, vector.y));
		}
	}

	public void CenterOnTownheart(bool usePreset = false)
	{
		if (!_isCinematicLocked)
		{
			if (_lockedTransform != null)
			{
				Unlock();
			}
			if (usePreset)
			{
				LoadPreset();
			}
			else if (_centerOnTownheartCoroutine == null)
			{
				_centerOnTownheartCoroutine = StartCoroutine(CenterOnTownheartRoutine(Construction.Townheart ? Construction.Townheart.transform.position : Vector3.zero));
			}
			CameraGameEvent.DispatchReset();
		}
	}

	private IEnumerator CenterOnTownheartRoutine(Vector3 townheartPosition)
	{
		_centerOnTownheartTween.Initialize(townheartPosition);
		yield return Tweener.TweenRoutine(_centerOnTownheartTween.Duration, _centerOnTownheartTween.Easing, true, _centerOnTownheartTween);
		_centerOnTownheartCoroutine = null;
	}

	public void CinematicLock(Transform target, float targetZoomLevel, TargetFocusOrientationType orientationType = TargetFocusOrientationType.LookAtTarget, UnityAction completedCallback = null)
	{
		if (!_isCinematicLocked)
		{
			CenterOnTransform(target, targetZoomLevel, orientationType, completedCallback);
			Lock(target, targetZoomLevel);
			UIManager.AddFlagsProvider(this);
			_isCinematicLocked = true;
			if ((bool)_zoomController)
			{
				_zoomController.SetIsCinematicLocked(isCinematicLocked: true);
			}
			GameEventDispatcher.AddListener(GameEventType.DialogueEnded, OnCinematicDialogueEnded);
		}
	}

	public void UnlockCinematicLock(bool centerOnTransform)
	{
		if (_isCinematicLocked)
		{
			if (centerOnTransform)
			{
				_centerOnTransformCoroutine = MoveToPositionCoroutine(base.transform.position.Leveled(), _preset.Rotation, base.transform.rotation, _preset.ZoomLevel, TargetFocusOrientationType.FollowTarget, UnlockCinematicLockInternal);
				StartCoroutine(_centerOnTransformCoroutine);
			}
			else
			{
				UnlockCinematicLockInternal();
			}
		}
	}

	private void OnCinematicDialogueEnded(GameEvent gameEvent)
	{
		if (gameEvent is DialogueGameEvent { IsToBeContinued: false })
		{
			GameEventDispatcher.RemoveListener(GameEventType.DialogueEnded, OnCinematicDialogueEnded);
			UnlockCinematicLock(centerOnTransform: true);
		}
	}

	private void UnlockCinematicLockInternal()
	{
		UIManager.RemoveFlagsProvider(this);
		_isCinematicLocked = false;
		if (_zoomController != null)
		{
			_zoomController.SetIsCinematicLocked(isCinematicLocked: false);
		}
		Unlock();
	}

	public bool CenterOnTransform(Transform target, float targetZoomLevel, TargetFocusOrientationType orientationType = TargetFocusOrientationType.LookAtTarget, UnityAction onCompletedCallback = null)
	{
		if (_centerOnTransformCoroutine != null || _isCinematicLocked)
		{
			return false;
		}
		Unlock();
		_centerOnTransformCoroutine = MoveToPositionCoroutine(target.position, target.forward, target.rotation, targetZoomLevel, orientationType, onCompletedCallback);
		StartCoroutine(_centerOnTransformCoroutine);
		return true;
	}

	private IEnumerator MoveToPositionCoroutine(Vector3 targetPosition, Vector3 targetForward, Quaternion targetRotation, float targetZoomLevel, TargetFocusOrientationType orientationType, UnityAction onCompletedCallback, float duration = 1f)
	{
		Camera.transform.SetParent(null, worldPositionStays: true);
		switch (orientationType)
		{
		case TargetFocusOrientationType.LookAtTarget:
			targetRotation = Quaternion.LookRotation(targetPosition - base.transform.position);
			break;
		case TargetFocusOrientationType.FaceTarget:
			targetRotation = Quaternion.LookRotation(-targetForward, Vector3.up);
			break;
		case TargetFocusOrientationType.FollowTarget:
			targetRotation = Quaternion.Euler(targetForward);
			break;
		default:
			targetRotation = base.transform.rotation;
			break;
		case TargetFocusOrientationType.TargetRotation:
			break;
		}
		if (targetPosition != base.transform.position || targetRotation != base.transform.rotation || targetZoomLevel != _zoomController.CurrentZoomLevel)
		{
			base.transform.SetPositionAndRotation(targetPosition, targetRotation);
			_zoomController.SetZoom(targetZoomLevel, overwriteDesiredZoom: true);
			float time = 0f;
			Camera.transform.GetPositionAndRotation(out var fromPosition, out var fromRotation);
			while (time < duration)
			{
				time = Mathf.Min(time + UnscaledDeltaTime, duration);
				float num = time / duration;
				float t = _cameraPanCurve.Evaluate(num);
				Camera.transform.SetPositionAndRotation(Vector3.Lerp(fromPosition, _zoomTransform.position, t), Quaternion.Lerp(fromRotation, _zoomTransform.rotation, num));
				yield return null;
			}
		}
		Camera.transform.SetParent(_zoomTransform, worldPositionStays: true);
		Camera.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
		_centerOnTransformCoroutine = null;
		onCompletedCallback?.Invoke();
	}

	public Vector3 ReturnFocusPoint()
	{
		return _swivel.transform.position;
	}

	private void UpdateMainCamera()
	{
		MainCameraPosition = (MainCamera = Camera.main).transform.position;
	}

	private IEnumerator GroundCameraCoroutine()
	{
		while (Mathf.Abs(base.transform.position.y) > 0.01f)
		{
			Vector3 vector = base.transform.position.Leveled() - base.transform.position;
			base.transform.position += vector * Time.deltaTime;
			yield return null;
		}
		base.transform.position = base.transform.position.Leveled();
	}

	public void SetAudioListenerEnabled(bool enabled)
	{
		FMODListener.enabled = enabled;
	}

	public bool ReturnHandleInput()
	{
		if (GameManager.Gamepaused || UIManager.State == UIState.Map || _centerOnTownheartCoroutine != null || _centerOnTransformCoroutine != null || (FlotsamInputManager.HasActiveInput(_blockableInputs) && UIManager.HasFlagsSet(PanelContainerFlags.BlockCameraInput)))
		{
			return false;
		}
		return true;
	}

	public CameraPresetProperties ReturnPreset()
	{
		CameraPresetProperties cameraPresetProperties = ScriptableObject.CreateInstance<CameraPresetProperties>();
		cameraPresetProperties.Position = base.transform.position;
		cameraPresetProperties.Rotation = base.transform.localRotation.eulerAngles;
		cameraPresetProperties.SwivelRotation = _swivel.localRotation.eulerAngles;
		cameraPresetProperties.ZoomLevel = _zoomController.CurrentZoomLevel;
		return cameraPresetProperties;
	}

	public float ReturnMovement(float movementInput, float multiplier)
	{
		return movementInput * _moveSpeed * multiplier * UnscaledDeltaTime;
	}

	public bool TryReturnRotation(out float rotation, float rotationInput, bool flip)
	{
		if (Mathf.Approximately(rotationInput, 0f))
		{
			rotation = 0f;
			return false;
		}
		rotation = rotationInput * UnscaledDeltaTime * Settings.Instance.GameplayPlayerData.RotationSensitivity;
		if (flip)
		{
			rotation *= -1f;
		}
		return true;
	}

	public void LoadPreset(bool overridePosition = true)
	{
		if (_preset == null)
		{
			Debugger.Error("No camera preset set.", this);
			return;
		}
		ApplyPreset(_preset, overridePosition);
		Debugger.Log("Loaded camera preset.", this, 3);
	}

	public void ApplyPreset(CameraPresetProperties preset, bool overridePosition = true)
	{
		if (overridePosition)
		{
			base.transform.position = preset.Position;
		}
		base.transform.localRotation = Quaternion.Euler(preset.Rotation);
		_swivel.localRotation = Quaternion.Euler(preset.SwivelRotation);
		if (_zoomTransform == null)
		{
			Debugger.Warning("Zoom field hasn't been set.", this);
			return;
		}
		_zoomController.SetZoom(preset.ZoomLevel, overwriteDesiredZoom: true);
		_zoomTransform.LookAt(_swivel.position);
	}
}
