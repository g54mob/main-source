using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using Coherence.Toolkit.Bindings;
using Newtonsoft.Json.Linq;
using Rewired;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.UI.Player;
using Zenject;

namespace VampireSurvivors.Objects.Characters
{
	[DefaultExecutionOrder(850)]
	public class CharacterController : ArcadeSprite, IDamageable
	{
		private struct EdgeDistances
		{
			public float xToRightUnbound;

			public float xToLeftUnbound;

			public float yToTopUnbound;

			public float yToBottomUnbound;
		}

		private struct WorldSpaceLimits
		{
			public float? Left;

			public float? Right;

			public float? Top;

			public float? Bottom;
		}

		[CompilerGenerated]
		private sealed class _003CAddCursor_003Ed__458 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CharacterController _003C_003E4__this;

			private string _003Chex_003E5__2;

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
			public _003CAddCursor_003Ed__458(int _003C_003E1__state)
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
		private sealed class _003CQueueWeaponSelectionInternal_003Ed__531 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CharacterController _003C_003E4__this;

			public string selectionType;

			public WeaponType type;

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
			public _003CQueueWeaponSelectionInternal_003Ed__531(int _003C_003E1__state)
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

		[Sync]
		public Vector2 CurrentDefaultMapPosition;

		[SerializeField]
		protected int _PlayerIndex;

		[SerializeField]
		protected SpriteRenderer _CharacterRenderer;

		[SerializeField]
		private SpriteRenderer _DeathNoHurtRenderer;

		protected SignalBus _signalBus;

		protected PlayerOptions _playerOptions;

		protected GameManager _gameManager;

		private CharacterController_Support _classSupport;

		private bool _sentRevivalCommand;

		private Player _player;

		protected CoherenceSync _coherenceSync;

		private Unity.Mathematics.Random _randomEnemyPickerRng;

		private Transform _cachedTransform;

		private CharacterWeaponsManager _weaponsManager;

		private CharacterAccessoriesManager _accessoriesManager;

		protected SpriteAnimation _spriteAnimation;

		protected ParticleSystem _damageVfx;

		private SpriteTrail _spriteTrail;

		private HealthBar _healthBar;

		private CharacterLightManager _characterLightManager;

		protected CharAnimationType _currentAnimation;

		private DataManager _dataManager;

		protected JObject _currentJsonData;

		protected CharacterData _currentCharacterData;

		protected CharacterData _currentSkinData;

		protected CharacterData _levelZeroCharacterData;

		private List<WeaponType> _weaponSelection;

		protected WeaponType _startingWeaponType;

		protected CharacterType _characterType;

		protected SkinType _skinType;

		protected Timer _regenTimer;

		protected Timer _blinkTimeoutTimer;

		protected Timer _freezeWeaponsTimer;

		protected bool _receivingDamage;

		protected bool _playDamageSFX;

		private float _invincibilityTimer;

		protected bool _hasWalkingAnimation;

		protected bool _hasIdleAnimation;

		protected MultiTargetTween _wiggleTween;

		protected Vector2 _currentDirection;

		private Vector2 _currentDirectionRaw;

		private Vector2 _lastMovementDirection;

		private bool _actionButtonPressed;

		protected MaterialPropertyBlock _propBlock;

		private ArcadeBodyBounds _worldBoxCollider;

		private ArcadeBodyBounds _coopMovementBoxCollider;

		private ModifierStats _onEveryLevelUp;

		protected MeleeAttack _meleeAnim;

		protected MeleeAttack _meleeAnim2;

		protected MeleeAttack _rangedAnim;

		protected MeleeAttack _magicAnim;

		protected MeleeAttack _specialAnim;

		protected MeleeAttack _idleAnim;

		private bool _followPlayerOne;

		private float _defaultSpriteWidth;

		protected SpriteRenderer _customDamageOverlayRenderer;

		private bool _useWorldSpaceMovementLimits;

		private WorldSpaceLimits _worldSpaceMovementLimits;

		protected PlayerModifierStats _playerStats;

