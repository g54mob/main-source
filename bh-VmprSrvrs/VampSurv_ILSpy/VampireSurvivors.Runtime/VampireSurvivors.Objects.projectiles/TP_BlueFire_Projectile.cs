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
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_BlueFire_Projectile : Projectile
{
	private SpriteRenderer _GroundFx;

	private ParticleEmitterManager _particleEmitterManager;

	private Sequence _scaleTween;

	private const float Radius = 8f;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("UnityCircle");
		_GroundFx.sprite = sprite;
		AssignRandomColorToGroundFx();
		GenerateParticleSystems();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_004f: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		//IL_005d: Expected I4, but got O
		//IL_0798: Unknown result type (might be due to invalid IL or missing references)
		//IL_079d: Expected O, but got Unknown
		//IL_0a27: Expected O, but got F4
		//IL_0106: Expected I4, but got O
		//IL_07ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f3: Expected O, but got Unknown
		//IL_080d: Expected I, but got O
		//IL_01bb: Expected O, but got I4
		//IL_01c5: Expected I4, but got O
		//IL_0205: Expected O, but got I
		//IL_0235: Expected O, but got I
		//IL_02e1: Expected O, but got I
		//IL_0368: Expected O, but got I
		//IL_084a: Expected I, but got O
		//IL_08bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c2: Expected O, but got Unknown
		//IL_08f5: Expected I4, but got O
		//IL_0908: Expected I, but got O
		//IL_095d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0962: Expected O, but got Unknown
		//IL_09d0: Expected I, but got O
		//IL_050d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0512: Expected O, but got Unknown
		//IL_0680: Expected I, but got O
		//IL_0a3f->IL072a: Incompatible stack heights: 1 vs 0
		//IL_00b0->IL072a: Incompatible stack heights: 1 vs 0
		//IL_00df->IL072a: Incompatible stack heights: 1 vs 0
		//IL_01df->IL072a: Incompatible stack heights: 5 vs 0
		//IL_024f->IL072a: Incompatible stack heights: 5 vs 0
		//IL_027e->IL072a: Incompatible stack heights: 5 vs 0
		//IL_03e8->IL072a: Incompatible stack heights: 5 vs 0
		//IL_0417->IL072a: Incompatible stack heights: 5 vs 0
		//IL_09ae->IL072a: Incompatible stack heights: 9 vs 0
		//IL_09fa->IL072a: Incompatible stack heights: 9 vs 0
		//IL_0a19->IL072a: Incompatible stack heights: 9 vs 0
		base.InitProjectile(pool, weapon, index);
		if ((object)_renderer != null)
		{
			_renderer.enabled = false;
			if (body != null)
			{
				BaseBody baseBody = body.setCircle(1f, (float?)(object)0, (float?)(object)0);
				int num = (int)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rdi_v15 (System.Int32)+10]");
					bool flag = (nint)0 == 0;
					object obj2 = default(object);
					object obj = obj2 - 64;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rdi_v15 (System.Int32)+10]");
					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
					_ = 0;
					object obj3 = UnityEngine.Random.value;
					if ((object)weapon != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
						{
							BaseBody baseBody2 = characterController.body;
							if (characterController.body != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
								float num2 = 0f - 0.5f;
								int num3 = (int)_cachedTransform;
								float num4 = num2 * (float)baseBody2._size;
								float num5 = num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
								float num6 = num5 + 0f;
								bool flag2 = (object)_cachedTransform == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-30]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-38]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rdi_v16 (System.Int32)+10]");
								bool flag3 = (nint)0 == 0;
								object obj4 = obj2 - 48;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v703 @ rdi_v16 (System.Int32)+10]");
								Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj4);
								nint num7 = (nint)this;
								float projectileSpeed = base.ProjectileSpeed;
								ArcadeSprite sprite = _sprite;
								bool flag4 = (object)_sprite == null;
								BaseBody baseBody3 = sprite.body;
								bool flag5 = sprite.body == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-30]");
								_ = 0;
								baseBody3._velocity = (float2)0;
								int num8 = (int)body;
								if (body != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
									int indexInWeapon = _indexInWeapon;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdi_v17 (System.Int32)+70]");
									float2 velocity = (float2)((nint)indexInWeapon + (nint)0);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
									ArcadeSprite sprite2 = _sprite;
									int indexInWeapon2 = _indexInWeapon;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdi_v17 (System.Int32)+74]");
									object obj5 = (nint)indexInWeapon2 + (nint)0;
									if ((object)_sprite != null)
									{
										BaseBody baseBody4 = sprite2.body;
										if (sprite2.body != null)
										{
											baseBody4._velocity = velocity;
											SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
											_ = 0;
											_ = 1048576000;
											soundConfig.Rate = 1f;
											soundConfig.Rate = 2f;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+30]");
											soundConfig.Volume = (float?)(object)0;
											float detune = (float)_indexInWeapon * -100f;
											soundConfig.Detune = detune;
											float time = default(float);
											PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Flame, soundConfig, 200f, 1, time);
											SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
											_ = 0;
											_ = 1056964608;
											soundConfig2.Rate = 1f;
											_ = 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp+30]");
											soundConfig2.Volume = (float?)(object)0;
											float detune2 = (float)_indexInWeapon * -100f;
											soundConfig2.Rate = 2f;
											soundConfig2.Detune = detune2;
											PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_Fireball, soundConfig2, 500f, 1, time);
											SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_GroundFx, 1f);
											if ((object)_GroundFx != null)
											{
												_GroundFx.enabled = true;
												if ((object)_GroundFx != null)
												{
													Transform transform = _GroundFx.transform;
													nint num9 = (nint)typeof(Vector3);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1204 @ rcx_v53 (Il2CppClass<UnityEngine.Vector3>)+B8]");
													nint num10 = 0;
													_ = Vector3.oneVector;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v829 @ rdx_v34 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
													float num11 = 0f * 2f;
													bool flag6 = (object)transform == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1238 @ rax_v66 (UnityEngine.Transform)+10]");
													bool flag7 = (nint)0 == 0;
													object obj6 = obj2 - 48;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1238 @ rax_v66 (UnityEngine.Transform)+10]");
													Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj6);
													SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_renderer, 1f);
													int num12 = (int)_cachedTransform;
													nint num13 = (nint)typeof(Vector3);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1317 @ rax_v74 (Il2CppClass<UnityEngine.Vector3>)+B8]");
													nint num14 = 0;
													bool flag8 = (object)_cachedTransform == null;
													_ = Vector3.zeroVector;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rax_v75 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rdi_v21 (System.Int32)+10]");
													bool flag9 = (nint)0 == 0;
													object obj7 = obj2 - 64;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v982 @ rdi_v21 (System.Int32)+10]");
													Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj7);
													if (_scaleTween != null)
													{
														TweenExtensions.Kill(_scaleTween);
													}
													Sequence sequence = DOTween.Sequence();
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
													if ((nint)0 == 0)
													{
														_ = 1;
													}
													if (sequence != null)
													{
														_scaleTween = sequence;
														nint num15 = (nint)typeof(Vector3);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v89 (Il2CppClass<UnityEngine.Vector3>)+B8]");
														nint num16 = 0;
														if ((object)_weapon != null)
														{
															float num17 = _weapon.PArea();
															_ = Vector3.oneVector;
															float num18 = (float)Vector3.zeroVector * 8f;
															float num19 = num18;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rdi_v23 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
															float num20 = num19 * 0f;
															Vector3 endValue = (Vector3)(obj2 - 48);
															TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(_cachedTransform, endValue, 0.2f);
															if (TweenSettingsExtensions.ValidateAddToSequence(_scaleTween, (Tween)t, false))
															{
																Sequence sequence2 = Sequence.DoInsert(_scaleTween, (Tween)t, 0f);
															}
															TweenerCore<Color, Color, ColorOptions> t2 = DOTweenModuleSprite.DOFade(_GroundFx, 0f, 0.2f);
															if (TweenSettingsExtensions.ValidateAddToSequence(_scaleTween, (Tween)t2, false))
															{
																Sequence sequence3 = Sequence.DoInsert(_scaleTween, (Tween)t2, 0f);
															}
															Sequence scaleTween = _scaleTween;
															if (_scaleTween != null && ((Tween)scaleTween)._003Cactive_003Ek__BackingField)
															{
																((Tween)scaleTween).easeType = Ease.Linear;
																((Tween)scaleTween).customEase = null;
															}
															Sequence scaleTween2 = _scaleTween;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1690 @ r8_v27 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_BlueFire_Projectile>)+370]");
															TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
															nint num21 = (nint)this;
															if (_scaleTween != null && ((Tween)scaleTween2)._003Cactive_003Ek__BackingField)
															{
																scaleTween2.onComplete = onComplete;
															}
															Sequence scaleTween3 = _scaleTween;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
															if ((nint)0 == 0)
															{
																_ = 1;
															}
															if (_scaleTween != null)
															{
																scaleTween3.stringId = "DefaultGameTweenId";
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
		//IL_06d1: Expected O, but got I4
		//IL_0242: Expected O, but got I
		//IL_025e: Expected O, but got I4
		//IL_0277: Expected O, but got Ref
		//IL_0291: Expected native int or pointer, but got O
		//IL_06ee: Expected O, but got I4
		//IL_02c3: Expected O, but got Ref
		//IL_02dd: Expected native int or pointer, but got O
		//IL_0728: Expected O, but got I
		//IL_04a9: Expected O, but got Ref
		//IL_04c3: Expected native int or pointer, but got O
		//IL_0762: Expected O, but got I
		//IL_04fb: Expected O, but got Ref
		//IL_0515: Expected native int or pointer, but got O
		//IL_052f: Expected O, but got I
		//IL_054f: Expected O, but got Ref
		//IL_0569: Expected native int or pointer, but got O
		//IL_0583: Expected O, but got I
		//IL_05bc: Expected O, but got I
		//IL_05d8: Expected O, but got I4
		//IL_05f1: Expected O, but got Ref
		//IL_060b: Expected native int or pointer, but got O
		//IL_079c: Expected O, but got I
		//IL_0643: Expected O, but got Ref
		//IL_065d: Expected native int or pointer, but got O
		//IL_07ce: Expected O, but got I
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
			((List<object>)(object)list).AddWithResize((object)"PfxGreen");
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
			((List<object>)(object)list).AddWithResize((object)"PfxBlue");
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
			((List<object>)(object)list2).AddWithResize((object)"ProjectileFlameHoly");
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
			((List<object>)(object)list2).AddWithResize((object)"PfxHoly1");
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
}
