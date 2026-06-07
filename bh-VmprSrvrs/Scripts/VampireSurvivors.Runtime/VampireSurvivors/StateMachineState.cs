using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace VampireSurvivors
{
	public class StateMachineState : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CFireEventWithDelayRoutine_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public StateMachineState _003C_003E4__this;

			public string eventStr;

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
			public _003CFireEventWithDelayRoutine_003Ed__6(int _003C_003E1__state)
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

		protected StateMachine parentStateMachine;

		public virtual void Init(StateMachine stateMachine)
		{
		}

		public virtual void OnEnter()
		{
		}

		public virtual void OnExit()
		{
		}

		protected void FireEvent(string eventStr)
		{
		}

		protected void FireEventWithDelay(string eventStr, float delay)
		{
		}

		[IteratorStateMachine(typeof(_003CFireEventWithDelayRoutine_003Ed__6))]
		private IEnumerator FireEventWithDelayRoutine(string eventStr, float delay)
		{
			return null;
		}
	}
}
