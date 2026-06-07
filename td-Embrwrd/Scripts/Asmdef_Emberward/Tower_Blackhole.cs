using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Blackhole : ABaseTower
{
	[CompilerGenerated]
	private sealed class _003CSpawnProc_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Blackhole _003C_003E4__this;

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
		public _003CSpawnProc_003Ed__8(int _003C_003E1__state)
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
	private List<Collider> list_CollisionColliders;

	[Header("放置時的煙霧特效")]
	[SerializeField]
	protected ParticleSystem particle_PlacementCloud;

	[SerializeField]
	private GameObject node_BlackholeEnergy;

	private Vector3 headModelForward;

	private void Start()
	{
	}

	public override List<Collider> GetCollisionColliders()
	{
		return null;
	}

	protected override void CannonUpdateProc()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnProc_003Ed__8))]
	private IEnumerator SpawnProc()
	{
		return null;
	}

	protected override void ShootProc()
	{
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	protected override TowerStats AddBuffMultiplier_Prepass(TowerStats buffStat)
	{
		return null;
	}
}
