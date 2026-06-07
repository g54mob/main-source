using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Earthquake : ABaseTower
{
	[CompilerGenerated]
	private sealed class _003CCR_ShootProc_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Earthquake _003C_003E4__this;

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
		public _003CCR_ShootProc_003Ed__19(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CSpawnProc_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Earthquake _003C_003E4__this;

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
		public _003CSpawnProc_003Ed__13(int _003C_003E1__state)
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
	private float originalShootRange;

	[SerializeField]
	private Transform node_ShootEffect;

	[SerializeField]
	[Header("放置時的煙霧特效")]
	private ParticleSystem particle_PlacementCloud;

	[Header("未升級的攻擊特效")]
	[SerializeField]
	private ParticleSystem particle_AttackEffect;

	[Header("升級A的攻擊特效")]
	[SerializeField]
	private ParticleSystem particle_AttackEffect_UpgradeA;

	[Header("升級B的額外模型")]
	[SerializeField]
	private GameObject model_UpgradeB;

	[Header("升級B的特效")]
	[SerializeField]
	private ParticleSystem particle_UpgradeB_SignalWave;

	private int earthquakeTowerCount;

	private StatModifier curModifier_UpgradeB;

	protected override void CannonSpawnProc()
	{
	}

	protected override void CannonDespawnProc()
	{
	}

	protected override void SwitchToPlacementModeProc()
	{
	}

	private void OnTowerPlaced(ABaseTower tower)
	{
	}

	private void OnTowerRemoved(ABaseTower tower)
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnProc_003Ed__13))]
	private IEnumerator SpawnProc()
	{
		return null;
	}

	protected void Update_UpgradeB_Effect()
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

	[IteratorStateMachine(typeof(_003CCR_ShootProc_003Ed__19))]
	private IEnumerator CR_ShootProc()
	{
		return null;
	}
}
