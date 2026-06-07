using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class GridPieceObjFlyer : GridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_ChangeFlyingPos_003Ed__18 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjFlyer _003C_003E4__this;

		public bool newFlying;

		private float _003CstartTime_003E5__2;

		private Vector3 _003CstartPos_003E5__3;

		private Vector3 _003CtgtPos_003E5__4;

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
		public _003C_ChangeFlyingPos_003Ed__18(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003C_MyUpdate_003Ed__19 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjFlyer _003C_003E4__this;

		private float _003CnextFlyTime_003E5__2;

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
		public _003C_MyUpdate_003Ed__19(int _003C_003E1__state)
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

	private CoroutineHandle _update;

	private CoroutineHandle _flyAnim;

	private bool _isTransitioning;

	public bool IsFlying;

	public float MinGroundCycle;

	public float MaxGroundCycle;

	public float MinFlyCycle;

	public float MaxFlyCycle;

	public GridPieceMarker CurMarker;

	[Header("Shooting")]
	public ArrowType TgtArrow;

	public int NumArrowsPerShot;

	public float ArrowArc;

	private const float kFlyTime = 0.25f;

	public override void Init(GridPieceInst inst)
	{
	}

	public override void Reset()
	{
	}

	public override void Die(bool runDeathAnim)
	{
	}

	private float PickRandomCycle()
	{
		return 0f;
	}

	public void SetFlying(bool isFlying, bool force = false)
	{
	}

	[IteratorStateMachine(typeof(_003C_ChangeFlyingPos_003Ed__18))]
	private IEnumerator<float> _ChangeFlyingPos(bool newFlying)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_MyUpdate_003Ed__19))]
	private IEnumerator<float> _MyUpdate()
	{
		return null;
	}

	public override void UpdateWalk()
	{
	}

	public override void AttackPlayer()
	{
	}
}
