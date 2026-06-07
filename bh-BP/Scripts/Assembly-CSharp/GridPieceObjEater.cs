using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class GridPieceObjEater : GridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_HoldBall_003Ed__11 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjEater _003C_003E4__this;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_HoldBall_003Ed__11(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
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
		void IEnumerator.Reset()
		{
		}
	}

	public int MaxEatenBalls;

	public float EatenBallRadius;

	public List<Transform> EatenBallXfms;

	public List<BallObj> EatenBalls;

	private CoroutineHandle _holdAnim;

	private float _rndCycle;

	private float _rndDir;

	public override void Init(GridPieceInst inst)
	{
	}

	public override void Reset()
	{
	}

	public override void Die(bool runDeathAnim)
	{
	}

	public override bool OnAboutToHit(BallObj b, Vector2 hitNormal)
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003C_HoldBall_003Ed__11))]
	private IEnumerator<float> _HoldBall()
	{
		return null;
	}
}
