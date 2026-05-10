using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class hb
{
	private sealed class ha : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int qap;

		private object qaq;

		public string qar;

		public Action qas;

		private AsyncOperation qat;

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
		public ha(int a)
		{
		}

		[DebuggerHidden]
		private void ejd()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ejd
			this.ejd();
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
		private void ejf()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ejf
			this.ejf();
		}
	}

	public void ejh(string a)
	{
	}

	public void hky(string a)
	{
	}

	public bool ela()
	{
		return false;
	}

	public void myf(string a)
	{
	}

	[IteratorStateMachine(typeof(ha))]
	private IEnumerator ejk(string a, Action b = null)
	{
		return null;
	}

	public void gxt(string a)
	{
	}

	public void hdq(string a)
	{
	}

	public bool ejj()
	{
		return false;
	}

	public void kuk(string a, Action b = null)
	{
	}

	public bool exi()
	{
		return false;
	}

	public bool ctc()
	{
		return false;
	}

	public void eji(string a, Action b = null)
	{
	}
}
