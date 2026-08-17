using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
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
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Energy2_Projectile : Projectile
{
	private TP_Energy2_Weapon _trueWeapon;

	private float _cachedArea;

	private bool _isBeamInfinite;

	private PhaserSprite _beamSprite;

	private PhaserSprite _shotSprite;

	private PhaserSprite _chargeSprite;

	private const float SpriteWidth = 120f;

	private const float SpriteHeight = 25f;

	private const int SpriteDepth = 5000;

	private const int AnimFPS = 50;

	private Timer _expireTimer;

	private Timer _hitboxTimer;

	private Timer _sfxTimer;

	private const float SfxStartDuration = 600f;

	private const float SfxLoopDuration = 400f;

	private float SfxVolume;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private MultiTargetTween _chargeAlphaTween;

	private MultiTargetTween _chargeScaleTween;

	private const float ScaleTweenDuration = 200f;

	private const float ChargeTweenDuration = 500f;

	private bool _scaleInFinished;

	protected override void Awake()
	{
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		ArcadeSprite arcadeSprite = setFrame(sprite);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite beamSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Nitesco_Beam");
		_beamSprite = beamSprite;
		GameObject gameObject2 = _beamSprite.gameObject;
		PhaserSprite shotSprite = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "ThosePeople", "TP_VFX_Nitesco01");
		_shotSprite = shotSprite;
		GameObject gameObject3 = _beamSprite.gameObject;
		PhaserSprite chargeSprite = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "ThosePeople", "TP_VFX_Nitesco_Charge");
		_chargeSprite = chargeSprite;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Nitesco", 1, 8, "ThosePeople", num);
		PhaserSprite shotSprite2 = _shotSprite;
		Action action = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A442F]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			PhaserSprite shotSprite4 = _shotSprite;
			shotSprite4._spriteAnimation.SetAnimation("shot_loop");
		};
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		shotSprite2._spriteAnimation.AddAnimation("shot_start", animationFrames, 50, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_VFX_Nitesco", 9, 12, "ThosePeople", num);
		PhaserSprite shotSprite3 = _shotSprite;
		shotSprite3._spriteAnimation.AddAnimation("shot_loop", animationFrames2, 50, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_081c: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0109: Expected O, but got I4
		//IL_0109: Expected O, but got I4
		//IL_0127: Expected O, but got I4
		//IL_01a9: Expected O, but got I4
		//IL_0209: Expected O, but got I4
		//IL_0276: Expected I, but got O
		//IL_02e8: Expected O, but got I4
		//IL_03a9: Expected I, but got O
		//IL_041f: Expected I4, but got I8
		//IL_042d: Expected O, but got I4
		//IL_04c6: Expected I, but got O
		//IL_0538: Expected O, but got I4
		//IL_05d1: Expected I, but got O
		//IL_0627: Expected O, but got I4
		//IL_0643: Expected O, but got I4
		//IL_08a4: Expected O, but got I4
		//IL_07a4: Expected I4, but got F4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		float? trueWeapon;
		if ((object)weapon == null)
		{
			trueWeapon = (float?)(object)0;
			goto IL_07f5;
		}
		nint num = (nint)typeof(TP_Energy2_Weapon);
		nint num2 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v98 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Energy2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v77 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v98 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Energy2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v77 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v161+FFFFFFF8+v71 @ rax_v156*8]");
			if (0 == (nint)typeof(TP_Energy2_Weapon))
			{
				obj3 = 1;
				goto IL_0804;
			}
		}
		obj3 = 0;
		goto IL_0804;
		IL_0804:
		bool flag = obj3 == null;
		trueWeapon = (float?)(object)0;
		if (!flag)
		{
			trueWeapon = (float?)weapon;
		}
		goto IL_07f5;
		IL_07f5:
		_trueWeapon = (TP_Energy2_Weapon)trueWeapon;
		float num4 = _weapon.PArea();
		float cachedArea = default(float);
		_cachedArea = cachedArea;
		UpdatePosition();
		BaseBody baseBody = body.setSize((float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body.setOffset(-60f, (float?)(object)1);
		PhaserSprite phaserSprite = _beamSprite.setAlpha(0.5f);
		PhaserSprite phaserSprite2 = _shotSprite.setAlpha(0.75f);
		PhaserSprite phaserSprite3 = _shotSprite.setVisible(visible: false);
		PhaserSprite phaserSprite4 = _chargeSprite.setAlpha(0f);
		PhaserSprite phaserSprite5 = _chargeSprite.setScale(0.5f, (float?)(object)0);
		PhaserSprite phaserSprite6 = _beamSprite.setDepth(5000);
		PhaserSprite phaserSprite7 = _shotSprite.setDepth(5001);
		PhaserSprite phaserSprite8 = _chargeSprite.setDepth(5002);
		ArcadeSprite arcadeSprite = setScale(_cachedArea, (float?)(object)1);
		_scaleInFinished = false;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num5 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj4 = default(object);
		if (obj4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.ease = Ease.OutSine;
			tweenConfig.scaleY = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4430]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				_scaleInFinished = true;
				PhaserSprite phaserSprite9 = _shotSprite.setVisible(visible: true);
				PhaserSprite shotSprite = _shotSprite;
				shotSprite._spriteAnimation.SetAnimation("shot_start");
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			if (_alphaTween != null)
			{
				_alphaTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			if ((object)_beamSprite != null)
			{
				nint num6 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj5 = default(object);
				if (obj5 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 100f;
			tweenConfig2.yoyo = true;
			tweenConfig2.repeat = -1;
			tweenConfig2.alpha = (float?)(object)1;
			MultiTargetTween alphaTween = Tweens.Add(tweenConfig2);
			_alphaTween = alphaTween;
			if (_chargeAlphaTween != null)
			{
				_chargeAlphaTween.Kill();
			}
			TweenConfig tweenConfig3 = new TweenConfig();
			object[] array3 = new object[1];
			if ((object)_chargeSprite != null)
			{
				nint num7 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj6 = default(object);
				if (obj6 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array3;
			tweenConfig3.duration = 250f;
			tweenConfig3.yoyo = true;
			tweenConfig3.alpha = (float?)(object)1;
			MultiTargetTween chargeAlphaTween = Tweens.Add(tweenConfig3);
			_chargeAlphaTween = chargeAlphaTween;
			if (_chargeScaleTween != null)
			{
				_chargeScaleTween.Kill();
			}
			TweenConfig tweenConfig4 = new TweenConfig();
			object[] array4 = new object[1];
			if ((object)_chargeSprite != null)
			{
				nint num8 = (nint)array4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj7 = default(object);
				if (obj7 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig4.targets = array4;
			tweenConfig4.scale = (float?)(object)1;
			tweenConfig4.duration = 500f;
			tweenConfig4.angle = (float?)(object)1;
			MultiTargetTween chargeScaleTween = Tweens.Add(tweenConfig4);
			_chargeScaleTween = chargeScaleTween;
			_isBeamInfinite = true;
			float num9 = _weapon.PInterval();
			float num10 = _weapon.PDuration();
			if (_cachedArea > _cachedArea)
			{
				_isBeamInfinite = false;
				StartExpireTimer();
			}
			StartHitboxTimer();
			float sfxVolume = ((!_isBeamInfinite) ? 2.5f : 1.5f);
			SfxVolume = sfxVolume;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			float num11 = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_NitescoStart, soundConfig, 600f, 1, num11);
			if (_sfxTimer != null)
			{
				_sfxTimer.Cancel();
			}
			Action onComplete2 = PlaySfxLoop;
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer sfxTimer = Timers.Register(0.6f, onComplete2, null, isLooped: false, (byte)(int)num11 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_sfxTimer = sfxTimer;
			return;
		}
		ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
		throw ex4;
	}

	public override void InternalUpdate()
	{
		UpdatePosition();
		if (_isBeamInfinite)
		{
			float num = _weapon.PInterval();
			float num2 = _weapon.PDuration();
			object obj = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				_isBeamInfinite = false;
				StartExpireTimer();
			}
		}
	}

	private void StartExpireTimer()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num = _weapon.PDuration();
		Action onComplete = StartDespawn;
		object obj = default(object);
		float duration = (float)obj * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	private unsafe void UpdatePosition()
	{
		//IL_00e2: Expected O, but got I
		//IL_0118: Expected O, but got I
		//IL_0183: Expected O, but got I
		//IL_01b9: Expected O, but got I
		//IL_0269: Invalid comparison between I4 and F4
		//IL_02e3: Invalid comparison between I4 and F4
		//IL_038e: Invalid comparison between O and F4
		//IL_044b: Expected O, but got I4
		//IL_044b: Expected F4, but got O
		//IL_04d9->IL0455: Incompatible stack heights: 1 vs 0
		//IL_01a3->IL0455: Incompatible stack heights: 1 vs 0
		//IL_01d6->IL0455: Incompatible stack heights: 1 vs 0
		//IL_0205->IL0455: Incompatible stack heights: 1 vs 0
		//IL_024b->IL0522: Incompatible stack heights: 4 vs 2
		//IL_0587->IL0455: Incompatible stack heights: 4 vs 0
		//IL_02c5->IL0455: Incompatible stack heights: 4 vs 0
		//IL_05a6->IL0455: Incompatible stack heights: 4 vs 0
		//IL_033f->IL0455: Incompatible stack heights: 4 vs 0
		//IL_0371->IL0455: Incompatible stack heights: 4 vs 0
		//IL_05c5->IL0455: Incompatible stack heights: 4 vs 0
		//IL_0428->IL0455: Incompatible stack heights: 4 vs 0
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			bool flag = ((Equipment)weapon)._003COwner_003Ek__BackingField.flipX;
			if (_isBeamInfinite)
			{
				if ((object)_weapon == null)
				{
					goto IL_0455;
				}
				float num = _weapon.PArea();
			}
			ArcadeSprite weapon2 = (ArcadeSprite)(object)_weapon;
			if ((object)_weapon != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rsi_v9 (ArcadeSprite)+58]");
				ArcadeSprite arcadeSprite = (ArcadeSprite)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rsi_v9 (ArcadeSprite)+58]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rsi_v9 (ArcadeSprite)+58]");
					((ArcadeSprite)0).CheckRenderer();
					if ((object)arcadeSprite._spriteRenderer != null)
					{
						Sprite sprite = arcadeSprite._spriteRenderer.sprite;
						if ((object)sprite != null)
						{
							bool flag2 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
							float2 ret;
							Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out *(Rect*)(&ret));
							ArcadeSprite weapon3 = (ArcadeSprite)(object)_weapon;
							if ((object)_weapon != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rsi_v12 (ArcadeSprite)+58]");
								ArcadeSprite arcadeSprite2 = (ArcadeSprite)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rsi_v12 (ArcadeSprite)+58]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rsi_v12 (ArcadeSprite)+58]");
									((ArcadeSprite)0).CheckRenderer();
									if ((object)arcadeSprite2._spriteRenderer != null)
									{
										Sprite sprite2 = arcadeSprite2._spriteRenderer.sprite;
										if ((object)sprite2 != null)
										{
											bool flag3 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
											Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out *(Rect*)(&ret));
											Transform transform = default(Transform);
											if (!flag)
											{
												bool flag4 = (object)_trueWeapon == null;
												float playerFacing = _trueWeapon.PlayerFacing;
												transform = base.transform;
												bool flag5 = (object)transform == null;
											}
											bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
											Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&ret));
											bool flag7 = (object)_trueWeapon == null;
											float playerFacing2 = _trueWeapon.PlayerFacing;
											bool flag8 = 0f > -1f;
											bool flag9 = flag;
											if (!flag8)
											{
												flag9 = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
											}
											if ((object)_beamSprite != null)
											{
												PhaserSprite phaserSprite = _beamSprite.setFlipX(flag9);
												if ((object)_trueWeapon != null)
												{
													float playerFacing3 = _trueWeapon.PlayerFacing;
													bool flag10 = 0f > -1f;
													bool flag11 = flag;
													if (!flag10)
													{
														flag11 = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
													}
													if ((object)_shotSprite != null)
													{
														PhaserSprite phaserSprite2 = _shotSprite.setFlipX(flag11);
														if ((object)_chargeSprite != null)
														{
															float2 float5 = default(float2);
															PhaserSprite phaserSprite3 = _chargeSprite.setLocalPosition(float5);
															if ((object)_trueWeapon != null)
															{
																float playerFacing4 = _trueWeapon.PlayerFacing;
																bool flag12 = System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)(-1f));
																bool flag13 = flag;
																if (!flag12)
																{
																	flag13 = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
																}
																if ((object)_chargeSprite != null)
																{
																	PhaserSprite phaserSprite4 = _chargeSprite.setFlipX(flag13);
																	if (!_isBeamInfinite || !_scaleInFinished)
																	{
																		return;
																	}
																	if ((object)_weapon != null)
																	{
																		float num2 = _weapon.PArea();
																		ArcadeSprite arcadeSprite3 = setScale((float)float5, (float?)(object)0);
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
		goto IL_0455;
		IL_0455:
		throw new NullReferenceException();
	}

	private void StartHitboxTimer()
	{
		float num3;
		if (_isBeamInfinite)
		{
			float num = _weapon.PDuration();
			float num2 = _weapon.PInterval();
			object obj = default(object);
			num3 = (float)obj / (float)obj;
		}
		else
		{
			num3 = 1f;
		}
		float hitBoxDelay = _weapon.HitBoxDelay;
		float num4 = _weapon.PAmount();
		float num5 = hitBoxDelay * num3;
		float num6 = hitBoxDelay / num5;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		Action onComplete = delegate
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			StartHitboxTimer();
		};
		float duration = num6 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
	}

	private void PlaySfxLoop()
	{
		//IL_00ad: Expected O, but got I4
		//IL_0069: Expected I4, but got F4
		StopSfxLoop();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_NitescoLoop, soundConfig, 400f, 2, num);
		Action onComplete = PlaySfxLoop;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer sfxTimer = Timers.Register(0.4f, onComplete, null, isLooped: true, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_sfxTimer = sfxTimer;
	}

	private void StopSfxLoop()
	{
		SoundManager.StopSound(SfxType.TP_sfx_NitescoLoop);
		if (_sfxTimer != null)
		{
			_sfxTimer.Cancel();
		}
	}

	private void StartDespawn()
	{
		//IL_003f: Expected I, but got O
		//IL_00b1: Expected O, but got I4
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
			tweenConfig.ease = Ease.InSine;
			tweenConfig.scaleY = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
				TP_Energy2_Weapon trueWeapon = _trueWeapon;
				trueWeapon._003CIsBeamActive_003Ek__BackingField = false;
				Despawn();
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void Despawn()
	{
		PhaserSprite phaserSprite = _shotSprite.setVisible(visible: false);
		PhaserSprite shotSprite = _shotSprite;
		SpriteAnimation spriteAnimation = shotSprite._spriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_chargeScaleTween != null)
		{
			_chargeScaleTween.Kill();
		}
		if (_chargeAlphaTween != null)
		{
			_chargeAlphaTween.Kill();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_sfxTimer != null)
		{
			_sfxTimer.Cancel();
		}
		StopSfxLoop();
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
	}

	private void _003CAwake_003Eb__23_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A442F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PhaserSprite shotSprite = _shotSprite;
		shotSprite._spriteAnimation.SetAnimation("shot_loop");
	}

	private void _003CInitProjectile_003Eb__24_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4430]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_scaleInFinished = true;
		PhaserSprite phaserSprite = _shotSprite.setVisible(visible: true);
		PhaserSprite shotSprite = _shotSprite;
		shotSprite._spriteAnimation.SetAnimation("shot_start");
	}

	private void _003CStartHitboxTimer_003Eb__28_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		StartHitboxTimer();
	}

	private void _003CStartDespawn_003Eb__31_0()
	{
		TP_Energy2_Weapon trueWeapon = _trueWeapon;
		trueWeapon._003CIsBeamActive_003Ek__BackingField = false;
		Despawn();
	}
}
