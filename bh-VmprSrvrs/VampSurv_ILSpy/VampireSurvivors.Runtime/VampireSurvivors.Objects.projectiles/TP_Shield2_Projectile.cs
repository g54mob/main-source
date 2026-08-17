using System;
using System.Collections.Generic;
using System.Threading;
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
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Shield2_Projectile : Projectile
{
	private float _bodyRadius = 20f;

	private PhaserSprite _displaySprite1;

	private PhaserSprite _displaySprite2;

	private MultiTargetTween _alphaTween1;

	private MultiTargetTween _alphaTween2;

	private VampireSurvivors.Framework.TimerSystem.Timer _hitBoxTimer;

	private VampireSurvivors.Framework.TimerSystem.Timer _durationTimer;

	private TP_Shield2_Weapon _trueWeapon;

	private VampireSurvivors.Framework.TimerSystem.Timer _selfDelayTimer;

	private bool _canShoot = true;

	private PhaserSprite _displaySprite3;

	private MultiTargetTween _alphaTween3;

	protected override void Awake()
	{
		//IL_00fe: Expected O, but got I4
		//IL_01b0: Expected O, but got I4
		//IL_01b0: Expected I4, but got O
		//IL_022f: Expected O, but got I4
		//IL_02f0: Expected O, but got I4
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				GameObject gameObject = base.gameObject;
				Vector2 vector = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_ShieldDark01");
				if ((object)phaserSprite != null)
				{
					PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
					if ((object)phaserSprite2 != null)
					{
						PhaserSprite displaySprite = phaserSprite2.setScale(1.2f, (float?)(object)0);
						_displaySprite1 = displaySprite;
						string text = default(string);
						int num = default(int);
						bool flag = default(bool);
						List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_ShieldDark", 10, 24, vector, text, num, flag);
						PhaserSprite displaySprite2 = _displaySprite1;
						if ((object)_displaySprite1 != null && (object)displaySprite2._spriteAnimation != null)
						{
							bool autoSetAnimation = default(bool);
							displaySprite2._spriteAnimation.AddAnimation("loop", animationFrames, 32, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
							GameObject gameObject2 = base.gameObject;
							PhaserSprite phaserSprite3 = RenderingExtensions.AddPhaserSprite(gameObject2, vector, "ThosePeople", "TP_VFX_ShieldDark25");
							if ((object)phaserSprite3 != null)
							{
								PhaserSprite phaserSprite4 = phaserSprite3.setAlpha(0f);
								if ((object)phaserSprite4 != null)
								{
									PhaserSprite phaserSprite5 = phaserSprite4.setScale(1.2f, (float?)(object)0);
									if ((object)phaserSprite5 != null)
									{
										PhaserSprite displaySprite3 = phaserSprite5.setBlendMode(BlendMode.Add);
										_displaySprite2 = displaySprite3;
										GameObject gameObject3 = base.gameObject;
										PhaserSprite phaserSprite6 = RenderingExtensions.AddPhaserSprite(gameObject3, vector, "ThosePeople", "TP_VFX_ShieldDark03");
										if ((object)phaserSprite6 != null)
										{
											PhaserSprite phaserSprite7 = phaserSprite6.setAlpha(0f);
											if ((object)phaserSprite7 != null)
											{
												PhaserSprite displaySprite4 = phaserSprite7.setOrigin(0.5f, (float?)(object)1);
												_displaySprite3 = displaySprite4;
												if ((object)_displaySprite3 != null)
												{
													Transform transform = _displaySprite3.transform;
													if ((object)transform != null)
													{
														bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
														Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
														_canShoot = true;
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
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_08c0: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_03b4: Expected I, but got O
		//IL_03c7: Expected O, but got I4
		//IL_0427: Expected O, but got I4
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0442: Expected F4, but got Unknown
		//IL_047d: Expected O, but got I4
		//IL_047d: Expected O, but got I4
		//IL_0517: Expected O, but got I4
		//IL_05e9: Expected I, but got O
		//IL_0661: Expected O, but got I4
		//IL_070a: Expected O, but got I4
		//IL_0782: Expected O, but got I4
		//IL_09ad: Expected O, but got F4
		//IL_09ca: Expected I4, but got F4
		//IL_084a: Expected F4, but got I4
		//IL_02c2->IL0854: Incompatible stack heights: 1 vs 0
		//IL_0283->IL0854: Incompatible stack heights: 1 vs 0
		//IL_032c->IL0854: Incompatible stack heights: 1 vs 0
		//IL_03a2->IL0854: Incompatible stack heights: 1 vs 0
		//IL_0380->IL0380: Incompatible stack heights: 2 vs 1
		//IL_045c->IL0854: Incompatible stack heights: 1 vs 0
		//IL_049b->IL0854: Incompatible stack heights: 1 vs 0
		//IL_099f->IL0854: Incompatible stack heights: 1 vs 0
		//IL_0540->IL0854: Incompatible stack heights: 1 vs 0
		//IL_05bd->IL0854: Incompatible stack heights: 1 vs 0
		//IL_062e->IL0854: Incompatible stack heights: 1 vs 0
		//IL_060c->IL060c: Incompatible stack heights: 2 vs 1
		//IL_07af->IL0854: Incompatible stack heights: 1 vs 0
		//IL_07de->IL0854: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0899;
		}
		nint num = (nint)typeof(TP_Shield2_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v88 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Shield2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r9_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v88 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Shield2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r9_v25 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v154+FFFFFFF8+v72 @ rax_v149*8]");
			if (0 == (nint)typeof(TP_Shield2_Weapon))
			{
				obj3 = 1;
				goto IL_08a8;
			}
		}
		obj3 = 0;
		goto IL_08a8;
		IL_08a8:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_0899;
		IL_0899:
		_trueWeapon = (TP_Shield2_Weapon)trueWeapon;
		if ((object)_displaySprite1 != null)
		{
			float2 localPosition = default(float2);
			PhaserSprite phaserSprite = _displaySprite1.setLocalPosition(localPosition);
			if ((object)_displaySprite2 != null)
			{
				PhaserSprite phaserSprite2 = _displaySprite2.setLocalPosition(localPosition);
				_canShoot = true;
				if ((object)_displaySprite3 != null)
				{
					PhaserSprite phaserSprite3 = _displaySprite3.setVisible(visible: true);
					if ((object)weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
					{
						Transform parent = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
						if ((object)_displaySprite3 != null)
						{
							Transform transform = _displaySprite3.transform;
							if ((object)transform != null)
							{
								transform.SetParent(parent, worldPositionStays: true);
								if ((object)_displaySprite3 != null)
								{
									Transform transform2 = _displaySprite3.transform;
									bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
									Vector3 value = default(Vector3);
									Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
									PhaserSprite phaserSprite4 = _displaySprite3.setAlpha(0.25f);
									Weapon weapon3 = _weapon;
									uint bottomLeft;
									uint topLeft;
									uint topRight;
									if (!((Equipment)weapon3)._003COwner_003Ek__BackingField.flipX)
									{
										if ((object)_displaySprite3 == null)
										{
											goto IL_0854;
										}
										bottomLeft = 16776960u;
										topLeft = 65280u;
										topRight = 255u;
									}
									else
									{
										if ((object)_displaySprite3 == null)
										{
											goto IL_0854;
										}
										bottomLeft = 255u;
										topLeft = 16711680u;
										topRight = 16776960u;
									}
									uint num4 = default(uint);
									BlendMode blendMode = default(BlendMode);
									PhaserSprite phaserSprite5 = _displaySprite3.setTint(topLeft, topRight, bottomLeft, num4, blendMode);
									if (_alphaTween3 != null)
									{
										_alphaTween3.Kill();
									}
									TweenConfig tweenConfig = new TweenConfig();
									object[] array = new object[1];
									if (array != null)
									{
										if ((object)_displaySprite3 != null)
										{
											void* value2 = ((IntPtr*)(&array))->m_value;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj4 = default(object);
											bool flag3 = obj4 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if (tweenConfig != null)
										{
											((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
											((MonoBehaviour)(object)tweenConfig).m_CancellationTokenSource = (CancellationTokenSource)1140457472;
											_ = 1;
											((GameMonoBehaviour)(object)tweenConfig)._onPauseSent = true;
											_ = 4294967295L;
											_ = 1;
											MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
											_alphaTween3 = alphaTween;
											_isCullable = false;
											ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
											float bodyRadius = _bodyRadius;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
											float num5 = bodyRadius ^ 0;
											if (body != null)
											{
												BaseBody baseBody = body.setCircle(_bodyRadius, (float?)(object)1, (float?)(object)1);
												if ((object)_weapon != null)
												{
													float num6 = _weapon.PArea();
													if (!(1f < num5) || num5 < 3f)
													{
													}
													if ((object)_displaySprite1 != null)
													{
														PhaserSprite phaserSprite6 = _displaySprite1.setAlpha(0f);
														ArcadeSprite arcadeSprite2 = setScale(num5, (float?)(object)0);
														UpdatePosition();
														if ((object)_displaySprite2 != null)
														{
															PhaserSprite phaserSprite7 = _displaySprite2.setAlpha(0f);
															if (_alphaTween1 != null)
															{
																_alphaTween1.Kill();
															}
															TweenConfig tweenConfig2 = new TweenConfig();
															object[] array2 = new object[1];
															if (array2 != null)
															{
																if ((object)_displaySprite1 != null)
																{
																	nint num7 = (nint)array2;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																	object obj5 = default(object);
																	bool flag4 = obj5 == null;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																if (tweenConfig2 != null)
																{
																	tweenConfig2.targets = array2;
																	tweenConfig2.duration = 100f;
																	tweenConfig2.alpha = (float?)(object)1;
																	TweenCallback onStart = delegate
																	{
																		PhaserSprite phaserSprite8 = _displaySprite1.setAlpha(0f);
																	};
																	tweenConfig2.onStart = onStart;
																	MultiTargetTween alphaTween2 = Tweens.Add(tweenConfig2);
																	_alphaTween1 = alphaTween2;
																	float hitBoxDelay = weapon.HitBoxDelay;
																	Action onComplete = delegate
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
																	};
																	float num8 = hitBoxDelay * 0.001f;
																	int repeat = default(int);
																	TimerType type = default(TimerType);
																	VampireSurvivors.Framework.TimerSystem.Timer hitBoxTimer = Timers.Register(num8, onComplete, null, isLooped: true, (byte)num4 != 0, (MonoBehaviour)blendMode, repeat, type, isOnlineTimer: false, canPause: false);
																	_hitBoxTimer = hitBoxTimer;
																	float num9 = weapon.PDuration();
																	Action onComplete2 = StartDespawn;
																	float num10 = num8 * 0.001f;
																	VampireSurvivors.Framework.TimerSystem.Timer durationTimer = Timers.Register(num10, onComplete2, null, isLooped: false, (byte)num4 != 0, (MonoBehaviour)blendMode, repeat, type, isOnlineTimer: false, canPause: false);
																	_durationTimer = durationTimer;
																	if ((object)_weapon != null)
																	{
																		float num11 = _weapon.PInterval();
																		if ((object)_weapon != null)
																		{
																			float num12 = _weapon.PDuration();
																			if (num10 > num10)
																			{
																				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
																				{
																					Rate = 0.8f
																				};
																				object obj6 = UnityEngine.Random.value;
																				float num13 = num10 * -100f;
																				((GameMonoBehaviour)(object)soundConfig)._onPauseSent = (byte)(int)num13 != 0;
																				_ = 1;
																				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_ShieldDark1, soundConfig, 200f, 10, (int)num4);
																			}
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
		goto IL_0854;
		IL_0854:
		throw new NullReferenceException();
	}

	public void StartDespawn()
	{
		//IL_008d: Expected I, but got O
		//IL_00e5: Expected I, but got O
		//IL_0149: Expected O, but got I4
		//IL_0164: Expected I, but got O
		if (_alphaTween3 != null)
		{
			_alphaTween3.Kill();
		}
		if (_alphaTween1 != null)
		{
			_alphaTween1.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_displaySprite1 != null)
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
		if ((object)_displaySprite3 != null)
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
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Shield2_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num3 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween1 = alphaTween;
	}

	public override void InternalUpdate()
	{
		UpdatePosition();
		Weapon weapon = _weapon;
		bool flag = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
		PhaserSprite phaserSprite = _displaySprite3.setFlipX(flag);
	}

	private void UpdatePosition()
	{
		//IL_0281: Expected O, but got I4
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Expected O, but got Unknown
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_0384->IL026d: Incompatible stack heights: 1 vs 0
		//IL_0152->IL026d: Incompatible stack heights: 1 vs 0
		//IL_0181->IL026d: Incompatible stack heights: 1 vs 0
		//IL_040a->IL026d: Incompatible stack heights: 2 vs 0
		//IL_01bd->IL026d: Incompatible stack heights: 2 vs 0
		//IL_0206->IL026d: Incompatible stack heights: 2 vs 0
		//IL_0246->IL026d: Incompatible stack heights: 2 vs 0
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			TP_Shield2_Weapon trueWeapon = _trueWeapon;
			ArcadeSprite arcadeSprite = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			if ((object)_trueWeapon != null)
			{
				float num = (float)trueWeapon.SlotNumber / 3f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
				bool flag = (object)((Equipment)weapon)._003COwner_003Ek__BackingField == null;
				if (!flag)
				{
					bool flag2 = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
					bool flag3 = (byte)((flag2 ? 1u : 0u) ^ 1u) != 0;
					if (!flag)
					{
						flag3 = flag2;
					}
					object obj = (flag3 ? 1 : 0) + (flag3 ? 1 : 0);
					object obj2 = obj - 1;
					object obj3 = obj ^ 1;
					object obj4 = obj ^ obj2;
					object obj5 = obj3 & obj4;
					bool flag4 = (nint)obj5 < 0;
					bool flag5 = (nint)obj2 < 0;
					bool flag6 = obj2 == null;
					bool flag7 = flag5 == flag4;
					bool flag8 = !flag6;
					bool flag9 = flag8 & flag7;
					((ArcadeSprite)((Equipment)weapon)._003COwner_003Ek__BackingField).CheckRenderer();
					if ((object)arcadeSprite._spriteRenderer != null)
					{
						Sprite sprite = arcadeSprite._spriteRenderer.sprite;
						if ((object)sprite != null)
						{
							bool flag10 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
							if (body != null)
							{
								float num2 = base.scale;
								((ArcadeSprite)((Equipment)weapon)._003COwner_003Ek__BackingField).CheckRenderer();
								if ((object)arcadeSprite._spriteRenderer != null)
								{
									Sprite sprite2 = arcadeSprite._spriteRenderer.sprite;
									if ((object)sprite2 != null)
									{
										bool flag11 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
										Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out ret);
										if ((nint)obj > 1)
										{
										}
										float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
										float2 float6 = default(float2);
										base.position = float6;
										if ((object)_displaySprite1 != null)
										{
											PhaserSprite phaserSprite = _displaySprite1.setFlipX(flag9);
											if ((object)_displaySprite2 != null)
											{
												PhaserSprite phaserSprite2 = _displaySprite2.setFlipX(flag9);
												int num3 = ((Equipment)weapon)._003COwner_003Ek__BackingField.Depth;
												if ((object)_displaySprite1 != null)
												{
													int num4 = num3 + 1;
													PhaserSprite phaserSprite3 = _displaySprite1.setDepth(num4);
													if ((object)_displaySprite2 != null)
													{
														int num5 = num3 + 2;
														PhaserSprite phaserSprite4 = _displaySprite2.setDepth(num5);
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
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		if (_alphaTween3 != null)
		{
			_alphaTween3.Kill();
		}
		PhaserSprite phaserSprite = _displaySprite3.setVisible(visible: false);
		if (_selfDelayTimer != null)
		{
			_selfDelayTimer.Cancel();
		}
		if (_hitBoxTimer != null)
		{
			_hitBoxTimer.Cancel();
		}
		if (_durationTimer != null)
		{
			_durationTimer.Cancel();
		}
		if (_alphaTween1 != null)
		{
			_alphaTween1.Kill();
		}
		if (_alphaTween2 != null)
		{
			_alphaTween2.Kill();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_02ce: Expected O, but got F4
		//IL_030a: Expected O, but got I4
		//IL_012c: Expected F4, but got I4
		//IL_01ef: Expected I, but got O
		//IL_025d: Expected O, but got I4
		//IL_0212->IL0212: Incompatible stack heights: 1 vs 0
		if (!_canShoot)
		{
			return;
		}
		_canShoot = false;
		if (_selfDelayTimer != null)
		{
			_selfDelayTimer.Cancel();
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			_canShoot = true;
		};
		float duration = hitBoxDelay * 0.001f;
		bool flag = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		VampireSurvivors.Framework.TimerSystem.Timer selfDelayTimer = Timers.Register(duration, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_selfDelayTimer = selfDelayTimer;
		TP_Shield2_Weapon trueWeapon = _trueWeapon;
		float2 float5 = base.position;
		Vector2 vector = default(Vector2);
		_trueWeapon.FireProjectiles(trueWeapon._standardPool, vector);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		float num = (float)vector - 0.5f;
		soundConfig.Rate = 1f;
		float detune = num * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_ShieldDark1, soundConfig, 200f, 1, flag ? 1 : 0);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
			if (_alphaTween2 != null)
			{
				_alphaTween2.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if ((object)_displaySprite2 != null)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				bool flag2 = obj2 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 100f;
			tweenConfig.yoyo = true;
			tweenConfig.alpha = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				PhaserSprite phaserSprite = _displaySprite2.setAlpha(0f);
			};
			tweenConfig.onStart = onStart;
			MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
			_alphaTween2 = alphaTween;
		}
	}

	private void _003CInitProjectile_003Eb__13_1()
	{
		PhaserSprite phaserSprite = _displaySprite1.setAlpha(0f);
	}

	private void _003CInitProjectile_003Eb__13_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003COnHasHitAnObject_003Eb__18_0()
	{
		_canShoot = true;
	}

	private void _003COnHasHitAnObject_003Eb__18_1()
	{
		PhaserSprite phaserSprite = _displaySprite2.setAlpha(0f);
	}
}
