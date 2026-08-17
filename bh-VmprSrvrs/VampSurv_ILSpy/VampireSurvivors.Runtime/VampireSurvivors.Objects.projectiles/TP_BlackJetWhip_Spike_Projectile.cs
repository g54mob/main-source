using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_BlackJetWhip_Spike_Projectile : Projectile
{
	private float pxWidth = 24f;

	private float pxHeight = 80f;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _scale2Tween;

	private PhaserSprite _animatedSprite;

	private MultiTargetTween _alphaTween;

	private float _currentScale = 1f;

	private MultiTargetTween _durationTween;

	protected override void Awake()
	{
		//IL_014d: Expected O, but got I4
		//IL_014d: Expected I4, but got O
		//IL_021e->IL021e: Incompatible stack heights: 1 vs 0
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				Vector2 vector = default(Vector2);
				string text = default(string);
				int num = default(int);
				bool flag = default(bool);
				bool autoSetAnimation = default(bool);
				while (true)
				{
					GameObject gameObject = base.gameObject;
					PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Blade01");
					_animatedSprite = animatedSprite;
					List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Blade", 1, 9, vector, text, num, flag);
					PhaserSprite animatedSprite2 = _animatedSprite;
					if ((object)_animatedSprite == null || (object)animatedSprite2._spriteAnimation == null)
					{
						break;
					}
					animatedSprite2._spriteAnimation.AddAnimation("explode", animationFrames, 30, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
					if ((object)_animatedSprite == null)
					{
						break;
					}
					Transform transform = _animatedSprite.transform;
					if ((object)transform == null)
					{
						break;
					}
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rcx_v25 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_02d5: Expected O, but got I4
		//IL_003e: Expected O, but got I4
		//IL_005b: Expected O, but got I4
		//IL_010c: Expected I, but got O
		//IL_0170: Expected O, but got I4
		//IL_01fc: Expected I, but got O
		//IL_0250: Expected O, but got I4
		//IL_02ae: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)1);
		_isCullable = false;
		float num = _weapon.PArea();
		float num2 = default(float);
		float xScale = num2 * pxWidth;
		_currentScale = num2;
		ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)1);
		PhaserSprite phaserSprite = _animatedSprite.setScale(num2, (float?)(object)0);
		PhaserSprite phaserSprite2 = _animatedSprite.setAlpha(0.85f);
		PhaserSprite phaserSprite3 = _animatedSprite.setVisible(visible: true);
		PhaserSprite animatedSprite = _animatedSprite;
		animatedSprite._spriteAnimation.SetAnimation("explode");
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
			tweenConfig.scaleY = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				//IL_0027: Expected O, but got I4
				float xScale2 = _currentScale * pxWidth;
				ArcadeSprite arcadeSprite3 = setScale(xScale2, (float?)(object)1);
			};
			tweenConfig.onStart = onStart;
			TweenCallback onComplete = delegate
			{
				//IL_0027: Expected O, but got I4
				float xScale2 = _currentScale * pxWidth;
				ArcadeSprite arcadeSprite3 = setScale(xScale2, (float?)(object)1);
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v672 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_BlackJetWhip_Spike_Projectile>)+370]");
			Action onComplete2 = new Action(this, (IntPtr)0);
			nint num4 = (nint)this;
			bool flag = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.3f, onComplete2, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 0.8f;
			float num5 = (float)_indexInWeapon * 50f;
			float detune = num5 - 500f;
			soundConfig.Detune = detune;
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Shuriken2, soundConfig, 200f, 3, flag ? 1 : 0);
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void LateUpdate()
	{
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		int num = base.depth;
		int num2 = num - _indexInWeapon;
		PhaserSprite phaserSprite = _animatedSprite.setDepth(num2);
		bool flag = base.flipX;
		PhaserSprite phaserSprite2 = _animatedSprite.setFlipX(flag);
	}

	public override void Despawn()
	{
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_scale2Tween != null)
		{
			_scale2Tween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_durationTween != null)
		{
			_durationTween.Kill();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}

	private void _003CInitProjectile_003Eb__9_0()
	{
		//IL_0027: Expected O, but got I4
		float xScale = _currentScale * pxWidth;
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)1);
	}

	private void _003CInitProjectile_003Eb__9_1()
	{
		//IL_0027: Expected O, but got I4
		float xScale = _currentScale * pxWidth;
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)1);
	}
}
