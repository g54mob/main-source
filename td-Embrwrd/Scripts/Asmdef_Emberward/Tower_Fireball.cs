using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Fireball : ABaseTower
{
	[CompilerGenerated]
	private sealed class _003CSpawnProc_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Fireball _003C_003E4__this;

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

	[SerializeField]
	private List<Collider> list_AdditionalColliders;

	[SerializeField]
	[Header("放置時的煙霧特效")]
	protected ParticleSystem particle_PlacementCloud;

	[SerializeField]
	[Header("升級A子彈Prefab")]
	private GameObject prefab_UpgradeA_Bullet;

	[Header("升級A額外模型")]
	[SerializeField]
	private GameObject node_UpgradeA_ExtraPart;

	private Vector3 headModelForward;

	private void Start()
	{
	}

	protected override void SwitchToPlacementModeProc()
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	private void UpdateRotation()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnProc_003Ed__11))]
	private IEnumerator SpawnProc()
	{
		return null;
	}

	protected override void ShootProc()
	{
	}
}