		private float _slowMultiplier;

		private bool _isSlow;

		private float _currentHp;

		private int _level;

		private float _walked;

		private Vector2 _lastFacingDirection;

		private float _xp;

		private bool _isAnimForced;

		private bool _canFlip;

		private bool _isFlipped;

		private float _shieldInvulTime;

		private MagnetZone _magnet;

		private SineBonus _sineSpeed;

		private SineBonus _sineCooldown;

		private SineBonus _sineArea;

		private SineBonus _sineDuration;

		private SineBonus _sineMight;

		private float _slowTime;

		private float _gFeverMul;

		private Action<float, float> _onHpRecoveryCallback;

		private bool _isInFinalStage;

		private bool _isDead;

		protected bool _isInvul;

		protected bool _isSendingDeath;

		protected bool _isInitialized;

		private bool _isLastBreathEnabled;

		private bool _hasLastBreath;

		private Action _onLastBreath;

		private bool _isCriticalHPEnabled;

		private bool _hasAnyCriticalHPSkill;

		private Action _onCriticalHP;

		private float _criticalHPTreshold;

		private bool _hasThorns;

		private int _maxWeaponCount;

		private int _maxAccessoryCount;

		private int _maxWeaponBonus;

		private int _maxAccessoryBonus;

		private MultiplayerRevivalUI _multiplayerRevivalUI;

		private SpriteRenderer _multiplayerIndicator;

		private SpriteOutlinerControl _multiplayerOutliner;

		private SpriteRenderer _outlineReferenceRenderer;

		private bool _usingCustomRendererForOutline;

		protected float _multiplayerRevivalProportion;

		private int _revivalJuiceThisFrame;

		private Timer _multiplayerChompTimer;

		private Timer _multiplayerIndicatorTimer;

		private float _debuffSlow;

		private Timer _multiplayerDecompositionTimer;

		private Transform _multiplayerCameraTargetTransform;

		private Timer _deathConsequenceTimer;

		private Timer _multiplayerReviveShake1;

		private Timer _multiplayerReviveShake2;

		private bool _multiplayerRevivalAllowed;

		private PetManager _petManager;

		protected CharacterADControl _deficiencyControl;

		private PickupMode _pickupMode;

		private bool _permanentInvulnerability;

		private bool _blockInput;

		public float MoveSpeedMultiplier;

		public float ArmorManualIncrease;

		public List<WeaponType> GlimmeredTechniques;

		public float SvMult_AnyRare;

		public float SvMult_Foil;

		public float SvMult_Gala;

		public float SvMult_Poly;

		public float SvMult_Holo;

		public float SvMult_Inve;

		public float SvMult_Base;

		public CharacterSkillCardsManager CharacterSkillCardsManager;

		public float TempCurse;

		[Sync]
		public bool IsFollowerSharingPassives;

		[Sync]
		public bool IsFollowerReactingToArcanas;

		[NonSerialized]
		public float RapidFire_Life;

		[NonSerialized]
		public float Barrier_Number;

		private PhaserSprite BarrierSprite;

		public bool HasFourthLevelUpOption;

		public List<Weapon> HeldShieldSlots;

		public float MaxReachedPCoolDownFinal;

		public float MinReachedPCoolDownFinal;

		public float MaxReachedPLuck;

		public float MinReachedPLuck;

		public SfxType DamageSound;

		public float DamageVolume;

		public float DamageBaseDetune;

		private bool _hasForcedSortingOrder;

		private int _forcedSortingOrder;

		[Sync]
		public int SyncedCharacterType
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
		public int SyncedSkinType
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
		public bool IsFlipped
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync]
		public float CurrentHp
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		[Sync]
		public uint RandomEnemyPickerSeed { get; set; }

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		public bool ShowHealthBar
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		public float HealthBarScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public ref Unity.Mathematics.Random RandomEnemyPickerGenerator
		{
			get
			{
				throw null;
			}
		}

