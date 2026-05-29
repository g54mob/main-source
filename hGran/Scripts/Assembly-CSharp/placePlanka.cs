using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class placePlanka : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CtextTimer_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public placePlanka _003C_003E4__this;

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
		public _003CtextTimer_003Ed__10(int _003C_003E1__state)
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

	public GameObject gameController;

	public GameObject highlightPlanka;

	public bool holeOpen;

	public bool startText;

	public GameObject PlaceButton;

	public GameObject text;

	public virtual void Start()
	{
	}

	public virtual void OnTriggerEnter(Collider other)
	{
	}

	public virtual void OnTriggerStay(Collider other)
	{
	}

	public virtual void OnTriggerExit(Collider other)
	{
	}

	[IteratorStateMachine(typeof(_003CtextTimer_003Ed__10))]
	public virtual IEnumerator textTimer()
	{
		return null;
	}
}
