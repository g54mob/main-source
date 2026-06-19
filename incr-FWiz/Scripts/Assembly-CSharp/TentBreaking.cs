using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using OUSystems.Basics.Effects;
using UnityEngine;

public class TentBreaking : StoryIDEvent
{
	[CompilerGenerated]
	private sealed class _003CBreakAnimation_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TentBreaking _003C_003E4__this;

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
		public _003CBreakAnimation_003Ed__10(int _003C_003E1__state)
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

	public bool Broken;

	public GameObject StandingTent;

	public GameObject BrokenTent;

	public EventReference ShakeSound;

	public EventReference BreakSound;

	public ShakeReceiver ShakeReceiver;

	public float Shake;

	public float ShakeTime;

	public void SetBroken()
	{
	}

	public override void Trigger()
	{
	}

	[IteratorStateMachine(typeof(_003CBreakAnimation_003Ed__10))]
	public IEnumerator BreakAnimation()
	{
		return null;
	}
}
