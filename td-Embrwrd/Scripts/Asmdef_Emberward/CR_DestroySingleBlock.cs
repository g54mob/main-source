using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CR_DestroySingleBlock : ABaseTower
{
	private class MonsterTriggerEntry
	{
		public AMonsterBase monster;

		public float triggerTime;
	}

	[CompilerGenerated]
	private sealed class _003CCR_DestroyBlock_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CR_DestroySingleBlock _003C_003E4__this;

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
		public _003CCR_DestroyBlock_003Ed__19(int _003C_003E1__state)
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
	private ParticleSystem particle_Destroy;

	[SerializeField]
	private ParticleSystem particle_Error;

	[SerializeField]
	private ParticleSystem particle_DrillBlock;

	[SerializeField]
	private ParticleSystem particle_BreakBlock;

	[SerializeField]
	private int roundSincePlacement;

	private bool hasBlock;

	private Color blockColor;

	private float animationInterval;

	private float animationTimer;

	private List<string> list_PrefabNames;

	private float upgradeBTimer;

	protected override void OnEnableProc()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	private void Update()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnRoundEnd()
	{
	}

	protected override void CannonUpgradeProc()
	{
	}

	public void ImmediateDrill()
	{
	}

	private void DestroyBlock()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_DestroyBlock_003Ed__19))]
	private IEnumerator CR_DestroyBlock()
	{
		return null;
	}

	private void DestroySingleBlock(Obj_TetrisBlock block, Vector3 destroyPosition, bool doImmediatelyRecalcPath)
	{
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	protected override void CannonDespawnProc()
	{
	}

	protected override void ShootProc()
	{
	}
}
