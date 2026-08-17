using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class MisspellProjectile : Projectile
{
	private SpriteRenderer _GroundFx;

	private ParticleEmitterManager _particleEmitterManager;

	private MultiTargetTween _scaleTween;

	private const float Radius = 16f;

	public bool isPlayerFacing = true;

	protected override void Awake()
	{
		base.Awake();
		AssignRandomColorToGroundFx();
		GenerateParticleSystems();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00f2: Expected O, but got I4
		//IL_00f2: Expected O, but got I4
		//IL_0755: Unknown result type (might be due to invalid IL or missing references)
		//IL_075a: Expected O, but got Unknown
		//IL_07e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e7: Expected O, but got Unknown
		//IL_02a9: Expected I, but got O
		//IL_02d1: Expected O, but got I4
		//IL_02da: Expected O, but got I4
		//IL_0309: Expected O, but got I
		//IL_0339: Expected O, but got I
		//IL_0265: Expected F4, but got I
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_0296: Expected O, but got I4
		//IL_01e7: Expected F4, but got I
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_0218: Expected O, but got I4
		//IL_03d7: Expected O, but got I
		//IL_0855: Expected I, but got O
		//IL_0914: Unknown result type (might be due to invalid IL or missing references)
		//IL_0919: Expected O, but got Unknown
		//IL_095c: Expected I, but got O
		//IL_09ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b3: Expected O, but got Unknown
		//IL_05fb: Expected I, but got O
		//IL_06b7: Expected O, but got F4
		//IL_0842->IL06ff: Incompatible stack heights: 4 vs 0
		//IL_0250->IL06ff: Incompatible stack heights: 4 vs 0
		//IL_01d2->IL06ff: Incompatible stack heights: 4 vs 0
		//IL_0353->IL06ff: Incompatible stack heights: 4 vs 0
		//IL_0382->IL06ff: Incompatible stack heights: 4 vs 0
		//IL_045c->IL06ff: Incompatible stack heights: 4 vs 0
		//IL_048b->IL06ff: Incompatible stack heights: 4 vs 0
		//IL_051a->IL06ff: Incompatible stack heights: 8 vs 0
		//IL_05e9->IL06ff: Incompatible stack heights: 8 vs 0
		//IL_056e->IL056e: Incompatible stack heights: 9 vs 8
		//IL_05c7->IL05c7: Incompatible stack heights: 9 vs 8
		//IL_0639->IL06ff: Incompatible stack heights: 8 vs 0
		//IL_0696->IL06ff: Incompatible stack heights: 8 vs 0
		base.InitProjectile(pool, weapon, index);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundFx, 0.2f);
		if ((object)_GroundFx != null)
		{
			_GroundFx.enabled = true;
			Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
			if ((object)_GroundFx != null)
			{
				((Renderer)_GroundFx).SetMaterial(material);
				if ((object)_renderer != null)
				{
					_renderer.enabled = false;
					if (body != null)
					{
						BaseBody baseBody = body.setCircle(1f, (float?)(object)0, (float?)(object)0);
						ArcadeSprite arcadeSprite = setTintFill(isEnabled: true, 16711680u);
						SpriteRenderer cachedTransform = (SpriteRenderer)(object)_cachedTransform;
						if ((object)_cachedTransform != null)
						{
							_ = 0;
							_ = 0;
							bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
							object obj2 = default(object);
							object obj = obj2 - 64;
							Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)obj);
							SpriteRenderer cachedTransform2 = (SpriteRenderer)(object)_cachedTransform;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-3C]");
							float num = 0f + 0.24f;
							bool flag2 = (object)_cachedTransform == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-30]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-38]");
							_ = 0;
							bool flag3 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
							object obj3 = obj2 - 48;
							Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref *(Vector3*)obj3);
							Weapon weapon2 = _weapon;
							bool flag4 = (object)_weapon == null;
							if (!weapon2.IsHoming)
							{
								if (!isPlayerFacing)
								{
									VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
									if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null)
									{
										goto IL_06ff;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v134 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
									float num2 = 0f;
									Vector3 playerDirection = (Vector3)(obj2 - 48);
									_ = 0;
									ApplyInversePlayerFacingVelocity(playerDirection);
									object obj4 = 0;
									bool flag5 = true;
								}
								else
								{
									VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
									if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null)
									{
										goto IL_06ff;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v102 (VampireSurvivors.Objects.Characters.CharacterController)+184]");
									float num2 = 0f;
									Vector3 playerDirection = (Vector3)(obj2 - 48);
									_ = 0;
									ApplyPlayerFacingVelocity(playerDirection);
									object obj4 = 0;
									bool flag5 = true;
								}
							}
							else
							{
								nint num3 = (nint)this;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1105 @ rax_v131 (Il2CppClass<VampireSurvivors.Objects.Projectiles.MisspellProjectile>)+3B0]");
								bool flag5 = false;
								Transform transform = base.AimForNearestEnemy();
								object obj4 = 0;
								Vector3 playerDirection = (Vector3)1;
								float num2 = 1f;
							}
							SpriteRenderer spriteRenderer2 = (SpriteRenderer)(object)body;
							if (body != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
								int indexInWeapon = _indexInWeapon;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rsi_v20 (UnityEngine.SpriteRenderer)+70]");
								float2 velocity = (float2)((nint)indexInWeapon + (nint)0);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
								ArcadeSprite sprite = _sprite;
								int indexInWeapon2 = _indexInWeapon;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ rsi_v20 (UnityEngine.SpriteRenderer)+74]");
								object obj5 = (nint)indexInWeapon2 + (nint)0;
								if ((object)_sprite != null)
								{
									BaseBody baseBody2 = sprite.body;
									if (sprite.body != null)
									{
										baseBody2._velocity = velocity;
										SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
										_ = 0;
										_ = 1065353216;
										_ = 1;
										soundConfig.Rate = 1f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+20]");
										soundConfig.Volume = (float?)(object)0;
										soundConfig.Rate = 2f;
										float detune = (float)_indexInWeapon * -100f;
										soundConfig.Detune = detune;
										float time = default(float);
										PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Fireloop, soundConfig, 200f, 1, time);
										SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(_GroundFx, 1f);
										if ((object)_GroundFx != null)
										{
											_GroundFx.enabled = true;
											if ((object)_GroundFx != null)
											{
												Transform transform2 = _GroundFx.transform;
												nint num4 = (nint)typeof(Vector3);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1312 @ rcx_v57 (Il2CppClass<UnityEngine.Vector3>)+B8]");
												nint num5 = 0;
												object obj6 = default(object);
												float num6 = (float)obj6 * 2f;
												float num7 = (float)Vector3.oneVector * 2f;
												_ = Vector3.oneVector;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ rdx_v38 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
												float num8 = 0f * 2f;
												float num9 = num7 * 0.01f;
												float num10 = num6 * 0.01f;
												float num11 = num8 * 0.01f;
												bool flag6 = (object)transform2 == null;
												bool flag7 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
												object obj7 = obj2 - 48;
												Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj7);
												SpriteRenderer spriteRenderer4 = RenderingExtensions.SetAlpha(_renderer, 1f);
												SpriteRenderer cachedTransform3 = (SpriteRenderer)(object)_cachedTransform;
												nint num12 = (nint)typeof(Vector3);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1440 @ rax_v78 (Il2CppClass<UnityEngine.Vector3>)+B8]");
												nint num13 = 0;
												bool flag8 = (object)_cachedTransform == null;
												_ = Vector3.zeroVector;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1220 @ rax_v79 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
												_ = 0;
												bool flag9 = ((UnityEngine.Object)cachedTransform3).m_CachedPtr == (IntPtr)0;
												object obj8 = obj2 - 64;
												Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform3).m_CachedPtr, ref *(Vector3*)obj8);
												if (_scaleTween != null)
												{
													_scaleTween.Kill();
												}
												TweenConfig tweenConfig = new TweenConfig();
												object[] array = new object[2];
												if (array != null)
												{
													if ((object)_cachedTransform != null)
													{
														void* value = ((IntPtr*)(&array))->m_value;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj9 = default(object);
														bool flag10 = obj9 == null;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if ((object)_GroundFx != null)
													{
														void* value2 = ((IntPtr*)(&array))->m_value;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj10 = default(object);
														bool flag11 = obj10 == null;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if (tweenConfig != null)
													{
														((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
														_ = 0;
														_ = 0;
														_ = 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+20]");
														_ = 0;
														if ((object)_weapon != null)
														{
															_ = 0;
															float num14 = _weapon.PArea();
															float num15 = (float)Vector3.zeroVector * 16f;
															_ = 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+20]");
															_ = 0;
															if ((object)_weapon != null)
															{
																float num16 = _weapon.PDuration();
																((SpriteRenderer)(object)tweenConfig).m_SpriteChangeEvent = (UnityEvent<SpriteRenderer>)num15;
																_ = 1;
																TweenCallback tweenCallback = delegate
																{
																	base.Despawn();
																};
																MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
																_scaleTween = scaleTween;
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
		goto IL_06ff;
		IL_06ff:
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		//IL_0068->IL009b: Incompatible stack heights: 1 vs 0
		ParticleEmitterManager particleEmitterManager = _particleEmitterManager;
		if ((object)_particleEmitterManager != null && ((UnityEngine.Object)particleEmitterManager).m_CachedPtr != (IntPtr)0)
		{
			object cachedTransform = _cachedTransform;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v4 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rbx_v4 (System.Object)+10]");
			Transform.get_position_Injected((IntPtr)0, out Vector3 _);
			Vector2 pos = default(Vector2);
			_particleEmitterManager.EmitParticleAt(pos);
		}
	}

	private unsafe void AssignRandomColorToGroundFx()
	{
		//IL_00a2: Expected I4, but got O
		//IL_00a6: Expected O, but got I4
		//IL_00e1->IL00ab: Incompatible stack heights: 1 vs 0
		string[] array = new string[3];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		object obj = UnityEngine.Random.RandomRangeInt(0, (int)((SpriteRenderer)(object)array).m_SpriteChangeEvent);
		if (ColorUtility.DoTryParseHtmlColor(array[obj], out Color32 _))
		{
			SpriteRenderer groundFx = _GroundFx;
			bool flag = ((UnityEngine.Object)groundFx).m_CachedPtr == (IntPtr)0;
			float value = default(float);
			SpriteRenderer.set_color_Injected(((UnityEngine.Object)groundFx).m_CachedPtr, ref *(Color*)(&value));
		}
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_01f7: Expected O, but got Ref
		//IL_0211: Expected native int or pointer, but got O
		//IL_06df: Expected O, but got I4
		//IL_0242: Expected O, but got I
		//IL_025e: Expected O, but got I4
		//IL_0277: Expected O, but got Ref
		//IL_0291: Expected native int or pointer, but got O
		//IL_06fc: Expected O, but got I4
		//IL_02c3: Expected O, but got Ref
		//IL_02dd: Expected native int or pointer, but got O
		//IL_0736: Expected O, but got I
		//IL_04a9: Expected O, but got Ref
		//IL_04c3: Expected native int or pointer, but got O
		//IL_0770: Expected O, but got I
		//IL_04fb: Expected O, but got Ref
		//IL_0515: Expected native int or pointer, but got O
		//IL_052f: Expected O, but got I
		//IL_054f: Expected O, but got Ref
		//IL_0569: Expected native int or pointer, but got O
		//IL_0583: Expected O, but got I
		//IL_05bc: Expected O, but got I
		//IL_05e6: Expected O, but got I4
		//IL_05ff: Expected O, but got Ref
		//IL_0619: Expected native int or pointer, but got O
		//IL_07aa: Expected O, but got I
		//IL_0651: Expected O, but got Ref
		//IL_066b: Expected native int or pointer, but got O
		//IL_07dc: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particleEmitterManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 368))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+170]");
			particleEmitterManager = (ParticleEmitterManager)0;
		}
		else
		{
			particleEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particleEmitterManager = particleEmitterManager;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxRed");
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
			((List<object>)(object)list).AddWithResize((object)"PfxYellow");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+170]");
		particleSystemConfig._quantity = (int?)(object)0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(100f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
		_ = 0;
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+90]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
		_ = 0;
		particleSystemConfig._on = false;
		ParticleSystem particleSystem = _particleEmitterManager.CreateEmitter(particleSystemConfig, null, "PfxEmitter1");
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
		List<string> list2 = new List<string>();
		int version3 = list2._version + 1;
		list2._version = version3;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"Flame2");
		}
		else
		{
			int num3 = list2._size + 1;
			list2._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list2._version + 1;
		list2._version = version4;
		string[] items4 = list2._items;
		if (list2._size >= items4.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"PfxYellow");
		}
		else
		{
			int num4 = list2._size + 1;
			list2._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D0]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 180f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E0]");
		particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F0]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+170]");
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+100]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+110]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-10]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0f, 2f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+120]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+130]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+18]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
		_ = 0;
		particleSystemConfig2._on = false;
		ParticleSystem particleSystem2 = _particleEmitterManager.CreateEmitter(particleSystemConfig2, null, "PfxEmitter2");
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
	}

	private void _003CInitProjectile_003Eb__6_0()
	{
		base.Despawn();
	}
}
