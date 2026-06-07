using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Lasso : ABaseTower
{
	public enum eTowerState
	{
		IDLE = 0,
		CONNECTING = 1,
		CONNECTED = 2
	}

	[CompilerGenerated]
	private sealed class _003CCR_ConnectEffect_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Lasso _003C_003E4__this;

		private float _003Ctime_003E5__2;

		private float _003Cduration_003E5__3;

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
		public _003CCR_ConnectEffect_003Ed__33(int _003C_003E1__state)
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
	private sealed class _003CSpawnProc_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Lasso _003C_003E4__this;

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
		public _003CSpawnProc_003Ed__20(int _003C_003E1__state)
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
	private LineRenderer lineRenderer;

	[SerializeField]
	private ParticleSystem particle_ShootingLightningBall;

	[SerializeField]
	private ParticleSystem particle_LassoRing;

	[SerializeField]
	private ParticleSystem particle_BreakConnectionExplosion;

	[SerializeField]
	private Spin spin_Cog;

	[SerializeField]
	private Vector3 cogSpinSpeed_Normal;

	[SerializeField]
	private Vector3 cogSpinSpeed_Fast;

	[SerializeField]
	private float breakConnectionExplosionRadius;

	[SerializeField]
	[Header("放置時的煙霧特效")]
	protected ParticleSystem particle_PlacementCloud;

	[SerializeField]
	[Header("升級A特效")]
	private LineRenderer lineRenderer_UpgradeA;

	[SerializeField]
	private ParticleSystem particle_ShootingLightningBall_UpgradeA;

	[SerializeField]
	private ParticleSystem particle_LassoRing_UpgradeA;

	[SerializeField]
	private ParticleSystem particle_BreakConnectionExplosion_UpgradeA;

	[SerializeField]
	private eTowerState towerState;

	private float connectedTime;

	private float upgradeBTimer;

	private float upgradeBDamageMultiplier;

	private AMonsterBase lastUpgradeBTarget;

	private int accumulatedDamage;

	private Coroutine cr_ConnectEffect;

	private Vector3 lastHitPosition;

	private void Start()
	{
	}

	protected override void SwitchToPlacementModeProc()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnProc_003Ed__20))]
	private IEnumerator SpawnProc()
	{
		return null;
	}

	private void SwitchState(eTowerState newState)
	{
	}

	public override void TowerStunProc()
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	private void LateUpdate()
	{
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	protected override void ShootProc()
	{
	}

	private Vector3 GetTargetBindPosition()
	{
		return default(Vector3);
	}

	[IteratorStateMachine(typeof(_003CCR_ConnectEffect_003Ed__33))]
	private IEnumerator CR_ConnectEffect()
	{
		return null;
	}

	private void UpdateLinePosition()
	{
	}
}
