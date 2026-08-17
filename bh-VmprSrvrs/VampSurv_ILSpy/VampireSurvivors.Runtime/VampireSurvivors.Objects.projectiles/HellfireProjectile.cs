using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class HellfireProjectile : Projectile
{
	private ParticleSystem _pfx;

	private Tween _scaleTween;

	protected override void Awake()
	{
		base.Awake();
		GenerateParticleSystem();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_009b: Expected I4, but got O
		//IL_0437: Expected O, but got I4
		//IL_0440: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Expected I4, but got Unknown
		//IL_0117: Expected F4, but got O
		//IL_0187: Expected I4, but got O
		//IL_0351: Expected O, but got I4
		//IL_0351: Expected O, but got I4
		//IL_026c: Expected O, but got I4
		//IL_026c: Expected O, but got I4
		//IL_0370->IL0386: Incompatible stack heights: 2 vs 0
		//IL_04be->IL0386: Incompatible stack heights: 2 vs 0
		//IL_0243->IL0386: Incompatible stack heights: 2 vs 0
		//IL_04ed->IL0386: Incompatible stack heights: 2 vs 0
		//IL_0295->IL0386: Incompatible stack heights: 2 vs 0
		//IL_02c4->IL0386: Incompatible stack heights: 2 vs 0
		//IL_02e3->IL0386: Incompatible stack heights: 2 vs 0
		//IL_0324->IL0386: Incompatible stack heights: 2 vs 0
		base.InitProjectile(pool, weapon, index);
		if (base.body != null)
		{
			BaseBody baseBody = base.body.setCircle(16f, (float?)(object)0, (float?)(object)0);
			if ((object)_renderer != null)
			{
				Transform transform = _renderer.transform;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				float value = default(float);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
				PhaserScene s_scene = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer = s_scene._renderer;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
				int sortingOrder = default(int);
				_renderer.sortingOrder = sortingOrder;
				int num = (int)_renderer;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rsi_v10 (System.Int32)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rsi_v10 (System.Int32)+10]");
				object obj = Renderer.get_sortingOrder_Injected((IntPtr)0);
				int num2 = obj - 1;
				RenderingExtensions.SetDepth(_pfx, num2);
				Tween scaleTween = _scaleTween;
				if (_scaleTween != null && scaleTween._003Cactive_003Ek__BackingField)
				{
					TweenExtensions.Kill(_scaleTween);
				}
				Transform target = _renderer.transform;
				float num3 = _weapon.PArea();
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (float)Vector3.zeroVector, 0.2f);
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v846 @ rax_v42 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 1;
						_ = 0;
					}
				}
				_scaleTween = tweenerCore;
				int num4 = (int)_scaleTween;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				int num5 = _weapon.PBounces();
				if (num5 <= 0)
				{
					goto IL_047d;
				}
				if (_bounceActivated)
				{
					goto IL_033c;
				}
				_bounceActivated = true;
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null && (object)s_scene2.physics != null)
				{
					WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
					if (ArcadePhysics.s_world != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
						setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
						Weapon weapon2 = _weapon;
						if ((object)_weapon != null)
						{
							VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
							if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null && base.body != null)
							{
								Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
								BaseBody baseBody2 = base.body;
								if (base.body != null)
								{
									baseBody2._onWorldBounds = true;
									goto IL_047d;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0386;
		IL_047d:
		if (_bounceActivated)
		{
			goto IL_033c;
		}
		goto IL_0356;
		IL_0386:
		throw new NullReferenceException();
		IL_033c:
		setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
		goto IL_0356;
		IL_0356:
		if ((object)_pfx != null)
		{
			_pfx.Play(withChildren: true);
			return;
		}
		goto IL_0386;
	}

	public unsafe override void SetTarget(Transform target)
	{
		//IL_00ca: Expected O, but got I
		//IL_0144: Expected O, but got I
		//IL_05e8: Expected O, but got I
		//IL_01ae: Expected O, but got I
		//IL_0630: Expected O, but got I
		//IL_021c: Expected O, but got I
		//IL_0201: Expected I4, but got I8
		//IL_0678: Expected O, but got I
		//IL_028a: Expected O, but got I
		//IL_06c0: Expected O, but got I
		//IL_02f8: Expected O, but got I
		//IL_02dd: Expected I4, but got I8
		//IL_0708: Expected O, but got I
		//IL_0366: Expected O, but got I
		//IL_0750: Expected O, but got I
		//IL_03d4: Expected O, but got I
		//IL_03b9: Expected I4, but got I8
		//IL_0798: Expected O, but got I
		//IL_0442: Expected O, but got I
		//IL_07e0: Expected O, but got I
		//IL_04b1: Expected O, but got I
		//IL_0495: Expected I4, but got I8
		//IL_04db: Expected O, but got I
		//IL_0887: Expected F4, but got O
		//IL_05ae: Expected O, but got Ref
		//IL_04fb->IL05af: Incompatible stack heights: 1 vs 0
		//IL_055e->IL05af: Incompatible stack heights: 1 vs 0
		_targetTransform = target;
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			Transform playerTransform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
			float num = AngleFromTargetRadians(_targetTransform, playerTransform);
			List<int> list = new List<int>();
			if (list != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v15+18]");
					if (num2 >= 0)
					{
						list.AddWithResize(0);
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
						object obj2 = (nint)0 + (nint)1;
						_ = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdx_v17+18]");
						if (num3 >= 0)
						{
							list.AddWithResize(10);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
							object obj4 = (nint)0 + (nint)1;
							_ = 10;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdx_v19+18]");
							if (num4 >= 0)
							{
								list.AddWithResize(-10);
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
								object obj6 = (nint)0 + (nint)1;
								_ = 4294967286L;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v21+18]");
								if (num5 >= 0)
								{
									list.AddWithResize(20);
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
									object obj8 = (nint)0 + (nint)1;
									_ = 20;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
								object obj9 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
									nint num6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdx_v23+18]");
									if (num6 >= 0)
									{
										list.AddWithResize(-20);
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
										object obj10 = (nint)0 + (nint)1;
										_ = 4294967276L;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
									_ = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
									object obj11 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
										nint num7 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdx_v25+18]");
										if (num7 >= 0)
										{
											list.AddWithResize(30);
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
											object obj12 = (nint)0 + (nint)1;
											_ = 30;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
										object obj13 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
											nint num8 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdx_v27+18]");
											if (num8 >= 0)
											{
												list.AddWithResize(-30);
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
												object obj14 = (nint)0 + (nint)1;
												_ = 4294967266L;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
											_ = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
											object obj15 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
												nint num9 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdx_v29+18]");
												if (num9 >= 0)
												{
													list.AddWithResize(40);
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
													object obj16 = (nint)0 + (nint)1;
													_ = 40;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+1C]");
												_ = (nint)0 + (nint)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
												object obj17 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
													nint num10 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v31+18]");
													if (num10 >= 0)
													{
														list.AddWithResize(-40);
													}
													else
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
														object obj18 = (nint)0 + (nint)1;
														_ = 4294967256L;
													}
													int indexInWeapon = _indexInWeapon;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
													int num11 = (int)((nint)indexInWeapon % (nint)0);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+18]");
													bool flag = (nint)num11 >= (nint)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
													Transform transform = (Transform)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v21 (System.Collections.Generic.List`1<System.Int32>)+10]");
													if ((nint)0 != 0)
													{
														float projectileSpeed = base.ProjectileSpeed;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rbx_v11 (UnityEngine.Transform)+20+v148 @ rdx_v34 (System.Int32)*4]");
														float num12 = 0f * ((float)Math.PI / 180f);
														float rotation = num12 + num;
														Vector2 vector = SetVelocityFromRotation(rotation, num);
														if (body != null)
														{
															Transform transform2 = base.transform;
															((List<int>)(object)this).Add(0);
															Vector3 axis = default(Vector3);
															Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
															bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
															Quaternion value = default(Quaternion);
															Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
															Transform transform3 = _renderer.transform;
															transform3.localEulerAngles = (Vector3)(&axis);
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

	private void Bounce(Body b, bool up, bool down, bool left, bool right)
	{
		//IL_0039: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		//IL_0113: Expected O, but got F4
		//IL_0204: Expected F4, but got O
		//IL_01f5->IL01f5: Incompatible stack heights: 1 vs 0
		if (body != b)
		{
			return;
		}
		if (_bounces <= 0)
		{
			setCollideWorldBounds(value: false, (float?)(object)1, (float?)(object)1);
			goto IL_0146;
		}
		int bounces = _bounces - 1;
		_bounces = bounces;
		BaseBody baseBody = body;
		if (body != null)
		{
			float num = (float)baseBody._velocity * -1.5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v34 (BaseBody)+74]");
			float num2 = 0f * -1.5f;
			ArcadeSprite sprite = _sprite;
			if ((object)_sprite != null)
			{
				BaseBody baseBody2 = sprite.body;
				if (sprite.body != null)
				{
					baseBody2._velocity = (float2)num;
					if (_objectsHit != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
						goto IL_0146;
					}
				}
			}
		}
		goto IL_0193;
		IL_0193:
		throw new NullReferenceException();
		IL_0146:
		Transform transform = base.transform;
		BaseBody baseBody3 = body;
		if (body != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			Vector3 axis = default(Vector3);
			Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			return;
		}
		goto IL_0193;
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		BaseBody baseBody = body;
		Body b;
		if (body == null)
		{
			b = null;
			goto IL_00f5;
		}
		nint num = (nint)typeof(Body);
		nint num2 = (nint)baseBody;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ r8_v3 (Il2CppClass<Body>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r9_v3 (Il2CppClass<BaseBody>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ r8_v3 (Il2CppClass<Body>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ r9_v3 (Il2CppClass<BaseBody>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rax_v9+FFFFFFF8+v45 @ rax_v4*8]");
			if (0 == (nint)typeof(Body))
			{
				obj3 = 1;
				goto IL_0112;
			}
		}
		obj3 = 0;
		goto IL_0112;
		IL_0112:
		bool flag = obj3 == null;
		b = null;
		if (!flag)
		{
			b = (Body)body;
		}
		goto IL_00f5;
		IL_00f5:
		bool left = default(bool);
		bool right = default(bool);
		Bounce(b, up: false, down: false, left, right);
	}

	private void SetDepth()
	{
		//IL_00e0: Expected O, but got I4
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected I4, but got Unknown
		PhaserScene s_scene = ArcadePhysics.s_scene;
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
					HellfireProjectile renderer2 = (HellfireProjectile)(object)_renderer;
					if ((object)_renderer != null)
					{
						bool flag = ((UnityEngine.Object)renderer2).m_CachedPtr == (IntPtr)0;
						object obj = Renderer.get_sortingOrder_Injected(((UnityEngine.Object)renderer2).m_CachedPtr);
						int num = obj - 1;
						RenderingExtensions.SetDepth(_pfx, num);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		base.Despawn();
		_pfx.Stop();
		Tween scaleTween = _scaleTween;
		if (_scaleTween != null && scaleTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_scaleTween);
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0169: Expected O, but got Ref
		//IL_0183: Expected native int or pointer, but got O
		//IL_019d: Expected O, but got I
		//IL_01bd: Expected O, but got Ref
		//IL_01e4: Expected O, but got I
		//IL_01f9: Expected native int or pointer, but got O
		//IL_0213: Expected O, but got I
		//IL_0233: Expected O, but got Ref
		//IL_024d: Expected native int or pointer, but got O
		//IL_02e6: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"ProjectileFireball");
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
			((List<object>)(object)list).AddWithResize((object)"HitBoom2");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, 360f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-11]");
		particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-1]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 15));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(300f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+F]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+1F]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 47));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1.25f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+2F]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+3F]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
		_ = 0;
		particleSystemConfig._on = true;
		ParticleSystem pfx = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, _cachedTransform);
		_pfx = pfx;
	}
}
