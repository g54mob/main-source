using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class SwipeInput : MonoBehaviour
{
	private sealed class _003CSwiping_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SwipeInput _003C_003E4__this;

		private Vector2 _003CcurrentFramePrimaryPos_003E5__2;

		private Vector2 _003ClastFramePrimaryPos_003E5__3;

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
		public _003CSwiping_003Ed__19(int _003C_003E1__state)
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
			SwipeInput swipeInput = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003CcurrentFramePrimaryPos_003E5__2 = swipeInput.touchController.CurrentPrimaryTouchPos;
				_003ClastFramePrimaryPos_003E5__3 = _003CcurrentFramePrimaryPos_003E5__2;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			case 2:
				_003C_003E1__state = -1;
				_003ClastFramePrimaryPos_003E5__3 = _003CcurrentFramePrimaryPos_003E5__2;
				break;
			}
			_003CcurrentFramePrimaryPos_003E5__2 = swipeInput.touchController.CurrentPrimaryTouchPos;
			Vector2 vector = swipeInput.touchController.Controls.Touch.PrimaryTouchDelta.ReadValue<Vector2>();
			Vector2 vector2 = swipeInput.touchController.Controls.Touch.SecondaryTouchDelta.ReadValue<Vector2>();
			if (swipeInput.twoFingersDown && Vector2.Dot(vector, vector2) < 0f)
			{
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (swipeInput.useWorldPos)
			{
				Ray ray = swipeInput.mainCamera.ScreenPointToRay(_003CcurrentFramePrimaryPos_003E5__2);
				Ray ray2 = swipeInput.mainCamera.ScreenPointToRay(_003ClastFramePrimaryPos_003E5__3);
				swipeInput.groundPlane.Raycast(ray, out var enter);
				swipeInput.groundPlane.Raycast(ray2, out var enter2);
				Vector3 point = ray.GetPoint(enter);
				Vector3 vector3 = ray2.GetPoint(enter2) - point;
				vector = new Vector2(vector3.x, vector3.z);
			}
			else
			{
				vector *= PlayerPrefs.GetFloat("MouseSensitivity", 1f);
			}
			if (swipeInput.twoFingersDown)
			{
				swipeInput.onTwoFingerSwipe?.Invoke((vector + vector2) / 2f * swipeInput.speedMultiplier);
			}
			else
			{
				swipeInput.onSwipe?.Invoke(vector * swipeInput.speedMultiplier);
			}
			_003C_003E2__current = null;
			_003C_003E1__state = 2;
			return true;
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
	private Vector2Event onSwipeStart;

	[SerializeField]
	private Vector2Event onSwipe;

	[SerializeField]
	private UnityEvent onSwipeEnd;

	[SerializeField]
	private Vector2Event onTwoFingerSwipeStart;

	[SerializeField]
	private Vector2Event onTwoFingerSwipe;

	[SerializeField]
	private UnityEvent onTwoFingerSwipeEnd;

	[SerializeField]
	private float speedMultiplier = 1f;

	[SerializeField]
	private bool useWorldPos;

	private TouchController touchController;

	private Coroutine swipeCoroutine;

	private Camera mainCamera;

	private bool twoFingersDown;

	private Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

	private void Awake()
	{
		touchController = GetComponentInParent<TouchController>();
	}

	private void Start()
	{
		mainCamera = OverwritingSingleton<IngameUi>.Instance.mainCamera;
		touchController.Controls.Touch.PrimaryTouchContact.started += StartTouchPrimary;
		touchController.Controls.Touch.PrimaryTouchContact.canceled += EndTouchPrimary;
		touchController.Controls.Touch.SecondaryTouchContact.started += delegate
		{
			StartSecondaryTouch();
		};
		touchController.Controls.Touch.SecondaryTouchContact.canceled += delegate
		{
			EndSecondaryTouch();
		};
	}

	private void StartSecondaryTouch()
	{
		twoFingersDown = true;
		onTwoFingerSwipeStart?.Invoke(touchController.CurrentPrimaryTouchPos);
	}

	private void EndSecondaryTouch()
	{
		twoFingersDown = false;
		onTwoFingerSwipeEnd?.Invoke();
	}

	private void StartTouchPrimary(InputAction.CallbackContext ctx)
	{
		onSwipeStart?.Invoke(touchController.CurrentPrimaryTouchPos);
		swipeCoroutine = StartCoroutine(Swiping());
	}

	private void EndTouchPrimary(InputAction.CallbackContext ctx)
	{
		StopCoroutine(swipeCoroutine);
		onSwipeEnd?.Invoke();
	}

	private IEnumerator Swiping()
	{
		return new _003CSwiping_003Ed__19(0)
		{
			_003C_003E4__this = this
		};
	}

	private void _003CStart_003Eb__14_0(InputAction.CallbackContext _)
	{
		StartSecondaryTouch();
	}

	private void _003CStart_003Eb__14_1(InputAction.CallbackContext _)
	{
		EndSecondaryTouch();
	}
}
