using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class ColdExplosionProjectile : Projectile
{
	private SpriteRenderer _GroundFx;

	private bool _particlesGenerated;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private ParticleSystem _pfxEmitter2;

	private GravityWell _well;

	private Tween _timer;

	private Tween _alphaTween;

	private Tween _radiusTween;

	private Timer _despawnTimer;

	private float _radius = 0.64f;

	private float _exploRadius = 16f;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		if (!_particlesGenerated)
		{
			GenerateParticleSystems();
		}
		BaseBody baseBody = body;
		baseBody._enable = false;
		Weapon weapon2 = _weapon;
		PlayerOptionsData config = weapon2._playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 77 Invalid \"Jump target not found in method: 0x18701C6F0\"");
		throw new NullReferenceException();
	}

	private unsafe void Explode(bool flashingVFX)
	{
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_02dd: Expected O, but got I4
		//IL_02dd: Expected O, but got I4
		//IL_03e7: Expected O, but got I4
		//IL_0572: Expected O, but got F4
		//IL_003d->IL041b: Incompatible stack heights: 1 vs 0
		//IL_04f1->IL0480: Incompatible stack heights: 6 vs 1
		SpriteRenderer groundFx = _GroundFx;
		if ((object)_GroundFx != null)
		{
			bool flag = ((UnityEngine.Object)groundFx).m_CachedPtr == (IntPtr)0;
			Color value = default(Color);
			SpriteRenderer.set_color_Injected(((UnityEngine.Object)groundFx).m_CachedPtr, ref value);
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundFx, 0.4f);
			if ((object)_GroundFx != null)
			{
				_GroundFx.enabled = false;
				RenderingExtensions.Start(_pfxEmitter);
				RenderingExtensions.Start(_pfxEmitter2);
				if (flashingVFX)
				{
					bool flag2 = (object)_GroundFx == null;
					_GroundFx.enabled = true;
					bool flag3 = (object)_GroundFx == null;
					Transform transform = _GroundFx.transform;
					bool flag4 = (object)_weapon == null;
					float num = _weapon.PArea();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12400]");
					float num2 = 0f * _radius;
					float num3 = num2 * (float)Vector3.oneVector;
					bool flag5 = (object)transform == null;
					bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
				}
				if (_alphaTween != null)
				{
					TweenExtensions.Kill(_alphaTween);
				}
				TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_GroundFx, 0f, 0.120000005f);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				bool flag7 = tweenerCore == null;
				_alphaTween = tweenerCore;
				if (_timer != null)
				{
					TweenExtensions.Kill(_timer);
				}
				TweenCallback callback = TriggerDespawnTimer;
				Tween tween = DOVirtual.DelayedCall(0.120000005f, callback, ignoreTimeScale: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				bool flag8 = tween == null;
				_timer = tween;
				bool flag9 = (object)_weapon == null;
				float num4 = _weapon.PArea();
				float num5 = 0.120000005f * _radius;
				float num6 = num5 * 0.5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				object obj = num6 ^ 0;
				bool flag10 = body == null;
				BaseBody baseBody = body.setCircle(num6, (float?)(object)1, (float?)(object)1);
				BaseBody baseBody2 = body;
				bool flag11 = body == null;
				baseBody2._enable = true;
				if (_radiusTween != null)
				{
					TweenExtensions.Kill(_radiusTween);
				}
				DOGetter<float> getter = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				DOSetter<float> dOSetter = null;
				((ColdExplosionProjectile)(object)dOSetter)._003CExplode_003Eb__13_1(num6);
				TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter, dOSetter, num6, 0.120000005f);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				bool flag12 = tweenerCore2 == null;
				_radiusTween = tweenerCore2;
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
				{
					Volume = (float?)(object)1,
					Rate = 1f
				};
				object obj2 = UnityEngine.Random.value;
				float num7 = (float)obj - 0.5f;
				float detune = num7 * 500f;
				soundConfig.Detune = detune;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.FireExplosion, soundConfig, 150f, 3, time);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void TriggerDespawnTimer()
	{
		//IL_0179: Expected I, but got O
		//IL_024a->IL01c0: Incompatible stack heights: 1 vs 0
		//IL_00b0->IL01c0: Incompatible stack heights: 2 vs 0
		//IL_00e9->IL01c0: Incompatible stack heights: 2 vs 0
		//IL_0145->IL01c0: Incompatible stack heights: 2 vs 0
		ParticleSystem pfxEmitter = _pfxEmitter;
		if ((object)_pfxEmitter != null)
		{
			bool flag = ((UnityEngine.Object)pfxEmitter).m_CachedPtr == (IntPtr)0;
			ParticleSystem.Stop_Injected(((UnityEngine.Object)pfxEmitter).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
			ParticleSystem pfxEmitter2 = _pfxEmitter2;
			if ((object)_pfxEmitter2 != null)
			{
				bool flag2 = ((UnityEngine.Object)pfxEmitter2).m_CachedPtr == (IntPtr)0;
				ParticleSystem.Stop_Injected(((UnityEngine.Object)pfxEmitter2).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
				if (_alphaTween != null)
				{
					TweenExtensions.Kill(_alphaTween);
				}
				if (_radiusTween != null)
				{
					TweenExtensions.Kill(_radiusTween);
				}
				if (_timer != null)
				{
					TweenExtensions.Kill(_timer);
				}
				if ((object)_GroundFx != null)
				{
					_GroundFx.enabled = false;
					BaseBody baseBody = body;
					if (body != null)
					{
						baseBody._enable = false;
						if (_despawnTimer != null)
						{
							_despawnTimer.Cancel();
						}
						if ((object)_particlesManager != null)
						{
							float remainingLifetime = _particlesManager.GetRemainingLifetime();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.ColdExplosionProjectile>)+370]");
							Action onComplete = new Action(this, (IntPtr)0);
							nint num = (nint)this;
							bool useRealTime = default(bool);
							MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
							int repeat = default(int);
							TimerType type = default(TimerType);
							Timer despawnTimer = Timers.Register(remainingLifetime, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							_despawnTimer = despawnTimer;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_0293: Expected O, but got I4
		//IL_02ac: Expected O, but got Ref
		//IL_02c6: Expected native int or pointer, but got O
		//IL_02e0: Expected O, but got I
		//IL_0300: Expected O, but got Ref
		//IL_031a: Expected native int or pointer, but got O
		//IL_0334: Expected O, but got I
		//IL_0354: Expected O, but got Ref
		//IL_036e: Expected native int or pointer, but got O
		//IL_0934: Expected O, but got I
		//IL_03a6: Expected O, but got Ref
		//IL_03cd: Expected O, but got I
		//IL_03e7: Expected native int or pointer, but got O
		//IL_096e: Expected O, but got I
		//IL_041f: Expected O, but got Ref
		//IL_0446: Expected O, but got I
		//IL_0460: Expected native int or pointer, but got O
		//IL_09a8: Expected O, but got I
		//IL_064d: Expected O, but got I4
		//IL_0666: Expected O, but got Ref
		//IL_0680: Expected native int or pointer, but got O
		//IL_069a: Expected O, but got I
		//IL_06ba: Expected O, but got Ref
		//IL_06d4: Expected native int or pointer, but got O
		//IL_06ee: Expected O, but got I
		//IL_070e: Expected O, but got Ref
		//IL_0728: Expected native int or pointer, but got O
		//IL_0743: Expected O, but got I
		//IL_0a2f: Expected O, but got I
		//IL_0763: Expected O, but got Ref
		//IL_078a: Expected O, but got I
		//IL_07a4: Expected native int or pointer, but got O
		//IL_0a69: Expected O, but got I
		//IL_0b62: Expected O, but got I
		//IL_0b83: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 464))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1D0]");
			particlesManager = (ParticleEmitterManager)0;
		}
		else
		{
			particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particlesManager = particlesManager;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		float num = _weapon.PArea();
		Circle circle = new Circle();
		object obj3 = default(object);
		float radius = (float)obj3 * _exploRadius;
		circle._x = 0f;
		circle._radius = radius;
		emitZone._source = circle;
		emitZone._type = EmitZoneType.Random;
		emitZone._yoyo = false;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"feedback-5");
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
			((List<object>)(object)list).AddWithResize((object)"feedback-4");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+58]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 180f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+68]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+78]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+98]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1D0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 200));
		_ = 0;
		_ = 1065353216;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1D0]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-10]");
		_ = 0;
		particleSystemConfig._emitZone = emitZone;
		particleSystemConfig._on = false;
		ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter2");
		_pfxEmitter2 = pfxEmitter;
		Transform transform = _pfxEmitter2.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		list2._002Ector();
		int version3 = list2._version + 1;
		list2._version = version3;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"feedback-5");
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
			((List<object>)(object)list2).AddWithResize((object)"feedback-4");
		}
		else
		{
			int num5 = list2._size + 1;
			list2._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 232));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E8]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 264));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+108]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+118]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 296));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(50f, 80f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+128]");
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+138]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 328));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1D0]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+148]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+158]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+20]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+40]");
		_ = 0;
		_ = 0;
		_ = 1065353216;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1D0]");
		particleSystemConfig2._frequency = (float?)(object)0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1D0]");
		particleSystemConfig2._blendMode = (BlendMode?)(object)0;
		particleSystemConfig2._emitZone = emitZone;
		particleSystemConfig2._on = false;
		bool flag2 = (object)_particlesManager == null;
		ParticleSystem pfxEmitter2 = _particlesManager.CreateEmitter(particleSystemConfig2, null, "PfxEmitter");
		_pfxEmitter = pfxEmitter2;
		bool flag3 = (object)_pfxEmitter == null;
		Transform transform2 = _pfxEmitter.transform;
		bool flag4 = (object)transform2 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v953 @ rax_v96 (UnityEngine.Transform)+10]");
		bool flag5 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v953 @ rax_v96 (UnityEngine.Transform)+10]");
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected((IntPtr)0, ref value2);
		GravityWellConfig gravityWellConfig = new GravityWellConfig();
		bool flag6 = gravityWellConfig == null;
		_ = 1065353216;
		_ = 1112014848;
		_ = 1101004800;
		bool flag7 = (object)_particlesManager == null;
		GravityWell well = _particlesManager.CreateGravityWell(gravityWellConfig);
		_well = well;
		bool flag8 = (object)_well == null;
		Transform transform3 = _well.transform;
		bool flag9 = (object)transform3 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ rax_v105 (UnityEngine.Transform)+10]");
		bool flag10 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ rax_v105 (UnityEngine.Transform)+10]");
		Vector3 value3 = default(Vector3);
		Transform.set_localPosition_Injected((IntPtr)0, ref value3);
		_particlesGenerated = true;
	}

	private float _003CExplode_003Eb__13_0()
	{
		BaseBody baseBody = body;
		return baseBody._radius;
	}

	private void _003CExplode_003Eb__13_1(float r)
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		BaseBody baseBody = body.setCircle(r, (float?)(object)1, (float?)(object)1);
	}
}
