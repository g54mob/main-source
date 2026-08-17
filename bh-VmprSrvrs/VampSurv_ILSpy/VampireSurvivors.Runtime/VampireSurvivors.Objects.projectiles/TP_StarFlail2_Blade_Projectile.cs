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
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_StarFlail2_Blade_Projectile : Projectile
{
	private MultiTargetTween _posTween;

	private SpriteAnimation _anim;

	private MultiTargetTween _despawnTween;

	private MultiTargetTween _scaleTween;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	private float _angle;

	private const float RotationSpeed = 500f;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_Moon01", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		GenerateParticleSystem();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_025b: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_00a5: Expected I, but got O
		//IL_0128: Expected O, but got I4
		//IL_027c: Expected O, but got F4
		//IL_016f: Expected O, but got Ref
		//IL_02a4: Expected O, but got F4
		//IL_02d2: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = true;
		_speed = 1.5f;
		ArcadeSprite arcadeSprite = setScale(0.65f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(30f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setScale(0.25f, (float?)(object)0);
		ArcadeSprite arcadeSprite3 = setAlpha(0.85f);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			float num2 = _weapon.PArea();
			tweenConfig.duration = 150f;
			object obj2 = default(object);
			float num3 = (float)obj2 * 0.65f;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			object obj3 = UnityEngine.Random.value;
			float num4 = num3 * 360f;
			_angle = num4;
			Transform transform = _cachedTransform.transform;
			object obj4 = default(object);
			transform.localEulerAngles = (Vector3)(&obj4);
			Circle circle = new Circle();
			circle._x = 0f;
			circle._radius = 40f;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = circle;
			RenderingExtensions.SetEmitZone(_pfx, emitZone);
			RenderingExtensions.SetQuantity(_pfx, 1);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			object obj5 = UnityEngine.Random.value;
			object obj6 = default(object);
			float num5 = (float)obj6 - 0.5f;
			float detune = num5 * 1000f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_ShieldMedusa3, soundConfig, 500f, 1, time);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public void ManualIntProjectile(float flyAngle, bool isFlipped)
	{
		//IL_000d: Expected I, but got O
		//IL_0062: Expected O, but got I4
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0105: Expected I, but got O
		//IL_0165: Expected O, but got I4
		//IL_0191: Expected O, but got I4
		ArcadeSprite arcadeSprite = setFlipX(isFlipped);
		Weapon weapon = _weapon;
		nint num = (nint)weapon;
		float num2 = weapon.PSpeed();
		object obj = default(object);
		float num3 = (float)obj * 0.29999998f;
		float num4 = num3 * _speed;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		object obj2 = (isFlipped ? 1 : 0) ^ 1;
		float num5 = flyAngle * num4;
		object obj3 = obj2 * 2;
		object obj4 = obj3 - 1;
		float num6 = num5 * (float)obj4;
		RenderingExtensions.Start(_pfx);
		if (_posTween != null)
		{
			_posTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num7 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj5 = default(object);
		if (obj5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			float2 float5 = base.position;
			tweenConfig.x = (float?)(object)1;
			float2 float6 = base.position;
			object obj6 = default(object);
			float num8 = (float)obj6 + num6;
			tweenConfig.y = (float?)(object)1;
			float num9 = _weapon.PDuration();
			float duration = num8 * 0.5f;
			tweenConfig.duration = duration;
			TweenCallback onComplete = Shoot;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween posTween = Tweens.Add(tweenConfig);
			_posTween = posTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0026: Expected O, but got Ref
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 500f;
		float num2 = num + _angle;
		_angle = num2;
		Transform transform = _cachedTransform.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private unsafe void UpdateRotation()
	{
		//IL_0026: Expected O, but got Ref
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 500f;
		float num2 = num + _angle;
		_angle = num2;
		Transform transform = _cachedTransform.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	public unsafe void Shoot()
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		ApplyPlayerFacingVelocity((Vector3)(&obj), rotate: false);
	}

	public void FadeOut()
	{
		//IL_003f: Expected I, but got O
		//IL_0095: Expected O, but got I4
		//IL_00a3: Expected O, but got I4
		//IL_00ef: Expected I, but got O
		if (_despawnTween != null)
		{
			_despawnTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.alpha = (float?)(object)1;
			tweenConfig.scale = (float?)(object)1;
			float num2 = _weapon.PDuration();
			object obj2 = default(object);
			float duration = (float)obj2 * 0.5f;
			tweenConfig.duration = duration;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_StarFlail2_Blade_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num3 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween despawnTween = Tweens.Add(tweenConfig);
			_despawnTween = despawnTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void Despawn()
	{
		_pfx.Stop();
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_posTween != null)
		{
			_posTween.Kill();
		}
		if (_despawnTween != null)
		{
			_despawnTween.Kill();
		}
		base.Despawn();
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0207: Expected O, but got Ref
		//IL_0221: Expected native int or pointer, but got O
		//IL_03fb: Expected O, but got I4
		//IL_0239: Expected O, but got Ref
		//IL_0266: Expected O, but got I
		//IL_0287: Expected O, but got I
		//IL_029c: Expected native int or pointer, but got O
		//IL_02b6: Expected O, but got I
		//IL_02d6: Expected O, but got Ref
		//IL_02f0: Expected native int or pointer, but got O
		//IL_0418: Expected O, but got I4
		//IL_0308: Expected O, but got Ref
		//IL_0322: Expected native int or pointer, but got O
		//IL_0442: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem pfx = _pfx;
		if ((object)_pfx == null || ((UnityEngine.Object)pfx).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
			_pfxManager = pfxManager;
			Circle circle = new Circle();
			circle._x = 0f;
			circle._radius = 40f;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxHoly1.png");
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
				((List<object>)(object)list).AddWithResize((object)"PfxHoly2.png");
			}
			else
			{
				int num2 = list._size + 1;
				list._size = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 88));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
			_ = 0;
			_ = 2;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 1133903872;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
			particleSystemConfig._frequency = (float?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(600f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(2f, 1f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
			_ = 0;
			particleSystemConfig._on = false;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = circle;
			particleSystemConfig._emitZone = emitZone;
			Transform parent = base.transform;
			ParticleSystem pfx2 = _pfxManager.CreateEmitter(particleSystemConfig, parent);
			_pfx = pfx2;
		}
	}
}
