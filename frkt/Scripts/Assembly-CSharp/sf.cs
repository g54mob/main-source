using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Zenject;

public class sf : rx.rw
{
	private sealed class se : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int rqq;

		private object rqr;

		public sf rqs;

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
		public se(int a)
		{
		}

		[DebuggerHidden]
		private void gsp()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in gsp
			this.gsp();
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
		private void gsr()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in gsr
			this.gsr();
		}
	}

	private bjs rqt;

	private bool rqu;

	private gd rqv;

	private void gsx()
	{
	}

	public override void gsu()
	{
	}

	private void jzm()
	{
	}

	public override void gsv()
	{
	}

	[IteratorStateMachine(typeof(se))]
	public IEnumerator gsw()
	{
		return null;
	}

	[Inject]
	private void gst(gd a)
	{
	}

	private void mur()
	{
	}
}
