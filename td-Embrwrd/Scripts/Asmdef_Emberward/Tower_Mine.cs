using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Mine : ABaseTower
{
	[CompilerGenerated]
	private sealed class _003CSpawnProc_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Mine _003C_003E4__this;

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
		public _003CSpawnProc_003Ed__22(int _003C_003E1__state)
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

	[SerializeField]
	[Header("放置時的煙霧特效")]
	private ParticleSystem particle_PlacementCloud;

	[SerializeField]
	private int maxMineCount;

	[SerializeField]
	private float mineSpawnIntervalMultiplier_PrepPhase;

	[SerializeField]
	private float mineSpawnIntervalMultiplier_BattlePhase;

	[SerializeField]
	private GameObject prefab_Mine;

	[SerializeField]
	private Transform node_GachaMines;

	[SerializeField]
	private List<Transform> list_GachaMines;

	private Vector3 headModelForward;

	private List<Obj_TowerMine> list_Mines;

	private static List<Vector3Int> list_MinePositions;

	private float mineSpawnTimer;

	public override List<Collider> GetCollisionColliders()
	{
		return null;
	}

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnRoundEnd()
	{
	}

	private void OnTetrisPlaced(Obj_TetrisBlock block)
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	protected override void CannonDespawnProc()
	{
	}

	private void CreateMine()
	{
	}

	private void OnMineRemoved(Obj_TowerMine mine)
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	[IteratorStateMachine(typeof(_003CSpawnProc_003Ed__22))]
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
}
