using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster_Boss_03 : Monster_Basic
{
	[Serializable]
	public class ArmorParts
	{
		public List<Transform> parts;
	}

	public enum eDialogKey
	{
		INTRO_1 = 0,
		INTRO_2 = 1,
		CHOOSE_ITEM_1 = 2,
		CHOOSE_ITEM_1_HARDMODE = 3,
		CHOOSE_ITEM_2 = 4,
		CHOOSE_ITEM_3 = 5,
		SUMMON_SPIDERS = 6,
		SUMMON_WOLF = 7,
		SUMMON_ORC = 8,
		SUMMON_ELEMENTAL = 9,
		SUMMON_SKELETON_ARMY = 10,
		SUMMON_BOSS_1 = 11,
		SUMMON_JOKE = 12,
		SUMMON_JOKE_2 = 13,
		SUMMON_WAIT_1 = 14,
		SUMMON_WAIT_2 = 15,
		SUMMON_WAIT_3 = 16,
		SUMMON_WAIT_FINAL = 17,
		SUMMON_ALT_END_1 = 18,
		SUMMON_ALT_END_2 = 19,
		SUMMON_ALT_END_3 = 20,
		SUMMON_ALT_END_4 = 21,
		SUMMON_ALT_END_5 = 22,
		SUMMON_ALT_END_6 = 23,
		DEFEAT_1 = 24,
		DEFEAT_2 = 25,
		DEFEAT_3 = 26,
		NONE = 27
	}

	[CompilerGenerated]
	private sealed class _003CCR_WalkToPlayer_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_Boss_03 _003C_003E4__this;

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
		public _003CCR_WalkToPlayer_003Ed__14(int _003C_003E1__state)
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
	private sealed class _003CDeathProc_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_Boss_03 _003C_003E4__this;

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
		public _003CDeathProc_003Ed__9(int _003C_003E1__state)
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

	private Coroutine cr_WalkToPlayer;

	private void Start()
	{
	}

	public void ForceUnregister()
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

	[IteratorStateMachine(typeof(_003CDeathProc_003Ed__9))]
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

	[IteratorStateMachine(typeof(_003CCR_WalkToPlayer_003Ed__14))]
	private IEnumerator CR_WalkToPlayer()
	{
		return null;
	}

	public void ShowDialog(float delay, float duration, eDialogKey dialogKey)
	{
	}

	protected override void OnMouseEnter()
	{
	}

	protected override void OnMouseExit()
	{
	}
}
