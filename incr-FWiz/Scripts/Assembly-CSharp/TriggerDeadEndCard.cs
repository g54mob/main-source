using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using UnityEngine;

public class TriggerDeadEndCard : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public bool finishedPanning;

		internal void _003CTriggerPlayerPopup_003Eb__0()
		{
		}

		internal void _003CTriggerPlayerPopup_003Eb__1()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CTriggerPlayerPopup_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TriggerDeadEndCard _003C_003E4__this;

		private _003C_003Ec__DisplayClass6_0 _003C_003E8__1;

		private DeadEndCard _003CdeadEndCard_003E5__2;

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
		public _003CTriggerPlayerPopup_003Ed__6(int _003C_003E1__state)
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

	public Transform ReturnPosition;

	public float PanTime;

	private bool _handling;

	public DeadEndCard DemoEndCard;

	public EventReference _popupSound;

	private void OnCollisionEnter2D(Collision2D collision)
	{
	}

	[IteratorStateMachine(typeof(_003CTriggerPlayerPopup_003Ed__6))]
	public IEnumerator TriggerPlayerPopup()
	{
		return null;
	}
}
