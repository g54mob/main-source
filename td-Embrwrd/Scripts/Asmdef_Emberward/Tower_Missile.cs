using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Missile : ABaseTower
{
	[CompilerGenerated]
	private sealed class _003CCR_Shoot_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public List<AMonsterBase> targets;

		public Tower_Missile _003C_003E4__this;

		private List<AMonsterBase>.Enumerator _003C_003E7__wrap1;

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
		public _003CCR_Shoot_003Ed__14(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CSpawnProc_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Missile _003C_003E4__this;

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
		public _003CSpawnProc_003Ed__11(int _003C_003E1__state)
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
	private Transform node_SecondShootPosition;

	[SerializeField]
	private ParticleSystem particle_Shoot_1;

	[SerializeField]
	private ParticleSystem particle_Shoot_2;

	[SerializeField]
	[Header("放置時的煙霧特效")]
	protected ParticleSystem particle_PlacementCloud;

	[SerializeField]
	[Header("升級A: 飛彈Prefab")]
	private GameObject prefab_Bullet_UpgradeA;

	[SerializeField]
	[Header("升級B: 飛彈Prefab")]
	private GameObject prefab_Bullet_UpgradeB;

	private int bulletShootCount;

	private AMonsterBase firstTargetInLastShoot;

	private List<AMonsterBase> targets;

	private void Start()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnProc_003Ed__11))]
	private IEnumerator SpawnProc()
	{
		return null;
	}

	protected override void CannonUpdateProc()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Shoot_003Ed__14))]
	private IEnumerator CR_Shoot(List<AMonsterBase> targets)
	{
		return null;
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	protected override void ShootProc()
	{
	}

	protected void CreateBullet()
	{
	}
}
