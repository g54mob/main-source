using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SkjutplattaDoor : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003Cljudlength_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public SkjutplattaDoor _003C_003E4__this;

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
		public _003Cljudlength_003Ed__9(int _003C_003E1__state)
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

	public bool doorUnlocked;

	public bool doorUnlockedArrow;

	public GameObject steelDoor;

	public GameObject lockDel1;

	public GameObject lockDel2;

	public AudioClip unlockLjud;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public virtual void OnTriggerEnter(Collider other)
	{
	}

	[IteratorStateMachine(typeof(_003Cljudlength_003Ed__9))]
	public virtual IEnumerator ljudlength()
	{
		return null;
	}
}
