using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class bnz : MonoBehaviour
{
	private sealed class bny : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int ufo;

		private object ufp;

		public bnz ufq;

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
		public bny(int a)
		{
		}

		[DebuggerHidden]
		private void lbx()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in lbx
			this.lbx();
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
		private void lbz()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in lbz
			this.lbz();
		}
	}

	public float weight;

	public bmo ik;

	private float ufr;

	protected float xtk => 0f;

	[IteratorStateMachine(typeof(bny))]
	private IEnumerator lcc()
	{
		return null;
	}

	private void iuq()
	{
	}

	private void lcd()
	{
	}

	protected abstract void lbe();

	protected virtual void Start()
	{
	}

	private void ojk()
	{
	}

	private void nbk()
	{
	}

	protected virtual void OnDestroy()
	{
	}
}
