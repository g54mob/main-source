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
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class SpellstrikeProjectile : Projectile
{
	private ParticleEmitterManager _pfxEmitter;

	private ParticleSystem _emitter2;

	private Circle _emitZone;

	private ParticleSystem _emitter1;

	private MultiTargetTween _strikeTween;

	private MultiTargetTween _emitterTween;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0114: Expected O, but got I
		//IL_02ab: Expected O, but got Ref
		//IL_02c5: Expected native int or pointer, but got O
		//IL_0781: Expected O, but got I4
		//IL_02dd: Expected O, but got Ref
		//IL_0304: Expected O, but got I
		//IL_031e: Expected native int or pointer, but got O
		//IL_0338: Expected O, but got I
		//IL_0358: Expected O, but got Ref
		//IL_0372: Expected native int or pointer, but got O
		//IL_079e: Expected O, but got I4
		//IL_038a: Expected O, but got Ref
		//IL_03a4: Expected native int or pointer, but got O
		//IL_07c8: Expected O, but got I
		//IL_05a0: Expected O, but got Ref
		//IL_05b5: Expected native int or pointer, but got O
		//IL_0814: Expected O, but got I
		//IL_05ed: Expected O, but got Ref
		//IL_0614: Expected O, but got I
		//IL_062e: Expected native int or pointer, but got O
		//IL_0648: Expected O, but got I
		//IL_0668: Expected O, but got Ref
		//IL_0682: Expected native int or pointer, but got O
		//IL_084e: Expected O, but got I
		//IL_06ba: Expected O, but got Ref
		//IL_06d4: Expected native int or pointer, but got O
		//IL_06ef: Expected O, but got I
		//IL_0888: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("2Strike1", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		Circle circle = new Circle();
		circle._x = 0f;
		circle._radius = 16f;
		_emitZone = circle;
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, (string)null);
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rbx_v1 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		_ = 0;
		ParticleEmitterManager pfxEmitter;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+160]");
			pfxEmitter = (ParticleEmitterManager)0;
		}
		else
		{
			pfxEmitter = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_pfxEmitter = pfxEmitter;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"2Spell1");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"2Spell2");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 32));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(50f, 150f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+160]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(300f, 700f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+40]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+50]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 2f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+90]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-80]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-60]");
		_ = 0;
		particleSystemConfig._on = false;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = _emitZone;
		particleSystemConfig._emitZone = emitZone;
		ParticleSystem emitter = _pfxEmitter.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
		_emitter1 = emitter;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		int version3 = list2._version + 1;
		list2._version = version3;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"2Spell3");
		}
		else
		{
			int num4 = list2._size + 1;
			list2._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list2._version + 1;
		list2._version = version4;
		string[] items4 = list2._items;
		if (list2._size >= items4.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"2Spell4");
		}
		else
		{
			int num5 = list2._size + 1;
			list2._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+B0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-58]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-38]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+160]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(150f, 300f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+C0]");
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+D0]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+E0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+F0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-30]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-10]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 2f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+100]");
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+110]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-8]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+18]");
		_ = 0;
		particleSystemConfig2._on = false;
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Random;
		emitZone2._source = _emitZone;
		particleSystemConfig2._emitZone = emitZone2;
		ParticleSystem emitter2 = _pfxEmitter.CreateEmitter(particleSystemConfig2, null, "PfxEmitter");
		_emitter2 = emitter2;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_010c: Expected I, but got O
		//IL_017e: Expected O, but got I4
		//IL_0267: Expected I, but got O
		//IL_03b4: Expected O, but got I4
		//IL_0410: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body;
		baseBody._enable = true;
		float2 float5 = base.position;
		float2 float6 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		bool flag = (byte)(float5 < float6) != 0;
		object obj = float5 - float6;
		bool flag2 = obj == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		ArcadeSprite arcadeSprite = setFlipX(flag5);
		if (_strikeTween != null)
		{
			_strikeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
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
		tweenConfig.targets = array;
		tweenConfig.duration = 80f;
		tweenConfig.ease = Ease.OutBounce;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_0010: Expected O, but got I4
			ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
			ArcadeSprite arcadeSprite3 = setVisible(visible: true);
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			ArcadeSprite arcadeSprite2 = setVisible(visible: false);
			base.Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween strikeTween = Tweens.Add(tweenConfig);
		_strikeTween = strikeTween;
		if (_emitterTween != null)
		{
			_emitterTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if (_emitZone != null)
		{
			nint num2 = (nint)array2;
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
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object value = default(object);
		bool flag6 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"Radius", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		tweenConfig2.custom = dictionary;
		tweenConfig2.duration = 80f;
		TweenCallback onStart2 = delegate
		{
			Circle emitZone = _emitZone;
			emitZone._radius = 32f;
			emitZone._diameter = 64f;
		};
		tweenConfig2.onStart = onStart2;
		TweenCallback onUpdate = delegate
		{
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = _emitZone;
			RenderingExtensions.SetEmitZone(_emitter1, emitZone);
			EmitZone emitZone2 = new EmitZone();
			emitZone2._type = EmitZoneType.Random;
			emitZone2._source = _emitZone;
			RenderingExtensions.SetEmitZone(_emitter2, emitZone2);
			float2 float7 = base.position;
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt(_emitter1, pos, 4);
			float2 float8 = base.position;
			RenderingExtensions.EmitParticleAt(_emitter2, pos, 2);
		};
		tweenConfig2.onUpdate = onUpdate;
		MultiTargetTween emitterTween = Tweens.Add(tweenConfig2);
		_emitterTween = emitterTween;
		WeaponData currentWeaponData = weapon._currentWeaponData;
		bool flag7 = 1073741824 < 0;
		bool flag8 = !flag7;
		object obj4 = -1 & (flag8 ? 1 : 0);
		object obj5 = (object?)currentWeaponData._003Cvolume_003Ek__BackingField & obj4;
		float? volume;
		if (obj5 != null)
		{
			WeaponData currentWeaponData2 = weapon._currentWeaponData;
			volume = currentWeaponData2._003Cvolume_003Ek__BackingField;
		}
		else
		{
			volume = (float?)(object)1;
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Volume = volume;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.SpellStrike, soundConfig, 200f, 4, time);
	}

	public override void InternalUpdate()
	{
		int num = base.depth;
		int num2 = num - 1;
		ParticleEmitterManager particleEmitterManager = _pfxEmitter.SetDepth(num2);
	}

	private void _003CInitProjectile_003Eb__7_0()
	{
		//IL_0010: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setVisible(visible: true);
	}

	private void _003CInitProjectile_003Eb__7_1()
	{
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__7_2()
	{
		Circle emitZone = _emitZone;
		emitZone._radius = 32f;
		emitZone._diameter = 64f;
	}

	private void _003CInitProjectile_003Eb__7_3()
	{
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = _emitZone;
		RenderingExtensions.SetEmitZone(_emitter1, emitZone);
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Random;
		emitZone2._source = _emitZone;
		RenderingExtensions.SetEmitZone(_emitter2, emitZone2);
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		RenderingExtensions.EmitParticleAt(_emitter1, pos, 4);
		float2 float6 = base.position;
		RenderingExtensions.EmitParticleAt(_emitter2, pos, 2);
	}
}
