using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using MEC;
using UnityEngine;

public class GridPieceObjShooter : GridPieceObj
{
	[CompilerGenerated]
	private sealed class _003C_MyUpdate_003Ed__10 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridPieceObjShooter _003C_003E4__this;

		private float _003CnextShootTime_003E5__2;

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
		public _003C_MyUpdate_003Ed__10(int _003C_003E1__state)
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

	[Header("Shooter")]
	public ArrowType TgtArrow;

	public float MinShootCycle;

	public float MaxShootCycle;

	public int NumArrowsPerShot;

	public float ArrowArc;

	public EventReference SFXOnShoot;

	public override void Init(GridPieceInst inst)
	{
	}

	public override void Reset()
	{
	}

	private float PickRandomCycle()
	{
		return 0f;
	}

	[IteratorStateMachine(typeof(_003C_MyUpdate_003Ed__10))]
	private IEnumerator<float> _MyUpdate()
	{
		return null;
	}
}
