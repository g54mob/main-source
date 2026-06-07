using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class Obj_SealedIceBlock : AMonsterBase
{
	[CompilerGenerated]
	private sealed class _003CDeathProc_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Obj_SealedIceBlock _003C_003E4__this;

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
		public _003CDeathProc_003Ed__10(int _003C_003E1__state)
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
	private GameObject node_IceBlockModel;

	[SerializeField]
	private GameObject node_ChestModel;

	[SerializeField]
	private ParticleSystem particle_Destroy;

	[SerializeField]
	private Collider pathobstacle_Collider;

	private Tweener tween;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void Start()
	{
	}

	public override void Spawn(MonsterSpawner spawner, bool isCorrupted)
	{
	}

	protected override void HitProc(int damage, eDamageType damageType, bool doTriggerHitReaction, bool isFromTower)
	{
	}

	[IteratorStateMachine(typeof(_003CDeathProc_003Ed__10))]
	protected override IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true)
	{
		return null;
	}

	protected override void OnMouseEnterProc()
	{
	}

	private void ShowTooltip()
	{
	}

	protected override void OnMouseExitProc()
	{
	}

	public override float GetRemainingDistance()
	{
		return 0f;
	}

	protected override void SpawnProc()
	{
	}

	protected override void DespawnProc()
	{
	}

	protected override void UpdateProc(float deltaTime)
	{
	}
}
