using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class spiderWallControll : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CwaitingTime_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public spiderWallControll _003C_003E4__this;

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
		public _003CwaitingTime_003Ed__17(int _003C_003E1__state)
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

	public GameObject animationHolder;

	public Transform target;

	public Transform targetPosition1;

	public Transform targetPosition2;

	public Transform targetPosition3;

	public Transform targetPosition4;

	public Transform targetPosition5;

	public bool waiting;

	public float rndWaitingTime;

	public float moveSpeed;

	public float distance;

	public float number;

	public float degrees;

	public float Tempnumber;

	public GameObject walkSound;

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	[IteratorStateMachine(typeof(_003CwaitingTime_003Ed__17))]
	public virtual IEnumerator waitingTime()
	{
		return null;
	}
}