		public bool IsDead
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		[OnValueSynced("OnPermanentInvulnerabilityUpdated")]
		public bool PermanentInvulnerability
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		public bool TrackedByCamera { get; set; }

		public bool IsCoffinVisible => false;

		public virtual float LootMult_Rosary => 0f;

		public virtual float LootMult_Orologion => 0f;

		public virtual float LootMult_Rerollo => 0f;

		public float SkillCards_Mult { get; set; }

		public int Level
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int MaxWeaponCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int MaxAccessoryCount => 0;

		public int MaxWeaponBonus
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int MaxAccessoryBonus
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float DefaultSpriteWidth => 0f;

		public PlayerModifierStats PlayerStats => null;

		public CoherenceSync Sync => null;

		public PetManager PetManager => null;

		public CharacterADControl DeficiencyControl => null;

		public PickupMode PickupMode
		{
			get
			{
				return default(PickupMode);
			}
			set
			{
			}
		}

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		public int SyncedPickupMode
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		public uint FollowerLevelUpShuffleSeed { get; set; }

		public bool AlwaysCoinBag { get; set; }

		public bool AlwaysRoast { get; set; }

		public bool AlwaysRandomLimitBreak { get; set; }

		public ModifierStats OnEveryLevelUp => null;

		public Transform CachedTransform => null;

		private Vector2 CurrentPos => default(Vector2);

		public Vector2 Velocity => default(Vector2);

		public Vector2 ScaledVelocity => default(Vector2);

		public float2 ExternalVelocity { get; set; }

		public float FrameWalk => 0f;

		public float Walked
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool IsDisconnectedFromOnlinePlay => false;

		private float Speed => 0f;

		public Vector2 LastFacingDirection
		{
			get
			{
				return default(Vector2);
			}
			private set
			{
			}
		}

		public bool ActionButtonPressed => false;

		public Vector2 CurrentDirection
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		[Sync]
		[OnValueSynced("OnMovDirectionUpdated")]
		public Vector2 CurrentDirectionRaw
		{
			get
			{
				return default(Vector2);
			}
			set
			{
			}
		}

		public Vector2 LastMovementDirection => default(Vector2);

		public SpriteTrail rtGhosts => null;

		[Sync]
		[OnValueSynced("OnXpUpdated")]
		public float Xp
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool IsAnimForced
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool CanFlip
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Player PlayerInput => null;

		public List<WeaponType> weaponSelection
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public WeaponType StartingWeaponType => default(WeaponType);

		public CharacterWeaponsManager WeaponsManager => null;

		public CharacterAccessoriesManager AccessoriesManager => null;

		public CharacterData CurrentCharacterData => null;

		public CharacterData CurrentSkinData => null;

		public CharacterType CharacterType => default(CharacterType);

		public float MultiplayerRevivalProportion => 0f;

		public bool MultiplayerRevivalAllowed => false;

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		public bool CountsAsMainCharacterForRevivals { get; set; }

		public Transform CameraTarget => null;

		public bool IsLastBreathEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool HasLastBreath
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Action OnLastBreath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool HasAnyCriticalHPSkill
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsCriticalHPEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Action OnCriticalHP
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float ShieldInvulTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float CurrentInvincibilityTimer => 0f;

		public virtual bool HasThorns
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public MagnetZone Magnet
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SineBonus SineSpeed
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SineBonus SineCooldown
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SineBonus SineArea
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SineBonus SineDuration
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SineBonus SineMight
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float SlowTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float gFeverMul
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float SilentCooldown { get; set; }

		public float SilentMight { get; set; }

		public SpriteAnimation SpriteAnimation => null;

		public SpriteAnimation Anims => null;

		public string CurrentWalkAnimName { get; set; }

		public PlayerOptions PlayerOptions => null;

		public Action<float, float> OnHpRecoveryCallback
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ArcadeBodyBounds WorldBoxCollider => null;

		public int Depth => 0;

		public HealthBar HealthBar => null;

		public bool IsInFinalStage
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsPlatformMovementActive { get; set; }

