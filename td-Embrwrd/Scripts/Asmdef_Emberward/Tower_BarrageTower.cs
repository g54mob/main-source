using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_BarrageTower : ADirectionalTower
{
	[Serializable]
	public class TowerAndParticleSet
	{
		public Transform towerHead;

		public Animator animator;

		public ParticleSystem particle_L;

		public ParticleSystem particle_R;
	}

	[CompilerGenerated]
	private sealed class _003CCR_Shoot_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_BarrageTower _003C_003E4__this;

		private int _003CcurSet_003E5__2;

		private int _003CshootCount_003E5__3;

		private int _003Ci_003E5__4;

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
		public _003CCR_Shoot_003Ed__21(int _003C_003E1__state)
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
	private float baseAttackRange;

	[SerializeField]
	private int maxBulletPerShoot;

	[SerializeField]
	private Spin spin_Cog;

	[SerializeField]
	private Vector3 cogSpinSpeed_Idle;

	[SerializeField]
	private Vector3 cogSpinSpeed_Shooting;

	[SerializeField]
	private ParticleSystem particle_UpgradeBSpark;

	[SerializeField]
	private List<TowerAndParticleSet> list_TowerAndParticleSets;

	private List<AMonsterBase> list_MonstersInArea;

	private int bulletShootCount;

	private int connectedBarrageTower;

	private Vector3 targetCogSpinSpeed;

	protected override void CannonSpawnProc()
	{
	}

	protected override void CannonDespawnProc()
	{
	}

	private void OnTowerPlaced(ABaseTower tower)
	{
	}

	private void OnTowerRemoved(ABaseTower tower)
	{
	}

	private void UpdateConnectedBarrageTowerCount()
	{
	}

	private int CountConnectedBarrageTowerInDirection(Vector3Int startPos, Vector3Int direction)
	{
		return 0;
	}

	protected override void CannonUpdateProc()
	{
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	protected override void ShootProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Shoot_003Ed__21))]
	private IEnumerator CR_Shoot()
	{
		return null;
	}
}
