using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class BaseTutMgr : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_RunControllerSidebarTut_003Ed__11 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_RunControllerSidebarTut_003Ed__11(int _003C_003E1__state)
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
	private sealed class _003C_RunTut_003Ed__12 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public BaseTutType t;

		public BaseTutMgr _003C_003E4__this;

		private Vector3 _003CstartPos_003E5__2;

		private FTUEArgs _003CfArgs_003E5__3;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_RunTut_003Ed__12(int _003C_003E1__state)
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

	public static BaseTutMgr I;

	public DelegateUtl.NoArgsEvent OnTutSeen;

	public BaseTutType CurTut;

	public int CurTutStep;

	public BuildItem TgtBldItem;

	private CoroutineHandle _curAnim;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public bool IsSeen(BaseTutType t)
	{
		return false;
	}

	public void Show(BaseTutType t)
	{
	}

	public void Cancel()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunControllerSidebarTut_003Ed__11))]
	private IEnumerator<float> _RunControllerSidebarTut()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunTut_003Ed__12))]
	private IEnumerator<float> _RunTut(BaseTutType t)
	{
		return null;
	}

	public bool IsShowing()
	{
		return false;
	}

	public void MarkSeen(BaseTutType t)
	{
	}
}
