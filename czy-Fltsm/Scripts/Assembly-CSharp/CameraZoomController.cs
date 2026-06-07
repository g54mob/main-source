using System;
using System.Linq;
using PajamaLlama.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraZoomController : SceneBehaviour
{
	[Serializable]
	public struct Settings
	{
		[Range(0f, 1f)]
		public float Initial;

		[MinMaxRangeFloat(0f, 5000f)]
		public RangedFloat Range;

		public float Speed;

		[Range(0.1f, 1f)]
		public float Easing;

		public AnimationCurve Movement;

		public AnimationCurve MovementSpeedMultiplier;

		public bool ApplyLookAt;
	}

	[Header("General")]
	[SerializeField]
	private UIState[] _disabledStates;

	[Header("Zoom")]
	[SerializeField]
	private Transform _zoomTransform;

	[Header("Settings")]
	[SerializeField]
	private Settings _mouseSettings;

	[SerializeField]
	private Settings _joystickSettings;

	[Header("Swivel")]
	[SerializeField]
	private Transform _swivelTransform;

	[Header("Shadows")]
	[SerializeField]
	private bool _overrideShadowDistance;

	[SerializeField]
	[ConditionalHide(false, ConditionalSourceField = "_overrideShadowDistance")]
	private AnimationCurve _shadowDistanceCurve;

	private Settings _settings;

	private float _zoomTimer;

	private bool _isCinematicLocked;

	public RangedFloat ZoomRange => _settings.Range;

	public float DesiredZoomLevel { get; private set; }

	public float CurrentZoomLevel { get; private set; }

	public bool IsInterpolating => _zoomTimer > 0f;

	public bool IsPlayerZooming { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		SetZoom(ReturnSettings().Initial, overwriteDesiredZoom: true);
	}

	private void OnEnable()
	{
		_settings = ReturnSettings();
		if (_overrideShadowDistance)
		{
			ApplyShadowDistanceOverride();
		}
		else
		{
			ShadowManager.ResetShadowDistance();
		}
	}

	private void OnDisable()
	{
		ShadowManager.ResetShadowDistance();
	}

	private void Update()
	{
		if (!ReturnIsDisabled())
		{
			float currentZoomLevel = CurrentZoomLevel;
			IsPlayerZooming = ZoomControls(FlotsamInputManager.GetCameraZoom());
			InterpolateZoom();
			if (IsPlayerZooming && CurrentZoomLevel != currentZoomLevel)
			{
				CameraGameEvent.DispatchManualZoom(CurrentZoomLevel - currentZoomLevel);
			}
		}
	}

	private void LateUpdate()
	{
		_settings = ReturnSettings();
	}

	public void SetIsCinematicLocked(bool isCinematicLocked)
	{
		_isCinematicLocked = isCinematicLocked;
	}

	private bool ZoomControls(float zoomInput)
	{
		if (Mathf.Approximately(zoomInput, 0f))
		{
			return false;
		}
		if (!Application.isFocused)
		{
			return false;
		}
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return false;
		}
		LandmarkBehaviour.IsCameraLocked = false;
		float num = (global::Settings.Instance.GameplayPlayerData.InvertScrolling ? (-1f) : 1f);
		SetDesiredZoom(DesiredZoomLevel + zoomInput * _settings.Speed * GameSpeedManager.PausableUnscaledDeltaTime * num * global::Settings.Instance.GameplayPlayerData.ScrollingSensitivity, _settings.Easing);
		return true;
	}

	public void SetDesiredZoom(float desiredZoom, float smoothness)
	{
		desiredZoom = Mathf.Clamp01(desiredZoom);
		if (!Mathf.Approximately(desiredZoom, DesiredZoomLevel))
		{
			DesiredZoomLevel = desiredZoom;
			_zoomTimer = smoothness;
			ApplyShadowDistanceOverride();
		}
		if (!IsInterpolating)
		{
			if (Mathf.Approximately(DesiredZoomLevel, 1f))
			{
				CameraGameEvent.DispatchMaxZoom();
			}
			if (Mathf.Approximately(DesiredZoomLevel, 0f))
			{
				CameraGameEvent.DispatchMinZoom();
			}
		}
	}

	public void SetZoom(float zoom, bool overwriteDesiredZoom = false)
	{
		_settings = ReturnSettings();
		CurrentZoomLevel = Mathf.Clamp01(zoom);
		if (overwriteDesiredZoom)
		{
			DesiredZoomLevel = CurrentZoomLevel;
		}
		_zoomTransform.localPosition = ReturnZoomPosition(zoom);
		if (_settings.ApplyLookAt)
		{
			_zoomTransform.LookAt(_swivelTransform.position);
		}
		AudioManager.SetZoomLevelParameter(CurrentZoomLevel);
	}

	private void InterpolateZoom(bool checkZoomTimer = true)
	{
		if (!checkZoomTimer || !(_zoomTimer <= 0f))
		{
			_zoomTimer -= GameSpeedManager.PausableUnscaledDeltaTime;
			SetZoom(Mathf.Lerp(CurrentZoomLevel, DesiredZoomLevel, _settings.Easing));
		}
	}

	private void ApplyShadowDistanceOverride()
	{
		if (_overrideShadowDistance)
		{
			ShadowManager.SetShadowDistance(_shadowDistanceCurve.Evaluate(DesiredZoomLevel));
		}
	}

	public float ReturnMovementSpeedMultiplier()
	{
		return CalculateMovementSpeedMultiplier(CurrentZoomLevel);
	}

	private float CalculateMovementSpeedMultiplier(float zoomLevel)
	{
		zoomLevel = Mathf.Clamp(zoomLevel, 0f, 1f);
		float result = 1f;
		if (_settings.MovementSpeedMultiplier.keys.Length != 0)
		{
			float time = (1f - zoomLevel) * _settings.MovementSpeedMultiplier.keys.LastOrDefault().time;
			result = _settings.MovementSpeedMultiplier.Evaluate(time);
		}
		return result;
	}

	private Vector3 ReturnZoomPosition(float zoomLevel)
	{
		float num = zoomLevel * (_settings.Range.Maximum - _settings.Range.Minimum);
		Vector3 vector = new Vector3(0f, 0f, 0f - num - _settings.Range.Minimum);
		if (_settings.Movement.keys.Length != 0)
		{
			float time = (1f - zoomLevel) * _settings.Movement.keys.LastOrDefault().time;
			return vector + Vector3.up * _settings.Movement.Evaluate(time);
		}
		return vector;
	}

	private bool ReturnIsDisabled()
	{
		if (UIManager.HasFlagsSet(PanelContainerFlags.BlockCameraInput) || _isCinematicLocked || CameraDevTools.CinematicCameraIsActive)
		{
			return true;
		}
		if (_disabledStates == null)
		{
			return false;
		}
		UIState state = UIManager.State;
		UIState[] disabledStates = _disabledStates;
		foreach (UIState uIState in disabledStates)
		{
			if (state == uIState)
			{
				return true;
			}
		}
		return false;
	}

	private Settings ReturnSettings()
	{
		if (FlotsamInputManager.IsJoystick)
		{
			return _joystickSettings;
		}
		return _mouseSettings;
	}
}
