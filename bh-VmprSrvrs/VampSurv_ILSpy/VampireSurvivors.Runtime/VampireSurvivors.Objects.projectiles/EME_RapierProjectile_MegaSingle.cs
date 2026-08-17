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
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_RapierProjectile_MegaSingle : Projectile
{
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public EME_RapierProjectile_MegaSingle _003C_003E4__this;

		public float __area;

		internal void _003CInitProjectile_003Eb__0()
		{
			//IL_001a: Expected O, but got I4
			ArcadeSprite arcadeSprite = _003C_003E4__this.setScale(0f, (float?)(object)1);
		}

		internal void _003CInitProjectile_003Eb__1()
		{
			EME_RapierProjectile_MegaSingle eME_RapierProjectile_MegaSingle = _003C_003E4__this;
			SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(eME_RapierProjectile_MegaSingle._backgroundSprite, 0.35f);
			ArcadeSprite arcadeSprite = _003C_003E4__this.setAlpha(1f);
		}
	}

	private SpriteRenderer _backgroundSprite;

	private const float RADIUS = 8f;

	private const float INDEX_OFFSET_SCALE_FACTOR = 0.1f;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	private MultiTargetTween _tween;

	private MultiTargetTween _tween2;

	private readonly List<uint> _tints;

	private readonly List<string> _frameNames;

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_006e: Expected O, but got I4
		//IL_0103: Expected O, but got I
		//IL_0103: Expected O, but got I
		//IL_01d8: Expected O, but got I
		//IL_01d8: Expected O, but got I
		//IL_0270: Expected I4, but got O
		//IL_0ad1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad6: Expected O, but got Unknown
		//IL_0b26: Expected O, but got F4
		//IL_0c87: Expected O, but got F4
		//IL_0c92: Expected I4, but got O
		//IL_0b55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5a: Expected O, but got Unknown
		//IL_038b: Expected O, but got I
		//IL_038b: Expected O, but got I
		//IL_0d17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1c: Expected O, but got Unknown
		//IL_0d2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d33: Expected O, but got Unknown
		//IL_0bb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbb: Expected O, but got Unknown
		//IL_0487: Expected F4, but got I
		//IL_053b: Expected O, but got I
		//IL_07e3: Expected O, but got I
		//IL_081c: Expected O, but got I
		//IL_09e4: Expected I, but got O
		//IL_0cf1->IL0a16: Incompatible stack heights: 5 vs 0
		//IL_0327->IL0a16: Incompatible stack heights: 5 vs 0
		//IL_0353->IL0a16: Incompatible stack heights: 5 vs 0
		//IL_0d4d->IL0a16: Incompatible stack heights: 5 vs 0
		//IL_03dc->IL0a16: Incompatible stack heights: 5 vs 0
		//IL_0417->IL0a16: Incompatible stack heights: 5 vs 0
		//IL_0bed->IL0cb0: Incompatible stack heights: 6 vs 5
		//IL_0446->IL0a16: Incompatible stack heights: 5 vs 0
		//IL_04ec->IL0a16: Incompatible stack heights: 5 vs 0
		//IL_055b->IL0a16: Incompatible stack heights: 6 vs 0
		//IL_05a7->IL0a16: Incompatible stack heights: 7 vs 0
		//IL_060a->IL0a16: Incompatible stack heights: 8 vs 0
		//IL_0688->IL0a16: Incompatible stack heights: 9 vs 0
		//IL_071d->IL0a16: Incompatible stack heights: 9 vs 0
		//IL_0791->IL0a16: Incompatible stack heights: 9 vs 0
		//IL_076f->IL076f: Incompatible stack heights: 10 vs 9
		//IL_08cc->IL0a16: Incompatible stack heights: 9 vs 0
		//IL_0972->IL0a16: Incompatible stack heights: 10 vs 0
		//IL_0950->IL0950: Incompatible stack heights: 11 vs 10
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass9_0();
		bool flag4;
		if (CS_0024_003C_003E8__locals8 != null)
		{
			CS_0024_003C_003E8__locals8._003C_003E4__this = this;
			base.InitProjectile(pool, weapon, index);
			_speed = 10f;
			if ((object)_weapon != null)
			{
				float num = _weapon.PArea();
				float xScale = default(float);
				ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
				CheckRenderer();
				SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
				if (SpriteTextures.Base != null && spriteTexturesBase.Vfx != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F5E3]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-20]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-18]");
					Sprite sprite = SpriteManager.GetSprite((string)num2, (string)0);
					if ((object)((ArcadeSprite)this)._spriteRenderer != null)
					{
						((ArcadeSprite)this)._spriteRenderer.sprite = sprite;
						SpriteTextures.SpriteTexturesBase spriteTexturesBase2 = SpriteTextures.Base;
						if (SpriteTextures.Base != null && spriteTexturesBase2.Vfx != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F5DF]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-20]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-18]");
							Sprite sprite2 = SpriteManager.GetSprite((string)num3, (string)0);
							if ((object)_backgroundSprite != null)
							{
								_backgroundSprite.sprite = sprite2;
								CheckRenderer();
								Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
								if ((object)((ArcadeSprite)this)._spriteRenderer != null)
								{
									((Renderer)((ArcadeSprite)this)._spriteRenderer).SetMaterial(material);
									GenerateParticleSystem();
									int num4 = (int)_cachedTransform;
									if ((object)_cachedTransform != null)
									{
										_ = 0;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rdi_v20 (System.Int32)+10]");
										bool flag = (nint)0 == 0;
										object obj2 = default(object);
										object obj = obj2 - 48;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rdi_v20 (System.Int32)+10]");
										Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj);
										Weapon weapon2 = _weapon;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-30]");
										_ = 0;
										bool flag2 = (object)_weapon == null;
										bool flag3 = (object)((Equipment)weapon2)._003COwner_003Ek__BackingField == null;
										flag4 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.flipX;
										ArcadeSprite arcadeSprite2 = setFlipX(flag4);
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul edi\"");
										object obj3 = UnityEngine.Random.value;
										object obj4 = UnityEngine.Random.value;
										int num5 = (int)_cachedTransform;
										bool flag5 = (object)_cachedTransform == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-28]");
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdi_v23 (System.Int32)+10]");
										bool flag6 = (nint)0 == 0;
										object obj5 = obj2 - 64;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ rdi_v23 (System.Int32)+10]");
										Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj5);
										float num6 = -8f;
										if (flag4)
										{
											goto IL_0cb0;
										}
										if ((object)_renderer != null)
										{
											Sprite sprite3 = _renderer.sprite;
											if ((object)sprite3 != null)
											{
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v203 (UnityEngine.Sprite)+10]");
												bool flag7 = (nint)0 == 0;
												object obj6 = obj2 - 32;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v203 (UnityEngine.Sprite)+10]");
												Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj6);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-18]");
												num6 = 0f - 8f;
												goto IL_0cb0;
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
		goto IL_0a16;
		IL_0a16:
		throw new NullReferenceException();
		IL_0cb0:
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 3238002688L;
		_ = 1;
		if (body != null)
		{
			BaseBody baseBody = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-30]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-40]");
			BaseBody baseBody2 = baseBody.setCircle(8f, (float?)(object)num7, (float?)(object)0);
			if (flag4)
			{
			}
			ArcadeSprite sprite4 = _sprite;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-30]");
			float2 velocity = (float2)(0 * _speed);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-2C]");
			object obj7 = 0 * _speed;
			if ((object)_sprite != null)
			{
				BaseBody baseBody3 = sprite4.body;
				if (sprite4.body != null)
				{
					baseBody3._velocity = velocity;
					Weapon weapon3 = _weapon;
					if ((object)_weapon != null)
					{
						WeaponData currentWeaponData = weapon3._currentWeaponData;
						if (weapon3._currentWeaponData != null)
						{
							_ = currentWeaponData._003Cvolume_003Ek__BackingField;
							if ((object)currentWeaponData._003Cvolume_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-2C]");
								float num8 = 0f;
							}
							else
							{
								float num8 = 0.15f;
							}
							SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
							{
								Rate = 1f
							};
							float num9 = (float)_indexInWeapon * 50f;
							if (!(1000f > num9))
							{
								num9 = 1000f;
							}
							_ = 0;
							soundConfig.Detune = num9;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-30]");
							_ = 0;
							float time = default(float);
							PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.MagicMissile, soundConfig, 500f, 10, time);
							List<uint> tints = _tints;
							if (_tints != null)
							{
								int indexInWeapon = _indexInWeapon;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r8_v30 (System.Collections.Generic.List`1<System.UInt32>)+18]");
								int num10 = (int)((nint)indexInWeapon % (nint)0);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r8_v30 (System.Collections.Generic.List`1<System.UInt32>)+18]");
								bool flag8 = (nint)num10 >= (nint)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r8_v30 (System.Collections.Generic.List`1<System.UInt32>)+10]");
								object obj8 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ r8_v30 (System.Collections.Generic.List`1<System.UInt32>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rcx_v81+18]");
									bool flag9 = (nint)num10 >= (nint)0;
									List<string> frameNames = _frameNames;
									if (_frameNames != null)
									{
										int num11 = _indexInWeapon % frameNames._size;
										bool flag10 = num11 >= frameNames._size;
										string[] items = frameNames._items;
										if (frameNames._items != null)
										{
											bool flag11 = num11 >= items.Length;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
											Sprite sprite5 = default(Sprite);
											ArcadeSprite arcadeSprite3 = setFrame(sprite5);
											ParticleSystem pfx = _pfx;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rcx_v81+20+v154 @ rdx_v56 (System.Int32)*4]");
											ParticleSystem particleSystem = RenderingExtensions.SetTint(pfx, 0u);
											if ((object)_weapon != null)
											{
												float num12 = _weapon.PArea();
												CS_0024_003C_003E8__locals8.__area = 0f;
												if (_tween != null)
												{
													_tween.Kill();
												}
												TweenConfig tweenConfig = new TweenConfig();
												object[] array = new object[1];
												Transform transform = base.transform;
												if (array != null)
												{
													if ((object)transform != null)
													{
														int value = ((int*)(&array))->m_value;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj9 = default(object);
														bool flag12 = obj9 == null;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if (tweenConfig != null)
													{
														tweenConfig.targets = array;
														float num13 = CS_0024_003C_003E8__locals8.__area * 4f;
														_ = 0;
														_ = 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-30]");
														tweenConfig.scaleX = (float?)(object)0;
														_ = 0;
														_ = CS_0024_003C_003E8__locals8.__area;
														tweenConfig.duration = 150f;
														_ = 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-30]");
														tweenConfig.scaleY = (float?)(object)0;
														TweenCallback onStart = delegate
														{
															//IL_001a: Expected O, but got I4
															ArcadeSprite arcadeSprite4 = CS_0024_003C_003E8__locals8._003C_003E4__this.setScale(0f, (float?)(object)1);
														};
														tweenConfig.onStart = onStart;
														MultiTargetTween tween = Tweens.Add(tweenConfig);
														_tween = tween;
														if (_tween2 != null)
														{
															_tween2.Kill();
														}
														TweenConfig tweenConfig2 = new TweenConfig();
														object[] array2 = new object[2];
														if (array2 != null)
														{
															object obj10 = array2;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj11 = default(object);
															bool flag13 = obj11 == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_backgroundSprite != null)
															{
																object obj12 = array2;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj13 = default(object);
																bool flag14 = obj13 == null;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if (tweenConfig2 != null)
															{
																_ = 0;
																_ = 1133903872;
																_ = 0;
																_ = 1;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rsp-30]");
																_ = 0;
																TweenCallback tweenCallback = delegate
																{
																	EME_RapierProjectile_MegaSingle eME_RapierProjectile_MegaSingle = CS_0024_003C_003E8__locals8._003C_003E4__this;
																	SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(eME_RapierProjectile_MegaSingle._backgroundSprite, 0.35f);
																	ArcadeSprite arcadeSprite4 = CS_0024_003C_003E8__locals8._003C_003E4__this.setAlpha(1f);
																};
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2725 @ r8_v43 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_RapierProjectile_MegaSingle>)+370]");
																TweenCallback tweenCallback2 = new TweenCallback(this, (IntPtr)0);
																nint num14 = (nint)this;
																MultiTargetTween tween2 = Tweens.Add(tweenConfig2);
																_tween2 = tween2;
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
		goto IL_0a16;
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0146: Expected O, but got Ref
		//IL_0160: Expected native int or pointer, but got O
		//IL_035e: Expected O, but got I4
		//IL_0178: Expected O, but got Ref
		//IL_019f: Expected O, but got I
		//IL_01ae: Expected O, but got I4
		//IL_01b7: Expected native int or pointer, but got O
		//IL_01d1: Expected O, but got I
		//IL_01e9: Expected O, but got Ref
		//IL_0203: Expected native int or pointer, but got O
		//IL_037b: Expected O, but got I4
		//IL_021b: Expected O, but got Ref
		//IL_0235: Expected native int or pointer, but got O
		//IL_03a5: Expected O, but got I
		//IL_026d: Expected O, but got Ref
		//IL_0287: Expected native int or pointer, but got O
		//IL_03df: Expected O, but got I
		//IL_02e6: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem pfx = _pfx;
		if ((object)_pfx == null || ((UnityEngine.Object)pfx).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
			_pfxManager = pfxManager;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxLine.png");
			}
			else
			{
				int num = list._size + 1;
				list._size = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+90]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			obj = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(300f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-10]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0.35f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(8f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
			particleSystemConfig._scaleX = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.1f, 0.1f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
			particleSystemConfig._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
			_ = 0;
			_ = 0;
			particleSystemConfig._on = false;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+90]");
			particleSystemConfig._blendMode = (BlendMode?)(object)0;
			Transform parent = base.transform;
			ParticleSystem pfx2 = _pfxManager.CreateEmitter(particleSystemConfig, parent);
			_pfx = pfx2;
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T14_JEWELS))
		{
			bool flag = TryFreeze(other);
		}
	}

	public EME_RapierProjectile_MegaSingle()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_048d: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_04b5: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_04dd: Expected O, but got I
		//IL_01c0: Expected O, but got I
		List<uint> list = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(16746632u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 16746632;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(8947967u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 8947967;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(16777096u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 16777096;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			list.AddWithResize(16746751u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 16746751;
		}
		_tints = list;
		List<string> list2 = new List<string>();
		list2._version++;
		string[] items = list2._items;
		if (list2._size >= items.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"add_pierceOrange");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items2 = list2._items;
		if (list2._size >= items2.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"add_piercePurple");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items3 = list2._items;
		if (list2._size >= items3.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"add_pierceBlue");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items4 = list2._items;
		if (list2._size >= items4.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"add_pierceRed");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_frameNames = list2;
		base._002Ector();
	}
}
