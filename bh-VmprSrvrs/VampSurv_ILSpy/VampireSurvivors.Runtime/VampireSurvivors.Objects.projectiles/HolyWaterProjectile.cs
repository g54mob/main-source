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
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class HolyWaterProjectile : Projectile
{
	private SpriteRenderer _GroundFx;

	private Camera _camera;

	private Tween _angleTween;

	private Tween _positionTween;

	private Timer _hitboxTimer;

	private Timer _expireTimer;

	private Timer _DespawnTimer;

	private ParticleSystem _pfx1;

	private ParticleSystem _pfx2;

	private ParticleSystem _explosionPfx1;

	private ParticleSystem _explosionPfx2;

	private Circle _explosionCircle;

	private const float Radius = 16f;

	private const float ExploRadius = 8f;

	private bool _isBroken;

	private bool _isDespawning;

	private HolyWaterWeapon HolyWater
	{
		get
		{
			//IL_0015: Expected I, but got O
			//IL_001d: Expected I, but got O
			//IL_002d: Expected O, but got I
			//IL_0069: Expected O, but got I
			Weapon weapon = _weapon;
			if ((object)_weapon == null)
			{
				return null;
			}
			nint num = (nint)typeof(HolyWaterWeapon);
			nint num2 = (nint)weapon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.HolyWaterWeapon>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r9_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r8_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.HolyWaterWeapon>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r9_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v7+FFFFFFF8+v46 @ rax_v2*8]");
				if (0 == (nint)typeof(HolyWaterWeapon))
				{
					HolyWaterWeapon holyWaterWeapon = null;
					return (HolyWaterWeapon)_weapon;
				}
			}
			return null;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		GenerateParticleSystems();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0ca3: Expected O, but got I8
		//IL_00d8: Expected O, but got I
		//IL_00d8: Expected O, but got I
		//IL_00ec: Expected O, but got I4
		//IL_0119: Expected O, but got I
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected I4, but got Unknown
		//IL_0d24: Expected O, but got Ref
		//IL_0d51: Expected O, but got F4
		//IL_0d95: Expected O, but got I4
		//IL_0dae: Expected O, but got I4
		//IL_0dd6: Expected I4, but got O
		//IL_04e1: Expected O, but got I
		//IL_0e18: Expected O, but got I4
		//IL_0e31: Expected O, but got I4
		//IL_0e59: Expected I4, but got O
		//IL_0565: Expected O, but got I
		//IL_05ca: Expected O, but got I
		//IL_062f: Invalid comparison between F4 and O
		//IL_083e: Expected O, but got Ref
		//IL_08e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ee: Expected O, but got Unknown
		//IL_0905: Unknown result type (might be due to invalid IL or missing references)
		//IL_090a: Expected O, but got Unknown
		//IL_0921: Unknown result type (might be due to invalid IL or missing references)
		//IL_0926: Expected O, but got Unknown
		//IL_0ef8: Expected O, but got Ref
		//IL_0ff6: Expected O, but got I4
		//IL_1006: Unknown result type (might be due to invalid IL or missing references)
		//IL_100b: Expected O, but got Unknown
		//IL_0a7d: Expected O, but got Ref
		//IL_0501->IL0cc2: Incompatible stack heights: 1 vs 0
		//IL_0528->IL0cc2: Incompatible stack heights: 1 vs 0
		//IL_0e83->IL0cc2: Incompatible stack heights: 1 vs 0
		//IL_0585->IL0cc2: Incompatible stack heights: 2 vs 0
		//IL_05e4->IL0cc2: Incompatible stack heights: 2 vs 0
		//IL_06a7->IL0cc2: Incompatible stack heights: 2 vs 0
		//IL_06c9->IL0cc2: Incompatible stack heights: 2 vs 0
		//IL_0fe3->IL0cc2: Incompatible stack heights: 2 vs 0
		//IL_078e->IL0cc2: Incompatible stack heights: 2 vs 0
		//IL_07bc->IL0cc2: Incompatible stack heights: 2 vs 0
		//IL_0755->IL0cc2: Incompatible stack heights: 2 vs 0
		//IL_0f69->IL0cc2: Incompatible stack heights: 2 vs 0
		//IL_0f20->IL0e88: Incompatible stack heights: 3 vs 2
		//IL_0fbc->IL0cc2: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		Camera camera = _camera;
		object obj3 = 6603577472L;
		if ((object)_camera == null || ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0)
		{
			Camera main = Camera.main;
			_camera = main;
		}
		_ = 0;
		_ = 0;
		_speed = 2f;
		_ = 3238002688L;
		_ = 1;
		_ = 3238002688L;
		_ = 1;
		float num10;
		float num12;
		int num6;
		if (body != null)
		{
			BaseBody baseBody = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+67]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+5F]");
			BaseBody baseBody2 = baseBody.setCircle(16f, (float?)(object)num, (float?)(object)0);
			ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
			_ = 0;
			_ = 1056964608;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1+5F]");
			ArcadeSprite arcadeSprite2 = setOrigin(0.5f, (float?)(object)0);
			ArcadeSprite arcadeSprite3 = setVisible(visible: true);
			BaseBody baseBody3 = body;
			_isCullable = false;
			_isBroken = false;
			if (body != null)
			{
				baseBody3._enable = false;
				if (_hitboxTimer != null)
				{
					_hitboxTimer.Cancel();
				}
				if (_expireTimer != null)
				{
					_expireTimer.Cancel();
				}
				if (_DespawnTimer != null)
				{
					_DespawnTimer.Cancel();
				}
				_isDespawning = false;
				if ((object)_renderer != null)
				{
					_renderer.enabled = true;
					if ((object)_GroundFx != null)
					{
						_GroundFx.enabled = false;
						Weapon weapon2 = _weapon;
						if ((object)_weapon != null)
						{
							float num2 = (float)((Equipment)weapon2)._003CLevel_003Ek__BackingField / 3f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
							object obj4 = default(object);
							int num3 = obj4 + 1;
							bool flag = num3 >= 10;
							int quantity = 10;
							if (!flag)
							{
								quantity = num3;
							}
							if ((object)_weapon != null)
							{
								float num4 = _weapon.PArea();
								Circle circle = new Circle();
								float num5 = num2 * 8f;
								circle._x = 0f;
								float radius = num5 * 3f;
								circle._radius = radius;
								_explosionCircle = circle;
								EmitZone emitZone = new EmitZone();
								emitZone._type = EmitZoneType.Random;
								emitZone._source = _explosionCircle;
								RenderingExtensions.SetEmitZone(_pfx1, emitZone);
								RenderingExtensions.SetQuantity(_pfx1, quantity);
								EmitZone emitZone2 = new EmitZone();
								emitZone2._type = EmitZoneType.Random;
								emitZone2._source = _explosionCircle;
								RenderingExtensions.SetEmitZone(_pfx2, emitZone2);
								RenderingExtensions.SetQuantity(_pfx2, quantity);
								Weapon weapon3 = _weapon;
								if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
								{
									Transform transform = ((Equipment)weapon3)._003COwner_003Ek__BackingField.transform;
									if ((object)transform != null)
									{
										_ = 0;
										_ = 0;
										if (((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
										{
											object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
											Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj5);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-51]");
											_ = 0;
											Bounds bounds = CameraExtensions.OrthographicBounds(_camera);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1489 @ rax_v61 (UnityEngine.Bounds)+10]");
											_ = 0;
											object obj6 = UnityEngine.Random.value;
											float2 float5 = default(float2);
											base.position = float5;
											HolyWaterWeapon holyWater = HolyWater;
											if ((object)holyWater != null)
											{
												object obj7 = holyWater._lasAngleIndex + 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
												object obj8 = 0 * 2;
												List<float> targetAngles = holyWater._targetAngles;
												object obj9 = obj8 << 2;
												num6 = (holyWater._lasAngleIndex = obj7 - obj9);
												if (holyWater._targetAngles != null)
												{
													int num7 = num6;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rdx_v37 (System.Collections.Generic.List`1<System.Single>)+18]");
													bool flag2 = (nint)num7 >= (nint)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rdx_v37 (System.Collections.Generic.List`1<System.Single>)+10]");
													object obj10 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ rdx_v37 (System.Collections.Generic.List`1<System.Single>)+10]");
													if ((nint)0 != 0)
													{
														HolyWaterWeapon holyWater2 = HolyWater;
														if ((object)holyWater2 != null)
														{
															object obj11 = holyWater2._lastRadiusIndex + 1;
															Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
															object obj12 = 0 * 2;
															List<float> targetRadii = holyWater2._targetRadii;
															object obj13 = obj12 << 2;
															int num8 = (holyWater2._lastRadiusIndex = obj11 - obj13);
															if (holyWater2._targetRadii != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rdx_v42 (System.Collections.Generic.List`1<System.Single>)+18]");
																bool flag3 = (nint)num8 >= (nint)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rdx_v42 (System.Collections.Generic.List`1<System.Single>)+10]");
																object obj14 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ rdx_v42 (System.Collections.Generic.List`1<System.Single>)+10]");
																if ((nint)0 != 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
																	Weapon weapon4 = _weapon;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ rdx_v38+20+v384 @ r8_v27 (System.Int32)*4]");
																	nint num9 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rdx_v43+20+v425 @ rcx_v62 (System.Int32)*4]");
																	object obj15 = num9 * 0;
																	if ((object)_weapon != null)
																	{
																		bool flag4 = weapon4.IsHoming;
																		num10 = 0.5f;
																		if (flag4)
																		{
																			goto IL_0683;
																		}
																		float num11 = _weapon.PAmount();
																		bool flag5 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)4f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15);
																		num12 = 4f;
																		if (!flag5)
																		{
																			bool flag6 = _indexInWeapon != 0;
																			num10 = 4f;
																			num12 = 4f;
																			if (!flag6)
																			{
																				goto IL_0683;
																			}
																		}
																		goto IL_0fc1;
																	}
																}
															}
														}
													}
												}
											}
										}
										else
										{
											UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0cc2;
		IL_0fc1:
		PhaserScene s_scene = ArcadePhysics.s_scene;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore;
		if (ArcadePhysics.s_scene != null)
		{
			PhaserScene.Renderer renderer = s_scene._renderer;
			if (s_scene._renderer != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
				if ((object)_renderer != null)
				{
					int sortingOrder = default(int);
					_renderer.sortingOrder = sortingOrder;
					Tween positionTween = _positionTween;
					if (_positionTween != null && positionTween._003Cactive_003Ek__BackingField)
					{
						DG.Tweening.TweenExtensions.Kill(_positionTween);
					}
					Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ rbp_v1-49]");
					_ = 0;
					tweenerCore = ShortcutExtensions.DOMove(_cachedTransform, endValue, 0.75f);
					TweenCallback tweenCallback2;
					if (tweenerCore != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1842 @ rax_v93 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 != 0)
						{
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
							bool flag7 = (nint)0 == 0;
							_ = 0;
							if (!flag7)
							{
								object obj16 = tweenerCore + 184;
								object obj17 = obj16 >> 12;
								object obj18 = obj17 & 0x1FFFFF;
								object obj19 = obj18 >> 6;
								object obj20 = obj18 & 0x3F;
								nint num14;
								do
								{
									object obj21 = 1 << (int)obj20;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ r12_v1+462E0+v1906 @ rdx_v73*8]");
									object obj22 = 0 | obj21;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ r12_v1+462E0+v1906 @ rdx_v73*8]");
									nint num13 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ r12_v1+462E0+v1906 @ rdx_v73*8]");
									if (num13 == 0)
									{
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ r12_v1+462E0+v1906 @ rdx_v73*8]");
									num14 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ r12_v1+462E0+v1906 @ rdx_v73*8]");
								}
								while (num14 != 0);
								TweenCallback tweenCallback = Break;
								tweenCallback2 = tweenCallback;
								goto IL_0993;
							}
						}
					}
					TweenCallback tweenCallback3 = Break;
					bool flag8 = tweenerCore == null;
					tweenCallback2 = tweenCallback3;
					if (!flag8)
					{
						goto IL_0993;
					}
					goto IL_09c2;
				}
			}
		}
		goto IL_0cc2;
		IL_0683:
		Weapon weapon5 = _weapon;
		if ((object)_weapon == null || (object)weapon5._gameMan == null)
		{
			goto IL_0cc2;
		}
		Transform transform2 = weapon5._gameMan.FindClosestEnemyToPlayer(((Equipment)weapon5)._003COwner_003Ek__BackingField);
		bool flag9 = (object)transform2 == null;
		num12 = num10;
		num6 = 0;
		if (!flag9)
		{
			bool flag10 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			num12 = num10;
			num6 = 0;
			if (!flag10)
			{
				Transform transform3 = transform2.transform;
				if ((object)transform3 == null)
				{
					goto IL_0cc2;
				}
				_ = 0;
				_ = 0;
				bool flag11 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
				object obj23 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
				Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj23);
				num12 = num10;
				num6 = 0;
			}
		}
		goto IL_0fc1;
		IL_09c2:
		_positionTween = tweenerCore;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (_positionTween != null)
		{
			Tween angleTween = _angleTween;
			if (_angleTween != null && angleTween._003Cactive_003Ek__BackingField)
			{
				DG.Tweening.TweenExtensions.Kill(_angleTween);
			}
			Vector3 endValue2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
			_ = -360f;
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(_cachedTransform, endValue2, 0.6f, RotateMode.FastBeyond360);
			if (tweenerCore2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2250 @ rax_v100 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2250 @ rax_v100 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2250 @ rax_v100 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2250 @ rax_v100 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2250 @ rax_v100 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 1;
						_ = 0;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2250 @ rax_v100 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2250 @ rax_v100 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 4294967295L;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2250 @ rax_v100 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
						if ((nint)0 == 0)
						{
							_ = 2139095040;
						}
					}
				}
			}
			_angleTween = tweenerCore2;
			Tween angleTween2 = _angleTween;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (_angleTween != null)
			{
				angleTween2.stringId = "DefaultGameTweenId";
				return;
			}
		}
		goto IL_0cc2;
		IL_0993:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1842 @ rax_v93 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_09c2;
		IL_0cc2:
		throw new NullReferenceException();
	}

	public unsafe override void InternalUpdate()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_023d: Expected I4, but got O
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_0169: Expected O, but got I4
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_02ae: Expected I4, but got O
		//IL_02b3->IL0192: Incompatible stack heights: 7 vs 0
		object obj2 = default(object);
		object obj = obj2 - 280;
		if (_isBroken && !_isDespawning)
		{
			Transform cachedTransform = _cachedTransform;
			_ = 0;
			_ = 0;
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			Transform pfx = (Transform)(object)_pfx1;
			_ = 0;
			Weapon weapon = _weapon;
			_ = 1;
			_ = 1;
			bool flag2 = (object)_weapon == null;
			float num = (float)((Equipment)weapon)._003CLevel_003Ek__BackingField / 3f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			bool flag3 = (object)_pfx1 == null;
			object obj4 = default(object);
			object obj3 = obj4 + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1+D0]");
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			bool flag4 = ((UnityEngine.Object)pfx).m_CachedPtr == (IntPtr)0;
			ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
			ParticleSystem.Emit_Injected(((UnityEngine.Object)pfx).m_CachedPtr, ref emitParams, (int)obj3);
			Weapon weapon2 = _weapon;
			Transform pfx2 = (Transform)(object)_pfx2;
			bool flag5 = (object)_weapon == null;
			float num2 = (float)((Equipment)weapon2)._003CLevel_003Ek__BackingField / 3f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			bool flag6 = (object)_pfx2 == null;
			object obj6 = default(object);
			object obj5 = obj6 + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1+50]");
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			obj = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1+D0]");
			_ = 0;
			bool flag7 = ((UnityEngine.Object)pfx2).m_CachedPtr == (IntPtr)0;
			object obj7 = obj - 64;
			ParticleSystem.Emit_Injected(((UnityEngine.Object)pfx2).m_CachedPtr, ref *(ParticleSystem.EmitParams*)obj7, (int)obj5);
		}
	}

	private unsafe void Break()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0630: Expected I, but got O
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected O, but got Unknown
		//IL_0252: Expected O, but got I
		//IL_0252: Expected O, but got I
		//IL_043a: Expected O, but got I4
		//IL_04c1: Expected O, but got I4
		//IL_07c6: Expected O, but got Ref
		//IL_07f9: Expected O, but got I4
		//IL_08ab: Expected O, but got Ref
		//IL_08fe: Expected O, but got I4
		//IL_0931: Expected O, but got I
		//IL_05f0: Expected F4, but got I4
		//IL_06b8->IL05f9: Incompatible stack heights: 1 vs 0
		//IL_029f->IL05f9: Incompatible stack heights: 6 vs 0
		//IL_0367->IL05f9: Incompatible stack heights: 6 vs 0
		//IL_072a->IL05f9: Incompatible stack heights: 6 vs 0
		//IL_0410->IL05f9: Incompatible stack heights: 6 vs 0
		//IL_0494->IL05f9: Incompatible stack heights: 6 vs 0
		//IL_04db->IL05f9: Incompatible stack heights: 6 vs 0
		//IL_0507->IL05f9: Incompatible stack heights: 6 vs 0
		//IL_05f9->IL0943: Incompatible stack heights: 14 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (_isBroken)
		{
			return;
		}
		_isBroken = true;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v5 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		ArcadeSprite sprite = _sprite;
		if ((object)_sprite != null)
		{
			BaseBody baseBody = sprite.body;
			if (sprite.body != null)
			{
				baseBody._velocity = Vector2.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
				_ = 0;
				if (_objectsHit != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
					BaseBody baseBody2 = body;
					if (body != null)
					{
						baseBody2._enable = true;
						if ((object)_GroundFx != null)
						{
							Transform transform = _GroundFx.transform;
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							Transform transform2 = _GroundFx.transform;
							if ((object)_weapon != null)
							{
								float num3 = _weapon.PArea();
								bool flag2 = (object)transform2 == null;
								bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
								Vector3 value2 = default(Vector3);
								Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
								bool flag4 = (object)_GroundFx == null;
								_GroundFx.enabled = true;
								bool flag5 = (object)_weapon == null;
								float num4 = _weapon.PArea();
								object obj3 = default(object);
								float num5 = (float)obj3 * 16f;
								_ = 0;
								_ = 0;
								_ = 1;
								_ = 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
								object obj4 = num5 ^ 0;
								float num6 = (float)obj4 + 8f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
								object obj5 = num5 ^ 0;
								float num7 = (float)obj5 + 8f;
								bool flag6 = body == null;
								BaseBody baseBody3 = body;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1A0]");
								nint num8 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
								BaseBody baseBody4 = baseBody3.setCircle(num5, (float?)(object)num8, (float?)(object)0);
								if (_hitboxTimer != null)
								{
									_hitboxTimer.Cancel();
								}
								if ((object)_weapon != null)
								{
									float hitBoxDelay = _weapon.HitBoxDelay;
									Action onComplete = delegate
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
									};
									float num9 = hitBoxDelay * 0.001f;
									bool flag7 = default(bool);
									MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
									int repeat = default(int);
									TimerType type = default(TimerType);
									Timer hitboxTimer = Timers.Register(num9, onComplete, null, isLooped: true, flag7, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
									_hitboxTimer = hitboxTimer;
									if (_expireTimer != null)
									{
										_expireTimer.Cancel();
									}
									if ((object)_weapon != null)
									{
										float num10 = _weapon.PDuration();
										Action onComplete2 = StartDespawn;
										float duration = num9 * 0.001f;
										Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: false, flag7, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
										_expireTimer = expireTimer;
										PhaserScene s_scene = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null)
										{
											PhaserScene.Renderer renderer = s_scene._renderer;
											if (s_scene._renderer != null)
											{
												int num11 = renderer.pixelHeight >> 31;
												object obj6 = renderer.pixelHeight - num11;
												object obj7 = obj6 >> 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
												int sortingOrder = default(int);
												RenderingExtensions.SetDepth(_pfx1, sortingOrder);
												RenderingExtensions.SetDepth(_pfx2, sortingOrder);
												if ((object)_GroundFx != null)
												{
													_GroundFx.sortingOrder = sortingOrder;
													object explosionPfx = _explosionPfx1;
													_ = 0;
													obj = 0;
													if ((object)_explosionPfx1 != null)
													{
														Transform transform3 = _explosionPfx1.transform;
														if ((object)transform3 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ rax_v95 (UnityEngine.Transform)+10]");
															bool flag8 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ rax_v95 (UnityEngine.Transform)+10]");
															Transform.get_position_Injected((IntPtr)0, out value);
															_ = 0;
															_ = 1;
															_ = 1;
															bool flag9 = (object)_explosionPfx1 == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
															_ = 0;
															_ = 0;
															_ = 0;
															_ = 0;
															_ = 0;
															_ = 0;
															_ = 0;
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rsi_v23 (System.Object)+10]");
															bool flag10 = (nint)0 == 0;
															object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v336 @ rsi_v23 (System.Object)+10]");
															ParticleSystem.Emit_Injected((IntPtr)0, ref *(ParticleSystem.EmitParams*)obj8, 1);
															object explosionPfx2 = _explosionPfx2;
															_ = 0;
															obj = 0;
															bool flag11 = (object)_explosionPfx2 == null;
															Transform transform4 = _explosionPfx2.transform;
															bool flag12 = (object)transform4 == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1672 @ rax_v106 (UnityEngine.Transform)+10]");
															bool flag13 = (nint)0 == 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1672 @ rax_v106 (UnityEngine.Transform)+10]");
															Transform.get_position_Injected((IntPtr)0, out value);
															_ = 0;
															_ = 1;
															_ = 1;
															bool flag14 = (object)_explosionPfx2 == null;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
															_ = 0;
															_ = 0;
															_ = 0;
															_ = 0;
															_ = 0;
															_ = 0;
															_ = 0;
															_ = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1041 @ rsi_v24 (System.Object)+10]");
															bool flag15 = (nint)0 == 0;
															object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1041 @ rsi_v24 (System.Object)+10]");
															ParticleSystem.Emit_Injected((IntPtr)0, ref *(ParticleSystem.EmitParams*)obj9, 3);
															SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
															_ = 0;
															_ = 1051931443;
															_ = 1;
															soundConfig.Rate = 1f;
															object obj10 = _indexInWeapon - 4;
															soundConfig.Rate = 2f;
															float detune = (float)obj10 * 50f;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
															soundConfig.Volume = (float?)(object)0;
															soundConfig.Detune = detune;
															PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Holywater, soundConfig, 200f, 12, flag7 ? 1 : 0);
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

	private void StartDespawn()
	{
		//IL_0042: Expected O, but got I4
		//IL_0076: Expected O, but got I4
		//IL_00a6: Expected O, but got I4
		//IL_0118: Expected O, but got I4
		//IL_0235: Expected O, but got I
		//IL_029e: Expected I, but got O
		_isCullable = true;
		_GroundFx.enabled = false;
		Tween angleTween = _angleTween;
		bool flag = _angleTween == null;
		bool flag2 = false;
		object obj = 0;
		if (!flag)
		{
			bool flag3 = !angleTween._003Cactive_003Ek__BackingField;
			flag2 = false;
			obj = 0;
			if (!flag3)
			{
				DG.Tweening.TweenExtensions.Kill(_angleTween);
				flag2 = false;
				obj = 0;
			}
		}
		Tween positionTween = _positionTween;
		if (_positionTween != null && positionTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_positionTween);
			flag2 = false;
			obj = 0;
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
			flag2 = false;
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
			flag2 = false;
		}
		_isDespawning = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9E0]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9E0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v401 @ rax_v15 (should have been resolved before IL gen)");
		ParticleSystem.MinMaxCurveBlittable minMaxCurveBlittable = default(ParticleSystem.MinMaxCurveBlittable);
		ParticleSystem.MinMaxCurve minMaxCurve = ParticleSystem.MinMaxCurveBlittable.ToMinMaxCurve(ref minMaxCurveBlittable);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.HolyWaterProjectile>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		float duration = default(float);
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer despawnTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_DespawnTimer = despawnTimer;
	}

	public override void Despawn()
	{
		_isCullable = true;
		_GroundFx.enabled = false;
		Tween angleTween = _angleTween;
		if (_angleTween != null && angleTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_angleTween);
		}
		Tween positionTween = _positionTween;
		if (_positionTween != null && positionTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_positionTween);
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_DespawnTimer != null)
		{
			_DespawnTimer.Cancel();
		}
		base.Despawn();
	}

	private void GetComponents()
	{
		Camera camera = _camera;
		if ((object)_camera == null || ((UnityEngine.Object)camera).m_CachedPtr == (IntPtr)0)
		{
			Camera main = Camera.main;
			_camera = main;
		}
	}

	private unsafe void GenerateParticleSystems()
	{
		//IL_0008: Expected O, but got Ref
		//IL_017e: Expected O, but got Ref
		//IL_0198: Expected native int or pointer, but got O
		//IL_0b25: Expected O, but got I4
		//IL_01b0: Expected O, but got Ref
		//IL_01d7: Expected O, but got I
		//IL_01f1: Expected native int or pointer, but got O
		//IL_020b: Expected O, but got I
		//IL_0239: Expected O, but got I4
		//IL_0252: Expected O, but got Ref
		//IL_026c: Expected native int or pointer, but got O
		//IL_0b42: Expected O, but got I4
		//IL_029e: Expected O, but got Ref
		//IL_02b8: Expected native int or pointer, but got O
		//IL_0b7c: Expected O, but got I
		//IL_04b8: Expected O, but got Ref
		//IL_04d2: Expected native int or pointer, but got O
		//IL_0bc8: Expected O, but got I
		//IL_0510: Expected O, but got Ref
		//IL_0531: Expected O, but got I
		//IL_054b: Expected native int or pointer, but got O
		//IL_0565: Expected O, but got I
		//IL_0593: Expected O, but got I4
		//IL_05ac: Expected O, but got Ref
		//IL_05c6: Expected native int or pointer, but got O
		//IL_0c02: Expected O, but got I
		//IL_05fe: Expected O, but got Ref
		//IL_0618: Expected native int or pointer, but got O
		//IL_0c34: Expected O, but got I
		//IL_0669: Expected O, but got I
		//IL_07a8: Expected O, but got Ref
		//IL_07cf: Expected O, but got I
		//IL_07e9: Expected native int or pointer, but got O
		//IL_0803: Expected O, but got I
		//IL_0831: Expected O, but got I4
		//IL_084a: Expected O, but got Ref
		//IL_0864: Expected native int or pointer, but got O
		//IL_0c80: Expected O, but got I
		//IL_089c: Expected O, but got Ref
		//IL_08b6: Expected native int or pointer, but got O
		//IL_0cba: Expected O, but got I
		//IL_096b: Expected O, but got Ref
		//IL_0992: Expected O, but got I
		//IL_09ac: Expected native int or pointer, but got O
		//IL_09cb: Expected O, but got I
		//IL_09f9: Expected O, but got I4
		//IL_0a12: Expected O, but got Ref
		//IL_0a2c: Expected native int or pointer, but got O
		//IL_0cf4: Expected O, but got I
		//IL_0a64: Expected O, but got Ref
		//IL_0a7e: Expected native int or pointer, but got O
		//IL_0d2e: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Circle circle = (_explosionCircle = new Circle());
		circle._x = 0f;
		circle._radius = 8f;
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"ProjectileFlameHoly");
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
			((List<object>)(object)list).AddWithResize((object)"ProjectileFlameBlue");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(1f, 1f));
		particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+2F0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(90f, 90f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+100]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+110]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(600f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 0f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+120]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+130]");
		_ = 0;
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-68]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.25f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+140]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+150]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-60]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-40]");
		_ = 0;
		EmitZone emitZone = new EmitZone();
		emitZone._type = EmitZoneType.Random;
		emitZone._source = _explosionCircle;
		particleSystemConfig._emitZone = emitZone;
		particleSystemConfig._on = false;
		ParticleSystem pfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, _cachedTransform, "PfxEmitter1");
		_pfx1 = pfx;
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
			((List<object>)(object)list2).AddWithResize((object)"ProjectileFlameBlue");
		}
		else
		{
			int num4 = list2._size + 1;
			list2._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig2._frame = list2;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(1f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+160]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+170]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-38]");
		particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-18]");
		_ = 0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 384));
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+2F0]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(90f, 90f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+180]");
		particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+190]");
		_ = 0;
		minMaxCurve3 = new ParticleSystem.MinMaxCurve(600f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 416));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0.2f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+1A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+1B0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-10]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+10]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 448));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0.25f, 0.5f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+1C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+1D0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+18]");
		particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+38]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+2F0]");
		particleSystemConfig2._blendMode = (BlendMode?)(object)0;
		EmitZone emitZone2 = new EmitZone();
		emitZone2._type = EmitZoneType.Random;
		emitZone2._source = _explosionCircle;
		particleSystemConfig2._emitZone = emitZone2;
		particleSystemConfig2._on = false;
		ParticleSystem pfx2 = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig2, _cachedTransform, "PfxEmitter2");
		_pfx2 = pfx2;
		ParticleSystemConfig particleSystemConfig3 = new ParticleSystemConfig("vfx");
		List<string> list3 = new List<string>();
		int version5 = list3._version + 1;
		list3._version = version5;
		string[] items5 = list3._items;
		if (list3._size >= items5.Length)
		{
			((List<object>)(object)list3).AddWithResize((object)"HitCloud2");
		}
		else
		{
			int num5 = list3._size + 1;
			list3._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig3._frame = list3;
		ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 480));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+2F0]");
		particleSystemConfig3._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+1E0]");
		particleSystemConfig3._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+1F0]");
		_ = 0;
		minMaxCurve3 = new ParticleSystem.MinMaxCurve(150f);
		particleSystemConfig3._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 512));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(1f, 0.5f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+200]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+210]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+40]");
		particleSystemConfig3._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+50]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+60]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve12 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 544));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve12, new ParticleSystem.MinMaxCurve(0.25f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+220]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+230]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+68]");
		particleSystemConfig3._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+88]");
		_ = 0;
		particleSystemConfig3._on = false;
		ParticleSystem explosionPfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig3, _cachedTransform, "ExplosionPfx1");
		_explosionPfx1 = explosionPfx;
		ParticleSystemConfig particleSystemConfig4 = new ParticleSystemConfig("vfx");
		List<string> list4 = new List<string>();
		list4.Add("HitCloud1");
		particleSystemConfig4._frame = list4;
		ParticleSystem.MinMaxCurve minMaxCurve13 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 576));
		_ = 0;
		_ = 3;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+2F0]");
		particleSystemConfig4._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve13, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+240]");
		particleSystemConfig4._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+250]");
		_ = 0;
		minMaxCurve3 = new ParticleSystem.MinMaxCurve(150f);
		particleSystemConfig4._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve14 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 608));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve14, new ParticleSystem.MinMaxCurve(1f, 0.5f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+260]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+270]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+90]");
		particleSystemConfig4._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+B0]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve15 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 640));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve15, new ParticleSystem.MinMaxCurve(0.25f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+280]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+290]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+B8]");
		particleSystemConfig4._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+D8]");
		_ = 0;
		particleSystemConfig4._on = false;
		ParticleSystem explosionPfx2 = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig4, _cachedTransform, "ExplosionPfx2");
		_explosionPfx2 = explosionPfx2;
	}

	private void _003CBreak_003Eb__21_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
