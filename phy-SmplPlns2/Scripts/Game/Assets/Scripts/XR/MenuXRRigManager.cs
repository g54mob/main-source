using System;
using Assets.Scripts.Input.XR;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.XR
{
	public class MenuXRRigManager : MonoBehaviour
	{
		[SerializeField]
		private Transform _cameraOffset;

		private Quaternion _headsetStartRot;

		[SerializeField]
		private Transform _headsetTransform;

		private bool _waitingRecenter;

		protected virtual void Awake()
		{
			_ = Game.Instance.Device.IsPicoXRBuild;
		}

		protected virtual void OnApplicationFocus(bool focus)
		{
			if (Game.Instance.Device.IsAndroidVRBuild)
			{
				HandPoseManager[] componentsInChildren = GetComponentsInChildren<HandPoseManager>(includeInactive: true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].gameObject.SetActive(focus);
				}
			}
		}

		protected virtual void OnDestroy()
		{
			XRInputs.Menu.RecenterView.performed -= OnRecenterButtonClicked;
			Game.Instance.XRDeviceManager.XRPlatformViewReset -= XRPlatformViewReset;
		}

		protected virtual void Start()
		{
			XRInputs.Menu.RecenterView.performed += OnRecenterButtonClicked;
			XRDeviceManager xRDeviceManager = Game.Instance.XRDeviceManager;
			xRDeviceManager.XRPlatformViewReset += XRPlatformViewReset;
			if (xRDeviceManager.HmdCustomOffset.HasValue)
			{
				xRDeviceManager.ApplyCustomOffsetToTransform(_cameraOffset);
				return;
			}
			_waitingRecenter = true;
			_headsetStartRot = _headsetTransform.localRotation;
		}

		protected virtual void Update()
		{
			if (_waitingRecenter && Quaternion.Angle(_headsetTransform.localRotation, _headsetStartRot) > 1f)
			{
				_waitingRecenter = false;
				RecenterPlayerCustom();
			}
		}

		private void OnRecenterButtonClicked(InputAction.CallbackContext obj)
		{
			RecenterPlayerCustom();
		}

		private void RecenterPlayerCustom()
		{
			Game.Instance.XRDeviceManager.RecenterCustomOffset(_headsetTransform, base.transform, _cameraOffset);
		}

		private void XRPlatformViewReset(object sender, EventArgs e)
		{
			Game.Instance.XRDeviceManager.ClearCustomOffset(_cameraOffset);
			Debug.Log("Resetting view offset due to boundary change");
		}
	}
}
