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
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TriaceProjectile : Projectile
{
	private ParticleEmitterManager _PfxEmitter;

	private PhaserSprite _GroundFx;

	private MultiTargetTween _ScaleTween;

	private MultiTargetTween _AlphaTween;

	private float _radius = 16f;

	private uint _myColor;

	private ParticleSystem _projEmitter;

	private float _timeToReach;

	protected unsafe override void Awake()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0030: Expected O, but got I
		//IL_008a: Expected O, but got I
		//IL_095c: Expected O, but got I
		//IL_00f4: Expected O, but got I
		//IL_0168: Expected O, but got I
		//IL_01c2: Expected O, but got I4
		//IL_03bb: Expected O, but got Ref
		//IL_03d5: Expected native int or pointer, but got O
		//IL_09c7: Expected O, but got I4
		//IL_0406: Expected O, but got I
		//IL_0422: Expected O, but got I4
		//IL_043b: Expected O, but got Ref
		//IL_0455: Expected native int or pointer, but got O
		//IL_09e4: Expected O, but got I4
		//IL_0487: Expected O, but got Ref
		//IL_04a1: Expected native int or pointer, but got O
		//IL_0a1e: Expected O, but got I
		//IL_0700: Expected O, but got Ref
		//IL_071a: Expected native int or pointer, but got O
		//IL_0a58: Expected O, but got I
		//IL_0752: Expected O, but got Ref
		//IL_076c: Expected native int or pointer, but got O
		//IL_0786: Expected O, but got I
		//IL_07a6: Expected O, but got Ref
		//IL_07c0: Expected native int or pointer, but got O
		//IL_07da: Expected O, but got I
		//IL_0813: Expected O, but got I
		//IL_083d: Expected O, but got I4
		//IL_0856: Expected O, but got Ref
		//IL_0870: Expected native int or pointer, but got O
		//IL_0a92: Expected O, but got I
		//IL_08a8: Expected O, but got Ref
		//IL_08c2: Expected native int or pointer, but got O
		//IL_0ac4: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.Awake();
		List<uint> list = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v5+18]");
		if (num >= 0)
		{
			list.AddWithResize(65535u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 65535;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rdx_v7+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(26367u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 26367;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		uint item = 0u;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v710 @ rdx_v10 (System.UInt32)+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(16777062u);
			item = 16777062u;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v3 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj7 = (nint)0 + (nint)1;
			_ = 16777062;
		}
		list.Add(item);
		uint myColor = default(uint);
		_myColor = myColor;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite groundFx = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "WhiteDot");
		_GroundFx = groundFx;
		PhaserSprite phaserSprite = _GroundFx.setOrigin(0.5f, (float?)(object)0);
		PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0.2f);
		PhaserSprite phaserSprite3 = phaserSprite2.setVisible(visible: true);
		PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Add);
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		GameObject gameObject2 = base.gameObject;
		ParticleEmitterManager pfxEmitter = gameObject2.AddComponent<ParticleEmitterManager>();
		_PfxEmitter = pfxEmitter;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		int version = list2._version + 1;
		list2._version = version;
		string[] items = list2._items;
		if (list2._size >= items.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"PfxGreen");
		}
		else
		{
			int num4 = list2._size + 1;
			list2._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list2._version + 1;
		list2._version = version2;
		string[] items2 = list2._items;
		if (list2._size >= items2.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"PfxYellow");
		}
		else
		{
			int num5 = list2._size + 1;
			list2._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list2;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1A0]");
		particleSystemConfig._quantity = (int?)(object)0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(100f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
		_ = 0;
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+90]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
		_ = 0;
		particleSystemConfig._on = false;
		ParticleSystem particleSystem = _PfxEmitter.CreateEmitter(particleSystemConfig);
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list3 = new List<string>();
		int version3 = list3._version + 1;
		list3._version = version3;
		string[] items3 = list3._items;
		if (list3._size >= items3.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"ProjectileBlue1");
		}
		else
		{
			int num6 = list3._size + 1;
			list3._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list3._version + 1;
		list3._version = version4;
		string[] items4 = list3._items;
		if (list3._size >= items4.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"ProjectileBlue2");
		}
		else
		{
			int num7 = list3._size + 1;
			list3._size = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list3._version + 1;
		list3._version = version5;
		string[] items5 = list3._items;
		if (list3._size >= items5.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"PfxLightGreen");
		}
		else
		{
			int num8 = list3._size + 1;
			list3._size = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list3;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 180f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F0]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1A0]");
		particleSystemConfig2._quantity = (int?)(object)0;
		particleSystemConfig2._angleSteps = 16;
		minMaxCurve2 = new ParticleSystem.MinMaxCurve(100f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-10]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+10]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0f, 2f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+120]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
		_ = 0;
		particleSystemConfig2._on = false;
		ParticleSystem projEmitter = _PfxEmitter.CreateEmitter(particleSystemConfig2);
		_projEmitter = projEmitter;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0023: Expected O, but got I4
		//IL_0023: Expected O, but got I4
		//IL_004a: Expected O, but got I4
		//IL_00c6: Expected O, but got I4
		//IL_0129: Expected O, but got I4
		//IL_016b: Expected O, but got I4
		//IL_01c5: Expected O, but got Ref
		//IL_0245: Expected I, but got O
		//IL_02bc: Expected O, but got I4
		//IL_03e5: Expected I, but got O
		//IL_03ac: Expected I, but got O
		//IL_0440: Expected O, but got I4
		//IL_04a5: Expected O, but got I4
		//IL_04a5: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body.setCircle(1f, (float?)(object)0, (float?)(object)0);
		float num = _weapon.PArea();
		float xScale = default(float);
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setTintFill(isEnabled: true, _myColor);
		float2 float5 = base.position;
		float2 float6 = default(float2);
		base.position = float6;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		float num2 = (float)_indexInWeapon * -100f;
		soundConfig.Rate = 2.5f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = num2;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Fireloop, soundConfig, 200f, 1, time);
		PhaserSprite phaserSprite = _GroundFx.setAlpha(0.4f);
		PhaserSprite phaserSprite2 = phaserSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite3 = phaserSprite2.setVisible(visible: true);
		ArcadeSprite arcadeSprite3 = setAlpha(0f);
		ArcadeSprite arcadeSprite4 = arcadeSprite3.setScale(0f, (float?)(object)0);
		float num3 = _weapon.PArea();
		bool flag = 2f > num2;
		float max = 2f;
		if (!flag)
		{
			max = num2;
		}
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f, max);
		object obj = default(object);
		RenderingExtensions.SetScale(_projEmitter, (ParticleSystem.MinMaxCurve)(&obj));
		if (_ScaleTween != null)
		{
			_ScaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			nint num4 = (nint)array;
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
		float num5 = _weapon.PArea();
		float duration = 0f * _radius;
		tweenConfig.scale = (float?)(object)1;
		float num6 = _weapon.PDuration();
		tweenConfig.duration = duration;
		tweenConfig.ease = Ease.Linear;
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_ScaleTween = scaleTween;
		if (_AlphaTween != null)
		{
			_AlphaTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[2];
		if ((object)_GroundFx != null)
		{
			nint num7 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		nint num8 = (nint)array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj4 = default(object);
		if (obj4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.alpha = (float?)(object)1;
			float num9 = _weapon.PDuration();
			tweenConfig2.duration = duration;
			tweenConfig2.ease = Ease.Linear;
			MultiTargetTween alphaTween = Tweens.Add(tweenConfig2);
			_AlphaTween = alphaTween;
			setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
			Weapon weapon2 = _weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
			Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
			BaseBody baseBody2 = base.body;
			baseBody2._onWorldBounds = true;
			return;
		}
		ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
		throw ex3;
	}

	public override void InternalUpdate()
	{
		//IL_0130: Expected I4, but got I8
		//IL_0096: Expected I4, but got I8
		//IL_00f6->IL009f: Incompatible stack heights: 1 vs 0
		//IL_0073->IL009f: Incompatible stack heights: 1 vs 0
		//IL_014a->IL009f: Incompatible stack heights: 2 vs 0
		//IL_009f->IL00ab: Incompatible stack heights: 2 vs 0
		if (PauseSystem._paused)
		{
			return;
		}
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			if ((object)_PfxEmitter != null)
			{
				Vector2 pos = default(Vector2);
				_PfxEmitter.EmitParticleAt(pos);
				Transform renderer = (Transform)(object)_renderer;
				if ((object)_renderer != null)
				{
					bool flag2 = ((UnityEngine.Object)renderer).m_CachedPtr == (IntPtr)0;
					Renderer.set_sortingOrder_Injected(((UnityEngine.Object)renderer).m_CachedPtr, -2);
					if ((object)_PfxEmitter != null)
					{
						ParticleEmitterManager particleEmitterManager = _PfxEmitter.SetDepth(-1);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (_ScaleTween != null)
		{
			_ScaleTween.Kill();
		}
		if (_AlphaTween != null)
		{
			_AlphaTween.Kill();
		}
		PhaserSprite phaserSprite = _GroundFx.setVisible(visible: false);
		Weapon weapon = _weapon;
		if (weapon._explodeOnExpire && ((Equipment)weapon)._equipmentType != WeaponType.TRIASSO1)
		{
			float2 pos = base.position;
			Projectile projectile = weapon.SpawnExplosionAt(pos, 0, 1, 0f);
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable target)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
		object obj2 = default(object);
		bool flag = obj2 == null;
		IDamageable damageable = target;
		if (!flag)
		{
			Weapon weapon = _weapon;
			bool flag2 = ((Equipment)weapon)._equipmentType != WeaponType.TRIASSO3;
			damageable = target;
			if (!flag2)
			{
				GameManager gameMan = weapon._gameMan;
				float2 float5 = base.position;
				Vector2 pos = default(Vector2);
				gameMan._arcanaManager.TriggerFireExplosion(pos);
				damageable = null;
			}
		}
		GameManager core2 = GM.Core;
		ArcanaManager arcanaManager2 = core2._arcanaManager;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
		object obj3 = default(object);
		if (obj3 != null)
		{
			bool flag3 = TryFreeze(target);
		}
		if (--_penetrating <= 0)
		{
			Despawn();
		}
	}

	public unsafe override void SetTarget(Transform target)
	{
		//IL_0069: Expected F4, but got I8
		//IL_007c: Expected F4, but got I4
		//IL_0097: Expected I, but got O
		//IL_011c: Expected O, but got F4
		//IL_019f: Expected I, but got O
		//IL_0143: Expected O, but got I
		//IL_0181: Expected O, but got Ref
		_targetTransform = target;
		Weapon weapon = _weapon;
		Transform playerTransform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
		float num = AngleFromTargetRadians(_targetTransform, playerTransform);
		float[] array = new float[3] { 0f, 3.2453427E+09f, 1.0978591E+09f };
		int num2 = _indexInWeapon % array.Length;
		nint num3 = (nint)this;
		float projectileSpeed = base.ProjectileSpeed;
		BaseBody baseBody = body;
		float num4 = array[num2] * ((float)Math.PI / 180f);
		float num5 = num4 + num;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		float num6 = num5 * num;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		float num7 = num5 * num;
		baseBody._velocity = (float2)num6;
		nint num8 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v21 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num9 = 0;
		BaseBody baseBody2 = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v11 (BaseBody)+74]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rcx_v12 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
		object obj = num10 - 0;
		object obj2 = (object)baseBody2._velocity - (object)Vector2.rightVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Transform transform = base.transform;
		object obj3 = default(object);
		transform.localEulerAngles = (Vector3)(&obj3);
	}

	private void _003CInitProjectile_003Eb__9_0()
	{
		Despawn();
	}
}
