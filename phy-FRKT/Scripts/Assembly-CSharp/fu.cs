using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Jobs;
using UnityEngine;

public abstract class fu
{
	private sealed class ft : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pzd;

		private object pze;

		public fu pzf;

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
		public ft(int a)
		{
		}

		[DebuggerHidden]
		private void efm()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in efm
			this.efm();
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
		private void efo()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in efo
			this.efo();
		}
	}

	private readonly MonoBehaviour pzh;

	private Coroutine pzi;

	private bool pzj;

	private bool pzk;

	private JobHandle pzl;

	private IReadOnlyCollection<IDisposable> pzm;

	private bool pzn;

	public bool pzg
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public fu(MonoBehaviour a)
	{
	}

	protected virtual void efu()
	{
	}

	public void isr()
	{
	}

	public void efs()
	{
	}

	public void eft()
	{
	}

	[IteratorStateMachine(typeof(ft))]
	private IEnumerator efw()
	{
		return null;
	}

	public void fhu()
	{
	}

	private string efx()
	{
		return null;
	}

	public void csf()
	{
	}

	public void jzh()
	{
	}

	protected void efv(JobHandle a, params IDisposable[] disposables)
	{
	}

	public void chu()
	{
	}

	protected void faa(JobHandle a, params IDisposable[] disposables)
	{
	}

	protected abstract IEnumerator dmk();
}
