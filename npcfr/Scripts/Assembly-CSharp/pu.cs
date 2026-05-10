using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using Views.Generic;

public class pu
{
	private sealed class pt : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int rcr;

		private object rcs;

		public pu rct;

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
		public pt(int a)
		{
		}

		[DebuggerHidden]
		private void ges()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ges
			this.ges();
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
		private void geu()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in geu
			this.geu();
		}
	}

	private readonly gd rcu;

	private readonly GameObject rcv;

	private readonly PopupWindow rcw;

	private readonly Highlighter rcx;

	private bool rcy;

	private Coroutine rcz;

	private bool rda;

	public void gex()
	{
	}

	public void iox(bool a)
	{
	}

	public void nvr(bool a)
	{
	}

	public void gey(bool a)
	{
	}

	[IteratorStateMachine(typeof(pt))]
	private IEnumerator gez()
	{
		return null;
	}

	public void gew()
	{
	}

	public pu(gd a, GameObject b, PopupWindow c, Highlighter d)
	{
	}

	public void hep()
	{
	}

	public void lra(bool a)
	{
	}

	public void fsn()
	{
	}
}
