using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Scythe : ABaseTower
{
	[CompilerGenerated]
	private sealed class _003CCR_ShootProc_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Scythe _003C_003E4__this;

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
		public _003CCR_ShootProc_003Ed__17(int _003C_003E1__state)
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

		public Tower_Scythe _003C_003E4__this;

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
	private Transform node_AttackCenter;

	[SerializeField]
	private List<Collider> list_AdditionalColliders;

	[SerializeField]
	[Header("放置時的煙霧特效")]
	protected ParticleSystem particle_PlacementCloud;

	[SerializeField]
	private ParticleSystem particle_HitMonster;

	[SerializeField]
	private ParticleSystem particle_AttackEffect_Normal;

	[SerializeField]
	private ParticleSystem particle_AttackEffect_UpgradeB;

	[SerializeField]
	private GameObject node_Particle_PurpleGlow;

	[SerializeField]
	private GameObject node_Particle_BlueGlow;

	private Vector3 headModelForward;

	private ParticleSystem particle_AttackEffect;

	protected override void CannonUpdateProc()
	{
	}

	protected override void SwitchToPlacementModeProc()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnProc_003Ed__13))]
	private IEnumerator SpawnProc()
	{
		return null;
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	protected override void ShootProc()
	{
	}

	private int CalculateTotalDamage(AMonsterBase monster)
	{
		return 0;
	}

	[IteratorStateMachine(typeof(_003CCR_ShootProc_003Ed__17))]
	private IEnumerator CR_ShootProc()
	{
		return null;
	}

	public override Vector3 GetTowerAttackCenter()
	{
		return default(Vector3);
	}
}
