using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Perk_RandomLavaDotTetrisSpawnEveryRound : APerkBase
{
	[CompilerGenerated]
	private sealed class _003CCR_CreateBlocks_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay_min;

		public float delay_max;

		public Perk_RandomLavaDotTetrisSpawnEveryRound _003C_003E4__this;

		public int count;

		private int _003Ci_003E5__2;

		private float _003CcurTime_003E5__3;

		private float _003Cdelay_003E5__4;

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
		public _003CCR_CreateBlocks_003Ed__4(int _003C_003E1__state)
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

	private int retryLimit;

	private Dictionary<Obj_TetrisBlock, List<BoxCollider>> dic_TetrisToTempColliders;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnRoundStart(int round, int maxRound)
	{
	}

	private void OnRoundEnd()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_CreateBlocks_003Ed__4))]
	private IEnumerator CR_CreateBlocks(int count, float delay_min, float delay_max)
	{
		return null;
	}

	private void CreateRandomBlock()
	{
	}

	private Quaternion GetRandomRotation()
	{
		return default(Quaternion);
	}

	private (bool, Vector3) GetRandomBlockPosition()
	{
		return default((bool, Vector3));
	}

	private bool CreateRandomBlockInternal()
	{
		return false;
	}

	private bool IsRaycastHitSomething(Vector3 position)
	{
		return false;
	}

	private bool IsPositionTooCloseToBoss(Vector3Int pos, float limit)
	{
		return false;
	}

	private void OnTetrisPlacementFinished(Obj_TetrisBlock block)
	{
	}
}
