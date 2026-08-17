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
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FlareExplosionProjectile : Projectile
{
	private MultiTargetTween _fadeoutTween;

	private MultiTargetTween _scaleTween;

	private PhaserSprite _starSprite;

	private PhaserSprite _sideSprite;

	private PhaserSprite _flatSprite;

	private bool _isLight = true;

	private string[] _sideNames;

	private string[] _starNames;

	private string[] _flatNames;

	private MultiTargetTween _flatTween;

	private MultiTargetTween _sideTween;

	private MultiTargetTween _starTween;

	private PhaserSprite _exploSprite;

	private MultiTargetTween _exploTween;

	private WeaponType[] _darkWeapons;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _PfxEmitter;

	private bool _particlesGenerated;

	public float _BodyScale;

	protected unsafe override void Awake()
	{
		//IL_0601: Unknown result type (might be due to invalid IL or missing references)
		//IL_0606: Expected O, but got Unknown
		//IL_015e: Expected O, but got I4
		//IL_01ab: Expected O, but got I
		//IL_0653: Unknown result type (might be due to invalid IL or missing references)
		//IL_0658: Expected O, but got Unknown
		//IL_0298: Expected O, but got I4
		//IL_02e5: Expected O, but got I
		//IL_06a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ad: Expected O, but got Unknown
		//IL_03d2: Expected O, but got I4
		//IL_041f: Expected O, but got I
		//IL_06fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ff: Expected O, but got Unknown
		//IL_04ae: Expected O, but got I4
		//IL_0595: Unknown result type (might be due to invalid IL or missing references)
		//IL_059a: Expected O, but got Unknown
		//IL_00e8->IL05bc: Incompatible stack heights: 1 vs 0
		//IL_0117->IL05bc: Incompatible stack heights: 1 vs 0
		//IL_0146->IL05bc: Incompatible stack heights: 1 vs 0
		//IL_018c->IL05bc: Incompatible stack heights: 1 vs 0
		//IL_01e0->IL05bc: Incompatible stack heights: 1 vs 0
		//IL_0222->IL05bc: Incompatible stack heights: 2 vs 0
		//IL_0251->IL05bc: Incompatible stack heights: 2 vs 0
		//IL_0280->IL05bc: Incompatible stack heights: 2 vs 0
		//IL_02c6->IL05bc: Incompatible stack heights: 2 vs 0
		//IL_031a->IL05bc: Incompatible stack heights: 2 vs 0
		//IL_035c->IL05bc: Incompatible stack heights: 3 vs 0
		//IL_038b->IL05bc: Incompatible stack heights: 3 vs 0
		//IL_03ba->IL05bc: Incompatible stack heights: 3 vs 0
		//IL_0400->IL05bc: Incompatible stack heights: 3 vs 0
		//IL_0454->IL05bc: Incompatible stack heights: 3 vs 0
		//IL_0496->IL05bc: Incompatible stack heights: 4 vs 0
		//IL_04ca->IL05bc: Incompatible stack heights: 4 vs 0
		//IL_04f9->IL05bc: Incompatible stack heights: 4 vs 0
		//IL_0528->IL05bc: Incompatible stack heights: 4 vs 0
		//IL_0557->IL05bc: Incompatible stack heights: 4 vs 0
		//IL_0581->IL05bc: Incompatible stack heights: 4 vs 0
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					_ = 0;
					_ = 0;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					object obj2 = default(object);
					object obj = obj2 - 80;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj);
					GameObject gameObject = base.gameObject;
					Vector2 pos = default(Vector2);
					PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "FlareStar1");
					if ((object)phaserSprite != null)
					{
						PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
						if ((object)phaserSprite2 != null)
						{
							PhaserSprite phaserSprite3 = phaserSprite2.setBlendMode(BlendMode.Add);
							if ((object)phaserSprite3 != null)
							{
								PhaserSprite phaserSprite4 = phaserSprite3.setScale(0.5f, (float?)(object)0);
								_ = 0;
								_ = 1056964608;
								_ = 1;
								if ((object)phaserSprite4 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
									PhaserSprite starSprite = phaserSprite4.setOrigin(0.5f, (float?)(object)0);
									_starSprite = starSprite;
									Transform transform2 = base.transform;
									if ((object)transform2 != null)
									{
										_ = 0;
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v45 (UnityEngine.Transform)+10]");
										bool flag2 = (nint)0 == 0;
										object obj3 = obj2 - 80;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v45 (UnityEngine.Transform)+10]");
										Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj3);
										GameObject gameObject2 = base.gameObject;
										PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "vfx", "FlareSide1");
										if ((object)phaserSprite5 != null)
										{
											PhaserSprite phaserSprite6 = phaserSprite5.setVisible(visible: false);
											if ((object)phaserSprite6 != null)
											{
												PhaserSprite phaserSprite7 = phaserSprite6.setBlendMode(BlendMode.Add);
												if ((object)phaserSprite7 != null)
												{
													PhaserSprite phaserSprite8 = phaserSprite7.setScale(0.5f, (float?)(object)0);
													_ = 0;
													_ = 1056964608;
													_ = 1;
													if ((object)phaserSprite8 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
														PhaserSprite sideSprite = phaserSprite8.setOrigin(1f, (float?)(object)0);
														_sideSprite = sideSprite;
														Transform transform3 = base.transform;
														if ((object)transform3 != null)
														{
															_ = 0;
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rax_v60 (UnityEngine.Transform)+10]");
															bool flag3 = (nint)0 == 0;
															object obj4 = obj2 - 80;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rax_v60 (UnityEngine.Transform)+10]");
															Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj4);
															GameObject gameObject3 = base.gameObject;
															PhaserSprite phaserSprite9 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "vfx", "FlareFlat1");
															if ((object)phaserSprite9 != null)
															{
																PhaserSprite phaserSprite10 = phaserSprite9.setVisible(visible: false);
																if ((object)phaserSprite10 != null)
																{
																	PhaserSprite phaserSprite11 = phaserSprite10.setBlendMode(BlendMode.Add);
																	if ((object)phaserSprite11 != null)
																	{
																		PhaserSprite phaserSprite12 = phaserSprite11.setScale(0.5f, (float?)(object)0);
																		_ = 0;
																		_ = 1056964608;
																		_ = 1;
																		if ((object)phaserSprite12 != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp+20]");
																			PhaserSprite flatSprite = phaserSprite12.setOrigin(0.5f, (float?)(object)0);
																			_flatSprite = flatSprite;
																			Transform transform4 = base.transform;
																			if ((object)transform4 != null)
																			{
																				_ = 0;
																				_ = 0;
																				bool flag4 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
																				object obj5 = obj2 - 80;
																				Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)obj5);
																				GameObject gameObject4 = base.gameObject;
																				PhaserSprite phaserSprite13 = RenderingExtensions.AddPhaserSprite(gameObject4, pos, "vfx", "s_pfx_rainbow_64w");
																				if ((object)phaserSprite13 != null)
																				{
																					PhaserSprite phaserSprite14 = phaserSprite13.setOrigin(0.5f, (float?)(object)0);
																					if ((object)phaserSprite14 != null)
																					{
																						PhaserSprite phaserSprite15 = phaserSprite14.setVisible(visible: false);
																						if ((object)phaserSprite15 != null)
																						{
																							PhaserSprite phaserSprite16 = phaserSprite15.setBlendMode(BlendMode.Add);
																							if ((object)phaserSprite16 != null)
																							{
																								PhaserSprite phaserSprite17 = phaserSprite16.setAlpha(0.25f);
																								if ((object)phaserSprite17 != null)
																								{
																									Transform transform5 = phaserSprite17.transform;
																									if ((object)transform5 != null)
																									{
																										_ = -90f;
																										Vector3 localEulerAngles = (Vector3)(obj2 - 80);
																										transform5.localEulerAngles = localEulerAngles;
																										_exploSprite = phaserSprite17;
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
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0719: Expected O, but got I
		//IL_0719: Expected O, but got I
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_0770: Expected O, but got I
		//IL_078d: Expected I4, but got O
		//IL_0d98: Expected O, but got I4
		//IL_07ec: Expected O, but got I
		//IL_07fa: Expected I4, but got O
		//IL_0db7: Expected O, but got I4
		//IL_0859: Expected O, but got I
		//IL_0867: Expected I4, but got O
		//IL_028f: Expected O, but got I
		//IL_0dd6: Expected O, but got I4
		//IL_08c6: Expected O, but got I
		//IL_0314: Expected O, but got I
		//IL_038a: Expected O, but got I
		//IL_03c4: Expected I4, but got O
		//IL_03d7: Expected O, but got Ref
		//IL_0413: Expected native int or pointer, but got O
		//IL_0442: Expected F4, but got I
		//IL_0455: Expected O, but got Ref
		//IL_046f: Expected native int or pointer, but got O
		//IL_04a7: Expected O, but got Ref
		//IL_04c1: Expected native int or pointer, but got O
		//IL_04f5: Expected O, but got I
		//IL_0503: Expected O, but got Ref
		//IL_0511: Expected O, but got I4
		//IL_052b: Expected native int or pointer, but got O
		//IL_0570: Expected O, but got I
		//IL_0585: Expected O, but got I
		//IL_05ad: Expected O, but got Ref
		//IL_05c7: Expected native int or pointer, but got O
		//IL_0a1c: Expected O, but got I4
		//IL_0a89: Expected O, but got I4
		//IL_0af6: Expected O, but got I4
		//IL_1028: Expected I, but got O
		//IL_00e3->IL0c0c: Incompatible stack heights: 1 vs 0
		//IL_0c9d->IL0c0c: Incompatible stack heights: 1 vs 0
		//IL_0cf1->IL0c0c: Incompatible stack heights: 1 vs 0
		//IL_016f->IL0c0c: Incompatible stack heights: 1 vs 0
		//IL_0d79->IL0c0c: Incompatible stack heights: 5 vs 0
		//IL_06a0->IL0c47: Incompatible stack heights: 5 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		if (!_particlesGenerated)
		{
			Weapon weapon2 = _weapon;
			Weapon darkWeapons = (Weapon)(object)_darkWeapons;
			if ((object)_weapon != null)
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rsi_v46 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
				}
				bool flag = _darkWeapons == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507A40");
				object obj4 = default(object);
				object obj3 = obj4 - -1;
				bool isLight = obj3 == null;
				_isLight = isLight;
				if ((object)_starSprite != null)
				{
					bool flag2 = (nint)obj4 == -1;
					uint tint = 16777215u;
					if (!flag2)
					{
						tint = 16746632u;
					}
					PhaserSprite phaserSprite = _starSprite.setTint(tint);
					if ((object)_sideSprite != null)
					{
						bool flag3 = _isLight;
						uint tint2 = 16777215u;
						if (!flag3)
						{
							tint2 = 16746632u;
						}
						PhaserSprite phaserSprite2 = _sideSprite.setTint(tint2);
						if (!_isLight)
						{
							if ((object)_flatSprite == null)
							{
								goto IL_0c0c;
							}
							PhaserSprite phaserSprite3 = _flatSprite.setTintFill(isEnabled: true, 2228258u);
						}
						bool flag4 = !_isLight;
						string spriteName = "s_pfx_rainbow_64u";
						if (!flag4)
						{
							spriteName = "s_pfx_rainbow_64w";
						}
						if ((object)_exploSprite != null)
						{
							PhaserSprite phaserSprite4 = _exploSprite.setFrame(spriteName, "vfx");
							bool flag5 = _isLight;
							uint tintColor = 16777215u;
							if (!flag5)
							{
								tintColor = 2228258u;
							}
							ArcadeSprite arcadeSprite = setTintFill(isEnabled: true, tintColor);
							GameObject gameObject = base.gameObject;
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v869 @ rsi_v49 (Il2CppMethodInfo)+38]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
							}
							_ = 0;
							bool flag6 = (object)gameObject == null;
							ParticleEmitterManager particlesManager;
							if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224))))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+E0]");
								particlesManager = (ParticleEmitterManager)0;
							}
							else
							{
								particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
							}
							_particlesManager = particlesManager;
							ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
							List<string> list = new List<string>();
							bool flag7 = list == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1560 @ rax_v194 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1560 @ rax_v194 (System.Collections.Generic.List`1<System.String>)+10]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1560 @ rax_v194 (System.Collections.Generic.List`1<System.String>)+10]");
							bool flag8 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1560 @ rax_v194 (System.Collections.Generic.List`1<System.String>)+18]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v653 @ rcx_v160+18]");
							if (num3 >= 0)
							{
								((List<object>)(object)list).AddWithResize((object)"WhiteDot");
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1560 @ rax_v194 (System.Collections.Generic.List`1<System.String>)+18]");
								object obj6 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							bool flag9 = particleSystemConfig == null;
							((Equipment)(object)particleSystemConfig)._003CLevelsNumber_003Ek__BackingField = (int)list;
							ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 40));
							_ = 0;
							_ = 10;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+E0]");
							((Weapon)(object)particleSystemConfig)._isVisible = false;
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(250f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-28]");
							((Weapon)(object)particleSystemConfig).IsHoming = false;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-18]");
							((Weapon)(object)particleSystemConfig)._003CFreezeChance_003Ek__BackingField = 0f;
							ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 8));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0.7f, 0f));
							((Weapon)(object)particleSystemConfig)._003CSkipAddingNormalWeapon_003Ek__BackingField = true;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-80]");
							_ = 0;
							ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+18]");
							((Equipment)(object)particleSystemConfig)._003CShowInRecap_003Ek__BackingField = false;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+28]");
							((Weapon)(object)particleSystemConfig)._gameMan = (GameManager)0;
							ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 56));
							((Weapon)(object)particleSystemConfig)._gameSessionData = (GameSessionData)2;
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(200f, 400f));
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+38]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+48]");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-78]");
							((Weapon)(object)particleSystemConfig)._firingTimer = (Timer)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-68]");
							((Weapon)(object)particleSystemConfig)._targetTransform = (Transform)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-58]");
							((Weapon)(object)particleSystemConfig)._critIndex = 0;
							ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
							_ = 0;
							_ = 0;
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+58]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+68]");
							_ = 0;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-50]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-40]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-30]");
							_ = 0;
							_ = 0;
							bool flag10 = _isLight;
							uint num4 = 16777215u;
							if (!flag10)
							{
								num4 = 2228258u;
							}
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+E0]");
							_ = 0;
							_ = 0;
							if ((object)_particlesManager != null)
							{
								ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig);
								_PfxEmitter = pfxEmitter;
								ArcadeSprite arcadeSprite2 = setVisible(visible: false);
								_particlesGenerated = true;
								goto IL_0c47;
							}
						}
					}
				}
			}
			goto IL_0c0c;
		}
		goto IL_0c47;
		IL_0c0c:
		throw new NullReferenceException();
		IL_0c47:
		BaseBody baseBody = body;
		if (body != null)
		{
			_ = 0;
			_ = 0;
			baseBody._enable = true;
			_ = 1065353216;
			_ = 1;
			_ = 1107296256;
			_ = 1;
			if (body != null)
			{
				BaseBody baseBody2 = body;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+E8]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+E0]");
				BaseBody baseBody3 = baseBody2.setSize((float?)(object)num5, (float?)(object)0);
				_ = 0;
				_ = 3246391296L;
				_ = 1;
				if (body != null)
				{
					BaseBody baseBody4 = body;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+E0]");
					BaseBody baseBody5 = baseBody4.setOffset(-0.5f, (float?)(object)0);
					ArcadeSprite arcadeSprite3 = setVisible(visible: false);
					int num6 = (int)_starNames;
					if (_starNames != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rsi_v30 (System.Int32)+18]");
						object obj7 = UnityEngine.Random.RandomRangeInt(0, 0);
						if ((object)_starSprite != null)
						{
							PhaserSprite starSprite = _starSprite;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rsi_v30 (System.Int32)+20+v236 @ rax_v81*8]");
							PhaserSprite phaserSprite5 = starSprite.setFrame((string)0, "vfx");
							int num7 = (int)_sideNames;
							if (_sideNames != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rsi_v31 (System.Int32)+18]");
								object obj8 = UnityEngine.Random.RandomRangeInt(0, 0);
								if ((object)_sideSprite != null)
								{
									PhaserSprite sideSprite = _sideSprite;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rsi_v31 (System.Int32)+20+v238 @ rax_v85*8]");
									PhaserSprite phaserSprite6 = sideSprite.setFrame((string)0, "vfx");
									int num8 = (int)_flatNames;
									if (_flatNames != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rsi_v32 (System.Int32)+18]");
										object obj9 = UnityEngine.Random.RandomRangeInt(0, 0);
										if ((object)_flatSprite != null)
										{
											PhaserSprite flatSprite = _flatSprite;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rsi_v32 (System.Int32)+20+v240 @ rax_v89*8]");
											PhaserSprite phaserSprite7 = flatSprite.setFrame((string)0, "vfx");
											if ((object)_starSprite != null)
											{
												Transform transform = _starSprite.transform;
												Transform transform2 = base.transform;
												if ((object)transform2 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v92 (UnityEngine.Transform)+10]");
													bool flag11 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rax_v92 (UnityEngine.Transform)+10]");
													Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
													bool flag12 = (object)transform == null;
													bool flag13 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
													Vector3 value = default(Vector3);
													Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
													bool flag14 = (object)_sideSprite == null;
													Transform transform3 = _sideSprite.transform;
													Transform transform4 = base.transform;
													bool flag15 = (object)transform4 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1748 @ rax_v104 (UnityEngine.Transform)+10]");
													bool flag16 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1748 @ rax_v104 (UnityEngine.Transform)+10]");
													Transform.get_position_Injected((IntPtr)0, out ret);
													bool flag17 = (object)transform3 == null;
													bool flag18 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
													Vector3 value2 = default(Vector3);
													Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
													bool flag19 = (object)_exploSprite == null;
													Transform transform5 = _exploSprite.transform;
													Transform transform6 = base.transform;
													bool flag20 = (object)transform6 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2334 @ rax_v116 (UnityEngine.Transform)+10]");
													bool flag21 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2334 @ rax_v116 (UnityEngine.Transform)+10]");
													Transform.get_position_Injected((IntPtr)0, out ret);
													bool flag22 = (object)transform5 == null;
													bool flag23 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
													Transform.set_position_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref value);
													bool flag24 = (object)_weapon == null;
													float num9 = _weapon.PArea();
													bool flag25 = (object)_starSprite == null;
													float num10 = (float)ret * 0.5f;
													PhaserSprite phaserSprite8 = _starSprite.setScale(num10, (float?)(object)0);
													bool flag26 = (object)_weapon == null;
													float num11 = _weapon.PArea();
													bool flag27 = (object)_sideSprite == null;
													float num12 = num10 * 0.5f;
													PhaserSprite phaserSprite9 = _sideSprite.setScale(num12, (float?)(object)0);
													bool flag28 = (object)_weapon == null;
													float num13 = _weapon.PArea();
													bool flag29 = (object)_flatSprite == null;
													float xScale = num12 * 0.5f;
													PhaserSprite phaserSprite10 = _flatSprite.setScale(xScale, (float?)(object)0);
													bool flag30 = (object)_PfxEmitter == null;
													Transform transform7 = _PfxEmitter.transform;
													Transform transform8 = base.transform;
													bool flag31 = (object)transform8 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2837 @ rax_v137 (UnityEngine.Transform)+10]");
													bool flag32 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2837 @ rax_v137 (UnityEngine.Transform)+10]");
													Transform.get_position_Injected((IntPtr)0, out ret);
													bool flag33 = (object)transform7 == null;
													bool flag34 = ((Exception)(object)transform7)._className == null;
													Transform.set_position_Injected((IntPtr)((Exception)(object)transform7)._className, ref value2);
													bool flag35 = (object)_weapon == null;
													float num14 = _weapon.PArea();
													bool flag36 = (object)_weapon == null;
													float num15 = _weapon.PArea();
													RenderingExtensions.SetSpeed(max: (float)ret * 400f, min: (float)ret * 200f, pfx: _PfxEmitter);
													bool flag37 = (object)_exploSprite == null;
													PhaserSprite phaserSprite11 = _exploSprite.setAlpha(0.25f);
													Explode();
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
		goto IL_0c0c;
	}

	private unsafe void Explode()
	{
		//IL_007d: Expected I, but got O
		//IL_01ff: Expected O, but got I4
		//IL_0703: Expected I, but got O
		//IL_0767: Expected O, but got I4
		//IL_0775: Expected O, but got I4
		//IL_0285: Expected I, but got O
		//IL_02db: Expected O, but got I4
		//IL_0329: Expected O, but got I4
		//IL_081d: Expected O, but got I4
		//IL_03ea: Expected I, but got O
		//IL_0440: Expected O, but got I4
		//IL_04a7: Expected O, but got I4
		//IL_0568: Expected I, but got O
		//IL_05be: Expected O, but got I4
		//IL_05cc: Expected O, but got I4
		//IL_0633: Expected O, but got I4
		//IL_0686: Expected O, but got I4
		RenderingExtensions.Start(_PfxEmitter);
		float num = _weapon.PArea();
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num2 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 150f;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_BodyScale", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig.custom = dictionary;
			TweenCallback onStart = delegate
			{
				_BodyScale = 1f;
			};
			tweenConfig.onStart = onStart;
			TweenCallback onUpdate = delegate
			{
				//IL_001f: Expected O, but got I4
				//IL_001f: Expected O, but got I4
				//IL_005e: Expected O, but got I4
				BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
				float num16 = _BodyScale * -1f;
				float x = num16 * 0.5f;
				BaseBody baseBody2 = body.setOffset(x, (float?)(object)1);
			};
			tweenConfig.onUpdate = onUpdate;
			TweenCallback onComplete = delegate
			{
				//IL_001f: Expected O, but got I4
				//IL_001f: Expected O, but got I4
				//IL_005e: Expected O, but got I4
				BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
				float num16 = _BodyScale * -1f;
				float x = num16 * 0.5f;
				BaseBody baseBody2 = body.setOffset(x, (float?)(object)1);
				BaseBody baseBody3 = body;
				baseBody3._enable = false;
				FadeOut();
			};
			tweenConfig.onComplete = onComplete;
			nint num3 = 0;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			bool flag2 = !config._003CFlashingVFXEnabled_003Ek__BackingField;
			object obj2 = 0;
			if (!flag2)
			{
				if (_flatTween != null)
				{
					_flatTween.Kill();
				}
				TweenConfig tweenConfig2 = new TweenConfig();
				object[] array2 = new object[1];
				if ((object)_flatSprite != null)
				{
					nint num4 = (nint)array2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj3 = default(object);
					if (obj3 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				tweenConfig2.alpha = (float?)(object)1;
				float num5 = _weapon.PArea();
				float num7 = default(float);
				float num6 = num7 * 0.7f;
				tweenConfig2.yoyo = true;
				tweenConfig2.duration = 150f;
				tweenConfig2.scale = (float?)(object)1;
				TweenCallback onStart2 = delegate
				{
					//IL_0038: Expected O, but got I4
					float num16 = _weapon.PArea();
					object obj7 = default(object);
					float xScale = (float)obj7 * 0.5f;
					PhaserSprite phaserSprite = _flatSprite.setScale(xScale, (float?)(object)0);
					PhaserSprite phaserSprite2 = _flatSprite.setAlpha(0f);
					PhaserSprite phaserSprite3 = _flatSprite.setVisible(visible: true);
				};
				tweenConfig2.onStart = onStart2;
				MultiTargetTween flatTween = Tweens.Add(tweenConfig2);
				_flatTween = flatTween;
				if (_sideTween != null)
				{
					_sideTween.Kill();
				}
				TweenConfig tweenConfig3 = new TweenConfig();
				object[] array3 = new object[1];
				if ((object)_sideSprite != null)
				{
					nint num8 = (nint)array3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj4 = default(object);
					if (obj4 == null)
					{
						ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
						throw ex2;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig3.targets = array3;
				tweenConfig3.alpha = (float?)(object)1;
				float2 float5 = base.position;
				float num9 = _weapon.PArea();
				float num10 = num6 * 0.32f;
				tweenConfig3.yoyo = true;
				tweenConfig3.duration = 150f;
				float num11 = num10 + (float)float5;
				tweenConfig3.x = (float?)(object)1;
				TweenCallback onStart3 = delegate
				{
					PhaserSprite phaserSprite = _sideSprite.setAlpha(0f);
					PhaserSprite phaserSprite2 = _sideSprite.setVisible(visible: true);
				};
				tweenConfig3.onStart = onStart3;
				MultiTargetTween sideTween = Tweens.Add(tweenConfig3);
				_sideTween = sideTween;
				if (_starTween != null)
				{
					_starTween.Kill();
				}
				TweenConfig tweenConfig4 = new TweenConfig();
				object[] array4 = new object[1];
				if ((object)_starSprite != null)
				{
					nint num12 = (nint)array4;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj5 = default(object);
					if (obj5 == null)
					{
						ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
						throw ex3;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig4.targets = array4;
				tweenConfig4.alpha = (float?)(object)1;
				tweenConfig4.angle = (float?)(object)1;
				float2 float6 = base.position;
				float num13 = _weapon.PArea();
				num7 = num11 * 0.16f;
				tweenConfig4.yoyo = true;
				tweenConfig4.duration = 150f;
				float num14 = (float)float6 - num7;
				tweenConfig4.x = (float?)(object)1;
				TweenCallback onStart4 = delegate
				{
					//IL_003d: Expected O, but got I4
					//IL_0080: Expected O, but got Ref
					float num16 = _weapon.PArea();
					object obj7 = default(object);
					float xScale = (float)obj7 * 0.5f;
					PhaserSprite phaserSprite = _starSprite.setScale(xScale, (float?)(object)0);
					PhaserSprite phaserSprite2 = _starSprite.setAlpha(0f);
					Transform transform = _starSprite.transform;
					object obj8 = default(object);
					transform.localEulerAngles = (Vector3)(&obj8);
					PhaserSprite phaserSprite3 = _starSprite.setVisible(visible: true);
				};
				tweenConfig4.onStart = onStart4;
				num3 = 0;
				MultiTargetTween starTween = Tweens.Add(tweenConfig4);
				_starTween = starTween;
				obj2 = 0;
			}
			if (_exploTween != null)
			{
				_exploTween.Kill();
			}
			TweenConfig tweenConfig5 = new TweenConfig();
			object[] array5 = new object[1];
			if ((object)_exploSprite != null)
			{
				nint num15 = (nint)array5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj6 = default(object);
				if (obj6 == null)
				{
					ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
					throw ex4;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig5.targets = array5;
			tweenConfig5.duration = 150f;
			tweenConfig5.scaleY = (float?)(object)1;
			tweenConfig5.scaleX = (float?)(object)1;
			TweenCallback onStart5 = delegate
			{
				//IL_001a: Expected O, but got I4
				PhaserSprite phaserSprite = _exploSprite.setScale(1f, (float?)(object)1);
				PhaserSprite phaserSprite2 = _exploSprite.setVisible(visible: true);
			};
			tweenConfig5.onStart = onStart5;
			TweenCallback onComplete2 = delegate
			{
				PhaserSprite phaserSprite = _exploSprite.setVisible(visible: false);
			};
			tweenConfig5.onComplete = onComplete2;
			MultiTargetTween exploTween = Tweens.Add(tweenConfig5);
			_exploTween = exploTween;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			float detune = (float)_indexInWeapon * -100f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Flare, soundConfig, 200f, 1, time);
			return;
		}
		ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
		throw ex5;
	}

	private void FadeOut()
	{
		//IL_0059: Expected I, but got O
		//IL_00b1: Expected I, but got O
		//IL_0109: Expected I, but got O
		//IL_0161: Expected I, but got O
		//IL_01b9: Expected I, but got O
		//IL_021d: Expected O, but got I4
		_PfxEmitter.Stop();
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[5];
		if ((object)_starSprite != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_exploSprite != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_sideSprite != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_flatSprite != null)
		{
			nint num4 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_sprite != null)
		{
			nint num5 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 300f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween fadeoutTween = Tweens.Add(tweenConfig);
		_fadeoutTween = fadeoutTween;
	}

	public override void Despawn()
	{
		base.Despawn();
		if (_fadeoutTween != null)
		{
			_fadeoutTween.Kill();
		}
	}

	public FlareExplosionProjectile()
	{
		string[] sideNames = new string[5];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_sideNames = sideNames;
		string[] starNames = new string[6];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_starNames = starNames;
		string[] flatNames = new string[5];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_flatNames = flatNames;
		_darkWeapons = new WeaponType[7]
		{
			WeaponType.VESPERS,
			WeaponType.SILF2,
			WeaponType.MANNAGGIA,
			WeaponType.BONE,
			WeaponType.TRAPANO,
			WeaponType.TP_EVIL1,
			WeaponType.TP_EVIL2
		};
		_BodyScale = 1f;
		base._002Ector();
	}

	private void _003CExplode_003Eb__21_0()
	{
		_BodyScale = 1f;
	}

	private void _003CExplode_003Eb__21_1()
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_005e: Expected O, but got I4
		BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
		float num = _BodyScale * -1f;
		float x = num * 0.5f;
		BaseBody baseBody2 = body.setOffset(x, (float?)(object)1);
	}

	private void _003CExplode_003Eb__21_2()
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		//IL_005e: Expected O, but got I4
		BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
		float num = _BodyScale * -1f;
		float x = num * 0.5f;
		BaseBody baseBody2 = body.setOffset(x, (float?)(object)1);
		BaseBody baseBody3 = body;
		baseBody3._enable = false;
		FadeOut();
	}

	private void _003CExplode_003Eb__21_3()
	{
		//IL_0038: Expected O, but got I4
		float num = _weapon.PArea();
		object obj = default(object);
		float xScale = (float)obj * 0.5f;
		PhaserSprite phaserSprite = _flatSprite.setScale(xScale, (float?)(object)0);
		PhaserSprite phaserSprite2 = _flatSprite.setAlpha(0f);
		PhaserSprite phaserSprite3 = _flatSprite.setVisible(visible: true);
	}

	private void _003CExplode_003Eb__21_4()
	{
		PhaserSprite phaserSprite = _sideSprite.setAlpha(0f);
		PhaserSprite phaserSprite2 = _sideSprite.setVisible(visible: true);
	}

	private unsafe void _003CExplode_003Eb__21_5()
	{
		//IL_003d: Expected O, but got I4
		//IL_0080: Expected O, but got Ref
		float num = _weapon.PArea();
		object obj = default(object);
		float xScale = (float)obj * 0.5f;
		PhaserSprite phaserSprite = _starSprite.setScale(xScale, (float?)(object)0);
		PhaserSprite phaserSprite2 = _starSprite.setAlpha(0f);
		Transform transform = _starSprite.transform;
		object obj2 = default(object);
		transform.localEulerAngles = (Vector3)(&obj2);
		PhaserSprite phaserSprite3 = _starSprite.setVisible(visible: true);
	}

	private void _003CExplode_003Eb__21_6()
	{
		//IL_001a: Expected O, but got I4
		PhaserSprite phaserSprite = _exploSprite.setScale(1f, (float?)(object)1);
		PhaserSprite phaserSprite2 = _exploSprite.setVisible(visible: true);
	}

	private void _003CExplode_003Eb__21_7()
	{
		PhaserSprite phaserSprite = _exploSprite.setVisible(visible: false);
	}

	private void _003CFadeOut_003Eb__22_0()
	{
		Despawn();
	}
}
