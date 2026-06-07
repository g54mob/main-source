using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MyStuff.Core;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using Unity.Netcode;
using UnityEngine;

namespace Synty.AnimationBaseLocomotion.Samples
{
	[DefaultExecutionOrder(100)]
	public class SampleCameraController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CWaitForNetworkSpawnThenInitialize_003Ed__82 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SampleCameraController _003C_003E4__this;

			private float _003Ctimeout_003E5__2;

			private float _003Celapsed_003E5__3;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitForNetworkSpawnThenInitialize_003Ed__82(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Tooltip("The character game object")]
		[SerializeField]
		private GameObject _syntyCharacter;

		[Tooltip("Main camera used for player perspective")]
		[SerializeField]
		private Camera _mainCamera;

		[SerializeField]
		private Transform _playerTarget;

		[SerializeField]
		private Transform _lockOnTarget;

		private Transform _vehicleOverrideTarget;

		private float _vehicleFollowHeightOffset;

		private Transform _cachedPlayerTarget;

		[SerializeField]
		private bool _invertCamera;

		[SerializeField]
		private bool _hideCursor;

		[SerializeField]
		private bool _isLockedOn;

		[SerializeField]
		private float _mouseSensitivity;

		[SerializeField]
		private float _mouseSensitivityX;

		[SerializeField]
		private float _mouseSensitivityY;

		[SerializeField]
		private float _cameraDistance;

		[Header("Camera Distance Settings")]
		[SerializeField]
		[Tooltip("Minimum camera distance from player")]
		private float _minCameraDistance;

		[SerializeField]
		[Tooltip("Maximum camera distance from player")]
		private float _maxCameraDistance;

		[SerializeField]
		[Tooltip("Smooth zoom transitions")]
		private bool _smoothZoom;

		[SerializeField]
		[Tooltip("Smoothing speed for zoom transitions")]
		[Range(1f, 20f)]
		private float _zoomSmoothSpeed;

		[SerializeField]
		[Tooltip("How much distance changes per scroll notch")]
		[Range(0.5f, 20f)]
		private float _zoomSensitivity;

		[Header("Camera Collision Settings")]
		[SerializeField]
		[Tooltip("Physics layers tested when preventing the camera from clipping")]
		private LayerMask _collisionLayers;

		[SerializeField]
		[Tooltip("Radius of the virtual sphere used for collision checks")]
		private float _cameraCollisionRadius;

		[SerializeField]
		[Tooltip("Extra gap maintained between the camera and any obstacle")]
		private float _collisionBuffer;

		[SerializeField]
		[Tooltip("Minimum obstacle width required before the camera reacts")]
		private float _minObstacleWidth;

		[SerializeField]
		[Tooltip("Smooth time used when adjusting the camera because of collisions")]
		[Range(0.01f, 0.5f)]
		private float _collisionSmoothTime;

		[Header("Aggressive Collision Settings")]
		[SerializeField]
		[Tooltip("Distance change threshold that triggers fast smooth transition instead of normal smooth")]
		private float _collisionSnapThreshold;

		[SerializeField]
		[Tooltip("Radius for checking if camera is inside geometry")]
		private float _insideGeometryCheckRadius;

		[SerializeField]
		[Tooltip("Enable aggressive collision avoidance that moves camera out of geometry quickly")]
		private bool _enableAggressiveCollision;

		[SerializeField]
		[Tooltip("Smooth time for fast collision response (smaller = faster, 0 = instant snap)")]
		[Range(0f, 0.15f)]
		private float _fastCollisionSmoothTime;

		[Header("Indoor Camera Improvements")]
		[SerializeField]
		[Tooltip("Minimum camera distance before FOV compensation kicks in (prevents claustrophobic feel)")]
		private float _fovCompensationThreshold;

		[SerializeField]
		[Tooltip("Maximum additional FOV added when camera is pushed very close")]
		[Range(0f, 30f)]
		private float _maxFovCompensation;

