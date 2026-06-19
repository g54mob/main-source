using System;
using SharpConfig;
using UnityEngine;

namespace TH20
{
	public class DebugFlyCamera : MustCallDestroy
	{
		private readonly DebugFlyCameraConfig _config;

		private readonly InputManager _inputManager;

		private readonly GameObject _cameraObject;

		private readonly Transform _transform;

		private readonly bool _invertMousePitch;

		private readonly bool _invertJoypadPitch;

		private bool _enabled;

		private float _timeSpeedUpHeld;

		private CursorLockMode _oldCursorLockMode;

		public bool Enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				if (Enabled && !value)
				{
					Cursor.lockState = _oldCursorLockMode;
					_cameraObject.SetActive(value: false);
				}
				else if (!Enabled && value)
				{
					_oldCursorLockMode = Cursor.lockState;
					Cursor.lockState = CursorLockMode.Locked;
					_cameraObject.SetActive(value: true);
				}
				_enabled = value;
			}
		}

		public DebugFlyCamera(DebugFlyCameraConfig config, InputManager inputManager, Configuration developerPreferences)
		{
			_config = config;
			_inputManager = inputManager;
			try
			{
				_invertMousePitch = developerPreferences["Debug"]["InvertDebugCameraMousePitch"].BoolValue;
				_invertJoypadPitch = developerPreferences["Debug"]["InvertDebugCameraJoypadPitch"].BoolValue;
			}
			catch (Exception)
			{
			}
			_cameraObject = new GameObject("DebugFlyCamera");
			_cameraObject.AddComponent<Camera>().allowHDR = true;
			_transform = _cameraObject.GetComponent<Transform>();
			_enabled = false;
			_cameraObject.SetActive(value: false);
		}

		public override void Destroy()
		{
			UnityEngine.Object.Destroy(_cameraObject);
			base.Destroy();
		}

		public void Update()
		{
			if (Enabled)
			{
				float num = Input.GetAxis("Mouse X") * _config.MouseSensitivity;
				float num2 = _inputManager.GetAxis(28) * _config.JoypadRotationSensitivity * GameTime.unscaledDeltaTime;
				float num3 = Input.GetAxis("Mouse Y") * _config.MouseSensitivity;
				float num4 = _inputManager.GetAxis(29) * _config.JoypadRotationSensitivity * GameTime.unscaledDeltaTime;
				num3 = (_invertMousePitch ? (0f - num3) : num3);
				num4 = (_invertJoypadPitch ? (0f - num4) : num4);
				float y = _transform.localEulerAngles.y + num + num2;
				float num5 = 0f - _transform.localEulerAngles.x + num3 + num4;
				_transform.localEulerAngles = new Vector3(0f - num5, y, 0f);
				float num6 = _config.Speed;
				float axis = _inputManager.GetAxis(26);
				float axis2 = _inputManager.GetAxis(27);
				float num7 = axis - axis2;
				if (axis > axis2)
				{
					_timeSpeedUpHeld = Mathf.Min(_timeSpeedUpHeld + GameTime.unscaledDeltaTime, _config.SpeedUpTimeToReachMaximumSpeed);
					num6 = Mathf.Lerp(t: Mathf.Min(num7, _timeSpeedUpHeld / _config.SpeedUpTimeToReachMaximumSpeed), a: _config.SpeedUpMinimumSpeed, b: _config.SpeedUpMaximumSpeed);
				}
				else if (axis2 > 0f)
				{
					num6 = (1f + num7) * _config.SlowDownSpeed;
				}
				if (axis == 0f)
				{
					_timeSpeedUpHeld = Mathf.Max(_timeSpeedUpHeld - GameTime.unscaledDeltaTime * _config.SpeedUpReturnToZeroSpeed, 0f);
				}
				Vector3 translation = GetInputDirection() * num6 * GameTime.unscaledDeltaTime;
				float y2 = _transform.position.y;
				_transform.Translate(translation);
				if (_inputManager.GetButton(30))
				{
					_transform.position = new Vector3(_transform.position.x, y2, _transform.position.z);
				}
			}
		}

		private Vector3 GetInputDirection()
		{
			return new Vector3(0f - _inputManager.GetAxis(24), _inputManager.GetAxis(22), _inputManager.GetAxis(23));
		}
	}
}
