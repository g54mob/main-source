using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class prisonDoorOpenClose : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CdoorLoose_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public prisonDoorOpenClose _003C_003E4__this;

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
		public _003CdoorLoose_003Ed__25(int _003C_003E1__state)
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
	private sealed class _003CtimerDoorclosed_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public prisonDoorOpenClose _003C_003E4__this;

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
		public _003CtimerDoorclosed_003Ed__23(int _003C_003E1__state)
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
	private sealed class _003CtimerDooropen_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public prisonDoorOpenClose _003C_003E4__this;

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
		public _003CtimerDooropen_003Ed__22(int _003C_003E1__state)
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

	public bool DoorOpen;

	public bool DoorMoving;

	public AudioClip doorOpen;

	public AudioClip doorClose;

	public AudioClip doorLockedLjud;

	public bool doorLocked;

	public bool sprint1Bort;

	public bool sprint2Bort;

	public GameObject sprint1;

	public GameObject sprint2;

	public bool doorFree;

	public GameObject sparcle1;

	public GameObject sparcle2;

	public GameObject galler;

	public GameObject gallerColliders;

	public GameObject camSeeTrigger;

	public GameObject camSound;

	public GameObject bottomCollider;

	public bool doorOpenAgain;

	public GameObject granny;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CtimerDooropen_003Ed__22))]
	public virtual IEnumerator timerDooropen()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CtimerDoorclosed_003Ed__23))]
	public virtual IEnumerator timerDoorclosed()
	{
		return null;
	}

	public virtual void timerDoorlocked()
	{
	}

	[IteratorStateMachine(typeof(_003CdoorLoose_003Ed__25))]
	public virtual IEnumerator doorLoose()
	{
		return null;
	}

	public virtual void OnTriggerEnter(Collider other)
	{
	}
}
