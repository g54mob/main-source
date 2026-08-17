using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class GattiScuffleProjectile : Projectile
{
	private ParticleEmitterManager _pfxEmitterManager;

	private ParticleSystem _pfxEmitter1;

	private ParticleSystem _pfxEmitter2;

	private Circle _explosionCircle;

	private int _exploRadius = 64;

	private Timer _expireTimer;

	private Timer _hitboxTimer;

	private GattiWeapon _trueWeapon;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0955: Expected F4, but got I4
		//IL_01a9: Expected O, but got Ref
		//IL_01c3: Expected native int or pointer, but got O
		//IL_0972: Expected O, but got I4
		//IL_01db: Expected O, but got Ref
		//IL_0202: Expected O, but got I
		//IL_021c: Expected native int or pointer, but got O
		//IL_0236: Expected O, but got I
		//IL_0264: Expected O, but got I4
		//IL_027d: Expected O, but got Ref
		//IL_0297: Expected native int or pointer, but got O
		//IL_098f: Expected O, but got I4
		//IL_02c9: Expected O, but got Ref
		//IL_02e3: Expected native int or pointer, but got O
		//IL_09c9: Expected O, but got I
		//IL_073c: Expected O, but got Ref
		//IL_0756: Expected native int or pointer, but got O
		//IL_0a15: Expected O, but got I
		//IL_078e: Expected O, but got Ref
		//IL_07b5: Expected O, but got I
		//IL_07cf: Expected native int or pointer, but got O
		//IL_07e9: Expected O, but got I
		//IL_0817: Expected O, but got I4
		//IL_0830: Expected O, but got Ref
		//IL_084a: Expected native int or pointer, but got O
		//IL_0a4f: Expected O, but got I
		//IL_0882: Expected O, but got Ref
		//IL_089c: Expected native int or pointer, but got O
		//IL_0a81: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = _exploRadius;
		_explosionCircle = circle;
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
			((List<object>)(object)list).AddWithResize((object)"Smoke1");
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
			((List<object>)(object)list).AddWithResize((object)"Smoke2");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(1f, 10f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
		_ = 0;
		_ = 2;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+180]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(500f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+90]");
		_ = 0;
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
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
		int version3 = list2._version + 1;
		list2._version = version3;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"Smoke1");
		}
		else
		{
			int num3 = list2._size + 1;
			list2._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list2._version + 1;
		list2._version = version4;
		string[] items4 = list2._items;
		if (list2._size >= items4.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"Smoke2");
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
			((List<object>)(object)list2).AddWithResize((object)"HitStarRed1");
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
			((List<object>)(object)list2).AddWithResize((object)"HitStarRed2");
		}
		else
		{
			int num6 = list2._size + 1;
			list2._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version7 = list2._version + 1;
		list2._version = version7;
		string[] items7 = list2._items;
		if (list2._size >= items7.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"Hit2");
		}
		else
		{
			int num7 = list2._size + 1;
			list2._size = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version8 = list2._version + 1;
		list2._version = version8;
		string[] items8 = list2._items;
		if (list2._size >= items8.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"Cat");
		}
		else
		{
			int num8 = list2._size + 1;
			list2._size = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 10f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+180]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E0]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F0]");
		_ = 0;
		minMaxCurve3 = new ParticleSystem.MinMaxCurve(250f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+100]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+110]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-10]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0f, 2f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+120]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+130]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+18]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
		_ = 0;
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Random;
		emitZone2._source = _explosionCircle;
		particleSystemConfig2._emitZone = emitZone2;
		particleSystemConfig2._on = false;
		ParticleSystem pfxEmitter2 = _pfxEmitterManager.CreateEmitter(particleSystemConfig2);
		_pfxEmitter2 = pfxEmitter2;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_04b2: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_00f8: Expected O, but got I4
		//IL_011c: Expected O, but got I4
		//IL_011c: Expected O, but got I4
		//IL_0152: Expected O, but got I4
		//IL_025d: Expected I, but got O
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected I4, but got Unknown
		//IL_02c6: Expected O, but got Ref
		//IL_031c: Expected I, but got O
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Expected I4, but got Unknown
		//IL_0386: Expected O, but got Ref
		base.InitProjectile(pool, weapon, index);
		float? trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_048b;
		}
		nint num = (nint)typeof(GattiWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v55 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v43 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rdx_v55 (Il2CppClass<VampireSurvivors.Objects.Weapons.GattiWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ r8_v43 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v89+FFFFFFF8+v69 @ rax_v84*8]");
			if (0 == (nint)typeof(GattiWeapon))
			{
				obj3 = 1;
				goto IL_049a;
			}
		}
		obj3 = 0;
		goto IL_049a;
		IL_049a:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)weapon;
		}
		goto IL_048b;
		IL_048b:
		_trueWeapon = (GattiWeapon)trueWeapon;
		BaseBody baseBody = body;
		baseBody._enable = true;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody2 = body.setCircle(32f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		float num4 = _weapon.PArea();
		float num5 = default(float);
		ArcadeSprite arcadeSprite3 = setScale(num5, (float?)(object)0);
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num6 = _weapon.PArea();
		Circle circle = new Circle();
		circle._x = 0f;
		float radius = (float)_exploRadius * num5;
		circle._radius = radius;
		_explosionCircle = circle;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = _explosionCircle;
		RenderingExtensions.SetEmitZone(_pfxEmitter1, emitZone);
		Weapon weapon2 = _weapon;
		nint num7 = (nint)weapon2;
		float num8 = weapon2.PArea();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		object obj4 = default(object);
		int quantity = obj4 + 1;
		RenderingExtensions.SetQuantity(_pfxEmitter1, quantity);
		float num9 = _weapon.PArea();
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(num5, 1f);
		float num10 = default(float);
		RenderingExtensions.SetScale(_pfxEmitter1, (ParticleSystem.MinMaxCurve)(&num10));
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Random;
		emitZone2._source = _explosionCircle;
		RenderingExtensions.SetEmitZone(_pfxEmitter2, emitZone2);
		Weapon weapon3 = _weapon;
		nint num11 = (nint)weapon3;
		float num12 = weapon3.PArea();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		object obj5 = default(object);
		int quantity2 = obj5 + 1;
		RenderingExtensions.SetQuantity(_pfxEmitter2, quantity2);
		float num13 = _weapon.PArea();
		ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(0f, 0f);
		RenderingExtensions.SetScale(_pfxEmitter2, (ParticleSystem.MinMaxCurve)(&num10));
		float num14 = _weapon.PDuration();
		Action onComplete = delegate
		{
			Despawn();
		};
		float duration = 0f * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		Action onComplete2 = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			GattiWeapon trueWeapon2 = _trueWeapon;
			float2 pos = base.position;
			Projectile projectile = trueWeapon2._scratchPool.SpawnAt(pos, _weapon);
		};
		Timer hitboxTimer = Timers.Register(0.030000001f, onComplete2, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
	}

	public override void InternalUpdate()
	{
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		_pfxEmitterManager.EmitParticleAt(pos);
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
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__9_0()
	{
		Despawn();
	}

	private void _003CInitProjectile_003Eb__9_1()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		GattiWeapon trueWeapon = _trueWeapon;
		float2 pos = base.position;
		Projectile projectile = trueWeapon._scratchPool.SpawnAt(pos, _weapon);
	}
}
