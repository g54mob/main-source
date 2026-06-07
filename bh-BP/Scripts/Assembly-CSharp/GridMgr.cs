using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMOD.Studio;
using MEC;
using Sirenix.OdinInspector;
using UnityEngine;

public class GridMgr : SerializedMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_AdvanceTactics_003Ed__88 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridMgr _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_AdvanceTactics_003Ed__88(int _003C_003E1__state)
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
	private sealed class _003C_DamagePieceRoutine_003Ed__75 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BallObj b;

		public GridPieceObj p;

		public GridMgr _003C_003E4__this;

		public Vector2 hitNormal;

		public Vector3 hitPos;

		public bool isBaby;

		public HeroInst h;

		public Vector2 hitAimDir;

		public bool isGhost;

		private HeroInst _003CbParent_003E5__2;

		private bool _003CbouncedOnAnyWall_003E5__3;

		private int _003CnumWallBounces_003E5__4;

		private bool _003ClastBounceOnWall_003E5__5;

		private int _003CnumBounces_003E5__6;

		private bool _003CbouncedOnBackWall_003E5__7;

		private bool _003CisOnFire_003E5__8;

		private DamageType _003CdmgType_003E5__9;

		private PassiveInst _003CpassiveSrc_003E5__10;

		private bool _003CisSideBall_003E5__11;

		private bool _003CshouldCancelDmg_003E5__12;

		private int _003CnumEnemyBounces_003E5__13;

		private StatusEffect _003CbleedEf_003E5__14;

		private int _003CpHealth_003E5__15;

		private int _003CbaseDmg_003E5__16;

		private float _003CtotalDmg_003E5__17;

		private int _003CfollowerBonusDmg_003E5__18;

		private float _003CnonWallBonusDmg_003E5__19;

		private float _003CnonBackBonusDmg_003E5__20;

		private float _003CpassiveWallBounceBonusDmg_003E5__21;

		private float _003CbounceDecayBonusDmg_003E5__22;

		private float _003CghostBonusDmg_003E5__23;

		private float _003CetherealBonusDmg_003E5__24;

		private float _003CsideGhostBonusDmg_003E5__25;

		private float _003ChatchetBonusDmg_003E5__26;

		private float _003CbounceBonusDmg_003E5__27;

		private float _003CbabyCountBonusDmg_003E5__28;

		private float _003CswordBreakerBonusDmg_003E5__29;

		private float _003ChammerBonusDmg_003E5__30;

		private float _003CnotCritChance_003E5__31;

		private float _003CbackStabCritChance_003E5__32;

		private float _003CfrontStabCritChance_003E5__33;

		private float _003CleftStabCritChance_003E5__34;

		private float _003CrightStabCritChance_003E5__35;

		private float _003CblindCritChance_003E5__36;

		private float _003CcolumnCritChance_003E5__37;

		private HitType _003ChitType_003E5__38;

		private float _003CcritBonusDamage_003E5__39;

		private int _003CextraCritBonusDmg_003E5__40;

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
		public _003C_DamagePieceRoutine_003Ed__75(int _003C_003E1__state)
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
	private sealed class _003C_IncreaseLevelProgress_003Ed__99 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float len;

		public int tgtProg;

		public int startProg;

		private float _003CcurTime_003E5__2;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_IncreaseLevelProgress_003Ed__99(int _003C_003E1__state)
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
	private sealed class _003C_InitGridOnLoad_003Ed__49 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridMgr _003C_003E4__this;

		private int _003Ci_003E5__2;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_InitGridOnLoad_003Ed__49(int _003C_003E1__state)
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
	private sealed class _003C_RunAdvance_003Ed__93 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridMgr _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private float _003CwaitLen_003E5__3;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_RunAdvance_003Ed__93(int _003C_003E1__state)
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
	private sealed class _003C_RunCloudClouds_003Ed__154 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridMgr _003C_003E4__this;

		private int _003CcloudDir_003E5__2;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_RunCloudClouds_003Ed__154(int _003C_003E1__state)
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
	private sealed class _003C_RunEnteringLvl_003Ed__51 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public bool isLoading;

		public GridMgr _003C_003E4__this;

		private float _003CstartTime_003E5__2;

		private Vector3 _003CplayerTgtPos_003E5__3;

		private Vector3 _003CplayerStartPos_003E5__4;

		private float _003CentryLen_003E5__5;

		private PlayerCharControllerFalconer _003Cfalconer_003E5__6;

		private Vector3 _003CfalconLeftStartPos_003E5__7;

		private Vector3 _003CfalconRightStartPos_003E5__8;

		private bool _003CstartedFalcon_003E5__9;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_RunEnteringLvl_003Ed__51(int _003C_003E1__state)
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
	private sealed class _003C_RunSavannaWind_003Ed__152 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridMgr _003C_003E4__this;

		private float _003CnextWindTime_003E5__2;

		private float _003CstartTime_003E5__3;

		private float _003CwindLen_003E5__4;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_RunSavannaWind_003Ed__152(int _003C_003E1__state)
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
	private sealed class _003C_RunTimeFreeze_003Ed__80 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridMgr _003C_003E4__this;

		public float len;

		private CoroutineHandle _003CfadeAnim_003E5__2;

		private float _003CstartTime_003E5__3;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_RunTimeFreeze_003Ed__80(int _003C_003E1__state)
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
	private sealed class _003C_RunTwitchEvent_003Ed__171 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridMgr _003C_003E4__this;

		public TwitchRandomEventType evType;

		private int _003CnumPotions_003E5__2;

		private float _003Clen_003E5__3;

		private int _003CbonusGold_003E5__4;

		private int _003CnumGoldDrops_003E5__5;

		private int _003CnumBabyBursts_003E5__6;

		private LevelWave _003Cwave_003E5__7;

		private int _003Ci_003E5__8;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_RunTwitchEvent_003Ed__171(int _003C_003E1__state)
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
	private sealed class _003C_SpawnWave_003Ed__123 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridMgr _003C_003E4__this;

		public LevelWave wave;

		public int y;

		private int _003CjustSpawnedStartIdx_003E5__2;

		private float _003CwaitLen_003E5__3;

		private float _003CstartTime_003E5__4;

		private int _003Ci_003E5__5;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_SpawnWave_003Ed__123(int _003C_003E1__state)
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
	private sealed class _003C_SpawnWaves_003Ed__122 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public GridMgr _003C_003E4__this;

		public List<LevelWave> waves;

		public int y;

		public int numWaves;

		private List<CoroutineHandle> _003Ccoroutines_003E5__2;

		private int _003Ci_003E5__3;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_SpawnWaves_003Ed__122(int _003C_003E1__state)
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
	private sealed class _003C_WaitForBattleSeconds_003Ed__133 : IEnumerator<float>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private float _003C_003E2__current;

		public float secs;

		private float _003CstartTime_003E5__2;

		float IEnumerator<float>.Current
		{
			[DebuggerHidden]
			get
			{
				return 0f;
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
		public _003C_WaitForBattleSeconds_003Ed__133(int _003C_003E1__state)
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

	public static GridMgr I;

	public const float kSpaceWidth = 1.125f;

	public const float kSpaceHeight = 1.125f;

	public static readonly Vector2 kSpaceSize;

	public static readonly Vector3 kSpaceSize3;

	public Dictionary<Collider2D, GridPieceObj> PieceColDict;

	public Dictionary<Collider2D, ObstacleObj> ObstacleColDict;

	private bool _isGeneratingWave;

	private bool _isSpawningWaves;

	private bool _isSpawningWave;

	private CoroutineHandle _curUpdateRoutine;

	private CoroutineHandle _curSpawnRoutine;

	private CoroutineHandle _curEnviroRoutine;

	private float _windXDir;

	public float OutOfBoundsTopY;

	public float OutOfBoundsLeftX;

	public float OutOfBoundsRightX;

	public float LeftBorderX;

	public float RightBorderX;

	public float TopBorderY;

	public float BottomBorderY;

	public float AttackY;

	public float FrontEnemyY;

	public int TopGridRow;

	public int BotGridRow;

	private float _scrollPos;

	private float _scrollSpeedMult;

	private bool _isSpawningPaused;

	private float _deltaScroll;

	public PartSys WindParts;

	public PartSys SnowParts;

	public PartSys ShroomParts;

	public DelegateUtl.NoArgsEvent OnTacticsStateChanged;

	private TurnBasedState _tacticsState;

	private CoroutineHandle _tacticsAnim;

	private List<GridPieceObj> _tacticsBlockers;

	private float _lastWaitLen;

	public System.Random LvlRnd;

	public System.Random MiscRnd;

	public ThreadSafeRandom MiscRndThreadSafe;

	private BattleSaveData _bSave;

	private MetaSaveData _mSave;

	public bool IsInited;

	private int _numAnims;

	private ContactFilter2D _filt;

	private bool _timeFrozen;

	private RangeViz _moveDistMarker;

	private const float kGrowLen = 3f;

	public List<LevelWave> _curWaves;

	public int _numWavesSpawning;

	private List<GridPieceInst> _justSpawned;

	public static readonly Vector3 kFakeLightOffset;

	public bool IsExpanding;

	public EventInstance _expansionSFX;

	private float _expandTimer;

	private int _expandPrevCols;

	private int _expandPrevRows;

	private int _numExpansions;

	private float _expandStartPlayerMaxY;

	private float _expandTgtPlayerMaxY;

	private Vector3 _expandStartCamPos;

	private Vector3 _expandTgtCamPos;

	private Vector3 _expandStartFakeLightPos;

	private int _rowsToGenerate;

	private const float kBombThickness = 0.5f;

	public const int kWallWrapLength = 4;

	private float _lastTwitchPollTime;

	private bool _isAwaitingTwitchPoll;

	[NonSerialized]
	public TwitchRandomEventType CurTwitchEvent;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void FixedUpdate()
	{
	}

	private void OnDestroy()
	{
	}

	[IteratorStateMachine(typeof(_003C_InitGridOnLoad_003Ed__49))]
	private IEnumerator<float> _InitGridOnLoad()
	{
		return null;
	}

	public void InitGrid(LoadMode loadMode)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunEnteringLvl_003Ed__51))]
	private IEnumerator<float> _RunEnteringLvl(bool isLoading)
	{
		return null;
	}

	public void RefreshBoardValues()
	{
	}

	public void RefreshBoardValuesExpansion(int prevRows, int prevCols, float pct)
	{
	}

	public Vector3 GetWorldPos(Vector2Int gridPos)
	{
		return default(Vector3);
	}

	public Vector3 GetWorldPos(float x, float y, float width = 1f, float height = 1f, float gridCols = -1f, float gridRows = -1f)
	{
		return default(Vector3);
	}

	public float GetWorldX(float x, float width = 1f, float gridCols = -1f)
	{
		return 0f;
	}

	public float GetWorldY(float y, float height = 1f, float gridRows = -1f)
	{
		return 0f;
	}

	public Vector2Int GetGridPosInt(Vector3 worldPos)
	{
		return default(Vector2Int);
	}

	public Vector2 GetGridPos(Vector3 worldPos)
	{
		return default(Vector2);
	}

	public bool HasPieceAtWorldPos(float x, float y, float w, float h)
	{
		return false;
	}

	public bool HasObjAtGridPos(float x, float y, float w, float h, int layerMask)
	{
		return false;
	}

	public bool HasPieceInWorldBounds(float minX, float minY, float maxX, float maxY)
	{
		return false;
	}

	public bool HasObjInWorldBounds(float minX, float minY, float maxX, float maxY, int layerMask)
	{
		return false;
	}

	public GridPieceObj CreatePiece(GridPieceInst p, bool isLoading)
	{
		return null;
	}

	public GridPieceObj GetClosestPiece(Vector3 pos)
	{
		return null;
	}

	public GridPieceObj GetClosestEnemy(Vector3 pos)
	{
		return null;
	}

	public void RemovePiece(GridPieceObj p, bool disable)
	{
	}

	public bool DamagePiece(GridPieceObj p, int amt, DamageType dt, BallObj ballSrc, HitEffectSrc src = HitEffectSrc.kAOE)
	{
		return false;
	}

	public bool DamagePiece(GridPieceObj p, int amt, DamageType dt, HeroInst h, bool isBaby, Vector3 pos, HitEffectSrc src = HitEffectSrc.kAOE)
	{
		return false;
	}

	public bool DamageCollider(Collider2D col, int amt, DamageType dt, BallObj ballSrc, HitEffectSrc src)
	{
		return false;
	}

	public bool DamageCollider(Collider2D col, int amt, DamageType dt, HeroInst h, bool isBaby, Vector3 pos, HitEffectSrc src)
	{
		return false;
	}

	public void ApplyHitEffects(GridPieceObj p, BallObj b, HitEffectSrc src)
	{
	}

	public void ApplyHitEffects(GridPieceObj p, HeroInst h, bool isBaby, Vector3 srcPos, HitEffectSrc src)
	{
	}

	public void DamagePiece(GridPieceObj p, BallObj b, Vector2 hitNormal, bool isGhost)
	{
	}

	[IteratorStateMachine(typeof(_003C_DamagePieceRoutine_003Ed__75))]
	private IEnumerator _DamagePieceRoutine(GridPieceObj p, BallObj b, HeroInst h, bool isBaby, Vector2 hitNormal, Vector3 hitPos, Vector2 hitAimDir, bool isGhost)
	{
		return null;
	}

	public void RunAOE(GridPieceObj p, HeroInst h, Vector3 pos, Vector3 aimDir, bool isBaby, bool isDirect)
	{
	}

	public void FreezeTime(float len)
	{
	}

	public bool IsTimeFrozen()
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003C_RunTimeFreeze_003Ed__80))]
	private IEnumerator<float> _RunTimeFreeze(float len)
	{
		return null;
	}

	public void GetLightningPieces(List<GridPieceInst> outList, int limit, int searchIdx = 0)
	{
	}

	public GridPieceObj GetPieceFromCol(Collider2D col)
	{
		return null;
	}

	public void DamageCollider(Collider2D col, BallObj b, Vector2 hitNormal, bool isGhost)
	{
	}

	public void KillPiece(GridPieceObj p)
	{
	}

	public TurnBasedState GetTacticsState()
	{
		return default(TurnBasedState);
	}

	public void SetTacticsState(TurnBasedState tb)
	{
	}

	[IteratorStateMachine(typeof(_003C_AdvanceTactics_003Ed__88))]
	private IEnumerator<float> _AdvanceTactics()
	{
		return null;
	}

	public bool ShouldTimeMoveForward()
	{
		return false;
	}

	private void MyFixedUpdate()
	{
	}

	private void MoveAndAttack()
	{
	}

	public void RunAdvance()
	{
	}

	[IteratorStateMachine(typeof(_003C_RunAdvance_003Ed__93))]
	private IEnumerator<float> _RunAdvance()
	{
		return null;
	}

	private bool IsPieceInJustSpawned(float x, float y, float w, float h)
	{
		return false;
	}

	[IteratorStateMachine(typeof(_003C_IncreaseLevelProgress_003Ed__99))]
	private IEnumerator<float> _IncreaseLevelProgress(int startProg, int tgtProg, float len)
	{
		return null;
	}

	public void RunGenerate()
	{
	}

	private void TryStartExpanding()
	{
	}

	private void Expand()
	{
	}

	private void StartSpawningWaves()
	{
	}

	public bool IsGeneratingWave()
	{
		return false;
	}

	public void SetSpawningPaused(bool isPaused)
	{
	}

	public bool IsSpawningPaused()
	{
		return false;
	}

	public int GetNumWavesSpawning()
	{
		return 0;
	}

	public List<LevelWave> GetCurSpawningWaves()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_SpawnWaves_003Ed__122))]
	private IEnumerator<float> _SpawnWaves(List<LevelWave> waves, int numWaves, int y)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_SpawnWave_003Ed__123))]
	private IEnumerator<float> _SpawnWave(LevelWave wave, int y)
	{
		return null;
	}

	public float GetDefaultMoveSpeed()
	{
		return 0f;
	}

	public void DamageArea(Vector2 ptA, Vector2 ptB, int minAmt, int maxAmt, DamageType dt, BallObj ballSrc)
	{
	}

	public int DamageAreaRange(Vector2 ptA, Vector2 ptB, int minAmt, int maxAmt, DamageType dt, HeroInst h, bool isBaby, Vector3 pos, HitEffectSrc src = HitEffectSrc.kAOE)
	{
		return 0;
	}

	public void DamageBox(Vector2 pt, Vector2 size, float angle, int amt, DamageType dt, BallObj ballSrc)
	{
	}

	public void DamageCircle(Vector2 pt, float radius, int minAmt, int maxAmt, DamageType dt, HeroInst h, bool isBaby, Vector3 pos)
	{
	}

	public void RunRay(LineFXType fxType, Vector3 pos, Vector3 aimDir, int minDmg, int maxDmg, HeroInst h, bool isBaby)
	{
	}

	public float WaitForTurns(float turns)
	{
		return 0f;
	}

	public float WaitForBattleSeconds(float secs)
	{
		return 0f;
	}

	[IteratorStateMachine(typeof(_003C_WaitForBattleSeconds_003Ed__133))]
	public IEnumerator<float> _WaitForBattleSeconds(float secs)
	{
		return null;
	}

	public void PickSpawnablePoints(Vector3 pos, GridPieceInfo spawnedInf, float range, List<Vector3> outPos)
	{
	}

	public void PickSpawnablePoints(Vector3 pos, GridPieceInfo spawnedInf, Vector2 minOffset, Vector2 maxOffset, List<Vector3> outPos)
	{
	}

	public void SpawnFromPiece(GridPieceObj src, int nToSpawn, GridPieceInfo spawnedInf, float range, List<Vector3> outPos)
	{
	}

	public int SpawnFromBoss(GridPieceObj boss, int nToSpawn, GridPieceInfo spawnedInf, float range, List<Vector3> outPos)
	{
		return 0;
	}

	public int SpawnFromBoss(GridPieceObj boss, int nToSpawn, GridPieceInfo spawnedInf, Vector2 minOffset, Vector2 maxOffset, List<Vector3> outPos)
	{
		return 0;
	}

	public int SpawnFromBossWorldPos(GridPieceObj boss, int nToSpawn, GridPieceInfo spawnedInf, Vector2 minWorld, Vector2 maxWorld, List<Vector3> outPos)
	{
		return 0;
	}

	private int SpawnFromBoss(GridPieceObj boss, int nToSpawn, GridPieceInfo spawnedInf, List<Vector3> outPos)
	{
		return 0;
	}

	public bool IsGridClear()
	{
		return false;
	}

	public bool IsEveryoneDead()
	{
		return false;
	}

	public void RunClearBonus()
	{
	}

	public void RunDeathBonus()
	{
	}

	public void StopRoutines()
	{
	}

	public ObstacleObj CreateObstacle(ObstacleType at, float x, float y, float size)
	{
		return null;
	}

	public ObstacleObj CreateObstacle(ObstacleType at, BallObj b)
	{
		return null;
	}

	public void RemoveObstacle(ObstacleObj ob)
	{
	}

	public void HitObstacle(BallObj b, Collider2D col)
	{
	}

	public void RunEnviroRoutines()
	{
	}

	public float GetWindXDir()
	{
		return 0f;
	}

	[IteratorStateMachine(typeof(_003C_RunSavannaWind_003Ed__152))]
	private IEnumerator<float> _RunSavannaWind()
	{
		return null;
	}

	private BlockingCloudObj CreateBlockingCloud(int dir, bool isInitial)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003C_RunCloudClouds_003Ed__154))]
	private IEnumerator<float> _RunCloudClouds()
	{
		return null;
	}

	public void EmitThorns(Vector3 srcPos, int amt)
	{
	}

	public void SetScrollSpeedMult(float mult)
	{
	}

	public float GetScrollSpeedMult()
	{
		return 0f;
	}

	public float GetScrollSpeed()
	{
		return 0f;
	}

	public float GetDeltaScroll()
	{
		return 0f;
	}

	public void ScrollBoard(float scrollDelta)
	{
	}

	private void UpdatePieceStatusEffects(GridPieceInst p, float dt)
	{
	}

	private void MyUpdate()
	{
	}

	public void AddTacticsBlocker(GridPieceObj p)
	{
	}

	public void RemoveTacticsBlocker(GridPieceObj p)
	{
	}

	private void StartTwitchPoll()
	{
	}

	private void OnPollClosed(List<PollResult> results, int totalVotes)
	{
	}

	[IteratorStateMachine(typeof(_003C_RunTwitchEvent_003Ed__171))]
	private IEnumerator<float> _RunTwitchEvent(TwitchRandomEventType evType)
	{
		return null;
	}
}
