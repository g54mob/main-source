using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Com.LuisPedroFonseca.ProCamera2D;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Rewired;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Cursors;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;
using VampireSurvivors.UI;
using VampireSurvivors.UI.Player;
using Zenject;

namespace VampireSurvivors.Objects.Characters;

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

	private sealed class _003C_003Ec__DisplayClass446_0
	{
		public CharacterController _003C_003E4__this;

		public bool instantRevival;

		internal void _003CTriggerOnlineRevival_003Eb__0()
		{
			_003C_003E4__this.DoMultiplayerRevival(instantRevival);
		}
	}

	private sealed class _003C_003Ec__DisplayClass476_0
	{
		public CharacterController _003C_003E4__this;

		public float percentage;

		internal void _003COnlineRevival_003Eb__0()
		{
			_003C_003E4__this.PerformRevival(percentage);
		}
	}

	private sealed class _003C_003Ec__DisplayClass517_0
	{
		public CharacterController _003C_003E4__this;

		public CoherenceSync player;

		internal void _003CReportBody_003Eb__0()
		{
			CharacterController component = player.GetComponent<CharacterController>();
			GM.Core.QueueReportBody(_003C_003E4__this, component);
		}
	}

	private sealed class _003C_003Ec__DisplayClass523_0
	{
		public Report2Weapon weapon;

		public List<EnemyType> enemies;

		public int voteTarget;

		internal void _003CEmergencyMeeting_003Eb__0()
		{
			weapon.OnlinePerformVote(enemies, voteTarget);
		}
	}

	private sealed class _003C_003Ec__DisplayClass525_0
	{
		public CharacterController _003C_003E4__this;

		public int weaponType;

		internal void _003COnlineApplyWeaponLevelUp_003Eb__0()
		{
			_003C_003E4__this.ApplyWeaponLevelUp((WeaponType)weaponType);
		}
	}

	private sealed class _003C_003Ec__DisplayClass527_0
	{
		public CharacterController _003C_003E4__this;

		public int weaponType;

		public float value;

		internal void _003CAddAttributeOnline_003Eb__0()
		{
			_003C_003E4__this.AddAttribute((WeaponType)weaponType, value);
		}
	}

	private sealed class _003C_003Ec__DisplayClass561_0
	{
		public CharacterController _003C_003E4__this;

		public bool ignoreInvulnerabilityForRestoringTint;

		internal void _003COnGetDamaged_003Eb__0()
		{
			CharacterController characterController = _003C_003E4__this;
			characterController._receivingDamage = false;
			CharacterController characterController2 = _003C_003E4__this;
			if (characterController2._isInvul)
			{
				_003C_003E4__this.RestoreTint();
			}
			CharacterController characterController3 = _003C_003E4__this;
			characterController3._damageVfx.Stop();
		}
	}

	private sealed class _003C_003Ec__DisplayClass604_0
	{
		public SkinType skinType;

		internal bool _003CSetSkin_003Eb__0(Skin x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if (x != null)
			{
				object obj = x.skinType - skinType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CSetSkin_003Eb__1(Skin x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if (x != null)
			{
				object obj = x.skinType - skinType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003CAddCursor_003Ed__458(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public CharacterController _003C_003E4__this;

		private string _003Chex_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_00cd: Expected I4, but got I8
			//IL_029c: Expected I4, but got O
			//IL_006d: Expected O, but got Ref
			CharacterController characterController = _003C_003E4__this;
			PlayerInfo playerInfo;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					goto IL_028e;
				}
				if (characterController._PlayerIndex == -1)
				{
					goto IL_025b;
				}
				Color coopColour = _003C_003E4__this.GetCoopColour();
				float r = default(float);
				string text = ColorUtility.ToHtmlStringRGB((Color)(&r));
				_003Chex_003E5__2 = text;
				playerInfo = null;
				r = coopColour.r;
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_025b;
				}
				_003C_003E1__state = -1;
				if ((object)OnlineStageManager._instance == null)
				{
					goto IL_028e;
				}
				PlayerInfo playerInfoForCharacter = OnlineStageManager._instance.GetPlayerInfoForCharacter(_003C_003E4__this);
				playerInfo = playerInfoForCharacter;
			}
			if ((object)playerInfo != null && ((UnityEngine.Object)playerInfo).m_CachedPtr != (IntPtr)0)
			{
				CursorData cursorData = new CursorData();
				cursorData.IconAlpha = 1f;
				cursorData._cursorProportionOfScreenFromCenter = 0.45f;
				cursorData.AnimationName = "arrowNeutral_0";
				cursorData.AnimationStartingFrame = 1;
				cursorData.AnimationFramesCount = 8;
				cursorData.AnimationFrameRate = 16;
				Sprite sprite = SpriteManager.GetSprite("arrowNeutral_01", "UI");
				cursorData.CursorSprite = sprite;
				cursorData.CursorScale = 2f;
				cursorData.CursorAlpha = 1f;
				string cursorColorHex = "#" + _003Chex_003E5__2;
				cursorData.CursorColorHex = cursorColorHex;
				cursorData.Text = playerInfo._003CUserName_003Ek__BackingField;
				if ((object)_003C_003E4__this != null)
				{
					GameObject gameObject = _003C_003E4__this.gameObject;
					if (characterController._signalBus != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4920");
						goto IL_025b;
					}
				}
				goto IL_028e;
			}
			_003C_003E2__current = null;
			_003C_003E1__state = 1;
			return true;
			IL_028e:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_025b:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CQueueWeaponSelectionInternal_003Ed__531(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public CharacterController _003C_003E4__this;

		public string selectionType;

		public WeaponType type;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_00ae: Expected I4, but got I8
			//IL_0036: Expected I4, but got O
			//IL_0061: Expected O, but got Ref
			//IL_01b4: Expected I4, but got O
			CharacterController characterController = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				GM.Core.QueueOpenWeaponSelection(characterController, selectionType);
				object obj = default(object);
				object arg = (WeaponType)obj;
				System.ParamsArray paramsArray = new System.ParamsArray(arg, selectionType);
				object obj2 = default(object);
				string message = string.FormatHelper((IFormatProvider)null, "Add to EnterWeaponSelectionList weaponType = {0}, selectionType = {1}", (System.ParamsArray)(&obj2));
				Debug.Log(message);
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_01e4;
				}
				_003C_003E1__state = -1;
			}
			Weapon weaponByTypeFromAnyCollection = characterController._weaponsManager.GetWeaponByTypeFromAnyCollection(type);
			if ((object)weaponByTypeFromAnyCollection != null && ((UnityEngine.Object)weaponByTypeFromAnyCollection).m_CachedPtr != (IntPtr)0)
			{
				GameManager core = GM.Core;
				Weapon weapon = core._weaponsFacade.RemoveWeapon(type, characterController);
				WeaponData currentWeaponData = weaponByTypeFromAnyCollection._currentWeaponData;
				if ((object)currentWeaponData._003CaddEvolvedWeapon_003Ek__BackingField != null)
				{
					GameManager core2 = GM.Core;
					WeaponData currentWeaponData2 = weaponByTypeFromAnyCollection._currentWeaponData;
					if ((object)currentWeaponData2._003CaddEvolvedWeapon_003Ek__BackingField == null)
					{
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
						bool result = default(bool);
						return result;
					}
					WeaponType weapon2 = (WeaponType)((object?)currentWeaponData2._003CaddEvolvedWeapon_003Ek__BackingField >> 32);
					core2._levelUpFactory.AddLateWeapon(weapon2, characterController);
				}
				GM.Core.SetSeenWeapon(type);
				goto IL_01e4;
			}
			_003C_003E2__current = null;
			_003C_003E1__state = 1;
			return true;
			IL_01e4:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	public Vector2 CurrentDefaultMapPosition;

	private uint _003CRandomEnemyPickerSeed_003Ek__BackingField;

	protected int _PlayerIndex;

	protected SpriteRenderer _CharacterRenderer;

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

	private bool _003CTrackedByCamera_003Ek__BackingField;

	public float MoveSpeedMultiplier;

	public float ArmorManualIncrease;

	public List<WeaponType> GlimmeredTechniques;

	private Action m_OnRevivalStarted;

	public float SvMult_AnyRare;

	public float SvMult_Foil;

	public float SvMult_Gala;

	public float SvMult_Poly;

	public float SvMult_Holo;

	public float SvMult_Inve;

	public float SvMult_Base;

	public CharacterSkillCardsManager CharacterSkillCardsManager;

	private float _003CSkillCards_Mult_003Ek__BackingField;

	public float TempCurse;

	private uint _003CFollowerLevelUpShuffleSeed_003Ek__BackingField;

	private bool _003CAlwaysCoinBag_003Ek__BackingField;

	private bool _003CAlwaysRoast_003Ek__BackingField;

	private bool _003CAlwaysRandomLimitBreak_003Ek__BackingField;

	public bool IsFollowerSharingPassives;

	public bool IsFollowerReactingToArcanas;

	private float2 _003CExternalVelocity_003Ek__BackingField;

	private bool _003CCountsAsMainCharacterForRevivals_003Ek__BackingField;

	private float _003CSilentCooldown_003Ek__BackingField;

	private float _003CSilentMight_003Ek__BackingField;

	private string _003CCurrentWalkAnimName_003Ek__BackingField;

	private bool _003CIsPlatformMovementActive_003Ek__BackingField;

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

	public int SyncedCharacterType
	{
		get
		{
			return (int)_characterType;
		}
		set
		{
			_characterType = (CharacterType)value;
		}
	}

	public int SyncedSkinType
	{
		get
		{
			return (int)_skinType;
		}
		set
		{
			_skinType = (SkinType)value;
		}
	}

	public bool IsFlipped
	{
		get
		{
			return _isFlipped;
		}
		set
		{
			_isFlipped = value;
		}
	}

	public float CurrentHp
	{
		get
		{
			return _currentHp;
		}
		set
		{
			_currentHp = value;
		}
	}

	public uint RandomEnemyPickerSeed
	{
		get
		{
			return _003CRandomEnemyPickerSeed_003Ek__BackingField;
		}
		set
		{
			_003CRandomEnemyPickerSeed_003Ek__BackingField = value;
		}
	}

	public bool ShowHealthBar
	{
		get
		{
			//IL_00a7: Expected I4, but got O
			HealthBar healthBar = _healthBar;
			if ((object)_healthBar != null && ((UnityEngine.Object)healthBar).m_CachedPtr != (IntPtr)0)
			{
				if ((object)_healthBar != null)
				{
					GameObject gameObject = _healthBar.gameObject;
					if ((object)gameObject != null)
					{
						return gameObject.activeInHierarchy;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return false;
		}
		set
		{
			HealthBar healthBar = _healthBar;
			if ((object)_healthBar != null && ((UnityEngine.Object)healthBar).m_CachedPtr != (IntPtr)0)
			{
				GameObject gameObject = _healthBar.gameObject;
				gameObject.SetActive(value);
			}
		}
	}

	public unsafe float HealthBarScale
	{
		get
		{
			HealthBar healthBar = _healthBar;
			if ((object)_healthBar != null && ((UnityEngine.Object)healthBar).m_CachedPtr != (IntPtr)0)
			{
				Transform transform = _healthBar.transform;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				float ret;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				return ret;
			}
			return 1f;
		}
		set
		{
			HealthBar healthBar = _healthBar;
			if ((object)_healthBar != null && ((UnityEngine.Object)healthBar).m_CachedPtr != (IntPtr)0)
			{
				HealthBar healthBar2 = RenderingExtensions.SetScale(_healthBar, value);
			}
		}
	}

	public unsafe ref Unity.Mathematics.Random RandomEnemyPickerGenerator
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Expected Ref, but got Unknown
			return ref *(Unity.Mathematics.Random*)(this + 176);
		}
	}

	public bool IsDead
	{
		get
		{
			if (_isDead)
			{
				return true;
			}
			return IsDisconnectedFromOnlinePlay;
		}
		set
		{
			_isDead = value;
		}
	}

	public bool PermanentInvulnerability
	{
		get
		{
			return _permanentInvulnerability;
		}
		set
		{
			_permanentInvulnerability = value;
		}
	}

	public bool TrackedByCamera
	{
		get
		{
			return _003CTrackedByCamera_003Ek__BackingField;
		}
		set
		{
			_003CTrackedByCamera_003Ek__BackingField = value;
		}
	}

	public bool IsCoffinVisible
	{
		get
		{
			//IL_0041: Expected I4, but got O
			if ((object)_multiplayerRevivalUI != null)
			{
				return _multiplayerRevivalUI.IsVisible();
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public virtual float LootMult_Rosary => 1f;

	public virtual float LootMult_Orologion => 1f;

	public virtual float LootMult_Rerollo => 1f;

	public float SkillCards_Mult
	{
		get
		{
			return _003CSkillCards_Mult_003Ek__BackingField;
		}
		set
		{
			_003CSkillCards_Mult_003Ek__BackingField = value;
		}
	}

	public int Level
	{
		get
		{
			return _level;
		}
		set
		{
			_level = value;
		}
	}

	public int MaxWeaponCount
	{
		get
		{
			return _maxWeaponBonus + _maxWeaponCount;
		}
		set
		{
			_maxWeaponCount = value;
		}
	}

	public int MaxAccessoryCount => _maxAccessoryBonus + _maxAccessoryCount;

	public int MaxWeaponBonus
	{
		get
		{
			return _maxWeaponBonus;
		}
		set
		{
			_maxWeaponBonus = value;
		}
	}

	public int MaxAccessoryBonus
	{
		get
		{
			return _maxAccessoryBonus;
		}
		set
		{
			_maxAccessoryBonus = value;
		}
	}

	public float DefaultSpriteWidth => _defaultSpriteWidth;

	public PlayerModifierStats PlayerStats => _playerStats;

	public CoherenceSync Sync => _coherenceSync;

	public PetManager PetManager
	{
		get
		{
			PetManager petManager = _petManager;
			if ((object)_petManager == null || ((UnityEngine.Object)petManager).m_CachedPtr == (IntPtr)0)
			{
				GameObject gameObject = base.gameObject;
				if ((object)gameObject != null)
				{
					PetManager petManager2 = gameObject.AddComponent<PetManager>();
					_petManager = petManager2;
					PetManager petManager3 = _petManager;
					if ((object)_petManager != null)
					{
						List<PetInstance> pets = new List<PetInstance>();
						petManager3._pets = pets;
						petManager3._owner = this;
						goto IL_00aa;
					}
				}
				return (PetManager)(object)new NullReferenceException();
			}
			goto IL_00aa;
			IL_00aa:
			return _petManager;
		}
	}

	public CharacterADControl DeficiencyControl => _deficiencyControl;

	public PickupMode PickupMode
	{
		get
		{
			return _pickupMode;
		}
		set
		{
			_pickupMode = value;
		}
	}

	public int SyncedPickupMode
	{
		get
		{
			return (int)_pickupMode;
		}
		set
		{
			_pickupMode = (PickupMode)value;
		}
	}

	public uint FollowerLevelUpShuffleSeed
	{
		get
		{
			return _003CFollowerLevelUpShuffleSeed_003Ek__BackingField;
		}
		set
		{
			_003CFollowerLevelUpShuffleSeed_003Ek__BackingField = value;
		}
	}

	public bool AlwaysCoinBag
	{
		get
		{
			return _003CAlwaysCoinBag_003Ek__BackingField;
		}
		set
		{
			_003CAlwaysCoinBag_003Ek__BackingField = value;
		}
	}

	public bool AlwaysRoast
	{
		get
		{
			return _003CAlwaysRoast_003Ek__BackingField;
		}
		set
		{
			_003CAlwaysRoast_003Ek__BackingField = value;
		}
	}

	public bool AlwaysRandomLimitBreak
	{
		get
		{
			return _003CAlwaysRandomLimitBreak_003Ek__BackingField;
		}
		set
		{
			_003CAlwaysRandomLimitBreak_003Ek__BackingField = value;
		}
	}

	public ModifierStats OnEveryLevelUp => _onEveryLevelUp;

	public Transform CachedTransform => _cachedTransform;

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
			float num = PMoveSpeed();
			float deltaTime = PauseSystem.DeltaTime;
			Vector2 result = default(Vector2);
			return result;
		}
	}

	public Vector2 ScaledVelocity
	{
		get
		{
			object obj = default(object);
			float num4;
			do
			{
				float num = PMoveSpeed();
				float num2 = (float)obj * GameManager.PlayerPxSpeed;
				float num3 = num2 * _slowMultiplier;
				num4 = num3 * _debuffSlow;
			}
			while (!(-2.1474836E+09f > num4) && num4 > 2.1474836E+09f);
			Vector2 result = default(Vector2);
			return result;
		}
	}

	public float2 ExternalVelocity
	{
		get
		{
			float2 result = default(float2);
			return result;
		}
		set
		{
			_003CExternalVelocity_003Ek__BackingField = value;
		}
	}

	public float FrameWalk
	{
		get
		{
			//IL_000a: Expected I, but got O
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			nint num = (nint)this;
			float num2 = PMoveSpeed();
			object obj = this + 368;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
			object obj2 = default(object);
			float num3 = GameManager.PlayerPxSpeed * (float)obj2;
			return (float)obj2 * num3;
		}
	}

	public float Walked
	{
		get
		{
			return _walked;
		}
		set
		{
			_walked = value;
		}
	}

	public bool IsDisconnectedFromOnlinePlay
	{
		get
		{
			//IL_0049: Expected O, but got I4
			GameObject gameObject = base.gameObject;
			bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			object obj = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			return obj == null;
		}
	}

	private float Speed
	{
		get
		{
			float num = PMoveSpeed();
			float deltaTime = PauseSystem.DeltaTime;
			object obj = default(object);
			float num2 = GameManager.PlayerPxSpeed * (float)obj;
			return deltaTime * num2;
		}
	}

	public Vector2 LastFacingDirection
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
		private set
		{
			_lastFacingDirection = value;
		}
	}

	public bool ActionButtonPressed => _actionButtonPressed;

	public Vector2 CurrentDirection
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
		set
		{
			_currentDirection = value;
		}
	}

	public Vector2 CurrentDirectionRaw
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
		set
		{
			_currentDirectionRaw = value;
		}
	}

	public Vector2 LastMovementDirection
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
	}

	public SpriteTrail rtGhosts => _spriteTrail;

	public float Xp
	{
		get
		{
			return _xp;
		}
		set
		{
			_xp = value;
		}
	}

	public bool IsAnimForced
	{
		get
		{
			return _isAnimForced;
		}
		set
		{
			_isAnimForced = value;
		}
	}

	public bool CanFlip
	{
		get
		{
			return _canFlip;
		}
		set
		{
			_canFlip = value;
		}
	}

	public Player PlayerInput => _player;

	public List<WeaponType> weaponSelection
	{
		get
		{
			return _weaponSelection;
		}
		set
		{
			_weaponSelection = value;
		}
	}

	public WeaponType StartingWeaponType => _startingWeaponType;

	public CharacterWeaponsManager WeaponsManager => _weaponsManager;

	public CharacterAccessoriesManager AccessoriesManager => _accessoriesManager;

	public CharacterData CurrentCharacterData => _currentCharacterData;

	public CharacterData CurrentSkinData => _currentSkinData;

	public CharacterType CharacterType => _characterType;

	public float MultiplayerRevivalProportion => _multiplayerRevivalProportion;

	public bool MultiplayerRevivalAllowed => _multiplayerRevivalAllowed;

	public bool CountsAsMainCharacterForRevivals
	{
		get
		{
			return _003CCountsAsMainCharacterForRevivals_003Ek__BackingField;
		}
		set
		{
			_003CCountsAsMainCharacterForRevivals_003Ek__BackingField = value;
		}
	}

	public Transform CameraTarget
	{
		get
		{
			if (!ShouldStopAtScreenEdge())
			{
				return base.transform;
			}
			Transform multiplayerCameraTargetTransform = _multiplayerCameraTargetTransform;
			if ((object)_multiplayerCameraTargetTransform == null || ((UnityEngine.Object)multiplayerCameraTargetTransform).m_CachedPtr == (IntPtr)0)
			{
				GameObject gameObject = new GameObject();
				GameObject.Internal_CreateGameObject(gameObject, (string)null);
				Transform multiplayerCameraTargetTransform2 = gameObject.transform;
				_multiplayerCameraTargetTransform = multiplayerCameraTargetTransform2;
				Transform parent = base.transform;
				_multiplayerCameraTargetTransform.SetParent(parent, worldPositionStays: true);
			}
			GameManager core = GM.Core;
			bool flag = (object)GM.Core == null;
			bool flag2 = (object)core.CoopConfig == null;
			bool flag3 = (object)_multiplayerCameraTargetTransform == null;
			Transform transform = _multiplayerCameraTargetTransform.transform;
			bool flag4 = (object)transform == null;
			bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			return _multiplayerCameraTargetTransform;
		}
	}

	public bool IsLastBreathEnabled
	{
		get
		{
			return _isLastBreathEnabled;
		}
		set
		{
			_isLastBreathEnabled = value;
		}
	}

	public bool HasLastBreath
	{
		get
		{
			return _hasLastBreath;
		}
		set
		{
			_hasLastBreath = value;
		}
	}

	public Action OnLastBreath
	{
		get
		{
			return _onLastBreath;
		}
		set
		{
			_onLastBreath = value;
		}
	}

	public bool HasAnyCriticalHPSkill
	{
		get
		{
			return _hasAnyCriticalHPSkill;
		}
		set
		{
			_hasAnyCriticalHPSkill = value;
		}
	}

	public bool IsCriticalHPEnabled
	{
		get
		{
			return _isCriticalHPEnabled;
		}
		set
		{
			_isCriticalHPEnabled = value;
		}
	}

	public Action OnCriticalHP
	{
		get
		{
			return _onCriticalHP;
		}
		set
		{
			_onCriticalHP = value;
		}
	}

	public float ShieldInvulTime
	{
		get
		{
			return _shieldInvulTime;
		}
		set
		{
			_shieldInvulTime = value;
		}
	}

	public float CurrentInvincibilityTimer => _invincibilityTimer;

	public virtual bool HasThorns
	{
		get
		{
			return _hasThorns;
		}
		set
		{
			_hasThorns = value;
		}
	}

	public MagnetZone Magnet
	{
		get
		{
			return _magnet;
		}
		set
		{
			_magnet = value;
		}
	}

	public SineBonus SineSpeed
	{
		get
		{
			return _sineSpeed;
		}
		set
		{
			_sineSpeed = value;
		}
	}

	public SineBonus SineCooldown
	{
		get
		{
			return _sineCooldown;
		}
		set
		{
			_sineCooldown = value;
		}
	}

	public SineBonus SineArea
	{
		get
		{
			return _sineArea;
		}
		set
		{
			_sineArea = value;
		}
	}

	public SineBonus SineDuration
	{
		get
		{
			return _sineDuration;
		}
		set
		{
			_sineDuration = value;
		}
	}

	public SineBonus SineMight
	{
		get
		{
			return _sineMight;
		}
		set
		{
			_sineMight = value;
		}
	}

	public float SlowTime
	{
		get
		{
			return _slowTime;
		}
		set
		{
			_slowTime = value;
		}
	}

	public float gFeverMul
	{
		get
		{
			return _gFeverMul;
		}
		set
		{
			_gFeverMul = value;
		}
	}

	public float SilentCooldown
	{
		get
		{
			return _003CSilentCooldown_003Ek__BackingField;
		}
		set
		{
			_003CSilentCooldown_003Ek__BackingField = value;
		}
	}

	public float SilentMight
	{
		get
		{
			return _003CSilentMight_003Ek__BackingField;
		}
		set
		{
			_003CSilentMight_003Ek__BackingField = value;
		}
	}

	public SpriteAnimation SpriteAnimation => _spriteAnimation;

	public SpriteAnimation Anims => _spriteAnimation;

	public string CurrentWalkAnimName
	{
		get
		{
			return _003CCurrentWalkAnimName_003Ek__BackingField;
		}
		set
		{
			_003CCurrentWalkAnimName_003Ek__BackingField = value;
		}
	}

	public PlayerOptions PlayerOptions => _playerOptions;

	public Action<float, float> OnHpRecoveryCallback
	{
		get
		{
			return _onHpRecoveryCallback;
		}
		set
		{
			_onHpRecoveryCallback = value;
		}
	}

	public ArcadeBodyBounds WorldBoxCollider => _worldBoxCollider;

	public int Depth
	{
		get
		{
			SpriteRenderer characterRenderer = _CharacterRenderer;
			bool flag = ((UnityEngine.Object)characterRenderer).m_CachedPtr == (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 43 ConditionalJump @-1, v51 @ ZF_v5 (System.Boolean) --- -1 Nop");
			/*Error: End of method reached without returning.*/;
		}
	}

	public HealthBar HealthBar => _healthBar;

	public bool IsInFinalStage
	{
		get
		{
			return _isInFinalStage;
		}
		set
		{
			_isInFinalStage = value;
		}
	}

	public bool IsPlatformMovementActive
	{
		get
		{
			return _003CIsPlatformMovementActive_003Ek__BackingField;
		}
		set
		{
			_003CIsPlatformMovementActive_003Ek__BackingField = value;
		}
	}

	public ParticleSystem DamageBloodVfx => _damageVfx;

	public virtual bool DrainWeaponsImmunity => false;

	public virtual int GlimmerComboModifier => 0;

	public virtual bool NeedsCart => true;

	public unsafe bool IsInvul
	{
		get
		{
			return _isInvul;
		}
		set
		{
			//IL_00f4: Expected O, but got Ref
			//IL_00c3: Expected O, but got Ref
			//IL_014e: Expected O, but got I
			//IL_01cb: Expected I, but got O
			//IL_01d0->IL01b8: Incompatible stack heights: 1 vs 0
			if (_isInvul != value)
			{
				_isInvul = value;
				SpriteRenderer customDamageOverlayRenderer = _customDamageOverlayRenderer;
				Renderer renderer = (((object)_customDamageOverlayRenderer == null || ((UnityEngine.Object)customDamageOverlayRenderer).m_CachedPtr == (IntPtr)0) ? _CharacterRenderer : _customDamageOverlayRenderer);
				renderer.Internal_GetPropertyBlock(_propBlock);
				Color color = default(Color);
				if (!_isInvul)
				{
					RenderingExtensions.SetTintFillEnabled(_propBlock, isEnabled: false);
					RenderingExtensions.SetTintFillColor(_propBlock, (Color)(&color));
				}
				else
				{
					bool flag = ColorUtility.TryParseHtmlString("#ffffbb", out color);
					RenderingExtensions.SetTintFillColor(_propBlock, (Color)(&color));
					RenderingExtensions.SetTintFillEnabled(_propBlock, isEnabled: true);
				}
				MaterialPropertyBlock materialPropertyBlock = _propBlock;
				bool flag2 = ((UnityEngine.Object)renderer).m_CachedPtr == (IntPtr)0;
				if (_propBlock != null)
				{
					materialPropertyBlock = (MaterialPropertyBlock)(nint)materialPropertyBlock.m_Ptr;
				}
				Renderer.Internal_SetPropertyBlock_Injected(((UnityEngine.Object)renderer).m_CachedPtr, (IntPtr)materialPropertyBlock);
			}
		}
	}

	public float NormalizedHp
	{
		get
		{
			//IL_003a: Expected F4, but got I4
			float num = MaxHp();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187583FAFh\"");
			object obj = default(object);
			if (obj == null)
			{
				return 0f;
			}
			float num2 = MaxHp();
			return _currentHp / (float)obj;
		}
	}

	public bool IsFollower
	{
		get
		{
			return (byte)(_PlayerIndex >> 31) != 0;
		}
		set
		{
			//IL_0028: Expected I4, but got I8
			if (value)
			{
				_PlayerIndex = -1;
			}
		}
	}

	public CoherenceSync FollowedCharacter
	{
		get
		{
			if (_deficiencyControl != null)
			{
				CharacterADControl deficiencyControl = _deficiencyControl;
				CharacterController followedCharacter = deficiencyControl._followedCharacter;
				if ((object)deficiencyControl._followedCharacter != null && ((UnityEngine.Object)followedCharacter).m_CachedPtr != (IntPtr)0)
				{
					CharacterADControl deficiencyControl2 = _deficiencyControl;
					if (_deficiencyControl != null)
					{
						CharacterController followedCharacter2 = deficiencyControl2._followedCharacter;
						if ((object)deficiencyControl2._followedCharacter != null)
						{
							return followedCharacter2._coherenceSync;
						}
					}
					return (CoherenceSync)(object)new NullReferenceException();
				}
			}
			return null;
		}
		set
		{
			if ((object)value != null && ((UnityEngine.Object)value).m_CachedPtr != (IntPtr)0)
			{
				CharacterController component = value.GetComponent<CharacterController>();
				if (_deficiencyControl == null)
				{
					SetMovementAI(AIType.Masochistic, component);
				}
				CharacterADControl deficiencyControl = _deficiencyControl;
				CharacterController component2 = value.GetComponent<CharacterController>();
				deficiencyControl._followedCharacter = component2;
			}
		}
	}

	public int FollowerLevelUpType
	{
		get
		{
			//IL_003d: Expected I4, but got I8
			if (_deficiencyControl != null)
			{
				CharacterADControl deficiencyControl = _deficiencyControl;
				return (int)deficiencyControl._003CLevelupType_003Ek__BackingField;
			}
			return -1;
		}
		set
		{
			if (_deficiencyControl == null)
			{
				SetMovementAI(AIType.Masochistic);
			}
			if (value != -1 && _deficiencyControl != null)
			{
				CharacterADControl deficiencyControl = _deficiencyControl;
				deficiencyControl._003CLevelupType_003Ek__BackingField = (LevelupType)value;
			}
		}
	}

	public bool IsMainCharacterFollower
	{
		get
		{
			//IL_0045: Expected O, but got I4
			bool flag = _deficiencyControl == null;
			bool flag2 = false;
			if (!flag)
			{
				CharacterADControl deficiencyControl = _deficiencyControl;
				object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
				bool flag3 = obj == null;
				flag2 = flag3;
			}
			int num = _PlayerIndex >> 31;
			return (byte)((uint)num & (flag2 ? 1u : 0u)) != 0;
		}
	}

	public bool IsMinorFollower
	{
		get
		{
			//IL_0045: Expected O, but got I4
			bool flag = _deficiencyControl == null;
			bool flag2 = true;
			if (!flag)
			{
				CharacterADControl deficiencyControl = _deficiencyControl;
				object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
				bool flag3 = obj == null;
				flag2 = !flag3;
			}
			int num = _PlayerIndex >> 31;
			return (byte)((uint)num & (flag2 ? 1u : 0u)) != 0;
		}
	}

	public bool SkipsArcanaEffects
	{
		get
		{
			//IL_0045: Expected O, but got I4
			bool flag = _deficiencyControl == null;
			bool flag2 = true;
			if (!flag)
			{
				CharacterADControl deficiencyControl = _deficiencyControl;
				object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
				bool flag3 = obj == null;
				flag2 = !flag3;
			}
			int num = _PlayerIndex >> 31;
			return (byte)((uint)num & (flag2 ? 1u : 0u)) != 0;
		}
	}

	public virtual bool RespectAnimationXPivots => false;

	public float DebuffSlowAmount
	{
		get
		{
			return _debuffSlow;
		}
		set
		{
			_debuffSlow = value;
		}
	}

	public virtual float BloodlineDamage
	{
		get
		{
			//IL_006d: Expected F4, but got I4
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Expected O, but got Unknown
			GameManager core = GM.Core;
			ArcanaManager arcanaManager = core._arcanaManager;
			if (arcanaManager._003CHasDivineBloodline_003Ek__BackingField)
			{
				float num = MaxHp();
				object obj2 = default(object);
				object obj = obj2 - _currentHp;
				return (float)obj / 100f;
			}
			return 0f;
		}
	}

	public virtual float BloodlineArmorValue
	{
		get
		{
			//IL_005e: Expected F4, but got I4
			GameManager core = GM.Core;
			ArcanaManager arcanaManager = core._arcanaManager;
			if (arcanaManager._003CHasDivineBloodline_003Ek__BackingField)
			{
				float num = PArmor();
				object obj = default(object);
				return (float)obj * 0.5f;
			}
			return 0f;
		}
	}

	public virtual float2 GetVectorWhipOffset
	{
		get
		{
			CheckRenderer();
			if ((object)base._spriteRenderer != null)
			{
				Vector2 vector = base._spriteRenderer.size;
				bool flag = base.flipX;
				CheckRenderer();
				if ((object)base._spriteRenderer != null)
				{
					Vector2 vector2 = base._spriteRenderer.size;
					float2 result = default(float2);
					return result;
				}
			}
			return (float2)new NullReferenceException();
		}
	}

	public unsafe virtual float GetSpriteWhipOffset
	{
		get
		{
			CheckRenderer();
			if ((object)base._spriteRenderer != null)
			{
				Sprite sprite = base._spriteRenderer.sprite;
				if ((object)sprite != null)
				{
					bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
					float ret;
					Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)(&ret));
					object obj = default(object);
					return (float)obj * 0.0035f;
				}
			}
			throw new NullReferenceException();
		}
	}

	public event Action OnRevivalStarted
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 864;
			Delegate obj2 = this.m_OnRevivalStarted;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 864;
			Delegate obj2 = this.m_OnRevivalStarted;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public void AddSkillCard(CharacterSkillCard_Base card)
	{
		//IL_0008: Expected I, but got O
		nint num = (nint)card;
		card.SetLinkedCharacter(this);
		CharacterSkillCardsManager characterSkillCardsManager = CharacterSkillCardsManager;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1A80");
		card.InitialActivate();
		OnSkillCardAdded(card);
	}

	public virtual void OnSkillCardAdded(CharacterSkillCard_Base card)
	{
	}

	public void SetStartingWeaponFromWeaponSelector(WeaponType weaponType)
	{
		_startingWeaponType = weaponType;
	}

	public virtual float GetThornDamage(EnemyController enemy)
	{
		PlayerModifierStats playerStats = _playerStats;
		return playerStats._003CThorns_003Ek__BackingField + ArcanaManager.ThornsValue;
	}

	public virtual WeaponType GetFourthLevelUpOption()
	{
		return WeaponType.VOID;
	}

	public unsafe bool HasSeraphicCry(out SantaJavelin2Weapon seraphicCry)
	{
		//IL_02b6: Expected I4, but got O
		//IL_0055: Expected I, but got O
		//IL_0063: Expected I, but got O
		//IL_0073: Expected O, but got I
		//IL_00f3: Expected O, but got I4
		//IL_00af: Expected O, but got I
		//IL_00e5: Expected O, but got I4
		//IL_01a9: Expected I, but got O
		//IL_01b7: Expected I, but got O
		//IL_01c7: Expected O, but got I
		//IL_0247: Expected O, but got I4
		//IL_0203: Expected O, but got I
		//IL_0239: Expected O, but got I4
		if ((object)_weaponsManager == null)
		{
			goto IL_02a8;
		}
		Weapon weaponByType = _weaponsManager.GetWeaponByType(WeaponType.SANTAJAVELIN2);
		Weapon weapon;
		Weapon weapon2;
		if ((object)weaponByType == null)
		{
			weapon = null;
			weapon2 = null;
			goto IL_02d5;
		}
		nint num = (nint)weaponByType;
		nint num2 = (nint)typeof(SantaJavelin2Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.SantaJavelin2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.SantaJavelin2Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ r9_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v57+FFFFFFF8+v114 @ rax_v52*8]");
			if (0 == (nint)typeof(SantaJavelin2Weapon))
			{
				obj3 = 1;
				goto IL_02e2;
			}
		}
		obj3 = 0;
		goto IL_02e2;
		IL_0339:
		object obj4;
		Weapon weaponByType2;
		if (obj4 != null)
		{
			weapon = weaponByType2;
		}
		goto IL_032c;
		IL_02d5:
		ref SantaJavelin2Weapon reference = ref *(SantaJavelin2Weapon*)weapon2;
		SantaJavelin2Weapon santaJavelin2Weapon = seraphicCry;
		if ((object)seraphicCry != null && ((UnityEngine.Object)santaJavelin2Weapon).m_CachedPtr != (IntPtr)0)
		{
			goto IL_0259;
		}
		if ((object)_weaponsManager == null)
		{
			goto IL_02a8;
		}
		weaponByType2 = _weaponsManager.GetWeaponByType(WeaponType.SANTAJAVELIN2, searchHidden: true);
		if ((object)weaponByType2 == null)
		{
			goto IL_032c;
		}
		nint num4 = (nint)weaponByType2;
		nint num5 = (nint)typeof(SantaJavelin2Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v497 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.SantaJavelin2Weapon>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v497 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.SantaJavelin2Weapon>)+130]");
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ rax_v38+FFFFFFF8+v498 @ rax_v34*8]");
			if (0 == (nint)typeof(SantaJavelin2Weapon))
			{
				obj4 = 1;
				goto IL_0339;
			}
		}
		obj4 = 0;
		goto IL_0339;
		IL_032c:
		reference = ref *(SantaJavelin2Weapon*)weapon;
		goto IL_0259;
		IL_0259:
		SantaJavelin2Weapon santaJavelin2Weapon2 = seraphicCry;
		if ((object)seraphicCry != null)
		{
			bool flag = ((UnityEngine.Object)santaJavelin2Weapon2).m_CachedPtr == (IntPtr)0;
			return !flag;
		}
		return false;
		IL_02a8:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_02e2:
		bool flag2 = obj3 == null;
		weapon = null;
		weapon2 = null;
		if (!flag2)
		{
			weapon = null;
			weapon2 = weaponByType;
		}
		goto IL_02d5;
	}

	public bool IsInvulnerabilityWindowActive()
	{
		bool flag = _isInvul;
		bool result = true;
		if (!flag)
		{
			result = _receivingDamage;
		}
		return result;
	}

	private void Construct(SignalBus signalBus, DataManager dataManager, PlayerOptions playerOptions, GameManager gameManager)
	{
		_signalBus = signalBus;
		_dataManager = dataManager;
		_playerOptions = playerOptions;
		GameManager gameManager2 = default(GameManager);
		_gameManager = gameManager2;
	}

	private void Awake()
	{
		//IL_04c0: Expected O, but got I4
		//IL_0098: Expected O, but got I
		//IL_0305: Expected I4, but got O
		//IL_02bc: Expected I, but got O
		//IL_02d8: Expected O, but got I
		//IL_034e: Expected I4, but got I8
		//IL_036a: Expected O, but got I4
		//IL_02f5->IL02f5: Incompatible stack heights: 1 vs 0
		CharacterController_Support characterController_Support = null;
		characterController_Support.controller = this;
		_classSupport = characterController_Support;
		CoherenceSync component = GetComponent<CoherenceSync>();
		_coherenceSync = component;
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rcx_v119 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rcx_v119 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ rcx_v119 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				goto IL_045a;
			}
		}
		uint num = (uint)UnityEngine.Random.RandomRangeInt(1, 2147483647);
		_003CRandomEnemyPickerSeed_003Ek__BackingField = num;
		goto IL_045a;
		IL_045a:
		int num2 = (int)(_003CRandomEnemyPickerSeed_003Ek__BackingField << 13);
		int num3 = (int)_003CRandomEnemyPickerSeed_003Ek__BackingField ^ num2;
		_onHpRecoveryCallback = null;
		int num4 = num3 >> 17;
		int num5 = num3 ^ num4;
		int num6 = num5 << 5;
		int num7 = num6 ^ num5;
		_randomEnemyPickerRng = (Unity.Mathematics.Random)num7;
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		IntPtr ptr = MaterialPropertyBlock.CreateImpl();
		materialPropertyBlock.m_Ptr = ptr;
		_propBlock = materialPropertyBlock;
		Transform cachedTransform = base.transform;
		_cachedTransform = cachedTransform;
		SpriteAnimation componentInChildren = GetComponentInChildren<SpriteAnimation>();
		_spriteAnimation = componentInChildren;
		CharacterWeaponsManager component2 = GetComponent<CharacterWeaponsManager>();
		_weaponsManager = component2;
		CharacterAccessoriesManager component3 = GetComponent<CharacterAccessoriesManager>();
		_accessoriesManager = component3;
		SpriteTrail component4 = _CharacterRenderer.GetComponent<SpriteTrail>();
		_spriteTrail = component4;
		HealthBar componentInChildren2 = GetComponentInChildren<HealthBar>();
		_healthBar = componentInChildren2;
		GameManager core = GM.Core;
		CoopConfig coopConfig = core.CoopConfig;
		Transform parent = base.transform;
		MultiplayerRevivalUI multiplayerRevivalUI = UnityEngine.Object.Instantiate(coopConfig._multiplayerRevivalUIPrefab, parent, worldPositionStays: false);
		_multiplayerRevivalUI = multiplayerRevivalUI;
		GameManager core2 = GM.Core;
		CoopConfig coopConfig2 = core2.CoopConfig;
		Transform parent2 = base.transform;
		PlayerIndicator playerIndicator = UnityEngine.Object.Instantiate(coopConfig2._playerIndicatorUIPrefab, parent2, worldPositionStays: false);
		SpriteRenderer component5 = playerIndicator.GetComponent<SpriteRenderer>();
		_multiplayerIndicator = component5;
		SpriteOutlinerControl componentInChildren3 = GetComponentInChildren<SpriteOutlinerControl>(includeInactive: true);
		_multiplayerOutliner = componentInChildren3;
		CharacterLightManager componentInChildren4 = GetComponentInChildren<CharacterLightManager>(includeInactive: true);
		_characterLightManager = componentInChildren4;
		SetupDamageVfx();
		base.angle = -5f;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num8 = (nint)array;
			Transform cachedTransform2 = _cachedTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1624 @ rcx_v76 (Il2CppClass<VampireSurvivors.UI.PlayerIndicator>)+40]");
			PlayerIndicator playerIndicator2 = UnityEngine.Object.Instantiate((PlayerIndicator)(object)cachedTransform2, (Transform)0, worldPositionStays: false);
			bool flag3 = (object)playerIndicator2 == null;
		}
		PlayerIndicator playerIndicator3 = UnityEngine.Object.Instantiate((PlayerIndicator)(object)array, null, (byte)(int)_cachedTransform != 0);
		tweenConfig.targets = array;
		tweenConfig.duration = 250f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.repeat = -1;
		tweenConfig.yoyo = true;
		tweenConfig.angle = (float?)(object)1;
		MultiTargetTween wiggleTween = Tweens.Add(tweenConfig);
		_wiggleTween = wiggleTween;
		_wiggleTween.Pause();
		base.angle = 0f;
	}

	private bool ShouldStopAtScreenEdge()
	{
		//IL_00ff: Expected O, but got I4
		//IL_0242: Expected O, but got I4
		//IL_017c: Expected I, but got O
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			int playerCount = core._multiplayer.GetPlayerCount();
			if (playerCount > 1 || core._multiplayer.IsOnlineMultiplayer || _PlayerIndex >> 31 != 0)
			{
				return true;
			}
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null && core2._characters != null)
			{
				List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
				while (true)
				{
					if (enumerator.MoveNext())
					{
						object obj = 0;
						bool flag = (object)this == null;
						bool flag2 = !flag;
						object obj2 = !flag2;
						if (obj2 == null)
						{
							if ((object)this == null)
							{
								nint num = (nint)typeof(UnityEngine.Object);
								throw new NullReferenceException();
							}
							if (((UnityEngine.Object)this).m_CachedPtr != (IntPtr)0)
							{
								break;
							}
						}
						continue;
					}
					return false;
				}
				throw new NullReferenceException();
			}
		}
		throw new NullReferenceException();
	}

	protected override void OnUpdate()
	{
		//IL_0b46: Expected O, but got I
		//IL_001f: Expected O, but got I
		//IL_008e: Expected O, but got I
		//IL_01f6: Expected O, but got F4
		//IL_0322: Expected O, but got I
		//IL_036c: Expected O, but got I
		//IL_03fb: Expected O, but got I
		//IL_03b0: Expected F4, but got I
		//IL_03c0: Expected F4, but got I
		//IL_042d: Expected O, but got I
		//IL_0444: Expected F4, but got O
		//IL_0491: Expected F4, but got O
		//IL_0c93: Expected O, but got F4
		//IL_0595: Invalid comparison between I4 and F4
		//IL_05a7: Expected F4, but got I4
		//IL_0d09: Expected O, but got I4
		//IL_0e5e: Expected O, but got I4
		//IL_0d32: Expected O, but got I4
		//IL_0ccd: Expected I, but got O
		//IL_0cd1: Expected O, but got I4
		//IL_0558: Expected F4, but got O
		//IL_0568: Expected F4, but got I
		//IL_0578: Expected F4, but got I
		//IL_0d49: Expected O, but got F4
		//IL_066d: Expected F4, but got O
		//IL_0534: Expected O, but got I
		//IL_0540: Expected F4, but got O
		//IL_0922: Expected O, but got I
		//IL_0d8d: Invalid comparison between O and F4
		//IL_06df: Expected F4, but got O
		//IL_0dc5: Expected O, but got F4
		//IL_06b3: Invalid comparison between F4 and O
		//IL_097d: Expected O, but got I
		//IL_06f2: Expected I, but got O
		//IL_070b: Expected F4, but got O
		//IL_071b: Expected O, but got I
		//IL_0729: Invalid comparison between I4 and F4
		//IL_06d2: Expected F4, but got O
		//IL_099f: Expected O, but got I
		//IL_09af: Expected O, but got I
		//IL_09e4: Expected O, but got I
		//IL_0e03: Invalid comparison between F4 and I4
		//IL_084a: Expected O, but got F4
		//IL_0818: Expected O, but got F4
		//IL_0a3e: Expected O, but got I
		//IL_0a8d: Expected O, but got I
		//IL_0ac2: Expected O, but got I
		//IL_02e7->IL0b06: Incompatible stack heights: 1 vs 0
		//IL_030c->IL0b06: Incompatible stack heights: 1 vs 0
		//IL_0c71->IL0b06: Incompatible stack heights: 1 vs 0
		//IL_03e5->IL0b06: Incompatible stack heights: 1 vs 0
		//IL_04c3->IL0b06: Incompatible stack heights: 1 vs 0
		//IL_04ef->IL0b06: Incompatible stack heights: 1 vs 0
		//IL_0e3e->IL0b06: Incompatible stack heights: 1 vs 0
		//IL_08b9->IL00e5: Incompatible stack heights: 1 vs 0
		//IL_08e8->IL00e5: Incompatible stack heights: 1 vs 0
		//IL_057d->IL0c76: Incompatible stack heights: 2 vs 1
		//IL_051e->IL0b06: Incompatible stack heights: 2 vs 0
		//IL_090d->IL00e5: Incompatible stack heights: 1 vs 0
		//IL_0549->IL0c76: Incompatible stack heights: 2 vs 1
		//IL_0942->IL0b06: Incompatible stack heights: 1 vs 0
		//IL_0967->IL00e5: Incompatible stack heights: 1 vs 0
		//IL_098a->IL00e5: Incompatible stack heights: 1 vs 0
		//IL_09cf->IL0b06: Incompatible stack heights: 1 vs 0
		//IL_0a04->IL0b06: Incompatible stack heights: 1 vs 0
		//IL_0a29->IL0b06: Incompatible stack heights: 1 vs 0
		//IL_0a5e->IL0b06: Incompatible stack heights: 1 vs 0
		//IL_0aad->IL0b06: Incompatible stack heights: 1 vs 0
		//IL_0ae2->IL0b06: Incompatible stack heights: 1 vs 0
		//IL_0b06->IL00e5: Incompatible stack heights: 1 vs 0
		string coherenceSync = (string)(object)_coherenceSync;
		if ((object)_coherenceSync != null)
		{
			CharacterController characterController = this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (System.String)+160]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (System.String)+160]");
			if ((nint)0 == 0)
			{
				goto IL_0b79;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rax_v18+20]");
			characterController = (CharacterController)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rax_v18+20]");
			if ((nint)0 != 0)
			{
				bool flag = (byte)(nint)((UnityEngine.Object)characterController).m_CachedPtr != 0;
				if (((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)1)
				{
					object obj2 = (nint)((UnityEngine.Object)characterController).m_CachedPtr - 3;
					bool flag2 = obj2 == null;
					flag = flag2;
				}
				if (flag)
				{
					goto IL_0b79;
				}
				InternalUpdate();
				if (_classSupport != null)
				{
					_classSupport.InternalUpdate();
					UpdateBoxCollider();
					return;
				}
			}
		}
		goto IL_0b06;
		IL_084f:
		float num2;
		Vector2 velocity;
		float num;
		if (_useWorldSpaceMovementLimits)
		{
			Vector2 movement = default(Vector2);
			LimitMovementInsideWorldSpaceLimits(ref movement);
			num = num2;
			velocity = movement;
		}
		BaseBody baseBody = body;
		if (body != null)
		{
			baseBody._velocity = velocity;
			if (_deficiencyControl == null)
			{
				return;
			}
			string deficiencyControl = (string)(object)_deficiencyControl;
			if (deficiencyControl._stringLength != 13)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rbx_v14 (System.String)+50]");
			if ((nint)0 == 0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rbx_v14 (System.String)+18]");
			CharacterController characterController2 = (CharacterController)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rbx_v14 (System.String)+18]");
			if ((nint)0 != 0)
			{
				if (characterController2._isDead)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rbx_v14 (System.String)+18]");
				if (((CharacterController)0).IsDisconnectedFromOnlinePlay)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rbx_v14 (System.String)+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rbx_v14 (System.String)+18]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rbx_v14 (System.String)+20]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rax_v43+28]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rax_v43+28]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rbx_v14 (System.String)+18]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v36+28]");
							object obj6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v36+28]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rax_v44+70]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rax_v44+74]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rbx_v14 (System.String)+18]");
								object obj7 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rbx_v14 (System.String)+18]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v37+28]");
									object obj8 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v37+28]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v46+70]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rax_v46+74]");
										_ = 0;
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0b06;
		IL_0c76:
		bool flag3 = ShouldStopAtScreenEdge();
		bool flag4 = !flag3;
		float num3;
		velocity = (Vector2)num3;
		float2 float5 = default(float2);
		if (!flag4)
		{
			EdgeDistances distancesToScreenEdges = GetDistancesToScreenEdges();
			bool flag5 = !(0f < distancesToScreenEdges.xToRightUnbound);
			float num4 = 0f;
			if (!flag5)
			{
				num4 = distancesToScreenEdges.xToRightUnbound;
			}
			bool flag6 = 0 <= (nint)float5;
			float2 float6 = (float2)0;
			if (!flag6)
			{
				float6 = float5;
			}
			bool flag7 = 0 >= (nint)float5;
			float2 float7 = (float2)0;
			if (!flag7)
			{
				float7 = float5;
			}
			bool flag8 = 0 <= (nint)float5;
			float2 float8 = (float2)0;
			if (!flag8)
			{
				float8 = float5;
			}
			object obj9 = Time.deltaTime;
			float num5;
			float2 float9;
			if ((nint)float8 > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
				object obj10 = default(object);
				num4 /= (float)obj10;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
				object obj11 = default(object);
				num5 = (float)float6 / (float)obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
				object obj12 = default(object);
				float7 = (object)float7 / obj12;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
				object obj13 = default(object);
				float9 = (object)float8 / obj13;
			}
			else
			{
				float9 = float8;
				num5 = (float)float6;
			}
			if (!(num5 > num3))
			{
				if (num3 > num4)
				{
					num3 = num4;
				}
			}
			else
			{
				num3 = num5;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float9) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num))
			{
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float7))
				{
					num = (float)float7;
				}
			}
			else
			{
				num = (float)float9;
			}
			bool flag9 = _003CTrackedByCamera_003Ek__BackingField;
			num2 = num;
			velocity = (Vector2)num3;
			if (!flag9)
			{
				nint num6 = (nint)typeof(float2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1449 @ rax_v52 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
				nint num7 = 0;
				float num8 = (float)float2.zero;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1453 @ rcx_v42 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
				object obj14 = 0;
				if (!(0f > distancesToScreenEdges.xToRightUnbound))
				{
					if ((nint)float5 > 0)
					{
						float num9 = (float)float5 + num8;
						num8 = num9;
					}
				}
				else
				{
					float num10 = distancesToScreenEdges.xToRightUnbound + (float)float2.zero;
					num8 = num10;
				}
				if (0 <= (nint)float5)
				{
					if ((nint)float5 > 0)
					{
						object obj15 = (object)float5 + obj14;
						obj14 = obj15;
					}
				}
				else
				{
					object obj16 = (object)float5 + obj14;
					obj14 = obj16;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187585A51h\"");
				if (num8 == 0f)
				{
					bool flag10 = obj14 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187585A51h\"");
					num2 = num;
					velocity = (Vector2)num3;
					if (flag10)
					{
						goto IL_084f;
					}
				}
				float2 float10 = base.position;
				base.position = float5;
				num2 = num;
				velocity = (Vector2)num3;
			}
		}
		goto IL_084f;
		IL_0c4d:
		string gameManager = (string)(object)_gameManager;
		Vector2 vector;
		if ((object)_gameManager != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rbx_v11 (System.String)+168]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rbx_v11 (System.String)+168]");
				int playerCount = ((MultiplayerManager)0).GetPlayerCount();
				if (playerCount <= 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rbx_v11 (System.String)+168]");
					bool isOnlineMultiplayer = ((MultiplayerManager)0).IsOnlineMultiplayer;
					bool flag11 = !isOnlineMultiplayer;
					num3 = (float)vector;
					if (flag11)
					{
						goto IL_0c76;
					}
				}
				if (!_isDead)
				{
					bool isDisconnectedFromOnlinePlay = IsDisconnectedFromOnlinePlay;
					bool flag12 = !isDisconnectedFromOnlinePlay;
					num3 = (float)vector;
					if (flag12)
					{
						goto IL_0c76;
					}
				}
				Component multiplayerRevivalUI = _multiplayerRevivalUI;
				if ((object)_multiplayerRevivalUI != null)
				{
					GameObject gameObject = _multiplayerRevivalUI.gameObject;
					if ((object)gameObject != null)
					{
						bool flag13 = ((MultiplayerManager)(object)gameObject)._playerOptions == null;
						object obj17 = GameObject.get_activeSelf_Injected((IntPtr)((MultiplayerManager)(object)gameObject)._playerOptions);
						if (obj17 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rsi_v9 (UnityEngine.Component)+38]");
							if ((nint)0 == 0)
							{
								goto IL_0b06;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rsi_v9 (UnityEngine.Component)+38]");
							bool flag14 = ((Renderer)0).enabled;
							num3 = (float)vector;
							if (flag14)
							{
								goto IL_0c76;
							}
						}
						num3 = (float)_003CExternalVelocity_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rcx_v1 (VampireSurvivors.Objects.Characters.CharacterController)+3A8]");
						num = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rcx_v1 (VampireSurvivors.Objects.Characters.CharacterController)+3A8]");
						num2 = 0f;
						goto IL_0c76;
					}
				}
			}
		}
		goto IL_0b06;
		IL_0b9b:
		Vector2 currentDirectionRaw;
		_currentDirectionRaw = currentDirectionRaw;
		ProcessRawDirection();
		InternalUpdate();
		float axis = default(float);
		if (_classSupport != null)
		{
			_classSupport.InternalUpdate();
			object cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rbx_v9 (System.Object)+10]");
				bool flag15 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rbx_v9 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 _);
				UpdateBoxCollider();
				Vector2 scaledVelocity = ScaledVelocity;
				Vector2 vector2 = ProcessMovementVector(float5);
				if (!_isDead)
				{
					bool isDisconnectedFromOnlinePlay2 = IsDisconnectedFromOnlinePlay;
					bool flag16 = !isDisconnectedFromOnlinePlay2;
					num2 = axis;
					num = axis;
					vector = vector2;
					if (flag16)
					{
						goto IL_0c4d;
					}
				}
				string gameManager2 = (string)(object)_gameManager;
				if ((object)_gameManager != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v16 (System.String)+168]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v16 (System.String)+168]");
						int playerCount2 = ((MultiplayerManager)0).GetPlayerCount();
						bool flag17 = playerCount2 > 1;
						num2 = axis;
						num = axis;
						vector = vector2;
						if (!flag17)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v16 (System.String)+168]");
							bool isOnlineMultiplayer2 = ((MultiplayerManager)0).IsOnlineMultiplayer;
							num2 = axis;
							num = axis;
							vector = vector2;
							if (!isOnlineMultiplayer2)
							{
								vector = _003CExternalVelocity_003Ek__BackingField;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rcx_v1 (VampireSurvivors.Objects.Characters.CharacterController)+3A8]");
								num = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rcx_v1 (VampireSurvivors.Objects.Characters.CharacterController)+3A8]");
								num2 = 0f;
							}
						}
						goto IL_0c4d;
					}
				}
			}
		}
		goto IL_0b06;
		IL_023d:
		Vector2 vector3 = default(Vector2);
		currentDirectionRaw = vector3;
		goto IL_0b9b;
		IL_0b79:
		if (_deficiencyControl == null)
		{
			if (_blockInput)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
				goto IL_023d;
			}
			if (_player == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
				string text = ToString();
				string message = "Character " + text + " has no input or MovementAI set";
				Debug.LogWarning(message);
				string text2 = " has no input or MovementAI set";
				Vector2 vector4 = default(Vector2);
				currentDirectionRaw = vector4;
				goto IL_0b9b;
			}
			if (_player != null)
			{
				float axis2 = _player.GetAxis("Move Horizontal");
				if (_player != null)
				{
					axis = _player.GetAxis("Move Vertical");
					string text2 = null;
					currentDirectionRaw = (Vector2)axis2;
					goto IL_0b9b;
				}
			}
		}
		else if (_deficiencyControl != null)
		{
			vector3 = _deficiencyControl.CalculateMovement();
			goto IL_023d;
		}
		goto IL_0b06;
		IL_0b06:
		throw new NullReferenceException();
	}

	public void UpdateBoxCollider()
	{
		if (_worldBoxCollider != null && _coopMovementBoxCollider != null)
		{
			ArcadeBodyBounds worldBoxCollider = _worldBoxCollider;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			worldBoxCollider.width = renderer.width;
			ArcadeBodyBounds worldBoxCollider2 = _worldBoxCollider;
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			worldBoxCollider2.height = renderer2.height;
			ArcadeBodyBounds worldBoxCollider3 = _worldBoxCollider;
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer3 = s_scene3._renderer;
			ArcadeBodyBounds worldBoxCollider4 = _worldBoxCollider;
			float num = worldBoxCollider4.width * 0.5f;
			float x = (float)renderer3.screenCenter - num;
			worldBoxCollider3.x = x;
			PhaserScene s_scene4 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer4 = s_scene4._renderer;
			ArcadeBodyBounds worldBoxCollider5 = _worldBoxCollider;
			float num2 = worldBoxCollider5.height * 0.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rcx_v11 (PhaserScene+Renderer)+38]");
			float y = 0f - num2;
			worldBoxCollider4.y = y;
			ArcadeBodyBounds coopMovementBoxCollider = _coopMovementBoxCollider;
			ArcadeBodyBounds worldBoxCollider6 = _worldBoxCollider;
			coopMovementBoxCollider.width = worldBoxCollider5.width;
			GameManager gameManager = _gameManager;
			CoopConfig coopConfig = gameManager.CoopConfig;
			ArcadeBodyBounds coopMovementBoxCollider2 = _coopMovementBoxCollider;
			float num3 = coopConfig._physicalScreenBoundsTopOffsetPixels * 0.01f;
			float height = worldBoxCollider6.height - num3;
			coopMovementBoxCollider2.height = height;
			coopMovementBoxCollider2.x = worldBoxCollider6.x;
			GameManager gameManager2 = _gameManager;
			CoopConfig coopConfig2 = gameManager2.CoopConfig;
			ArcadeBodyBounds coopMovementBoxCollider3 = _coopMovementBoxCollider;
			float num4 = coopConfig2._physicalScreenBoundsTopOffsetPixels * 0.01f;
			float y2 = worldBoxCollider6.y - num4;
			coopMovementBoxCollider3.y = y2;
		}
	}

	private unsafe EdgeDistances GetDistancesToScreenEdges()
	{
		//IL_0013: Expected native int or pointer, but got O
		//IL_031a: Expected native int or pointer, but got O
		//IL_008b: Expected native int or pointer, but got O
		//IL_00c6: Expected native int or pointer, but got O
		//IL_017d: Expected native int or pointer, but got O
		//IL_023f: Expected native int or pointer, but got O
		//IL_02b1->IL0249: Incompatible stack heights: 1 vs 0
		//IL_0339->IL0249: Incompatible stack heights: 2 vs 0
		//IL_00e5->IL0249: Incompatible stack heights: 2 vs 0
		//IL_0114->IL0249: Incompatible stack heights: 2 vs 0
		//IL_019c->IL0249: Incompatible stack heights: 2 vs 0
		//IL_01bb->IL0249: Incompatible stack heights: 2 vs 0
		//IL_01ea->IL0249: Incompatible stack heights: 2 vs 0
		SpriteRenderer characterRenderer = _CharacterRenderer;
		EdgeDistances edgeDistances = default(EdgeDistances);
		((EdgeDistances*)(nint)edgeDistances)->xToRightUnbound = 0f;
		if ((object)_CharacterRenderer != null)
		{
			bool flag = ((UnityEngine.Object)characterRenderer).m_CachedPtr == (IntPtr)0;
			Renderer.get_bounds_Injected(((UnityEngine.Object)characterRenderer).m_CachedPtr, out Bounds ret);
			object obj2 = default(object);
			object obj = (object)ret - obj2;
			SpriteRenderer characterRenderer2 = _CharacterRenderer;
			if ((object)_CharacterRenderer != null)
			{
				bool flag2 = ((UnityEngine.Object)characterRenderer2).m_CachedPtr == (IntPtr)0;
				Renderer.get_bounds_Injected(((UnityEngine.Object)characterRenderer2).m_CachedPtr, out Bounds ret2);
				object obj4 = default(object);
				object obj3 = (object)ret2 + obj4;
				float2 float5 = base.position;
				float2 float6 = base.position;
				ArcadeBodyBounds worldBoxCollider = _worldBoxCollider;
				((EdgeDistances*)(nint)edgeDistances)->xToRightUnbound = 0f;
				if (_worldBoxCollider != null)
				{
					float num = worldBoxCollider.width + worldBoxCollider.x;
					float num2 = num - 0.02f;
					float xToRightUnbound = num2 - (float)obj3;
					((EdgeDistances*)(nint)edgeDistances)->xToRightUnbound = xToRightUnbound;
					GameManager gameManager = _gameManager;
					float num3 = worldBoxCollider.x + 0.02f;
					float xToLeftUnbound = num3 - (float)obj;
					((EdgeDistances*)(nint)edgeDistances)->xToLeftUnbound = xToLeftUnbound;
					if ((object)_gameManager != null)
					{
						CoopConfig coopConfig = gameManager.CoopConfig;
						if ((object)gameManager.CoopConfig != null)
						{
							float num4 = coopConfig._screenBoundsTopOffsetPixels * 0.01f;
							float num5 = worldBoxCollider.height + worldBoxCollider.y;
							float num6 = num5 - 0.02f;
							float num7 = num6 - num4;
							object obj5 = default(object);
							float yToTopUnbound = num7 - (float)obj5;
							((EdgeDistances*)(nint)edgeDistances)->yToTopUnbound = yToTopUnbound;
							if (_worldBoxCollider != null && (object)_gameManager != null)
							{
								CoopConfig coopConfig2 = gameManager.CoopConfig;
								if ((object)gameManager.CoopConfig != null)
								{
									float num8 = worldBoxCollider.y + 0.02f;
									float num9 = coopConfig2._screenBoundsBottomOffsetPixels * 0.01f;
									float num10 = num9 + num8;
									object obj6 = default(object);
									float yToBottomUnbound = num10 - (float)obj6;
									((EdgeDistances*)(nint)edgeDistances)->yToBottomUnbound = yToBottomUnbound;
									return edgeDistances;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void SetWorldSpaceMovementLimitsActive(bool limitsActive)
	{
		_useWorldSpaceMovementLimits = limitsActive;
	}

	public void SetWorldSpaceMovementLimits(float? left, float? right, float? top, float? bottom)
	{
		_worldSpaceMovementLimits = (WorldSpaceLimits)left;
	}

	public void ClearWorldSpaceMovementLimits()
	{
		//IL_000b: Expected O, but got I4
		_worldSpaceMovementLimits = (WorldSpaceLimits)0;
		_ = 0;
		_ = 0;
		_ = 0;
	}

	private unsafe void LimitMovementInsideWorldSpaceLimits(ref Vector2 movement)
	{
		//IL_0048: Invalid comparison between O and F4
		//IL_0066: Invalid comparison between F4 and I4
		//IL_008f: Expected O, but got I4
		//IL_0166: Invalid comparison between F4 and O
		//IL_0184: Invalid comparison between F4 and I4
		//IL_01ad: Expected O, but got I4
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected O, but got Unknown
		//IL_0293: Invalid comparison between O and F4
		//IL_02b1: Invalid comparison between F4 and I4
		//IL_02da: Expected O, but got I4
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Expected O, but got Unknown
		//IL_03bd: Invalid comparison between F4 and O
		//IL_03db: Invalid comparison between F4 and I4
		//IL_0404: Expected O, but got I4
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Expected O, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Expected O, but got Unknown
		//IL_011e: Expected Ref, but got F4
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Expected O, but got Unknown
		//IL_0248: Expected Ref, but got F4
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Expected O, but got Unknown
		object obj = default(object);
		if ((object)_worldSpaceMovementLimits != null)
		{
			float2 float5 = base.position;
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * (float)movement;
			float num2 = num + (float)float5;
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2);
			float num3 = (float)obj - num2;
			bool flag2 = num3 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			object obj2 = flag4 & flag3;
			object obj3 = (object)_worldSpaceMovementLimits & obj2;
			if (obj3 != null)
			{
				if ((object)_worldSpaceMovementLimits == null)
				{
					goto IL_04a1;
				}
				float2 float6 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.CharacterController)+1F8]");
				object obj4 = 0 - float6;
				float deltaTime2 = PauseSystem.DeltaTime;
				float num4 = (float)obj4 / deltaTime2;
				ref Vector2 reference = ref *(Vector2*)num4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.CharacterController)+1FC]");
		if ((nint)0 != 0)
		{
			float2 float7 = base.position;
			float deltaTime3 = PauseSystem.DeltaTime;
			float num5 = deltaTime3 * (float)movement;
			float num6 = num5 + (float)float7;
			bool flag5 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
			float num7 = num6 - (float)obj;
			bool flag6 = num7 == 0f;
			bool flag7 = !flag5;
			bool flag8 = !flag6;
			object obj5 = flag8 & flag7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.CharacterController)+1FC]");
			object obj6 = 0 & obj5;
			if (obj6 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.CharacterController)+1FC]");
				if ((nint)0 == 0)
				{
					goto IL_04a1;
				}
				float2 float8 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.CharacterController)+200]");
				object obj7 = 0 - float8;
				float deltaTime4 = PauseSystem.DeltaTime;
				float num8 = (float)obj7 / deltaTime4;
				ref Vector2 reference = ref *(Vector2*)num8;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.CharacterController)+20C]");
		object obj8 = default(object);
		if ((nint)0 != 0)
		{
			float2 float9 = base.position;
			float deltaTime5 = PauseSystem.DeltaTime;
			float num9 = deltaTime5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [movement @ rdx (UnityEngine.Vector2&)+4]");
			float num10 = num9 * 0f;
			float num11 = num10 + (float)obj8;
			bool flag9 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num11);
			float num12 = (float)obj - num11;
			bool flag10 = num12 == 0f;
			bool flag11 = !flag9;
			bool flag12 = !flag10;
			object obj9 = flag12 & flag11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.CharacterController)+20C]");
			object obj10 = 0 & obj9;
			if (obj10 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.CharacterController)+20C]");
				if ((nint)0 == 0)
				{
					goto IL_04a1;
				}
				float2 float10 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.CharacterController)+210]");
				object obj11 = 0 - obj;
				float deltaTime6 = PauseSystem.DeltaTime;
				float num13 = (float)obj11 / deltaTime6;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.CharacterController)+204]");
		if ((nint)0 != 0)
		{
			float2 float11 = base.position;
			float deltaTime7 = PauseSystem.DeltaTime;
			float num14 = deltaTime7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [movement @ rdx (UnityEngine.Vector2&)+4]");
			float num15 = num14 * 0f;
			float num16 = num15 + (float)obj8;
			bool flag13 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num16) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
			float num17 = num16 - (float)obj;
			bool flag14 = num17 == 0f;
			bool flag15 = !flag13;
			bool flag16 = !flag14;
			object obj12 = flag16 & flag15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.CharacterController)+204]");
			object obj13 = 0 & obj12;
			if (obj13 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.CharacterController)+204]");
				if ((nint)0 != 0)
				{
					float2 float12 = base.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.CharacterController)+208]");
					object obj14 = 0 - obj;
					float deltaTime8 = PauseSystem.DeltaTime;
					float num18 = (float)obj14 / deltaTime8;
					return;
				}
				goto IL_04a1;
			}
			return;
		}
		return;
		IL_04a1:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
	}

	private void DoOnlineOrLocalRevival(bool instantRevival)
	{
		GameManager gameManager = _gameManager;
		if (gameManager._multiplayer.IsOnlineMultiplayer)
		{
			if (_coherenceSync.HasStateAuthority && !_sentRevivalCommand)
			{
				_sentRevivalCommand = true;
				Debug.Log("Sending Trigger Online Revival Method");
				Action<long, bool> action = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5AF0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
				OnlineStageManager onlineStageManager = default(OnlineStageManager);
				long startingOnlineClientFrame = onlineStageManager.GetStartingOnlineClientFrame();
				bool param = default(bool);
				bool flag = _coherenceSync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
			}
		}
		else
		{
			DoMultiplayerRevival(instantRevival);
		}
	}

	public void TriggerOnlineRevival(long startingSimFrame, bool instantRevival)
	{
		_003C_003Ec__DisplayClass446_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass446_0();
		CS_0024_003C_003E8__locals4._003C_003E4__this = this;
		CS_0024_003C_003E8__locals4.instantRevival = instantRevival;
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000C1F0");
		Action onComplete = delegate
		{
			CS_0024_003C_003E8__locals4._003C_003E4__this.DoMultiplayerRevival(CS_0024_003C_003E8__locals4.instantRevival);
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,rbp\"");
		float num = 0f / 60f;
		float num2 = num * 1000f;
		float duration = num2 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		timer.Resume();
	}

	private void DoMultiplayerRevival(bool instantRevival)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_01b8: Expected I, but got O
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Expected O, but got Unknown
		//IL_04aa: Expected O, but got I4
		if (_multiplayerRevivalUI.IsVisible())
		{
			_multiplayerRevivalUI.OpenLidAnimation();
		}
		EggDouble eggDouble = PRevivals();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [rax+10h]\"");
		object obj = eggDouble._eggVal & 0x7FFFFFFFFFFFFFFFL;
		if ((long)obj != 9218868437227405312L)
		{
			object obj2 = eggDouble._eggVal & 0x7FFFFFFFFFFFFFFFL;
			bool flag = (long)obj2 == 9218868437227405312L;
			if ((long)obj2 <= 9218868437227405312L)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [188A11860h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187586914h\"");
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,qword ptr [188A10758h]\"");
					if ((long)obj2 >= 9218868437227405312L)
					{
						goto IL_0126;
					}
				}
				goto IL_0439;
			}
		}
		goto IL_0126;
		IL_045d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		object obj3 = default(object);
		if ((nint)obj3 <= 0)
		{
			Accessory accessoryByType = _accessoriesManager.GetAccessoryByType(WeaponType.REVIVAL);
			if ((bool)accessoryByType)
			{
				GameManager core = GM.Core;
				core._accessoriesFacade.RemoveAccessory(WeaponType.REVIVAL, this);
			}
		}
		GameManager core2 = GM.Core;
		core2._gizmoManager.DisplayAngel(this);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.AutoLB, soundConfig, 200f, 1, time);
		GameManager core3 = GM.Core;
		ArcanaManager arcanaManager = core3._arcanaManager;
		if (arcanaManager._003CActiveArcanas_003Ek__BackingField != null)
		{
			GameManager core4 = GM.Core;
			ArcanaManager arcanaManager2 = core4._arcanaManager;
			List<ArcanaType> list = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ rcx_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			if ((nint)0 > (nint)0)
			{
				GameManager core5 = GM.Core;
				ArcanaManager arcanaManager3 = core5._arcanaManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
				object obj4 = default(object);
				if (obj4 != null)
				{
					GameManager core6 = GM.Core;
					core6._arcanaManager.TriggerAwake(this);
				}
			}
		}
		goto IL_0439;
		IL_0439:
		Revive(0.5f, instantRevival);
		GM.Core.RunAllPostRevivialActions(this, instantRevival);
		return;
		IL_0126:
		PlayerModifierStats playerStats = _playerStats;
		EggDouble eggDouble2 = playerStats._003CRevivals_003Ek__BackingField;
		EggDouble eggDouble3 = new EggDouble(eggDouble2._val, eggDouble2._eggVal);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm7,qword ptr [188A10758h]\"");
		playerStats._003CRevivals_003Ek__BackingField = eggDouble3;
		PlayerModifierStats playerStats2 = _playerStats;
		int num = playerStats2._003CUsedRevivals_003Ek__BackingField + 1;
		playerStats2._003CUsedRevivals_003Ek__BackingField = num;
		nint num2 = (nint)this;
		EggDouble eggDouble4 = PRevivals();
		double eggVal = eggDouble4._eggVal;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [rax+10h]\"");
		object obj5 = eggDouble4._eggVal & 0x7FFFFFFFFFFFFFFFL;
		if ((long)obj5 != 9218868437227405312L)
		{
			object obj6 = eggDouble4._eggVal & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj6 <= 9218868437227405312L)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [188A11860h]\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187586A6Ch\"");
				if ((long)obj6 == 9218868437227405312L)
				{
					eggVal = -1.7976931348623157E+308;
				}
				goto IL_045d;
			}
		}
		eggVal = 1.7976931348623157E+308;
		goto IL_045d;
	}

	public virtual void DoPostRevivalActions(CharacterController revived, bool instantRevival = false)
	{
	}

	private void TurnIntoMultiplayerGhost()
	{
		EnsureOnScreen();
		_multiplayerRevivalUI.SetGhost(isGhost: true);
		GameManager core = GM.Core;
		CoopConfig coopConfig = core.CoopConfig;
		if (coopConfig._removeDeadPlayersFromCamera)
		{
			ProCamera2D instance = ProCamera2D.Instance;
			Transform targetTransform = base.transform;
			Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget = instance.GetCameraTarget(targetTransform);
			if (cameraTarget == null)
			{
				ProCamera2D instance2 = ProCamera2D.Instance;
				Transform cameraTarget2 = CameraTarget;
				float duration = default(float);
				Vector2 targetOffset = default(Vector2);
				Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget3 = instance2.AddCameraTarget(cameraTarget2, 1f, 1f, duration, targetOffset);
			}
		}
	}

	public void ForceHideOutline()
	{
		GameObject gameObject = _multiplayerOutliner.gameObject;
		gameObject.SetActive(value: false);
	}

	private void EnsureOnScreen()
	{
		//IL_01ff: Expected I, but got O
		//IL_005f: Invalid comparison between O and F4
		//IL_0148: Expected O, but got I
		//IL_009c: Invalid comparison between F4 and O
		//IL_0238: Expected O, but got I
		//IL_00c5: Invalid comparison between O and F4
		//IL_01ae: Expected O, but got I8
		//IL_0102: Invalid comparison between F4 and O
		//IL_01ec: Expected O, but got I8
		nint num = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num2 = 0;
		GameManager core = GM.Core;
		CoopConfig coopConfig = core.CoopConfig;
		if (!coopConfig._removeDeadPlayersFromCamera)
		{
			return;
		}
		ArcadeBodyBounds coopMovementBoxCollider = _coopMovementBoxCollider;
		float2 float5 = base.position;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)coopMovementBoxCollider.x);
		float2 float6 = float5;
		if (!flag)
		{
			float num3 = coopMovementBoxCollider.width + coopMovementBoxCollider.x;
			bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) < System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5);
			float6 = float5;
			if (!flag2)
			{
				float2 float7 = default(float2);
				bool flag3 = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float7) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)coopMovementBoxCollider.y);
				float6 = float7;
				if (!flag3)
				{
					num3 = coopMovementBoxCollider.height + coopMovementBoxCollider.y;
					bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) < System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float7);
					bool flag5 = !flag4;
					float6 = float7;
					if (flag5)
					{
						return;
					}
				}
			}
		}
		ArcadeBodyBounds coopMovementBoxCollider2 = _coopMovementBoxCollider;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag6 = (nint)0 != 0;
		ArcadeSprite arcadeSprite = this;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			arcadeSprite = (ArcadeSprite)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v392 @ rax_v17 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
			arcadeSprite = (ArcadeSprite)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v416 @ rax_v20 (should have been resolved before IL gen)");
		float2 float8 = default(float2);
		base.position = float8;
	}

	public unsafe void HandleLateUpdate()
	{
		//IL_06eb: Expected O, but got I
		//IL_0024: Expected O, but got I
		//IL_00f2: Expected O, but got Ref
		//IL_0093: Expected O, but got I
		//IL_0723: Expected O, but got Ref
		//IL_0305: Expected O, but got I
		//IL_01e2: Expected O, but got I
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected O, but got Unknown
		//IL_0337: Expected O, but got I
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		//IL_045b: Invalid comparison between F4 and I4
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fc: Expected O, but got Unknown
		//IL_0505: Expected F4, but got I4
		//IL_05fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0603: Expected O, but got Unknown
		//IL_060b: Invalid comparison between F4 and O
		//IL_061d: Expected F4, but got I4
		//IL_0646: Invalid comparison between F4 and I4
		//IL_0894->IL0676: Incompatible stack heights: 1 vs 0
		//IL_00d1->IL0676: Incompatible stack heights: 1 vs 0
		//IL_0044->IL0676: Incompatible stack heights: 1 vs 0
		//IL_0140->IL0676: Incompatible stack heights: 1 vs 0
		//IL_0779->IL024d: Incompatible stack heights: 2 vs 1
		//IL_0385->IL0676: Incompatible stack heights: 6 vs 0
		//IL_0419->IL0676: Incompatible stack heights: 6 vs 0
		//IL_0448->IL0676: Incompatible stack heights: 6 vs 0
		//IL_049d->IL0676: Incompatible stack heights: 6 vs 0
		//IL_0594->IL0676: Incompatible stack heights: 6 vs 0
		//IL_04cc->IL0676: Incompatible stack heights: 6 vs 0
		//IL_05c3->IL0676: Incompatible stack heights: 6 vs 0
		Transform cachedTransform = _cachedTransform;
		float2 value;
		float2 float6;
		float2 float8;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)(&value));
			MultiplayerManager coherenceSync = (MultiplayerManager)(object)_coherenceSync;
			if ((object)_coherenceSync != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v9 (VampireSurvivors.Framework.MultiplayerManager)+160]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v9 (VampireSurvivors.Framework.MultiplayerManager)+160]");
				float2 float7 = default(float2);
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v25+20]");
					ArcadeSprite arcadeSprite = (ArcadeSprite)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v25+20]");
					if ((nint)0 == 0)
					{
						goto IL_0676;
					}
					bool flag2 = (byte)(nint)((UnityEngine.Object)arcadeSprite).m_CachedPtr != 0;
					if (((UnityEngine.Object)arcadeSprite).m_CachedPtr != (IntPtr)1)
					{
						object obj2 = (nint)((UnityEngine.Object)arcadeSprite).m_CachedPtr - 3;
						bool flag3 = obj2 == null;
						flag2 = flag3;
					}
					bool flag4 = !flag2;
					float2 float5 = (float2)(&value);
					float6 = float7;
					float8 = value;
					if (flag4)
					{
						goto IL_024d;
					}
				}
				GameManager core = GM.Core;
				if ((object)GM.Core != null)
				{
					bool flag5 = (object)core._003CHardBounds_003Ek__BackingField == null;
					float2 float5 = (float2)(&value);
					float6 = float7;
					float8 = value;
					ArcadeSprite arcadeSprite = (ArcadeSprite)(object)typeof(GM);
					if (!flag5)
					{
						GameManager core2 = GM.Core;
						if ((object)GM.Core == null)
						{
							goto IL_0676;
						}
						bool flag6 = (object)core2._003CHardBounds_003Ek__BackingField == null;
						float2 float9 = default(float2);
						if (float9 <= value != 0)
						{
							object obj3 = float9 + float9;
							bool flag7 = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref value) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3);
							float8 = value;
							if (!flag7)
							{
								float8 = float9 + float9;
							}
						}
						else
						{
							float8 = float9;
						}
						if (float9 <= float7 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v48 (VampireSurvivors.Framework.GameManager)+388]");
							float2 float10 = (float2)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v48 (VampireSurvivors.Framework.GameManager)+388]");
							object obj4 = 0 + float9;
							bool flag8 = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float7) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4);
							float6 = float7;
							if (!flag8)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v48 (VampireSurvivors.Framework.GameManager)+388]");
								float6 = 0 + float9;
							}
						}
						else
						{
							float6 = float9;
							float2 float10 = float9;
						}
						base.position = float9;
						float5 = float9;
						arcadeSprite = this;
					}
					goto IL_024d;
				}
			}
		}
		goto IL_0676;
		IL_024d:
		float num = (float)float6 * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		float num2 = (float)float8 * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		bool flag9 = (object)_CharacterRenderer == null;
		Transform transform = _CharacterRenderer.transform;
		bool flag10 = (object)transform == null;
		bool flag11 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
		RefreshMultiplayerOutline();
		object core3 = GM.Core;
		bool flag12 = (object)GM.Core == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v905 @ rdi_v11 (System.Object)+168]");
		bool flag13 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v905 @ rdi_v11 (System.Object)+168]");
		int playerCount = ((MultiplayerManager)0).GetPlayerCount();
		if (playerCount <= 1)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v905 @ rdi_v11 (System.Object)+168]");
			if (!((MultiplayerManager)0).IsOnlineMultiplayer && _PlayerIndex >= 0)
			{
				return;
			}
		}
		if ((object)_multiplayerRevivalUI != null)
		{
			if (!_multiplayerRevivalUI.IsVisible() || (!_isDead && !IsDisconnectedFromOnlinePlay))
			{
				goto IL_07d3;
			}
			GameManager core4 = GM.Core;
			if ((object)GM.Core != null)
			{
				CoopConfig coopConfig = core4.CoopConfig;
				if ((object)core4.CoopConfig != null)
				{
					if (coopConfig._revivalLossSpeed < 0f)
					{
						float deltaTime = PauseSystem.DeltaTime;
						GameManager core5 = GM.Core;
						if ((object)GM.Core != null)
						{
							CoopConfig coopConfig2 = core5.CoopConfig;
							if ((object)core5.CoopConfig != null)
							{
								bool flag14 = !_multiplayerRevivalAllowed;
								float revivalLossSpeed = coopConfig2._revivalLossSpeed;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
								object obj5 = revivalLossSpeed ^ 0;
								float num3 = 0f;
								if (!flag14)
								{
									num3 = 1f;
								}
								float num4 = (float)obj5 * deltaTime;
								float num5 = num4 * num3;
								if ((_multiplayerRevivalProportion = num5 + _multiplayerRevivalProportion) > 1f)
								{
									_multiplayerRevivalProportion = 1f;
									EnsureOnScreen();
									DoOnlineOrLocalRevival(instantRevival: false);
								}
								goto IL_07d3;
							}
						}
					}
					else
					{
						if (_revivalJuiceThisFrame != 0)
						{
							goto IL_07d3;
						}
						float deltaTime2 = PauseSystem.DeltaTime;
						GameManager core6 = GM.Core;
						if ((object)GM.Core != null)
						{
							CoopConfig coopConfig3 = core6.CoopConfig;
							if ((object)core6.CoopConfig != null)
							{
								float num6 = deltaTime2 * coopConfig3._revivalLossSpeed;
								float num7 = 0f - _multiplayerRevivalProportion;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
								object obj6 = num7 & 0;
								bool flag15 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6);
								float multiplayerRevivalProportion = 0f;
								if (!flag15)
								{
									float num8 = 0f - _multiplayerRevivalProportion;
									float num9 = ((num8 < 0f) ? (-1f) : 1f);
									float num10 = num9 * num6;
									multiplayerRevivalProportion = num10 + _multiplayerRevivalProportion;
								}
								_multiplayerRevivalProportion = multiplayerRevivalProportion;
								goto IL_07d3;
							}
						}
					}
				}
			}
		}
		goto IL_0676;
		IL_0676:
		throw new NullReferenceException();
		IL_07d3:
		_revivalJuiceThisFrame = 0;
	}

	private unsafe Vector3 ContainCharacterInHardBounds(Vector3 pos)
	{
		//IL_0098: Expected native int or pointer, but got O
		//IL_00aa: Expected native int or pointer, but got O
		//IL_006f: Expected O, but got I
		//IL_0121: Invalid comparison between O and F4
		//IL_0196: Expected F4, but got O
		//IL_0191: Expected native int or pointer, but got O
		//IL_0274: Invalid comparison between O and F4
		//IL_020c: Expected F4, but got O
		//IL_0207: Expected native int or pointer, but got O
		//IL_017f: Expected native int or pointer, but got O
		//IL_01f5: Expected native int or pointer, but got O
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v11 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v11 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v11 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				goto IL_008b;
			}
		}
		GameManager core = GM.Core;
		if ((object)core._003CHardBounds_003Ek__BackingField != null)
		{
			GameManager core2 = GM.Core;
			if ((object)core2._003CHardBounds_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				Vector3 result = default(Vector3);
				return result;
			}
			float2 float5 = default(float2);
			if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)pos.x))
			{
				float num = (float)float5 + (float)float5;
				if (pos.x > num)
				{
					float x = (float)float5 + (float)float5;
					((Vector3*)(nint)pos)->x = x;
				}
			}
			else
			{
				((Vector3*)(nint)pos)->x = (float)float5;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)pos.y))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v8 (VampireSurvivors.Framework.GameManager)+388]");
				float num2 = 0f + (float)float5;
				if (pos.y > num2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v8 (VampireSurvivors.Framework.GameManager)+388]");
					float y = 0f + (float)float5;
					((Vector3*)(nint)pos)->y = y;
				}
			}
			else
			{
				((Vector3*)(nint)pos)->y = (float)float5;
			}
			base.position = float5;
		}
		goto IL_008b;
		IL_008b:
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = pos.x;
		((Vector3*)(nint)vector)->z = pos.z;
		return vector;
	}

	public bool IsWithinBounds(ArcadeBodyBounds bounds)
	{
		//IL_00e9: Expected I4, but got O
		//IL_0034: Invalid comparison between O and F4
		//IL_0069: Invalid comparison between F4 and O
		//IL_008a: Invalid comparison between O and F4
		//IL_00bf: Invalid comparison between F4 and O
		float2 float5 = base.position;
		if (bounds != null)
		{
			if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)bounds.x))
			{
				float num = bounds.width + bounds.x;
				object obj = default(object);
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) >= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)bounds.y))
				{
					float num2 = bounds.height + bounds.y;
					bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
					return !flag;
				}
			}
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void RefreshMultiplayerOutline()
	{
		GameManager core = GM.Core;
		int playerCount = core._multiplayer.GetPlayerCount();
		if (playerCount > 1 || core._multiplayer.IsOnlineMultiplayer)
		{
			_multiplayerOutliner.UpdateSprite(_outlineReferenceRenderer, _usingCustomRendererForOutline);
		}
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		CharacterWeaponsManager weaponsManager = _weaponsManager;
		weaponsManager._maxActiveCount = 0;
		weaponsManager.SetMaxWeaponCount(0, 0);
		if (_regenTimer != null)
		{
			_regenTimer.Cancel();
		}
		if (_blinkTimeoutTimer != null)
		{
			_blinkTimeoutTimer.Cancel();
		}
		if (_multiplayerDecompositionTimer != null)
		{
			_multiplayerDecompositionTimer.Cancel();
		}
		if (_deathConsequenceTimer != null)
		{
			_deathConsequenceTimer.Cancel();
		}
		if (_multiplayerChompTimer != null)
		{
			_multiplayerChompTimer.Cancel();
		}
		if (_multiplayerIndicatorTimer != null)
		{
			_multiplayerIndicatorTimer.Cancel();
		}
		if (_multiplayerReviveShake1 != null)
		{
			_multiplayerReviveShake1.Cancel();
		}
		if (_multiplayerReviveShake2 != null)
		{
			_multiplayerReviveShake2.Cancel();
		}
		GameObject gameObject = _multiplayerRevivalUI.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = base.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
	}

	public unsafe void InitCharacter(CharacterType characterType, int playerIndex, bool asRemote, bool dontGetCharacterDataForCurrentLevel = false)
	{
		//IL_016e: Expected F4, but got I4
		//IL_01fa: Expected F4, but got I4
		//IL_027b: Expected O, but got I
		//IL_02ad: Expected O, but got I
		//IL_03d9: Expected O, but got Ref
		//IL_08ca: Expected O, but got I
		//IL_07d0: Expected I, but got O
		//IL_065a: Expected O, but got I
		//IL_06d2: Expected O, but got I
		//IL_0825: Expected I, but got O
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e2: Expected O, but got Unknown
		//IL_0521: Expected O, but got I4
		//IL_089f: Expected I, but got O
		//IL_05b5: Expected O, but got I4
		//IL_07f0->IL0707: Incompatible stack heights: 1 vs 0
		//IL_04a5->IL0707: Incompatible stack heights: 1 vs 0
		//IL_084c->IL0707: Incompatible stack heights: 2 vs 0
		//IL_054e->IL0707: Incompatible stack heights: 2 vs 0
		//IL_061c->IL061c: Incompatible stack heights: 8 vs 0
		_isInitialized = true;
		List<Weapon> heldShieldSlots = new List<Weapon>();
		HeldShieldSlots = heldShieldSlots;
		List<WeaponType> glimmeredTechniques = new List<WeaponType>();
		GlimmeredTechniques = glimmeredTechniques;
		CharacterSkillCardsManager characterSkillCardsManager = new CharacterSkillCardsManager();
		List<CharacterSkillCard_Base> characterCards = new List<CharacterSkillCard_Base>();
		characterSkillCardsManager._characterCards = characterCards;
		CharacterSkillCardsManager = characterSkillCardsManager;
		_characterType = characterType;
		_PlayerIndex = playerIndex;
		_maxWeaponBonus = 0;
		if (!asRemote && _PlayerIndex >= 0)
		{
			ReInput.PlayerHelper players = ReInput.players;
			if (players == null)
			{
				goto IL_0707;
			}
			Player player = players.GetPlayer(_PlayerIndex);
			_player = player;
		}
		Action onComplete = Regenerate;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer regenTimer = Timers.Register(1f, onComplete, null, isLooped: true, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_regenTimer = regenTimer;
		InitDeathNoHurtRenderer();
		bool dontGetCharacterDataForCurrentLevel2 = default(bool);
		MakeLevelOne(dontGetCharacterDataForCurrentLevel2);
		SetupAnimation();
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		object obj = default(object);
		float width = (float)obj * 2f;
		ArcadeBodyBounds worldBoxCollider = new ArcadeBodyBounds(0f, 0f, width, flag ? 1 : 0);
		_worldBoxCollider = worldBoxCollider;
		float width2 = (float)obj * 2f;
		GameManager gameManager = _gameManager;
		Rect ret = default(Rect);
		if ((object)_gameManager != null && (object)gameManager.CoopConfig != null)
		{
			ArcadeBodyBounds coopMovementBoxCollider = new ArcadeBodyBounds(0f, 0f, width2, flag ? 1 : 0);
			_coopMovementBoxCollider = coopMovementBoxCollider;
			_hasLastBreath = true;
			List<CharacterSkillCard_Base> core = (List<CharacterSkillCard_Base>)(object)GM.Core;
			if ((object)GM.Core != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v693 @ rbx_v16 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterSkillCard_Base>)+168]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v693 @ rbx_v16 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterSkillCard_Base>)+168]");
					int playerCount = ((MultiplayerManager)0).GetPlayerCount();
					if (playerCount <= 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v693 @ rbx_v16 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterSkillCard_Base>)+168]");
						if (!((MultiplayerManager)0).IsOnlineMultiplayer)
						{
							goto IL_03e0;
						}
					}
					_outlineReferenceRenderer = _CharacterRenderer;
					if (_playerOptions != null)
					{
						PlayerOptionsData config = _playerOptions.Config;
						if (config != null)
						{
							if (config._003CPermanentCoopOutlines_003Ek__BackingField)
							{
								CharacterData currentCharacterData = _currentCharacterData;
								if (_currentCharacterData == null)
								{
									goto IL_0707;
								}
								if (currentCharacterData._003CallowCoopOutline_003Ek__BackingField)
								{
									Color coopColour = GetCoopColour();
									if ((object)_multiplayerOutliner == null)
									{
										goto IL_0707;
									}
									_multiplayerOutliner.ShowOutline(_outlineReferenceRenderer, (Color)(&ret));
								}
							}
							goto IL_03e0;
						}
					}
				}
			}
		}
		goto IL_0707;
		IL_03e0:
		List<CharacterSkillCard_Base> barrierSprite = (List<CharacterSkillCard_Base>)(object)BarrierSprite;
		if ((object)BarrierSprite != null && barrierSprite._items != null)
		{
			goto IL_061c;
		}
		CheckRenderer();
		if ((object)base._spriteRenderer != null)
		{
			Sprite sprite = base._spriteRenderer.sprite;
			if ((object)sprite != null)
			{
				bool flag2 = ((List<CharacterSkillCard_Base>)(object)sprite)._items == null;
				Sprite.get_rect_Injected((IntPtr)((List<CharacterSkillCard_Base>)(object)sprite)._items, out Rect ret2);
				CheckRenderer();
				if ((object)base._spriteRenderer != null)
				{
					Sprite sprite2 = base._spriteRenderer.sprite;
					if ((object)sprite2 != null)
					{
						bool flag3 = ((List<CharacterSkillCard_Base>)(object)sprite2)._items == null;
						Sprite.get_rect_Injected((IntPtr)((List<CharacterSkillCard_Base>)(object)sprite2)._items, out ret);
						object obj2 = default(object);
						object obj3 = default(object);
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
						{
							object obj4 = obj2 & -2147483649L;
							if ((nint)obj4 <= 2139095040)
							{
							}
						}
						PhaserWorld instance = PhaserWorld.Instance;
						if ((object)instance != null)
						{
							PhaserSprite barrierSprite2 = instance.AddPhaserSprite((Vector2)0, "vfx", "round");
							BarrierSprite = barrierSprite2;
							if ((object)BarrierSprite != null)
							{
								Transform transform = BarrierSprite.transform;
								bool flag4 = (object)transform == null;
								bool flag5 = ((List<CharacterSkillCard_Base>)(object)transform)._items == null;
								Transform.set_localScale_Injected((IntPtr)((List<CharacterSkillCard_Base>)(object)transform)._items, ref *(Vector3*)(&ret2));
								bool flag6 = (object)BarrierSprite == null;
								PhaserSprite phaserSprite = BarrierSprite.setAlpha(0.95f);
								bool flag7 = (object)BarrierSprite == null;
								PhaserSprite phaserSprite2 = BarrierSprite.setOrigin(0.5f, (float?)(object)1);
								bool flag8 = (object)BarrierSprite == null;
								PhaserSprite phaserSprite3 = BarrierSprite.setVisible(visible: false);
								bool flag9 = (object)BarrierSprite == null;
								PhaserSprite phaserSprite4 = BarrierSprite.setTint(8433904u);
								goto IL_061c;
							}
						}
					}
				}
			}
		}
		goto IL_0707;
		IL_0707:
		throw new NullReferenceException();
		IL_061c:
		List<CharacterSkillCard_Base> coherenceSync = (List<CharacterSkillCard_Base>)(object)_coherenceSync;
		if ((object)_coherenceSync != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ rbx_v21 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterSkillCard_Base>)+160]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ rbx_v21 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.CharacterSkillCard_Base>)+160]");
			if ((nint)0 == 0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v925 @ rax_v64+20]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v925 @ rax_v64+20]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v730 @ rcx_v58+10]");
				bool flag10 = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v730 @ rcx_v58+10]");
				if ((nint)0 != 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v730 @ rcx_v58+10]");
					object obj7 = -3;
					bool flag11 = obj7 == null;
					flag10 = flag11;
				}
				if (!flag10)
				{
					_003CAddCursor_003Ed__458 obj8 = null;
					obj8._003C_003E1__state = 0;
					obj8._003C_003E4__this = this;
					Coroutine coroutine = StartCoroutine(obj8);
				}
				return;
			}
		}
		goto IL_0707;
	}

	private IEnumerator AddCursor()
	{
		_003CAddCursor_003Ed__458 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void UpdateMaxWeaponCount()
	{
		//IL_0021: Expected O, but got I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		bool flag = MultiplayerManager.s_instance == null;
		int playerCount = MultiplayerManager.s_instance.GetPlayerCount();
		object obj = playerCount - 1;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag)
				{
					if ((nint)obj3 == 1)
					{
						_maxWeaponCount = 2;
					}
				}
				else
				{
					_maxWeaponCount = 3;
				}
			}
			else
			{
				_maxWeaponCount = 4;
			}
		}
		else
		{
			_maxWeaponCount = 6;
		}
		GameManager gameManager = _gameManager;
		CoopConfig coopConfig = gameManager.CoopConfig;
		if (coopConfig._limitAccessoriesLikeWeapons)
		{
			_maxAccessoryCount = _maxWeaponCount;
		}
	}

	public virtual void AfterFullInitialization()
	{
		//IL_00f5: Expected O, but got I4
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageData stageData = stage._stageData;
		if (stageData._003CisRacingStage_003Ek__BackingField && GM.Core.IsStageVisuallyInverted())
		{
			_isFlipped = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186863D20");
			Vector2 lastFacingDirection = default(Vector2);
			_lastFacingDirection = lastFacingDirection;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186863D20");
			Vector2 lastMovementDirection = default(Vector2);
			_lastMovementDirection = lastMovementDirection;
		}
		if (_PlayerIndex < 0)
		{
			if (_deficiencyControl == null)
			{
				return;
			}
			CharacterADControl deficiencyControl = _deficiencyControl;
			object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
			if (obj != null)
			{
				return;
			}
		}
		PlayerOptionsData config = _playerOptions.Config;
		GameManager gameManager = _gameManager;
		_maxWeaponCount = config._003CSelectedMaxWeapons_003Ek__BackingField;
		int playerCount = gameManager._multiplayer.GetPlayerCount();
		if (playerCount > 1 || gameManager._multiplayer.IsOnlineMultiplayer)
		{
			UpdateMaxWeaponCount();
		}
	}

	public virtual void OnWeaponMadeLevelOne(WeaponType type)
	{
	}

	public virtual void OnQuit()
	{
		//IL_0079: Expected O, but got I
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v7 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v7 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rcx_v7 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	public virtual void OnGlimmeredTechniqueFired()
	{
	}

	public virtual void OnGlimmeredTechniqueLearned(WeaponType glimmerType)
	{
		//IL_0028: Expected O, but got I
		//IL_007d: Expected O, but got I
		List<System.Int32Enum> glimmeredTechniques = (List<System.Int32Enum>)(object)GlimmeredTechniques;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v3+18]");
		if (num >= 0)
		{
			glimmeredTechniques.AddWithResize((System.Int32Enum)glimmerType);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj2 = (nint)0 + (nint)1;
	}

	public void ForceSetPosition(Vector2 newPosition)
	{
		float2 float5 = default(float2);
		base.position = float5;
	}

	public float GetMultipliedHPRecoveryValue(float value)
	{
		float num = PRegen();
		GameManager gameManager = _gameManager;
		object obj = default(object);
		float num2 = (float)obj + 1f;
		float num3 = num2 * value;
		ArcanaManager arcanaManager = gameManager._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				float num4 = num3 + num3;
				num3 = num4;
			}
		}
		return num3;
	}

	public virtual void RecoverHp(float value, bool showRecovery = false, bool mulByRegen = false)
	{
		//IL_01b2: Expected I, but got O
		//IL_01c2: Expected O, but got I
		//IL_0200: Expected I, but got O
		//IL_0210: Expected O, but got I
		//IL_03f1->IL0413: Incompatible stack heights: 11 vs 0
		//IL_0369->IL04ce: Incompatible stack heights: 11 vs 9
		//IL_03b0->IL03b0: Incompatible stack heights: 12 vs 9
		if (_isDead || IsDisconnectedFromOnlinePlay)
		{
			return;
		}
		float num2;
		if (mulByRegen)
		{
			float num = PRegen();
			object obj = default(object);
			num2 = (float)obj + 1f;
		}
		else
		{
			num2 = 1f;
		}
		GameManager gameManager = _gameManager;
		float num3 = num2 * value;
		bool flag = (object)_gameManager == null;
		ArcanaManager arcanaManager = gameManager._arcanaManager;
		bool flag2 = gameManager._arcanaManager == null;
		bool flag3 = arcanaManager._003CActiveArcanas_003Ek__BackingField == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
		object obj2 = default(object);
		if (obj2 != null)
		{
			float num4 = num3 + num3;
			num3 = num4;
		}
		GameManager gameManager2 = _gameManager;
		bool flag4 = (object)_gameManager == null;
		bool flag5 = gameManager2._arcanaManager == null;
		gameManager2._arcanaManager.OnPlayerHPRecovery(this, num3);
		GameManager core = GM.Core;
		bool flag6 = (object)GM.Core == null;
		bool flag7 = core._playerOptions == null;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag8 = config == null;
		float num5 = (config._003CRawRunHeal_003Ek__BackingField = num3 + config._003CRawRunHeal_003Ek__BackingField);
		nint num6 = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+560]");
		object obj3 = 0;
		float num7 = MaxHp();
		float num8;
		if (_currentHp > num5)
		{
			num8 = num3;
		}
		else
		{
			nint num9 = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ rdx_v27 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+560]");
			obj3 = 0;
			float num10 = MaxHp();
			num8 = num5 - _currentHp;
			if (num8 > num3)
			{
				num8 = num3;
			}
		}
		Action<float, float> onHpRecoveryCallback = _onHpRecoveryCallback;
		if (_onHpRecoveryCallback != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v558 @ rax_v19 (System.Action`2<System.Single, System.Single>)+18] (should have been resolved before IL gen)");
		}
		bool flag9 = (object)_coherenceSync == null;
		if (_coherenceSync.HasStateAuthority)
		{
			float num11 = (_currentHp = num8 + _currentHp);
			float num12 = MaxHp();
			if (num11 > num5)
			{
				float num13 = MaxHp();
				_currentHp = num5;
			}
		}
		float num14 = MaxHp();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875890A8h\"");
		if (_currentHp == num5)
		{
			_hpFullyRecovered(num8);
		}
		if (9000f > num8)
		{
			bool flag10 = _playerOptions == null;
			PlayerOptionsData config2 = _playerOptions.Config;
			bool flag11 = config2 == null;
			float num15 = num8 + config2._003CLifetimeHeal_003Ek__BackingField;
			config2._003CLifetimeHeal_003Ek__BackingField = num15;
		}
		if (showRecovery)
		{
			CharacterController cachedTransform = (CharacterController)(object)_cachedTransform;
			bool flag12 = (object)_cachedTransform == null;
			bool flag13 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			bool flag14 = (object)_gameManager == null;
			Vector2 pos = default(Vector2);
			_gameManager.ShowRecoveryAt(pos, num3);
		}
		GameManager core2 = GM.Core;
		bool flag15 = (object)GM.Core == null;
		bool flag16 = core2._arcanaManager == null;
	}

	public virtual void SetBloodColor(uint colorValue)
	{
		ParticleSystem damageVfx = _damageVfx;
		if ((object)_damageVfx != null && ((UnityEngine.Object)damageVfx).m_CachedPtr != (IntPtr)0)
		{
			ParticleSystem particleSystem = RenderingExtensions.SetTint(_damageVfx, colorValue);
		}
	}

	protected virtual void _hpFullyRecovered(float recovered)
	{
		//IL_0009: Invalid comparison between F4 and I4
		if (recovered > 0f)
		{
			_isCriticalHPEnabled = true;
		}
	}

	public void EnableDestroyDestructiblesOnTouch()
	{
		//IL_005c: Expected I, but got O
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		PhysicsManager physicsManager = core._physicsManager;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+670]");
		ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
		nint num = (nint)this;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(this, physicsManager._destructiblesGroup, collideCallback, processCallback, callbackContext);
	}

	public virtual void LevelUp()
	{
		//IL_03a7: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_01c3: Expected O, but got I4
		//IL_01d9: Expected O, but got I4
		//IL_02e4: Expected O, but got I4
		//IL_02fe: Expected O, but got I4
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected O, but got Unknown
		CharacterData currentCharacterData = _currentCharacterData;
		GetCharacterDataForCurrentLevel(++_level);
		CharacterData currentCharacterData2 = _currentCharacterData;
		currentCharacterData2._003CcurrentSkin_003Ek__BackingField = currentCharacterData._003CcurrentSkin_003Ek__BackingField;
		if (_onEveryLevelUp != null)
		{
			PlayerStatsUpgrade(_onEveryLevelUp);
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		bool flag = _deficiencyControl == null;
		bool flag2 = true;
		if (!flag)
		{
			CharacterADControl deficiencyControl = _deficiencyControl;
			object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
			bool flag3 = obj == null;
			flag2 = !flag3;
		}
		int num = _PlayerIndex >> 31;
		int num2 = (flag2 ? 1 : 0) & num;
		bool flag4 = num2 == 0;
		object obj2 = !flag4;
		if (obj2 == null && arcanaManager._hasHailFromTheFuture)
		{
			GameManager core2 = GM.Core;
			GameSessionData gameSessionData = core2._gameSessionData;
			bool flag5 = (object)gameSessionData._activeCharacter == null;
			bool flag6 = (object)this == null;
			object obj3 = flag6 & flag5;
			bool flag7 = obj3 == null;
			object obj4 = !flag7;
			if (obj4 == null)
			{
				bool flag8;
				if ((object)gameSessionData._activeCharacter != null)
				{
					object obj5 = (object)this - (object)gameSessionData._activeCharacter;
					flag8 = obj5 == null;
				}
				else
				{
					flag8 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				}
				if (!flag8)
				{
					goto IL_018b;
				}
			}
			arcanaManager.arcanaManager_Support.SendHailFromTheFutureGift(this);
		}
		goto IL_018b;
		IL_018b:
		if (_PlayerIndex >= 0)
		{
			OnLevelUpFollowers();
		}
		CharacterSkillCardsManager characterSkillCardsManager = CharacterSkillCardsManager;
		List<CharacterSkillCard_Base> characterCards = characterSkillCardsManager._characterCards;
		object obj6 = 0;
		List<CharacterSkillCard_Base> characterCards2 = characterSkillCardsManager._characterCards;
		object obj7 = 0;
		while (true)
		{
			if ((nint)obj6 < characterCards._size)
			{
				if ((nint)obj7 >= characterCards2._size)
				{
					break;
				}
				CharacterSkillCard_Base[] items = characterCards2._items;
				items[obj7].OnOwnerLevelUp();
				characterCards2 = characterSkillCardsManager._characterCards;
				obj7++;
				obj6 = obj7;
				characterCards = characterSkillCardsManager._characterCards;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public unsafe virtual void OnLevelUpFollowers()
	{
		//IL_0039: Expected O, but got Ref
		List<CharacterController> followers = GM.Core.GetFollowers(this);
		List<CharacterController> list = followers;
		List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			CharacterController characterController = null;
			List<CharacterController>.Enumerator enumerator2 = (List<CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public virtual void OnLevelUpCompleted()
	{
		if (_PlayerIndex < 0 && _deficiencyControl != null)
		{
			_deficiencyControl.HandleOnLevelUpCompleted();
		}
	}

	public virtual void OnLevelUpSkipped()
	{
		//IL_001d: Expected O, but got I4
		//IL_0026: Expected O, but got I4
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		CharacterSkillCardsManager characterSkillCardsManager = CharacterSkillCardsManager;
		List<CharacterSkillCard_Base> characterCards = characterSkillCardsManager._characterCards;
		object obj = 0;
		object obj2 = 0;
		List<CharacterSkillCard_Base> characterCards2 = characterSkillCardsManager._characterCards;
		while (true)
		{
			if ((nint)obj2 < characterCards._size)
			{
				if ((nint)obj >= characterCards2._size)
				{
					break;
				}
				CharacterSkillCard_Base[] items = characterCards2._items;
				items[obj].OnOwnerLevelUpSkipped();
				characterCards2 = characterSkillCardsManager._characterCards;
				obj++;
				obj2 = obj;
				characterCards = characterSkillCardsManager._characterCards;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public virtual void Revive(float percentage = 1f, bool instantRevival = false)
	{
		//IL_0185: Expected O, but got I
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_004c: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_01fa: Expected O, but got I
		//IL_0298: Expected O, but got I4
		//IL_01e5: Expected O, but got I8
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			PerformRevival(percentage);
			CharacterSkillCardsManager characterSkillCardsManager = CharacterSkillCardsManager;
			List<CharacterSkillCard_Base> characterCards = characterSkillCardsManager._characterCards;
			object obj = 0;
			object obj2 = 0;
			List<CharacterSkillCard_Base> characterCards2 = characterSkillCardsManager._characterCards;
			while (true)
			{
				if ((nint)obj2 < characterCards._size)
				{
					if ((nint)obj >= characterCards2._size)
					{
						break;
					}
					CharacterSkillCard_Base[] items = characterCards2._items;
					items[obj].OnOwnerRevived(percentage, instantRevival);
					characterCards2 = characterSkillCardsManager._characterCards;
					obj++;
					obj2 = obj;
					characterCards = characterSkillCardsManager._characterCards;
					continue;
				}
				return;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			return;
		}
		if (_deathConsequenceTimer != null)
		{
			_deathConsequenceTimer.Cancel();
		}
		if (!_coherenceSync.HasStateAuthority)
		{
			return;
		}
		Action<long, float> action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r9_v5 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r9_v5 (Il2CppMethodInfo)+4C]");
		object obj3 = (nint)0 >> 4;
		object obj4 = obj3 & 1;
		object obj5;
		if (obj4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r9_v5 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 2)
			{
				obj5 = 6447765328L;
				goto IL_028f;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rax_v14 (System.Action`2<System.Int64, System.Single>)+10]");
		obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rax_v14 (System.Action`2<System.Int64, System.Single>)+20]");
		_ = 0;
		goto IL_028f;
		IL_028f:
		object obj6 = 24;
		_ = 6447765216L;
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		float param = default(float);
		bool flag = _coherenceSync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
	}

	public void OnlineRevival(long startingSimFrame, float percentage)
	{
		_003C_003Ec__DisplayClass476_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass476_0();
		CS_0024_003C_003E8__locals4._003C_003E4__this = this;
		CS_0024_003C_003E8__locals4.percentage = percentage;
		Action onSyncedTimer = delegate
		{
			CS_0024_003C_003E8__locals4._003C_003E4__this.PerformRevival(CS_0024_003C_003E8__locals4.percentage);
		};
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	private unsafe void PerformRevival(float percentage)
	{
		//IL_0cfc: Expected O, but got I
		//IL_0d6c: Expected I, but got O
		//IL_0218: Expected I, but got O
		//IL_0255: Expected O, but got Ref
		//IL_033f: Expected I4, but got O
		//IL_033f: Expected I4, but got F4
		//IL_03bf: Expected O, but got I
		//IL_03f1: Expected O, but got I
		//IL_07e8: Expected O, but got I
		//IL_081a: Expected O, but got I
		//IL_077f: Expected F4, but got I4
		//IL_0384->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_03a9->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_045a->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0a48->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0560->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0a6a->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0a95->IL0c6a: Incompatible stack heights: 1 vs 0
		//IL_0dac->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0ab4->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0592->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_05c9->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0b64->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0b05->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_05f8->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0b90->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0bb2->IL0c6a: Incompatible stack heights: 1 vs 0
		//IL_07ad->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0bdb->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0dca->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_07d2->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_066a->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0c00->IL0c6a: Incompatible stack heights: 1 vs 0
		//IL_0851->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0c22->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_087d->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_08d3->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0c49->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0902->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_06f5->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0c6a->IL0c6a: Incompatible stack heights: 1 vs 0
		//IL_0931->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0724->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_0741->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_09db->IL0c94: Incompatible stack heights: 1 vs 0
		//IL_09fd->IL0c94: Incompatible stack heights: 1 vs 0
		GameManager gameManager = _gameManager;
		if ((object)_gameManager != null && gameManager._multiplayer != null)
		{
			if (gameManager._multiplayer.IsOnlineMultiplayer)
			{
				GameObject gameObject = base.gameObject;
				if ((object)gameObject == null)
				{
					goto IL_0c94;
				}
				if (!gameObject.activeSelf)
				{
					return;
				}
			}
			Action onRevivalStarted = this.m_OnRevivalStarted;
			if (this.m_OnRevivalStarted != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v776.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			BaseBody baseBody = body;
			_sentRevivalCommand = false;
			_receivingDamage = false;
			_isDead = false;
			if (body != null)
			{
				baseBody._enable = true;
				if ((object)_CharacterRenderer != null)
				{
					Transform transform = _CharacterRenderer.transform;
					bool flag = (object)transform == null;
					IntPtr intPtr = default(IntPtr);
					object obj = (nint)intPtr;
					float num2 = default(float);
					object obj2 = default(object);
					object[] array = default(object[]);
					if (!flag)
					{
						int num = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Despawn, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)transform, false, num2, obj2, array);
						obj = transform;
						bool flag2 = false;
					}
					if ((object)_DeathNoHurtRenderer != null)
					{
						Transform transform2 = _DeathNoHurtRenderer.transform;
						if ((object)transform2 != null)
						{
							int num3 = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Despawn, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)transform2, false, num2, obj2, array);
							obj = transform2;
							bool flag2 = false;
						}
						if ((object)_CharacterRenderer != null)
						{
							Transform transform3 = _CharacterRenderer.transform;
							bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
							InitDeathNoHurtRenderer();
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							nint num4 = (nint)this;
							float num5 = MaxHp();
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							nint num6 = (nint)this;
							float num7 = MaxHp();
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							object arg = default(object);
							object arg2 = default(object);
							object arg3 = default(object);
							System.ParamsArray paramsArray = new System.ParamsArray(arg, arg2, arg3);
							object obj3 = default(object);
							string message = string.FormatHelper((IFormatProvider)null, "Performing Revival: Percentage: {0}. Max Hp: {1}. Hp Being Recovered: {2}", (System.ParamsArray)(&obj3));
							Debug.Log(message);
							float num8 = MaxHp();
							float num9 = 0f * percentage;
							RecoverHp(num9);
							IsInvul = true;
							float invincibilityTimer = _invincibilityTimer + 2f;
							_hasLastBreath = true;
							_invincibilityTimer = invincibilityTimer;
							if (_regenTimer != null)
							{
								_regenTimer.Cancel();
							}
							Action onComplete = Regenerate;
							TimerType type = default(TimerType);
							Timer regenTimer = Timers.Register(1f, onComplete, null, isLooped: true, (byte)(int)num2 != 0, (MonoBehaviour)obj2, (int)array, type, isOnlineTimer: false, canPause: false);
							_regenTimer = regenTimer;
							Action<float> action = null;
							bool flag4 = true;
							Transform gameManager2 = (Transform)(object)_gameManager;
							if ((object)_gameManager != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rbx_v12 (UnityEngine.Transform)+168]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rbx_v12 (UnityEngine.Transform)+168]");
									int playerCount = ((MultiplayerManager)0).GetPlayerCount();
									if (playerCount <= 1)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rbx_v12 (UnityEngine.Transform)+168]");
										if (!((MultiplayerManager)0).IsOnlineMultiplayer)
										{
											bool flag5 = _PlayerIndex >= 0;
											float num10 = num9;
											float num11 = 1f;
											if (flag5)
											{
												goto IL_0a24;
											}
										}
									}
									CharacterWeaponsManager weaponsManager = _weaponsManager;
									if ((object)_weaponsManager != null)
									{
										weaponsManager._maxActiveCount = -1;
										_weaponsManager.SetMaxWeaponCount(weaponsManager._maxActiveCount, weaponsManager._maxHiddenCount);
										if (_multiplayerDecompositionTimer != null)
										{
											_multiplayerDecompositionTimer.Cancel();
										}
										if (_multiplayerReviveShake1 != null)
										{
											_multiplayerReviveShake1.Cancel();
										}
										if (_multiplayerReviveShake2 != null)
										{
											_multiplayerReviveShake2.Cancel();
										}
										if (_deathConsequenceTimer != null)
										{
											_deathConsequenceTimer.Cancel();
										}
										if ((object)_multiplayerRevivalUI != null)
										{
											GameObject gameObject2 = _multiplayerRevivalUI.gameObject;
											if ((object)gameObject2 != null)
											{
												gameObject2.SetActive(value: false);
												if ((object)_multiplayerRevivalUI != null)
												{
													_multiplayerRevivalUI.SetGhost(isGhost: false);
													GameManager core = GM.Core;
													if ((object)GM.Core != null)
													{
														CoopConfig coopConfig = core.CoopConfig;
														if ((object)core.CoopConfig != null)
														{
															bool flag6 = !coopConfig._removeDeadPlayersFromCamera;
															float num10 = num9;
															float num11 = 1f;
															action = null;
															if (flag6)
															{
																goto IL_0789;
															}
															ProCamera2D instance = ProCamera2D.Instance;
															Transform targetTransform = base.transform;
															if ((object)instance != null)
															{
																Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget = instance.GetCameraTarget(targetTransform);
																bool flag7 = cameraTarget != null;
																num10 = num9;
																num11 = 1f;
																action = null;
																if (flag7)
																{
																	goto IL_0789;
																}
																ProCamera2D instance2 = ProCamera2D.Instance;
																Transform cameraTarget2 = CameraTarget;
																GameManager core2 = GM.Core;
																if ((object)GM.Core != null)
																{
																	CoopConfig coopConfig2 = core2.CoopConfig;
																	if ((object)core2.CoopConfig != null && (object)instance2 != null)
																	{
																		num10 = coopConfig2._removeDeadPlayerFromCameraDuration;
																		Com.LuisPedroFonseca.ProCamera2D.CameraTarget cameraTarget3 = instance2.AddCameraTarget(cameraTarget2, 1f, 1f, num2, (Vector2)obj2);
																		num11 = 0f;
																		action = null;
																		goto IL_0789;
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
						}
					}
				}
			}
		}
		goto IL_0c94;
		IL_0789:
		Transform gameManager3 = (Transform)(object)_gameManager;
		if ((object)_gameManager != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rbx_v17 (UnityEngine.Transform)+168]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rbx_v17 (UnityEngine.Transform)+168]");
				int playerCount2 = ((MultiplayerManager)0).GetPlayerCount();
				if (playerCount2 <= 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rbx_v17 (UnityEngine.Transform)+168]");
					if (!((MultiplayerManager)0).IsOnlineMultiplayer)
					{
						goto IL_08af;
					}
				}
				if (_playerOptions != null)
				{
					PlayerOptionsData config = _playerOptions.Config;
					if (config != null)
					{
						if (config._003CShowPlayerIndicators_003Ek__BackingField)
						{
							ShowMultiplayerIndicator();
						}
						goto IL_08af;
					}
				}
			}
		}
		goto IL_0c94;
		IL_08af:
		GameManager gameManager4 = _gameManager;
		if ((object)_gameManager != null)
		{
			GameSessionData gameSessionData = gameManager4._gameSessionData;
			if (gameManager4._gameSessionData != null)
			{
				CharacterController activeCharacter = gameSessionData._activeCharacter;
				if ((object)gameSessionData._activeCharacter != null)
				{
					bool flag4;
					if (!activeCharacter._isDead)
					{
						bool isDisconnectedFromOnlinePlay = gameSessionData._activeCharacter.IsDisconnectedFromOnlinePlay;
						bool flag8 = !isDisconnectedFromOnlinePlay;
						flag4 = false;
						if (flag8)
						{
							goto IL_0a24;
						}
					}
					bool flag9 = _PlayerIndex < 0;
					flag4 = false;
					if (!flag9)
					{
						GameManager gameManager5 = _gameManager;
						if ((object)_gameManager == null || gameManager5._gameSessionData == null)
						{
							goto IL_0c94;
						}
						gameManager5._gameSessionData.ActiveCharacter = this;
						Action<float> action = null;
						flag4 = false;
					}
					goto IL_0a24;
				}
			}
		}
		goto IL_0c94;
		IL_0a24:
		GameManager gameManager6 = _gameManager;
		if ((object)_gameManager != null && gameManager6._multiplayer != null)
		{
			if (!gameManager6._multiplayer.IsOnlineMultiplayer)
			{
				return;
			}
			if ((object)_coherenceSync != null)
			{
				if (_coherenceSync.HasStateAuthority)
				{
					GameManager gameManager7 = _gameManager;
					if ((object)_gameManager == null)
					{
						goto IL_0c94;
					}
					if (gameManager7._003CIsInPauseGameState_003Ek__BackingField)
					{
						if ((object)OnlineStageManager._instance == null)
						{
							goto IL_0c94;
						}
						OnlineStageManager._instance.SendFreezeMyPlayer(freeze: true);
						Action<float> action = null;
					}
				}
				if (_playerOptions != null)
				{
					PlayerOptionsData config2 = _playerOptions.Config;
					if (config2 != null)
					{
						if (!config2._003CSelectedOnlineFreeRoam_003Ek__BackingField)
						{
							return;
						}
						GameManager gameManager8 = _gameManager;
						if ((object)_gameManager != null)
						{
							if (gameManager8._003CFreeRoamCameraTargetWhenDead_003Ek__BackingField <= 0)
							{
								return;
							}
							if (gameManager8._mainCharacters != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								ArcadeSprite arcadeSprite = default(ArcadeSprite);
								if ((object)arcadeSprite != null)
								{
									float2 float5 = arcadeSprite.position;
									float2 float6 = default(float2);
									base.position = float6;
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0c94;
		IL_0c94:
		throw new NullReferenceException();
	}

	private void CancelDeathConsequencesTimer()
	{
		if (_deathConsequenceTimer != null)
		{
			_deathConsequenceTimer.Cancel();
		}
	}

	public void AddXp(float value, XPMultiplierMode multiplierMode = XPMultiplierMode.Normal)
	{
		//IL_0013: Expected O, but got I4
		bool flag = multiplierMode == XPMultiplierMode.Normal;
		float xp;
		float xp2;
		float num;
		if (!flag)
		{
			object obj = multiplierMode - 1;
			if (!flag)
			{
				if ((nint)obj == 1)
				{
					xp = value + _xp;
					goto IL_00ce;
				}
				return;
			}
			xp2 = _xp;
			num = value * GameManager.ExperienceMultiplier;
		}
		else
		{
			xp2 = _xp;
			GameManager gameManager = _gameManager;
			ArcanaManager arcanaManager = gameManager._arcanaManager;
			float num2 = value * GameManager.ExperienceMultiplier;
			num = num2 * arcanaManager._003CXpMultiplier_003Ek__BackingField;
		}
		xp = num + xp2;
		goto IL_00ce;
		IL_00ce:
		_xp = xp;
	}

	public void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKnockBack = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		bool damaged = GetDamaged(value);
	}

	public void OnGetDamaged(HitVfxType hitVfxType, bool hasKb = true)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5ABA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		OnGetDamaged();
	}

	public bool IsUnitDead()
	{
		if (_isDead)
		{
			return true;
		}
		return IsDisconnectedFromOnlinePlay;
	}

	public float CurrentHealth()
	{
		return _currentHp;
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public void SetMaxHistory(int max)
	{
		_spriteTrail.Reset();
		SpriteTrail spriteTrail = _spriteTrail;
		spriteTrail._MaxHistory = max;
		spriteTrail.InitialiseGhosts(expandExisting: true);
	}

	public void DisableMultiplayerRevival()
	{
		_multiplayerRevivalAllowed = false;
		if (_multiplayerReviveShake1 != null)
		{
			_multiplayerReviveShake1.Cancel();
		}
		if (_multiplayerReviveShake2 != null)
		{
			_multiplayerReviveShake2.Cancel();
		}
		if (_multiplayerDecompositionTimer != null)
		{
			_multiplayerDecompositionTimer.Cancel();
		}
	}

	public unsafe bool WouldWeaponSynergise(WeaponType type)
	{
		//IL_0067: Expected O, but got I
		//IL_007c: Expected O, but got I
		//IL_0091: Expected O, but got I
		//IL_00c8: Expected O, but got I4
		//IL_00d1: Expected O, but got I4
		//IL_01ac: Expected O, but got I4
		//IL_01b4: Expected O, but got Ref
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_02bf: Expected O, but got I4
		//IL_02c7: Expected O, but got Ref
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)type);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v36 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v36 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v37+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdi_v16+58]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdi_v16+58]");
			bool flag = (nint)0 == 0;
			bool result = false;
			if (!flag)
			{
				object obj5 = 0;
				object obj6 = 0;
				while (true)
				{
					object obj7 = obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdi_v17+18]");
					bool flag2 = (nint)obj7 >= 0;
					result = false;
					if (flag2)
					{
						break;
					}
					CharacterWeaponsManager weaponsManager = _weaponsManager;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdi_v17+20+v112 @ rbx_v19*4]");
					Weapon weaponByType = weaponsManager.GetWeaponByType(WeaponType.VOID);
					if ((object)weaponByType == null || ((UnityEngine.Object)weaponByType).m_CachedPtr == (IntPtr)0)
					{
						CharacterAccessoriesManager accessoriesManager = _accessoriesManager;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdi_v17+20+v112 @ rbx_v19*4]");
						Accessory accessoryByType = accessoriesManager.GetAccessoryByType(WeaponType.VOID);
						if (!accessoryByType)
						{
							obj5++;
							obj6 = obj5;
							continue;
						}
					}
					result = true;
					break;
				}
				List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj8 = 0;
					List<Equipment>.Enumerator enumerator2 = (List<Equipment>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
				List<Equipment>.Enumerator enumerator3 = default(List<Equipment>.Enumerator);
				if (enumerator3.MoveNext())
				{
					object obj9 = 0;
					Dictionary<System.Int32Enum, object> dictionary = (Dictionary<System.Int32Enum, object>)(&enumerator3);
					throw new NullReferenceException();
				}
			}
			return result;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		bool result2 = default(bool);
		return result2;
	}

	public void GiveMaxedWeaponToPlayer(WeaponType weaponType, int minusMaxLevel = 0)
	{
		//IL_001d: Expected O, but got I4
		//IL_0026: Expected O, but got I4
		//IL_0056: Expected O, but got I
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			object obj3 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)weaponType);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v6 (System.Object)+18]");
			object obj4 = -minusMaxLevel;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
			{
				GM.Core.LevelWeaponUp(weaponType, removeFromStore: true, this);
				GM.Core.HandleLevelUp();
				obj2++;
				obj = obj2;
				continue;
			}
			break;
		}
	}

	public void InitCharacterSpotlight()
	{
		CharacterLightManager characterLightManager = _characterLightManager;
		if ((object)_characterLightManager != null && ((UnityEngine.Object)characterLightManager).m_CachedPtr != (IntPtr)0)
		{
			GameObject gameObject = _characterLightManager.gameObject;
			GameManager core = GM.Core;
			Stage stage = core._stage;
			StageData baseStageData = stage._baseStageData;
			gameObject.SetActive(baseStageData._003ChasCharacterSpotlight_003Ek__BackingField);
		}
	}

	public unsafe float2 ApplyRacingOffset(CharacterVehicleType characterVehicleType)
	{
		//IL_00b9: Expected O, but got Ref
		RacingOffsetData racingOffsetData = _currentCharacterData.GetRacingOffsetData(characterVehicleType);
		float2 result;
		if (racingOffsetData != null)
		{
			if ((object)racingOffsetData._003CracingOffset_003Ek__BackingField != null)
			{
			}
			bool flag = (object)racingOffsetData._003CracingAngle_003Ek__BackingField == null;
			float2 float5 = default(float2);
			result = float5;
			if (!flag)
			{
				CheckRenderer();
				bool flag2 = base.flipX;
				if ((object)racingOffsetData._003CracingAngle_003Ek__BackingField == null)
				{
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					float2 result2 = default(float2);
					return result2;
				}
				Transform transform = base._spriteRenderer.transform;
				Vector2? vector = default(Vector2?);
				transform.localEulerAngles = (Vector3)(&vector);
				result = float5;
			}
		}
		else
		{
			result = float2.zero;
		}
		return result;
	}

	public virtual float PInvulTime()
	{
		PlayerModifierStats playerStats = _playerStats;
		bool flag = !(1000f > playerStats._003CInvulTimeBonus_003Ek__BackingField);
		float result = 1000f;
		if (!flag)
		{
			result = playerStats._003CInvulTimeBonus_003Ek__BackingField;
		}
		return result;
	}

	public virtual float PShieldTime()
	{
		PlayerModifierStats playerStats = _playerStats;
		float num = _shieldInvulTime + playerStats._003CInvulTimeBonus_003Ek__BackingField;
		bool flag = !(1000f > num);
		float result = 1000f;
		if (!flag)
		{
			result = num;
		}
		return result;
	}

	public virtual float PArmor()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CArmor_003Ek__BackingField;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018758B96Eh\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				goto IL_00eb;
			}
		}
		num = 3.4028235E+38f;
		goto IL_00eb;
		IL_00eb:
		bool flag = !(50f > num);
		float num2 = 50f;
		if (!flag)
		{
			num2 = num;
		}
		return num2 + ArmorManualIncrease;
	}

	public virtual float PCurse()
	{
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CCurse_003Ek__BackingField;
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		WickedSeason wickedSeason = arcanaManager._wickedSeason;
		float eggValue = default(float);
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggValue);
		eggValue = eggFloat._eggVal * wickedSeason._curse;
		value = eggFloat._val * wickedSeason._curse;
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018758BAC6h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public virtual float PGrowth()
	{
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CGrowth_003Ek__BackingField;
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		WickedSeason wickedSeason = arcanaManager._wickedSeason;
		float eggValue = default(float);
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggValue);
		eggValue = eggFloat._eggVal * wickedSeason._growth;
		value = eggFloat._val * wickedSeason._growth;
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018758BC23h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public virtual float PLuck()
	{
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CLuck_003Ek__BackingField;
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		WickedSeason wickedSeason = arcanaManager._wickedSeason;
		float eggValue = default(float);
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggValue);
		eggValue = eggFloat._eggVal * wickedSeason._luck;
		value = eggFloat._val * wickedSeason._luck;
		if (eggFloat2._val > MaxReachedPLuck)
		{
			MaxReachedPLuck = eggFloat2._val;
		}
		if (MinReachedPLuck > eggFloat2._val)
		{
			MinReachedPLuck = eggFloat2._val;
		}
		return eggFloat2._val;
	}

	public virtual float PGreed()
	{
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CGreed_003Ek__BackingField;
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		WickedSeason wickedSeason = arcanaManager._wickedSeason;
		float eggValue = default(float);
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggValue);
		eggValue = eggFloat._eggVal * wickedSeason._greed;
		value = eggFloat._val * wickedSeason._greed;
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018758BEC3h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public virtual float PSpeed()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CSpeed_003Ek__BackingField;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018758BF44h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public virtual float PDuration()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CDuration_003Ek__BackingField;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018758BFB4h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public virtual float PAreaFinal(float preClampMultiplier = 1f)
	{
		object obj = default(object);
		if (_sineArea == null)
		{
			float num = PArea();
			float num2 = (float)obj * preClampMultiplier;
			bool flag = !(10f > num2);
			float result = 10f;
			if (!flag)
			{
				result = num2;
			}
			return result;
		}
		float num3 = PArea();
		float value = _sineArea.Value;
		float num4 = value * (float)obj;
		float num5 = num4 * preClampMultiplier;
		bool flag2 = !(10f > num5);
		float result2 = 10f;
		if (!flag2)
		{
			result2 = num5;
		}
		return result2;
	}

	public virtual float PArea()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected F4, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected F4, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CArea_003Ek__BackingField;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018758C0D8h\"");
				if (num == -1f / 0f)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
					return -3.4028235E+38f & 0;
				}
				goto IL_00eb;
			}
		}
		num = 3.4028235E+38f;
		goto IL_00eb;
		IL_00eb:
		float num2 = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		return num2 & 0;
	}

	public virtual float PRegen()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CRegen_003Ek__BackingField;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018758C144h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public virtual float MaxHp()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CMaxHp_003Ek__BackingField;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018758C1B7h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public virtual float PMoveSpeed()
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CMoveSpeed_003Ek__BackingField;
		float eggValue = default(float);
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggValue);
		eggValue = eggFloat._eggVal * MoveSpeedMultiplier;
		value = eggFloat._val * MoveSpeedMultiplier;
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018758C2ABh\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public virtual float PCooldownFinal(float cap = 0.1f)
	{
		object obj = default(object);
		if (_sineCooldown == null)
		{
			float num = PCooldown();
			float num2 = (float)obj + _003CSilentCooldown_003Ek__BackingField;
			bool flag = !(cap < num2);
			float num3 = cap;
			if (!flag)
			{
				num3 = num2;
			}
			if (num3 > MaxReachedPCoolDownFinal)
			{
				MaxReachedPCoolDownFinal = num3;
			}
			if (MinReachedPCoolDownFinal > num3)
			{
				MinReachedPCoolDownFinal = num3;
			}
			return num3;
		}
		float num4 = PCooldown();
		float value = _sineCooldown.Value;
		float num5 = (float)obj + _003CSilentCooldown_003Ek__BackingField;
		float num6 = value * num5;
		bool flag2 = !(cap < num6);
		float result = cap;
		if (!flag2)
		{
			result = num6;
		}
		return result;
	}

	public virtual float PCooldown()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018758C404h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public virtual float PAmount()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CAmount_003Ek__BackingField;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018758C474h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public virtual EggDouble PRevivals()
	{
		PlayerModifierStats playerStats = _playerStats;
		if (_playerStats != null)
		{
			return playerStats._003CRevivals_003Ek__BackingField;
		}
		return (EggDouble)(object)new NullReferenceException();
	}

	public float PPowerFinal()
	{
		float num2;
		object obj = default(object);
		if (_sineMight == null)
		{
			float num = PPower();
			num2 = (float)obj + _003CSilentMight_003Ek__BackingField;
		}
		else
		{
			float num3 = PPower();
			float value = _sineMight.Value;
			float num4 = (float)obj + _003CSilentMight_003Ek__BackingField;
			num2 = value * num4;
		}
		bool flag = !(10f > num2);
		float result = 10f;
		if (!flag)
		{
			result = num2;
		}
		return result;
	}

	public float PPowerWithoutSilentMight()
	{
		float num2;
		float num3 = default(float);
		if (_sineMight == null)
		{
			float num = PPower();
			num2 = num3;
		}
		else
		{
			float num4 = PPower();
			float value = _sineMight.Value;
			num2 = value * num3;
		}
		bool flag = !(10f > num2);
		float result = 10f;
		if (!flag)
		{
			result = num2;
		}
		return result;
	}

	public virtual float PPower()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
		float num = eggFloat._eggVal + eggFloat._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018758C614h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				return num;
			}
		}
		return 3.4028235E+38f;
	}

	public void AddTemporaryBonus(Action start, Action end, float duration)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: start.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		float duration2 = duration * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(duration2, end, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public void ReportBody(long startingSimFrame, CoherenceSync player)
	{
		_003C_003Ec__DisplayClass517_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass517_0();
		CS_0024_003C_003E8__locals4._003C_003E4__this = this;
		CS_0024_003C_003E8__locals4.player = player;
		Action onSyncedTimer = delegate
		{
			CharacterController component = CS_0024_003C_003E8__locals4.player.GetComponent<CharacterController>();
			GM.Core.QueueReportBody(CS_0024_003C_003E8__locals4._003C_003E4__this, component);
		};
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void PerformReportBody(CharacterController player)
	{
		//IL_0050: Expected I, but got O
		//IL_005e: Expected I, but got O
		//IL_006e: Expected O, but got I
		//IL_00ee: Expected O, but got I4
		//IL_00aa: Expected O, but got I
		//IL_00e0: Expected O, but got I4
		Weapon weaponByType = _weaponsManager.GetWeaponByType(WeaponType.C1_REPORT1);
		ReportWeapon reportWeapon;
		if ((object)weaponByType == null)
		{
			reportWeapon = null;
			goto IL_0170;
		}
		nint num = (nint)weaponByType;
		nint num2 = (nint)typeof(ReportWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.ReportWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.ReportWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rax_v21+FFFFFFF8+v67 @ rax_v17*8]");
			if (0 == (nint)typeof(ReportWeapon))
			{
				obj3 = 1;
				goto IL_0149;
			}
		}
		obj3 = 0;
		goto IL_0149;
		IL_0149:
		bool flag = obj3 == null;
		reportWeapon = null;
		if (!flag)
		{
			reportWeapon = (ReportWeapon)weaponByType;
		}
		goto IL_0170;
		IL_0170:
		if ((object)reportWeapon != null && ((UnityEngine.Object)reportWeapon).m_CachedPtr != (IntPtr)0)
		{
			reportWeapon.ReportBody(player);
		}
	}

	public void FireSireWeapon(bool skipTriggers)
	{
		//IL_0050: Expected I, but got O
		//IL_005e: Expected I, but got O
		//IL_006e: Expected O, but got I
		//IL_00ee: Expected O, but got I4
		//IL_00aa: Expected O, but got I
		//IL_00e0: Expected O, but got I4
		Weapon weaponByType = _weaponsManager.GetWeaponByType(WeaponType.SIRE);
		SireWeapon sireWeapon;
		if ((object)weaponByType == null)
		{
			sireWeapon = null;
			goto IL_0170;
		}
		nint num = (nint)weaponByType;
		nint num2 = (nint)typeof(SireWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.SireWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.SireWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rax_v21+FFFFFFF8+v67 @ rax_v17*8]");
			if (0 == (nint)typeof(SireWeapon))
			{
				obj3 = 1;
				goto IL_0149;
			}
		}
		obj3 = 0;
		goto IL_0149;
		IL_0149:
		bool flag = obj3 == null;
		sireWeapon = null;
		if (!flag)
		{
			sireWeapon = (SireWeapon)weaponByType;
		}
		goto IL_0170;
		IL_0170:
		if ((object)sireWeapon != null && ((UnityEngine.Object)sireWeapon).m_CachedPtr != (IntPtr)0)
		{
			sireWeapon.FireSire(skipTriggers);
		}
	}

	public void FirePentagramWeapon(bool eraseItems, bool skipTriggers)
	{
		//IL_0050: Expected I, but got O
		//IL_005e: Expected I, but got O
		//IL_006e: Expected O, but got I
		//IL_00ee: Expected O, but got I4
		//IL_00aa: Expected O, but got I
		//IL_00e0: Expected O, but got I4
		Weapon weaponByType = _weaponsManager.GetWeaponByType(WeaponType.PENTAGRAM);
		PentagramWeapon pentagramWeapon;
		if ((object)weaponByType == null)
		{
			pentagramWeapon = null;
			goto IL_017d;
		}
		nint num = (nint)weaponByType;
		nint num2 = (nint)typeof(PentagramWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.PentagramWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.PentagramWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rax_v21+FFFFFFF8+v70 @ rax_v17*8]");
			if (0 == (nint)typeof(PentagramWeapon))
			{
				obj3 = 1;
				goto IL_0156;
			}
		}
		obj3 = 0;
		goto IL_0156;
		IL_0156:
		bool flag = obj3 == null;
		pentagramWeapon = null;
		if (!flag)
		{
			pentagramWeapon = (PentagramWeapon)weaponByType;
		}
		goto IL_017d;
		IL_017d:
		if ((object)pentagramWeapon != null && ((UnityEngine.Object)pentagramWeapon).m_CachedPtr != (IntPtr)0)
		{
			pentagramWeapon._003CEraseItems_003Ek__BackingField = eraseItems;
			pentagramWeapon.PerformFire(skipTriggers);
		}
	}

	public void FireBattiliaWeapon()
	{
		//IL_0050: Expected I, but got O
		//IL_005e: Expected I, but got O
		//IL_006e: Expected O, but got I
		//IL_00ee: Expected O, but got I4
		//IL_00aa: Expected O, but got I
		//IL_00e0: Expected O, but got I4
		Weapon weaponByType = _weaponsManager.GetWeaponByType(WeaponType.BATTILIA);
		BattiliaWeapon battiliaWeapon;
		if ((object)weaponByType == null)
		{
			battiliaWeapon = null;
			goto IL_0172;
		}
		nint num = (nint)weaponByType;
		nint num2 = (nint)typeof(BattiliaWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.BattiliaWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.BattiliaWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v21+FFFFFFF8+v64 @ rax_v17*8]");
			if (0 == (nint)typeof(BattiliaWeapon))
			{
				obj3 = 1;
				goto IL_014b;
			}
		}
		obj3 = 0;
		goto IL_014b;
		IL_014b:
		bool flag = obj3 == null;
		battiliaWeapon = null;
		if (!flag)
		{
			battiliaWeapon = (BattiliaWeapon)weaponByType;
		}
		goto IL_0172;
		IL_0172:
		if ((object)battiliaWeapon != null && ((UnityEngine.Object)battiliaWeapon).m_CachedPtr != (IntPtr)0)
		{
			battiliaWeapon.FireInternal(true, false);
		}
	}

	public void FireVenusCrescentWeapon(bool skipTriggers)
	{
		//IL_0050: Expected I, but got O
		//IL_005e: Expected I, but got O
		//IL_006e: Expected O, but got I
		//IL_00ee: Expected O, but got I4
		//IL_00aa: Expected O, but got I
		//IL_00e0: Expected O, but got I4
		Weapon weaponByType = _weaponsManager.GetWeaponByType(WeaponType.TP_SPIRITTORNADO2);
		TP_SpiritTornado2_Weapon tP_SpiritTornado2_Weapon;
		if ((object)weaponByType == null)
		{
			tP_SpiritTornado2_Weapon = null;
			goto IL_0170;
		}
		nint num = (nint)weaponByType;
		nint num2 = (nint)typeof(TP_SpiritTornado2_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rax_v21+FFFFFFF8+v67 @ rax_v17*8]");
			if (0 == (nint)typeof(TP_SpiritTornado2_Weapon))
			{
				obj3 = 1;
				goto IL_0149;
			}
		}
		obj3 = 0;
		goto IL_0149;
		IL_0149:
		bool flag = obj3 == null;
		tP_SpiritTornado2_Weapon = null;
		if (!flag)
		{
			tP_SpiritTornado2_Weapon = (TP_SpiritTornado2_Weapon)weaponByType;
		}
		goto IL_0170;
		IL_0170:
		if ((object)tP_SpiritTornado2_Weapon != null && ((UnityEngine.Object)tP_SpiritTornado2_Weapon).m_CachedPtr != (IntPtr)0)
		{
			tP_SpiritTornado2_Weapon.FireVenusCrescent(skipTriggers);
		}
	}

	public void EmergencyMeeting(long startingSimFrame, byte[] serializedEnemyTypes, int voteTarget)
	{
		//IL_0077: Expected I, but got O
		//IL_0085: Expected I, but got O
		//IL_0095: Expected O, but got I
		//IL_0115: Expected O, but got I4
		//IL_00d1: Expected O, but got I
		//IL_0107: Expected O, but got I4
		_003C_003Ec__DisplayClass523_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass523_0();
		CS_0024_003C_003E8__locals8.voteTarget = voteTarget;
		List<EnemyType> enemies = SerializationUtils.DeserializeEnum<EnemyType>(serializedEnemyTypes);
		CS_0024_003C_003E8__locals8.enemies = enemies;
		Weapon weaponByType = _weaponsManager.GetWeaponByType(WeaponType.C1_REPORT2);
		bool flag = (object)weaponByType == null;
		Weapon weapon = weaponByType;
		if (flag)
		{
			goto IL_019a;
		}
		nint num = (nint)weaponByType;
		nint num2 = (nint)typeof(Report2Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Report2Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Weapons.Report2Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rax_v38+FFFFFFF8+v253 @ rax_v33*8]");
			if (0 == (nint)typeof(Report2Weapon))
			{
				obj3 = 1;
				goto IL_01ac;
			}
		}
		obj3 = 0;
		goto IL_01ac;
		IL_019a:
		CS_0024_003C_003E8__locals8.weapon = (Report2Weapon)weapon;
		Report2Weapon weapon2 = CS_0024_003C_003E8__locals8.weapon;
		if ((object)CS_0024_003C_003E8__locals8.weapon != null && ((UnityEngine.Object)weapon2).m_CachedPtr != (IntPtr)0)
		{
			Action onSyncedTimer = delegate
			{
				CS_0024_003C_003E8__locals8.weapon.OnlinePerformVote(CS_0024_003C_003E8__locals8.enemies, CS_0024_003C_003E8__locals8.voteTarget);
			};
			OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
		}
		return;
		IL_01ac:
		bool flag2 = obj3 == null;
		weapon = null;
		if (!flag2)
		{
			weapon = weaponByType;
		}
		goto IL_019a;
	}

	public void SendApplyWeaponLevelUp(WeaponType weapon)
	{
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			ApplyWeaponLevelUp(weapon);
			return;
		}
		Action<long, int> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		int param = default(int);
		bool flag = _coherenceSync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
	}

	public void OnlineApplyWeaponLevelUp(long startingSimFrame, int weaponType)
	{
		_003C_003Ec__DisplayClass525_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass525_0();
		CS_0024_003C_003E8__locals4._003C_003E4__this = this;
		CS_0024_003C_003E8__locals4.weaponType = weaponType;
		Action onSyncedTimer = delegate
		{
			CS_0024_003C_003E8__locals4._003C_003E4__this.ApplyWeaponLevelUp((WeaponType)CS_0024_003C_003E8__locals4.weaponType);
		};
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer);
	}

	public void SendAddAttribute(WeaponType weaponType, float value)
	{
		//IL_0020: Expected O, but got I
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0095: Expected O, but got I
		//IL_010a: Expected O, but got I4
		//IL_0080: Expected O, but got I8
		Action<long, int, float> action = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r9_v1 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r9_v1 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		object obj3;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r9_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 3)
			{
				obj3 = 6447778992L;
				goto IL_0101;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Action`3<System.Int64, System.Int32, System.Single>)+10]");
		obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Action`3<System.Int64, System.Int32, System.Single>)+20]");
		_ = 0;
		goto IL_0101;
		IL_0101:
		object obj4 = 24;
		_ = 6447778848L;
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		int param = default(int);
		float param2 = default(float);
		bool flag = _coherenceSync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param, param2);
	}

	public void AddAttributeOnline(long startingSimFrame, int weaponType, float value)
	{
		_003C_003Ec__DisplayClass527_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass527_0();
		CS_0024_003C_003E8__locals6._003C_003E4__this = this;
		CS_0024_003C_003E8__locals6.value = value;
		CS_0024_003C_003E8__locals6.weaponType = weaponType;
		Action onSyncedTimer = delegate
		{
			CS_0024_003C_003E8__locals6._003C_003E4__this.AddAttribute((WeaponType)CS_0024_003C_003E8__locals6.weaponType, CS_0024_003C_003E8__locals6.value);
		};
		OnlineStageManager._instance.FireSyncTimer(startingSimFrame, onSyncedTimer, canBePaused: false);
	}

	public void AddAttribute(WeaponType weaponType, float value)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 43 Invalid \"Jump target not found in method: 0x18758DB98\"");
	}

	private unsafe void ApplyWeaponLevelUp(WeaponType weapon)
	{
		//IL_009d: Expected O, but got I
		//IL_00b2: Expected O, but got I
		//IL_0111: Expected O, but got Ref
		//IL_0111: Expected O, but got I
		GM.Core.LevelWeaponUp(weapon, removeFromStore: true, this);
		GameManager core = GM.Core;
		core._gizmoManager.DisplayWeaponLevelup(this);
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rax_v13 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rax_v13 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v14+20]");
			object obj3 = 0;
			GameManager core2 = GM.Core;
			Color coopColour = GetCoopColour();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			GizmoManager gizmoManager = core2._gizmoManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v8+40]");
			object obj4 = default(object);
			CharacterController character = default(CharacterController);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			string textureName = default(string);
			gizmoManager.DisplayIconOverhead((string)0, "1", (Color?)(object)(&obj4), character, displayTimeMultiplier, vOffset, textureName);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void QueueWeaponSelectionSelector(WeaponType weapon, string selectionType)
	{
		_003CQueueWeaponSelectionInternal_003Ed__531 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.type = weapon;
		obj.selectionType = selectionType;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator QueueWeaponSelectionInternal(WeaponType type, string selectionType)
	{
		_003CQueueWeaponSelectionInternal_003Ed__531 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.type = type;
		obj.selectionType = selectionType;
		return obj;
	}

	public void SendSetGlimmerNextFireForWeapon(WeaponType weapon)
	{
		Action<long, int> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA5A20");
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		int param = default(int);
		bool flag = _coherenceSync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame, param);
	}

	public void SetGlimmerNextFireForWeapon(long frame, int weaponType)
	{
		//IL_004f: Expected I, but got O
		//IL_005d: Expected I, but got O
		//IL_006d: Expected O, but got I
		//IL_00ed: Expected O, but got I4
		//IL_00a9: Expected O, but got I
		//IL_00df: Expected O, but got I4
		Weapon weaponByType = _weaponsManager.GetWeaponByType((WeaponType)weaponType);
		object obj;
		if ((object)weaponByType == null)
		{
			obj = null;
			goto IL_01cc;
		}
		nint num = (nint)weaponByType;
		nint num2 = (nint)typeof(EME_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Weapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Weapon>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v34+FFFFFFF8+v123 @ rax_v30*8]");
			if (0 == (nint)typeof(EME_Weapon))
			{
				obj4 = 1;
				goto IL_01a5;
			}
		}
		obj4 = 0;
		goto IL_01a5;
		IL_01a5:
		bool flag = obj4 == null;
		obj = null;
		if (!flag)
		{
			obj = weaponByType;
		}
		goto IL_01cc;
		IL_01cc:
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rbx_v3 (System.Object)+10]");
			if ((nint)0 != 0)
			{
				Action onSyncedTimer = ((EME_Weapon)obj).SetGlimmerFirstTimeOnline;
				OnlineStageManager._instance.FireSyncTimer(frame, onSyncedTimer);
				return;
			}
		}
		int num4 = default(int);
		string text = num4.ToString();
		string text2 = ToString();
		string message = "Cannot SetGlimmerNextFireForWeapon since no weapon found for weapon type " + text + " that is an EME_Weapon on character " + text2;
		Debug.LogError(message, this);
	}

	protected void Pushback(GameObject value, float duration)
	{
	}

	public void SetHealth(float health)
	{
		_currentHp = health;
		float num = MaxHp();
		float num2 = default(float);
		if (health > num2)
		{
			float num3 = MaxHp();
			_currentHp = num2;
		}
	}

	public void Kill()
	{
		TakeDamage(_currentHp);
	}

	public void Resurrect()
	{
		_multiplayerRevivalProportion = 1f;
	}

	public void Die()
	{
		//IL_016c: Expected I, but got O
		GameManager gameManager = _gameManager;
		_isDead = true;
		int playerCount = gameManager._multiplayer.GetPlayerCount();
		if (playerCount <= 1 && !gameManager._multiplayer.IsOnlineMultiplayer && _PlayerIndex >= 0)
		{
			BaseBody baseBody = body;
			baseBody._enable = false;
		}
		else
		{
			GameManager gameManager2 = _gameManager;
			if (gameManager2._multiplayer.IsOnlineMultiplayer)
			{
				GameObject gameObject = base.gameObject;
				if (!gameObject.activeSelf)
				{
					return;
				}
			}
			CharacterWeaponsManager weaponsManager = _weaponsManager;
			_multiplayerRevivalProportion = 0f;
			weaponsManager._maxActiveCount = 0;
			weaponsManager.SetMaxWeaponCount(0, 0);
			if (body != null)
			{
				nint num = (nint)typeof(float2);
				BaseBody baseBody2 = body;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rax_v15 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
				nint num2 = 0;
				baseBody2._velocity = float2.zero;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rcx_v11 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
				_ = 0;
			}
		}
		OnDeath();
	}

	public void DisableIfFollower()
	{
		//IL_0043: Expected I, but got O
		if (_PlayerIndex < 0)
		{
			CharacterWeaponsManager weaponsManager = _weaponsManager;
			weaponsManager._maxActiveCount = 0;
			weaponsManager.SetMaxWeaponCount(0, 0);
			nint num = (nint)typeof(float2);
			BaseBody baseBody = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v6 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
			nint num2 = 0;
			baseBody._velocity = float2.zero;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v4 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
			_ = 0;
			BaseBody baseBody2 = body;
			baseBody2._enable = false;
			_CharacterRenderer.enabled = false;
			_spriteTrail.enabled = false;
		}
	}

	public void EnableIfFollower()
	{
		if (_PlayerIndex < 0)
		{
			CharacterWeaponsManager weaponsManager = _weaponsManager;
			weaponsManager._maxActiveCount = -1;
			weaponsManager.SetMaxWeaponCount(weaponsManager._maxActiveCount, weaponsManager._maxHiddenCount);
			BaseBody baseBody = body;
			baseBody._enable = true;
			_CharacterRenderer.enabled = true;
			_spriteTrail.enabled = true;
		}
	}

	public void Debug_ToggleInvulnerability()
	{
		if (!_isInvul)
		{
			IsInvul = true;
			float invincibilityTimer = _invincibilityTimer + 3.4028234E+35f;
			_invincibilityTimer = invincibilityTimer;
			RestoreTint();
			Action onComplete = delegate
			{
				RestoreTint();
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
		else
		{
			IsInvul = false;
			_invincibilityTimer = 0f;
		}
	}

	public void FreezePlayer(bool freeze)
	{
		_blockInput = freeze;
		if (_isDead || IsDisconnectedFromOnlinePlay)
		{
			return;
		}
		CharacterWeaponsManager weaponsManager = _weaponsManager;
		int maxActiveCount = (freeze ? 1 : 0) - 1;
		weaponsManager._maxActiveCount = maxActiveCount;
		weaponsManager.SetMaxWeaponCount(maxHidden: weaponsManager._maxHiddenCount = (freeze ? 1 : 0) - 1, maxActives: weaponsManager._maxActiveCount);
		if (_freezeWeaponsTimer != null)
		{
			_freezeWeaponsTimer.Cancel();
		}
		if (freeze)
		{
			IsInvul = true;
			if (10f > _invincibilityTimer)
			{
				_invincibilityTimer = 10f;
			}
			Action onComplete = delegate
			{
				CharacterWeaponsManager weaponsManager2 = _weaponsManager;
				weaponsManager2._maxActiveCount = -1;
				weaponsManager2.SetMaxWeaponCount(weaponsManager2._maxActiveCount, weaponsManager2._maxHiddenCount);
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer freezeWeaponsTimer = Timers.Register(10f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_freezeWeaponsTimer = freezeWeaponsTimer;
		}
		else
		{
			_invincibilityTimer = 0f;
		}
	}

	public void SetPermanentInvulnerability(bool on)
	{
		_permanentInvulnerability = on;
		if (!on)
		{
			IsInvul = false;
			_invincibilityTimer = 0f;
			return;
		}
		IsInvul = true;
		float invincibilityTimer = _invincibilityTimer + 3.4028234E+35f;
		_invincibilityTimer = invincibilityTimer;
		RestoreTint();
		Action onComplete = delegate
		{
			RestoreTint();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	protected void OnPermanentInvulnerabilityUpdated(bool old, bool newValue)
	{
		SetPermanentInvulnerability(newValue);
	}

	public void SetInvulForMilliSeconds(float duration)
	{
		IsInvul = true;
		float num = duration * 0.001f;
		float invincibilityTimer = num + _invincibilityTimer;
		_invincibilityTimer = invincibilityTimer;
	}

	public void SetInvulForMilliSecondsNonCumulative(float duration)
	{
		IsInvul = true;
		float num = duration * 0.001f;
		if (num > _invincibilityTimer)
		{
			_invincibilityTimer = num;
		}
	}

	public void SetInvulForMilliSecondsNonCumulativeIncludeParma(float duration)
	{
		IsInvul = true;
		PlayerModifierStats playerStats = _playerStats;
		float num = duration + playerStats._003CInvulTimeBonus_003Ek__BackingField;
		float num2 = num * 0.001f;
		if (num2 > _invincibilityTimer)
		{
			_invincibilityTimer = num2;
		}
	}

	public bool TryGettingChomped()
	{
		if (!_receivingDamage)
		{
			_receivingDamage = true;
			PlayDamageParticleFX();
			Action onComplete = delegate
			{
				_damageVfx.Stop();
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer multiplayerChompTimer = Timers.Register(0.060000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_multiplayerChompTimer = multiplayerChompTimer;
			Action onComplete2 = delegate
			{
				_receivingDamage = false;
			};
			Timer blinkTimeoutTimer = Timers.Register(0.24000001f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_blinkTimeoutTimer = blinkTimeoutTimer;
			return true;
		}
		return false;
	}

	public void RemoveInvul()
	{
		_invincibilityTimer = 0f;
	}

	public void TriggerGetDamagedByOwnWeapon(float damageAmount)
	{
		//IL_00d2: Expected I, but got O
		//IL_006f: Expected O, but got I
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v12 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v12 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v12 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			GetDamagedByOwnWeapon(damageAmount);
			return;
		}
		Action<float> action = null;
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049AE70");
		bool flag3 = _coherenceSync.SendCommand(action, MessageTarget.All, damageAmount);
	}

	public virtual void GetDamagedByOwnWeapon(float damageAmount)
	{
		//IL_006c: Invalid comparison between I4 and F4
		//IL_008e: Invalid comparison between F4 and I4
		//IL_03e6: Expected I, but got O
		//IL_00bf: Invalid comparison between F4 and I4
		//IL_0376: Expected I, but got O
		//IL_0144: Invalid comparison between F4 and I4
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Expected O, but got Unknown
		//IL_0250: Invalid comparison between F4 and I4
		if (_receivingDamage || _isInvul || _isDead || IsDisconnectedFromOnlinePlay || !(0f < _currentHp))
		{
			return;
		}
		float num2;
		float num4;
		if (!(Barrier_Number > 0f))
		{
			PlayerModifierStats playerStats = _playerStats;
			if (!(playerStats._003CShields_003Ek__BackingField > 0f))
			{
				GameManager core = GM.Core;
				Stage stage = core._stage;
				StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
				if ((object)stageModifiers._003CEndCycles_003Ek__BackingField != null)
				{
					object obj = default(object);
					float num = playerStats._003CShroud_003Ek__BackingField - (float)obj;
					bool flag = !(num > 0f);
					num2 = damageAmount;
					if (!flag)
					{
						bool flag2 = !(damageAmount > num);
						num2 = damageAmount;
						if (!flag2)
						{
							num2 = num;
						}
					}
					EggFloat eggFloat = playerStats._003CArmor_003Ek__BackingField;
					float num3 = eggFloat._eggVal + eggFloat._val;
					object obj2 = num3 & -2147483649L;
					if ((nint)obj2 != 2139095040)
					{
						object obj3 = num3 & -2147483649L;
						if ((nint)obj3 <= 2139095040)
						{
							bool flag3 = num3 == -1f / 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018758F3E6h\"");
							if (flag3 || !(num3 > 0f))
							{
								goto IL_0454;
							}
						}
					}
					EggFloat eggFloat2 = playerStats._003CArmor_003Ek__BackingField;
					num4 = eggFloat2._eggVal + eggFloat2._val;
					object obj4 = num4 & -2147483649L;
					if ((nint)obj4 != 2139095040)
					{
						object obj5 = num4 & -2147483649L;
						if ((nint)obj5 <= 2139095040)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018758F442h\"");
							if (num4 == -1f / 0f)
							{
								num4 = -3.4028235E+38f;
							}
							goto IL_0463;
						}
					}
					num4 = 3.4028235E+38f;
					goto IL_0463;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				throw new NullReferenceException();
			}
			float num5 = --playerStats._003CShields_003Ek__BackingField;
			float num6 = PShieldTime();
			nint num7 = (nint)this;
			OnGetDamaged("#ffffbb", num5, playDamageFx: false);
			SignalBus signalBus = _signalBus;
			CharacterController characterController = this;
			bool flag4 = false;
			float num8 = num5;
		}
		else
		{
			float num9 = --Barrier_Number;
			float num10 = PShieldTime();
			nint num7 = (nint)this;
			OnGetDamaged("#ffffbb", num9, playDamageFx: false);
			SignalBus signalBus = _signalBus;
			CharacterController characterController = this;
			bool flag4 = false;
			float num8 = num9;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1980");
		return;
		IL_0463:
		num2 -= num4;
		if (1f > num2)
		{
			num2 = 1f;
		}
		goto IL_0454;
		IL_0454:
		TakeDamage(num2);
	}

	public virtual bool GetDamaged(float damageAmount)
	{
		//IL_006c: Invalid comparison between I4 and F4
		//IL_008e: Invalid comparison between F4 and I4
		//IL_0578: Expected O, but got I4
		//IL_00bf: Invalid comparison between F4 and I4
		//IL_050f: Expected O, but got I4
		//IL_0146: Expected O, but got I4
		//IL_02b5: Invalid comparison between F4 and I4
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Expected O, but got Unknown
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Expected O, but got Unknown
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Expected O, but got Unknown
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0434: Expected O, but got Unknown
		//IL_03b1: Invalid comparison between F4 and I4
		float num;
		float num9;
		if (!_receivingDamage && !_isInvul && !_isDead && !IsDisconnectedFromOnlinePlay && 0f < _currentHp)
		{
			if (!(Barrier_Number > 0f))
			{
				PlayerModifierStats playerStats = _playerStats;
				if (!(playerStats._003CShields_003Ek__BackingField > 0f))
				{
					GameManager core = GM.Core;
					Stage stage = core._stage;
					StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
					object obj = default(object);
					bool flag = (nint)obj < 0;
					bool flag2 = obj == null;
					bool flag3 = !flag;
					bool flag4 = !flag2;
					object obj2 = flag4 & flag3;
					object obj3 = (object?)stageModifiers._003CEndCycles_003Ek__BackingField & obj2;
					bool flag5 = obj3 == null;
					num = damageAmount;
					if (!flag5)
					{
						if ((object)stageModifiers._003CEndCycles_003Ek__BackingField == null)
						{
							goto IL_05cc;
						}
						float num2 = (float)obj * 0.25f;
						float num3 = num2 + 1f;
						num = damageAmount * num3;
						float num4 = MaxHp();
						if (num > num3)
						{
							float num5 = MaxHp();
							float num6 = num3 - 1f;
							bool flag6 = 10f > num6;
							num = 10f;
							if (!flag6)
							{
								num = num6;
							}
						}
					}
					PlayerModifierStats playerStats2 = _playerStats;
					GameManager core2 = GM.Core;
					Stage stage2 = core2._stage;
					StageModifiers stageModifiers2 = stage2._003CStageMods_003Ek__BackingField;
					if ((object)stageModifiers2._003CEndCycles_003Ek__BackingField == null)
					{
						goto IL_05cc;
					}
					float num7 = playerStats2._003CShroud_003Ek__BackingField - (float)obj;
					if (num7 > 0f && num > num7)
					{
						num = num7;
					}
					EggFloat eggFloat = playerStats2._003CArmor_003Ek__BackingField;
					float num8 = eggFloat._eggVal + eggFloat._val;
					object obj4 = num8 & -2147483649L;
					if ((nint)obj4 != 2139095040)
					{
						object obj5 = num8 & -2147483649L;
						if ((nint)obj5 <= 2139095040)
						{
							bool flag7 = num8 == -1f / 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018758F931h\"");
							if (flag7 || !(num8 > 0f))
							{
								goto IL_05d6;
							}
						}
					}
					EggFloat eggFloat2 = playerStats2._003CArmor_003Ek__BackingField;
					num9 = eggFloat2._eggVal + eggFloat2._val;
					object obj6 = num9 & -2147483649L;
					if ((nint)obj6 != 2139095040)
					{
						object obj7 = num9 & -2147483649L;
						if ((nint)obj7 <= 2139095040)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018758F98Dh\"");
							if (num9 == -1f / 0f)
							{
								num9 = -3.4028235E+38f;
							}
							goto IL_05ee;
						}
					}
					num9 = 3.4028235E+38f;
					goto IL_05ee;
				}
				float num10 = --playerStats._003CShields_003Ek__BackingField;
				float num11 = PShieldTime();
				OnGetDamaged("#ffffbb", num10, playDamageFx: false);
				SignalBus signalBus = _signalBus;
				CharacterController characterController = this;
				float num12 = num10;
				bool flag8 = false;
				object obj8 = 0;
			}
			else
			{
				float num13 = --Barrier_Number;
				float num14 = PShieldTime();
				OnGetDamaged("#ffffbb", num13, playDamageFx: false);
				SignalBus signalBus = _signalBus;
				CharacterController characterController = this;
				float num12 = num13;
				bool flag8 = false;
				object obj8 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1980");
			return false;
		}
		return false;
		IL_05cc:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		bool result = default(bool);
		return result;
		IL_05d6:
		TakeDamage(num);
		return true;
		IL_05ee:
		num -= num9;
		if (1f > num)
		{
			num = 1f;
		}
		goto IL_05d6;
	}

	private void TakeDamage(float damageAmount)
	{
		//IL_065e: Invalid comparison between I4 and F4
		//IL_006f: Expected O, but got I
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_0566: Expected I, but got O
		//IL_01bf: Expected I, but got O
		//IL_01cf: Expected O, but got I
		//IL_06ac: Expected O, but got I4
		//IL_0305: Expected O, but got I4
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v64 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v64 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v64 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				goto IL_0653;
			}
		}
		float num = default(float);
		float currentHp = _currentHp - num;
		_currentHp = currentHp;
		goto IL_0653;
		IL_0653:
		if (0f < _currentHp)
		{
			OnGetDamaged();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj3 = default(object);
			object obj2 = obj3 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			Type type = default(Type);
			Type signalType = type;
			object obj5 = default(object);
			object obj4 = (IntPtr)obj5;
			bool requireDeclaration = default(bool);
			_signalBus.InternalFire(signalType, obj4, (object)null, requireDeclaration);
			GameManager core = GM.Core;
			core._arcanaManager.OnPlayerHPDamage(this, num);
			CharacterSkillCardsManager characterSkillCardsManager = CharacterSkillCardsManager;
			List<CharacterSkillCard_Base> characterCards = characterSkillCardsManager._characterCards;
			bool flag3 = false;
			bool flag4 = false;
			object obj6 = obj4;
			List<CharacterSkillCard_Base> characterCards2 = characterSkillCardsManager._characterCards;
			while (true)
			{
				if ((flag4 ? 1 : 0) < characterCards._size)
				{
					if ((flag3 ? 1 : 0) >= characterCards2._size)
					{
						break;
					}
					CharacterSkillCard_Base[] items = characterCards2._items;
					CharacterSkillCard_Base characterSkillCard_Base = items[flag3 ? 1u : 0u];
					nint num2 = (nint)characterSkillCard_Base;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1057 @ rax_v60 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterSkillCard_Base>)+1F0]");
					obj6 = 0;
					characterSkillCard_Base.OnOwnerGetDamaged(num);
					characterCards2 = characterSkillCardsManager._characterCards;
					flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
					flag4 = flag3;
					characterCards = characterSkillCardsManager._characterCards;
					continue;
				}
				if (!_hasAnyCriticalHPSkill || !_isCriticalHPEnabled)
				{
					return;
				}
				float num3 = MaxHp();
				float num4 = _currentHp / 0f;
				if (_criticalHPTreshold < num4)
				{
					return;
				}
				if (_onCriticalHP != null)
				{
					Action onCriticalHP = _onCriticalHP;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1051.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					_isCriticalHPEnabled = false;
				}
				GameManager core2 = GM.Core;
				ArcanaManager arcanaManager = core2._arcanaManager;
				bool flag5 = _deficiencyControl == null;
				bool flag6 = true;
				if (!flag5)
				{
					CharacterADControl deficiencyControl = _deficiencyControl;
					object obj7 = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
					bool flag7 = obj7 == null;
					flag6 = !flag7;
				}
				int num5 = _PlayerIndex >> 31;
				int num6 = (flag6 ? 1 : 0) & num5;
				bool flag8 = num6 == 0;
				object obj8 = !flag8;
				if (obj8 == null && arcanaManager._hasCrystalCries)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD650");
					_isCriticalHPEnabled = false;
				}
				CharacterSkillCardsManager characterSkillCardsManager2 = CharacterSkillCardsManager;
				List<CharacterSkillCard_Base> characterCards3 = characterSkillCardsManager2._characterCards;
				bool flag9 = false;
				bool flag10 = false;
				List<CharacterSkillCard_Base> characterCards4 = characterSkillCardsManager2._characterCards;
				while (true)
				{
					if ((flag10 ? 1 : 0) < characterCards3._size)
					{
						if ((flag9 ? 1 : 0) >= characterCards4._size)
						{
							break;
						}
						CharacterSkillCard_Base[] items2 = characterCards4._items;
						items2[flag9 ? 1u : 0u].OnOwnerCriticalHPTreshold(num);
						characterCards4 = characterSkillCardsManager2._characterCards;
						flag9 = (byte)((flag9 ? 1u : 0u) + 1u) != 0;
						bool flag11 = characterSkillCardsManager2._characterCards != null;
						flag10 = flag9;
						characterCards3 = characterSkillCardsManager2._characterCards;
						if (!flag11)
						{
							throw new NullReferenceException();
						}
						continue;
					}
					return;
				}
				break;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		else
		{
			GameManager core3 = GM.Core;
			if (!core3._multiplayer.IsOnlineMultiplayer)
			{
				OnHpReachedZero(num);
			}
			else if (_coherenceSync.HasStateAuthority && !_isSendingDeath)
			{
				_isSendingDeath = true;
				Action action = OnHpReachedZeroOnline;
				bool flag12 = _coherenceSync.SendCommand(action, MessageTarget.All);
			}
		}
	}

	public void OnHpReachedZeroOnline()
	{
		_isSendingDeath = false;
		OnHpReachedZero();
	}

	private void OnHpReachedZero(float damageAmount = 0f)
	{
		if (_isLastBreathEnabled && _hasLastBreath)
		{
			bool flag = _onLastBreath == null;
			_currentHp = 1f;
			if (!flag)
			{
				Action onLastBreath = _onLastBreath;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v75.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				_hasLastBreath = false;
			}
			GameManager core = GM.Core;
			ArcanaManager arcanaManager = core._arcanaManager;
			if (arcanaManager._hasVictorianHorror && _hasLastBreath)
			{
				IsInvul = true;
				if (3.0000002f > _invincibilityTimer)
				{
					_invincibilityTimer = 3.0000002f;
				}
				ArcanaManager_VFX arcanaManager_VFX = arcanaManager.arcanaManager_VFX;
				if (arcanaManager_VFX.WorldEaterVFX == null)
				{
					WorldEaterVFX worldEaterVFX = new WorldEaterVFX(this);
					arcanaManager_VFX.WorldEaterVFX = worldEaterVFX;
				}
				arcanaManager_VFX.WorldEaterVFX.CastSoulSteal(null, isCursed: true);
				_hasLastBreath = false;
			}
		}
		else
		{
			_currentHp = 0f;
			Die();
		}
	}

	public virtual void OnGetDamaged(string hexColor = "#ff0000", float vulnerabilityDelay = 120f, bool playDamageFx = true, bool playWeaponDamageFx = false)
	{
		bool playWeaponDamageFx2 = default(bool);
		bool ignoreInvulnerabilityForRestoringTint = default(bool);
		OnGetDamaged(hexColor, vulnerabilityDelay, playDamageFx, playWeaponDamageFx2, ignoreInvulnerabilityForRestoringTint);
	}

	public unsafe void OnGetDamaged(string hexColor, float vulnerabilityDelay, bool playDamageFx, bool playWeaponDamageFx, bool ignoreInvulnerabilityForRestoringTint)
	{
		//IL_03db: Expected I, but got O
		//IL_0169: Expected O, but got I4
		//IL_01d2: Expected O, but got I4
		//IL_023c: Expected F4, but got I4
		//IL_0285: Expected O, but got I4
		//IL_02e3: Expected F4, but got I4
		//IL_03c9->IL0319: Incompatible stack heights: 2 vs 0
		_003C_003Ec__DisplayClass561_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass561_0();
		if (CS_0024_003C_003E8__locals7 != null)
		{
			CS_0024_003C_003E8__locals7._003C_003E4__this = this;
			bool ignoreInvulnerabilityForRestoringTint2 = default(bool);
			CS_0024_003C_003E8__locals7.ignoreInvulnerabilityForRestoringTint = ignoreInvulnerabilityForRestoringTint2;
			if (_receivingDamage)
			{
				return;
			}
			float num = PInvulTime();
			object obj = default(object);
			float num2 = vulnerabilityDelay + (float)obj;
			SpriteRenderer customDamageOverlayRenderer = _customDamageOverlayRenderer;
			Renderer renderer = (((object)_customDamageOverlayRenderer == null || ((UnityEngine.Object)customDamageOverlayRenderer).m_CachedPtr == (IntPtr)0) ? _CharacterRenderer : _customDamageOverlayRenderer);
			if ((object)renderer != null)
			{
				renderer.Internal_GetPropertyBlock(_propBlock);
				bool flag = ColorUtility.DoTryParseHtmlColor(hexColor, out Color32 _);
				string propBlock = (string)(object)_propBlock;
				if (_propBlock != null)
				{
					bool flag2 = propBlock._stringLength == 0;
					float value = default(float);
					MaterialPropertyBlock.SetColorImpl_Injected((IntPtr)propBlock._stringLength, RenderingExtensions.TintFillColor, ref *(Color*)(&value));
					RenderingExtensions.SetTintFillEnabled(_propBlock, isEnabled: true);
					string propBlock2 = (string)(object)_propBlock;
					bool flag3 = ((UnityEngine.Object)renderer).m_CachedPtr == (IntPtr)0;
					bool flag4 = _propBlock == null;
					Renderer renderer2 = null;
					if (!flag4)
					{
						renderer2 = (Renderer)propBlock2._stringLength;
					}
					Renderer.Internal_SetPropertyBlock_Injected(((UnityEngine.Object)renderer).m_CachedPtr, (IntPtr)renderer2);
					Action onComplete = delegate
					{
						CharacterController characterController = CS_0024_003C_003E8__locals7._003C_003E4__this;
						characterController._receivingDamage = false;
						CharacterController characterController2 = CS_0024_003C_003E8__locals7._003C_003E4__this;
						if (characterController2._isInvul)
						{
							CS_0024_003C_003E8__locals7._003C_003E4__this.RestoreTint();
						}
						CharacterController characterController3 = CS_0024_003C_003E8__locals7._003C_003E4__this;
						characterController3._damageVfx.Stop();
					};
					float duration = num2 * 0.001f;
					bool flag5 = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer blinkTimeoutTimer = Timers.Register(duration, onComplete, null, isLooped: false, flag5, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_blinkTimeoutTimer = blinkTimeoutTimer;
					if (playDamageFx)
					{
						PlayDamageParticleFX();
						if (_playDamageSFX)
						{
							SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
							{
								Volume = (float?)(object)1,
								Rate = 1f
							};
							float value2 = UnityEngine.Random.value;
							float num3 = value2 * 500f;
							float detune = num3 + 1000f;
							soundConfig.Detune = detune;
							PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Hit, soundConfig, 150f, 3, flag5 ? 1 : 0);
							object obj2 = default(object);
							if (obj2 == null)
							{
								SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig
								{
									Rate = 1f,
									Volume = (float?)(object)1
								};
								float value3 = UnityEngine.Random.value;
								float num4 = value3 * -500f;
								float detune2 = num4 + DamageBaseDetune;
								soundConfig2.Detune = detune2;
								PlaySoundResult playSoundResult2 = SoundManager.PlaySound(DamageSound, soundConfig2, 450f, 1, flag5 ? 1 : 0);
							}
						}
					}
					_receivingDamage = true;
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public virtual void RestoreTint()
	{
		//IL_00e3: Expected O, but got I
		//IL_01be: Expected I, but got O
		SpriteRenderer customDamageOverlayRenderer = _customDamageOverlayRenderer;
		Renderer renderer = (((object)_customDamageOverlayRenderer == null || ((UnityEngine.Object)customDamageOverlayRenderer).m_CachedPtr == (IntPtr)0) ? _CharacterRenderer : _customDamageOverlayRenderer);
		if ((object)renderer != null)
		{
			renderer.Internal_GetPropertyBlock(_propBlock);
			RenderingExtensions.SetTintFillEnabled(_propBlock, isEnabled: false);
			MaterialPropertyBlock propBlock = _propBlock;
			if (_propBlock != null)
			{
				bool flag = propBlock.m_Ptr == (IntPtr)0;
				Color value = default(Color);
				MaterialPropertyBlock.SetColorImpl_Injected(propBlock.m_Ptr, RenderingExtensions.TintFillColor, ref value);
				MaterialPropertyBlock propBlock2 = _propBlock;
				bool flag2 = ((UnityEngine.Object)renderer).m_CachedPtr == (IntPtr)0;
				Renderer.Internal_SetPropertyBlock_Injected(properties: (IntPtr)((_propBlock != null) ? ((object)(nint)propBlock2.m_Ptr) : null), _unity_self: ((UnityEngine.Object)renderer).m_CachedPtr);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void ActivateSineSpeedBonus(SineBonusData data)
	{
		SineBonus sineSpeed = new SineBonus();
		_sineSpeed = sineSpeed;
		_sineSpeed.Start(data);
	}

	public void ActivateSineDurationBonus(SineBonusData data)
	{
		SineBonus sineDuration = new SineBonus();
		_sineDuration = sineDuration;
		_sineDuration.Start(data);
	}

	public void ActivateSineMightBonus(SineBonusData data)
	{
		SineBonus sineMight = new SineBonus();
		_sineMight = sineMight;
		_sineMight.Start(data);
	}

	public void ActivateSineAreaBonus(SineBonusData data)
	{
		SineBonus sineArea = new SineBonus();
		_sineArea = sineArea;
		_sineArea.Start(data);
	}

	public void ActivateSineCooldownBonus(SineBonusData data)
	{
		SineBonus sineCooldown = new SineBonus();
		_sineCooldown = sineCooldown;
		_sineCooldown.Start(data);
	}

	public virtual void GetTreasureModifier()
	{
	}

	protected void OnXpUpdated(float oldXp, float newXp)
	{
		GameManager._003CFirePlayerXpUpdatedFromOnlineRoutine_003Ed__608 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = GM.Core;
		Coroutine coroutine = GM.Core.StartCoroutine(obj);
	}

	protected void OnMovDirectionUpdated(Vector2 oldLastMovDir, Vector2 newLastMovDir)
	{
		ProcessRawDirection();
	}

	private void SetupInput()
	{
		if (_PlayerIndex >= 0)
		{
			ReInput.PlayerHelper players = ReInput.players;
			Player player = players.GetPlayer(_PlayerIndex);
			_player = player;
		}
	}

	protected virtual void OnStop()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5AE9]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_wiggleTween != null)
		{
			_wiggleTween.Pause();
		}
		base.angle = 0f;
		if (!_hasIdleAnimation)
		{
			SpriteAnimation spriteAnimation = _spriteAnimation;
			((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = true;
		}
		else if (_currentAnimation != CharAnimationType.idle)
		{
			_isAnimForced = false;
			_spriteAnimation.SetAnimation("idle");
			_currentAnimation = CharAnimationType.idle;
		}
	}

	public virtual void OnWeaponFired(Weapon weapon)
	{
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		if (arcanaManager._003CActiveArcanas_003Ek__BackingField != null)
		{
			GameManager core2 = GM.Core;
			ArcanaManager arcanaManager2 = core2._arcanaManager;
			List<ArcanaType> list = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
			if ((nint)0 > (nint)0)
			{
				GameManager core3 = GM.Core;
				core3._arcanaManager.OnWeaponFired(weapon);
			}
		}
	}

	private unsafe void SetupDamageVfx()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00eb: Expected O, but got I
		//IL_0107: Expected O, but got I4
		//IL_0120: Expected O, but got Ref
		//IL_012f: Expected O, but got I4
		//IL_013d: Expected native int or pointer, but got O
		//IL_03f9: Expected O, but got I4
		//IL_0155: Expected O, but got Ref
		//IL_016f: Expected native int or pointer, but got O
		//IL_0189: Expected O, but got I
		//IL_01a9: Expected O, but got Ref
		//IL_01c3: Expected native int or pointer, but got O
		//IL_0416: Expected O, but got I4
		//IL_01f5: Expected O, but got Ref
		//IL_020f: Expected native int or pointer, but got O
		//IL_0450: Expected O, but got I
		//IL_0255: Expected O, but got I4
		//IL_0287: Expected O, but got I
		//IL_048a: Expected O, but got I
		//IL_02c7: Expected O, but got I
		//IL_02e2: Expected O, but got I
		//IL_02fd: Expected O, but got I
		//IL_0329: Expected O, but got I4
		//IL_033e: Expected O, but got I
		//IL_04c0: Expected O, but got I
		//IL_0536: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"WhiteDot");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		_ = 0;
		_ = 10;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B0]");
		particleSystemConfig._quantity = (int?)(object)0;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(2000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
		_ = 0;
		obj = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(225f, 315f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+10]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+20]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(75f, 125f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+40]");
		_ = 0;
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(300f);
		particleSystemConfig._gravity = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		_ = 0;
		_ = 16711680;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B0]");
		particleSystemConfig._tint = (uint?)(object)0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0.1f);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
		particleSystemConfig._bounce = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B0]");
		particleSystemConfig._collideTop = (bool?)(object)0;
		_ = 257;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B0]");
		particleSystemConfig._collideBottom = (bool?)(object)0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B0]");
		particleSystemConfig._collideLeft = (bool?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
		particleSystemConfig._on = false;
		_ = 1;
		particleSystemConfig._bounds = (Rect?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B0]");
		particleSystemConfig._collideRight = (bool?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12020]");
		_ = 0;
		ParticleSystem damageVfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, _cachedTransform);
		_damageVfx = damageVfx;
		_ = _damageVfx;
		_ = _damageVfx;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB20]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB20]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 184));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1529 @ rax_v54 (should have been resolved before IL gen)");
		Transform transform = _damageVfx.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&minMaxCurve));
	}

	private void HandlePlayerInput()
	{
		//IL_00c9: Expected O, but got F4
		Vector2 currentDirectionRaw;
		Vector2 vector2 = default(Vector2);
		if (_deficiencyControl == null)
		{
			if (!_blockInput)
			{
				if (_player == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
					string text = ToString();
					string message = "Character " + text + " has no input or MovementAI set";
					Debug.LogWarning(message);
					Vector2 vector = default(Vector2);
					currentDirectionRaw = vector;
				}
				else
				{
					float axis = _player.GetAxis("Move Horizontal");
					float axis2 = _player.GetAxis("Move Vertical");
					currentDirectionRaw = (Vector2)axis;
				}
				goto IL_0120;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
		}
		else
		{
			vector2 = _deficiencyControl.CalculateMovement();
		}
		currentDirectionRaw = vector2;
		goto IL_0120;
		IL_0120:
		_currentDirectionRaw = currentDirectionRaw;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 164 Invalid \"Jump target not found in method: 0x187592070\"");
		throw new NullReferenceException();
	}

	private void ProcessRawDirection()
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00bb: Invalid comparison between O and F4
		//IL_0046: Expected O, but got I
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		Vector2 vector = _currentDirectionRaw;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875920D8h\"");
		if ((object)_currentDirectionRaw == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.CharacterController)+17C]");
			vector = (Vector2)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875920D8h\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.CharacterController)+17C]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
				Vector2 currentDirection = default(Vector2);
				_currentDirection = currentDirection;
				_walked = 0f;
				return;
			}
		}
		object obj = this + 376;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
		Vector2 currentDirection2;
		if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) && !_003CIsPlatformMovementActive_003Ek__BackingField)
		{
			object obj2 = this + 376;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
			Vector2 vector2 = default(Vector2);
			currentDirection2 = vector2;
		}
		else
		{
			Vector2 vector3 = default(Vector2);
			currentDirection2 = vector3;
		}
		_currentDirection = currentDirection2;
		_lastMovementDirection = _currentDirection;
		_lastFacingDirection = _currentDirection;
		float frameWalk = FrameWalk;
		float walked = frameWalk + _walked;
		_walked = walked;
	}

	protected virtual Vector2 ProcessMovementVector(Vector2 v)
	{
		return v;
	}

	private void Regenerate()
	{
		//IL_0013: Invalid comparison between F4 and I4
		float num = PRegen();
		float num2 = default(float);
		if (num2 > 0f)
		{
			float num3 = PRegen();
			RecoverHp(num2);
		}
	}

	private unsafe void SetDamageFxColor()
	{
		//IL_0051: Expected O, but got Ref
		//IL_0062: Expected O, but got Ref
		CharacterData currentCharacterData = _currentCharacterData;
		if (currentCharacterData._003CnoHurt_003Ek__BackingField)
		{
		}
		object obj = default(object);
		ParticleSystem.MinMaxGradient minMaxGradient = (Color)(&obj);
		ParticleSystem.MainModule mainModule = default(ParticleSystem.MainModule);
		object obj2 = default(object);
		mainModule.startColor = (ParticleSystem.MinMaxGradient)(&obj2);
	}

	private void InitDeathNoHurtRenderer()
	{
		_DeathNoHurtRenderer.enabled = false;
		Transform transform = _DeathNoHurtRenderer.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
	}

	protected virtual bool OnCharacterOverlapsDestructible_Destroy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0108: Expected I4, but got O
		//IL_00f1: Expected F4, but got I4
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				Destructible component = gameObject.GetComponent<Destructible>();
				if ((object)component != null)
				{
					if (!component._isDead && !component._003CIsStationary_003Ek__BackingField)
					{
						component.GetDamaged(component._maxHp, HitVfxType.Fire, 0f, WeaponType.VOID, hasKb: false);
						float? volume = default(float?);
						float rate = default(float);
						float detune = default(float);
						bool loop = default(bool);
						PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Coin, 1f, 1, 0f, volume, rate, detune, loop, 1f);
					}
					return false;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected unsafe virtual void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0129: Expected I4, but got O
		//IL_03c7: Expected O, but got I
		//IL_082e: Expected O, but got Ref
		//IL_0849: Expected O, but got Ref
		//IL_0857: Expected O, but got Ref
		//IL_03b2: Expected O, but got I
		//IL_0477: Expected O, but got I4
		//IL_050b: Expected O, but got I
		//IL_052e: Expected O, but got I
		//IL_052e: Expected F4, but got I
		//IL_0939: Expected O, but got Ref
		//IL_0956: Expected O, but got Ref
		//IL_0966: Expected I4, but got O
		//IL_0978: Expected O, but got Ref
		//IL_0990: Expected native int or pointer, but got O
		//IL_05d4: Expected O, but got Ref
		//IL_0625: Expected I4, but got O
		//IL_09aa: Expected I4, but got O
		//IL_0a7f: Expected O, but got Ref
		//IL_0aa6: Expected F4, but got I
		//IL_0ac7: Expected F4, but got I
		//IL_0ae8: Expected F4, but got I
		//IL_0b04: Expected F4, but got I
		//IL_0b20: Expected F4, but got I
		//IL_09e9: Expected O, but got Ref
		//IL_0a06: Expected O, but got Ref
		//IL_0a16: Expected I4, but got O
		//IL_0a28: Expected O, but got Ref
		//IL_0a40: Expected native int or pointer, but got O
		//IL_06df: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_level = 1;
		_shieldInvulTime = 240f;
		if (!dontGetCharacterDataForCurrentLevel)
		{
			GetCharacterDataForCurrentLevel(1);
		}
		CharacterData currentCharacterData = _currentCharacterData;
		CharacterData characterData;
		if (_currentCharacterData != null)
		{
			_level = currentCharacterData._003Clevel_003Ek__BackingField;
			SetCharacterSprite();
			if (_currentJsonData != null)
			{
				object modifierStats = _currentJsonData.ToObject<object>();
				if (_playerStats != null)
				{
					_playerStats.Set((ModifierStats)modifierStats);
					float num = MaxHp();
					CharacterData currentCharacterData2 = _currentCharacterData;
					float currentHp = default(float);
					_currentHp = currentHp;
					if (_currentCharacterData != null)
					{
						WeaponType startingWeaponType = (((object)currentCharacterData2._003CstartingWeapon_003Ek__BackingField == null) ? WeaponType.WHIP : ((WeaponType)((object?)currentCharacterData2._003CstartingWeapon_003Ek__BackingField >> 32)));
						_startingWeaponType = startingWeaponType;
						if ((object)_magnet != null)
						{
							_magnet.RefreshSize();
							CharacterData currentCharacterData3 = _currentCharacterData;
							if (_currentCharacterData != null)
							{
								if (currentCharacterData3._003CsineSpeed_003Ek__BackingField != null)
								{
									ActivateSineSpeedBonus(currentCharacterData3._003CsineSpeed_003Ek__BackingField);
								}
								CharacterData currentCharacterData4 = _currentCharacterData;
								if (_currentCharacterData != null)
								{
									if (currentCharacterData4._003CsineCooldown_003Ek__BackingField != null)
									{
										SineBonus sineCooldown = new SineBonus();
										_sineCooldown = sineCooldown;
										if (_sineCooldown == null)
										{
											goto IL_077c;
										}
										_sineCooldown.Start(currentCharacterData4._003CsineCooldown_003Ek__BackingField);
									}
									CharacterData currentCharacterData5 = _currentCharacterData;
									if (_currentCharacterData != null)
									{
										if (currentCharacterData5._003CsineArea_003Ek__BackingField != null)
										{
											ActivateSineAreaBonus(currentCharacterData5._003CsineArea_003Ek__BackingField);
										}
										CharacterData currentCharacterData6 = _currentCharacterData;
										if (_currentCharacterData != null)
										{
											if (currentCharacterData6._003CsineDuration_003Ek__BackingField != null)
											{
												ActivateSineDurationBonus(currentCharacterData6._003CsineDuration_003Ek__BackingField);
											}
											CharacterData currentCharacterData7 = _currentCharacterData;
											if (_currentCharacterData != null)
											{
												if (currentCharacterData7._003CsineMight_003Ek__BackingField != null)
												{
													SineBonus sineMight = new SineBonus();
													_sineMight = sineMight;
													if (_sineMight == null)
													{
														goto IL_077c;
													}
													_sineMight.Start(currentCharacterData7._003CsineMight_003Ek__BackingField);
												}
												_ = _damageVfx;
												_ = _damageVfx;
												CharacterData currentCharacterData8 = _currentCharacterData;
												if (currentCharacterData8._003CnoHurt_003Ek__BackingField)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
													object obj3 = 0;
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
													object obj3 = 0;
												}
												Color color = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
												ParticleSystem.MinMaxGradient minMaxGradient = color;
												ParticleSystem.MinMaxGradient startColor = (ParticleSystem.MinMaxGradient)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
												ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 127));
												_ = minMaxGradient.m_Mode;
												_ = minMaxGradient.m_GradientMax;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v951 @ rax_v39 (UnityEngine.ParticleSystem+MinMaxGradient)+20]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v951 @ rax_v39 (UnityEngine.ParticleSystem+MinMaxGradient)+30]");
												_ = 0;
												((ParticleSystem.MainModule*)mainModule)->startColor = startColor;
												CharacterData currentSkinData = _currentSkinData;
												if (_currentSkinData != null)
												{
													_ = currentSkinData._003CbodyOffset_003Ek__BackingField;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v955 @ rax_v41 (VampireSurvivors.Data.Characters.CharacterData)+178]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
													if ((nint)0 != 0)
													{
														characterData = _currentSkinData;
														goto IL_08bb;
													}
												}
												CharacterData currentCharacterData9 = _currentCharacterData;
												if (_currentCharacterData != null)
												{
													_ = currentCharacterData9._003CbodyOffset_003Ek__BackingField;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
													bool flag = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rax_v124 (VampireSurvivors.Data.Characters.CharacterData)+178]");
													_ = 0;
													float? num2 = (float?)(object)0;
													if (!flag)
													{
														characterData = _currentCharacterData;
														goto IL_08bb;
													}
													goto IL_08d8;
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
		goto IL_077c;
		IL_090c:
		SpriteRenderer spriteRenderer = default(SpriteRenderer);
		if ((object)base._spriteRenderer != null)
		{
			bool flag2 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
			bool flag3 = flag2;
		}
		else
		{
			bool flag3 = true;
		}
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
		_ = _characterType;
		object arg = (CharacterType)obj5;
		System.ParamsArray paramsArray = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
		_ = 0;
		_ = 0;
		object arg2 = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg2, arg));
		System.ParamsArray args = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
		_ = 0;
		string message = string.FormatHelper((IFormatProvider)null, "Is Rend null? {0} for character {1}", args);
		Debug.Log(message);
		CheckRenderer();
		bool flag4 = (byte)(int)base._spriteRenderer != 0;
		if ((int)(~base._spriteRenderer) == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rbx_v12 (System.Boolean)+10]");
			if ((nint)0 != 0)
			{
				CheckRenderer();
				if ((object)base._spriteRenderer == null)
				{
					goto IL_077c;
				}
				Sprite sprite = base._spriteRenderer.sprite;
				if ((object)sprite != null)
				{
					bool flag5 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
					bool flag6 = flag5;
				}
				else
				{
					bool flag6 = true;
				}
				object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 111));
				_ = _characterType;
				object arg3 = (CharacterType)obj7;
				System.ParamsArray paramsArray2 = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
				_ = 0;
				_ = 0;
				object arg4 = default(object);
				System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray2, new System.ParamsArray(arg4, arg3));
				args = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
				_ = 0;
				string message2 = string.FormatHelper((IFormatProvider)null, "Is Rend.sprite null? {0} for character {1}", args);
				Debug.Log(message2);
			}
		}
		CheckRenderer();
		if ((object)base._spriteRenderer != null)
		{
			Sprite sprite2 = base._spriteRenderer.sprite;
			if ((object)sprite2 != null)
			{
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v65 (UnityEngine.Sprite)+10]");
				bool flag7 = (nint)0 == 0;
				object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 89));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v65 (UnityEngine.Sprite)+10]");
				Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj8);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-51]");
				_defaultSpriteWidth = 0f;
				float num3 = PCooldownFinal();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-51]");
				MaxReachedPCoolDownFinal = 0f;
				float num4 = PCooldownFinal();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-51]");
				MinReachedPCoolDownFinal = 0f;
				float num5 = PLuck();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-51]");
				MaxReachedPLuck = 0f;
				float num6 = PLuck();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-51]");
				MinReachedPLuck = 0f;
				return;
			}
		}
		goto IL_077c;
		IL_08bb:
		if (characterData != null)
		{
			_ = characterData._003CbodyOffset_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-59]");
			if ((nint)0 == 0)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				goto IL_090c;
			}
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v120 (VampireSurvivors.Data.Characters.CharacterData)+178]");
			_ = 0;
			_ = 1;
			if (body != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
				float? num2 = (float?)(object)0;
				BaseBody baseBody = body;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-55]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+67]");
				BaseBody baseBody2 = baseBody.setOffset(num7, (float?)(object)0);
				goto IL_08d8;
			}
		}
		goto IL_077c;
		IL_077c:
		throw new NullReferenceException();
		IL_08d8:
		CharacterData levelZeroCharacterData = _levelZeroCharacterData;
		if (_levelZeroCharacterData == null)
		{
			goto IL_077c;
		}
		if (levelZeroCharacterData._003ConEveryLevelUp_003Ek__BackingField != null)
		{
			_onEveryLevelUp = levelZeroCharacterData._003ConEveryLevelUp_003Ek__BackingField;
		}
		AddAttackAnimations();
		CheckRenderer();
		spriteRenderer = base._spriteRenderer;
		goto IL_090c;
	}

	public void UpdateMagnet()
	{
		_magnet.RefreshSize();
	}

	protected virtual void AddAttackAnimations()
	{
		//IL_0161: Expected O, but got I4
		//IL_0161: Expected I4, but got O
		//IL_02b3: Expected O, but got I4
		//IL_02b3: Expected I4, but got O
		//IL_0405: Expected O, but got I4
		//IL_0405: Expected I4, but got O
		//IL_0557: Expected O, but got I4
		//IL_0557: Expected I4, but got O
		//IL_0693: Expected O, but got I4
		//IL_0693: Expected I4, but got O
		//IL_07cf: Expected O, but got I4
		//IL_07cf: Expected I4, but got O
		Skin currentSkinData = _currentCharacterData.GetCurrentSkinData();
		MeleeAttack meleeAnim;
		if (currentSkinData != null)
		{
			SpriteAnims spriteAnims = currentSkinData._003CspriteAnims_003Ek__BackingField;
			if (currentSkinData._003CspriteAnims_003Ek__BackingField != null)
			{
				meleeAnim = spriteAnims._003CmeleeAttack_003Ek__BackingField;
				goto IL_07df;
			}
		}
		meleeAnim = null;
		goto IL_07df;
		IL_082a:
		MeleeAttack idleAnim;
		_idleAnim = idleAnim;
		Vector2 pivot = default(Vector2);
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		bool autoSetAnimation = default(bool);
		if (_idleAnim != null)
		{
			MeleeAttack idleAnim2 = _idleAnim;
			string animName = idleAnim2._003CspriteName_003Ek__BackingField.Replace("01.png", "");
			MeleeAttack idleAnim3 = _idleAnim;
			bool respectAnimationXPivots = RespectAnimationXPivots;
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, idleAnim3._003CframesNumber_003Ek__BackingField, pivot, text, num, flag);
			MeleeAttack idleAnim4 = _idleAnim;
			_spriteAnimation.AddAnimation("idle", animationFrames, idleAnim4._003CframeRate_003Ek__BackingField, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
			_hasIdleAnimation = true;
		}
		return;
		IL_080c:
		MeleeAttack magicAnim;
		_magicAnim = magicAnim;
		if (_magicAnim != null)
		{
			MeleeAttack magicAnim2 = _magicAnim;
			string animName2 = magicAnim2._003CspriteName_003Ek__BackingField.Replace("01.png", "");
			MeleeAttack magicAnim3 = _magicAnim;
			bool respectAnimationXPivots2 = RespectAnimationXPivots;
			List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames(animName2, 1, magicAnim3._003CframesNumber_003Ek__BackingField, pivot, text, num, flag);
			MeleeAttack magicAnim4 = _magicAnim;
			Action action = OnMagicAComplete;
			_spriteAnimation.AddAnimation("magicA", animationFrames2, magicAnim4._003CframeRate_003Ek__BackingField, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		}
		MeleeAttack specialAnim;
		if (currentSkinData != null)
		{
			SpriteAnims spriteAnims2 = currentSkinData._003CspriteAnims_003Ek__BackingField;
			if (currentSkinData._003CspriteAnims_003Ek__BackingField != null)
			{
				specialAnim = spriteAnims2._003CspecialAnimation_003Ek__BackingField;
				goto IL_081b;
			}
		}
		specialAnim = null;
		goto IL_081b;
		IL_081b:
		_specialAnim = specialAnim;
		if (_specialAnim != null)
		{
			MeleeAttack specialAnim2 = _specialAnim;
			string animName3 = specialAnim2._003CspriteName_003Ek__BackingField.Replace("01.png", "");
			MeleeAttack specialAnim3 = _specialAnim;
			bool respectAnimationXPivots3 = RespectAnimationXPivots;
			List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames(animName3, 1, specialAnim3._003CframesNumber_003Ek__BackingField, pivot, text, num, flag);
			MeleeAttack specialAnim4 = _specialAnim;
			_spriteAnimation.AddAnimation("special", animationFrames3, specialAnim4._003CframeRate_003Ek__BackingField, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		}
		if (currentSkinData != null)
		{
			SpriteAnims spriteAnims3 = currentSkinData._003CspriteAnims_003Ek__BackingField;
			if (currentSkinData._003CspriteAnims_003Ek__BackingField != null)
			{
				idleAnim = spriteAnims3._003CidleAnimation_003Ek__BackingField;
				goto IL_082a;
			}
		}
		idleAnim = null;
		goto IL_082a;
		IL_07df:
		_meleeAnim = meleeAnim;
		if (_meleeAnim != null)
		{
			MeleeAttack meleeAnim2 = _meleeAnim;
			string animName4 = meleeAnim2._003CspriteName_003Ek__BackingField.Replace("01.png", "");
			MeleeAttack meleeAnim3 = _meleeAnim;
			bool respectAnimationXPivots4 = RespectAnimationXPivots;
			List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames(animName4, 1, meleeAnim3._003CframesNumber_003Ek__BackingField, pivot, text, num, flag);
			MeleeAttack meleeAnim4 = _meleeAnim;
			Action action2 = OnMeleeAComplete;
			_spriteAnimation.AddAnimation("meleeA", animationFrames4, meleeAnim4._003CframeRate_003Ek__BackingField, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		}
		MeleeAttack meleeAnim5;
		if (currentSkinData != null)
		{
			SpriteAnims spriteAnims4 = currentSkinData._003CspriteAnims_003Ek__BackingField;
			if (currentSkinData._003CspriteAnims_003Ek__BackingField != null)
			{
				meleeAnim5 = spriteAnims4._003CmeleeAttack2_003Ek__BackingField;
				goto IL_07ee;
			}
		}
		meleeAnim5 = null;
		goto IL_07ee;
		IL_07fd:
		MeleeAttack rangedAnim;
		_rangedAnim = rangedAnim;
		if (_rangedAnim != null)
		{
			MeleeAttack rangedAnim2 = _rangedAnim;
			string animName5 = rangedAnim2._003CspriteName_003Ek__BackingField.Replace("01.png", "");
			MeleeAttack rangedAnim3 = _rangedAnim;
			bool respectAnimationXPivots5 = RespectAnimationXPivots;
			List<Sprite> animationFrames5 = SpriteManager.GetAnimationFrames(animName5, 1, rangedAnim3._003CframesNumber_003Ek__BackingField, pivot, text, num, flag);
			MeleeAttack rangedAnim4 = _rangedAnim;
			Action action3 = OnRangedAComplete;
			_spriteAnimation.AddAnimation("rangedA", animationFrames5, rangedAnim4._003CframeRate_003Ek__BackingField, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		}
		if (currentSkinData != null)
		{
			SpriteAnims spriteAnims5 = currentSkinData._003CspriteAnims_003Ek__BackingField;
			if (currentSkinData._003CspriteAnims_003Ek__BackingField != null)
			{
				magicAnim = spriteAnims5._003CmagicAttack_003Ek__BackingField;
				goto IL_080c;
			}
		}
		magicAnim = null;
		goto IL_080c;
		IL_07ee:
		_meleeAnim2 = meleeAnim5;
		if (_meleeAnim2 != null)
		{
			MeleeAttack meleeAnim6 = _meleeAnim2;
			string animName6 = meleeAnim6._003CspriteName_003Ek__BackingField.Replace("01.png", "");
			MeleeAttack meleeAnim7 = _meleeAnim2;
			bool respectAnimationXPivots6 = RespectAnimationXPivots;
			List<Sprite> animationFrames6 = SpriteManager.GetAnimationFrames(animName6, 1, meleeAnim7._003CframesNumber_003Ek__BackingField, pivot, text, num, flag);
			MeleeAttack meleeAnim8 = _meleeAnim2;
			Action action4 = OnMeleeAComplete;
			_spriteAnimation.AddAnimation("meleeB", animationFrames6, meleeAnim8._003CframeRate_003Ek__BackingField, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		}
		if (currentSkinData != null)
		{
			SpriteAnims spriteAnims6 = currentSkinData._003CspriteAnims_003Ek__BackingField;
			if (currentSkinData._003CspriteAnims_003Ek__BackingField != null)
			{
				rangedAnim = spriteAnims6._003CrangedAttack_003Ek__BackingField;
				goto IL_07fd;
			}
		}
		rangedAnim = null;
		goto IL_07fd;
	}

	private void OnMeleeAComplete()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5AF0]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_isAnimForced = false;
		if (!_hasIdleAnimation)
		{
			_spriteAnimation.SetAnimation("walk");
			_currentAnimation = CharAnimationType.walk;
		}
		else
		{
			_spriteAnimation.SetAnimation("idle");
			_currentAnimation = CharAnimationType.idle;
		}
	}

	public virtual void OnMeleeAttackAnim()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5AF1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_meleeAnim != null && !_isAnimForced)
		{
			SpriteAnimation spriteAnimation = _spriteAnimation;
			_isAnimForced = true;
			((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
			_canFlip = true;
			_spriteAnimation.SetAnimation("meleeA");
			_currentAnimation = CharAnimationType.melee;
		}
	}

	protected void OnRangedAComplete()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5AF2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_isAnimForced = false;
		if (!_hasIdleAnimation)
		{
			_spriteAnimation.SetAnimation("walk");
			_currentAnimation = CharAnimationType.walk;
		}
		else
		{
			_spriteAnimation.SetAnimation("idle");
			_currentAnimation = CharAnimationType.idle;
		}
	}

	public virtual void OnRangedAttackAnim()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5AF3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_rangedAnim != null && !_isAnimForced)
		{
			SpriteAnimation spriteAnimation = _spriteAnimation;
			_isAnimForced = true;
			((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
			_spriteAnimation.SetAnimation("rangedA");
			_currentAnimation = CharAnimationType.ranged;
		}
	}

	private void OnMagicAComplete()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5AF4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_isAnimForced = false;
		if (!_hasIdleAnimation)
		{
			_spriteAnimation.SetAnimation("walk");
			_currentAnimation = CharAnimationType.walk;
		}
		else
		{
			_spriteAnimation.SetAnimation("idle");
			_currentAnimation = CharAnimationType.idle;
		}
	}

	public virtual void OnMagicAttackAnim()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5AF5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_magicAnim != null && !_isAnimForced)
		{
			SpriteAnimation spriteAnimation = _spriteAnimation;
			_isAnimForced = true;
			((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
			_spriteAnimation.SetAnimation("magicA");
			_currentAnimation = CharAnimationType.magic;
		}
	}

	public virtual void ClearFromSpecialAnims()
	{
	}

	public virtual void OnAttackAnim(Weapon.FiringAnimation firingAnimation)
	{
	}

	private unsafe void GetCharacterDataForCurrentLevel(int level)
	{
		//IL_00e2: Expected O, but got Ref
		//IL_01ec: Expected O, but got I4
		//IL_0447: Expected I, but got O
		//IL_024f: Expected I, but got O
		//IL_028b: Expected I, but got O
		DataManager dataManager = _dataManager;
		if (_dataManager != null)
		{
			bool flag = dataManager._003CAllCharacters_003Ek__BackingField == null;
			if (!flag)
			{
				int num = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllCharacters_003Ek__BackingField).FindEntry((System.Int32Enum)_characterType);
				if (flag)
				{
					return;
				}
				DataManager dataManager2 = _dataManager;
				if (_dataManager != null && dataManager2._003CAllCharacters_003Ek__BackingField != null)
				{
					object obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllCharacters_003Ek__BackingField).get_Item((System.Int32Enum)_characterType);
					if (obj != null)
					{
						IEnumerator<JToken> enumerator = ((JArray)obj).GetEnumerator();
						object obj3 = default(object);
						object obj2 = (object)(&obj3);
						object obj4 = default(object);
						object obj5;
						IEnumerable<JToken> value = default(IEnumerable<JToken>);
						object obj6 = default(object);
						while (true)
						{
							if (obj3 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
								if (obj4 != null)
								{
									bool flag2 = obj3 == null;
									IEnumerable<JToken> enumerable = null;
									if (!flag2)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804860B0");
										obj5 = Newtonsoft.Json.Linq.Extensions.Value<object>(value);
										if (obj5 != null)
										{
											if (((JObject)obj5).ContainsKey("level"))
											{
												JToken jToken = ((JObject)obj5).get_Item("level");
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAEBA0");
												if ((nint)obj6 == level)
												{
													break;
												}
											}
											continue;
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								if (obj2 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
								}
								return;
							}
							throw new NullReferenceException();
						}
						bool flag3 = obj2 == null;
						object obj7 = 0;
						if (!flag3)
						{
							obj7 = obj2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						nint num2 = (nint)obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v503 @ rdx_v17 (Il2CppClass<System.Object>)+238] (should have been resolved before IL gen)");
						object obj8 = default(object);
						if (obj8 == null)
						{
							return;
						}
						nint num3 = (nint)obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v505 @ r8_v18 (Il2CppClass<System.Object>)+208] (should have been resolved before IL gen)");
						IEnumerable<JToken> value2 = default(IEnumerable<JToken>);
						object obj9 = Newtonsoft.Json.Linq.Extensions.Value<object>(value2);
						if (obj9 == null)
						{
							return;
						}
						nint num4 = (nint)obj9;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v510 @ rdx_v21 (Il2CppClass<System.Object>)+238] (should have been resolved before IL gen)");
						object obj10 = default(object);
						if (obj10 == null)
						{
							return;
						}
						if (_currentJsonData != null && _currentJsonData.HasValues)
						{
							JObject currentJsonData = DataHelper.UpgradeJsonData(_currentJsonData, (JObject)obj9);
							_currentJsonData = currentJsonData;
						}
						else
						{
							_currentJsonData = (JObject)obj9;
						}
						if (_currentJsonData != null)
						{
							object currentCharacterData = _currentJsonData.ToObject<object>();
							_currentCharacterData = (CharacterData)currentCharacterData;
							if (level == 1)
							{
								if (_currentJsonData == null)
								{
									goto IL_03c7;
								}
								object levelZeroCharacterData = _currentJsonData.ToObject<object>();
								_levelZeroCharacterData = (CharacterData)levelZeroCharacterData;
							}
							object other = ((JToken)obj9).ToObject<object>();
							PlayerStatsUpgrade((ModifierStats)other);
							return;
						}
					}
				}
			}
		}
		goto IL_03c7;
		IL_03c7:
		throw new NullReferenceException();
	}

	public unsafe void ShowMultiplayerIndicator()
	{
		//IL_014f: Expected O, but got I
		//IL_0181: Expected O, but got I
		//IL_0236: Expected O, but got Ref
		//IL_01c2->IL030d: Incompatible stack heights: 9 vs 0
		//IL_025d->IL030d: Incompatible stack heights: 9 vs 0
		//IL_020d->IL030d: Incompatible stack heights: 9 vs 0
		//IL_028c->IL030d: Incompatible stack heights: 9 vs 0
		//IL_0467->IL030d: Incompatible stack heights: 10 vs 0
		//IL_023b->IL023b: Incompatible stack heights: 10 vs 9
		if (_multiplayerIndicatorTimer != null)
		{
			_multiplayerIndicatorTimer.Cancel();
			_multiplayerIndicatorTimer = null;
		}
		if ((object)_multiplayerIndicator != null)
		{
			Transform transform = _multiplayerIndicator.transform;
			if ((object)_CharacterRenderer != null)
			{
				Transform transform2 = _CharacterRenderer.transform;
				if ((object)transform2 != null)
				{
					bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					float ret;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)(&ret));
					bool flag2 = (object)transform == null;
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 ret2 = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref ret2);
					bool flag4 = (object)_multiplayerIndicator == null;
					GameObject gameObject = _multiplayerIndicator.gameObject;
					bool flag5 = (object)gameObject == null;
					gameObject.SetActive(value: true);
					Transform multiplayerIndicator = (Transform)(object)_multiplayerIndicator;
					Color coopColour = GetCoopColour();
					bool flag6 = (object)_multiplayerIndicator == null;
					bool flag7 = ((UnityEngine.Object)multiplayerIndicator).m_CachedPtr == (IntPtr)0;
					SpriteRenderer.set_color_Injected(((UnityEngine.Object)multiplayerIndicator).m_CachedPtr, ref *(Color*)(&ret));
					Transform gameManager = (Transform)(object)_gameManager;
					bool flag8 = (object)_gameManager == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1027 @ rbx_v15 (UnityEngine.Transform)+168]");
					bool flag9 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1027 @ rbx_v15 (UnityEngine.Transform)+168]");
					int playerCount = ((MultiplayerManager)0).GetPlayerCount();
					if (playerCount <= 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1027 @ rbx_v15 (UnityEngine.Transform)+168]");
						if (!((MultiplayerManager)0).IsOnlineMultiplayer)
						{
							return;
						}
					}
					CharacterData currentCharacterData = _currentCharacterData;
					if (_currentCharacterData != null)
					{
						if (!currentCharacterData._003CallowCoopOutline_003Ek__BackingField)
						{
							goto IL_023b;
						}
						Transform multiplayerIndicator2 = (Transform)(object)_multiplayerIndicator;
						if ((object)_multiplayerIndicator != null)
						{
							bool flag10 = ((UnityEngine.Object)multiplayerIndicator2).m_CachedPtr == (IntPtr)0;
							SpriteRenderer.get_color_Injected(((UnityEngine.Object)multiplayerIndicator2).m_CachedPtr, out *(Color*)(&ret2));
							if ((object)_multiplayerOutliner != null)
							{
								_multiplayerOutliner.ShowOutline(_outlineReferenceRenderer, (Color)(&ret2));
								goto IL_023b;
							}
						}
					}
				}
			}
		}
		goto IL_030d;
		IL_030d:
		throw new NullReferenceException();
		IL_023b:
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			CoopConfig coopConfig = core.CoopConfig;
			if ((object)core.CoopConfig != null)
			{
				Action onComplete = delegate
				{
					GameObject gameObject2 = _multiplayerIndicator.gameObject;
					gameObject2.SetActive(value: false);
					PlayerOptionsData config = _playerOptions.Config;
					if (!config._003CPermanentCoopOutlines_003Ek__BackingField || _PlayerIndex < 0)
					{
						GameObject gameObject3 = _multiplayerOutliner.gameObject;
						gameObject3.SetActive(value: false);
					}
				};
				float num = coopConfig._multiplayerIndicatorDuration * 1000f;
				float duration = num * 0.001f;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer multiplayerIndicatorTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_multiplayerIndicatorTimer = multiplayerIndicatorTimer;
				return;
			}
		}
		goto IL_030d;
	}

	protected unsafe void SetCustomOutlineReferenceRenderer(SpriteRenderer referenceRenderer)
	{
		//IL_00d2: Expected O, but got Ref
		GameManager core = GM.Core;
		int playerCount = core._multiplayer.GetPlayerCount();
		if (playerCount > 1 || core._multiplayer.IsOnlineMultiplayer)
		{
			_outlineReferenceRenderer = referenceRenderer;
			CharacterData currentCharacterData = _currentCharacterData;
			_usingCustomRendererForOutline = true;
			if (currentCharacterData._003CallowCoopOutline_003Ek__BackingField)
			{
				Color coopColour = GetCoopColour();
				object obj = default(object);
				_multiplayerOutliner.ShowOutline(referenceRenderer, (Color)(&obj), _usingCustomRendererForOutline);
			}
		}
	}

	protected void SetOutlineOffsetNegative()
	{
		SpriteOutlinerControl multiplayerOutliner = _multiplayerOutliner;
		multiplayerOutliner._outlineOffsetNegative = true;
	}

	protected virtual void SetCharacterSprite()
	{
		CharacterData currentCharacterData = _currentCharacterData;
		List<Skin> list = currentCharacterData._003Cskins_003Ek__BackingField;
		if (currentCharacterData._003Cskins_003Ek__BackingField != null && list._size > 0)
		{
			if (_coherenceSync.HasStateAuthority)
			{
				SkinType skinTypeForCharacter = _playerOptions.GetSkinTypeForCharacter(_characterType);
				_skinType = skinTypeForCharacter;
			}
			CharacterData characterData = SetSkin(_skinType, currentCharacterData);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 113 Invalid \"Jump target not found in method: 0x187594BF0\"");
		throw new NullReferenceException();
	}

	private unsafe void SetSpriteForSkin(CharacterData skinData)
	{
		//IL_009c: Expected I, but got O
		//IL_0106: Expected I, but got O
		//IL_0170: Expected I, but got O
		//IL_0228: Expected O, but got Ref
		//IL_01d6: Expected I, but got O
		_currentSkinData = skinData;
		CharacterData currentSkinData = _currentSkinData;
		Vector2 newPivot = default(Vector2);
		Sprite sprite = SpriteManager.GetSprite(currentSkinData._003CspriteName_003Ek__BackingField, newPivot, currentSkinData._003CtextureName_003Ek__BackingField);
		_CharacterRenderer.sprite = sprite;
		object[] array = new object[4];
		CharacterType characterType = default(CharacterType);
		object obj = characterType;
		if (obj != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		CharacterData currentSkinData2 = _currentSkinData;
		if (currentSkinData2._003CspriteName_003Ek__BackingField != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		CharacterData currentSkinData3 = _currentSkinData;
		if (currentSkinData3._003CtextureName_003Ek__BackingField != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Sprite sprite2 = _CharacterRenderer.sprite;
		if ((object)sprite2 != null)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object obj5 = default(object);
		if (obj5 != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		System.ParamsArray paramsArray = new System.ParamsArray(array);
		object obj7 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Setting character {0} sprite to {1} from texture {2}. Found Sprite?: {3}", (System.ParamsArray)(&obj7));
		Debug.Log(message);
	}

	private CharacterData SetSkin(SkinType skinType, CharacterData skinData)
	{
		//IL_01f7: Expected O, but got I4
		_003C_003Ec__DisplayClass604_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass604_0();
		CharacterData result;
		if (CS_0024_003C_003E8__locals5 != null)
		{
			CS_0024_003C_003E8__locals5.skinType = skinType;
			CharacterData currentCharacterData = _currentCharacterData;
			if (_currentCharacterData != null)
			{
				Predicate<Skin> match = delegate(Skin x)
				{
					//IL_0053: Expected I4, but got O
					//IL_0031: Expected O, but got I4
					if (x == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					object obj = x.skinType - CS_0024_003C_003E8__locals5.skinType;
					return obj == null;
				};
				if (currentCharacterData._003Cskins_003Ek__BackingField != null)
				{
					Skin skin = currentCharacterData._003Cskins_003Ek__BackingField.Find(match);
					bool flag = skin == null;
					result = skinData;
					if (flag)
					{
						goto IL_01e4;
					}
					CharacterData currentCharacterData2 = _currentCharacterData;
					if (_currentCharacterData != null)
					{
						Func<Skin, bool> predicate = delegate(Skin x)
						{
							//IL_0053: Expected I4, but got O
							//IL_0031: Expected O, but got I4
							if (x == null)
							{
								NullReferenceException ex = new NullReferenceException();
								return (byte)(int)ex != 0;
							}
							object obj = x.skinType - CS_0024_003C_003E8__locals5.skinType;
							return obj == null;
						};
						Skin value = Enumerable.First(currentCharacterData2._003Cskins_003Ek__BackingField, predicate);
						JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
						if (jsonSerializerSettings != null)
						{
							jsonSerializerSettings._referenceLoopHandling = (ReferenceLoopHandling?)(object)1;
							JsonSerializer jsonSerializer = JsonSerializer.CreateDefault();
							JsonSerializer.ApplySerializerSettings(jsonSerializer, jsonSerializerSettings);
							string value2 = JsonConvert.SerializeObjectInternal((object)value, (Type)null, jsonSerializer);
							CharacterData characterData = JsonConvert.DeserializeObject<CharacterData>(value2);
							CharacterData currentCharacterData3 = _currentCharacterData;
							if (_currentCharacterData != null)
							{
								currentCharacterData3._003CcurrentSkin_003Ek__BackingField = CS_0024_003C_003E8__locals5.skinType;
								result = characterData;
								goto IL_01e4;
							}
						}
					}
				}
			}
		}
		return (CharacterData)(object)new NullReferenceException();
		IL_01e4:
		return result;
	}

	protected virtual void SetupAnimation()
	{
		//IL_0100: Expected O, but got I4
		//IL_0100: Expected I4, but got O
		//IL_00c5: Expected I4, but got O
		CharacterData currentSkinData = _currentSkinData;
		if (_currentSkinData != null)
		{
			if (currentSkinData._003CwalkingFrames_003Ek__BackingField > 0)
			{
				_hasWalkingAnimation = true;
				string animName = currentSkinData._003CspriteName_003Ek__BackingField.Replace("01.png", "");
				bool respectAnimationXPivots = RespectAnimationXPivots;
				Vector2 pivot = default(Vector2);
				string text = default(string);
				int num = default(int);
				bool flag = default(bool);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, currentSkinData._003CwalkingFrames_003Ek__BackingField, pivot, text, num, flag);
				int fps = (((object)currentSkinData._003CwalkFrameRate_003Ek__BackingField == null) ? 8 : ((object?)currentSkinData._003CwalkFrameRate_003Ek__BackingField >> 32));
				bool autoSetAnimation = default(bool);
				_spriteAnimation.AddAnimation("walk", animationFrames, fps, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
				_spriteAnimation.SetAnimation("walk");
				_currentAnimation = CharAnimationType.walk;
				CurrentWalkAnimName = "walk";
				OnStop();
			}
		}
		else
		{
			Debug.LogError("Uh oh, skin data is invalid");
		}
	}

	public unsafe Color GetCoopColour()
	{
		//IL_01d2: Expected I, but got O
		//IL_01b1: Expected F4, but got I
		//IL_0225: Expected native int or pointer, but got O
		//IL_0133: Expected I, but got O
		nint num = (nint)typeof(MultiplayerManager);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (Il2CppClass<VampireSurvivors.Framework.MultiplayerManager>)+B8]");
		nint num2 = 0;
		float r;
		if (MultiplayerManager.s_instance != null)
		{
			int playerCount = MultiplayerManager.s_instance.GetPlayerCount();
			if ((playerCount <= 1 && !MultiplayerManager.s_instance.IsOnlineMultiplayer) || _PlayerIndex < 0)
			{
				goto IL_01a1;
			}
			GameManager gameManager = _gameManager;
			if ((object)_gameManager != null)
			{
				MultiplayerManager multiplayer = gameManager._multiplayer;
				if (gameManager._multiplayer != null)
				{
					int num3;
					if (gameManager._multiplayer.IsOnlineMultiplayer)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
						OnlineStageManager onlineStageManager = default(OnlineStageManager);
						if ((object)onlineStageManager == null)
						{
							goto IL_01b6;
						}
						int seatNumberForCharacter = onlineStageManager.GetSeatNumberForCharacter(this);
						num2 = unchecked((nint)null);
						multiplayer = (MultiplayerManager)(object)onlineStageManager;
						num3 = seatNumberForCharacter;
					}
					else
					{
						num3 = _PlayerIndex;
					}
					if (num3 == -1)
					{
						goto IL_01a1;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18695F8A0");
					MultiplayerManager multiplayerManager = default(MultiplayerManager);
					if (multiplayerManager != null)
					{
						r = multiplayerManager.GetSlotColor(num3).r;
						goto IL_021d;
					}
				}
			}
		}
		goto IL_01b6;
		IL_021d:
		Color color = default(Color);
		((Color*)(nint)color)->r = r;
		return color;
		IL_01b6:
		return (Color)new NullReferenceException();
		IL_01a1:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		r = 0f;
		goto IL_021d;
	}

	protected virtual void InternalUpdate()
	{
		//IL_0142: Invalid comparison between I4 and F4
		//IL_03c1: Invalid comparison between F4 and I4
		//IL_03d2: Invalid comparison between F4 and I4
		//IL_0432: Invalid comparison between I4 and F4
		//IL_0454: Invalid comparison between F4 and I4
		//IL_0465: Invalid comparison between F4 and I4
		//IL_0086: Invalid comparison between F4 and I4
		//IL_02d0: Expected F4, but got I4
		//IL_02d9: Expected F4, but got I4
		//IL_04ff: Invalid comparison between F4 and I4
		//IL_02f8: Invalid comparison between F4 and I4
		if (_isDead)
		{
			return;
		}
		bool isDisconnectedFromOnlinePlay = IsDisconnectedFromOnlinePlay;
		if (isDisconnectedFromOnlinePlay || _isInitialized == isDisconnectedFromOnlinePlay)
		{
			return;
		}
		PhaserSprite barrierSprite = BarrierSprite;
		if ((object)BarrierSprite != null && ((UnityEngine.Object)barrierSprite).m_CachedPtr != (IntPtr)0)
		{
			if (!(Barrier_Number > 0f))
			{
				PhaserSprite phaserSprite = BarrierSprite.setVisible(visible: false);
			}
			else
			{
				PhaserSprite phaserSprite2 = BarrierSprite.setVisible(visible: true);
				int num = base.depth;
				int num2 = num + 1;
				PhaserSprite phaserSprite3 = BarrierSprite.setDepth(num2);
				float2 float5 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			}
		}
		float deltaTime = PauseSystem.DeltaTime;
		if (0f > (_invincibilityTimer -= deltaTime))
		{
			_invincibilityTimer = 0f;
		}
		bool flag = _invincibilityTimer < 0f;
		bool flag2 = _invincibilityTimer == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool isInvul = flag4 & flag3;
		IsInvul = isInvul;
		float deltaTime2 = PauseSystem.DeltaTime;
		if (0f > (_slowTime -= deltaTime2))
		{
			_slowTime = 0f;
		}
		bool flag5 = _slowTime < 0f;
		bool flag6 = _slowTime == 0f;
		bool flag7 = !flag5;
		bool flag8 = !flag6;
		float slowMultiplier = ((!(_isSlow = flag8 & flag7)) ? 1f : 0.5f);
		_slowMultiplier = slowMultiplier;
		int forcedSortingOrder = default(int);
		if (_hasForcedSortingOrder)
		{
			forcedSortingOrder = _forcedSortingOrder;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		}
		_CharacterRenderer.sortingOrder = forcedSortingOrder;
		_spriteTrail.UpdateDepth();
		if (_canFlip)
		{
			if (_coherenceSync.HasStateAuthority)
			{
				if (0 > (nint)_currentDirection)
				{
					_isFlipped = true;
				}
				else if ((nint)_currentDirection > 0)
				{
					_isFlipped = false;
				}
			}
			_CharacterRenderer.flipX = _isFlipped;
		}
		PlayWalkingAnimations();
		CharacterSkillCardsManager characterSkillCardsManager = CharacterSkillCardsManager;
		if (CharacterSkillCardsManager == null)
		{
			return;
		}
		List<CharacterSkillCard_Base> characterCards = characterSkillCardsManager._characterCards;
		float num3 = 0f;
		float num4 = 0f;
		List<CharacterSkillCard_Base> characterCards2 = characterSkillCardsManager._characterCards;
		while (true)
		{
			if (num4 < (float)characterCards._size)
			{
				if (!(num3 < (float)characterCards2._size))
				{
					break;
				}
				CharacterSkillCard_Base[] items = characterCards2._items;
				items[num3].Update();
				characterCards2 = characterSkillCardsManager._characterCards;
				num3++;
				num4 = num3;
				characterCards = characterSkillCardsManager._characterCards;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public void SetSortgingOrder(bool value, int order = 0)
	{
		_hasForcedSortingOrder = value;
		_forcedSortingOrder = order;
	}

	public virtual void PlayWalkingAnimations()
	{
		//IL_0198: Expected I, but got O
		//IL_01d5: Expected O, but got I
		//IL_0205: Invalid comparison between F4 and O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5AFE]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		object obj = _currentDirection - Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.CharacterController)+174]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		object obj2 = num3 - 0;
		object obj3 = obj2 * obj2;
		object obj4 = obj * obj;
		object obj5 = obj3 + obj4;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
		{
			if (!_hasWalkingAnimation)
			{
				if (_wiggleTween != null)
				{
					MultiTargetTween wiggleTween = _wiggleTween;
					if (wiggleTween._isPaused)
					{
						wiggleTween.Play();
					}
				}
			}
			else if (!_hasIdleAnimation)
			{
				SpriteAnimation spriteAnimation = _spriteAnimation;
				((BaseSpriteAnimation)spriteAnimation)._003CIsPaused_003Ek__BackingField = false;
			}
			else if (!_isAnimForced && _currentAnimation != CharAnimationType.walk)
			{
				_isAnimForced = false;
				_spriteAnimation.SetAnimation("walk");
				_currentAnimation = CharAnimationType.walk;
			}
		}
		else if (!_isAnimForced)
		{
			OnStop();
		}
	}

	private void SetHealthToMax()
	{
		float num = MaxHp();
		float currentHp = default(float);
		_currentHp = currentHp;
	}

	public unsafe virtual void OnDeath()
	{
		//IL_012e: Expected F4, but got I
		//IL_0a64: Expected I, but got O
		//IL_0189: Expected O, but got I
		//IL_0589: Expected O, but got Ref
		//IL_03a3: Expected F4, but got I4
		//IL_0a2a: Expected O, but got I
		//IL_0aa2: Expected I, but got O
		//IL_05f7: Expected O, but got I
		//IL_0a88->IL08d6: Incompatible stack heights: 1 vs 0
		//IL_03cb->IL08d6: Incompatible stack heights: 1 vs 0
		//IL_01cd->IL08d6: Incompatible stack heights: 1 vs 0
		//IL_0468->IL08d6: Incompatible stack heights: 1 vs 0
		//IL_0497->IL08d6: Incompatible stack heights: 1 vs 0
		//IL_0951->IL08d6: Incompatible stack heights: 1 vs 0
		//IL_04c5->IL08d6: Incompatible stack heights: 1 vs 0
		//IL_02c3->IL08d6: Incompatible stack heights: 1 vs 0
		//IL_098d->IL08d6: Incompatible stack heights: 1 vs 0
		//IL_054f->IL08d6: Incompatible stack heights: 1 vs 0
		//IL_096e->IL08d6: Incompatible stack heights: 1 vs 0
		//IL_09d0->IL08d6: Incompatible stack heights: 1 vs 0
		//IL_05b2->IL08d6: Incompatible stack heights: 1 vs 0
		//IL_0822->IL08d6: Incompatible stack heights: 1 vs 0
		//IL_09ed->IL08d6: Incompatible stack heights: 1 vs 0
		//IL_0ab8->IL0973: Incompatible stack heights: 2 vs 1
		//IL_0859->IL0ad5: Incompatible stack heights: 2 vs 1
		//IL_0ad0->IL08d6: Incompatible stack heights: 1 vs 0
		if (_wiggleTween != null)
		{
			_wiggleTween.Pause();
		}
		if (_regenTimer != null)
		{
			_regenTimer.Cancel();
		}
		if (_blinkTimeoutTimer != null)
		{
			_blinkTimeoutTimer.Cancel();
		}
		SpriteRenderer customDamageOverlayRenderer = _customDamageOverlayRenderer;
		_receivingDamage = false;
		Renderer renderer = (((object)_customDamageOverlayRenderer == null || ((UnityEngine.Object)customDamageOverlayRenderer).m_CachedPtr == (IntPtr)0) ? _CharacterRenderer : _customDamageOverlayRenderer);
		if ((object)renderer != null)
		{
			renderer.Internal_GetPropertyBlock(_propBlock);
			object propBlock = _propBlock;
			if (_propBlock != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
				float num = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rsi_v8 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rsi_v8 (System.Object)+10]");
					float value = default(float);
					MaterialPropertyBlock.SetColorImpl_Injected((IntPtr)0, RenderingExtensions.TintFillColor, ref *(Color*)(&value));
					RenderingExtensions.SetTintFillEnabled(_propBlock, isEnabled: true);
					MaterialPropertyBlock propBlock2 = _propBlock;
					bool flag = ((UnityEngine.Object)renderer).m_CachedPtr == (IntPtr)0;
					bool flag2 = _propBlock == null;
					Renderer renderer2 = null;
					if (!flag2)
					{
						renderer2 = (Renderer)(nint)propBlock2.m_Ptr;
					}
					Renderer.Internal_SetPropertyBlock_Injected(((UnityEngine.Object)renderer).m_CachedPtr, (IntPtr)renderer2);
					CharacterData currentCharacterData = _currentCharacterData;
					if (_currentCharacterData != null)
					{
						if (!currentCharacterData._003CnoHurt_003Ek__BackingField)
						{
							if ((object)_CharacterRenderer != null)
							{
								Transform target = _CharacterRenderer.transform;
								TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleX(target, 2f, 1f);
								bool flag3 = tweenerCore == null;
								bool flag4 = false;
								if (!flag3)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1144 @ rax_v117 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
									bool flag5 = (nint)0 == 0;
									flag4 = false;
									if (!flag5)
									{
										_ = 30;
										_ = 0;
										flag4 = false;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								if (tweenerCore != null && (object)_CharacterRenderer != null)
								{
									Transform target2 = _CharacterRenderer.transform;
									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScaleY(target2, 0f, 1f);
									bool flag6 = tweenerCore2 == null;
									bool flag7 = false;
									if (!flag6)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1387 @ rax_v123 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
										bool flag8 = (nint)0 == 0;
										flag7 = false;
										if (!flag8)
										{
											_ = 1;
											_ = 0;
											flag7 = false;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									if (tweenerCore2 != null)
									{
										float num2 = 0f;
										float num3 = 1f;
										goto IL_0802;
									}
								}
							}
						}
						else if ((object)_CharacterRenderer != null)
						{
							Transform target3 = _CharacterRenderer.transform;
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(target3, 0f, 1f);
							if (tweenerCore3 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1146 @ rax_v62 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
								if ((nint)0 != 0)
								{
									_ = 30;
									_ = 0;
								}
							}
							if ((object)_DeathNoHurtRenderer != null)
							{
								_DeathNoHurtRenderer.enabled = true;
								if ((object)_CharacterRenderer != null)
								{
									Sprite sprite = _CharacterRenderer.sprite;
									if ((object)_DeathNoHurtRenderer != null)
									{
										_DeathNoHurtRenderer.sprite = sprite;
										bool flag9 = ColorUtility.DoTryParseHtmlColor("#ddddff", out Color32 _);
										num = 0f / 255f;
										float num4 = 0f / 255f;
										bool flag10 = !flag9;
										bool flag4 = flag9;
										if (flag10)
										{
											goto IL_0973;
										}
										if ((object)_DeathNoHurtRenderer != null)
										{
											((Renderer)_DeathNoHurtRenderer).Internal_GetPropertyBlock(_propBlock);
											RenderingExtensions.SetTintFillEnabled(_propBlock, isEnabled: true);
											RenderingExtensions.SetTintFillColor(_propBlock, (Color)(&value));
											object deathNoHurtRenderer = _DeathNoHurtRenderer;
											if ((object)_DeathNoHurtRenderer != null)
											{
												MaterialPropertyBlock propBlock3 = _propBlock;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rsi_v23 (System.Object)+10]");
												bool flag11 = (nint)0 == 0;
												bool flag12 = _propBlock == null;
												SpriteRenderer spriteRenderer = null;
												if (!flag12)
												{
													spriteRenderer = (SpriteRenderer)(nint)propBlock3.m_Ptr;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rsi_v23 (System.Object)+10]");
												Renderer.Internal_SetPropertyBlock_Injected((IntPtr)0, (IntPtr)spriteRenderer);
												num = num4;
												flag4 = false;
												goto IL_0973;
											}
										}
									}
								}
							}
						}
					}
				}
				else
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_propBlock);
				}
			}
		}
		goto IL_08d6;
		IL_0802:
		PlayDamageParticleFX();
		if ((object)_damageVfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB20]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB20]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag13 = obj == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1749 @ rax_v48 (should have been resolved before IL gen)");
			Action onComplete = delegate
			{
				_damageVfx.Stop();
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.25f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			ScheduleDeathConsequences();
			return;
		}
		goto IL_08d6;
		IL_08d6:
		throw new NullReferenceException();
		IL_0973:
		if ((object)_DeathNoHurtRenderer != null)
		{
			Transform target4 = _DeathNoHurtRenderer.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOScale(target4, 0f, 1.5000001f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (tweenerCore4 != null)
			{
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = ShortcutExtensions.DOLocalMoveY(target4, 0.96f, 1.5000001f);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (tweenerCore5 != null)
				{
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore6 = ShortcutExtensions.DOLocalMoveX(target4, 0.24f, 0.25f);
					if (tweenerCore6 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1919 @ rax_v77 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 != 0)
						{
							_ = 4;
							_ = 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1919 @ rax_v77 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1919 @ rax_v77 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
							if ((nint)0 == 0)
							{
								_ = 3;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1919 @ rax_v77 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1919 @ rax_v77 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
									float num = 0f * 3f;
								}
							}
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if (tweenerCore6 != null)
					{
						float num2 = 0.24f;
						bool flag7 = false;
						float num3 = 0.25f;
						goto IL_0802;
					}
				}
			}
		}
		goto IL_08d6;
	}

	protected unsafe virtual void ScheduleDeathConsequences()
	{
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_03f9: Expected O, but got I4
		//IL_0413: Expected O, but got I4
		GameManager gameManager = _gameManager;
		int playerCount = gameManager._multiplayer.GetPlayerCount();
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (playerCount <= 1 && !gameManager._multiplayer.IsOnlineMultiplayer && _PlayerIndex >= 0)
		{
			Action onComplete = delegate
			{
				if (!_isInFinalStage)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1B20");
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1A70");
				}
			};
			Timer timer = Timers.Register(1.25f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			return;
		}
		GameManager core = GM.Core;
		CoopConfig coopConfig = core.CoopConfig;
		if (coopConfig._immediateRevivalUsage)
		{
			EggDouble eggDouble = PRevivals();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [rax+10h]\"");
			object obj = eggDouble._eggVal & 0x7FFFFFFFFFFFFFFFL;
			if ((long)obj != 9218868437227405312L)
			{
				object obj2 = eggDouble._eggVal & 0x7FFFFFFFFFFFFFFFL;
				bool flag = (long)obj2 == 9218868437227405312L;
				if ((long)obj2 <= 9218868437227405312L)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [188A11860h]\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187596A17h\"");
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,qword ptr [188A10758h]\"");
						if ((long)obj2 >= 9218868437227405312L)
						{
							goto IL_01ec;
						}
					}
					goto IL_0292;
				}
			}
			goto IL_01ec;
		}
		goto IL_0292;
		IL_0292:
		GameManager gameManager2 = _gameManager;
		GameSessionData gameSessionData = gameManager2._gameSessionData;
		bool flag2 = (object)gameSessionData._activeCharacter == null;
		bool flag3 = (object)this == null;
		object obj3 = flag3 & flag2;
		bool flag4 = obj3 == null;
		object obj4 = !flag4;
		if (obj4 == null)
		{
			bool flag5;
			if ((object)gameSessionData._activeCharacter != null)
			{
				object obj5 = (object)gameSessionData._activeCharacter - (object)this;
				flag5 = obj5 == null;
			}
			else
			{
				flag5 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			}
			if (!flag5)
			{
				goto IL_0332;
			}
		}
		_gameManager.CycleActivePlayer();
		goto IL_0332;
		IL_0332:
		if (_deathConsequenceTimer != null)
		{
			_deathConsequenceTimer.Cancel();
		}
		Action onComplete2 = delegate
		{
			//IL_0482: Expected I4, but got O
			//IL_04a7: Expected O, but got Ref
			//IL_042e: Expected I4, but got O
			//IL_0453: Expected O, but got Ref
			//IL_051e: Expected I4, but got O
			//IL_00be: Invalid comparison between I4 and F4
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Expected O, but got Unknown
			//IL_0352: Expected O, but got I
			//IL_0367: Expected O, but got I
			//IL_037c: Expected O, but got I
			//IL_0391: Expected O, but got I
			if (_multiplayerRevivalAllowed)
			{
				_multiplayerRevivalUI.ToggleVisible(visible: true);
				GameManager core2 = GM.Core;
				CoopConfig coopConfig2 = core2.CoopConfig;
				Action onComplete4 = TurnIntoMultiplayerGhost;
				bool useRealTime2 = default(bool);
				MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
				int repeat2 = default(int);
				TimerType type2 = default(TimerType);
				Timer multiplayerDecompositionTimer = Timers.Register(coopConfig2._decompositionTimeSeconds, onComplete4, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
				_multiplayerDecompositionTimer = multiplayerDecompositionTimer;
				GameManager core3 = GM.Core;
				CoopConfig coopConfig3 = core3.CoopConfig;
				if (0f > coopConfig3._revivalLossSpeed)
				{
					GameManager core4 = GM.Core;
					CoopConfig coopConfig4 = core4.CoopConfig;
					float revivalLossSpeed = coopConfig4._revivalLossSpeed;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
					object obj6 = revivalLossSpeed ^ 0;
					float num = 1f / (float)obj6;
					Action onComplete5 = delegate
					{
						_multiplayerRevivalUI.DoShake(1f);
					};
					float duration = num - 2f;
					Timer multiplayerReviveShake = Timers.Register(duration, onComplete5, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
					_multiplayerReviveShake1 = multiplayerReviveShake;
					Action onComplete6 = delegate
					{
						_multiplayerRevivalUI.DoShake(2f);
					};
					float duration2 = num - 1f;
					Timer multiplayerReviveShake2 = Timers.Register(duration2, onComplete6, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
					_multiplayerReviveShake2 = multiplayerReviveShake2;
				}
			}
			GameManager core5 = GM.Core;
			CoopConfig coopConfig5 = core5.CoopConfig;
			if (_gameManager.GetAlivePlayerCount(coopConfig5._immediateRevivalUsage, includeOnlyMainCharacters: true) != 0)
			{
				GameManager core6 = GM.Core;
				CoopConfig coopConfig6 = core6.CoopConfig;
				if (coopConfig6._removeDeadPlayersFromCamera)
				{
					ProCamera2D instance = ProCamera2D.Instance;
					Transform cameraTarget = CameraTarget;
					GameManager core7 = GM.Core;
					CoopConfig coopConfig7 = core7.CoopConfig;
					instance.RemoveCameraTarget(cameraTarget, coopConfig7._removeDeadPlayerFromCameraDuration);
				}
			}
			else
			{
				bool flag6 = !_multiplayerRevivalAllowed;
				bool flag7 = true;
				if (!flag6)
				{
					GameManager gameManager3 = _gameManager;
					flag7 = (byte)(int)gameManager3._characters != 0;
					bool flag8 = false;
					bool flag9 = false;
					while (true)
					{
						bool num2 = flag9;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v709 @ r8_v4 (System.Boolean)+18]");
						if ((nint)(num2 ? 1 : 0) >= (nint)0)
						{
							break;
						}
						bool num3 = flag8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v709 @ r8_v4 (System.Boolean)+18]");
						if ((nint)(num3 ? 1 : 0) >= (nint)0)
						{
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v709 @ r8_v4 (System.Boolean)+10]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v21+20+v175 @ rdi_v4 (System.Boolean)*8]");
						object obj8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rcx_v22+218]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rcx_v23+A0]");
						object obj10 = 0;
						if (0L <= 9218868437227405312L)
						{
							flag9 = (byte)((flag8 ? 1u : 0u) + 1u) != 0;
							_ = 0;
							flag8 = flag9;
						}
						else
						{
							flag9 = (byte)((flag8 ? 1u : 0u) + 1u) != 0;
							_ = 1.7976931348623157E+308;
							flag8 = flag9;
						}
					}
				}
				object obj11 = default(object);
				object obj12 = default(object);
				if (!_isInFinalStage)
				{
					object arg = (CharacterType)obj11;
					System.ParamsArray paramsArray = new System.ParamsArray(arg);
					string message = string.FormatHelper((IFormatProvider)null, "<color=green>Player {0} Died. Sending CharacterDiedSignal</color>", (System.ParamsArray)(&obj12));
					Debug.Log(message);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1B20");
				}
				else
				{
					object arg2 = (CharacterType)obj11;
					System.ParamsArray paramsArray = new System.ParamsArray(arg2);
					string message2 = string.FormatHelper((IFormatProvider)null, "<color=green>Player {0} Died. Sending ShowGameOverinoSceneSignal</color>", (System.ParamsArray)(&obj12));
					Debug.Log(message2);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1A70");
				}
			}
		};
		Timer deathConsequenceTimer = Timers.Register(1.25f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_deathConsequenceTimer = deathConsequenceTimer;
		return;
		IL_01ec:
		if (_multiplayerRevivalAllowed)
		{
			if (_deathConsequenceTimer != null)
			{
				_deathConsequenceTimer.Cancel();
			}
			Action onComplete3 = delegate
			{
				DoOnlineOrLocalRevival(instantRevival: true);
			};
			Timer deathConsequenceTimer2 = Timers.Register(1.25f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_deathConsequenceTimer = deathConsequenceTimer2;
			return;
		}
		goto IL_0292;
	}

	public virtual void Despawn()
	{
	}

	public void GiveReward(Action<Pickup> onRewardGiven = null)
	{
	}

	protected void StopParticleFX()
	{
		_damageVfx.Stop();
	}

	protected void PlayDamageParticleFX()
	{
		//IL_009b: Expected O, but got I
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CDisableBlood_003Ek__BackingField)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB20]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BB20]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v260 @ rax_v12 (should have been resolved before IL gen)");
		RenderingExtensions.Start(_damageVfx);
	}

	public virtual bool ShouldCollideWithWalls()
	{
		return true;
	}

	private void EditorLogPlayerStats()
	{
	}

	public List<Vector2> GetHeadOffsets()
	{
		//IL_0079: Expected O, but got I
		//IL_008e: Expected O, but got I
		CharacterData characterData = _currentCharacterData;
		if (_currentCharacterData == null)
		{
			GameManager core = GM.Core;
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core._dataManager.GetConvertedCharacterData();
			object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)1);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v15 (System.Object)+18]");
			if ((nint)0 <= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				List<Vector2> result = default(List<Vector2>);
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rax_v15 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rcx_v11+20]");
			characterData = (CharacterData)0;
		}
		if (characterData._003Cskins_003Ek__BackingField == null)
		{
			return characterData._003CheadOffsets_003Ek__BackingField;
		}
		Skin currentSkinData = characterData.GetCurrentSkinData();
		return currentSkinData._003CheadOffsets_003Ek__BackingField;
	}

	public void ApplySkinModifiers()
	{
		//IL_08b6: Expected I4, but got O
		if (_currentCharacterData == null)
		{
			return;
		}
		Skin currentSkinData = _currentCharacterData.GetCurrentSkinData();
		if (currentSkinData != null)
		{
			PlayerModifierStats playerStats = _playerStats;
			EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = (float)currentSkinData._003Cpower_003Ek__BackingField + eggFloat._val;
			playerStats._003CPower_003Ek__BackingField = eggFloat2;
			PlayerModifierStats playerStats2 = _playerStats;
			EggFloat eggFloat3 = playerStats2._003CRegen_003Ek__BackingField;
			float value2 = default(float);
			EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
			value2 = eggFloat3._val + currentSkinData._003Cregen_003Ek__BackingField;
			playerStats2._003CRegen_003Ek__BackingField = eggFloat4;
			PlayerModifierStats playerStats3 = _playerStats;
			EggFloat eggFloat5 = playerStats3._003CMaxHp_003Ek__BackingField;
			float value3 = default(float);
			EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
			value3 = eggFloat5._val + currentSkinData._003CmaxHp_003Ek__BackingField;
			playerStats3._003CMaxHp_003Ek__BackingField = eggFloat6;
			PlayerModifierStats playerStats4 = _playerStats;
			EggFloat eggFloat7 = playerStats4._003CArmor_003Ek__BackingField;
			float value4 = default(float);
			EggFloat eggFloat8 = new EggFloat(value4, eggFloat7._eggVal);
			value4 = eggFloat7._val + currentSkinData._003Carmor_003Ek__BackingField;
			playerStats4._003CArmor_003Ek__BackingField = eggFloat8;
			PlayerModifierStats playerStats5 = _playerStats;
			EggFloat eggFloat9 = playerStats5._003CArea_003Ek__BackingField;
			float value5 = default(float);
			EggFloat eggFloat10 = new EggFloat(value5, eggFloat9._eggVal);
			value5 = eggFloat9._val + currentSkinData._003Carea_003Ek__BackingField;
			playerStats5._003CArea_003Ek__BackingField = eggFloat10;
			PlayerModifierStats playerStats6 = _playerStats;
			EggFloat eggFloat11 = playerStats6._003CSpeed_003Ek__BackingField;
			float value6 = default(float);
			EggFloat eggFloat12 = new EggFloat(value6, eggFloat11._eggVal);
			value6 = eggFloat11._val + currentSkinData._003Cspeed_003Ek__BackingField;
			playerStats6._003CSpeed_003Ek__BackingField = eggFloat12;
			PlayerModifierStats playerStats7 = _playerStats;
			EggFloat eggFloat13 = playerStats7._003CCooldown_003Ek__BackingField;
			float value7 = default(float);
			EggFloat eggFloat14 = new EggFloat(value7, eggFloat13._eggVal);
			value7 = eggFloat13._val + currentSkinData._003Ccooldown_003Ek__BackingField;
			playerStats7._003CCooldown_003Ek__BackingField = eggFloat14;
			PlayerModifierStats playerStats8 = _playerStats;
			EggFloat eggFloat15 = playerStats8._003CDuration_003Ek__BackingField;
			float value8 = default(float);
			EggFloat eggFloat16 = new EggFloat(value8, eggFloat15._eggVal);
			value8 = eggFloat15._val + currentSkinData._003Cduration_003Ek__BackingField;
			playerStats8._003CDuration_003Ek__BackingField = eggFloat16;
			PlayerModifierStats playerStats9 = _playerStats;
			EggFloat eggFloat17 = playerStats9._003CAmount_003Ek__BackingField;
			float value9 = default(float);
			EggFloat eggFloat18 = new EggFloat(value9, eggFloat17._eggVal);
			value9 = eggFloat17._val + currentSkinData._003Camount_003Ek__BackingField;
			playerStats9._003CAmount_003Ek__BackingField = eggFloat18;
			PlayerModifierStats playerStats10 = _playerStats;
			EggFloat eggFloat19 = playerStats10._003CMoveSpeed_003Ek__BackingField;
			float value10 = default(float);
			EggFloat eggFloat20 = new EggFloat(value10, eggFloat19._eggVal);
			value10 = eggFloat19._val + currentSkinData._003CmoveSpeed_003Ek__BackingField;
			playerStats10._003CMoveSpeed_003Ek__BackingField = eggFloat20;
			MagnetZone magnet = _magnet;
			EggFloat radius = magnet.Radius;
			float eggValue = default(float);
			float value11 = default(float);
			EggFloat eggFloat21 = new EggFloat(value11, eggValue);
			eggValue = radius._eggVal * currentSkinData._003Cmagnet_003Ek__BackingField;
			value11 = radius._val * currentSkinData._003Cmagnet_003Ek__BackingField;
			float eggValue2 = default(float);
			float value12 = default(float);
			EggFloat radius2 = new EggFloat(value12, eggValue2);
			eggValue2 = eggFloat21._eggVal + radius._eggVal;
			value12 = eggFloat21._val + radius._val;
			magnet.Radius = radius2;
			_magnet.RefreshSize();
			PlayerModifierStats playerStats11 = _playerStats;
			EggFloat eggFloat22 = playerStats11._003CLuck_003Ek__BackingField;
			float value13 = default(float);
			EggFloat eggFloat23 = new EggFloat(value13, eggFloat22._eggVal);
			value13 = eggFloat22._val + currentSkinData._003Cluck_003Ek__BackingField;
			playerStats11._003CLuck_003Ek__BackingField = eggFloat23;
			PlayerModifierStats playerStats12 = _playerStats;
			EggFloat eggFloat24 = playerStats12._003CGrowth_003Ek__BackingField;
			float value14 = default(float);
			EggFloat eggFloat25 = new EggFloat(value14, eggFloat24._eggVal);
			value14 = eggFloat24._val + currentSkinData._003Cgrowth_003Ek__BackingField;
			playerStats12._003CGrowth_003Ek__BackingField = eggFloat25;
			PlayerModifierStats playerStats13 = _playerStats;
			EggFloat eggFloat26 = playerStats13._003CGreed_003Ek__BackingField;
			float value15 = default(float);
			EggFloat eggFloat27 = new EggFloat(value15, eggFloat26._eggVal);
			value15 = eggFloat26._val + currentSkinData._003Cgreed_003Ek__BackingField;
			playerStats13._003CGreed_003Ek__BackingField = eggFloat27;
			PlayerModifierStats playerStats14 = _playerStats;
			EggFloat eggFloat28 = playerStats14._003CCurse_003Ek__BackingField;
			float value16 = default(float);
			EggFloat eggFloat29 = new EggFloat(value16, eggFloat28._eggVal);
			value16 = eggFloat28._val + currentSkinData._003Ccurse_003Ek__BackingField;
			playerStats14._003CCurse_003Ek__BackingField = eggFloat29;
			PlayerModifierStats playerStats15 = _playerStats;
			float currentHp = (playerStats15._003CShields_003Ek__BackingField += currentSkinData._003Cshields_003Ek__BackingField);
			PlayerModifierStats playerStats16 = _playerStats;
			EggDouble eggDouble = playerStats16._003CRevivals_003Ek__BackingField;
			EggDouble eggDouble2 = new EggDouble(currentSkinData._003Crevivals_003Ek__BackingField, eggDouble._eggVal);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm1,xmm6\"");
			playerStats16._003CRevivals_003Ek__BackingField = eggDouble2;
			PlayerModifierStats playerStats17 = _playerStats;
			EggFloat eggFloat30 = playerStats17._003CReRolls_003Ek__BackingField;
			float value17 = default(float);
			EggFloat eggFloat31 = new EggFloat(value17, eggFloat30._eggVal);
			value17 = eggFloat30._val + currentSkinData._003CreRolls_003Ek__BackingField;
			playerStats17._003CReRolls_003Ek__BackingField = eggFloat31;
			PlayerModifierStats playerStats18 = _playerStats;
			EggFloat eggFloat32 = playerStats18._003CSkips_003Ek__BackingField;
			float value18 = default(float);
			EggFloat eggFloat33 = new EggFloat(value18, eggFloat32._eggVal);
			value18 = eggFloat32._val + currentSkinData._003Cskips_003Ek__BackingField;
			playerStats18._003CSkips_003Ek__BackingField = eggFloat33;
			PlayerModifierStats playerStats19 = _playerStats;
			EggFloat eggFloat34 = playerStats19._003CBanish_003Ek__BackingField;
			float value19 = default(float);
			EggFloat eggFloat35 = new EggFloat(value19, eggFloat34._eggVal);
			value19 = eggFloat34._val + currentSkinData._003Cbanish_003Ek__BackingField;
			playerStats19._003CBanish_003Ek__BackingField = eggFloat35;
			WeaponType startingWeaponType = (((object)currentSkinData._003CstartingWeapon_003Ek__BackingField == null) ? _startingWeaponType : ((WeaponType)((object?)currentSkinData._003CstartingWeapon_003Ek__BackingField >> 32)));
			_startingWeaponType = startingWeaponType;
			if (_onEveryLevelUp != null && currentSkinData._003ConEveryLevelUp_003Ek__BackingField != null)
			{
				_onEveryLevelUp.Upgrade(currentSkinData._003ConEveryLevelUp_003Ek__BackingField);
			}
			float num = MaxHp();
			_currentHp = currentHp;
		}
	}

	public void AddSkinWeapons()
	{
		//IL_004a: Expected I, but got O
		if (_currentCharacterData == null)
		{
			return;
		}
		Skin currentSkinData = _currentCharacterData.GetCurrentSkinData();
		if (currentSkinData == null)
		{
			return;
		}
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		while (enumerator.MoveNext())
		{
			nint num = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v58 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			nint num2 = 0;
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				WeaponType weaponType = Enum.Parse<WeaponType>(null);
				Weapon weapon = core._weaponsFacade.AddWeapon(weaponType, this);
				continue;
			}
			throw new NullReferenceException();
		}
		List<string>.Enumerator enumerator2 = default(List<string>.Enumerator);
		while (enumerator2.MoveNext())
		{
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null)
			{
				WeaponType accessoryType = Enum.Parse<WeaponType>(null);
				bool flag = core2._accessoriesFacade == null;
				string text = null;
				if (!flag)
				{
					core2._accessoriesFacade.AddAccessory(accessoryType, this);
					continue;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		List<string>.Enumerator enumerator3 = default(List<string>.Enumerator);
		bool allowDuplicates = default(bool);
		while (true)
		{
			if (enumerator3.MoveNext())
			{
				GameManager core3 = GM.Core;
				if ((object)GM.Core != null)
				{
					WeaponType weaponType2 = Enum.Parse<WeaponType>(null);
					bool flag2 = core3._weaponsFacade == null;
					string text = null;
					if (flag2)
					{
						break;
					}
					Weapon weapon2 = core3._weaponsFacade.AddHiddenWeapon(weaponType2, this, removeFromStore: true, allowDuplicates);
					continue;
				}
				throw new NullReferenceException();
			}
			return;
		}
		throw new NullReferenceException();
	}

	public void ResetStats()
	{
		_playerStats.ResetStats();
		_currentJsonData = null;
	}

	public void PlayerStatsUpgrade(ModifierStats other, bool multiplicativeMaxHp = false)
	{
		//IL_0026: Invalid comparison between F4 and I4
		_playerStats.Upgrade(other, multiplicativeMaxHp);
		if (other._003CMagnet_003Ek__BackingField > 0f)
		{
			MagnetZone magnet = _magnet;
			EggFloat radius = magnet.Radius;
			float eggValue = default(float);
			float value = default(float);
			EggFloat eggFloat = new EggFloat(value, eggValue);
			eggValue = radius._eggVal * other._003CMagnet_003Ek__BackingField;
			value = radius._val * other._003CMagnet_003Ek__BackingField;
			float eggValue2 = default(float);
			float value2 = default(float);
			EggFloat radius2 = new EggFloat(value2, eggValue2);
			eggValue2 = eggFloat._eggVal + radius._eggVal;
			value2 = eggFloat._val + radius._val;
			magnet.Radius = radius2;
			_magnet.RefreshSize();
		}
	}

	public void AddValueToAttribute(CharacterController character, WeaponType weaponType, float value)
	{
		//IL_000e: Expected O, but got I4
		//IL_0038: Expected O, but got I8
		//IL_0052: Expected O, but got I8
		object obj = weaponType + -50;
		if ((nint)obj <= 16)
		{
			object obj2 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ rcx_v1+7598AC4+v2 @ r8_v1*4]");
			object obj3 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v24 @ rdx_v2 (should have been resolved before IL gen)");
		}
	}

	public void AddActiveRapidFire(float cooldownChange, float speedChange, float duration)
	{
		_classSupport.AddActiveRapidFire(cooldownChange, speedChange, duration);
	}

	public void AddActiveHeartRefresh(float statChange1, float statChange2, float duration)
	{
		_classSupport.AddActiveHeartRefresh(statChange1, statChange2, duration);
	}

	public void AddActiveKarmaCoin()
	{
		CharacterController_Support classSupport = _classSupport;
		int karmaCoinCount = classSupport._karmaCoinCount + 1;
		classSupport._karmaCoinCount = karmaCoinCount;
	}

	public void AddActiveMirrorOfTruth(float statChange1, float statChange2, float duration)
	{
		_classSupport.AddActiveMirrorOfTruth(statChange1, statChange2, duration);
	}

	public virtual void SetExtraVisualsVisible(bool show)
	{
	}

	public void SetMovementAI(AIType aiType, CharacterController followedCharacter = null)
	{
		if (aiType != AIType.None)
		{
			if (_deficiencyControl == null)
			{
				CharacterADControl characterADControl = new CharacterADControl();
				characterADControl._003CLevelupType_003Ek__BackingField = LevelupType.LevelupPresets;
				characterADControl._congaMaxDistance = 0.5f;
				characterADControl._congaMinDistance = 0.1f;
				_deficiencyControl = characterADControl;
			}
			CharacterADControl deficiencyControl = _deficiencyControl;
			deficiencyControl._currentType = aiType;
			deficiencyControl._controlledPlayer = this;
			deficiencyControl._followedCharacter = followedCharacter;
			if ((object)followedCharacter != null && ((UnityEngine.Object)followedCharacter).m_CachedPtr != (IntPtr)0)
			{
				_player = followedCharacter._player;
			}
			else
			{
				_player = null;
			}
		}
		else
		{
			_deficiencyControl = null;
		}
	}

	public virtual bool DoesWantPickup(Pickup pickup)
	{
		//IL_0551: Expected I4, but got O
		//IL_0078: Expected O, but got I4
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_04f0: Expected O, but got I4
		//IL_0474: Expected O, but got I4
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_0523: Expected O, but got I4
		//IL_04a7: Expected O, but got I4
		//IL_00f4: Expected O, but got I4
		//IL_0588: Expected O, but got I4
		//IL_05cd: Expected O, but got I4
		//IL_01c2: Expected O, but got I4
		//IL_0612: Expected O, but got I4
		//IL_0248: Expected O, but got I4
		//IL_0657: Expected O, but got I4
		//IL_02ce: Expected O, but got I4
		//IL_069c: Expected O, but got I4
		//IL_0354: Expected O, but got I4
		//IL_03da: Expected O, but got I4
		//IL_044d: Expected O, but got I4
		if ((object)pickup != null)
		{
			if (pickup.CanCharacterCollectPickup(_characterType))
			{
				bool flag = _pickupMode == PickupMode.Normal;
				if (!flag)
				{
					object obj = _pickupMode - 1;
					if (!flag)
					{
						object obj2 = obj - 1;
						if (!flag)
						{
							object obj3 = obj2 - 1;
							if (!flag)
							{
								if ((nint)obj3 == 1)
								{
									goto IL_053d;
								}
							}
							else
							{
								object obj4 = pickup._003CPickupType_003Ek__BackingField - 2;
								if ((nint)obj4 > 4 && pickup._003CPickupType_003Ek__BackingField != ItemType.ROAST && pickup._003CPickupType_003Ek__BackingField != ItemType.TP_SOULSTEAL_LITTLEHEART)
								{
									if (pickup._003CPickupType_003Ek__BackingField == ItemType.LITTLEHEART)
									{
										bool flag2 = _deficiencyControl == null;
										bool flag3 = false;
										if (!flag2)
										{
											CharacterADControl deficiencyControl = _deficiencyControl;
											object obj5 = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
											bool flag4 = obj5 == null;
											flag3 = flag4;
										}
										int num = _PlayerIndex >> 31;
										int num2 = (flag3 ? 1 : 0) & num;
										bool flag5 = num2 == 0;
										object obj6 = !flag5;
										if (obj6 != null)
										{
											goto IL_00db;
										}
									}
									if (pickup._003CPickupType_003Ek__BackingField == ItemType.BONUS_CURSEDSOUL)
									{
										bool flag6 = _deficiencyControl == null;
										bool flag7 = false;
										if (!flag6)
										{
											CharacterADControl deficiencyControl2 = _deficiencyControl;
											object obj7 = deficiencyControl2._003CLevelupType_003Ek__BackingField - 3;
											bool flag8 = obj7 == null;
											flag7 = flag8;
										}
										int num3 = _PlayerIndex >> 31;
										int num4 = (flag7 ? 1 : 0) & num3;
										bool flag9 = num4 == 0;
										object obj8 = !flag9;
										if (obj8 != null)
										{
											goto IL_00db;
										}
									}
									if (pickup._003CPickupType_003Ek__BackingField == ItemType.FB_BARRIER)
									{
										bool flag10 = _deficiencyControl == null;
										bool flag11 = false;
										if (!flag10)
										{
											CharacterADControl deficiencyControl3 = _deficiencyControl;
											object obj9 = deficiencyControl3._003CLevelupType_003Ek__BackingField - 3;
											bool flag12 = obj9 == null;
											flag11 = flag12;
										}
										int num5 = _PlayerIndex >> 31;
										int num6 = (flag11 ? 1 : 0) & num5;
										bool flag13 = num6 == 0;
										object obj10 = !flag13;
										if (obj10 != null)
										{
											goto IL_00db;
										}
									}
									if (pickup._003CPickupType_003Ek__BackingField == ItemType.FB_GRENADE)
									{
										bool flag14 = _deficiencyControl == null;
										bool flag15 = false;
										if (!flag14)
										{
											CharacterADControl deficiencyControl4 = _deficiencyControl;
											object obj11 = deficiencyControl4._003CLevelupType_003Ek__BackingField - 3;
											bool flag16 = obj11 == null;
											flag15 = flag16;
										}
										int num7 = _PlayerIndex >> 31;
										int num8 = (flag15 ? 1 : 0) & num7;
										bool flag17 = num8 == 0;
										object obj12 = !flag17;
										if (obj12 != null)
										{
											goto IL_00db;
										}
									}
									if (pickup._003CPickupType_003Ek__BackingField == ItemType.FB_RAPIDFIRE)
									{
										bool flag18 = _deficiencyControl == null;
										bool flag19 = false;
										if (!flag18)
										{
											CharacterADControl deficiencyControl5 = _deficiencyControl;
											object obj13 = deficiencyControl5._003CLevelupType_003Ek__BackingField - 3;
											bool flag20 = obj13 == null;
											flag19 = flag20;
										}
										int num9 = _PlayerIndex >> 31;
										int num10 = (flag19 ? 1 : 0) & num9;
										bool flag21 = num10 == 0;
										object obj14 = !flag21;
										if (obj14 != null)
										{
											goto IL_00db;
										}
									}
									if (_characterType != CharacterType.EME_MAGICALL)
									{
										goto IL_053d;
									}
									if (pickup._003CPickupType_003Ek__BackingField != ItemType.EME_CATY)
									{
										object obj15 = pickup._003CPickupType_003Ek__BackingField - 106;
										return obj15 == null;
									}
								}
							}
							goto IL_00db;
						}
						object obj16 = pickup._003CPickupType_003Ek__BackingField - 2;
						if ((nint)obj16 > 4)
						{
							object obj17 = pickup._003CPickupType_003Ek__BackingField - 12;
							return obj17 == null;
						}
					}
					else if (pickup._003CPickupType_003Ek__BackingField != ItemType.GEM)
					{
						object obj18 = pickup._003CPickupType_003Ek__BackingField - 2;
						if ((nint)obj18 > 2)
						{
							object obj19 = pickup._003CPickupType_003Ek__BackingField - 5;
							return obj19 == null;
						}
					}
					return true;
				}
				goto IL_00db;
			}
			goto IL_053d;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_053d:
		return false;
		IL_00db:
		return true;
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
		_customDamageOverlayRenderer = renderer;
	}

	public CharacterController()
	{
		//IL_0279: Expected I, but got O
		//IL_0166: Expected I, but got O
		//IL_02b4: Expected I, but got O
		//IL_01a1: Expected I, but got O
		//IL_00af: Expected I, but got O
		_startingWeaponType = WeaponType.MAGIC_MISSILE;
		_characterType = CharacterType.ANTONIO;
		_playDamageSFX = true;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_currentDirection = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		nint num3 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v5 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num4 = 0;
		_currentDirectionRaw = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		nint num5 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v7 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num6 = 0;
		_lastMovementDirection = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		ModifierStats onEveryLevelUp = new ModifierStats();
		_onEveryLevelUp = onEveryLevelUp;
		_defaultSpriteWidth = 32f;
		PlayerModifierStats playerStats = new PlayerModifierStats();
		_playerStats = playerStats;
		_slowMultiplier = 1f;
		nint num7 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rax_v14 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num8 = 0;
		_lastFacingDirection = Vector2.rightVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rcx_v13 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
		_ = 0;
		_canFlip = true;
		_shieldInvulTime = 240f;
		_gFeverMul = 1f;
		_hasLastBreath = true;
		_isCriticalHPEnabled = true;
		_criticalHPTreshold = 0.2f;
		_maxWeaponCount = 6;
		_maxAccessoryCount = 6;
		_debuffSlow = 1f;
		_multiplayerRevivalAllowed = true;
		_003CTrackedByCamera_003Ek__BackingField = true;
		MoveSpeedMultiplier = 1f;
		List<WeaponType> glimmeredTechniques = new List<WeaponType>();
		GlimmeredTechniques = glimmeredTechniques;
		SvMult_AnyRare = 1f;
		SvMult_Foil = 1f;
		SvMult_Gala = 1f;
		SvMult_Poly = 1f;
		SvMult_Holo = 1f;
		SvMult_Inve = 1f;
		SvMult_Base = 1f;
		_003CSkillCards_Mult_003Ek__BackingField = 1f;
		IsFollowerSharingPassives = true;
		nint num9 = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v18 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num10 = 0;
		_003CExternalVelocity_003Ek__BackingField = float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rcx_v17 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		_ = 0;
		_003CCountsAsMainCharacterForRevivals_003Ek__BackingField = true;
		List<Weapon> heldShieldSlots = new List<Weapon>();
		HeldShieldSlots = heldShieldSlots;
		DamageSound = SfxType.LossSFX;
		DamageVolume = 0.1f;
		DamageBaseDetune = -500f;
		((GameMonoBehaviour)this)._onResumeSent = true;
	}

	private void _003CDebug_ToggleInvulnerability_003Eb__541_0()
	{
		RestoreTint();
	}

	private void _003CFreezePlayer_003Eb__542_0()
	{
		CharacterWeaponsManager weaponsManager = _weaponsManager;
		weaponsManager._maxActiveCount = -1;
		weaponsManager.SetMaxWeaponCount(weaponsManager._maxActiveCount, weaponsManager._maxHiddenCount);
	}

	private void _003CSetPermanentInvulnerability_003Eb__543_0()
	{
		RestoreTint();
	}

	private void _003CTryGettingChomped_003Eb__552_0()
	{
		_damageVfx.Stop();
	}

	private void _003CTryGettingChomped_003Eb__552_1()
	{
		_receivingDamage = false;
	}

	private void _003CShowMultiplayerIndicator_003Eb__599_0()
	{
		GameObject gameObject = _multiplayerIndicator.gameObject;
		gameObject.SetActive(value: false);
		PlayerOptionsData config = _playerOptions.Config;
		if (!config._003CPermanentCoopOutlines_003Ek__BackingField || _PlayerIndex < 0)
		{
			GameObject gameObject2 = _multiplayerOutliner.gameObject;
			gameObject2.SetActive(value: false);
		}
	}

	private void _003COnDeath_003Eb__611_0()
	{
		_damageVfx.Stop();
	}

	private void _003CScheduleDeathConsequences_003Eb__612_0()
	{
		if (!_isInFinalStage)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1B20");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1A70");
		}
	}

	private void _003CScheduleDeathConsequences_003Eb__612_1()
	{
		DoOnlineOrLocalRevival(instantRevival: true);
	}

	private unsafe void _003CScheduleDeathConsequences_003Eb__612_2()
	{
		//IL_0482: Expected I4, but got O
		//IL_04a7: Expected O, but got Ref
		//IL_042e: Expected I4, but got O
		//IL_0453: Expected O, but got Ref
		//IL_051e: Expected I4, but got O
		//IL_00be: Invalid comparison between I4 and F4
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0352: Expected O, but got I
		//IL_0367: Expected O, but got I
		//IL_037c: Expected O, but got I
		//IL_0391: Expected O, but got I
		if (_multiplayerRevivalAllowed)
		{
			_multiplayerRevivalUI.ToggleVisible(visible: true);
			GameManager core = GM.Core;
			CoopConfig coopConfig = core.CoopConfig;
			Action onComplete = TurnIntoMultiplayerGhost;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer multiplayerDecompositionTimer = Timers.Register(coopConfig._decompositionTimeSeconds, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_multiplayerDecompositionTimer = multiplayerDecompositionTimer;
			GameManager core2 = GM.Core;
			CoopConfig coopConfig2 = core2.CoopConfig;
			if (0f > coopConfig2._revivalLossSpeed)
			{
				GameManager core3 = GM.Core;
				CoopConfig coopConfig3 = core3.CoopConfig;
				float revivalLossSpeed = coopConfig3._revivalLossSpeed;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				object obj = revivalLossSpeed ^ 0;
				float num = 1f / (float)obj;
				Action onComplete2 = delegate
				{
					_multiplayerRevivalUI.DoShake(1f);
				};
				float duration = num - 2f;
				Timer multiplayerReviveShake = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_multiplayerReviveShake1 = multiplayerReviveShake;
				Action onComplete3 = delegate
				{
					_multiplayerRevivalUI.DoShake(2f);
				};
				float duration2 = num - 1f;
				Timer multiplayerReviveShake2 = Timers.Register(duration2, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_multiplayerReviveShake2 = multiplayerReviveShake2;
			}
		}
		GameManager core4 = GM.Core;
		CoopConfig coopConfig4 = core4.CoopConfig;
		if (_gameManager.GetAlivePlayerCount(coopConfig4._immediateRevivalUsage, includeOnlyMainCharacters: true) != 0)
		{
			GameManager core5 = GM.Core;
			CoopConfig coopConfig5 = core5.CoopConfig;
			if (coopConfig5._removeDeadPlayersFromCamera)
			{
				ProCamera2D instance = ProCamera2D.Instance;
				Transform cameraTarget = CameraTarget;
				GameManager core6 = GM.Core;
				CoopConfig coopConfig6 = core6.CoopConfig;
				instance.RemoveCameraTarget(cameraTarget, coopConfig6._removeDeadPlayerFromCameraDuration);
			}
			return;
		}
		bool flag = !_multiplayerRevivalAllowed;
		bool flag2 = true;
		if (!flag)
		{
			GameManager gameManager = _gameManager;
			flag2 = (byte)(int)gameManager._characters != 0;
			bool flag3 = false;
			bool flag4 = false;
			while (true)
			{
				bool num2 = flag4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v709 @ r8_v4 (System.Boolean)+18]");
				if ((nint)(num2 ? 1 : 0) >= (nint)0)
				{
					break;
				}
				bool num3 = flag3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v709 @ r8_v4 (System.Boolean)+18]");
				if ((nint)(num3 ? 1 : 0) < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v709 @ r8_v4 (System.Boolean)+10]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v21+20+v175 @ rdi_v4 (System.Boolean)*8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rcx_v22+218]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rcx_v23+A0]");
					object obj5 = 0;
					if (0L <= 9218868437227405312L)
					{
						flag4 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
						_ = 0;
						flag3 = flag4;
					}
					else
					{
						flag4 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
						_ = 1.7976931348623157E+308;
						flag3 = flag4;
					}
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new NullReferenceException();
			}
		}
		object obj6 = default(object);
		object obj7 = default(object);
		if (!_isInFinalStage)
		{
			object arg = (CharacterType)obj6;
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			string message = string.FormatHelper((IFormatProvider)null, "<color=green>Player {0} Died. Sending CharacterDiedSignal</color>", (System.ParamsArray)(&obj7));
			Debug.Log(message);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1B20");
		}
		else
		{
			object arg2 = (CharacterType)obj6;
			System.ParamsArray paramsArray = new System.ParamsArray(arg2);
			string message2 = string.FormatHelper((IFormatProvider)null, "<color=green>Player {0} Died. Sending ShowGameOverinoSceneSignal</color>", (System.ParamsArray)(&obj7));
			Debug.Log(message2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1A70");
		}
	}

	private void _003CScheduleDeathConsequences_003Eb__612_3()
	{
		_multiplayerRevivalUI.DoShake(1f);
	}

	private void _003CScheduleDeathConsequences_003Eb__612_4()
	{
		_multiplayerRevivalUI.DoShake(2f);
	}
}
