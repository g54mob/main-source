using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RootMotion.FinalIK;
using UnityEngine;

public abstract class bnx : MonoBehaviour
{
	[Serializable]
	public class OffsetLimits
	{
		public FullBodyBipedEffector effector;

		public float spring;

		public bool x;

		public bool y;

		public bool z;

		public float minX;

		public float maxX;

		public float minY;

		public float maxY;

		public float minZ;

		public float maxZ;

		public void lbm(IKEffector a, Quaternion b)
		{
		}

		private float lbn(float a, float b, float c)
		{
			return 0f;
		}

		private float lbo(float a, float b, bool c)
		{
			return 0f;
		}
	}

	private sealed class bnw : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int ufk;

		private object ufl;

		public bnx ufm;

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
		public bnw(int a)
		{
		}

		[DebuggerHidden]
		private void lbp()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in lbp
			this.lbp();
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
		private void lbr()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in lbr
			this.lbr();
		}
	}

	public float weight;

	public bmi ik;

	protected float ufn;

	protected float xth => 0f;

	protected virtual void OnDestroy()
	{
	}

	protected void lbw(OffsetLimits[] a)
	{
	}

	private void kkb()
	{
	}

	[IteratorStateMachine(typeof(bnw))]
	private IEnumerator lbu()
	{
		return null;
	}

	protected virtual void Start()
	{
	}

	protected abstract void kzn();

	private void lbv()
	{
	}

	private void drc()
	{
	}

	private void jkl()
	{
	}

	protected void bga(OffsetLimits[] a)
	{
	}

	private void jrr()
	{
	}
}
