using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class bl : MonoBehaviour
{
	private sealed class bk : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pfz;

		private object pga;

		public bl pgb;

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
		public bk(int a)
		{
		}

		[DebuggerHidden]
		private void dcg()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dcg
			this.dcg();
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
		private void dci()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dci
			this.dci();
		}
	}

	public float time;

	private float pgc;

	[IteratorStateMachine(typeof(bk))]
	private IEnumerator Flicker()
	{
		return null;
	}

	private void hqa()
	{
	}

	private void cvt()
	{
	}

	private void Start()
	{
	}
}