		[SerializeField]
		[Tooltip("Minimum effective camera distance (prevents extreme close-up against walls)")]
		[Range(0.1f, 1.5f)]
		private float _minEffectiveDistance;

		[SerializeField]
		[Tooltip("Number of rays for multi-ray visibility check (reduces false positives from doorframes)")]
		[Range(1f, 5f)]
		private int _visibilityRayCount;

		[Header("Camera Offset Settings")]
		[SerializeField]
		[Tooltip("Height offset of the camera relative to the player target")]
		private float _cameraHeightOffset;

		[SerializeField]
		[Tooltip("Horizontal (left/right) offset of the camera")]
		private float _cameraHorizontalOffset;

		[SerializeField]
		[Tooltip("Tilt angle offset for the camera")]
		private float _cameraTiltOffset;

		[SerializeField]
		[Tooltip("Additional vertical offset for the camera pivot point (adjusts camera height)")]
		private float _cameraPivotHeightOffset;

		[SerializeField]
		private Vector2 _cameraTiltBounds;

		[SerializeField]
		[Range(1f, 20f)]
		private float _positionFollowSpeed;

		[SerializeField]
		[Range(1f, 20f)]
		private float _rotationFollowSpeed;

		private float _cameraInversion;

		[Header("Camera Shake Settings")]
		[SerializeField]
		[Tooltip("Enable camera shake when taking damage")]
		private bool _enableDamageShake;

		[SerializeField]
		[Tooltip("Intensity of camera shake when taking damage")]
		[Range(0.05f, 1f)]
		private float _damageShakeIntensity;

		[SerializeField]
		[Tooltip("Duration of camera shake when taking damage (seconds)")]
		[Range(0.1f, 0.5f)]
		private float _damageShakeDuration;

		[SerializeField]
		[Tooltip("Enable camera shake when hitting enemies")]
		private bool _enableHitShake;

		[SerializeField]
		[Tooltip("Intensity of camera shake when hitting enemies (lighter than damage shake)")]
		[Range(0.01f, 0.3f)]
		private float _hitShakeIntensity;

		[SerializeField]
		[Tooltip("Duration of camera shake when hitting enemies (seconds)")]
		[Range(0.05f, 0.2f)]
		private float _hitShakeDuration;

		[SerializeField]
		private bool _disableMouseInput;

		private InputReader _inputReader;

		private MyControls _inputActions;

		private NetworkObject _networkObject;

		private float _currentAngleX;

		private float _currentAngleY;

		private Vector3 _currentPosition;

		private float _targetAngleX;

		private float _targetAngleY;

		private Vector3 _targetPosition;

		[Header("Camera Reference")]
		[Tooltip("The camera transform. If not assigned, will attempt to find first child.")]
		[SerializeField]
		private Transform _syntyCamera;

		private Vector3 _velocity;

		private float _rotationVelocityX;

		private float _rotationVelocityY;

		private float _targetCameraDistance;

		private float _currentCameraDistance;

		private float _zoomVelocity;

		private float _collisionAdjustedDistance;

		private float _collisionDistanceVelocity;

		private readonly RaycastHit[] _collisionHits;

		private readonly Collider[] _overlapResults;

		private float _effectiveHeightOffset;

		private float _heightOffsetVelocity;

		private float _ceilingDistanceLimit;

		private float _ceilingDistanceLimitVelocity;

		private float _baseFov;

		private float _currentFovCompensation;

		private float _fovCompensationVelocity;

		private Camera _cameraComponent;

		private float _shakeTimer;

		private float _shakeIntensity;

		private Vector3 _shakeOffset;

		private bool _smoothTakeoverActive;

		private float _smoothTakeoverTimer;

		private float _smoothTakeoverDuration;

		private Vector3 _takeoverStartPosition;

		private float _takeoverStartAngleX;

		private float _takeoverStartAngleY;

		public Camera MainCamera => null;

