using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Coherence.Toolkit.Bindings.TransformBindings;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using Newtonsoft.Json.Linq;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.Objects.Characters;

public class EnemyController : BasePoolableSpriteBehaviour, IDamageable
{
	private sealed class _003C_003Ec__DisplayClass312_0
	{
		public Action<Pickup> onRewardGiven;

		internal void _003CGiveReward_003Eb__0(Pickup pickup)
		{
			Action<Pickup> action = onRewardGiven;
			if (onRewardGiven != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass312_1
	{
		public float rawXp;

		internal void _003CGiveReward_003Eb__1(Pickup p)
		{
			if ((object)p != null && ((UnityEngine.Object)p).m_CachedPtr != (IntPtr)0)
			{
				float num = p._003CValue_003Ek__BackingField;
				if (!(p._003CValue_003Ek__BackingField > rawXp))
				{
					num = rawXp;
				}
				p._003CValue_003Ek__BackingField = num;
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass313_0
	{
		public Action<Pickup> onRewardGiven;

		internal void _003CGiveFullReward_003Eb__0(Pickup pickup)
		{
			Action<Pickup> action = onRewardGiven;
			if (onRewardGiven != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass313_1
	{
		public float rawXp;

		internal void _003CGiveFullReward_003Eb__1(Pickup p)
		{
			if ((object)p != null && ((UnityEngine.Object)p).m_CachedPtr != (IntPtr)0)
			{
				float num = p._003CValue_003Ek__BackingField;
				if (!(p._003CValue_003Ek__BackingField > rawXp))
				{
					num = rawXp;
				}
				p._003CValue_003Ek__BackingField = num;
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass326_0
	{
		public EnemyController _003C_003E4__this;

		public uint defangColorTint;

		public bool stopAnimation;

		internal void _003CDoDefang_003Eb__0()
		{
			EnemyController enemyController = _003C_003E4__this;
			enemyController._003CIsDefanged_003Ek__BackingField = false;
			if (defangColorTint != 0)
			{
				enemyController.RestoreTint();
			}
			if (~(stopAnimation ? 1u : 0u) == 0)
			{
				EnemyData currentEnemyData = enemyController._currentEnemyData;
				if (currentEnemyData._003CidleFrameCount_003Ek__BackingField > 0)
				{
					SpriteAnimation spriteAnimation = enemyController._SpriteAnimation;
					((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
				}
			}
		}
	}

	private const uint DefangTint = 4521864u;

	private bool _003CKilledByAuthority_003Ek__BackingField;

	protected SpriteRenderer _EnemyRenderer;

	protected SpriteRenderer _AlertSpriteRenderer;

	protected SpriteAnimation _SpriteAnimation;

	protected SignalBus _signalBus;

	protected Transform _cachedTransform;

	protected GameSessionData _gameSessionData;

	protected GameManager _gameManager;

	protected DataManager _dataManager;

	private JObject _currentJsonData;

	protected EnemyData _currentEnemyData;

	protected bool _hasInitializedData;

	protected PlayerOptions _playerOptions;

	protected CoherenceSync _coherenceSync;

	private PositionBinding _positionBinding;

	protected Unity.Mathematics.Random _deathRng;

	protected EnemyDeathStyle _deathStyle;

	protected uint _deathSeed;

	private Vector2 _networkErrorVector;

	private Vector2 _errorVelocity;

	private Transform _targetTransform;

	protected bool _receivingDamage;

	private bool _passThroughWalls;

	protected Treasure _treasure;

	protected bool _selfDestruct;

	protected bool _isSelfDestructionTriggered;

	private float _startingAngle;

	protected Sequence _alertTween;

	protected uint _saveTint;

	public bool _hasATreasure;

	protected Transform _enemyRendererTransform;

	private float _wiggleProgress;

	private bool _wiggleForward;

	private bool _wiggleInit;

	private readonly Quaternion _wiggleStartRot;

	private readonly Quaternion _wiggleEndRot;

	protected Timer _selfDestructTimer;

	private Timer _pushbackTimer;

	private Timer _freezeTimer;

	private Timer _slowedTimer;

	protected Timer _blinkTimeout;

	protected Vector2 _spritePivot;

	protected bool _canBeDamagedByBloodline;

	protected Timer _divineBloodlineDamageTimer;

	protected bool _allowAnimationPauseResume;

	protected EnemyType _enemyType;

	protected float _damageKb;

	protected float _defaultSpeed;

	protected float _scaleMul;

	protected bool _hpXLevel;

	private bool _fixedDirection;

	protected bool _medusa;

	protected float _medusaElapsed;

	protected GameObject _owner;

	private float _alpha;

	protected string _defaultName;

	protected float _damageWeakness;

	protected float _maxDamageWeakness;

	private int _multiplayerCorpseFeedingCounter;

	protected bool _isImmuneToModification;

	protected Vector2 _currentDirection;

	protected float _hp;

	protected float _maxHp;

	private static readonly int ApplyTintFill;

	private static readonly int TintFillColor;

	public const string ANIM_IDLE = "idle";

	public const string ANIM_DIE = "die";

	[NonSerialized]
	public float Distance;

	private float _003CSpeed_003Ek__BackingField;

	private bool _003CIsTeleportOnCull_003Ek__BackingField;

	private bool _003CIsBoss_003Ek__BackingField;

	private bool _003CDontTeleportOnFreeRoam_003Ek__BackingField;

	private bool _003CIgnoreNetworkError_003Ek__BackingField;

	private Tween _003CScaleTween_003Ek__BackingField;

	private bool _003CIsCullable_003Ek__BackingField;

	private bool _003CIsStatic_003Ek__BackingField;

	private float? _003CResRosary_003Ek__BackingField;

	private float? _003CResDebuffs_003Ek__BackingField;

	private float? _003CResCorridor_003Ek__BackingField;

	private float? _003CResFreeze_003Ek__BackingField;

	private float? _003CResDefang_003Ek__BackingField;

	private float _003CWeakFire_003Ek__BackingField;

	private float _003CSlow_003Ek__BackingField;

	private bool _003CIsPatrolling_003Ek__BackingField;

	private float _003CKnockBack_003Ek__BackingField;

	private bool _003CIsDefanged_003Ek__BackingField;

	private bool _003CIsTimeStopped_003Ek__BackingField;

	private bool _003CIsTimeSlowed_003Ek__BackingField;

	private float _003CSelfDestDistance_003Ek__BackingField;

	private int _003CStageEventId_003Ek__BackingField;

	private bool _003CConditionalCanMove_003Ek__BackingField;

	private bool _003CIgnoreMovementFreezeFromTimeStop_003Ek__BackingField;

	private Timer DefangTimer;

	private const float _defaultCorrectionFactor = 0.85f;

	public static WeaponType[] FireDamageTypes;

	private bool _003CIsDead_003Ek__BackingField;

	private static readonly ProfilerMarker MarkerInitEnemy;

	private static readonly ProfilerMarker MarkerDespawn;

	private static readonly ProfilerMarker MarkerInitialiseLocalData;

	private static readonly ProfilerMarker MarkerOnRecycleEnemy;

	private static readonly ProfilerMarker MarkerSetEnemySpriteAndAnimations;

	private static ProfilerMarker updateDepthMarker;

	private int currentDepthEnemy;

	private int currentDepthAlert;

	private static ProfilerMarker setTintFillMarker;

	public int SyncedEnemyType
	{
		get
		{
			return (int)_enemyType;
		}
		set
		{
			_enemyType = (EnemyType)value;
			InitialiseLocalData((EnemyType)value);
		}
	}

	public byte SyncedDeathStyle
	{
		get
		{
			return (byte)_deathStyle;
		}
		set
		{
			_deathStyle = (EnemyDeathStyle)value;
		}
	}

	public EnemyDeathStyle DeathStyle => _deathStyle;

	public Transform TargetTransform
	{
		get
		{
			return _targetTransform;
		}
		set
		{
			_targetTransform = value;
		}
	}

	public GameObject Owner
	{
		get
		{
			return _owner;
		}
		set
		{
			SetOwner(value);
		}
	}

	public uint DeathSeed
	{
		get
		{
			return _deathSeed;
		}
		set
		{
			_deathSeed = value;
		}
	}

	public bool KilledByAuthority
	{
		get
		{
			return _003CKilledByAuthority_003Ek__BackingField;
		}
		set
		{
			_003CKilledByAuthority_003Ek__BackingField = value;
		}
	}

	public float AttackPower
	{
		get
		{
			EnemyData currentEnemyData = _currentEnemyData;
			return currentEnemyData._003Cpower_003Ek__BackingField * GameManager.DifficultyAdjustmentEnemyDamageMultiplier;
		}
	}

	public float Speed
	{
		get
		{
			return _003CSpeed_003Ek__BackingField;
		}
		set
		{
			_003CSpeed_003Ek__BackingField = value;
		}
	}

	public float DefaultSpeed => _defaultSpeed;

	private Vector2 CurrentPos
	{
		get
		{
			Transform cachedTransform = _cachedTransform;
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			Vector2 result = default(Vector2);
			return result;
		}
	}

	public Vector2 Velocity
	{
		get
		{
			Vector2 result = default(Vector2);
			if (body != null)
			{
				return result;
			}
			return (Vector2)new NullReferenceException();
		}
	}

	public bool IsTeleportOnCull
	{
		get
		{
			return _003CIsTeleportOnCull_003Ek__BackingField;
		}
		set
		{
			_003CIsTeleportOnCull_003Ek__BackingField = value;
		}
	}

	public bool IsBoss
	{
		get
		{
			return _003CIsBoss_003Ek__BackingField;
		}
		set
		{
			_003CIsBoss_003Ek__BackingField = value;
		}
	}

	public bool DontTeleportOnFreeRoam
	{
		get
		{
			return _003CDontTeleportOnFreeRoam_003Ek__BackingField;
		}
		set
		{
			_003CDontTeleportOnFreeRoam_003Ek__BackingField = value;
		}
	}

	public float ScaleMul => _scaleMul;

	public bool IgnoreNetworkError
	{
		get
		{
			return _003CIgnoreNetworkError_003Ek__BackingField;
		}
		set
		{
			_003CIgnoreNetworkError_003Ek__BackingField = value;
		}
	}

	public Tween ScaleTween
	{
		get
		{
			return _003CScaleTween_003Ek__BackingField;
		}
		set
		{
			_003CScaleTween_003Ek__BackingField = value;
		}
	}

	public bool CannotBeFollower
	{
		get
		{
			//IL_0041: Expected I4, but got O
			EnemyData currentEnemyData = _currentEnemyData;
			if (_currentEnemyData != null)
			{
				return currentEnemyData._003CCannotBeFollower_003Ek__BackingField;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		set
		{
			EnemyData currentEnemyData = _currentEnemyData;
			currentEnemyData._003CCannotBeFollower_003Ek__BackingField = value;
		}
	}

	public bool IsCullable
	{
		get
		{
			return _003CIsCullable_003Ek__BackingField;
		}
		set
		{
			_003CIsCullable_003Ek__BackingField = value;
		}
	}

	public bool IsStatic
	{
		get
		{
			return _003CIsStatic_003Ek__BackingField;
		}
		set
		{
			_003CIsStatic_003Ek__BackingField = value;
		}
	}

	public float FeverValue
	{
		get
		{
			//IL_0027: Invalid comparison between F4 and I4
			EnemyData currentEnemyData = _currentEnemyData;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187658A7Fh\"");
			if (currentEnemyData._003CfeverValue_003Ek__BackingField == 0f)
			{
				return 1f;
			}
			return currentEnemyData._003CfeverValue_003Ek__BackingField;
		}
		set
		{
			EnemyData currentEnemyData = _currentEnemyData;
			currentEnemyData._003CfeverValue_003Ek__BackingField = value;
		}
	}

	public unsafe Vector3 CurrentDirection
	{
		get
		{
			//IL_0008: Expected native int or pointer, but got O
			//IL_0016: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			float x = default(float);
			((Vector3*)(nint)vector)->x = x;
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		protected set
		{
			//IL_000f: Expected O, but got F4
			_currentDirection = (Vector2)value.x;
		}
	}

	public bool FixedDirection => _fixedDirection;

	public float? ResRosary
	{
		get
		{
			return _003CResRosary_003Ek__BackingField;
		}
		private set
		{
			_003CResRosary_003Ek__BackingField = value;
		}
	}

	public float? ResDebuffs
	{
		get
		{
			return _003CResDebuffs_003Ek__BackingField;
		}
		private set
		{
			_003CResDebuffs_003Ek__BackingField = value;
		}
	}

	public float? ResCorridor
	{
		get
		{
			return _003CResCorridor_003Ek__BackingField;
		}
		private set
		{
			_003CResCorridor_003Ek__BackingField = value;
		}
	}

	public float? ResFreeze
	{
		get
		{
			return _003CResFreeze_003Ek__BackingField;
		}
		set
		{
			_003CResFreeze_003Ek__BackingField = value;
		}
	}

	public float? ResDefang
	{
		get
		{
			return _003CResDefang_003Ek__BackingField;
		}
		set
		{
			_003CResDefang_003Ek__BackingField = value;
		}
	}

	public float WeakFire
	{
		get
		{
			return _003CWeakFire_003Ek__BackingField;
		}
		private set
		{
			_003CWeakFire_003Ek__BackingField = value;
		}
	}

	public SpriteRenderer EnemyRenderer => _EnemyRenderer;

	public SpriteRenderer AlertSpriteRenderer => _AlertSpriteRenderer;

	public float Slow
	{
		get
		{
			return _003CSlow_003Ek__BackingField;
		}
		set
		{
			_003CSlow_003Ek__BackingField = value;
		}
	}

	public bool IsPatrolling
	{
		get
		{
			return _003CIsPatrolling_003Ek__BackingField;
		}
		set
		{
			_003CIsPatrolling_003Ek__BackingField = value;
		}
	}

	public float KnockBack
	{
		get
		{
			return _003CKnockBack_003Ek__BackingField;
		}
		set
		{
			_003CKnockBack_003Ek__BackingField = value;
		}
	}

	public EnemyData CurrentEnemyData => _currentEnemyData;

	public bool IsDefanged
	{
		get
		{
			return _003CIsDefanged_003Ek__BackingField;
		}
		private set
		{
			_003CIsDefanged_003Ek__BackingField = value;
		}
	}

	public bool IsTimeStopped
	{
		get
		{
			return _003CIsTimeStopped_003Ek__BackingField;
		}
		private set
		{
			_003CIsTimeStopped_003Ek__BackingField = value;
		}
	}

	public bool IsTimeSlowed
	{
		get
		{
			return _003CIsTimeSlowed_003Ek__BackingField;
		}
		private set
		{
			_003CIsTimeSlowed_003Ek__BackingField = value;
		}
	}

	protected Camera MainCamera => Camera.main;

	public float SelfDestDistance
	{
		get
		{
			return _003CSelfDestDistance_003Ek__BackingField;
		}
		set
		{
			_003CSelfDestDistance_003Ek__BackingField = value;
		}
	}

	public SpriteAnimation SpriteAnimation => _SpriteAnimation;

	public SpriteAnimation anims => _SpriteAnimation;

	public EnemyType EnemyType => _enemyType;

	public int StageEventId
	{
		get
		{
			return _003CStageEventId_003Ek__BackingField;
		}
		set
		{
			_003CStageEventId_003Ek__BackingField = value;
		}
	}

	public bool ConditionalCanMove
	{
		get
		{
			return _003CConditionalCanMove_003Ek__BackingField;
		}
		set
		{
			_003CConditionalCanMove_003Ek__BackingField = value;
		}
	}

	public bool IgnoreMovementFreezeFromTimeStop
	{
		get
		{
			return _003CIgnoreMovementFreezeFromTimeStop_003Ek__BackingField;
		}
		set
		{
			_003CIgnoreMovementFreezeFromTimeStop_003Ek__BackingField = value;
		}
	}

	public CoherenceSync Sync => _coherenceSync;

	public float Hp
	{
		get
		{
			return _hp;
		}
		set
		{
			_hp = value;
		}
	}

	public bool IsDead
	{
		get
		{
			return _003CIsDead_003Ek__BackingField;
		}
		set
		{
			_003CIsDead_003Ek__BackingField = value;
		}
	}

	public float NormalizedHp => _hp / _maxHp;

	public float DamageWeakness
	{
		get
		{
			return _damageWeakness;
		}
		set
		{
			_damageWeakness = value;
		}
	}

	public float MaxDamageWeakness
	{
		get
		{
			return _maxDamageWeakness;
		}
		set
		{
			_maxDamageWeakness = value;
		}
	}

	protected virtual void FakeConstruct()
	{
		_gameManager = GM.Core;
		GameManager core = GM.Core;
		_signalBus = core._signalBus;
		GameManager core2 = GM.Core;
		_dataManager = core2._dataManager;
		GameManager core3 = GM.Core;
		_playerOptions = core3._playerOptions;
		GameManager core4 = GM.Core;
		_gameSessionData = core4._gameSessionData;
	}

	protected virtual void Awake()
	{
		//IL_0029: Expected O, but got I4
		Transform cachedTransform = base.transform;
		_cachedTransform = cachedTransform;
		CoherenceSync component = GetComponent<CoherenceSync>();
		_coherenceSync = component;
		_deathRng = (Unity.Mathematics.Random)0;
		CoherenceSync coherenceSync = _coherenceSync;
		if ((object)_coherenceSync != null && ((UnityEngine.Object)coherenceSync).m_CachedPtr != (IntPtr)0)
		{
			PositionBinding bakedValueBinding = _coherenceSync.GetBakedValueBinding<PositionBinding>();
			_positionBinding = bakedValueBinding;
			PositionBinding positionBinding = _positionBinding;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rax_v17 (Coherence.Toolkit.Bindings.TransformBindings.PositionBinding)+24]");
			if ((nint)0 == 1)
			{
				Action<object, bool, long> value = DetectMisprediction;
				positionBinding.OnNetworkSampleReceived += value;
			}
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		_EnemyRenderer.enabled = true;
	}

	protected virtual void Start()
	{
	}

	protected override void OnDestroy()
	{
		if (_selfDestructTimer != null)
		{
			_selfDestructTimer.Cancel();
		}
		if (body != null)
		{
			BaseBody baseBody = body;
			baseBody._gameObject = null;
		}
		Tween alertTween = _alertTween;
		if (_alertTween != null && alertTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_alertTween);
		}
	}

	protected unsafe virtual void OnDrawGizmosSelected()
	{
		//IL_001d: Expected O, but got I4
		object obj = Application.isPlaying;
		if (obj != null)
		{
			Color value = default(Color);
			Gizmos.set_color_Injected(ref value);
			Vector2 currentPos = CurrentPos;
			Vector2 currentPos2 = CurrentPos;
			Vector3 to = default(Vector3);
			Gizmos.DrawLine_Injected(ref *(Vector3*)(&value), ref to);
			Color value2 = default(Color);
			Gizmos.set_color_Injected(ref value2);
		}
	}

	public virtual void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_03e9: Expected I, but got O
		//IL_04cc: Expected I, but got O
		//IL_04f5: Expected O, but got I
		//IL_043a: Expected I4, but got I8
		//IL_0457: Expected O, but got I4
		//IL_0047: Expected I, but got O
		//IL_024a: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		//IL_0076: Expected O, but got I
		//IL_0479: Invalid comparison between I4 and F4
		//IL_00dc: Expected O, but got I8
		//IL_0367: Expected O, but got I
		//IL_01de: Expected O, but got I4
		//IL_01e6: Expected O, but got F4
		//IL_0186: Expected F4, but got O
		_EnemyRenderer.enabled = true;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rax_v6 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_networkErrorVector = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ rdx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		nint num3 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v8 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num4 = 0;
		Vector2 zeroVector = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		object obj = 0;
		_errorVelocity = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		_deathStyle = EnemyDeathStyle.Despawn;
		_003CConditionalCanMove_003Ek__BackingField = true;
		_hasATreasure = false;
		_003CKilledByAuthority_003Ek__BackingField = false;
		FakeConstruct();
		if (enemyType != _enemyType)
		{
			_hasInitializedData = false;
		}
		_enemyType = enemyType;
		_003CIsDead_003Ek__BackingField = false;
		_003CStageEventId_003Ek__BackingField = -1;
		bool flag = _hasInitializedData;
		object obj2 = 0;
		if (!flag)
		{
			InitialiseLocalData(enemyType);
			obj2 = 0;
		}
		nint num5 = (nint)this;
		_multiplayerCorpseFeedingCounter = 0;
		SetEnemySpriteAndAnimations();
		if (!asRemote)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag2 = (nint)0 != 0;
			EnemyController enemyController = this;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj3 == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				enemyController = (EnemyController)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v523 @ rax_v42 (should have been resolved before IL gen)");
			if (0f > 1f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si rax,xmm0\"");
			}
			uint deathSeed = default(uint);
			_deathSeed = deathSeed;
			GameManager core = GM.Core;
			CharacterController characterController;
			float num6;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				float2 float5 = base.position;
				GameManager gameManager = _gameManager;
				CoopConfig coopConfig = gameManager.CoopConfig;
				bool inclusionMode = !coopConfig._spawningEnemiesTargetDeadPlayersAlso;
				bool includeFollowers = default(bool);
				characterController = _gameManager.GetClosestPlayer(float5, inclusionMode ? PlayerInclusionMode.AlivePreferred : PlayerInclusionMode.AliveOrDead, 3.4028235E+38f, includeFollowers);
				num6 = (float)float5;
			}
			else
			{
				PlayerInfo myPlayerInfo = OnlineStageManager._instance.GetMyPlayerInfo();
				characterController = myPlayerInfo.CharacterController;
				num6 = 1f;
			}
			Transform targetTransform = characterController.transform;
			_targetTransform = targetTransform;
			obj = 0;
			zeroVector = (Vector2)num6;
		}
		int num7 = (int)(_deathSeed << 13);
		int num8 = (int)_deathSeed ^ num7;
		int num9 = num8 >> 17;
		int num10 = num8 ^ num9;
		int num11 = num10 << 5;
		int num12 = num11 ^ num10;
		_deathRng = (Unity.Mathematics.Random)num12;
		if (body == null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			Factory add = s_scene.add;
			PhaserGameObject phaserGameObject = add._world.enableBody(this);
			if (body == null)
			{
				goto IL_0370;
			}
		}
		BaseBody baseBody = body;
		baseBody._enable = true;
		GameManager core2 = GM.Core;
		Group obj4 = core2.Enemies.add(this);
		BaseBody baseBody2 = body;
		if (baseBody2._enable && !_passThroughWalls)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D80");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v33+20]");
			Group obj5 = ((Group)0).add(this);
		}
		goto IL_0370;
		IL_0370:
		OnRecycleEnemy();
		if (!_isImmuneToModification && _003CIsBoss_003Ek__BackingField)
		{
			UpdateBaseHealth();
		}
	}

	protected virtual void UpdateBaseHealth()
	{
		//IL_0078: Invalid comparison between I4 and F4
		GameManager core = GM.Core;
		if ((_hp = core._bossHealthMultiplier * _hp) > _maxHp)
		{
			_hp = _maxHp;
		}
		if (!(0f < _hp))
		{
			Die();
		}
	}

	protected virtual bool CanUseAbility()
	{
		//IL_00cb: Expected O, but got I
		//IL_004e: Invalid comparison between F4 and I4
		//IL_0079: Invalid comparison between F4 and I4
		//IL_008d: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v41 @ rax_v3 (should have been resolved before IL gen)");
		GameManager core = GM.Core;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187659B5Fh\"");
		if (core._bossAttacksTriggerChance == 0f)
		{
			return false;
		}
		bool flag = core._bossAttacksTriggerChance < 0f;
		bool flag2 = core._bossAttacksTriggerChance == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	public void SetTargetTransform(Transform target)
	{
		_targetTransform = target;
	}

	public virtual void SetOwner(GameObject owner)
	{
		_owner = owner;
	}

	public virtual void OnTeleportOnCull()
	{
		CoherenceSync coherenceSync = _coherenceSync;
		if ((object)_coherenceSync != null && ((UnityEngine.Object)coherenceSync).m_CachedPtr != (IntPtr)0 && !_coherenceSync.HasStateAuthority)
		{
			return;
		}
		Transform targetTransform = _targetTransform;
		Component component2;
		if ((object)_targetTransform != null && ((UnityEngine.Object)targetTransform).m_CachedPtr != (IntPtr)0)
		{
			CharacterController component = _targetTransform.GetComponent<CharacterController>();
			component2 = component;
		}
		else
		{
			component2 = null;
		}
		bool flag = (object)component2 == null;
		CharacterController player = (CharacterController)component2;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
			player = (CharacterController)component2;
			if (!flag2)
			{
				GameObject gameObject = component2.gameObject;
				bool activeInHierarchy = gameObject.activeInHierarchy;
				player = (CharacterController)component2;
				if (!activeInHierarchy)
				{
					TargetClosestPlayer();
					Transform targetTransform2 = _targetTransform;
					if ((object)_targetTransform != null && ((UnityEngine.Object)targetTransform2).m_CachedPtr != (IntPtr)0)
					{
						CharacterController component3 = _targetTransform.GetComponent<CharacterController>();
						player = component3;
					}
					else
					{
						player = null;
					}
				}
			}
		}
		GameManager core = GM.Core;
		Vector2 bossyPosition = core._stage.GetBossyPosition(player);
		float2 float5 = default(float2);
		base.position = float5;
	}

	public virtual bool CanEnemyTeleport()
	{
		return true;
	}

	public void AttachTreasure(Treasure treasure)
	{
		_treasure = treasure;
		_hasATreasure = true;
	}

	public virtual void Disappear()
	{
		if (_003CIsDead_003Ek__BackingField)
		{
			return;
		}
		if (_selfDestruct)
		{
			_AlertSpriteRenderer.forceRenderingOff = true;
			Tween alertTween = _alertTween;
			if (_alertTween != null && alertTween._003Cactive_003Ek__BackingField)
			{
				DG.Tweening.TweenExtensions.Kill(_alertTween);
			}
		}
		_003CIsDead_003Ek__BackingField = true;
		_deathStyle = EnemyDeathStyle.Disappear;
		PlayDeathAnimation();
	}

	public virtual void Despawn()
	{
		//IL_0281: Expected I, but got O
		//IL_01c0->IL01fc: Incompatible stack heights: 5 vs 4
		//IL_01e2->IL01fc: Incompatible stack heights: 5 vs 4
		//IL_01fc->IL01fc: Incompatible stack heights: 5 vs 4
		if ((object)MarkerDespawn != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerDespawn);
		}
		GameManager core = GM.Core;
		bool flag = (object)GM.Core == null;
		bool flag2 = core.Enemies == null;
		core.Enemies.remove(this);
		PhysicsManager sInstance = PhysicsManager._sInstance;
		bool flag3 = PhysicsManager._sInstance == null;
		bool flag4 = sInstance._enemyGroup == null;
		sInstance._enemyGroup.remove(this);
		if (body != null)
		{
			body.destroy();
			body = null;
		}
		_003CIsCullable_003Ek__BackingField = true;
		Tween tween = _003CScaleTween_003Ek__BackingField;
		if (_003CScaleTween_003Ek__BackingField != null && tween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_003CScaleTween_003Ek__BackingField);
		}
		if (_selfDestructTimer != null)
		{
			_selfDestructTimer.Cancel();
		}
		if (_selfDestruct)
		{
			bool flag5 = (object)_AlertSpriteRenderer == null;
			_AlertSpriteRenderer.forceRenderingOff = true;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_AlertSpriteRenderer, 0f);
			Tween alertTween = _alertTween;
			if (_alertTween != null && alertTween._003Cactive_003Ek__BackingField)
			{
				DG.Tweening.TweenExtensions.Kill(_alertTween);
			}
		}
		FireKilledSignal();
		GameObject obj = base.gameObject;
		bool flag6 = (object)base._ParentPool == null;
		base._ParentPool.Release(obj);
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		autoScope.Dispose();
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public void FeedOnPlayer()
	{
		//IL_00ec: Expected I, but got O
		//IL_00f9: Expected I, but got O
		//IL_0109: Expected O, but got I
		//IL_0141: Expected O, but got I
		int multiplayerCorpseFeedingCounter = _multiplayerCorpseFeedingCounter + 1;
		_multiplayerCorpseFeedingCounter = multiplayerCorpseFeedingCounter;
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rsi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rsi_v1 (System.Object)+10]");
		Transform.get_localScale_Injected((IntPtr)0, out Vector3 _);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rsi_v1 (System.Object)+10]");
		bool flag2 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rsi_v1 (System.Object)+10]");
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected((IntPtr)0, ref value);
		_cachedTransform.hasChanged = true;
		GameManager gameManager = _gameManager;
		CoopConfig coopConfig = gameManager.CoopConfig;
		float num = coopConfig._enemyChompHPGainProportionPerChomp + 1f;
		GameManager gameManager2 = _gameManager;
		float maxHp = num * _maxHp;
		_maxHp = maxHp;
		CoopConfig coopConfig2 = gameManager2.CoopConfig;
		float num2 = coopConfig2._enemyChompHPGainProportionPerChomp + 1f;
		Body body = (Body)base.body;
		float hp = num2 * _hp;
		_hp = hp;
		nint num3 = (nint)typeof(Body);
		nint num4 = (nint)body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ r8_v6 (Il2CppClass<Body>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r9_v5 (Il2CppClass<Body>)+130]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ r8_v6 (Il2CppClass<Body>)+130]");
		bool flag3 = num5 < 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ r9_v5 (Il2CppClass<Body>)+C8]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rax_v33+FFFFFFF8+v498 @ rax_v32*8]");
		bool flag4 = 0 != (nint)typeof(Body);
		body.updateFromGameObject();
		GameManager gameManager3 = _gameManager;
		CoopConfig coopConfig3 = gameManager3.CoopConfig;
		if (coopConfig3._enemyChompEffect != HitVfxType.None)
		{
			GameManager gameManager4 = _gameManager;
			CoopConfig coopConfig4 = gameManager4.CoopConfig;
			PlayVFXFlash(coopConfig4._enemyChompEffect);
		}
	}

