using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using Dorfromantik;
using Dorfromantik.UI;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	private sealed class _003CAutoMovingCameraUntilInView_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CameraMovement _003C_003E4__this;

		public Vector3 targetWorldPos;

		public Vector2 viewPortOffset;

		public float speedMultiplier;

		private Vector3 _003CcameraDirection_003E5__2;

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
		public _003CAutoMovingCameraUntilInView_003Ed__39(int _003C_003E1__state)
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
			CameraMovement cameraMovement = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				cameraMovement.distance = cameraMovement.DistanceToViewportSection(targetWorldPos, viewPortOffset);
				_003CcameraDirection_003E5__2 = (targetWorldPos - cameraMovement.transform.position).normalized;
				cameraMovement.autoMovingCamera = true;
				Tween autoCamTween = cameraMovement.autoCamTween;
				if (autoCamTween != null)
				{
					TweenExtensions.Kill(autoCamTween);
				}
				cameraMovement.peakDistance = 0f;
				cameraMovement.peakDistanceMultiplier = 0f;
				cameraMovement.peakScreenPosition = Vector2.zero;
				goto IL_01c1;
			}
			case 1:
				_003C_003E1__state = -1;
				goto IL_01c1;
			case 2:
				{
					_003C_003E1__state = -1;
					break;
				}
				IL_01c1:
				if (cameraMovement.distance > 0f && cameraMovement.autoMovingCamera)
				{
					cameraMovement.distance = cameraMovement.DistanceToViewportSection(targetWorldPos, viewPortOffset);
					cameraMovement.distanceMultiplier = cameraMovement.autoCamMaxSpeedByDistance.Evaluate(cameraMovement.distance);
					if (cameraMovement.distance > cameraMovement.peakDistance)
					{
						cameraMovement.peakDistance = cameraMovement.distance;
					}
					if (cameraMovement.distanceMultiplier > cameraMovement.peakDistanceMultiplier)
					{
						cameraMovement.peakDistanceMultiplier = cameraMovement.distanceMultiplier;
					}
					float num2 = cameraMovement.autoCamMaxSpeed * cameraMovement.distanceMultiplier * speedMultiplier;
					if (cameraMovement.autoCameraSpeed <= num2)
					{
						cameraMovement.autoCameraSpeed = Mathf.Clamp(cameraMovement.autoCameraSpeed + cameraMovement.autoCamAcceleration * cameraMovement.distanceMultiplier * Time.deltaTime * speedMultiplier, 0f, num2);
					}
					_003CcameraDirection_003E5__2 = (targetWorldPos - cameraMovement.transform.position).normalized;
					cameraMovement.worldMovementDelta = _003CcameraDirection_003E5__2 * cameraMovement.autoCameraSpeed * Time.deltaTime;
					cameraMovement.MoveCameraBy(cameraMovement.worldMovementDelta, Space.World, movedByPlayer: false);
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				break;
			}
			if (cameraMovement.autoMovingCamera && cameraMovement.autoCameraSpeed > 0.01f)
			{
				cameraMovement.worldMovementDelta = _003CcameraDirection_003E5__2 * cameraMovement.autoCameraSpeed * Time.deltaTime;
				cameraMovement.MoveCameraBy(cameraMovement.worldMovementDelta, Space.World, movedByPlayer: false);
				cameraMovement.autoCameraSpeed *= cameraMovement.smoothOutBreakFactor;
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			}
			cameraMovement.autoMovingCamera = false;
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

	private sealed class _003CSmoothOutPan_003Ed__46 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CameraMovement _003C_003E4__this;

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
		public _003CSmoothOutPan_003Ed__46(int _003C_003E1__state)
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
			CameraMovement cameraMovement = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (cameraMovement.worldMovementDelta.magnitude > cameraMovement.smoothOutSpeedStopThreshold && !cameraMovement.isMovingByInput && !cameraMovement.autoMovingCamera)
			{
				cameraMovement.MoveCameraBy(cameraMovement.worldMovementDelta, Space.World);
				cameraMovement.worldMovementDelta *= cameraMovement.smoothOutBreakFactor;
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
	private UiScalingManager uiScalingManager;

	[SerializeField]
	private SettingsRouter settingsRouter;

	[SerializeField]
	private float panningSpeed = 0.5f;

	[SerializeField]
	private float smoothOutBreakFactor = 0.1f;

	[SerializeField]
	private float smoothOutSpeedStopThreshold = 0.5f;

	[SerializeField]
	private float boundsSlowDownTreshold = 3f;

	[SerializeField]
	private float autoCamAcceleration = 3f;

	[SerializeField]
	private float autoCamDeceleration = 3f;

	[SerializeField]
	private AnimationCurve autoCamMaxSpeedByDistance;

	[SerializeField]
	private float autoCamMaxSpeed = 3f;

	[SerializeField]
	private float preciseCamSpeed = 2f;

	private CameraController cameraController;

	private Camera mainCamera;

	private Vector3 startPos;

	private Quaternion startRot;

	private bool isMovingByInput;

	private Vector3 worldMovementDelta;

	private float currentSpeed;

	private bool autoMovingCamera;

	private Coroutine autoCamMovement;

	private float autoCameraSpeed;

	private bool cameraMoved;

	private int rememberAntiAliasingLevel = -1;

	private Tween autoCamTween;

	private float distance;

	private float peakDistance;

	private float distanceMultiplier;

	private float peakDistanceMultiplier;

	private Vector2 screenPosition;

	private Vector2 peakScreenPosition;

	public event Action<Vector2, bool> OnCameraMoved;

	private void Awake()
	{
		cameraController = GetComponent<CameraController>();
		mainCamera = GetComponentInChildren<Camera>();
	}

	private void Start()
	{
		startPos = base.transform.position;
		startRot = base.transform.rotation;
		inputRouter.OnPanCamera += PanCamera;
		inputRouter.OnPanCameraLocalSpace += PanCameraLocal;
		inputRouter.OnFinishPanCamera += StopPanningCamera;
		inputRouter.OnResetCamera += ResetTransform;
	}

	public void MoveCameraUntilInView(Vector3 targetWorldPos, Vector2 viewPortOffset, float autoCamSpeedMultiplier = 1f)
	{
		if (autoCamMovement != null)
		{
			StopCoroutine(autoCamMovement);
		}
		autoCamMovement = StartCoroutine(AutoMovingCameraUntilInView(targetWorldPos, viewPortOffset, autoCamSpeedMultiplier));
	}

	public void MoveCameraTowardsPrecisePosition(Vector3 targetWorldPos, float maxDuration = -1f)
	{
		float num = Vector3.Distance(base.transform.position, targetWorldPos) / preciseCamSpeed;
		if (maxDuration > 0f)
		{
			num = Mathf.Clamp(num, 0f, maxDuration);
		}
		Tween tween = autoCamTween;
		if (tween != null)
		{
			TweenExtensions.Kill(tween);
		}
		autoCamTween = TweenSettingsExtensions.OnUpdate(TweenSettingsExtensions.SetEase(ShortcutExtensions.DOMove(base.transform, targetWorldPos, num), Ease.OutCubic), OnPreciseCameraMoved);
	}

	private void OnPreciseCameraMoved()
	{
		cameraMoved = true;
		uiScalingManager.OnMoveCamera();
		this.OnCameraMoved?.Invoke(Vector2.zero, arg2: false);
	}

	private IEnumerator AutoMovingCameraUntilInView(Vector3 targetWorldPos, Vector2 viewPortOffset, float speedMultiplier = 1f)
	{
		return new _003CAutoMovingCameraUntilInView_003Ed__39(0)
		{
			_003C_003E4__this = this,
			targetWorldPos = targetWorldPos,
			viewPortOffset = viewPortOffset,
			speedMultiplier = speedMultiplier
		};
	}

	private float DistanceToViewportSection(Vector3 targetWorldPos, Vector2 viewPortOffset)
	{
		if (CameraUtility.IsVisibleByCamera(targetWorldPos, mainCamera, -viewPortOffset))
		{
			return 0f;
		}
		Vector3[] array = new Vector3[4]
		{
			CameraUtility.ViewportPosToWorldPosOnGroundPlane(viewPortOffset, mainCamera),
			CameraUtility.ViewportPosToWorldPosOnGroundPlane(new Vector2(1f - viewPortOffset.x, viewPortOffset.y), mainCamera),
			CameraUtility.ViewportPosToWorldPosOnGroundPlane(new Vector2(viewPortOffset.x, 1f - viewPortOffset.y), mainCamera),
			CameraUtility.ViewportPosToWorldPosOnGroundPlane(new Vector2(1f - viewPortOffset.x, 1f - viewPortOffset.y), mainCamera)
		};
		Ray[] array2 = new Ray[4]
		{
			new Ray(array[0], (array[1] - array[0]).normalized),
			new Ray(array[0], (array[2] - array[0]).normalized),
			new Ray(array[1], (array[3] - array[1]).normalized),
			new Ray(array[2], (array[3] - array[2]).normalized)
		};
		Debug.DrawLine(array[0], array[1], Color.green);
		Debug.DrawLine(array[0], array[2], Color.green);
		Debug.DrawLine(array[1], array[3], Color.green);
		Debug.DrawLine(array[2], array[3], Color.green);
		float[] values = new float[4]
		{
			MathUtility.DistancePointToRay(array2[0], targetWorldPos),
			MathUtility.DistancePointToRay(array2[1], targetWorldPos),
			MathUtility.DistancePointToRay(array2[2], targetWorldPos),
			MathUtility.DistancePointToRay(array2[3], targetWorldPos)
		};
		return Mathf.Min(values);
	}

	private void PanCameraLocal(Vector2 panningDirection)
	{
		MoveCameraBy(panningDirection, panningSpeed, Space.Self);
	}

	private void PanCamera(Vector2 panningDirection)
	{
		MoveCameraBy(panningDirection, -1f);
	}

	private void MoveCameraBy(Vector2 inputDelta, float speed, Space relativeSpace = Space.World)
	{
		isMovingByInput = true;
		autoMovingCamera = false;
		Tween tween = autoCamTween;
		if (tween != null)
		{
			TweenExtensions.Kill(tween);
		}
		worldMovementDelta = new Vector3(inputDelta.x, 0f, inputDelta.y);
		if (speed > 0f)
		{
			worldMovementDelta *= speed * Time.deltaTime;
		}
		MoveCameraBy(worldMovementDelta, relativeSpace);
	}

	private void ResetTransform()
	{
		base.transform.position = startPos;
		base.transform.rotation = startRot;
	}

	private void StopPanningCamera()
	{
		isMovingByInput = false;
		StartCoroutine(SmoothOutPan());
	}

	private IEnumerator SmoothOutPan()
	{
		return new _003CSmoothOutPan_003Ed__46(0)
		{
			_003C_003E4__this = this
		};
	}

	private void MoveCameraBy(Vector3 movementDelta, Space relativeSpace, bool movedByPlayer = true)
	{
		if (relativeSpace == Space.Self)
		{
			worldMovementDelta = Vector3.ProjectOnPlane(base.transform.TransformVector(movementDelta), Vector3.up).normalized * movementDelta.magnitude;
		}
		else
		{
			worldMovementDelta = movementDelta;
		}
		Vector3 targetPos = base.transform.position + worldMovementDelta;
		float distanceToPanningBounds;
		Vector3 vector = cameraController.ClampToWorldBounds(targetPos, out distanceToPanningBounds);
		Vector3 vector2 = vector - base.transform.position;
		base.transform.position = vector;
		this.OnCameraMoved?.Invoke(vector2, movedByPlayer);
		uiScalingManager.OnMoveCamera();
		cameraMoved = true;
	}

	private void LateUpdate()
	{
		if (settingsRouter.DisableAntiAliasingWhenCameraMoves)
		{
			if (cameraMoved && settingsRouter.AntiAliasingLevel != 3)
			{
				rememberAntiAliasingLevel = settingsRouter.AntiAliasingLevel;
				settingsRouter.SetAntialisingLevel(3);
			}
			else if (!cameraMoved && rememberAntiAliasingLevel != -1 && settingsRouter.AntiAliasingLevel != rememberAntiAliasingLevel)
			{
				settingsRouter.SetAntialisingLevel(rememberAntiAliasingLevel);
				rememberAntiAliasingLevel = -1;
			}
		}
		cameraMoved = false;
	}

	private void OnDestroy()
	{
		inputRouter.OnPanCamera -= PanCamera;
		inputRouter.OnFinishPanCamera -= StopPanningCamera;
		inputRouter.OnResetCamera -= ResetTransform;
		inputRouter.OnPanCameraLocalSpace -= PanCameraLocal;
	}
}
