using System;
using System.Collections;
using CTS.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	[DefaultExecutionOrder(-30)]
	public class CameraFollowing : MonoSingleton<CameraFollowing>
	{
		public enum LockType
		{
			Tutorial = 0,
			Soft = 1,
			Hard = 2
		}

		[SerializeField]
		private float _attachmentDuration = 0.75f;

		[SerializeField]
		private AnimationCurve _attachCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		private MainCamera _mainCameraRef;

		private CameraZoom _cameraZoomRef;

		private CameraMovements _cameraMovementsRef;

		private Coroutine _targetRoutine;

		private Transform _currentTransform;

		private LockToggle _movementToggle;

		private bool _isEventLock;

		public event Action<bool> OnTrackingStatusChanged;

		protected override void SingletonAwake()
		{
			_mainCameraRef = GetComponent<MainCamera>();
			_cameraZoomRef = GetComponent<CameraZoom>();
			_cameraMovementsRef = GetComponent<CameraMovements>();
			_movementToggle = new LockToggle(_cameraMovementsRef);
		}

		private void OnEnable()
		{
			InputManager.game.toggleTracking.onComplete += OnInputToggleTracking;
			_cameraMovementsRef.OnValueChanged += OnMoved;
			_mainCameraRef.CVarLockType.SubscribeToChange(OnLockTypeChanged);
			_mainCameraRef.CVarTracking.SubscribeToChange(OnTargetingValueChanged);
		}

		private void OnDisable()
		{
			InputManager.game.toggleTracking.onComplete -= OnInputToggleTracking;
			_cameraMovementsRef.OnValueChanged -= OnMoved;
			_mainCameraRef.CVarLockType.UnsubscribeToChange(OnLockTypeChanged);
			_mainCameraRef.CVarTracking.UnsubscribeToChange(OnTargetingValueChanged);
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void OnInputToggleTracking(InputAction.CallbackContext ctx)
		{
			if ((LockType)_mainCameraRef.CVarLockType != LockType.Tutorial && _mainCameraRef.CVarTracking.GetCurrentValue() && (bool)_currentTransform)
			{
				if (_targetRoutine == null)
				{
					Lock(_currentTransform);
				}
				else
				{
					StopTargetRoutine();
				}
			}
		}

		private void OnLockTypeChanged(LockType p_lockType)
		{
			if ((LockType)_mainCameraRef.CVarLockType != LockType.Tutorial && _mainCameraRef.CVarTracking.GetCurrentValue())
			{
				if (_isEventLock)
				{
					EventLock(_currentTransform);
				}
				else
				{
					Lock(_currentTransform);
				}
			}
		}

		private void OnTargetingValueChanged(bool p_value)
		{
			if ((LockType)_mainCameraRef.CVarLockType == LockType.Tutorial)
			{
				return;
			}
			if (p_value)
			{
				if (_isEventLock)
				{
					EventLock(_currentTransform);
				}
				else
				{
					Lock(_currentTransform);
				}
			}
			else
			{
				StopTargetRoutine();
			}
		}

		private void OnMoved(float p_distance)
		{
			if ((LockType)_mainCameraRef.CVarLockType == LockType.Soft)
			{
				StopTargetRoutine();
			}
		}

		public void EventLock(Transform p_transform)
		{
			Lock(p_transform, eventLock: true);
		}

		public void Lock(Transform p_transform, bool eventLock = false)
		{
			_isEventLock = eventLock;
			if ((LockType)_mainCameraRef.CVarLockType == LockType.Tutorial)
			{
				StopTargetRoutine();
				_currentTransform = p_transform;
				_targetRoutine = StartCoroutine(LockUpdate(p_transform));
				return;
			}
			bool flag = _mainCameraRef.CVarTracking.GetCurrentValue() || _isEventLock;
			if (!p_transform || !flag)
			{
				_currentTransform = null;
				StopTargetRoutine();
			}
			else
			{
				_currentTransform = p_transform;
				_targetRoutine = StartCoroutine(LockUpdate(p_transform));
			}
		}

		private IEnumerator LockUpdate(Transform p_transform)
		{
			if (!p_transform)
			{
				yield break;
			}
			MonoSingleton<FloorsManager>.Instance.ChangeCurrentFloor(FloorsManager.GetNearestFloorIndex(p_transform.position.y));
			this.OnTrackingStatusChanged?.Invoke(obj: true);
			_movementToggle.Lock();
			Vector3 startPos = _mainCameraRef.GroundPoint;
			for (float time = 0f; time < 1f; time += Time.unscaledDeltaTime / _attachmentDuration)
			{
				Vector3 vector = base.transform.forward * _cameraZoomRef.Distance;
				Vector3 vector2 = Vector3.up * _mainCameraRef.PlaneHeightOffset;
				base.transform.position = Vector3.Lerp(startPos - vector, p_transform.position + vector2 - vector, _attachCurve.Evaluate(time));
				yield return null;
			}
			_movementToggle.Unlock();
			while (true)
			{
				Vector3 vector3 = base.transform.forward * _cameraZoomRef.Distance;
				Vector3 vector4 = Vector3.up * _mainCameraRef.PlaneHeightOffset;
				base.transform.position = p_transform.position + vector4 - vector3;
				yield return null;
			}
		}

		private void StopTargetRoutine()
		{
			_movementToggle.Unlock();
			if (_targetRoutine != null)
			{
				this.OnTrackingStatusChanged?.Invoke(obj: false);
				_targetRoutine = null;
				StopAllCoroutines();
				if (_isEventLock)
				{
					_isEventLock = false;
					_currentTransform = null;
				}
			}
		}
	}
}
