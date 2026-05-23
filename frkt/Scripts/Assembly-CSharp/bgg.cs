using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Infrastructure.Project.Registration;
using Infrastructure.Project.Registration.Native;
using UnityEngine;

public abstract class bgg : MonoBehaviour, bgd, bfw, bfz
{
	private sealed class bge<a> where a : bgb
	{
		public a sxh;

		internal a isw()
		{
			return null;
		}
	}

	private sealed class bgf : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int sxi;

		private object sxj;

		public bgg sxk;

		private List<NativePrefabsGroupHandler>.Enumerator sxl;

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

		private void isy()
		{
		}

		[DebuggerHidden]
		private void isx()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in isx
			this.isx();
		}

		[DebuggerHidden]
		public bgf(int a)
		{
		}

		[DebuggerHidden]
		private void ita()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ita
			this.ita();
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
	}

	private List<NativePrefabsGroupHandler> sxm;

	private bool sxn;

	private bfx sxo;

	protected IEnumerable<NativePrefabsGroupHandler> xmt => null;

	protected abstract List<NativePrefabsGroupHandler> iso();

	public void isp<a>(PrefabID a, a b) where a : bgb
	{
	}

	public void itd(bfx a)
	{
	}

	protected virtual void isn()
	{
	}

	[IteratorStateMachine(typeof(bgf))]
	public IEnumerator irn()
	{
		return null;
	}

	public void hhn(bfx a)
	{
	}
}
