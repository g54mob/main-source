using System;
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

public class TP_AuraBig_Projectile : Projectile
{
	private float _radius = 48f;

	private Tween _radiusTween;

	private MultiTargetTween _scaleTween;

	private PhaserSprite _animatedSprite;

	private PhaserSprite _animatedSprite2;

	private PhaserSprite _animatedSprite3;

	private MultiTargetTween _enterTween;

	private MultiTargetTween _alphaTween;

	private MultiTargetTween _alphaTween2;

	private MultiTargetTween _alphaTween3;

	protected override void Awake()
	{
		//IL_007e: Expected O, but got I4
		//IL_00c9: Expected O, but got I4
		//IL_0114: Expected O, but got I4
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "ThosePeople", "TP_VFX_Aurablast00");
		PhaserSprite animatedSprite = phaserSprite.setOrigin(0.5f, (float?)(object)1);
		_animatedSprite = animatedSprite;
		GameObject gameObject2 = base.gameObject;
		PhaserSprite phaserSprite2 = RenderingExtensions.AddPhaserSprite(gameObject2, pos, "ThosePeople", "TP_VFX_Aurablast00");
		PhaserSprite animatedSprite2 = phaserSprite2.setOrigin(0.5f, (float?)(object)1);
		_animatedSprite2 = animatedSprite2;
		GameObject gameObject3 = base.gameObject;
		PhaserSprite phaserSprite3 = RenderingExtensions.AddPhaserSprite(gameObject3, pos, "ThosePeople", "TP_VFX_Aurablast00");
		PhaserSprite animatedSprite3 = phaserSprite3.setOrigin(0.5f, (float?)(object)1);
		_animatedSprite3 = animatedSprite3;
		PhaserSprite phaserSprite4 = _animatedSprite2.setFlipX(flipX: true);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0831: Expected O, but got I4
		//IL_0035: Expected O, but got I4
		//IL_0035: Expected O, but got I4
		//IL_006c: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		//IL_013e: Expected O, but got I4
		//IL_0265: Expected O, but got I4
		//IL_02c5: Expected O, but got I4
		//IL_034c: Expected I, but got O
		//IL_03b0: Expected O, but got I4
		//IL_0449: Expected I, but got O
		//IL_049f: Expected O, but got I4
		//IL_04d7: Expected O, but got I4
		//IL_05e8: Expected I, but got O
		//IL_063e: Expected O, but got I4
		//IL_0676: Expected O, but got I4
		//IL_0737: Expected I, but got O
		//IL_078d: Expected O, but got I4
		//IL_07c5: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setScale(0.5f, (float?)(object)0);
		float num = _weapon.PArea();
		BaseBody baseBody = body.setCircle(_radius, (float?)(object)1, (float?)(object)1);
		PhaserSprite phaserSprite = _animatedSprite.setBlendMode(BlendMode.Normal);
		PhaserSprite phaserSprite2 = _animatedSprite.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite3 = _animatedSprite.setAlpha(0.65f);
		PhaserSprite phaserSprite4 = _animatedSprite.setVisible(visible: true);
		PhaserSprite phaserSprite5 = _animatedSprite2.setBlendMode(BlendMode.Add);
		PhaserSprite phaserSprite6 = _animatedSprite2.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite7 = _animatedSprite2.setAlpha(0.35f);
		PhaserSprite phaserSprite8 = _animatedSprite2.setVisible(visible: true);
		PhaserSprite phaserSprite9 = _animatedSprite3.setBlendMode(BlendMode.Normal);
		PhaserSprite phaserSprite10 = _animatedSprite3.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite11 = _animatedSprite3.setAlpha(0.35f);
		PhaserSprite phaserSprite12 = _animatedSprite3.setVisible(visible: true);
		Weapon weapon2 = _weapon;
		int num2 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.depth;
		PhaserSprite phaserSprite13 = _animatedSprite.setDepth(num2);
		Weapon weapon3 = _weapon;
		int num3 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.depth;
		int num4 = num3 + 1;
		PhaserSprite phaserSprite14 = _animatedSprite2.setDepth(num4);
		Weapon weapon4 = _weapon;
		int num5 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.depth;
		int num6 = num5 + 1;
		PhaserSprite phaserSprite15 = _animatedSprite3.setDepth(num6);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * 100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Aurablast, soundConfig, 200f, 3, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.TP_sfx_Hellfire1, soundConfig2, 200f, 3, time);
		if (_enterTween != null)
		{
			_enterTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num7 = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 300f;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween enterTween = Tweens.Add(tweenConfig);
			_enterTween = enterTween;
			if (_alphaTween != null)
			{
				_alphaTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			if ((object)_animatedSprite != null)
			{
				nint num8 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj2 = default(object);
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.scale = (float?)(object)1;
			tweenConfig2.duration = 300f;
			tweenConfig2.yoyo = true;
			tweenConfig2.repeat = 4;
			tweenConfig2.alpha = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				//IL_0015: Expected O, but got I4
				PhaserSprite phaserSprite16 = _animatedSprite.setScale(1f, (float?)(object)0);
				PhaserSprite phaserSprite17 = _animatedSprite.setAlpha(0.65f);
			};
			tweenConfig2.onStart = onStart;
			TweenCallback onRepeat = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			};
			tweenConfig2.onRepeat = onRepeat;
			TweenCallback onComplete = StartDespawn;
			tweenConfig2.onComplete = onComplete;
			MultiTargetTween alphaTween = Tweens.Add(tweenConfig2);
			_alphaTween = alphaTween;
			if (_alphaTween2 != null)
			{
				_alphaTween2.Kill();
			}
			TweenConfig tweenConfig3 = new TweenConfig();
			object[] array3 = new object[1];
			if ((object)_animatedSprite2 != null)
			{
				nint num9 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array3;
			tweenConfig3.scale = (float?)(object)1;
			tweenConfig3.duration = 150f;
			tweenConfig3.yoyo = true;
			tweenConfig3.repeat = 8;
			tweenConfig3.alpha = (float?)(object)1;
			TweenCallback onStart2 = delegate
			{
				//IL_0015: Expected O, but got I4
				PhaserSprite phaserSprite16 = _animatedSprite2.setScale(1f, (float?)(object)0);
				PhaserSprite phaserSprite17 = _animatedSprite2.setAlpha(0.35f);
			};
			tweenConfig3.onStart = onStart2;
			MultiTargetTween alphaTween2 = Tweens.Add(tweenConfig3);
			_alphaTween2 = alphaTween2;
			if (_alphaTween3 != null)
			{
				_alphaTween3.Kill();
			}
			TweenConfig tweenConfig4 = new TweenConfig();
			object[] array4 = new object[1];
			if ((object)_animatedSprite3 != null)
			{
				nint num10 = (nint)array4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig4.targets = array4;
			tweenConfig4.scale = (float?)(object)1;
			tweenConfig4.duration = 150f;
			tweenConfig4.yoyo = true;
			tweenConfig4.repeat = 8;
			tweenConfig4.alpha = (float?)(object)1;
			TweenCallback onStart3 = delegate
			{
				//IL_0015: Expected O, but got I4
				PhaserSprite phaserSprite16 = _animatedSprite3.setScale(1f, (float?)(object)0);
				PhaserSprite phaserSprite17 = _animatedSprite3.setAlpha(0.35f);
			};
			tweenConfig4.onStart = onStart3;
			MultiTargetTween alphaTween3 = Tweens.Add(tweenConfig4);
			_alphaTween3 = alphaTween3;
			return;
		}
		ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
		throw ex4;
	}

	public override void Despawn()
	{
		if (_radiusTween != null)
		{
			TweenExtensions.Kill(_radiusTween);
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_enterTween != null)
		{
			_enterTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_alphaTween2 != null)
		{
			_alphaTween2.Kill();
		}
		if (_alphaTween3 != null)
		{
			_alphaTween3.Kill();
		}
		base.Despawn();
	}

	private void StartDespawn()
	{
		//IL_003f: Expected I, but got O
		//IL_00a3: Expected O, but got I4
		//IL_00be: Expected I, but got O
		if (_enterTween != null)
		{
			_enterTween.Kill();
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
			tweenConfig.duration = 300f;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_AuraBig_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween enterTween = Tweens.Add(tweenConfig);
			_enterTween = enterTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
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

	private void _003CInitProjectile_003Eb__11_0()
	{
		//IL_0015: Expected O, but got I4
		PhaserSprite phaserSprite = _animatedSprite.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _animatedSprite.setAlpha(0.65f);
	}

	private void _003CInitProjectile_003Eb__11_1()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
	}

	private void _003CInitProjectile_003Eb__11_2()
	{
		//IL_0015: Expected O, but got I4
		PhaserSprite phaserSprite = _animatedSprite2.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _animatedSprite2.setAlpha(0.35f);
	}

	private void _003CInitProjectile_003Eb__11_3()
	{
		//IL_0015: Expected O, but got I4
		PhaserSprite phaserSprite = _animatedSprite3.setScale(1f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _animatedSprite3.setAlpha(0.35f);
	}
}
