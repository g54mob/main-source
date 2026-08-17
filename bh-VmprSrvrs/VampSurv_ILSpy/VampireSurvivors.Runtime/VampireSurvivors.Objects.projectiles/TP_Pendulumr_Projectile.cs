using System;
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

public class TP_Pendulumr_Projectile : Projectile
{
	private float _radius = 16f;

	private PhaserSprite _pendulumSprite;

	private PhaserSprite _shaftSprite;

	private PhaserSprite _stretchSprite;

	private Tween _radiusTween;

	private MultiTargetTween _scaleTween;

	private bool _isDespawning;

	private MultiTargetTween _angleTween;

	private Timer _expireTimer;

	private Timer _hitBoxTimer;

	private Vector3 penOrigin;

	private float _elapsedTime;

	private float _currentLength;

	private int _swingDirection;

	private float _previousAngle;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite pendulumSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Gears01");
		_pendulumSprite = pendulumSprite;
		GameObject gameObject2 = base.gameObject;
		PhaserSprite shaftSprite = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "ThosePeople", "TP_VFX_Gears06");
		_shaftSprite = shaftSprite;
		GameObject gameObject3 = base.gameObject;
		PhaserSprite stretchSprite = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "ThosePeople", "TP_VFX_Gears00");
		_stretchSprite = stretchSprite;
		Transform transform = _stretchSprite.transform;
		Transform parent = _shaftSprite.transform;
		transform.SetParent(parent, worldPositionStays: true);
		Transform transform2 = _stretchSprite.transform;
		bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0ba7: Expected O, but got I4
		//IL_0036: Expected O, but got I
		//IL_0036: Expected O, but got I
		//IL_00cc: Expected O, but got Ref
		//IL_013d: Expected O, but got Ref
		//IL_019c: Expected O, but got I
		//IL_01ed: Expected O, but got I
		//IL_023e: Expected O, but got I
		//IL_025f: Expected I4, but got O
		//IL_0276: Expected I4, but got O
		//IL_0c37: Expected O, but got Ref
		//IL_0c6a: Expected F4, but got I
		//IL_0c9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca2: Expected O, but got Unknown
		//IL_0cb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbc: Expected O, but got Unknown
		//IL_0363: Expected O, but got I
		//IL_0363: Expected O, but got I
		//IL_039a: Expected O, but got I4
		//IL_0cee: Expected I, but got O
		//IL_0d46: Expected O, but got Ref
		//IL_0468: Expected O, but got I4
		//IL_0d84: Expected I, but got O
		//IL_0ddc: Expected O, but got Ref
		//IL_0534: Expected I4, but got O
		//IL_0e42: Expected O, but got I4
		//IL_0593: Unknown result type (might be due to invalid IL or missing references)
		//IL_0598: Expected I4, but got Unknown
		//IL_0621: Expected O, but got I4
		//IL_0e98: Expected O, but got Ref
		//IL_0ebf: Expected O, but got I
		//IL_0806: Unknown result type (might be due to invalid IL or missing references)
		//IL_080b: Expected O, but got Unknown
		//IL_0f38: Expected O, but got Ref
		//IL_10fc: Expected O, but got Ref
		//IL_107d: Expected O, but got I4
		//IL_0fef: Expected O, but got Ref
		//IL_0b4a: Expected I4, but got I8
		//IL_0cdb->IL0bf6: Incompatible stack heights: 1 vs 0
		//IL_0381->IL0bf6: Incompatible stack heights: 1 vs 0
		//IL_03b8->IL0bf6: Incompatible stack heights: 1 vs 0
		//IL_03eb->IL0bf6: Incompatible stack heights: 1 vs 0
		//IL_041e->IL0bf6: Incompatible stack heights: 1 vs 0
		//IL_0788->IL0bf6: Incompatible stack heights: 16 vs 0
		//IL_07b2->IL0bf6: Incompatible stack heights: 16 vs 0
		//IL_0992->IL0bf6: Incompatible stack heights: 22 vs 0
		//IL_086a->IL0bf6: Incompatible stack heights: 22 vs 0
		//IL_10c2->IL0bf6: Incompatible stack heights: 22 vs 0
		//IL_0f8e->IL0bf6: Incompatible stack heights: 22 vs 0
		//IL_09c6->IL0bf6: Incompatible stack heights: 22 vs 0
		//IL_089e->IL0bf6: Incompatible stack heights: 22 vs 0
		//IL_09ef->IL0bf6: Incompatible stack heights: 22 vs 0
		//IL_08bc->IL0bf6: Incompatible stack heights: 22 vs 0
		//IL_0a11->IL0bf6: Incompatible stack heights: 22 vs 0
		//IL_0a40->IL0bf6: Incompatible stack heights: 22 vs 0
		//IL_0fb5->IL0bf6: Incompatible stack heights: 22 vs 0
		//IL_08f0->IL0bf6: Incompatible stack heights: 22 vs 0
		//IL_0919->IL0bf6: Incompatible stack heights: 22 vs 0
		//IL_093b->IL0bf6: Incompatible stack heights: 22 vs 0
		//IL_0a94->IL0bf6: Incompatible stack heights: 23 vs 0
		//IL_096a->IL0bf6: Incompatible stack heights: 22 vs 0
		//IL_0ae6->IL0bf6: Incompatible stack heights: 24 vs 0
		//IL_0b64->IL0bf6: Incompatible stack heights: 24 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		_isDespawning = false;
		_isCullable = false;
		_elapsedTime = 0f;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		_ = 0;
		_ = 0;
		_ = 3204448256L;
		_ = 1;
		_ = 3204448256L;
		_ = 1;
		float currentLength;
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
				if ((object)_pendulumSprite != null)
				{
					Transform transform = _pendulumSprite.transform;
					if ((object)transform != null)
					{
						_ = -0f;
						Vector3 localEulerAngles = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
						transform.localEulerAngles = localEulerAngles;
						if ((object)_shaftSprite != null)
						{
							Transform transform2 = _shaftSprite.transform;
							if ((object)transform2 != null)
							{
								_ = -0f;
								Vector3 localEulerAngles2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
								transform2.localEulerAngles = localEulerAngles2;
								_ = 0;
								_ = 1065353216;
								_ = 1;
								if ((object)_shaftSprite != null)
								{
									PhaserSprite shaftSprite = _shaftSprite;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
									PhaserSprite phaserSprite = shaftSprite.setOrigin(0.5f, (float?)(object)0);
									_ = 0;
									_ = 1065353216;
									_ = 1;
									if ((object)_stretchSprite != null)
									{
										PhaserSprite stretchSprite = _stretchSprite;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
										PhaserSprite phaserSprite2 = stretchSprite.setOrigin(0.5f, (float?)(object)0);
										_ = 0;
										_ = 1084227584;
										_ = 1;
										if ((object)_stretchSprite != null)
										{
											PhaserSprite stretchSprite2 = _stretchSprite;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
											PhaserSprite phaserSprite3 = stretchSprite2.setScale(1f, (float?)(object)0);
											bool flag = _indexInWeapon != 0;
											int num3 = (int)"TP_VFX_Gears01";
											if (!flag)
											{
												num3 = (int)"TP_VFX_Gears02";
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
											if ((object)_pendulumSprite != null)
											{
												Sprite sprite = default(Sprite);
												PhaserSprite phaserSprite4 = _pendulumSprite.setFrame(sprite);
												PhaserSprite pendulumSprite = _pendulumSprite;
												if ((object)_pendulumSprite != null && (object)pendulumSprite._spriteRenderer != null)
												{
													Sprite sprite2 = pendulumSprite._spriteRenderer.sprite;
													if ((object)sprite2 != null)
													{
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v70 (UnityEngine.Sprite)+10]");
														bool flag2 = (nint)0 == 0;
														object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v70 (UnityEngine.Sprite)+10]");
														Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj3);
														_ = 0;
														_ = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-19]");
														_radius = 0f;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-19]");
														float num5 = default(float);
														float num4 = 0f * num5;
														_ = 1;
														_ = 1;
														float num6 = num4;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
														object obj4 = num6 ^ 0;
														float num7 = num4;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
														object obj5 = num7 ^ 0;
														if (body != null)
														{
															BaseBody baseBody3 = body;
															float radius = num4;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
															nint num8 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
															BaseBody baseBody4 = baseBody3.setCircle(radius, (float?)(object)num8, (float?)(object)0);
															if ((object)_pendulumSprite != null)
															{
																PhaserSprite phaserSprite5 = _pendulumSprite.setScale(num5, (float?)(object)0);
																if ((object)_pendulumSprite != null)
																{
																	PhaserSprite phaserSprite6 = _pendulumSprite.setAlpha(1f);
																	if ((object)_pendulumSprite != null)
																	{
																		PhaserSprite phaserSprite7 = _pendulumSprite.setVisible(visible: true);
																		if ((object)_pendulumSprite != null)
																		{
																			Transform transform3 = _pendulumSprite.transform;
																			nint num9 = (nint)typeof(Vector3);
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1842 @ rcx_v74 (Il2CppClass<UnityEngine.Vector3>)+B8]");
																			nint num10 = 0;
																			bool flag3 = (object)transform3 == null;
																			_ = Vector3.zeroVector;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1843 @ rax_v82 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1767 @ rax_v80 (UnityEngine.Transform)+10]");
																			bool flag4 = (nint)0 == 0;
																			object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1767 @ rax_v80 (UnityEngine.Transform)+10]");
																			Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj6);
																			bool flag5 = (object)_shaftSprite == null;
																			PhaserSprite phaserSprite8 = _shaftSprite.setScale(num5, (float?)(object)0);
																			bool flag6 = (object)_shaftSprite == null;
																			PhaserSprite phaserSprite9 = _shaftSprite.setAlpha(1f);
																			bool flag7 = (object)_shaftSprite == null;
																			PhaserSprite phaserSprite10 = _shaftSprite.setVisible(visible: true);
																			bool flag8 = (object)_shaftSprite == null;
																			Transform transform4 = _shaftSprite.transform;
																			nint num11 = (nint)typeof(Vector3);
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2179 @ rcx_v83 (Il2CppClass<UnityEngine.Vector3>)+B8]");
																			nint num12 = 0;
																			bool flag9 = (object)transform4 == null;
																			_ = Vector3.zeroVector;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2173 @ rax_v93 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
																			_ = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2253 @ rax_v91 (UnityEngine.Transform)+10]");
																			bool flag10 = (nint)0 == 0;
																			object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2253 @ rax_v91 (UnityEngine.Transform)+10]");
																			Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)obj7);
																			bool flag11 = (object)_pendulumSprite == null;
																			PhaserSprite phaserSprite11 = _pendulumSprite.setDepth(3);
																			int num13 = (int)_pendulumSprite;
																			bool flag12 = (object)_pendulumSprite == null;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2182 @ rdi_v29 (System.Int32)+28]");
																			int num14 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2182 @ rdi_v29 (System.Int32)+28]");
																			bool flag13 = (nint)0 == 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ rdi_v30 (System.Int32)+10]");
																			bool flag14 = (nint)0 == 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ rdi_v30 (System.Int32)+10]");
																			object obj8 = Renderer.get_sortingOrder_Injected((IntPtr)0);
																			bool flag15 = (object)_shaftSprite == null;
																			int num15 = obj8 - 1;
																			PhaserSprite phaserSprite12 = _shaftSprite.setDepth(num15);
																			bool flag16 = (object)weapon == null;
																			float num16 = weapon.PHitBoxDelayOverSpeed();
																			GameManager core = GM.Core;
																			bool flag17 = (object)GM.Core == null;
																			bool flag18 = !core._003CIsTimeStopped_003Ek__BackingField;
																			bool flag19 = !flag18;
																			object obj9 = (flag19 ? 1 : 0) + 1;
																			object obj10 = (object)Vector3.zeroVector / obj9;
																			if (_expireTimer != null)
																			{
																				_expireTimer.Cancel();
																			}
																			float num17 = weapon.PDuration();
																			Action onComplete = StartDespawn;
																			float duration = (float)Vector3.zeroVector * 0.001f;
																			bool useRealTime = default(bool);
																			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																			int repeat = default(int);
																			TimerType type = default(TimerType);
																			Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																			_expireTimer = expireTimer;
																			if (_hitBoxTimer != null)
																			{
																				_hitBoxTimer.Cancel();
																			}
																			Action onComplete2 = delegate
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
																			};
																			float duration2 = (float)obj10 * 0.001f;
																			Timer hitBoxTimer = Timers.Register(duration2, onComplete2, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																			_hitBoxTimer = hitBoxTimer;
																			Camera main = Camera.main;
																			if ((object)main != null)
																			{
																				Transform transform5 = main.transform;
																				if ((object)transform5 != null)
																				{
																					_ = 0;
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v124 (UnityEngine.Transform)+10]");
																					bool flag20 = (nint)0 == 0;
																					object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v124 (UnityEngine.Transform)+10]");
																					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj11);
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
																					penOrigin = (Vector3)0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
																					_ = 0;
																					bool flag21 = (object)GM.Core == null;
																					PhaserScene s_scene = ArcadePhysics.s_scene;
																					bool flag22 = ArcadePhysics.s_scene == null;
																					PhaserScene.Renderer renderer = s_scene._renderer;
																					bool flag23 = s_scene._renderer == null;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Pendulumr_Projectile)+124]");
																					object obj12 = 0 + renderer.height;
																					Transform transform6 = base.transform;
																					bool flag24 = (object)transform6 == null;
																					_ = penOrigin;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Pendulumr_Projectile)+128]");
																					_ = 0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1702 @ rax_v135 (UnityEngine.Transform)+10]");
																					bool flag25 = (nint)0 == 0;
																					object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1702 @ rax_v135 (UnityEngine.Transform)+10]");
																					Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)obj13);
																					bool num18;
																					if (_indexInWeapon != 0)
																					{
																						if ((object)GM.Core != null)
																						{
																							PhaserScene s_scene2 = ArcadePhysics.s_scene;
																							if (ArcadePhysics.s_scene != null)
																							{
																								PhaserScene.Renderer renderer2 = s_scene2._renderer;
																								if (s_scene2._renderer != null && (object)GM.Core != null)
																								{
																									PhaserScene s_scene3 = ArcadePhysics.s_scene;
																									if (ArcadePhysics.s_scene != null)
																									{
																										PhaserScene.Renderer renderer3 = s_scene3._renderer;
																										if (s_scene3._renderer != null)
																										{
																											PhaserSprite pendulumSprite2 = _pendulumSprite;
																											if ((object)_pendulumSprite != null && (object)pendulumSprite2._spriteRenderer != null)
																											{
																												Sprite sprite3 = pendulumSprite2._spriteRenderer.sprite;
																												if ((object)sprite3 != null)
																												{
																													_ = 0;
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rax_v187 (UnityEngine.Sprite)+10]");
																													bool flag26 = (nint)0 == 0;
																													num18 = flag26;
																													object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rax_v187 (UnityEngine.Sprite)+10]");
																													Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj14);
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-19]");
																													num4 = 0f * 0.01f;
																													float minInclusive = renderer2.height * 0.5f;
																													float maxInclusive = renderer3.height - num4;
																													float num19 = UnityEngine.Random.Range(minInclusive, maxInclusive);
																													currentLength = num19;
																													goto IL_1063;
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																					else if ((object)GM.Core != null)
																					{
																						PhaserScene s_scene4 = ArcadePhysics.s_scene;
																						if (ArcadePhysics.s_scene != null)
																						{
																							PhaserScene.Renderer renderer4 = s_scene4._renderer;
																							if (s_scene4._renderer != null)
																							{
																								PhaserSprite pendulumSprite3 = _pendulumSprite;
																								if ((object)_pendulumSprite != null && (object)pendulumSprite3._spriteRenderer != null)
																								{
																									Sprite sprite4 = pendulumSprite3._spriteRenderer.sprite;
																									if ((object)sprite4 != null)
																									{
																										_ = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rax_v169 (UnityEngine.Sprite)+10]");
																										bool flag27 = (nint)0 == 0;
																										num18 = flag27;
																										object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rax_v169 (UnityEngine.Sprite)+10]");
																										Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)obj15);
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-19]");
																										float num19 = 0f * 0.01f;
																										currentLength = renderer4.height - num19;
																										goto IL_1063;
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
		goto IL_0bf6;
		IL_1063:
		_currentLength = currentLength;
		ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if (array != null)
		{
			object obj16 = array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj17 = default(object);
			bool flag28 = obj17 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if (tweenConfig != null)
			{
				_ = 0;
				_ = 1128792064;
				_ = 1065353216;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
				_ = 0;
				MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
				_scaleTween = scaleTween;
				_swingDirection = -1;
				_previousAngle = 1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 1914 Invalid \"Jump target not found in method: 0x187141340\"");
			}
		}
		goto IL_0bf6;
		IL_0bf6:
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Pendulumr_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
		}
	}

	public override void Despawn()
	{
		if (_radiusTween != null)
		{
			TweenExtensions.Kill(_radiusTween);
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_angleTween != null)
		{
			_angleTween.Kill();
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

	private unsafe void LateUpdate()
	{
		//IL_00b2: Expected I, but got O
		//IL_038c: Invalid comparison between I4 and F4
		//IL_011e: Expected F4, but got I4
		//IL_0208: Expected I4, but got I8
		//IL_0274: Expected O, but got Ref
		//IL_0345->IL02bf: Incompatible stack heights: 1 vs 0
		//IL_036c->IL02bf: Incompatible stack heights: 1 vs 0
		//IL_0068->IL02bf: Incompatible stack heights: 1 vs 0
		//IL_0236->IL02bf: Incompatible stack heights: 1 vs 0
		//IL_0262->IL02bf: Incompatible stack heights: 1 vs 0
		Camera main = Camera.main;
		Vector3 value;
		float num12;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out value);
				penOrigin = value;
				_ = 0;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						PhaserScene.Renderer renderer = s_scene._renderer;
						if (s_scene._renderer != null)
						{
							float num = renderer.height * 0.5f;
							float num2 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rcx_v25 (VampireSurvivors.Objects.Projectiles.TP_Pendulumr_Projectile)+124]");
							float num3 = num2 + 0f;
							_ = 1065353216;
							float deltaTime = PauseSystem.DeltaTime;
							nint num4 = (nint)this;
							float num5 = deltaTime * 1000f;
							float projectileSpeed = base.ProjectileSpeed;
							float num6 = num5 * 0.032f;
							float num7 = deltaTime * num6;
							float num8 = (_elapsedTime = num7 + _elapsedTime);
							float num9 = 0.00981f / _currentLength;
							float num10;
							if (!(0f > num9))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm1\"");
								num10 = 0f;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
								num10 = num9;
							}
							float num11 = num10 * num8;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
							num12 = num11 * ((float)Math.PI / 4f);
							if (_swingDirection == -1 && num12 > _previousAngle)
							{
								_swingDirection = 1;
							}
							else
							{
								if (_swingDirection != 1 || !(_previousAngle > num12))
								{
									goto IL_020d;
								}
								_swingDirection = -1;
							}
							PlaySfx();
							goto IL_020d;
						}
					}
				}
			}
		}
		goto IL_02bf;
		IL_020d:
		_previousAngle = num12;
		if ((object)_shaftSprite != null)
		{
			Transform transform2 = _shaftSprite.transform;
			if ((object)transform2 != null)
			{
				transform2.localEulerAngles = (Vector3)(&value);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Transform transform3 = base.transform;
				bool flag2 = (object)transform3 == null;
				bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
				Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
				return;
			}
		}
		goto IL_02bf;
		IL_02bf:
		throw new NullReferenceException();
	}

	public unsafe Vector2 GetPositionAtTime(float time)
	{
		//IL_01b5: Invalid comparison between I4 and F4
		//IL_0018: Expected F4, but got I4
		//IL_0102: Expected I4, but got I8
		//IL_016e: Expected O, but got Ref
		float num = 0.00981f / _currentLength;
		float num2;
		if (!(0f > num))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm1\"");
			num2 = 0f;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
			num2 = num;
		}
		float num3 = num2 * time;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num4 = num3 * ((float)Math.PI / 4f);
		if (_swingDirection == -1 && num4 > _previousAngle)
		{
			_swingDirection = 1;
		}
		else
		{
			if (_swingDirection != 1 || !(_previousAngle > num4))
			{
				goto IL_0107;
			}
			_swingDirection = -1;
		}
		PlaySfx();
		goto IL_0107;
		IL_0107:
		_previousAngle = num4;
		if ((object)_shaftSprite != null)
		{
			Transform transform = _shaftSprite.transform;
			if ((object)transform != null)
			{
				object obj = default(object);
				transform.localEulerAngles = (Vector3)(&obj);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Vector2 result = default(Vector2);
				return result;
			}
		}
		return (Vector2)new NullReferenceException();
	}

	private void CheckForDirectionChange(float angle)
	{
		//IL_00a5: Expected I4, but got I8
		if (_swingDirection == -1 && angle > _previousAngle)
		{
			_swingDirection = 1;
		}
		else
		{
			if (_swingDirection != 1 || !(_previousAngle > angle))
			{
				_previousAngle = angle;
				return;
			}
			_swingDirection = -1;
		}
		PlaySfx();
		_previousAngle = angle;
	}

	private void PlaySfx()
	{
		//IL_006d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		float num = _currentLength * -100f;
		float detune = num + 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_PocketWatch2, soundConfig, 200f, 5, time);
	}

	private void _003CInitProjectile_003Eb__16_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
