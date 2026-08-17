using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_SonicBloomProjectile : Projectile
{
	private MultiTargetTween _scaleTween;

	private MultiTargetTween _fadeTween;

	private SpriteAnimation _anim;

	private bool _isFadingOut;

	protected override void Awake()
	{
		//IL_00db: Expected O, but got I4
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Ring Laser-F1", "firstBlood");
		float2 originalSize = default(float2);
		ArcadeSprite arcadeSprite = setFrameIncludingOriginalSize(sprite, originalSize);
		CheckRenderer();
		GameObject gameObject = ((ArcadeSprite)this)._spriteRenderer.gameObject;
		SpriteAnimation anim = gameObject.AddComponent<SpriteAnimation>();
		_anim = anim;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Ring Laser-F", 1, 5, "firstBlood", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_anim.AddAnimation("idle", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		SpriteAnimation anim2 = _anim;
		anim2._originalSpriteSize = (float2)1108869120;
		_ = 1108869120;
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_03c4: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_008e: Expected I, but got O
		//IL_00b7: Expected O, but got I4
		//IL_0071: Expected O, but got Ref
		//IL_0084: Expected O, but got I4
		//IL_0102: Expected I, but got O
		//IL_0161: Expected I, but got O
		//IL_016a: Expected O, but got I4
		//IL_0192: Expected O, but got I4
		//IL_01a9: Expected I, but got O
		//IL_01dd: Expected O, but got I4
		//IL_0257: Expected I, but got O
		//IL_02ad: Expected O, but got I4
		//IL_02e9: Expected I, but got O
		//IL_0355: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		_isFadingOut = false;
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		_isCullable = false;
		ArcadeSprite arcadeSprite2 = setTint(16777215u);
		ArcadeSprite arcadeSprite3 = setAlpha(1f);
		BaseBody baseBody = body.setCircle(26f, (float?)(object)1, (float?)(object)1);
		if (!weapon.IsHoming)
		{
			object obj = default(object);
			ApplyPlayerFacingVelocity((Vector3)(&obj));
			bool flag = true;
			float? num = (float?)(object)0;
		}
		else
		{
			nint num2 = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rax_v86 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_SonicBloomProjectile>)+3B0]");
			bool flag = false;
			Transform transform = base.AimForNearestEnemy();
			float? num = (float?)(object)1;
		}
		float2 float5 = base.position;
		float num3 = 3.2359055E+09f + 0.244f;
		float2 float6 = default(float2);
		base.position = float6;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		_scaleTween = null;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num4 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			Weapon weapon2 = _weapon;
			nint num5 = (nint)weapon2;
			object obj3 = 1000;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v709 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+v225 @ r14_v6] (should have been resolved before IL gen)");
			float duration = (float)float6 * 0.5f;
			tweenConfig.scaleX = (float?)(object)1;
			Weapon weapon3 = _weapon;
			nint num6 = (nint)weapon3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v714 @ rdx_v20 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+v225 @ r14_v6] (should have been resolved before IL gen)");
			tweenConfig.duration = 500f;
			tweenConfig.ease = Ease.OutCubic;
			tweenConfig.scaleY = (float?)(object)1;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			if (_fadeTween != null)
			{
				_fadeTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			nint num7 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				tweenConfig2.targets = array2;
				tweenConfig2.alpha = (float?)(object)1;
				float num8 = _weapon.PDuration();
				tweenConfig2.duration = duration;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v887 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_SonicBloomProjectile>)+370]");
				TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
				nint num9 = (nint)this;
				tweenConfig2.onComplete = onComplete;
				MultiTargetTween fadeTween = Tweens.Add(tweenConfig2);
				_fadeTween = fadeTween;
				float? volume = default(float?);
				float rate = default(float);
				float detune = default(float);
				bool loop = default(bool);
				PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.ExploSoft, 100f, 10, 0f, volume, rate, detune, loop, 1f);
				_anim.Play("idle", 16);
				int num10 = 1000 - _indexInWeapon;
				ArcadeSprite arcadeSprite4 = setDepth(num10);
				return;
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private void FadeOut()
	{
		//IL_0069: Expected I, but got O
		//IL_00cd: Expected O, but got I4
		//IL_00e8: Expected I, but got O
		if (!_isFadingOut)
		{
			_isFadingOut = true;
			if (_fadeTween != null)
			{
				_fadeTween.Kill();
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
			tweenConfig.duration = 100f;
			tweenConfig.alpha = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_SonicBloomProjectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween fadeTween = Tweens.Add(tweenConfig);
			_fadeTween = fadeTween;
		}
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		_isFadingOut = true;
		if (baseBody._enable)
		{
			if (_scaleTween != null)
			{
				_scaleTween.Kill();
			}
			_scaleTween = null;
			if (_fadeTween != null)
			{
				_fadeTween.Kill();
			}
			_fadeTween = null;
			base.Despawn();
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_0096: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (_bounces <= 0)
		{
			if (--_penetrating <= 0)
			{
				FadeOut();
			}
		}
		else
		{
			nint num = (nint)this;
			int bounces = _bounces - 1;
			_bounces = bounces;
			Transform transform = base.AimForRandomEnemy();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}
}
