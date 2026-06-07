using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using VampireSurvivors.Signals;

namespace VampireSurvivors
{
	public class GameStateSurvarotsSelection : GameStateMachineState
	{
		[CompilerGenerated]
		private sealed class _003CWaitDelay_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameStateSurvarotsSelection _003C_003E4__this;

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
			public _003CWaitDelay_003Ed__4(int _003C_003E1__state)
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

		public override void OnEnter()
		{
		}

		public override void OnExit()
		{
		}

		private void AddCharacterCard(UISignals.CharacterCardSelectedSignal sig)
		{
		}

		private void Skip()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitDelay_003Ed__4))]
		private IEnumerator WaitDelay()
		{
			return null;
		}

		private void OnConnectionError(GameplaySignals.ConnectionErrorSignal signal)
		{
		}
	}
}
