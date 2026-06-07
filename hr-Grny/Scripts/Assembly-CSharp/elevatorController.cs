using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class elevatorController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CdoorsIsMoving_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public elevatorController _003C_003E4__this;

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
		public _003CdoorsIsMoving_003Ed__16(int _003C_003E1__state)
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

	public GameObject ElevatorDoors;

	public bool ElevatorIsDown;

	public bool DoorsClosed;

	public bool ElevatorInUse;

	public bool doorsMoving;

	public bool doorsOpen;

	public AudioClip DoorOpenSound;

	public AudioClip DoorCloseSound;

	public GameObject elevatorSound;

	public bool testButton;

	public bool testButtonDoors;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public virtual void ElevatorGo()
	{
	}

	public virtual void CallElevatorDown()
	{
	}

	public virtual void DoorsCloseOpen()
	{
	}

	[IteratorStateMachine(typeof(_003CdoorsIsMoving_003Ed__16))]
	public virtual IEnumerator doorsIsMoving()
	{
		return null;
	}
}
