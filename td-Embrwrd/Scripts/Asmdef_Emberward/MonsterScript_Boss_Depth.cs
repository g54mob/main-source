using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class MonsterScript_Boss_Depth : ABossStageScript
{
	public enum eState
	{
		IDLE = 0,
		MOVE = 1,
		ATTACK = 2
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass28_0
	{
		public bool isTutorialFinished;

		internal void _003CCR_Intro_003Eb__0()
		{
		}

		internal void _003CCR_Intro_003Eb__1()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_BossHammerEffct_003Ed__36 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Depth _003C_003E4__this;

		public int count;

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
		public _003CCR_BossHammerEffct_003Ed__36(int _003C_003E1__state)
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
	private sealed class _003CCR_BossIntroAnim_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Depth _003C_003E4__this;

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
		public _003CCR_BossIntroAnim_003Ed__32(int _003C_003E1__state)
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
	private sealed class _003CCR_Intro_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Depth _003C_003E4__this;

		private _003C_003Ec__DisplayClass28_0 _003C_003E8__1;

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
		public _003CCR_Intro_003Ed__28(int _003C_003E1__state)
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
	private sealed class _003CCR_LerpCamera_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Easing.Type easingType;

		public float duration;

		public Vector3 startPos;

		public Vector3 targetPos;

		public float startFOV;

		public float targetFOV;

		private float _003Ctime_003E5__2;

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
		public _003CCR_LerpCamera_003Ed__29(int _003C_003E1__state)
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
	private sealed class _003CCR_Outro_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CCR_Outro_003Ed__41(int _003C_003E1__state)
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
	private sealed class _003CCR_Round_AttackPlayer_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Depth _003C_003E4__this;

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
		public _003CCR_Round_AttackPlayer_003Ed__33(int _003C_003E1__state)
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
	private sealed class _003CCR_Round_AttackTower_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Depth _003C_003E4__this;

		public int round;

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
		public _003CCR_Round_AttackTower_003Ed__35(int _003C_003E1__state)
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
	private sealed class _003CCR_SpawnAncientTower_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public int round;

		public MonsterScript_Boss_Depth _003C_003E4__this;

		private List<Obj_TetrisBlock> _003Clist_Tetris_003E5__2;

		private int _003CbasicTowerCount_003E5__3;

		private List<Vector3> _003Clist_CreatedTowerPos_003E5__4;

		private int _003Ci_003E5__5;

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
		public _003CCR_SpawnAncientTower_003Ed__26(int _003C_003E1__state)
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
	private List<Obj_AncientTower_Base> list_AncientTowers;

	[SerializeField]
	private float moveSpeed;

	[SerializeField]
	private float attackRange;

	[SerializeField]
	private GameObject obj_AnvilObjects;

	[SerializeField]
	private List<Obj_Chest> list_StartingChests;

	[SerializeField]
	private List<Obj_AncientMech_Base> list_WeatherMechs;

	[SerializeField]
	private List<Obj_AncientMech_Base> list_AllAncientMechs;

	[SerializeField]
	private GameObject prefab_BasicAncientTower;

	[SerializeField]
	private GameObject prefab_SniperAncientTower;

	[SerializeField]
	private eState state;

	private Monster_Boss_04 monster_boss;

	private Vector3 anvilObjOriginPos;

	private quaternion anvilObjOriginRot;

	private bool isActivatedAnyWeatherMech;

	private bool isAnyAncientTowerActivated;

	private int currentConnected;

	private Coroutine currentBossActionCoroutine;

	private Coroutine bossIntroCoroutine;

	private bool skipIntro;

	private eEmberType emberType;

	private float hammerTimer;

	private float burningSignalSendTimer;

	private float burningSignalSendInterval;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnAncientTowerActivated(Obj_AncientTower_Base @base)
	{
	}

	private void OnPlayerVictory()
	{
	}

	private void OnAncientCircuitUpdated(List<Obj_ElectricCircuit.ElectricCircuitNode> list_Nodes, List<Obj_AncientMech_Base> list_AncientMechs)
	{
	}

	protected override void Awake()
	{
	}

	private void OnRoundStart(int round, int totalRound)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SpawnAncientTower_003Ed__26))]
	private IEnumerator CR_SpawnAncientTower(int round)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_Intro_003Ed__28))]
	public override IEnumerator CR_Intro()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_LerpCamera_003Ed__29))]
	private IEnumerator CR_LerpCamera(Vector3 startPos, Vector3 targetPos, float startFOV, float targetFOV, float duration, Easing.Type easingType)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_BossIntroAnim_003Ed__32))]
	public IEnumerator CR_BossIntroAnim()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_Round_AttackPlayer_003Ed__33))]
	private IEnumerator CR_Round_AttackPlayer()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_Round_AttackTower_003Ed__35))]
	private IEnumerator CR_Round_AttackTower(int round)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_BossHammerEffct_003Ed__36))]
	private IEnumerator CR_BossHammerEffct(int count)
	{
		return null;
	}

	private void Update()
	{
	}

	private void TriggerAnimation(string key)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Outro_003Ed__41))]
	public override IEnumerator CR_Outro()
	{
		return null;
	}
}