		public bool IsFollowingVehicle => false;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForNetworkSpawnThenInitialize_003Ed__82))]
		private IEnumerator WaitForNetworkSpawnThenInitialize()
		{
			return null;
		}

		private void SubscribeToSettings()
		{
		}

		private void UnsubscribeFromSettings()
		{
		}

		private void OnSettingsManagerReady(SettingsManager manager)
		{
		}

		private void OnMouseSensitivityChanged(float sensitivityX, float sensitivityY)
		{
		}

		public void InitializeCamera()
		{
		}

		private bool ShouldControlCamera()
		{
			return false;
		}

		private void FindWorkingInputReader()
		{
		}

		private bool IsInputReaderWorking(InputReader reader)
		{
			return false;
		}

		private bool ShouldProcessInput()
		{
			return false;
		}

		private float GetCollisionAdjustedDistance(float desiredDistance)
		{
			return 0f;
		}

		private bool ShouldIgnoreCollision(Collider collider)
		{
			return false;
		}

		private bool IsObstacleWideEnough(Collider collider)
		{
			return false;
		}

		private bool IsCameraInsideGeometry(Vector3 cameraWorldPosition)
		{
			return false;
		}

		private float GetSafeHeightOffset(float desiredHeightOffset, float cameraDistance)
		{
			return 0f;
		}

		private bool CanCameraSeePlayer(Vector3 cameraWorldPosition)
		{
			return false;
		}

		private bool IsRayBlocked(Vector3 from, Vector3 to, float maxDistance)
		{
			return false;
		}

		private float GetCollisionAdjustedDistanceBase(float desiredDistance)
		{
			return 0f;
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void UpdateFovCompensation()
		{
		}

		private void UpdateCameraShake()
		{
		}

		private void TriggerShake(float intensity, float duration)
		{
		}

		public void ShakeOnDamage()
		{
		}

		public void ShakeOnHit()
		{
		}

		public void ShakeCustom(float intensity, float duration)
		{
		}

		public void LockOn(bool enable, Transform newLockOnTarget)
		{
		}

		public Vector3 GetCameraPosition()
		{
			return default(Vector3);
		}

		public Vector3 GetCameraForward()
		{
			return default(Vector3);
		}

		public Vector3 GetCameraForwardZeroedY()
		{
			return default(Vector3);
		}

		public Vector3 GetCameraForwardZeroedYNormalised()
		{
			return default(Vector3);
		}

		public Vector3 GetCameraRightZeroedY()
		{
			return default(Vector3);
		}

		public Vector3 GetCameraRightZeroedYNormalised()
		{
			return default(Vector3);
		}

		public float GetCameraTiltX()
		{
			return 0f;
		}

		public void SetMouseInputDisabled(bool disable)
		{
		}

		public bool IsMouseInputDisabled()
		{
			return false;
		}

		public float GetCameraDistance()
		{
			return 0f;
		}

		public void SetCameraDistance(float distance, bool immediate = false)
		{
		}

		public float GetMinCameraDistance()
		{
			return 0f;
		}

		public float GetMaxCameraDistance()
		{
			return 0f;
		}

		private void HandleZoomInput(float zoomAmount)
		{
		}

		public float GetCameraPivotHeightOffset()
		{
			return 0f;
		}

		public void SetCameraPivotHeightOffset(float offset)
		{
		}

		public (Vector3, Quaternion) GetDesiredCameraState()
		{
			return default((Vector3, Quaternion));
		}

		public void ResumeFromExternalControl()
		{
		}

		public void SyncToCurrentPosition(bool smoothTakeover = true)
		{
		}

		public void SetVehicleFollowTarget(Transform vehicleRoot, Transform virtualPlayerSeat = null)
		{
		}

		public void ClearVehicleFollowTarget()
		{
		}

		public void SetBaseFov(float fov)
		{
		}

		private Vector3 GetEffectiveFollowPosition()
		{
			return default(Vector3);
		}

		private void OnEnable()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
