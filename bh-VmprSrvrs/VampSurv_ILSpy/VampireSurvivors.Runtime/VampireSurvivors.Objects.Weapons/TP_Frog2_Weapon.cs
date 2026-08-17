using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Frog2_Weapon : Weapon
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<Equipment> _003C_003E9__50_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CInitRecoveredHPBonus_003Eb__50_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 19;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private Projectile _FrogProjectilePrefab;

	private Projectile _TongueProjectilePrefab;

	private Transform _SpriteContainer;

	private const float VortexTweenDurationMS = 1500f;

	private const float SpriteScale = 27f / 32f;

	private const float AlphaBG = 0.7f;

	private const float MorphRadiusMultiplier = 1.2f;

	private PhaserSprite _vortexBG;

	private PhaserSprite _vortexOverlay1;

	private PhaserSprite _vortexOverlay2;

	private PhaserSprite _vortexOverlay3;

	private MultiTargetTween _vortexTween1;

	private MultiTargetTween _vortexTween2;

	private MultiTargetTween _vortexTween3;

	private MultiTargetTween _tintTween;

	private Timer _vortex2DelayTimer;

	private Timer _vortex3DelayTimer;

	private Timer _morphTimer;

	private bool _morphQueued;

	private float _totalTimeCounterWeapon;

	private float _recoveredHP;

	private float _recoveredCalculated;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private GravityWell _well;

	private Circle _shape1;

	private EmitZone _emitZone;

	private float _mul = 166.66667f;

	private bool _cooldownAffectedByMovement;

	private WeaponType _counterWeaponType = WeaponType.TP_FROG_COUNTER;

	private Weapon _counterWeapon;

	private bool _hasCounterWeapon;

	private BulletPool _frogProjectilePool;

	private BulletPool _tongueProjectilePool;

	private int _003CEnemiesEatenThisRun_003Ek__BackingField;

	[NonSerialized]
	public static float PAreaMax = 3.5f;

	public BulletPool FrogProjectilePool => _frogProjectilePool;

	public float RecoveredHP => _recoveredHP;

	public float Radius => 96f;

	public int EnemiesEatenThisRun
	{
		get
		{
			return _003CEnemiesEatenThisRun_003Ek__BackingField;
		}
		set
		{
			_003CEnemiesEatenThisRun_003Ek__BackingField = value;
		}
	}

	public override float PAmount()
	{
		return 1f;
	}

	public override float PArea()
	{
		float result = PAreaMax;
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = default(object);
		float num2 = (float)obj * currentWeaponData._003Carea_003Ek__BackingField;
		if (PAreaMax > num2)
		{
			result = num2;
		}
		return result;
	}

	public override float PPower()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PPower();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj2 = default(object);
		object obj = obj2 * currentWeaponData._003Cpower_003Ek__BackingField;
		return (float)obj + _recoveredCalculated;
	}

	protected override void OnStart()
	{
		//IL_006e: Expected I, but got O
		//IL_0111: Expected I, but got O
		base.OnStart();
		if (_frogProjectilePool == null)
		{
			BulletPool frogProjectilePool = new BulletPool(_FrogProjectilePrefab);
			_frogProjectilePool = frogProjectilePool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Frog2_Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_frogProjectilePool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Frog2_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			Collider collider2 = physics2.add.overlap(_frogProjectilePool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
		if (_tongueProjectilePool == null)
		{
			BulletPool tongueProjectilePool = new BulletPool(_TongueProjectilePrefab);
			_tongueProjectilePool = tongueProjectilePool;
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		InitRecoveredHPBonus();
		InitParticles();
		InitSprites();
		StartTweens();
		base._003CTotalTime_003Ek__BackingField = 0f;
		_003CEnemiesEatenThisRun_003Ek__BackingField = 0;
		_morphQueued = false;
		StartMorphTimer();
	}

	private void InitRecoveredHPBonus()
	{
		//IL_006d: Expected I, but got O
		//IL_007b: Expected I, but got O
		//IL_008b: Expected O, but got I
		//IL_010b: Expected O, but got I4
		//IL_0060: Expected F4, but got I4
		//IL_027a: Expected I, but got O
		//IL_029c: Expected F4, but got I4
		//IL_00c7: Expected O, but got I
		//IL_0118: Expected F4, but got O
		//IL_00fd: Expected O, but got I4
		//IL_02b8: Invalid comparison between F4 and I4
		//IL_01bb: Expected F4, but got I4
		//IL_0205: Expected O, but got F4
		//IL_01dc: Invalid comparison between F4 and I4
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		_recoveredHP = 0f;
		CharacterWeaponsManager weaponsManager = characterController._weaponsManager;
		Predicate<Equipment> match = _003C_003Ec._003C_003E9__50_0;
		nint num;
		if (_003C_003Ec._003C_003E9__50_0 == null)
		{
			match = (_003C_003Ec._003C_003E9__50_0 = delegate(Equipment x)
			{
				//IL_0052: Expected I4, but got O
				//IL_0030: Expected O, but got I4
				if ((object)x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj5 = x._equipmentType - 19;
				return obj5 == null;
			});
			num = unchecked((nint)null);
		}
		Equipment equipment = ((EquipmentManager)weaponsManager)._003CRemovedEquipment_003Ek__BackingField.Find(match);
		float num2;
		if ((object)equipment == null)
		{
			num2 = 0f;
			goto IL_02af;
		}
		num = (nint)equipment;
		nint num3 = (nint)typeof(VortexWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.VortexWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.VortexWeapon>)+130]");
		object obj3;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r9_v4 (Il2CppClass<VampireSurvivors.Objects.Equipment>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ rax_v37+FFFFFFF8+v343 @ rax_v33*8]");
			if (0 == (nint)typeof(VortexWeapon))
			{
				obj3 = 1;
				goto IL_0284;
			}
		}
		obj3 = 0;
		goto IL_0284;
		IL_02af:
		if (num2 != 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v4 (System.Single)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v4 (System.Single)+168]");
				float recoveredHP = 0f + _recoveredHP;
				_recoveredHP = recoveredHP;
			}
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		Action<float, float> b = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE6B0");
		Delegate obj4 = Delegate.Combine(characterController2._onHpRecoveryCallback, b);
		bool flag = (object)obj4 == null;
		float num5 = 0f;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			float num6 = default(float);
			bool flag2 = num6 == 0f;
			num5 = num6;
			if (flag2)
			{
				throw new InvalidCastException();
			}
		}
		characterController2._onHpRecoveryCallback = (Action<float, float>)num5;
		return;
		IL_0284:
		bool flag3 = obj3 == null;
		num2 = 0f;
		if (!flag3)
		{
			num2 = (float)equipment;
		}
		goto IL_02af;
	}

	private unsafe void InitSprites()
	{
		//IL_011c: Expected O, but got I4
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected Ref, but got Unknown
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected Ref, but got Unknown
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected Ref, but got Unknown
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F66D]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)this != null)
			{
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "circle");
				if ((object)phaserSprite != null)
				{
					PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0.7f);
					if ((object)phaserSprite2 != null)
					{
						PhaserSprite phaserSprite3 = phaserSprite2.setTint(3145808u);
						if ((object)phaserSprite3 != null)
						{
							PhaserSprite phaserSprite4 = phaserSprite3.setScale(1f, (float?)(object)0);
							if ((object)phaserSprite4 != null)
							{
								Transform transform = phaserSprite4.transform;
								if ((object)transform != null)
								{
									transform.SetParent(_SpriteContainer, worldPositionStays: true);
									GameObject gameObject2 = phaserSprite4.gameObject;
									if ((object)gameObject2 != null)
									{
										((UnityEngine.Object)gameObject2).SetName("_vortexBG");
										_vortexBG = phaserSprite4;
										if ((object)_vortexBG != null)
										{
											Transform transform2 = _vortexBG.transform;
											bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
											Vector3 value = default(Vector3);
											Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
											MakeOverlay(ref *(PhaserSprite*)(this + 376), "_vortexOverlay1");
											MakeOverlay(ref *(PhaserSprite*)(this + 384), "_vortexOverlay2");
											MakeOverlay(ref *(PhaserSprite*)(this + 392), "_vortexOverlay3");
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
		throw new NullReferenceException();
	}

	private unsafe void MakeOverlay(ref PhaserSprite overlay, string objectName)
	{
		//IL_014b: Expected O, but got I4
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F66D]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)this != null)
			{
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "circle");
				if ((object)phaserSprite != null)
				{
					PhaserSprite phaserSprite2 = phaserSprite.setBlendMode(BlendMode.Normal);
					if ((object)phaserSprite2 != null)
					{
						PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0f);
						if ((object)phaserSprite3 != null)
						{
							PhaserSprite phaserSprite4 = phaserSprite3.setTint(0u);
							if ((object)phaserSprite4 != null)
							{
								PhaserSprite phaserSprite5 = phaserSprite4.setScale(1f, (float?)(object)0);
								if ((object)phaserSprite5 != null)
								{
									Transform transform = phaserSprite5.transform;
									if ((object)transform != null)
									{
										transform.SetParent(_SpriteContainer, worldPositionStays: true);
										GameObject gameObject2 = phaserSprite5.gameObject;
										if ((object)gameObject2 != null)
										{
											((UnityEngine.Object)gameObject2).SetName(objectName);
											ref PhaserSprite reference = ref *(PhaserSprite*)phaserSprite5;
											if ((object)overlay != null)
											{
												Transform transform2 = overlay.transform;
												bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
												Vector3 value = default(Vector3);
												Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
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
		throw new NullReferenceException();
	}

	private unsafe void InitParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_01cd: Expected O, but got I4
		//IL_01f4: Expected O, but got I4
		//IL_021b: Expected O, but got I4
		//IL_0460: Expected O, but got I4
		//IL_0247: Expected O, but got Ref
		//IL_0261: Expected native int or pointer, but got O
		//IL_047d: Expected O, but got I4
		//IL_02ac: Expected O, but got I
		//IL_04b7: Expected O, but got I
		//IL_02ed: Expected O, but got Ref
		//IL_0314: Expected O, but got I
		//IL_032e: Expected native int or pointer, but got O
		//IL_0348: Expected O, but got I
		//IL_03cb: Expected O, but got I
		//IL_03e0: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
			particlesManager = (ParticleEmitterManager)0;
		}
		else
		{
			particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particlesManager = particlesManager;
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 96f;
		_shape1 = circle;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = _shape1;
		_emitZone = emitZone;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxColor2");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
		_ = 0;
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
		_ = 0;
		_ = 0;
		_ = 2;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
		particleSystemConfig._quantity = (int?)(object)0;
		particleSystemConfig._on = false;
		minMaxCurve = new ParticleSystem.MinMaxCurve(0.4f);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
		_ = 0;
		particleSystemConfig._emitZone = _emitZone;
		ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig);
		_pfxEmitter = pfxEmitter;
		GravityWellConfig gravityWellConfig = new GravityWellConfig();
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
		gravityWellConfig._y = (float?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
		gravityWellConfig._x = (float?)(object)0;
		gravityWellConfig._epsilon = 20f;
		gravityWellConfig._power = 1f;
		gravityWellConfig._gravity = 50f;
		GravityWell well = _particlesManager.CreateGravityWell(gravityWellConfig);
		_well = well;
	}

	private void StartTweens()
	{
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		//IL_00e2: Expected I4, but got I8
		//IL_00fe: Expected O, but got I4
		if (_tintTween != null)
		{
			_tintTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_vortexBG != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 1500f;
		tweenConfig.tint = (uint?)(object)1;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = -1;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween tintTween = Tweens.Add(tweenConfig);
		_tintTween = tintTween;
		DoVortexOverlayTween1();
		if (_vortex2DelayTimer != null)
		{
			_vortex2DelayTimer.Cancel();
		}
		Action onComplete = DoVortexOverlayTween2;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer vortex2DelayTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_vortex2DelayTimer = vortex2DelayTimer;
		if (_vortex3DelayTimer != null)
		{
			_vortex3DelayTimer.Cancel();
		}
		Action onComplete2 = DoVortexOverlayTween3;
		Timer vortex3DelayTimer = Timers.Register(1f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_vortex3DelayTimer = vortex3DelayTimer;
	}

	private void DoVortexOverlayTween1()
	{
		//IL_001a: Expected O, but got I4
		//IL_00af: Expected I, but got O
		//IL_0105: Expected O, but got I4
		//IL_012f: Expected O, but got I4
		PhaserSprite phaserSprite = _vortexOverlay1.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _vortexOverlay1.setAlpha(0f);
		if (_vortexTween1 != null)
		{
			_vortexTween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_vortexOverlay1 != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = 1500f;
		tweenConfig.ease = Ease.InSine;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = DoVortexOverlayTween1;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween vortexTween = Tweens.Add(tweenConfig);
		_vortexTween1 = vortexTween;
	}

	private void DoVortexOverlayTween2()
	{
		//IL_001a: Expected O, but got I4
		//IL_00af: Expected I, but got O
		//IL_0105: Expected O, but got I4
		//IL_012f: Expected O, but got I4
		PhaserSprite phaserSprite = _vortexOverlay2.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _vortexOverlay2.setAlpha(0f);
		if (_vortexTween2 != null)
		{
			_vortexTween2.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_vortexOverlay2 != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = 1500f;
		tweenConfig.ease = Ease.InSine;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = DoVortexOverlayTween2;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween vortexTween = Tweens.Add(tweenConfig);
		_vortexTween2 = vortexTween;
	}

	private void DoVortexOverlayTween3()
	{
		//IL_001a: Expected O, but got I4
		//IL_00af: Expected I, but got O
		//IL_0105: Expected O, but got I4
		//IL_012f: Expected O, but got I4
		PhaserSprite phaserSprite = _vortexOverlay3.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _vortexOverlay3.setAlpha(0f);
		if (_vortexTween3 != null)
		{
			_vortexTween3.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_vortexOverlay3 != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = 1500f;
		tweenConfig.ease = Ease.InSine;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = DoVortexOverlayTween3;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween vortexTween = Tweens.Add(tweenConfig);
		_vortexTween3 = vortexTween;
	}

	private void StartMorphTimer()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAmount();
		object obj = default(object);
		float num2 = (float)obj + 1f;
		bool flag = 1f > num2;
		float num3 = 1f;
		if (!flag)
		{
			num3 = num2;
		}
		float num4 = base.PInterval();
		float num5 = num2 + num2;
		float num6 = num5 / num3;
		bool flag2 = 200f > num6;
		float num7 = 200f;
		if (!flag2)
		{
			num7 = num6;
		}
		if (_morphTimer != null)
		{
			_morphTimer.Cancel();
		}
		Action onComplete = delegate
		{
			MorphEnemyInRange();
		};
		float duration = num7 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer morphTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_morphTimer = morphTimer;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		if (_morphQueued)
		{
			MorphEnemyInRange();
		}
		float num = PauseSystem.DeltaTime;
		float num2 = num * 1000f;
		float num3 = num2 + base._003CTotalTime_003Ek__BackingField;
		float totalTimeCounterWeapon = num2 + _totalTimeCounterWeapon;
		base._003CTotalTime_003Ek__BackingField = num3;
		_totalTimeCounterWeapon = totalTimeCounterWeapon;
		VortexUpdate(num2);
		if (_cooldownAffectedByMovement)
		{
			float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
			float num4 = num2 / _mul;
			num = frameWalk * 100f;
			float num5 = num4 * num;
			float num6 = num5 + base._003CTotalTime_003Ek__BackingField;
			base._003CTotalTime_003Ek__BackingField = num6;
		}
		float num7 = base.PInterval();
		if (!(base._003CTotalTime_003Ek__BackingField < num))
		{
			float num8 = base.PInterval();
			float num9 = base._003CTotalTime_003Ek__BackingField - num;
			base._003CTotalTime_003Ek__BackingField = num9;
			base.Fire();
		}
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon == null || ((UnityEngine.Object)counterWeapon).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		float num10 = _counterWeapon.PInterval();
		if (!(_totalTimeCounterWeapon < num))
		{
			_totalTimeCounterWeapon = 0f;
			Weapon counterWeapon2 = _counterWeapon;
			if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon2).m_CachedPtr != (IntPtr)0)
			{
				_counterWeapon.Fire(false);
			}
		}
	}

	protected unsafe void VortexUpdate(float deltaTime)
	{
		//IL_007e: Expected O, but got I4
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected I4, but got Unknown
		//IL_0353: Expected I4, but got I8
		Transform transform = _SpriteContainer.transform;
		float num = PArea();
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector2 value = default(Vector2);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
		int depth = ((Equipment)this)._003COwner_003Ek__BackingField.Depth;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num2 = renderer.pixelHeight >> 31;
		object obj = renderer.pixelHeight - num2;
		object obj2 = obj >> 1;
		int num3 = depth - obj2;
		int depth2 = num3 - 1;
		PhaserSprite phaserSprite = _vortexBG.setDepth(depth2);
		PhaserSprite phaserSprite2 = _vortexOverlay1.setDepth(num3);
		PhaserSprite phaserSprite3 = _vortexOverlay2.setDepth(num3);
		PhaserSprite phaserSprite4 = _vortexOverlay3.setDepth(num3);
		Transform transform2 = _well.transform;
		bool flag2 = (object)transform2 == null;
		bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
		float num4 = PArea();
		bool flag4 = _shape1 == null;
		float num5 = (float)Vector3.zeroVector * 96f;
		float num6 = num5 + num5;
		EmitZone emitZone = _emitZone;
		bool flag5 = _emitZone == null;
		emitZone._source = _shape1;
		RenderingExtensions.SetEmitZone(_pfxEmitter, _emitZone);
		bool flag6 = (object)_pfxEmitter == null;
		Transform transform3 = _pfxEmitter.transform;
		bool flag7 = (object)transform3 == null;
		bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
		Vector3 value3 = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value3);
		TP_Frog2_Weapon cachedTransform = (TP_Frog2_Weapon)(object)_cachedTransform;
		bool flag9 = (object)_cachedTransform == null;
		bool flag10 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)(&value));
		Vector2 pos = default(Vector2);
		RenderingExtensions.EmitParticleAt(_pfxEmitter, pos, -1);
	}

	public override void Fire(bool skipTriggers = false)
	{
		float num = _recoveredHP / 600f;
		bool flag = !(10f > num);
		float recoveredCalculated = 10f;
		if (!flag)
		{
			recoveredCalculated = num;
		}
		_recoveredCalculated = recoveredCalculated;
		base.Fire(skipTriggers);
	}

	private void MorphEnemyInRange()
	{
		//IL_00a0: Expected F4, but got O
		//IL_00f2: Expected O, but got I4
		//IL_03fe: Expected I, but got O
		//IL_040c: Expected I, but got O
		//IL_041c: Expected O, but got I
		//IL_049c: Expected O, but got I4
		//IL_0458: Expected O, but got I
		//IL_04aa: Expected I4, but got O
		//IL_048e: Expected O, but got I4
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected O, but got Unknown
		//IL_02fc: Expected O, but got I4
		//IL_06e2->IL0698: Incompatible stack heights: 1 vs 0
		float num = PArea();
		object obj = default(object);
		float num2 = (float)obj * 115.200005f;
		float radius = num2 * 0.01f;
		List<EnemyController> list2;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				if ((object)GM.Core != null && (object)ArcadePhysics.s_instance != null)
				{
					float y = default(float);
					bool flag = default(bool);
					bool includeStatic = default(bool);
					Group specificGroup = default(Group);
					List<BaseBody> list = ArcadePhysics.s_instance.OverlapCirc((float)position, y, radius, flag, includeStatic, specificGroup);
					list2 = new List<EnemyController>();
					bool flag2 = (nint)list < 0;
					if (list != null)
					{
						object obj2 = list._size - 1;
						if (flag2)
						{
							goto IL_0312;
						}
						while (true)
						{
							if ((nint)obj2 < list._size)
							{
								BaseBody[] items = list._items;
								if (list._items == null)
								{
									break;
								}
								if ((nint)obj2 < items.Length)
								{
									BaseBody baseBody = items[obj2];
									Component component = ((items[obj2] == null) ? null : baseBody._gameObject);
									ArcadePhysics arcadePhysics;
									if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
									{
										EnemyController component2 = component.GetComponent<EnemyController>();
										arcadePhysics = (ArcadePhysics)(object)component2;
									}
									else
									{
										arcadePhysics = null;
									}
									bool flag3 = (nint)arcadePhysics < 0;
									if ((object)arcadePhysics != null)
									{
										flag3 = (nint)((UnityEngine.Object)arcadePhysics).m_CachedPtr < 0;
										if (((UnityEngine.Object)arcadePhysics).m_CachedPtr != (IntPtr)0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rbx_v10 (ArcadePhysics)+260]");
											flag3 = (nint)0 < (nint)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rbx_v10 (ArcadePhysics)+260]");
											if ((nint)0 == 0)
											{
												bool flag4 = ((EnemyController)(object)arcadePhysics).IsBossEnemy();
												flag3 = (flag4 ? 1 : 0) < (false ? 1 : 0);
												if (!flag4)
												{
													flag3 = (nint)list2 < 0;
													if (list2 == null)
													{
														break;
													}
													list2._002Ector();
												}
											}
										}
									}
									obj2--;
									object obj3 = !flag3;
									flag = flag;
									if (obj3 != null)
									{
										continue;
									}
									goto IL_0312;
								}
							}
							else
							{
								System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							}
							throw new IndexOutOfRangeException();
						}
					}
				}
			}
		}
		goto IL_057f;
		IL_057f:
		throw new NullReferenceException();
		IL_0312:
		EnemyController enemyController;
		Projectile projectile;
		bool flag6;
		object obj6;
		if (list2 != null)
		{
			if (list2._size == 0)
			{
				_morphQueued = true;
				return;
			}
			_morphQueued = false;
			enemyController = Extensions.PickRnd(list2);
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				if (_tongueProjectilePool != null)
				{
					float2 pos = default(float2);
					projectile = _tongueProjectilePool.SpawnAt(pos, this);
					bool flag5 = (object)projectile == null;
					flag6 = false;
					if (!flag5)
					{
						nint num3 = (nint)projectile;
						nint num4 = (nint)typeof(TP_Frog2_TongueProjectile);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rdx_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog2_TongueProjectile>)+130]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v798 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v799 @ rdx_v30 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Frog2_TongueProjectile>)+130]");
						if (num5 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v798 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v868 @ rax_v89+FFFFFFF8+v800 @ rax_v85*8]");
							if (0 == (nint)typeof(TP_Frog2_TongueProjectile))
							{
								obj6 = 1;
								goto IL_0653;
							}
						}
						obj6 = 0;
						goto IL_0653;
					}
					goto IL_067f;
				}
			}
		}
		goto IL_057f;
		IL_0698:
		StartMorphTimer();
		return;
		IL_067f:
		if (flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rsi_v9 (System.Boolean)+10]");
			if ((nint)0 != 0)
			{
				if ((object)enemyController != null)
				{
					((ArcadeSprite)enemyController).CheckRenderer();
					if ((object)((ArcadeSprite)enemyController)._spriteRenderer != null)
					{
						Transform transform = ((ArcadeSprite)enemyController)._spriteRenderer.transform;
						if ((object)transform != null)
						{
							bool flag7 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
							goto IL_0698;
						}
					}
				}
				goto IL_057f;
			}
		}
		goto IL_0698;
		IL_0653:
		bool flag8 = obj6 == null;
		flag6 = false;
		if (!flag8)
		{
			flag6 = (byte)(int)projectile != 0;
		}
		goto IL_067f;
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Cleanup()
	{
		if (_vortexTween1 != null)
		{
			_vortexTween1.Kill();
		}
		if (_vortexTween2 != null)
		{
			_vortexTween2.Kill();
		}
		if (_vortexTween3 != null)
		{
			_vortexTween3.Kill();
		}
		if (_tintTween != null)
		{
			_tintTween.Kill();
		}
		if (_vortex2DelayTimer != null)
		{
			_vortex2DelayTimer.Cancel();
		}
		if (_vortex3DelayTimer != null)
		{
			_vortex3DelayTimer.Cancel();
		}
		if (_morphTimer != null)
		{
			_morphTimer.Cancel();
		}
		base.Cleanup();
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_02d0: Expected I4, but got O
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		//IL_0110: Expected I, but got O
		//IL_0118: Expected I, but got O
		//IL_0128: Expected O, but got I
		//IL_0164: Expected O, but got I
		//IL_01a1: Expected O, but got I
		//IL_01e5: Expected O, but got I4
		//IL_01d7: Expected O, but got I4
		//IL_0349: Expected I, but got O
		if (first == null)
		{
			goto IL_02c2;
		}
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)first;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ r8_v2 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ r8_v2 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v30+FFFFFFF8+v53 @ rax_v4*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj3 = 1;
				goto IL_02ed;
			}
		}
		obj3 = 0;
		goto IL_02ed;
		IL_02c2:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_030f:
		return false;
		IL_02ed:
		bool flag = obj3 == null;
		ArcadeColliderType arcadeColliderType = null;
		if (!flag)
		{
			arcadeColliderType = first;
		}
		if (arcadeColliderType != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rbx_v3 (ArcadeColliderType)+260]");
			if ((nint)0 != 0)
			{
				goto IL_030f;
			}
			if (second != null)
			{
				nint num4 = (nint)typeof(Projectile);
				nint num5 = (nint)second;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+C8]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v9+FFFFFFF8+v76 @ rax_v8*8]");
					if (0 == (nint)typeof(Projectile))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v9+FFFFFFF8+v313 @ rcx_v6*8]");
						object obj7 = ((0 != (nint)typeof(Projectile)) ? ((object)0) : ((object)1));
						bool flag2 = obj7 == null;
						ArcadeColliderType arcadeColliderType2 = null;
						if (!flag2)
						{
							arcadeColliderType2 = second;
						}
						if (!((Projectile)arcadeColliderType2).HasAlreadyHitObject((IDamageable)arcadeColliderType))
						{
							float num7 = PPower();
							WeaponData currentWeaponData = _currentWeaponData;
							if (_currentWeaponData != null)
							{
								HitVfxType hitVfxType = currentWeaponData._003ChitVFX_003Ek__BackingField;
							}
							else
							{
								HitVfxType hitVfxType = HitVfxType.Default;
							}
							float knockback = base.Knockback;
							nint num8 = (nint)arcadeColliderType;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v361 @ rdx_v9 (Il2CppClass<ArcadeColliderType>)+3E8] (should have been resolved before IL gen)");
							float num9 = PPower();
							float num10 = knockback + base._003CStatsInflictedDamage_003Ek__BackingField;
							base._003CStatsInflictedDamage_003Ek__BackingField = num10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rbx_v3 (ArcadeColliderType)+260]");
							if ((nint)0 != 0)
							{
								float value = UnityEngine.Random.value;
								float num11 = PPower();
								float2 position = ((ArcadeSprite)arcadeColliderType).position;
								float num12 = value / 7f;
								float num13 = num12 * 0.15f;
								if (num13 > value)
								{
									MakeHeartPickup(position, value);
								}
							}
						}
						goto IL_030f;
					}
				}
			}
		}
		goto IL_02c2;
	}

	public void MakeHeartPickup(float2 pos, float rnd = 0.5f)
	{
		if (GM.Core.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.LITTLEHEART))
		{
			Vector2 pos2 = default(Vector2);
			Pickup pickup = PickupManager.CreatePickup(pos2, ItemType.LITTLEHEART);
			pickup.GoToLowestHealthPlayer();
			pickup.Time = 1f;
			return;
		}
		throw new NullReferenceException();
	}

	protected void Fire_FireCounter(bool skipTriggers = false)
	{
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			_counterWeapon.Fire(skipTriggers);
		}
	}

	public override bool LevelUp()
	{
		//IL_0077: Expected I4, but got O
		bool result = LevelUp(skipFire: false);
		Weapon counterWeapon = _counterWeapon;
		if ((object)_counterWeapon != null && ((UnityEngine.Object)counterWeapon).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_counterWeapon == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			bool flag = _counterWeapon.LevelUp();
		}
		return result;
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj > -1)
		{
			Weapon counterWeapon = _counterWeapon;
			if (((object)_counterWeapon == null || ((UnityEngine.Object)counterWeapon).m_CachedPtr == (IntPtr)0) && !_hasCounterWeapon)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
				_hasCounterWeapon = true;
				Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
				if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
				{
					_counterWeapon = weaponByType;
					_counterWeapon.Cleanup();
					GameObject gameObject = _counterWeapon.gameObject;
					gameObject.SetActive(value: true);
				}
				else
				{
					GameManager core2 = GM.Core;
					bool allowDuplicates = default(bool);
					Weapon counterWeapon2 = core2._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
					_counterWeapon = counterWeapon2;
				}
				Equipment counterWeapon3 = _counterWeapon;
				while (!counterWeapon3.IsMaxLevel())
				{
					bool flag = _counterWeapon.LevelUp(skipFire: true);
					counterWeapon3 = _counterWeapon;
				}
			}
		}
		GameManager core3 = GM.Core;
		ArcanaManager arcanaManager2 = core3._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj2 = default(object);
		if ((nint)obj2 > -1)
		{
			_cooldownAffectedByMovement = true;
		}
	}

	public override void SetVisible(bool visible)
	{
		PhaserSprite vortexBG = _vortexBG;
		_isVisible = visible;
		if ((object)_vortexBG != null && ((UnityEngine.Object)vortexBG).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _vortexBG.setVisible(visible);
		}
		PhaserSprite vortexOverlay = _vortexOverlay1;
		if ((object)_vortexOverlay1 != null && ((UnityEngine.Object)vortexOverlay).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite2 = _vortexOverlay1.setVisible(visible);
		}
		PhaserSprite vortexOverlay2 = _vortexOverlay2;
		if ((object)_vortexOverlay2 != null && ((UnityEngine.Object)vortexOverlay2).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite3 = _vortexOverlay2.setVisible(visible);
		}
		PhaserSprite vortexOverlay3 = _vortexOverlay3;
		if ((object)_vortexOverlay3 != null && ((UnityEngine.Object)vortexOverlay3).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite4 = _vortexOverlay3.setVisible(visible);
		}
		if (!visible)
		{
			if (_morphTimer != null)
			{
				_morphTimer.Cancel();
			}
		}
		else
		{
			StartMorphTimer();
		}
	}

	private void _003CInitRecoveredHPBonus_003Eb__50_1(float amount, float rawAmount)
	{
		float recoveredHP = amount + _recoveredHP;
		_recoveredHP = recoveredHP;
	}

	private void _003CStartMorphTimer_003Eb__58_0()
	{
		MorphEnemyInRange();
	}
}
