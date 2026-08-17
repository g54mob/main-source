using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class CarnageExplosionProjectile : Projectile
{
	private SpriteRenderer _ScreenSprite;

	private SpriteAnimation _ScreenSpriteAnimation;

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

	private float _totalTime;

	private CarnageWeapon _trueWeapon;

	private float _colliderRadius = 0.1f;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_003b: Expected I, but got O
		//IL_0043: Expected I, but got O
		//IL_0053: Expected O, but got I
		//IL_00d3: Expected O, but got I4
		//IL_008f: Expected O, but got I
		//IL_00c5: Expected O, but got I4
		//IL_0163: Expected O, but got I4
		//IL_0163: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Transform cachedWeaponTransform = _weapon.transform;
		_cachedWeaponTransform = cachedWeaponTransform;
		Weapon weapon2 = _weapon;
		CarnageWeapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_0238;
		}
		nint num = (nint)typeof(CarnageWeapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.CarnageWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ r10_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.CarnageWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ r10_v3 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rax_v33+FFFFFFF8+v263 @ rax_v28*8]");
			if (0 == (nint)typeof(CarnageWeapon))
			{
				obj3 = 1;
				goto IL_0247;
			}
		}
		obj3 = 0;
		goto IL_0247;
		IL_0247:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = (CarnageWeapon)_weapon;
		}
		goto IL_0238;
		IL_0238:
		_trueWeapon = trueWeapon;
		GenerateParticleSystems();
		SetScaleToArea();
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_renderer, 1f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_renderer, 0f);
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetTint(_renderer, 56831u);
		BaseBody baseBody = body.setCircle(10f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
		SpriteRenderer spriteRenderer4 = RenderingExtensions.SetAlpha(_ScreenSprite, 0.5f);
		_ScreenSprite.enabled = false;
		float num4 = _weapon.PArea();
		float num5 = default(float);
		SpriteRenderer spriteRenderer5 = RenderingExtensions.SetScale(_ScreenSprite, num5);
		_isCullable = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 334 Invalid \"Jump target not found in method: 0x1870097A0\"");
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		//IL_0217: Expected O, but got F4
		//IL_0043->IL01b7: Incompatible stack heights: 1 vs 0
		//IL_00b4->IL01b7: Incompatible stack heights: 1 vs 0
		//IL_00d6->IL01b7: Incompatible stack heights: 1 vs 0
		//IL_0120->IL01b7: Incompatible stack heights: 1 vs 0
		//IL_0142->IL01b7: Incompatible stack heights: 1 vs 0
		Camera mainCamera = _mainCamera;
		if ((object)_mainCamera != null)
		{
			bool flag = ((UnityEngine.Object)mainCamera).m_CachedPtr == (IntPtr)0;
			object obj = Camera.get_orthographicSize_Injected(((UnityEngine.Object)mainCamera).m_CachedPtr);
			object obj2 = default(object);
			float num = (float)obj2 * -2f;
			float num2 = num * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
			if ((object)_renderer != null)
			{
				int sortingOrder = default(int);
				_renderer.sortingOrder = sortingOrder;
				float deltaTime = PauseSystem.DeltaTime;
				float num3 = deltaTime * 1000f;
				Weapon weapon = _weapon;
				float totalTime = num3 + _totalTime;
				_totalTime = totalTime;
				if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
				{
					float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					Weapon weapon2 = _weapon;
					if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
					{
						float2 float6 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
						bool flag2 = (object)_well == null;
						Transform transform = _well.transform;
						bool flag3 = (object)transform == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rax_v27 (UnityEngine.Transform)+10]");
						bool flag4 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rax_v27 (UnityEngine.Transform)+10]");
						Vector3 value = default(Vector3);
						Transform.set_position_Injected((IntPtr)0, ref value);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Explode()
	{
		//IL_0225: Expected I, but got O
		//IL_01b6: Expected O, but got I
		//IL_0796->IL061a: Incompatible stack heights: 1 vs 0
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ScreenSprite, 0f);
		if ((object)_ScreenSprite != null)
		{
			_ScreenSprite.enabled = true;
			if ((object)_ScreenSpriteAnimation != null)
			{
				_ScreenSpriteAnimation.SetAnimation("screen");
				SpriteAnimation screenSpriteAnimation = _ScreenSpriteAnimation;
				if ((object)_ScreenSpriteAnimation != null)
				{
					((BaseSpriteAnimation)screenSpriteAnimation)._003CIsPaused_003Ek__BackingField = false;
					if (_alphaTween != null)
					{
						TweenExtensions.Kill(_alphaTween);
					}
					TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_ScreenSprite, 0.5f, 0.120000005f);
					if (tweenerCore != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
							if ((nint)0 == 0)
							{
								_ = 2;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
									nint num = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v18 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
									object obj = num + 0;
								}
							}
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if (tweenerCore != null)
					{
						_alphaTween = tweenerCore;
						if (_despawnTween != null)
						{
							TweenExtensions.Kill(_despawnTween);
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v846 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.CarnageExplosionProjectile>)+370]");
						TweenCallback callback = new TweenCallback(this, (IntPtr)0);
						nint num2 = (nint)this;
						Tween tween = DOVirtual.DelayedCall(1f, callback, ignoreTimeScale: false);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						if (tween != null)
						{
							_despawnTween = tween;
							SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_renderer, 1f);
							SpriteRenderer spriteRenderer3 = RenderingExtensions.SetScale(_renderer, 1f);
							if (_exploAlphaTween != null)
							{
								TweenExtensions.Kill(_exploAlphaTween);
							}
							TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleSprite.DOFade(_renderer, 0f, 0.120000005f);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if (tweenerCore2 != null)
							{
								_exploAlphaTween = tweenerCore2;
								if ((object)_weapon != null)
								{
									float num3 = _weapon.PArea();
									float num4 = 1f * 5f;
									if (_exploScaleTween != null)
									{
										TweenExtensions.Kill(_exploScaleTween);
									}
									if ((object)_renderer != null)
									{
										Transform target = _renderer.transform;
										TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(target, num4, 0.120000005f);
										TweenCallback tweenCallback = delegate
										{
											BaseBody baseBody = body;
											baseBody._enable = false;
										};
										if (tweenerCore3 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1200 @ rax_v45 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
											if ((nint)0 == 0)
											{
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
										if ((nint)0 == 0)
										{
											_ = 1;
										}
										if (tweenerCore3 != null)
										{
											_exploScaleTween = tweenerCore3;
											if (_colliderTween != null)
											{
												TweenExtensions.Kill(_colliderTween);
											}
											DOGetter<float> getter = null;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
											DOSetter<float> dOSetter = null;
											((CarnageExplosionProjectile)(object)dOSetter)._003CExplode_003Eb__19_2(num4);
											float endValue = _colliderRadius * num4;
											TweenerCore<float, float, FloatOptions> tweenerCore4 = DOTween.To(getter, dOSetter, endValue, 0.120000005f);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
											if ((nint)0 == 0)
											{
												_ = 1;
											}
											if (tweenerCore4 != null)
											{
												_colliderTween = tweenerCore4;
												SpriteRenderer cachedTransform = (SpriteRenderer)(object)_cachedTransform;
												if ((object)_cachedTransform != null)
												{
													if (((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0)
													{
														UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_cachedTransform);
													}
													else
													{
														Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
														if ((object)_particlesManager != null)
														{
															Vector2 pos = default(Vector2);
															_particlesManager.EmitParticleAt(pos, 100);
															SpriteRenderer cachedTransform2 = (SpriteRenderer)(object)_cachedTransform;
															if ((object)_cachedTransform != null)
															{
																bool flag = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
																Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out ret);
																if ((object)_particlesManagerLine != null)
																{
																	_particlesManagerLine.EmitParticleAt(pos);
																	return;
																}
															}
														}
													}
												}
											}
										}
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
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_ScreenSprite, 0f);
		_ScreenSprite.enabled = false;
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_renderer, 0f);
		SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_renderer, 0f);
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
				((List<object>)(object)list).AddWithResize((object)"PfxPink");
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
				((List<object>)(object)list).AddWithResize((object)"PfxPurple");
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

	private void _003CExplode_003Eb__19_0()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
	}

	private float _003CExplode_003Eb__19_1()
	{
		return body.WorldRadius;
	}

	private void _003CExplode_003Eb__19_2(float r)
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		BaseBody baseBody = body.setCircle(r, (float?)(object)1, (float?)(object)1);
	}
}
