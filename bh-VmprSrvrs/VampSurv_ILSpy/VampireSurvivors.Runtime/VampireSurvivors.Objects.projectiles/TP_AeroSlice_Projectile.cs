using System;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_AeroSlice_Projectile : Projectile
{
	private float _radius = 16f;

	private PhaserSprite _animatedSprite;

	protected override void Awake()
	{
		//IL_00d8: Expected O, but got I4
		//IL_00d8: Expected I4, but got O
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_AeroSlice01");
		_animatedSprite = animatedSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_AeroSlice", 1, 3, vector, text, num, flag);
		PhaserSprite animatedSprite2 = _animatedSprite;
		bool autoSetAnimation = default(bool);
		animatedSprite2._spriteAnimation.AddAnimation("loop", animationFrames, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite animatedSprite3 = _animatedSprite;
		animatedSprite3._spriteAnimation.SetAnimation("loop");
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0188: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_0046: Expected O, but got I4
		//IL_019a: Expected O, but got F4
		//IL_0077: Invalid comparison between F4 and I4
		//IL_00b6: Expected O, but got I4
		//IL_0108: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_speed = 1.65f;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		float num = _weapon.PArea();
		float num2 = default(float);
		float radius = num2 * _radius;
		BaseBody baseBody = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
		object obj = UnityEngine.Random.value;
		bool flag = num2 < 0.5f;
		float num3 = num2 - 0.5f;
		bool flag2 = num3 == 0f;
		BlendMode blendMode = ((flag | flag2) ? BlendMode.Add : BlendMode.Normal);
		PhaserSprite phaserSprite = _animatedSprite.setBlendMode(blendMode);
		PhaserSprite phaserSprite2 = _animatedSprite.setScale(num2, (float?)(object)0);
		PhaserSprite phaserSprite3 = _animatedSprite.setAlpha(0.85f);
		PhaserSprite phaserSprite4 = _animatedSprite.setVisible(visible: true);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float detune = (float)_indexInWeapon * 100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.FireExplosion, soundConfig, 150f, 3, time);
	}
}