		public ParticleSystem DamageBloodVfx => null;

		public virtual bool DrainWeaponsImmunity => false;

		public virtual int GlimmerComboModifier => 0;

		public virtual bool NeedsCart => false;

		public bool IsInvul
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float NormalizedHp => 0f;

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		public bool IsFollower
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		[Sync(DefaultSyncMode = SyncMode.CreationOnly)]
		public CoherenceSync FollowedCharacter
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
		public int FollowerLevelUpType
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool IsMainCharacterFollower => false;

		public bool IsMinorFollower => false;

		public bool SkipsArcanaEffects => false;

		public virtual bool RespectAnimationXPivots => false;

		public float DebuffSlowAmount
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public virtual float BloodlineDamage => 0f;

		public virtual float BloodlineArmorValue => 0f;

		public virtual float2 GetVectorWhipOffset => default(float2);

		public virtual float GetSpriteWhipOffset => 0f;

		public event Action OnRevivalStarted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void AddSkillCard(CharacterSkillCard_Base card)
		{
		}

		public virtual void OnSkillCardAdded(CharacterSkillCard_Base card)
		{
		}

		public void SetStartingWeaponFromWeaponSelector(WeaponType weaponType)
		{
		}

		public virtual float GetThornDamage(EnemyController enemy)
		{
			return 0f;
		}

		public virtual WeaponType GetFourthLevelUpOption()
		{
			return default(WeaponType);
		}

		public bool HasSeraphicCry(out SantaJavelin2Weapon seraphicCry)
		{
			seraphicCry = null;
			return false;
		}

		public bool IsInvulnerabilityWindowActive()
		{
			return false;
		}

		[Inject]
		private void Construct(SignalBus signalBus, DataManager dataManager, PlayerOptions playerOptions, GameManager gameManager)
		{
		}

		private void Awake()
		{
		}

		private bool ShouldStopAtScreenEdge()
		{
			return false;
		}

		protected override void OnUpdate()
		{
		}

		public void UpdateBoxCollider()
		{
		}

		private EdgeDistances GetDistancesToScreenEdges()
		{
			return default(EdgeDistances);
		}

		public void SetWorldSpaceMovementLimitsActive(bool limitsActive)
		{
		}

		public void SetWorldSpaceMovementLimits(float? left, float? right, float? top, float? bottom)
		{
		}

		public void ClearWorldSpaceMovementLimits()
		{
		}

		private void LimitMovementInsideWorldSpaceLimits(ref Vector2 movement)
		{
		}

		private void DoOnlineOrLocalRevival(bool instantRevival)
		{
		}

		[Command]
		public void TriggerOnlineRevival(long startingSimFrame, bool instantRevival)
		{
		}

		private void DoMultiplayerRevival(bool instantRevival)
		{
		}

		public virtual void DoPostRevivalActions(CharacterController revived, bool instantRevival = false)
		{
		}

		private void TurnIntoMultiplayerGhost()
		{
		}

		public void ForceHideOutline()
		{
		}

		private void EnsureOnScreen()
		{
		}

		public void HandleLateUpdate()
		{
		}

		private Vector3 ContainCharacterInHardBounds(Vector3 pos)
		{
			return default(Vector3);
		}

		public bool IsWithinBounds(ArcadeBodyBounds bounds)
		{
			return false;
		}

		public void RefreshMultiplayerOutline()
		{
		}

		protected override void OnDisable()
		{
		}

