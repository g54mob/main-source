using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Controls
{
	public class CameraController : MonoBehaviour
	{
		private class CameraTarget
		{
			public Transform Transform;

			public bool FocusWhenOutOfView;

			public Rigidbody Rigidbody;

			public bool IsCameraTracker;

			public CameraTarget(Transform t, bool focus, bool isCameraTracker)
			{
				Transform = t;
				FocusWhenOutOfView = focus;
				Rigidbody = Transform.GetComponent<Rigidbody>();
				IsCameraTracker = isCameraTracker;
			}
		}

		public const float CameraSpeed = 0.15f;

		public const float MaxCameraSpeed = 2000f;

		public const float FreeMovementSpeed = 30f;

		public const float TargetFollowSpeed = 5f;

		public const float MouseFollowSpeed = 5f;

		public const float VelocitySpeed = 5f;

		public ECameraVersusMode VsFocusMode;

		public float DefaultZoom = 90f;

		public float MinZoom = 40f;

		public float MaxZoom = 150f;

		public const float ManualZoomSpeed = 20f;

		public const float AutomaticZoomSpeed = 5f;

		internal Camera Camera;

		internal bool FocusTarget;

		private Vector3 _oldPosition;

		private Vector3 _freeMovementOrigin;

		private float _targetAutomaticZoom;

		private float _previousTarget;

		private bool _usePlayerOverride;

		private float _playerZoomOverride;

		private float _autoZoomOverride;

		private bool _zoomCamera;

		private bool _rotateCamera;

		private bool _moveToCursor;

		private bool _moveToVelocity;

		private bool _freeCam;

		private bool _clampPosition;

		private Vector2 _positionMax;

		private Vector2 _positionMin;

		private float _recoilShakeAmount;

		private Vector3 _recoillShakeDirection;

		private bool _isCameraRecoilShaking;

		private Vector3 _currentVelocity = Vector3.zero;

		private Vector3 _oldVelocity;

		private bool _waitingForInput;

		private bool _firstUpdate;

		private CameraTarget _player1;

		private CameraTarget _player2;

		private readonly List<CameraTarget> _trackerList = new List<CameraTarget>();

		private float ZoomOverride
		{
			get
			{
				if (!_usePlayerOverride)
				{
					return _autoZoomOverride;
				}
				return _playerZoomOverride;
			}
			set
			{
				if (_usePlayerOverride)
				{
					_playerZoomOverride = value;
				}
				else
				{
					_autoZoomOverride = value;
				}
			}
		}

		private List<CameraTarget> TargetList
		{
			get
			{
				List<CameraTarget> list = new List<CameraTarget>();
				if (_player1 != null)
				{
					list.Add(_player1);
				}
				if (_player2 != null)
				{
					list.Add(_player2);
				}
				list.AddRange(_trackerList);
				return list;
			}
		}

		private IEnumerable<CameraTarget> ActiveTargets
		{
			get
			{
				if (_trackerList.Any((CameraTarget t) => t.IsCameraTracker))
				{
					return _trackerList.Where((CameraTarget t) => t.IsCameraTracker);
				}
				List<CameraTarget> list = TargetList.Where((CameraTarget t) => t.FocusWhenOutOfView || TransformHelper.IsInsideCameraViewport(Camera, t.Transform.position, 0.1f)).ToList();
				if (!list.Any())
				{
					return TargetList;
				}
				return list;
			}
		}

		protected void Awake()
		{
			Camera = GetComponent<Camera>();
			RuntimeGlobals.MainCamera = Camera;
			RuntimeGlobals.Camera = this;
			FocusTarget = false;
			_moveToVelocity = true;
			_player1 = null;
			_player2 = null;
			_trackerList.Clear();
			_firstUpdate = true;
			_targetAutomaticZoom = DefaultZoom;
			_oldVelocity = Vector3.zero;
		}

		public void ChangeStartPosition(Vector3 pos)
		{
			base.transform.position = pos;
			_oldPosition = pos;
		}

		public void Start()
		{
			_oldPosition = base.transform.position;
			_rotateCamera = RunningModeSpecifics.Has(ERunningModeSpecific.RotateCamera);
			_moveToCursor = RunningModeSpecifics.Can(ERunningModeSpecific.MoveCameraToCursor);
			_zoomCamera = RunningModeSpecifics.Can(ERunningModeSpecific.ZoomCamera);
			_usePlayerOverride = VsFocusMode == ECameraVersusMode.Player1 || VsFocusMode == ECameraVersusMode.Player2;
			Camera.orthographicSize = DefaultZoom;
			if (RuntimeGlobals.RunningMode == ERunningMode.TestFlight || RuntimeGlobals.RunningMode == ERunningMode.TestFlightPlanet)
			{
				Camera.backgroundColor = RuntimeGlobals.Settings.BackgroundColor;
			}
		}

		public void AddPlayer(Transform trans, bool neverLoseFocus, bool instant, bool isPlayer1)
		{
			if (isPlayer1 ? (_player1 == null) : (_player2 == null))
			{
				if (isPlayer1)
				{
					_player1 = new CameraTarget(trans, neverLoseFocus, false);
				}
				else
				{
					_player2 = new CameraTarget(trans, neverLoseFocus, false);
				}
				Realign(instant);
			}
		}

		public void RemovePlayer(Transform trans, bool instant = false)
		{
			if (_player1 != null && _player1.Transform == trans)
			{
				_player1 = null;
				Realign(instant);
			}
			if (_player2 != null && _player2.Transform == trans)
			{
				_player2 = null;
				Realign(instant);
			}
		}

		public void AddTracker(Transform trans, bool neverLoseFocus, bool instant, bool isCameraTracker = true)
		{
			if (_trackerList.FirstOrDefault((CameraTarget t) => t.Transform == trans) == null)
			{
				_trackerList.Add(new CameraTarget(trans, neverLoseFocus, isCameraTracker));
				Realign(instant);
			}
		}

		public void RemoveTracker(Transform trans, bool instant = false)
		{
			CameraTarget cameraTarget = _trackerList.FirstOrDefault((CameraTarget t) => t.Transform == trans);
			if (cameraTarget != null)
			{
				_trackerList.Remove(cameraTarget);
				Realign(instant);
			}
		}

		private void Realign(bool instant)
		{
			if (FocusTarget && instant && Camera != null)
			{
				float distance;
				Vector3 vector = CalculateTargetPosition(out distance);
				vector.z = Camera.transform.position.z;
				Camera.transform.position = vector;
				_oldPosition = vector;
			}
		}

		public Transform GetFirstTarget()
		{
			if (TargetList.Count > 0)
			{
				return TargetList[0].Transform;
			}
			return RuntimeGlobals.NimbatusPlayer.transform;
		}

		public void SetClamp(bool active, Vector2 minPos, Vector2 maxPos)
		{
			_clampPosition = active;
			_positionMin = minPos;
			_positionMax = maxPos;
		}

		public void SetMode(ECameraVersusMode mode)
		{
			if (VsFocusMode != mode)
			{
				switch (mode)
				{
				case ECameraVersusMode.Player1:
				case ECameraVersusMode.Player2:
					_usePlayerOverride = true;
					_autoZoomOverride = 0f;
					break;
				case ECameraVersusMode.Auto:
					_usePlayerOverride = false;
					break;
				case ECameraVersusMode.Free:
					StartCoroutine(_WaitForManualInput());
					break;
				}
				VsFocusMode = mode;
			}
		}

		public void ToggleFreeCam(bool freeCam)
		{
			_freeCam = freeCam;
			MaxZoom *= (_freeCam ? 4f : 0.25f);
			SetMode(_freeCam ? ECameraVersusMode.Free : ECameraVersusMode.Off);
		}

		private void CheckMode()
		{
			if ((VsFocusMode == ECameraVersusMode.Player1 && _player1 == null) || (VsFocusMode == ECameraVersusMode.Player2 && _player2 == null))
			{
				VsFocusMode = ECameraVersusMode.Auto;
			}
		}

		internal void LateUpdate()
		{
			if (RuntimeGlobals.BlockUInteraction)
			{
				return;
			}
			Vector3 vector = Camera.transform.position;
			float z = base.transform.position.z;
			if (FocusTarget)
			{
				float distance;
				vector = CalculateTargetPosition(out distance);
				float num = 0f;
				switch (VsFocusMode)
				{
				case ECameraVersusMode.Off:
					num = Mathf.Clamp(distance + 20f, DefaultZoom, MaxZoom);
					break;
				case ECameraVersusMode.Auto:
					num = Mathf.Clamp(distance + 10f, DefaultZoom, MaxZoom);
					break;
				case ECameraVersusMode.Player1:
				case ECameraVersusMode.Player2:
					num = DefaultZoom;
					break;
				case ECameraVersusMode.Free:
					num = _previousTarget;
					break;
				}
				_previousTarget = num;
				_targetAutomaticZoom = Mathf.Lerp(_targetAutomaticZoom, num, _firstUpdate ? 1f : (Time.smoothDeltaTime * 5f));
				_oldPosition = Vector3.Lerp(_oldPosition, vector, _firstUpdate ? 1f : (Time.unscaledDeltaTime * 5f));
				vector = _oldPosition;
			}
			else
			{
				_targetAutomaticZoom = Mathf.Lerp(_targetAutomaticZoom, DefaultZoom, _firstUpdate ? 1f : (Time.smoothDeltaTime * 5f));
			}
			vector.z = z;
			if (FocusTarget && VsFocusMode != ECameraVersusMode.Free)
			{
				if (_moveToVelocity)
				{
					vector = ApplyTargetVelocity(vector);
				}
				if (_moveToCursor && !RuntimeGlobals.IsMovementBlocked)
				{
					vector = ApplyMouseMovement(vector);
				}
				if (_isCameraRecoilShaking)
				{
					vector = CalculateRecoilShake(vector);
				}
			}
			vector.z = z;
			if (VsFocusMode == ECameraVersusMode.Free && _clampPosition)
			{
				vector = new Vector3(Mathf.Clamp(vector.x, _positionMin.x, _positionMax.x), Mathf.Clamp(vector.y, _positionMin.y, _positionMax.y), vector.z);
			}
			base.transform.position = ((VsFocusMode == ECameraVersusMode.Free && !_waitingForInput) ? Vector3.Lerp(base.transform.position, vector, 30f * Time.unscaledDeltaTime) : Vector3.SmoothDamp(base.transform.position, vector, ref _currentVelocity, _firstUpdate ? 0f : 0.15f, 2000f, Time.smoothDeltaTime));
			if (_rotateCamera)
			{
				RotateCameraToGravity(vector);
			}
			ApplyZoom();
			_firstUpdate = false;
		}

		private IEnumerator _WaitForManualInput()
		{
			_waitingForInput = true;
			while (!Input.GetMouseButtonDown(0))
			{
				yield return null;
			}
			_waitingForInput = false;
		}

		private Vector3 CalculateTargetPosition(out float distance)
		{
			if (this == null || !base.enabled)
			{
				distance = 0f;
				return Vector3.zero;
			}
			Vector3 vector = Camera.transform.position;
			distance = 0f;
			if (FocusTarget)
			{
				if (VsFocusMode == ECameraVersusMode.Free)
				{
					if (Input.GetMouseButtonDown(0))
					{
						_freeMovementOrigin = Camera.ScreenToWorldPoint(Input.mousePosition);
					}
					if (Input.GetMouseButton(0))
					{
						Vector3 vector2 = Camera.ScreenToWorldPoint(Input.mousePosition) - vector;
						vector = _freeMovementOrigin - vector2;
					}
					return vector;
				}
				if (TargetList.Count <= 0 && RuntimeGlobals.NimbatusPlayer != null)
				{
					return RuntimeGlobals.NimbatusPlayer.transform.position;
				}
				List<CameraTarget> list = ActiveTargets.ToList();
				if (VsFocusMode == ECameraVersusMode.Player1)
				{
					list = new List<CameraTarget> { _player1 };
				}
				else if (VsFocusMode == ECameraVersusMode.Player2)
				{
					list = new List<CameraTarget> { _player2 };
				}
				for (int i = 0; i < list.Count; i++)
				{
					CameraTarget cameraTarget = list[i];
					if (cameraTarget == null || cameraTarget.Transform == null)
					{
						if (_trackerList.Contains(cameraTarget))
						{
							_trackerList.Remove(cameraTarget);
						}
						else if (_player1 == cameraTarget)
						{
							_player1 = null;
						}
						else if (_player2 == cameraTarget)
						{
							_player2 = null;
						}
						CheckMode();
					}
					else
					{
						vector = ((i != 0) ? Vector3.Lerp(vector, cameraTarget.Transform.position, 0.5f) : cameraTarget.Transform.position);
					}
				}
				foreach (CameraTarget activeTarget in ActiveTargets)
				{
					distance = Mathf.Max(distance, Vector2.Distance(vector, activeTarget.Transform.position));
				}
			}
			return vector;
		}

		private Vector3 ApplyMouseMovement(Vector3 targetPosition)
		{
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = targetPosition.z;
			Vector3 vector = Camera.main.ScreenToWorldPoint(mousePosition);
			float num = Vector2.Distance(targetPosition, vector);
			float num2 = Mathf.Min(num * num, _rotateCamera ? 0.5f : 2f);
			targetPosition = Vector3.Lerp(targetPosition, vector, 0.049999997f * num2);
			return targetPosition;
		}

		private Vector3 ApplyTargetVelocity(Vector3 targetPosition)
		{
			Vector2 vector = Vector2.zero;
			List<Rigidbody> list = (from t in ActiveTargets
				select t.Rigidbody into r
				where r != null
				select r).ToList();
			if (list.Count > 1)
			{
				foreach (Rigidbody item in list)
				{
					vector += (Vector2)item.velocity;
				}
				vector /= (float)list.Count;
			}
			else
			{
				CameraTarget cameraTarget = TargetList.FirstOrDefault();
				Transform transform = null;
				if (cameraTarget != null)
				{
					transform = cameraTarget.Transform;
				}
				else if (RuntimeGlobals.NimbatusPlayer != null)
				{
					transform = RuntimeGlobals.NimbatusPlayer.transform;
				}
				if (transform != null)
				{
					Rigidbody component = transform.GetComponent<Rigidbody>();
					if (component != null)
					{
						vector = component.velocity;
					}
				}
			}
			float num = 0.5f;
			if (vector.magnitude > 200f)
			{
				num = 200f * num / vector.magnitude;
			}
			Vector2 vector2 = vector * num;
			_oldVelocity = Vector3.Slerp(_oldVelocity, vector2, Time.smoothDeltaTime * 5f);
			targetPosition += _oldVelocity;
			return targetPosition;
		}

		private void ApplyZoom()
		{
			if (_zoomCamera)
			{
				ZoomOverride -= Input.GetAxis("Mouse ScrollWheel") * 20f;
				ZoomOverride = Mathf.Clamp(ZoomOverride, MinZoom - _targetAutomaticZoom, MaxZoom - _targetAutomaticZoom);
				Camera.orthographicSize = Mathf.Lerp(Camera.orthographicSize, Mathf.Clamp(_targetAutomaticZoom + ZoomOverride, MinZoom, MaxZoom), _firstUpdate ? 1f : (((VsFocusMode == ECameraVersusMode.Free) ? Time.unscaledDeltaTime : Time.smoothDeltaTime) * 10f));
			}
			else
			{
				Camera.orthographicSize = _targetAutomaticZoom;
			}
		}

		private void RotateCameraToGravity(Vector3 targetPosition)
		{
			Vector3 vector = new Vector3(0f, 60f, 0f);
			Vector3 vector2 = (_freeCam ? vector : targetPosition);
			Quaternion b = Quaternion.AngleAxis(Mathf.Atan2(vector2.y, vector2.x) * 57.29578f - 90f, Vector3.forward);
			Vector2 vector3 = (_freeCam ? vector : targetPosition);
			if (vector3.magnitude > (float)((!_freeCam) ? 20 : 0))
			{
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, _firstUpdate ? 1f : (Time.smoothDeltaTime * vector3.sqrMagnitude * 0.001f));
			}
		}

		private Vector3 CalculateRecoilShake(Vector3 targetPosition)
		{
			if (_recoilShakeAmount > 0f)
			{
				float num = _recoilShakeAmount * 0.4f;
				return targetPosition + _recoillShakeDirection * num;
			}
			return targetPosition;
		}

		internal void DoRecoilShake(Vector3 direction, float amount)
		{
			StartCoroutine(RecoilShake(direction, amount));
		}

		private IEnumerator RecoilShake(Vector3 direction, float amount)
		{
			_recoilShakeAmount = amount;
			_recoillShakeDirection = direction;
			_isCameraRecoilShaking = true;
			yield return new WaitForSeconds(0.05f);
			_isCameraRecoilShaking = false;
		}
	}
}
