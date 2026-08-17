using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class LarobbaProjectile : Projectile
{
	private MultiTargetTween _angleTween;

	private MultiTargetTween _movementTween;

	private MultiTargetTween _scaleTween;

	private float _startingAngle;

	private LarobbaWeapon _trueWeapon;

	private Timer _bounceTimer;

	private float _defaultVelocityY;

	public float _moveAngle;

	private float _grav = -5f / 24f;

	private float2 _initialVelocity;

	protected override void Awake()
	{
		//IL_0047: Expected I, but got O
		//IL_00bd: Expected I4, but got I8
		//IL_00cb: Expected O, but got I4
		//IL_0116: Expected I, but got O
		base.Awake();
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = base.transform;
		if ((object)transform != null)
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
		tweenConfig.duration = 1000f;
		tweenConfig.ease = Ease.Linear;
		tweenConfig.repeat = -1;
		tweenConfig.angle = (float?)(object)1;
		MultiTargetTween angleTween = Tweens.Add(tweenConfig);
		_angleTween = angleTween;
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		nint num2 = (nint)array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value = default(object);
			bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_moveAngle", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			tweenConfig2.custom = dictionary;
			tweenConfig2.duration = 1000f;
			tweenConfig2.ease = Ease.Linear;
			MultiTargetTween movementTween = Tweens.Add(tweenConfig2);
			_movementTween = movementTween;
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_0907: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0928: Expected O, but got I4
		//IL_0964: Unknown result type (might be due to invalid IL or missing references)
		//IL_0969: Expected O, but got Unknown
		//IL_0991: Expected I4, but got O
		//IL_013f: Expected O, but got I
		//IL_0171: Expected O, but got I
		//IL_0183: Expected O, but got I
		//IL_01d4: Expected O, but got I4
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Expected O, but got Unknown
		//IL_0289: Expected O, but got I4
		//IL_0289: Expected O, but got I4
		//IL_0335: Expected I, but got O
		//IL_039f: Expected O, but got I4
		//IL_0a51: Expected O, but got F4
		//IL_0a8b: Expected I, but got O
		//IL_0acb: Expected O, but got I
		//IL_0b06: Expected O, but got I4
		//IL_0b42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b47: Expected O, but got Unknown
		//IL_0b7c: Expected I4, but got O
		//IL_0589: Expected O, but got I
		//IL_05c0: Expected F4, but got I
		//IL_05ca: Expected I, but got O
		//IL_0673: Expected O, but got F4
		//IL_06c0: Expected O, but got F4
		//IL_06df: Expected F4, but got I
		//IL_06f1: Expected F4, but got I
		//IL_0733: Expected I, but got O
		//IL_0866: Expected O, but got I4
		//IL_015c->IL0899: Incompatible stack heights: 1 vs 0
		//IL_01b3->IL0899: Incompatible stack heights: 1 vs 0
		//IL_01f8->IL0899: Incompatible stack heights: 1 vs 0
		//IL_0a43->IL0899: Incompatible stack heights: 3 vs 0
		//IL_030b->IL0899: Incompatible stack heights: 3 vs 0
		//IL_037a->IL0899: Incompatible stack heights: 3 vs 0
		//IL_0358->IL0358: Incompatible stack heights: 4 vs 3
		//IL_03c7->IL0899: Incompatible stack heights: 3 vs 0
		//IL_0463->IL0899: Incompatible stack heights: 3 vs 0
		//IL_0485->IL0899: Incompatible stack heights: 3 vs 0
		//IL_0c12->IL0899: Incompatible stack heights: 3 vs 0
		//IL_04be->IL0899: Incompatible stack heights: 3 vs 0
		//IL_0a78->IL0899: Incompatible stack heights: 3 vs 0
		//IL_04e5->IL0899: Incompatible stack heights: 3 vs 0
		//IL_0518->IL0899: Incompatible stack heights: 3 vs 0
		//IL_0547->IL0899: Incompatible stack heights: 3 vs 0
		//IL_0c3b->IL0899: Incompatible stack heights: 3 vs 0
		//IL_0ba6->IL0899: Incompatible stack heights: 3 vs 0
		//IL_05a9->IL0899: Incompatible stack heights: 4 vs 0
		//IL_0bcd->IL0899: Incompatible stack heights: 4 vs 0
		//IL_05f8->IL0899: Incompatible stack heights: 4 vs 0
		//IL_061a->IL0899: Incompatible stack heights: 4 vs 0
		//IL_069c->IL0899: Incompatible stack heights: 4 vs 0
		//IL_0726->IL0899: Incompatible stack heights: 4 vs 0
		//IL_0778->IL0899: Incompatible stack heights: 5 vs 0
		//IL_07c0->IL0899: Incompatible stack heights: 5 vs 0
		BulletPool typeFromHandle = default(BulletPool);
		base.InitProjectile(typeFromHandle, weapon, index);
		float? trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_08d2;
		}
		nint num = (nint)typeof(LarobbaWeapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v84 (Il2CppClass<VampireSurvivors.Objects.Weapons.LarobbaWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v61 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v84 (Il2CppClass<VampireSurvivors.Objects.Weapons.LarobbaWeapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v61 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v176+FFFFFFF8+v71 @ rax_v171*8]");
			if (0 == (nint)typeof(LarobbaWeapon))
			{
				obj3 = 1;
				goto IL_08e1;
			}
		}
		obj3 = 0;
		goto IL_08e1;
		IL_0899:
		throw new NullReferenceException();
		IL_08d2:
		_trueWeapon = (LarobbaWeapon)trueWeapon;
		LarobbaWeapon trueWeapon2 = _trueWeapon;
		_bounceActivated = true;
		float num6 = default(float);
		float num8;
		if ((object)_trueWeapon != null)
		{
			object obj4 = trueWeapon2._lastRobbaIndex + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
			object obj5 = (object)typeFromHandle >> 3;
			object obj6 = obj5 >> 31;
			object obj7 = obj5 + obj6;
			object obj8 = obj7 * 4;
			object obj9 = obj7 + obj8;
			object obj10 = obj9 << 2;
			int num4 = (trueWeapon2._lastRobbaIndex = obj4 - obj10);
			LarobbaWeapon robbaFrames = (LarobbaWeapon)(object)trueWeapon2._robbaFrames;
			if (trueWeapon2._robbaFrames != null)
			{
				bool flag = num4 >= (nint)((MonoBehaviour)robbaFrames).m_CancellationTokenSource;
				LarobbaWeapon larobbaWeapon = (LarobbaWeapon)(nint)((UnityEngine.Object)robbaFrames).m_CachedPtr;
				if (((UnityEngine.Object)robbaFrames).m_CachedPtr != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rdi_v14 (VampireSurvivors.Objects.Weapons.LarobbaWeapon)+20+v392 @ rcx_v29 (System.Int32)*8]");
					Sprite sprite = (Sprite)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rdi_v14 (VampireSurvivors.Objects.Weapons.LarobbaWeapon)+20+v392 @ rcx_v29 (System.Int32)*8]");
					ArcadeSprite arcadeSprite = setFrame((Sprite)0);
					ArcadeSprite arcadeSprite2 = setTint(16777215u);
					if ((object)weapon != null)
					{
						float num5 = weapon.PArea();
						float xScale = default(float);
						ArcadeSprite arcadeSprite3 = setScale(xScale, (float?)(object)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rdi_v14 (VampireSurvivors.Objects.Weapons.LarobbaWeapon)+20+v392 @ rcx_v29 (System.Int32)*8]");
						if ((nint)0 != 0)
						{
							bool flag2 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
							bool flag3 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
							float num7 = default(float);
							if (!(num6 > num7))
							{
								object obj11 = num6 & -2147483649L;
								bool flag4 = (nint)obj11 <= 2139095040;
								num8 = num7;
								if (flag4)
								{
									goto IL_0a19;
								}
							}
							num8 = num6;
							goto IL_0a19;
						}
					}
				}
			}
		}
		goto IL_0899;
		IL_08e1:
		bool flag5 = obj3 == null;
		typeFromHandle = (BulletPool)(object)typeof(LarobbaWeapon);
		trueWeapon = (float?)(object)0;
		if (!flag5)
		{
			typeFromHandle = (BulletPool)(object)typeof(LarobbaWeapon);
			trueWeapon = (float?)weapon;
		}
		goto IL_08d2;
		IL_0a19:
		float radius = num8 * 0.5f;
		if (body != null)
		{
			BaseBody baseBody = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
			_isCullable = false;
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			Transform transform = base.transform;
			if (array != null)
			{
				if ((object)transform != null)
				{
					nint num9 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj12 = default(object);
					bool flag6 = obj12 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					tweenConfig.targets = array;
					tweenConfig.scale = (float?)(object)1;
					tweenConfig.duration = 500f;
					if ((object)_weapon != null)
					{
						float num10 = _weapon.PDuration();
						tweenConfig.delay = num6;
						tweenConfig.ease = Ease.Linear;
						TweenCallback onComplete = delegate
						{
							Despawn();
						};
						tweenConfig.onComplete = onComplete;
						MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
						_scaleTween = scaleTween;
						Weapon weapon2 = _weapon;
						if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
						{
							float2 float5 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
							object obj13 = UnityEngine.Random.value;
							PhaserScene s_scene = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
							{
								PhaserScene s_scene2 = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
								{
									float2 float6 = default(float2);
									base.position = float6;
									Weapon weapon3 = _weapon;
									if ((object)_weapon != null)
									{
										VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
										if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
										{
											nint num11 = (nint)typeof(Vector2);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1861 @ rax_v86 (Il2CppClass<UnityEngine.Vector2>)+B8]");
											nint num12 = 0;
											object obj14 = Vector2.rightVector * characterController._lastFacingDirection;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1862 @ rcx_v65 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
											nint num13 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rax_v84 (VampireSurvivors.Objects.Characters.CharacterController)+238]");
											object obj15 = num13 * 0;
											object obj16 = obj14 + obj15;
											LarobbaWeapon trueWeapon3 = default(LarobbaWeapon);
											if (0 <= (nint)obj16)
											{
												trueWeapon3 = _trueWeapon;
												if ((object)_trueWeapon == null)
												{
													goto IL_0899;
												}
											}
											object obj17 = trueWeapon3._lastAngleIndex + 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
											object obj18 = (object)float6 >> 1;
											object obj19 = obj18 >> 31;
											object obj20 = obj18 + obj19;
											object obj21 = obj20 * 2;
											object obj22 = obj20 + obj21;
											List<float> targetAngles = trueWeapon3._targetAngles;
											object obj23 = obj22 << 2;
											int num14 = (trueWeapon3._lastAngleIndex = obj17 - obj23);
											if (trueWeapon3._targetAngles != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rdx_v48 (System.Collections.Generic.List`1<System.Single>)+18]");
												bool flag7 = (nint)num14 >= (nint)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rdx_v48 (System.Collections.Generic.List`1<System.Single>)+10]");
												object obj24 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rdx_v48 (System.Collections.Generic.List`1<System.Single>)+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rdx_v49+20+v339 @ r8_v26 (System.Int32)*4]");
													_startingAngle = 0f;
													PhaserScene s_scene3 = ArcadePhysics.s_scene;
													if (ArcadePhysics.s_scene != null)
													{
														nint num15 = (nint)this;
														float projectileSpeed = base.ProjectileSpeed;
														LarobbaWeapon larobbaWeapon2 = (LarobbaWeapon)(object)body;
														if (body != null && (object)s_scene3.physics != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rdx_v49+20+v339 @ r8_v26 (System.Int32)*4]");
															float num16 = 0f * (float)obj15;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rdx_v49+20+v339 @ r8_v26 (System.Int32)*4]");
															float num17 = 0f * (float)obj15;
															((Weapon)larobbaWeapon2)._gameMan = (GameManager)num16;
															BaseBody baseBody2 = body;
															if (body != null)
															{
																float num18 = (float)baseBody2._velocity * 1.5f;
																_initialVelocity = (float2)num18;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ rax_v103 (BaseBody)+74]");
																_ = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ rax_v103 (BaseBody)+74]");
																_defaultVelocityY = 0f;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rdx_v49+20+v339 @ r8_v26 (System.Int32)*4]");
																_moveAngle = 0f;
																TweenConfig tweenConfig2 = new TweenConfig();
																object[] array2 = new object[1];
																if (array2 != null)
																{
																	nint num19 = (nint)array2;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																	object obj25 = default(object);
																	bool flag8 = obj25 == null;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																	if (tweenConfig2 != null)
																	{
																		tweenConfig2.targets = array2;
																		Dictionary<string, object> dictionary = new Dictionary<string, object>();
																		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
																		if (dictionary != null)
																		{
																			object value = default(object);
																			bool flag9 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"_moveAngle", value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
																			tweenConfig2.custom = dictionary;
																			tweenConfig2.duration = 1500f;
																			tweenConfig2.ease = Ease.Linear;
																			MultiTargetTween movementTween = Tweens.Add(tweenConfig2);
																			_movementTween = movementTween;
																			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
																			{
																				Rate = 1f
																			};
																			float detune = (float)_indexInWeapon * -100f;
																			soundConfig.Volume = (float?)(object)1;
																			soundConfig.Detune = detune;
																			float time = default(float);
																			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, time);
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
		goto IL_0899;
	}

	public override void Despawn()
	{
		if (_movementTween != null)
		{
			_movementTween.Kill();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable target)
	{
		//IL_00e2: Expected I, but got O
		//IL_0153: Expected O, but got F4
		//IL_017e: Expected O, but got F4
		//IL_0193: Expected F4, but got I
		//IL_01a9: Invalid comparison between F4 and I
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		IDamageable damageable = target;
		bool flag = default(bool);
		if (!flag)
		{
			if (_bounceActivated == flag)
			{
				return;
			}
			_bounceActivated = flag;
			if (_bounceTimer != null)
			{
				_bounceTimer.Cancel();
			}
			Action onComplete = delegate
			{
				_bounceActivated = true;
			};
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer bounceTimer = Timers.Register(0.030000001f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_bounceTimer = bounceTimer;
			damageable = null;
		}
		nint num = (nint)this;
		float projectileSpeed = base.ProjectileSpeed;
		BaseBody baseBody = body;
		float num2 = _startingAngle * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		float num3 = num2 * 0.030000001f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		float num4 = num2 * 0.030000001f;
		baseBody._velocity = (float2)num3;
		float num5 = (float)_initialVelocity * -1f;
		BaseBody baseBody2 = body;
		_initialVelocity = (float2)num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v14 (BaseBody)+74]");
		float num6 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v14 (BaseBody)+74]");
		if (!(-600f > 0f))
		{
			object obj = -600f & -2147483649L;
			if ((nint)obj <= 2139095040)
			{
				goto IL_01fe;
			}
		}
		num6 = -600f;
		goto IL_01fe;
		IL_01fe:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	public override void InternalUpdate()
	{
		//IL_00fc: Expected O, but got I4
		//IL_00fc: Expected F4, but got O
		//IL_005e: Invalid comparison between O and F4
		//IL_0123: Expected O, but got F4
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * _grav;
		float num2 = num * 1000f;
		float num3 = num2 * 0.01f;
		float num4 = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.LarobbaProjectile)+110]");
		float num5 = num4 + 0f;
		setVelocity((float)_initialVelocity, (float?)(object)1);
		float2 float5 = base.position;
		Weapon weapon = _weapon;
		float2 float6 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		float num6 = num5 + renderer.height;
		object obj = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6))
		{
			object obj2 = UnityEngine.Random.value;
			float2 float7 = default(float2);
			base.position = float7;
			_ = _defaultVelocityY;
		}
	}

	private void _003CInitProjectile_003Eb__11_0()
	{
		Despawn();
	}

	private void _003COnHasHitAnObject_003Eb__13_0()
	{
		_bounceActivated = true;
	}
}
