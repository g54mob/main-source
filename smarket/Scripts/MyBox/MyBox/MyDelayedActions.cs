using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace MyBox
{
	public static class MyDelayedActions
	{
		[CompilerGenerated]
		private sealed class _003CDelayedActionCoroutine_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public bool unscaled;

			public float waitSeconds;

			public Action action;

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
			public _003CDelayedActionCoroutine_003Ed__6(int _003C_003E1__state)
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
		private sealed class _003CDelayedUiSelection_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameObject objectToSelect;

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
			public _003CDelayedUiSelection_003Ed__4(int _003C_003E1__state)
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

		public static Coroutine DelayedAction(float waitSeconds, Action action, bool unscaled = false)
		{
			return null;
		}

		public static void DelayedAction(Action action)
		{
		}

		public static Coroutine DelayedAction(this MonoBehaviour invoker, float waitSeconds, Action action, bool unscaled = false)
		{
			return null;
		}

		public static Coroutine DelayedAction(this MonoBehaviour invoker, Action action)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDelayedUiSelection_003Ed__4))]
		public static IEnumerator DelayedUiSelection(GameObject objectToSelect)
		{
			return null;
		}

		public static Coroutine DelayedUiSelection(this MonoBehaviour invoker, GameObject objectToSelect)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDelayedActionCoroutine_003Ed__6))]
		private static IEnumerator DelayedActionCoroutine(float waitSeconds, Action action, bool unscaled = false)
		{
			return null;
		}
	}
}
