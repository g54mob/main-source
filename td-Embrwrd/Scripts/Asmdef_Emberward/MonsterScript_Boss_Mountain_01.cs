using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class MonsterScript_Boss_Mountain_01 : ABossStageScript
{
	[Serializable]
	public class WaveSizeSetting
	{
		[FormerlySerializedAs("small")]
		public int smallMonsterCount;

		[FormerlySerializedAs("medium")]
		public int mediumMonsterCount;

		[FormerlySerializedAs("large")]
		public int largeMonsterCount;
	}

	[Serializable]
	public class WaveMonsterCombination
	{
		public int minRoundLimit;

		public int maxRoundLimit;

		public List<eMonsterType> eMonsterType;
	}

	[Serializable]
	private class SmallSpawnPointSet
	{
		public Transform start;

		public Transform end;

		public List<Vector3> GetPoints(int count)
		{
			return null;
		}
	}

	public enum eState
	{
		IDLE = 0,
		MOVE = 1,
		ATTACK = 2
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass65_0
	{
		public UI_ChooseSkeletonKingPerk_Popup ui_ChooseRoguelitePerk_Popup;

		internal bool _003CCR_ChoosePerks_003Eb__0()
		{
			return false;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass69_0
	{
		public bool isTutorialFinished;

		internal void _003CCR_Intro_003Eb__0()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_ChoosePerks_003Ed__65 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Mountain_01 _003C_003E4__this;

		public bool isHardMode;

		private _003C_003Ec__DisplayClass65_0 _003C_003E8__1;

		private int _003CshowRoundInterval_003E5__2;

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
		public _003CCR_ChoosePerks_003Ed__65(int _003C_003E1__state)
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
	private sealed class _003CCR_DelayedMonsterStartMoving_003Ed__64 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public AMonsterBase monster;

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
		public _003CCR_DelayedMonsterStartMoving_003Ed__64(int _003C_003E1__state)
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
	private sealed class _003CCR_Intro_003Ed__69 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Mountain_01 _003C_003E4__this;

		private _003C_003Ec__DisplayClass69_0 _003C_003E8__1;

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
		public _003CCR_Intro_003Ed__69(int _003C_003E1__state)
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
	private sealed class _003CCR_LerpCamera_003Ed__70 : IEnumerator<object>, IEnumerator, IDisposable
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
		public _003CCR_LerpCamera_003Ed__70(int _003C_003E1__state)
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
	private sealed class _003CCR_Outro_003Ed__72 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Mountain_01 _003C_003E4__this;

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
		public _003CCR_Outro_003Ed__72(int _003C_003E1__state)
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
	private sealed class _003CCR_Outro_Alt_003Ed__74 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Mountain_01 _003C_003E4__this;

		private UI_CinematicBorder _003Cui_CinematicBorder_003E5__2;

		private int _003Ci_003E5__3;

		private List<AMonsterBase>.Enumerator _003C_003E7__wrap3;

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
		public _003CCR_Outro_Alt_003Ed__74(int _003C_003E1__state)
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

		private void _003C_003Em__Finally1()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CCR_Outro_Normal_003Ed__73 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Mountain_01 _003C_003E4__this;

		private UI_CinematicBorder _003Cui_CinematicBorder_003E5__2;

		private Vector3 _003CtargetPos_003E5__3;

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
		public _003CCR_Outro_Normal_003Ed__73(int _003C_003E1__state)
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
	private sealed class _003CCR_Round_AttackPlayer_003Ed__71 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Mountain_01 _003C_003E4__this;

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
		public _003CCR_Round_AttackPlayer_003Ed__71(int _003C_003E1__state)
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
	private sealed class _003CCR_SendOutMonsters_003Ed__63 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Mountain_01 _003C_003E4__this;

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
		public _003CCR_SendOutMonsters_003Ed__63(int _003C_003E1__state)
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
	private sealed class _003CCR_SummonBorderIceWalls_003Ed__59 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Mountain_01 _003C_003E4__this;

		private float _003CmaxRange_003E5__2;

		private float _003Cduration_003E5__3;

		private float _003Ctime_003E5__4;

		private List<Transform> _003Clist_IceWallBlocks_003E5__5;

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
		public _003CCR_SummonBorderIceWalls_003Ed__59(int _003C_003E1__state)
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
	private sealed class _003CCR_SummonMonsters_003Ed__56 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Mountain_01 _003C_003E4__this;

		public UI_CinematicBorder inheritaeCinematicBorder;

		public int round;

		public bool isFinalRound;

		private UI_CinematicBorder _003Cui_CinematicBorder_003E5__2;

		private WaveMonsterData _003CnextWaveData_003E5__3;

		private int _003CsetCount_003E5__4;

		private int _003Ci_003E5__5;

		private List<Vector3> _003Clist_TrapPositions_003E5__6;

		private int _003Ci_003E5__7;

		private GameObject _003Ctrap_003E5__8;

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
		public _003CCR_SummonMonsters_003Ed__56(int _003C_003E1__state)
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
	private sealed class _003CCR_UnsummonBorderIceWalls_003Ed__60 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MonsterScript_Boss_Mountain_01 _003C_003E4__this;

		private float _003Cduration_003E5__2;

		private float _003Ctime_003E5__3;

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
		public _003CCR_UnsummonBorderIceWalls_003Ed__60(int _003C_003E1__state)
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
	private Transform bossMonsterHandNode;

	[SerializeField]
	private float moveSpeed;

	[SerializeField]
	private float attackRange;

	[SerializeField]
	private Material mat_SoulMonster;

	[SerializeField]
	private eState state;

	[SerializeField]
	private Monster_Boss_03 monster_boss;

	[SerializeField]
	private Transform node_SpawnPoint_Boss;

	[SerializeField]
	private List<Transform> list_SpawnPoints_AltBoss;

	[SerializeField]
	private List<Transform> list_SpawnPoints_Large;

	[SerializeField]
	private List<Transform> list_SpawnPoints_Medium;

	[SerializeField]
	private List<SmallSpawnPointSet> list_SpawnPointSets_Small;

	[SerializeField]
	private List<Transform> list_BorderIceWallBlocks;

	[SerializeField]
	[Header("白色格子的魔法陷阱位置 (排除火源和石柱的位置)")]
	private List<Transform> list_WhiteMagicTrapPositions;

	[SerializeField]
	[Header("黑色格子的魔法陷阱位置 (排除火源和石柱的位置)")]
	private List<Transform> list_BlackMagicTrapPositions;

	[Header("所有白色格子位置 (for成就)")]
	[SerializeField]
	private List<Transform> list_WhiteFloorPositions;

	[SerializeField]
	[Header("所有黑色格子位置 (for成就)")]
	private List<Transform> list_BlackFloorPositions;

	[SerializeField]
	private GameObject prefab_SkeletonKingTrap_Freeze;

	[SerializeField]
	private GameObject prefab_SkeletonKingTrap_Lava;

	[SerializeField]
	private Animator animator_GateDoor;

	[SerializeField]
	private List<WaveSizeSetting> list_WaveSizeSettings;

	[SerializeField]
	private List<WaveMonsterCombination> list_WaveMonsterCombination;

	[SerializeField]
	private List<Transform> list_TrapNodes;

	[SerializeField]
	private List<GameObject> list_Traps;

	private int skeletonKingGiftCount;

	private List<eItemType> list_SkeletonKingGift_Buff;

	private List<eItemType> list_SelectedBuff;

	private List<eItemType> list_SkeletonKingGift_Curse;

	private List<eItemType> list_SelectedCurse;

	private List<Obj_SkeletonKingTrap> list_ActivatedMagicTraps;

	private List<Obj_MagicWindArea> list_MagicWindAreas_Activated;

	private GameSceneReferenceHandler gameSceneReferenceHandler;

	private Coroutine currentBossActionCoroutine;

	private int curWaveIndex;

	private int totalWaveCount;

	private int roundIndex;

	private List<Monster_Boss_03.eDialogKey> list_UsedKeys;

	private Vector3 cameraOriginOffset;

	private List<AMonsterBase> list_SpawnedMonsters;

	private Vector3 fireSourcePos;

	private bool isHiddenWaveUsed;

	private int killedMonsterCountThisWave;

	private float spawnMonsterInterval;

	private float spawnMonsterTimer;

	private void OnValidate()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnPlayerVictory()
	{
	}

	private bool IsOnWhiteFloor(Vector3 position)
	{
		return false;
	}

	private void OnInitializeEnvSceneBindings(GameSceneReferenceHandler refHandler)
	{
	}

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnRoundStart(int round, int totalRound)
	{
	}

	private WaveMonsterData CreateNextWave(int round)
	{
		return null;
	}

	private Monster_Boss_03.eDialogKey GetBossSummonDialog(WaveMonsterData data)
	{
		return default(Monster_Boss_03.eDialogKey);
	}

	private bool HasMonster(params eMonsterType[] monsterTypes)
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003CCR_SummonMonsters_003Ed__56))]
	private IEnumerator CR_SummonMonsters(int round, bool isFinalRound, UI_CinematicBorder inheritaeCinematicBorder = null)
	{
		return null;
	}

	private void CreateSoulMonsterSummonEffect(Vector3 targetPos, eMonsterType monsterType, Action<eMonsterType, Vector3> callback)
	{
	}

	private void SoulEffectCallback(eMonsterType monsterType, Vector3 position)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SummonBorderIceWalls_003Ed__59))]
	private IEnumerator CR_SummonBorderIceWalls()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_UnsummonBorderIceWalls_003Ed__60))]
	private IEnumerator CR_UnsummonBorderIceWalls()
	{
		return null;
	}

	private void OnBattleStart()
	{
	}

	[IteratorStateMachine(typeof(_003CCR_SendOutMonsters_003Ed__63))]
	private IEnumerator CR_SendOutMonsters()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_DelayedMonsterStartMoving_003Ed__64))]
	private IEnumerator CR_DelayedMonsterStartMoving(AMonsterBase monster, float delay)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_ChoosePerks_003Ed__65))]
	private IEnumerator CR_ChoosePerks(bool isHardMode)
	{
		return null;
	}

	private void OnPerkSelected(eItemType buffType, eItemType debuffType)
	{
	}

	private void OnBattleEnd()
	{
	}

	private void OnMonsterKilled(AMonsterBase monster)
	{
	}

	[IteratorStateMachine(typeof(_003CCR_Intro_003Ed__69))]
	public override IEnumerator CR_Intro()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_LerpCamera_003Ed__70))]
	private IEnumerator CR_LerpCamera(Vector3 startPos, Vector3 targetPos, float startFOV, float targetFOV, float duration, Easing.Type easingType)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_Round_AttackPlayer_003Ed__71))]
	private IEnumerator CR_Round_AttackPlayer()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_Outro_003Ed__72))]
	public override IEnumerator CR_Outro()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_Outro_Normal_003Ed__73))]
	public IEnumerator CR_Outro_Normal()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCR_Outro_Alt_003Ed__74))]
	public IEnumerator CR_Outro_Alt()
	{
		return null;
	}

	private void TriggerAnimation(string key)
	{
	}

	private void Update()
	{
	}

	private void TriggerBossAnimation(string key)
	{
	}
}
