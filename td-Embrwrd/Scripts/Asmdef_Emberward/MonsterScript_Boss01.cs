using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MonsterScript_Boss01 : ABossStageScript
{
	public enum eState
	{
		IDLE = 0,
		MOVE = 1,
		ATTACK = 2
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public bool isTutorialFinished;

		internal void _003CCR_Intro_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_AttackPlayerTower_Fireball_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss01 _003C_003E4__this;

		private ABaseTower _003CtargetTower_003E5__2;

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
		public _003CCR_AttackPlayerTower_Fireball_003Ed__24(int _003C_003E1__state)
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
	private sealed class _003CCR_AttackPlayerTower_Flame_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss01 _003C_003E4__this;

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
		public _003CCR_AttackPlayerTower_Flame_003Ed__22(int _003C_003E1__state)
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
	private sealed class _003CCR_Intro_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		private _003C_003Ec__DisplayClass19_0 _003C_003E8__1;

		private UI_CinematicBorder _003Cui_CinematicBorder_003E5__2;

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
		public _003CCR_Intro_003Ed__19(int _003C_003E1__state)
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
	private sealed class _003CCR_Outro_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

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
		public _003CCR_Outro_003Ed__32(int _003C_003E1__state)
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
	private sealed class _003CCR_Round_AttackPlayer_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss01 _003C_003E4__this;

		private Obj_FireSource _003CflameSource_003E5__2;

		private float _003CextraSkillCooldown_003E5__3;

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
		public _003CCR_Round_AttackPlayer_003Ed__20(int _003C_003E1__state)
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
	private sealed class _003CCR_Round_AttackTower_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss01 _003C_003E4__this;

		public int round;

		private Tower_NPC_Arrow _003CtargetTower_003E5__2;

		private float _003CattackTimer_003E5__3;

		private float _003CattackInterval_003E5__4;

		private float _003CextraSkillCooldown_003E5__5;

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
		public _003CCR_Round_AttackTower_003Ed__21(int _003C_003E1__state)
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
	private Animator animator;

	[SerializeField]
	private List<Tower_NPC_Arrow> list_Towers;

	[SerializeField]
	private float moveSpeed;

	[SerializeField]
	private float attackRange;

	[SerializeField]
	private GameObject prefab_Fireball;

	[SerializeField]
	private Transform node_HeadBone;

	[SerializeField]
	private float extraSkillInterval;

	[SerializeField]
	private ParticleSystem particle_Skill2;

	[SerializeField]
	private GameObject node_HardModeExcludeWalls;

	[SerializeField]
	private eState state;

	private Monster_Boss_01 monster_boss;

	private int hardModeLevel;

	private Coroutine currentBossActionCoroutine;

	private bool isUsingExtraSkill;

	private float burningSignalSendTimer;

	private float burningSignalSendInterval;

	private float skill2DetectInterval;

	private float skill2DetectTimer;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnTetrisPlaced(Obj_TetrisBlock block)
	{
	}

	protected override void Awake()
	{
	}

	private void OnRoundStart(int round, int totalRound)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Intro_003Ed__19))]
	public override IEnumerator CR_Intro()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_Round_AttackPlayer_003Ed__20))]
	private IEnumerator CR_Round_AttackPlayer()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_Round_AttackTower_003Ed__21))]
	private IEnumerator CR_Round_AttackTower(int round)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_AttackPlayerTower_Flame_003Ed__22))]
	private IEnumerator CR_AttackPlayerTower_Flame()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_AttackPlayerTower_Fireball_003Ed__24))]
	private IEnumerator CR_AttackPlayerTower_Fireball()
	{
		return null;
	}

	private void Update()
	{
	}

	private void Skill2Effect_BlockToLava()
	{
	}

	private void TriggerAnimation(string key)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Outro_003Ed__32))]
	public override IEnumerator CR_Outro()
	{
		return null;
	}
}
