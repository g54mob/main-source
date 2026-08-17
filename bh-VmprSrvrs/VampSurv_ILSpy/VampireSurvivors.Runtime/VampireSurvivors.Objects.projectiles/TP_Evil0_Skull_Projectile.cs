using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.VFX;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Evil0_Skull_Projectile : Projectile
{
	private float _radius = 20f;

	private Tween _radiusTween;

	private PhaserSprite _animatedSprite;

	private PhaserSprite _jawSprite;

	private PhaserSprite _animatedSprite2;

	private PhaserSprite _jawSprite2;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private Timer _hitboxTimer;

	private Timer _expireTimer;

	private bool _isDespawning;

	private TP_Evil1_Weapon _trueWeapon;

	private float _direction;

	private Vector3 _cursorOffset;

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
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)3f))
				{
					return 0.8f;
				}
				float num2 = (float)obj - 1f;
				float num3 = num2 * 0.19999999f;
				float num4 = num3 * 0.5f;
				result = 1f - num4;
			}
			return result;
		}
	}

	protected override void Awake()
	{
		//IL_0151: Expected O, but got I4
		//IL_0151: Expected I4, but got O
		//IL_01ae: Expected O, but got I4
		//IL_01ae: Expected I4, but got O
		//IL_02db: Expected O, but got I4
		//IL_02db: Expected I4, but got O
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Curse01");
		GameObject gameObject2 = phaserSprite.gameObject;
		((UnityEngine.Object)gameObject2).SetName("_animatedSprite");
		_animatedSprite = phaserSprite;
		GameObject gameObject3 = base.gameObject;
		PhaserSprite phaserSprite2 = RenderingExtensions.AddPhaserSprite(gameObject3, vector, "ThosePeople", "TP_VFX_Curse01");
		GameObject gameObject4 = phaserSprite2.gameObject;
		((UnityEngine.Object)gameObject4).SetName("_animatedSprite2");
		_animatedSprite2 = phaserSprite2;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Curse", 1, 4, vector, text, num, flag);
		PhaserSprite animatedSprite = _animatedSprite;
		bool autoSetAnimation = default(bool);
		animatedSprite._spriteAnimation.AddAnimation("loop", animationFrames, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite animatedSprite2 = _animatedSprite;
		animatedSprite2._spriteAnimation.SetAnimation("loop");
		PhaserSprite animatedSprite3 = _animatedSprite2;
		animatedSprite3._spriteAnimation.AddAnimation("loop", animationFrames, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite animatedSprite4 = _animatedSprite2;
		animatedSprite4._spriteAnimation.SetAnimation("loop");
		GameObject gameObject5 = base.gameObject;
		PhaserSprite phaserSprite3 = RenderingExtensions.AddPhaserSprite(gameObject5, vector, "ThosePeople", "TP_VFX_Curse05");
		GameObject gameObject6 = phaserSprite3.gameObject;
		((UnityEngine.Object)gameObject6).SetName("_jawSprite");
		_jawSprite = phaserSprite3;
		GameObject gameObject7 = base.gameObject;
		PhaserSprite phaserSprite4 = RenderingExtensions.AddPhaserSprite(gameObject7, vector, "ThosePeople", "TP_VFX_Curse05");
		GameObject gameObject8 = phaserSprite4.gameObject;
		((UnityEngine.Object)gameObject8).SetName("_jawSprite2");
		_jawSprite2 = phaserSprite4;
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_VFX_Curse", 5, 6, vector, text, num, flag);
		PhaserSprite jawSprite = _jawSprite;
		jawSprite._spriteAnimation.AddAnimation("curse", animationFrames2, 8, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite phaserSprite5 = _animatedSprite2.setTintFill(isEnabled: true, 0u);
		PhaserSprite phaserSprite6 = _jawSprite2.setTintFill(isEnabled: true, 0u);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0029: Expected I, but got O
		//IL_0031: Expected I, but got O
		//IL_0041: Expected O, but got I
		//IL_00c1: Expected O, but got I4
		//IL_0016: Expected O, but got I4
		//IL_0ba4: Expected O, but got I
		//IL_0bad: Expected O, but got I4
		//IL_007d: Expected O, but got I
		//IL_00ce: Expected O, but got I
		//IL_00b3: Expected O, but got I4
		//IL_0193: Expected I4, but got I8
		//IL_0c68: Expected F4, but got I4
		//IL_0ca4: Invalid comparison between I4 and F4
		//IL_0cb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cba: Expected O, but got Unknown
		//IL_0d15: Expected F4, but got I4
		//IL_0201: Expected I4, but got I8
		//IL_02bf: Expected O, but got I4
		//IL_0313: Expected O, but got I4
		//IL_0313: Expected O, but got I4
		//IL_0356: Expected O, but got I4
		//IL_0395: Expected O, but got F4
		//IL_0adc: Expected O, but got I4
		//IL_0b2a: Expected F4, but got I4
		//IL_0d06->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_01c9->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_0233->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_0265->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_0297->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_02f2->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_0332->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_0438->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_0487->IL0487: Incompatible stack heights: 6 vs 5
		//IL_04db->IL04db: Incompatible stack heights: 6 vs 5
		//IL_05a5->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_052f->IL052f: Incompatible stack heights: 6 vs 5
		//IL_0583->IL0583: Incompatible stack heights: 6 vs 5
		//IL_062b->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_066c->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_06e8->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_07ad->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_0737->IL0737: Incompatible stack heights: 6 vs 5
		//IL_078b->IL078b: Incompatible stack heights: 6 vs 5
		//IL_0887->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_0920->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_09b4->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_0d42->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_0a1a->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_0a5a->IL0b2f: Incompatible stack heights: 5 vs 0
		//IL_0a9a->IL0b2f: Incompatible stack heights: 5 vs 0
		base.InitProjectile(pool, weapon, index);
		_isDespawning = false;
		_isCullable = false;
		float? trueWeapon;
		Weapon weapon2;
		if ((object)weapon == null)
		{
			weapon2 = weapon;
			trueWeapon = (float?)(object)0;
			goto IL_0b7e;
		}
		nint num = (nint)typeof(TP_Evil1_Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v120 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Evil1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v88 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v120 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Evil1_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v88 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v203+FFFFFFF8+v71 @ rax_v198*8]");
			if (0 == (nint)typeof(TP_Evil1_Weapon))
			{
				obj3 = 1;
				goto IL_0b8d;
			}
		}
		obj3 = 0;
		goto IL_0b8d;
		IL_0b8d:
		bool flag = obj3 == null;
		weapon2 = (Weapon)num2;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			weapon2 = (Weapon)num2;
			trueWeapon = (float?)weapon;
		}
		goto IL_0b7e;
		IL_0b7e:
		_trueWeapon = (TP_Evil1_Weapon)trueWeapon;
		if ((object)_animatedSprite != null)
		{
			Transform transform = _animatedSprite.transform;
			bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			Transform transform2 = _jawSprite.transform;
			bool flag3 = (object)transform2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1180 @ rax_v47 (UnityEngine.Transform)+10]");
			bool flag4 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1180 @ rax_v47 (UnityEngine.Transform)+10]");
			Vector3 value2 = default(Vector3);
			Transform.set_localPosition_Injected((IntPtr)0, ref value2);
			SyncSprites();
			bool flag5 = (object)weapon == null;
			bool flag6 = (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null;
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			float2 float6 = base.position;
			bool flag7 = (byte)(float5 <= float6) != 0;
			bool flag8 = true;
			if (!flag7)
			{
				flag8 = true;
			}
			_direction = (flag8 ? 1 : 0);
			float2 float7 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
			object obj4 = default(object);
			if (obj4 != null)
			{
				if ((object)_trueWeapon == null)
				{
					goto IL_0b2f;
				}
				bool isPrimaryWeapon = _trueWeapon.IsPrimaryWeapon;
				bool flag9 = true;
				if (!isPrimaryWeapon)
				{
					flag9 = true;
				}
				_direction = (flag9 ? 1 : 0);
			}
			bool flag10 = 0f < _direction;
			object obj5 = 0 - _direction;
			bool flag11 = obj5 == null;
			bool flag12 = !flag10;
			bool flag13 = !flag11;
			bool flag14 = flag13 & flag12;
			if ((object)_animatedSprite != null)
			{
				PhaserSprite phaserSprite = _animatedSprite.setFlipX(flag14);
				if ((object)_animatedSprite2 != null)
				{
					PhaserSprite phaserSprite2 = _animatedSprite2.setFlipX(flag14);
					if ((object)_jawSprite != null)
					{
						PhaserSprite phaserSprite3 = _jawSprite.setFlipX(flag14);
						if ((object)_jawSprite2 != null)
						{
							PhaserSprite phaserSprite4 = _jawSprite2.setFlipX(flag14);
							ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
							float num4 = _radius ^ -0f;
							if (body != null)
							{
								BaseBody baseBody = body.setCircle(_radius, (float?)(object)1, (float?)(object)1);
								if ((object)_weapon != null)
								{
									float num5 = _weapon.PArea();
									ArcadeSprite arcadeSprite2 = setScale(num4, (float?)(object)0);
									float2 float8 = base.position;
									float num6 = _radius * 0.01f;
									float2 cursorOffset = default(float2);
									base.position = cursorOffset;
									object obj6 = _radius ^ -0f;
									float num7 = (float)obj6 * 0.01f;
									float num8 = num7 * num4;
									float num9 = num8 * 0.65f;
									_cursorOffset = (Vector3)cursorOffset;
									_ = 0;
									if (_scaleTween != null)
									{
										_scaleTween.Kill();
									}
									TweenConfig tweenConfig = new TweenConfig();
									object[] array = new object[4];
									if (array != null)
									{
										if ((object)_animatedSprite != null)
										{
											object obj7 = array;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj8 = default(object);
											bool flag15 = obj8 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if ((object)_jawSprite != null)
										{
											object obj9 = array;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj10 = default(object);
											bool flag16 = obj10 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if ((object)_animatedSprite2 != null)
										{
											object obj11 = array;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj12 = default(object);
											bool flag17 = obj12 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if ((object)_jawSprite2 != null)
										{
											object obj13 = array;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj14 = default(object);
											bool flag18 = obj14 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if (tweenConfig != null)
										{
											_ = 1128792064;
											_ = 4;
											_ = 1;
											TweenCallback tweenCallback = delegate
											{
												//IL_001a: Expected O, but got I4
												//IL_0038: Expected O, but got I4
												//IL_0056: Expected O, but got I4
												//IL_0074: Expected O, but got I4
												PhaserSprite phaserSprite11 = _animatedSprite.setScale(0f, (float?)(object)1);
												PhaserSprite phaserSprite12 = _jawSprite.setScale(0f, (float?)(object)1);
												PhaserSprite phaserSprite13 = _animatedSprite2.setScale(0f, (float?)(object)1);
												PhaserSprite phaserSprite14 = _jawSprite2.setScale(0f, (float?)(object)1);
											};
											MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
											_scaleTween = scaleTween;
											float scaledAlpha = ScaledAlpha;
											if ((object)_animatedSprite != null)
											{
												PhaserSprite phaserSprite5 = _animatedSprite.setAlpha(scaledAlpha);
												float scaledAlpha2 = ScaledAlpha;
												if ((object)_jawSprite != null)
												{
													PhaserSprite phaserSprite6 = _jawSprite.setAlpha(scaledAlpha2);
													if (_alphaTween != null)
													{
														_alphaTween.Kill();
													}
													TweenConfig tweenConfig2 = new TweenConfig();
													object[] array2 = new object[2];
													if (array2 != null)
													{
														if ((object)_animatedSprite2 != null)
														{
															object obj15 = array2;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj16 = default(object);
															bool flag19 = obj16 == null;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if ((object)_jawSprite2 != null)
														{
															object obj17 = array2;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj18 = default(object);
															bool flag20 = obj18 == null;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if (tweenConfig2 != null)
														{
															_ = 1128792064;
															_ = 1;
															_ = 1;
															TweenCallback tweenCallback2 = delegate
															{
																float scaledAlpha3 = ScaledAlpha;
																PhaserSprite phaserSprite11 = _animatedSprite2.setAlpha(scaledAlpha3);
																float scaledAlpha4 = ScaledAlpha;
																PhaserSprite phaserSprite12 = _jawSprite2.setAlpha(scaledAlpha4);
															};
															MultiTargetTween alphaTween = Tweens.Add(tweenConfig2);
															_alphaTween = alphaTween;
															if (_hitboxTimer != null)
															{
																_hitboxTimer.Cancel();
															}
															if (_expireTimer != null)
															{
																_expireTimer.Cancel();
															}
															if ((object)_weapon != null)
															{
																float hitBoxDelay = _weapon.HitBoxDelay;
																Action onComplete = FireRunes;
																float num10 = hitBoxDelay * 0.001f;
																bool flag21 = default(bool);
																MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																int repeat = default(int);
																TimerType type = default(TimerType);
																Timer hitboxTimer = Timers.Register(num10, onComplete, null, isLooped: true, flag21, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																_hitboxTimer = hitboxTimer;
																if ((object)_weapon != null)
																{
																	float num11 = _weapon.PDuration();
																	Action onComplete2 = StartDespawn;
																	float duration = num10 * 0.001f;
																	Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: false, flag21, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																	_expireTimer = expireTimer;
																	if ((object)_trueWeapon != null)
																	{
																		bool isPrimaryWeapon2 = _trueWeapon.IsPrimaryWeapon;
																		int num12 = 4;
																		if (!isPrimaryWeapon2)
																		{
																			num12 = 7;
																		}
																		ArcadeSprite arcadeSprite3 = setDepth(num12);
																		if ((object)_animatedSprite != null)
																		{
																			PhaserSprite phaserSprite7 = _animatedSprite.setDepth(num12);
																			if ((object)_animatedSprite2 != null)
																			{
																				int num13 = num12 + 1;
																				PhaserSprite phaserSprite8 = _animatedSprite2.setDepth(num13);
																				if ((object)_jawSprite != null)
																				{
																					int num14 = num12 - 1;
																					PhaserSprite phaserSprite9 = _jawSprite.setDepth(num14);
																					if ((object)_jawSprite2 != null)
																					{
																						int num15 = num12 + 1;
																						PhaserSprite phaserSprite10 = _jawSprite2.setDepth(num15);
																						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
																						{
																							Volume = (float?)(object)1,
																							Rate = 1f
																						};
																						float detune = (float)_indexInWeapon * 100f;
																						soundConfig.Detune = detune;
																						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.FireExplosion, soundConfig, 150f, 3, flag21 ? 1 : 0);
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
		goto IL_0b2f;
		IL_0b2f:
		throw new NullReferenceException();
	}

	private unsafe void FireRunes()
	{
		//IL_00ce: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		PhaserSprite jawSprite = _jawSprite;
		jawSprite._spriteAnimation.SetAnimation("curse");
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		_trueWeapon.FireProjectiles(pos, _direction);
		float hitBoxDelay = _weapon.HitBoxDelay;
		ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.SpellcastingCursor);
		SpellcastingCursorVFX objectComponent = pool.GetObjectComponent<SpellcastingCursorVFX>();
		float2 float6 = base.position;
		Vector3 vector = default(Vector3);
		float num = default(float);
		string texture = default(string);
		string text = default(string);
		bool flip = default(bool);
		objectComponent.Display(1, hitBoxDelay, (Vector3)(&vector), num, texture, text, flip);
	}

	private void StartDespawn()
	{
		//IL_00ec: Expected I, but got O
		//IL_0144: Expected I, but got O
		//IL_019c: Expected I, but got O
		//IL_01f4: Expected I, but got O
		//IL_024a: Expected O, but got I4
		//IL_0274: Expected O, but got I4
		//IL_028f: Expected I, but got O
		//IL_0340: Expected I, but got O
		//IL_0398: Expected I, but got O
		//IL_0414: Expected O, but got I4
		if (_isDespawning)
		{
			return;
		}
		_isDespawning = true;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		SyncSprites();
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[4];
		if ((object)_animatedSprite != null)
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
		if ((object)_jawSprite != null)
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
		if ((object)_animatedSprite2 != null)
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
		if ((object)_jawSprite2 != null)
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
		tweenConfig.targets = array;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.duration = 200f;
		tweenConfig.ease = Ease.InOutSine;
		tweenConfig.scaleY = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Evil0_Skull_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num5 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[2];
		if ((object)_animatedSprite2 != null)
		{
			nint num6 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_jawSprite2 != null)
		{
			nint num7 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
				throw ex6;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		float scaledAlpha = ScaledAlpha;
		tweenConfig2.duration = 200f;
		tweenConfig2.ease = Ease.Linear;
		tweenConfig2.alpha = (float?)(object)1;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig2);
		_alphaTween = alphaTween;
		Weapon weapon = _weapon;
		if (weapon._explodeOnExpire)
		{
			float2 pos = base.position;
			Projectile projectile = weapon.SpawnExplosionAt(pos, 0, 1, 0f);
		}
	}

	private void SyncSprites()
	{
		PhaserSprite animatedSprite = _animatedSprite2;
		PhaserSprite animatedSprite2 = _animatedSprite;
		Sprite sprite = animatedSprite2._spriteRenderer.sprite;
		animatedSprite._spriteRenderer.sprite = sprite;
		PhaserSprite jawSprite = _jawSprite2;
		PhaserSprite jawSprite2 = _jawSprite;
		Sprite sprite2 = jawSprite2._spriteRenderer.sprite;
		jawSprite._spriteRenderer.sprite = sprite2;
	}

	public override void Despawn()
	{
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_radiusTween != null)
		{
			TweenExtensions.Kill(_radiusTween);
		}
		base.Despawn();
	}

	private unsafe void DisplayCursorVFX(int _times, float _duration)
	{
		//IL_005e: Expected O, but got Ref
		ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.SpellcastingCursor);
		SpellcastingCursorVFX objectComponent = pool.GetObjectComponent<SpellcastingCursorVFX>();
		float2 float5 = base.position;
		float2 float6 = default(float2);
		float num = default(float);
		string texture = default(string);
		string text = default(string);
		bool flip = default(bool);
		objectComponent.Display(_times, _duration, (Vector3)(&float6), num, texture, text, flip);
	}

	private void _003CInitProjectile_003Eb__17_0()
	{
		//IL_001a: Expected O, but got I4
		//IL_0038: Expected O, but got I4
		//IL_0056: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		PhaserSprite phaserSprite = _animatedSprite.setScale(0f, (float?)(object)1);
		PhaserSprite phaserSprite2 = _jawSprite.setScale(0f, (float?)(object)1);
		PhaserSprite phaserSprite3 = _animatedSprite2.setScale(0f, (float?)(object)1);
		PhaserSprite phaserSprite4 = _jawSprite2.setScale(0f, (float?)(object)1);
	}

	private void _003CInitProjectile_003Eb__17_1()
	{
		float scaledAlpha = ScaledAlpha;
		PhaserSprite phaserSprite = _animatedSprite2.setAlpha(scaledAlpha);
		float scaledAlpha2 = ScaledAlpha;
		PhaserSprite phaserSprite2 = _jawSprite2.setAlpha(scaledAlpha2);
	}
}
