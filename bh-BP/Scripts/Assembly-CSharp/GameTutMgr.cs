using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class GameTutMgr : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_RunTut_003Ed__13 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GameTutType t;

		public bool skipButtonPress;

		public GameTutMgr _003C_003E4__this;

		private float _003CstartXP_003E5__2;

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
		public _003C_RunTut_003Ed__13(int _003C_003E1__state)
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

	public static GameTutMgr I;

	public GameTutType CurTut;

	private bool _pressedCurBtn;

	private bool _didMoveHorizontal;

	private bool _didMoveVertical;

	private bool _didAim;

	private bool _didShoot;

	private float _showTime;

	private CoroutineHandle _curAnim;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public bool IsSeen(GameTutType t)
	{
		return false;
	}

	public void Show(GameTutType t, bool skipButtonPress = false)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunTut_003Ed__13))]
	private IEnumerator<float> _RunTut(GameTutType t, bool skipButtonPress)
	{
		return null;
	}

	private void OnGameStateChanged()
	{
	}
}
