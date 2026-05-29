using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MyBox;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDelayedControllerEnabler_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController _003C_003E4__this;

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
		public _003CDelayedControllerEnabler_003Ed__14(int _003C_003E1__state)
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
	private sealed class _003CInsideChecker_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerController _003C_003E4__this;

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
		public _003CInsideChecker_003Ed__26(int _003C_003E1__state)
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

	[SerializeField]
	private Vector3 m_PlayerResetPosition;

	private Quaternion m_PlayerResetRotation;

	private bool m_Enabled;

	public Action<bool, bool, bool> onControllerEnabled;

	[SerializeField]
	[ReadOnly(new string[] { })]
	private bool m_IsInside;

	private Coroutine RayCheckerCoroutine;

	private PlayerInstance m_PlayerInstance;

	private LayerMask m_LayerMask;

	private Vector3 m_RayOffset;

	private Vector3 m_RayDirection;

	private RaycastHit m_Hit;

	public bool Enabled => false;

	public bool IsInside => false;

	public PlayerInstance PlayerInstance => null;

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CDelayedControllerEnabler_003Ed__14))]
	private IEnumerator DelayedControllerEnabler()
	{
		return null;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDayFinished()
	{
	}

	private void OnNewDayStarted()
	{
	}

	public void EnableController(bool enable, bool includeCamera, bool hasSentFromPauseMenu = false)
	{
	}

	private void OnDayCycleDisabled()
	{
	}

	public void IncreaseTimeScale()
	{
	}

	[IteratorStateMachine(typeof(_003CInsideChecker_003Ed__26))]
	private IEnumerator InsideChecker()
	{
		return null;
	}
}
