using System;
using System.Collections.Generic;
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
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Fire1_Projectile : Projectile
{
	private float _radius = 16f;

	private PhaserSprite _animatedSprite;

	private Tween _radiusTween;

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
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Fire01");
		_animatedSprite = animatedSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Fire", 1, 16, vector, text, num, flag);
		PhaserSprite animatedSprite2 = _animatedSprite;
		bool autoSetAnimation = default(bool);
		animatedSprite2._spriteAnimation.AddAnimation("explode", animationFrames, 32, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_02fa: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_030c: Expected O, but got F4
		//IL_01b9: Invalid comparison between F4 and I4
		//IL_01f8: Expected O, but got I4
		//IL_0285: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(1f, (float?)(object)1, (float?)(object)1);
		float num = _weapon.PArea();
		Tween radiusTween = _radiusTween;
		float num2 = default(float);
		float endValue = num2 * _radius;
		if (_radiusTween != null && radiusTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_radiusTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((TP_Fire1_Projectile)(object)dOSetter)._003CInitProjectile_003Eb__4_1(1f);
		TweenerCore<float, float, FloatOptions> radiusTween2 = DOTween.To(getter, dOSetter, endValue, 0.5f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TweenCallback tweenCallback = StartDespawn;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rax_v19 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 != 0)
		{
		}
		_radiusTween = radiusTween2;
		object obj = UnityEngine.Random.value;
		bool flag = num2 < 0.5f;
		float num3 = num2 - 0.5f;
		bool flag2 = num3 == 0f;
		BlendMode blendMode = ((flag | flag2) ? BlendMode.Add : BlendMode.Normal);
		PhaserSprite phaserSprite = _animatedSprite.setBlendMode(blendMode);
		PhaserSprite phaserSprite2 = _animatedSprite.setScale(num2, (float?)(object)0);
		PhaserSprite phaserSprite3 = _animatedSprite.setAlpha(0.65f);
		PhaserSprite phaserSprite4 = _animatedSprite.setVisible(visible: true);
		PhaserSprite animatedSprite = _animatedSprite;
		animatedSprite._spriteAnimation.SetAnimation("explode");
		PhaserSprite phaserSprite5 = _animatedSprite.setDepth(2);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float detune = (float)_indexInWeapon * 50f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_RagingFire, soundConfig, 200f, 5, time);
	}

	private void StartDespawn()
	{
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		Despawn();
	}

	public override void Despawn()
	{
		if (_radiusTween != null)
		{
			TweenExtensions.Kill(_radiusTween);
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
	}

	private float _003CInitProjectile_003Eb__4_0()
	{
		BaseBody baseBody = body;
		return baseBody._radius;
	}

	private void _003CInitProjectile_003Eb__4_1(float r)
	{
		//IL_001f: Expected O, but got I4
		//IL_001f: Expected O, but got I4
		BaseBody baseBody = body.setCircle(r, (float?)(object)1, (float?)(object)1);
	}
}
