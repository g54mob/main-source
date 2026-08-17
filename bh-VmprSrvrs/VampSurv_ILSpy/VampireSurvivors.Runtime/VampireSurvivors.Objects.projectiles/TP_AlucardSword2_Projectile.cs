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
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_AlucardSword2_Projectile : Projectile
{
	private SpriteRenderer _AlucardSprite;

	private SpriteRenderer _AlucardGlowSprite;

	private SpriteRenderer _SwordSprite;

	private SpriteAnimation _alucardAnim;

	private SpriteAnimation _alucardGlowAnim;

	private SpriteAnimation _swordAnim;

	private const float SwordOffsetX = 0.16f;

	private const float SwordOffsetY = 0.08f;

	private int _evoCount;

	private List<string> _swordSpriteNames;

	private List<uint> _glowTints;

	private bool _initSpriteTrail;

	private bool _cachedFlipX;

	private const float DashDuration = 750f;

	private int _numSlashes;

	private float _slashesRemaining;

	private List<float> _ghostYOffsets;

	private float _ghostYOffsetMul;

	private TP_AlucardSword2_Weapon _trueWeapon;

	private Tween _posTween;

	private MultiTargetTween _alphaTween;

	private Timer _slashTimer;

	private Timer _bodyTimer;

	private float ScaledAlpha
	{
		get
		{
			//IL_0018: Invalid comparison between F4 and O
			//IL_0041: Invalid comparison between O and F4
			float num = _weapon.PArea();
			object obj = default(object);
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
			float result = 1f;
			if (!flag)
			{
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)2.5f))
				{
					return 0.5f;
				}
				float num2 = (float)obj - 1f;
				float num3 = num2 * 0.5f;
				float num4 = num3 / 1.5f;
				result = 1f - num4;
			}
			return result;
		}
	}

	protected override void Awake()
	{
		base.Awake();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0029: Expected I, but got O
		//IL_0031: Expected I, but got O
		//IL_0041: Expected O, but got I
		//IL_00c1: Expected O, but got I4
		//IL_0016: Expected O, but got I4
		//IL_0cae: Expected O, but got I
		//IL_0cc5: Expected O, but got I4
		//IL_007d: Expected O, but got I
		//IL_00ce: Expected O, but got I
		//IL_00b3: Expected O, but got I4
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected I4, but got Unknown
		//IL_02cf: Expected I4, but got I8
		//IL_0302: Expected O, but got I4
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected O, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected I4, but got Unknown
		//IL_034e: Expected I, but got O
		//IL_0395: Expected F4, but got I4
		//IL_03de: Expected O, but got I4
		//IL_03de: Expected F4, but got I4
		//IL_052f: Expected O, but got I
		//IL_0709: Expected O, but got I4
		//IL_07c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ce: Expected O, but got Unknown
		//IL_0b8b: Expected F4, but got I4
		//IL_0ba2: Expected F4, but got I4
		//IL_0f17: Expected O, but got I
		//IL_0f41: Expected O, but got I
		//IL_0be6: Expected O, but got I8
		//IL_0c47: Expected O, but got Ref
		//IL_054f->IL0cd3: Incompatible stack heights: 1 vs 0
		//IL_0811->IL0cd3: Incompatible stack heights: 1 vs 0
		//IL_05b7->IL0cd3: Incompatible stack heights: 1 vs 0
		//IL_0830->IL0cd3: Incompatible stack heights: 1 vs 0
		//IL_05e3->IL0cd3: Incompatible stack heights: 1 vs 0
		//IL_0dd0->IL0cd3: Incompatible stack heights: 1 vs 0
		//IL_0d45->IL0cd3: Incompatible stack heights: 1 vs 0
		//IL_0917->IL0cd3: Incompatible stack heights: 1 vs 0
		//IL_063c->IL0cd3: Incompatible stack heights: 1 vs 0
		//IL_097c->IL0cd3: Incompatible stack heights: 1 vs 0
		//IL_0673->IL0cd3: Incompatible stack heights: 1 vs 0
		//IL_09dc->IL0cd3: Incompatible stack heights: 1 vs 0
		//IL_06aa->IL0cd3: Incompatible stack heights: 1 vs 0
		//IL_06e7->IL0cd3: Incompatible stack heights: 1 vs 0
		//IL_0e26->IL0cd3: Incompatible stack heights: 2 vs 0
		//IL_0d9d->IL0cd3: Incompatible stack heights: 1 vs 0
		//IL_0acd->IL0cd3: Incompatible stack heights: 2 vs 0
		//IL_0d74->IL0cd3: Incompatible stack heights: 1 vs 0
		//IL_075e->IL0cd3: Incompatible stack heights: 2 vs 0
		//IL_0e86->IL0cd3: Incompatible stack heights: 3 vs 0
		//IL_0789->IL0cd3: Incompatible stack heights: 2 vs 0
		//IL_0b17->IL0cd3: Incompatible stack heights: 3 vs 0
		//IL_07e8->IL0d79: Incompatible stack heights: 2 vs 1
		//IL_0b46->IL0cd3: Incompatible stack heights: 3 vs 0
		//IL_07ed->IL07ed: Incompatible stack heights: 2 vs 1
		//IL_0ecc->IL0cd3: Incompatible stack heights: 3 vs 0
		//IL_1005->IL0cd3: Incompatible stack heights: 4 vs 0
		//IL_0beb->IL0fd7: Incompatible stack heights: 5 vs 4
		//IL_0fa9->IL0cd3: Incompatible stack heights: 5 vs 0
		//IL_0c38->IL0cd3: Incompatible stack heights: 6 vs 0
		//IL_0c56->IL0cd3: Incompatible stack heights: 6 vs 0
		BulletPool typeFromHandle = default(BulletPool);
		base.InitProjectile(typeFromHandle, weapon, index);
		float? trueWeapon;
		Weapon weapon2;
		if ((object)weapon == null)
		{
			weapon2 = weapon;
			trueWeapon = (float?)(object)0;
			goto IL_0c88;
		}
		nint num = (nint)typeof(TP_AlucardSword2_Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v73 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_AlucardSword2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r8_v48 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v73 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_AlucardSword2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r8_v48 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v157+FFFFFFF8+v73 @ rax_v152*8]");
			if (0 == (nint)typeof(TP_AlucardSword2_Weapon))
			{
				obj3 = 1;
				goto IL_0c97;
			}
		}
		obj3 = 0;
		goto IL_0c97;
		IL_0cd3:
		throw new NullReferenceException();
		IL_0c88:
		_trueWeapon = (TP_AlucardSword2_Weapon)trueWeapon;
		TP_AlucardSword2_Weapon trueWeapon2 = _trueWeapon;
		int num9 = default(int);
		float scaledAlpha;
		if ((object)_trueWeapon != null)
		{
			int evoCount;
			if (trueWeapon2._totalOtherEvos <= 5 && trueWeapon2._totalOtherEvos == -1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
				object obj4 = (object)typeFromHandle >> 31;
				typeFromHandle = (BulletPool)(object)((object)typeFromHandle + obj4);
				object obj5 = typeFromHandle * 2;
				object obj6 = (object)typeFromHandle + obj5;
				object obj7 = obj6 + obj6;
				evoCount = trueWeapon2._fireCounter - obj7;
			}
			else
			{
				evoCount = trueWeapon2._totalOtherEvos;
				if (trueWeapon2._totalOtherEvos > 5)
				{
					evoCount = 5;
				}
			}
			_evoCount = evoCount;
			if ((object)weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
				object obj8 = default(object);
				float num4 = (float)obj8 + 0.16f;
				float2 float6 = default(float2);
				base.position = float6;
				InitAnimations();
				Weapon weapon3 = _weapon;
				if ((object)_weapon != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
					{
						_cachedFlipX = characterController._isFlipped;
						int num5 = (int)(index & 0x80000001L);
						if ((nint)((Equipment)weapon3)._003COwner_003Ek__BackingField < 0)
						{
							object obj9 = num5 - 1;
							object obj10 = obj9 | -2;
							num5 = obj10 + 1;
						}
						if (num5 == 1)
						{
							bool cachedFlipX = !characterController._isFlipped;
							_cachedFlipX = cachedFlipX;
						}
						Weapon weapon4 = _weapon;
						if ((object)_weapon != null)
						{
							nint num6 = (nint)weapon4;
							float num7 = _weapon.PAmount();
							float num8 = (float)float6 * 0.5f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B937E0");
							_numSlashes = num9;
							BaseBody baseBody = body;
							_slashesRemaining = num9;
							if (body != null)
							{
								baseBody._enable = false;
								float num10 = weapon.PArea();
								ArcadeSprite arcadeSprite = setScale(num9, (float?)(object)0);
								if ((object)_AlucardSprite != null)
								{
									_AlucardSprite.flipX = _cachedFlipX;
									if ((object)_alucardAnim != null)
									{
										_alucardAnim.SetAnimation("alucard_run");
										if ((object)_AlucardGlowSprite != null)
										{
											_AlucardGlowSprite.enabled = false;
											if ((object)_AlucardGlowSprite != null)
											{
												_AlucardGlowSprite.flipX = _cachedFlipX;
												scaledAlpha = ScaledAlpha;
												SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_AlucardGlowSprite, scaledAlpha);
												List<uint> glowTints = _glowTints;
												int evoCount2 = _evoCount;
												if (_glowTints != null)
												{
													int evoCount3 = _evoCount;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ rax_v58 (System.Collections.Generic.List`1<System.UInt32>)+18]");
													bool flag = (nint)evoCount3 >= (nint)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ rax_v58 (System.Collections.Generic.List`1<System.UInt32>)+10]");
													object obj11 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v431 @ rax_v58 (System.Collections.Generic.List`1<System.UInt32>)+10]");
													if ((nint)0 != 0)
													{
														SpriteRenderer alucardGlowSprite = _AlucardGlowSprite;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v59+20+v391 @ rdx_v37 (System.Int32)*4]");
														SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(alucardGlowSprite, 0u);
														if (_initSpriteTrail)
														{
															goto IL_07ed;
														}
														_initSpriteTrail = true;
														if ((object)_AlucardSprite != null)
														{
															GameObject gameObject = _AlucardSprite.gameObject;
															if ((object)gameObject != null)
															{
																SpriteTrail spriteTrail = gameObject.AddComponent<SpriteTrail>();
																_spriteTrail = spriteTrail;
																SpriteTrail spriteTrail2 = _spriteTrail;
																if ((object)_spriteTrail != null)
																{
																	spriteTrail2._MainSprite = _AlucardSprite;
																	SpriteTrail spriteTrail3 = _spriteTrail;
																	if ((object)_spriteTrail != null)
																	{
																		spriteTrail3._DefaultGhostAlpha = 0.5f;
																		SpriteTrail spriteTrail4 = _spriteTrail;
																		if ((object)_spriteTrail != null)
																		{
																			spriteTrail4._AlphaDecayPerGhost = 0f;
																			SpriteTrail spriteTrail5 = _spriteTrail;
																			if ((object)_spriteTrail != null)
																			{
																				spriteTrail5._MaxHistory = 3;
																				_spriteTrail.InitialiseGhosts(expandExisting: true);
																				if ((object)_spriteTrail != null)
																				{
																					SpriteTrail spriteTrail6 = _spriteTrail.setVisible(b: true);
																					float? num11 = (float?)(object)0;
																					while (true)
																					{
																						SpriteTrail spriteTrail7 = _spriteTrail;
																						if ((object)_spriteTrail == null)
																						{
																							break;
																						}
																						List<SpriteRenderer> ghosts = spriteTrail7._ghosts;
																						if (spriteTrail7._ghosts == null)
																						{
																							break;
																						}
																						bool flag2 = (nint)num11 >= ghosts._size;
																						SpriteRenderer[] items = ghosts._items;
																						if (ghosts._items == null)
																						{
																							break;
																						}
																						uint[] array = new uint[1];
																						if (array == null)
																						{
																							break;
																						}
																						array[0] = 16740464u;
																						SpriteRenderer spriteRenderer3 = RenderingExtensions.SetTint(items[(object)num11], array);
																						num11 = (float?)(object)((_003F?)num11 + 1);
																						if ((nint)num11 < 3)
																						{
																							continue;
																						}
																						goto IL_07ed;
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
		goto IL_0cd3;
		IL_0c97:
		bool flag3 = obj3 == null;
		weapon2 = (Weapon)num2;
		typeFromHandle = (BulletPool)(object)typeof(TP_AlucardSword2_Weapon);
		trueWeapon = (float?)(object)0;
		if (!flag3)
		{
			weapon2 = (Weapon)num2;
			typeFromHandle = (BulletPool)(object)typeof(TP_AlucardSword2_Weapon);
			trueWeapon = (float?)weapon;
		}
		goto IL_0c88;
		IL_07ed:
		SpriteTrail spriteTrail8 = _spriteTrail;
		if ((object)_spriteTrail != null && (object)_weapon != null)
		{
			float num12 = _weapon.PArea();
			float num16;
			if (1f < scaledAlpha)
			{
				if (scaledAlpha < 2.5f)
				{
					float num13 = scaledAlpha - 1f;
					float num14 = num13 * 0.5f;
					float num15 = num14 / 1.5f;
					num16 = 1f - num15;
				}
				else
				{
					num16 = 0.5f;
				}
			}
			else
			{
				num16 = 1f;
			}
			float num17 = num16 * spriteTrail8._DefaultGhostAlpha;
			if ((object)_spriteTrail != null)
			{
				SpriteTrail spriteTrail9 = _spriteTrail.SetAlpha(0, num17);
				if ((object)_spriteTrail != null)
				{
					float num18 = num17 + num17;
					float num19 = num18 / 3f;
					float a = num17 - num19;
					SpriteTrail spriteTrail10 = _spriteTrail.SetAlpha(1, a);
					if ((object)_spriteTrail != null)
					{
						float num20 = num17 / 3f;
						float a2 = num17 - num20;
						SpriteTrail spriteTrail11 = _spriteTrail.SetAlpha(2, a2);
						object swordSprite = _SwordSprite;
						if ((object)_SwordSprite != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rbx_v15 (System.Object)+10]");
							bool flag4 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rbx_v15 (System.Object)+10]");
							Renderer.set_enabled_Injected((IntPtr)0, false);
							if ((object)_weapon != null)
							{
								float num21 = _weapon.PArea();
								bool flag5 = !(1f < num20);
								float alpha = 1f;
								if (!flag5)
								{
									if (num20 < 2.5f)
									{
										float num22 = num20 - 1f;
										float num23 = num22 * 0.5f;
										num20 = num23 / 1.5f;
										alpha = 1f - num20;
									}
									else
									{
										alpha = 0.5f;
									}
								}
								SpriteRenderer spriteRenderer4 = RenderingExtensions.SetAlpha(_SwordSprite, alpha);
								object swordSprite2 = _SwordSprite;
								if ((object)_SwordSprite != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rbx_v17 (System.Object)+10]");
									bool flag6 = (nint)0 == 0;
									bool value = !_cachedFlipX;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rbx_v17 (System.Object)+10]");
									SpriteRenderer.set_flipX_Injected((IntPtr)0, value);
									SetSwordOffset();
									if ((object)_AlucardGlowSprite != null)
									{
										_AlucardGlowSprite.sortingOrder = 500;
										if ((object)_AlucardSprite != null)
										{
											_AlucardSprite.sortingOrder = 501;
											if ((object)_SwordSprite != null)
											{
												_SwordSprite.sortingOrder = 502;
												if (!_cachedFlipX || 0 <= num9)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm7,xmm12\"");
													float num24 = 0f;
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
													float num24 = num9;
												}
												object cachedTransform = _cachedTransform;
												if ((object)_cachedTransform != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rbx_v19 (System.Object)+10]");
													bool flag7 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rbx_v19 (System.Object)+10]");
													Transform.get_position_Injected((IntPtr)0, out Vector3 _);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
													object obj12 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
													bool flag8 = (nint)0 != 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rbx_v19 (System.Object)+10]");
													object obj13 = 0;
													if (!flag8)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
														bool flag9 = obj12 == null;
														obj13 = 6573110936L;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v2238 @ rax_v91 (should have been resolved before IL gen)");
													float? cachedTransform2 = (float?)_cachedTransform;
													if ((object)_cachedTransform != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rbx_v20 (System.Nullable`1<System.Single>)+10]");
														bool flag10 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rbx_v20 (System.Nullable`1<System.Single>)+10]");
														Transform.get_position_Injected((IntPtr)0, out Vector3 ret2);
														List<float> ghostYOffsets = _ghostYOffsets;
														if (_ghostYOffsets != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v98 (System.Collections.Generic.List`1<System.Single>)+18]");
															bool flag11 = (nint)index >= (nint)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rax_v98 (System.Collections.Generic.List`1<System.Single>)+10]");
															if ((nint)0 != 0)
															{
																DashToPosition((Vector3)(&ret2));
																Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1549 Invalid \"Jump target not found in method: 0x18707F840\"");
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
		goto IL_0cd3;
	}

	public override void InternalUpdate()
	{
	}

	public override void Despawn()
	{
		if (_slashTimer != null)
		{
			_slashTimer.Cancel();
		}
		if (_bodyTimer != null)
		{
			_bodyTimer.Cancel();
		}
		if (_posTween != null)
		{
			TweenExtensions.Kill(_posTween);
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if ((object)_swordAnim != null)
		{
			_swordAnim.CleanAnimations();
		}
		if ((object)_alucardAnim != null)
		{
			_alucardAnim.CleanAnimations();
		}
		base.Despawn();
	}

	private void LateUpdate()
	{
		Transform transform = _AlucardGlowSprite.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	private void InitAnimations()
	{
		SpriteAnimation swordAnim = _swordAnim;
		if ((object)_swordAnim == null || ((UnityEngine.Object)swordAnim).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = _SwordSprite.gameObject;
			SpriteAnimation swordAnim2 = gameObject.AddComponent<SpriteAnimation>();
			_swordAnim = swordAnim2;
		}
		SpriteAnimation alucardAnim = _alucardAnim;
		if ((object)_alucardAnim == null || ((UnityEngine.Object)alucardAnim).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject2 = _AlucardSprite.gameObject;
			SpriteAnimation alucardAnim2 = gameObject2.AddComponent<SpriteAnimation>();
			_alucardAnim = alucardAnim2;
		}
		SpriteAnimation alucardGlowAnim = _alucardGlowAnim;
		if ((object)_alucardGlowAnim == null || ((UnityEngine.Object)alucardGlowAnim).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject3 = _AlucardGlowSprite.gameObject;
			SpriteAnimation alucardGlowAnim2 = gameObject3.AddComponent<SpriteAnimation>();
			_alucardGlowAnim = alucardGlowAnim2;
		}
		List<string> swordSpriteNames = _swordSpriteNames;
		int evoCount = _evoCount;
		if (_evoCount < swordSpriteNames._size)
		{
			string[] items = swordSpriteNames._items;
			int num = default(int);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(items[evoCount], 1, 5, "ThosePeople", num);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			_swordAnim.AddAnimation("sword_slash", animationFrames, 50, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames(items[evoCount], 6, 13, "ThosePeople", num);
			_swordAnim.AddAnimation("sword_followthrough", animationFrames2, 25, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("TP_VFX_AlucardSlash", 1, 7, "ThosePeople", num);
			_alucardAnim.AddAnimation("alucard_dash", animationFrames3, 10, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("TP_VFX_AlucardSlash", 8, 11, "ThosePeople", num);
			_alucardAnim.AddAnimation("alucard_slash", animationFrames4, 30, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
			List<Sprite> animationFrames5 = SpriteManager.GetAnimationFrames("TP_VFX_AlucardSlashGlow", 1, 4, "ThosePeople", num);
			_alucardGlowAnim.AddAnimation("alucard_glow", animationFrames5, 30, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void StartFadeIn()
	{
		//IL_0091: Expected I, but got O
		//IL_010d: Expected O, but got I4
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_AlucardSprite, 0f);
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_AlucardSprite != null)
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
		tweenConfig.targets = array;
		float scaledAlpha = ScaledAlpha;
		tweenConfig.duration = 750f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}

	private unsafe void DashToPosition(Vector3 pos)
	{
		//IL_0033: Expected O, but got Ref
		if (_posTween != null)
		{
			TweenExtensions.Kill(_posTween);
		}
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOMove(_cachedTransform, (Vector3)(&obj), 0.75000006f);
		TweenCallback tweenCallback = delegate
		{
			SlashAttack();
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v4 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 9;
					_ = 0;
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_posTween = tweenerCore;
		Action onComplete = SetBodyForAlucard;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer bodyTimer = Timers.Register(0.65000004f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_bodyTimer = bodyTimer;
	}

	private void SlashAttack()
	{
		//IL_0099: Expected O, but got I4
		//IL_0121: Expected I4, but got F4
		_SwordSprite.enabled = true;
		_AlucardGlowSprite.enabled = true;
		_swordAnim.SetAnimation("sword_slash");
		_alucardAnim.SetAnimation("alucard_slash");
		_alucardGlowAnim.SetAnimation("alucard_glow");
		SetBodyForSlash();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_SwordSimple, soundConfig, 200f, 10, num);
		Action onComplete = OnSlashComplete;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer slashTimer = Timers.Register(0.2f, onComplete, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_slashTimer = slashTimer;
	}

	private unsafe void OnSlashComplete()
	{
		//IL_0471: Invalid comparison between F4 and I4
		//IL_0480: Expected O, but got I4
		//IL_048d: Expected O, but got Ref
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Expected O, but got Unknown
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Expected O, but got Unknown
		//IL_058e: Expected I, but got O
		//IL_05ba: Expected O, but got I
		//IL_06b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b5: Expected O, but got Unknown
		//IL_06da: Unknown result type (might be due to invalid IL or missing references)
		//IL_06df: Expected O, but got Unknown
		//IL_06fd: Expected O, but got I
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Expected O, but got Unknown
		//IL_0621: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Expected O, but got Unknown
		//IL_0648: Expected O, but got I
		//IL_0658: Expected O, but got I
		//IL_0675: Expected O, but got I
		//IL_0748: Unknown result type (might be due to invalid IL or missing references)
		//IL_074d: Expected O, but got Unknown
		//IL_0788: Unknown result type (might be due to invalid IL or missing references)
		//IL_078d: Expected O, but got Unknown
		//IL_057b->IL049b: Incompatible stack heights: 1 vs 0
		//IL_031c->IL049b: Incompatible stack heights: 1 vs 0
		//IL_02a6->IL049b: Incompatible stack heights: 1 vs 0
		//IL_02d5->IL049b: Incompatible stack heights: 1 vs 0
		//IL_083a->IL049b: Incompatible stack heights: 2 vs 0
		//IL_039b->IL049b: Incompatible stack heights: 2 vs 0
		//IL_07e9->IL049b: Incompatible stack heights: 3 vs 0
		//IL_03d9->IL049b: Incompatible stack heights: 3 vs 0
		//IL_0412->IL049b: Incompatible stack heights: 3 vs 0
		//IL_044c->IL049b: Incompatible stack heights: 3 vs 0
		bool flag = --_slashesRemaining > 0f;
		object obj = 0;
		TP_AlucardSword2_Projectile tP_AlucardSword2_Projectile = this;
		object obj3 = default(object);
		object obj2 = (object)(&obj3);
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 59 Invalid \"Jump target not found in method: 0x1870807A0\"");
			object obj4 = default(object);
			obj = obj4;
			TP_AlucardSword2_Projectile tP_AlucardSword2_Projectile2 = default(TP_AlucardSword2_Projectile);
			tP_AlucardSword2_Projectile = tP_AlucardSword2_Projectile2;
			object obj5 = default(object);
			obj2 = obj5;
		}
		BaseBody baseBody = tP_AlucardSword2_Projectile.body;
		object obj11;
		if (tP_AlucardSword2_Projectile.body != null)
		{
			baseBody._enable = false;
			if ((object)tP_AlucardSword2_Projectile._SwordSprite != null)
			{
				tP_AlucardSword2_Projectile._SwordSprite.enabled = false;
				if ((object)tP_AlucardSword2_Projectile._AlucardGlowSprite != null)
				{
					tP_AlucardSword2_Projectile._AlucardGlowSprite.enabled = false;
					if (tP_AlucardSword2_Projectile._objectsHit != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null)
							{
								PhaserScene.Renderer renderer = s_scene._renderer;
								if (s_scene._renderer != null && (object)GM.Core != null)
								{
									PhaserScene s_scene2 = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null)
									{
										PhaserScene.Renderer renderer2 = s_scene2._renderer;
										if (s_scene2._renderer != null)
										{
											float num = renderer.width * 0.35f;
											float num2 = renderer2.height * 0.35f;
											GameManager core = GM.Core;
											if (num > num2)
											{
												num = num2;
											}
											if ((object)GM.Core != null)
											{
												object cachedTransform = tP_AlucardSword2_Projectile._cachedTransform;
												if ((object)tP_AlucardSword2_Projectile._cachedTransform != null)
												{
													_ = 0;
													_ = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v10 (System.Object)+10]");
													bool flag2 = (nint)0 == 0;
													object obj6 = obj2 - 9;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdi_v10 (System.Object)+10]");
													Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj6);
													if ((object)core._stage != null)
													{
														Vector3 queryPos = (Vector3)(obj2 + 7);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbp_v2-9]");
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbp_v2-1]");
														_ = 0;
														EnemyController enemyController = core._stage.FindClosestEnemy(queryPos, excludeDead: true, num);
														nint num3 = (nint)typeof(Vector3);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v962 @ rcx_v36 (Il2CppClass<UnityEngine.Vector3>)+B8]");
														nint num4 = 0;
														_ = Vector3.zeroVector;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rdx_v26 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
														object obj7 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rdx_v26 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
														_ = 0;
														bool num5;
														if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
														{
															if ((object)enemyController._EnemyRenderer != null)
															{
																Transform transform = enemyController._EnemyRenderer.transform;
																if ((object)transform != null)
																{
																	_ = 0;
																	_ = 0;
																	bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
																	num5 = flag3;
																	object obj8 = obj2 - 9;
																	Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj8);
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbp_v2-9]");
																	object obj9 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbp_v2-1]");
																	object obj10 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbp_v2-9]");
																	_ = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbp_v2-9]");
																	obj11 = 0;
																	goto IL_081d;
																}
															}
														}
														else
														{
															Vector2 insideUnitCircle = UnityEngine.Random.insideUnitCircle;
															Transform transform2 = tP_AlucardSword2_Projectile.transform;
															if ((object)transform2 != null)
															{
																_ = 0;
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rax_v65 (UnityEngine.Transform)+10]");
																bool flag4 = (nint)0 == 0;
																num5 = flag4;
																object obj12 = obj2 - 9;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rax_v65 (UnityEngine.Transform)+10]");
																Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj12);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbp_v2-1]");
																obj7 = 0 + obj;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbp_v2-9]");
																nint num6 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbp_v2+67]");
																obj11 = num6 + 0;
																object obj10 = obj7;
																object obj13 = default(object);
																object obj9 = obj13;
																goto IL_081d;
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
		goto IL_049b;
		IL_049b:
		throw new NullReferenceException();
		IL_081d:
		if ((object)tP_AlucardSword2_Projectile._alucardAnim != null)
		{
			tP_AlucardSword2_Projectile._alucardAnim.SetAnimation("alucard_dash");
			Vector3 pos = (Vector3)(obj2 + 7);
			tP_AlucardSword2_Projectile.DashToPosition(pos);
			tP_AlucardSword2_Projectile.StartFadeIn();
			object cachedTransform2 = tP_AlucardSword2_Projectile._cachedTransform;
			if ((object)tP_AlucardSword2_Projectile._cachedTransform != null)
			{
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdi_v13 (System.Object)+10]");
				bool flag5 = (nint)0 == 0;
				object obj14 = obj2 - 9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdi_v13 (System.Object)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj14);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbp_v2-9]");
				bool flag6 = 0 < (nint)obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbp_v2-9]");
				object obj15 = 0 - obj11;
				bool flag7 = obj15 == null;
				bool flag8 = !flag6;
				bool flag9 = !flag7;
				bool flag10 = (tP_AlucardSword2_Projectile._cachedFlipX = flag9 & flag8);
				if ((object)tP_AlucardSword2_Projectile._AlucardSprite != null)
				{
					tP_AlucardSword2_Projectile._AlucardSprite.flipX = flag10;
					if ((object)tP_AlucardSword2_Projectile._AlucardGlowSprite != null)
					{
						tP_AlucardSword2_Projectile._AlucardGlowSprite.flipX = tP_AlucardSword2_Projectile._cachedFlipX;
						if ((object)tP_AlucardSword2_Projectile._SwordSprite != null)
						{
							bool flag11 = !tP_AlucardSword2_Projectile._cachedFlipX;
							tP_AlucardSword2_Projectile._SwordSprite.flipX = flag11;
							Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 851 Invalid \"Jump target not found in method: 0x187080D90\"");
						}
					}
				}
			}
		}
		goto IL_049b;
	}

	private void StartDespawn()
	{
		//IL_00a6: Expected I, but got O
		//IL_00fe: Expected I, but got O
		//IL_0156: Expected I, but got O
		//IL_01c8: Expected O, but got I4
		//IL_01e3: Expected I, but got O
		_swordAnim.SetAnimation("sword_followthrough");
		SpriteTrail spriteTrail = _spriteTrail.setVisible(b: false);
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[3];
		if ((object)_AlucardSprite != null)
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
		if ((object)_SwordSprite != null)
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
		if ((object)_AlucardGlowSprite != null)
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
		tweenConfig.targets = array;
		tweenConfig.duration = 500f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_AlucardSword2_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num4 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}

	private void SetBodyForAlucard()
	{
		//IL_0033: Expected O, but got I4
		//IL_0033: Expected O, but got I4
		BaseBody baseBody = body;
		baseBody._enable = true;
		BaseBody baseBody2 = body.setCircle(30f, (float?)(object)1, (float?)(object)1);
	}

	private void SetBodyForSlash()
	{
		//IL_0032: Expected O, but got I4
		//IL_0032: Expected O, but got I4
		//IL_0048: Expected F4, but got I8
		//IL_009d: Expected O, but got I4
		//IL_0065: Expected F4, but got I8
		BaseBody baseBody = body;
		baseBody._enable = true;
		BaseBody baseBody2 = body.setSize((float?)(object)1, (float?)(object)1);
		float x = 4.2949673E+09f;
		if (!_cachedFlipX)
		{
			x = 4.2949673E+09f;
		}
		BaseBody baseBody3 = body.setOffset(x, (float?)(object)1);
		Action onComplete = delegate
		{
			BaseBody baseBody4 = body;
			baseBody4._enable = false;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer bodyTimer = Timers.Register(0.25f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_bodyTimer = bodyTimer;
	}

	private void SetSwordOffset()
	{
		//IL_00bc: Expected O, but got I4
		//IL_010c->IL0085: Incompatible stack heights: 1 vs 0
		//IL_006c->IL0085: Incompatible stack heights: 1 vs 0
		SpriteRenderer swordSprite = _SwordSprite;
		if ((object)_SwordSprite != null)
		{
			bool flag = ((UnityEngine.Object)swordSprite).m_CachedPtr == (IntPtr)0;
			SpriteRenderer spriteRenderer = (SpriteRenderer)SpriteRenderer.get_flipX_Injected(((UnityEngine.Object)swordSprite).m_CachedPtr);
			float num = base.scale;
			if ((object)spriteRenderer == null)
			{
			}
			float num2 = base.scale;
			if ((object)_SwordSprite != null)
			{
				Transform transform = _SwordSprite.transform;
				SpriteRenderer cachedTransform = (SpriteRenderer)(object)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
					bool flag3 = (object)transform == null;
					bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public TP_AlucardSword2_Projectile()
	{
		//IL_03d0: Expected O, but got I
		//IL_042a: Expected O, but got I
		//IL_0955: Expected O, but got I
		//IL_0494: Expected O, but got I
		//IL_097d: Expected O, but got I
		//IL_04fe: Expected O, but got I
		//IL_09a5: Expected O, but got I
		//IL_0568: Expected O, but got I
		//IL_09cd: Expected O, but got I
		//IL_05d2: Expected O, but got I
		//IL_09f5: Expected O, but got I
		//IL_063c: Expected O, but got I
		//IL_0683: Expected O, but got I
		//IL_06dd: Expected O, but got I
		//IL_0a2c: Expected O, but got I
		//IL_0747: Expected O, but got I
		//IL_0a54: Expected O, but got I
		//IL_07b1: Expected O, but got I
		//IL_0a7c: Expected O, but got I
		//IL_081b: Expected O, but got I
		//IL_0aa4: Expected O, but got I
		//IL_0885: Expected O, but got I
		//IL_0acc: Expected O, but got I
		//IL_08f3: Expected O, but got I
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_AlucardSword");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_AlucardSwordB");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_AlucardSwordC");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_AlucardSwordD");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_AlucardSwordE");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_AlucardSwordF");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_swordSpriteNames = list;
		List<uint> list2 = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rdx_v17+18]");
		if (num >= 0)
		{
			list2.AddWithResize(16257040u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 16257040;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rdx_v19+18]");
		if (num2 >= 0)
		{
			list2.AddWithResize(12566463u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 12566463;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rdx_v21+18]");
		if (num3 >= 0)
		{
			list2.AddWithResize(49232u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 49232;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rdx_v23+18]");
		if (num4 >= 0)
		{
			list2.AddWithResize(57504u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 57504;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rdx_v25+18]");
		if (num5 >= 0)
		{
			list2.AddWithResize(15792168u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 15792168;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v27+18]");
		if (num6 >= 0)
		{
			list2.AddWithResize(5481433u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ rax_v16 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 5481433;
		}
		_glowTints = list2;
		List<float> list3 = new List<float>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rcx_v36+18]");
		if (num7 >= 0)
		{
			list3.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v32+18]");
		if (num8 >= 0)
		{
			list3.AddWithResize(0f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rcx_v40+18]");
		if (num9 >= 0)
		{
			list3.AddWithResize(1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 1065353216;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v34+18]");
		if (num10 >= 0)
		{
			list3.AddWithResize(1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 1065353216;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rcx_v44+18]");
		if (num11 >= 0)
		{
			list3.AddWithResize(-1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 3212836864L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rdx_v36+18]");
		if (num12 >= 0)
		{
			list3.AddWithResize(-1f);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1067 @ rax_v26 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 3212836864L;
		}
		_ghostYOffsets = list3;
		_ghostYOffsetMul = 50f;
		base._002Ector();
	}

	private void _003CDashToPosition_003Eb__32_0()
	{
		SlashAttack();
	}

	private void _003CSetBodyForSlash_003Eb__37_0()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
	}
}
