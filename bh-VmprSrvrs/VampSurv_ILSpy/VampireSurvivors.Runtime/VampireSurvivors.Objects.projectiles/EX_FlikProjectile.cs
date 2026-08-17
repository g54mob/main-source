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

public class EX_FlikProjectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private MultiTargetTween _animTween;

	private SpriteAnimation _anims;

	private Transform _cachedSpriteTransform;

	private Vector2 _collisionPos;

	private Vector2 _spritePos;

	private float physArea = 16f;

	public float _life;

	private ParticleEmitterManager _pfxEmitterManager;

	private ParticleSystem _pfxEmitter;

	private SpriteRenderer _lanceSprite;

	private MultiTargetTween _tween3;

	private bool _initialisedParticles;

	protected override void Awake()
	{
		//IL_0106->IL00af: Incompatible stack heights: 1 vs 0
		//IL_009b->IL00af: Incompatible stack heights: 1 vs 0
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if ((object)_lanceSprite != null)
		{
			Transform transform = _lanceSprite.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
				if ((object)_lanceSprite != null)
				{
					GameObject gameObject = _lanceSprite.gameObject;
					if ((object)gameObject != null)
					{
						gameObject.SetActive(value: false);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0544: Expected O, but got I4
		//IL_0558: Expected O, but got I4
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008c: Expected O, but got I
		//IL_008c: Expected O, but got I
		//IL_02cc: Expected O, but got Ref
		//IL_02f3: Expected O, but got I
		//IL_0308: Expected native int or pointer, but got O
		//IL_0322: Expected O, but got I
		//IL_0342: Expected O, but got Ref
		//IL_035c: Expected native int or pointer, but got O
		//IL_05b5: Expected O, but got I4
		//IL_0374: Expected O, but got Ref
		//IL_038e: Expected native int or pointer, but got O
		//IL_03a8: Expected O, but got I
		//IL_03c8: Expected O, but got Ref
		//IL_03ef: Expected O, but got I
		//IL_0409: Expected native int or pointer, but got O
		//IL_05d2: Expected O, but got I4
		//IL_043b: Expected O, but got Ref
		//IL_0455: Expected native int or pointer, but got O
		//IL_060c: Expected O, but got I
		//IL_04a6: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
		float num = physArea;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj3 = num ^ 0;
		_ = 0;
		float num2 = physArea;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj4 = num2 ^ 0;
		_ = 0;
		_ = 1;
		_ = 1;
		BaseBody baseBody = body;
		float radius = physArea;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+A8]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+A0]");
		BaseBody baseBody2 = baseBody.setCircle(radius, (float?)(object)num3, (float?)(object)0);
		GameObject gameObject = _lanceSprite.gameObject;
		gameObject.SetActive(value: true);
		Transform cachedSpriteTransform = _lanceSprite.transform;
		_cachedSpriteTransform = cachedSpriteTransform;
		SpriteAnimation anims = _anims;
		if ((object)_anims == null || ((UnityEngine.Object)anims).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject2 = _lanceSprite.gameObject;
			SpriteAnimation anims2 = gameObject2.AddComponent<SpriteAnimation>();
			_anims = anims2;
			int num4 = default(int);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("flik_0", 1, 4, "vfx", num4);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			_anims.AddAnimation("idle", animationFrames, 16, (byte)num4 != 0, startRandomFrame, onComplete, autoSetAnimation);
		}
		if (!_initialisedParticles)
		{
			Circle circle = new Circle();
			circle._x = 0f;
			circle._radius = 16f;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"WhiteDot");
			}
			else
			{
				int num5 = list._size + 1;
				list._size = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
			_ = 0;
			_ = 10;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+A0]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(500f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-38]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-28]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+8]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+18]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+A0]");
			particleSystemConfig._blendMode = (BlendMode?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+38]");
			_ = 0;
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-68]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 72));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+58]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-60]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-40]");
			_ = 0;
			_ = 0;
			_ = 35071;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+A0]");
			particleSystemConfig._tint = (uint?)(object)0;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			emitZone._source = circle;
			particleSystemConfig._emitZone = emitZone;
			particleSystemConfig._on = false;
			Transform parent = base.transform;
			ParticleSystem pfxEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent);
			_pfxEmitter = pfxEmitter;
			_initialisedParticles = true;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1185 Invalid \"Jump target not found in method: 0x187266030\"");
		throw new NullReferenceException();
	}

	private unsafe void OnRecycle()
	{
		//IL_0044: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		//IL_0128: Expected I, but got O
		//IL_0192: Expected I, but got O
		//IL_021b: Expected O, but got I4
		//IL_0229: Expected O, but got I4
		//IL_027d: Expected O, but got I4
		//IL_02cb: Expected I, but got O
		//IL_034b: Expected O, but got I4
		//IL_03ea: Expected I, but got O
		//IL_0387: Expected O, but got I4
		//IL_04c2: Expected I, but got O
		//IL_054b: Expected O, but got Ref
		//IL_05c6: Expected O, but got I4
		//IL_05dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e1: Expected I4, but got Unknown
		//IL_0658: Expected O, but got F4
		//IL_06af: Expected O, but got F4
		//IL_070b: Expected F4, but got I4
		_lanceSprite.enabled = false;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_lanceSprite, 0.65f);
		_pfxEmitter.Stop();
		_collisionPos = (Vector2)0;
		_spritePos = (Vector2)0;
		float num = _weapon.PSpeed();
		float num2 = default(float);
		bool flag = num2 > 5f;
		float num3 = 5f;
		if (!flag)
		{
			num3 = num2;
		}
		float num4 = _weapon.PArea();
		_life = 0f;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_cachedTransform != null)
		{
			nint num5 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Transform transform = _lanceSprite.transform;
		if ((object)transform != null)
		{
			nint num6 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		Transform transform2 = transform;
		tweenConfig.duration = 120f;
		tweenConfig.ease = Ease.Linear;
		float num7 = num3 * num2;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.scaleY = (float?)(object)1;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
		if (_alphaTween != null)
		{
			_alphaTween.Restart();
			float? num8 = (float?)(object)1;
		}
		else
		{
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			if ((object)_lanceSprite != null)
			{
				nint num9 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 60f;
			tweenConfig2.ease = Ease.Linear;
			tweenConfig2.delay = 120f;
			tweenConfig2.alpha = (float?)(object)1;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig2);
			MultiTargetTween alphaTween = multiTargetTween.SetAutoKill(autoKill: false);
			_alphaTween = alphaTween;
			float? num8 = (float?)(object)1;
			transform2 = null;
		}
		if (_tween3 != null)
		{
			_tween3.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		nint num10 = (nint)array3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj4 = default(object);
		if (obj4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array3;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_life", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig3.custom = dictionary;
			tweenConfig3.duration = 90f;
			tweenConfig3.ease = Ease.Linear;
			tweenConfig3.yoyo = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1403 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EX_FlikProjectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num11 = (nint)this;
			tweenConfig3.onComplete = onComplete;
			MultiTargetTween tween = Tweens.Add(tweenConfig3);
			_tween3 = tween;
			float num12 = base.RotateTowardsEnemy();
			float num13 = num7 * -1f;
			float num14 = num13 * ((float)Math.PI / 180f);
			Transform transform3 = _lanceSprite.transform;
			object obj5 = default(object);
			transform3.localEulerAngles = (Vector3)(&obj5);
			Weapon weapon = _weapon;
			int num15 = ((Equipment)weapon)._003COwner_003Ek__BackingField.Depth;
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer = s_scene._renderer;
				int num16 = renderer.pixelHeight >> 31;
				object obj6 = renderer.pixelHeight - num16;
				object obj7 = obj6 >> 1;
				int sortingOrder = num15 + obj7;
				_lanceSprite.sortingOrder = sortingOrder;
				float num17 = physArea * 0.01f;
				float num18 = num17 * num2;
				float num19 = num18 * num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				float num20 = num19 * 6f;
				float num21 = num14 * num20;
				_collisionPos = (Vector2)num21;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float num22 = num19 * -6f;
				float num23 = num14 * num22;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				float num24 = num14 * 0.12f;
				_spritePos = (Vector2)num24;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float num25 = num14 * -0.12f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sbb eax,eax\"");
				float? volume = default(float?);
				float rate = default(float);
				float detune = default(float);
				bool loop = default(bool);
				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.sfx_flikA, 100f, 1, 0f, volume, rate, detune, loop, 1f);
				_anims.SetAnimation("idle");
				return;
			}
			throw new NullReferenceException();
		}
		ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
		throw ex4;
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_tween3 != null)
		{
			_tween3.Kill();
		}
		_pfxEmitter.Stop();
		_lanceSprite.enabled = false;
		base.Despawn();
	}

	public unsafe override void InternalUpdate()
	{
		_lanceSprite.enabled = true;
		Weapon weapon = _weapon;
		float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		float2 pos = default(float2);
		base.position = pos;
		Transform cachedSpriteTransform = _cachedSpriteTransform;
		bool flag = ((UnityEngine.Object)cachedSpriteTransform).m_CachedPtr == (IntPtr)0;
		float2 value = default(float2);
		Transform.set_position_Injected(((UnityEngine.Object)cachedSpriteTransform).m_CachedPtr, ref *(Vector3*)(&value));
		float2 float6 = base.position;
		RenderingExtensions.EmitParticleAt(_pfxEmitter, pos, 4);
	}
}
