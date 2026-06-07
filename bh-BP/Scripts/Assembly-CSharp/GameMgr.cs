using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMOD.Studio;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_EnterGameOver_003Ed__30 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GameMgr _003C_003E4__this;

		private bool _003ChasAnyPickups_003E5__2;

		private int _003Ci_003E5__3;

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
		public _003C_EnterGameOver_003Ed__30(int _003C_003E1__state)
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
	private sealed class _003C_RunLevelComplete_003Ed__28 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GameMgr _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private float _003CapproxLen_003E5__3;

		private int _003CnumPerFrame_003E5__4;

		private bool _003ChasAnyPickups_003E5__5;

		private int _003Ci_003E5__6;

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
		public _003C_RunLevelComplete_003Ed__28(int _003C_003E1__state)
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
	private sealed class _003C_RunSlomo_003Ed__35 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GameMgr _003C_003E4__this;

		public float speed;

		public float len;

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
		public _003C_RunSlomo_003Ed__35(int _003C_003E1__state)
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
	private sealed class _003C_WaitForBattleSeconds_003Ed__33 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float secs;

		private float _003CstartTime_003E5__2;

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
		public _003C_WaitForBattleSeconds_003Ed__33(int _003C_003E1__state)
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

	public static GameMgr I;

	public GameState PrevState;

	public GameState CurState;

	public List<GameState> QueuedStates;

	public List<PetType> QueuedFoundEggs;

	public DelegateUtl.NoArgsEvent OnStateChanged;

	public DelegateUtl.NoArgsEvent OnSecondPassed;

	private List<EventInstance> _loopingSFX;

	private float _lastBattleTime;

	private float _battleDeltaTime;

	private bool _isRunningSlomo;

	private bool _enteredGameOver;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private bool HasSpecialMenu(GameState st)
	{
		return false;
	}

	public void CloseSpecialMenu()
	{
	}

	public void SetState(GameState st, bool force = false)
	{
	}

	private void OnTacticsStateChanged()
	{
	}

	public void PauseLoopingSFX(bool isPaused)
	{
	}

	public float GetDefaultGameSpeed()
	{
		return 0f;
	}

	private void MyFixedUpdate()
	{
	}

	public void OnBattleLoaded()
	{
	}

	private void MyUpdate()
	{
	}

	public void GoToBase()
	{
	}

	public bool IsInputAllowed()
	{
		return false;
	}

	public void MarkLevelComplete()
	{
	}

	public void AddSeconds(float secs)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunLevelComplete_003Ed__28))]
	private IEnumerator<float> _RunLevelComplete()
	{
		return null;
	}

	public void LoseGame()
	{
	}

	[IteratorStateMachine(typeof(_003C_EnterGameOver_003Ed__30))]
	private IEnumerator<float> _EnterGameOver()
	{
		return null;
	}

	public float GetBattleDeltaTime()
	{
		return 0f;
	}

	public float WaitForBattleSeconds(float secs)
	{
		return 0f;
	}

	[IteratorStateMachine(typeof(_003C_WaitForBattleSeconds_003Ed__33))]
	public IEnumerator<float> _WaitForBattleSeconds(float secs)
	{
		return null;
	}

	public void RunSlomo(float speed, float len)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunSlomo_003Ed__35))]
	private IEnumerator<float> _RunSlomo(float speed, float len)
	{
		return null;
	}

	public void RegisterLoopingSFX(EventInstance inst)
	{
	}

	public void DeregisterLoopingSFX(EventInstance inst)
	{
	}

	private void OnControllerDisconnected()
	{
	}

	public void EnterEndless()
	{
	}
}
