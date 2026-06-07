using System;
using Assets.Scripts.Input.XR;
using Assets.Scripts.XR.UI;
using Assets.Scripts.XR.UI.InputModules;
using Jundroo.Common.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.OpenXR.Input;

namespace Assets.Scripts.XR
{
	public class HandScriptBase : MonoBehaviour
	{
		private Vector3? _currentFramePosition;

		private Quaternion? _currentFrameRotation;

		private Quaternion? _defaultRotation;

		[SerializeField]
		private XRHandType _handType;

		[SerializeField]
		private float _idleHandTimeThreshold = 5f;

		private bool _isIdle;

		[SerializeField]
		private float _laserDistanceOffset;

		[SerializeField]
		private LaserRenderingScript _laserPointer;

		private SkinnedMeshRenderer[] _meshRenderers;

		[SerializeField]
		private TrackedPointerInputModule _pointerInput;

		private InputAction _poseAction;

		private InputAction _positionAction;

		private Vector3? _previousFramePosition;

		private Quaternion? _previousFrameRotation;

		private InputAction _rotationAction;

		private InputAction _thumbTouched;

		private InputAction _triggerTouched;

		private bool _visible = true;

		public virtual bool CanIdle
		{
			get
			{
				if (!Game.Instance.Device.IsAndroidVRBuild && !_thumbTouched.IsPressed())
				{
					return !_triggerTouched.IsPressed();
				}
				return false;
			}
		}

		public XRController Controller => (UsePose ? _poseAction : _positionAction).activeControl.device as XRController;

		public XRHandType HandType => _handType;

		public float IdleHandTime { get; private set; }

		public bool IsIdle
		{
			get
			{
				return _isIdle;
			}
			set
			{
				if (value != _isIdle)
				{
					_isIdle = value;
					UpdateVisibility();
				}
			}
		}

		public bool IsVisible
		{
			get
			{
				if (_visible)
				{
					return !_isIdle;
				}
				return false;
			}
			set
			{
				if (value != _visible)
				{
					_visible = value;
					UpdateVisibility();
				}
			}
		}

		public InputAction PoseAction => _poseAction;

		protected static bool UsePose => !Game.Instance.Device.IsPicoXRBuild;

		public static Quaternion GetDefaultRotation(InputDevice inputDevice)
		{
			if (inputDevice.name.StartsWith("HTCViveControllerOpenXR", StringComparison.Ordinal))
			{
				return Quaternion.Euler(30f, 0f, 0f);
			}
			return Quaternion.identity;
		}

		public void SendHaptic(float amplitude, float duration)
		{
			InputDevice inputDevice = (UsePose ? _poseAction : _positionAction).activeControl?.device;
			if (inputDevice != null && inputDevice is XRControllerWithRumble xRControllerWithRumble && !Game.Instance.Device.IsPicoXRBuild)
			{
				xRControllerWithRumble.SendImpulse(amplitude, duration);
			}
		}

		protected virtual void LateUpdate()
		{
			if ((object)_pointerInput != null && (object)_laserPointer != null)
			{
				RaycastResult? pointerCurrentRaycast = _pointerInput.PointerCurrentRaycast;
				if (pointerCurrentRaycast?.gameObject != null)
				{
					_laserPointer.SetLength(pointerCurrentRaycast.Value.distance + _laserDistanceOffset);
					_laserPointer.SetNormal(pointerCurrentRaycast.Value.worldNormal);
					_laserPointer.gameObject.SetActive(value: true);
				}
				else
				{
					_laserPointer.gameObject.SetActive(value: false);
				}
			}
		}

		protected virtual void Start()
		{
			if (_handType == XRHandType.Left)
			{
				_poseAction = XRInputs.PoseLeftHand.PointerPose;
				_positionAction = XRInputs.PoseLeftHand.DevicePosition;
				_rotationAction = XRInputs.PoseLeftHand.DeviceRotation;
				_thumbTouched = XRInputs.PoseLeftHand.ThumbTouched;
				_triggerTouched = XRInputs.PoseLeftHand.TriggerTouched;
			}
			else
			{
				_poseAction = XRInputs.PoseRightHand.PointerPose;
				_positionAction = XRInputs.PoseRightHand.DevicePosition;
				_rotationAction = XRInputs.PoseRightHand.DeviceRotation;
				_thumbTouched = XRInputs.PoseRightHand.ThumbTouched;
				_triggerTouched = XRInputs.PoseRightHand.TriggerTouched;
			}
			_meshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			UpdateVisibility();
		}

		protected virtual void Update()
		{
			_previousFramePosition = _currentFramePosition;
			_previousFrameRotation = _currentFrameRotation;
			bool flag = CanIdle;
			if ((UsePose ? _poseAction : _positionAction)?.activeControl?.device is TrackedDevice trackedDevice && (trackedDevice.trackingState.ReadValue() & 1) != 0)
			{
				UnityEngine.XR.OpenXR.Input.Pose pose = (UsePose ? _poseAction.ReadValue<UnityEngine.XR.OpenXR.Input.Pose>() : new UnityEngine.XR.OpenXR.Input.Pose
				{
					isTracked = true,
					position = _positionAction.ReadValue<Vector3>(),
					rotation = _rotationAction.ReadValue<Quaternion>()
				});
				if (pose.isTracked)
				{
					Quaternion? defaultRotation = _defaultRotation;
					Quaternion quaternion2;
					if (!defaultRotation.HasValue)
					{
						Quaternion? quaternion = (_defaultRotation = GetDefaultRotation(trackedDevice));
						quaternion2 = quaternion.Value;
					}
					else
					{
						quaternion2 = defaultRotation.GetValueOrDefault();
					}
					Quaternion quaternion3 = quaternion2;
					base.transform.localPosition = pose.position;
					base.transform.localRotation = pose.rotation * quaternion3;
					_currentFramePosition = pose.position;
					_currentFrameRotation = pose.rotation;
					flag &= _previousFramePosition.HasValue && Utilities.CompareVector3s(_currentFramePosition.Value, _previousFramePosition.Value, 0.0025f) && _previousFrameRotation.HasValue && Utilities.CompareQuaternions(_currentFrameRotation.Value, _previousFrameRotation.Value, 0.0025f);
				}
			}
			IdleHandTime = (flag ? (IdleHandTime + Time.deltaTime) : 0f);
			IsIdle = IdleHandTime >= _idleHandTimeThreshold;
		}

		private void UpdateVisibility()
		{
			if (_meshRenderers != null)
			{
				SkinnedMeshRenderer[] meshRenderers = _meshRenderers;
				for (int i = 0; i < meshRenderers.Length; i++)
				{
					meshRenderers[i].enabled = IsVisible;
				}
			}
		}
	}
}
