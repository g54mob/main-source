using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_WaveProjectile : Projectile
{
	private SpriteRenderer _SpriteRenderer;

	private SpriteTrail _Trail;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _fadeTween;

	private PhaserSprite _sonicSprite;

	private SpriteAnimation _spriteAnim;

	private bool _isFadingOut;

	public bool IsCharged;

	protected override void Awake()
	{
		//IL_0108: Expected O, but got I4
		//IL_0128: Expected O, but got I4
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("SoundWaves05", "vfx");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		float2 float5 = base.position;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite sonicSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "firstBlood", "Ring Laser-F1");
		_sonicSprite = sonicSprite;
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Ring Laser-F", 1, 5, "firstBlood", num);
		PhaserSprite sonicSprite2 = _sonicSprite;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		sonicSprite2._spriteAnimation.AddAnimation("idle", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite sonicSprite3 = _sonicSprite;
		SpriteAnimation spriteAnimation = sonicSprite3._spriteAnimation;
		spriteAnimation._originalSpriteSize = (float2)1108869120;
		_ = 1108869120;
		PhaserSprite phaserSprite = _sonicSprite.setScale(0.5f, (float?)(object)1);
		SpriteTrail spriteTrail = _Trail.setVisible(b: false);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_016f: Expected O, but got I4
		//IL_016f: Expected O, but got I4
		//IL_020d: Expected I, but got O
		//IL_0272: Expected O, but got I4
		//IL_02b0: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_Trail.InitialiseGhosts();
		_Trail.Reset();
		SpriteTrail spriteTrail = _Trail.setVisible(b: false);
		IsCharged = false;
		PhaserSprite phaserSprite = _sonicSprite.setTint(65535u);
		SpriteAnimation spriteAnim = _spriteAnim;
		if ((object)_spriteAnim == null || ((UnityEngine.Object)spriteAnim).m_CachedPtr == (IntPtr)0)
		{
			CheckRenderer();
			GameObject gameObject = ((ArcadeSprite)this)._spriteRenderer.gameObject;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v323 @ rdi_v9 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			SpriteAnimation spriteAnim2 = ((!gameObject.TryGetComponent<SpriteAnimation>(out var component)) ? gameObject.AddComponent<SpriteAnimation>() : component);
			_spriteAnim = spriteAnim2;
		}
		BaseBody baseBody = body.setCircle(64f, (float?)(object)1, (float?)(object)1);
		_isFadingOut = false;
		ArcadeSprite arcadeSprite = setAlpha(1f);
		SetScaleToArea(0.5f);
		_isCullable = false;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		_scaleTween = null;
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num2 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			float num3 = _weapon.PArea();
			tweenConfig.scaleX = (float?)(object)1;
			float num4 = _weapon.PArea();
			tweenConfig.duration = 3600f;
			tweenConfig.ease = Ease.OutCubic;
			tweenConfig.scaleY = (float?)(object)1;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public void MakeBasicProjectile()
	{
		//IL_0139: Expected O, but got I4
		//IL_0139: Expected O, but got I4
		_Trail.Reset();
		SpriteTrail spriteTrail = _Trail.setVisible(b: false);
		Weapon weapon = _weapon;
		WeaponData currentWeaponData = weapon._currentWeaponData;
		_penetrating = currentWeaponData._003Cpenetrating_003Ek__BackingField;
		IsCharged = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		ArcadeSprite arcadeSprite = setFrame(sprite);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @187074010");
		object obj = default(object);
		if (obj == null)
		{
			int num = default(int);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Wave Beam-WaveBeam_0", 1, 3, "firstBlood", num);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			_spriteAnim.AddAnimation("Basic", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		}
		_spriteAnim.SetAnimation("Basic");
		BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		PhaserSprite phaserSprite = _sonicSprite.setVisible(visible: true);
	}

	public void MakeChargedProjectile()
	{
		//IL_0147: Expected O, but got I4
		//IL_0147: Expected O, but got I4
		_Trail.Reset();
		SpriteTrail spriteTrail = _Trail.setVisible(b: true);
		Weapon weapon = _weapon;
		WeaponData currentWeaponData = weapon._currentWeaponData;
		int penetrating = currentWeaponData._003Cpenetrating_003Ek__BackingField + 10;
		IsCharged = true;
		_penetrating = penetrating;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		ArcadeSprite arcadeSprite = setFrame(sprite);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @187074010");
		object obj = default(object);
		if (obj == null)
		{
			int num = default(int);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Wave Beam Alt-WaveBeamAlt_0", 1, 4, "firstBlood", num);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			_spriteAnim.AddAnimation("Charged", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		}
		_spriteAnim.SetAnimation("Charged");
		BaseBody baseBody = body.setCircle(32f, (float?)(object)1, (float?)(object)1);
		PhaserSprite phaserSprite = _sonicSprite.setVisible(visible: false);
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		OnHasHitAnObjectLogic(other, triggerHit: true);
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		//IL_0056: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _bounces > 0)
		{
			nint num = (nint)this;
			int bounces = _bounces - 1;
			_bounces = bounces;
			Transform transform = base.AimForRandomEnemy();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	protected void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
	{
		//IL_00af: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (_bounces <= 0)
		{
			if (triggerHit && --_penetrating <= 0)
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

	public override void InternalUpdate()
	{
		//IL_0102: Invalid comparison between I4 and F4
		//IL_009b->IL008f: Incompatible stack heights: 1 vs 0
		//IL_006c->IL006c: Incompatible stack heights: 1 vs 0
		if (!_isFadingOut)
		{
			CheckRenderer();
			object spriteRenderer = ((ArcadeSprite)this)._spriteRenderer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v4 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdi_v4 (System.Object)+10]");
			SpriteRenderer.get_color_Injected((IntPtr)0, out Color _);
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 0.5f;
			object obj = default(object);
			float num2 = (float)obj - num;
			if (0f > num2)
			{
				Despawn();
				return;
			}
			ArcadeSprite arcadeSprite = setAlpha(num2);
			PhaserSprite phaserSprite = _sonicSprite.setAlpha(num2);
		}
		int num3 = 1000 - _indexInWeapon;
		ArcadeSprite arcadeSprite2 = setDepth(num3);
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
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
			SpriteTrail spriteTrail = _Trail.setVisible(b: false);
			base.Despawn();
		}
	}

	private void FadeOut()
	{
		//IL_0069: Expected I, but got O
		//IL_00c1: Expected I, but got O
		//IL_0125: Expected O, but got I4
		//IL_0140: Expected I, but got O
		if (_isFadingOut)
		{
			return;
		}
		_isFadingOut = true;
		if (_fadeTween != null)
		{
			_fadeTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)_sonicSprite != null)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.alpha = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_WaveProjectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num3 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween fadeTween = Tweens.Add(tweenConfig);
			_fadeTween = fadeTween;
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}
}
