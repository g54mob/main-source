using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Light2_Projectile : TP_Light1_Projectile
{
	public override float BodyRadius => 16f;

	public override float Scale => 1f;

	public override bool HasOrbiters => true;

	public override int InvertMotion => 1;

	protected override void InitAlpha()
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
		float alpha = num2 * 0.65f;
		PhaserSprite phaserSprite = _glowSprite.setAlpha(alpha);
		if (!(0.7f < num2))
		{
			ArcadeSprite arcadeSprite2 = setDepth(0);
		}
		TP_Light1_Weapon trueWeapon = _trueWeapon;
		trueWeapon._003CProjScaledAlpha_003Ek__BackingField = num2;
	}

	public override void MakeSpriteAnimation()
	{
		GameObject gameObject = _renderer.gameObject;
		SpriteAnimation spriteAnimator = gameObject.AddComponent<SpriteAnimation>();
		_spriteAnimator = spriteAnimator;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Lumos", 13, 24, "ThosePeople", num);
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

	protected override void PlayFiringSfx()
	{
		//IL_004b: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * 100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_MagicMissile1, soundConfig, 50f, 1, time);
	}

	public TP_Light2_Projectile()
	{
		base._flipNum = 1f;
		((Projectile)this)._002Ector();
	}
}
