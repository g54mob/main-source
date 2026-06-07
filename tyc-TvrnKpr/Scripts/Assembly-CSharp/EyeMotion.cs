using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Gh.Tk;
using UnityEngine;

public class EyeMotion : AttachedBehaviour
{
	public enum BlinkType
	{
		Awake = 0,
		Droop = 1,
		Sleep = 2,
		Wide = 3,
		WideShort = 4,
		Squint = 5,
		Reset = 6
	}

	[CompilerGenerated]
	private sealed class _003CBlinkTimer_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EyeMotion _003C_003E4__this;

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

		public EyeMotion _003C_003E4__this;

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

	private Transform _leftEyeball;

	private Transform _leftLidUpper;

	private Transform _leftLidLower;

	private Transform _rightEyeball;

	private Transform _rightLidUpper;

	private Transform _rightLidLower;

	public Transform lookAtTarget;

	[PersistenceOptIn]
	public bool lookAt;

	[PersistenceOptIn]
	private bool _lastLookAt;

	[PersistenceOptIn]
	private bool _blink;

	[PersistenceOptIn]
	public BlinkType currentBlinkType;

	[PersistenceOptIn]
	private BlinkType _lastBlinkType;

	[PersistenceOptIn]
	public bool autoReturnToAwake;

	[PersistenceOptIn]
	private bool _readyToSwitch;

	[PersistenceOptIn]
	private bool _playedOnce;

	public override void Start()
	{
	}

	protected override void UpdateInternal()
	{
	}

	private void ForceCleanUp()
	{
	}

	public override void OnDestroy()
	{
	}

	private void BlinkCleanUp()
	{
	}

	private void BlinkPlay(float? duration = null)
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

	private void AnimateLid(Vector3 upperRotation, Vector3 lowerRotation, int loopAmount = 1, LoopType loopType = LoopType.Incremental, float? duration = null, Action onComplete = null)
	{
	}

	private void Blink(float? duration = null)
	{
	}

	private void Wide(float? duration = null)
	{
	}

	private void Unwide(float? duration = null)
	{
	}

	private void Droop(float? duration = null)
	{
	}

	private void Undroop(float? duration = null)
	{
	}

	private void Squint(float? duration = null)
	{
	}

	private void Unsquint(float? duration = null)
	{
	}

	private void Sleep(float? duration = null)
	{
	}

	private void Wake(float? duration = null)
	{
	}

	protected override void LateRestoreStateInternal(IDataStore data)
	{
	}
}