	public unsafe bool IsPlayingDeathAnimation()
	{
		//IL_01a6: Expected I4, but got O
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected Ref, but got Unknown
		//IL_0101: Expected I8, but got O
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5F17]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		if ((object)_SpriteAnimation != null)
		{
			FrameAnimationData currentAnimation = ((BaseSpriteAnimation)spriteAnimation)._currentAnimation;
			if (((BaseSpriteAnimation)spriteAnimation)._currentAnimation != null)
			{
				currentAnimation = (FrameAnimationData)(object)currentAnimation._name;
			}
			object obj = "die";
			if ((object)currentAnimation == "die")
			{
				goto IL_013d;
			}
			if (currentAnimation != null && "die" != null)
			{
				string text = currentAnimation._name;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rdx_v2+10]");
				if (text == null)
				{
					ref byte second = ref *(byte*)("die" + 20);
					ulong length = (ulong)(long)(currentAnimation._name + currentAnimation._name);
					if (System.SpanHelpers.SequenceEqual(ref *(byte*)(currentAnimation + 20), ref second, length))
					{
						goto IL_013d;
					}
				}
			}
			goto IL_015f;
		}
		goto IL_0198;
		IL_013d:
		if (body == null)
		{
			goto IL_015f;
		}
		if ((object)_EnemyRenderer != null)
		{
			return _EnemyRenderer.enabled;
		}
		goto IL_0198;
		IL_015f:
		return false;
		IL_0198:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool WouldEat()
	{
		//IL_017c: Expected I4, but got O
		//IL_0037: Invalid comparison between F4 and I4
		//IL_005c: Invalid comparison between F4 and I4
		//IL_0104: Expected O, but got I4
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected I4, but got Unknown
		EnemyData currentEnemyData = _currentEnemyData;
		if (_currentEnemyData != null)
		{
			if (!(currentEnemyData._003Cxp_003Ek__BackingField > 0f) || !(currentEnemyData._003Cspeed_003Ek__BackingField > 0f) || currentEnemyData._003CpassThroughWalls_003Ek__BackingField)
			{
				return false;
			}
			GameManager gameManager = _gameManager;
			if ((object)_gameManager != null)
			{
				CoopConfig coopConfig = gameManager.CoopConfig;
				if ((object)gameManager.CoopConfig != null)
				{
					object obj = _multiplayerCorpseFeedingCounter - coopConfig._enemyChompMaxCount;
					int num = _multiplayerCorpseFeedingCounter ^ coopConfig._enemyChompMaxCount;
					int num2 = _multiplayerCorpseFeedingCounter ^ obj;
					int num3 = num & num2;
					bool flag = num3 < 0;
					bool flag2 = (nint)obj < 0;
					return flag2 != flag;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsBossEnemy()
	{
		//IL_004c: Expected O, but got I4
		//IL_005b: Expected I4, but got O
		if (_003CIsBoss_003Ek__BackingField)
		{
			return true;
		}
		object obj = default(object);
		bool flag = (nint)obj < 0;
		bool flag2 = obj == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj2 = flag4 & flag3;
		return (byte)(obj2 & (object?)_003CResRosary_003Ek__BackingField) != 0;
	}

	public bool IsBullet()
	{
		//IL_005b: Expected I4, but got O
		//IL_0037: Invalid comparison between I4 and F4
		EnemyData currentEnemyData = _currentEnemyData;
		if (_currentEnemyData != null)
		{
			bool flag = 0f < currentEnemyData._003Cxp_003Ek__BackingField;
			return !flag;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsFlying()
	{
		//IL_0041: Expected I4, but got O
		EnemyData currentEnemyData = _currentEnemyData;
		if (_currentEnemyData != null)
		{
			return currentEnemyData._003CpassThroughWalls_003Ek__BackingField;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public virtual void OnPlayerOverlap(CharacterController player)
	{
		//IL_00d2: Expected I, but got O
		//IL_00e0: Expected I, but got O
		//IL_00f0: Expected O, but got I
		//IL_0170: Expected O, but got I4
		//IL_012c: Expected O, but got I
		//IL_017d: Expected I4, but got O
		//IL_0162: Expected O, but got I4
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		if (!arcanaManager._003CHasDivineBloodline_003Ek__BackingField)
		{
			goto IL_028d;
		}
		if (!_canBeDamagedByBloodline)
		{
			return;
		}
		float num = player.PArmor();
		float num2 = default(float);
		GetDamaged(num2, HitVfxType.None, 3f, WeaponType.VOID, hasKb: false);
		Weapon weaponByType = player._weaponsManager.GetWeaponByType(WeaponType.BLOODLINE, searchHidden: true);
		bool flag;
		if ((object)weaponByType == null)
		{
			flag = false;
			goto IL_03c7;
		}
		nint num3 = (nint)weaponByType;
		nint num4 = (nint)typeof(DivineBloodlineWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ rdx_v27 (Il2CppClass<VampireSurvivors.Objects.Weapons.DivineBloodlineWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ r9_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ rdx_v27 (Il2CppClass<VampireSurvivors.Objects.Weapons.DivineBloodlineWeapon>)+130]");
		object obj3;
		if (num5 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ r9_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v521 @ rax_v57+FFFFFFF8+v464 @ rax_v53*8]");
			if (0 == (nint)typeof(DivineBloodlineWeapon))
			{
				obj3 = 1;
				goto IL_039c;
			}
		}
		obj3 = 0;
		goto IL_039c;
		IL_03c7:
		if (flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rbx_v6 (System.Boolean)+10]");
			if ((nint)0 != 0)
			{
				float num6 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rbx_v6 (System.Boolean)+134]");
				float num7 = num6 + 0f;
			}
		}
		if (_003CIsDead_003Ek__BackingField)
		{
			GameManager core2 = GM.Core;
			core2._arcanaManager.IncreaseBloodlineBonus(player);
		}
		_canBeDamagedByBloodline = false;
		if (_divineBloodlineDamageTimer != null)
		{
			_divineBloodlineDamageTimer.Cancel();
		}
		Action onComplete = delegate
		{
			_canBeDamagedByBloodline = true;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer divineBloodlineDamageTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_divineBloodlineDamageTimer = divineBloodlineDamageTimer;
		goto IL_028d;
		IL_028d:
		if (player.HasThorns && _canBeDamagedByBloodline)
		{
			float thornDamage = player.GetThornDamage(this);
			GetDamaged(0.5f, HitVfxType.Default, 3f, WeaponType.VOID, hasKb: false);
			_canBeDamagedByBloodline = false;
			if (_divineBloodlineDamageTimer != null)
			{
				_divineBloodlineDamageTimer.Cancel();
			}
			Action onComplete2 = delegate
			{
				_canBeDamagedByBloodline = true;
			};
			Timer divineBloodlineDamageTimer2 = Timers.Register(0.5f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_divineBloodlineDamageTimer = divineBloodlineDamageTimer2;
		}
		return;
		IL_039c:
		bool flag2 = obj3 == null;
		flag = false;
		if (!flag2)
		{
			flag = (byte)(int)weaponByType != 0;
		}
		goto IL_03c7;
	}

	public virtual void SetFlipX(bool flip)
	{
		//IL_0235: Expected O, but got I4
		//IL_0076: Expected O, but got I
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_01a4: Expected O, but got I
		//IL_018f: Expected O, but got I
		//IL_01cc: Expected O, but got I4
		//IL_0029->IL01d5: Incompatible stack heights: 1 vs 0
		//IL_0061->IL01d5: Incompatible stack heights: 1 vs 0
		//IL_00da->IL01d5: Incompatible stack heights: 1 vs 0
		//IL_0106->IL01d5: Incompatible stack heights: 1 vs 0
		//IL_02a6->IL01d5: Incompatible stack heights: 2 vs 0
		//IL_013f->IL01d5: Incompatible stack heights: 2 vs 0
		//IL_02c5->IL01d5: Incompatible stack heights: 2 vs 0
		//IL_01d5->IL0251: Incompatible stack heights: 2 vs 1
		SpriteRenderer enemyRenderer = _EnemyRenderer;
		if ((object)_EnemyRenderer != null)
		{
			bool flag = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
			object obj = SpriteRenderer.get_flipX_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr);
			if ((nint)obj == (flip ? 1 : 0))
			{
				return;
			}
			if ((object)_EnemyRenderer != null)
			{
				_EnemyRenderer.flipX = flip;
				SpriteRenderer currentEnemyData = (SpriteRenderer)(object)_currentEnemyData;
				if (_currentEnemyData != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdi_v9 (UnityEngine.SpriteRenderer)+A8]");
					SpriteRenderer spriteRenderer = (SpriteRenderer)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdi_v9 (UnityEngine.SpriteRenderer)+A8]");
					if ((nint)0 == 0)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdi_v10 (UnityEngine.SpriteRenderer)+1C]");
					if ((nint)0 == 0)
					{
						return;
					}
					if ((object)_EnemyRenderer != null)
					{
						Sprite sprite = _EnemyRenderer.sprite;
						if ((object)sprite != null)
						{
							bool flag2 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
							EnemyData currentEnemyData2 = _currentEnemyData;
							if (_currentEnemyData != null)
							{
								ColliderOverride colliderOverride = currentEnemyData2._003CcolliderOverride_003Ek__BackingField;
								if (currentEnemyData2._003CcolliderOverride_003Ek__BackingField != null)
								{
									object obj3 = default(object);
									object obj2 = obj3 * colliderOverride._003Cradius_003Ek__BackingField;
									float num = (float)obj2 * 0.5f;
									object obj4;
									if (flip)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdi_v10 (UnityEngine.SpriteRenderer)+20]");
										obj4 = 0;
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rdi_v10 (UnityEngine.SpriteRenderer)+14]");
										obj4 = 0;
									}
									if (body != null)
									{
										float x = (float)obj4 + num;
										BaseBody baseBody = body.setOffset(x, (float?)(object)1);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public bool IsValid()
	{
		if (body != null)
		{
			return !_003CIsDead_003Ek__BackingField;
		}
		return false;
	}

	public override SpriteRenderer GetAttachedRenderer()
	{
		return _EnemyRenderer;
	}

	public void InitialiseLocalData(EnemyType enemyType)
	{
		//IL_019a: Expected O, but got I4
		//IL_01aa: Expected O, but got I4
		//IL_01ba: Expected O, but got I4
		//IL_01ca: Expected O, but got I4
		//IL_01da: Expected O, but got I4
		//IL_01ea: Expected O, but got I4
		//IL_0284: Expected I4, but got O
		FakeConstruct();
		_enemyType = enemyType;
		_currentJsonData = null;
		_currentEnemyData = null;
		if (GetEnemyDataForCurrentLevel(0) && _currentEnemyData != null)
		{
			EnemyData enemyData = _currentEnemyData;
			_hasInitializedData = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018765B0F4h\"");
			float num;
			if (enemyData._003CmaxSpeed_003Ek__BackingField == -1f)
			{
				num = enemyData._003Cspeed_003Ek__BackingField;
			}
			else
			{
				float value = UnityEngine.Random.value;
				EnemyData currentEnemyData = _currentEnemyData;
				float num2 = currentEnemyData._003CmaxSpeed_003Ek__BackingField - currentEnemyData._003Cspeed_003Ek__BackingField;
				float num3 = num2 * value;
				num = num3 + currentEnemyData._003Cspeed_003Ek__BackingField;
				enemyData = currentEnemyData;
			}
			_003CKnockBack_003Ek__BackingField = enemyData._003Cknockback_003Ek__BackingField;
			EnemyData currentEnemyData2 = _currentEnemyData;
			_003CSpeed_003Ek__BackingField = num;
			_defaultSpeed = num;
			float alpha = currentEnemyData2._003Calpha_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018765B168h\"");
			if (currentEnemyData2._003Calpha_003Ek__BackingField == -1f)
			{
				alpha = 1f;
			}
			_alpha = alpha;
			float num4 = default(float);
			float scaleMul = (((object)currentEnemyData2._003Cscale_003Ek__BackingField == null) ? 1f : num4);
			_scaleMul = scaleMul;
			_003CResFreeze_003Ek__BackingField = (float?)(object)1;
			_003CResRosary_003Ek__BackingField = (float?)(object)1;
			_003CResDebuffs_003Ek__BackingField = (float?)(object)1;
			_003CResDebuffs_003Ek__BackingField = (float?)(object)1;
			_003CResCorridor_003Ek__BackingField = (float?)(object)1;
			_003CResDefang_003Ek__BackingField = (float?)(object)1;
			EnemyData currentEnemyData3 = _currentEnemyData;
			bool flag = (object)currentEnemyData3._003Cweak_Fire_003Ek__BackingField == null;
			float num5 = 1f;
			if (!flag)
			{
				num5 = num4;
			}
			_003CWeakFire_003Ek__BackingField = num5;
			EnemyData currentEnemyData4 = _currentEnemyData;
			_passThroughWalls = currentEnemyData4._003CpassThroughWalls_003Ek__BackingField;
			EnemyData currentEnemyData5 = _currentEnemyData;
			uint saveTint = (((object)currentEnemyData5._003Ctint_003Ek__BackingField == null) ? 16777215u : ((uint)((object?)currentEnemyData5._003Ctint_003Ek__BackingField >> 32)));
			_saveTint = saveTint;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5F2A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			bool flag2 = _passThroughWalls;
			string layerName = "EnemiesPassThrough";
			if (!flag2)
			{
				layerName = "Enemies";
			}
			int layer = LayerMask.NameToLayer(layerName);
			Transform parent = base.transform;
			LayerHelper.SetLayerRecursively(parent, layer);
			InitSkills();
			CheckRenderer();
			EnemyData currentEnemyData6 = _currentEnemyData;
			Material material = MaterialManager.GetMaterial(currentEnemyData6._003CmaterialType_003Ek__BackingField);
			((Renderer)((ArcadeSprite)this)._spriteRenderer).SetMaterial(material);
		}
	}

	protected unsafe override void OnUpdate()
	{
		//IL_02bb: Expected F4, but got I4
		//IL_0259: Expected F4, but got I4
		//IL_0221: Expected O, but got F4
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_02ad: Expected F4, but got I4
		//IL_0b5f: Invalid comparison between O and F4
		//IL_0b7f: Invalid comparison between F4 and I4
		//IL_08b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b9: Expected O, but got Unknown
		//IL_0c70: Expected O, but got F4
		//IL_0bf3: Expected O, but got F4
		//IL_0944: Expected O, but got F4
		//IL_04d5: Expected I4, but got O
		//IL_04f1: Expected F4, but got I4
		//IL_09e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ed: Expected O, but got Unknown
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Expected O, but got Unknown
		//IL_0780: Expected I4, but got I8
		//IL_0a52->IL0c87: Incompatible stack heights: 2 vs 0
		//IL_0875->IL0b36: Incompatible stack heights: 3 vs 0
		if (_003CIsDead_003Ek__BackingField)
		{
			return;
		}
		UpdateDepth();
		if (_003CIsTimeStopped_003Ek__BackingField)
		{
			if (_003CIgnoreMovementFreezeFromTimeStop_003Ek__BackingField)
			{
				if (_003CConditionalCanMove_003Ek__BackingField)
				{
					RetargetIfNecessary();
					CalculateCurrentDirection();
					CalculateDirectionAndVelocity();
					goto IL_0977;
				}
				return;
			}
			if (_003CIsTimeStopped_003Ek__BackingField)
			{
				return;
			}
		}
		if (_003CConditionalCanMove_003Ek__BackingField)
		{
			RetargetIfNecessary();
			if (!_fixedDirection)
			{
				goto IL_017c;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018765B734h\"");
			bool flag = (object)_currentDirection != null;
			Transform transform = null;
			Vector2 vector = (Vector2)this;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018765B734h\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.EnemyController)+1E4]");
				bool flag2 = (nint)0 != 0;
				transform = null;
				vector = (Vector2)this;
				if (!flag2)
				{
					goto IL_017c;
				}
			}
			goto IL_023f;
		}
		float num = 0f;
		goto IL_0982;
		IL_0b36:
		if (!_003CConditionalCanMove_003Ek__BackingField)
		{
			return;
		}
		float num3;
		if (_receivingDamage)
		{
			float num2 = _003CKnockBack_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj = num2 ^ 0;
			num3 = (float)obj * _damageKb;
		}
		bool flag3 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref _currentDirection) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num);
		float num4 = (float)_currentDirection - num;
		bool flag4 = num4 == 0f;
		bool flag5 = !flag3;
		bool flag6 = !flag4;
		bool flag7 = flag6 & flag5;
		SetFlipX(flag7);
		float num5 = GameManager.EnemySpeed * _003CSpeed_003Ek__BackingField;
		float num7;
		float num6 = num5 / num7;
		float num8 = num6 * num3;
		float num9 = num8 * _003CSlow_003Ek__BackingField;
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		if ((object)CoherenceBridgeStore.masterBridge != null)
		{
			float num10;
			if (masterBridge.controlTimeScale)
			{
				num10 = 0.85f;
			}
			else
			{
				object obj2 = Time.timeScale;
				num10 = 0.85f / (float)_currentDirection;
			}
			float num11 = num10 * (float)_networkErrorVector;
			float num12 = num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.EnemyController)+E8]");
			float num13 = num12 * 0f;
			_errorVelocity = (Vector2)num11;
			float num14 = (float)_currentDirection * num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.EnemyController)+1E4]");
			float num15 = 0f * num9;
			float num16 = num11 + num14;
			float num17 = num13 + num15;
			BaseBody baseBody = body;
			if (body != null)
			{
				baseBody._velocity = (float2)num16;
				goto IL_0977;
			}
		}
		goto IL_094e;
		IL_0977:
		ProcessWiggle();
		return;
		IL_023f:
		bool flag8 = !_medusa;
		num = 0f;
		if (!flag8)
		{
			float medusaElapsed = _medusaElapsed + 0.05f;
			_medusaElapsed = medusaElapsed;
			float num18 = _medusaElapsed + 0.05f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			num = 0f;
		}
		goto IL_0982;
		IL_017c:
		object obj3 = default(object);
		object obj4 = default(object);
		if ((object)_targetTransform != null)
		{
			Vector3 vector2 = _targetTransform.position;
			Transform transform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Vector3 vector3 = _cachedTransform.position;
				float x = vector3.x;
				float num19 = (float)obj3 - (float)obj4;
				float num20 = vector2.x - vector3.x;
				_currentDirection = (Vector2)num20;
				Vector2 vector = (Vector2)(this + 480);
				((Vector2*)vector)->Normalize();
				goto IL_023f;
			}
		}
		goto IL_094e;
		IL_094e:
		throw new NullReferenceException();
		IL_0982:
		if (_selfDestruct && !_isSelfDestructionTriggered)
		{
			if ((object)_cachedTransform != null)
			{
				Vector3 vector4 = _cachedTransform.position;
				float num21 = (float)obj4 * 100f;
				float num22 = vector4.x * 100f;
				GameSessionData gameSessionData = _gameSessionData;
				if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
				{
					Transform transform2 = gameSessionData._activeCharacter.transform;
					if ((object)transform2 != null)
					{
						Vector3 vector5 = transform2.position;
						float num23 = (float)obj4 * 100f;
						float num24 = vector5.x * 100f;
						float num25 = num21 - num23;
						float num26 = num22 - num24;
						float num27 = num25 * num25;
						float num28 = num26 * num26;
						float num29 = num27 + num28;
						GameManager core = GM.Core;
						if ((object)GM.Core != null && core._multiplayer != null)
						{
							Vector3 value = default(Vector3);
							bool canPause;
							if (core._multiplayer.IsOnlineMultiplayer)
							{
								GameManager core2 = GM.Core;
								if ((object)GM.Core == null || (int)(~core2._characters) != 0)
								{
									goto IL_094e;
								}
								float num30 = 0f;
								List<CharacterController>.Enumerator characters = (List<CharacterController>.Enumerator)core2._characters;
								List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
								while (enumerator.MoveNext())
								{
									Transform transform3 = ((Component)null).transform;
									bool flag9 = (object)transform3 == null;
									bool flag10 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out value);
									characters = (List<CharacterController>.Enumerator)(obj3 * 100f);
									num30 = (float)value * 100f;
									float num31 = num21 - (float)characters;
									float num32 = num22 - num30;
									float num33 = num31 * num31;
									float x = num32 * num32;
									float num34 = num33 + x;
									if (!(num29 > num34))
									{
										object obj5 = num34 & -2147483649L;
										if ((nint)obj5 <= 2139095040)
										{
											continue;
										}
									}
									num29 = num34;
								}
								canPause = false;
							}
							else
							{
								canPause = false;
							}
							bool flag11 = !(_003CSelfDestDistance_003Ek__BackingField > num29);
							num7 = 100f;
							if (flag11)
							{
								goto IL_0cad;
							}
							if ((object)_AlertSpriteRenderer != null)
							{
								Transform target = _AlertSpriteRenderer.transform;
								_isSelfDestructionTriggered = true;
								if ((object)_AlertSpriteRenderer != null)
								{
									_AlertSpriteRenderer.forceRenderingOff = false;
									SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_AlertSpriteRenderer, 1f);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v893 @ rax_v66 (UnityEngine.Transform)+10]");
									bool flag12 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v893 @ rax_v66 (UnityEngine.Transform)+10]");
									Transform.set_localScale_Injected((IntPtr)0, ref value);
									Vector3 localPosition = _enemyRendererTransform.localPosition;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v893 @ rax_v66 (UnityEngine.Transform)+10]");
									bool flag13 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v893 @ rax_v66 (UnityEngine.Transform)+10]");
									float value2 = default(float);
									Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&value2));
									Tween alertTween = _alertTween;
									if (_alertTween != null && alertTween._003Cactive_003Ek__BackingField)
									{
										DG.Tweening.TweenExtensions.Kill(_alertTween);
									}
									Sequence alertTween2 = DOTween.Sequence();
									_alertTween = alertTween2;
									Sequence sequence = TweenSettingsExtensions.Insert(t: DOTweenModuleSprite.DOFade(_AlertSpriteRenderer, num, 0.2f), s: _alertTween, atPosition: num);
									Sequence sequence2 = TweenSettingsExtensions.Insert(t: ShortcutExtensions.DOScale(target, 0.9f, 0.2f), s: _alertTween, atPosition: num);
									Sequence alertTween3 = _alertTween;
									if (_alertTween != null && ((Tween)alertTween3)._003Cactive_003Ek__BackingField && !((Tween)alertTween3).creationLocked)
									{
										((Tween)alertTween3).loops = -1;
										((Tween)alertTween3).loopType = LoopType.Yoyo;
										if (((ABSSequentiable)alertTween3).tweenType == TweenType.Tweener)
										{
											((Tween)alertTween3).fullDuration = 1f / 0f;
										}
									}
									TweenCallback tweenCallback = delegate
									{
										//IL_003e: Expected O, but got I4
										Sequence alertTween5 = _alertTween;
										if (_alertTween != null)
										{
											float timeScale = alertTween5.timeScale * 1.1f;
											alertTween5.timeScale = timeScale;
											SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
											soundConfig.Volume = (float?)(object)1;
											soundConfig.Rate = 1f;
											float time = default(float);
											PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Alert, soundConfig, 250f, 3, time);
											return;
										}
										throw new NullReferenceException();
									};
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049DEC0");
									Sequence alertTween4 = _alertTween;
									bool flag14 = _alertTween == null;
									alertTween4.timeScale = 1f;
									Sequence sequence3 = VampireSurvivors.Tools.TweenExtensions.SetGameId(_alertTween);
									Action onComplete = OnSelfDestruct;
									bool useRealTime = default(bool);
									MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
									int repeat = default(int);
									TimerType type = default(TimerType);
									Timer selfDestructTimer = Timers.Register(2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause);
									_selfDestructTimer = selfDestructTimer;
									num3 = 1f;
									num7 = 100f;
									goto IL_0b36;
								}
							}
						}
					}
				}
			}
			goto IL_094e;
		}
		num7 = 100f;
		goto IL_0cad;
		IL_0cad:
		num3 = 1f;
		goto IL_0b36;
	}

	private static float GetCorrectionFactor()
	{
		//IL_005a: Expected O, but got F4
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		if (masterBridge.controlTimeScale)
		{
			return 0.85f;
		}
		object obj = Time.timeScale;
		float num = default(float);
		return 0.85f / num;
	}

	protected void RetargetIfNecessary()
	{
		Transform targetTransform = _targetTransform;
		if ((object)_targetTransform != null && ((UnityEngine.Object)targetTransform).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _targetTransform.gameObject;
			if (gameObject.activeInHierarchy)
			{
				return;
			}
		}
		TargetClosestPlayer();
	}

	public void TargetClosestPlayer()
	{
		float2 float5 = base.position;
		GameManager gameManager = _gameManager;
		CoopConfig coopConfig = gameManager.CoopConfig;
		bool inclusionMode = !coopConfig._spawningEnemiesTargetDeadPlayersAlso;
		bool includeFollowers = default(bool);
		CharacterController closestPlayer = _gameManager.GetClosestPlayer(float5, inclusionMode ? PlayerInclusionMode.AlivePreferred : PlayerInclusionMode.AliveOrDead, 3.4028235E+38f, includeFollowers);
		Transform targetTransform = closestPlayer.transform;
		_targetTransform = targetTransform;
	}

	protected unsafe virtual void CalculateCurrentDirection()
	{
		//IL_004b: Expected O, but got I4
		//IL_008b: Expected O, but got I4
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_0180->IL0125: Incompatible stack heights: 1 vs 0
		//IL_01f7->IL00d6: Incompatible stack heights: 2 vs 0
		if (!_fixedDirection)
		{
			goto IL_0099;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018765C596h\"");
		bool flag = (object)_currentDirection != null;
		Vector2 vector = (Vector2)this;
		Vector2 vector2 = (Vector2)0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018765C596h\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.EnemyController)+1E4]");
			bool flag2 = (nint)0 != 0;
			vector = (Vector2)this;
			vector2 = (Vector2)0;
			if (!flag2)
			{
				goto IL_0099;
			}
		}
		goto IL_00d6;
		IL_0099:
		Transform targetTransform = _targetTransform;
		if ((object)_targetTransform != null)
		{
			bool flag3 = ((UnityEngine.Object)targetTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)targetTransform).m_CachedPtr, out Vector3 ret);
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag4 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret2);
				vector2 = ret - ret2;
				object obj2 = default(object);
				object obj3 = default(object);
				object obj = obj2 - obj3;
				vector = (Vector2)(this + 480);
				_currentDirection = vector2;
				((Vector2*)vector)->Normalize();
				goto IL_00d6;
			}
		}
		throw new NullReferenceException();
		IL_00d6:
		if (_medusa)
		{
			float medusaElapsed = _medusaElapsed + 0.05f;
			_medusaElapsed = medusaElapsed;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		}
	}

	protected virtual void CalculateDirectionAndVelocity()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_004d: Expected O, but got F4
		float num2;
		if (_receivingDamage)
		{
			float num = _003CKnockBack_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj = num ^ 0;
			num2 = (float)obj * _damageKb;
		}
		else
		{
			num2 = 1f;
		}
		bool flag = (nint)_currentDirection < 0;
		bool flag2 = (object)_currentDirection == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		SetFlipX(flag5);
		float num3 = GameManager.EnemySpeed * _003CSpeed_003Ek__BackingField;
		float num4 = num3 / 100f;
		float num5 = num4 * num2;
		float num6 = num5 * _003CSlow_003Ek__BackingField;
		float num7 = (float)_currentDirection * num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.EnemyController)+1E4]");
		float num8 = 0f * num6;
		BaseBody baseBody = body;
		baseBody._velocity = (float2)num7;
	}

	public bool Freeze(float duration, float chance = 1f)
	{
		//IL_01fd: Invalid comparison between O and F4
		//IL_021b: Invalid comparison between F4 and I4
		//IL_0244: Expected O, but got I4
		//IL_026d: Expected O, but got I4
		//IL_01f5: Expected I4, but got O
		object obj = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)chance);
		float num = (float)obj - chance;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj2 = flag4 & flag3;
		object obj3 = (object?)_003CResFreeze_003Ek__BackingField & obj2;
		bool flag5 = obj3 == null;
		object obj4 = !flag5;
		if (obj4 == null && !_003CIsTimeStopped_003Ek__BackingField)
		{
			if (_freezeTimer != null)
			{
				_freezeTimer.Cancel();
			}
			Action onComplete = ResumeFromFreeze;
			float duration2 = duration * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer freezeTimer = Timers.Register(duration2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_freezeTimer = freezeTimer;
			BaseBody baseBody = body;
			_003CIsTimeStopped_003Ek__BackingField = true;
			_003CSpeed_003Ek__BackingField = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
			if (body != null)
			{
				float2 velocity = default(float2);
				baseBody._velocity = velocity;
				SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(_EnemyRenderer, 255u);
				EnemyData currentEnemyData = _currentEnemyData;
				if (_currentEnemyData != null)
				{
					if (currentEnemyData._003CidleFrameCount_003Ek__BackingField > 0 && _allowAnimationPauseResume)
					{
						SpriteAnimation spriteAnimation = _SpriteAnimation;
						if ((object)_SpriteAnimation == null)
						{
							goto IL_01e7;
						}
						((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = true;
					}
					return true;
				}
			}
			goto IL_01e7;
		}
		return false;
		IL_01e7:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool Freeze_WithoutTint(float duration, float chance = 1f)
	{
		//IL_01e4: Invalid comparison between O and F4
		//IL_0202: Invalid comparison between F4 and I4
		//IL_022b: Expected O, but got I4
		//IL_0254: Expected O, but got I4
		//IL_01dc: Expected I4, but got O
		object obj = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)chance);
		float num = (float)obj - chance;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj2 = flag4 & flag3;
		object obj3 = (object?)_003CResFreeze_003Ek__BackingField & obj2;
		bool flag5 = obj3 == null;
		object obj4 = !flag5;
		if (obj4 == null && !_003CIsTimeStopped_003Ek__BackingField)
		{
			if (_freezeTimer != null)
			{
				_freezeTimer.Cancel();
			}
			Action onComplete = ResumeFromFreeze;
			float duration2 = duration * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer freezeTimer = Timers.Register(duration2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_freezeTimer = freezeTimer;
			BaseBody baseBody = body;
			_003CIsTimeStopped_003Ek__BackingField = true;
			_003CSpeed_003Ek__BackingField = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
			if (body != null)
			{
				float2 velocity = default(float2);
				baseBody._velocity = velocity;
				EnemyData currentEnemyData = _currentEnemyData;
				if (_currentEnemyData != null)
				{
					if (currentEnemyData._003CidleFrameCount_003Ek__BackingField > 0 && _allowAnimationPauseResume)
					{
						SpriteAnimation spriteAnimation = _SpriteAnimation;
						if ((object)_SpriteAnimation == null)
						{
							goto IL_01ce;
						}
						((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = true;
					}
					return true;
				}
			}
			goto IL_01ce;
		}
		return false;
		IL_01ce:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void TimeStop(bool ignoreMovementFreezeFromTimeStop = false)
	{
		if (body != null)
		{
			_003CIgnoreMovementFreezeFromTimeStop_003Ek__BackingField = ignoreMovementFreezeFromTimeStop;
			if (!ignoreMovementFreezeFromTimeStop)
			{
				BaseBody baseBody = body;
				_003CSpeed_003Ek__BackingField = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
				float2 velocity = default(float2);
				baseBody._velocity = velocity;
			}
			if (_freezeTimer != null)
			{
				_freezeTimer.Cancel();
			}
			SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(_EnemyRenderer, 255u);
			EnemyData currentEnemyData = _currentEnemyData;
			_003CIsTimeStopped_003Ek__BackingField = true;
			if (currentEnemyData._003CidleFrameCount_003Ek__BackingField > 0 && _allowAnimationPauseResume)
			{
				SpriteAnimation spriteAnimation = _SpriteAnimation;
				((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = true;
			}
		}
	}

	public void ResumeFromTimeStop()
	{
		_003CSpeed_003Ek__BackingField = _defaultSpeed;
		_003CIsTimeStopped_003Ek__BackingField = false;
		RestoreTint();
		EnemyData currentEnemyData = _currentEnemyData;
		if (currentEnemyData._003CidleFrameCount_003Ek__BackingField > 0 && _allowAnimationPauseResume)
		{
			SpriteAnimation spriteAnimation = _SpriteAnimation;
			((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
		}
		InitWiggle();
	}

	public bool SlowEnemy(float duration, float chance = 1f, float slowAmount = 0.5f)
	{
		//IL_00fe: Invalid comparison between O and F4
		//IL_011c: Invalid comparison between F4 and I4
		//IL_0145: Expected O, but got I4
		//IL_016e: Expected O, but got I4
		object obj = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)chance);
		float num = (float)obj - chance;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj2 = flag4 & flag3;
		object obj3 = (object?)_003CResFreeze_003Ek__BackingField & obj2;
		bool flag5 = obj3 == null;
		object obj4 = !flag5;
		if (obj4 == null && !_003CIsTimeSlowed_003Ek__BackingField)
		{
			if (_slowedTimer != null)
			{
				_slowedTimer.Cancel();
			}
			Action onComplete = ResumeFromSlow;
			float duration2 = duration * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer slowedTimer = Timers.Register(duration2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_slowedTimer = slowedTimer;
			_003CSlow_003Ek__BackingField = slowAmount;
			return true;
		}
		return false;
	}

	public void ResumeFromSlow()
	{
		_003CIsTimeSlowed_003Ek__BackingField = false;
		_003CSlow_003Ek__BackingField = 1f;
	}

	public virtual void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_021f: Invalid comparison between F4 and I4
		//IL_028a: Invalid comparison between F4 and I4
		//IL_013e: Invalid comparison between I4 and F4
		//IL_00d0: Expected I, but got O
		//IL_0198: Expected I, but got O
		//IL_00f8->IL00f8: Incompatible stack heights: 1 vs 0
		//IL_01be->IL01be: Incompatible stack heights: 1 vs 0
		bool flag = !(_damageWeakness > 1f);
		float num = value;
		if (!flag)
		{
			num = value * _damageWeakness;
		}
		bool flag2 = _003CWeakFire_003Ek__BackingField == 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018765CF71h\"");
		HitVfxType hitVfxType = showHitVfx;
		if (!flag2)
		{
			WeaponType[] fireDamageTypes = FireDamageTypes;
			if (FireDamageTypes == null)
			{
				ArgumentNullException ex = new ArgumentNullException("array");
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507A40");
			object obj = default(object);
			bool flag3 = (nint)obj <= -1;
			hitVfxType = HitVfxType.None;
			if (!flag3)
			{
				num *= _003CWeakFire_003Ek__BackingField;
				hitVfxType = HitVfxType.None;
			}
		}
		Vector3 ret;
		if (num > 0f)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config._003CDamageNumbersEnabled_003Ek__BackingField)
			{
				nint num2 = (nint)_cachedTransform;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rdi_v11 (Il2CppMethodInfo)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rdi_v11 (Il2CppMethodInfo)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2990");
			}
		}
		if (!_003CIsDead_003Ek__BackingField && !(0f < (_hp -= num)))
		{
			Die();
		}
		if (_hp > 0f)
		{
			_damageKb = damageKb;
		}
		PlayHitSfx();
		if (showHitVfx != HitVfxType.None)
		{
			nint num3 = (nint)_cachedTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdi_v10 (Il2CppMethodInfo)+10]");
			bool flag5 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rdi_v10 (Il2CppMethodInfo)+10]");
			Transform.get_position_Injected((IntPtr)0, out ret);
			Vector2 worldPos = default(Vector2);
			VFXManager.SpawnImpactVFX(showHitVfx, worldPos);
		}
		bool hasKb2 = default(bool);
		OnGetDamaged(showHitVfx, hasKb2);
	}

	public virtual void GetDamagedSpecial(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true, Vector3? damagePosition = null)
	{
		//IL_01d9: Invalid comparison between F4 and I4
		//IL_00a4: Invalid comparison between I4 and F4
		//IL_0120: Expected I, but got O
		//IL_022b->IL012f: Incompatible stack heights: 1 vs 0
		bool flag = !(_damageWeakness > 1f);
		float num = value;
		if (!flag)
		{
			num = value * _damageWeakness;
		}
		bool flag2 = _003CWeakFire_003Ek__BackingField == 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018765D3D1h\"");
		if (!flag2)
		{
			WeaponType[] fireDamageTypes = FireDamageTypes;
			if (FireDamageTypes == null)
			{
				ArgumentNullException ex = new ArgumentNullException("array");
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507A40");
			object obj = default(object);
			if ((nint)obj > -1)
			{
				num *= _003CWeakFire_003Ek__BackingField;
			}
		}
		if (!_003CIsDead_003Ek__BackingField && !(0f < (_hp -= num)))
		{
			Die();
		}
		if (_hp > 0f)
		{
			_damageKb = damageKb;
		}
		PlayHitSfx();
		if (showHitVfx != HitVfxType.None)
		{
			object obj2 = default(object);
			if (obj2 == null)
			{
				nint num2 = (nint)_cachedTransform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rdi_v8 (Il2CppMethodInfo)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rdi_v8 (Il2CppMethodInfo)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			}
			Vector2 worldPos = default(Vector2);
			VFXManager.SpawnImpactVFX(showHitVfx, worldPos);
		}
		bool hasKb2 = default(bool);
		OnGetDamaged(showHitVfx, hasKb2);
	}

	public unsafe void PlayVFXFlash(HitVfxType showHitVfx)
	{
		//IL_00be: Expected O, but got I4
		//IL_00a9: Expected O, but got Ref
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CFlashingVFXEnabled_003Ek__BackingField && showHitVfx != HitVfxType.None)
		{
			HitVFXData data = VFXManager.GetData(showHitVfx);
			if (!data.HasTintFill)
			{
				Color? color = default(Color?);
				RenderingExtensions.SetTint(_EnemyRenderer, (Color?)(object)(&color));
			}
			else
			{
				SetTintFill(isEnabled: true, (HitVfxType?)(object)1);
			}
		}
		float num = ((!_003CIsDead_003Ek__BackingField) ? 120f : 60f);
		Action onComplete = RestoreTint;
		float duration = num * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer blinkTimeout = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_blinkTimeout = blinkTimeout;
	}

	public virtual void OnGetDamaged(HitVfxType showHitVfx, bool hasKb = true)
	{
		PlayVFXFlash(showHitVfx);
		_receivingDamage = hasKb;
	}

	public bool IsUnitDead()
	{
		return _003CIsDead_003Ek__BackingField;
	}

	public float MaxHp()
	{
		return _maxHp;
	}

	public float CurrentHealth()
	{
		return _hp;
	}

	public void ChangeMaxHealth(float maxHP)
	{
		float num = _hp / _maxHp;
		_maxHp = maxHP;
		float hp = num * maxHP;
		_hp = hp;
	}

	public void RandomizeCurrentHp(float min = 0.1f)
	{
		float hp = UnityEngine.Random.Range(min, _maxHp);
		_hp = hp;
	}

	public void SetHealth(float health)
	{
		//IL_004f: Invalid comparison between I4 and F4
		_hp = health;
		if (health > _maxHp)
		{
			_hp = _maxHp;
		}
		if (!(0f < _hp))
		{
			Die();
		}
	}

	public void Kill()
	{
		//IL_0016: Invalid comparison between I4 and F4
		//IL_0051: Invalid comparison between I4 and F4
		_hp = 0f;
		if (0f > _maxHp)
		{
			_hp = _maxHp;
		}
		if (!(0f < _hp))
		{
			Die();
		}
	}

	public virtual void OnMusicBeat()
	{
	}

	protected unsafe virtual void OnRecycleEnemy()
	{
		//IL_0008: Expected O, but got Ref
		//IL_03c0: Expected O, but got I4
		//IL_01e4: Expected O, but got I
		//IL_0460: Invalid comparison between F4 and I4
		//IL_063b: Expected O, but got I4
		//IL_04af: Expected O, but got I4
		//IL_04c6: Expected O, but got I4
		//IL_0502: Invalid comparison between F4 and I4
		//IL_0b6b: Expected O, but got Ref
		//IL_06bc: Expected O, but got I
		//IL_06bc: Expected O, but got I
		//IL_0aed: Expected O, but got I
		//IL_0b03: Expected O, but got I
		//IL_0562: Expected O, but got I
		//IL_0c1e: Expected O, but got Ref
		//IL_0595: Expected O, but got I
		//IL_0712: Expected O, but got I
		//IL_05f6: Invalid comparison between F4 and I
		//IL_0c78: Expected O, but got I
		//IL_0ca9: Expected I, but got O
		//IL_080c: Expected O, but got I
		//IL_080c: Expected O, but got I
		//IL_0d23: Expected O, but got Ref
		//IL_08f2: Expected O, but got I
		//IL_0d96: Expected O, but got Ref
		//IL_0e3a: Expected O, but got Ref
		//IL_0be1->IL094f: Incompatible stack heights: 1 vs 0
		//IL_06ee->IL094f: Incompatible stack heights: 1 vs 0
		//IL_0c4a->IL094f: Incompatible stack heights: 2 vs 0
		//IL_05b5->IL094f: Incompatible stack heights: 1 vs 0
		//IL_0743->IL094f: Incompatible stack heights: 2 vs 0
		//IL_0608->IL062b: Incompatible stack heights: 1 vs 0
		//IL_0c96->IL094f: Incompatible stack heights: 2 vs 0
		//IL_07df->IL094f: Incompatible stack heights: 2 vs 0
		//IL_062b->IL062b: Incompatible stack heights: 1 vs 0
		//IL_0834->IL094f: Incompatible stack heights: 2 vs 0
		//IL_0863->IL094f: Incompatible stack heights: 2 vs 0
		//IL_0d5c->IL094f: Incompatible stack heights: 4 vs 0
		//IL_08be->IL094f: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		bool flag = _selfDestructTimer == null;
		_003CConditionalCanMove_003Ek__BackingField = true;
		_damageWeakness = 1f;
		if (!flag)
		{
			_selfDestructTimer.Cancel();
			if ((object)_AlertSpriteRenderer == null)
			{
				goto IL_094f;
			}
			_AlertSpriteRenderer.forceRenderingOff = true;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_AlertSpriteRenderer, 1f);
			_isSelfDestructionTriggered = false;
		}
		EnemyData currentEnemyData = _currentEnemyData;
		_canBeDamagedByBloodline = true;
		_receivingDamage = false;
		_damageKb = 1f;
		SpriteRenderer spriteRenderer2;
		if (_currentEnemyData != null)
		{
			GameSessionData gameSessionData = _gameSessionData;
			if (_gameSessionData != null && (object)gameSessionData._activeCharacter != null)
			{
				float num = gameSessionData._activeCharacter.PCurse();
				GameManager gameManager = _gameManager;
				if ((object)_gameManager != null)
				{
					Stage stage = gameManager._stage;
					if ((object)gameManager._stage != null)
					{
						bool flag2 = !_hpXLevel;
						float num2 = GameManager.EnemyHealthMultiplier * currentEnemyData._003CmaxHp_003Ek__BackingField;
						float num3 = num2 * GameManager.DifficultyAdjustmentEnemyHPMultiplier;
						object obj3 = default(object);
						float num4 = num3 * (float)obj3;
						float maxHp = num4 * stage._003CEnemyHealthMultiplier_003Ek__BackingField;
						_maxHp = maxHp;
						if (flag2)
						{
							goto IL_09b9;
						}
						GameSessionData gameSessionData2 = _gameSessionData;
						if (_gameSessionData != null)
						{
							SpriteRenderer activeCharacter = (SpriteRenderer)(object)gameSessionData2._activeCharacter;
							if ((object)gameSessionData2._activeCharacter != null)
							{
								EnemyData currentEnemyData2 = _currentEnemyData;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rbx_v15 (UnityEngine.SpriteRenderer)+22C]");
								spriteRenderer2 = (SpriteRenderer)0;
								if (_currentEnemyData != null)
								{
									if ((object)currentEnemyData2._003CminimumHpScalingLevel_003Ek__BackingField != null)
									{
										if ((object)currentEnemyData2._003CminimumHpScalingLevel_003Ek__BackingField == null)
										{
											goto IL_0a04;
										}
										SpriteRenderer spriteRenderer3 = (SpriteRenderer)((object?)currentEnemyData2._003CminimumHpScalingLevel_003Ek__BackingField >> 32);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rbx_v15 (UnityEngine.SpriteRenderer)+22C]");
										if (0 <= (nint)spriteRenderer3)
										{
											spriteRenderer2 = spriteRenderer3;
										}
									}
									EnemyData currentEnemyData3 = _currentEnemyData;
									if (_currentEnemyData != null)
									{
										if ((object)currentEnemyData3._003CmaximumHpScalingLevel_003Ek__BackingField != null)
										{
											if ((object)currentEnemyData3._003CmaximumHpScalingLevel_003Ek__BackingField == null)
											{
												goto IL_0a04;
											}
											SpriteRenderer spriteRenderer4 = (SpriteRenderer)((object?)currentEnemyData3._003CmaximumHpScalingLevel_003Ek__BackingField >> 32);
											if (System.Runtime.CompilerServices.Unsafe.As<SpriteRenderer, UIntPtr>(ref spriteRenderer2) >= System.Runtime.CompilerServices.Unsafe.As<SpriteRenderer, UIntPtr>(ref spriteRenderer4))
											{
												spriteRenderer2 = spriteRenderer4;
											}
										}
										goto IL_0a0a;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_094f;
		IL_09b9:
		if (_fixedDirection || _medusa)
		{
			_currentDirection = (Vector2)0;
		}
		_hp = _maxHp;
		_003CSpeed_003Ek__BackingField = _defaultSpeed;
		_003CIsDefanged_003Ek__BackingField = false;
		_003CSlow_003Ek__BackingField = 1f;
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			GameSessionData gameSessionData3 = core._gameSessionData;
			if (core._gameSessionData != null)
			{
				CharacterController activeCharacter2 = gameSessionData3._activeCharacter;
				if ((object)gameSessionData3._activeCharacter != null)
				{
					PlayerModifierStats playerStats = activeCharacter2._playerStats;
					if (activeCharacter2._playerStats != null)
					{
						bool flag3 = playerStats._003CDefang_003Ek__BackingField == 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018765DDDFh\"");
						if (!flag3)
						{
							_ = _003CResDefang_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+6B]");
							bool flag4 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018765DDFBh\"");
							float? num5 = (float?)(object)1;
							if (!flag4)
							{
								num5 = (float?)(object)0;
							}
							object obj4 = (object?)num5 & (object?)_003CResDefang_003Ek__BackingField;
							if (obj4 != null)
							{
								EnemyData currentEnemyData4 = _currentEnemyData;
								if (_currentEnemyData != null)
								{
									if (!(currentEnemyData4._003Cspeed_003Ek__BackingField > 0f))
									{
										goto IL_062b;
									}
									Sprite core2 = (Sprite)(object)GM.Core;
									if ((object)GM.Core != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rsi_v15 (UnityEngine.Sprite)+180]");
										object obj5 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rsi_v15 (UnityEngine.Sprite)+178]");
										object obj6 = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rsi_v15 (UnityEngine.Sprite)+180]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rsi_v15 (UnityEngine.Sprite)+178]");
											nint num6 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ r8_v19+18]");
											object obj7 = num6 % 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ r8_v19+18]");
											bool flag5 = (nint)obj7 >= 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ r8_v19+10]");
											object obj8 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ r8_v19+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rcx_v65+18]");
												if ((nint)obj7 < 0)
												{
													float num7 = playerStats._003CDefang_003Ek__BackingField;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ rcx_v65+20+v244 @ rdx_v33*4]");
													if (num7 > 0f)
													{
														bool flag6 = DoDefang();
													}
													goto IL_062b;
												}
												throw new IndexOutOfRangeException();
											}
										}
									}
								}
								goto IL_094f;
							}
						}
						goto IL_062b;
					}
				}
			}
		}
		goto IL_094f;
		IL_0a0a:
		EnemyData currentEnemyData5 = _currentEnemyData;
		if (_currentEnemyData != null)
		{
			GameManager gameManager2 = _gameManager;
			if ((object)_gameManager != null)
			{
				Stage stage2 = gameManager2._stage;
				if ((object)gameManager2._stage != null)
				{
					float num8 = (float)spriteRenderer2 * currentEnemyData5._003CmaxHp_003Ek__BackingField;
					float num9 = num8 * GameManager.EnemyHealthMultiplier;
					float num10 = num9 * GameManager.DifficultyAdjustmentEnemyHPMultiplier;
					float maxHp2 = num10 * stage2._003CEnemyHealthMultiplier_003Ek__BackingField;
					_maxHp = maxHp2;
					goto IL_09b9;
				}
			}
		}
		goto IL_094f;
		IL_062b:
		ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)0);
		if ((object)_EnemyRenderer != null)
		{
			Sprite sprite = _EnemyRenderer.sprite;
			if ((object)sprite != null)
			{
				_ = 0;
				bool flag7 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
				object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)obj9);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-11]");
				float num11 = 0f * 0.4f;
				_ = 0;
				_ = 0;
				_ = 1;
				_ = 1;
				float num12 = num11 * 0.5f;
				if (body != null)
				{
					BaseBody baseBody = body;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
					nint num13 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
					BaseBody baseBody2 = baseBody.setCircle(num11, (float?)(object)num13, (float?)(object)0);
					Sprite cachedTransform = (Sprite)(object)_cachedTransform;
					BaseBody baseBody3 = body;
					if ((object)_cachedTransform != null)
					{
						_ = 0;
						_ = 0;
						bool flag8 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
						object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)obj10);
						if (body != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
							baseBody3._position = (float2)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-25]");
							_ = 0;
							EnemyData currentEnemyData6 = _currentEnemyData;
							if (_currentEnemyData != null)
							{
								if (currentEnemyData6._003CcolliderOverride_003Ek__BackingField == null)
								{
									goto IL_0c4f;
								}
								ColliderOverride colliderOverride = currentEnemyData6._003CcolliderOverride_003Ek__BackingField;
								_ = 0;
								_ = 0;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-11]");
								float num14 = 0f * colliderOverride._003Cradius_003Ek__BackingField;
								_ = 1;
								float num15 = num14 * 0.5f;
								if (body != null)
								{
									BaseBody baseBody4 = body;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
									nint num16 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
									BaseBody baseBody5 = baseBody4.setCircle(num14, (float?)(object)num16, (float?)(object)0);
									EnemyData currentEnemyData7 = _currentEnemyData;
									if (_currentEnemyData != null)
									{
										ColliderOverride colliderOverride2 = currentEnemyData7._003CcolliderOverride_003Ek__BackingField;
										if (currentEnemyData7._003CcolliderOverride_003Ek__BackingField != null)
										{
											EnemyData currentEnemyData8 = _currentEnemyData;
											_ = 0;
											_ = 1;
											ColliderOverride colliderOverride3 = currentEnemyData8._003CcolliderOverride_003Ek__BackingField;
											float num17 = num15 + colliderOverride3._003CoffsetY_003Ek__BackingField;
											if (body != null)
											{
												float x = num15 + colliderOverride2._003CoffsetX_003Ek__BackingField;
												BaseBody baseBody6 = body;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
												BaseBody baseBody7 = baseBody6.setOffset(x, (float?)(object)0);
												goto IL_0c4f;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_094f;
		IL_0a04:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		goto IL_0a0a;
		IL_0c4f:
		_ = 0;
		_ = 1065353216;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+67]");
		ArcadeSprite arcadeSprite2 = setOrigin(0.5f, (float?)(object)0);
		if ((object)_SpriteAnimation != null)
		{
			_SpriteAnimation.SetAnimation("idle");
			object cachedTransform2 = _cachedTransform;
			nint num18 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1914 @ rax_v50 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num19 = 0;
			_ = Vector3.oneVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1915 @ rcx_v35 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			float num20 = 0f * _scaleMul;
			bool flag9 = (object)_cachedTransform == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1185 @ rbx_v11 (System.Object)+10]");
			bool flag10 = (nint)0 == 0;
			object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1185 @ rbx_v11 (System.Object)+10]");
			Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj11);
			object enemyRenderer = _EnemyRenderer;
			if ((object)_EnemyRenderer != null)
			{
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rbx_v12 (System.Object)+10]");
				bool flag11 = (nint)0 == 0;
				object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rbx_v12 (System.Object)+10]");
				SpriteRenderer.get_color_Injected((IntPtr)0, out *(Color*)obj12);
				object enemyRenderer2 = _EnemyRenderer;
				_ = _alpha;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-11]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-15]");
				_ = 0;
				bool flag12 = (object)_EnemyRenderer == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1457 @ rbx_v13 (System.Object)+10]");
				bool flag13 = (nint)0 == 0;
				object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1457 @ rbx_v13 (System.Object)+10]");
				SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)obj13);
				RestoreTint();
				InitWiggle();
				currentDepthEnemy = -1;
				_003CIsBoss_003Ek__BackingField = false;
				return;
			}
		}
		goto IL_094f;
		IL_094f:
		throw new NullReferenceException();
	}

	protected virtual void InitWiggle()
	{
		//IL_003d: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0165: Invalid comparison between I4 and F4
		//IL_009e: Expected O, but got I8
		//IL_00dc: Expected O, but got I8
		Component enemyRenderer = _EnemyRenderer;
		Transform enemyRendererTransform = _EnemyRenderer.transform;
		_enemyRendererTransform = enemyRendererTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			enemyRenderer = (Component)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v133 @ rax_v11 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		_wiggleProgress = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
			enemyRenderer = (Component)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v166 @ rax_v14 (should have been resolved before IL gen)");
		bool flag = 0f < 0.5f;
		_wiggleInit = false;
		bool wiggleForward = !flag;
		_wiggleForward = wiggleForward;
	}

	protected virtual void ProcessWiggle()
	{
		//IL_00fa: Expected F4, but got O
		//IL_005d: Invalid comparison between I4 and F4
		//IL_01f8: Expected F4, but got O
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected F4, but got Unknown
		//IL_0153->IL00bd: Incompatible stack heights: 2 vs 0
		Quaternion a = default(Quaternion);
		Quaternion b = default(Quaternion);
		object obj = default(object);
		Quaternion ret;
		Quaternion value = default(Quaternion);
		if (_wiggleInit)
		{
			Transform transform = base.transform;
			Quaternion.Lerp_Injected(ref a, ref b, (float)obj, out ret);
			bool flag = (object)transform == null;
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.set_localRotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			_wiggleInit = true;
		}
		float deltaTime = PauseSystem.DeltaTime;
		float num = ((!_wiggleForward) ? (-1f) : 1f);
		float num2 = deltaTime * num;
		float num3 = num2 * 1.5f;
		float num4 = (_wiggleProgress = num3 + _wiggleProgress);
		float wiggleProgress;
		if (!(num4 > 1f))
		{
			if (!(0f > num4))
			{
				goto IL_01aa;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			wiggleProgress = num4 ^ 0;
		}
		else
		{
			float num5 = num4 - 1f;
			wiggleProgress = 1f - num5;
		}
		bool wiggleForward = !_wiggleForward;
		_wiggleProgress = wiggleProgress;
		_wiggleForward = wiggleForward;
		goto IL_01aa;
		IL_01aa:
		Transform transform2 = base.transform;
		Quaternion.Lerp_Injected(ref a, ref value, (float)obj, out ret);
		bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Transform.set_localRotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref b);
	}

	protected void FireKilledSignal()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0066: Expected I, but got O
		//IL_0082: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	protected void OnSelfDestruct()
	{
		//IL_0130: Expected F4, but got I4
		//IL_0130: Expected F4, but got I4
		//IL_0197->IL013b: Incompatible stack heights: 1 vs 0
		//IL_00e5->IL013b: Incompatible stack heights: 1 vs 0
		//IL_0107->IL013b: Incompatible stack heights: 1 vs 0
		//IL_013b->IL0142: Incompatible stack heights: 1 vs 0
		if (_003CIsDead_003Ek__BackingField)
		{
			return;
		}
		if ((object)_AlertSpriteRenderer != null)
		{
			_AlertSpriteRenderer.forceRenderingOff = true;
			if (_alertTween != null)
			{
				DG.Tweening.TweenExtensions.Kill(_alertTween);
				_alertTween = null;
			}
			Transform cachedTransform = _cachedTransform;
			GameManager gameManager = _gameManager;
			if ((object)_cachedTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
				EnemyData currentEnemyData = _currentEnemyData;
				if (_currentEnemyData != null && (object)_gameManager != null && gameManager._explosionManager != null)
				{
					Vector2 spawnPos = default(Vector2);
					gameManager._explosionManager.SpawnExplosion(spawnPos, currentEnemyData._003CmoreX_003Ek__BackingField, currentEnemyData._003CmoreY_003Ek__BackingField);
					Disappear();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void UpdateScale()
	{
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
	}

	private void UpdateAlpha()
	{
		SpriteRenderer enemyRenderer = _EnemyRenderer;
		bool flag = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
		SpriteRenderer.get_color_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr, out Color _);
		EnemyController enemyRenderer2 = (EnemyController)(object)_EnemyRenderer;
		bool flag2 = (object)_EnemyRenderer == null;
		bool flag3 = ((UnityEngine.Object)enemyRenderer2).m_CachedPtr == (IntPtr)0;
		Color value = default(Color);
		SpriteRenderer.set_color_Injected(((UnityEngine.Object)enemyRenderer2).m_CachedPtr, ref value);
	}

	private void DetectMisprediction(object sampleData, bool stopped, long simulationFrame)
	{
		//IL_0034: Expected I, but got O
		//IL_0059: Expected I, but got O
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00d3: Invalid comparison between F4 and O
		//IL_00a6->IL00f6: Incompatible stack heights: 1 vs 0
		//IL_018d->IL010b: Incompatible stack heights: 2 vs 0
		//IL_00e2->IL010b: Incompatible stack heights: 2 vs 0
		//IL_01a7->IL010b: Incompatible stack heights: 2 vs 0
		if (stopped || _003CIgnoreNetworkError_003Ek__BackingField != stopped)
		{
			return;
		}
		nint num = (nint)typeof(Vector3);
		if (sampleData != null)
		{
			nint num2 = (nint)sampleData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rcx_v11 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdx_v2 (Il2CppClass<UnityEngine.Vector3>)+40]");
			bool flag = num3 != 0;
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v13 (UnityEngine.Transform)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v13 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [sampleData @ rdx (System.Object)+10]");
				Vector2 networkErrorVector = (Vector2)(0 - ret);
				object obj2 = default(object);
				object obj3 = default(object);
				object obj = obj2 - obj3;
				bool flag3 = !_003CIsTeleportOnCull_003Ek__BackingField;
				_networkErrorVector = networkErrorVector;
				if (!flag3)
				{
					object obj4 = this + 228;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)3f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
					{
						float2 float5 = default(float2);
						base.position = float5;
						_networkErrorVector = Vector3.zeroVector;
					}
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void SnapPosition(Vector3 networkPosition)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_003d: Invalid comparison between F4 and O
		if (_003CIsTeleportOnCull_003Ek__BackingField)
		{
			object obj = this + 228;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
			object obj2 = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)3f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				float2 float5 = default(float2);
				base.position = float5;
				_networkErrorVector = Vector3.zeroVector;
			}
		}
	}

	protected void DealDamage(float damage)
	{
		//IL_0046: Invalid comparison between I4 and F4
		if (!_003CIsDead_003Ek__BackingField && !(0f < (_hp -= damage)))
		{
			Die();
		}
	}

	private void InitLayer()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5F2A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = _passThroughWalls;
		string layerName = "EnemiesPassThrough";
		if (!flag)
		{
			layerName = "Enemies";
		}
		int layer = LayerMask.NameToLayer(layerName);
		Transform parent = base.transform;
		LayerHelper.SetLayerRecursively(parent, layer);
	}

	private unsafe void InitSkills()
	{
		//IL_0207: Expected O, but got F4
		//IL_019b: Expected O, but got Ref
		EnemyData currentEnemyData = _currentEnemyData;
		_hpXLevel = false;
		_medusa = false;
		_selfDestruct = false;
		if (currentEnemyData._003Cskills_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2A70");
			object obj = default(object);
			if (obj != null)
			{
				_hpXLevel = true;
			}
			EnemyData currentEnemyData2 = _currentEnemyData;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2A70");
			object obj2 = default(object);
			if (obj2 != null)
			{
				_fixedDirection = true;
			}
			EnemyData currentEnemyData3 = _currentEnemyData;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2A70");
			object obj3 = default(object);
			if (obj3 != null)
			{
				_medusa = true;
				object obj4 = UnityEngine.Random.value;
				float medusaElapsed = medusaElapsed + medusaElapsed;
				_medusaElapsed = medusaElapsed;
			}
			EnemyData currentEnemyData4 = _currentEnemyData;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2A70");
			object obj5 = default(object);
			if (obj5 != null)
			{
				_selfDestruct = true;
				Sprite sprite = SpriteManager.GetSprite("sPFX_ring_64", "vfx");
				_AlertSpriteRenderer.sprite = sprite;
				_AlertSpriteRenderer.forceRenderingOff = true;
				Material material = ((Renderer)_AlertSpriteRenderer).GetMaterial();
				material.SetFloatImpl(ApplyTintFill, 1f);
				Material material2 = ((Renderer)_AlertSpriteRenderer).GetMaterial();
				object obj6 = default(object);
				material2.SetColor(TintFillColor, (Color)(&obj6));
			}
		}
	}

	private unsafe bool GetEnemyDataForCurrentLevel(int level)
	{
		//IL_01b1: Expected O, but got I
		//IL_0211: Expected O, but got I
		//IL_02c3: Expected I, but got O
		//IL_02d3: Expected O, but got I
		//IL_0303: Expected I, but got O
		//IL_035c: Expected I, but got O
		//IL_0407: Expected O, but got Ref
		//IL_0414: Expected I, but got O
		//IL_0454: Expected I, but got O
		//IL_0485: Expected I, but got O
		//IL_04ae: Expected I, but got O
		//IL_04d3: Expected O, but got I
		//IL_04ec: Expected I, but got O
		//IL_050a: Expected O, but got I
		//IL_052b: Expected I, but got O
		//IL_0576: Expected O, but got I
		//IL_07b3: Expected I, but got O
		//IL_07e2: Expected I, but got O
		//IL_05ad: Expected O, but got I
		//IL_0807: Expected O, but got I
		//IL_0828: Expected I, but got O
		//IL_0854: Expected I4, but got O
		//IL_060f: Expected O, but got I
		//IL_08a3: Expected O, but got I
		//IL_08b4: Expected O, but got I4
		//IL_08be: Expected I, but got O
		//IL_068d: Expected I, but got O
		//IL_06bc: Expected I, but got O
		//IL_0655: Expected O, but got I
		//IL_06e1: Expected O, but got I
		//IL_070c: Expected I, but got O
		//IL_076e: Expected I, but got O
		//IL_0795: Expected O, but got I
		//IL_079e: Expected O, but got I4
		//IL_07a6: Expected I, but got O
		DataManager dataManager = _dataManager;
		if (_dataManager != null)
		{
			bool flag = dataManager._003CAllEnemies_003Ek__BackingField == null;
			if (!flag)
			{
				int num = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllEnemies_003Ek__BackingField).FindEntry((System.Int32Enum)_enemyType);
				if (flag)
				{
					goto IL_094f;
				}
				DataManager dataManager2 = _dataManager;
				if (_dataManager != null && dataManager2._003CAllEnemies_003Ek__BackingField != null)
				{
					object obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllEnemies_003Ek__BackingField).get_Item((System.Int32Enum)_enemyType);
					if (obj != null)
					{
						int count = ((JContainer)obj).Count;
						if (level >= count)
						{
							goto IL_094f;
						}
						if (_dataManager != null)
						{
							Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = _dataManager.GetConvertedEnemyData();
							if (convertedEnemyData != null)
							{
								object obj2 = ((Dictionary<System.Int32Enum, object>)(object)convertedEnemyData).get_Item((System.Int32Enum)_enemyType);
								if (obj2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v47 (System.Object)+18]");
									if ((nint)level >= (nint)0)
									{
										System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
										bool result = default(bool);
										return result;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v47 (System.Object)+10]");
									object obj3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v47 (System.Object)+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rax_v48+18]");
										if ((nint)level >= (nint)0)
										{
											throw new IndexOutOfRangeException();
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rax_v48+20+level @ rdx (System.Int32)*8]");
										_currentEnemyData = (EnemyData)0;
										if (_currentEnemyData != null)
										{
											goto IL_0941;
										}
										DataManager dataManager3 = _dataManager;
										if (_dataManager != null && dataManager3._003CAllEnemies_003Ek__BackingField != null)
										{
											object obj4 = ((Dictionary<System.Int32Enum, object>)(object)dataManager3._003CAllEnemies_003Ek__BackingField).get_Item((System.Int32Enum)_enemyType);
											if (obj4 != null)
											{
												nint num2 = (nint)obj4;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1253 @ r8_v27 (Il2CppClass<System.Object>)+678]");
												object obj5 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1253 @ r8_v27 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
												IEnumerable<JToken> enumerable = default(IEnumerable<JToken>);
												if (enumerable != null)
												{
													nint num3 = (nint)enumerable;
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1254 @ rdx_v28 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Newtonsoft.Json.Linq.JToken>>)+238] (should have been resolved before IL gen)");
													object obj6 = default(object);
													if (obj6 != null)
													{
														object obj7 = Newtonsoft.Json.Linq.Extensions.Value<object>(enumerable);
														if (obj7 != null)
														{
															nint num4 = (nint)obj7;
															Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1255 @ rdx_v31 (Il2CppClass<System.Object>)+238] (should have been resolved before IL gen)");
															object obj8 = default(object);
															if (obj8 != null)
															{
																if (_currentJsonData != null && _currentJsonData.HasValues)
																{
																	IEnumerable<JProperty> enumerable2 = ((JObject)obj7).Properties();
																	if (enumerable2 == null)
																	{
																		goto IL_095d;
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
																	object obj10 = default(object);
																	object obj9 = (object)(&obj10);
																	object obj11 = obj7;
																	nint num5 = unchecked((nint)null);
																	object obj12 = default(object);
																	object obj13 = default(object);
																	object obj16 = default(object);
																	object obj19 = default(object);
																	float num6 = default(float);
																	object obj21 = default(object);
																	object obj22 = default(object);
																	while (true)
																	{
																		if (obj10 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
																			if (obj12 == null)
																			{
																				break;
																			}
																			bool flag2 = obj10 == null;
																			num5 = unchecked((nint)null);
																			if (!flag2)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2430");
																				bool flag3 = obj13 == null;
																				num5 = (nint)_currentJsonData;
																				if (!flag3)
																				{
																					bool flag4 = _currentJsonData == null;
																					num5 = (nint)_currentJsonData;
																					if (!flag4)
																					{
																						JObject currentJsonData = _currentJsonData;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v72+60]");
																						bool flag5 = currentJsonData.ContainsKey((string)0);
																						bool flag6 = !flag5;
																						num5 = (nint)_currentJsonData;
																						if (flag6)
																						{
																							continue;
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v72+58]");
																						object obj14 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v72+58]");
																						bool flag7 = (nint)0 == 0;
																						num5 = (nint)_currentJsonData;
																						if (!flag7)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v925 @ rax_v74+10]");
																							num5 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v925 @ rax_v74+10]");
																							if ((nint)0 != 0)
																							{
																								object obj15 = num5;
																								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1389 @ rdx_v45+228] (should have been resolved before IL gen)");
																								if ((nint)obj16 != 6)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v72+58]");
																									object obj17 = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v72+58]");
																									if ((nint)0 == 0)
																									{
																										throw new NullReferenceException();
																									}
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ rax_v86+10]");
																									num5 = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ rax_v86+10]");
																									if ((nint)0 == 0)
																									{
																										throw new NullReferenceException();
																									}
																									object obj18 = num5;
																									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1407 @ rdx_v51+228] (should have been resolved before IL gen)");
																									JObject currentJsonData2;
																									JToken value;
																									if ((nint)obj19 != 7)
																									{
																										currentJsonData2 = _currentJsonData;
																										object obj20 = obj11;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v72+60]");
																										value = ((JObject)obj20).get_Item((string)0);
																										if (_currentJsonData == null)
																										{
																											throw new NullReferenceException();
																										}
																										num6 = num6;
																									}
																									else
																									{
																										nint num7 = (nint)enumerable;
																										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1423 @ r8_v45 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Newtonsoft.Json.Linq.JToken>>)+248] (should have been resolved before IL gen)");
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAECF0");
																										bool flag8 = _currentJsonData == null;
																										num5 = (nint)_currentJsonData;
																										if (flag8)
																										{
																											throw new NullReferenceException();
																										}
																										JObject currentJsonData3 = _currentJsonData;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v72+60]");
																										JToken jToken = currentJsonData3.get_Item((string)0);
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAECF0");
																										currentJsonData2 = _currentJsonData;
																										nint num8 = (nint)typeof(JToken);
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rcx_v61 (Il2CppClass<Newtonsoft.Json.Linq.JToken>)+E4]");
																										bool flag9 = (nint)0 != 0;
																										float num9 = num6 + num6;
																										value = num9;
																										bool flag10 = _currentJsonData == null;
																										num6 = num9;
																										num5 = (nint)typeof(JToken);
																										if (flag10)
																										{
																											throw new NullReferenceException();
																										}
																									}
																									JObject jObject = currentJsonData2;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v72+60]");
																									jObject.set_Item((string)0, value);
																									obj5 = 0;
																									num5 = (nint)currentJsonData2;
																								}
																								else
																								{
																									nint num10 = (nint)enumerable;
																									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1402 @ r8_v39 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Newtonsoft.Json.Linq.JToken>>)+248] (should have been resolved before IL gen)");
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAEBA0");
																									bool flag11 = _currentJsonData == null;
																									num5 = (nint)_currentJsonData;
																									if (flag11)
																									{
																										throw new NullReferenceException();
																									}
																									JObject currentJsonData4 = _currentJsonData;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v72+60]");
																									JToken jToken2 = currentJsonData4.get_Item((string)0);
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAEBA0");
																									nint num11 = (nint)typeof(JToken);
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1430 @ rcx_v51 (Il2CppClass<Newtonsoft.Json.Linq.JToken>)+E4]");
																									bool flag9 = (nint)0 != 0;
																									int num12 = (int)(obj21 + obj22);
																									JToken value2 = num12;
																									bool flag12 = _currentJsonData == null;
																									num5 = num12;
																									if (flag12)
																									{
																										throw new NullReferenceException();
																									}
																									JObject currentJsonData5 = _currentJsonData;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1011 @ rax_v72+60]");
																									currentJsonData5.set_Item((string)0, value2);
																									obj11 = obj7;
																									obj5 = 0;
																									num5 = (nint)_currentJsonData;
																								}
																								continue;
																							}
																							throw new NullReferenceException();
																						}
																						throw new NullReferenceException();
																					}
																					throw new NullReferenceException();
																				}
																				throw new NullReferenceException();
																			}
																			throw new NullReferenceException();
																		}
																		throw new NullReferenceException();
																	}
																	if (obj9 != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
																	}
																}
																else
																{
																	_currentJsonData = (JObject)obj7;
																}
																if (_currentJsonData != null)
																{
																	object currentEnemyData = _currentJsonData.ToObject<object>();
																	_currentEnemyData = (EnemyData)currentEnemyData;
																	goto IL_0941;
																}
																goto IL_095d;
															}
														}
													}
													goto IL_094f;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_095d;
		IL_095d:
		throw new NullReferenceException();
		IL_094f:
		return false;
		IL_0941:
		return true;
	}

	protected static void PlayHitSfx()
	{
		//IL_0046: Expected O, but got F4
		//IL_0033: Expected F4, but got I4
		object obj = UnityEngine.Random.value;
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Hit, 150f, 3, 0f, volume, rate, detune, loop, 1f);
	}

	protected virtual void Die()
	{
		//IL_0069: Expected O, but got I4
		//IL_009d: Expected O, but got I4
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_01b3: Invalid comparison between O and F4
		//IL_00cd: Expected O, but got I4
		//IL_01e6: Expected O, but got F4
		if (_003CIsDead_003Ek__BackingField)
		{
			return;
		}
		bool flag = !_selfDestruct;
		IntPtr intPtr = default(IntPtr);
		bool flag2 = (byte)(nint)intPtr != 0;
		if (!flag)
		{
			_AlertSpriteRenderer.forceRenderingOff = true;
			Tween alertTween = _alertTween;
			bool flag3 = _alertTween == null;
			flag2 = true;
			object obj = 0;
			if (!flag3)
			{
				bool flag4 = !alertTween._003Cactive_003Ek__BackingField;
				flag2 = true;
				obj = 0;
				if (!flag4)
				{
					DG.Tweening.TweenExtensions.Kill(_alertTween);
					flag2 = false;
					obj = 0;
				}
			}
		}
		_003CIsDead_003Ek__BackingField = true;
		_deathStyle = EnemyDeathStyle.Die;
		if (_blinkTimeout != null)
		{
			_blinkTimeout.Cancel();
			flag2 = false;
		}
		if (body == null)
		{
			GameObject context = base.gameObject;
			Debug.LogError("Body is null in EnemyController.Die() - Probably the enemy was Despawned earlier in this frame without killing it (e.g. by being culled off-screen)", context);
		}
		else
		{
			EnemyData currentEnemyData = _currentEnemyData;
			float num = currentEnemyData._003CdeathKB_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj2 = num ^ 0;
			float num2 = GameManager.EnemySpeed * _003CSpeed_003Ek__BackingField;
			float num3 = num2 / 100f;
			float num4 = num3 * (float)obj2;
			float num5 = num4 * _003CSlow_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C6C6E0");
			Vector3 vector2 = default(Vector3);
			Vector3 vector = ((System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f)) ? Vector3.zeroVector : vector2);
			float num6 = (float)vector * num5;
			object obj3 = default(object);
			float num7 = (float)obj3 * num5;
			BaseBody baseBody = body;
			baseBody._velocity = (float2)num6;
		}
		GiveReward();
		PlayDeathAnimation();
	}

	protected void InitDeathRng()
	{
		//IL_0081: Expected O, but got I4
		if ((object)_deathRng == null)
		{
			int num = (int)(_deathSeed << 13);
			int num2 = (int)_deathSeed ^ num;
			int num3 = num2 >> 17;
			int num4 = num2 ^ num3;
			int num5 = num4 << 5;
			int num6 = num5 ^ num4;
			_deathRng = (Unity.Mathematics.Random)num6;
		}
	}

	public void GiveReward(Action<Pickup> onRewardGiven = null)
	{
		//IL_0622: Unknown result type (might be due to invalid IL or missing references)
		//IL_0627: Expected O, but got Unknown
		//IL_0098: Expected O, but got I4
		//IL_00e4: Invalid comparison between F4 and I4
		//IL_0180: Expected O, but got F4
		//IL_0729: Expected I, but got O
		//IL_0200: Expected O, but got F4
		//IL_05b7: Expected O, but got F4
		//IL_06f4->IL05bd: Incompatible stack heights: 1 vs 0
		//IL_0196->IL0196: Incompatible stack heights: 1 vs 0
		//IL_0743->IL05bd: Incompatible stack heights: 1 vs 0
		//IL_021d->IL021d: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass312_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass312_0();
		Vector3 ret;
		float num11 = default(float);
		if (CS_0024_003C_003E8__locals9 != null)
		{
			CS_0024_003C_003E8__locals9.onRewardGiven = onRewardGiven;
			if ((object)_deathRng == null)
			{
				int num = (int)(_deathSeed << 13);
				int num2 = (int)_deathSeed ^ num;
				int num3 = num2 >> 17;
				int num4 = num2 ^ num3;
				int num5 = num4 << 5;
				int num6 = num5 ^ num4;
				_deathRng = (Unity.Mathematics.Random)num6;
			}
			object obj = (object)_deathRng << 13;
			object obj2 = obj ^ (object)_deathRng;
			object obj3 = (object)_deathRng >> 9;
			object obj4 = obj3 | 0x3F800000;
			object obj5 = obj2 >> 17;
			object obj6 = obj2 ^ obj5;
			object obj7 = obj6 << 5;
			Unity.Mathematics.Random deathRng = (Unity.Mathematics.Random)(obj7 ^ obj6);
			_deathRng = deathRng;
			EnemyData currentEnemyData = _currentEnemyData;
			if (_currentEnemyData != null)
			{
				float num7 = (float)obj4 - 1f;
				float num8 = num7 + 0.5f;
				float num9 = num8 * currentEnemyData._003Cxp_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
				float num10 = default(float);
				if (!(num10 > 0f))
				{
					Action<Pickup> onRewardGiven2 = CS_0024_003C_003E8__locals9.onRewardGiven;
					if (CS_0024_003C_003E8__locals9.onRewardGiven != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v637 @ rax_v76 (System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>)+18] (should have been resolved before IL gen)");
					}
					goto IL_0196;
				}
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v65 (UnityEngine.Transform)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rax_v65 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret);
					Action<Pickup> action = delegate
					{
						Action<Pickup> onRewardGiven3 = CS_0024_003C_003E8__locals9.onRewardGiven;
						if (CS_0024_003C_003E8__locals9.onRewardGiven != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>)+18] (should have been resolved before IL gen)");
						}
					};
					if ((object)_gameManager != null)
					{
						_gameManager.MakeGem((Vector2)num11, num10, action);
						Action<Pickup> action2 = action;
						num9 = num11;
						goto IL_0196;
					}
				}
			}
		}
		goto IL_05bd;
		IL_0196:
		if (_treasure == null)
		{
			goto IL_021d;
		}
		Transform transform2 = base.transform;
		if ((object)transform2 != null)
		{
			bool flag2 = ((_003C_003Ec__DisplayClass312_0)(object)transform2).onRewardGiven == null;
			Transform.get_position_Injected((IntPtr)((_003C_003Ec__DisplayClass312_0)(object)transform2).onRewardGiven, out ret);
			if ((object)_gameManager != null)
			{
				TreasureChest treasureChest = _gameManager.MakeTreasure((Vector2)num11, _treasure);
				_treasure = null;
				Action<Pickup> action2 = null;
				float num9 = num11;
				goto IL_021d;
			}
		}
		goto IL_05bd;
		IL_040e:
		GameManager core = GM.Core;
		if ((object)GM.Core != null && (object)core._003CMainUI_003Ek__BackingField != null)
		{
			core._003CMainUI_003Ek__BackingField.UpdateKills();
			if (!_003CIsTimeStopped_003Ek__BackingField)
			{
				return;
			}
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null)
			{
				ArcanaManager arcanaManager = core2._arcanaManager;
				if (core2._arcanaManager != null)
				{
					if (!arcanaManager._hasCrystalCries)
					{
						return;
					}
					_003C_003Ec__DisplayClass312_1 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass312_1();
					EnemyData currentEnemyData2 = _currentEnemyData;
					if (_currentEnemyData != null && CS_0024_003C_003E8__locals11 != null)
					{
						CS_0024_003C_003E8__locals11.rawXp = currentEnemyData2._003Cxp_003Ek__BackingField;
						float2 float5 = base.position;
						Action<Pickup> callback = delegate(Pickup p)
						{
							if ((object)p != null && ((UnityEngine.Object)p).m_CachedPtr != (IntPtr)0)
							{
								float num14 = p._003CValue_003Ek__BackingField;
								if (!(p._003CValue_003Ek__BackingField > CS_0024_003C_003E8__locals11.rawXp))
								{
									num14 = CS_0024_003C_003E8__locals11.rawXp;
								}
								p._003CValue_003Ek__BackingField = num14;
							}
						};
						if ((object)GM.Core != null)
						{
							GM.Core.MakeFrozenSoul((Vector2)num11, 0f, callback);
							return;
						}
					}
				}
			}
		}
		goto IL_05bd;
		IL_05bd:
		throw new NullReferenceException();
		IL_021d:
		if ((object)GM.Core != null)
		{
			GM.Core.SetLatestKilledEnemy(this);
			if (_signalBus != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2AE0");
				if (_playerOptions != null)
				{
					PlayerOptionsData config = _playerOptions.Config;
					_playerOptions.TrackEnemyKill(_enemyType, config);
					if (_playerOptions != null)
					{
						PlayerOptionsData config2 = _playerOptions.Config;
						if (config2 != null)
						{
							int num12 = config2._003CRunEnemies_003Ek__BackingField + 1;
							config2._003CRunEnemies_003Ek__BackingField = num12;
							if (!_003CIsBoss_003Ek__BackingField)
							{
								goto IL_040e;
							}
							if (_playerOptions != null)
							{
								PlayerOptionsData config3 = _playerOptions.Config;
								if (config3 != null)
								{
									int num13 = config3._003CRunBossesCount_003Ek__BackingField + 1;
									config3._003CRunBossesCount_003Ek__BackingField = num13;
									if (_playerOptions != null)
									{
										PlayerOptionsData config4 = _playerOptions.Config;
										if (config4 != null && config4._003CRunBossesTypes_003Ek__BackingField != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AF90");
											goto IL_040e;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_05bd;
	}

	public void GiveFullReward(Action<Pickup> onRewardGiven = null)
	{
		//IL_004e: Invalid comparison between F4 and I4
		//IL_05f2: Expected I, but got O
		//IL_05bd->IL052c: Incompatible stack heights: 1 vs 0
		//IL_0105->IL0105: Incompatible stack heights: 1 vs 0
		//IL_060c->IL052c: Incompatible stack heights: 1 vs 0
		//IL_018c->IL018c: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass313_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass313_0();
		Vector3 ret;
		Vector2 vector = default(Vector2);
		if (CS_0024_003C_003E8__locals9 != null)
		{
			CS_0024_003C_003E8__locals9.onRewardGiven = onRewardGiven;
			EnemyData currentEnemyData = _currentEnemyData;
			if (_currentEnemyData != null)
			{
				if (!(currentEnemyData._003Cxp_003Ek__BackingField > 0f))
				{
					Action<Pickup> onRewardGiven2 = CS_0024_003C_003E8__locals9.onRewardGiven;
					if (CS_0024_003C_003E8__locals9.onRewardGiven != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v595 @ rax_v69 (System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>)+18] (should have been resolved before IL gen)");
					}
					goto IL_0105;
				}
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v58 (UnityEngine.Transform)+10]");
					bool flag = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v58 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret);
					Action<Pickup> action = delegate
					{
						Action<Pickup> onRewardGiven3 = CS_0024_003C_003E8__locals9.onRewardGiven;
						if (CS_0024_003C_003E8__locals9.onRewardGiven != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`1<VampireSurvivors.Objects.Pickups.Pickup>)+18] (should have been resolved before IL gen)");
						}
					};
					if ((object)_gameManager != null)
					{
						_gameManager.MakeGem(vector, currentEnemyData._003Cxp_003Ek__BackingField, action);
						Vector2 vector2 = vector;
						Action<Pickup> action2 = action;
						goto IL_0105;
					}
				}
			}
		}
		goto IL_052c;
		IL_037d:
		GameManager core = GM.Core;
		if ((object)GM.Core != null && (object)core._003CMainUI_003Ek__BackingField != null)
		{
			core._003CMainUI_003Ek__BackingField.UpdateKills();
			if (!_003CIsTimeStopped_003Ek__BackingField)
			{
				return;
			}
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null)
			{
				ArcanaManager arcanaManager = core2._arcanaManager;
				if (core2._arcanaManager != null)
				{
					if (!arcanaManager._hasCrystalCries)
					{
						return;
					}
					_003C_003Ec__DisplayClass313_1 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass313_1();
					EnemyData currentEnemyData2 = _currentEnemyData;
					if (_currentEnemyData != null && CS_0024_003C_003E8__locals11 != null)
					{
						CS_0024_003C_003E8__locals11.rawXp = currentEnemyData2._003Cxp_003Ek__BackingField;
						float2 float5 = base.position;
						Action<Pickup> callback = delegate(Pickup p)
						{
							if ((object)p != null && ((UnityEngine.Object)p).m_CachedPtr != (IntPtr)0)
							{
								float num3 = p._003CValue_003Ek__BackingField;
								if (!(p._003CValue_003Ek__BackingField > CS_0024_003C_003E8__locals11.rawXp))
								{
									num3 = CS_0024_003C_003E8__locals11.rawXp;
								}
								p._003CValue_003Ek__BackingField = num3;
							}
						};
						if ((object)GM.Core != null)
						{
							GM.Core.MakeFrozenSoul(vector, 0f, callback);
							return;
						}
					}
				}
			}
		}
		goto IL_052c;
		IL_018c:
		if ((object)GM.Core != null)
		{
			GM.Core.SetLatestKilledEnemy(this);
			if (_signalBus != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB2AE0");
				if (_playerOptions != null)
				{
					PlayerOptionsData config = _playerOptions.Config;
					_playerOptions.TrackEnemyKill(_enemyType, config);
					if (_playerOptions != null)
					{
						PlayerOptionsData config2 = _playerOptions.Config;
						if (config2 != null)
						{
							int num = config2._003CRunEnemies_003Ek__BackingField + 1;
							config2._003CRunEnemies_003Ek__BackingField = num;
							if (!_003CIsBoss_003Ek__BackingField)
							{
								goto IL_037d;
							}
							if (_playerOptions != null)
							{
								PlayerOptionsData config3 = _playerOptions.Config;
								if (config3 != null)
								{
									int num2 = config3._003CRunBossesCount_003Ek__BackingField + 1;
									config3._003CRunBossesCount_003Ek__BackingField = num2;
									if (_playerOptions != null)
									{
										PlayerOptionsData config4 = _playerOptions.Config;
										if (config4 != null && config4._003CRunBossesTypes_003Ek__BackingField != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AF90");
											goto IL_037d;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_052c;
		IL_0105:
		if (_treasure == null)
		{
			goto IL_018c;
		}
		Transform transform2 = base.transform;
		if ((object)transform2 != null)
		{
			bool flag2 = ((_003C_003Ec__DisplayClass313_0)(object)transform2).onRewardGiven == null;
			Transform.get_position_Injected((IntPtr)((_003C_003Ec__DisplayClass313_0)(object)transform2).onRewardGiven, out ret);
			if ((object)_gameManager != null)
			{
				TreasureChest treasureChest = _gameManager.MakeTreasure(vector, _treasure);
				_treasure = null;
				Vector2 vector2 = vector;
				Action<Pickup> action2 = null;
				goto IL_018c;
			}
		}
		goto IL_052c;
		IL_052c:
		throw new NullReferenceException();
	}

	protected virtual void SetEnemySpriteAndAnimations()
	{
		//IL_0385: Expected I, but got O
		//IL_039d: Expected I4, but got O
		//IL_03a1: Expected O, but got I4
		//IL_030d: Expected I, but got O
		//IL_03d4->IL0350: Incompatible stack heights: 6 vs 5
		//IL_023a->IL023a: Incompatible stack heights: 6 vs 5
		if ((object)MarkerSetEnemySpriteAndAnimations != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerSetEnemySpriteAndAnimations);
		}
		EnemyData currentEnemyData = _currentEnemyData;
		bool flag = _currentEnemyData == null;
		EnemyController enemyController = (EnemyController)(object)currentEnemyData._003CframeNames_003Ek__BackingField;
		bool flag2 = currentEnemyData._003CframeNames_003Ek__BackingField == null;
		object obj = UnityEngine.Random.RandomRangeInt(0, (int)((MonoBehaviour)enemyController).m_CancellationTokenSource);
		EnemyData currentEnemyData2 = _currentEnemyData;
		bool flag3 = _currentEnemyData == null;
		List<string> list = currentEnemyData2._003CframeNames_003Ek__BackingField;
		bool flag4 = currentEnemyData2._003CframeNames_003Ek__BackingField == null;
		bool flag5 = (nint)obj >= list._size;
		string[] items = list._items;
		_defaultName = items[obj];
		EnemyData currentEnemyData3 = _currentEnemyData;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		_EnemyRenderer.sprite = sprite;
		_AlertSpriteRenderer.forceRenderingOff = true;
		_SpriteAnimation.CleanAnimations();
		SpriteAnimation spriteAnimation = _SpriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
		EnemyData currentEnemyData4 = _currentEnemyData;
		List<string> list2 = currentEnemyData4._003CframeNames_003Ek__BackingField;
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		if (list2._size != 0)
		{
			bool shouldLoop = default(bool);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			if (currentEnemyData4._003CidleFrameCount_003Ek__BackingField > 0)
			{
				List<List<string>> internal_IdleAnimFrameNames = currentEnemyData4.Internal_IdleAnimFrameNames;
				bool flag6 = (nint)obj >= internal_IdleAnimFrameNames._size;
				List<string>[] items2 = internal_IdleAnimFrameNames._items;
				List<Sprite> frames = SpriteManager.GetAnimationFramesFast(textureName: _currentEnemyData._003CtextureName_003Ek__BackingField, frameNames: items2[obj]);
				_SpriteAnimation.AddAnimation("idle", frames, 8, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
			}
			EnemyData currentEnemyData5 = _currentEnemyData;
			List<List<string>> internal_DeathAnimFrameNames = currentEnemyData5.Internal_DeathAnimFrameNames;
			bool flag7 = (nint)obj >= internal_DeathAnimFrameNames._size;
			List<string>[] items3 = internal_DeathAnimFrameNames._items;
			List<Sprite> list3 = SpriteManager.GetAnimationFramesFast(textureName: _currentEnemyData._003CtextureName_003Ek__BackingField, frameNames: items3[obj]);
			if (list3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1876626E0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1670 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+490]");
				Action action = new Action(this, (IntPtr)0);
				nint num = (nint)this;
				_SpriteAnimation.AddAnimation("die", list3, 24, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
			}
			autoScope.Dispose();
		}
		else
		{
			autoScope.Dispose();
		}
	}

	protected virtual void UpdateDepth()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		if (num != currentDepthEnemy)
		{
			currentDepthEnemy = num;
			_EnemyRenderer.sortingOrder = num;
		}
		int num2 = num - 1;
		if (num2 != currentDepthAlert)
		{
			currentDepthAlert = num2;
			_AlertSpriteRenderer.sortingOrder = num2;
		}
	}

	private void PauseAnimations()
	{
		EnemyData currentEnemyData = _currentEnemyData;
		if (currentEnemyData._003CidleFrameCount_003Ek__BackingField > 0 && _allowAnimationPauseResume)
		{
			SpriteAnimation spriteAnimation = _SpriteAnimation;
			((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = true;
		}
	}

	private void ResumeAnimations()
	{
		EnemyData currentEnemyData = _currentEnemyData;
		if (currentEnemyData._003CidleFrameCount_003Ek__BackingField > 0 && _allowAnimationPauseResume)
		{
			SpriteAnimation spriteAnimation = _SpriteAnimation;
			((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
		}
	}

	protected void PlayDeathAnimation()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1873EDE70");
		FrameAnimationData frameAnimationData = default(FrameAnimationData);
		if (frameAnimationData != null)
		{
			SpriteAnimation spriteAnimation = _SpriteAnimation;
			((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
			_SpriteAnimation.SetAnimation(frameAnimationData, "die");
			CoherenceSync coherenceSync = _coherenceSync;
			if ((object)_coherenceSync != null && ((UnityEngine.Object)coherenceSync).m_CachedPtr != (IntPtr)0 && !_coherenceSync.HasStateAuthority && IsBossEnemy() && !_003CKilledByAuthority_003Ek__BackingField)
			{
				Action action = OnlineKill;
				bool flag = _coherenceSync.SendCommand(action, MessageTarget.AuthorityOnly);
			}
		}
		else
		{
			OnDeathAnimationComplete();
		}
	}

	public void OnlineKill()
	{
		//IL_0016: Invalid comparison between I4 and F4
		//IL_0051: Invalid comparison between I4 and F4
		_hp = 0f;
		if (0f > _maxHp)
		{
			_hp = _maxHp;
		}
		if (!(0f < _hp))
		{
			Die();
		}
	}

	protected virtual void OnDeathAnimationComplete()
	{
		CoherenceSync coherenceSync = _coherenceSync;
		if ((object)_coherenceSync != null && ((UnityEngine.Object)coherenceSync).m_CachedPtr != (IntPtr)0)
		{
			bool hasStateAuthority = _coherenceSync.HasStateAuthority;
			if (!hasStateAuthority && _003CKilledByAuthority_003Ek__BackingField == hasStateAuthority)
			{
				_EnemyRenderer.enabled = false;
				FireKilledSignal();
				return;
			}
		}
		Despawn();
	}

	private void ResumeFromFreeze()
	{
		_003CSpeed_003Ek__BackingField = _defaultSpeed;
		_003CIsTimeStopped_003Ek__BackingField = false;
		RestoreTint();
		EnemyData currentEnemyData = _currentEnemyData;
		if (currentEnemyData._003CidleFrameCount_003Ek__BackingField > 0 && _allowAnimationPauseResume)
		{
			SpriteAnimation spriteAnimation = _SpriteAnimation;
			((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
		}
		InitWiggle();
	}

	public bool DoDefang(float duration = -1f, uint defangColorTint = 4521864u, bool stopAnimation = false)
	{
		//IL_0290: Expected I4, but got O
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Expected O, but got Unknown
		//IL_02eb: Invalid comparison between F4 and I4
		_003C_003Ec__DisplayClass326_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass326_0();
		if (CS_0024_003C_003E8__locals10 != null)
		{
			CS_0024_003C_003E8__locals10._003C_003E4__this = this;
			CS_0024_003C_003E8__locals10.defangColorTint = defangColorTint;
			CS_0024_003C_003E8__locals10.stopAnimation = stopAnimation;
			object obj = default(object);
			bool flag = obj == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187661864h\"");
			bool flag2 = true;
			if (!flag)
			{
				flag2 = false;
			}
			object obj2 = flag2 & (_003F?)_003CResDefang_003Ek__BackingField;
			if (obj2 == null)
			{
				return false;
			}
			if (DefangTimer != null)
			{
				DefangTimer.Cancel();
			}
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					if (!config._003CDisplayDefangedEnemies_003Ek__BackingField)
					{
						CS_0024_003C_003E8__locals10.defangColorTint = 0u;
					}
					if (duration > 0f)
					{
						Action onComplete = delegate
						{
							EnemyController enemyController = CS_0024_003C_003E8__locals10._003C_003E4__this;
							enemyController._003CIsDefanged_003Ek__BackingField = false;
							if (CS_0024_003C_003E8__locals10.defangColorTint != 0)
							{
								enemyController.RestoreTint();
							}
							if (~(CS_0024_003C_003E8__locals10.stopAnimation ? 1u : 0u) == 0)
							{
								EnemyData currentEnemyData2 = enemyController._currentEnemyData;
								if (currentEnemyData2._003CidleFrameCount_003Ek__BackingField > 0)
								{
									SpriteAnimation spriteAnimation2 = enemyController._SpriteAnimation;
									((BaseSpriteAnimation)spriteAnimation2)._003CIsPaused_003Ek__BackingField = false;
								}
							}
						};
						float duration2 = duration * 0.001f;
						bool useRealTime = default(bool);
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						TimerType type = default(TimerType);
						Timer defangTimer = Timers.Register(duration2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						DefangTimer = defangTimer;
					}
					_003CIsDefanged_003Ek__BackingField = true;
					if (CS_0024_003C_003E8__locals10.defangColorTint != 0)
					{
						ArcadeSprite arcadeSprite = setTint(4521864u);
					}
					if (CS_0024_003C_003E8__locals10.stopAnimation)
					{
						EnemyData currentEnemyData = _currentEnemyData;
						if (_currentEnemyData == null)
						{
							goto IL_0282;
						}
						if (currentEnemyData._003CidleFrameCount_003Ek__BackingField > 0)
						{
							SpriteAnimation spriteAnimation = _SpriteAnimation;
							if ((object)_SpriteAnimation == null)
							{
								goto IL_0282;
							}
							((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = true;
						}
					}
					return true;
				}
			}
		}
		goto IL_0282;
		IL_0282:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void ResumeFromDefang(uint fakeFreezeDisplay = 4521864u, bool stopAnimation = false)
	{
		_003CIsDefanged_003Ek__BackingField = false;
		if (fakeFreezeDisplay != 0)
		{
			RestoreTint();
		}
		if (stopAnimation)
		{
			EnemyData currentEnemyData = _currentEnemyData;
			if (currentEnemyData._003CidleFrameCount_003Ek__BackingField > 0)
			{
				SpriteAnimation spriteAnimation = _SpriteAnimation;
				((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
			}
		}
	}

	protected void SetTintFill(bool isEnabled, HitVfxType? hitVfxType = null)
	{
		SpriteRenderer enemyRenderer = _EnemyRenderer;
		if ((object)_EnemyRenderer == null || ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Material material;
		HitVfxType type;
		if (!isEnabled)
		{
			EnemyData currentEnemyData = _currentEnemyData;
			if (currentEnemyData._003CmaterialType_003Ek__BackingField != MaterialType.DefaultSprite)
			{
				material = MaterialManager.GetMaterial(currentEnemyData._003CmaterialType_003Ek__BackingField);
				goto IL_00b9;
			}
			type = HitVfxType.None;
		}
		else
		{
			HitVfxType hitVfxType2 = default(HitVfxType);
			type = hitVfxType2;
		}
		material = VFXManager.GetMaterial(type);
		goto IL_00b9;
		IL_00b9:
		((Renderer)_EnemyRenderer).SetMaterial(material);
	}

	private void RestoreTint()
	{
		//IL_00bd: Expected O, but got I4
		SetTintFill(isEnabled: false, (HitVfxType?)(object)0);
		SpriteRenderer enemyRenderer;
		uint tint;
		if (!_003CIsTimeStopped_003Ek__BackingField)
		{
			if (_003CIsDefanged_003Ek__BackingField)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config._003CDisplayDefangedEnemies_003Ek__BackingField)
				{
					enemyRenderer = _EnemyRenderer;
					tint = 4521864u;
					goto IL_00df;
				}
			}
			enemyRenderer = _EnemyRenderer;
			tint = _saveTint;
		}
		else
		{
			enemyRenderer = _EnemyRenderer;
			tint = 255u;
		}
		goto IL_00df;
		IL_00df:
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(enemyRenderer, tint);
		_receivingDamage = false;
	}

	public void ForceDefaultTint()
	{
		//IL_0080: Expected O, but got I4
		SetTintFill(isEnabled: false, (HitVfxType?)(object)0);
		if (_003CIsDefanged_003Ek__BackingField)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config._003CDisplayDefangedEnemies_003Ek__BackingField)
			{
				SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(_EnemyRenderer, 4521864u);
				return;
			}
		}
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(_EnemyRenderer, _saveTint);
	}

	public void ForceTint(uint tintValue, bool isTintFill = false)
	{
		//IL_0028: Expected O, but got I4
		SetTintFill(isTintFill, (HitVfxType?)(object)0);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(_EnemyRenderer, tintValue);
	}

	protected virtual void FireEnemyAsBullet(Vector2 spawnPos, EnemyType bulletType)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0061: Expected I, but got O
		//IL_007d: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
	}

	protected Vector2 SetVelocityFromRotation(float rotation, float speed)
	{
		//IL_006d: Expected O, but got F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num = rotation * speed;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		BaseBody baseBody = body;
		float num2 = rotation * speed;
		if (body != null)
		{
			baseBody._velocity = (float2)num;
			Vector2 result = default(Vector2);
			return result;
		}
		return (Vector2)new NullReferenceException();
	}

	public void ReloadCurrentData()
	{
		InitialiseLocalData(_enemyType);
	}

	public EnemyController()
	{
		//IL_002e: Expected O, but got I4
		//IL_00b9: Expected I, but got O
		//IL_00d4: Expected O, but got I4
		//IL_0148: Expected I4, but got I8
		_wiggleForward = true;
		Vector3 euler = default(Vector3);
		Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion ret);
		_wiggleStartRot = ret;
		Vector3 euler2 = default(Vector3);
		Quaternion.Internal_FromEulerRad_Injected(ref euler2, out Quaternion ret2);
		_spritePivot = (Vector2)1056964608;
		_allowAnimationPauseResume = true;
		_wiggleEndRot = ret2;
		_damageKb = 1f;
		_defaultSpeed = 100f;
		_scaleMul = 1f;
		_alpha = 1f;
		_damageWeakness = 1f;
		_maxDamageWeakness = 100f;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rax_v9 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_003CResDefang_003Ek__BackingField = (float?)(object)1;
		_currentDirection = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		_003CSpeed_003Ek__BackingField = 100f;
		_003CIsCullable_003Ek__BackingField = true;
		_003CWeakFire_003Ek__BackingField = 1f;
		_003CSlow_003Ek__BackingField = 1f;
		_003CIsPatrolling_003Ek__BackingField = true;
		_003CKnockBack_003Ek__BackingField = 1f;
		_003CSelfDestDistance_003Ek__BackingField = 40000f;
		_003CStageEventId_003Ek__BackingField = -1;
		_003CConditionalCanMove_003Ek__BackingField = true;
		currentDepthEnemy = -1;
		((GameMonoBehaviour)this)._onResumeSent = true;
	}

	static EnemyController()
	{
		//IL_0047: Expected O, but got I
		//IL_0072: Expected O, but got I
		//IL_0098: Expected O, but got I
		//IL_00c3: Expected O, but got I
		//IL_00e9: Expected O, but got I
		//IL_0114: Expected O, but got I
		//IL_013a: Expected O, but got I
		int applyTintFill = Shader.PropertyToID("_ApplyTintFill");
		ApplyTintFill = applyTintFill;
		int tintFillColor = Shader.PropertyToID("_TintFillColor");
		TintFillColor = tintFillColor;
		FireDamageTypes = new WeaponType[42]
		{
			WeaponType.FIREEXPLOSION,
			WeaponType.TRAPANO2,
			WeaponType.FIREBALL,
			WeaponType.HELLFIRE,
			WeaponType.MISSPELL,
			WeaponType.MISSPELL2,
			WeaponType.NDUJA,
			WeaponType.NDUJA_COUNTER,
			WeaponType.TRIASSO1,
			WeaponType.TRIASSO2,
			WeaponType.TRIASSO3,
			WeaponType.HOLYWATER,
			WeaponType.BORA,
			WeaponType.FB_FIREWALL,
			WeaponType.FB_FIREARM,
			WeaponType.FB_FIREEXPLOSION,
			WeaponType.TP_ALCHEMYWHIP2,
			WeaponType.TP_ALCHEMYWHIP1,
			WeaponType.TP_FIRE1,
			WeaponType.TP_FIRE2,
			WeaponType.TP_FIRE1_COUNTER,
			WeaponType.TP_CUSTOS1,
			WeaponType.TP_CUSTOS4,
			WeaponType.TP_CUSTOS4_FIREBALL,
			WeaponType.TP_DCUSTOS_FIRE,
			WeaponType.TP_DCUSTOS_EXPLOSION,
			WeaponType.TP_DOMINUS1,
			WeaponType.TP_SAVROG_WEAPON,
			WeaponType.TP_HYDROSTORM2,
			WeaponType.TP_GOTH_MISSILE2,
			WeaponType.TP_SAVROG_WEAPON2,
			WeaponType.TP_AURABLAST_WEAPON2,
			WeaponType.EME_PUNCH1,
			WeaponType.EME_PUNCH2,
			WeaponType.EME_PUNCH3,
			WeaponType.EME_CANNON1,
			WeaponType.EME_CANNON2,
			WeaponType.EME_CANNON3,
			WeaponType.EME_MAGIC1,
			WeaponType.EME_MAGIC2,
			WeaponType.LEM_INFERNO1,
			WeaponType.LEM_INFERNO2
		};
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("EnemyController.InitEnemy", 1, MarkerFlags.Default, 0);
		MarkerInitEnemy = (ProfilerMarker)(nint)intPtr;
		IntPtr intPtr2 = ProfilerUnsafeUtility.CreateMarker("EnemyController.Despawn", 1, MarkerFlags.Default, 0);
		MarkerDespawn = (ProfilerMarker)(nint)intPtr2;
		IntPtr intPtr3 = ProfilerUnsafeUtility.CreateMarker("EnemyController.InitialiseLocalData", 1, MarkerFlags.Default, 0);
		MarkerInitialiseLocalData = (ProfilerMarker)(nint)intPtr3;
		IntPtr intPtr4 = ProfilerUnsafeUtility.CreateMarker("EnemyController.OnRecycleEnemy", 1, MarkerFlags.Default, 0);
		MarkerOnRecycleEnemy = (ProfilerMarker)(nint)intPtr4;
		IntPtr intPtr5 = ProfilerUnsafeUtility.CreateMarker("EnemyController.SetEnemySpriteAndAnimations", 1, MarkerFlags.Default, 0);
		MarkerSetEnemySpriteAndAnimations = (ProfilerMarker)(nint)intPtr5;
		IntPtr intPtr6 = ProfilerUnsafeUtility.CreateMarker("EnemyController.UpdateDepth", 1, MarkerFlags.Default, 0);
		updateDepthMarker = (ProfilerMarker)(nint)intPtr6;
		IntPtr intPtr7 = ProfilerUnsafeUtility.CreateMarker("EnemyController.SetTintFill", 1, MarkerFlags.Default, 0);
		setTintFillMarker = (ProfilerMarker)(nint)intPtr7;
	}

	private void _003COnPlayerOverlap_003Eb__265_0()
	{
		_canBeDamagedByBloodline = true;
	}

	private void _003COnPlayerOverlap_003Eb__265_1()
	{
		_canBeDamagedByBloodline = true;
	}

	private void _003COnUpdate_003Eb__271_0()
	{
		//IL_003e: Expected O, but got I4
		Sequence alertTween = _alertTween;
		if (_alertTween != null)
		{
			float timeScale = alertTween.timeScale * 1.1f;
			alertTween.timeScale = timeScale;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Alert, soundConfig, 250f, 3, time);
			return;
		}
		throw new NullReferenceException();
	}
}
