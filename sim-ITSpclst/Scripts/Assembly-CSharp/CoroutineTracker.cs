using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CoroutineTracker : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CWrapCoroutine_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public IEnumerator routine;

		public Action<Coroutine> onComplete;

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
		public _003CWrapCoroutine_003Ed__3(int _003C_003E1__state)
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

	private static List<Coroutine> activeCoroutines;

	public static Coroutine StartTrackedCoroutine(IEnumerator routine, MonoBehaviour owner)
	{
		return null;
	}

	public static void StopTrackedCoroutine(Coroutine coroutine, MonoBehaviour owner)
	{
	}

	[IteratorStateMachine(typeof(_003CWrapCoroutine_003Ed__3))]
	private static IEnumerator WrapCoroutine(IEnumerator routine, Action<Coroutine> onComplete)
	{
		return null;
	}

	private void OnGUI()
	{
	}
}
