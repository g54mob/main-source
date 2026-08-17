using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class OphionProjectile : Projectile
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__25_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CImplode_003Eb__25_0()
		{
		}
	}

	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public OphionProjectile _003C_003E4__this;

		public float scale;

		internal void _003CExplode_003Eb__1()
		{
			//IL_004d: Expected O, but got I4
			OphionProjectile ophionProjectile = _003C_003E4__this;
			PhaserSprite phaserSprite = ophionProjectile._snakeSprite.setAlpha(0f);
			OphionProjectile ophionProjectile2 = _003C_003E4__this;
			PhaserSprite phaserSprite2 = ophionProjectile2._snakeSprite.setScale(0f, (float?)(object)0);
			OphionProjectile ophionProjectile3 = _003C_003E4__this;
			PhaserSprite phaserSprite3 = ophionProjectile3._snakeSprite.setVisible(visible: true);
		}

		internal void _003CExplode_003Eb__2()
		{
			//IL_0027: Expected O, but got I4
			//IL_0052: Expected O, but got I4
			OphionProjectile ophionProjectile = _003C_003E4__this;
			PhaserSprite phaserSprite = ophionProjectile._snakeSprite.setScale(0f, (float?)(object)0);
			OphionProjectile ophionProjectile2 = _003C_003E4__this;
			PhaserSprite phaserSprite2 = ophionProjectile2._displaySprite.setScale(0f, (float?)(object)0);
			OphionProjectile ophionProjectile3 = _003C_003E4__this;
			PhaserSprite phaserSprite3 = ophionProjectile3._displaySprite.setVisible(visible: true);
		}

		internal void _003CExplode_003Eb__3()
		{
			//IL_009a: Expected I, but got O
			//IL_0110: Expected I4, but got I8
			//IL_011e: Expected O, but got I4
			OphionProjectile ophionProjectile = _003C_003E4__this;
			RenderingExtensions.Start(ophionProjectile._purpleEmitter1);
			OphionProjectile ophionProjectile2 = _003C_003E4__this;
			RenderingExtensions.Start(ophionProjectile2._purpleEmitter2);
			OphionProjectile ophionProjectile3 = _003C_003E4__this;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			OphionProjectile ophionProjectile4 = _003C_003E4__this;
			if ((object)ophionProjectile4._displaySprite != null)
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
			tweenConfig.duration = 100f;
			tweenConfig.yoyo = true;
			tweenConfig.repeat = -1;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween displayScaleTween = Tweens.Add(tweenConfig);
			ophionProjectile3._displayScaleTween2 = displayScaleTween;
		}

		internal void _003CExplode_003Eb__0()
		{
			_003C_003E4__this.Implode();
		}
	}

	private float _exploRadius = 16f;

	private PhaserSprite _snakeSprite;

	private MultiTargetTween _explosionTween;

	private bool _isExploding;

	private ShadowServantWeapon _trueWeaponShadowSerpant;

	private OphionWeapon _trueWeapon;

	private ParticleEmitterManager _particlesManager;

	private Circle _explosionCircle;

	private ParticleSystem _purpleEmitter1;

	private ParticleSystem _purpleEmitter2;

	private MultiTargetTween _displayScaleTween;

	private MultiTargetTween _displayScaleTween2;

	private PhaserSprite _displaySprite;

	private MultiTargetTween _snakeTween;

	private MultiTargetTween _scaleTween;

	private Timer _durationTimer;

	private MultiTargetTween _implosionTween;

	private Timer _hitboxTimer;

	public float _explo1DUration = 500f;

	public float _explo2DUration = 100f;

	public float _explo3DUration = 200f;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0116: Expected O, but got I4
		//IL_0116: Expected I4, but got O
		//IL_01d7: Expected O, but got I
		//IL_0324: Expected F4, but got I
		//IL_0337: Expected O, but got I4
		//IL_0366: Expected F4, but got I
		//IL_0379: Expected O, but got I4
		//IL_03a0: Expected O, but got I4
		//IL_03b9: Expected O, but got Ref
		//IL_03d3: Expected native int or pointer, but got O
		//IL_03ed: Expected O, but got I
		//IL_040d: Expected O, but got Ref
		//IL_0427: Expected native int or pointer, but got O
		//IL_0441: Expected O, but got I
		//IL_0461: Expected O, but got Ref
		//IL_0489: Expected native int or pointer, but got O
		//IL_0b80: Expected O, but got I4
		//IL_04ae: Expected O, but got Ref
		//IL_04d5: Expected O, but got I
		//IL_04ef: Expected native int or pointer, but got O
		//IL_0bba: Expected O, but got I
		//IL_0527: Expected O, but got Ref
		//IL_0541: Expected native int or pointer, but got O
		//IL_0bf4: Expected O, but got I
		//IL_0592: Expected O, but got I
		//IL_05b3: Expected O, but got I
		//IL_070b: Expected F4, but got I
		//IL_071e: Expected O, but got I4
		//IL_074d: Expected F4, but got I
		//IL_0760: Expected O, but got I4
		//IL_0787: Expected O, but got I4
		//IL_07a0: Expected O, but got Ref
		//IL_07ba: Expected native int or pointer, but got O
		//IL_07d4: Expected O, but got I
		//IL_07f4: Expected O, but got Ref
		//IL_080e: Expected native int or pointer, but got O
		//IL_0828: Expected O, but got I
		//IL_0848: Expected O, but got Ref
		//IL_0870: Expected native int or pointer, but got O
		//IL_0898: Expected O, but got I
		//IL_0c40: Expected O, but got I
		//IL_08ab: Expected O, but got Ref
		//IL_08d2: Expected O, but got I
		//IL_08ec: Expected native int or pointer, but got O
		//IL_0c7a: Expected O, but got I
		//IL_0924: Expected O, but got Ref
		//IL_093e: Expected native int or pointer, but got O
		//IL_0cb4: Expected O, but got I
		//IL_098f: Expected O, but got I
		//IL_09b0: Expected O, but got I
		//IL_0a5d: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("_OPBubble", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		_speed = 2f;
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 vector = default(Vector2);
		PhaserSprite displaySprite = instance.AddPhaserSprite(vector, "vfx", "_OPBubble");
		_displaySprite = displaySprite;
		PhaserWorld instance2 = PhaserWorld.Instance;
		PhaserSprite snakeSprite = instance2.AddPhaserSprite(vector, "vfx", "Ophion0000");
		_snakeSprite = snakeSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Ophion", 0, 31, vector, text, num, flag);
		PhaserSprite snakeSprite2 = _snakeSprite;
		bool autoSetAnimation = default(bool);
		snakeSprite2._spriteAnimation.AddAnimation("loop", animationFrames, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite snakeSprite3 = _snakeSprite;
		snakeSprite3._spriteAnimation.SetAnimation("loop");
		GameObject gameObject = base.gameObject;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v610 @ rbx_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 528))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+210]");
			particlesManager = (ParticleEmitterManager)0;
		}
		else
		{
			particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particlesManager = particlesManager;
		Circle circle = new Circle();
		circle._radius = _exploRadius;
		circle._x = 0f;
		_explosionCircle = circle;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"OPpfx");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+210]");
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		float2 float6 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+214]");
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+60]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+70]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		particleSystemConfig._angleSteps = 16;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(50f, 80f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
		_ = 0;
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+210]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
		_ = 0;
		_ = 0;
		_ = 1065353216;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+210]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+210]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = _explosionCircle;
		particleSystemConfig._emitZone = emitZone;
		particleSystemConfig._on = false;
		ParticleSystem purpleEmitter = _particlesManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter2");
		_purpleEmitter2 = purpleEmitter;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		int version2 = list2._version + 1;
		list2._version = version2;
		string[] items2 = list2._items;
		if (list2._size >= items2.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"OPpfx2");
		}
		else
		{
			int num4 = list2._size + 1;
			list2._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		float2 float7 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+210]");
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		float2 float8 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+214]");
		minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
		particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+100]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+110]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+120]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+130]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
		particleSystemConfig2._angleSteps = 16;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(50f, 80f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+150]");
		obj = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+210]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+160]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+10]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+30]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 384));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+180]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
		_ = 0;
		_ = 0;
		_ = 1065353216;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+210]");
		particleSystemConfig2._frequency = (float?)(object)0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+210]");
		particleSystemConfig2._blendMode = (BlendMode?)(object)0;
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Random;
		emitZone2._source = _explosionCircle;
		particleSystemConfig2._emitZone = emitZone2;
		particleSystemConfig2._on = false;
		ParticleSystem purpleEmitter2 = _particlesManager.CreateEmitter(particleSystemConfig2, null, "_pfxEmitter");
		_purpleEmitter1 = purpleEmitter2;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserSprite snakeSprite4 = _snakeSprite;
		int num5 = -renderer.pixelHeight;
		object obj3 = num5 - 2;
		float num6 = (float)obj3 * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		int sortingOrder = default(int);
		snakeSprite4._spriteRenderer.sortingOrder = sortingOrder;
		float num7 = (float)num5 - 1f;
		_particlesManager.SetDepthMultiplied(num7);
		PhaserSprite displaySprite2 = _displaySprite;
		float num8 = (float)num5 * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		int sortingOrder2 = default(int);
		displaySprite2._spriteRenderer.sortingOrder = sortingOrder2;
		float num9 = (float)num5 * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
		int sortingOrder3 = default(int);
		_renderer.sortingOrder = sortingOrder3;
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		PhaserSprite phaserSprite = _displaySprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _snakeSprite.setVisible(visible: false);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_065d: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_00e7: Expected I, but got O
		//IL_00ef: Expected I, but got O
		//IL_00ff: Expected O, but got I
		//IL_017f: Expected O, but got I4
		//IL_00d4: Expected O, but got I4
		//IL_0692: Expected O, but got I4
		//IL_013b: Expected O, but got I
		//IL_01a1: Expected O, but got I4
		//IL_0171: Expected O, but got I4
		//IL_01f6: Expected O, but got I4
		//IL_01f6: Expected O, but got I4
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Expected I4, but got Unknown
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ab: Expected I4, but got Unknown
		//IL_06ea->IL05fd: Incompatible stack heights: 1 vs 0
		//IL_021e->IL05fd: Incompatible stack heights: 1 vs 0
		//IL_025a->IL05fd: Incompatible stack heights: 1 vs 0
		//IL_028d->IL05fd: Incompatible stack heights: 1 vs 0
		//IL_02cb->IL05fd: Incompatible stack heights: 1 vs 0
		//IL_037c->IL05fd: Incompatible stack heights: 1 vs 0
		//IL_03f6->IL05fd: Incompatible stack heights: 1 vs 0
		//IL_045f->IL05fd: Incompatible stack heights: 1 vs 0
		//IL_04d9->IL05fd: Incompatible stack heights: 1 vs 0
		//IL_0501->IL05fd: Incompatible stack heights: 1 vs 0
		//IL_057d->IL05fd: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		float? trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0636;
		}
		nint num = (nint)typeof(OphionWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v52 (Il2CppClass<VampireSurvivors.Objects.Weapons.OphionWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v46 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v52 (Il2CppClass<VampireSurvivors.Objects.Weapons.OphionWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v46 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v100+FFFFFFF8+v71 @ rax_v95*8]");
			if (0 == (nint)typeof(OphionWeapon))
			{
				obj3 = 1;
				goto IL_0645;
			}
		}
		obj3 = 0;
		goto IL_0645;
		IL_066b:
		float? trueWeaponShadowSerpant;
		_trueWeaponShadowSerpant = (ShadowServantWeapon)trueWeaponShadowSerpant;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			if (body != null)
			{
				BaseBody baseBody = body.setCircle(24f, (float?)(object)1, (float?)(object)1);
				BaseBody baseBody2 = body;
				if (body != null)
				{
					baseBody2._enable = true;
					ArcadeSprite arcadeSprite2 = setVisible(visible: false);
					if ((object)_displaySprite != null)
					{
						PhaserSprite phaserSprite = _displaySprite.setVisible(visible: false);
						if ((object)_snakeSprite != null)
						{
							PhaserSprite phaserSprite2 = _snakeSprite.setVisible(visible: false);
							_isExploding = false;
							if ((object)_weapon != null)
							{
								float num4 = _weapon.PArea();
								Circle circle = new Circle();
								object obj4 = default(object);
								float radius = (float)obj4 * _exploRadius;
								circle._x = 0f;
								circle._radius = radius;
								_explosionCircle = circle;
								EmitZone emitZone = new EmitZone
								{
									_type = EmitZoneType.Random,
									_source = _explosionCircle
								};
								RenderingExtensions.SetEmitZone(_purpleEmitter1, emitZone);
								if ((object)_weapon != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul dword ptr [rcx+4Ch]\"");
									object obj5 = (object)emitZone >> 31;
									object obj6 = (object)emitZone + obj5;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
									int quantity = obj6 + 1;
									RenderingExtensions.SetQuantity(_purpleEmitter2, quantity);
									if ((object)_purpleEmitter1 != null)
									{
										_purpleEmitter1.Stop();
										EmitZone emitZone2 = new EmitZone
										{
											_type = EmitZoneType.Random,
											_source = _explosionCircle
										};
										RenderingExtensions.SetEmitZone(_purpleEmitter1, emitZone2);
										if ((object)_weapon != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul dword ptr [rcx+4Ch]\"");
											object obj7 = (object)emitZone2 >> 31;
											object obj8 = (object)emitZone2 + obj7;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
											int quantity2 = obj8 + 1;
											RenderingExtensions.SetQuantity(_purpleEmitter2, quantity2);
											if ((object)_purpleEmitter2 != null)
											{
												_purpleEmitter2.Stop();
												if ((object)weapon != null)
												{
													if (!weapon.IsHoming)
													{
														Transform transform2 = base.AimForRandomEnemy();
													}
													else
													{
														Transform transform3 = base.AimForNearestEnemyToPlayer();
													}
													if (_hitboxTimer != null)
													{
														_hitboxTimer.Cancel();
													}
													if ((object)_weapon != null)
													{
														float hitBoxDelay = _weapon.HitBoxDelay;
														Action onComplete = delegate
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
														};
														float duration = hitBoxDelay * 0.001f;
														bool useRealTime = default(bool);
														MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
														int repeat = default(int);
														TimerType type = default(TimerType);
														Timer hitboxTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
														_hitboxTimer = hitboxTimer;
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
		throw new NullReferenceException();
		IL_0636:
		_trueWeapon = (OphionWeapon)trueWeapon;
		if ((object)weapon == null)
		{
			trueWeaponShadowSerpant = (float?)(object)0;
			goto IL_066b;
		}
		nint num5 = (nint)typeof(ShadowServantWeapon);
		nint num6 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ r8_v41 (Il2CppClass<VampireSurvivors.Objects.Weapons.ShadowServantWeapon>)+130]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ r9_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ r8_v41 (Il2CppClass<VampireSurvivors.Objects.Weapons.ShadowServantWeapon>)+130]");
		object obj11;
		if (num7 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ r9_v16 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rax_v89+FFFFFFF8+v241 @ rax_v84*8]");
			if (0 == (nint)typeof(ShadowServantWeapon))
			{
				obj11 = 1;
				goto IL_067a;
			}
		}
		obj11 = 0;
		goto IL_067a;
		IL_0645:
		bool flag2 = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag2)
		{
			trueWeapon = (float?)weapon;
		}
		goto IL_0636;
		IL_067a:
		bool flag3 = obj11 == null;
		trueWeaponShadowSerpant = (float?)(object)0;
		if (!flag3)
		{
			trueWeaponShadowSerpant = (float?)weapon;
		}
		goto IL_066b;
	}

	protected override void OnHasHitAnObject(IDamageable target)
	{
		Explode();
	}

	public void Explode()
	{
		//IL_0071: Expected O, but got I4
		//IL_00ee: Expected O, but got I4
		//IL_017a: Expected O, but got I4
		//IL_034d: Expected I, but got O
		//IL_03b7: Expected O, but got I4
		//IL_03c5: Expected O, but got I4
		//IL_0514: Expected I, but got O
		//IL_04df: Expected I, but got O
		//IL_0583: Expected O, but got I4
		//IL_0591: Expected O, but got I4
		//IL_06cf: Expected I4, but got F4
		//IL_0321->IL06e3: Incompatible stack heights: 10 vs 0
		//IL_0392->IL06e3: Incompatible stack heights: 10 vs 0
		//IL_0370->IL0370: Incompatible stack heights: 11 vs 10
		//IL_04b3->IL06e3: Incompatible stack heights: 10 vs 0
		//IL_0502->IL0502: Incompatible stack heights: 11 vs 10
		//IL_055e->IL06e3: Incompatible stack heights: 11 vs 0
		//IL_0660->IL06e3: Incompatible stack heights: 11 vs 0
		//IL_06e2->IL06e2: Incompatible stack heights: 11 vs 0
		_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass24_0();
		if (CS_0024_003C_003E8__locals15 != null)
		{
			CS_0024_003C_003E8__locals15._003C_003E4__this = this;
			if (_isExploding)
			{
				return;
			}
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			float num = (float)_indexInWeapon * 4.294967E+09f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = num;
			float num2 = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Ophion1, soundConfig, 200f, 6, num2);
			bool flag = _indexInWeapon != 1;
			int num3 = 6;
			float num4 = 200f;
			if (!flag)
			{
				SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
				soundConfig2.Volume = (float?)(object)1;
				soundConfig2.Rate = 1f;
				PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Ophion2, soundConfig2, 200f, 2, num2);
				num3 = 2;
				num4 = 200f;
			}
			BaseBody baseBody = body;
			_isExploding = true;
			if (body != null)
			{
				baseBody._velocity = (float2)0;
				if (body != null)
				{
					_ = 0;
					Transform transform = base.transform;
					if ((object)transform != null)
					{
						bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
						bool flag3 = (object)_snakeSprite == null;
						Transform transform2 = _snakeSprite.transform;
						bool flag4 = (object)transform2 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v934 @ rax_v45 (UnityEngine.Transform)+10]");
						bool flag5 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v934 @ rax_v45 (UnityEngine.Transform)+10]");
						Vector3 value = default(Vector3);
						Transform.set_position_Injected((IntPtr)0, ref value);
						bool flag6 = (object)_displaySprite == null;
						Transform transform3 = _displaySprite.transform;
						bool flag7 = (object)transform3 == null;
						bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
						Vector3 value2 = default(Vector3);
						Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
						bool flag9 = (object)_displaySprite == null;
						PhaserSprite phaserSprite = _displaySprite.setVisible(visible: false);
						bool flag10 = (object)_snakeSprite == null;
						PhaserSprite phaserSprite2 = _snakeSprite.setVisible(visible: false);
						bool flag11 = (object)_weapon == null;
						float num5 = _weapon.PArea();
						float num6 = num + num;
						CS_0024_003C_003E8__locals15.scale = num6;
						if (_snakeTween != null)
						{
							_snakeTween.Kill();
						}
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if (array != null)
						{
							if ((object)_snakeSprite != null)
							{
								nint num7 = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj = default(object);
								bool flag12 = obj == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null)
							{
								tweenConfig.targets = array;
								tweenConfig.scale = (float?)(object)1;
								tweenConfig.alpha = (float?)(object)1;
								tweenConfig.duration = _explo1DUration;
								TweenCallback onStart = delegate
								{
									//IL_004d: Expected O, but got I4
									OphionProjectile ophionProjectile = CS_0024_003C_003E8__locals15._003C_003E4__this;
									PhaserSprite phaserSprite3 = ophionProjectile._snakeSprite.setAlpha(0f);
									OphionProjectile ophionProjectile2 = CS_0024_003C_003E8__locals15._003C_003E4__this;
									PhaserSprite phaserSprite4 = ophionProjectile2._snakeSprite.setScale(0f, (float?)(object)0);
									OphionProjectile ophionProjectile3 = CS_0024_003C_003E8__locals15._003C_003E4__this;
									PhaserSprite phaserSprite5 = ophionProjectile3._snakeSprite.setVisible(visible: true);
								};
								tweenConfig.onStart = onStart;
								MultiTargetTween snakeTween = Tweens.Add(tweenConfig);
								_snakeTween = snakeTween;
								if (_displayScaleTween != null)
								{
									_displayScaleTween.Kill();
								}
								if (_displayScaleTween2 != null)
								{
									_displayScaleTween2.Kill();
								}
								TweenConfig tweenConfig2 = new TweenConfig();
								object[] array2 = new object[2];
								if (array2 != null)
								{
									if ((object)_displaySprite != null)
									{
										nint num8 = (nint)array2;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj2 = default(object);
										bool flag13 = obj2 == null;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									nint num9 = (nint)array2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj3 = default(object);
									bool flag14 = obj3 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig2 != null)
									{
										tweenConfig2.targets = array2;
										tweenConfig2.scale = (float?)(object)1;
										tweenConfig2.alpha = (float?)(object)1;
										tweenConfig2.duration = _explo1DUration;
										TweenCallback onStart2 = delegate
										{
											//IL_0027: Expected O, but got I4
											//IL_0052: Expected O, but got I4
											OphionProjectile ophionProjectile = CS_0024_003C_003E8__locals15._003C_003E4__this;
											PhaserSprite phaserSprite3 = ophionProjectile._snakeSprite.setScale(0f, (float?)(object)0);
											OphionProjectile ophionProjectile2 = CS_0024_003C_003E8__locals15._003C_003E4__this;
											PhaserSprite phaserSprite4 = ophionProjectile2._displaySprite.setScale(0f, (float?)(object)0);
											OphionProjectile ophionProjectile3 = CS_0024_003C_003E8__locals15._003C_003E4__this;
											PhaserSprite phaserSprite5 = ophionProjectile3._displaySprite.setVisible(visible: true);
										};
										tweenConfig2.onStart = onStart2;
										TweenCallback onComplete = delegate
										{
											//IL_009a: Expected I, but got O
											//IL_0110: Expected I4, but got I8
											//IL_011e: Expected O, but got I4
											OphionProjectile ophionProjectile = CS_0024_003C_003E8__locals15._003C_003E4__this;
											RenderingExtensions.Start(ophionProjectile._purpleEmitter1);
											OphionProjectile ophionProjectile2 = CS_0024_003C_003E8__locals15._003C_003E4__this;
											RenderingExtensions.Start(ophionProjectile2._purpleEmitter2);
											OphionProjectile ophionProjectile3 = CS_0024_003C_003E8__locals15._003C_003E4__this;
											TweenConfig tweenConfig3 = new TweenConfig();
											object[] array3 = new object[1];
											OphionProjectile ophionProjectile4 = CS_0024_003C_003E8__locals15._003C_003E4__this;
											if ((object)ophionProjectile4._displaySprite != null)
											{
												nint num11 = (nint)array3;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
												object obj4 = default(object);
												if (obj4 == null)
												{
													ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
													throw ex;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											tweenConfig3.targets = array3;
											tweenConfig3.duration = 100f;
											tweenConfig3.yoyo = true;
											tweenConfig3.repeat = -1;
											tweenConfig3.scale = (float?)(object)1;
											MultiTargetTween displayScaleTween2 = Tweens.Add(tweenConfig3);
											ophionProjectile3._displayScaleTween2 = displayScaleTween2;
										};
										tweenConfig2.onComplete = onComplete;
										MultiTargetTween displayScaleTween = Tweens.Add(tweenConfig2);
										_displayScaleTween = displayScaleTween;
										if (_durationTimer != null)
										{
											_durationTimer.Cancel();
										}
										if ((object)_weapon != null)
										{
											float num10 = _weapon.PDuration();
											Action onComplete2 = delegate
											{
												CS_0024_003C_003E8__locals15._003C_003E4__this.Implode();
											};
											float duration = CS_0024_003C_003E8__locals15.scale * 0.001f;
											MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
											int repeat = default(int);
											TimerType type = default(TimerType);
											Timer durationTimer = Timers.Register(duration, onComplete2, null, isLooped: false, (byte)(int)num2 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
											_durationTimer = durationTimer;
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

	public void Implode()
	{
		//IL_00d1: Expected I, but got O
		//IL_0098: Expected I, but got O
		//IL_012c: Expected O, but got I4
		//IL_013a: Expected O, but got I4
		_purpleEmitter1.Stop();
		_purpleEmitter2.Stop();
		if (_implosionTween != null)
		{
			_implosionTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_displaySprite != null)
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
		nint num2 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.scale = (float?)(object)1;
			tweenConfig.alpha = (float?)(object)1;
			tweenConfig.duration = _explo2DUration;
			TweenCallback onStart = _003C_003Ec._003C_003E9__25_0;
			if (_003C_003Ec._003C_003E9__25_0 == null)
			{
				onStart = (_003C_003Ec._003C_003E9__25_0 = delegate
				{
				});
			}
			tweenConfig.onStart = onStart;
			TweenCallback onComplete = delegate
			{
				Explode2();
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween implosionTween = Tweens.Add(tweenConfig);
			_implosionTween = implosionTween;
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	public void Explode2()
	{
		//IL_04bb: Expected O, but got I4
		//IL_0172: Expected I, but got O
		//IL_0139: Expected I, but got O
		//IL_01cd: Expected O, but got I4
		//IL_01db: Expected O, but got I4
		//IL_02a4: Expected I, but got O
		//IL_02fa: Expected O, but got I4
		//IL_0308: Expected O, but got I4
		//IL_03bd: Expected I, but got O
		//IL_0413: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		float detune = (float)_indexInWeapon * 4.294967E+09f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Ophion3, soundConfig, 500f, 6, time);
		if (_snakeTween != null)
		{
			_snakeTween.Kill();
		}
		if (_displayScaleTween != null)
		{
			_displayScaleTween.Kill();
		}
		if (_displayScaleTween2 != null)
		{
			_displayScaleTween2.Kill();
		}
		float num = _weapon.PArea();
		if (_explosionTween != null)
		{
			_explosionTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_snakeSprite != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		nint num3 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.scale = (float?)(object)1;
			tweenConfig.alpha = (float?)(object)1;
			tweenConfig.duration = _explo3DUration;
			TweenCallback onStart = delegate
			{
				PhaserSprite phaserSprite = _snakeSprite.setAlpha(1f);
			};
			tweenConfig.onStart = onStart;
			TweenCallback onComplete = delegate
			{
				BaseBody baseBody = body;
				baseBody._enable = false;
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween explosionTween = Tweens.Add(tweenConfig);
			_explosionTween = explosionTween;
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			if ((object)_displaySprite != null)
			{
				nint num4 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.scale = (float?)(object)1;
			tweenConfig2.alpha = (float?)(object)1;
			tweenConfig2.duration = _explo3DUration;
			TweenCallback onStart2 = delegate
			{
				PhaserSprite phaserSprite = _displaySprite.setAlpha(0f);
			};
			tweenConfig2.onStart = onStart2;
			TweenCallback onComplete2 = delegate
			{
				PhaserSprite phaserSprite = _displaySprite.setAlpha(0f);
			};
			tweenConfig2.onComplete = onComplete2;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig2);
			TweenConfig tweenConfig3 = new TweenConfig();
			object[] array3 = new object[1];
			if ((object)_displaySprite != null)
			{
				nint num5 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array3;
			tweenConfig3.alpha = (float?)(object)1;
			tweenConfig3.duration = _explo3DUration;
			TweenCallback onStart3 = delegate
			{
				PhaserSprite phaserSprite = _displaySprite.setAlpha(0f);
			};
			tweenConfig3.onStart = onStart3;
			TweenCallback onComplete3 = delegate
			{
				Despawn();
			};
			tweenConfig3.onComplete = onComplete3;
			MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig3);
			return;
		}
		ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
		throw ex4;
	}

	protected override void OnUpdate()
	{
		//IL_0011: Invalid comparison between F4 and I4
		//IL_0023: Expected F4, but got I4
		CheckIfVisibleOnScreen();
		bool flag = !(base._pauseWallChecksTimer > 0f);
		float num = 0f;
		if (!flag)
		{
			num = PauseSystem.DeltaTime;
			float pauseWallChecksTimer = base._pauseWallChecksTimer - num;
			base._pauseWallChecksTimer = pauseWallChecksTimer;
		}
		Transform transform = base.transform;
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		bool flag3 = (object)_snakeSprite == null;
		Transform transform2 = _snakeSprite.transform;
		bool flag4 = (object)transform2 == null;
		bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
		bool flag6 = (object)_displaySprite == null;
		Transform transform3 = _displaySprite.transform;
		bool flag7 = (object)transform3 == null;
		bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
	}

	public void Disable()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
	}

	public override void Despawn()
	{
		if (_indexInWeapon == 1)
		{
			SoundManager.StopSound(SfxType.Ophion2);
		}
		RenderingExtensions.StopEmitting(_purpleEmitter1);
		RenderingExtensions.StopEmitting(_purpleEmitter2);
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__22_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CImplode_003Eb__25_1()
	{
		Explode2();
	}

	private void _003CExplode2_003Eb__26_0()
	{
		PhaserSprite phaserSprite = _snakeSprite.setAlpha(1f);
	}

	private void _003CExplode2_003Eb__26_1()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
	}

	private void _003CExplode2_003Eb__26_2()
	{
		PhaserSprite phaserSprite = _displaySprite.setAlpha(0f);
	}

	private void _003CExplode2_003Eb__26_3()
	{
		PhaserSprite phaserSprite = _displaySprite.setAlpha(0f);
	}

	private void _003CExplode2_003Eb__26_4()
	{
		PhaserSprite phaserSprite = _displaySprite.setAlpha(0f);
	}

	private void _003CExplode2_003Eb__26_5()
	{
		Despawn();
	}
}
