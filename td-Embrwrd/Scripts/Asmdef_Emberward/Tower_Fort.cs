using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Fort : ABaseTower
{
	[CompilerGenerated]
	private sealed class _003CSpawnProc_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Fort _003C_003E4__this;

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
		public _003CSpawnProc_003Ed__25(int _003C_003E1__state)
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
	private GameObject node_UpgradeAHeatBar;

	[SerializeField]
	private GameObject heatBar_RedBlock;

	[SerializeField]
	private GameObject heatBar_YellowBlock;

	[SerializeField]
	private GameObject node_UpgradeAHeatBar_BarSize;

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
	[Header("放置時的煙霧特效")]
	protected ParticleSystem particle_PlacementCloud;

	[SerializeField]
	[Header("升級A: 額外模型")]
	protected GameObject model_UpgradeA_AdditionalPart;

	[SerializeField]
	[Header("升級B: 額外模型")]
	protected GameObject model_UpgradeB_AdditionalPart;

	private int upgradeA_bulletShotCount;

	private int upgradeA_bulletShotLimit;

	private float upgradeA_overheatTimer;

	private float upgradeA_overheatDuration;

	private float timeAfterShoot;

	private bool isAllGridHaveTetris;

	private Vector3 headAimTargetPosition;

	private float checkNewTargetTimer;

	private float bulletCooldownTimer;

	private void Start()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnProc_003Ed__25))]
	private IEnumerator SpawnProc()
	{
		return null;
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

	private void UpdateHeatBar()
	{
	}
}
