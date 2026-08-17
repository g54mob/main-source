using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine;
using UnityEngine;

namespace VampireSurvivors;

public class StateMachineState : MonoBehaviour
{
	private sealed class _003CFireEventWithDelayRoutine_003Ed__6(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public StateMachineState _003C_003E4__this;

		public string eventStr;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0079: Expected I4, but got I8
			//IL_00f2: Expected I4, but got O
			StateMachineState stateMachineState = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForSeconds waitForSeconds = null;
				waitForSeconds.m_Seconds = delay;
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null || (object)stateMachineState.parentStateMachine == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				stateMachineState.parentStateMachine.FireEvent(eventStr);
				GameEventMessage.SendEvent(eventStr);
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	protected StateMachine parentStateMachine;

	public virtual void Init(StateMachine stateMachine)
	{
		parentStateMachine = stateMachine;
	}

	public virtual void OnEnter()
	{
	}

	public virtual void OnExit()
	{
	}

	protected void FireEvent(string eventStr)
	{
		parentStateMachine.FireEvent(eventStr);
		GameEventMessage.SendEvent(eventStr);
	}

	protected void FireEventWithDelay(string eventStr, float delay)
	{
		_003CFireEventWithDelayRoutine_003Ed__6 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.eventStr = eventStr;
		obj.delay = delay;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator FireEventWithDelayRoutine(string eventStr, float delay)
	{
		_003CFireEventWithDelayRoutine_003Ed__6 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.eventStr = eventStr;
		obj.delay = delay;
		return obj;
	}

	public StateMachineState()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
