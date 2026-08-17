using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Newtonsoft.Json.Linq;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Weapon : Equipment
{
	public enum FiringAnimation
	{
		None,
		Melee,
		Ranged,
		Magic,
		Bazooka,
		GlyphAbs,
		Axe,
		ConeOfCold
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Equipment, WeaponType> _003C_003E9__140_0;

		public static Func<Equipment, WeaponType> _003C_003E9__140_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal WeaponType _003CLevelUp_003Eb__140_0(Equipment x)
		{
			//IL_0035: Expected I4, but got O
			if ((object)x != null)
			{
				return x._equipmentType;
			}
			NullReferenceException ex = new NullReferenceException();
			return (WeaponType)ex;
		}

		internal WeaponType _003CLevelUp_003Eb__140_1(Equipment x)
		{
			//IL_0035: Expected I4, but got O
			if ((object)x != null)
			{
				return x._equipmentType;
			}
			NullReferenceException ex = new NullReferenceException();
			return (WeaponType)ex;
		}
	}

	private sealed class _003C_003Ec__DisplayClass156_0
	{
		public int localIndex;

		public Weapon _003C_003E4__this;

		internal void _003CFire_003Eb__0()
		{
			//IL_012f: Expected O, but got I4
			//IL_00b4: Expected O, but got I
			//IL_00e9: Expected I, but got O
			//IL_0079->IL00f8: Incompatible stack heights: 1 vs 0
			//IL_009e->IL00f8: Incompatible stack heights: 1 vs 0
			//IL_00dc->IL00f8: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject = _003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj == null)
					{
						return;
					}
					GameObject gameObject2 = (GameObject)(object)_003C_003E4__this;
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
							float2 position = ((ArcadeSprite)0).position;
							Weapon weapon = _003C_003E4__this;
							if ((object)_003C_003E4__this != null)
							{
								nint num = (nint)gameObject2;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v246 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass176_0
	{
		public Weapon _003C_003E4__this;

		public FiringAnimation animation;

		internal void _003CPlayNextAttackAnim_003Eb__0()
		{
			Weapon weapon = _003C_003E4__this;
			((Equipment)weapon)._003COwner_003Ek__BackingField.OnRangedAttackAnim();
		}

		internal void _003CPlayNextAttackAnim_003Eb__1()
		{
			Weapon weapon = _003C_003E4__this;
			((Equipment)weapon)._003COwner_003Ek__BackingField.OnMeleeAttackAnim();
		}

		internal void _003CPlayNextAttackAnim_003Eb__2()
		{
			Weapon weapon = _003C_003E4__this;
			((Equipment)weapon)._003COwner_003Ek__BackingField.OnMagicAttackAnim();
		}

		internal void _003CPlayNextAttackAnim_003Eb__3()
		{
			Weapon weapon = _003C_003E4__this;
			((Equipment)weapon)._003COwner_003Ek__BackingField.OnAttackAnim(animation);
		}
	}

	private Projectile _ProjectilePrefab;

	protected GameManager _gameMan;

	protected PlayerOptions _playerOptions;

	protected GameSessionData _gameSessionData;

	protected WeaponData _currentWeaponData;

	protected bool _skipAddingEvolution;

	protected readonly List<Projectile> _spawnedProjectiles;

	protected Transform _cachedTransform;

	protected Timer _lastShotTimer;

	protected Timer _firingTimer;

	private Timer _firingAnimEvent;

	protected Transform _targetTransform;

	protected BulletPool _projectilePool;

	protected int _critIndex;

	protected List<float> _critChancesArray;

	protected int _bounces;

	protected int _bonusBounces;

	protected float _lastFiringInterval;

	protected bool _beginningArcana;

	protected int _beginningAmount;

	protected List<Collider> _wallsColliders;

	protected bool _isVisible;

	protected WeaponType _explosionType;

	[NonSerialized]
	public bool _explodeOnExpire;

	protected BulletPool _secondaryPool;

	protected ProjectileFactory _projectileFactory;

	protected WeaponType _secondaryOvarlapDamageType;

	public LimitBreakData accumulatedLimitBreaks;

	[NonSerialized]
	public bool IsHoming;

	[NonSerialized]
	public bool IsAdept;

	public bool HasCooldownSpeedBonus;

	private float _003CStatsInflictedDamage_003Ek__BackingField;

	private float _003CStatsLifetime_003Ek__BackingField;

	private bool _003CCanCrit_003Ek__BackingField;

	private float _003CFreezeChance_003Ek__BackingField;

	private float _defangChance;

	private float _003CTotalTime_003Ek__BackingField;

	private int _003CLimitBreakLevel_003Ek__BackingField;

	private bool _003CSkipAddingNormalWeapon_003Ek__BackingField;

	private bool _003CShowAsDisabledOnEquipmentPanel_003Ek__BackingField;

	private static readonly ProfilerMarker _markerCleanup;

	private static readonly ProfilerMarker _markerFireOneProjectile;

	protected virtual int ProjectilePoolSize => 50;

	public PhysicsGroup ProjectileGroup => _projectilePool;

	public List<Projectile> SpawnedProjectiles => _spawnedProjectiles;

	public GameManager GameMan => _gameMan;

	protected HitVfxType VfxType
	{
		get
		{
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null)
			{
				return currentWeaponData._003ChitVFX_003Ek__BackingField;
			}
			return HitVfxType.Default;
		}
	}

	protected virtual bool UseOnlineTimer => true;

	public float StatsInflictedDamage
	{
		get
		{
			return _003CStatsInflictedDamage_003Ek__BackingField;
		}
		set
		{
			_003CStatsInflictedDamage_003Ek__BackingField = value;
		}
	}

	public float StatsLifetime
	{
		get
		{
			return _003CStatsLifetime_003Ek__BackingField;
		}
		private set
		{
			_003CStatsLifetime_003Ek__BackingField = value;
		}
	}

	public virtual float Chance
	{
		get
		{
			WeaponData currentWeaponData = _currentWeaponData;
			return currentWeaponData._003Cchance_003Ek__BackingField;
		}
	}

	public int Penetrating
	{
		get
		{
			//IL_0041: Expected I4, but got O
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null)
			{
				return currentWeaponData._003Cpenetrating_003Ek__BackingField;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
		protected set
		{
			WeaponData currentWeaponData = _currentWeaponData;
			currentWeaponData._003Cpenetrating_003Ek__BackingField = value;
		}
	}

	public float Interval
	{
		get
		{
			WeaponData currentWeaponData = _currentWeaponData;
			return currentWeaponData._003Cinterval_003Ek__BackingField;
		}
		set
		{
			WeaponData currentWeaponData = _currentWeaponData;
			currentWeaponData._003Cinterval_003Ek__BackingField = value;
		}
	}

	protected float Duration
	{
		get
		{
			WeaponData currentWeaponData = _currentWeaponData;
			float result = default(float);
			if ((object)currentWeaponData._003Cduration_003Ek__BackingField != null)
			{
				return result;
			}
			return 1000f;
		}
	}

	public float RepeatInterval
	{
		get
		{
			WeaponData currentWeaponData = _currentWeaponData;
			return currentWeaponData._003CrepeatInterval_003Ek__BackingField;
		}
	}

	public WeaponData CurrentWeaponData => _currentWeaponData;

	public float HitBoxDelay
	{
		get
		{
			WeaponData currentWeaponData = _currentWeaponData;
			float result = default(float);
			if ((object)currentWeaponData._003ChitBoxDelay_003Ek__BackingField != null)
			{
				return result;
			}
			return 1000f;
		}
	}

	public float Knockback
	{
		get
		{
			WeaponData currentWeaponData = _currentWeaponData;
			float result = default(float);
			if ((object)currentWeaponData._003Cknockback_003Ek__BackingField != null)
			{
				return result;
			}
			return 5f;
		}
	}

	public PlayerOptions PlayerOptions => _playerOptions;

	public bool CanCrit
	{
		get
		{
			return _003CCanCrit_003Ek__BackingField;
		}
		protected set
		{
			_003CCanCrit_003Ek__BackingField = value;
		}
	}

	public List<float> CritChancesArray => _critChancesArray;

	public float FreezeChance
	{
		get
		{
			return _003CFreezeChance_003Ek__BackingField;
		}
		set
		{
			_003CFreezeChance_003Ek__BackingField = value;
		}
	}

	public virtual float DefangChance
	{
		get
		{
			return _defangChance;
		}
		set
		{
			_defangChance = value;
		}
	}

	public int CritIndex
	{
		get
		{
			return _critIndex;
		}
		set
		{
			_critIndex = value;
		}
	}

	protected Vector2 PlayerPos
	{
		get
		{
			if ((object)base._003COwner_003Ek__BackingField != null)
			{
				float2 position = base._003COwner_003Ek__BackingField.position;
				Vector2 result = default(Vector2);
				return result;
			}
			return (Vector2)new NullReferenceException();
		}
	}

	public float TotalTime
	{
		get
		{
			return _003CTotalTime_003Ek__BackingField;
		}
		set
		{
			_003CTotalTime_003Ek__BackingField = value;
		}
	}

	public int LimitBreakLevel
	{
		get
		{
			return _003CLimitBreakLevel_003Ek__BackingField;
		}
		private set
		{
			_003CLimitBreakLevel_003Ek__BackingField = value;
		}
	}

	public bool SkipAddingEvolution
	{
		get
		{
			return _skipAddingEvolution;
		}
		set
		{
			_skipAddingEvolution = value;
		}
	}

	public bool SkipAddingNormalWeapon
	{
		get
		{
			return _003CSkipAddingNormalWeapon_003Ek__BackingField;
		}
		set
		{
			_003CSkipAddingNormalWeapon_003Ek__BackingField = value;
		}
	}

	public bool IsVisible => _isVisible;

	public bool ShowAsDisabledOnEquipmentPanel
	{
		get
		{
			return _003CShowAsDisabledOnEquipmentPanel_003Ek__BackingField;
		}
		set
		{
			_003CShowAsDisabledOnEquipmentPanel_003Ek__BackingField = value;
		}
	}

	public virtual float HeartOfFirePower
	{
		get
		{
			WeaponData currentWeaponData = _currentWeaponData;
			return currentWeaponData._003Cpower_003Ek__BackingField;
		}
	}

	public override bool IsPowerup()
	{
		return false;
	}

	public virtual float StatsGetDps()
	{
		//IL_000b: Invalid comparison between F4 and I4
		//IL_005b: Expected F4, but got I4
		//IL_003e: Invalid comparison between F4 and I4
		bool flag = _003CStatsLifetime_003Ek__BackingField == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018755E8E2h\"");
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018755E8F5h\"");
			if (_003CStatsInflictedDamage_003Ek__BackingField != 0f)
			{
				return _003CStatsInflictedDamage_003Ek__BackingField / _003CStatsLifetime_003Ek__BackingField;
			}
		}
		return 0f;
	}

	protected override void FakeConstruct()
	{
		GameManager core = GM.Core;
		_dataManager = core._dataManager;
		GameManager core2 = GM.Core;
		_signalBus = core2._signalBus;
		GameManager core3 = GM.Core;
		_levelUpFactory = core3._levelUpFactory;
		_gameMan = GM.Core;
		GameManager core4 = GM.Core;
		_playerOptions = core4._playerOptions;
		GameManager core5 = GM.Core;
		_gameSessionData = core5._gameSessionData;
		GameManager core6 = GM.Core;
		_projectileFactory = core6._projectileFactory;
	}

	protected virtual void Awake()
	{
		Transform cachedTransform = base.transform;
		_cachedTransform = cachedTransform;
		_003CLimitBreakLevel_003Ek__BackingField = 0;
		List<Collider> wallsColliders = new List<Collider>();
		_wallsColliders = wallsColliders;
		LimitBreakData limitBreakData = new LimitBreakData();
		accumulatedLimitBreaks = limitBreakData;
	}

	protected override void OnDestroy()
	{
		if (_firingAnimEvent != null)
		{
			_firingAnimEvent.Cancel();
		}
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
		if (_projectilePool != null)
		{
			_projectilePool.Destroy();
		}
		_projectilePool = null;
		if (_secondaryPool != null)
		{
			_secondaryPool.Destroy();
		}
		_secondaryPool = null;
	}

	public virtual void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		FakeConstruct();
		base._003COwner_003Ek__BackingField = characterController;
		base._equipmentType = weaponType;
		_003CStatsInflictedDamage_003Ek__BackingField = 0f;
		_003CTotalTime_003Ek__BackingField = 0f;
		_beginningAmount = 0;
		if (_projectilePool == null)
		{
			int projectilePoolSize = ProjectilePoolSize;
			BulletPool projectilePool = new BulletPool(_ProjectilePrefab, projectilePoolSize);
			_projectilePool = projectilePool;
		}
		_isVisible = true;
		MakeLevelOne();
		OnStart();
		GameManager core = GM.Core;
		ParticleSystem[] componentsInChildren = GetComponentsInChildren<ParticleSystem>();
		core._particleManager.RegisterParticleSystem(componentsInChildren);
	}

	public virtual void OnMirrorData(Vector2 position)
	{
	}

	public virtual void OnWeaponAdded()
	{
	}

	public virtual float CalculateTotalDamage()
	{
		return _003CStatsInflictedDamage_003Ek__BackingField;
	}

	protected unsafe virtual void OnStart()
	{
		//IL_08dc: Expected I, but got O
		//IL_090d: Expected O, but got I
		//IL_008e: Expected I, but got O
		//IL_00e7: Expected O, but got I
		//IL_0107: Expected O, but got I
		//IL_0929: Expected I, but got O
		//IL_095a: Expected O, but got I
		//IL_01ce: Expected I, but got O
		//IL_0227: Expected O, but got I
		//IL_0227: Expected O, but got I
		//IL_0247: Expected O, but got I
		//IL_0275: Expected I, but got O
		//IL_02a6: Expected O, but got I
		//IL_02d0: Expected O, but got I
		//IL_0976: Expected I, but got O
		//IL_09a7: Expected O, but got I
		//IL_033b: Expected O, but got I4
		//IL_0402: Expected I, but got O
		//IL_045b: Expected O, but got I
		//IL_045b: Expected O, but got I
		//IL_047b: Expected O, but got I
		//IL_04ac: Expected O, but got I4
		//IL_0614: Expected O, but got I
		//IL_06c3: Expected O, but got I
		//IL_075e: Expected I, but got O
		//IL_0817: Expected O, but got Ref
		//IL_0a51: Expected O, but got I
		//IL_0a61: Expected O, but got I
		if (GetFiringAnimation() != FiringAnimation.None)
		{
			PlayNextAttackAnim();
		}
		ResetFiringTimer();
		nint num = (nint)typeof(ArcadePhysics);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v8 (Il2CppClass<ArcadePhysics>)+B8]");
		nint num2 = 0;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		bool flag = ArcadePhysics.s_scene == null;
		ArcadePhysicsCallback arcadePhysicsCallback = (ArcadePhysicsCallback)num2;
		ArcadePhysicsCallback arcadePhysicsCallback3 = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if (!flag)
		{
			arcadePhysicsCallback = (ArcadePhysicsCallback)(object)s_scene.physics;
			if ((object)s_scene.physics != null)
			{
				GameManager gameMan = _gameMan;
				if ((object)_gameMan != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v701 @ r8_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+350]");
					ArcadePhysicsCallback arcadePhysicsCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
					nint num3 = (nint)this;
					bool flag2 = ((Delegate)arcadePhysicsCallback2).delegate_trampoline == (IntPtr)0;
					arcadePhysicsCallback = arcadePhysicsCallback2;
					if (!flag2)
					{
						Collider collider = ((Factory)(nint)((Delegate)arcadePhysicsCallback2).delegate_trampoline).overlap(_projectilePool, gameMan.Enemies, arcadePhysicsCallback2, arcadePhysicsCallback3, callbackContext);
						bool flag3 = collider == null;
						arcadePhysicsCallback = (ArcadePhysicsCallback)(nint)((Delegate)arcadePhysicsCallback2).delegate_trampoline;
						if (!flag3)
						{
							Collider collider2 = collider.setName("Projectiles>Enemies");
							nint num4 = (nint)typeof(ArcadePhysics);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ rax_v21 (Il2CppClass<ArcadePhysics>)+B8]");
							nint num5 = 0;
							PhaserScene s_scene2 = ArcadePhysics.s_scene;
							bool flag4 = ArcadePhysics.s_scene == null;
							arcadePhysicsCallback = (ArcadePhysicsCallback)num5;
							if (!flag4)
							{
								arcadePhysicsCallback = (ArcadePhysicsCallback)(object)s_scene2.physics;
								if ((object)s_scene2.physics != null)
								{
									GameManager gameMan2 = _gameMan;
									if ((object)_gameMan != null)
									{
										arcadePhysicsCallback = (ArcadePhysicsCallback)(object)gameMan2._physicsManager;
										if (gameMan2._physicsManager != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v811 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+3A0]");
											ArcadePhysicsCallback arcadePhysicsCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
											nint num6 = (nint)this;
											bool flag5 = ((Delegate)arcadePhysicsCallback4).delegate_trampoline == (IntPtr)0;
											arcadePhysicsCallback = arcadePhysicsCallback4;
											if (!flag5)
											{
												Collider collider3 = ((Factory)(nint)((Delegate)arcadePhysicsCallback4).delegate_trampoline).overlap(_projectilePool, (ArcadeColliderType)(nint)((Delegate)arcadePhysicsCallback4).method_code, arcadePhysicsCallback4, arcadePhysicsCallback3, callbackContext);
												bool flag6 = collider3 == null;
												arcadePhysicsCallback = (ArcadePhysicsCallback)(nint)((Delegate)arcadePhysicsCallback4).delegate_trampoline;
												if (!flag6)
												{
													Collider collider4 = collider3.setName("Projectiles>Destructibles");
													nint num7 = (nint)typeof(GM);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v28 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
													nint num8 = 0;
													GameManager core = GM.Core;
													bool flag7 = (object)GM.Core == null;
													arcadePhysicsCallback = (ArcadePhysicsCallback)num8;
													if (!flag7)
													{
														bool flag8 = core._multiplayer == null;
														arcadePhysicsCallback = (ArcadePhysicsCallback)num8;
														if (!flag8)
														{
															int playerCount = core._multiplayer.GetPlayerCount();
															if (playerCount <= 1)
															{
																bool isOnlineMultiplayer = core._multiplayer.IsOnlineMultiplayer;
																bool flag9 = !isOnlineMultiplayer;
																ArcadePhysicsCallback arcadePhysicsCallback5 = arcadePhysicsCallback4;
																object obj = 0;
																string text = null;
																arcadePhysicsCallback = (ArcadePhysicsCallback)(object)core._multiplayer;
																if (flag9)
																{
																	goto IL_04c2;
																}
															}
															nint num9 = (nint)typeof(ArcadePhysics);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v870 @ rax_v87 (Il2CppClass<ArcadePhysics>)+B8]");
															nint num10 = 0;
															PhaserScene s_scene3 = ArcadePhysics.s_scene;
															bool flag10 = ArcadePhysics.s_scene == null;
															arcadePhysicsCallback = (ArcadePhysicsCallback)num10;
															if (!flag10)
															{
																arcadePhysicsCallback = (ArcadePhysicsCallback)(object)s_scene3.physics;
																if ((object)s_scene3.physics != null)
																{
																	GameManager gameMan3 = _gameMan;
																	if ((object)_gameMan != null)
																	{
																		arcadePhysicsCallback = (ArcadePhysicsCallback)(object)gameMan3._physicsManager;
																		if (gameMan3._physicsManager != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v988 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+360]");
																			ArcadePhysicsCallback arcadePhysicsCallback6 = new ArcadePhysicsCallback(this, (IntPtr)0);
																			nint num11 = (nint)this;
																			bool flag11 = ((Delegate)arcadePhysicsCallback6).delegate_trampoline == (IntPtr)0;
																			arcadePhysicsCallback = arcadePhysicsCallback6;
																			if (!flag11)
																			{
																				Collider collider5 = ((Factory)(nint)((Delegate)arcadePhysicsCallback6).delegate_trampoline).overlap(_projectilePool, (ArcadeColliderType)(nint)((Delegate)arcadePhysicsCallback6).method_ptr, arcadePhysicsCallback6, arcadePhysicsCallback3, callbackContext);
																				bool flag12 = collider5 == null;
																				arcadePhysicsCallback = (ArcadePhysicsCallback)(nint)((Delegate)arcadePhysicsCallback6).delegate_trampoline;
																				if (!flag12)
																				{
																					Collider collider6 = collider5.setName("Projectiles>Player");
																					ArcadePhysicsCallback arcadePhysicsCallback5 = arcadePhysicsCallback6;
																					object obj = 0;
																					string text = "Projectiles>Player";
																					arcadePhysicsCallback = (ArcadePhysicsCallback)(object)collider5;
																					goto IL_04c2;
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
				}
			}
		}
		goto IL_089b;
		IL_089b:
		throw new NullReferenceException();
		IL_04c2:
		WeaponData currentWeaponData = _currentWeaponData;
		if (_currentWeaponData != null)
		{
			if (!currentWeaponData._003ChitsWalls_003Ek__BackingField)
			{
				return;
			}
			GameManager gameMan4 = _gameMan;
			if ((object)_gameMan != null)
			{
				Stage stage = gameMan4._stage;
				if ((object)gameMan4._stage == null || ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				GameManager gameMan5 = _gameMan;
				bool flag13 = (object)_gameMan == null;
				arcadePhysicsCallback = (ArcadePhysicsCallback)(object)typeof(UnityEngine.Object);
				if (!flag13)
				{
					arcadePhysicsCallback = (ArcadePhysicsCallback)(object)gameMan5._stage;
					if ((object)gameMan5._stage != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rcx_v8 (ArcadePhysicsCallback)+88]");
						if ((nint)0 == 0)
						{
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rcx_v8 (ArcadePhysicsCallback)+208]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rcx_v8 (ArcadePhysicsCallback)+208]");
						if ((nint)0 == 0)
						{
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rbx_v11+10]");
						if ((nint)0 == 0)
						{
							return;
						}
						GameManager gameMan6 = _gameMan;
						bool flag14 = (object)_gameMan == null;
						arcadePhysicsCallback = (ArcadePhysicsCallback)(object)typeof(UnityEngine.Object);
						if (!flag14)
						{
							arcadePhysicsCallback = (ArcadePhysicsCallback)(object)gameMan6._stage;
							if ((object)gameMan6._stage != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rcx_v8 (ArcadePhysicsCallback)+208]");
								object obj3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rcx_v8 (ArcadePhysicsCallback)+208]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
									object obj4 = default(object);
									if (obj4 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v46+18]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185004430");
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1105 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+3B0]");
											ArcadePhysicsCallback arcadePhysicsCallback7 = new ArcadePhysicsCallback(this, (IntPtr)0);
											nint num12 = (nint)this;
											World world = default(World);
											ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
											CallbackContext callbackContext2 = default(CallbackContext);
											TilemapSetCollider tilemapSetCollider = new TilemapSetCollider(world, overlapOnly: false, _projectilePool, (ArcadeColliderType)(object)arcadePhysicsCallback3, (ArcadePhysicsCallback)(object)callbackContext, processCallback, callbackContext2);
											bool flag15 = tilemapSetCollider == null;
											arcadePhysicsCallback = (ArcadePhysicsCallback)(object)tilemapSetCollider;
											if (!flag15)
											{
												Collider collider7 = tilemapSetCollider.setName("Projectiles>Tilemap");
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ r15_v8+60]");
												bool flag16 = (nint)0 == 0;
												arcadePhysicsCallback = (ArcadePhysicsCallback)(object)tilemapSetCollider;
												if (!flag16)
												{
													PhaserTilemap phaserTilemap = null;
													ArcadeColliderType projectilePool = _projectilePool;
													List<PhaserTilemap>.Enumerator enumerator = default(List<PhaserTilemap>.Enumerator);
													if (enumerator.MoveNext())
													{
														PhaserTilemap phaserTilemap2 = null;
														List<PhaserTilemap>.Enumerator enumerator2 = (List<PhaserTilemap>.Enumerator)(&enumerator);
														throw new NullReferenceException();
													}
													PhaserScene s_scene4 = ArcadePhysics.s_scene;
													bool flag17 = ArcadePhysics.s_scene == null;
													arcadePhysicsCallback = (ArcadePhysicsCallback)(object)typeof(ArcadePhysics);
													if (!flag17)
													{
														bool flag18 = (object)s_scene4.physics == null;
														arcadePhysicsCallback = (ArcadePhysicsCallback)(object)typeof(ArcadePhysics);
														if (!flag18)
														{
															arcadePhysicsCallback = (ArcadePhysicsCallback)(object)typeof(ArcadePhysics);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ rcx_v8 (ArcadePhysicsCallback)+B8]");
															object obj5 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rax_v62+18]");
															object obj6 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rax_v62+18]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rbx_v13+50]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4520");
																	return;
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
		goto IL_089b;
	}

	public virtual float2 GetFiringVector()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = base._003COwner_003Ek__BackingField;
		if ((object)base._003COwner_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
			float2 result = default(float2);
			return result;
		}
		return (float2)new NullReferenceException();
	}

	protected virtual bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0125: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0142;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									DealDamage(component);
								}
								goto IL_0142;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0142:
		return false;
	}

	protected virtual bool OnBulletOverlapsPlayer(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_01dc: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController component = gameObject.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
				if ((object)component != null)
				{
					if (!component._isDead && !component.IsDisconnectedFromOnlinePlay)
					{
						bool flag;
						if ((object)base._003COwner_003Ek__BackingField != null)
						{
							object obj = (object)component - (object)base._003COwner_003Ek__BackingField;
							flag = obj == null;
						}
						else
						{
							flag = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
						}
						if (!flag)
						{
							if (second != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
								GameObject gameObject2 = default(GameObject);
								if ((object)gameObject2 != null)
								{
									Projectile component2 = gameObject2.GetComponent<Projectile>();
									if ((object)component2 != null && component2._objectsHit != null)
									{
										if (((HashSet<object>)(object)component2._objectsHit).Contains((object)component))
										{
											goto IL_01c8;
										}
										if (component2._objectsHit != null)
										{
											bool flag2 = ((HashSet<object>)(object)component2._objectsHit).AddIfNotPresent((object)component);
											component2.OnHasHitAnotherPlayerObject((IDamageable)component);
											return true;
										}
									}
								}
							}
							goto IL_01ce;
						}
					}
					goto IL_01c8;
				}
			}
		}
		goto IL_01ce;
		IL_01ce:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01c8:
		return false;
	}

	protected virtual bool OnSecondaryBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0169: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0186;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = SecondaryPPower();
									WeaponData currentWeaponData = _currentWeaponData;
									HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
									float knockback = Knockback;
									float num2 = default(float);
									component.GetDamaged(num2, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
									float num3 = num2 + _003CStatsInflictedDamage_003Ek__BackingField;
									_003CStatsInflictedDamage_003Ek__BackingField = num3;
								}
								goto IL_0186;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0186:
		return false;
	}

	protected virtual bool OnSecondaryBulletOverlapsEnemyCurse(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0169: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0186;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = SecondaryCursePPower();
									WeaponData currentWeaponData = _currentWeaponData;
									HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
									float knockback = Knockback;
									float num2 = default(float);
									component.GetDamaged(num2, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
									float num3 = num2 + _003CStatsInflictedDamage_003Ek__BackingField;
									_003CStatsInflictedDamage_003Ek__BackingField = num3;
								}
								goto IL_0186;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0186:
		return false;
	}

	protected virtual bool OnBulletOverlapsEnemyRetaliation(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0125: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0142;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									DealDamageRetaliation(component);
								}
								goto IL_0142;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0142:
		return false;
	}

	protected virtual bool OnBulletOverlapsDestructible(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0138: Expected I4, but got O
		if (second != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				Projectile component = gameObject.GetComponent<Projectile>();
				if (first != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					GameObject gameObject2 = default(GameObject);
					if ((object)gameObject2 != null)
					{
						Destructible component2 = gameObject2.GetComponent<Destructible>();
						if ((object)component != null)
						{
							if (!component.HasAlreadyHitObject(component2))
							{
								float num = PPower();
								if (_currentWeaponData == null || (object)component2 == null)
								{
									goto IL_012a;
								}
								float value = default(float);
								component2.GetDamaged(value, HitVfxType.None, 0f, WeaponType.VOID, hasKb: false);
							}
							return false;
						}
					}
				}
			}
		}
		goto IL_012a;
		IL_012a:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected virtual bool OnBulletOverlapsWall(CallbackContext context, ArcadeColliderType bullet, ArcadeColliderType tile)
	{
		//IL_0034: Expected I, but got O
		//IL_0059: Expected I, but got O
		//IL_0069: Expected O, but got I
		//IL_00f3: Expected I4, but got O
		//IL_00a5: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		Projectile component = gameObject.GetComponent<Projectile>();
		nint num = (nint)typeof(PhaserTile);
		if (tile != null)
		{
			nint num2 = (nint)tile;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v5 (Il2CppClass<PhaserTile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v6 (Il2CppClass<ArcadeColliderType>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v5 (Il2CppClass<PhaserTile>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v6 (Il2CppClass<ArcadeColliderType>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rax_v13+FFFFFFF8+v99 @ rax_v12*8]");
				if (0 == (nint)typeof(PhaserTile))
				{
					goto IL_00d2;
				}
			}
			InvalidCastException ex = new InvalidCastException();
			return (byte)(int)ex != 0;
		}
		goto IL_00d2;
		IL_00d2:
		component.OnHasHitWallPhaser((PhaserTile)tile);
		return false;
	}

	public override void InternalUpdate()
	{
		//IL_00bf: Expected O, but got F4
		//IL_0018: Expected O, but got I4
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_009c->IL00a7: Incompatible stack heights: 1 vs 0
		//IL_00a1->IL00a1: Incompatible stack heights: 1 vs 0
		object obj = Time.deltaTime;
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		object obj2 = default(object);
		float num = (float)obj2 + _003CStatsLifetime_003Ek__BackingField;
		_003CStatsLifetime_003Ek__BackingField = num;
		bool flag = (nint)_spawnedProjectiles < 0;
		object obj3 = spawnedProjectiles._size - 1;
		if (!flag)
		{
			Projectile[] items;
			do
			{
				List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
				bool flag2 = (nint)obj3 >= spawnedProjectiles2._size;
				items = spawnedProjectiles2._items;
				items[obj3].InternalUpdate();
				obj3--;
			}
			while ((nint)items[obj3] >= 0);
		}
	}

	public virtual int ActiveProjectileCount()
	{
		if (_projectilePool == null)
		{
			return 0;
		}
		return _projectilePool.countActive();
	}

	public void AddSpawnedProjectile(Projectile projectile)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1730");
		object obj = default(object);
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6A10");
		}
	}

	public void DespawnProjectile(Projectile projectile)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1730");
		object obj = default(object);
		if (obj != null)
		{
			bool flag = ((List<object>)(object)_spawnedProjectiles).Remove((object)projectile);
		}
	}

	public override void Cleanup()
	{
		if (_firingAnimEvent != null)
		{
			_firingAnimEvent.Cancel();
		}
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
		if (_lastShotTimer != null)
		{
			_lastShotTimer.Cancel();
		}
		if (_projectilePool != null)
		{
			_projectilePool.Cleanup();
		}
		if (_secondaryPool != null)
		{
			_secondaryPool.Cleanup();
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	public Vector2 GetPlayerCurrentDirection()
	{
		Vector2 result = default(Vector2);
		if ((object)base._003COwner_003Ek__BackingField != null)
		{
			return result;
		}
		return (Vector2)new NullReferenceException();
	}

	public virtual bool LevelUp()
	{
		//IL_0005: Expected I, but got O
		//IL_0015: Expected O, but got I
		//IL_0025: Expected O, but got I
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+208]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+210]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v3 @ rax_v1 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	public void EnableAdept()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		IsAdept = true;
		float num = currentWeaponData._003Cinterval_003Ek__BackingField * 0.5f;
		currentWeaponData._003Cinterval_003Ek__BackingField = num;
	}

	public override bool LevelUp(bool skipFire)
	{
		//IL_0652: Expected I4, but got O
		//IL_0249: Expected I4, but got O
		//IL_05e5: Expected I4, but got O
		//IL_0480: Expected I4, but got O
		//IL_050f: Expected I4, but got O
		if (!base.GetDataForLevel(base._equipmentType, base._003CLevel_003Ek__BackingField, out var _, upgradeExistingData: false))
		{
			goto IL_05ff;
		}
		if (_currentJsonDataObject != null)
		{
			object currentWeaponData = _currentJsonDataObject.ToObject<object>();
			_currentWeaponData = (WeaponData)currentWeaponData;
			if (_currentWeaponData == null)
			{
				goto IL_05ff;
			}
			float newWeaponPower = default(float);
			if (IsAdept)
			{
				WeaponData currentWeaponData2 = _currentWeaponData;
				newWeaponPower = (currentWeaponData2._003Cinterval_003Ek__BackingField *= 0.5f);
			}
			WeaponData currentWeaponData3 = _currentWeaponData;
			if (_currentWeaponData != null)
			{
				int num = currentWeaponData3._003Camount_003Ek__BackingField + _beginningAmount;
				currentWeaponData3._003Camount_003Ek__BackingField = num;
				GameManager gameMan = _gameMan;
				if ((object)_gameMan != null)
				{
					float heartOfFirePower = HeartOfFirePower;
					if (gameMan._arcanaManager != null)
					{
						gameMan._arcanaManager.UpdateHeartOfFirePower(newWeaponPower);
						int num2 = base._003CLevel_003Ek__BackingField + 1;
						base._003CLevel_003Ek__BackingField = num2;
						if (!skipFire)
						{
							ResetFiringTimer();
						}
						WeaponData currentWeaponData4 = _currentWeaponData;
						if (_currentWeaponData != null)
						{
							if (!currentWeaponData4._003CisPowerUp_003Ek__BackingField && !skipFire)
							{
								Fire();
							}
							if (_skipAddingEvolution)
							{
								goto IL_05f9;
							}
							WeaponData currentWeaponData5 = _currentWeaponData;
							if (_currentWeaponData != null)
							{
								if ((object)currentWeaponData5._003CaddEvolvedWeapon_003Ek__BackingField != null)
								{
									if ((object)currentWeaponData5._003CaddEvolvedWeapon_003Ek__BackingField == null)
									{
										goto IL_0605;
									}
									if (_levelUpFactory == null)
									{
										goto IL_0644;
									}
									WeaponType weapon = (WeaponType)((object?)currentWeaponData5._003CaddEvolvedWeapon_003Ek__BackingField >> 32);
									_levelUpFactory.AddLateWeapon(weapon, base._003COwner_003Ek__BackingField);
								}
								WeaponData currentWeaponData6 = _currentWeaponData;
								if (_currentWeaponData != null)
								{
									if ((object)currentWeaponData6._003CaddNormalWeapon_003Ek__BackingField == null || _003CSkipAddingNormalWeapon_003Ek__BackingField)
									{
										goto IL_0546;
									}
									VampireSurvivors.Objects.Characters.CharacterController characterController = base._003COwner_003Ek__BackingField;
									if ((object)base._003COwner_003Ek__BackingField != null)
									{
										CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
										if ((object)characterController._weaponsManager != null)
										{
											Func<Equipment, WeaponType> selector = _003C_003Ec._003C_003E9__140_0;
											if (_003C_003Ec._003C_003E9__140_0 == null)
											{
												selector = (_003C_003Ec._003C_003E9__140_0 = delegate(Equipment x)
												{
													//IL_0035: Expected I4, but got O
													if ((object)x == null)
													{
														NullReferenceException ex2 = new NullReferenceException();
														return (WeaponType)ex2;
													}
													return x._equipmentType;
												});
											}
											IEnumerable<WeaponType> source = Enumerable.Select(((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField, selector);
											IEnumerable<WeaponType> enumerable = Enumerable.Select((IEnumerable<Equipment>)source, selector);
											VampireSurvivors.Objects.Characters.CharacterController characterController2 = base._003COwner_003Ek__BackingField;
											if ((object)base._003COwner_003Ek__BackingField != null)
											{
												CharacterAccessoriesManager accessoriesManager = characterController2._accessoriesManager;
												if ((object)characterController2._accessoriesManager != null)
												{
													Func<Equipment, WeaponType> selector2 = _003C_003Ec._003C_003E9__140_1;
													if (_003C_003Ec._003C_003E9__140_1 == null)
													{
														selector2 = (_003C_003Ec._003C_003E9__140_1 = delegate(Equipment x)
														{
															//IL_0035: Expected I4, but got O
															if ((object)x == null)
															{
																NullReferenceException ex2 = new NullReferenceException();
																return (WeaponType)ex2;
															}
															return x._equipmentType;
														});
													}
													IEnumerable<WeaponType> source2 = Enumerable.Select(((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField, selector2);
													IEnumerable<WeaponType> collection = Enumerable.Select((IEnumerable<Equipment>)source2, selector2);
													if (enumerable != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v36 (System.Collections.Generic.IEnumerable`1<VampireSurvivors.Data.WeaponType>)+18]");
														((List<System.Int32Enum>)enumerable).InsertRange(0, (IEnumerable<System.Int32Enum>)collection);
														WeaponData currentWeaponData7 = _currentWeaponData;
														if (_currentWeaponData != null)
														{
															if ((object)currentWeaponData7._003CaddNormalWeapon_003Ek__BackingField == null)
															{
																goto IL_0605;
															}
															int index = (object?)currentWeaponData7._003CaddNormalWeapon_003Ek__BackingField >> 32;
															((List<WeaponType>)enumerable).InsertRange(index, collection);
															object obj = default(object);
															if (obj != null)
															{
																goto IL_0546;
															}
															WeaponData currentWeaponData8 = _currentWeaponData;
															if (_currentWeaponData != null)
															{
																if ((object)currentWeaponData8._003CaddNormalWeapon_003Ek__BackingField == null)
																{
																	goto IL_0605;
																}
																int index2 = (object?)currentWeaponData8._003CaddNormalWeapon_003Ek__BackingField >> 32;
																if (_signalBus != null)
																{
																	((List<WeaponType>)(object)_signalBus).InsertRange(index2, collection);
																	goto IL_0546;
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
		goto IL_0644;
		IL_0605:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		goto IL_0644;
		IL_0546:
		WeaponData currentWeaponData9 = _currentWeaponData;
		if (_currentWeaponData != null)
		{
			if ((object)currentWeaponData9._003CexcludeWeapon_003Ek__BackingField != null)
			{
				if ((object)currentWeaponData9._003CexcludeWeapon_003Ek__BackingField == null)
				{
					goto IL_0605;
				}
				if (_levelUpFactory == null)
				{
					goto IL_0644;
				}
				WeaponType t = (WeaponType)((object?)currentWeaponData9._003CexcludeWeapon_003Ek__BackingField >> 32);
				_levelUpFactory.ForceExclude(t);
			}
			goto IL_05f9;
		}
		goto IL_0644;
		IL_05ff:
		return false;
		IL_05f9:
		return true;
		IL_0644:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public virtual void HandlePlayerTeleport(float2 destinationPos)
	{
	}

	public virtual float PArea()
	{
		float num = base._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = default(object);
		return (float)obj * currentWeaponData._003Carea_003Ek__BackingField;
	}

	public virtual int PBounces()
	{
		return _bonusBounces + _bounces;
	}

	public virtual float PAmount()
	{
		float num = base._003COwner_003Ek__BackingField.PAmount();
		float num2 = default(float);
		bool flag = !(10f > num2);
		float num3 = 10f;
		if (!flag)
		{
			num3 = num2;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		return (float)currentWeaponData._003Camount_003Ek__BackingField + num3;
	}

	public virtual float SecondaryPAmount()
	{
		//IL_0005: Expected I, but got O
		//IL_0015: Expected O, but got I
		//IL_0025: Expected O, but got I
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+408]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+410]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ rax_v1 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	public virtual float PPower()
	{
		if ((object)base._003COwner_003Ek__BackingField != null)
		{
			float num = base._003COwner_003Ek__BackingField.PPowerFinal();
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null && (object)base._003COwner_003Ek__BackingField != null)
			{
				float bloodlineDamage = base._003COwner_003Ek__BackingField.BloodlineDamage;
				float num2 = currentWeaponData._003Cpower_003Ek__BackingField * num;
				return num + num2;
			}
		}
		throw new NullReferenceException();
	}

	public virtual float SecondaryPPower()
	{
		if ((object)base._003COwner_003Ek__BackingField != null)
		{
			float num = base._003COwner_003Ek__BackingField.PPowerFinal();
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null && (object)base._003COwner_003Ek__BackingField != null)
			{
				float bloodlineDamage = base._003COwner_003Ek__BackingField.BloodlineDamage;
				float num2 = currentWeaponData._003CsecondaryPower_003Ek__BackingField * num;
				return num + num2;
			}
		}
		throw new NullReferenceException();
	}

	public virtual float SecondaryCursePPower()
	{
		if ((object)base._003COwner_003Ek__BackingField != null)
		{
			float num = base._003COwner_003Ek__BackingField.PPowerFinal();
			WeaponData currentWeaponData = _currentWeaponData;
			if (_currentWeaponData != null && (object)base._003COwner_003Ek__BackingField != null)
			{
				float num2 = base._003COwner_003Ek__BackingField.PCurse();
				if ((object)base._003COwner_003Ek__BackingField != null)
				{
					float bloodlineDamage = base._003COwner_003Ek__BackingField.BloodlineDamage;
					float num3 = currentWeaponData._003CsecondaryPower_003Ek__BackingField * num;
					float num4 = num3 * num;
					return num + num4;
				}
			}
		}
		throw new NullReferenceException();
	}

	public virtual float PSpeed()
	{
		float num = base._003COwner_003Ek__BackingField.PSpeed();
		float num2 = default(float);
		bool flag = !(5f > num2);
		float num3 = 5f;
		if (!flag)
		{
			num3 = num2;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num4 = num3 * currentWeaponData._003Cspeed_003Ek__BackingField;
		VampireSurvivors.Objects.Characters.CharacterController characterController = base._003COwner_003Ek__BackingField;
		if ((object)base._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = base._003COwner_003Ek__BackingField;
			if (characterController2._sineSpeed != null)
			{
				float value = characterController2._sineSpeed.Value;
				num4 *= value;
			}
		}
		return num4;
	}

	public virtual float PHitBoxDelayOverSpeed()
	{
		float num = PSpeed();
		float num2 = default(float);
		bool flag = !(0.001f < num2);
		float num3 = 0.001f;
		if (!flag)
		{
			num3 = num2;
		}
		float hitBoxDelay = HitBoxDelay;
		return hitBoxDelay * num3;
	}

	public virtual float PSpeedRepeatInterval()
	{
		float num = PSpeed();
		float num2 = default(float);
		bool flag = !(0.001f < num2);
		float num3 = 0.001f;
		if (!flag)
		{
			num3 = num2;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num4 = 1f / num3;
		return num4 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
	}

	public virtual float PInterval()
	{
		float num4;
		float num5;
		float num2 = default(float);
		if (HasCooldownSpeedBonus)
		{
			if ((object)base._003COwner_003Ek__BackingField == null)
			{
				goto IL_0145;
			}
			float num = base._003COwner_003Ek__BackingField.PSpeed();
			bool flag = 1f > num2;
			float num3 = 1f;
			if (!flag)
			{
				bool flag2 = !(num2 > 5f);
				num3 = 5f;
				num4 = 5f;
				num5 = num2;
				if (flag2)
				{
					goto IL_0150;
				}
			}
			num4 = num3;
			num5 = num3;
		}
		else
		{
			num4 = num2;
			num5 = 1f;
		}
		goto IL_0150;
		IL_0145:
		throw new NullReferenceException();
		IL_0150:
		bool flag3 = (object)base._003COwner_003Ek__BackingField == null;
		num2 = num4;
		if (!flag3)
		{
			float num6 = base._003COwner_003Ek__BackingField.PCooldownFinal();
			WeaponData currentWeaponData = _currentWeaponData;
			bool flag4 = _currentWeaponData == null;
			num2 = num4;
			if (!flag4)
			{
				float num7 = currentWeaponData._003Cinterval_003Ek__BackingField / num5;
				return num7 * num4;
			}
		}
		goto IL_0145;
	}

	public virtual float PDuration()
	{
		VampireSurvivors.Objects.Characters.CharacterController characterController = base._003COwner_003Ek__BackingField;
		float num2 = default(float);
		if ((object)base._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = base._003COwner_003Ek__BackingField;
			if (characterController2._sineDuration != null)
			{
				float num = characterController2.PDuration();
				VampireSurvivors.Objects.Characters.CharacterController characterController3 = base._003COwner_003Ek__BackingField;
				float value = characterController3._sineDuration.Value;
				num2 = value * num2;
				goto IL_011b;
			}
		}
		float num3 = base._003COwner_003Ek__BackingField.PDuration();
		goto IL_011b;
		IL_011b:
		bool flag = !(5f > num2);
		float num4 = 5f;
		if (!flag)
		{
			num4 = num2;
		}
		float duration = Duration;
		return duration * num4;
	}

	public virtual void ParadoxFire()
	{
		Fire(skipTriggers: true);
	}

	public virtual void Fire()
	{
		Fire(false);
	}

	public virtual void Fire(bool skipTriggers = false)
	{
		//IL_0041: Invalid comparison between O and F4
		//IL_0052: Expected F4, but got O
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_0218: Invalid comparison between O and F4
		//IL_0073: Invalid comparison between O and F4
		//IL_0084: Expected F4, but got O
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00f0: Expected F4, but got O
		//IL_01cb: Invalid comparison between F4 and I4
		float2 position = base._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = FireOneProjectile(vector, 0, _targetTransform);
		float num = PAmount();
		bool flag = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
		float num2 = (float)vector;
		if (!flag)
		{
			float num3 = PAmount();
			bool flag2 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
			num2 = (float)vector;
			if (!flag2)
			{
				bool flag3 = true;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					object obj = flag3 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					if ((nint)obj <= 0)
					{
						Vector2 playerPos = PlayerPos;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
						num2 = (float)playerPos;
					}
					else
					{
						_003C_003Ec__DisplayClass156_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass156_0();
						CS_0024_003C_003E8__locals8._003C_003E4__this = this;
						CS_0024_003C_003E8__locals8.localIndex = (flag3 ? 1 : 0);
						WeaponData currentWeaponData2 = _currentWeaponData;
						Action onComplete = delegate
						{
							//IL_012f: Expected O, but got I4
							//IL_00b4: Expected O, but got I
							//IL_00e9: Expected I, but got O
							//IL_0079->IL00f8: Incompatible stack heights: 1 vs 0
							//IL_009e->IL00f8: Incompatible stack heights: 1 vs 0
							//IL_00dc->IL00f8: Incompatible stack heights: 1 vs 0
							if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
							{
								GameObject gameObject = CS_0024_003C_003E8__locals8._003C_003E4__this.gameObject;
								if ((object)gameObject != null)
								{
									bool flag4 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj3 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj3 == null)
									{
										return;
									}
									GameObject gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals8._003C_003E4__this;
									if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
											float2 position2 = ((ArcadeSprite)0).position;
											Weapon weapon = CS_0024_003C_003E8__locals8._003C_003E4__this;
											if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
											{
												nint num9 = (nint)gameObject2;
												Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v246 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
												return;
											}
										}
									}
								}
							}
							throw new NullReferenceException();
						};
						float num4 = (float)(flag3 ? 1 : 0) * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
						num2 = num4 * 0.001f;
						Timer lastShotTimer = Timers.Register(num2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_lastShotTimer = lastShotTimer;
					}
					flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
					float num5 = PAmount();
				}
				while (num2 > (float)(flag3 ? 1 : 0));
			}
		}
		float num6 = PInterval();
		float num7 = _lastFiringInterval - num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = num7 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num8 = PInterval();
			_lastFiringInterval = num2;
			ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			base._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public virtual Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null && (object)core._stage != null)
		{
			if (core._stage.IsCharacterNearYourPlayer(base._003COwner_003Ek__BackingField))
			{
				BulletPool bulletPool = default(BulletPool);
				bool flag = bulletPool != null;
				BulletPool bulletPool2 = bulletPool;
				if (!flag)
				{
					bulletPool2 = _projectilePool;
					if (_projectilePool == null)
					{
						goto IL_0187;
					}
				}
				float2 pos2 = default(float2);
				Projectile projectile = bulletPool2.SpawnAt(pos2, this, index);
				if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
				{
					if ((object)target != null && ((UnityEngine.Object)target).m_CachedPtr != (IntPtr)0)
					{
						projectile.SetTarget(target);
					}
					else
					{
						projectile.SetNullTarget();
					}
					BaseBody body = projectile.body;
					if (projectile.body != null)
					{
						if (body._transform == null)
						{
							goto IL_0187;
						}
						body._transform.ForceFullReupdate();
					}
				}
				return projectile;
			}
			return null;
		}
		goto IL_0187;
		IL_0187:
		return (Projectile)(object)new NullReferenceException();
	}

	public virtual Projectile FireOneProjectileIgnoreDistanceToPlayer(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		BulletPool bulletPool = default(BulletPool);
		bool flag = bulletPool != null;
		BulletPool bulletPool2 = bulletPool;
		if (!flag)
		{
			bulletPool2 = _projectilePool;
			if (_projectilePool == null)
			{
				goto IL_010a;
			}
		}
		float2 pos2 = default(float2);
		Projectile projectile = bulletPool2.SpawnAt(pos2, this, index);
		if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
		{
			if ((object)target != null && ((UnityEngine.Object)target).m_CachedPtr != (IntPtr)0)
			{
				projectile.SetTarget(target);
			}
			else
			{
				projectile.SetNullTarget();
			}
			BaseBody body = projectile.body;
			if (projectile.body != null)
			{
				if (body._transform == null)
				{
					goto IL_010a;
				}
				body._transform.ForceFullReupdate();
			}
		}
		return projectile;
		IL_010a:
		return (Projectile)(object)new NullReferenceException();
	}

	public Projectile FireOneBullet(float x, float y, int index, Transform target)
	{
		//IL_0005: Expected I, but got O
		//IL_0015: Expected O, but got I
		//IL_0025: Expected O, but got I
		nint num = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+4D8]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rax_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+4E0]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ r10_v1 (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	public virtual void DealDamage(IDamageable other)
	{
		float num = PPower();
		float num2 = CalcCritMul();
		object obj = default(object);
		float damage = (float)obj * (float)obj;
		DealDamage(other, damage);
	}

	public virtual void DealDamageRetaliation(IDamageable other)
	{
		//IL_0108: Expected I, but got O
		float num = base._003COwner_003Ek__BackingField.PArmor();
		object obj = default(object);
		float num4;
		if ((nint)obj > 0)
		{
			float num2 = base._003COwner_003Ek__BackingField.PArmor();
			float num3 = (float)obj * 0.1f;
			num4 = num3 + 1f;
		}
		else
		{
			num4 = 1f;
		}
		float num5 = PPower();
		nint num6 = (nint)this;
		float damage = (float)obj * num4;
		DealDamage(other, damage);
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		if (arcanaManager._003CHasDivineBloodline_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj2 = default(object);
			if (obj2 != null)
			{
				GameManager core2 = GM.Core;
				core2._arcanaManager.IncreaseBloodlineBonus(base._003COwner_003Ek__BackingField);
			}
		}
	}

	public virtual void DealDamage(IDamageable other, float damage)
	{
		if (other == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			if (_currentWeaponData != null)
			{
			}
			float knockback = Knockback;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAD810");
			float num = damage + _003CStatsInflictedDamage_003Ek__BackingField;
			_003CStatsInflictedDamage_003Ek__BackingField = num;
		}
	}

	public unsafe void DamageAllEnemies(float value)
	{
		//IL_027d: Invalid comparison between F4 and I4
		//IL_0228: Expected O, but got I4
		//IL_0257: Expected O, but got F4
		//IL_0261: Expected F4, but got O
		//IL_0269: Expected O, but got F4
		//IL_021a: Expected O, but got I4
		//IL_0324->IL0329: Incompatible stack heights: 5 vs 0
		//IL_026e->IL0329: Incompatible stack heights: 5 vs 0
		bool flag = value > 0f;
		float num = value;
		if (!flag)
		{
			float num2 = PPower();
			float num3 = default(float);
			num = num3;
		}
		GameManager core = GM.Core;
		PhysicsGroup enemies = core.Enemies;
		Component component = null;
		HashSet<object>.Enumerator children = (HashSet<object>.Enumerator)((Group)enemies).children;
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		object obj2 = default(object);
		HashSet<object>.Enumerator enumerator2 = default(HashSet<object>.Enumerator);
		while (enumerator.MoveNext())
		{
			EnemyController component2 = ((Component)null).GetComponent<EnemyController>();
			GameManager core2 = GM.Core;
			bool flag2 = (object)GM.Core == null;
			Stage stage = core2._stage;
			bool flag3 = (object)core2._stage == null;
			bool flag4 = (object)component2 == null;
			Transform cachedTrans = ((ArcadeSprite)component2).CachedTrans;
			bool flag5 = (object)cachedTrans == null;
			bool flag6 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
			Component ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
			object obj;
			if (component2.body != null)
			{
				BaseBody body = component2.body;
				ArcadeTransform arcadeTransform = body._transform;
				arcadeTransform.position = (float2)ret;
				obj = obj2;
				component = ret;
			}
			else
			{
				obj = obj2;
				component = ret;
			}
			Component component3 = component;
			Rect containmentExactRect = stage._containmentExactRect;
			object obj4;
			if (System.Runtime.CompilerServices.Unsafe.As<Component, UIntPtr>(ref component3) >= System.Runtime.CompilerServices.Unsafe.As<Rect, UIntPtr>(ref containmentExactRect))
			{
				children = (HashSet<object>.Enumerator)((object)enumerator2 + (object)stage._containmentExactRect);
				if (System.Runtime.CompilerServices.Unsafe.As<HashSet<object>.Enumerator, UIntPtr>(ref children) > System.Runtime.CompilerServices.Unsafe.As<Component, UIntPtr>(ref component))
				{
					bool flag7 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<HashSet<object>.Enumerator, UIntPtr>(ref enumerator2);
					children = enumerator2;
					if (!flag7)
					{
						children = (HashSet<object>.Enumerator)((object)enumerator2 + (object)enumerator2);
						bool flag8 = System.Runtime.CompilerServices.Unsafe.As<HashSet<object>.Enumerator, UIntPtr>(ref children) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
						object obj3 = (object)children - obj;
						bool flag9 = obj3 == null;
						bool flag10 = !flag8;
						bool flag11 = !flag9;
						obj4 = flag11 & flag10;
						goto IL_030c;
					}
				}
			}
			obj4 = 0;
			goto IL_030c;
			IL_030c:
			if (obj4 != null)
			{
				component2.GetDamaged(num, HitVfxType.None, 0f, WeaponType.VOID, hasKb: false);
				children = (HashSet<object>.Enumerator)(num + _003CStatsInflictedDamage_003Ek__BackingField);
				_003CStatsInflictedDamage_003Ek__BackingField = (float)children;
				component = (Component)num;
			}
		}
	}

	public virtual void StandardCritical(ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		//IL_0142: Expected O, but got I
		//IL_01a3: Invalid comparison between F4 and I
		//IL_01ea: Expected I, but got O
		//IL_01f2: Expected I, but got O
		//IL_0202: Expected O, but got I
		//IL_023e: Expected O, but got I
		//IL_027b: Expected O, but got I
		//IL_02bf: Expected O, but got I4
		//IL_02b1: Expected O, but got I4
		//IL_03c2: Expected I, but got O
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)first;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rax_v37+FFFFFFF8+v61 @ rax_v8*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj3 = 1;
				goto IL_033f;
			}
		}
		obj3 = 0;
		goto IL_033f;
		IL_033f:
		bool flag = obj3 == null;
		ArcadeColliderType arcadeColliderType = null;
		if (!flag)
		{
			arcadeColliderType = first;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rdi_v5 (ArcadeColliderType)+260]");
		if ((nint)0 != 0)
		{
			return;
		}
		List<float> critChancesArray = _critChancesArray;
		int critIndex = _critIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num4 = (int)((nint)critIndex % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v8 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num4 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v8 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj4 = 0;
			int critIndex2 = _critIndex + 1;
			_critIndex = critIndex2;
			WeaponData currentWeaponData = _currentWeaponData;
			float num5 = base._003COwner_003Ek__BackingField.PLuck();
			object obj5 = default(object);
			float num6 = (float)obj5 * currentWeaponData._003CcritChance_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ rcx_v9+20+v94 @ rdx_v7 (System.Int32)*4]");
			float num7;
			if (num6 > 0f)
			{
				WeaponData currentWeaponData2 = _currentWeaponData;
				num7 = currentWeaponData2._003CcritMul_003Ek__BackingField * ArcanaManager.CritMul;
			}
			else
			{
				num7 = 1f;
			}
			nint num8 = (nint)typeof(Projectile);
			nint num9 = (nint)second;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ r8_v6 (Il2CppClass<ArcadeColliderType>)+130]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			if (num10 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ r8_v6 (Il2CppClass<ArcadeColliderType>)+C8]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v19+FFFFFFF8+v103 @ rax_v18*8]");
				if (0 == (nint)typeof(Projectile))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v19+FFFFFFF8+v516 @ rcx_v13*8]");
					object obj9 = ((0 != (nint)typeof(Projectile)) ? ((object)0) : ((object)1));
					bool flag2 = obj9 == null;
					ArcadeColliderType arcadeColliderType2 = null;
					if (!flag2)
					{
						arcadeColliderType2 = second;
					}
					if (!((Projectile)arcadeColliderType2).HasAlreadyHitObject((IDamageable)arcadeColliderType))
					{
						float num11 = PPower();
						WeaponData currentWeaponData3 = _currentWeaponData;
						float num12 = num6 * num7;
						if (_currentWeaponData != null)
						{
							HitVfxType hitVfxType = currentWeaponData3._003ChitVFX_003Ek__BackingField;
						}
						else
						{
							HitVfxType hitVfxType = HitVfxType.Default;
						}
						float knockback = Knockback;
						nint num13 = (nint)arcadeColliderType;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v381 @ rdx_v15 (Il2CppClass<ArcadeColliderType>)+3E8] (should have been resolved before IL gen)");
						float num14 = num12 + _003CStatsInflictedDamage_003Ek__BackingField;
						_003CStatsInflictedDamage_003Ek__BackingField = num14;
					}
					return;
				}
			}
			throw new NullReferenceException();
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
	}

	public void CheckBeginningArcana()
	{
		if (_beginningArcana)
		{
			return;
		}
		GameManager gameMan = _gameMan;
		List<WeaponType> list = gameMan._arcanaManager.Beginning(base._003COwner_003Ek__BackingField);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		if ((nint)0 > (nint)0)
		{
			GameManager gameMan2 = _gameMan;
			List<WeaponType> list2 = gameMan2._arcanaManager.Beginning(base._003COwner_003Ek__BackingField);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			object obj = default(object);
			if (obj != null)
			{
				int beginningAmount = _beginningAmount + 3;
				_beginningAmount = beginningAmount;
				WeaponData currentWeaponData = _currentWeaponData;
				_beginningArcana = true;
				int num = currentWeaponData._003Camount_003Ek__BackingField + 3;
				currentWeaponData._003Camount_003Ek__BackingField = num;
			}
		}
	}

	public bool HasActiveArcanaOfType(ArcanaType arcanaType)
	{
		//IL_0073: Expected I4, but got O
		GameManager gameMan = _gameMan;
		if ((object)_gameMan != null)
		{
			ArcanaManager arcanaManager = gameMan._arcanaManager;
			if (gameMan._arcanaManager != null && arcanaManager._003CActiveArcanas_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
				bool result = default(bool);
				return result;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool CheckFreeze()
	{
		//IL_00e7: Expected I4, but got O
		//IL_0087: Invalid comparison between F4 and O
		//IL_00a5: Invalid comparison between F4 and I4
		VampireSurvivors.Objects.Characters.CharacterController characterController = base._003COwner_003Ek__BackingField;
		if ((object)base._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			float chanceFromArray = GetChanceFromArray();
			if ((object)base._003COwner_003Ek__BackingField != null)
			{
				float num = base._003COwner_003Ek__BackingField.PLuck();
				object obj = default(object);
				float num2 = (float)obj * _003CFreezeChance_003Ek__BackingField;
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
				float num3 = num2 - (float)obj;
				bool flag2 = num3 == 0f;
				bool flag3 = !flag;
				bool flag4 = !flag2;
				return flag4 & flag3;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public bool CheckDefang()
	{
		//IL_00eb: Expected I4, but got O
		VampireSurvivors.Objects.Characters.CharacterController characterController = base._003COwner_003Ek__BackingField;
		if ((object)base._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
		{
			float chanceFromArray = GetChanceFromArray();
			float defangChance = DefangChance;
			if ((object)base._003COwner_003Ek__BackingField != null)
			{
				float num = base._003COwner_003Ek__BackingField.PLuck();
				object obj2 = default(object);
				object obj = obj2 * obj2;
				bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
				object obj3 = obj - obj2;
				bool flag2 = obj3 == null;
				bool flag3 = !flag;
				bool flag4 = !flag2;
				return flag4 & flag3;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public virtual void CopyAccumulatedLimitBreaks(Weapon from, Weapon to)
	{
		if (from.accumulatedLimitBreaks != null)
		{
			from.accumulatedLimitBreaks.ApplyDataToWeapon(to._currentWeaponData);
		}
		to.accumulatedLimitBreaks.AccumulateData(from.accumulatedLimitBreaks);
		int num = to._003CLimitBreakLevel_003Ek__BackingField + from._003CLimitBreakLevel_003Ek__BackingField;
		to._003CLimitBreakLevel_003Ek__BackingField = num;
	}

	public virtual bool ApplyLimitBreak(WeightedLimitBreak weightedLimitBreak)
	{
		//IL_0155: Expected I4, but got O
		if (weightedLimitBreak.KeyValues != null)
		{
			weightedLimitBreak.KeyValues.ApplyDataToWeapon(_currentWeaponData);
		}
		accumulatedLimitBreaks.AccumulateData(weightedLimitBreak.KeyValues);
		ResetFiringTimer();
		WeaponData currentWeaponData = _currentWeaponData;
		int num = _003CLimitBreakLevel_003Ek__BackingField + 1;
		_003CLimitBreakLevel_003Ek__BackingField = num;
		if (!currentWeaponData._003CisPowerUp_003Ek__BackingField)
		{
			Fire();
		}
		if (!_skipAddingEvolution)
		{
			LimitBreakData keyValues = weightedLimitBreak.KeyValues;
			if (weightedLimitBreak.KeyValues != null && (object)keyValues._003CaddEvolvedWeapon_003Ek__BackingField != null)
			{
				GameManager gameMan = _gameMan;
				LimitBreakData keyValues2 = weightedLimitBreak.KeyValues;
				if ((object)keyValues2._003CaddEvolvedWeapon_003Ek__BackingField == null)
				{
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					bool result = default(bool);
					return result;
				}
				WeaponType weapon = (WeaponType)((object?)keyValues2._003CaddEvolvedWeapon_003Ek__BackingField >> 32);
				gameMan._levelUpFactory.AddLateWeapon(weapon, base._003COwner_003Ek__BackingField);
			}
		}
		bool flag = (nint)weightedLimitBreak.KeyValues < 0;
		bool flag2 = weightedLimitBreak.KeyValues == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	public virtual Projectile SpawnExplosionAt(float2 pos, int enemiesHit = 0, int damage = 1, float area = 1f)
	{
		//IL_01ea: Expected I, but got O
		//IL_012e: Expected I, but got O
		//IL_02ed: Expected I, but got O
		if (_secondaryPool != null)
		{
			goto IL_0347;
		}
		Factory add;
		ArcadeColliderType enemies;
		ArcadePhysicsCallback collideCallback;
		ArcadeColliderType secondaryPool2;
		if ((object)_projectileFactory != null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(_explosionType);
			int projectilePoolSize = ProjectilePoolSize;
			BulletPool secondaryPool = new BulletPool(projectilePrefab, projectilePoolSize);
			_secondaryPool = secondaryPool;
			if (_secondaryOvarlapDamageType != WeaponType.CURSE)
			{
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						ArcadePhysics physics = s_scene.physics;
						if ((object)s_scene.physics != null)
						{
							add = physics.add;
							GameManager core = GM.Core;
							if ((object)GM.Core != null)
							{
								enemies = core.Enemies;
								nint method = default(nint);
								collideCallback = new ArcadePhysicsCallback(this, method);
								nint num = (nint)this;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+370]");
								method = 0;
								secondaryPool2 = _secondaryPool;
								goto IL_03da;
							}
						}
					}
				}
			}
			else if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					ArcadePhysics physics2 = s_scene2.physics;
					if ((object)s_scene2.physics != null)
					{
						add = physics2.add;
						GameManager core2 = GM.Core;
						if ((object)GM.Core != null)
						{
							enemies = core2.Enemies;
							collideCallback = null;
							nint num2 = (nint)this;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+380]");
							nint method = 0;
							secondaryPool2 = _secondaryPool;
							goto IL_03da;
						}
					}
				}
			}
		}
		goto IL_0383;
		IL_0383:
		return (Projectile)(object)new NullReferenceException();
		IL_03da:
		if (add != null)
		{
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = add.overlap(secondaryPool2, enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null)
				{
					ArcadePhysics physics3 = s_scene3.physics;
					if ((object)s_scene3.physics != null)
					{
						GameManager core3 = GM.Core;
						if ((object)GM.Core != null)
						{
							PhysicsManager physicsManager = core3._physicsManager;
							if (core3._physicsManager != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v574 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+3A0]");
								ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
								nint num3 = (nint)this;
								if (physics3.add != null)
								{
									Collider collider2 = physics3.add.overlap(_secondaryPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
									goto IL_0347;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0383;
		IL_0347:
		if (_secondaryPool != null)
		{
			return _secondaryPool.SpawnAt(pos, this, enemiesHit);
		}
		goto IL_0383;
	}

	public virtual void ResetFiringTimer()
	{
		//IL_0156: Expected I4, but got O
		//IL_00a0: Expected I, but got O
		//IL_00e9: Expected I4, but got O
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
		WeaponData currentWeaponData = _currentWeaponData;
		float num2;
		if (currentWeaponData._003CintervalDependsOnDuration_003Ek__BackingField)
		{
			float duration = Duration;
			float num = PInterval();
			num2 = duration + duration;
		}
		else
		{
			float num3 = PInterval();
			float num4 = default(float);
			num2 = num4;
		}
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		if (GetFiringAnimation() == FiringAnimation.None)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+4C0]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num5 = (nint)this;
			bool useOnlineTimer = UseOnlineTimer;
			float duration2 = num2 * 0.001f;
			Timer firingTimer = Timers.Register(duration2, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, (byte)(int)this != 0);
			_firingTimer = firingTimer;
		}
		else
		{
			Action onComplete2 = FireAndQueueAnimation;
			bool useOnlineTimer2 = UseOnlineTimer;
			float duration3 = num2 * 0.001f;
			Timer firingTimer2 = Timers.Register(duration3, onComplete2, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, (byte)(int)this != 0);
			_firingTimer = firingTimer2;
		}
	}

	protected void FireAndQueueAnimation()
	{
		PlayNextAttackAnim();
		Fire();
	}

	protected void PlayNextAttackAnim()
	{
		_003C_003Ec__DisplayClass176_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass176_0();
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		if (_firingAnimEvent != null)
		{
			_firingAnimEvent.Cancel();
		}
		Action onComplete3;
		object obj2;
		object obj = default(object);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		switch (CS_0024_003C_003E8__locals5.animation = GetFiringAnimation())
		{
		default:
		{
			float num7 = PInterval();
			nint num6 = default(nint);
			onComplete3 = new Action(CS_0024_003C_003E8__locals5, num6);
			obj2 = obj;
			num6 = 0;
			break;
		}
		case FiringAnimation.Magic:
		{
			float num5 = PInterval();
			onComplete3 = null;
			obj2 = obj;
			nint num6 = 0;
			break;
		}
		case FiringAnimation.None:
			return;
		case FiringAnimation.Melee:
		{
			float num3 = PInterval();
			Action onComplete2 = delegate
			{
				Weapon weapon = CS_0024_003C_003E8__locals5._003C_003E4__this;
				((Equipment)weapon)._003COwner_003Ek__BackingField.OnMeleeAttackAnim();
			};
			float num4 = (float)obj - 120f;
			float duration2 = num4 * 0.001f;
			Timer firingAnimEvent2 = Timers.Register(duration2, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_firingAnimEvent = firingAnimEvent2;
			return;
		}
		case FiringAnimation.Ranged:
		{
			float num = PInterval();
			Action onComplete = delegate
			{
				Weapon weapon = CS_0024_003C_003E8__locals5._003C_003E4__this;
				((Equipment)weapon)._003COwner_003Ek__BackingField.OnRangedAttackAnim();
			};
			float num2 = (float)obj - 120f;
			float duration = num2 * 0.001f;
			Timer firingAnimEvent = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_firingAnimEvent = firingAnimEvent;
			return;
		}
		}
		float num8 = (float)obj2 - 120f;
		float duration3 = num8 * 0.001f;
		Timer firingAnimEvent3 = Timers.Register(duration3, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_firingAnimEvent = firingAnimEvent3;
	}

	protected virtual FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.None;
	}

	public void RemoveFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
		if (_firingAnimEvent != null)
		{
			_firingAnimEvent.Cancel();
		}
	}

	public virtual void SetVisible(bool visible)
	{
		_isVisible = visible;
	}

	public static List<float> MakeChanceArray(int amount = 100)
	{
		//IL_000e: Expected O, but got I4
		//IL_0148: Expected O, but got I
		//IL_0158: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		List<float> list = new List<float>();
		float num = 1f / (float)amount;
		if (amount > 0)
		{
			object obj = 0;
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj3 = 0;
				float item = (float)obj * num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v5+18]");
				if (num2 >= 0)
				{
					list.AddWithResize(item);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj4 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdx_v5+18]");
					if (num3 >= 0)
					{
						return (List<float>)(object)new IndexOutOfRangeException();
					}
				}
				obj++;
			}
			while ((nint)obj < amount);
		}
		VampireSurvivors.App.Tools.Extensions.Shuffle(list);
		return list;
	}

	protected virtual float CalcCritMul()
	{
		//IL_007c: Expected O, but got I
		//IL_0136: Invalid comparison between F4 and I
		if (_003CCanCrit_003Ek__BackingField)
		{
			List<float> critChancesArray = _critChancesArray;
			if (_critChancesArray != null)
			{
				int critIndex = _critIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v3 (System.Collections.Generic.List`1<System.Single>)+18]");
				int num = (int)((nint)critIndex % (nint)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v3 (System.Collections.Generic.List`1<System.Single>)+18]");
				if ((nint)num < (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v3 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rcx_v3 (System.Collections.Generic.List`1<System.Single>)+10]");
					if ((nint)0 != 0)
					{
						int critIndex2 = _critIndex + 1;
						_critIndex = critIndex2;
						WeaponData currentWeaponData = _currentWeaponData;
						if (_currentWeaponData != null && (object)base._003COwner_003Ek__BackingField != null)
						{
							float num2 = base._003COwner_003Ek__BackingField.PLuck();
							float num3 = num3 * currentWeaponData._003CcritChance_003Ek__BackingField;
							float num4 = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rcx_v7+20+v108 @ rdx_v4 (System.Int32)*4]");
							if (!(num4 > 0f))
							{
								goto IL_017b;
							}
							WeaponData currentWeaponData2 = _currentWeaponData;
							if (_currentWeaponData != null)
							{
								return currentWeaponData2._003CcritMul_003Ek__BackingField * ArcanaManager.CritMul;
							}
						}
					}
				}
				else
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
			}
			throw new NullReferenceException();
		}
		goto IL_017b;
		IL_017b:
		return 1f;
	}

	public virtual float GetChanceFromArray()
	{
		//IL_0053: Expected O, but got I
		//IL_0065: Expected F4, but got I
		List<float> critChancesArray = _critChancesArray;
		int critIndex = _critIndex + 1;
		_critIndex = critIndex;
		int critIndex2 = _critIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num = (int)((nint)critIndex2 % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v7+20+v50 @ rdx_v5 (System.Int32)*4]");
			return 0f;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		float result = default(float);
		return result;
	}

	protected unsafe override void MakeLevelOne()
	{
		//IL_007d: Expected O, but got I
		//IL_00cb: Expected O, but got I4
		//IL_014f: Expected F4, but got I4
		//IL_0157: Expected O, but got Ref
		//IL_0182: Expected F4, but got I4
		//IL_018a: Expected O, but got Ref
		//IL_011d: Expected I4, but got O
		//IL_01b7: Expected F4, but got O
		//IL_03fc: Expected O, but got I4
		//IL_040e: Expected O, but got I4
		//IL_042e: Expected O, but got I4
		//IL_045c: Expected I, but got O
		//IL_021a: Expected O, but got I
		//IL_0581: Expected I, but got O
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Expected O, but got Unknown
		//IL_0318: Expected F4, but got O
		base._003CLevel_003Ek__BackingField = 0;
		List<float> critChancesArray = MakeChanceArray(1000);
		_critChancesArray = critChancesArray;
		JToken newLevelData;
		if (!base.GetDataForLevel(base._equipmentType, base._003CLevel_003Ek__BackingField, out *(JObject*)(&newLevelData), upgradeExistingData: false))
		{
			return;
		}
		object currentWeaponData = newLevelData.ToObject<object>();
		_currentWeaponData = (WeaponData)currentWeaponData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		object obj = 0;
		nint num = base._003CLevel_003Ek__BackingField;
		if (_currentWeaponData == null)
		{
			return;
		}
		WeaponData currentWeaponData2 = _currentWeaponData;
		base._003CLevel_003Ek__BackingField = currentWeaponData2._003Clevel_003Ek__BackingField;
		bool flag = (object)currentWeaponData2._003CpoolLimit_003Ek__BackingField == null;
		BulletPool bulletPool = (BulletPool)currentWeaponData2._003Clevel_003Ek__BackingField;
		if (!flag)
		{
			bulletPool = _projectilePool;
			if ((object)currentWeaponData2._003CpoolLimit_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				throw new NullReferenceException();
			}
			int upperLimit = (object?)currentWeaponData2._003CpoolLimit_003Ek__BackingField >> 32;
			bulletPool.UpperLimit = upperLimit;
		}
		WeaponData currentWeaponData3 = _currentWeaponData;
		bool flag2 = currentWeaponData3._003CskipRemovingBaseWeapon_003Ek__BackingField;
		float lastFiringInterval = 0f;
		List<WeaponType> list = (List<WeaponType>)(&newLevelData);
		if (!flag2)
		{
			bool flag3 = currentWeaponData3._003CevolvesFrom_003Ek__BackingField == null;
			lastFiringInterval = 0f;
			list = (List<WeaponType>)(&newLevelData);
			if (!flag3)
			{
				list = currentWeaponData3._003CevolvesFrom_003Ek__BackingField;
				lastFiringInterval = (float)currentWeaponData3._003CevolvesFrom_003Ek__BackingField;
				object obj2 = default(object);
				object obj3 = default(object);
				object obj5 = default(object);
				while (true)
				{
					if (obj2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ stack_-48_v21+1C]");
						if (obj3 != null)
						{
							break;
						}
						object obj4 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ stack_-48_v21+18]");
						if ((nint)obj4 >= 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ stack_-48_v21+10]");
						object obj6 = 0;
						obj5++;
						nint num2 = 0;
						GameManager core = GM.Core;
						CoopConfig coopConfig = core.CoopConfig;
						if (coopConfig._shareEvolutionPassives)
						{
							PlayerOptionsData config = _playerOptions.Config;
							if (config._003CSelectedSharePassives_003Ek__BackingField)
							{
								Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ rdx_v41+20+v1632 @ rcx_v50*4]");
								object obj7 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)0);
								List<WeaponData> list2 = ((Dictionary<WeaponType, List<WeaponData>>)obj7).get_Item(WeaponType.VOID);
								num2 = 0;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE9C0");
						lastFiringInterval = (float)base._003COwner_003Ek__BackingField;
						continue;
					}
					throw new NullReferenceException();
				}
				obj = obj3;
				bool flag4 = obj2 == null;
				nint num3 = 0;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ stack_-48_v21+1C]");
					if (obj3 == null)
					{
						num = 0;
						goto IL_05eb;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					num3 = unchecked((nint)null);
				}
				throw new NullReferenceException();
			}
		}
		goto IL_05eb;
		IL_05eb:
		WeaponData currentWeaponData4 = _currentWeaponData;
		string text = currentWeaponData4._003Cbgm_003Ek__BackingField;
		if (currentWeaponData4._003Cbgm_003Ek__BackingField != null && text._stringLength > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8710");
			BgmType bgmType = default(BgmType);
			SoundManager.StopMusic(bgmType);
			WeaponData currentWeaponData5 = _currentWeaponData;
			BgmType bgmType2 = Enum.Parse<BgmType>(currentWeaponData5._003Cbgm_003Ek__BackingField);
			BgmType bgmType3 = Enum.Parse<BgmType>((string)bgmType2);
			BgmType bgmType4 = Enum.Parse<BgmType>((string)bgmType2);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Loop = true;
			soundConfig.Rate = 1f;
			SoundManager.PlayMusic(bgmType4, soundConfig);
			num = unchecked((nint)null);
		}
		CheckArcanas();
		float num4 = PInterval();
		_lastFiringInterval = lastFiringInterval;
		WeaponData currentWeaponData6 = _currentWeaponData;
		if (currentWeaponData6._003CunexcludeSelf_003Ek__BackingField)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = base._003COwner_003Ek__BackingField;
			if (characterController._PlayerIndex >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2130");
			}
		}
		WeaponData currentWeaponData7 = _currentWeaponData;
		base._003COwner_003Ek__BackingField.OnWeaponMadeLevelOne(currentWeaponData7._003CbulletType_003Ek__BackingField);
	}

	public unsafe void ReloadCurrentData()
	{
		//IL_0098: Expected O, but got Ref
		//IL_00f9: Expected I4, but got O
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		if (base._003CLevel_003Ek__BackingField > 0)
		{
			JObject jObject = null;
			do
			{
				bool dataForLevel = base.GetDataForLevel(base._equipmentType, (int)jObject, out var _, upgradeExistingData: false);
				object currentWeaponData = _currentJsonDataObject.ToObject<object>();
				_currentWeaponData = (WeaponData)currentWeaponData;
				jObject = (JObject)(jObject + 1);
			}
			while ((nint)jObject < base._003CLevel_003Ek__BackingField);
		}
		WeaponData currentWeaponData2 = _currentWeaponData;
		int num = currentWeaponData2._003Camount_003Ek__BackingField + _beginningAmount;
		currentWeaponData2._003Camount_003Ek__BackingField = num;
		ResetFiringTimer();
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string message = "Reloading current data for " + text;
		Debug.Log(message);
	}

	protected override Dictionary<WeaponType, JArray> GetDataDictionary()
	{
		DataManager dataManager = _dataManager;
		if (_dataManager != null)
		{
			return dataManager._003CAllWeaponData_003Ek__BackingField;
		}
		return (Dictionary<WeaponType, JArray>)(object)new NullReferenceException();
	}

	private void ApplyLimitBreakStatsToWeaponStats(LimitBreakData limitBreakData)
	{
		limitBreakData?.ApplyDataToWeapon(_currentWeaponData);
	}

	public Weapon()
	{
		List<Projectile> list = null;
		Projectile[] items = null;
		list._items = items;
		_spawnedProjectiles = list;
		List<float> critChancesArray = new List<float>();
		_critChancesArray = critChancesArray;
		_lastFiringInterval = 100000f;
		_explosionType = WeaponType.RAYEXPLOSION;
		_secondaryOvarlapDamageType = WeaponType.POWER;
		base._003CShowInRecap_003Ek__BackingField = true;
		((GameMonoBehaviour)this)._onResumeSent = true;
	}

	static Weapon()
	{
		//IL_002b: Expected O, but got I
		//IL_0051: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("Cleanup", 1, MarkerFlags.Default, 0);
		_markerCleanup = (ProfilerMarker)(nint)intPtr;
		IntPtr intPtr2 = ProfilerUnsafeUtility.CreateMarker("FireOneProjectile", 1, MarkerFlags.Default, 0);
		_markerFireOneProjectile = (ProfilerMarker)(nint)intPtr2;
	}
}
