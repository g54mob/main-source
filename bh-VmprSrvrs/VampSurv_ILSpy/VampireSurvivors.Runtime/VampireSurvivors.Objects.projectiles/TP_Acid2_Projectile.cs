using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
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

public class TP_Acid2_Projectile : Projectile
{
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public TP_Acid2_Projectile _003C_003E4__this;

		public Weapon weapon;

		public Action _003C_003E9__1;

		internal void _003CInitProjectile_003Eb__0()
		{
			TP_Acid2_Projectile tP_Acid2_Projectile = _003C_003E4__this;
			if (tP_Acid2_Projectile._expireTimer != null)
			{
				tP_Acid2_Projectile._expireTimer.Cancel();
			}
			TP_Acid2_Projectile tP_Acid2_Projectile2 = _003C_003E4__this;
			float num = weapon.PDuration();
			Action onComplete = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				onComplete = (_003C_003E9__1 = delegate
				{
					_003C_003E4__this.StartDespawn();
				});
			}
			object obj = default(object);
			float duration = (float)obj * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			tP_Acid2_Projectile2._expireTimer = expireTimer;
		}

		internal void _003CInitProjectile_003Eb__1()
		{
			_003C_003E4__this.StartDespawn();
		}
	}

	private PhaserSprite _animatedSprite;

	private Timer _expireTimer;

	private float _radius = 8f;

	private MultiTargetTween _scaleTween;

	private float _IndexOffsetScaleFactor = 0.1f;

	private MultiTargetTween _alphaTween;

	protected unsafe override void Awake()
	{
		//IL_014d: Expected O, but got I4
		//IL_014d: Expected I4, but got O
		//IL_03bb: Expected I, but got O
		//IL_03d4: Expected O, but got I4
		//IL_04cc: Expected O, but got F4
		//IL_0333->IL0406: Incompatible stack heights: 8 vs 0
		//IL_03a9->IL0406: Incompatible stack heights: 8 vs 0
		//IL_0387->IL0387: Incompatible stack heights: 9 vs 8
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				GameObject gameObject = base.gameObject;
				Vector2 vector = default(Vector2);
				PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Morbus01");
				_animatedSprite = animatedSprite;
				string text = default(string);
				int num = default(int);
				bool flag = default(bool);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Morbus", 2, 9, vector, text, num, flag);
				PhaserSprite animatedSprite2 = _animatedSprite;
				if ((object)_animatedSprite != null && (object)animatedSprite2._spriteAnimation != null)
				{
					bool autoSetAnimation = default(bool);
					animatedSprite2._spriteAnimation.AddAnimation("loop", animationFrames, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
					PhaserSprite animatedSprite3 = _animatedSprite;
					if ((object)_animatedSprite != null && (object)animatedSprite3._spriteAnimation != null)
					{
						animatedSprite3._spriteAnimation.SetAnimation("loop");
						if ((object)_animatedSprite != null)
						{
							Transform transform = _animatedSprite.transform;
							bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							Transform transform2 = _animatedSprite.transform;
							Vector2 euler = default(Vector2);
							Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&euler), out Quaternion ret);
							bool flag3 = (object)transform2 == null;
							bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Quaternion value2 = default(Quaternion);
							Transform.set_localRotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
							bool flag5 = (object)_animatedSprite == null;
							PhaserSprite phaserSprite = _animatedSprite.setAlpha(0.95f);
							PhaserSprite animatedSprite4 = _animatedSprite;
							bool flag6 = (object)_animatedSprite == null;
							SpriteAnimation spriteAnimation = animatedSprite4._spriteAnimation;
							bool flag7 = (object)animatedSprite4._spriteAnimation == null;
							((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
							PhaserSprite animatedSprite5 = _animatedSprite;
							bool flag8 = (object)_animatedSprite == null;
							bool flag9 = (object)animatedSprite5._spriteAnimation == null;
							animatedSprite5._spriteAnimation.SetAnimation("loop");
							if (_alphaTween != null)
							{
								_alphaTween.Kill();
							}
							TweenConfig tweenConfig = new TweenConfig();
							object[] array = new object[1];
							if (array != null)
							{
								if ((object)_animatedSprite != null)
								{
									void* value3 = ((IntPtr*)(&array))->m_value;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj = default(object);
									bool flag10 = obj == null;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig != null)
								{
									((UnityEngine.Object)(object)tweenConfig).m_CachedPtr = (IntPtr)array;
									_ = 1;
									((SpriteRenderer)(object)tweenConfig).m_SpriteChangeEvent = (UnityEvent<SpriteRenderer>)1148846080;
									_ = 4294967295L;
									_ = 1;
									object obj2 = UnityEngine.Random.value;
									float num2 = (float)ret * 1000f;
									MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
									_alphaTween = alphaTween;
									return;
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0046: Expected O, but got I4
		//IL_008b: Expected O, but got I4
		//IL_008b: Expected O, but got I4
		//IL_009f: Expected O, but got I4
		//IL_037a: Expected I, but got O
		//IL_0481: Expected O, but got F4
		//IL_0388: Expected O, but got F4
		//IL_041e: Expected I, but got O
		//IL_01a3: Expected I, but got O
		//IL_024f: Expected O, but got I4
		//IL_02e0: Expected O, but got I4
		//IL_0446: Expected O, but got F4
		//IL_0473: Expected O, but got F4
		//IL_0196->IL030b: Incompatible stack heights: 3 vs 0
		//IL_01e8->IL030b: Incompatible stack heights: 4 vs 0
		//IL_021c->IL030b: Incompatible stack heights: 4 vs 0
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass7_0();
		if (CS_0024_003C_003E8__locals13 != null)
		{
			CS_0024_003C_003E8__locals13._003C_003E4__this = this;
			CS_0024_003C_003E8__locals13.weapon = weapon;
			base.InitProjectile(pool, CS_0024_003C_003E8__locals13.weapon, index);
			_isCullable = false;
			ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
			if (body != null)
			{
				BaseBody baseBody = body.setCircle(_radius, (float?)(object)1, (float?)(object)1);
				ArcadeSprite arcadeSprite2 = setScale(0f, (float?)(object)0);
				if ((object)_animatedSprite != null)
				{
					PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: true);
					if ((object)_animatedSprite != null)
					{
						PhaserSprite phaserSprite2 = _animatedSprite.setDepth(2);
						BulletPool cachedTransform = (BulletPool)(object)_cachedTransform;
						_IndexOffsetScaleFactor = 0.1f;
						if ((object)_cachedTransform != null)
						{
							bool flag = ((EventEmitter)cachedTransform).callbacks == null;
							Transform.get_position_Injected((IntPtr)((EventEmitter)cachedTransform).callbacks, out Vector3 ret);
							object obj = UnityEngine.Random.value;
							object obj2 = UnityEngine.Random.value;
							float num = (float)ret - 0.5f;
							BulletPool cachedTransform2 = (BulletPool)(object)_cachedTransform;
							float num2 = num * (float)_indexInWeapon;
							float num3 = num2 * _IndexOffsetScaleFactor;
							object obj3 = default(object);
							float num4 = num3 + (float)obj3;
							bool flag2 = (object)_cachedTransform == null;
							bool flag3 = ((EventEmitter)cachedTransform2).callbacks == null;
							Vector3 value = default(Vector3);
							Transform.set_position_Injected((IntPtr)((EventEmitter)cachedTransform2).callbacks, ref value);
							if (_scaleTween != null)
							{
								_scaleTween.Kill();
							}
							TweenConfig tweenConfig = new TweenConfig();
							object[] array = new object[1];
							if (array != null)
							{
								nint num5 = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj4 = default(object);
								bool flag4 = obj4 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig != null)
								{
									tweenConfig.targets = array;
									if ((object)CS_0024_003C_003E8__locals13.weapon != null)
									{
										float num6 = CS_0024_003C_003E8__locals13.weapon.PArea();
										tweenConfig.duration = 200f;
										tweenConfig.scale = (float?)(object)1;
										TweenCallback onComplete = delegate
										{
											TP_Acid2_Projectile tP_Acid2_Projectile = CS_0024_003C_003E8__locals13._003C_003E4__this;
											if (tP_Acid2_Projectile._expireTimer != null)
											{
												tP_Acid2_Projectile._expireTimer.Cancel();
											}
											TP_Acid2_Projectile tP_Acid2_Projectile2 = CS_0024_003C_003E8__locals13._003C_003E4__this;
											float num9 = CS_0024_003C_003E8__locals13.weapon.PDuration();
											Action onComplete2 = CS_0024_003C_003E8__locals13._003C_003E9__1;
											if (CS_0024_003C_003E8__locals13._003C_003E9__1 == null)
											{
												onComplete2 = (CS_0024_003C_003E8__locals13._003C_003E9__1 = delegate
												{
													CS_0024_003C_003E8__locals13._003C_003E4__this.StartDespawn();
												});
											}
											object obj7 = default(object);
											float duration = (float)obj7 * 0.001f;
											bool useRealTime = default(bool);
											MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
											int repeat = default(int);
											TimerType type = default(TimerType);
											Timer expireTimer = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
											tP_Acid2_Projectile2._expireTimer = expireTimer;
										};
										tweenConfig.onComplete = onComplete;
										MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
										_scaleTween = scaleTween;
										if (index == 0)
										{
											SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
											{
												Rate = 1f,
												Volume = (float?)(object)1
											};
											object obj5 = UnityEngine.Random.value;
											object obj6 = default(object);
											float num7 = (float)obj6 - 0.5f;
											float num8 = num7 * 300f;
											((Group)(object)soundConfig).childrenToRemove = (HashSet<PhaserGameObject>)num8;
											float time = default(float);
											PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_AcidicBubbles2, soundConfig, 200f, 3, time);
										}
										return;
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

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			int penetrating = _penetrating - 1;
			_penetrating = penetrating;
		}
	}

	private void StartDespawn()
	{
		//IL_003f: Expected I, but got O
		//IL_00a3: Expected O, but got I4
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
			tweenConfig.duration = 300f;
			tweenConfig.scale = (float?)(object)1;
			TweenCallback onComplete = delegate
			{
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
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}

	private void _003CStartDespawn_003Eb__9_0()
	{
		Despawn();
	}
}
