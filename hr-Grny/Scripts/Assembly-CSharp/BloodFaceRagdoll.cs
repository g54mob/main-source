using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class BloodFaceRagdoll : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003ChitTimer_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BloodFaceRagdoll _003C_003E4__this;

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
		public _003ChitTimer_003Ed__10(int _003C_003E1__state)
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

	public GameObject GC_Lantern;

	public GameObject GC_Flashlight;

	public GameObject Lantern;

	public GameObject flashlight;

	public Image bloodScreenHit;

	public GameObject bloodScreenHitTexture;

	public bool bloodHitON;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public virtual void playerHit()
	{
	}

	[IteratorStateMachine(typeof(_003ChitTimer_003Ed__10))]
	public virtual IEnumerator hitTimer()
	{
		return null;
	}
}
