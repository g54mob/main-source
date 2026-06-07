using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class ARuneGrid : AGridObject
{
	public enum ePowerGridState
	{
		IDLE = 0,
		HAS_TETRIS = 1,
		HAS_TOWER = 2
	}

	[CompilerGenerated]
	private sealed class _003CCR_PlaceTetrisProc_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CCR_PlaceTetrisProc_003Ed__12(int _003C_003E1__state)
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
	protected PowerGridSettingData settingData;

	[SerializeField]
	protected Animator animator;

	[SerializeField]
	protected Collider collider;

	[SerializeField]
	protected ePowerGridState state;

	private Vector3Int registeredPosition;

	private bool isTooltipOn;

	public PowerGridSettingData SettingData => null;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public virtual void OnTetrisPlaced(Obj_TetrisBlock tetris)
	{
	}

	protected virtual void OnTetrisRemoved(Obj_TetrisBlock tetris)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_PlaceTetrisProc_003Ed__12))]
	protected virtual IEnumerator CR_PlaceTetrisProc(Obj_TetrisBlock tetris)
	{
		return null;
	}

	public void OnTowerPlaced(ABaseTower tower)
	{
	}

	private void OnTowerRemoved(ABaseTower tower)
	{
	}

	protected virtual void ApplyEffectToTower(ABaseTower tower)
	{
	}

	protected virtual void RemoveEffectFromTower(ABaseTower tower)
	{
	}

	private void Update()
	{
	}

	public void OnMouseEnter()
	{
	}

	public void OnMouseExit()
	{
	}

	public virtual string GetLocNameString(bool isPrefix = true)
	{
		return null;
	}

	public virtual string GetLocStatsString()
	{
		return null;
	}
}
