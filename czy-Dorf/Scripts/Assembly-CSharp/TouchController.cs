using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TouchController : MonoBehaviour
{
	private sealed class _003CResetMovedDistanceAtEndOfFrame_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TouchController _003C_003E4__this;

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
		public _003CResetMovedDistanceAtEndOfFrame_003Ed__15(int _003C_003E1__state)
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
			TouchController touchController = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForEndOfFrame();
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				touchController.movedDistance = 0f;
				return false;
			}
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

	private float mouseMoveThreshold = 0.1f;

	private float movedDistance;

	private PlayerControls controls;

	public PlayerControls Controls => controls;

	public Vector2 CurrentPrimaryTouchPos => Controls.Touch.PrimaryFingerPosition.ReadValue<Vector2>();

	public Vector2 CurrentFrameSecondaryTouchPos => Controls.Touch.SecondaryFingerPosition.ReadValue<Vector2>();

	public bool TilePlacementAllowed => movedDistance <= mouseMoveThreshold;

	private void Awake()
	{
		controls = new PlayerControls();
	}

	private void OnEnable()
	{
		controls.Enable();
	}

	private void OnDisable()
	{
		controls.Disable();
	}

	public void ResetMovedDistance()
	{
		StartCoroutine(ResetMovedDistanceAtEndOfFrame());
	}

	private IEnumerator ResetMovedDistanceAtEndOfFrame()
	{
		return new _003CResetMovedDistanceAtEndOfFrame_003Ed__15(0)
		{
			_003C_003E4__this = this
		};
	}

	public void AddMovedDistance(Vector2 delta)
	{
		movedDistance += delta.magnitude;
	}
}
