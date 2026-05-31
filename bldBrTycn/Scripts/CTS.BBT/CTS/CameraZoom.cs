using System;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	[DefaultExecutionOrder(-40)]
	public class CameraZoom : MonoBehaviour
	{
		[SerializeField]
		private float _zoomUpdateSpeed = 5f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _zoomIncrementMultiplier = 0.01f;

		[SerializeField]
		[MinMaxSlider(0f, 50f)]
		private Vector2 _distanceMinMax = Vector2.one;

		[SerializeField]
		private AnimationCurve _distanceCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		[MinMaxSlider(0f, 90f)]
		private Vector2 _orientationMinMax = Vector2.one;

		[SerializeField]
		private AnimationCurve _orientationCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[SerializeField]
		[Range(0f, 1f)]
		private float _startZoomLerp = 0.5f;

		private MainCamera _cameraRef;

		private float _targetLerp;

		private float _currentLerp;

		public float Distance { get; private set; }

		public event Action<float> DistanceChanged;

		private void Awake()
		{
			_cameraRef = GetComponent<MainCamera>();
			_currentLerp = _startZoomLerp;
			_targetLerp = _currentLerp;
		}

		private void Update()
		{
			UpdateZoom(_cameraRef.GroundPoint);
		}

		private void UpdateZoom(Vector3 p_groundPoint)
		{
			_currentLerp = Mathf.Lerp(_currentLerp, _targetLerp, Time.unscaledDeltaTime * _zoomUpdateSpeed);
			float x = Mathf.Lerp(_orientationMinMax.x, _orientationMinMax.y, _orientationCurve.Evaluate(_currentLerp));
			Distance = Mathf.Lerp(_distanceMinMax.x, _distanceMinMax.y, _distanceCurve.Evaluate(_currentLerp));
			Vector3 vector = Quaternion.Euler(x, 0f, 0f) * Vector3.forward;
			Vector3 vector2 = Quaternion.Euler(0f, base.transform.eulerAngles.y, 0f) * vector;
			base.transform.SetPositionAndRotation(p_groundPoint - vector2 * Distance, Quaternion.LookRotation(vector2, Vector3.up));
		}

		public void ParamsForThisScene(CameraZoomStruct cameraZoomStruct)
		{
			if (cameraZoomStruct.IsNeedZoom)
			{
				base.enabled = true;
				_zoomUpdateSpeed = cameraZoomStruct._zoomUpdateSpeed;
				_zoomIncrementMultiplier = cameraZoomStruct._zoomIncrementMultiplier;
				_distanceMinMax = cameraZoomStruct._distanceMinMax;
				_distanceCurve = cameraZoomStruct._distanceCurve;
				_orientationMinMax = cameraZoomStruct._orientationMinMax;
				_orientationCurve = cameraZoomStruct._orientationCurve;
				_startZoomLerp = cameraZoomStruct._startZoomLerp;
			}
			else
			{
				base.enabled = false;
			}
		}

		public CameraZoomStruct GetCameraZoomStruct()
		{
			return new CameraZoomStruct
			{
				IsNeedZoom = base.enabled,
				_zoomUpdateSpeed = _zoomUpdateSpeed,
				_zoomIncrementMultiplier = _zoomIncrementMultiplier,
				_distanceMinMax = _distanceMinMax,
				_distanceCurve = _distanceCurve,
				_orientationMinMax = _orientationMinMax,
				_orientationCurve = _orientationCurve,
				_startZoomLerp = _startZoomLerp
			};
		}

		private void OnEnable()
		{
			SubscribeInputs();
		}

		private void OnDisable()
		{
			UnsubscribeInputs();
		}

		private void SubscribeInputs()
		{
			InputManager.game.cameraZoom.onComplete += OnInputZoom;
		}

		private void UnsubscribeInputs()
		{
			_targetLerp = _currentLerp;
			InputManager.game.cameraZoom.onComplete -= OnInputZoom;
		}

		private void OnInputZoom(InputAction.CallbackContext p_ctx)
		{
			float p_strength = p_ctx.ReadValue<float>();
			AddTargetZoom(p_strength);
		}

		public void AddTargetZoom(float p_strength)
		{
			if (!WorldSelector.PointerIsOverUI)
			{
				_targetLerp = Math.Clamp(_targetLerp - p_strength * _zoomIncrementMultiplier, 0f, 1f);
				this.DistanceChanged?.Invoke(_targetLerp);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		public void UpdateZoomEditor()
		{
			_currentLerp = _startZoomLerp;
			_targetLerp = _currentLerp;
			Transform obj = base.transform;
			Vector3 forward = obj.forward;
			Vector3 position = obj.position;
			Ray ray = new Ray(position, forward);
			Vector3 p_groundPoint = Vector3.zero;
			if (new Plane(Vector3.up, Vector3.zero).Raycast(ray, out var enter))
			{
				p_groundPoint = position + forward * enter;
			}
			UpdateZoom(p_groundPoint);
		}
	}
}
