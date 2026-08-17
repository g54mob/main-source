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
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Light1_Projectile : Projectile
{
	private List<Projectile> _orbiters;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private float2 _centralPos;

	private float _angleInc;

	private float _flipNum = 1f;

	private Timer _expireTimer;

	protected SpriteAnimation _spriteAnimator;

	private float radiusMul;

	private TweenerCore<float, float, FloatOptions> radiusTween;

	private int _flipDir;

	protected PhaserSprite _glowSprite;

	private const float goldenRatio = 1.618034f;

	protected TP_Light1_Weapon _trueWeapon;

	public virtual float BodyRadius => 16f;

	public virtual float Scale => 1f;

	public virtual float Depth => 2f;

	public virtual bool HasOrbiters => false;

	public virtual int InvertMotion => 1;

	protected override void Awake()
	{
		base.Awake();
		_speed = 0.5f;
		List<Projectile> orbiters = new List<Projectile>();
		_orbiters = orbiters;
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		MakeSpriteAnimation();
	}

	public virtual void MakeSpriteAnimation()
	{
		GameObject gameObject = _renderer.gameObject;
		SpriteAnimation spriteAnimator = gameObject.AddComponent<SpriteAnimation>();
		_spriteAnimator = spriteAnimator;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Lumos", 1, 12, "ThosePeople", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimator.AddAnimation("loop", animationFrames, 30, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		GameObject gameObject2 = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite glowSprite = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "vfx", "corridor_light");
		_glowSprite = glowSprite;
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_glowSprite, 0.25f);
		PhaserSprite phaserSprite2 = _glowSprite.setAlpha(0.65f);
		PhaserSprite phaserSprite3 = _glowSprite.setVisible(visible: false);
	}

	protected virtual void InitAlpha()
	{
		//IL_0018: Invalid comparison between F4 and O
		//IL_0041: Invalid comparison between O and F4
		float num = _weapon.PArea();
		object obj = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
		float num2 = 1f;
		if (!flag)
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)3f))
			{
				float num3 = (float)obj - 1f;
				float num4 = num3 * 0.3f;
				float num5 = num4 * 0.5f;
				num2 = 1f - num5;
			}
			else
			{
				num2 = 0.7f;
			}
		}
		ArcadeSprite arcadeSprite = setAlpha(num2);
		PhaserSprite phaserSprite = _glowSprite.setAlpha(0f);
		TP_Light1_Weapon trueWeapon = _trueWeapon;
		trueWeapon._003CProjScaledAlpha_003Ek__BackingField = num2;
	}

	protected virtual void PlayFiringSfx()
	{
		//IL_004b: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.8f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * 100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_MagicMissile1, soundConfig, 50f, 1, time);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I4, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_0b72: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_018a: Expected O, but got I4
		//IL_018a: Expected O, but got I4
		//IL_01b6: Expected O, but got I4
		//IL_0268: Expected I, but got O
		//IL_02e4: Expected O, but got I4
		//IL_0376: Expected I, but got O
		//IL_03e4: Expected O, but got I4
		//IL_0bdf: Expected O, but got I4
		//IL_0be8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bed: Expected O, but got Unknown
		//IL_06af: Expected O, but got F4
		//IL_08fb: Invalid comparison between F4 and I4
		//IL_090d: Expected O, but got I4
		//IL_0c7e: Expected I, but got O
		//IL_0a1c: Expected I4, but got O
		//IL_0a1c: Expected O, but got I
		//IL_0ad5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ada: Expected O, but got Unknown
		//IL_0ae2: Invalid comparison between F4 and O
		//IL_0d10->IL0b01: Incompatible stack heights: 1 vs 0
		//IL_09bc->IL0b01: Incompatible stack heights: 1 vs 0
		//IL_09f8->IL0b01: Incompatible stack heights: 1 vs 0
		//IL_0afb->IL0cc3: Incompatible stack heights: 1 vs 0
		//IL_0b00->IL0b00: Incompatible stack heights: 1 vs 0
		//IL_0a8b->IL0b01: Incompatible stack heights: 1 vs 0
		//IL_0ab7->IL0b01: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		float? trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_0b4b;
		}
		nint num = (nint)typeof(TP_Light1_Weapon);
		int num2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v105 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Light1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r9_v16 (System.Int32)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v105 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Light1_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r9_v16 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v175+FFFFFFF8+v72 @ rax_v170*8]");
			if (0 == (nint)typeof(TP_Light1_Weapon))
			{
				obj3 = 1;
				goto IL_0b5a;
			}
		}
		obj3 = 0;
		goto IL_0b5a;
		IL_0b5a:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)_weapon;
		}
		goto IL_0b4b;
		IL_0b4b:
		_trueWeapon = (TP_Light1_Weapon)trueWeapon;
		InitAlpha();
		PlayFiringSfx();
		_isCullable = false;
		if ((object)_spriteAnimator != null)
		{
			_spriteAnimator.SetAnimation("loop");
			if ((object)_renderer != null)
			{
				_renderer.enabled = true;
				float bodyRadius = BodyRadius;
				if (body != null)
				{
					float num4 = default(float);
					BaseBody baseBody = body.setCircle(num4, (float?)(object)0, (float?)(object)0);
					float num5 = Depth;
					ArcadeSprite arcadeSprite = setDepth(num4);
					ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
					if ((object)_weapon != null)
					{
						float num6 = _weapon.PArea();
						float num7 = Scale;
						if (_scaleTween != null)
						{
							_scaleTween.Kill();
						}
						TweenConfig tweenConfig = new TweenConfig();
						object[] array = new object[1];
						if (array != null)
						{
							nint num8 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							object obj4 = default(object);
							if (obj4 == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null)
							{
								tweenConfig.targets = array;
								tweenConfig.duration = 1000f;
								tweenConfig.scale = (float?)(object)1;
								MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
								_scaleTween = scaleTween;
								if (_alphaTween != null)
								{
									_alphaTween.Kill();
								}
								TweenConfig tweenConfig2 = new TweenConfig();
								object[] array2 = new object[1];
								if (array2 != null)
								{
									nint num9 = (nint)array2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj5 = default(object);
									if (obj5 == null)
									{
										ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
										throw ex2;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
									if (tweenConfig2 != null)
									{
										tweenConfig2.targets = array2;
										tweenConfig2.alpha = (float?)(object)1;
										if ((object)_weapon != null)
										{
											float num10 = _weapon.PDuration();
											tweenConfig2.duration = num4;
											MultiTargetTween alphaTween = Tweens.Add(tweenConfig2);
											_alphaTween = alphaTween;
											_angleInc = 0f;
											int invertMotion = InvertMotion;
											Weapon weapon3 = _weapon;
											if ((object)_weapon != null)
											{
												VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon3)._003COwner_003Ek__BackingField;
												if ((object)((Equipment)weapon3)._003COwner_003Ek__BackingField != null)
												{
													int flipDir = -invertMotion;
													if (!characterController._isFlipped)
													{
														flipDir = invertMotion;
													}
													_flipDir = flipDir;
													int invertMotion2 = InvertMotion;
													int num11 = ~_indexInWeapon;
													int num12 = num11 & 1;
													object obj6 = num12 * 2;
													object obj7 = obj6 - 1;
													float flipNum = (float)obj7 * (float)invertMotion2;
													_flipNum = flipNum;
													Weapon weapon4 = _weapon;
													if ((object)_weapon != null && (object)((Equipment)weapon4)._003COwner_003Ek__BackingField != null)
													{
														float2 float5 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.position;
														Weapon weapon5 = _weapon;
														if ((object)_weapon != null)
														{
															ArcadeSprite arcadeSprite3 = ((Equipment)weapon5)._003COwner_003Ek__BackingField;
															if ((object)((Equipment)weapon5)._003COwner_003Ek__BackingField != null)
															{
																((ArcadeSprite)((Equipment)weapon5)._003COwner_003Ek__BackingField).CheckRenderer();
																if ((object)arcadeSprite3._spriteRenderer != null)
																{
																	Vector2 vector = arcadeSprite3._spriteRenderer.size;
																	Weapon weapon6 = _weapon;
																	if ((object)_weapon != null)
																	{
																		ArcadeSprite arcadeSprite4 = ((Equipment)weapon6)._003COwner_003Ek__BackingField;
																		if ((object)((Equipment)weapon6)._003COwner_003Ek__BackingField != null)
																		{
																			((ArcadeSprite)((Equipment)weapon6)._003COwner_003Ek__BackingField).CheckRenderer();
																			if ((object)arcadeSprite4._spriteRenderer != null)
																			{
																				Vector2 vector2 = arcadeSprite4._spriteRenderer.size;
																				float num13 = (float)vector * 0.5f;
																				object obj8 = default(object);
																				float num14 = (float)obj8 * 0.5f;
																				float num15 = num13 * _flipNum;
																				float num16 = num14 + 1.0569646E+09f;
																				float num17 = (float)float5 + num15;
																				_centralPos = (float2)num17;
																				if (_expireTimer != null)
																				{
																					_expireTimer.Cancel();
																				}
																				if ((object)_weapon != null)
																				{
																					float num18 = _weapon.PDuration();
																					Action onComplete = StartDespawn;
																					float num19 = num17 * 0.001f;
																					bool useRealTime = default(bool);
																					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																					int repeat = default(int);
																					TimerType type = default(TimerType);
																					Timer expireTimer = Timers.Register(num19, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																					_expireTimer = expireTimer;
																					radiusMul = 0f;
																					if (radiusTween != null)
																					{
																						TweenExtensions.Kill(radiusTween);
																					}
																					DOGetter<float> getter = null;
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
																					DOSetter<float> dOSetter = null;
																					((TP_Light1_Projectile)(object)dOSetter)._003CInitProjectile_003Eb__28_1(num15);
																					TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 18f, 0.5f);
																					radiusTween = tweenerCore;
																					TweenerCore<float, float, FloatOptions> tweenerCore2 = radiusTween;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
																					if ((nint)0 == 0)
																					{
																						_ = 1;
																					}
																					if (radiusTween != null)
																					{
																						if (!HasOrbiters)
																						{
																							return;
																						}
																						if ((object)_glowSprite != null)
																						{
																							PhaserSprite phaserSprite = _glowSprite.setVisible(visible: true);
																							List<Projectile> orbiters = new List<Projectile>();
																							_orbiters = orbiters;
																							if ((object)weapon != null)
																							{
																								float num20 = weapon.PAmount();
																								bool flag2 = !(num19 > 0f);
																								float? num21 = (float?)(object)0;
																								if (flag2)
																								{
																									return;
																								}
																								float2 pos = default(float2);
																								float num22 = default(float);
																								while (true)
																								{
																									Weapon weapon7 = _weapon;
																									Weapon trueWeapon2 = _trueWeapon;
																									if ((object)_weapon == null)
																									{
																										break;
																									}
																									ArcadeSprite arcadeSprite5 = ((Equipment)weapon7)._003COwner_003Ek__BackingField;
																									if ((object)((Equipment)weapon7)._003COwner_003Ek__BackingField == null)
																									{
																										break;
																									}
																									Transform cachedTrans = ((ArcadeSprite)((Equipment)weapon7)._003COwner_003Ek__BackingField).CachedTrans;
																									if ((object)cachedTrans == null)
																									{
																										break;
																									}
																									bool flag3 = ((EventEmitter)(object)cachedTrans).callbacks == null;
																									float2 ret;
																									Transform.get_position_Injected((IntPtr)((EventEmitter)(object)cachedTrans).callbacks, out *(Vector3*)(&ret));
																									if (arcadeSprite5.body != null)
																									{
																										BaseBody baseBody2 = arcadeSprite5.body;
																										ArcadeTransform arcadeTransform = baseBody2._transform;
																										if (baseBody2._transform == null)
																										{
																											break;
																										}
																										arcadeTransform.position = ret;
																									}
																									if ((object)_trueWeapon == null)
																									{
																										break;
																									}
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ r14_v11 (VampireSurvivors.Objects.Weapons.Weapon)+158]");
																									if ((nint)0 == 0)
																									{
																										break;
																									}
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ r14_v11 (VampireSurvivors.Objects.Weapons.Weapon)+158]");
																									Projectile projectile = ((BulletPool)0).SpawnAt(pos, _trueWeapon, (int)num21);
																									if ((object)projectile != null && ((UnityEngine.Object)projectile).m_CachedPtr != (IntPtr)0)
																									{
																										Transform transform = projectile.transform;
																										Transform parent = base.transform;
																										if ((object)transform == null)
																										{
																											break;
																										}
																										transform.parent = parent;
																										if (_orbiters == null)
																										{
																											break;
																										}
																										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6A10");
																									}
																									num21 = (float?)(object)((_003F?)num21 + 1);
																									bool flag4 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num19) > System.Runtime.CompilerServices.Unsafe.As<float?, UIntPtr>(ref num21);
																									num15 = num22;
																									if (!flag4)
																									{
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
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		//IL_000e: Expected I, but got O
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c2: Invalid comparison between O and F4
		float deltaTime = PauseSystem.DeltaTime;
		nint num = (nint)this;
		float num2 = deltaTime * 1000f;
		float projectileSpeed = base.ProjectileSpeed;
		float num3 = num2 * 0.0025f;
		float num4 = deltaTime * num3;
		float num5 = (_angleInc = num4 + _angleInc);
		float num6 = num5 / (float)Math.PI;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
		float num7 = radiusMul * _flipNum;
		float num8 = 1.618034f * num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num8 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)500f))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rbx+118h]\"");
			float num9 = 0f * num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,dword ptr [rbx+118h]\"");
			float num10 = 0f * num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float2 float5 = default(float2);
			base.position = float5;
		}
		else if (body != null)
		{
			Despawn();
		}
	}

	private void StartDespawn()
	{
		//IL_003f: Expected I, but got O
		//IL_00a3: Expected O, but got I4
		//IL_00b1: Expected O, but got I4
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
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
			tweenConfig.duration = 100f;
			tweenConfig.alpha = (float?)(object)1;
			tweenConfig.scale = (float?)(object)1;
			TweenCallback onComplete = TryDespawn;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
			_alphaTween = alphaTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void TryDespawn()
	{
		if (body != null)
		{
			Despawn();
		}
	}

	public override void Despawn()
	{
		//IL_0013: Expected O, but got I4
		//IL_00f2: Expected O, but got I4
		//IL_0100: Expected O, but got I4
		List<Projectile>.Enumerator enumerator = default(List<Projectile>.Enumerator);
		if (_orbiters != null && enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
		if (radiusTween != null)
		{
			TweenExtensions.Kill(radiusTween);
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		Timer expireTimer = _expireTimer;
		if (_expireTimer != null && !_expireTimer.IsDone)
		{
			float timeElapsed = _expireTimer.GetTimeElapsed();
			expireTimer._timeElapsedBeforeCancel = (float?)(object)1;
			expireTimer._timeElapsedBeforePause = (float?)(object)0;
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable target)
	{
	}

	private float _003CInitProjectile_003Eb__28_0()
	{
		return radiusMul;
	}

	private void _003CInitProjectile_003Eb__28_1(float x)
	{
		radiusMul = x;
	}
}
