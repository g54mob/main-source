using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace Rhizomatic.Utility
{
	public class Awaiter : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003C_AwaitYield_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public YieldInstruction yieldInstruction;

			public UnityAction done;

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
			public _003C_AwaitYield_003Ed__4(int _003C_003E1__state)
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
		private sealed class _003C_AwaitYield_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CustomYieldInstruction yieldInstruction;

			public UnityAction done;

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
			public _003C_AwaitYield_003Ed__6(int _003C_003E1__state)
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

		private static Awaiter _instance;

		public static Awaiter instance => null;

		public Coroutine AwaitYield(YieldInstruction yieldInstruction, UnityAction done)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003C_AwaitYield_003Ed__4))]
		private IEnumerator _AwaitYield(YieldInstruction yieldInstruction, UnityAction done)
		{
			return null;
		}

		public Coroutine AwaitYield(CustomYieldInstruction yieldInstruction, UnityAction done)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003C_AwaitYield_003Ed__6))]
		private IEnumerator _AwaitYield(CustomYieldInstruction yieldInstruction, UnityAction done)
		{
			return null;
		}
	}
}
