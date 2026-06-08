using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PinchInput : MonoBehaviour
{
	private sealed class _003CZooming_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PinchInput _003C_003E4__this;

		private float _003CcurrentDistance_003E5__2;

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
		public _003CZooming_003Ed__8(int _003C_003E1__state)
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
			PinchInput pinchInput = _003C_003E4__this;
			float num2;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				num2 = _003CcurrentDistance_003E5__2;
			}
			else
			{
				_003C_003E1__state = -1;
				num2 = 0f;
				_003CcurrentDistance_003E5__2 = 0f;
			}
			_003CcurrentDistance_003E5__2 = Vector2.Distance(pinchInput.touchController.Controls.Touch.PrimaryFingerPosition.ReadValue<Vector2>(), pinchInput.touchController.Controls.Touch.SecondaryFingerPosition.ReadValue<Vector2>());
			if (!(Vector2.Dot(pinchInput.touchController.Controls.Touch.PrimaryTouchDelta.ReadValue<Vector2>(), pinchInput.touchController.Controls.Touch.SecondaryTouchDelta.ReadValue<Vector2>()) > 0f) && _003CcurrentDistance_003E5__2 != num2)
			{
				pinchInput.OnPinchZoom.Invoke(Time.deltaTime * pinchInput.zoomMultiplier * (_003CcurrentDistance_003E5__2 - num2));
			}
			_003C_003E2__current = null;
			_003C_003E1__state = 1;
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
	private float zoomMultiplier = 1f;

	[SerializeField]
	private FloatEvent OnPinchZoom;

	private TouchController touchController;

	private Coroutine zoomCoroutine;

	private void Awake()
	{
		touchController = GetComponentInParent<TouchController>();
	}

	private void Start()
	{
		touchController.Controls.Touch.SecondaryTouchContact.started += delegate
		{
			ZoomStart();
		};
		touchController.Controls.Touch.SecondaryTouchContact.canceled += delegate
		{
			ZoomEnd();
		};
	}

	private void ZoomStart()
	{
		zoomCoroutine = StartCoroutine(Zooming());
	}

	private void ZoomEnd()
	{
		StopCoroutine(zoomCoroutine);
	}

	private IEnumerator Zooming()
	{
		return new _003CZooming_003Ed__8(0)
		{
			_003C_003E4__this = this
		};
	}

	private void _003CStart_003Eb__5_0(InputAction.CallbackContext _)
	{
		ZoomStart();
	}

	private void _003CStart_003Eb__5_1(InputAction.CallbackContext _)
	{
		ZoomEnd();
	}
}
