using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
	private sealed class _003CSmoothOutRotation_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CameraRotator _003C_003E4__this;

		private float _003CcurrentRotationSpeed_003E5__2;

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
		public _003CSmoothOutRotation_003Ed__20(int _003C_003E1__state)
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
			CameraRotator cameraRotator = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CcurrentRotationSpeed_003E5__2 = cameraRotator.rotationSpeed;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (_003CcurrentRotationSpeed_003E5__2 > cameraRotator.smoothOutSpeedStopThreshold && !cameraRotator.isRotatingByInput)
			{
				float angle = cameraRotator.currentRotationAmount * Time.deltaTime * _003CcurrentRotationSpeed_003E5__2;
				cameraRotator.RotateCameraBy(angle);
				_003CcurrentRotationSpeed_003E5__2 *= cameraRotator.smoothOutBreakFactor;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
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
	private bool rotationEnabled = true;

	[SerializeField]
	private float rotationSpeed = 20f;

	[SerializeField]
	private float smoothOutBreakFactor = 0.5f;

	[SerializeField]
	private float smoothOutSpeedStopThreshold = 0.5f;

	[SerializeField]
	private Vector2 screenFocusPoint = new Vector2(0.5f, 0.3f);

	[SerializeField]
	private bool rotateAroundMousePos;

	private Plane groundPlane = new Plane(Vector3.up, 0f);

	private Vector3 rotationCenter;

	private bool isRotatingByInput;

	private float currentRotationAmount;

	private CameraController cameraController;

	private Camera mainCamera;

	public event Action<float> OnCameraRotated;

	private void Awake()
	{
		cameraController = GetComponent<CameraController>();
	}

	private void Start()
	{
		inputRouter.OnRotateCamera += RotateCamera;
		inputRouter.OnFinishRotateCamera += StopRotatingCamera;
		inputRouter.OnSetCameraRotationPoint += CalculateRotationCenter;
		mainCamera = OverwritingSingleton<IngameUi>.Instance.mainCamera;
	}

	private void RotateCamera(Vector2 rotationAmount)
	{
		currentRotationAmount = rotationAmount.x;
		if (rotationEnabled)
		{
			isRotatingByInput = true;
			float angle = currentRotationAmount * Time.deltaTime * rotationSpeed;
			RotateCameraBy(angle);
		}
	}

	private void StopRotatingCamera()
	{
		if (rotationEnabled)
		{
			isRotatingByInput = false;
			StartCoroutine(SmoothOutRotation());
		}
	}

	private IEnumerator SmoothOutRotation()
	{
		return new _003CSmoothOutRotation_003Ed__20(0)
		{
			_003C_003E4__this = this
		};
	}

	private void RotateCameraBy(float angle)
	{
		base.transform.RotateAround(rotationCenter, Vector3.up, angle);
		base.transform.position = cameraController.ClampToWorldBounds(base.transform.position, out var _);
		this.OnCameraRotated?.Invoke(angle);
	}

	private void CalculateRotationCenter(Vector2 mousePos)
	{
		Ray ray = ((!rotateAroundMousePos) ? mainCamera.ScreenPointToRay(new Vector3((float)Screen.width * screenFocusPoint.x, (float)Screen.height * screenFocusPoint.y, 0f)) : mainCamera.ScreenPointToRay(mousePos));
		groundPlane.Raycast(ray, out var enter);
		rotationCenter = ray.GetPoint(enter);
	}

	private void OnDestroy()
	{
		inputRouter.OnRotateCamera -= RotateCamera;
		inputRouter.OnFinishRotateCamera -= StopRotatingCamera;
		inputRouter.OnSetCameraRotationPoint -= CalculateRotationCenter;
	}
}
