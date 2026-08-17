using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
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

public class TrapanoProjectile : Projectile
{
	private TrailRenderer _Trail;

	[NonSerialized]
	public bool _isYeeted;

	[NonSerialized]
	public float _durataMillis;

	private MultiTargetTween _angleTween;

	private Vector2 _aimVec;

	private MultiTargetTween _tween1;

	private SpriteRenderer _groundFx;

	private PhaserSprite _spikeSprite;

	private Vector2 _previousVector;

	private Timer _hitboxTimer;

	private bool _isFading;

	private Timer _expireTimer;

	private float _timeStopped;

	private const int Radius = 8;

	protected unsafe override void Awake()
	{
		//IL_00e8: Expected O, but got I4
		//IL_00f3: Expected O, but got I4
		//IL_0174: Expected O, but got I4
		//IL_01a8: Expected O, but got I4
		//IL_0200: Expected O, but got Ref
		//IL_015c->IL0316: Incompatible stack heights: 1 vs 0
		//IL_0190->IL0316: Incompatible stack heights: 1 vs 0
		//IL_01c4->IL0316: Incompatible stack heights: 1 vs 0
		//IL_01ee->IL0316: Incompatible stack heights: 1 vs 0
		//IL_0259->IL0316: Incompatible stack heights: 1 vs 0
		//IL_027b->IL0316: Incompatible stack heights: 1 vs 0
		//IL_02d0->IL0316: Incompatible stack heights: 1 vs 0
		//IL_02f2->IL0316: Incompatible stack heights: 1 vs 0
		base.Awake();
		if ((object)this != null)
		{
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			SpriteRenderer spriteRenderer = RenderingExtensions.AddGraphic(gameObject, pos);
			SpriteRenderer spriteRenderer2 = RenderingExtensions.FillCircle(spriteRenderer, 8);
			SpriteRenderer spriteRenderer3 = RenderingExtensions.SetAlpha(spriteRenderer2, 0.5f);
			SpriteRenderer spriteRenderer4 = RenderingExtensions.SetTint(spriteRenderer3, 4456448u);
			if ((object)spriteRenderer4 != null)
			{
				spriteRenderer4.enabled = true;
				Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
				((Renderer)spriteRenderer4).SetMaterial(material);
				_groundFx = spriteRenderer4;
				ArcadeSprite arcadeSprite = setVisible(visible: false);
				_previousVector = (Vector2)0;
				_aimVec = (Vector2)0;
				Transform transform = base.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
					GameObject gameObject2 = base.gameObject;
					PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "items", "trapano");
					if ((object)phaserSprite != null)
					{
						PhaserSprite phaserSprite2 = phaserSprite.setScale(1f, (float?)(object)0);
						if ((object)phaserSprite2 != null)
						{
							PhaserSprite phaserSprite3 = phaserSprite2.setOrigin(0.5f, (float?)(object)1);
							if ((object)phaserSprite3 != null)
							{
								Transform transform2 = phaserSprite3.transform;
								if ((object)transform2 != null)
								{
									transform2.localEulerAngles = (Vector3)(&ret);
									_spikeSprite = phaserSprite3;
									int num = default(int);
									List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("trapano", 1, 10, "vfx", num);
									PhaserSprite spikeSprite = _spikeSprite;
									if ((object)_spikeSprite != null && (object)spikeSprite._spriteAnimation != null)
									{
										bool startRandomFrame = default(bool);
										Action onComplete = default(Action);
										bool autoSetAnimation = default(bool);
										spikeSprite._spriteAnimation.AddAnimation("idle", animationFrames, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
										PhaserSprite spikeSprite2 = _spikeSprite;
										if ((object)_spikeSprite != null && (object)spikeSprite2._spriteAnimation != null)
										{
											spikeSprite2._spriteAnimation.SetAnimation("idle");
											_durataMillis = 0f;
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
		throw new NullReferenceException();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00aa: Expected I, but got O
		//IL_0131: Expected O, but got I
		//IL_015f: Expected I4, but got I8
		//IL_0c75: Expected O, but got F4
		//IL_0c93: Expected O, but got I4
		//IL_0ce0: Expected I, but got O
		//IL_034b: Expected O, but got Ref
		//IL_0397: Expected O, but got I4
		//IL_041f: Expected O, but got I
		//IL_041f: Expected O, but got I
		//IL_056a: Expected O, but got I4
		//IL_05d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d7: Expected O, but got Unknown
		//IL_05ea: Expected O, but got I
		//IL_067d: Expected O, but got I
		//IL_0d60: Expected O, but got Ref
		//IL_0d72: Expected I, but got O
		//IL_0db9: Expected O, but got Ref
		//IL_0dcb: Expected I, but got O
		//IL_0752: Expected O, but got Ref
		//IL_0dfc: Expected O, but got Ref
		//IL_0e0e: Expected I, but got O
		//IL_0e32: Expected O, but got I4
		//IL_0849: Expected I, but got O
		//IL_0907: Expected O, but got I
		//IL_09dd: Expected I, but got O
		//IL_0a60: Expected O, but got I
		//IL_0cfa->IL0c20: Incompatible stack heights: 1 vs 0
		//IL_021a->IL0c20: Incompatible stack heights: 1 vs 0
		//IL_0248->IL0c20: Incompatible stack heights: 1 vs 0
		//IL_0286->IL0c20: Incompatible stack heights: 1 vs 0
		//IL_02b4->IL0c20: Incompatible stack heights: 1 vs 0
		//IL_0306->IL0c20: Incompatible stack heights: 1 vs 0
		//IL_0332->IL0c20: Incompatible stack heights: 1 vs 0
		//IL_0377->IL0c20: Incompatible stack heights: 1 vs 0
		//IL_03f0->IL0c20: Incompatible stack heights: 1 vs 0
		//IL_0447->IL0c20: Incompatible stack heights: 1 vs 0
		//IL_0474->IL0c20: Incompatible stack heights: 1 vs 0
		//IL_04a8->IL0c20: Incompatible stack heights: 1 vs 0
		//IL_04db->IL0c20: Incompatible stack heights: 1 vs 0
		//IL_052d->IL0c20: Incompatible stack heights: 1 vs 0
		//IL_058e->IL0c20: Incompatible stack heights: 1 vs 0
		//IL_05b0->IL0c20: Incompatible stack heights: 1 vs 0
		//IL_0629->IL0c20: Incompatible stack heights: 1 vs 0
		//IL_0d23->IL0c20: Incompatible stack heights: 1 vs 0
		//IL_081f->IL0c20: Incompatible stack heights: 10 vs 0
		//IL_088e->IL0c20: Incompatible stack heights: 10 vs 0
		//IL_086c->IL086c: Incompatible stack heights: 11 vs 10
		//IL_08bf->IL0c20: Incompatible stack heights: 10 vs 0
		//IL_0987->IL0c20: Incompatible stack heights: 10 vs 0
		//IL_09b3->IL0c20: Incompatible stack heights: 10 vs 0
		//IL_0a22->IL0c20: Incompatible stack heights: 10 vs 0
		//IL_0a00->IL0a00: Incompatible stack heights: 11 vs 10
		//IL_0ad2->IL0c20: Incompatible stack heights: 10 vs 0
		//IL_0ba5->IL0c20: Incompatible stack heights: 10 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		base.InitProjectile(pool, weapon, index);
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_spikeSprite != null)
		{
			Transform transform = _spikeSprite.transform;
			if (array != null)
			{
				if ((object)transform != null)
				{
					nint num = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj3 = default(object);
					if (obj3 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (tweenConfig != null)
				{
					tweenConfig.targets = array;
					_ = 0;
					_ = 1110704128;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
					tweenConfig.angle = (float?)(object)0;
					tweenConfig.duration = 1000f;
					tweenConfig.ease = Ease.Linear;
					tweenConfig.repeat = -1;
					tweenConfig.yoyo = true;
					object obj4 = UnityEngine.Random.value;
					object obj5 = default(object);
					float num2 = (float)obj5 * 500f;
					object obj6 = index * 239;
					float num3 = (tweenConfig.delay = num2 + (float)obj6);
					MultiTargetTween angleTween = Tweens.Add(tweenConfig);
					_angleTween = angleTween;
					TweenConfig trail = (TweenConfig)(object)_Trail;
					_isCullable = false;
					_isFading = false;
					if ((object)_Trail != null)
					{
						bool flag = trail.targets == null;
						TrailRenderer.Clear_Injected((IntPtr)trail.targets);
						if ((object)_Trail != null)
						{
							_Trail.enabled = false;
							TrailRenderer trailRenderer = RenderingExtensions.SetAlpha(_Trail, 1f);
							if ((object)_weapon != null)
							{
								float num4 = _weapon.PArea();
								if ((object)_Trail != null)
								{
									float num5 = num3 * 0.01f;
									_Trail.startWidth = num5;
									if ((object)_weapon != null)
									{
										float num6 = _weapon.PArea();
										if ((object)_Trail != null)
										{
											float endWidth = num5 * 0.01f;
											_Trail.endWidth = endWidth;
											TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
											if ((object)_spikeSprite != null)
											{
												Transform transform2 = _spikeSprite.transform;
												if ((object)transform2 != null)
												{
													_ = 45f;
													Vector3 localEulerAngles = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
													transform2.localEulerAngles = localEulerAngles;
													if (_angleTween != null)
													{
														_angleTween.Play();
														ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
														BaseBody baseBody = body;
														_ = 0;
														_ = 0;
														_ = 3229614080L;
														_ = 1;
														_ = 3229614080L;
														_ = 1;
														if (body != null)
														{
															BaseBody baseBody2 = body;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
															nint num7 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
															BaseBody baseBody3 = baseBody2.setCircle(8f, (float?)(object)num7, (float?)(object)0);
															BaseBody baseBody4 = body;
															if (body != null)
															{
																baseBody4._enable = true;
																if (_objectsHit != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
																	_isYeeted = false;
																	if ((object)_spikeSprite != null)
																	{
																		PhaserSprite phaserSprite = _spikeSprite.setVisible(visible: true);
																		if ((object)_groundFx != null)
																		{
																			_groundFx.enabled = true;
																			ArcadeSprite arcadeSprite2 = setVisible(visible: false);
																			ArcadeSprite arcadeSprite3 = setAlpha(1f);
																			if ((object)_spikeSprite != null)
																			{
																				PhaserSprite phaserSprite2 = _spikeSprite.setAlpha(1f);
																				SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_groundFx, 0.5f);
																				_aimVec = (Vector2)0;
																				Weapon weapon2 = _weapon;
																				if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
																				{
																					Vector2 scaledVelocity = ((Equipment)weapon2)._003COwner_003Ek__BackingField.ScaledVelocity;
																					Vector2 vector = (Vector2)(this + 264);
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
																					_previousVector = (Vector2)0;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+63]");
																					_ = 0;
																					((Vector2*)vector)->Normalize();
																					Weapon weapon3 = _weapon;
																					if ((object)_weapon != null)
																					{
																						if (!weapon3.IsHoming)
																						{
																							_ = 0;
																							_ = 0;
																							_ = 1;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
																							setVelocity(0f, (float?)(object)0);
																						}
																						else
																						{
																							_speed = 0.25f;
																							Transform transform3 = base.AimForNearestEnemy(rotate: false);
																						}
																						TweenConfig cachedTransform = (TweenConfig)(object)_cachedTransform;
																						if ((object)_cachedTransform != null)
																						{
																							_ = 0;
																							_ = 0;
																							bool flag2 = cachedTransform.targets == null;
																							object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
																							Transform.get_position_Injected((IntPtr)cachedTransform.targets, out *(Vector3*)obj7);
																							bool flag3 = (object)_spikeSprite == null;
																							Transform transform4 = _spikeSprite.transform;
																							bool flag4 = (object)transform4 == null;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-39]");
																							_ = 0;
																							bool flag5 = ((TweenConfig)(object)transform4).targets == null;
																							object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
																							Transform.set_position_Injected((IntPtr)((TweenConfig)(object)transform4).targets, ref *(Vector3*)obj8);
																							bool flag6 = (object)_spikeSprite == null;
																							Transform transform5 = _spikeSprite.transform;
																							bool flag7 = (object)transform5 == null;
																							_ = -0f;
																							Vector3 localEulerAngles2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
																							transform5.localEulerAngles = localEulerAngles2;
																							bool flag8 = (object)_groundFx == null;
																							Transform transform6 = _groundFx.transform;
																							bool flag9 = (object)transform6 == null;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-39]");
																							_ = 0;
																							bool flag10 = ((TweenConfig)(object)transform6).targets == null;
																							object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
																							Transform.set_position_Injected((IntPtr)((TweenConfig)(object)transform6).targets, ref *(Vector3*)obj9);
																							SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_groundFx, 0f);
																							ArcadeSprite arcadeSprite4 = setScale(0f, (float?)(object)0);
																							if (_tween1 != null)
																							{
																								_tween1.Kill();
																							}
																							TweenConfig tweenConfig2 = new TweenConfig();
																							object[] array2 = new object[1];
																							Transform transform7 = base.transform;
																							if (array2 != null)
																							{
																								if ((object)transform7 != null)
																								{
																									nint num8 = (nint)array2;
																									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																									object obj10 = default(object);
																									bool flag11 = obj10 == null;
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																								if (tweenConfig2 != null)
																								{
																									tweenConfig2.targets = array2;
																									if ((object)_weapon != null)
																									{
																										_ = 0;
																										float num9 = _weapon.PArea();
																										tweenConfig2.duration = 300f;
																										_ = 1;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
																										tweenConfig2.scale = (float?)(object)0;
																										TweenCallback onStart = delegate
																										{
																											//IL_0010: Expected O, but got I4
																											ArcadeSprite arcadeSprite5 = setScale(0f, (float?)(object)0);
																										};
																										tweenConfig2.onStart = onStart;
																										MultiTargetTween tween = Tweens.Add(tweenConfig2);
																										_tween1 = tween;
																										TweenConfig tweenConfig3 = new TweenConfig();
																										object[] array3 = new object[1];
																										if ((object)_groundFx != null)
																										{
																											Transform transform8 = _groundFx.transform;
																											if (array3 != null)
																											{
																												if ((object)transform8 != null)
																												{
																													nint num10 = (nint)array3;
																													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																													object obj11 = default(object);
																													bool flag12 = obj11 == null;
																												}
																												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																												if (tweenConfig3 != null)
																												{
																													tweenConfig3.targets = array3;
																													_ = 0;
																													_ = 1066192077;
																													_ = 1;
																													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+5F]");
																													tweenConfig3.scale = (float?)(object)0;
																													tweenConfig3.duration = 300f;
																													tweenConfig3.yoyo = true;
																													MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig3);
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
																														float num11 = hitBoxDelay * 0.001f;
																														bool useRealTime = default(bool);
																														MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																														int repeat = default(int);
																														TimerType type = default(TimerType);
																														Timer hitboxTimer = Timers.Register(num11, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																														_hitboxTimer = hitboxTimer;
																														_durataMillis = 0f;
																														if (_expireTimer != null)
																														{
																															_expireTimer.Cancel();
																														}
																														if ((object)_weapon != null)
																														{
																															float num12 = _weapon.PDuration();
																															Action onComplete2 = FadeOut;
																															float duration = num11 * 0.001f;
																															Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																															_expireTimer = expireTimer;
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
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected I4, but got Unknown
		//IL_0476: Expected O, but got I4
		//IL_0491: Expected I4, but got O
		//IL_02e3: Invalid comparison between I4 and F4
		//IL_032e: Expected F4, but got I4
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Expected O, but got Unknown
		//IL_051f: Expected O, but got F4
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Expected O, but got Unknown
		//IL_03d8: Expected O, but got F4
		//IL_042b: Expected O, but got F4
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		int sortingOrder = -renderer.pixelHeight;
		_renderer.sortingOrder = sortingOrder;
		_groundFx.sortingOrder = sortingOrder;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		object obj = default(object);
		int num = obj - 1;
		PhaserSprite phaserSprite = _spikeSprite.setDepth(num);
		if (!_isYeeted)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num2 = deltaTime * 1000f;
			Weapon weapon = _weapon;
			float durataMillis = num2 + _durataMillis;
			_durataMillis = durataMillis;
			Vector2 scaledVelocity = ((Equipment)weapon)._003COwner_003Ek__BackingField.ScaledVelocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001872F95A8h\"");
			object obj2 = default(object);
			if ((object)scaledVelocity == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 00000001872F95A8h\"");
				if (obj2 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872F952Eh\"");
					if ((object)_previousVector == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TrapanoProjectile)+10C]");
						bool flag = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001872F952Eh\"");
						if (flag)
						{
							return;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186228470");
					object obj3 = default(object);
					if (!((_timeStopped = (float)obj3 + _timeStopped) < 0.04f))
					{
						_timeStopped = 0f;
						Yeet();
						_isYeeted = true;
					}
					return;
				}
			}
			if (_isYeeted)
			{
				return;
			}
			Weapon weapon2 = _weapon;
			if (weapon2.IsHoming)
			{
				return;
			}
			_timeStopped = 0f;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
			Weapon weapon3 = _weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
			object obj4 = characterController._currentDirectionRaw * characterController._currentDirectionRaw;
			float num3 = (float)obj4 * 0.5f;
			if (!(0f > num3))
			{
				if (num3 > 1f)
				{
					num3 = 1f;
				}
			}
			else
			{
				num3 = 0f;
			}
			object obj5 = scaledVelocity - _previousVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TrapanoProjectile)+10C]");
			object obj6 = obj2 - 0;
			float num4 = (float)obj5 * num3;
			float num5 = (float)obj6 * num3;
			float num6 = num4 + (float)_previousVector;
			float num7 = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TrapanoProjectile)+10C]");
			float num8 = num7 + 0f;
			_previousVector = (Vector2)num6;
			float num9 = _weapon.PSpeed();
			if (num8 > 1f)
			{
				object obj7 = scaledVelocity - _aimVec;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TrapanoProjectile)+EC]");
				object obj8 = obj2 - 0;
				float num10 = (float)obj7 * 0.002f;
				float num11 = (float)obj8 * 0.002f;
				float num12 = (float)_aimVec - num10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TrapanoProjectile)+EC]");
				float num13 = 0f - num11;
				_aimVec = (Vector2)num12;
				float num14 = _weapon.PSpeed();
				float num15 = num12 * num8;
				float num16 = num13 * num8;
				BaseBody baseBody = body;
				baseBody._velocity = (float2)num15;
			}
		}
		else
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			int num17 = renderer2.pixelHeight >> 31;
			object obj9 = renderer2.pixelHeight - num17;
			object obj10 = obj9 >> 1;
			int sortingOrder2 = (int)(obj + obj10);
			_Trail.sortingOrder = sortingOrder2;
		}
	}

	public override void Despawn()
	{
		//IL_0097: Expected O, but got I4
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_tween1 != null)
		{
			_tween1.Kill();
		}
		PhaserSprite phaserSprite = _spikeSprite.setVisible(visible: false);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		_groundFx.enabled = false;
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		BaseBody baseBody = body;
		baseBody._enable = false;
		base.Despawn();
	}

	private void FadeOut()
	{
		//IL_0066: Expected I, but got O
		//IL_00be: Expected I, but got O
		//IL_0116: Expected I, but got O
		//IL_0180: Expected I, but got O
		//IL_01e4: Expected O, but got I4
		if (_isFading)
		{
			return;
		}
		_isFading = true;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[4];
		PhaserSprite spikeSprite = _spikeSprite;
		if ((object)spikeSprite._spriteRenderer != null)
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
		if ((object)_renderer != null)
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
		if ((object)_groundFx != null)
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
		Material material = ((Renderer)_Trail).GetMaterial();
		if ((object)material != null)
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
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			Despawn();
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
		Weapon weapon = _weapon;
		if (weapon._explodeOnExpire)
		{
			float2 pos = base.position;
			Projectile projectile = weapon.SpawnExplosionAt(pos, 0, 1, 0f);
		}
	}

	private unsafe void Yeet()
	{
		//IL_0044: Expected O, but got I
		//IL_004c: Expected O, but got I
		//IL_0365: Expected O, but got I4
		//IL_00a6: Expected O, but got Ref
		//IL_014c: Expected O, but got Ref
		//IL_01fc: Expected I, but got O
		//IL_0258: Expected O, but got I4
		//IL_0283: Expected O, but got I4
		//IL_021f->IL021f: Incompatible stack heights: 1 vs 0
		Weapon weapon = _weapon;
		object obj;
		if (!weapon.IsHoming)
		{
			Vector2 previousVector = _previousVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rcx_v1 (VampireSurvivors.Objects.Projectiles.TrapanoProjectile)+10C]");
			obj = 0;
			IntPtr intPtr = default(IntPtr);
			Vector3 vector = (Vector3)(nint)intPtr;
			ArcadeSprite arcadeSprite = this;
		}
		else
		{
			GameManager core = GM.Core;
			Weapon weapon2 = _weapon;
			float2 float5 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
			object obj2 = default(object);
			EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj2), excludeDead: true);
			ArcadeSprite arcadeSprite2;
			if ((object)enemyController != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
			{
				arcadeSprite2 = enemyController;
			}
			else
			{
				Weapon weapon3 = _weapon;
				arcadeSprite2 = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
			}
			float2 float6 = arcadeSprite2.position;
			float2 float7 = base.position;
			object obj3 = default(object);
			object obj4 = default(object);
			obj = obj3 - obj4;
			Vector2 previousVector = float6 - float7;
			Vector3 vector = (Vector3)(&obj2);
			ArcadeSprite arcadeSprite = this;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		float num = (float)obj * 57.29578f;
		base.angle = num;
		setVelocity(0f, (float?)(object)0);
		Weapon weapon4 = _weapon;
		float num2 = weapon4.PArea();
		object trail = _Trail;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rsi_v5 (System.Object)+10]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rsi_v5 (System.Object)+10]");
			TrailRenderer.Clear_Injected((IntPtr)0);
			_Trail.enabled = true;
			float2 float8 = base.position;
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			Transform transform = base.transform;
			if ((object)transform != null)
			{
				nint num3 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj5 = default(object);
				bool flag = obj5 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			tweenConfig.x = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			tweenConfig.duration = 150f;
			tweenConfig.y = (float?)(object)1;
			float delay = (float)_indexInWeapon * 50f;
			tweenConfig.ease = Ease.InOutSine;
			tweenConfig.delay = delay;
			TweenCallback onStart = delegate
			{
				//IL_003b: Expected O, but got Ref
				//IL_0067: Expected O, but got I4
				//IL_0085: Expected O, but got I4
				if (_angleTween != null)
				{
					_angleTween.Kill();
				}
				Transform transform2 = _spikeSprite.transform;
				object obj6 = default(object);
				transform2.localEulerAngles = (Vector3)(&obj6);
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				object obj7 = _indexInWeapon * 200;
				float detune = (float)obj7 - 200f;
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Detune = detune;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, time);
			};
			tweenConfig.onStart = onStart;
			TweenCallback onComplete = delegate
			{
				FadeOut();
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
			return;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(trail);
		throw new NullReferenceException();
	}

	private void _003CInitProjectile_003Eb__15_1()
	{
		//IL_0010: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
	}

	private void _003CInitProjectile_003Eb__15_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CFadeOut_003Eb__18_0()
	{
		Despawn();
	}

	private unsafe void _003CYeet_003Eb__19_0()
	{
		//IL_003b: Expected O, but got Ref
		//IL_0067: Expected O, but got I4
		//IL_0085: Expected O, but got I4
		if (_angleTween != null)
		{
			_angleTween.Kill();
		}
		Transform transform = _spikeSprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj2 = _indexInWeapon * 200;
		float detune = (float)obj2 - 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, time);
	}

	private void _003CYeet_003Eb__19_1()
	{
		FadeOut();
	}
}
