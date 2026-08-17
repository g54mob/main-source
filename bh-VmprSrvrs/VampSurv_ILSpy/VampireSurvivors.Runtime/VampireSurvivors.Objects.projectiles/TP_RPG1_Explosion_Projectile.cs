using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_RPG1_Explosion_Projectile : Projectile
{
	private bool _particlesGenerated;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private ParticleSystem _pfxEmitter2;

	private GravityWell _well;

	private Tween _timer;

	private Tween _alphaTween;

	private Tween _radiusTween;

	private Timer _despawnTimer;

	private float _radius = 32f;

	private float _exploRadius = 16f;

	private EmitZone _explosionCircle;

	private Tween _despawnTween;

	private PhaserSprite _animatedSprite;

	protected override void Awake()
	{
		//IL_00ee: Expected O, but got I4
		//IL_00ee: Expected I4, but got O
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Fire01");
		_animatedSprite = animatedSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Fire", 19, 29, vector, text, num, flag);
		PhaserSprite animatedSprite2 = _animatedSprite;
		Action action = HideExplosion;
		bool autoSetAnimation = default(bool);
		animatedSprite2._spriteAnimation.AddAnimation("explode", animationFrames, 32, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0068: Expected O, but got I4
		//IL_0068: Expected O, but got I4
		//IL_007c: Expected O, but got I4
		//IL_0048->IL013a: Incompatible stack heights: 1 vs 0
		//IL_00a4->IL013a: Incompatible stack heights: 1 vs 0
		//IL_00c6->IL013a: Incompatible stack heights: 1 vs 0
		//IL_00f5->IL013a: Incompatible stack heights: 1 vs 0
		//IL_0109->IL013a: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		if ((object)_animatedSprite != null)
		{
			Transform transform = _animatedSprite.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			_isCullable = false;
			if (!_particlesGenerated)
			{
				GenerateParticleSystems();
			}
			if (body != null)
			{
				BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
				ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
				Weapon weapon2 = _weapon;
				if ((object)_weapon != null && weapon2._playerOptions != null)
				{
					PlayerOptionsData config = weapon2._playerOptions.Config;
					if (config != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 235 Invalid \"Jump target not found in method: 0x18714E840\"");
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void HideExplosion()
	{
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
	}

	private unsafe void Explode(bool flashingVFX)
	{
		//IL_00dc: Expected O, but got I4
		//IL_018e: Expected O, but got Ref
		//IL_01c4: Expected O, but got Ref
		//IL_03b5: Expected F4, but got I4
		//IL_03d1: Expected F4, but got I4
		//IL_0501: Expected O, but got F4
		//IL_0530: Expected O, but got I4
		float num = _weapon.PArea();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num2 = default(int);
		ArcadeSprite arcadeSprite = setDepth(num2);
		int num3 = num2 + 1;
		PhaserSprite phaserSprite = _animatedSprite.setDepth(num3);
		int num4 = num2 - 2;
		RenderingExtensions.SetDepth(_pfxEmitter, num4);
		int num5 = num2 - 1;
		RenderingExtensions.SetDepth(_pfxEmitter2, num5);
		PhaserSprite phaserSprite2 = _animatedSprite.setVisible(visible: true);
		PhaserSprite phaserSprite3 = _animatedSprite.setBlendMode(BlendMode.Add);
		float num6 = default(float);
		PhaserSprite phaserSprite4 = _animatedSprite.setScale(num6, (float?)(object)0);
		PhaserSprite animatedSprite = _animatedSprite;
		animatedSprite._spriteAnimation.SetAnimation("explode");
		EmitZone explosionCircle = _explosionCircle;
		Circle circle = new Circle();
		float radius = _exploRadius * num6;
		circle._x = 0f;
		circle._radius = radius;
		explosionCircle._source = circle;
		float min = num6 * 0.5f;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(min, 0f);
		object obj = default(object);
		RenderingExtensions.SetScale(_pfxEmitter, (ParticleSystem.MinMaxCurve)(&obj));
		float min2 = num6 * 0.75f;
		ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(min2, 0f);
		RenderingExtensions.SetScale(_pfxEmitter2, (ParticleSystem.MinMaxCurve)(&obj));
		RenderingExtensions.SetEmitZone(_pfxEmitter, _explosionCircle);
		RenderingExtensions.SetEmitZone(_pfxEmitter2, _explosionCircle);
		RenderingExtensions.Start(_pfxEmitter);
		RenderingExtensions.Start(_pfxEmitter2);
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		float remainingLifetime = _particlesManager.GetRemainingLifetime();
		Action onComplete = TriggerDespawnTimer;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer despawnTimer = Timers.Register(0.5f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_despawnTimer = despawnTimer;
		BaseBody baseBody = body;
		baseBody._enable = true;
		float num7 = _weapon.PArea();
		Tween radiusTween = _radiusTween;
		float endValue = 0.5f * _radius;
		if (_radiusTween != null && radiusTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_radiusTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((TP_RPG1_Explosion_Projectile)(object)dOSetter)._003CExplode_003Eb__17_1(0f);
		TweenerCore<float, float, FloatOptions> radiusTween2 = DOTween.To(getter, dOSetter, endValue, 0.120000005f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		bool flag2 = (nint)0 != 0;
		float time = (flag ? 1 : 0);
		if (!flag2)
		{
			_ = 1;
			time = (flag ? 1 : 0);
		}
		_radiusTween = radiusTween2;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj2 = UnityEngine.Random.value;
		float num8 = 0.5f - 0.5f;
		float detune = num8 * 500f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.FireExplosion, soundConfig, 200f, 3, time);
		Weapon weapon = _weapon;
		GameManager gameMan = weapon._gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rcx_v52 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			if ((nint)obj3 != -1)
			{
				Weapon weapon2 = _weapon;
				GameManager gameMan2 = weapon2._gameMan;
				float2 float5 = base.position;
				Vector2 pos = default(Vector2);
				gameMan2._arcanaManager.TriggerFireExplosion(pos);
			}
		}
	}

	private void TriggerDespawnTimer()
	{
		//IL_01c4: Expected I, but got O
		//IL_0296->IL020c: Incompatible stack heights: 1 vs 0
		//IL_0190->IL020c: Incompatible stack heights: 2 vs 0
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
					if (_despawnTimer != null)
					{
						_despawnTimer.Cancel();
					}
					if ((object)_particlesManager != null)
					{
						float remainingLifetime = _particlesManager.GetRemainingLifetime();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v513 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_RPG1_Explosion_Projectile>)+370]");
						Action onComplete = new Action(this, (IntPtr)0);
						nint num = (nint)this;
						bool useRealTime = default(bool);
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						TimerType type = default(TimerType);
						Timer despawnTimer = Timers.Register(0.70000005f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_despawnTimer = despawnTimer;
						return;
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
		//IL_07c6: Expected O, but got I4
		//IL_07df: Expected O, but got Ref
		//IL_07f9: Expected native int or pointer, but got O
		//IL_0813: Expected O, but got I
		//IL_0833: Expected O, but got Ref
		//IL_084d: Expected native int or pointer, but got O
		//IL_0867: Expected O, but got I
		//IL_0887: Expected O, but got Ref
		//IL_08a1: Expected native int or pointer, but got O
		//IL_10d2: Expected O, but got I4
		//IL_08df: Expected O, but got I
		//IL_0901: Expected O, but got Ref
		//IL_0932: Expected native int or pointer, but got O
		//IL_110c: Expected O, but got I
		//IL_0970: Expected O, but got Ref
		//IL_0991: Expected O, but got I
		//IL_09ab: Expected native int or pointer, but got O
		//IL_1146: Expected O, but got I
		//IL_09fc: Expected O, but got I
		//IL_0de7: Expected O, but got I4
		//IL_0dfb: Expected O, but got Ref
		//IL_0e15: Expected native int or pointer, but got O
		//IL_0e34: Expected O, but got I
		//IL_0e4f: Expected O, but got Ref
		//IL_0e69: Expected native int or pointer, but got O
		//IL_0e88: Expected O, but got I
		//IL_0ea3: Expected O, but got Ref
		//IL_0ebd: Expected native int or pointer, but got O
		//IL_0eea: Expected O, but got I
		//IL_11cd: Expected O, but got I
		//IL_0f16: Expected O, but got I
		//IL_0f50: Expected O, but got Ref
		//IL_0f69: Expected native int or pointer, but got O
		//IL_1207: Expected O, but got I
		//IL_1315: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 432))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B0]");
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
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("ThosePeople");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_FireDesat19");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_FireDesat20");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_FireDesat21");
		}
		else
		{
			int num4 = list._size + 1;
			list._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_FireDesat22");
		}
		else
		{
			int num5 = list._size + 1;
			list._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_FireDesat23");
		}
		else
		{
			int num6 = list._size + 1;
			list._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list._version + 1;
		list._version = version6;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_FireDesat24");
		}
		else
		{
			int num7 = list._size + 1;
			list._size = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version7 = list._version + 1;
		list._version = version7;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_FireDesat25");
		}
		else
		{
			int num8 = list._size + 1;
			list._size = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version8 = list._version + 1;
		list._version = version8;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_FireDesat26");
		}
		else
		{
			int num9 = list._size + 1;
			list._size = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version9 = list._version + 1;
		list._version = version9;
		string[] items9 = list._items;
		if (list._size >= items9.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_FireDesat27");
		}
		else
		{
			int num10 = list._size + 1;
			list._size = num10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version10 = list._version + 1;
		list._version = version10;
		string[] items10 = list._items;
		if (list._size >= items10.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_FireDesat28");
		}
		else
		{
			int num11 = list._size + 1;
			list._size = num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version11 = list._version + 1;
		list._version = version11;
		string[] items11 = list._items;
		if (list._size >= items11.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_FireDesat29");
		}
		else
		{
			int num12 = list._size + 1;
			list._size = num12;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(600f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 180f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+58]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 120));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+88]");
		_ = 0;
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B0]");
		particleSystemConfig._quantity = (int?)(object)0;
		float num13 = _weapon.PArea();
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 152));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
		float min = 0f * 0.75f;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(min, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+98]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
		_ = 0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 184));
		_ = 1065353216;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B0]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.75f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C8]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-20]");
		_ = 0;
		particleSystemConfig._emitZone = _explosionCircle;
		_ = 0;
		_ = 4473924;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B0]");
		particleSystemConfig._tint = (uint?)(object)0;
		particleSystemConfig._on = false;
		ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter2");
		_pfxEmitter2 = pfxEmitter;
		Transform transform = _pfxEmitter2.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("ThosePeople");
		List<string> list2 = new List<string>();
		list2._002Ector();
		int version12 = list2._version + 1;
		list2._version = version12;
		string[] items12 = list2._items;
		if (list2._size >= items12.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire19");
		}
		else
		{
			int num14 = list2._size + 1;
			list2._size = num14;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version13 = list2._version + 1;
		list2._version = version13;
		string[] items13 = list2._items;
		if (list2._size >= items13.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire20");
		}
		else
		{
			int num15 = list2._size + 1;
			list2._size = num15;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version14 = list2._version + 1;
		list2._version = version14;
		string[] items14 = list2._items;
		if (list2._size >= items14.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire21");
		}
		else
		{
			int num16 = list2._size + 1;
			list2._size = num16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version15 = list2._version + 1;
		list2._version = version15;
		string[] items15 = list2._items;
		if (list2._size >= items15.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire22");
		}
		else
		{
			int num17 = list2._size + 1;
			list2._size = num17;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version16 = list2._version + 1;
		list2._version = version16;
		string[] items16 = list2._items;
		if (list2._size >= items16.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Fire23");
		}
		else
		{
			int num18 = list2._size + 1;
			list2._size = num18;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2.Add("TP_VFX_Fire24");
		list2.Add("TP_VFX_Fire25");
		list2.Add("TP_VFX_Fire26");
		list2.Add("TP_VFX_Fire27");
		list2.Add("TP_VFX_Fire28");
		list2.Add("TP_VFX_Fire29");
		particleSystemConfig2._frame = list2;
		minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 216));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D8]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 248));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F8]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+108]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 280));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(50f, 80f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+118]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+128]");
		obj = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B0]");
		particleSystemConfig2._quantity = (int?)(object)0;
		float num19 = _weapon.PArea();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
		float min2 = 0f * 0.5f;
		ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 312));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(min2, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+138]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+148]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+30]");
		_ = 0;
		_ = 0;
		_ = 1065353216;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1B0]");
		particleSystemConfig2._frequency = (float?)(object)0;
		particleSystemConfig2._emitZone = _explosionCircle;
		particleSystemConfig2._on = false;
		ParticleSystem pfxEmitter2 = _particlesManager.CreateEmitter(particleSystemConfig2, null, "PfxEmitter");
		_pfxEmitter = pfxEmitter2;
		Transform transform2 = _pfxEmitter.transform;
		bool flag2 = (object)transform2 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3235 @ rax_v124 (UnityEngine.Transform)+10]");
		bool flag3 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3235 @ rax_v124 (UnityEngine.Transform)+10]");
		Transform.set_localPosition_Injected((IntPtr)0, ref value);
		GravityWellConfig gravityWellConfig = new GravityWellConfig();
		bool flag4 = gravityWellConfig == null;
		_ = 1065353216;
		_ = 1112014848;
		_ = 1101004800;
		bool flag5 = (object)_particlesManager == null;
		GravityWell well = _particlesManager.CreateGravityWell(gravityWellConfig);
		_well = well;
		bool flag6 = (object)_well == null;
		Transform transform3 = _well.transform;
		bool flag7 = (object)transform3 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1230 @ rax_v136 (UnityEngine.Transform)+10]");
		bool flag8 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1230 @ rax_v136 (UnityEngine.Transform)+10]");
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected((IntPtr)0, ref value2);
		_particlesGenerated = true;
	}

	public override void Despawn()
	{
		if (_timer != null)
		{
			TweenExtensions.Kill(_timer);
		}
		if (_alphaTween != null)
		{
			TweenExtensions.Kill(_alphaTween);
		}
		if (_radiusTween != null)
		{
			TweenExtensions.Kill(_radiusTween);
		}
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		if (_despawnTween != null)
		{
			TweenExtensions.Kill(_despawnTween);
		}
		base.Despawn();
	}

	private float _003CExplode_003Eb__17_0()
	{
		BaseBody baseBody = body;
		return baseBody._radius;
	}

	private void _003CExplode_003Eb__17_1(float r)
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		BaseBody baseBody = body.setCircle(r, (float?)(object)1, (float?)(object)1);
	}
}
