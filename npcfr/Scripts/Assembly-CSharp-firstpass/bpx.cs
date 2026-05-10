using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class bpx : MonoBehaviour
{
	private sealed class bpw : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int ukb;

		private object ukc;

		public bpx ukd;

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
		public bpw(int a)
		{
		}

		[DebuggerHidden]
		private void lgf()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in lgf
			this.lgf();
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
		private void lgh()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in lgh
			this.lgh();
		}
	}

	private Animator uke;

	private Vector3 ukf;

	private Quaternion ukg;

	private void Start()
	{
	}

	private void hcs()
	{
	}

	[IteratorStateMachine(typeof(bpw))]
	private IEnumerator lgj()
	{
		return null;
	}
}
