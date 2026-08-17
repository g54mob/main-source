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
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Aura_Projectile : Projectile
{
	private float _radius = 16f;

	private PhaserSprite _animatedSprite;

	private Tween _radiusTween;

	private MultiTargetTween _scaleTween;

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
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Aurablast01");
		_animatedSprite = animatedSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Aurablast", 1, 2, vector, text, num, flag);
		PhaserSprite animatedSprite2 = _animatedSprite;
		bool autoSetAnimation = default(bool);
		animatedSprite2._spriteAnimation.AddAnimation("loop", animationFrames, 16, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite animatedSprite3 = _animatedSprite;
		animatedSprite3._spriteAnimation.SetAnimation("loop");
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0289: Expected O, but got I4
		//IL_0036: Expected O, but got I4
		//IL_0036: Expected O, but got I4
		//IL_029b: Expected O, but got F4
		//IL_0048: Invalid comparison between O and F4
		//IL_0067: Invalid comparison between F4 and I4
		//IL_00a7: Expected O, but got I4
		//IL_0107: Expected O, but got I4
		//IL_01a4: Expected I, but got O
		//IL_0212: Expected O, but got I4
		//IL_022d: Expected I, but got O
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(0.5f, (float?)(object)0);
		float num = _weapon.PArea();
		BaseBody baseBody = body.setCircle(_radius, (float?)(object)1, (float?)(object)1);
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f);
		float num2 = (float)obj2 - 0.5f;
		bool flag2 = num2 == 0f;
		BlendMode blendMode = ((flag | flag2) ? BlendMode.Add : BlendMode.Normal);
		PhaserSprite phaserSprite = _animatedSprite.setBlendMode(blendMode);
		PhaserSprite phaserSprite2 = _animatedSprite.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite3 = _animatedSprite.setAlpha(0.65f);
		PhaserSprite phaserSprite4 = _animatedSprite.setVisible(visible: true);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * 100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Aurablast, soundConfig, 200f, 3, time);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num3 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj3 = default(object);
		bool flag3 = obj3 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 300f;
		tweenConfig.yoyo = true;
		tweenConfig.scale = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v540 @ r8_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Aura_Projectile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num4 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
	}

	private void StartDespawn()
	{
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		Despawn();
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

	public override void Despawn()
	{
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		if (_radiusTween != null)
		{
			TweenExtensions.Kill(_radiusTween);
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}
}
