using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_CrushProjectile : Projectile
{
	private Timer _hitboxTimer;

	private MultiTargetTween _flightPositionTween;

	private MultiTargetTween _flightScaleTween;

	private MultiTargetTween _scaleOutTween;

	private Timer _appearTimer;

	private Timer _disappearTimer;

	private bool _hasHitGround;

	private SpriteAnimation _spriteAnim;

	private PhaserSprite _displaySprite;

	private MultiTargetTween _blackBubbleTween;

	private void SetupAnimation()
	{
		CheckRenderer();
		GameObject gameObject = ((ArcadeSprite)this)._spriteRenderer.gameObject;
		SpriteAnimation spriteAnim = ((!gameObject.TryGetComponent<SpriteAnimation>(out var component)) ? gameObject.AddComponent<SpriteAnimation>() : component);
		_spriteAnim = spriteAnim;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Crush Bomb-Bomb-F", 1, 2, "firstBlood", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnim.AddAnimation("flight", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("Crush Black Hole-Loop-CrushBlackHoleLoop_0", 1, 6, "firstBlood", num);
		_spriteAnim.AddAnimation("hole", animationFrames2, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("Crush Black Hole-Death-CrushBlackHoleDeath_0", 1, 8, "firstBlood", num);
		_spriteAnim.AddAnimation("death", animationFrames3, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("Crush Black Hole-Death-CrushBlackHoleDeath_0", 8, 1, "firstBlood", num);
		_spriteAnim.AddAnimation("creation", animationFrames4, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
	}

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Crush Bomb-Bomb-F1", "firstBlood");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		PhaserWorld instance = PhaserWorld.Instance;
		Vector2 pos = default(Vector2);
		PhaserSprite displaySprite = instance.AddPhaserSprite(pos, "firstBlood", "crushBubble");
		_displaySprite = displaySprite;
		PhaserSprite phaserSprite = _displaySprite.setVisible(visible: false);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00d9: Expected O, but got I4
		//IL_012f: Expected O, but got I4
		//IL_019e: Expected O, but got I4
		//IL_019e: Expected O, but got I4
		//IL_0a52: Expected O, but got I4
		//IL_0a64: Expected O, but got I4
		//IL_0c78: Invalid comparison between I4 and F4
		//IL_0589: Invalid comparison between F4 and I4
		//IL_0355: Expected O, but got F4
		//IL_0654: Expected I, but got O
		//IL_0706: Expected O, but got F4
		//IL_073e: Expected O, but got I4
		//IL_074c: Expected O, but got I4
		//IL_0409: Expected I, but got O
		//IL_0450: Expected O, but got F4
		//IL_04c3: Expected O, but got I4
		//IL_0833: Expected I, but got O
		//IL_0923: Expected I, but got O
		//IL_098f: Expected F4, but got I4
		//IL_0647->IL0994: Incompatible stack heights: 1 vs 0
		//IL_0699->IL0994: Incompatible stack heights: 2 vs 0
		//IL_06d2->IL0994: Incompatible stack heights: 2 vs 0
		//IL_07ca->IL0994: Incompatible stack heights: 2 vs 0
		//IL_04c8->IL0c56: Incompatible stack heights: 0 vs 1
		//IL_0821->IL0994: Incompatible stack heights: 3 vs 0
		//IL_08ba->IL0994: Incompatible stack heights: 3 vs 0
		//IL_0911->IL0994: Incompatible stack heights: 4 vs 0
		base.InitProjectile(pool, weapon, index);
		SpriteAnimation spriteAnim = _spriteAnim;
		if ((object)_spriteAnim == null || ((UnityEngine.Object)spriteAnim).m_CachedPtr == (IntPtr)0)
		{
			SetupAnimation();
		}
		Transform targetTransform = base.AimForRandomEnemyInScreen();
		_targetTransform = targetTransform;
		_hasHitGround = false;
		CheckRenderer();
		Material material = MaterialManager.GetMaterial(MaterialType.DefaultSprite);
		float num;
		float num3;
		float num4;
		if ((object)((ArcadeSprite)this)._spriteRenderer != null)
		{
			((Renderer)((ArcadeSprite)this)._spriteRenderer).SetMaterial(material);
			ArcadeSprite arcadeSprite = setAlpha(1f);
			ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
			base.angle = 25f;
			SpriteAnimation spriteAnim2 = _spriteAnim;
			_isCullable = false;
			if ((object)_spriteAnim != null)
			{
				spriteAnim2._originalSpriteSize = (float2)1100480512;
				_ = 1100480512;
				if ((object)_spriteAnim != null)
				{
					_spriteAnim.SetAnimation("flight");
					if (body != null)
					{
						BaseBody baseBody = body.setCircle(8f, (float?)(object)1, (float?)(object)1);
						BaseBody baseBody2 = body;
						if (body != null)
						{
							baseBody2._enable = false;
							Renderer targetTransform2 = (Renderer)(object)_targetTransform;
							if ((object)_targetTransform != null && ((UnityEngine.Object)targetTransform2).m_CachedPtr != (IntPtr)0)
							{
								Renderer targetTransform3 = (Renderer)(object)_targetTransform;
								if ((object)_targetTransform != null)
								{
									bool flag = ((UnityEngine.Object)targetTransform3).m_CachedPtr == (IntPtr)0;
									float ret;
									Transform.get_position_Injected(((UnityEngine.Object)targetTransform3).m_CachedPtr, out *(Vector3*)(&ret));
									float num2 = default(float);
									num = num2;
									num3 = ret;
									PhaserScene phaserScene = (PhaserScene)1;
									num4 = 1f;
									float? num5 = (float?)(object)1;
									nint num6 = (nint)(&ret);
									goto IL_0c56;
								}
							}
							else if ((object)GM.Core != null)
							{
								PhaserScene s_scene = ArcadePhysics.s_scene;
								if (ArcadePhysics.s_scene != null)
								{
									PhaserScene.Renderer renderer = s_scene._renderer;
									if (s_scene._renderer != null && (object)GM.Core != null)
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
														object obj = renderer2.width ^ -0f;
														float minInclusive = (float)obj * 0.5f;
														float maxInclusive = renderer3.width * 0.5f;
														float num7 = UnityEngine.Random.Range(minInclusive, maxInclusive);
														if ((object)GM.Core != null)
														{
															PhaserScene phaserScene = ArcadePhysics.s_scene;
															if (ArcadePhysics.s_scene != null)
															{
																PhaserScene.Renderer renderer4 = phaserScene._renderer;
																if (phaserScene._renderer != null && (object)GM.Core != null)
																{
																	nint num6 = (nint)typeof(ArcadePhysics);
																	PhaserScene s_scene4 = ArcadePhysics.s_scene;
																	if (ArcadePhysics.s_scene != null)
																	{
																		PhaserScene.Renderer renderer5 = s_scene4._renderer;
																		if (s_scene4._renderer != null)
																		{
																			object obj2 = renderer4.height ^ -0f;
																			float minInclusive2 = (float)obj2 * 0.5f;
																			float maxInclusive2 = renderer5.height * 0.5f;
																			float num8 = UnityEngine.Random.Range(minInclusive2, maxInclusive2);
																			num3 = (float)renderer.screenCenter + num7;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v129 (PhaserScene+Renderer)+38]");
																			num = 0f + num8;
																			num4 = 1f;
																			float? num5 = (float?)(object)0;
																			goto IL_0c56;
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
		goto IL_0994;
		IL_0c56:
		float2 float5 = base.position;
		float num9 = num3 - (float)float5;
		float num10 = ((!(0f > num9)) ? num4 : (-1f));
		float num11 = num10 * 20f;
		float num12 = num11 * num;
		bool flag2 = -45f > num12;
		float num13 = -45f;
		float num14;
		if (!flag2)
		{
			bool flag3 = !(num12 > 45f);
			num13 = 45f;
			num14 = 45f;
			if (flag3)
			{
				goto IL_0b79;
			}
		}
		num14 = num13;
		num12 = num13;
		goto IL_0b79;
		IL_0b79:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		float num15 = num - (float)Math.PI / 4f;
		float num16 = num15 * 57.29578f;
		float num17 = num16 + num12;
		base.angle = num17;
		float2 float6 = base.position;
		float num18 = (float)float6 - num3;
		float num19 = 0f - num;
		float num20 = num18 * num18;
		float num21 = num19 * num19;
		float num22 = num20 + num21;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
		bool flag4 = !(num22 > 0f);
		float num23 = num22;
		if (!flag4)
		{
			bool flag5 = !(num4 > num22);
			num23 = num22;
			if (!flag5)
			{
				float2 float7 = base.position;
				float2 float8 = base.position;
				num23 = num4;
			}
		}
		float num24 = num23 * 100f;
		float num25 = num24 * 60f;
		float projectileSpeed = base.ProjectileSpeed;
		float num26 = num25 / num22;
		bool flag6 = 500f > num26;
		float num27 = 500f;
		if (!flag6)
		{
			num27 = num26;
		}
		if (_flightPositionTween != null)
		{
			_flightPositionTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if (array != null)
		{
			nint num28 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			bool flag7 = obj3 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if (tweenConfig != null)
			{
				tweenConfig.targets = array;
				Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
				if ((object)cachedTrans != null)
				{
					Vector3 localEulerAngles = cachedTrans.localEulerAngles;
					float num29 = num12 + num12;
					object obj4 = localEulerAngles.z ^ -0f;
					tweenConfig.duration = num27;
					float num30 = (float)obj4 + num29;
					tweenConfig.ease = Ease.InOutSine;
					tweenConfig.angle = (float?)(object)1;
					tweenConfig.x = (float?)(object)1;
					TweenCallback onComplete = CreateBubble;
					tweenConfig.onComplete = onComplete;
					MultiTargetTween flightPositionTween = Tweens.Add(tweenConfig);
					_flightPositionTween = flightPositionTween;
					TweenConfig tweenConfig2 = new TweenConfig();
					object[] array2 = new object[1];
					if (array2 != null)
					{
						void* value = ((IntPtr*)(&array2))->m_value;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj5 = default(object);
						bool flag8 = obj5 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (tweenConfig2 != null)
						{
							((UnityEngine.Object)(object)tweenConfig2).m_CachedPtr = (IntPtr)array2;
							_ = 1;
							_ = 27;
							MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig2);
							if (_flightScaleTween != null)
							{
								_flightScaleTween.Kill();
							}
							TweenConfig tweenConfig3 = new TweenConfig();
							object[] array3 = new object[1];
							if (array3 != null)
							{
								void* value2 = ((IntPtr*)(&array3))->m_value;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj6 = default(object);
								bool flag9 = obj6 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig3 != null)
								{
									((UnityEngine.Object)(object)tweenConfig3).m_CachedPtr = (IntPtr)array3;
									if (2f > num23)
									{
										_ = 1;
										_ = 4;
										float num31 = num27 * 0.5f;
										_ = 1;
									}
									MultiTargetTween flightScaleTween = Tweens.Add(tweenConfig3);
									_flightScaleTween = flightScaleTween;
									float? volume = default(float?);
									float rate = default(float);
									float detune = default(float);
									bool loop = default(bool);
									PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_CrushShot, 100f, 10, 0f, volume, rate, detune, loop, 1f);
									return;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0994;
		IL_0994:
		throw new NullReferenceException();
	}

	private void CreateBubble()
	{
		//IL_007b: Expected O, but got I4
		//IL_00ce: Expected F4, but got I4
		//IL_01d8: Expected I4, but got F4
		//IL_01d8: Expected O, but got F4
		//IL_01d8: Expected I4, but got O
		_hasHitGround = true;
		CheckRenderer();
		Material material = MaterialManager.GetMaterial(MaterialType.VfxScreen);
		((Renderer)((ArcadeSprite)this)._spriteRenderer).SetMaterial(material);
		ArcadeSprite arcadeSprite = setAlpha(0.65f);
		SpriteAnimation spriteAnim = _spriteAnim;
		((BaseSpriteAnimation)spriteAnim)._currentAnimation = null;
		SpriteAnimation spriteAnim2 = _spriteAnim;
		spriteAnim2._originalSpriteSize = (float2)1115684864;
		_ = 1115684864;
		_spriteAnim.Play("creation", 32);
		float? num = default(float?);
		float num2 = default(float);
		float num3 = default(float);
		bool flag = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_Explosion1, 100f, 10, 0f, num, num2, num3, flag, 1f);
		if (_flightScaleTween != null)
		{
			_flightScaleTween.Kill();
		}
		_flightScaleTween = null;
		SetScaleToArea();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num4 = default(int);
		ArcadeSprite arcadeSprite2 = setDepth(num4);
		int num5 = base.depth;
		int num6 = num5 - 1;
		PhaserSprite phaserSprite = _displaySprite.setDepth(num6);
		if (_appearTimer != null)
		{
			_appearTimer.Cancel();
		}
		Action onComplete = OnHitGround;
		Timer appearTimer = Timers.Register(0.25f, onComplete, null, isLooped: false, (byte)(int)num != 0, (MonoBehaviour)num2, (int)num3, flag ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
		_appearTimer = appearTimer;
	}

	private void OnHitGround()
	{
		//IL_0031: Expected O, but got I4
		//IL_0079: Expected O, but got I4
		//IL_00f5: Expected I, but got O
		//IL_0159: Expected O, but got I4
		//IL_01bd: Expected O, but got I4
		//IL_01bd: Expected O, but got I4
		//IL_0242: Expected I, but got O
		//IL_029a: Expected I, but got O
		//IL_030f: Expected O, but got I4
		SpriteAnimation spriteAnim = _spriteAnim;
		((BaseSpriteAnimation)spriteAnim)._currentAnimation = null;
		SpriteAnimation spriteAnim2 = _spriteAnim;
		spriteAnim2._originalSpriteSize = (float2)1115684864;
		_ = 1115684864;
		_spriteAnim.SetAnimation("hole");
		float num = _weapon.PArea();
		float num2 = default(float);
		PhaserSprite phaserSprite = _displaySprite.setScale(num2, (float?)(object)0);
		if (_blackBubbleTween != null)
		{
			_blackBubbleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_displaySprite != null)
		{
			nint num3 = (nint)array;
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
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			float2 float5 = base.position;
			PhaserSprite phaserSprite3 = _displaySprite.setPosition(float5);
			PhaserSprite phaserSprite4 = _displaySprite.setAlpha(0f);
			PhaserSprite phaserSprite5 = _displaySprite.setVisible(visible: true);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween blackBubbleTween = Tweens.Add(tweenConfig);
		_blackBubbleTween = blackBubbleTween;
		BaseBody baseBody = body.setCircle(32f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._enable = true;
		SetScaleToArea();
		if (_scaleOutTween != null)
		{
			_scaleOutTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[2];
		nint num4 = (nint)array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_displaySprite != null)
			{
				nint num5 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			float num6 = _weapon.PArea();
			float duration = num2 * 0.5f;
			tweenConfig2.scale = (float?)(object)1;
			float num7 = _weapon.PDuration();
			tweenConfig2.duration = duration;
			TweenCallback onComplete = PopBubble;
			tweenConfig2.onComplete = onComplete;
			MultiTargetTween scaleOutTween = Tweens.Add(tweenConfig2);
			_scaleOutTween = scaleOutTween;
			if (_hitboxTimer != null)
			{
				_hitboxTimer.Cancel();
			}
			float hitBoxDelay = _weapon.HitBoxDelay;
			Action onComplete2 = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			};
			float duration2 = hitBoxDelay * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer hitboxTimer = Timers.Register(duration2, onComplete2, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_hitboxTimer = hitboxTimer;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
			int num8 = default(int);
			ArcadeSprite arcadeSprite = setDepth(num8);
			int num9 = base.depth;
			int num10 = num9 - 1;
			PhaserSprite phaserSprite2 = _displaySprite.setDepth(num10);
			return;
		}
		ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
		throw ex3;
	}

	private void PopBubble()
	{
		//IL_007c: Expected I, but got O
		//IL_013b: Expected I, but got O
		//IL_0191: Expected O, but got I4
		//IL_01ad: Expected O, but got I4
		_spriteAnim.SetAnimation("death");
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_disappearTimer != null)
		{
			_disappearTimer.Cancel();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_CrushProjectile>)+370]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num = (nint)this;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer disappearTimer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_disappearTimer = disappearTimer;
		if (_blackBubbleTween != null)
		{
			_blackBubbleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_displaySprite != null)
		{
			nint num2 = (nint)array;
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
		tweenConfig.scale = (float?)(object)1;
		tweenConfig.duration = 200f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween blackBubbleTween = Tweens.Add(tweenConfig);
		_blackBubbleTween = blackBubbleTween;
	}

	public override void InternalUpdate()
	{
		//IL_0021: Expected O, but got I8
		//IL_0038: Expected O, but got I4
		bool flag = _hasHitGround;
		object obj = 4294967196L;
		if (!flag)
		{
			obj = 1000;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		ArcadeSprite arcadeSprite = setDepth(num);
		int num2 = base.depth;
		int num3 = num2 - 1;
		PhaserSprite phaserSprite = _displaySprite.setDepth(num3);
	}

	private void Cleanup()
	{
		if (_appearTimer != null)
		{
			_appearTimer.Cancel();
		}
		_appearTimer = null;
		if (_disappearTimer != null)
		{
			_disappearTimer.Cancel();
		}
		_disappearTimer = null;
		if (_flightPositionTween != null)
		{
			_flightPositionTween.Kill();
		}
		_flightPositionTween = null;
		if (_flightScaleTween != null)
		{
			_flightScaleTween.Kill();
		}
		_flightScaleTween = null;
		if (_scaleOutTween != null)
		{
			_scaleOutTween.Kill();
		}
		_scaleOutTween = null;
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		_hitboxTimer = null;
	}

	public override void Despawn()
	{
		Cleanup();
		base.Despawn();
	}

	protected override void OnDestroy()
	{
		Cleanup();
		if (body != null)
		{
			BaseBody baseBody = body;
			baseBody._gameObject = null;
		}
	}

	private void _003COnHitGround_003Eb__14_1()
	{
		float2 float5 = base.position;
		PhaserSprite phaserSprite = _displaySprite.setPosition(float5);
		PhaserSprite phaserSprite2 = _displaySprite.setAlpha(0f);
		PhaserSprite phaserSprite3 = _displaySprite.setVisible(visible: true);
	}

	private void _003COnHitGround_003Eb__14_0()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}
}
