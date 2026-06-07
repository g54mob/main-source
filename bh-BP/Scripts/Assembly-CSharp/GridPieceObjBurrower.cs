using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using MEC;
using UnityEngine;

public class GridPieceObjBurrower : GridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_ChangeBurrowPos_003Ed__19 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjBurrower _003C_003E4__this;

		public bool newBurrowing;

		private Vector3 _003CstartPos_003E5__2;

		private Vector3 _003CtgtPos_003E5__3;

		private float _003CstartTime_003E5__4;

		private float _003Clen_003E5__5;

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
		public _003C_ChangeBurrowPos_003Ed__19(int _003C_003E1__state)
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
	private sealed class _003C_MyUpdate_003Ed__20 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjBurrower _003C_003E4__this;

		private float _003CnextBurrowTime_003E5__2;

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
		public _003C_MyUpdate_003Ed__20(int _003C_003E1__state)
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
	private sealed class _003C_RunAttack_003Ed__22 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjBurrower _003C_003E4__this;

		public Transform xfm;

		public Func<EnemyAttackResult> onAttackComplete;

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
		public _003C_RunAttack_003Ed__22(int _003C_003E1__state)
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

	private CoroutineHandle _burrowAnim;

	public bool IsBurrowing;

	public GridPieceMarker CurMarker;

	public PartSys BurrowParts;

	public float MinGroundCycle;

	public float MaxGroundCycle;

	public float MinBurrowCycle;

	public float MaxBurrowCycle;

	[Header("Shooting")]
	public ArrowType TgtArrow;

	public int NumArrowsPerShot;

	public float ArrowArc;

	private const float kBurrowTime = 0.25f;

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

	public void SetBurrowing(bool isBurrowing, bool force = false)
	{
	}

	private Vector3 GetBurrowPos(bool isBurrowing)
	{
		return default(Vector3);
	}

	[IteratorStateMachine(typeof(_003C_ChangeBurrowPos_003Ed__19))]
	private IEnumerator<float> _ChangeBurrowPos(bool newBurrowing)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_MyUpdate_003Ed__20))]
	private IEnumerator<float> _MyUpdate()
	{
		return null;
	}

	public override void UpdateWalk()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunAttack_003Ed__22))]
	protected override IEnumerator<float> _RunAttack(Transform xfm, Func<EnemyAttackResult> onAttackComplete)
	{
		return null;
	}
}
