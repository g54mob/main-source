using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class FB_CrossbowCrashWeapon : FB_BladeCrossbowWeapon
{
	private BulletPool _crossPool;

	public float defaultWidth = 50f;

	private float _critChance = 0.05f;

	private Timer _evoTimer;

	private float _crossTime;

	private float _crossBaseDelay = 30000f;

	private float _nextInterval = 30000f;

	private float _projectileStock;

	private float _projectileTime;

	private float _projectileInterval = 500f;

	private PhaserSprite _lightSprite;

	private bool _hasSprites;

	private MultiTargetTween _tween1;

	private MultiTargetTween _tween2;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	private Rectangle _pfxRecta;

	private unsafe float Intensity()
	{
		PhaserSprite lightSprite = _lightSprite;
		if ((object)_lightSprite != null)
		{
			PhaserSprite spriteRenderer = (PhaserSprite)(object)lightSprite._spriteRenderer;
			if ((object)lightSprite._spriteRenderer != null)
			{
				bool flag = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				float ret;
				SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out *(Color*)(&ret));
				float result = default(float);
				return result;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00eb: Expected I, but got O
		//IL_035e: Expected O, but got I4
		//IL_01ef: Expected I, but got O
		//IL_05f2: Expected O, but got I
		//IL_069d: Expected O, but got I
		//IL_0748: Expected O, but got I
		//IL_0799: Expected O, but got Ref
		//IL_07b3: Expected native int or pointer, but got O
		//IL_0ab7: Expected O, but got I4
		//IL_07cb: Expected O, but got Ref
		//IL_07f2: Expected O, but got I
		//IL_080c: Expected native int or pointer, but got O
		//IL_0826: Expected O, but got I
		//IL_0846: Expected O, but got Ref
		//IL_085b: Expected native int or pointer, but got O
		//IL_0875: Expected O, but got I
		//IL_0895: Expected O, but got Ref
		//IL_08af: Expected native int or pointer, but got O
		//IL_0ad4: Expected O, but got I4
		//IL_08d4: Expected O, but got Ref
		//IL_08ee: Expected native int or pointer, but got O
		//IL_0b06: Expected O, but got I
		//IL_0245->IL0245: Incompatible stack heights: 12 vs 0
		//IL_0a7d->IL09a0: Incompatible stack heights: 1 vs 0
		//IL_0422->IL09a0: Incompatible stack heights: 1 vs 0
		//IL_044e->IL09a0: Incompatible stack heights: 1 vs 0
		//IL_047a->IL09a0: Incompatible stack heights: 1 vs 0
		//IL_0aa4->IL09a0: Incompatible stack heights: 1 vs 0
		//IL_04ae->IL09a0: Incompatible stack heights: 1 vs 0
		//IL_0556->IL09a0: Incompatible stack heights: 1 vs 0
		//IL_0598->IL09a0: Incompatible stack heights: 1 vs 0
		//IL_0643->IL09a0: Incompatible stack heights: 1 vs 0
		//IL_06ee->IL09a0: Incompatible stack heights: 1 vs 0
		//IL_0774->IL09a0: Incompatible stack heights: 1 vs 0
		//IL_095d->IL09a0: Incompatible stack heights: 1 vs 0
		//IL_09a0->IL0a1d: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitWeapon(characterController, weaponType);
		if (_crossPool == null)
		{
			bool flag = (object)_projectileFactory == null;
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.FB_CROSSBOWCRASH_SWORD);
			BulletPool crossPool = new BulletPool(projectilePrefab);
			_crossPool = crossPool;
			bool flag2 = (object)GM.Core == null;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			bool flag3 = ArcadePhysics.s_scene == null;
			ArcadePhysics physics = s_scene.physics;
			bool flag4 = (object)s_scene.physics == null;
			GameManager core = GM.Core;
			bool flag5 = (object)GM.Core == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1112 @ r8_v106 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_CrossbowCrashWeapon>)+370]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			bool flag6 = physics.add == null;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_crossPool, core.Enemies, collideCallback, processCallback, callbackContext);
			bool flag7 = (object)GM.Core == null;
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			bool flag8 = ArcadePhysics.s_scene == null;
			ArcadePhysics physics2 = s_scene2.physics;
			bool flag9 = (object)s_scene2.physics == null;
			GameManager core2 = GM.Core;
			bool flag10 = (object)GM.Core == null;
			PhysicsManager physicsManager = core2._physicsManager;
			bool flag11 = core2._physicsManager == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1201 @ r8_v109 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_CrossbowCrashWeapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			bool flag12 = physics2.add == null;
			Collider collider2 = physics2.add.overlap(_crossPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
		_crossTime = (_nextInterval = GetSpecialInterval());
		if (_hasSprites)
		{
			return;
		}
		_hasSprites = true;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite lightSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "HolyBeamGradient");
		_lightSprite = lightSprite;
		if ((object)_lightSprite != null)
		{
			PhaserSprite phaserSprite = _lightSprite.setBlendMode(BlendMode.Add);
			if ((object)_lightSprite != null)
			{
				PhaserSprite phaserSprite2 = _lightSprite.setAlpha(0.15f);
				if ((object)_lightSprite != null)
				{
					PhaserSprite phaserSprite3 = _lightSprite.setScale(0f, (float?)(object)0);
					if ((object)_lightSprite != null)
					{
						Transform transform = _lightSprite.transform;
						if ((object)transform != null)
						{
							bool flag13 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1174 @ rcx_v24 (Il2CppMethodInfo)+38]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
							}
							Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
							if ((object)_lightSprite != null)
							{
								PhaserSprite phaserSprite4 = _lightSprite.setVisible(visible: false);
								if ((object)_lightSprite != null)
								{
									GameObject gameObject2 = _lightSprite.gameObject;
									if ((object)gameObject2 != null)
									{
										((UnityEngine.Object)gameObject2).SetName("HolyBeamGradient");
										if ((object)GM.Core != null)
										{
											PhaserScene s_scene3 = ArcadePhysics.s_scene;
											if (ArcadePhysics.s_scene != null)
											{
												PhaserScene.Renderer renderer = s_scene3._renderer;
												if (s_scene3._renderer != null)
												{
													Rectangle rectangle = new Rectangle();
													float y = renderer.screenHeight * 0.5f;
													rectangle._height = renderer.screenHeight;
													rectangle._y = y;
													rectangle._x = -0.32f;
													rectangle._width = 0.64f;
													_pfxRecta = rectangle;
													ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
													List<string> list = new List<string>();
													if (list != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1304 @ rax_v40 (System.Collections.Generic.List`1<System.String>)+1C]");
														_ = (nint)0 + (nint)1;
														int stringLength = ((string)(object)list)._stringLength;
														if (((string)(object)list)._stringLength != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1304 @ rax_v40 (System.Collections.Generic.List`1<System.String>)+18]");
															nint num4 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v915 @ rcx_v39 (System.Int32)+18]");
															if (num4 >= 0)
															{
																((List<object>)(object)list).AddWithResize((object)"PfxYellow");
															}
															else
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1304 @ rax_v40 (System.Collections.Generic.List`1<System.String>)+18]");
																object obj3 = (nint)0 + (nint)1;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1304 @ rax_v40 (System.Collections.Generic.List`1<System.String>)+1C]");
															_ = (nint)0 + (nint)1;
															int stringLength2 = ((string)(object)list)._stringLength;
															if (((string)(object)list)._stringLength != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1304 @ rax_v40 (System.Collections.Generic.List`1<System.String>)+18]");
																nint num5 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ rcx_v41 (System.Int32)+18]");
																if (num5 >= 0)
																{
																	((List<object>)(object)list).AddWithResize((object)"PfxYellow");
																}
																else
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1304 @ rax_v40 (System.Collections.Generic.List`1<System.String>)+18]");
																	object obj4 = (nint)0 + (nint)1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1304 @ rax_v40 (System.Collections.Generic.List`1<System.String>)+1C]");
																_ = (nint)0 + (nint)1;
																int stringLength3 = ((string)(object)list)._stringLength;
																if (((string)(object)list)._stringLength != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1304 @ rax_v40 (System.Collections.Generic.List`1<System.String>)+18]");
																	nint num6 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v917 @ rcx_v43 (System.Int32)+18]");
																	if (num6 >= 0)
																	{
																		((List<object>)(object)list).AddWithResize((object)"PfxLine");
																	}
																	else
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1304 @ rax_v40 (System.Collections.Generic.List`1<System.String>)+18]");
																		object obj5 = (nint)0 + (nint)1;
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																	}
																	if (particleSystemConfig != null)
																	{
																		particleSystemConfig._frame = list;
																		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 72));
																		_ = 0;
																		_ = 0;
																		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(1f, 1f));
																		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
																		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
																		_ = 0;
																		_ = 2;
																		_ = 1;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
																		particleSystemConfig._quantity = (int?)(object)0;
																		_ = 0;
																		_ = 0;
																		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(90f, 90f));
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
																		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
																		_ = 0;
																		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
																		_ = 0;
																		_ = 0;
																		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(500f));
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-8]");
																		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+8]");
																		_ = 0;
																		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
																		_ = 0;
																		_ = 0;
																		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+28]");
																		_ = 0;
																		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
																		_ = 0;
																		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
																		_ = 0;
																		_ = 0;
																		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 1f));
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+48]");
																		_ = 0;
																		_ = 1;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-70]");
																		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
																		_ = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
																		_ = 0;
																		particleSystemConfig._emitZone = new EmitZone
																		{
																			_type = EmitZoneType.Random,
																			_source = _pfxRecta
																		};
																		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
																		{
																			Transform parent = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
																			ParticleSystem pfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, parent, "BFC200 emitter");
																			_pfx = pfx;
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
			}
		}
		throw new NullReferenceException();
	}

	private float GetSpecialInterval()
	{
		//IL_008a: Expected O, but got F4
		object obj = UnityEngine.Random.value;
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
		float num3 = default(float);
		float num2 = num3 * num3;
		float num4 = ((Equipment)this)._003COwner_003Ek__BackingField.PCooldownFinal(0.3f);
		float num5 = num3 * _crossBaseDelay;
		float num6 = num2 + 1f;
		float num7 = 1f / num6;
		return num7 * num5;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0010: Invalid comparison between I4 and F4
		//IL_033c: Invalid comparison between F4 and I4
		//IL_00e4: Expected O, but got I4
		//IL_043b: Expected I4, but got I8
		//IL_0455: Invalid comparison between F4 and I4
		//IL_0133: Expected O, but got I4
		//IL_07aa: Expected I, but got O
		//IL_080b: Expected I4, but got O
		//IL_027a: Expected I, but got O
		//IL_059e: Expected I, but got O
		//IL_09e5: Expected O, but got I4
		//IL_0686: Expected I, but got O
		//IL_06f8: Expected O, but got I4
		//IL_01c8->IL0885: Incompatible stack heights: 7 vs 0
		//IL_01f4->IL0885: Incompatible stack heights: 7 vs 0
		//IL_07cd->IL07cd: Incompatible stack heights: 1 vs 0
		//IL_0268->IL0885: Incompatible stack heights: 7 vs 0
		//IL_0246->IL0246: Incompatible stack heights: 8 vs 7
		//IL_056a->IL056a: Incompatible stack heights: 1 vs 0
		//IL_02cc->IL0885: Incompatible stack heights: 7 vs 0
		//IL_0885->IL0719: Incompatible stack heights: 1 vs 0
		//IL_02e6->IL02e6: Incompatible stack heights: 7 vs 0
		//IL_06a9->IL06a9: Incompatible stack heights: 1 vs 0
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float2 value = default(float2);
		if (!((_crossTime = num + _crossTime) < _nextInterval))
		{
			if (0f < _projectileStock)
			{
				goto IL_02e6;
			}
			bool flag = (object)_pfx == null;
			Transform transform = _pfx.transform;
			bool flag2 = (object)transform == null;
			bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
			bool flag4 = (object)_lightSprite == null;
			PhaserSprite phaserSprite = _lightSprite.setVisible(visible: true);
			bool flag5 = (object)_lightSprite == null;
			PhaserSprite phaserSprite2 = _lightSprite.setAlpha(0.15f);
			bool flag6 = (object)_lightSprite == null;
			PhaserSprite phaserSprite3 = _lightSprite.setScale(0f, (float?)(object)0);
			float num2 = base.PArea();
			Camera main = Camera.main;
			bool flag7 = (object)main == null;
			int pixelHeight = main.pixelHeight;
			object obj = pixelHeight + pixelHeight;
			if (_tween1 != null)
			{
				_tween1.Kill();
			}
			if (_tween2 != null)
			{
				_tween2.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)_lightSprite != null)
			{
				Transform transform2 = _lightSprite.transform;
				if (array != null)
				{
					if ((object)transform2 != null)
					{
						void* value2 = ((IntPtr*)(&array))->m_value;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj2 = default(object);
						bool flag8 = obj2 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null)
					{
						((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
						_ = 1;
						_ = 1140457472;
						_ = 1;
						MultiTargetTween tween = Tweens.Add(tweenConfig);
						_tween1 = tween;
						if ((object)_pfx != null)
						{
							_pfx.Play(withChildren: true);
							goto IL_02e6;
						}
					}
				}
			}
			goto IL_0885;
		}
		goto IL_08e5;
		IL_08e5:
		float deltaTime2 = PauseSystem.DeltaTime;
		float num3 = deltaTime2 * 1000f;
		if ((_projectileTime = num3 + _projectileTime) < _projectileInterval || !(_projectileStock > 0f))
		{
			return;
		}
		float projectileStock = _projectileStock - 1f;
		_projectileStock = projectileStock;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ebp,xmm0\"");
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float2 position3 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					if (_crossPool != null)
					{
						float2 pos = default(float2);
						Projectile projectile = _crossPool.SpawnAt(pos, this, -1986357120);
						_projectileTime = 0f;
						if (!(_projectileStock > 0f))
						{
							if ((object)_pfx != null)
							{
								_pfx.Stop();
								float num4 = _nextInterval - _crossTime;
								if (!(2000f > num4))
								{
									num4 = 2000f;
								}
								if (_tween2 != null)
								{
									_tween2.Kill();
								}
								TweenConfig tweenConfig2 = new TweenConfig();
								object[] array2 = new object[1];
								if (array2 != null)
								{
									if ((object)_lightSprite != null)
									{
										void* value3 = ((IntPtr*)(&array2))->m_value;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
										object obj3 = default(object);
										bool flag9 = obj3 == null;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig2 != null)
									{
										((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
										_ = 1;
										MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
										_tween2 = tween2;
										if (_tween1 != null)
										{
											_tween1.Kill();
										}
										TweenConfig tweenConfig3 = new TweenConfig();
										object[] array3 = new object[1];
										if ((object)_lightSprite != null)
										{
											Transform transform3 = _lightSprite.transform;
											if (array3 != null)
											{
												if ((object)transform3 != null)
												{
													nint num5 = (nint)array3;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													object obj4 = default(object);
													bool flag10 = obj4 == null;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												if (tweenConfig3 != null)
												{
													tweenConfig3.targets = array3;
													tweenConfig3.duration = num4;
													tweenConfig3.scaleX = (float?)(object)1;
													MultiTargetTween tween3 = Tweens.Add(tweenConfig3);
													_tween1 = tween3;
													return;
												}
											}
										}
									}
								}
							}
						}
						else
						{
							if (_tween2 != null)
							{
								_tween2.Kill();
							}
							TweenConfig tweenConfig4 = new TweenConfig();
							object[] array4 = new object[1];
							if (array4 != null)
							{
								if ((object)_lightSprite != null)
								{
									nint num6 = (nint)array4;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj5 = default(object);
									bool flag11 = obj5 == null;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig4 != null)
								{
									tweenConfig4.targets = array4;
									int num7 = (int)_lightSprite;
									if ((object)_lightSprite != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rbp_v15 (System.Int32)+28]");
										int num8 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rbp_v15 (System.Int32)+28]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v625 @ rbp_v16 (System.Int32)+10]");
											bool flag12 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v625 @ rbp_v16 (System.Int32)+10]");
											SpriteRenderer.get_color_Injected((IntPtr)0, out *(Color*)(&value));
											tweenConfig4.alpha = (float?)(object)1;
											tweenConfig4.duration = _projectileInterval;
											MultiTargetTween tween4 = Tweens.Add(tweenConfig4);
											_tween2 = tween4;
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
		goto IL_0885;
		IL_02e6:
		float num9 = (_nextInterval = GetSpecialInterval());
		_crossTime = 0f;
		float num10 = base.PAmount();
		float projectileStock2 = num9 + _projectileStock;
		_projectileStock = projectileStock2;
		goto IL_08e5;
		IL_0885:
		throw new NullReferenceException();
	}

	public void FireOneEvoProjectile(Vector2 pos, int index, float duration = 30000f)
	{
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 pos2 = default(float2);
		Projectile projectile = _crossPool.SpawnAt(pos2, this, index);
	}

	public unsafe override float SecondaryPPower()
	{
		//IL_004f: Expected O, but got I
		//IL_0313: Invalid comparison between F4 and I
		//IL_006f->IL01ea: Incompatible stack heights: 1 vs 0
		//IL_00cf->IL01ea: Incompatible stack heights: 1 vs 0
		//IL_0107->IL01ea: Incompatible stack heights: 1 vs 0
		//IL_0136->IL01ea: Incompatible stack heights: 1 vs 0
		//IL_02a9->IL01ea: Incompatible stack heights: 2 vs 0
		//IL_0171->IL01ea: Incompatible stack heights: 2 vs 0
		//IL_019f->IL01ea: Incompatible stack heights: 2 vs 0
		List<float> critChancesArray = _critChancesArray;
		if (_critChancesArray != null)
		{
			int critIndex = _critIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			int num = (int)((nint)critIndex % (nint)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
			bool flag = (nint)num >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v12+18]");
				if ((nint)num >= (nint)0)
				{
					throw new IndexOutOfRangeException();
				}
				int critIndex2 = _critIndex + 1;
				_critIndex = critIndex2;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float num2 = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
					PhaserSprite lightSprite = _lightSprite;
					if ((object)_lightSprite != null)
					{
						object spriteRenderer = lightSprite._spriteRenderer;
						if ((object)lightSprite._spriteRenderer != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdi_v7 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdi_v7 (System.Object)+10]");
							float ret;
							SpriteRenderer.get_color_Injected((IntPtr)0, out *(Color*)(&ret));
							float num3 = default(float);
							bool flag3 = !(1f < num3);
							float num4 = 1f;
							if (!flag3)
							{
								num4 = num3;
							}
							float num5 = num4 + 1f;
							float num7 = default(float);
							float num6 = num7 * _critChance;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v12+20+v61 @ rdx_v9 (System.Int32)*4]");
							if (num6 > 0f)
							{
								float num8 = num5 * 3f;
								float num9 = num8 * num7;
								num5 = num9 * ArcanaManager.CritMul;
							}
							WeaponData currentWeaponData = _currentWeaponData;
							if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
							{
								float num10 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
								if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
								{
									float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
									float num11 = currentWeaponData._003Cpower_003Ek__BackingField * num5;
									float num12 = num11 * num10;
									return num10 + num12;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void LateUpdate()
	{
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		PhaserSprite phaserSprite = _lightSprite.setPosition(position);
	}
}
