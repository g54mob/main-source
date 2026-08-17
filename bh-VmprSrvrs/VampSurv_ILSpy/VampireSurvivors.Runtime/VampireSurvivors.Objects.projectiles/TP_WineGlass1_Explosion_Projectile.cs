using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
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

public class TP_WineGlass1_Explosion_Projectile : Projectile
{
	private MultiTargetTween _scaleTween;

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
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Lightning14");
		_animatedSprite = animatedSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Lightning", 14, 20, vector, text, num, flag);
		PhaserSprite animatedSprite2 = _animatedSprite;
		bool autoSetAnimation = default(bool);
		animatedSprite2._spriteAnimation.AddAnimation("explode", animationFrames, 60, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite phaserSprite = _animatedSprite.setTintFill(isEnabled: true, 16777215u);
		PhaserSprite phaserSprite2 = _animatedSprite.setAlpha(0.25f);
		PhaserSprite phaserSprite3 = _animatedSprite.setVisible(visible: false);
		_animatedSprite.angle = 90f;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0023: Expected O, but got I4
		//IL_0023: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		//IL_00b6: Expected O, but got I4
		//IL_0121: Expected I, but got O
		//IL_0185: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body.setCircle(18f, (float?)(object)1, (float?)(object)1);
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag = !config._003CFlashingVFXEnabled_003Ek__BackingField;
		float? num = (float?)(object)1;
		if (!flag)
		{
			PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: true);
			PhaserSprite animatedSprite = _animatedSprite;
			animatedSprite._spriteAnimation.SetAnimation("explode");
			num = (float?)(object)0;
		}
		float num2 = weapon.PArea();
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num3 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
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
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__3_0()
	{
		Despawn();
	}
}
