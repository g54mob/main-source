using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Gh.Tk;
using UnityEngine;

public class IFEyeMotion : AttachedBehaviour
{
	public enum BlinkType
	{
		Awake = 0,
		Droop = 1,
		Sleep = 2,
		Wide = 3
	}

	[CompilerGenerated]
	private sealed class _003CBlinkTimer_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IFEyeMotion _003C_003E4__this;

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
		public _003CBlinkTimer_003Ed__23(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CReturnToAwake_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IFEyeMotion _003C_003E4__this;

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
		public _003CReturnToAwake_003Ed__24(int _003C_003E1__state)
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

	private Transform _left_Eyeball;

	private Transform _left_LidUpper;

	private Transform _left_LidLower;

	private Transform _right_Eyeball;

	private Transform _right_LidUpper;

	private Transform _right_LidLower;

	public Transform lookAtTarget;

	public bool lookAt;

	private bool _lastLookAt;

	public float minBlinkTime;

	public float maxBlinkTime;

	public bool _blink;

	public BlinkType currentBlinkType;

	private BlinkType lastBlinkType;

	public bool autoReturnToAwake;

	private bool _readyToSwitch;

	private bool _playedOnce;

	private bool _enabled;

	public override void Start()
	{
	}

	private void Update()
	{
	}

	private void BlinkCleanUp()
	{
	}

	private void BlinkPlay()
	{
	}

	[IteratorStateMachine(typeof(_003CBlinkTimer_003Ed__23))]
	private IEnumerator BlinkTimer()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CReturnToAwake_003Ed__24))]
	private IEnumerator ReturnToAwake()
	{
		return null;
	}

	private void Blink()
	{
	}

	private void Wide()
	{
	}

	private void Unwide()
	{
	}

	private void Droop()
	{
	}

	private void Undroop()
	{
	}

	private void DroopBlink()
	{
	}

	private void Sleep()
	{
	}

	private void Wake()
	{
	}

	protected override void LateRestoreStateInternal(IDataStore data)
	{
	}
}
