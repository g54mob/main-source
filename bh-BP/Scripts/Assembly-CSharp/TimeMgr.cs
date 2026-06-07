using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Sirenix.OdinInspector;

public class TimeMgr : SerializedMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CWaitForPhysicsSeconds_003Ed__29 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public TimeMgr _003C_003E4__this;

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
		public _003CWaitForPhysicsSeconds_003Ed__29(int _003C_003E1__state)
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
	private sealed class _003C_WaitForGameSeconds_003Ed__28 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public TimeMgr _003C_003E4__this;

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
		public _003C_WaitForGameSeconds_003Ed__28(int _003C_003E1__state)
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

	public static TimeMgr I;

	private float _timeDebt;

	private float _gameTime;

	private float _gameDeltaTime;

	private float _physicsTime;

	private float _defaultFixedDeltaTime;

	private float _gameFixedDeltaTime;

	private float _gameSpeed;

	[NonSerialized]
	public List<Action> FixedUpdaters;

	[NonSerialized]
	public DelegateUtl.NoArgsEvent OnGameSpeedChanged;

	private const int kMaxFixedFPS = 60;

	private const bool kAllowFastFixedDeltaTime = false;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnFPSChanged()
	{
	}

	private void MyUpdate()
	{
	}

	private void RunFixedUpdate(float fixedDeltaTime)
	{
	}

	public void SetGameSpeed(float speed)
	{
	}

	public float GetGameSpeed()
	{
		return 0f;
	}

	public float GetTime()
	{
		return 0f;
	}

	public float GetDeltaTime()
	{
		return 0f;
	}

	public float GetPhysicsTime()
	{
		return 0f;
	}

	public float GetFixedDeltaTime()
	{
		return 0f;
	}

	public float GetPct(float startTime, float len)
	{
		return 0f;
	}

	public float GetTimeSince(float startTime)
	{
		return 0f;
	}

	public float GetPhysPct(float startTime, float len)
	{
		return 0f;
	}

	public float WaitForGameSeconds(float secs)
	{
		return 0f;
	}

	[IteratorStateMachine(typeof(_003C_WaitForGameSeconds_003Ed__28))]
	public IEnumerator<float> _WaitForGameSeconds(float secs)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CWaitForPhysicsSeconds_003Ed__29))]
	public IEnumerator<float> WaitForPhysicsSeconds(float secs)
	{
		return null;
	}
}
