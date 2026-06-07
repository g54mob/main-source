using System.Collections;
using UnityEngine;

namespace RLD
{
	public class CameraPrjSwitchTransition
	{
		public enum Type
		{
			None = 0,
			ToOrtho = 1,
			ToPerspective = 2
		}

		private IEnumerator _transitionCrtn;

		private MonoBehaviour _targetMono;

		private Camera _targetCamera;

		private float _camFieldOfView = 60f;

		private Vector3 _camFocusPoint;

		private Vector3 _camRestorePosition;

		private Type _transitionType;

		private float _durationInSeconds = 0.23f;

		private float _progress;

		public MonoBehaviour TargetMono
		{
			get
			{
				return _targetMono;
			}
			set
			{
				if (!IsActive && value != null)
				{
					_targetMono = value;
				}
			}
		}

		public Camera TargetCamera
		{
			get
			{
				return _targetCamera;
			}
			set
			{
				if (!IsActive && value != null)
				{
					_targetCamera = value;
				}
			}
		}

		public Type TransitionType => _transitionType;

		public float DurationInSeconds
		{
			get
			{
				return _durationInSeconds;
			}
			set
			{
				if (!IsActive)
				{
					_durationInSeconds = Mathf.Max(0.01f, Mathf.Abs(value));
				}
			}
		}

		public float Progress => _progress;

		public float CamFieldOfView
		{
			get
			{
				return _camFieldOfView;
			}
			set
			{
				if (!IsActive)
				{
					_camFieldOfView = Mathf.Abs(value);
				}
			}
		}

		public Vector3 CamFocusPoint
		{
			get
			{
				return _camFocusPoint;
			}
			set
			{
				if (!IsActive)
				{
					_camFocusPoint = value;
				}
			}
		}

		public bool IsActive => _transitionType != Type.None;

		public event CameraProjectionSwitchBeginHandler TransitionBegin;

		public event CameraProjectionSwitchUpdateHandler TransitionUpdate;

		public event CameraProjectionSwitchBeginHandler TransitionEnd;

		public void Begin()
		{
			if (!(_targetMono == null) && !(_targetCamera == null))
			{
				if (IsActive)
				{
					TargetMono.StopCoroutine(_transitionCrtn);
					_transitionCrtn = null;
					_targetCamera.transform.position = _camRestorePosition;
				}
				TargetMono.StartCoroutine(_transitionCrtn = DoTransition());
			}
		}

		private IEnumerator DoTransition()
		{
			float frustumHeight = _targetCamera.orthographicSize * 2f;
			float num = 0f;
			float targetFOV = 0f;
			if (!IsActive)
			{
				if (_targetCamera.orthographic)
				{
					num = _targetCamera.GetOrthoFOV();
					targetFOV = _camFieldOfView;
					_transitionType = Type.ToPerspective;
				}
				else
				{
					num = _camFieldOfView;
					targetFOV = _targetCamera.GetOrthoFOV();
					_transitionType = Type.ToOrtho;
				}
			}
			else if (_transitionType == Type.ToOrtho)
			{
				num = _targetCamera.fieldOfView;
				targetFOV = _camFieldOfView;
				_transitionType = Type.ToPerspective;
			}
			else if (_transitionType == Type.ToPerspective)
			{
				num = _targetCamera.fieldOfView;
				targetFOV = _targetCamera.GetOrthoFOV();
				_transitionType = Type.ToOrtho;
			}
			_progress = 0f;
			if (this.TransitionBegin != null)
			{
				this.TransitionBegin(_transitionType);
			}
			float invDuration = 1f / _durationInSeconds;
			float fovSpeed = (targetFOV - num) * invDuration;
			Transform _targetTransform = _targetCamera.transform;
			_targetCamera.orthographic = false;
			_targetCamera.fieldOfView = num;
			_camRestorePosition = _targetTransform.position;
			while (_progress < 1f)
			{
				_targetCamera.fieldOfView += fovSpeed * Time.deltaTime;
				_targetCamera.transform.position = _camFocusPoint - _targetTransform.forward * _targetCamera.GetFrustumDistanceFromHeight(frustumHeight);
				_progress += Time.deltaTime * invDuration;
				_progress = Mathf.Min(1f, _progress);
				if ((fovSpeed < 0f && _targetCamera.fieldOfView <= targetFOV) || (fovSpeed > 0f && _targetCamera.fieldOfView >= targetFOV))
				{
					_progress = 1f;
					_targetCamera.fieldOfView = targetFOV;
					if (_transitionType == Type.ToOrtho)
					{
						_targetCamera.orthographic = true;
					}
					_targetTransform.position = _camRestorePosition;
					_targetCamera.fieldOfView = _camFieldOfView;
					if (this.TransitionUpdate != null)
					{
						this.TransitionUpdate(_transitionType);
					}
					yield return null;
				}
				else
				{
					if (this.TransitionUpdate != null)
					{
						this.TransitionUpdate(_transitionType);
					}
					yield return null;
				}
			}
			if (this.TransitionEnd != null)
			{
				this.TransitionEnd(_transitionType);
			}
			_transitionType = Type.None;
			_progress = 0f;
			_transitionCrtn = null;
		}
	}
}
