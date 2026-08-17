using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_HolyWhip1Smoke_Projectile : Projectile
{
	private bool _particlesGenerated;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private Tween _timer;

	private Timer _despawnTimer;

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
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_FireDesat19");
		_animatedSprite = animatedSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_FireDesat", 19, 29, vector, text, num, flag);
		PhaserSprite animatedSprite2 = _animatedSprite;
		Action action = TriggerDespawnTimer;
		bool autoSetAnimation = default(bool);
		animatedSprite2._spriteAnimation.AddAnimation("explode", animationFrames, 32, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_015a: Expected O, but got F4
		//IL_01bd: Expected O, but got F4
		//IL_01fa: Expected O, but got I4
		//IL_004c: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		//IL_00d9: Expected O, but got Ref
		base.InitProjectile(pool, weapon, index);
		if (!_particlesGenerated)
		{
			GenerateParticleSystems();
		}
		float projectileSpeed = base.ProjectileSpeed;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 * 0.6f;
		float num2 = num - 0.3f;
		object obj3 = UnityEngine.Random.value;
		float num3 = (float)obj2 * 0.6f;
		float xVel = num2 * (float)obj2;
		float xScale = num3 * (float)obj2;
		setVelocity(xVel, (float?)(object)1);
		float num4 = _weapon.PArea();
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
		BaseBody baseBody = body.setCircle(_exploRadius, (float?)(object)0, (float?)(object)0);
		Weapon weapon2 = _weapon;
		PlayerOptionsData config = weapon2._playerOptions.Config;
		EmitZone explosionCircle = _explosionCircle;
		Circle circle = new Circle();
		circle._radius = _exploRadius;
		circle._x = 0f;
		explosionCircle._source = circle;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0.5f, 0f);
		object obj4 = default(object);
		RenderingExtensions.SetScale(_pfxEmitter, (ParticleSystem.MinMaxCurve)(&obj4));
		RenderingExtensions.SetEmitZone(_pfxEmitter, _explosionCircle);
		RenderingExtensions.Start(_pfxEmitter);
		PhaserSprite animatedSprite = _animatedSprite;
		animatedSprite._spriteAnimation.SetAnimation("explode");
	}

	private unsafe void Explode(bool flashingVFX)
	{
		//IL_003e: Expected O, but got Ref
		EmitZone explosionCircle = _explosionCircle;
		Circle circle = new Circle();
		circle._radius = _exploRadius;
		circle._x = 0f;
		explosionCircle._source = circle;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0.5f, 0f);
		object obj = default(object);
		RenderingExtensions.SetScale(_pfxEmitter, (ParticleSystem.MinMaxCurve)(&obj));
		RenderingExtensions.SetEmitZone(_pfxEmitter, _explosionCircle);
		RenderingExtensions.Start(_pfxEmitter);
		PhaserSprite animatedSprite = _animatedSprite;
		animatedSprite._spriteAnimation.SetAnimation("explode");
	}

	private void TriggerDespawnTimer()
	{
		//IL_0068: Expected I, but got O
		object pfxEmitter = _pfxEmitter;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rbx_v1 (System.Object)+10]");
		ParticleSystem.Stop_Injected((IntPtr)0, true, ParticleSystemStopBehavior.StopEmitting);
		float remainingLifetime = _particlesManager.GetRemainingLifetime();
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_HolyWhip1Smoke_Projectile>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer despawnTimer = Timers.Register(remainingLifetime, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_despawnTimer = despawnTimer;
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_0269: Expected O, but got Ref
		//IL_027e: Expected native int or pointer, but got O
		//IL_0298: Expected O, but got I
		//IL_02b8: Expected O, but got Ref
		//IL_02d2: Expected native int or pointer, but got O
		//IL_02ec: Expected O, but got I
		//IL_030c: Expected O, but got Ref
		//IL_0326: Expected native int or pointer, but got O
		//IL_0340: Expected O, but got I
		//IL_0360: Expected O, but got Ref
		//IL_037a: Expected native int or pointer, but got O
		//IL_053a: Expected O, but got I4
		//IL_03ab: Expected O, but got I
		//IL_03f1: Expected O, but got Ref
		//IL_0409: Expected native int or pointer, but got O
		//IL_0557: Expected O, but got I4
		//IL_042e: Expected O, but got Ref
		//IL_0455: Expected O, but got I
		//IL_046f: Expected native int or pointer, but got O
		//IL_0589: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D0]");
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
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 72));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(200f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-48]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 180f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
		particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(10f, 20f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D0]");
		particleSystemConfig._quantity = (int?)(object)0;
		float num4 = _weapon.PArea();
		float num5 = _weapon.PArea();
		float num6 = default(float);
		float max = num6 * 0.5f;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(num6, max));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
		_ = 0;
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
		_ = 0;
		_ = 1065353216;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D0]");
		particleSystemConfig._frequency = (float?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+68]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
		_ = 0;
		particleSystemConfig._emitZone = _explosionCircle;
		particleSystemConfig._on = false;
		ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter2");
		_pfxEmitter = pfxEmitter;
		Transform transform = _pfxEmitter.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		_particlesGenerated = true;
	}

	public override void Despawn()
	{
		ParticleSystem pfxEmitter = _pfxEmitter;
		bool flag = ((UnityEngine.Object)pfxEmitter).m_CachedPtr == (IntPtr)0;
		ParticleSystem.Stop_Injected(((UnityEngine.Object)pfxEmitter).m_CachedPtr, true, ParticleSystemStopBehavior.StopEmitting);
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		if (_despawnTween != null)
		{
			TweenExtensions.Kill(_despawnTween);
		}
		if (_timer != null)
		{
			TweenExtensions.Kill(_timer);
		}
		base.Despawn();
	}
}
