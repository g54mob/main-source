using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using UnityEngine;

public class bfg : bfh
{
	private sealed class bff : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int svg;

		private object svh;

		public bfg svi;

		public CursorLockMode svj;

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
		public bff(int a)
		{
		}

		[DebuggerHidden]
		private void ipj()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ipj
			this.ipj();
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
		private void ipl()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ipl
			this.ipl();
		}
	}

	private readonly ok svl;

	private readonly gd svm;

	private CursorLockMode svn;

	private Coroutine svo;

	public CursorLockMode xme => default(CursorLockMode);

	private CinemachinePanTilt xmf => null;

	private CinemachineInputAxisController xmg => null;

	public event Action<CursorLockMode> svk
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void brc()
	{
	}

	[IteratorStateMachine(typeof(bff))]
	private IEnumerator ipu(CursorLockMode a)
	{
		return null;
	}

	private void mxk(bool a)
	{
	}

	private void nts(bool a)
	{
	}

	private void ipt()
	{
	}

	public bfg(ok a, gd b)
	{
	}

	private void qm()
	{
	}

	private void gqs(bool a)
	{
	}

	private void lsl()
	{
	}

	private void nfd()
	{
	}

	public void ips(CursorLockMode a)
	{
	}

	private void ipv(bool a)
	{
	}
}
