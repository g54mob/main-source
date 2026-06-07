using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Fort_V2 : ABaseTower, IDynamicPlacementTarget
{
	[CompilerGenerated]
	private sealed class _003CSpawnProc_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Fort_V2 _003C_003E4__this;

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
		public _003CSpawnProc_003Ed__28(int _003C_003E1__state)
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

	private Vector3 headModelForward;

	[SerializeField]
	private Transform node_HeadAimingRotation;

	[SerializeField]
	private GameObject node_FortBottom;

	[SerializeField]
	private Spin spin_MachineGun;

	[SerializeField]
	private Spin spin_Cog;

	[SerializeField]
	private ParticleSystem particle_ShieldEffect;

	[SerializeField]
	private Vector3 spinSpeed_MachineGun_Normal;

	[SerializeField]
	private Vector3 spinSpeed_MachineGun_Fast;

	[SerializeField]
	private Vector3 spinSpeed_Cog_Normal;

	[SerializeField]
	private Vector3 spinSpeed_Cog_Fast;

	[SerializeField]
	private GameObject obj_UpgradeB_RangeIndicator;

	[SerializeField]
	private ParticleSystem particle_UpgradeIceCloud;

	[Header("放置時的煙霧特效")]
	[SerializeField]
	protected ParticleSystem particle_PlacementCloud;

	[SerializeField]
	[Header("一般狀態額外模型")]
	protected GameObject model_NoUpgrade_AdditionalPart;

	[SerializeField]
	[Header("升級A: 額外模型")]
	protected GameObject model_UpgradeA_AdditionalPart;

	[SerializeField]
	[Header("升級B: 額外模型")]
	protected GameObject model_UpgradeB_AdditionalPart;

	[SerializeField]
	private List<eTowerSizeType> dynamicPlacementSizeType;

	[SerializeField]
	private Transform node_TowerPlacementPosition;

	[SerializeField]
	private GameObject node_MachineGun;

	[SerializeField]
	private GameObject prefab_Bullet_UpgradeB;

	private int upgradeA_bulletShotCount;

	private int upgradeA_bulletShotLimit;

	private float upgradeA_overheatTimer;

	private float upgradeA_overheatDuration;

	private float timeAfterShoot;

	private bool isAllGridHaveTetris;

	private Vector3 headAimTargetPosition;

	private float checkNewTargetTimer;

	private float upgradeBCheckTimer;

	private float upgradeBCheckInterval;

	private bool isRegisteredDynamicPlacement;

	private ABaseTower attachedTower;

	private void Start()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnProc_003Ed__28))]
	private IEnumerator SpawnProc()
	{
		return null;
	}

	protected override void CannonDespawnProc()
	{
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

	protected override void OnMouseEnterProc()
	{
	}

	protected override void OnMouseOverProc()
	{
	}

	protected override void OnMouseExitProc()
	{
	}

	private bool CanPlaceTower()
	{
		return false;
	}

	protected override void OnSellTowerProc()
	{
	}

	public Transform GetPlacementTransform()
	{
		return null;
	}

	public bool HasTower()
	{
		return false;
	}

	public void PlaceTowerProc(ABaseTower tower)
	{
	}

	private int GetFortTowerLayerCountRecursive(ABaseTower tower, int count)
	{
		return 0;
	}

	public void RemoveTowerProc(ABaseTower tower)
	{
	}
}
