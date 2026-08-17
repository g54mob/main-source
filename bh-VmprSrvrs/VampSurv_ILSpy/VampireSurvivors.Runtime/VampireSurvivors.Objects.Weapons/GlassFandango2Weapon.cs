using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class GlassFandango2Weapon : GlassFandangoWeapon
{
	private Transform _Sky;

	private MeshRenderer _SkyMesh;

	private float StaggerA = 2f;

	private float StaggerB = 50f;

	private float StaggerC = 8f;

	private SfxType HitSound = SfxType.Orologion;

	private ParticleEmitterManager _zodiacBlurEmitterManager;

	private ParticleSystem _zodiacBlurEmitter;

	private bool _initialisedZodiacParticles;

	private static readonly int _ScrollSpeedX;

	private static readonly int _ScrollSpeedY;

	private static readonly int _AlphaMul;

	private List<PhaserSprite> _doilies;

	private bool _isStarryHeavenRunning;

	private bool _isStarryHeavenStopping;

	private float _StarryExecutionDelta;

	private readonly float _StarryExecutionTime = 10000f;

	private Timer _restartTimer;

	private PhaserSprite _sprZodiac;

	private MultiTargetTween _tween2;

	private Circle _pfxCircle;

	private bool _playSoundsDuringUpdate;

	private ParticleSystem _zodiacBlurEmitterLarge;

	private ParticleSystem _zodiacBlurEmitterBack;

	private float _detuneValue;

	private float _defaultSkyScale;

	private PhaserSprite _darkBackground;

	private MultiTargetTween _tween1;

	private BulletPool _tvExplosionPool;

	private bool _generatedPools;

	private float _StarryFiringDelta;

	private float _StarryFiringDelay = 50f;

	public BulletPool TVExplosionPool => _tvExplosionPool;

	public override float PSpeed()
	{
		WeaponData currentWeaponData = _currentWeaponData;
		return currentWeaponData._003Cspeed_003Ek__BackingField;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
		((Weapon)this)._003CFreezeChance_003Ek__BackingField = 0.01f;
		SetName("ZodiacWeapon");
		MakeSprites();
		MakeEmitters();
		MakeProjectiles();
		Material material = ((Renderer)_SkyMesh).GetMaterial();
		material.SetFloatImpl(_ScrollSpeedX, 0.5f);
		Material material2 = ((Renderer)_SkyMesh).GetMaterial();
		material2.SetFloatImpl(_ScrollSpeedY, 0.5f);
		Material material3 = ((Renderer)_SkyMesh).GetMaterial();
		material3.SetFloatImpl(_AlphaMul, 0f);
	}

	protected override void OnStart()
	{
		base.OnStart();
		MakeEmitters();
		MakeProjectiles();
	}

	public unsafe void MakeEmitters()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0151: Expected O, but got Ref
		//IL_016b: Expected native int or pointer, but got O
		//IL_0185: Expected O, but got I
		//IL_01a5: Expected O, but got Ref
		//IL_01bf: Expected native int or pointer, but got O
		//IL_0d4a: Expected O, but got I
		//IL_01f7: Expected O, but got Ref
		//IL_022c: Expected O, but got I
		//IL_0246: Expected native int or pointer, but got O
		//IL_0260: Expected O, but got I
		//IL_0280: Expected O, but got Ref
		//IL_029a: Expected native int or pointer, but got O
		//IL_0d84: Expected O, but got I
		//IL_02f1: Expected O, but got I
		//IL_0320: Expected O, but got I
		//IL_0425: Expected O, but got Ref
		//IL_043f: Expected native int or pointer, but got O
		//IL_0459: Expected O, but got I
		//IL_0479: Expected O, but got Ref
		//IL_0493: Expected native int or pointer, but got O
		//IL_04ae: Expected O, but got I
		//IL_0dd0: Expected O, but got I
		//IL_04ce: Expected O, but got Ref
		//IL_0503: Expected O, but got I
		//IL_051d: Expected native int or pointer, but got O
		//IL_0537: Expected O, but got I
		//IL_0e0a: Expected O, but got I
		//IL_0e44: Expected O, but got I
		//IL_05c0: Expected O, but got I
		//IL_05ef: Expected O, but got I
		//IL_06f4: Expected O, but got Ref
		//IL_070e: Expected native int or pointer, but got O
		//IL_0728: Expected O, but got I
		//IL_0748: Expected O, but got Ref
		//IL_0762: Expected native int or pointer, but got O
		//IL_0e90: Expected O, but got I
		//IL_079a: Expected O, but got Ref
		//IL_07c1: Expected O, but got I
		//IL_07db: Expected native int or pointer, but got O
		//IL_07f5: Expected O, but got I
		//IL_0815: Expected O, but got Ref
		//IL_082f: Expected native int or pointer, but got O
		//IL_0eca: Expected O, but got I
		//IL_0880: Expected O, but got I
		//IL_08af: Expected O, but got I
		//IL_0f1e: Expected O, but got Ref
		//IL_0f2b: Expected O, but got Ref
		//IL_0f4b: Expected O, but got Ref
		//IL_0a69: Expected O, but got I
		//IL_0f6a: Expected O, but got Ref
		//IL_0f84: Expected O, but got I
		//IL_1056: Expected O, but got Ref
		//IL_1070: Expected O, but got I
		//IL_0fe2: Expected O, but got Ref
		//IL_0ffc: Expected O, but got I
		//IL_10a6: Expected O, but got Ref
		//IL_0c00: Expected O, but got Ref
		//IL_0c19: Expected native int or pointer, but got O
		//IL_0c32: Expected O, but got Ref
		//IL_0c3f: Expected O, but got Ref
		//IL_0c4d: Expected O, but got Ref
		//IL_0c66: Expected native int or pointer, but got O
		//IL_0c7f: Expected O, but got Ref
		//IL_0c8c: Expected O, but got Ref
		//IL_0c9a: Expected O, but got Ref
		//IL_0cb3: Expected native int or pointer, but got O
		//IL_0ccb: Expected O, but got Ref
		//IL_0cd8: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (_initialisedZodiacParticles)
		{
			return;
		}
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 120f;
		_pfxCircle = circle;
		_initialisedZodiacParticles = true;
		GameObject gameObject = base.gameObject;
		ParticleEmitterManager zodiacBlurEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
		_zodiacBlurEmitterManager = zodiacBlurEmitterManager;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"_blurTime");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D0]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(100f, 1000f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
		_ = 0;
		particleSystemConfig._angleSteps = 64;
		_ = 50;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2D0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(300f, 600f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+100]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+110]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0.65f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+120]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+130]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-10]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2D0]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		particleSystemConfig._on = true;
		_ = 1092616192;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2D0]");
		particleSystemConfig._frequency = (float?)(object)0;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Edge;
		emitZone._source = _pfxCircle;
		particleSystemConfig._emitZone = emitZone;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		int version2 = list2._version + 1;
		list2._version = version2;
		string[] items2 = list2._items;
		if (list2._size >= items2.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"_blurTime2");
		}
		else
		{
			int size2 = list2._size + 1;
			list2._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+150]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(-100f, -1600f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+160]");
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 384));
		_ = 0;
		particleSystemConfig2._angleSteps = 47;
		_ = 4;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2D0]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(300f, 600f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+180]");
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = new ParticleSystem.MinMaxCurve(0.5f);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+20]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+40]");
		_ = 0;
		minMaxCurve8 = new ParticleSystem.MinMaxCurve(1f);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+68]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2D0]");
		particleSystemConfig2._blendMode = (BlendMode?)(object)0;
		particleSystemConfig2._on = true;
		_ = 1092616192;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2D0]");
		particleSystemConfig2._frequency = (float?)(object)0;
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Edge;
		emitZone2._source = _pfxCircle;
		particleSystemConfig2._emitZone = emitZone2;
		ParticleSystemConfig particleSystemConfig3 = new ParticleSystemConfig("vfx");
		List<string> list3 = new List<string>();
		int version3 = list3._version + 1;
		list3._version = version3;
		string[] items3 = list3._items;
		if (list3._size >= items3.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"_blurTime2");
		}
		else
		{
			int size3 = list3._size + 1;
			list3._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig3._frame = list3;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 416));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1A0]");
		particleSystemConfig3._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1B0]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 448));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(100f, 500f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1D0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+70]");
		particleSystemConfig3._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 480));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2D0]");
		particleSystemConfig3._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(100f, 1000f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1E0]");
		particleSystemConfig3._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1F0]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 512));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+200]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+210]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+98]");
		particleSystemConfig3._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B8]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2D0]");
		particleSystemConfig3._blendMode = (BlendMode?)(object)0;
		particleSystemConfig3._on = true;
		_ = 1092616192;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+2D0]");
		particleSystemConfig3._frequency = (float?)(object)0;
		EmitZone emitZone3 = new EmitZone();
		emitZone3._type = EmitZoneType.Edge;
		emitZone3._source = _pfxCircle;
		particleSystemConfig3._emitZone = emitZone3;
		Transform parent = base.transform;
		ParticleSystem zodiacBlurEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent, "ZodiacEmitter");
		_zodiacBlurEmitter = zodiacBlurEmitter;
		Transform parent2 = base.transform;
		ParticleSystem zodiacBlurEmitterLarge = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig2, parent2, "ZodiacEmitterLarge");
		_zodiacBlurEmitterLarge = zodiacBlurEmitterLarge;
		Transform parent3 = base.transform;
		ParticleSystem zodiacBlurEmitterBack = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig3, parent3, "ZodiacEmitterBack");
		_zodiacBlurEmitterBack = zodiacBlurEmitterBack;
		RenderingExtensions.SetDepth(_zodiacBlurEmitter, 1002);
		RenderingExtensions.SetDepth(_zodiacBlurEmitterLarge, 1001);
		RenderingExtensions.SetDepth(_zodiacBlurEmitterBack, 1000);
		ParticleSystemRenderer component = _zodiacBlurEmitter.GetComponent<ParticleSystemRenderer>();
		ParticleSystemRenderer component2 = _zodiacBlurEmitterLarge.GetComponent<ParticleSystemRenderer>();
		component.renderMode = ParticleSystemRenderMode.Stretch;
		component2.renderMode = ParticleSystemRenderMode.Stretch;
		_ = _zodiacBlurEmitterLarge;
		_ = _zodiacBlurEmitterLarge;
		minMaxCurve8 = new ParticleSystem.MinMaxCurve(1f);
		ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 744));
		ParticleSystem.MinMaxCurve minMaxCurve13 = default(ParticleSystem.MinMaxCurve);
		((ParticleSystem.MainModule*)mainModule)->startSize = (ParticleSystem.MinMaxCurve)(&minMaxCurve13);
		_ = _zodiacBlurEmitterBack;
		minMaxCurve8 = new ParticleSystem.MinMaxCurve(1f);
		ParticleSystem.MainModule mainModule2 = default(ParticleSystem.MainModule);
		mainModule2.startSize = (ParticleSystem.MinMaxCurve)(&minMaxCurve13);
		_ = _zodiacBlurEmitter;
		_ = _zodiacBlurEmitter;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3506 @ rax_v134 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj5 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
		}
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 120));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3531 @ rax_v137 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj7 == null)
			{
				MissingMethodException ex3 = new MissingMethodException();
				throw ex3;
			}
		}
		object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 736));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3556 @ rax_v140 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999BAE8]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj9 == null)
			{
				MissingMethodException ex4 = new MissingMethodException();
				throw ex4;
			}
		}
		object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 736));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3581 @ rax_v143 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
		AnimationCurve animationCurve = new AnimationCurve();
		IntPtr ptr = AnimationCurve.Internal_Create((Keyframe[])null);
		animationCurve.m_Ptr = ptr;
		animationCurve.m_RequiresNativeCleanup = true;
		int num = animationCurve.AddKey(0f, 0f);
		int num2 = animationCurve.AddKey(1f, 1f);
		ParticleSystem.MinMaxCurve minMaxCurve14 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 544));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve14, new ParticleSystem.MinMaxCurve(1f, animationCurve));
		ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = (ParticleSystem.SizeOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
		((ParticleSystem.SizeOverLifetimeModule*)sizeOverLifetimeModule)->size = (ParticleSystem.MinMaxCurve)(&minMaxCurve13);
		ParticleSystem.MinMaxCurve minMaxCurve15 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 576));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve15, new ParticleSystem.MinMaxCurve(1f, animationCurve));
		ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule2 = (ParticleSystem.SizeOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 104));
		((ParticleSystem.SizeOverLifetimeModule*)sizeOverLifetimeModule2)->size = (ParticleSystem.MinMaxCurve)(&minMaxCurve13);
		ParticleSystem.MinMaxCurve minMaxCurve16 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 608));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve16, new ParticleSystem.MinMaxCurve(2f, animationCurve));
		ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule3 = (ParticleSystem.SizeOverLifetimeModule)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
		((ParticleSystem.SizeOverLifetimeModule*)sizeOverLifetimeModule3)->size = (ParticleSystem.MinMaxCurve)(&minMaxCurve13);
		_zodiacBlurEmitter.Stop();
		_zodiacBlurEmitterLarge.Stop();
		_zodiacBlurEmitterBack.Stop();
	}

	public void MakeProjectiles()
	{
		//IL_0090: Expected I, but got O
		if (!_generatedPools)
		{
			_generatedPools = true;
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.STARRYHEAVENDAMAGE);
			BulletPool tvExplosionPool = new BulletPool(projectilePrefab);
			_tvExplosionPool = tvExplosionPool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.GlassFandango2Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_tvExplosionPool, core.Enemies, collideCallback, processCallback, callbackContext);
		}
	}

	public void ButtonStartStarryHeavens()
	{
		StartStarryHeavens();
	}

	public void FireSpecialProjectiles()
	{
		//IL_0057: Expected O, but got I
		//IL_00cc: Expected I, but got O
		//IL_00da: Expected I, but got O
		//IL_00ea: Expected O, but got I
		//IL_016a: Expected O, but got I4
		//IL_0126: Expected O, but got I
		//IL_015c: Expected O, but got I4
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		BulletPool tvExplosionPool = _tvExplosionPool;
		ObjectPool pool = tvExplosionPool._pool;
		Dictionary<int, GameObject> aliveObjects = pool._aliveObjects;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v5 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+20]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v5 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+28]");
		object obj = num - 0;
		if ((nint)obj >= 100)
		{
			return;
		}
		Projectile projectile = null;
		do
		{
			Projectile projectile2 = _tvExplosionPool.SpawnAt(position, this);
			Projectile projectile3;
			if ((object)projectile2 == null)
			{
				projectile3 = null;
				goto IL_01ff;
			}
			nint num2 = (nint)projectile2;
			nint num3 = (nint)typeof(InvisibleProjectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.InvisibleProjectile>)+130]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.InvisibleProjectile>)+130]");
			object obj4;
			if (num4 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rax_v29+FFFFFFF8+v261 @ rax_v25*8]");
				if (0 == (nint)typeof(InvisibleProjectile))
				{
					obj4 = 1;
					goto IL_01d8;
				}
			}
			obj4 = 0;
			goto IL_01d8;
			IL_01d8:
			bool flag = obj4 == null;
			projectile3 = null;
			if (!flag)
			{
				projectile3 = projectile2;
			}
			goto IL_01ff;
			IL_01ff:
			if ((object)projectile3 != null && ((UnityEngine.Object)projectile3).m_CachedPtr != (IntPtr)0)
			{
				projectile3.AimForRandomDirection();
			}
			projectile = (Projectile)(projectile + 1);
		}
		while ((nint)projectile < 12);
	}

	public unsafe void StartStarryHeavens()
	{
		//IL_0061: Expected O, but got I4
		//IL_01f4: Expected I4, but got F4
		//IL_0241: Expected I4, but got F4
		//IL_0289: Expected I4, but got F4
		//IL_02d6: Expected I4, but got F4
		//IL_02df->IL02ed: Incompatible stack heights: 3 vs 0
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		int num = config._003CRunStarryHeavnes_003Ek__BackingField + 1;
		config._003CRunStarryHeavnes_003Ek__BackingField = num;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num2 = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.OrologionEcho, soundConfig, 1000f, 1, num2);
		_detuneValue = 1100f;
		_StarryExecutionDelta = 0f;
		if (!_isStarryHeavenRunning)
		{
			_isStarryHeavenRunning = true;
			Transform transform = _zodiacBlurEmitter.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			bool value = default(bool);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
			Transform transform2 = _zodiacBlurEmitterLarge.transform;
			bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			bool value2 = default(bool);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value2));
			Transform transform3 = _zodiacBlurEmitterBack.transform;
			bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			bool value3 = default(bool);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)(&value3));
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			if (config2._003CFlashingVFXEnabled_003Ek__BackingField)
			{
				Camera main = Camera.main;
				float orthographicSize = main.orthographicSize;
				main.orthographicSize = 0.5f;
				TweenerCore<float, float, FloatOptions> tweenerCore = ShortcutExtensions.DOOrthoSize(main, orthographicSize, 0.2f);
			}
			exe_FadeInSky();
			Action onComplete = exe_SlowDownSky;
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			Action onComplete2 = exe_BringInBlurryZodiac;
			Timer timer2 = Timers.Register(1f, onComplete2, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			Action onComplete3 = exe_BringInZodiac;
			Timer timer3 = Timers.Register(2f, onComplete3, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			Action onComplete4 = exe_StartParticles;
			Timer timer4 = Timers.Register(2.5f, onComplete4, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
	}

	private void exe_CameraZoom()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			Camera main = Camera.main;
			float orthographicSize = main.orthographicSize;
			main.orthographicSize = 0.5f;
			TweenerCore<float, float, FloatOptions> tweenerCore = ShortcutExtensions.DOOrthoSize(main, orthographicSize, 0.2f);
		}
	}

	private unsafe void exe_FadeInSky()
	{
		//IL_013b: Expected O, but got Ref
		//IL_0158: Expected O, but got Ref
		//IL_0240: Expected I, but got O
		//IL_02e3->IL0273: Incompatible stack heights: 1 vs 0
		//IL_0062->IL0273: Incompatible stack heights: 1 vs 0
		//IL_0332->IL0273: Incompatible stack heights: 2 vs 0
		//IL_036d->IL0273: Incompatible stack heights: 2 vs 0
		//IL_00ac->IL0273: Incompatible stack heights: 2 vs 0
		//IL_00de->IL0273: Incompatible stack heights: 2 vs 0
		//IL_010a->IL0273: Incompatible stack heights: 2 vs 0
		//IL_0210->IL0210: Incompatible stack heights: 4 vs 3
		if ((object)_Sky != null)
		{
			Transform transform = _Sky.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Quaternion value = default(Quaternion);
				Transform.set_localRotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				if ((object)_Sky != null)
				{
					Transform transform2 = _Sky.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Vector3 value2 = default(Vector3);
						Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
						if ((object)_SkyMesh != null)
						{
							Material material = ((Renderer)_SkyMesh).GetMaterial();
							TweenerCore<float, float, FloatOptions> tweenerCore = ShortcutExtensions.DOFloat(material, 0.65f, _AlphaMul, 0.05f);
							if ((object)_SkyMesh != null)
							{
								Material material2 = ((Renderer)_SkyMesh).GetMaterial();
								if ((object)material2 != null)
								{
									material2.SetFloatImpl(_ScrollSpeedX, 0.5f);
									if ((object)_SkyMesh != null)
									{
										Material material3 = ((Renderer)_SkyMesh).GetMaterial();
										if ((object)material3 != null)
										{
											material3.SetFloatImpl(_ScrollSpeedY, 0.5f);
											object obj = default(object);
											TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(_Sky, (Vector3)(&obj), 0.5f);
											TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(_Sky, (Vector3)(&obj), 0.5f);
											if (_tween1 != null)
											{
												_tween1.Kill();
											}
											TweenConfig tweenConfig = new TweenConfig();
											object[] array = new object[1];
											bool flag3 = array == null;
											if ((object)_darkBackground != null)
											{
												void* value3 = ((IntPtr*)(&array))->m_value;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj2 = default(object);
												bool flag4 = obj2 == null;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											bool flag5 = tweenConfig == null;
											((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
											_ = 1132068864;
											_ = 1;
											MultiTargetTween tween = Tweens.Add(tweenConfig);
											_tween1 = tween;
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

	private void exe_SlowDownSky()
	{
		//IL_0173: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		//IL_008b: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		//IL_011f: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.StarryAttack, soundConfig, 1000f, 1, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 0.8f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Naplow, soundConfig2, 1000f, 4, time);
		SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
		soundConfig3.Volume = (float?)(object)1;
		soundConfig3.Rate = 0.9f;
		PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.Naplow, soundConfig3, 1000f, 4, time);
		SoundManager.SoundConfig soundConfig4 = new SoundManager.SoundConfig();
		soundConfig4.Volume = (float?)(object)1;
		soundConfig4.Rate = 1f;
		PlaySoundResult playSoundResult4 = SoundManager.PlaySound(SfxType.Naplow, soundConfig4, 1000f, 4, time);
		SoundManager.SoundConfig soundConfig5 = new SoundManager.SoundConfig();
		soundConfig5.Volume = (float?)(object)1;
		soundConfig5.Rate = 1.1f;
		PlaySoundResult playSoundResult5 = SoundManager.PlaySound(SfxType.Naplow, soundConfig5, 1000f, 4, time);
	}

	private unsafe void exe_BringInBlurryZodiac()
	{
		//IL_000e: Expected O, but got I4
		//IL_0018: Expected O, but got I4
		//IL_0153: Expected O, but got I4
		//IL_0161: Expected O, but got I4
		//IL_016f: Expected O, but got I4
		//IL_0099: Expected O, but got I4
		//IL_00cf: Expected O, but got Ref
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		List<PhaserSprite> doilies = _doilies;
		object obj = 0;
		object obj2 = 0;
		object obj3 = default(object);
		object obj4 = default(object);
		while (true)
		{
			if ((nint)obj2 < doilies._size)
			{
				List<PhaserSprite> doilies2 = _doilies;
				if ((nint)obj >= doilies2._size)
				{
					break;
				}
				PhaserSprite[] items = doilies2._items;
				PhaserSprite phaserSprite = items[obj].setAlpha(0.9f);
				PhaserSprite phaserSprite2 = items[obj].setScale(10f, (float?)(object)0);
				Transform transform = items[obj].transform;
				transform.localEulerAngles = (Vector3)(&obj3);
				doilies = _doilies;
				obj++;
				obj3 = obj4;
				obj2 = obj;
				continue;
			}
			TweenConfig tweenConfig = new TweenConfig();
			PhaserSprite[] targets = _doilies.ToArray();
			tweenConfig.targets = targets;
			tweenConfig.ease = Ease.Linear;
			tweenConfig.alpha = (float?)(object)1;
			tweenConfig.angle = (float?)(object)1;
			tweenConfig.scale = (float?)(object)1;
			Func<int, float> staggerDelay = Tweens.Stagger(StaggerB);
			tweenConfig.staggerDelay = staggerDelay;
			tweenConfig.duration = 700f;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe void exe_BringInZodiac()
	{
		//IL_0047: Expected O, but got I4
		//IL_00bc: Expected O, but got I4
		//IL_00e6: Expected O, but got Ref
		//IL_015e: Expected I, but got O
		//IL_01c2: Expected O, but got I4
		TweenConfig tweenConfig = new TweenConfig();
		PhaserSprite[] targets = _doilies.ToArray();
		tweenConfig.targets = targets;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.alpha = (float?)(object)1;
		Func<int, float> staggerDelay = Tweens.Stagger(StaggerC);
		tweenConfig.staggerDelay = staggerDelay;
		tweenConfig.duration = 500f;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		PhaserSprite phaserSprite = _sprZodiac.setAlpha(0f);
		PhaserSprite phaserSprite2 = _sprZodiac.setScale(2f, (float?)(object)0);
		Transform transform = _sprZodiac.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array = new object[1];
		if ((object)_sprZodiac != null)
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
		tweenConfig2.targets = array;
		tweenConfig2.duration = 500f;
		tweenConfig2.alpha = (float?)(object)1;
		MultiTargetTween tween = Tweens.Add(tweenConfig2);
		_tween2 = tween;
	}

	private unsafe void exe_StartParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0066: Expected I, but got O
		//IL_00e9: Expected O, but got I
		//IL_010a: Expected O, but got I
		//IL_015b: Expected O, but got I
		//IL_0326: Expected O, but got Ref
		//IL_0340: Expected native int or pointer, but got O
		//IL_0358: Expected O, but got Ref
		//IL_0394: Expected O, but got Ref
		//IL_03a9: Expected native int or pointer, but got O
		//IL_01ee: Expected O, but got Ref
		//IL_0208: Expected native int or pointer, but got O
		//IL_03c1: Expected O, but got Ref
		//IL_03fd: Expected O, but got Ref
		//IL_0421: Expected native int or pointer, but got O
		//IL_0220: Expected O, but got Ref
		//IL_025c: Expected O, but got Ref
		//IL_0271: Expected native int or pointer, but got O
		//IL_043b: Expected O, but got I
		//IL_044b: Expected O, but got I
		//IL_0289: Expected O, but got Ref
		//IL_02c5: Expected O, but got Ref
		//IL_02e9: Expected native int or pointer, but got O
		//IL_04d1: Expected O, but got Ref
		//IL_0303: Expected O, but got I
		//IL_0313: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (_tween2 != null)
		{
			_tween2.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_sprZodiac != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 500f;
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
		tweenConfig.alpha = (float?)(object)0;
		_ = 1074580685;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
		tweenConfig.scale = (float?)(object)0;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween2 = tween;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		_ = 0;
		_ = 1067030938;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
		soundConfig.Volume = (float?)(object)0;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.StarryAttack, soundConfig, 100f, 1, time);
		_playSoundsDuringUpdate = true;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		ParticleSystem zodiacBlurEmitterBack;
		if (config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0.65f, 0f));
			ParticleSystem.MinMaxCurve value = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-49]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-39]");
			_ = 0;
			RenderingExtensions.SetAlpha(_zodiacBlurEmitter, value);
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0.5f));
			ParticleSystem.MinMaxCurve value2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-19]");
			_ = 0;
			RenderingExtensions.SetAlpha(_zodiacBlurEmitterLarge, value2);
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			zodiacBlurEmitterBack = _zodiacBlurEmitterBack;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0.5f, 0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-9]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+7]");
			object obj5 = 0;
		}
		else
		{
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0.15f, 0f));
			ParticleSystem.MinMaxCurve value3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-9]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+7]");
			_ = 0;
			RenderingExtensions.SetAlpha(_zodiacBlurEmitter, value3);
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.1f));
			ParticleSystem.MinMaxCurve value4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-29]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-19]");
			_ = 0;
			RenderingExtensions.SetAlpha(_zodiacBlurEmitterLarge, value4);
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
			zodiacBlurEmitterBack = _zodiacBlurEmitterBack;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.1f, 0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-49]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-39]");
			object obj5 = 0;
		}
		ParticleSystem.MinMaxCurve value5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
		RenderingExtensions.SetAlpha(zodiacBlurEmitterBack, value5);
		_zodiacBlurEmitter.Play(withChildren: true);
		_zodiacBlurEmitterLarge.Play(withChildren: true);
		_zodiacBlurEmitterBack.Play(withChildren: true);
	}

	public void StopStarryHeaven()
	{
		//IL_00b8: Expected I, but got O
		//IL_011c: Expected O, but got I4
		if (_isStarryHeavenStopping)
		{
			return;
		}
		_isStarryHeavenStopping = true;
		_zodiacBlurEmitter.Stop();
		_zodiacBlurEmitterLarge.Stop();
		_zodiacBlurEmitterBack.Stop();
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_darkBackground != null)
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
		tweenConfig.duration = 500f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween tween = Tweens.Add(tweenConfig);
		_tween1 = tween;
		Material material = ((Renderer)_SkyMesh).GetMaterial();
		TweenerCore<float, float, FloatOptions> tweenerCore = ShortcutExtensions.DOFloat(material, 0f, _AlphaMul, 0.5f);
		Action onComplete = ClearFlags;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer restartTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_restartTimer = restartTimer;
	}

	public void ClearFlags()
	{
		_playSoundsDuringUpdate = false;
		_isStarryHeavenRunning = false;
	}

	public override void InternalUpdate()
	{
		//IL_00ad: Expected O, but got I4
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		if (!((_StarryExecutionDelta = num + _StarryExecutionDelta) < _StarryExecutionTime) && _isStarryHeavenRunning)
		{
			StopStarryHeaven();
		}
		if (_playSoundsDuringUpdate)
		{
			float num2 = num * 0.2f;
			float detuneValue = num2 + _detuneValue;
			_detuneValue = detuneValue;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Detune = _detuneValue;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(HitSound, soundConfig, 50f, 2, time);
			if (!((_StarryFiringDelta = num + _StarryFiringDelta) < _StarryFiringDelay))
			{
				_StarryFiringDelta = 0f;
				FireSpecialProjectiles();
			}
		}
	}

	protected override void OnPause()
	{
		Material material = ((Renderer)_SkyMesh).GetMaterial();
		material.SetFloatImpl(_ScrollSpeedX, 0f);
		Material material2 = ((Renderer)_SkyMesh).GetMaterial();
		material2.SetFloatImpl(_ScrollSpeedY, 0f);
	}

	protected override void OnResume()
	{
		Material material = ((Renderer)_SkyMesh).GetMaterial();
		material.SetFloatImpl(_ScrollSpeedX, 0.5f);
		Material material2 = ((Renderer)_SkyMesh).GetMaterial();
		material2.SetFloatImpl(_ScrollSpeedY, 0.5f);
	}

	private unsafe void MakeSprites()
	{
		//IL_01a5: Expected O, but got F4
		//IL_022c: Expected O, but got I4
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected O, but got Unknown
		//IL_0440: Expected O, but got I4
		//IL_0490: Expected O, but got I4
		//IL_055b: Expected O, but got I4
		//IL_05fc: Expected I4, but got I8
		//IL_00d3->IL0699: Incompatible stack heights: 1 vs 0
		//IL_0761->IL0699: Incompatible stack heights: 1 vs 0
		//IL_0107->IL0699: Incompatible stack heights: 1 vs 0
		//IL_013a->IL0699: Incompatible stack heights: 1 vs 0
		//IL_0788->IL0699: Incompatible stack heights: 1 vs 0
		//IL_0161->IL0699: Incompatible stack heights: 1 vs 0
		//IL_017f->IL0699: Incompatible stack heights: 1 vs 0
		//IL_0331->IL07a6: Incompatible stack heights: 4 vs 1
		Camera main = Camera.main;
		float num = (float)CameraExtensions.OrthographicBounds(main).m_Extents * 2f;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v6 (UnityEngine.Bounds)+10]");
		float num2 = 0f * 2f;
		if (!(num > num2))
		{
			num = num2;
		}
		float num3 = num + num;
		float defaultSkyScale = num3 * 0.35f;
		_defaultSkyScale = defaultSkyScale;
		if ((object)_Sky != null)
		{
			Transform transform = _Sky.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector2 value = default(Vector2);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
				List<PhaserSprite> doilies = new List<PhaserSprite>();
				_doilies = doilies;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer = s_scene._renderer;
						if (s_scene._renderer != null)
						{
							float num4 = renderer.width * 0.5f;
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene2 = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null && s_scene2._renderer != null && (object)GM.Core != null)
								{
									Transform transform2 = null;
									do
									{
										GameObject gameObject = base.gameObject;
										PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, (Vector2)num4, "vfx", "ZodiacBlur");
										PhaserSprite phaserSprite2 = RenderingExtensions.SetScrollFactor(phaserSprite, 0f);
										bool flag2 = (object)phaserSprite == null;
										PhaserSprite phaserSprite3 = phaserSprite.setBlendMode(BlendMode.Normal);
										PhaserSprite phaserSprite4 = phaserSprite.setAlpha(0f);
										PhaserSprite phaserSprite5 = phaserSprite.setDepth(1000);
										PhaserSprite phaserSprite6 = phaserSprite.setScale(6f, (float?)(object)0);
										List<object> doilies2 = (List<object>)(object)_doilies;
										bool flag3 = _doilies == null;
										int version = doilies2._version + 1;
										doilies2._version = version;
										object[] items = doilies2._items;
										bool flag4 = doilies2._items == null;
										if (doilies2._size >= items.Length)
										{
											((List<object>)(object)_doilies).AddWithResize((object)phaserSprite);
										}
										else
										{
											int size = doilies2._size + 1;
											doilies2._size = size;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										}
										transform2 = (Transform)(transform2 + 1);
									}
									while ((nint)transform2 < 6);
									GameObject gameObject2 = base.gameObject;
									Vector2 pos = default(Vector2);
									PhaserSprite sprZodiac = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "vfx", "Zodiac");
									_sprZodiac = sprZodiac;
									PhaserSprite phaserSprite7 = RenderingExtensions.SetScrollFactor(_sprZodiac, 0f);
									bool flag5 = (object)_sprZodiac == null;
									PhaserSprite phaserSprite8 = _sprZodiac.setBlendMode(BlendMode.Add);
									bool flag6 = (object)_sprZodiac == null;
									PhaserSprite phaserSprite9 = _sprZodiac.setAlpha(0f);
									bool flag7 = (object)_sprZodiac == null;
									PhaserSprite phaserSprite10 = _sprZodiac.setDepth(1000);
									bool flag8 = (object)_sprZodiac == null;
									PhaserSprite phaserSprite11 = _sprZodiac.setScale(6f, (float?)(object)0);
									GameObject gameObject3 = base.gameObject;
									PhaserSprite phaserSprite12 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "vfx", "blackDot");
									bool flag9 = (object)phaserSprite12 == null;
									PhaserSprite phaserSprite13 = phaserSprite12.setOrigin(0f, (float?)(object)0);
									bool flag10 = (object)GM.Core == null;
									PhaserScene s_scene3 = ArcadePhysics.s_scene;
									bool flag11 = ArcadePhysics.s_scene == null;
									PhaserScene.Renderer renderer2 = s_scene3._renderer;
									bool flag12 = s_scene3._renderer == null;
									bool flag13 = (object)GM.Core == null;
									PhaserScene s_scene4 = ArcadePhysics.s_scene;
									bool flag14 = ArcadePhysics.s_scene == null;
									bool flag15 = s_scene4._renderer == null;
									bool flag16 = (object)phaserSprite13 == null;
									float xScale = renderer2.width * 100f;
									PhaserSprite phaserSprite14 = phaserSprite13.setScale(xScale, (float?)(object)1);
									bool flag17 = (object)phaserSprite14 == null;
									PhaserSprite phaserSprite15 = phaserSprite14.setBlendMode(BlendMode.Normal);
									bool flag18 = (object)phaserSprite15 == null;
									PhaserSprite component = phaserSprite15.setAlpha(0f);
									PhaserSprite phaserSprite16 = RenderingExtensions.SetScrollFactor(component, 0f);
									bool flag19 = (object)phaserSprite16 == null;
									PhaserSprite phaserSprite17 = phaserSprite16.setDepth(-1998);
									bool flag20 = (object)phaserSprite17 == null;
									GameObject gameObject4 = phaserSprite17.gameObject;
									bool flag21 = (object)gameObject4 == null;
									((UnityEngine.Object)gameObject4).SetName("darkBackground");
									_darkBackground = phaserSprite17;
									PhaserSprite darkBackground = _darkBackground;
									bool flag22 = (object)_darkBackground == null;
									SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(darkBackground._spriteRenderer, 1f);
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Cleanup()
	{
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_016c: Expected I4, but got O
		//IL_04e0->IL0490: Incompatible stack heights: 1 vs 0
		//IL_0554->IL0504: Incompatible stack heights: 1 vs 0
		((Weapon)this).Cleanup();
		if (base._walkedTimer != null)
		{
			base._walkedTimer.Cancel();
		}
		List<PhaserSprite> doilies = _doilies;
		if (_doilies != null)
		{
			object obj = null;
			bool flag = false;
			List<PhaserSprite> doilies2 = _doilies;
			while (true)
			{
				if ((flag ? 1 : 0) < doilies._size)
				{
					if (doilies2 == null)
					{
						break;
					}
					if ((nint)obj < doilies2._size)
					{
						PhaserSprite[] items = doilies2._items;
						if (doilies2._items == null)
						{
							break;
						}
						if ((nint)obj < items.Length)
						{
							if ((object)items[obj] == null)
							{
								break;
							}
							PhaserSprite phaserSprite = items[obj].setVisible(visible: false);
							doilies2 = _doilies;
							obj++;
							if (_doilies == null)
							{
								break;
							}
							flag = (byte)(int)obj != 0;
							doilies = _doilies;
							continue;
						}
					}
					else
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					}
					throw new IndexOutOfRangeException();
				}
				object sprZodiac = _sprZodiac;
				if ((object)_sprZodiac != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rbx_v11 (System.Object)+10]");
					if ((nint)0 != 0)
					{
						if ((object)_sprZodiac == null)
						{
							break;
						}
						PhaserSprite phaserSprite2 = _sprZodiac.setVisible(visible: false);
					}
				}
				object darkBackground = _darkBackground;
				if ((object)_darkBackground != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rbx_v12 (System.Object)+10]");
					if ((nint)0 != 0)
					{
						if ((object)_darkBackground == null)
						{
							break;
						}
						PhaserSprite phaserSprite3 = _darkBackground.setVisible(visible: false);
					}
				}
				ParticleSystem zodiacBlurEmitter = _zodiacBlurEmitter;
				if ((object)_zodiacBlurEmitter != null && ((UnityEngine.Object)zodiacBlurEmitter).m_CachedPtr != (IntPtr)0)
				{
					object zodiacBlurEmitter2 = _zodiacBlurEmitter;
					if ((object)_zodiacBlurEmitter == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rbx_v22 (System.Object)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rbx_v22 (System.Object)+10]");
					ParticleSystem.Stop_Injected((IntPtr)0, true, ParticleSystemStopBehavior.StopEmitting);
				}
				ParticleSystem zodiacBlurEmitterLarge = _zodiacBlurEmitterLarge;
				if ((object)_zodiacBlurEmitterLarge != null && ((UnityEngine.Object)zodiacBlurEmitterLarge).m_CachedPtr != (IntPtr)0)
				{
					object zodiacBlurEmitterLarge2 = _zodiacBlurEmitterLarge;
					if ((object)_zodiacBlurEmitterLarge == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rbx_v21 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rbx_v21 (System.Object)+10]");
					ParticleSystem.Stop_Injected((IntPtr)0, true, ParticleSystemStopBehavior.StopEmitting);
				}
				ParticleSystem zodiacBlurEmitterBack = _zodiacBlurEmitterBack;
				if ((object)_zodiacBlurEmitterBack != null && ((UnityEngine.Object)zodiacBlurEmitterBack).m_CachedPtr != (IntPtr)0)
				{
					object zodiacBlurEmitterBack2 = _zodiacBlurEmitterBack;
					if ((object)_zodiacBlurEmitterBack == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rbx_v20 (System.Object)+10]");
					if ((nint)0 == 0)
					{
						UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_zodiacBlurEmitterBack);
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rbx_v20 (System.Object)+10]");
					ParticleSystem.Stop_Injected((IntPtr)0, true, ParticleSystemStopBehavior.StopEmitting);
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public GlassFandango2Weapon()
	{
		ProjectilePixelSize = 40f;
		((Weapon)this)._002Ector();
	}

	static GlassFandango2Weapon()
	{
		int scrollSpeedX = Shader.PropertyToID("_ScrollSpeedX");
		_ScrollSpeedX = scrollSpeedX;
		int scrollSpeedY = Shader.PropertyToID("_ScrollSpeedY");
		_ScrollSpeedY = scrollSpeedY;
		int alphaMul = Shader.PropertyToID("_AlphaMul");
		_AlphaMul = alphaMul;
	}
}
