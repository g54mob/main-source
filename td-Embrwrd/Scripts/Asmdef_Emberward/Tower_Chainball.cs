using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Chainball : ADirectionalTower
{
	[CompilerGenerated]
	private sealed class _003CCR_Shoot_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Chainball _003C_003E4__this;

		private Vector3 _003CtargetPosition_003E5__2;

		private int _003Cdamage_003E5__3;

		private HashSet<AMonsterBase> _003Chash_AttackedMonster_003E5__4;

		private float _003Ctime_003E5__5;

		private float _003Cduration_003E5__6;

		private bool _003CisHitTarget_003E5__7;

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
		public _003CCR_Shoot_003Ed__20(int _003C_003E1__state)
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
	private LineRenderer lineRenderer_Chain;

	[SerializeField]
	private Transform node_Cogs;

	[SerializeField]
	private Transform node_Chainball;

	[SerializeField]
	private Transform node_ChainBallStartPosition;

	[SerializeField]
	private ParticleSystem particle_Hit;

	[SerializeField]
	private ParticleSystem particle_UpgradeA;

	[SerializeField]
	private ParticleSystem particle_UpgradeA_ChainBall;

	[SerializeField]
	private float chainFlySpeed;

	private List<AMonsterBase> list_MonstersInArea;

	private float updateTargetInterval;

	private float updateTargetTimer;

	private Vector3Int lastChainballPosition;

	private bool isShooting;

	private bool isChainBallGoingForward;

	protected override void SwitchToPlacementModeProc()
	{
	}

	protected override void CannonSpawnProc()
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

	private void UpdateLineRenderer(Vector3 targetPos)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Shoot_003Ed__20))]
	private IEnumerator CR_Shoot()
	{
		return null;
	}
}
