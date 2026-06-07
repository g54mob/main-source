using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[SelectionBase]
public class Obj_FreezeGrid : ACorruptedPowerGrid
{
	[CompilerGenerated]
	private sealed class _003CCR_PlaceTetrisProc_003Ed__1 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_TetrisBlock tetris;

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
		public _003CCR_PlaceTetrisProc_003Ed__1(int _003C_003E1__state)
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

	[SerializeField]
	private ParticleSystem particle_TetrisPlaced;

	[IteratorStateMachine(typeof(_003CCR_PlaceTetrisProc_003Ed__1))]
	protected override IEnumerator CR_PlaceTetrisProc(Obj_TetrisBlock tetris)
	{
		return null;
	}

	protected override void OnCorruptGridMoveStart(Vector3 targetPosition)
	{
	}

	protected override void OnCorruptGridMoveEnd()
	{
	}

	public override string GetLocStatsString()
	{
		return null;
	}
}
