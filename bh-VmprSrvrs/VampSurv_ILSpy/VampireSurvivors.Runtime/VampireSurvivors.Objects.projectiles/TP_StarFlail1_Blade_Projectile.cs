using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_StarFlail1_Blade_Projectile : Projectile
{
	private MultiTargetTween _posTween;

	private SpriteAnimation _anim;

	private MultiTargetTween _rotTween;

	private MultiTargetTween _despawnTween;

	private MultiTargetTween _scaleTween;

	protected override void Awake()
	{
		//IL_0113: Expected I, but got O
		//IL_016d: Expected I4, but got I8
		//IL_0189: Expected O, but got I4
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_DeltaSpark01", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		CheckRenderer();
		GameObject gameObject = ((ArcadeSprite)this)._spriteRenderer.gameObject;
		SpriteAnimation anim = gameObject.AddComponent<SpriteAnimation>();
		_anim = anim;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_DeltaSpark0", 0, 3, "ThosePeople", num);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_anim.AddAnimation("idle", animationFrames, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		if (_rotTween != null)
		{
			_rotTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num2 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.repeat = -1;
			tweenConfig.duration = 1000f;
			tweenConfig.angle = (float?)(object)1;
			MultiTargetTween rotTween = Tweens.Add(tweenConfig);
			_rotTween = rotTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0187: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_00ba: Expected I, but got O
		//IL_012d: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_isCullable = true;
		_speed = 1.5f;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(20f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setScale(0.5f, (float?)(object)0);
		_anim.SetAnimation("idle");
		ArcadeSprite arcadeSprite3 = setAlpha(0.65f);
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
			float num2 = _weapon.PArea();
			tweenConfig.duration = 150f;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public void ManualIntProjectile(float flyAngle, bool isFlipped)
	{
		//IL_000d: Expected I, but got O
		//IL_0062: Expected O, but got I4
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00f5: Expected I, but got O
		//IL_0155: Expected O, but got I4
		//IL_0181: Expected O, but got I4
		ArcadeSprite arcadeSprite = setFlipX(isFlipped);
		Weapon weapon = _weapon;
		nint num = (nint)weapon;
		float num2 = weapon.PSpeed();
		object obj = default(object);
		float num3 = (float)obj * 0.29999998f;
		float num4 = num3 * _speed;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		object obj2 = (isFlipped ? 1 : 0) ^ 1;
		float num5 = flyAngle * num4;
		object obj3 = obj2 * 2;
		object obj4 = obj3 - 1;
		float num6 = num5 * (float)obj4;
		if (_posTween != null)
		{
			_posTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num7 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj5 = default(object);
		if (obj5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			float2 float5 = base.position;
			tweenConfig.x = (float?)(object)1;
			float2 float6 = base.position;
			object obj6 = default(object);
			float num8 = (float)obj6 + num6;
			tweenConfig.y = (float?)(object)1;
			float num9 = _weapon.PDuration();
			float duration = num8 * 0.5f;
			tweenConfig.duration = duration;
			TweenCallback onComplete = FadeOut;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween posTween = Tweens.Add(tweenConfig);
			_posTween = posTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public void FadeOut()
	{
		//IL_003f: Expected I, but got O
		//IL_0095: Expected O, but got I4
		//IL_00a3: Expected O, but got I4
		//IL_00ef: Expected I, but got O
		if (_despawnTween != null)
		{
			_despawnTween.Kill();
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
			tweenConfig.alpha = (float?)(object)1;
			tweenConfig.scale = (float?)(object)1;
			float num2 = _weapon.PDuration();
			object obj2 = default(object);
			float duration = (float)obj2 * 0.5f;
			tweenConfig.duration = duration;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_StarFlail1_Blade_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num3 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween despawnTween = Tweens.Add(tweenConfig);
			_despawnTween = despawnTween;
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
		if (_posTween != null)
		{
			_posTween.Kill();
		}
		if (_despawnTween != null)
		{
			_despawnTween.Kill();
		}
		base.Despawn();
	}
}
