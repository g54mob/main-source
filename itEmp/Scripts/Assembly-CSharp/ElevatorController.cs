using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public int finishFloor;

		public Action _003C_003E9__0;

		internal void _003CCloseAllDoor_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int floorNumber;

		internal bool _003CMoveToFloor_003Eb__0(ElevatorFloor f)
		{
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003CCloseAllDoor_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ElevatorController _003C_003E4__this;

		private _003C_003Ec__DisplayClass10_0 _003C_003E8__1;

		public Action finish;

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
		public _003CCloseAllDoor_003Ed__10(int _003C_003E1__state)
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
	private sealed class _003CMoveToFloor_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int floorNumber;

		public ElevatorController _003C_003E4__this;

		public bool playerInElevator;

		private _003C_003Ec__DisplayClass8_0 _003C_003E8__1;

		public Action finish;

		private Vector3 _003CstartPosition_003E5__2;

		private Vector3 _003CtargetPosition_003E5__3;

		private float _003CtimeToMove_003E5__4;

		private float _003CelapsedTime_003E5__5;

		private float _003Cr_003E5__6;

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
		public _003CMoveToFloor_003Ed__8(int _003C_003E1__state)
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
	private sealed class _003COpenDoorOnFloor_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ElevatorController _003C_003E4__this;

		public int floor;

		public Action finish;

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
		public _003COpenDoorOnFloor_003Ed__11(int _003C_003E1__state)
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

	public Transform platform;

	public List<ElevatorFloor> Floor;

	public ElevatorPanel panel;

	public Transform BlockExit;

	public bool isMoving;

	public int currentFloor;

	public float elevatorSpeed;

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CMoveToFloor_003Ed__8))]
	public IEnumerator MoveToFloor(int floorNumber, bool playerInElevator, Action finish)
	{
		return null;
	}

	private void UpdateCurrentFloor()
	{
	}

	[IteratorStateMachine(typeof(_003CCloseAllDoor_003Ed__10))]
	public IEnumerator CloseAllDoor(Action finish)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003COpenDoorOnFloor_003Ed__11))]
	public IEnumerator OpenDoorOnFloor(int floor, Action finish)
	{
		return null;
	}

	public bool ElevatorBussy()
	{
		return false;
	}
}
