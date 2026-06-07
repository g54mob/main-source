using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.XR;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Input.XR;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.XR
{
	public class FlightXRRigManager : MonoBehaviour
	{
		public delegate void XrRecenteredDelgate(Quaternion newRotation, Vector3 positionOffset);

		public const float GripRepositionMaxDistance = 0.25f;

		private Vector3 _adjustGripLastPosition;

		private bool _adjustingOffset;

		private Vector3 _adjustingOffsetDelta;

		[SerializeField]
		private Transform _cameraOffset;

		private FlightHand[] _flightHands;

		private bool _grippingAirLastFrame;

		private Quaternion _headsetStartRot;

		[SerializeField]
		private Transform _headsetTransform;

		[SerializeField]
		private Transform _rigRoot;

		private bool _waitingRecenter;

		public static FlightXRRigManager Instance { get; private set; }

		public bool AdjustingOffset => _adjustingOffset;

		public Vector3 AdjustingOffsetDelta => _adjustingOffsetDelta;

		public Dictionary<Rigidbody, ControlBaseScript> CockpitControls { get; private set; } = new Dictionary<Rigidbody, ControlBaseScript>();

		public IReadOnlyList<FlightHand> FlightHands => _flightHands;

		protected virtual void Awake()
		{
			Instance = this;
			_ = Game.Instance.Device.IsPicoXRBuild;
		}

		protected virtual void OnApplicationFocus(bool focus)
		{
			if (Game.Instance.Device.IsAndroidVRBuild)
			{
				PauseManager.RequestPauseChange(!focus, userInitiated: false);
				HandPoseManager[] componentsInChildren = GetComponentsInChildren<HandPoseManager>(includeInactive: true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].gameObject.SetActive(focus);
				}
			}
		}

		protected void OnDestroy()
		{
			Instance = null;
			XRInputs.Flight.RecenterView.performed -= OnRecenterButtonClicked;
			XRInputs.Flight.ThrottleVtolToggle.performed -= OnThrottleVtolToggle;
			Game.Instance.XRDeviceManager.XRPlatformViewReset -= OnXRPlatformViewReset;
		}

		protected void Start()
		{
			XRInputs.Flight.RecenterView.performed += OnRecenterButtonClicked;
			XRInputs.Flight.ThrottleVtolToggle.performed += OnThrottleVtolToggle;
			XRDeviceManager xRDeviceManager = Game.Instance.XRDeviceManager;
			xRDeviceManager.XRPlatformViewReset += OnXRPlatformViewReset;
			if (xRDeviceManager.HmdCustomOffset.HasValue)
			{
				xRDeviceManager.ApplyCustomOffsetToTransform(_cameraOffset);
			}
			else
			{
				_waitingRecenter = true;
				_headsetStartRot = _headsetTransform.localRotation;
			}
			_flightHands = GetComponentsInChildren<FlightHand>(includeInactive: true);
		}

		protected virtual void Update()
		{
			_adjustingOffsetDelta = Vector3.zero;
			if (_waitingRecenter && Quaternion.Angle(_headsetTransform.localRotation, _headsetStartRot) > 1f)
			{
				_waitingRecenter = false;
				RecenterPlayerCustom();
			}
			FlightHand flightHand = _flightHands[0];
			FlightHand flightHand2 = _flightHands[1];
			bool flag = flightHand.GripPhysicallyPressed && !flightHand.IsGripped && flightHand2.GripPhysicallyPressed && !flightHand2.IsGripped;
			if (flag)
			{
				Vector3 vector = _cameraOffset.InverseTransformPoint(flightHand.GripTransform.position);
				Vector3 vector2 = _cameraOffset.InverseTransformPoint(flightHand2.GripTransform.position);
				Vector3 vector3 = (vector + vector2) / 2f;
				if (!_adjustingOffset && !_grippingAirLastFrame)
				{
					if (Vector3.Distance(vector, vector2) < 0.25f)
					{
						_adjustingOffset = true;
						_adjustGripLastPosition = vector3;
					}
				}
				else if (_adjustingOffset && _grippingAirLastFrame)
				{
					Vector3 vector4 = (_adjustingOffsetDelta = _cameraOffset.localRotation * (_adjustGripLastPosition - vector3));
					_cameraOffset.localPosition += vector4;
					_adjustGripLastPosition = vector3;
				}
			}
			else if (_adjustingOffset)
			{
				_adjustingOffset = false;
			}
			_grippingAirLastFrame = flag;
		}

		private void OnRecenterButtonClicked(InputAction.CallbackContext obj)
		{
			RecenterPlayerCustom();
		}

		private void OnThrottleVtolToggle(InputAction.CallbackContext context)
		{
			if (XRInputs.Flight.Throttle.enabled)
			{
				FlightSceneScript.Instance.FlightUI.ShowMessage("VTOL");
				XRInputs.Flight.Throttle.Disable();
				XRInputs.Flight.Vtol.Enable();
			}
			else if (XRInputs.Flight.Vtol.enabled)
			{
				FlightSceneScript.Instance.FlightUI.ShowMessage("Throttle");
				XRInputs.Flight.Throttle.Enable();
				XRInputs.Flight.Vtol.Disable();
			}
		}

		private void OnXRPlatformViewReset(object sender, EventArgs e)
		{
			Game.Instance.XRDeviceManager.ClearCustomOffset(_cameraOffset);
			Debug.Log("Resetting view offset due to boundary change");
		}

		private void RecenterPlayerCustom()
		{
			Game.Instance.XRDeviceManager.RecenterCustomOffset(_headsetTransform, base.transform, _cameraOffset);
		}

		private void SwitchSeat()
		{
			CameraManagerScript.Instance.SwitchToNextViewMode(displayMessage: true, saveAsDefault: true);
		}
	}
}
