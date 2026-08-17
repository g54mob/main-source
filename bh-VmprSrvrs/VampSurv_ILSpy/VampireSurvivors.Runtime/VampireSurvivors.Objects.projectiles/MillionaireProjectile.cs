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
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class MillionaireProjectile : Projectile
{
	private ParticleEmitterManager _pfxEmitterManager;

	private ParticleSystem _pfxEmitter1;

	private ParticleSystem _pfxEmitter2;

	private MultiTargetTween _angleTween;

	private MultiTargetTween _positionTween;

	private PhaserSprite _groundFx;

	private ParticleEmitterManager _pfxEmitterExplosionManager;

	private Timer _hitboxTimer;

	private Timer _expireTimer;

	private float _radius;

	private float _exploRadius;

	private bool _isBroken;

	private Vector2 _currentDirection;

	private Circle _explosionCircle;

	private Vector2 _target;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0058: Expected O, but got I4
		//IL_02e3: Expected O, but got Ref
		//IL_02fd: Expected native int or pointer, but got O
		//IL_0d67: Expected O, but got I4
		//IL_0315: Expected O, but got Ref
		//IL_033c: Expected O, but got I
		//IL_0356: Expected native int or pointer, but got O
		//IL_0370: Expected O, but got I
		//IL_039e: Expected O, but got I4
		//IL_03b7: Expected O, but got Ref
		//IL_03d1: Expected native int or pointer, but got O
		//IL_0d84: Expected O, but got I4
		//IL_0403: Expected O, but got Ref
		//IL_041d: Expected native int or pointer, but got O
		//IL_0dbe: Expected O, but got I
		//IL_06b1: Expected O, but got Ref
		//IL_06cb: Expected native int or pointer, but got O
		//IL_0e0a: Expected O, but got I
		//IL_0709: Expected O, but got Ref
		//IL_072a: Expected O, but got I
		//IL_0744: Expected native int or pointer, but got O
		//IL_075e: Expected O, but got I
		//IL_078c: Expected O, but got I4
		//IL_07a5: Expected O, but got Ref
		//IL_07bf: Expected native int or pointer, but got O
		//IL_0e44: Expected O, but got I
		//IL_07f7: Expected O, but got Ref
		//IL_0811: Expected native int or pointer, but got O
		//IL_0e76: Expected O, but got I
		//IL_0862: Expected O, but got I
		//IL_09e2: Expected O, but got I
		//IL_09fe: Expected O, but got I4
		//IL_0a17: Expected O, but got Ref
		//IL_0a31: Expected native int or pointer, but got O
		//IL_0a76: Expected O, but got I
		//IL_0a9e: Expected O, but got Ref
		//IL_0ab8: Expected native int or pointer, but got O
		//IL_0afd: Expected O, but got I
		//IL_0b9a: Expected O, but got Ref
		//IL_0bc1: Expected O, but got I
		//IL_0bdb: Expected native int or pointer, but got O
		//IL_0bfa: Expected O, but got I
		//IL_0c28: Expected O, but got I4
		//IL_0c41: Expected O, but got Ref
		//IL_0c5b: Expected native int or pointer, but got O
		//IL_0ec2: Expected O, but got I
		//IL_0c93: Expected O, but got Ref
		//IL_0cad: Expected native int or pointer, but got O
		//IL_0efc: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		_speed = 2f;
		Circle circle = new Circle();
		circle._radius = _exploRadius;
		circle._x = 0f;
		_explosionCircle = circle;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm8\"");
		Vector2 pos = default(Vector2);
		int radius = default(int);
		PhaserSprite phaserSprite = RenderingExtensions.circle(s_scene.add, pos, radius, 16777215u);
		PhaserSprite phaserSprite2 = phaserSprite.setOrigin(0.5f, (float?)(object)0);
		PhaserSprite phaserSprite3 = phaserSprite2.setAlpha(0.1f);
		PhaserSprite phaserSprite4 = phaserSprite3.setVisible(visible: false);
		PhaserSprite groundFx = phaserSprite4.setBlendMode(BlendMode.Add);
		_groundFx = groundFx;
		GameObject gameObject = base.gameObject;
		ParticleEmitterManager pfxEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
		_pfxEmitterManager = pfxEmitterManager;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxYellow");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxPurple");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxLine");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(1f, 1f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+2F0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(90f, 90f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+100]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+110]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(300f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+120]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+130]");
		_ = 0;
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 2f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+140]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+150]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-40]");
		_ = 0;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = _explosionCircle;
		particleSystemConfig._emitZone = emitZone;
		particleSystemConfig._on = false;
		ParticleSystem pfxEmitter = _pfxEmitterManager.CreateEmitter(particleSystemConfig);
		_pfxEmitter1 = pfxEmitter;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		int version4 = list2._version + 1;
		list2._version = version4;
		string[] items4 = list2._items;
		if (list2._size >= items4.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"PfxYellow");
		}
		else
		{
			int num4 = list2._size + 1;
			list2._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list2._version + 1;
		list2._version = version5;
		string[] items5 = list2._items;
		if (list2._size >= items5.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"PfxPurple");
		}
		else
		{
			int num5 = list2._size + 1;
			list2._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list2._version + 1;
		list2._version = version6;
		string[] items6 = list2._items;
		if (list2._size >= items6.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"PfxLine");
		}
		else
		{
			int num6 = list2._size + 1;
			list2._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+160]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+170]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-18]");
		_ = 0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 384));
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+2F0]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(90f, 90f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+180]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+190]");
		_ = 0;
		minMaxCurve3 = new ParticleSystem.MinMaxCurve(300f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 416));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0.2f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1B0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-10]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+10]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 448));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(1f, 0.5f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1D0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+18]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+38]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+2F0]");
		particleSystemConfig2._blendMode = (BlendMode?)(object)0;
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Random;
		emitZone2._source = _explosionCircle;
		particleSystemConfig2._emitZone = emitZone2;
		particleSystemConfig2._on = false;
		ParticleSystem pfxEmitter2 = _pfxEmitterManager.CreateEmitter(particleSystemConfig2);
		_pfxEmitter2 = pfxEmitter2;
		GameObject gameObject2 = base.gameObject;
		ParticleEmitterManager pfxEmitterExplosionManager = gameObject2.AddComponent<ParticleEmitterManager>();
		_pfxEmitterExplosionManager = pfxEmitterExplosionManager;
		ParticleSystemConfig particleSystemConfig3 = new ParticleSystemConfig("vfx");
		List<string> list3 = new List<string>();
		int version7 = list3._version + 1;
		list3._version = version7;
		string[] items7 = list3._items;
		if (list3._size >= items7.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"disc");
		}
		else
		{
			int num7 = list3._size + 1;
			list3._size = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig3._frame = list3;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+2F0]");
		particleSystemConfig3._quantity = (int?)(object)0;
		minMaxCurve3 = new ParticleSystem.MinMaxCurve(100f);
		particleSystemConfig3._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 480));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(0.65f, 0.35f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1E0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1F0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+40]");
		particleSystemConfig3._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+60]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 512));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(0.25f, 2f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+200]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+210]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+68]");
		particleSystemConfig3._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+88]");
		_ = 0;
		particleSystemConfig3._on = false;
		ParticleSystem particleSystem = _pfxEmitterExplosionManager.CreateEmitter(particleSystemConfig3);
		ParticleSystemConfig particleSystemConfig4 = new ParticleSystemConfig("vfx");
		List<string> list4 = new List<string>();
		list4.Add("blurredSharpStar");
		particleSystemConfig4._frame = list4;
		ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 544));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+2F0]");
		particleSystemConfig4._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+220]");
		particleSystemConfig4._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+230]");
		_ = 0;
		minMaxCurve3 = new ParticleSystem.MinMaxCurve(100f);
		particleSystemConfig4._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve13 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 576));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve13, new ParticleSystem.MinMaxCurve(0.35f, 0.15f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+240]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+250]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+90]");
		particleSystemConfig4._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B0]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve14 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 608));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve14, new ParticleSystem.MinMaxCurve(0.25f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+260]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+270]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+B8]");
		particleSystemConfig4._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+D8]");
		_ = 0;
		particleSystemConfig4._on = false;
		ParticleSystem particleSystem2 = _pfxEmitterExplosionManager.CreateEmitter(particleSystemConfig4);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_0035: Expected O, but got I4
		//IL_04b2: Expected O, but got I4
		//IL_04cb: Expected O, but got I4
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected I4, but got Unknown
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected I4, but got Unknown
		//IL_04de: Expected O, but got F4
		//IL_04fa: Expected O, but got F4
		//IL_0526: Expected O, but got F4
		//IL_057a: Expected O, but got F4
		base.InitProjectile(pool, weapon, index);
		float num = _radius * -0.5f;
		float num2 = _radius * -0.5f;
		_speed = 2f;
		BaseBody baseBody = body.setCircle(_radius, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setVisible(visible: true);
		ArcadeSprite arcadeSprite3 = setFlipX(flipX: false);
		BaseBody baseBody2 = body;
		_isBroken = false;
		baseBody2._enable = false;
		_isCullable = false;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		uint[] array = new uint[2] { 16776960u, 8913151u };
		object obj = UnityEngine.Random.RandomRangeInt(0, array.Length);
		string[] array2 = new string[2];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj2 = UnityEngine.Random.RandomRangeInt(0, array2.Length);
		Sprite sprite = SpriteManager.GetSprite(array2[obj2], "vfx");
		ArcadeSprite arcadeSprite4 = setFrame(sprite);
		Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)_renderer).SetMaterial(material);
		PhaserSprite phaserSprite = _groundFx.setTint(array[obj]);
		float num3 = _weapon.PArea();
		Circle circle = new Circle();
		float num4 = num2 * _exploRadius;
		circle._x = 0f;
		float radius = num4 * 3f;
		circle._radius = radius;
		_explosionCircle = circle;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = _explosionCircle;
		RenderingExtensions.SetEmitZone(_pfxEmitter1, emitZone);
		Weapon weapon2 = _weapon;
		float num5 = (float)((Equipment)weapon2)._003CLevel_003Ek__BackingField / 3f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		object obj3 = default(object);
		int quantity = obj3 + 1;
		RenderingExtensions.SetQuantity(_pfxEmitter1, quantity);
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Random;
		emitZone2._source = _explosionCircle;
		RenderingExtensions.SetEmitZone(_pfxEmitter2, emitZone2);
		Weapon weapon3 = _weapon;
		float num6 = (float)((Equipment)weapon3)._003CLevel_003Ek__BackingField / 3f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		object obj4 = default(object);
		int quantity2 = obj4 + 1;
		RenderingExtensions.SetQuantity(_pfxEmitter2, quantity2);
		float2 target = base.position;
		float2 float5 = base.position;
		_target = target;
		object obj5 = UnityEngine.Random.value;
		Weapon weapon4 = _weapon;
		float2 float6 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.position;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num7 = renderer.height * 0.6f;
		float num8 = num7 + num2;
		float2 float7 = default(float2);
		base.position = float7;
		object obj6 = UnityEngine.Random.value;
		float num9 = num * ((float)Math.PI * 2f);
		object obj7 = UnityEngine.Random.value;
		float num10 = num * 240f;
		float num11 = num10 * 0.01f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num12 = num9 * num11;
		float num13 = num12 + (float)_target;
		_target = (Vector2)num13;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num14 = num9 * num11;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.MillionaireProjectile)+13C]");
		float num15 = 0f - num14;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num16 = default(int);
		ArcadeSprite arcadeSprite5 = setDepth(num16);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		ArcadeSprite arcadeSprite6 = setVisible(config._003CFlashingVFXEnabled_003Ek__BackingField);
	}

	public void SetDisplayDirection(bool left)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected F4, but got Unknown
		//IL_00c5: Expected I, but got O
		//IL_011b: Expected O, but got I4
		//IL_0145: Expected O, but got I4
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num = renderer.width * 0.5f;
		ArcadeSprite arcadeSprite = setFlipX(left);
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float num2 = num;
		if (!left)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			num2 = num ^ 0;
		}
		float2 float6 = default(float2);
		base.position = float6;
		if (_positionTween != null)
		{
			_positionTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num3 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.x = (float?)(object)1;
			tweenConfig.duration = 100f;
			tweenConfig.ease = Ease.Linear;
			tweenConfig.y = (float?)(object)1;
			TweenCallback onComplete = Break;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween positionTween = Tweens.Add(tweenConfig);
			_positionTween = positionTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void Break()
	{
		//IL_0038: Expected O, but got I4
		//IL_00b2: Expected O, but got I4
		//IL_00ce: Expected O, but got I4
		//IL_0131: Expected O, but got I4
		//IL_01e1: Expected F4, but got I4
		//IL_021b: Expected O, but got F4
		//IL_02f0: Expected O, but got I4
		//IL_0302: Unsupported input type for neg.
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Expected O, but got Unknown
		//IL_0355: Expected O, but got I4
		//IL_0381: Expected O, but got I4
		//IL_0257: Expected O, but got I4
		//IL_0269: Unsupported input type for neg.
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_03af: Expected F4, but got I4
		//IL_0299: Expected F4, but got I4
		if (_isBroken)
		{
			return;
		}
		_isBroken = true;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		BaseBody baseBody = body;
		_ = 0;
		baseBody._velocity = (float2)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
		float2 float5 = base.position;
		PhaserSprite phaserSprite = _groundFx.setPosition(float5);
		float num = _weapon.PArea();
		PhaserSprite phaserSprite2 = phaserSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite3 = phaserSprite2.setOrigin(0.5f, (float?)(object)0);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		PhaserSprite phaserSprite4 = phaserSprite3.setVisible(config._003CFlashingVFXEnabled_003Ek__BackingField);
		float num2 = _weapon.PArea();
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		Action onComplete = delegate
		{
			PhaserSprite phaserSprite6 = _groundFx.setVisible(visible: false);
			if (_hitboxTimer != null)
			{
				_hitboxTimer.Cancel();
			}
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			Despawn();
		};
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(0.1f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		bool flag2 = false;
		Action<float> action = null;
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		bool flag3 = !config2._003CFlashingVFXEnabled_003Ek__BackingField;
		float num3 = 0f;
		float num4 = 0.1f;
		if (!flag3)
		{
			float2 float6 = base.position;
			float num5 = default(float);
			_pfxEmitterExplosionManager.EmitParticleAt((Vector2)num5);
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			int num6 = renderer.pixelHeight >> 31;
			object obj = renderer.pixelHeight - num6;
			object obj2 = obj >> 1;
			object obj3 = 0 - obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
			int num7 = default(int);
			ParticleEmitterManager particleEmitterManager = _pfxEmitterManager.SetDepth(num7);
			num3 = 0f;
			flag2 = false;
			num4 = num5;
			action = null;
		}
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		int num8 = renderer2.pixelHeight >> 31;
		object obj4 = renderer2.pixelHeight - num8;
		object obj5 = obj4 >> 1;
		object obj6 = 0 - obj5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num9 = default(int);
		PhaserSprite phaserSprite5 = _groundFx.setDepth(num9);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj7 = _indexInWeapon - 4;
		soundConfig.Rate = 2f;
		float detune = (float)obj7 * 50f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Holywater, soundConfig, 200f, 12, flag ? 1 : 0);
	}

	public override void InternalUpdate()
	{
		if (_isBroken)
		{
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			_pfxEmitterManager.EmitParticleAt(pos);
		}
	}

	public override void Despawn()
	{
		_isCullable = true;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		PhaserSprite phaserSprite = _groundFx.setVisible(visible: false);
		base.Despawn();
	}

	public MillionaireProjectile()
	{
		//IL_0035: Expected I, but got O
		_radius = 16f;
		_exploRadius = 8f;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_currentDirection = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		base._002Ector();
	}

	private void _003CBreak_003Eb__18_0()
	{
		PhaserSprite phaserSprite = _groundFx.setVisible(visible: false);
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Despawn();
	}
}
