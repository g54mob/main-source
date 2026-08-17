using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Gear_Projectile : Projectile
{
	private float _radius = 16f;

	private PhaserSprite _animatedSprite;

	private PhaserSprite _animatedSprite2;

	private Tween _radiusTween;

	private MultiTargetTween _scaleTween;

	private float __force;

	private Tween _forceTween;

	private float _saveVelX;

	private float _saveVelY;

	private bool _isDespawning;

	private List<string> _framesFront;

	private List<string> _framesBack;

	private MultiTargetTween _angleTween;

	private Timer _expireTimer;

	private Timer _hitBoxTimer;

	private MultiTargetTween _angleTween2;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Gears10");
		_animatedSprite = animatedSprite;
		GameObject gameObject2 = base.gameObject;
		PhaserSprite animatedSprite2 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "ThosePeople", "TP_VFX_Gears09");
		_animatedSprite2 = animatedSprite2;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0bac: Expected O, but got I4
		//IL_0036: Expected O, but got I
		//IL_0036: Expected O, but got I
		//IL_00cc: Expected O, but got Ref
		//IL_013d: Expected O, but got Ref
		//IL_0c30: Expected O, but got Ref
		//IL_0ca3: Expected O, but got Ref
		//IL_0f9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa1: Expected O, but got Unknown
		//IL_0fb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbb: Expected O, but got Unknown
		//IL_0308: Expected O, but got I
		//IL_0308: Expected O, but got I
		//IL_031c: Expected O, but got I4
		//IL_0d0d: Expected O, but got F4
		//IL_0d73: Expected O, but got F4
		//IL_0d7c: Invalid comparison between O and F4
		//IL_0d92: Expected O, but got I8
		//IL_041e: Expected O, but got I4
		//IL_06f2: Expected O, but got I4
		//IL_0dae: Expected I, but got O
		//IL_0e06: Expected O, but got Ref
		//IL_1007: Expected O, but got F4
		//IL_07b6: Invalid comparison between O and F4
		//IL_07d6: Invalid comparison between F4 and I4
		//IL_0841: Expected O, but got I4
		//IL_0e2e: Expected I, but got O
		//IL_0e86: Expected O, but got Ref
		//IL_0903: Expected I4, but got I8
		//IL_0911: Expected I4, but got O
		//IL_0eec: Expected O, but got I4
		//IL_0970: Unknown result type (might be due to invalid IL or missing references)
		//IL_0975: Expected I4, but got Unknown
		//IL_0f10: Expected O, but got F4
		//IL_0a26: Expected O, but got I4
		//IL_0ac4: Expected I4, but got F4
		//IL_0b59: Expected I4, but got F4
		//IL_0c69->IL0b6d: Incompatible stack heights: 1 vs 0
		//IL_0295->IL0b6d: Incompatible stack heights: 1 vs 0
		//IL_02c4->IL0b6d: Incompatible stack heights: 1 vs 0
		//IL_0fda->IL0b6d: Incompatible stack heights: 2 vs 0
		//IL_036a->IL0b6d: Incompatible stack heights: 2 vs 0
		//IL_03bc->IL0b6d: Incompatible stack heights: 3 vs 0
		//IL_0468->IL0b6d: Incompatible stack heights: 3 vs 0
		//IL_04d9->IL0b6d: Incompatible stack heights: 3 vs 0
		//IL_04b7->IL04b7: Incompatible stack heights: 4 vs 3
		//IL_051e->IL0b6d: Incompatible stack heights: 3 vs 0
		//IL_05d4->IL0b6d: Incompatible stack heights: 3 vs 0
		//IL_0645->IL0b6d: Incompatible stack heights: 3 vs 0
		//IL_0623->IL0623: Incompatible stack heights: 4 vs 3
		//IL_06d9->IL0b6d: Incompatible stack heights: 3 vs 0
		//IL_0710->IL0b6d: Incompatible stack heights: 3 vs 0
		//IL_0743->IL0b6d: Incompatible stack heights: 3 vs 0
		//IL_0776->IL0b6d: Incompatible stack heights: 3 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		_isDespawning = false;
		_isCullable = false;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		_ = 0;
		_ = 0;
		_ = 3204448256L;
		_ = 1;
		_ = 3204448256L;
		_ = 1;
		if (body != null)
		{
			BaseBody baseBody = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
			BaseBody baseBody2 = baseBody.setCircle(1f, (float?)(object)num, (float?)(object)0);
			if ((object)_weapon != null)
			{
				float num2 = _weapon.PArea();
				if ((object)_animatedSprite != null)
				{
					Transform transform = _animatedSprite.transform;
					if ((object)transform != null)
					{
						_ = -0f;
						Vector3 localEulerAngles = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
						transform.localEulerAngles = localEulerAngles;
						if ((object)_animatedSprite2 != null)
						{
							Transform transform2 = _animatedSprite2.transform;
							if ((object)transform2 != null)
							{
								_ = -0f;
								Vector3 localEulerAngles2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
								transform2.localEulerAngles = localEulerAngles2;
								string text = Extensions.PickRnd(_framesFront);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
								if ((object)_animatedSprite != null)
								{
									Sprite sprite = default(Sprite);
									PhaserSprite phaserSprite = _animatedSprite.setFrame(sprite);
									string text2 = Extensions.PickRnd(_framesBack);
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
									if ((object)_animatedSprite2 != null)
									{
										Sprite sprite2 = default(Sprite);
										PhaserSprite phaserSprite2 = _animatedSprite2.setFrame(sprite2);
										PhaserSprite animatedSprite = _animatedSprite;
										if ((object)_animatedSprite != null && (object)animatedSprite._spriteRenderer != null)
										{
											Sprite sprite3 = animatedSprite._spriteRenderer.sprite;
											if ((object)sprite3 != null)
											{
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rax_v72 (UnityEngine.Sprite)+10]");
												bool flag = (nint)0 == 0;
												object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ rax_v72 (UnityEngine.Sprite)+10]");
												Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj3);
												PhaserSprite animatedSprite2 = _animatedSprite2;
												if ((object)_animatedSprite2 != null && (object)animatedSprite2._spriteRenderer != null)
												{
													Sprite sprite4 = animatedSprite2._spriteRenderer.sprite;
													if ((object)sprite4 != null)
													{
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rax_v77 (UnityEngine.Sprite)+10]");
														bool flag2 = (nint)0 == 0;
														object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rax_v77 (UnityEngine.Sprite)+10]");
														Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj4);
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-39]");
														float num3 = 0f * 0.5f;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
														float num4 = 0f * 0.5f;
														if (!(num4 > num3))
														{
															num4 = num3;
														}
														_ = 0;
														_ = 0;
														_radius = num4;
														float num6 = default(float);
														float num5 = num4 * num6;
														_ = 1;
														_ = 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
														object obj5 = num5 ^ 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
														object obj6 = num5 ^ 0;
														if (body != null)
														{
															BaseBody baseBody3 = body;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
															nint num7 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
															BaseBody baseBody4 = baseBody3.setCircle(num5, (float?)(object)num7, (float?)(object)0);
															ArcadeSprite arcadeSprite2 = setScale(0.35f, (float?)(object)0);
															object obj7 = UnityEngine.Random.value;
															float num8 = (float)obj6 * 0.5f;
															float num9 = num6 * 0.5f;
															float num10 = num8 * num6;
															float num11 = num10 + num9;
															if (_scaleTween != null)
															{
																_scaleTween.Kill();
															}
															TweenConfig tweenConfig = new TweenConfig();
															object[] array = new object[1];
															if (array != null)
															{
																object obj8 = array;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj9 = default(object);
																bool flag3 = obj9 == null;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																if (tweenConfig != null)
																{
																	_ = 0;
																	_ = 1128792064;
																	_ = 1;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
																	_ = 0;
																	MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
																	_scaleTween = scaleTween;
																	object obj10 = UnityEngine.Random.value;
																	bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f);
																	object obj11 = 4294966936L;
																	if (!flag4)
																	{
																		obj11 = 360;
																	}
																	if (_angleTween != null)
																	{
																		_angleTween.Kill();
																	}
																	TweenConfig tweenConfig2 = new TweenConfig();
																	object[] array2 = new object[1];
																	if (array2 != null)
																	{
																		if ((object)_animatedSprite != null)
																		{
																			object obj12 = array2;
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																			object obj13 = default(object);
																			bool flag5 = obj13 == null;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																		if (tweenConfig2 != null)
																		{
																			_ = 0;
																			_ = 1;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
																			_ = 0;
																			if ((object)weapon != null)
																			{
																				float num12 = weapon.PSpeed();
																				float num13 = 2000f / (float)obj11;
																				_ = 4294967295L;
																				MultiTargetTween angleTween = Tweens.Add(tweenConfig2);
																				_angleTween = angleTween;
																				if (_angleTween2 != null)
																				{
																					_angleTween2.Kill();
																				}
																				TweenConfig tweenConfig3 = new TweenConfig();
																				object[] array3 = new object[1];
																				if (array3 != null)
																				{
																					if ((object)_animatedSprite2 != null)
																					{
																						object obj14 = array3;
																						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																						object obj15 = default(object);
																						bool flag6 = obj15 == null;
																					}
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																					if (tweenConfig3 != null)
																					{
																						_ = 0;
																						_ = 1;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
																						_ = 0;
																						float num14 = weapon.PSpeed();
																						float num15 = 3000f / (float)obj11;
																						_ = 4294967295L;
																						MultiTargetTween angleTween2 = Tweens.Add(tweenConfig3);
																						_angleTween2 = angleTween2;
																						if ((object)_animatedSprite != null)
																						{
																							PhaserSprite phaserSprite3 = _animatedSprite.setScale(num6, (float?)(object)0);
																							if ((object)_animatedSprite != null)
																							{
																								PhaserSprite phaserSprite4 = _animatedSprite.setAlpha(1f);
																								if ((object)_animatedSprite != null)
																								{
																									PhaserSprite phaserSprite5 = _animatedSprite.setVisible(visible: true);
																									if ((object)_animatedSprite != null)
																									{
																										Transform transform3 = _animatedSprite.transform;
																										nint num16 = (nint)typeof(Vector3);
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1922 @ rcx_v116 (Il2CppClass<UnityEngine.Vector3>)+B8]");
																										nint num17 = 0;
																										bool flag7 = (object)transform3 == null;
																										_ = Vector3.zeroVector;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1916 @ rax_v134 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
																										_ = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2540 @ rax_v132 (UnityEngine.Transform)+10]");
																										bool flag8 = (nint)0 == 0;
																										object obj16 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2540 @ rax_v132 (UnityEngine.Transform)+10]");
																										Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj16);
																										object obj17 = UnityEngine.Random.value;
																										bool flag9 = (object)_animatedSprite2 == null;
																										bool flag10 = System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref Vector3.zeroVector) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f);
																										float num18 = (float)Vector3.zeroVector - 0.5f;
																										bool flag11 = num18 == 0f;
																										bool flag12 = !flag10;
																										bool flag13 = !flag11;
																										bool visible = flag13 & flag12;
																										PhaserSprite phaserSprite6 = _animatedSprite2.setVisible(visible);
																										bool flag14 = (object)_animatedSprite2 == null;
																										PhaserSprite phaserSprite7 = _animatedSprite2.setScale(num6, (float?)(object)0);
																										bool flag15 = (object)_animatedSprite2 == null;
																										PhaserSprite phaserSprite8 = _animatedSprite2.setAlpha(1f);
																										bool flag16 = (object)_animatedSprite2 == null;
																										PhaserSprite phaserSprite9 = _animatedSprite2.setVisible(visible: true);
																										bool flag17 = (object)_animatedSprite2 == null;
																										Transform transform4 = _animatedSprite2.transform;
																										nint num19 = (nint)typeof(Vector3);
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1309 @ rdx_v92 (Il2CppClass<UnityEngine.Vector3>)+B8]");
																										nint num20 = 0;
																										bool flag18 = (object)transform4 == null;
																										_ = Vector3.zeroVector;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1758 @ rax_v149 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
																										_ = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2630 @ rax_v147 (UnityEngine.Transform)+10]");
																										bool flag19 = (nint)0 == 0;
																										object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2630 @ rax_v147 (UnityEngine.Transform)+10]");
																										Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj18);
																										bool flag20 = (object)_animatedSprite == null;
																										PhaserSprite phaserSprite10 = _animatedSprite.setDepth(-1998);
																										int num21 = (int)_animatedSprite;
																										bool flag21 = (object)_animatedSprite == null;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1771 @ rdi_v33 (System.Int32)+28]");
																										int num22 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1771 @ rdi_v33 (System.Int32)+28]");
																										bool flag22 = (nint)0 == 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1458 @ rdi_v34 (System.Int32)+10]");
																										bool flag23 = (nint)0 == 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1458 @ rdi_v34 (System.Int32)+10]");
																										object obj19 = Renderer.get_sortingOrder_Injected((IntPtr)0);
																										bool flag24 = (object)_animatedSprite2 == null;
																										int num23 = obj19 - 1;
																										PhaserSprite phaserSprite11 = _animatedSprite2.setDepth(num23);
																										SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
																										{
																											Rate = 0.8f
																										};
																										object obj20 = UnityEngine.Random.value;
																										_ = 0;
																										float num24 = (float)Vector3.zeroVector - 0.5f;
																										_ = 1060320051;
																										_ = 1;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
																										_ = 0;
																										float num25 = num24 * 300f;
																										float num26 = default(float);
																										PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_PocketWatch3, soundConfig, 200f, 5, num26);
																										float num27 = weapon.PHitBoxDelayOverSpeed();
																										GameManager core = GM.Core;
																										bool flag25 = (object)GM.Core == null;
																										bool flag26 = !core._003CIsTimeStopped_003Ek__BackingField;
																										bool flag27 = !flag26;
																										object obj21 = (flag27 ? 1 : 0) + 1;
																										float num28 = num25 / (float)obj21;
																										if (_expireTimer != null)
																										{
																											_expireTimer.Cancel();
																										}
																										float num29 = weapon.PDuration();
																										Action onComplete = StartDespawn;
																										float duration = num25 * 0.001f;
																										MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																										int repeat = default(int);
																										TimerType type = default(TimerType);
																										Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, (byte)(int)num26 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																										_expireTimer = expireTimer;
																										if (_hitBoxTimer != null)
																										{
																											_hitBoxTimer.Cancel();
																										}
																										Action onComplete2 = delegate
																										{
																											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
																										};
																										float duration2 = num28 * 0.001f;
																										Timer hitBoxTimer = Timers.Register(duration2, onComplete2, null, isLooped: true, (byte)(int)num26 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																										_hitBoxTimer = hitBoxTimer;
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

	private void StartDespawn()
	{
		//IL_0069: Expected I, but got O
		//IL_00cd: Expected O, but got I4
		//IL_00e8: Expected I, but got O
		if (!_isDespawning)
		{
			_isDespawning = true;
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Gear_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
		}
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_forceTween != null)
		{
			TweenExtensions.Kill(_forceTween);
		}
		if (_hitBoxTimer != null)
		{
			_hitBoxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}

	public TP_Gear_Projectile()
	{
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Gears10");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Gears11");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Gears14");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Gears15");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Gears17");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_framesFront = list;
		List<string> list2 = new List<string>();
		list2._version++;
		string[] items6 = list2._items;
		if (list2._size >= items6.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Gears09");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items7 = list2._items;
		if (list2._size >= items7.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Gears13");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items8 = list2._items;
		if (list2._size >= items8.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Gears09");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items9 = list2._items;
		if (list2._size >= items9.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Gears13");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items10 = list2._items;
		if (list2._size >= items10.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Gears09");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items11 = list2._items;
		if (list2._size >= items11.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Gears13");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items12 = list2._items;
		if (list2._size >= items12.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Gears09");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items13 = list2._items;
		if (list2._size >= items13.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Gears13");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items14 = list2._items;
		if (list2._size >= items14.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Gears19");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_framesBack = list2;
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__17_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
