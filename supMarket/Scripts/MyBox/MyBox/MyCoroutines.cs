using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	public static class MyCoroutines
	{
		[CompilerGenerated]
		private sealed class _003COnCompleteCoroutine_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Coroutine coroutine;

			public Action onComplete;

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
			public _003COnCompleteCoroutine_003Ed__10(int _003C_003E1__state)
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
		private sealed class _003CStartNextCoroutine_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Coroutine coroutine;

			public IEnumerator nextCoroutine;

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
			public _003CStartNextCoroutine_003Ed__9(int _003C_003E1__state)
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

		private static CoroutineOwner _coroutineOwner;

		private static CoroutineOwner CoroutineOwner => null;

		public static Coroutine StartCoroutine(this IEnumerator coroutine)
		{
			return null;
		}

		public static Coroutine StartNext(this Coroutine coroutine, IEnumerator nextCoroutine)
		{
			return null;
		}

		public static Coroutine OnComplete(this Coroutine coroutine, Action onComplete)
		{
			return null;
		}

		public static void StopCoroutine(Coroutine coroutine)
		{
		}

		public static void StopAllCoroutines()
		{
		}

		public static CoroutineGroup CreateGroup(MonoBehaviour owner = null)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CStartNextCoroutine_003Ed__9))]
		private static IEnumerator StartNextCoroutine(Coroutine coroutine, IEnumerator nextCoroutine)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003COnCompleteCoroutine_003Ed__10))]
		private static IEnumerator OnCompleteCoroutine(Coroutine coroutine, Action onComplete)
		{
			return null;
		}
	}
}
