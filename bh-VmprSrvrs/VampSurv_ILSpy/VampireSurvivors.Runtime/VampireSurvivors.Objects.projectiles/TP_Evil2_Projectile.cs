using System;
using System.Collections.Generic;
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
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Evil2_Projectile : Projectile
{
	private float _radius = 32f;

	private PhaserSprite _sprite1;

	private PhaserSprite _sprite2;

	private PhaserSprite _sprite3;

	private PhaserSprite _sprite4;

	private PhaserSprite _sprite5;

	private Tween _radiusTween;

	private MultiTargetTween _scaleTween;

	private Timer _expireTimer;

	private Timer _hitboxTimer;

	private MultiTargetTween _rotTween;

	private MultiTargetTween _alphaTween;

	private Vector2 startingVelocity;

	private float _accel = 1f;

	private MultiTargetTween _alphaTween2;

	private MultiTargetTween _scaleTween2;

	private List<bool> _cachedInRange;

	private float _cachedArea;

	private TP_Evil2_Weapon trueWeapon;

	protected unsafe override void Awake()
	{
		//IL_02e5: Expected I, but got O
		//IL_033d: Expected I, but got O
		//IL_0395: Expected I, but got O
		//IL_03ed: Expected I, but got O
		//IL_0445: Expected I, but got O
		//IL_04b3: Expected O, but got I4
		//IL_0513: Expected I4, but got I8
		//IL_05bf: Expected I, but got O
		//IL_0617: Expected I, but got O
		//IL_066f: Expected I, but got O
		//IL_077d: Expected I4, but got I8
		//IL_0837: Expected I, but got O
		//IL_088f: Expected I, but got O
		//IL_08e7: Expected I, but got O
		//IL_0955: Expected O, but got I4
		//IL_09b5: Expected I4, but got I8
		//IL_0b59: Expected I, but got O
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				GameObject gameObject = base.gameObject;
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Nightmare01");
				if ((object)phaserSprite != null)
				{
					PhaserSprite sprite2 = phaserSprite.setAlpha(1f);
					_sprite1 = sprite2;
					GameObject gameObject2 = base.gameObject;
					PhaserSprite phaserSprite2 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "ThosePeople", "TP_VFX_Nightmare02");
					if ((object)phaserSprite2 != null)
					{
						PhaserSprite sprite3 = phaserSprite2.setAlpha(0.75f);
						_sprite2 = sprite3;
						GameObject gameObject3 = base.gameObject;
						PhaserSprite phaserSprite3 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "ThosePeople", "TP_VFX_Nightmare03");
						if ((object)phaserSprite3 != null)
						{
							PhaserSprite sprite4 = phaserSprite3.setAlpha(0.45f);
							_sprite3 = sprite4;
							GameObject gameObject4 = base.gameObject;
							PhaserSprite phaserSprite4 = RenderingExtensions.AddPhaserSprite(gameObject4, pos, "ThosePeople", "TP_VFX_Nightmare04");
							if ((object)phaserSprite4 != null)
							{
								PhaserSprite sprite5 = phaserSprite4.setAlpha(0.65f);
								_sprite4 = sprite5;
								GameObject gameObject5 = base.gameObject;
								PhaserSprite phaserSprite5 = RenderingExtensions.AddPhaserSprite(gameObject5, pos, "ThosePeople", "TP_VFX_Nightmare04");
								if ((object)phaserSprite5 != null)
								{
									PhaserSprite sprite6 = phaserSprite5.setAlpha(0.65f);
									_sprite5 = sprite6;
									if (_rotTween != null)
									{
										_rotTween.Kill();
									}
									TweenConfig tweenConfig = new TweenConfig();
									object[] array = new object[5];
									if (array != null)
									{
										if ((object)_sprite5 != null)
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
										if ((object)_sprite4 != null)
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
										if ((object)_sprite3 != null)
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
										if ((object)_sprite2 != null)
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
										if ((object)_sprite1 != null)
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
										if (tweenConfig != null)
										{
											tweenConfig.targets = array;
											tweenConfig.angle = (float?)(object)1;
											StaggerConfig staggerConfig = new StaggerConfig();
											staggerConfig.ease = Ease.Linear;
											staggerConfig.start = 2000f;
											Func<int, float> staggerDuration = Tweens.Stagger(300f, staggerConfig);
											tweenConfig.staggerDuration = staggerDuration;
											tweenConfig.repeat = -1;
											MultiTargetTween rotTween = Tweens.Add(tweenConfig);
											_rotTween = rotTween;
											if (_alphaTween != null)
											{
												_alphaTween.Kill();
											}
											TweenConfig tweenConfig2 = new TweenConfig();
											object[] array2 = new object[3];
											if (array2 != null)
											{
												if ((object)_sprite2 != null)
												{
													nint num6 = (nint)array2;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													object obj6 = default(object);
													if (obj6 == null)
													{
														ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
														throw ex6;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												if ((object)_sprite3 != null)
												{
													nint num7 = (nint)array2;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													object obj7 = default(object);
													if (obj7 == null)
													{
														ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
														throw ex7;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												if ((object)_sprite4 != null)
												{
													nint num8 = (nint)array2;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
													object obj8 = default(object);
													if (obj8 == null)
													{
														ArrayTypeMismatchException ex8 = new ArrayTypeMismatchException();
														throw ex8;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
												if (tweenConfig2 != null)
												{
													tweenConfig2.targets = array2;
													StaggerConfig staggerConfig2 = new StaggerConfig();
													staggerConfig2.ease = Ease.Linear;
													staggerConfig2.start = 0.15f;
													Func<int, float> staggerAlpha = Tweens.Stagger(0.25f, staggerConfig2);
													tweenConfig2.staggerAlpha = staggerAlpha;
													StaggerConfig staggerConfig3 = new StaggerConfig();
													staggerConfig3.ease = Ease.Linear;
													staggerConfig3.start = 2000f;
													Func<int, float> staggerDuration2 = Tweens.Stagger(300f, staggerConfig3);
													tweenConfig2.staggerDuration = staggerDuration2;
													tweenConfig2.repeat = -1;
													tweenConfig2.yoyo = true;
													MultiTargetTween alphaTween = Tweens.Add(tweenConfig2);
													_alphaTween = alphaTween;
													if (_alphaTween2 != null)
													{
														_alphaTween2.Kill();
													}
													TweenConfig tweenConfig3 = new TweenConfig();
													object[] array3 = new object[3];
													if (array3 != null)
													{
														if ((object)_sprite1 != null)
														{
															nint num9 = (nint)array3;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj9 = default(object);
															if (obj9 == null)
															{
																ArrayTypeMismatchException ex9 = new ArrayTypeMismatchException();
																throw ex9;
															}
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if ((object)_sprite5 != null)
														{
															nint num10 = (nint)array3;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj10 = default(object);
															if (obj10 == null)
															{
																ArrayTypeMismatchException ex10 = new ArrayTypeMismatchException();
																throw ex10;
															}
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if ((object)_sprite4 != null)
														{
															nint num11 = (nint)array3;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
															object obj11 = default(object);
															if (obj11 == null)
															{
																ArrayTypeMismatchException ex11 = new ArrayTypeMismatchException();
																throw ex11;
															}
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
														if (tweenConfig3 != null)
														{
															tweenConfig3.targets = array3;
															tweenConfig3.alpha = (float?)(object)1;
															StaggerConfig staggerConfig4 = new StaggerConfig();
															staggerConfig4.ease = Ease.Linear;
															staggerConfig4.start = 1000f;
															Func<int, float> staggerDuration3 = Tweens.Stagger(500f, staggerConfig4);
															tweenConfig3.staggerDuration = staggerDuration3;
															tweenConfig3.repeat = -1;
															tweenConfig3.yoyo = true;
															MultiTargetTween alphaTween2 = Tweens.Add(tweenConfig3);
															_alphaTween2 = alphaTween2;
															if (_scaleTween2 != null)
															{
																_scaleTween2.Kill();
															}
															TweenConfig tweenConfig4 = new TweenConfig();
															object[] array4 = new object[3];
															if ((object)_sprite4 != null)
															{
																void* value = ((IntPtr*)(&array4))->m_value;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj12 = default(object);
																if (obj12 == null)
																{
																	ArrayTypeMismatchException ex12 = new ArrayTypeMismatchException();
																	throw ex12;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_sprite2 != null)
															{
																void* value2 = ((IntPtr*)(&array4))->m_value;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj13 = default(object);
																if (obj13 == null)
																{
																	ArrayTypeMismatchException ex13 = new ArrayTypeMismatchException();
																	throw ex13;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															if ((object)_sprite5 != null)
															{
																void* value3 = ((IntPtr*)(&array4))->m_value;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																object obj14 = default(object);
																if (obj14 == null)
																{
																	ArrayTypeMismatchException ex14 = new ArrayTypeMismatchException();
																	throw ex14;
																}
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
															((UnityEngine.Object)(object)tweenConfig4).m_CachedPtr = (IntPtr)array4;
															_ = 1;
															StaggerConfig staggerConfig5 = new StaggerConfig();
															staggerConfig5.ease = Ease.Linear;
															staggerConfig5.start = 1500f;
															Func<int, float> func = Tweens.Stagger(150f, staggerConfig5);
															_ = 4294967295L;
															_ = 1;
															MultiTargetTween scaleTween = Tweens.Add(tweenConfig4);
															_scaleTween2 = scaleTween;
															Transform transform = _sprite1.transform;
															bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
															Vector2 value4 = default(Vector2);
															Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value4));
															Transform transform2 = _sprite2.transform;
															bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
															Vector2 value5 = default(Vector2);
															Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)(&value5));
															Transform transform3 = _sprite3.transform;
															bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
															Vector2 value6 = default(Vector2);
															Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)(&value6));
															Transform transform4 = _sprite4.transform;
															bool flag4 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
															Vector2 value7 = default(Vector2);
															Transform.set_localPosition_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)(&value7));
															Transform transform5 = _sprite5.transform;
															bool flag5 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
															Vector2 value8 = default(Vector2);
															Transform.set_localPosition_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Vector3*)(&value8));
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
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_085a: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00dd: Expected O, but got I4
		//IL_00ef: Expected O, but got I4
		//IL_00f8: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_01f5: Expected O, but got I4
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected F4, but got Unknown
		//IL_0248: Expected O, but got I4
		//IL_0248: Expected O, but got I4
		//IL_0153: Expected O, but got I
		//IL_01ad: Expected O, but got I
		//IL_02c3: Expected I, but got O
		//IL_0871: Unknown result type (might be due to invalid IL or missing references)
		//IL_0876: Expected O, but got Unknown
		//IL_0319: Expected O, but got I4
		//IL_0349: Expected O, but got I4
		//IL_0381: Expected O, but got I4
		//IL_08ae: Expected O, but got F4
		//IL_03d0: Expected O, but got I4
		//IL_08e9: Expected O, but got F4
		//IL_0945: Expected I4, but got I8
		//IL_05fb: Expected I4, but got F4
		//IL_0653: Expected I, but got O
		//IL_0669: Expected O, but got I
		//IL_0672: Unknown result type (might be due to invalid IL or missing references)
		//IL_0677: Expected O, but got Unknown
		//IL_0611: Expected I4, but got F4
		//IL_06e0: Expected I, but got O
		//IL_09bc: Expected O, but got I4
		//IL_09e3: Expected I, but got I8
		//IL_0633: Expected O, but got I4
		//IL_0641: Expected O, but got I4
		//IL_06c9: Expected I, but got I8
		//IL_075d: Expected I, but got O
		//IL_0773: Expected O, but got I
		//IL_077c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0781: Expected O, but got Unknown
		//IL_07ef: Expected I, but got O
		//IL_0aa5: Expected I, but got I8
		//IL_07c2: Expected I, but got I8
		//IL_073d: Expected O, but got I4
		//IL_074b: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		float? num;
		if ((object)_weapon == null)
		{
			num = (float?)(object)0;
			goto IL_0833;
		}
		nint num2 = (nint)typeof(TP_Evil2_Weapon);
		nint num3 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v77 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Evil2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r9_v33 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v77 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Evil2_Weapon>)+130]");
		object obj3;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r9_v33 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v163+FFFFFFF8+v74 @ rax_v158*8]");
			if (0 == (nint)typeof(TP_Evil2_Weapon))
			{
				obj3 = 1;
				goto IL_0842;
			}
		}
		obj3 = 0;
		goto IL_0842;
		IL_09b3:
		object obj4 = 24;
		object obj5;
		float duration = (float)obj5 * 0.001f;
		Action action;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		bool useRealTime;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(duration, action, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		Timer expireTimer = _expireTimer;
		if (_expireTimer != null && !_expireTimer.IsDone)
		{
			float timeElapsed = _expireTimer.GetTimeElapsed();
			expireTimer._timeElapsedBeforeCancel = (float?)(object)1;
			expireTimer._timeElapsedBeforePause = (float?)(object)0;
		}
		Action action2 = null;
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v970 @ r10_v2 (Il2CppMethodInfo)+8]");
		((Delegate)action2).method_ptr = (IntPtr)0;
		((Delegate)action2).method = (nint)__ldftn(TP_Evil2_Projectile.StartDespawn);
		((Delegate)action2).m_target = this;
		((Delegate)action2).method_code = (IntPtr)action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v970 @ r10_v2 (Il2CppMethodInfo)+4C]");
		object obj6 = (nint)0 >> 4;
		object obj7 = obj6 & 1;
		nint num6;
		if (obj7 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v970 @ r10_v2 (Il2CppMethodInfo)+52]");
			bool flag = (nint)0 == 0;
			num6 = unchecked((nint)6447293664L);
			if (flag)
			{
				goto IL_0a7e;
			}
		}
		num6 = ((Delegate)action2).method_ptr;
		((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
		goto IL_0a7e;
		IL_0833:
		trueWeapon = (TP_Evil2_Weapon)num;
		setVelocity(0f, (float?)(object)1);
		GameManager core = GM.Core;
		float? num7 = (float?)(object)0;
		float? num8 = (float?)(object)0;
		while (true)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
			if ((nint)num7 >= characters._size)
			{
				break;
			}
			List<bool> cachedInRange = _cachedInRange;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rcx_v105 (System.Collections.Generic.List`1<System.Boolean>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rcx_v105 (System.Collections.Generic.List`1<System.Boolean>)+10]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rcx_v105 (System.Collections.Generic.List`1<System.Boolean>)+18]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ r8_v47+18]");
			if (num9 >= 0)
			{
				cachedInRange.AddWithResize(false);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rcx_v105 (System.Collections.Generic.List`1<System.Boolean>)+18]");
				object obj9 = (nint)0 + (nint)1;
				_ = 0;
			}
			num8 = (float?)(object)((_003F?)num8 + 1);
			core = GM.Core;
			num7 = num8;
		}
		_speed = 0.2f;
		_accel = 5f;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		float radius = _radius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj10 = radius ^ 0;
		float radius2 = _radius;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		float num10 = radius2 ^ 0;
		BaseBody baseBody = body.setCircle(_radius, (float?)(object)1, (float?)(object)1);
		float num11 = _weapon.PArea();
		_cachedArea = num10;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num12 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj11 = default(object);
		Vector2 vector = default(Vector2);
		if (obj11 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.alpha = (float?)(object)1;
			float num13 = _weapon.PArea();
			tweenConfig.duration = 600f;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 0.3f;
			object obj12 = UnityEngine.Random.value;
			float num14 = num10 - 0.5f;
			float num15 = (soundConfig.Detune = num14 * 200f);
			float num16 = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Nightmare, soundConfig, 200f, 3, num16);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Rate = 1f;
			object obj13 = UnityEngine.Random.value;
			float num17 = num15 - 0.5f;
			float detune = num17 * 200f;
			soundConfig2.Detune = detune;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_Nightmare2, soundConfig2, 200f, 3, num16);
			ArcadeSprite arcadeSprite2 = setDepth(-1994);
			int num18 = base.depth;
			int num19 = num18 + 3;
			PhaserSprite phaserSprite = _sprite1.setDepth(num19);
			int num20 = base.depth;
			int num21 = num20 + 5;
			PhaserSprite phaserSprite2 = _sprite2.setDepth(num21);
			int num22 = base.depth;
			int num23 = num22 + 4;
			PhaserSprite phaserSprite3 = _sprite3.setDepth(num23);
			int num24 = base.depth;
			int num25 = num24 + 2;
			PhaserSprite phaserSprite4 = _sprite4.setDepth(num25);
			int num26 = base.depth;
			int num27 = num26 + 1;
			PhaserSprite phaserSprite5 = _sprite5.setDepth(num27);
			Weapon weapon3 = _weapon;
			float2 float5 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
			float2 float6 = base.position;
			float num28 = 1.05360915E+09f - (float)obj10;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
			startingVelocity = vector;
			_ = 1053609165;
			DOGetter<float> getter = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
			DOSetter<float> dOSetter = null;
			((TP_Evil2_Projectile)(object)dOSetter)._003CInitProjectile_003Eb__20_1(0.4f);
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0.5f, 0.4f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			float num29 = _weapon.PDuration();
			float num30 = _weapon.PAmount();
			Timer hitboxTimer2 = _hitboxTimer;
			obj5 = (object)vector / (object)vector;
			bool flag2 = _hitboxTimer == null;
			useRealTime = (byte)(int)num16 != 0;
			if (!flag2)
			{
				useRealTime = (byte)(int)num16 != 0;
				if (!_hitboxTimer.IsDone)
				{
					float timeElapsed2 = _hitboxTimer.GetTimeElapsed();
					hitboxTimer2._timeElapsedBeforeCancel = (float?)(object)1;
					hitboxTimer2._timeElapsedBeforePause = (float?)(object)0;
				}
			}
			action = null;
			nint num31 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1491 @ r10_v1 (Il2CppMethodInfo)+8]");
			((Delegate)action).method_ptr = (IntPtr)0;
			((Delegate)action).method = (nint)__ldftn(TP_Evil2_Projectile._003CInitProjectile_003Eb__20_2);
			((Delegate)action).m_target = this;
			((Delegate)action).method_code = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1491 @ r10_v1 (Il2CppMethodInfo)+4C]");
			object obj14 = (nint)0 >> 4;
			object obj15 = obj14 & 1;
			nint num32;
			if (obj15 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1491 @ r10_v1 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num32 = unchecked((nint)6447293664L);
					goto IL_09b3;
				}
			}
			((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
			num32 = ((Delegate)action).method_ptr;
			goto IL_09b3;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
		IL_0842:
		bool flag3 = obj3 == null;
		num = (float?)(object)0;
		if (!flag3)
		{
			num = (float?)_weapon;
		}
		goto IL_0833;
		IL_0a7e:
		float duration2 = (float)vector * 0.001f;
		((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
		Timer expireTimer2 = Timers.Register(duration2, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer2;
	}

	private void LateUpdate()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		if (!PauseSystem._paused)
		{
			float projectileSpeed = base.ProjectileSpeed;
			object obj2 = default(object);
			object obj = obj2 * _accel;
			float2 velocity = (object)startingVelocity * obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Evil2_Projectile)+134]");
			object obj3 = 0 * obj;
			BaseBody baseBody = body;
			baseBody._velocity = velocity;
		}
	}

	private void StartDespawn()
	{
		//IL_003f: Expected I, but got O
		//IL_00a3: Expected O, but got I4
		//IL_00be: Expected I, but got O
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Evil2_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 273 Invalid \"Jump target not found in method: 0x1870F2690\"");
			throw new NullReferenceException();
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private unsafe void DoTwilightExplosions()
	{
		//IL_008b: Expected O, but got I4
		//IL_010f: Expected I, but got O
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_023c->IL014f: Incompatible stack heights: 1 vs 0
		//IL_00eb->IL014f: Incompatible stack heights: 1 vs 0
		//IL_0149->IL01a5: Incompatible stack heights: 1 vs 0
		//IL_014e->IL014e: Incompatible stack heights: 1 vs 0
		Weapon weapon = _weapon;
		if ((object)_weapon != null)
		{
			if (!weapon._explodeOnExpire)
			{
				return;
			}
			TP_Evil2_Projectile tP_Evil2_Projectile = this;
			object obj = 0;
			object obj2 = default(object);
			while (true)
			{
				float num = (float)obj * 60f;
				float num2 = num * ((float)Math.PI / 180f);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				TP_Evil2_Projectile weapon2 = (TP_Evil2_Projectile)(object)_weapon;
				float num3 = num2 * 0.24f;
				float num4 = num3 * _cachedArea;
				Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
				if ((object)cachedTrans == null)
				{
					break;
				}
				bool flag = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
				float2 ret;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
				if (body != null)
				{
					BaseBody baseBody = body;
					ArcadeTransform arcadeTransform = baseBody._transform;
					if (baseBody._transform == null)
					{
						break;
					}
					arcadeTransform.position = ret;
				}
				float num5 = (float)obj2 + num4;
				if ((object)_weapon == null)
				{
					break;
				}
				nint num6 = (nint)weapon2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v188 @ r10_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Evil2_Projectile>)+558] (should have been resolved before IL gen)");
				obj++;
				bool flag2 = (nint)obj < 6;
				tP_Evil2_Projectile = (TP_Evil2_Projectile)(object)_weapon;
				if (!flag2)
				{
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		base.Despawn();
	}

	public TP_Evil2_Projectile()
	{
		List<bool> cachedInRange = new List<bool>();
		_cachedInRange = cachedInRange;
		base._002Ector();
	}

	private float _003CInitProjectile_003Eb__20_0()
	{
		return _accel;
	}

	private void _003CInitProjectile_003Eb__20_1(float x)
	{
		_accel = x;
	}

	private void _003CInitProjectile_003Eb__20_2()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
