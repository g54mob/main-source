using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EME_KnifeProjectile_Special_MoonfallSlash : Projectile
{
	private SpriteAnimation _SpriteAnimation;

	private MultiTargetTween _alphaTween;

	protected override void Awake()
	{
		base.Awake();
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("eme_vfx_moonfall_", 1, 16, "Emeralds_VFX", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_SpriteAnimation.AddAnimation("Slash", animationFrames, 48, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		ArcadeSprite arcadeSprite = setAlpha(0f);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0057: Expected O, but got I4
		//IL_015e: Expected I4, but got I8
		//IL_01d7: Expected I, but got O
		//IL_0249: Expected O, but got I4
		//IL_0264: Expected I, but got O
		//IL_032f: Expected O, but got F4
		//IL_035a: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body.setCircle(24f, (float?)(object)0, (float?)(object)0);
		float num = _weapon.PArea();
		object obj = default(object);
		float num2 = (float)obj * 1.5f;
		ArcadeSprite arcadeSprite = setScale(num2, (float?)(object)0);
		float num3 = _weapon.PArea();
		float alpha;
		float num4;
		if (num2 > 2.8f)
		{
			bool flag = !(1f < num2);
			alpha = 1f;
			num4 = num2;
			if (!flag)
			{
				if (num2 < 7f)
				{
					float num5 = num2 - 1f;
					float num6 = num5 * 0.65f;
					num4 = num6 / 6f;
					alpha = 1f - num4;
				}
				else
				{
					alpha = 0.35f;
					num4 = num2;
				}
			}
		}
		else
		{
			alpha = 0.85f;
			num4 = num2;
		}
		bool flag2 = 2.8f > num2;
		int num7 = 2;
		if (!flag2)
		{
			num7 = -1998;
		}
		ArcadeSprite arcadeSprite2 = setDepth(num7);
		ArcadeSprite arcadeSprite3 = setAlpha(alpha);
		_SpriteAnimation.SetAnimation("Slash");
		_isCullable = false;
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num8 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.delay = 250f;
			tweenConfig.duration = 100f;
			tweenConfig.alpha = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_KnifeProjectile_Special_MoonfallSlash>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num9 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
			_alphaTween = alphaTween;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			object obj3 = UnityEngine.Random.value;
			float detune = num4 * -1000f;
			soundConfig.Detune = detune;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Sfx_eme_moonfall, soundConfig, 100f, 2, time);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}
}
