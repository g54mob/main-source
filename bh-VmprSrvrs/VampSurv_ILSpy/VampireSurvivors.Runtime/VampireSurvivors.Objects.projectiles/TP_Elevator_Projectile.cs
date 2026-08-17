using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Elevator_Projectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public TP_Elevator_Projectile _003C_003E4__this;

		public float hitboxDelay;

		public DOGetter<float> _003C_003E9__4;

		public DOSetter<float> _003C_003E9__5;

		internal void _003CSetTarget_003Eb__0()
		{
			TP_Elevator_Projectile tP_Elevator_Projectile = _003C_003E4__this;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}

		internal float _003CSetTarget_003Eb__1()
		{
			TP_Elevator_Projectile tP_Elevator_Projectile = _003C_003E4__this;
			return tP_Elevator_Projectile._speedMultiplier;
		}

		internal void _003CSetTarget_003Eb__2(float x)
		{
			TP_Elevator_Projectile tP_Elevator_Projectile = _003C_003E4__this;
			tP_Elevator_Projectile._speedMultiplier = x;
		}

		internal void _003CSetTarget_003Eb__3()
		{
			TP_Elevator_Projectile tP_Elevator_Projectile = _003C_003E4__this;
			tP_Elevator_Projectile._speedMultiplier = 2f;
			if (tP_Elevator_Projectile.yoyoTween != null)
			{
				TweenExtensions.Kill(tP_Elevator_Projectile.yoyoTween);
			}
			DOGetter<float> getter = _003C_003E9__4;
			TP_Elevator_Projectile tP_Elevator_Projectile2 = _003C_003E4__this;
			if (_003C_003E9__4 == null)
			{
				DOGetter<float> dOGetter = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				_003C_003E9__4 = dOGetter;
				getter = dOGetter;
			}
			DOSetter<float> setter = _003C_003E9__5;
			if (_003C_003E9__5 == null)
			{
				DOSetter<float> dOSetter = null;
				float x = default(float);
				((_003C_003Ec__DisplayClass22_0)(object)dOSetter)._003CSetTarget_003Eb__5(x);
				_003C_003E9__5 = dOSetter;
				setter = dOSetter;
			}
			float duration = hitboxDelay * 0.001f;
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, setter, -2f, duration);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 4294967295L;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
						if ((nint)0 == 0)
						{
							_ = 2139095040;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 4;
						_ = 0;
					}
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			tP_Elevator_Projectile2.yoyoTween = tweenerCore;
		}

		internal float _003CSetTarget_003Eb__4()
		{
			TP_Elevator_Projectile tP_Elevator_Projectile = _003C_003E4__this;
			return tP_Elevator_Projectile._speedMultiplier;
		}

		internal void _003CSetTarget_003Eb__5(float x)
		{
			TP_Elevator_Projectile tP_Elevator_Projectile = _003C_003E4__this;
			tP_Elevator_Projectile._speedMultiplier = x;
		}
	}

	private PhaserSprite _elevatorSprite;

	private PhaserSprite _weightSprite;

	private bool _isDespawning;

	private Timer _expireTimer;

	private Timer _hitBoxTimer;

	private List<string> FrameNames_Elevators;

	private List<string> FrameNames_Weights;

	private int repeats;

	private float tripDuration;

	private int completedTrips;

	private int directionMultiplier;

	private bool isElevator;

	private int _isRight;

	private MultiTargetTween _scaleTween;

	private float initialPosX;

	private float _speedMultiplier;

	private Tween yoyoTween;

	private float _currentProjectileSpeed;

	private Sequence _yoyoSequence;

	private Tween accelTween;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite elevatorSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Elevator00");
		_elevatorSprite = elevatorSprite;
		GameObject gameObject2 = base.gameObject;
		PhaserSprite weightSprite = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "ThosePeople", "TP_VFX_Elevator06");
		_weightSprite = weightSprite;
		PhaserSprite phaserSprite = _elevatorSprite.setDepth(1993);
		PhaserSprite phaserSprite2 = _weightSprite.setDepth(1993);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0038: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isDespawning = false;
		_isCullable = false;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
	}

	public override void SetTarget(Transform target)
	{
		//IL_0d31: Expected I, but got O
		//IL_02e6: Expected O, but got I4
		//IL_0411: Expected F4, but got O
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected F4, but got Unknown
		//IL_0339: Expected O, but got F4
		//IL_0486: Expected O, but got I4
		//IL_039a: Expected O, but got I4
		//IL_06a2: Expected O, but got F4
		//IL_06da: Expected O, but got I4
		//IL_0715: Invalid comparison between F4 and O
		//IL_0735: Invalid comparison between O and F4
		//IL_088c: Invalid comparison between I4 and F4
		//IL_089b: Expected F4, but got I4
		//IL_0a4a: Expected I4, but got O
		//IL_0ae6: Expected I4, but got O
		//IL_0b6b: Expected F4, but got O
		//IL_0e6c->IL0cb2: Incompatible stack heights: 1 vs 0
		//IL_0d5b->IL0cb2: Incompatible stack heights: 1 vs 0
		//IL_00bf->IL0cb2: Incompatible stack heights: 1 vs 0
		//IL_00de->IL0cb2: Incompatible stack heights: 1 vs 0
		//IL_0144->IL0cb2: Incompatible stack heights: 2 vs 0
		//IL_018f->IL0cb2: Incompatible stack heights: 3 vs 0
		//IL_01d5->IL0cb2: Incompatible stack heights: 3 vs 0
		//IL_01f4->IL0cb2: Incompatible stack heights: 3 vs 0
		//IL_025a->IL0cb2: Incompatible stack heights: 4 vs 0
		//IL_02a0->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_043f->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_0353->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_046e->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_0382->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_04a9->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_03bd->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_0dd2->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_0d82->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_04d0->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_03e4->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_0dab->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_0517->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_055a->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_0591->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_05c8->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_05fb->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_0def->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_066e->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_06bc->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_06f8->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_08d0->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_081d->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_0902->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_084f->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_0eab->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_0e30->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_09e4->IL0cb2: Incompatible stack heights: 5 vs 0
		//IL_0e4d->IL0cb2: Incompatible stack heights: 5 vs 0
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals15 = new _003C_003Ec__DisplayClass22_0();
		float2 float5 = default(float2);
		float num8;
		Transform transform3;
		if (CS_0024_003C_003E8__locals15 != null)
		{
			CS_0024_003C_003E8__locals15._003C_003E4__this = this;
			_targetTransform = target;
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				transform.parent = target;
				Transform transform2 = base.transform;
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
				if ((object)_elevatorSprite != null)
				{
					PhaserSprite phaserSprite = _elevatorSprite.setLocalPosition(float5);
					nint num = (nint)typeof(Vector2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rax_v32 (Il2CppClass<UnityEngine.Vector2>)+B8]");
					nint num2 = 0;
					if ((object)_weightSprite != null)
					{
						PhaserSprite phaserSprite2 = _weightSprite.setLocalPosition(float5);
						Weapon weapon = _weapon;
						List<string> frameNames_Elevators = FrameNames_Elevators;
						if ((object)_weapon != null && FrameNames_Elevators != null)
						{
							int num3 = ((Equipment)weapon)._003CLevel_003Ek__BackingField % frameNames_Elevators._size;
							bool flag2 = num3 >= frameNames_Elevators._size;
							string[] items = frameNames_Elevators._items;
							if (frameNames_Elevators._items != null)
							{
								bool flag3 = num3 >= items.Length;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
								if ((object)_elevatorSprite != null)
								{
									Sprite sprite = default(Sprite);
									PhaserSprite phaserSprite3 = _elevatorSprite.setFrame(sprite);
									Weapon weapon2 = _weapon;
									List<string> frameNames_Weights = FrameNames_Weights;
									if ((object)_weapon != null && FrameNames_Weights != null)
									{
										int num4 = ((Equipment)weapon2)._003CLevel_003Ek__BackingField % frameNames_Weights._size;
										bool flag4 = num4 >= frameNames_Weights._size;
										string[] items2 = frameNames_Weights._items;
										if (frameNames_Weights._items != null)
										{
											bool flag5 = num4 >= items2.Length;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
											bool flag6 = (object)_weightSprite == null;
											if (!flag6)
											{
												Sprite sprite2 = default(Sprite);
												PhaserSprite phaserSprite4 = _weightSprite.setFrame(sprite2);
												int num5 = ~_indexInWeapon;
												int num6 = num5 & 1;
												isElevator = (byte)num6 != 0;
												object obj = !flag6;
												if (obj == null)
												{
													float projectileSpeed = base.ProjectileSpeed;
													float num7 = (_currentProjectileSpeed = float5 ^ -0f);
													float projectileSpeed2 = base.ProjectileSpeed;
													ArcadeSprite sprite3 = _sprite;
													object obj2 = num7 ^ -0f;
													if ((object)_sprite != null)
													{
														BaseBody baseBody = sprite3.body;
														if (sprite3.body != null)
														{
															baseBody._velocity = (float2)0;
															float2 float6 = base.position;
															if ((object)GM.Core != null)
															{
																PhaserScene s_scene = ArcadePhysics.s_scene;
																if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
																{
																	num8 = -0f;
																	transform3 = null;
																	goto IL_0d87;
																}
															}
														}
													}
												}
												else
												{
													float projectileSpeed3 = base.ProjectileSpeed;
													_currentProjectileSpeed = (float)float5;
													float projectileSpeed4 = base.ProjectileSpeed;
													ArcadeSprite sprite4 = _sprite;
													if ((object)_sprite != null)
													{
														BaseBody baseBody2 = sprite4.body;
														if (sprite4.body != null)
														{
															baseBody2._velocity = (float2)0;
															float2 float7 = base.position;
															if ((object)GM.Core != null)
															{
																PhaserScene s_scene2 = ArcadePhysics.s_scene;
																if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
																{
																	num8 = -0f;
																	transform3 = null;
																	goto IL_0d87;
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
		goto IL_0cb2;
		IL_0cb2:
		throw new NullReferenceException();
		IL_0d87:
		base.position = float5;
		float num17;
		float num20;
		if ((object)_elevatorSprite != null)
		{
			PhaserSprite phaserSprite5 = _elevatorSprite.setVisible(isElevator);
			if ((object)_weightSprite != null)
			{
				bool visible = !isElevator;
				PhaserSprite phaserSprite6 = _weightSprite.setVisible(visible);
				if ((object)_elevatorSprite != null)
				{
					PhaserSprite phaserSprite7 = _elevatorSprite.setScale(1f, (float?)transform3);
					if ((object)_weightSprite != null)
					{
						PhaserSprite phaserSprite8 = _weightSprite.setScale(1f, (float?)transform3);
						if ((object)_elevatorSprite != null)
						{
							PhaserSprite phaserSprite9 = _elevatorSprite.setAlpha(0.85f);
							if ((object)_weightSprite != null)
							{
								PhaserSprite phaserSprite10 = _weightSprite.setAlpha(1f);
								PhaserSprite phaserSprite11 = ((!isElevator) ? _weightSprite : _elevatorSprite);
								if ((object)phaserSprite11 != null && (object)phaserSprite11._spriteRenderer != null)
								{
									Vector2 vector = phaserSprite11._spriteRenderer.size;
									float num9 = (float)vector * 50f;
									object obj3 = num9 ^ num8;
									if (body != null)
									{
										BaseBody baseBody3 = body.setCircle(num9, (float?)(object)1, (float?)transform3);
										if ((object)_weapon != null)
										{
											float num10 = _weapon.PArea();
											float num14;
											if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
											{
												if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)2.5f))
												{
													float num11 = (float)obj3 - 1f;
													float num12 = num11 * 0.25f;
													float num13 = num12 / 1.5f;
													num14 = 1f - num13;
												}
												else
												{
													num14 = 0.75f;
												}
											}
											else
											{
												num14 = 1f;
											}
											NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
											string text = System.Number.FormatSingle(num14, null, currentInfo);
											string message = "alpha = " + text;
											Debug.Log(message);
											if (isElevator)
											{
												if ((object)_elevatorSprite != null)
												{
													PhaserSprite phaserSprite12 = _elevatorSprite.setAlpha(num14);
													if ((object)_weapon != null)
													{
														float num15 = _weapon.PArea();
														float num16 = num14 - 1f;
														num17 = num16 * 0.1f;
														bool flag7 = 0f > num17;
														float num18 = 0f;
														if (!flag7)
														{
															num18 = num17;
														}
														float num19 = num18 + 1f;
														num20 = num19;
														goto IL_0e7f;
													}
												}
											}
											else if ((object)_weightSprite != null)
											{
												PhaserSprite phaserSprite13 = _weightSprite.setAlpha(num14);
												if ((object)_weapon != null)
												{
													float num21 = _weapon.PArea();
													num20 = num14;
													num17 = num14;
													goto IL_0e7f;
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
		goto IL_0cb2;
		IL_0e7f:
		ArcadeSprite arcadeSprite = setScale(num20, (float?)transform3);
		if ((object)_weapon != null)
		{
			float num22 = _weapon.PSpeed();
			bool flag8 = !(0.001f > num17);
			float num23 = num17;
			if (!flag8)
			{
				num23 = 0.001f;
			}
			if ((object)_weapon != null)
			{
				float hitBoxDelay = _weapon.HitBoxDelay;
				float num24 = (CS_0024_003C_003E8__locals15.hitboxDelay = hitBoxDelay / num23);
				if (_expireTimer != null)
				{
					_expireTimer.Cancel();
				}
				if ((object)_weapon != null)
				{
					float num25 = _weapon.PDuration();
					Action onComplete = StartDespawn;
					float duration = num24 * 0.001f;
					bool useRealTime = default(bool);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, (byte)(int)transform3 != 0);
					_expireTimer = expireTimer;
					if (_hitBoxTimer != null)
					{
						_hitBoxTimer.Cancel();
					}
					Action onComplete2 = delegate
					{
						TP_Elevator_Projectile tP_Elevator_Projectile = CS_0024_003C_003E8__locals15._003C_003E4__this;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
					};
					float duration2 = CS_0024_003C_003E8__locals15.hitboxDelay * 0.001f;
					Timer hitBoxTimer = Timers.Register(duration2, onComplete2, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, (byte)(int)transform3 != 0);
					_hitBoxTimer = hitBoxTimer;
					if (yoyoTween != null)
					{
						TweenExtensions.Kill(yoyoTween);
					}
					if (accelTween != null)
					{
						TweenExtensions.Kill(accelTween);
					}
					_speedMultiplier = (float)transform3;
					DOGetter<float> getter = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
					DOSetter<float> dOSetter = null;
					((_003C_003Ec__DisplayClass22_0)(object)dOSetter)._003CSetTarget_003Eb__2(num20);
					float duration3 = CS_0024_003C_003E8__locals15.hitboxDelay * 0.001f;
					TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 1f, duration3);
					if (tweenerCore != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1970 @ rax_v95 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
						if ((nint)0 != 0)
						{
							_ = 3;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if (tweenerCore != null)
					{
						TweenCallback tweenCallback = delegate
						{
							TP_Elevator_Projectile tP_Elevator_Projectile = CS_0024_003C_003E8__locals15._003C_003E4__this;
							tP_Elevator_Projectile._speedMultiplier = 2f;
							if (tP_Elevator_Projectile.yoyoTween != null)
							{
								TweenExtensions.Kill(tP_Elevator_Projectile.yoyoTween);
							}
							DOGetter<float> getter2 = CS_0024_003C_003E8__locals15._003C_003E9__4;
							TP_Elevator_Projectile tP_Elevator_Projectile2 = CS_0024_003C_003E8__locals15._003C_003E4__this;
							if (CS_0024_003C_003E8__locals15._003C_003E9__4 == null)
							{
								DOGetter<float> dOGetter = null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
								CS_0024_003C_003E8__locals15._003C_003E9__4 = dOGetter;
								getter2 = dOGetter;
							}
							DOSetter<float> setter = CS_0024_003C_003E8__locals15._003C_003E9__5;
							if (CS_0024_003C_003E8__locals15._003C_003E9__5 == null)
							{
								DOSetter<float> dOSetter2 = null;
								float x = default(float);
								((_003C_003Ec__DisplayClass22_0)(object)dOSetter2)._003CSetTarget_003Eb__5(x);
								CS_0024_003C_003E8__locals15._003C_003E9__5 = dOSetter2;
								setter = dOSetter2;
							}
							float duration4 = CS_0024_003C_003E8__locals15.hitboxDelay * 0.001f;
							TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter2, setter, -2f, duration4);
							if (tweenerCore2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
									if ((nint)0 == 0)
									{
										_ = 4294967295L;
										_ = 1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
										if ((nint)0 == 0)
										{
											_ = 2139095040;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
									if ((nint)0 != 0)
									{
										_ = 4;
										_ = 0;
									}
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							tP_Elevator_Projectile2.yoyoTween = tweenerCore2;
						};
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1970 @ rax_v95 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
						if ((nint)0 != 0)
						{
						}
						accelTween = tweenerCore;
						return;
					}
				}
			}
		}
		goto IL_0cb2;
	}

	private void StartDespawn()
	{
		//IL_0069: Expected I, but got O
		//IL_00c1: Expected I, but got O
		//IL_0119: Expected I, but got O
		//IL_017d: Expected O, but got I4
		//IL_0198: Expected I, but got O
		if (_isDespawning)
		{
			return;
		}
		_isDespawning = true;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[3];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_elevatorSprite != null)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_weightSprite != null)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Elevator_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num4 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			return;
		}
		ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
		throw ex3;
	}

	public override void Despawn()
	{
		Tween tween = accelTween;
		if (accelTween != null && tween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(accelTween);
		}
		if (yoyoTween != null)
		{
			TweenExtensions.Kill(yoyoTween);
		}
		if (_hitBoxTimer != null)
		{
			_hitBoxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		PhaserSprite phaserSprite = _elevatorSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _weightSprite.setVisible(visible: false);
		base.Despawn();
	}

	private void LateUpdate()
	{
		//IL_0047: Expected O, but got I4
		ArcadeSprite sprite = _sprite;
		float num = _currentProjectileSpeed * _speedMultiplier;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)0;
	}

	public TP_Elevator_Projectile()
	{
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Elevator00");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Elevator00");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Elevator01");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Elevator01");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Elevator02");
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
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Elevator02");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Elevator03");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Elevator03");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items9 = list._items;
		if (list._size >= items9.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Elevator04");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items10 = list._items;
		if (list._size >= items10.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Elevator04");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items11 = list._items;
		if (list._size >= items11.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Elevator04");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		FrameNames_Elevators = list;
		List<string> list2 = new List<string>();
		list2._version++;
		string[] items12 = list2._items;
		if (list2._size >= items12.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Elevator06");
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
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Elevator06");
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
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Elevator06");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items15 = list2._items;
		if (list2._size >= items15.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Elevator07");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items16 = list2._items;
		if (list2._size >= items16.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Elevator07");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items17 = list2._items;
		if (list2._size >= items17.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Elevator07");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items18 = list2._items;
		if (list2._size >= items18.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Elevator08");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items19 = list2._items;
		if (list2._size >= items19.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Elevator08");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items20 = list2._items;
		if (list2._size >= items20.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Elevator08");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items21 = list2._items;
		if (list2._size >= items21.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Elevator09");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list2._version++;
		string[] items22 = list2._items;
		if (list2._size >= items22.Length)
		{
			((List<object>)(object)list2).AddWithResize((object)"TP_VFX_Elevator09");
		}
		else
		{
			list2._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		FrameNames_Weights = list2;
		base._002Ector();
	}
}
