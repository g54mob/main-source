using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SFPModule : UsableObject
{
	[CompilerGenerated]
	private sealed class _003CSlideIntoPort_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SFPModule _003C_003E4__this;

		public Transform port;

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
		public _003CSlideIntoPort_003Ed__12(int _003C_003E1__state)
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

	public CableLink link;

	public float speed;

	public int sfpType;

	private Coroutine slideRoutine;

	public BoxCollider boxCollider;

	public bool isInTheBox;

	public int positionInBox;

	public override void Awake()
	{
	}

	public bool IsAnyCableConnected()
	{
		return false;
	}

	public override void InteractOnClick()
	{
	}

	public override void InteractOnHover(RaycastHit hit)
	{
	}

	public void InsertedInSFPPort(CableLink _link, bool immediate = false)
	{
	}

	[IteratorStateMachine(typeof(_003CSlideIntoPort_003Ed__12))]
	private IEnumerator SlideIntoPort(Transform port)
	{
		return null;
	}

	public void InsertDirectlyIntoPort(CableLink _link)
	{
	}

	public void RemoveFromPort()
	{
	}

	public override void OnDestroy()
	{
	}
}
