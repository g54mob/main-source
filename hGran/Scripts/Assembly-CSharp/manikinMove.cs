using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class manikinMove : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CTimer_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public manikinMove _003C_003E4__this;

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
		public _003CTimer_003Ed__9(int _003C_003E1__state)
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

	public bool startStopMoving;

	public bool soundPlayed;

	public Transform player;

	public int damping;

	public GameObject soundHolder;

	public GameObject gameController;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void OnTriggerEnter(Collider other)
	{
	}

	[IteratorStateMachine(typeof(_003CTimer_003Ed__9))]
	public virtual IEnumerator Timer()
	{
		return null;
	}
}
