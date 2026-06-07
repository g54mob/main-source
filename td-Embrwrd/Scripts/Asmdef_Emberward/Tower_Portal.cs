using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Portal : ABaseTower
{
	private class TrailRendererPair
	{
		public TrailRenderer trail;

		public bool isUsing;
	}

	private class TeleportingMonsterData
	{
		public AMonsterBase monster;

		public int monsterID;
	}

	[CompilerGenerated]
	private sealed class _003CCR_Teleport_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Portal _003C_003E4__this;

		public AMonsterBase monster;

		private TeleportingMonsterData _003Crecord_003E5__2;

		private Vector3 _003CtargetPosition_003E5__3;

		private TrailRendererPair _003CtrailPair_003E5__4;

		private TrailRenderer _003CtrailRenderer_003E5__5;

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
		public _003CCR_Teleport_003Ed__30(int _003C_003E1__state)
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
	private List<BoxCollider> list_PillarColliders;

	[SerializeField]
	private ParticleSystem particle_Teleport;

	[SerializeField]
	private ParticleSystem particle_Spark_UpgradeA;

	[SerializeField]
	private TrailRenderer trailRenderer;

	private List<TrailRendererPair> list_ClonedTrails;

	[SerializeField]
	private Dictionary<int, int> dic_MonsterTriggerRecords;

	private int energy;

	private int maxEnergy;

	private float energyRestoreInterval;

	private float energyRestoreTimer;

	private int energyRestoreAmount;

	private bool isUpgradeAEffectTriggered;

	private float infiniteEnergyTimer;

	private UI_Obj_PortalTowerEnergy ui_energyBar;

	private List<TeleportingMonsterData> list_TeleportingMonster;

	private Vector3Int gridPos;

	private int totalTeleportedCount;

	protected override void SwitchToPlacementModeProc()
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	protected override void CannonDespawnProc()
	{
	}

	private void OnRoundEnd()
	{
	}

	private void SetEnergy(int value)
	{
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	public override void TowerStunProc()
	{
	}

	public override void TowerStunEndProc()
	{
	}

	protected override void ShootProc()
	{
	}

	private int GetMonsterEnergyCost(AMonsterBase monster)
	{
		return 0;
	}

	[IteratorStateMachine(typeof(_003CCR_Teleport_003Ed__30))]
	private IEnumerator CR_Teleport(AMonsterBase monster)
	{
		return null;
	}

	private TrailRendererPair GetTrailRendererPair()
	{
		return null;
	}

	private bool CanTeleportMonster(AMonsterBase monster)
	{
		return false;
	}

	public override bool CanSellTower()
	{
		return false;
	}

	public override string GetExtraTowerControlRecord()
	{
		return null;
	}
}
