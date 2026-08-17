using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class SantaJavelin2ExplosionProjectile : Projectile
{
	private SpriteRenderer _VisibleSprite;

	private Tween _alphaTween;

	private Tween _despawnTween;

	private Tween _exploAlphaTween;

	private Tween _exploScaleTween;

	private Tween _colliderTween;

	private Transform _cachedWeaponTransform;

	private bool _particlesGenerated;

	private ParticleEmitterManager _particlesManager;

	private ParticleEmitterManager _particlesManagerLine;

	private ParticleSystem _pfxEmitter;

	private ParticleSystem _pfxEmitter2;

	private GravityWell _well;

	protected override void Awake()
	{
		base.Awake();
		GenerateParticleSystems();
		if ((object)_VisibleSprite != null)
		{
			Transform transform = _VisibleSprite.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_VisibleSprite, 0f);
				SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_VisibleSprite, 0f);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0086: Expected O, but got I4
		//IL_0086: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Transform cachedWeaponTransform = _weapon.transform;
		_cachedWeaponTransform = cachedWeaponTransform;
		_speed = 5f;
		base.AimForRandomDirection();
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_renderer, 0f);
		BaseBody baseBody = body.setCircle(10f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
		_isCullable = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 177 Invalid \"Jump target not found in method: 0x1872C9400\"");
		throw new NullReferenceException();
	}

	private unsafe void Explode()
	{
		//IL_0035: Expected I, but got O
		//IL_028d: Expected I, but got O
		//IL_0379: Expected I, but got O
		//IL_050e->IL0426: Incompatible stack heights: 3 vs 0
		//IL_01e0->IL0426: Incompatible stack heights: 3 vs 0
		//IL_0242->IL0426: Incompatible stack heights: 3 vs 0
		//IL_053a->IL0426: Incompatible stack heights: 3 vs 0
		//IL_0557->IL0426: Incompatible stack heights: 3 vs 0
		if (_despawnTween != null)
		{
			TweenExtensions.Kill(_despawnTween);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SantaJavelin2ExplosionProjectile>)+370]");
		TweenCallback callback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		Tween tween = DOVirtual.DelayedCall(1f, callback, ignoreTimeScale: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (tween != null)
		{
			tween.stringId = "DefaultGameTweenId";
			_despawnTween = tween;
			if ((object)_VisibleSprite != null)
			{
				Transform transform = _VisibleSprite.transform;
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					bool flag = ((ABSSequentiable)(object)transform2).tweenType == TweenType.Tweener;
					float ret;
					Transform.get_position_Injected((IntPtr)(nint)((ABSSequentiable)(object)transform2).tweenType, out *(Vector3*)(&ret));
					bool flag2 = (object)transform == null;
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					float value = default(float);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
					SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_VisibleSprite, 0.35f);
					SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_VisibleSprite, 0f);
					if (_exploAlphaTween != null)
					{
						TweenExtensions.Kill(_exploAlphaTween);
					}
					TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_VisibleSprite, 0f, 0.12f);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if (tweenerCore != null)
					{
						tweenerCore.stringId = "DefaultGameTweenId";
						_exploAlphaTween = tweenerCore;
						if ((object)_weapon != null)
						{
							float num2 = _weapon.PArea();
							if (_exploScaleTween != null)
							{
								TweenExtensions.Kill(_exploScaleTween);
							}
							if ((object)_VisibleSprite != null)
							{
								Transform target = _VisibleSprite.transform;
								TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target, 1f, 0.12f);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v963 @ r8_v19 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SantaJavelin2ExplosionProjectile>)+370]");
								TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
								nint num3 = (nint)this;
								if (tweenerCore2 != null && ((Tween)tweenerCore2)._003Cactive_003Ek__BackingField)
								{
									tweenerCore2.onComplete = onComplete;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								if (tweenerCore2 != null)
								{
									tweenerCore2.stringId = "DefaultGameTweenId";
									_exploScaleTween = tweenerCore2;
									Transform target2 = base.transform;
									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(target2, ret, 0.12f);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1200 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Projectiles.SantaJavelin2ExplosionProjectile>)+370]");
									TweenCallback onComplete2 = new TweenCallback(this, (IntPtr)0);
									nint num4 = (nint)this;
									if (tweenerCore3 != null && ((Tween)tweenerCore3)._003Cactive_003Ek__BackingField)
									{
										tweenerCore3.onComplete = onComplete2;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									if (tweenerCore3 != null)
									{
										tweenerCore3.stringId = "DefaultGameTweenId";
										_colliderTween = tweenerCore3;
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (_alphaTween != null)
		{
			TweenExtensions.Kill(_alphaTween);
		}
		if (_exploAlphaTween != null)
		{
			TweenExtensions.Kill(_exploAlphaTween);
		}
		if (_exploScaleTween != null)
		{
			TweenExtensions.Kill(_exploScaleTween);
		}
		if (_colliderTween != null)
		{
			TweenExtensions.Kill(_colliderTween);
		}
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_VisibleSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_VisibleSprite, 0f);
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(_renderer, 0f);
		SpriteRenderer spriteRenderer4 = RenderingExtensions.SetAlpha(_renderer, 0f);
		_isCullable = true;
		base.Despawn();
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_009b: Expected F4, but got I
		//IL_00ae: Expected O, but got I4
		//IL_00dd: Expected F4, but got I
		//IL_00f0: Expected O, but got I4
		//IL_0266: Expected O, but got I4
		//IL_027f: Expected O, but got Ref
		//IL_0299: Expected native int or pointer, but got O
		//IL_02b3: Expected O, but got I
		//IL_02d3: Expected O, but got Ref
		//IL_02ed: Expected native int or pointer, but got O
		//IL_0970: Expected O, but got I4
		//IL_0305: Expected O, but got Ref
		//IL_032c: Expected O, but got I
		//IL_0346: Expected native int or pointer, but got O
		//IL_098d: Expected O, but got I4
		//IL_0397: Expected O, but got I
		//IL_03b8: Expected O, but got I
		//IL_042b: Expected F4, but got I
		//IL_043e: Expected O, but got I4
		//IL_046d: Expected F4, but got I
		//IL_0480: Expected O, but got I4
		//IL_055f: Expected O, but got I4
		//IL_0578: Expected O, but got Ref
		//IL_0592: Expected native int or pointer, but got O
		//IL_05ac: Expected O, but got I
		//IL_05cc: Expected O, but got Ref
		//IL_05e6: Expected native int or pointer, but got O
		//IL_0600: Expected O, but got I
		//IL_0620: Expected O, but got Ref
		//IL_0648: Expected native int or pointer, but got O
		//IL_09c7: Expected O, but got I
		//IL_0680: Expected O, but got Ref
		//IL_06a7: Expected O, but got I
		//IL_06c1: Expected native int or pointer, but got O
		//IL_0a01: Expected O, but got I
		//IL_06f9: Expected O, but got Ref
		//IL_0713: Expected native int or pointer, but got O
		//IL_0a3b: Expected O, but got I
		//IL_074b: Expected O, but got Ref
		//IL_0765: Expected native int or pointer, but got O
		//IL_0a6d: Expected O, but got I
		//IL_07bc: Expected O, but got I
		//IL_07e3: Expected O, but got I
		//IL_0804: Expected O, but got I
		//IL_0890: Expected O, but got I
		//IL_0907: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!_particlesGenerated)
		{
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
			_particlesManager = particlesManager;
			GameObject gameObject2 = base.gameObject;
			ParticleEmitterManager particlesManagerLine = gameObject2.AddComponent<ParticleEmitterManager>();
			_particlesManagerLine = particlesManagerLine;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			float2 float5 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			float2 float6 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+194]");
			minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
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
				((List<object>)(object)list).AddWithResize((object)"PfxHoly1");
			}
			else
			{
				int num2 = list._size + 1;
				list._size = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+40]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+50]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(200f, 220f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
			_ = 0;
			_ = 100;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(4f, 0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
			_ = 0;
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
			_ = 0;
			_ = 0;
			_ = 1082130432;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
			particleSystemConfig._frequency = (float?)(object)0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
			particleSystemConfig._blendMode = (BlendMode?)(object)0;
			particleSystemConfig._on = false;
			ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter");
			_pfxEmitter = pfxEmitter;
			ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
			float2 float7 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
			minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			float2 float8 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+194]");
			minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			List<string> list2 = new List<string>();
			int version3 = list2._version + 1;
			list2._version = version3;
			string[] items3 = list2._items;
			if (list2._size >= items3.Length)
			{
				((List<object>)(object)list2).AddWithResize((object)"PfxLine2");
			}
			else
			{
				int num3 = list2._size + 1;
				list2._size = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig2._frame = list2;
			minMaxCurve = new ParticleSystem.MinMaxCurve(500f);
			particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0f, 0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
			particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
			particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D0]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
			particleSystemConfig2._angleSteps = 16;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(80f, 100f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
			particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
			particleSystemConfig2._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+100]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+110]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
			particleSystemConfig2._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(4f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+120]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+130]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-10]");
			particleSystemConfig2._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+10]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(0.5f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+150]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+18]");
			particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
			_ = 0;
			_ = 0;
			_ = 1065353216;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
			particleSystemConfig2._frequency = (float?)(object)0;
			_ = 16746751;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
			particleSystemConfig2._tint = (uint?)(object)0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
			particleSystemConfig2._blendMode = (BlendMode?)(object)0;
			particleSystemConfig2._on = false;
			ParticleSystem pfxEmitter2 = _particlesManagerLine.CreateEmitter(particleSystemConfig2, null, "PfxEmitter2");
			_pfxEmitter2 = pfxEmitter2;
			GravityWellConfig gravityWellConfig = new GravityWellConfig();
			float2 float9 = base.position;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1A0]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
			gravityWellConfig._x = (float?)(object)0;
			float2 float10 = base.position;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1A4]");
			float num4 = 0f + 0.19999999f;
			_ = 1;
			gravityWellConfig._power = 1f;
			gravityWellConfig._epsilon = 20f;
			gravityWellConfig._gravity = 200f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
			gravityWellConfig._y = (float?)(object)0;
			GravityWell well = _particlesManager.CreateGravityWell(gravityWellConfig);
			_well = well;
			_particlesGenerated = true;
		}
	}
}
