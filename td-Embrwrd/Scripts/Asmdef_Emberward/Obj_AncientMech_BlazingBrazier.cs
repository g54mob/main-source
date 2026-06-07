using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Obj_AncientMech_BlazingBrazier : Obj_AncientMech_Base
{
	[CompilerGenerated]
	private sealed class _003CCR_RemoveFreeGrid_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AGridObject gridObject;

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
		public _003CCR_RemoveFreeGrid_003Ed__14(int _003C_003E1__state)
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
	private Animator animator;

	[SerializeField]
	private int range;

	[SerializeField]
	private GameObject node_Model;

	[SerializeField]
	private GameObject node_Range;

	[SerializeField]
	private ParticleSystem particle_Flame;

	private float detectInterval;

	private float detectTimer;

	private List<Vector3Int> list_AllGridsInRange;

	private List<Obj_TetrisBlock> list_ProcessedTetrisBlocks;

	private bool isTooltipOn;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void Update()
	{
	}

	private void DetectFrozenBlocks()
	{
	}

	private void DetectFreezeCorruptGrid()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_RemoveFreeGrid_003Ed__14))]
	private IEnumerator CR_RemoveFreeGrid(AGridObject gridObject)
	{
		return null;
	}

	protected override void OnEffectActivateProc()
	{
	}

	protected override void OnEffectDeactivateProc()
	{
	}

	private void OnMouseEnter()
	{
	}

	private void OnMouseExit()
	{
	}
}
