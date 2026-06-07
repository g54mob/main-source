using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tower_Lava : ABaseTower
{
	[CompilerGenerated]
	private sealed class _003CCR_CreateLavaProc_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public bool doInitialDelay;

		public Tower_Lava _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003CCR_CreateLavaProc_003Ed__28(int _003C_003E1__state)
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
	private sealed class _003CCR_ExpandLavaProc_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Lava _003C_003E4__this;

		public int count;

		private List<Vector3> _003Clist_ExpandableNodes_003E5__2;

		private int _003Ci_003E5__3;

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
		public _003CCR_ExpandLavaProc_003Ed__29(int _003C_003E1__state)
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
	private sealed class _003CCR_SpawnProc_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tower_Lava _003C_003E4__this;

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
		public _003CCR_SpawnProc_003Ed__25(int _003C_003E1__state)
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
	private ParticleSystem particle_Lava;

	[SerializeField]
	private Obj_LavaGround prefab_LavaGround;

	[SerializeField]
	private List<Transform> list_DefaultLavaNodes;

	private int maxLavaGroundCount;

	private int maxLavaGroundCount_UpgradeA;

	private List<Obj_LavaGround> list_CreatedLavaObject;

	private List<Vector3> list_LavaNodes;

	private float lavaDurationIncreaseInterval;

	private float lavaDurationIncreaseTimer;

	private float spawnLavaInterval;

	private float spawnLavaTimer;

	private bool wasStunned;

	private Coroutine coroutine_CreateLava;

	private Vector3[] dirs;

	protected override void CannonUpdateProc()
	{
	}

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnTowerRemoved(ABaseTower tower)
	{
	}

	private void OnGridObjectChanged(GameObject gameObject)
	{
	}

	private void OnTetrisPlaced(Obj_TetrisBlock block)
	{
	}

	public override void TowerStunProc()
	{
	}

	public override void TowerDormantEndProc()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	protected override void CannonDespawnProc()
	{
	}

	protected int CheckLavaConnectivity()
	{
		return 0;
	}

	protected void CalculateLavaNodes()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SpawnProc_003Ed__25))]
	private IEnumerator CR_SpawnProc()
	{
		return null;
	}

	private void CreateLava(bool doInitialDelay = true)
	{
	}

	private bool IsOnMineCart()
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CCR_CreateLavaProc_003Ed__28))]
	private IEnumerator CR_CreateLavaProc(bool doInitialDelay = true)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_ExpandLavaProc_003Ed__29))]
	private IEnumerator CR_ExpandLavaProc(int count)
	{
		return null;
	}

	protected bool CheckIsPositionValid(Vector3 pos)
	{
		return false;
	}

	protected bool CheckIsPositionCanExpandLava(Vector3 pos)
	{
		return false;
	}

	protected override void ShootProc()
	{
	}

	protected override void CannonUpgradeProc()
	{
	}

	protected override void UpdateAfterMovedBySceneObjectsProc()
	{
	}

	protected void CreateLavaInFront()
	{
	}
}
