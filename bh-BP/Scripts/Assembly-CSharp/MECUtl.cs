using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public static class MECUtl
{
	[CompilerGenerated]
	private sealed class _003CEmulateUpdate_003Ed__3 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public MonoBehaviour scr;

		public Action func;

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
		public _003CEmulateUpdate_003Ed__3(int _003C_003E1__state)
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

	public static float WaitUntilDone(IEnumerator<float> routine, Segment tgtSegment = Segment.Update)
	{
		return 0f;
	}

	public static CoroutineHandle RunEmulateUpdate(Action func, MonoBehaviour scr, Segment seg = Segment.Update)
	{
		return default(CoroutineHandle);
	}

	public static void RunEmulateUpdate(Action func, MonoBehaviour scr, ref CoroutineHandle handle, Segment seg = Segment.Update)
	{
	}

	[IteratorStateMachine(typeof(_003CEmulateUpdate_003Ed__3))]
	public static IEnumerator<float> EmulateUpdate(Action func, MonoBehaviour scr)
	{
		return null;
	}
}
