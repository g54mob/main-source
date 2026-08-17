using System;
using System.Collections.Generic;
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
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_GothMissile_Projectile : Projectile
{
	private float _radius = 12f;

	private PhaserSprite _animatedSprite;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private Vector2 _direction;

	protected override void Awake()
	{
		//IL_0163: Expected O, but got I4
		//IL_0163: Expected I4, but got O
		//IL_0207: Expected O, but got I4
		//IL_0207: Expected I4, but got O
		//IL_037c->IL030b: Incompatible stack heights: 1 vs 0
		//IL_02c3->IL030b: Incompatible stack heights: 1 vs 0
		//IL_02f1->IL030b: Incompatible stack heights: 1 vs 0
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_MagicMissile61", "ThosePeople");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				GameObject gameObject = base.gameObject;
				Vector2 vector = default(Vector2);
				PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_MagicMissile01");
				_animatedSprite = animatedSprite;
				string text = default(string);
				int num = default(int);
				bool flag = default(bool);
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_MagicMissile", 1, 28, vector, text, num, flag);
				PhaserSprite animatedSprite2 = _animatedSprite;
				if ((object)_animatedSprite != null)
				{
					Action action = OnShotFired;
					if ((object)animatedSprite2._spriteAnimation != null)
					{
						bool autoSetAnimation = default(bool);
						animatedSprite2._spriteAnimation.AddAnimation("shoot", animationFrames, 24, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
						List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_VFX_MagicMissile", 29, 53, vector, text, num, flag);
						PhaserSprite animatedSprite3 = _animatedSprite;
						if ((object)_animatedSprite != null && (object)animatedSprite3._spriteAnimation != null)
						{
							animatedSprite3._spriteAnimation.AddAnimation("afterShot", animationFrames2, 24, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
							if ((object)_animatedSprite != null)
							{
								Transform transform = _animatedSprite.transform;
								if ((object)transform != null)
								{
									bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									nint num2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v666 @ rcx_v30 (Il2CppMethodInfo)+38]");
									if ((nint)0 == 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
									}
									Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
									PhaserSprite animatedSprite4 = _animatedSprite;
									if ((object)_animatedSprite != null)
									{
										SpriteAnimation spriteAnimation = animatedSprite4._spriteAnimation;
										if ((object)animatedSprite4._spriteAnimation != null)
										{
											((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
											if ((object)_animatedSprite != null)
											{
												PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
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
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0023: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_00f4: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_speed = 3f;
		_isCullable = false;
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		BaseBody baseBody = body;
		baseBody._enable = false;
		ArcadeSprite arcadeSprite2 = setScale(1f, (float?)(object)0);
		BaseBody baseBody2 = body.setCircle(_radius, (float?)(object)0, (float?)(object)0);
		_animatedSprite.angle = 0f;
		float2 float5 = base.position;
		PhaserSprite phaserSprite = _animatedSprite.setPosition(float5);
		PhaserSprite phaserSprite2 = _animatedSprite.setAlpha(0.85f);
		PhaserSprite phaserSprite3 = _animatedSprite.setVisible(visible: true);
		PhaserSprite animatedSprite = _animatedSprite;
		animatedSprite._spriteAnimation.SetAnimation("shoot");
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float detune = (float)_indexInWeapon * 100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_MagicCharge, soundConfig, 150f, 3, time);
	}

	public void SetDirection(Vector2 dir)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		bool flag = 0 < (nint)dir;
		object obj = 0 - dir;
		bool flag2 = obj == null;
		_direction = dir;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		ArcadeSprite arcadeSprite = setFlipX(flag5);
		bool flag6 = 0 < (nint)dir;
		object obj2 = 0 - dir;
		bool flag7 = obj2 == null;
		bool flag8 = !flag6;
		bool flag9 = !flag7;
		bool flag10 = flag9 & flag8;
		PhaserSprite phaserSprite = _animatedSprite.setFlipX(flag10);
	}

	private void OnShotFired()
	{
		//IL_02dd: Expected O, but got I4
		//IL_02f9: Expected O, but got F4
		//IL_00d1: Expected I, but got O
		//IL_0140: Expected O, but got I4
		//IL_01d9: Expected I, but got O
		//IL_0247: Expected O, but got I4
		//IL_02c5: Expected O, but got I4
		//IL_01fc->IL01fc: Incompatible stack heights: 2 vs 1
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		float num2 = num * 200f;
		float detune = num2 * (float)_indexInWeapon;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_MagicShot, soundConfig, 150f, 10, time);
		PhaserSprite animatedSprite = _animatedSprite;
		animatedSprite._spriteAnimation.SetAnimation("afterShot");
		ArcadeSprite arcadeSprite = setVisible(visible: true);
		BaseBody baseBody = body;
		baseBody._enable = true;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num3 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj3 = default(object);
		bool flag = obj3 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		float num4 = _weapon.PArea();
		tweenConfig.duration = 200f;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_animatedSprite != null)
		{
			nint num5 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			bool flag2 = obj4 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.delay = 750f;
		tweenConfig2.duration = 200f;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			_isCullable = true;
		};
		tweenConfig2.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig2);
		_alphaTween = alphaTween;
		float projectileSpeed = base.ProjectileSpeed;
		float projectileSpeed2 = base.ProjectileSpeed;
		float xVel = (float)_direction * 0f;
		setVelocity(xVel, (float?)(object)1);
	}

	public override void Despawn()
	{
		//IL_006e: Expected O, but got I4
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		ArcadeSprite arcadeSprite2 = setVisible(visible: false);
		BaseBody baseBody = body;
		baseBody._enable = false;
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		base.Despawn();
	}

	private void _003COnShotFired_003Eb__8_0()
	{
		_isCullable = true;
	}
}
