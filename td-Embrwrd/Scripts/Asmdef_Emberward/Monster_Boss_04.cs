using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Monster_Boss_04 : Monster_Basic
{
	public enum eDialogKey
	{
		INTRO_1 = 0,
		INTRO_2 = 1,
		INTRO_3 = 2,
		INTRO_4 = 3,
		INTRO_5 = 4,
		INTRO_6 = 5,
		INTRO_ANCIENT_1 = 6,
		INTRO_ANCIENT_2 = 7,
		INTRO_ANCIENT_3 = 8,
		INTRO_OTHER_1 = 9,
		INTRO_DEMON_1 = 10,
		INTRO_DEMON_2 = 11,
		INTRO_FROST_1 = 12,
		INTRO_FROST_2 = 13,
		INTRO_CANDLE_1 = 14,
		INTRO_CANDLE_2 = 15,
		INTRO_HOLY_1 = 16,
		INTRO_HOLY_2 = 17,
		INTRO_BLAZE_1 = 18,
		INTRO_BLAZE_2 = 19,
		INTRO_MEAT_1 = 20,
		INTRO_MEAT_2 = 21,
		DEFEAT = 22
	}

	[CompilerGenerated]
	private sealed class _003CCR_WalkToPlayer_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Monster_Boss_04 _003C_003E4__this;

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

		public Monster_Boss_04 _003C_003E4__this;

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

	private bool isPathAvailiableCheckOn;

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

	public void StartPathAviliableCheck()
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

	public void ShowDialog(float delay, eDialogKey dialogKey, float duration, bool doShake, string colorKey = "FFFFFF")
	{
	}

	protected override void OnMouseEnter()
	{
	}

	protected override void OnMouseExit()
	{
	}
}
