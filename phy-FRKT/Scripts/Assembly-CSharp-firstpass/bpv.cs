using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class bpv : MonoBehaviour
{
	private sealed class bpu : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int ujt;

		private object uju;

		public float ujv;

		public bpv ujw;

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
		public bpu(int a)
		{
		}

		[DebuggerHidden]
		private void lfz()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in lfz
			this.lfz();
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
		private void lgb()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in lgb
			this.lgb();
		}
	}

	public float resetDelay;

	private Vector3 ujx;

	private Quaternion ujy;

	private Transform ujz;

	private Rigidbody uka;

	private void Start()
	{
	}

	private void had()
	{
	}

	private void lgd(Transform a)
	{
	}

	private void gzc(Transform a)
	{
	}

	private void dhs()
	{
	}

	[IteratorStateMachine(typeof(bpu))]
	private IEnumerator lge(float a)
	{
		return null;
	}
}
