using System;
using Coherence;
using Coherence.Toolkit;
using Coherence.Toolkit.Bindings;
using Coherence.Toolkit.Bindings.TransformBindings;
using DG.Tweening;
using Newtonsoft.Json.Linq;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Serialization;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pickups;
using Zenject;

namespace VampireSurvivors.Objects.Characters
{
	public class EnemyController : BasePoolableSpriteBehaviour, IDamageable
	{
		private const uint DefangTint = 4521864u;

		[FormerlySerializedAs("_enemyRenderer")]
		[SerializeField]
		protected SpriteRenderer _EnemyRenderer;

		[FormerlySerializedAs("_alertSpriteRenderer")]
		[SerializeField]
		protected SpriteRenderer _AlertSpriteRenderer;

		[FormerlySerializedAs("_spriteAnimation")]
		[SerializeField]
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

		private Timer DefangTimer;

		private const float _defaultCorrectionFactor = 0.85f;

		public static WeaponType[] FireDamageTypes;

		private static readonly ProfilerMarker MarkerInitEnemy;

		private static readonly ProfilerMarker MarkerDespawn;

		private static readonly ProfilerMarker MarkerInitialiseLocalData;

		private static readonly ProfilerMarker MarkerOnRecycleEnemy;

		private static readonly ProfilerMarker MarkerSetEnemySpriteAndAnimations;

		private static ProfilerMarker updateDepthMarker;

		private int currentDepthEnemy;

		private int currentDepthAlert;

		private static ProfilerMarker setTintFillMarker;

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		public int SyncedEnemyType
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Sync]
		public byte SyncedDeathStyle
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public EnemyDeathStyle DeathStyle => default(EnemyDeathStyle);

		[Sync]
		public Transform TargetTransform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		public GameObject Owner
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		public uint DeathSeed
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public bool KilledByAuthority { get; set; }

		public float AttackPower => 0f;

		public float Speed { get; set; }

		public float DefaultSpeed => 0f;

		private Vector2 CurrentPos => default(Vector2);

		public Vector2 Velocity => default(Vector2);

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		public bool IsTeleportOnCull { get; set; }

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		public bool IsBoss { get; set; }

		public bool DontTeleportOnFreeRoam { get; set; }

		public float ScaleMul => 0f;

		public bool IgnoreNetworkError { get; set; }

		public Tween ScaleTween { get; set; }

		public bool CannotBeFollower
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsCullable { get; set; }

		public bool IsStatic { get; set; }

		public float FeverValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector3 CurrentDirection
		{
			get
			{
				return default(Vector3);
			}
			protected set
			{
			}
		}

		public bool FixedDirection => false;

		public float? ResRosary { get; private set; }

		public float? ResDebuffs { get; private set; }

		public float? ResCorridor { get; private set; }

		public float? ResFreeze { get; set; }

		public float? ResDefang { get; set; }

		public float WeakFire { get; private set; }

		public SpriteRenderer EnemyRenderer => null;

		public SpriteRenderer AlertSpriteRenderer => null;

		public float Slow { get; set; }

		public bool IsPatrolling { get; set; }

		public float KnockBack { get; set; }

		public EnemyData CurrentEnemyData => null;

		public bool IsDefanged { get; private set; }

		public bool IsTimeStopped { get; private set; }

		public bool IsTimeSlowed { get; private set; }

		protected Camera MainCamera => null;

		public float SelfDestDistance { get; set; }

		public SpriteAnimation SpriteAnimation => null;

		public SpriteAnimation anims => null;

		public EnemyType EnemyType => default(EnemyType);

		public int StageEventId { get; set; }

		public bool ConditionalCanMove { get; set; }

		public bool IgnoreMovementFreezeFromTimeStop { get; set; }

		public CoherenceSync Sync => null;

		public float Hp
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool IsDead { get; set; }

		public float NormalizedHp => 0f;

		public float DamageWeakness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MaxDamageWeakness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected virtual void FakeConstruct()
		{
		}

		protected virtual void Awake()
		{
		}

		protected override void OnEnable()
		{
		}

		protected virtual void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected virtual void OnDrawGizmosSelected()
		{
		}

		public virtual void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected virtual void UpdateBaseHealth()
		{
		}

		protected virtual bool CanUseAbility()
		{
			return false;
		}

		public void SetTargetTransform(Transform target)
		{
		}

		public virtual void SetOwner(GameObject owner)
		{
		}

		public virtual void OnTeleportOnCull()
		{
		}

		public virtual bool CanEnemyTeleport()
		{
			return false;
		}

		public void AttachTreasure(Treasure treasure)
		{
		}

		public virtual void Disappear()
		{
		}

		public virtual void Despawn()
		{
		}

		public GameObject GetGameObject()
		{
			return null;
		}

