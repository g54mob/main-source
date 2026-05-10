using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class bj : MonoBehaviour
{
	private sealed class bi : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pfr;

		private object pfs;

		public bj pft;

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
		public bi(int a)
		{
		}

		[DebuggerHidden]
		private void dcc()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dcc
			this.dcc();
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
		private void dce()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dce
			this.dce();
		}
	}

	private static Vector2[] pfu;

	public float lifetime;

	public float fadeoutpercent;

	public Vector2 frames;

	public bool randomRotation;

	public bool deactivate;

	private float pfv;

	private float pfw;

	private Color pfx;

	private float pfy;

	private void nzi()
	{
	}

	private void fun()
	{
	}

	private void bmf()
	{
	}

	private void mzs()
	{
	}

	private void ftb()
	{
	}

	private void OnEnable()
	{
	}

	private void lpq()
	{
	}

	private void Awake()
	{
	}

	[IteratorStateMachine(typeof(bi))]
	private IEnumerator holeUpdate()
	{
		return null;
	}
}
