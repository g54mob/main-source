using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class bg : MonoBehaviour
{
	private sealed class bf : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pfl;

		private object pfm;

		public bg pfn;

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
		public bf(int a)
		{
		}

		[DebuggerHidden]
		private void dby()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dby
			this.dby();
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
		private void dca()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dca
			this.dca();
		}
	}

	public bool OnlyDeactivate;

	private void csd()
	{
	}

	private void cfw()
	{
	}

	private void OnEnable()
	{
	}

	[IteratorStateMachine(typeof(bf))]
	private IEnumerator CheckIfAlive()
	{
		return null;
	}

	private void mbu()
	{
	}
}
