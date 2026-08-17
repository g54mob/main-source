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
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_DarkRift_Projetile : Projectile
{
	private float pxWidth = 24f;

	private float pxHeight = 128f;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _scale2Tween;

	private PhaserSprite _displaySprite;

	private PhaserSprite _animatedSprite;

	private MultiTargetTween _alphaTween;

	private float _currentScale = 1f;

	private MultiTargetTween _durationTween;

	protected override void Awake()
	{
		//IL_00e2: Expected O, but got I4
		//IL_025a: Expected O, but got I4
		//IL_025a: Expected I4, but got O
		//IL_0368->IL0301: Incompatible stack heights: 1 vs 0
		//IL_0207->IL0301: Incompatible stack heights: 1 vs 0
		//IL_0229->IL0301: Incompatible stack heights: 1 vs 0
		//IL_0274->IL0301: Incompatible stack heights: 1 vs 0
		//IL_02a0->IL0301: Incompatible stack heights: 1 vs 0
		//IL_03c2->IL0301: Incompatible stack heights: 2 vs 0
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		if ((object)_renderer != null)
		{
			_renderer.sprite = sprite;
			if ((object)_renderer != null)
			{
				_renderer.enabled = false;
				GameObject gameObject = base.gameObject;
				Vector2 vector = default(Vector2);
				PhaserSprite displaySprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Evil01");
				_displaySprite = displaySprite;
				if ((object)_displaySprite != null)
				{
					PhaserSprite phaserSprite = _displaySprite.setOrigin(0.5f, (float?)(object)1);
					if ((object)_displaySprite != null)
					{
						Transform transform = _displaySprite.transform;
						if ((object)transform != null)
						{
							bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							nint num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rcx_v29 (Il2CppMethodInfo)+38]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
							}
							Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
							if ((object)_displaySprite != null)
							{
								PhaserSprite phaserSprite2 = _displaySprite.setVisible(visible: false);
								GameObject gameObject2 = base.gameObject;
								PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject2, vector, "ThosePeople", "TP_VFX_PurpleSmoke01");
								_animatedSprite = animatedSprite;
								string text = default(string);
								int num2 = default(int);
								bool flag2 = default(bool);
								List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_PurpleSmoke", 0, 8, vector, text, num2, flag2);
								PhaserSprite animatedSprite2 = _animatedSprite;
								if ((object)_animatedSprite != null && (object)animatedSprite2._spriteAnimation != null)
								{
									bool autoSetAnimation = default(bool);
									animatedSprite2._spriteAnimation.AddAnimation("explode", animationFrames, 24, (byte)(int)text != 0, (byte)num2 != 0, (Action)flag2, autoSetAnimation);
									if ((object)_animatedSprite != null)
									{
										Transform transform2 = _animatedSprite.transform;
										if ((object)transform2 != null)
										{
											bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
											nint num3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v950 @ rcx_v44 (Il2CppMethodInfo)+38]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
											}
											Transform.SetParent_Injected(((UnityEngine.Object)transform2).m_CachedPtr, (IntPtr)0, true);
											if ((object)_animatedSprite != null)
											{
												PhaserSprite phaserSprite3 = _animatedSprite.setVisible(visible: false);
												return;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_03e6: Expected O, but got I4
		//IL_003e: Expected O, but got I4
		//IL_006b: Expected O, but got I4
		//IL_0088: Expected O, but got I4
		//IL_0181: Expected I, but got O
		//IL_01f5: Expected O, but got I4
		//IL_028e: Expected I, but got O
		//IL_031c: Expected O, but got I4
		//IL_032a: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)1);
		float num = _weapon.PArea();
		float num2 = default(float);
		float xScale = num2 * pxWidth;
		_currentScale = num2;
		ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)1);
		float xScale2 = num2 * 0.68085104f;
		PhaserSprite phaserSprite = _displaySprite.setScale(xScale2, (float?)(object)1);
		PhaserSprite phaserSprite2 = _animatedSprite.setScale(num2, (float?)(object)0);
		PhaserSprite phaserSprite3 = _animatedSprite.setBlendMode(BlendMode.Normal);
		PhaserSprite phaserSprite4 = _animatedSprite.setAlpha(0.65f);
		PhaserSprite phaserSprite5 = _animatedSprite.setVisible(visible: true);
		PhaserSprite phaserSprite6 = _displaySprite.setVisible(visible: true);
		PhaserSprite phaserSprite7 = _displaySprite.setAlpha(0.35f);
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_displaySprite != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		float num4 = num2 * 0.68085104f;
		tweenConfig.duration = 200f;
		tweenConfig.scaleY = (float?)(object)1;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
		if (_durationTween != null)
		{
			_durationTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_displaySprite != null)
		{
			nint num5 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.delay = 600f;
		tweenConfig2.duration = 500f;
		tweenConfig2.yoyo = false;
		tweenConfig2.repeat = 3;
		tweenConfig2.scale = (float?)(object)1;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			ShootWave();
		};
		tweenConfig2.onStart = onStart;
		TweenCallback onRepeat = delegate
		{
			ShootWave();
		};
		tweenConfig2.onRepeat = onRepeat;
		TweenCallback onComplete = delegate
		{
			StartDespawn();
		};
		tweenConfig2.onComplete = onComplete;
		MultiTargetTween durationTween = Tweens.Add(tweenConfig2);
		_durationTween = durationTween;
	}

	private void ShootWave()
	{
		//IL_01b4: Expected O, but got I4
		//IL_00b9: Expected I, but got O
		//IL_011d: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Hellfire2, soundConfig, 150f, 1, time);
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: true);
		PhaserSprite animatedSprite = _animatedSprite;
		animatedSprite._spriteAnimation.SetAnimation("explode");
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
			tweenConfig.duration = 200f;
			tweenConfig.scaleY = (float?)(object)1;
			TweenCallback onStart = delegate
			{
				//IL_0027: Expected O, but got I4
				float xScale = _currentScale * pxWidth;
				ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)1);
			};
			tweenConfig.onStart = onStart;
			TweenCallback onComplete = delegate
			{
				//IL_0027: Expected O, but got I4
				float xScale = _currentScale * pxWidth;
				ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)1);
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	private void LateUpdate()
	{
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 float6 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		int num = base.depth;
		PhaserSprite phaserSprite = _displaySprite.setDepth(num);
		int num2 = base.depth;
		int num3 = num2 - 1;
		PhaserSprite phaserSprite2 = _animatedSprite.setDepth(num3);
	}

	private void StartDespawn()
	{
		//IL_0127: Expected O, but got I4
		//IL_005e: Expected I, but got O
		//IL_00c2: Expected O, but got I4
		//IL_00dd: Expected I, but got O
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_displaySprite != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 500f;
		tweenConfig.alpha = (float?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_DarkRift_Projetile>)+370]");
		TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
		nint num2 = (nint)this;
		tweenConfig.onComplete = onComplete;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
	}

	public override void Despawn()
	{
		PhaserSprite phaserSprite = _displaySprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _animatedSprite.setVisible(visible: false);
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
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
	}

	private void _003CInitProjectile_003Eb__10_0()
	{
		ShootWave();
	}

	private void _003CInitProjectile_003Eb__10_1()
	{
		ShootWave();
	}

	private void _003CInitProjectile_003Eb__10_2()
	{
		StartDespawn();
	}

	private void _003CShootWave_003Eb__11_0()
	{
		//IL_0027: Expected O, but got I4
		float xScale = _currentScale * pxWidth;
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)1);
	}

	private void _003CShootWave_003Eb__11_1()
	{
		//IL_0027: Expected O, but got I4
		float xScale = _currentScale * pxWidth;
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)1);
	}
}
