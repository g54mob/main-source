using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class Vento2ExtraProjectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private SpriteAnimation _anims;

	private PhaserSprite _ghost1;

	private PhaserSprite _ghost2;

	private float _previousPArea = -1f;

	private float _previousPDuration = -1f;

	public override float ProjectileSpeed
	{
		get
		{
			//IL_001d: Invalid comparison between F4 and O
			//IL_0037: Expected F4, but got I4
			float num = _weapon.PSpeed();
			object obj = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				return 0f;
			}
			float num2 = _weapon.PSpeed();
			float num3 = (float)obj - 1f;
			float num4 = num3 * GameManager.ProjectileSpeed;
			return num4 * _speed;
		}
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_04fb: Expected O, but got I4
		//IL_04fb: Expected O, but got I4
		//IL_050f: Expected O, but got I4
		//IL_0128: Expected O, but got I4
		//IL_0547: Expected O, but got I4
		//IL_057f: Expected O, but got I4
		//IL_0674: Expected F4, but got O
		//IL_05e4: Invalid comparison between F4 and O
		//IL_01b8: Expected O, but got I4
		//IL_0615: Expected O, but got I4
		//IL_0637: Expected O, but got I4
		//IL_06e2: Expected I, but got O
		//IL_0906: Expected F4, but got O
		//IL_0876: Invalid comparison between F4 and O
		//IL_07b4: Expected O, but got I4
		//IL_08a7: Expected O, but got I4
		//IL_0967: Expected I, but got O
		//IL_08c9: Expected O, but got I4
		//IL_0807: Expected O, but got F4
		//IL_0810: Expected O, but got I4
		//IL_09d1: Expected O, but got I4
		//IL_0b29: Expected I4, but got I8
		//IL_0a0c: Expected F4, but got O
		//IL_10c2: Expected O, but got I4
		//IL_02c2: Expected O, but got I4
		//IL_0b5c: Expected O, but got I4
		//IL_0b65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6a: Expected O, but got Unknown
		//IL_0b73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b78: Expected I4, but got Unknown
		//IL_0aa4: Expected O, but got I4
		//IL_0bc7: Expected I, but got O
		//IL_0c53: Expected O, but got F4
		//IL_0ca2: Expected O, but got Ref
		//IL_0de3: Expected O, but got I4
		//IL_0df9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dfe: Expected I4, but got Unknown
		//IL_0e65: Expected O, but got Ref
		//IL_0ebd: Expected O, but got Ref
		//IL_005d->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0089->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_04ac->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_04db->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_00ea->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_052d->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0159->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0565->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_1089->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0656->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_05bc->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_01a0->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_06b8->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_01d4->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0203->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0727->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_08e8->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0705->IL0705: Incompatible stack heights: 2 vs 1
		//IL_084e->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_022d->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0758->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_093b->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0268->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_07de->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_09ac->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0acd->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_098a->IL098a: Incompatible stack heights: 2 vs 1
		//IL_10b0->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0afc->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_09eb->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_02aa->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_10f9->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_02de->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_030d->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0a7a->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_1120->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_033c->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0bf5->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0366->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0c17->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_03ac->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0c90->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_03ce->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0cc6->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0423->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0ce8->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0445->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0d32->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0d54->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_1147->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0d9a->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0db9->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0e27->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0e53->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0e7f->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0eab->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0ee6->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0f27->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0f68->IL0fc2: Incompatible stack heights: 1 vs 0
		//IL_0fa9->IL0fc2: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		Transform cachedTransform = _cachedTransform;
		Vector2 ret;
		Vector2 vector2 = default(Vector2);
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)(&ret));
			Transform anims = (Transform)(object)_anims;
			if ((object)_anims != null && ((UnityEngine.Object)anims).m_CachedPtr != (IntPtr)0)
			{
				goto IL_0483;
			}
			if ((object)_renderer != null)
			{
				GameObject gameObject = _renderer.gameObject;
				if ((object)gameObject != null)
				{
					SpriteAnimation anims2 = gameObject.AddComponent<SpriteAnimation>();
					_anims = anims2;
					int num = default(int);
					List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("petal", 1, 5, "vfx", num);
					if ((object)_anims != null)
					{
						bool startRandomFrame = default(bool);
						Action onComplete = default(Action);
						bool autoSetAnimation = default(bool);
						_anims.AddAnimation("strike", animationFrames, 60, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
						ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)1);
						ArcadeSprite arcadeSprite2 = setTint(1114129u);
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null)
							{
								Vector2 vector = default(Vector2);
								PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, vector, "vfx", "petal5");
								if ((object)phaserSprite != null)
								{
									PhaserSprite phaserSprite2 = phaserSprite.setOrigin(0.5f, (float?)(object)1);
									if ((object)phaserSprite2 != null)
									{
										PhaserSprite phaserSprite3 = phaserSprite2.setTint(16711680u);
										if ((object)phaserSprite3 != null)
										{
											GameObject gameObject2 = phaserSprite3.gameObject;
											if ((object)gameObject2 != null)
											{
												((UnityEngine.Object)gameObject2).SetName("[Vento2Extra] _ghost1");
												_ghost1 = phaserSprite3;
												if ((object)GM.Core != null)
												{
													PhaserScene s_scene2 = ArcadePhysics.s_scene;
													if (ArcadePhysics.s_scene != null)
													{
														PhaserSprite phaserSprite4 = RenderingExtensions.sprite(s_scene2.add, vector, "vfx", "petal5");
														if ((object)phaserSprite4 != null)
														{
															PhaserSprite phaserSprite5 = phaserSprite4.setOrigin(0.5f, (float?)(object)1);
															if ((object)phaserSprite5 != null)
															{
																PhaserSprite phaserSprite6 = phaserSprite5.setTint(6684774u);
																if ((object)phaserSprite6 != null)
																{
																	PhaserSprite phaserSprite7 = phaserSprite6.setBlendMode(BlendMode.Add);
																	if ((object)phaserSprite7 != null)
																	{
																		GameObject gameObject3 = phaserSprite7.gameObject;
																		if ((object)gameObject3 != null)
																		{
																			((UnityEngine.Object)gameObject3).SetName("[Vento2Extra] _ghost2");
																			_ghost2 = phaserSprite7;
																			PhaserSprite ghost = _ghost1;
																			if ((object)_ghost1 != null && (object)ghost._spriteAnimation != null)
																			{
																				ghost._spriteAnimation.AddAnimation("strike", animationFrames, 60, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
																				PhaserSprite ghost2 = _ghost2;
																				if ((object)_ghost2 != null && (object)ghost2._spriteAnimation != null)
																				{
																					ghost2._spriteAnimation.AddAnimation("strike", animationFrames, 60, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
																					vector2 = vector;
																					goto IL_0483;
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
		goto IL_0fc2;
		IL_0fc2:
		throw new NullReferenceException();
		IL_0815:
		if (_alphaTween != null)
		{
			if ((object)_weapon == null)
			{
				goto IL_0fc2;
			}
			float num2 = _weapon.PDuration();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873004DFh\"");
			if ((object)_previousPDuration == (object)vector2)
			{
				bool flag2 = _alphaTween == null;
				object obj = 0;
				if (!flag2)
				{
					_alphaTween.Restart();
					obj = 0;
				}
				goto IL_0aa9;
			}
		}
		if ((object)_weapon != null)
		{
			float num3 = _weapon.PDuration();
			_previousPDuration = (float)vector2;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			if (array != null)
			{
				if ((object)_renderer != null)
				{
					nint num4 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj2 = default(object);
					bool flag3 = obj2 == null;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					tweenConfig.targets = array;
					tweenConfig.alpha = (float?)(object)1;
					if ((object)_weapon != null)
					{
						float num5 = _weapon.PDuration();
						tweenConfig.duration = (float)vector2;
						tweenConfig.ease = Ease.Linear;
						tweenConfig.delay = 100f;
						TweenCallback onComplete2 = delegate
						{
							Despawn();
						};
						tweenConfig.onComplete = onComplete2;
						MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
						if (multiTargetTween != null)
						{
							MultiTargetTween alphaTween = multiTargetTween.SetAutoKill(autoKill: false);
							_alphaTween = alphaTween;
							object obj = 0;
							goto IL_0aa9;
						}
					}
				}
			}
		}
		goto IL_0fc2;
		IL_0aa9:
		Weapon weapon2 = _weapon;
		if ((object)_weapon != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
			if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
			{
				bool flag4 = !characterController._isFlipped;
				int num6 = (int)(_indexInWeapon & 0x80000001L);
				if ((characterController._isFlipped ? 1 : 0) < (false ? 1 : 0))
				{
					object obj3 = num6 - 1;
					object obj4 = obj3 | -2;
					num6 = obj4 + 1;
				}
				object obj5 = num6 - (flag4 ? 1 : 0);
				bool flag5 = obj5 == null;
				ArcadeSprite arcadeSprite3 = setFlipY(flag5);
				if ((object)_weapon != null)
				{
					float num7 = _weapon.PAmount();
					float num8 = 360f / (float)vector2;
					float num9 = num8 * (float)_indexInWeapon;
					float num10 = num9 * ((float)Math.PI / 180f);
					PhaserScene s_scene3 = ArcadePhysics.s_scene;
					if (ArcadePhysics.s_scene != null)
					{
						nint num11 = (nint)this;
						float projectileSpeed = ProjectileSpeed;
						BaseBody baseBody = body;
						if (body != null && (object)s_scene3.physics != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
							float num12 = num10 * (float)_indexInWeapon;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
							baseBody._velocity = (float2)num12;
							float num13 = num10 * (float)_indexInWeapon;
							Transform transform = base.transform;
							if ((object)transform != null)
							{
								transform.localEulerAngles = (Vector3)(&ret);
								Weapon weapon3 = _weapon;
								if ((object)_weapon != null && (object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
								{
									float2 float5 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
									base.position = float5;
									Weapon weapon4 = _weapon;
									if ((object)_weapon != null && (object)((Equipment)weapon4)._003COwner_003Ek__BackingField != null)
									{
										int num14 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.Depth;
										PhaserScene s_scene4 = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null)
										{
											PhaserScene.Renderer renderer = s_scene4._renderer;
											if (s_scene4._renderer != null && (object)_renderer != null)
											{
												int num15 = renderer.pixelHeight >> 31;
												object obj6 = renderer.pixelHeight - num15;
												object obj7 = obj6 >> 1;
												int sortingOrder = num14 + obj7;
												_renderer.sortingOrder = sortingOrder;
												if ((object)_ghost1 != null)
												{
													Transform transform2 = _ghost1.transform;
													if ((object)transform2 != null)
													{
														transform2.localEulerAngles = (Vector3)(&ret);
														if ((object)_ghost2 != null)
														{
															Transform transform3 = _ghost2.transform;
															if ((object)transform3 != null)
															{
																transform3.localEulerAngles = (Vector3)(&ret);
																bool flag6 = base.flipX;
																if ((object)_ghost1 != null)
																{
																	PhaserSprite phaserSprite8 = _ghost1.setFlipX(flag6);
																	bool flag7 = base.flipX;
																	if ((object)_ghost2 != null)
																	{
																		PhaserSprite phaserSprite9 = _ghost2.setFlipX(flag7);
																		bool flag8 = base.flipY;
																		if ((object)_ghost1 != null)
																		{
																			PhaserSprite phaserSprite10 = _ghost1.setFlipY(flag8);
																			bool flag9 = base.flipY;
																			if ((object)_ghost2 != null)
																			{
																				PhaserSprite phaserSprite11 = _ghost2.setFlipY(flag9);
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
		goto IL_0fc2;
		IL_0483:
		ArcadeSprite arcadeSprite4 = setAlpha(0.75f);
		if ((object)_anims != null)
		{
			_anims.SetAnimation("strike");
			if (body != null)
			{
				BaseBody baseBody2 = body.setCircle(24f, (float?)(object)1, (float?)(object)1);
				ArcadeSprite arcadeSprite5 = setScale(0f, (float?)(object)0);
				if ((object)_ghost1 != null)
				{
					PhaserSprite phaserSprite12 = _ghost1.setScale(0f, (float?)(object)0);
					if ((object)_ghost2 != null)
					{
						PhaserSprite phaserSprite13 = _ghost2.setScale(0f, (float?)(object)0);
						if (_scaleTween != null)
						{
							if ((object)_weapon == null)
							{
								goto IL_0fc2;
							}
							float num16 = _weapon.PArea();
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001873002A9h\"");
							if ((object)_previousPArea == (object)vector2)
							{
								bool flag10 = _scaleTween == null;
								float? num17 = (float?)(object)0;
								if (!flag10)
								{
									_scaleTween.Restart();
									num17 = (float?)(object)0;
								}
								goto IL_0815;
							}
						}
						if ((object)_weapon != null)
						{
							float num18 = _weapon.PArea();
							_previousPArea = (float)vector2;
							TweenConfig tweenConfig2 = new TweenConfig();
							object[] array2 = new object[1];
							Transform transform4 = base.transform;
							if (array2 != null)
							{
								if ((object)transform4 != null)
								{
									nint num19 = (nint)array2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj8 = default(object);
									bool flag11 = obj8 == null;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig2 != null)
								{
									tweenConfig2.targets = array2;
									if ((object)_weapon != null)
									{
										float num20 = _weapon.PArea();
										float num21 = (float)vector2 * 0.7f;
										tweenConfig2.duration = 200f;
										tweenConfig2.yoyo = true;
										tweenConfig2.ease = Ease.Linear;
										tweenConfig2.scale = (float?)(object)1;
										MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
										if (multiTargetTween2 != null)
										{
											MultiTargetTween scaleTween = multiTargetTween2.SetAutoKill(autoKill: false);
											_scaleTween = scaleTween;
											vector2 = (Vector2)num21;
											float? num17 = (float?)(object)0;
											goto IL_0815;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0fc2;
	}

	public override void InternalUpdate()
	{
		//IL_009f: Expected I4, but got I8
		//IL_00d6: Expected I4, but got I8
		//IL_011c: Expected O, but got I4
		//IL_0162: Expected O, but got I4
		//IL_0322->IL02d1: Incompatible stack heights: 1 vs 0
		//IL_02ae->IL02d1: Incompatible stack heights: 1 vs 0
		//IL_0371->IL02d1: Incompatible stack heights: 2 vs 0
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			base.position = float5;
			if ((object)_ghost1 != null)
			{
				PhaserSprite phaserSprite = _ghost1.setDepth(-1);
				if ((object)_ghost2 != null)
				{
					PhaserSprite phaserSprite2 = _ghost2.setDepth(-1);
					float xScale = base.scale;
					if ((object)_ghost1 != null)
					{
						PhaserSprite phaserSprite3 = _ghost1.setScale(xScale, (float?)(object)0);
						float xScale2 = base.scale;
						if ((object)_ghost2 != null)
						{
							PhaserSprite phaserSprite4 = _ghost2.setScale(xScale2, (float?)(object)0);
							float2 float6 = base.position;
							float2 float7 = base.position;
							if ((object)_ghost1 != null)
							{
								object obj = default(object);
								float y = (float)obj - 0.02f;
								float x = (float)float6 + 0.04f;
								PhaserSprite phaserSprite5 = _ghost1.setPosition(x, y);
								float2 float8 = base.position;
								float2 float9 = base.position;
								if ((object)_ghost2 != null)
								{
									float y2 = (float)obj + 0.02f;
									float x2 = (float)float8 - 0.04f;
									PhaserSprite phaserSprite6 = _ghost2.setPosition(x2, y2);
									PhaserSprite renderer = (PhaserSprite)(object)_renderer;
									if ((object)_renderer != null)
									{
										bool flag = ((UnityEngine.Object)renderer).m_CachedPtr == (IntPtr)0;
										SpriteRenderer.get_color_Injected(((UnityEngine.Object)renderer).m_CachedPtr, out Color ret);
										if ((object)_ghost1 != null)
										{
											float alpha = default(float);
											PhaserSprite phaserSprite7 = _ghost1.setAlpha(alpha);
											Vento2ExtraProjectile renderer2 = (Vento2ExtraProjectile)(object)_renderer;
											if ((object)_renderer != null)
											{
												bool flag2 = ((UnityEngine.Object)renderer2).m_CachedPtr == (IntPtr)0;
												SpriteRenderer.get_color_Injected(((UnityEngine.Object)renderer2).m_CachedPtr, out ret);
												if ((object)_ghost2 != null)
												{
													PhaserSprite phaserSprite8 = _ghost2.setAlpha(alpha);
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
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		PhaserSprite ghost = _ghost1;
		if ((object)_ghost1 != null && ((UnityEngine.Object)ghost).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite = _ghost1.setAlpha(0f);
		}
		PhaserSprite ghost2 = _ghost2;
		if ((object)_ghost2 != null && ((UnityEngine.Object)ghost2).m_CachedPtr != (IntPtr)0)
		{
			PhaserSprite phaserSprite2 = _ghost2.setAlpha(0f);
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__9_0()
	{
		Despawn();
	}
}
