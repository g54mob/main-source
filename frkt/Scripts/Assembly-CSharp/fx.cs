using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public static class fx
{
	private sealed class fv : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pzo;

		private object pzp;

		public fu pzq;

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
		public fv(int a)
		{
		}

		[DebuggerHidden]
		private void efz()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in efz
			this.efz();
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
		private void egb()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in egb
			this.egb();
		}
	}

	private sealed class fw : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pzr;

		private object pzs;

		public IReadOnlyCollection<fu> pzt;

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
		public fw(int a)
		{
		}

		[DebuggerHidden]
		private void egd()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in egd
			this.egd();
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
		private void egf()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in egf
			this.egf();
		}
	}

	[IteratorStateMachine(typeof(fv))]
	public static IEnumerator egh(fu a)
	{
		return null;
	}

	[IteratorStateMachine(typeof(fw))]
	public static IEnumerator egi(IReadOnlyCollection<fu> a)
	{
		return null;
	}
}
