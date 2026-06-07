using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[SelectionBase]
public class Obj_BuffGrid_Coin : APowerGrid
{
	private class MonsterTriggerEntry
	{
		public AMonsterBase monster;

		public float triggerTime;
	}

	[CompilerGenerated]
	private sealed class _003CCR_PlaceTetrisProc_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_BuffGrid_Coin _003C_003E4__this;

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
		public _003CCR_PlaceTetrisProc_003Ed__16(int _003C_003E1__state)
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

	[SerializeField]
	private ParticleSystem particle_TowerPlaced;

	[SerializeField]
	private TowerStats buffStat;

	[SerializeField]
	private bool isLimitTowerElement;

	[SerializeField]
	private eDamageType limitTowerElementType;

	private List<MonsterTriggerEntry> list_MonsterTriggerEntry;

	private bool isEffectAppliedToTower;

	public TowerStats BuffStat => null;

	public bool IsLimitTowerElement => false;

	public eDamageType LimitTowerElementType => default(eDamageType);

	private void Update()
	{
	}

	protected override void OnTetrisRemovedProc(Obj_TetrisBlock tetris)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_PlaceTetrisProc_003Ed__16))]
	protected override IEnumerator CR_PlaceTetrisProc(Obj_TetrisBlock tetris)
	{
		return null;
	}

	protected override void ApplyEffectToTower(ABaseTower tower)
	{
	}

	protected override void RemoveEffectFromTower(ABaseTower tower)
	{
	}

	private void OnTowerKillMonster(ABaseTower tower, AMonsterBase monster)
	{
	}

	public override string GetLocStatsString()
	{
		return null;
	}
}
