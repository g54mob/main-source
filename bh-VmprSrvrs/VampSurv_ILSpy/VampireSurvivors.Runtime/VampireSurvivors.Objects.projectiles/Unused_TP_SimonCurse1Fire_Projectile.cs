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
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Unused_TP_SimonCurse1Fire_Projectile : Projectile
{
	private SpriteRenderer _GroundFx;

	private bool _particlesGenerated;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private ParticleSystem _pfxEmitter2;

	private Tween _timer;

	private Tween _alphaTween;

	private Tween _radiusTween;

	private Timer _despawnTimer;

	private float _radius = 8f;

	private float _exploRadius = 4f;

	private EmitZone _explosionCircle;

	private Tween _despawnTween;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		SpriteRenderer spriteRenderer = RenderingExtensions.AddSprite(gameObject, pos, null, "UnityCircle");
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(spriteRenderer, 0.4f);
		Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
		((Renderer)spriteRenderer2).SetMaterial(material);
		SpriteRenderer groundFx = RenderingExtensions.SetTint(spriteRenderer2, 16711680u);
		_GroundFx = groundFx;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_002b: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_003f: Expected O, but got I4
		//IL_00be: Expected O, but got I4
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected I4, but got Unknown
		base.InitProjectile(pool, weapon, index);
		if (!_particlesGenerated)
		{
			GenerateParticleSystems();
		}
		BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setAlpha(0.5f);
		Weapon weapon2 = _weapon;
		int num = ((Equipment)weapon2)._003COwner_003Ek__BackingField.Depth;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int num2 = renderer.pixelHeight >> 31;
		object obj = renderer.pixelHeight - num2;
		object obj2 = obj >> 1;
		object obj3 = obj2 - 1;
		int sortingOrder = obj3 + num;
		_renderer.sortingOrder = sortingOrder;
		Weapon weapon3 = _weapon;
		PlayerOptionsData config = weapon3._playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 259 Invalid \"Jump target not found in method: 0x1871BCF20\"");
		throw new NullReferenceException();
	}

	private unsafe void Explode(bool flashingVFX)
	{
		//IL_00de: Expected O, but got Ref
		//IL_013e: Expected O, but got Ref
		//IL_0669: Expected O, but got I4
		//IL_0828: Expected O, but got F4
		//IL_07b6->IL032d: Incompatible stack heights: 8 vs 1
		EmitZone explosionCircle = _explosionCircle;
		if ((object)_weapon != null)
		{
			float num = _weapon.PArea();
			Circle circle = new Circle();
			object obj = default(object);
			float radius = (float)obj * _exploRadius;
			circle._x = 0f;
			circle._radius = radius;
			if (_explosionCircle != null)
			{
				explosionCircle._source = circle;
				if ((object)_weapon != null)
				{
					float num2 = _weapon.PArea();
					float min = (float)obj * 0.5f;
					ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(min, 0f);
					Vector3 value = default(Vector3);
					RenderingExtensions.SetScale(_pfxEmitter, (ParticleSystem.MinMaxCurve)(&value));
					if ((object)_weapon != null)
					{
						float num3 = _weapon.PArea();
						float min2 = 0f * 0.5f;
						ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(min2, 0f);
						RenderingExtensions.SetScale(_pfxEmitter2, (ParticleSystem.MinMaxCurve)(&value));
						RenderingExtensions.SetEmitZone(_pfxEmitter, _explosionCircle);
						RenderingExtensions.SetEmitZone(_pfxEmitter2, _explosionCircle);
						DOSetter<float> groundFx = (DOSetter<float>)(object)_GroundFx;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rsi_v9 (DG.Tweening.Core.DOSetter`1<System.Single>)+10]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rsi_v9 (DG.Tweening.Core.DOSetter`1<System.Single>)+10]");
						SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)(&value));
						SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundFx, 0.8f);
						_GroundFx.enabled = false;
						RenderingExtensions.Start(_pfxEmitter);
						RenderingExtensions.Start(_pfxEmitter2);
						if (flashingVFX)
						{
							bool flag2 = (object)_GroundFx == null;
							_GroundFx.enabled = true;
							bool flag3 = (object)_GroundFx == null;
							Transform transform = _GroundFx.transform;
							bool flag4 = (object)transform == null;
							bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							Tween despawnTween = _despawnTween;
							if (_despawnTween != null && despawnTween._003Cactive_003Ek__BackingField)
							{
								TweenExtensions.Kill(_despawnTween);
							}
							bool flag6 = (object)_GroundFx == null;
							Transform target = _GroundFx.transform;
							bool flag7 = (object)_weapon == null;
							float num4 = _weapon.PArea();
							float num5 = _radius + _radius;
							float endValue = (float)Vector3.oneVector * num5;
							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, endValue, 0.120000005f);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							bool flag8 = tweenerCore == null;
							_despawnTween = tweenerCore;
						}
						Tween alphaTween = _alphaTween;
						if (_alphaTween != null && alphaTween._003Cactive_003Ek__BackingField)
						{
							TweenExtensions.Kill(_alphaTween);
						}
						TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_GroundFx, 0f, 0.120000005f);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						bool flag9 = tweenerCore2 == null;
						_alphaTween = tweenerCore2;
						Tween timer = _timer;
						if (_timer != null && timer._003Cactive_003Ek__BackingField)
						{
							TweenExtensions.Kill(_timer);
						}
						TweenCallback callback = TriggerDespawnTimer;
						Tween tween = DOVirtual.DelayedCall(0.120000005f, callback, ignoreTimeScale: false);
						TweenCallback onStart = delegate
						{
							BaseBody baseBody = body;
							baseBody._enable = true;
						};
						if (tween != null && tween._003Cactive_003Ek__BackingField)
						{
							((ABSSequentiable)tween).onStart = onStart;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						bool flag10 = tween == null;
						tween.stringId = "DefaultGameTweenId";
						_timer = tween;
						bool flag11 = (object)_weapon == null;
						float num6 = _weapon.PArea();
						Tween radiusTween = _radiusTween;
						float endValue2 = 0.120000005f * _radius;
						if (_radiusTween != null && radiusTween._003Cactive_003Ek__BackingField)
						{
							TweenExtensions.Kill(_radiusTween);
						}
						DOGetter<float> getter = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
						DOSetter<float> dOSetter = null;
						((Unused_TP_SimonCurse1Fire_Projectile)(object)dOSetter)._003CExplode_003Eb__15_2(0f);
						TweenerCore<float, float, FloatOptions> tweenerCore3 = DOTween.To(getter, dOSetter, endValue2, 0.120000005f);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						bool flag12 = tweenerCore3 == null;
						_radiusTween = tweenerCore3;
						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
						{
							Volume = (float?)(object)1,
							Rate = 1f
						};
						object obj2 = UnityEngine.Random.value;
						float num7 = 0.120000005f - 0.5f;
						float detune = num7 * 500f;
						soundConfig.Detune = detune;
						float time = default(float);
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.FireExplosion, soundConfig, 150f, 3, time);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void TriggerDespawnTimer()
	{
		//IL_01f3: Expected I, but got O
		//IL_02c4->IL023a: Incompatible stack heights: 1 vs 0
		//IL_0161->IL023a: Incompatible stack heights: 2 vs 0
		//IL_01bf->IL023a: Incompatible stack heights: 2 vs 0
		BaseBody baseBody = body;
		if (body != null)
		{
			baseBody._enable = false;
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
					Tween alphaTween = _alphaTween;
					if (_alphaTween != null && alphaTween._003Cactive_003Ek__BackingField)
					{
						TweenExtensions.Kill(_alphaTween);
					}
					Tween radiusTween = _radiusTween;
					if (_radiusTween != null && radiusTween._003Cactive_003Ek__BackingField)
					{
						TweenExtensions.Kill(_radiusTween);
					}
					Tween timer = _timer;
					if (_timer != null && timer._003Cactive_003Ek__BackingField)
					{
						TweenExtensions.Kill(_timer);
					}
					if ((object)_GroundFx != null)
					{
						_GroundFx.enabled = false;
						if (_despawnTimer != null)
						{
							_despawnTimer.Cancel();
						}
						if ((object)_particlesManager != null)
						{
							float remainingLifetime = _particlesManager.GetRemainingLifetime();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Unused_TP_SimonCurse1Fire_Projectile>)+370]");
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
		//IL_0277: Expected O, but got I4
		//IL_0290: Expected O, but got Ref
		//IL_02aa: Expected native int or pointer, but got O
		//IL_02c4: Expected O, but got I
		//IL_02e4: Expected O, but got Ref
		//IL_02fe: Expected native int or pointer, but got O
		//IL_0318: Expected O, but got I
		//IL_0338: Expected O, but got Ref
		//IL_0352: Expected native int or pointer, but got O
		//IL_0889: Expected O, but got I4
		//IL_0383: Expected O, but got I
		//IL_03bd: Expected O, but got Ref
		//IL_03d6: Expected native int or pointer, but got O
		//IL_08bb: Expected O, but got I
		//IL_040e: Expected O, but got Ref
		//IL_0435: Expected O, but got I
		//IL_044f: Expected native int or pointer, but got O
		//IL_08f5: Expected O, but got I
		//IL_063c: Expected O, but got I4
		//IL_0655: Expected O, but got Ref
		//IL_066f: Expected native int or pointer, but got O
		//IL_0689: Expected O, but got I
		//IL_06a9: Expected O, but got Ref
		//IL_06c3: Expected native int or pointer, but got O
		//IL_06dd: Expected O, but got I
		//IL_06fd: Expected O, but got Ref
		//IL_0717: Expected native int or pointer, but got O
		//IL_097c: Expected O, but got I
		//IL_0768: Expected O, but got I
		//IL_07a2: Expected O, but got Ref
		//IL_07bb: Expected native int or pointer, but got O
		//IL_07c9: Expected O, but got I4
		//IL_09a4: Expected O, but got I4
		//IL_0a6c: Expected O, but got I
		//IL_0a8d: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 416))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1A0]");
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
		_explosionCircle = emitZone;
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
			int num2 = list._size + 1;
			list._size = num2;
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
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(200f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+28]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 180f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+58]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 104));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1A0]");
		particleSystemConfig._quantity = (int?)(object)0;
		float num4 = _weapon.PArea();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		float min = 0f * 0.5f;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 136));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(min, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+98]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 168));
		_ = 0;
		_ = 1065353216;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1A0]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.5f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
		_ = 0;
		particleSystemConfig._emitZone = _explosionCircle;
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
			((List<object>)(object)list2).AddWithResize((object)"HitSmoke1");
		}
		else
		{
			int num5 = list2._size + 1;
			list2._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list2._version + 1;
		list2._version = version4;
		string[] items4 = list2._items;
		if (list2._size >= items4.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"HitSmoke2");
		}
		else
		{
			int num6 = list2._size + 1;
			list2._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		minMaxCurve = new ParticleSystem.MinMaxCurve(200f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 200));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C8]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 232));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E8]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 264));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(50f, 80f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+108]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+118]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1A0]");
		particleSystemConfig2._quantity = (int?)(object)0;
		float num7 = _weapon.PArea();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
		float min2 = 0f * 0.5f;
		ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 296));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(min2, 0f));
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+128]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+138]");
		_ = 0;
		obj = 1;
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+20]");
		_ = 0;
		_ = 0;
		_ = 1065353216;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1A0]");
		particleSystemConfig2._frequency = (float?)(object)0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1A0]");
		particleSystemConfig2._blendMode = (BlendMode?)(object)0;
		particleSystemConfig2._emitZone = _explosionCircle;
		particleSystemConfig2._on = false;
		ParticleSystem pfxEmitter2 = _particlesManager.CreateEmitter(particleSystemConfig2, null, "PfxEmitter");
		_pfxEmitter = pfxEmitter2;
		Transform transform2 = _pfxEmitter.transform;
		bool flag2 = (object)transform2 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2724 @ rax_v101 (UnityEngine.Transform)+10]");
		bool flag3 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2724 @ rax_v101 (UnityEngine.Transform)+10]");
		Transform.set_localPosition_Injected((IntPtr)0, ref value);
		_particlesGenerated = true;
	}

	private void _003CExplode_003Eb__15_0()
	{
		BaseBody baseBody = body;
		baseBody._enable = true;
	}

	private float _003CExplode_003Eb__15_1()
	{
		BaseBody baseBody = body;
		return baseBody._radius;
	}

	private void _003CExplode_003Eb__15_2(float r)
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		BaseBody baseBody = body.setCircle(r, (float?)(object)1, (float?)(object)1);
	}
}