		public void InitCharacter(CharacterType characterType, int playerIndex, bool asRemote, bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		[IteratorStateMachine(typeof(_003CAddCursor_003Ed__458))]
		private IEnumerator AddCursor()
		{
			return null;
		}

		public void UpdateMaxWeaponCount()
		{
		}

		public virtual void AfterFullInitialization()
		{
		}

		public virtual void OnWeaponMadeLevelOne(WeaponType type)
		{
		}

		public virtual void OnQuit()
		{
		}

		public virtual void OnGlimmeredTechniqueFired()
		{
		}

		public virtual void OnGlimmeredTechniqueLearned(WeaponType glimmerType)
		{
		}

		public void ForceSetPosition(Vector2 newPosition)
		{
		}

		public float GetMultipliedHPRecoveryValue(float value)
		{
			return 0f;
		}

		public virtual void RecoverHp(float value, bool showRecovery = false, bool mulByRegen = false)
		{
		}

		public virtual void SetBloodColor(uint colorValue)
		{
		}

		protected virtual void _hpFullyRecovered(float recovered)
		{
		}

		public void EnableDestroyDestructiblesOnTouch()
		{
		}

		public virtual void LevelUp()
		{
		}

		public virtual void OnLevelUpFollowers()
		{
		}

		public virtual void OnLevelUpCompleted()
		{
		}

		public virtual void OnLevelUpSkipped()
		{
		}

		public virtual void Revive(float percentage = 1f, bool instantRevival = false)
		{
		}

		[Command]
		public void OnlineRevival(long startingSimFrame, float percentage)
		{
		}

		private void PerformRevival(float percentage)
		{
		}

		private void CancelDeathConsequencesTimer()
		{
		}

		public void AddXp(float value, XPMultiplierMode multiplierMode = XPMultiplierMode.Normal)
		{
		}

		public void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKnockBack = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		public void OnGetDamaged(HitVfxType hitVfxType, bool hasKb = true)
		{
		}

		public bool IsUnitDead()
		{
			return false;
		}

		public float CurrentHealth()
		{
			return 0f;
		}

		public GameObject GetGameObject()
		{
			return null;
		}

		public void SetMaxHistory(int max)
		{
		}

		public void DisableMultiplayerRevival()
		{
		}

		public bool WouldWeaponSynergise(WeaponType type)
		{
			return false;
		}

		public void GiveMaxedWeaponToPlayer(WeaponType weaponType, int minusMaxLevel = 0)
		{
		}

		public void InitCharacterSpotlight()
		{
		}

		public float2 ApplyRacingOffset(CharacterVehicleType characterVehicleType)
		{
			return default(float2);
		}

		public virtual float PInvulTime()
		{
			return 0f;
		}

		public virtual float PShieldTime()
		{
			return 0f;
		}

		public virtual float PArmor()
		{
			return 0f;
		}

		public virtual float PCurse()
		{
			return 0f;
		}

		public virtual float PGrowth()
		{
			return 0f;
		}

		public virtual float PLuck()
		{
			return 0f;
		}

		public virtual float PGreed()
		{
			return 0f;
		}

		public virtual float PSpeed()
		{
			return 0f;
		}

		public virtual float PDuration()
		{
			return 0f;
		}

		public virtual float PAreaFinal(float preClampMultiplier = 1f)
		{
			return 0f;
		}

		public virtual float PArea()
		{
			return 0f;
		}

		public virtual float PRegen()
		{
			return 0f;
		}

		public virtual float MaxHp()
		{
			return 0f;
		}

		public virtual float PMoveSpeed()
		{
			return 0f;
		}

		public virtual float PCooldownFinal(float cap = 0.1f)
		{
			return 0f;
		}

		public virtual float PCooldown()
		{
			return 0f;
		}

		public virtual float PAmount()
		{
			return 0f;
		}

		public virtual EggDouble PRevivals()
		{
			return null;
		}

		public float PPowerFinal()
		{
			return 0f;
		}

		public float PPowerWithoutSilentMight()
		{
			return 0f;
		}

		public virtual float PPower()
		{
			return 0f;
		}

		public void AddTemporaryBonus(Action start, Action end, float duration)
		{
		}

		[Command]
		public void ReportBody(long startingSimFrame, CoherenceSync player)
		{
		}

		public void PerformReportBody(CharacterController player)
		{
		}

		[Command]
		public void FireSireWeapon(bool skipTriggers)
		{
		}

		[Command]
		public void FirePentagramWeapon(bool eraseItems, bool skipTriggers)
		{
		}

		[Command]
		public void FireBattiliaWeapon()
		{
		}

		[Command]
		public void FireVenusCrescentWeapon(bool skipTriggers)
		{
		}

		[Command]
		public void EmergencyMeeting(long startingSimFrame, byte[] serializedEnemyTypes, int voteTarget)
		{
		}

		public void SendApplyWeaponLevelUp(WeaponType weapon)
		{
		}

		[Command]
		public void OnlineApplyWeaponLevelUp(long startingSimFrame, int weaponType)
		{
		}

		public void SendAddAttribute(WeaponType weaponType, float value)
		{
		}

		[Command]
		public void AddAttributeOnline(long startingSimFrame, int weaponType, float value)
		{
		}

		public void AddAttribute(WeaponType weaponType, float value)
		{
		}

		private void ApplyWeaponLevelUp(WeaponType weapon)
		{
		}

		public void QueueWeaponSelectionSelector(WeaponType weapon, string selectionType)
		{
		}

		[IteratorStateMachine(typeof(_003CQueueWeaponSelectionInternal_003Ed__531))]
		private IEnumerator QueueWeaponSelectionInternal(WeaponType type, string selectionType)
		{
			return null;
		}

		public void SendSetGlimmerNextFireForWeapon(WeaponType weapon)
		{
		}

		[Command]
		public void SetGlimmerNextFireForWeapon(long frame, int weaponType)
		{
		}

		protected void Pushback(GameObject value, float duration)
		{
		}

		public void SetHealth(float health)
		{
		}

		public void Kill()
		{
		}

		public void Resurrect()
		{
		}

		public void Die()
		{
		}

		public void DisableIfFollower()
		{
		}

		public void EnableIfFollower()
		{
		}

		public void Debug_ToggleInvulnerability()
		{
		}

		public void FreezePlayer(bool freeze)
		{
		}

		public void SetPermanentInvulnerability(bool on)
		{
		}

		protected void OnPermanentInvulnerabilityUpdated(bool old, bool newValue)
		{
		}

		public void SetInvulForMilliSeconds(float duration)
		{
		}

		public void SetInvulForMilliSecondsNonCumulative(float duration)
		{
		}

		public void SetInvulForMilliSecondsNonCumulativeIncludeParma(float duration)
		{
		}

		public bool TryGettingChomped()
		{
			return false;
		}

		public void RemoveInvul()
		{
		}

		public void TriggerGetDamagedByOwnWeapon(float damageAmount)
		{
		}

		[Command]
		public virtual void GetDamagedByOwnWeapon(float damageAmount)
		{
		}

		public virtual bool GetDamaged(float damageAmount)
		{
			return false;
		}

		private void TakeDamage(float damageAmount)
		{
		}

		[Command]
		public void OnHpReachedZeroOnline()
		{
		}

		private void OnHpReachedZero(float damageAmount = 0f)
		{
		}

		public virtual void OnGetDamaged(string hexColor = "#ff0000", float vulnerabilityDelay = 120f, bool playDamageFx = true, bool playWeaponDamageFx = false)
		{
		}

		public void OnGetDamaged(string hexColor, float vulnerabilityDelay, bool playDamageFx, bool playWeaponDamageFx, bool ignoreInvulnerabilityForRestoringTint)
		{
		}

		public virtual void RestoreTint()
		{
		}

		public void ActivateSineSpeedBonus(SineBonusData data)
		{
		}

		public void ActivateSineDurationBonus(SineBonusData data)
		{
		}

		public void ActivateSineMightBonus(SineBonusData data)
		{
		}

		public void ActivateSineAreaBonus(SineBonusData data)
		{
		}

		public void ActivateSineCooldownBonus(SineBonusData data)
		{
		}

		public virtual void GetTreasureModifier()
		{
		}

		protected void OnXpUpdated(float oldXp, float newXp)
		{
		}

		protected void OnMovDirectionUpdated(Vector2 oldLastMovDir, Vector2 newLastMovDir)
		{
		}

		private void SetupInput()
		{
		}

		protected virtual void OnStop()
		{
		}

		public virtual void OnWeaponFired(Weapon weapon)
		{
		}

		private void SetupDamageVfx()
		{
		}

		private void HandlePlayerInput()
		{
		}

		private void ProcessRawDirection()
		{
		}

		protected virtual Vector2 ProcessMovementVector(Vector2 v)
		{
			return default(Vector2);
		}

		private void Regenerate()
		{
		}

		private void SetDamageFxColor()
		{
		}

		private void InitDeathNoHurtRenderer()
		{
		}

		protected virtual bool OnCharacterOverlapsDestructible_Destroy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected virtual void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
		{
		}

		public void UpdateMagnet()
		{
		}

		protected virtual void AddAttackAnimations()
		{
		}

		private void OnMeleeAComplete()
		{
		}

		public virtual void OnMeleeAttackAnim()
		{
		}

		protected void OnRangedAComplete()
		{
		}

		public virtual void OnRangedAttackAnim()
		{
		}

		private void OnMagicAComplete()
		{
		}

		public virtual void OnMagicAttackAnim()
		{
		}

		public virtual void ClearFromSpecialAnims()
		{
		}

		public virtual void OnAttackAnim(Weapon.FiringAnimation firingAnimation)
		{
		}

		private void GetCharacterDataForCurrentLevel(int level)
		{
		}

		public void ShowMultiplayerIndicator()
		{
		}

		protected void SetCustomOutlineReferenceRenderer(SpriteRenderer referenceRenderer)
		{
		}

		protected void SetOutlineOffsetNegative()
		{
		}

		protected virtual void SetCharacterSprite()
		{
		}

		private void SetSpriteForSkin(CharacterData skinData)
		{
		}

		private CharacterData SetSkin(SkinType skinType, CharacterData skinData)
		{
			return null;
		}

		protected virtual void SetupAnimation()
		{
		}

		public Color GetCoopColour()
		{
			return default(Color);
		}

		protected virtual void InternalUpdate()
		{
		}

		public void SetSortgingOrder(bool value, int order = 0)
		{
		}

		public virtual void PlayWalkingAnimations()
		{
		}

		private void SetHealthToMax()
		{
		}

		public virtual void OnDeath()
		{
		}

		protected virtual void ScheduleDeathConsequences()
		{
		}

		public virtual void Despawn()
		{
		}

		public void GiveReward(Action<Pickup> onRewardGiven = null)
		{
		}

		protected void StopParticleFX()
		{
		}

		protected void PlayDamageParticleFX()
		{
		}

		public virtual bool ShouldCollideWithWalls()
		{
			return false;
		}

		private void EditorLogPlayerStats()
		{
		}

		public List<Vector2> GetHeadOffsets()
		{
			return null;
		}

		public void ApplySkinModifiers()
		{
		}

		public void AddSkinWeapons()
		{
		}

		public void ResetStats()
		{
		}

		public void PlayerStatsUpgrade(ModifierStats other, bool multiplicativeMaxHp = false)
		{
		}

		public void AddValueToAttribute(CharacterController character, WeaponType weaponType, float value)
		{
		}

		public void AddActiveRapidFire(float cooldownChange, float speedChange, float duration)
		{
		}

		public void AddActiveHeartRefresh(float statChange1, float statChange2, float duration)
		{
		}

		public void AddActiveKarmaCoin()
		{
		}

		public void AddActiveMirrorOfTruth(float statChange1, float statChange2, float duration)
		{
		}

		public virtual void SetExtraVisualsVisible(bool show)
		{
		}

		public void SetMovementAI(AIType aiType, CharacterController followedCharacter = null)
		{
		}

		public virtual bool DoesWantPickup(Pickup pickup)
		{
			return false;
		}

		public virtual void OnPickupCollected(Pickup pickup)
		{
		}

		public virtual bool OnTreasureCollected(TreasureChest treasure)
		{
			return false;
		}

		protected void SetCustomDamageOverlayRenderer(SpriteRenderer renderer)
		{
		}
	}
}
