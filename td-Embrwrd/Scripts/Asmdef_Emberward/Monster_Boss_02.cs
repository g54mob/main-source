using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster_Boss_02 : Monster_Basic
{
	[Serializable]
	public class ArmorParts
	{
		public List<Transform> parts;
	}

	public enum eDialogKey
	{
		INTRO = 0,
		AGGRO = 1,
		DEFEAT = 2
	}

	[CompilerGenerated]
	private sealed class _003CCR_WalkToPlayer_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_Boss_02 _003C_003E4__this;

		private Obj_FireSource _003CflameSource_003E5__2;

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
		public _003CCR_WalkToPlayer_003Ed__16(int _003C_003E1__state)
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
	private sealed class _003CDeathProc_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_Boss_02 _003C_003E4__this;

		public int damage;

		public bool isKilled;

		public bool playAnimation;

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
		public _003CDeathProc_003Ed__11(int _003C_003E1__state)
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
	private ParticleSystem particle_CannonHit;

	[SerializeField]
	private List<ArmorParts> list_ArmorParts;

	private int cannonHitCount;

	private Coroutine cr_WalkToPlayer;

	private void Start()
	{
	}

	public override void Spawn(MonsterSpawner spawner, bool isCorrupted)
	{
	}

	public override void Hit(int damage, float baseCritChance, eDamageType damageType, ABaseTower tower, bool hideDamageNumber = false, bool doTriggerHitReaction = true)
	{
	}

	public override void Hit(int damage, eDamageType damageType, Action<AMonsterBase> OnKillCallback = null, ABaseTower fromTower = null, bool hideDamageNumber = false, bool doTriggerHitReaction = true, float baseCritChance = 0f)
	{
	}

	protected override void HitProc(int damage, eDamageType damageType, bool doTriggerHitReaction, bool isFromTower)
	{
	}

	protected override void SpawnProc()
	{
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	[IteratorStateMachine(typeof(_003CDeathProc_003Ed__11))]
	protected override IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true)
	{
		return null;
	}

	protected override void ReachEndOfPathProc()
	{
	}

	public void StartWalkToPlayer()
	{
	}

	public void StopWalkToPlayer()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_WalkToPlayer_003Ed__16))]
	private IEnumerator CR_WalkToPlayer()
	{
		return null;
	}

	public void HitBack(Vector3 target)
	{
	}

	public void ShowDialog(float delay, eDialogKey dialogKey)
	{
	}

	protected override void OnMouseEnter()
	{
	}

	protected override void OnMouseExit()
	{
	}
}
