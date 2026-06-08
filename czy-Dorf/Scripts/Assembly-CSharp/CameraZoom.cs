using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Dorfromantik;
using Dorfromantik.UI;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraZoom : MonoBehaviour
{
	private sealed class _003CZoom_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CameraZoom _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CZoom_003Ed__26(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			CameraZoom cameraZoom = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				cameraZoom.isZoomingByInput = true;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (Mathf.Abs(cameraZoom.currentZoomDistance - cameraZoom.targetZoomDistance) > cameraZoom.stopTreshold)
			{
				float currentZoomDistance = cameraZoom.currentZoomDistance;
				cameraZoom.currentZoomDistance = Mathf.Lerp(cameraZoom.currentZoomDistance, cameraZoom.targetZoomDistance, cameraZoom.zoomDamping);
				cameraZoom.mainCamera.localPosition = Vector3.forward * cameraZoom.currentZoomDistance;
				cameraZoom.OnCameraZoomed?.Invoke(Mathf.Abs(currentZoomDistance - cameraZoom.currentZoomDistance));
				cameraZoom.uiScalingManager.OnZoomCamera(cameraZoom.currentZoomDistance);
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			cameraZoom.isZoomingByInput = false;
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
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private UiScalingManager uiScalingManager;

	[SerializeField]
	private SettingsRouter settingsRouter;

	public float initialZoomDistance;

	[SerializeField]
	private float zoomSpeed = 2f;

	[SerializeField]
	private float zoomInDistance = 2.3f;

	[SerializeField]
	private float zoomOutDistance = -2.3f;

	[SerializeField]
	private float smoothingInOutMaxDistance = 1f;

	[SerializeField]
	private float smoothOutBreakFactor = 0.9f;

	[SerializeField]
	[FormerlySerializedAs("smoothOutSpeedStopThreshold")]
	private float stopTreshold = 0.001f;

	private Vector3 originalCameraPosition;

	private Transform mainCamera;

	private bool isZoomingByInput;

	private float zoomDelta;

	private float currentDistance;

	private float movedDirection;

	private Plane groundPlane = new Plane(Vector3.up, 0f);

	private float currentZoomDistance;

	private float targetZoomDistance;

	[SerializeField]
	private float zoomDamping = 0.5f;

	public DefaultSettings settings;

	public event Action<float> OnCameraZoomed;

	private void Start()
	{
		mainCamera = OverwritingSingleton<IngameUi>.Instance.mainCamera.transform;
		currentZoomDistance = initialZoomDistance;
		mainCamera.localPosition = Vector3.forward * currentZoomDistance;
		inputRouter.OnZoomCamera += Zoom;
		uiScalingManager.OnZoomCamera(currentZoomDistance);
	}

	private void Zoom(float zoomAmount)
	{
		zoomDelta = zoomAmount * zoomSpeed;
		targetZoomDistance = Mathf.Clamp(targetZoomDistance + zoomDelta, settingsRouter.MaxZoomOutDistance, zoomInDistance);
		if (!isZoomingByInput)
		{
			StartCoroutine(Zoom());
		}
	}

	private IEnumerator Zoom()
	{
		return new _003CZoom_003Ed__26(0)
		{
			_003C_003E4__this = this
		};
	}

	private void OnDestroy()
	{
		inputRouter.OnZoomCamera -= Zoom;
	}

	public void SetMaxZoomOutDistance(float newZoomOutValue)
	{
		zoomOutDistance = newZoomOutValue;
	}
}