		public void FeedOnPlayer()
		{
		}

		public bool IsPlayingDeathAnimation()
		{
			return false;
		}

		public bool WouldEat()
		{
			return false;
		}

		public bool IsBossEnemy()
		{
			return false;
		}

		public bool IsBullet()
		{
			return false;
		}

		public bool IsFlying()
		{
			return false;
		}

		public virtual void OnPlayerOverlap(CharacterController player)
		{
		}

		public virtual void SetFlipX(bool flip)
		{
		}

		public bool IsValid()
		{
			return false;
		}

		public override SpriteRenderer GetAttachedRenderer()
		{
			return null;
		}

		public void InitialiseLocalData(EnemyType enemyType)
		{
		}

		protected override void OnUpdate()
		{
		}

		private static float GetCorrectionFactor()
		{
			return 0f;
		}

		protected void RetargetIfNecessary()
		{
		}

		public void TargetClosestPlayer()
		{
		}

		protected virtual void CalculateCurrentDirection()
		{
		}

		protected virtual void CalculateDirectionAndVelocity()
		{
		}

		public bool Freeze(float duration, float chance = 1f)
		{
			return false;
		}

		public bool Freeze_WithoutTint(float duration, float chance = 1f)
		{
			return false;
		}

		public void TimeStop(bool ignoreMovementFreezeFromTimeStop = false)
		{
		}

		public void ResumeFromTimeStop()
		{
		}

		public bool SlowEnemy(float duration, float chance = 1f, float slowAmount = 0.5f)
		{
			return false;
		}

		public void ResumeFromSlow()
		{
		}

		public virtual void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		public virtual void GetDamagedSpecial(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true, Vector3? damagePosition = null)
		{
		}

		public void PlayVFXFlash(HitVfxType showHitVfx)
		{
		}

		public virtual void OnGetDamaged(HitVfxType showHitVfx, bool hasKb = true)
		{
		}

		public bool IsUnitDead()
		{
			return false;
		}

		public float MaxHp()
		{
			return 0f;
		}

		public float CurrentHealth()
		{
			return 0f;
		}

		public void ChangeMaxHealth(float maxHP)
		{
		}

		public void RandomizeCurrentHp(float min = 0.1f)
		{
		}

		public void SetHealth(float health)
		{
		}

		public void Kill()
		{
		}

		public virtual void OnMusicBeat()
		{
		}

		protected virtual void OnRecycleEnemy()
		{
		}

		protected virtual void InitWiggle()
		{
		}

		protected virtual void ProcessWiggle()
		{
		}

		protected void FireKilledSignal()
		{
		}

		protected void OnSelfDestruct()
		{
		}

		private void UpdateScale()
		{
		}

		private void UpdateAlpha()
		{
		}

		private void DetectMisprediction(object sampleData, bool stopped, long simulationFrame)
		{
		}

		private void SnapPosition(Vector3 networkPosition)
		{
		}

		protected void DealDamage(float damage)
		{
		}

		private void InitLayer()
		{
		}

		private void InitSkills()
		{
		}

		private bool GetEnemyDataForCurrentLevel(int level)
		{
			return false;
		}

		protected static void PlayHitSfx()
		{
		}

		protected virtual void Die()
		{
		}

		protected void InitDeathRng()
		{
		}

		public void GiveReward(Action<Pickup> onRewardGiven = null)
		{
		}

		public void GiveFullReward(Action<Pickup> onRewardGiven = null)
		{
		}

		protected virtual void SetEnemySpriteAndAnimations()
		{
		}

		protected virtual void UpdateDepth()
		{
		}

		private void PauseAnimations()
		{
		}

		private void ResumeAnimations()
		{
		}

		protected void PlayDeathAnimation()
		{
		}

		[Command(defaultRouting = MessageTarget.AuthorityOnly)]
		public void OnlineKill()
		{
		}

		protected virtual void OnDeathAnimationComplete()
		{
		}

		private void ResumeFromFreeze()
		{
		}

		public bool DoDefang(float duration = -1f, uint defangColorTint = 4521864u, bool stopAnimation = false)
		{
			return false;
		}

		public void ResumeFromDefang(uint fakeFreezeDisplay = 4521864u, bool stopAnimation = false)
		{
		}

		protected void SetTintFill(bool isEnabled, HitVfxType? hitVfxType = null)
		{
		}

		private void RestoreTint()
		{
		}

		public void ForceDefaultTint()
		{
		}

		public void ForceTint(uint tintValue, bool isTintFill = false)
		{
		}

		protected virtual void FireEnemyAsBullet(Vector2 spawnPos, EnemyType bulletType)
		{
		}

		protected Vector2 SetVelocityFromRotation(float rotation, float speed)
		{
			return default(Vector2);
		}

		public void ReloadCurrentData()
		{
		}
	}
}
