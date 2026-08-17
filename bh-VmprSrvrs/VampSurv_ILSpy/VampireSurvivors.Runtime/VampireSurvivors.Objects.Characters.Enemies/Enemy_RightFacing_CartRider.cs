using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class Enemy_RightFacing_CartRider : EnemyController
{
	private PhaserSprite _frontSprite;

	private PhaserSprite _backSprite;

	protected float2 _CartOffset;

	private MultiTargetTween cartScaleTween;

	private SoundManager.SoundConfig sfxConfig;

	private Sprite _resetfrontSprite;

	private Sprite _resetbackSprite;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_00c3: Expected O, but got I4
		//IL_01e9: Expected O, but got I4
		//IL_02e8: Expected O, but got I4
		//IL_073c: Expected O, but got F4
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Expected O, but got Unknown
		//IL_03d0: Expected O, but got I4
		//IL_0407: Expected O, but got I4
		//IL_07c5->IL06eb: Incompatible stack heights: 1 vs 0
		//IL_03ee->IL06eb: Incompatible stack heights: 1 vs 0
		//IL_0425->IL06eb: Incompatible stack heights: 1 vs 0
		//IL_0458->IL06eb: Incompatible stack heights: 1 vs 0
		//IL_04c4->IL04c4: Incompatible stack heights: 1 vs 0
		base.InitEnemy(enemyType, asRemote);
		PhaserSprite frontSprite = _frontSprite;
		if ((object)_frontSprite != null && ((UnityEngine.Object)frontSprite).m_CachedPtr != (IntPtr)0)
		{
			goto IL_04c4;
		}
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("CarloCartFrontBreak_", 0, 14, "items", num);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("CarloCartBackBreak_", 0, 14, "items", num);
		PhaserWorld instance = PhaserWorld.Instance;
		float num4;
		if ((object)instance != null)
		{
			PhaserSprite frontSprite2 = instance.AddPhaserSprite((Vector2)0, "items", "CarloCartFront");
			_frontSprite = frontSprite2;
			if ((object)_frontSprite != null)
			{
				GameObject gameObject = _frontSprite.gameObject;
				if ((object)gameObject != null)
				{
					((UnityEngine.Object)gameObject).SetName("_frontCartSprite");
					PhaserSprite frontSprite3 = _frontSprite;
					if ((object)_frontSprite != null && (object)frontSprite3._spriteAnimation != null)
					{
						bool startRandomFrame = default(bool);
						Action onComplete = default(Action);
						bool autoSetAnimation = default(bool);
						frontSprite3._spriteAnimation.AddAnimation("break", animationFrames, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
						PhaserWorld instance2 = PhaserWorld.Instance;
						if ((object)instance2 != null)
						{
							PhaserSprite backSprite = instance2.AddPhaserSprite((Vector2)0, "items", "CarloCartBack");
							_backSprite = backSprite;
							if ((object)_backSprite != null)
							{
								GameObject gameObject2 = _backSprite.gameObject;
								if ((object)gameObject2 != null)
								{
									((UnityEngine.Object)gameObject2).SetName("_backCartSprite");
									PhaserSprite backSprite2 = _backSprite;
									if ((object)_backSprite != null && (object)backSprite2._spriteAnimation != null)
									{
										backSprite2._spriteAnimation.AddAnimation("break", animationFrames2, 16, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
										SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
										soundConfig.Volume = (float?)(object)1;
										soundConfig.Rate = 2f;
										object obj = UnityEngine.Random.value;
										object obj2 = default(object);
										float num2 = (float)obj2 * 400f;
										sfxConfig = soundConfig;
										CheckRenderer();
										if ((object)((ArcadeSprite)this)._spriteRenderer != null)
										{
											Sprite sprite = ((ArcadeSprite)this)._spriteRenderer.sprite;
											if ((object)sprite != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rax_v55 (UnityEngine.Sprite)+10]");
												bool flag = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rax_v55 (UnityEngine.Sprite)+10]");
												Sprite.get_rect_Injected((IntPtr)0, out Rect _);
												float num3 = default(float);
												if (!(32f > num3))
												{
													object obj3 = 32f & -2147483649L;
													bool flag2 = (nint)obj3 <= 2139095040;
													num4 = num3;
													if (flag2)
													{
														goto IL_079b;
													}
												}
												num4 = 32f;
												goto IL_079b;
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
		goto IL_06eb;
		IL_079b:
		float xScale = num4 * (1f / 32f);
		if ((object)_frontSprite != null)
		{
			PhaserSprite phaserSprite = _frontSprite.setScale(xScale, (float?)(object)0);
			if ((object)_backSprite != null)
			{
				PhaserSprite phaserSprite2 = _backSprite.setScale(xScale, (float?)(object)0);
				if ((object)_frontSprite != null)
				{
					PhaserSprite phaserSprite3 = _frontSprite.setVisible(visible: false);
					if ((object)_backSprite != null)
					{
						PhaserSprite phaserSprite4 = _backSprite.setVisible(visible: false);
						Sprite sprite2 = SpriteManager.GetSprite("CarloCartFront", "items");
						_resetfrontSprite = sprite2;
						Sprite sprite3 = SpriteManager.GetSprite("CarloCartBack", "items");
						_resetbackSprite = sprite3;
						goto IL_04c4;
					}
				}
			}
		}
		goto IL_06eb;
		IL_04c4:
		EnemyData currentEnemyData = _currentEnemyData;
		if (_currentEnemyData != null)
		{
			_defaultSpeed = currentEnemyData._003Cspeed_003Ek__BackingField;
			if ((object)_frontSprite != null)
			{
				PhaserSprite phaserSprite5 = _frontSprite.setFrame(_resetfrontSprite);
				if ((object)_backSprite != null)
				{
					PhaserSprite phaserSprite6 = _backSprite.setFrame(_resetbackSprite);
					if ((object)_frontSprite != null)
					{
						PhaserSprite phaserSprite7 = _frontSprite.setVisible(visible: true);
						if ((object)_backSprite != null)
						{
							PhaserSprite phaserSprite8 = _backSprite.setVisible(visible: true);
							float2 float5 = base.position;
							if ((object)_frontSprite != null)
							{
								float2 float6 = default(float2);
								PhaserSprite phaserSprite9 = _frontSprite.setPosition(float6);
								int num5 = base.depth;
								if ((object)_frontSprite != null)
								{
									int num6 = num5 + 1;
									PhaserSprite phaserSprite10 = _frontSprite.setDepth(num6);
									float2 float7 = base.position;
									if ((object)_backSprite != null)
									{
										PhaserSprite phaserSprite11 = _backSprite.setPosition(float6);
										int num7 = base.depth;
										if ((object)_backSprite != null)
										{
											int num8 = num7 - 1;
											PhaserSprite phaserSprite12 = _backSprite.setDepth(num8);
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
		goto IL_06eb;
		IL_06eb:
		throw new NullReferenceException();
	}

	protected override void OnRecycleEnemy()
	{
		base.OnRecycleEnemy();
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		float2 float5 = base.position;
		float2 float6 = default(float2);
		PhaserSprite phaserSprite = _frontSprite.setPosition(float6);
		int num = base.depth;
		int num2 = num + 1;
		PhaserSprite phaserSprite2 = _frontSprite.setDepth(num2);
		float2 float7 = base.position;
		PhaserSprite phaserSprite3 = _backSprite.setPosition(float6);
		int num3 = base.depth;
		int num4 = num3 - 1;
		PhaserSprite phaserSprite4 = _backSprite.setDepth(num4);
		bool flag = GM.Core.IsStageVisuallyInverted();
		bool flag2 = (byte)((flag ? 1u : 0u) ^ 1u) != 0;
		base.SetFlipX(flag2);
		GameManager core = GM.Core;
		Stage stage = core._stage;
		StageData stageData = stage._stageData;
		if (stageData._003CisRacingStage_003Ek__BackingField)
		{
			GameManager core2 = GM.Core;
			Stage stage2 = core2._stage;
			Transform target = base.transform;
			stage2._fancyBg.ContainWithinRacingBounds(target);
		}
	}

	public override void Despawn()
	{
		PhaserSprite frontSprite = _frontSprite;
		SpriteAnimation spriteAnimation = frontSprite._spriteAnimation;
		((BaseSpriteAnimation)spriteAnimation)._currentAnimation = null;
		PhaserSprite backSprite = _backSprite;
		SpriteAnimation spriteAnimation2 = backSprite._spriteAnimation;
		((BaseSpriteAnimation)spriteAnimation2)._currentAnimation = null;
		PhaserSprite phaserSprite = _frontSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _backSprite.setVisible(visible: false);
		base.Despawn();
	}

	protected override void Die()
	{
		base.Die();
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Carrello, sfxConfig, 150f, 2, time);
		PhaserSprite frontSprite = _frontSprite;
		frontSprite._spriteAnimation.SetAnimation("break");
		PhaserSprite backSprite = _backSprite;
		backSprite._spriteAnimation.SetAnimation("break");
	}

	public override void Disappear()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A6470]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		base.Disappear();
		PhaserSprite frontSprite = _frontSprite;
		frontSprite._spriteAnimation.SetAnimation("break");
		PhaserSprite backSprite = _backSprite;
		backSprite._spriteAnimation.SetAnimation("break");
	}

	public Enemy_RightFacing_CartRider()
	{
		//IL_0017: Expected O, but got I4
		_CartOffset = (float2)0;
		_ = 1034147594;
		base._002Ector();
	}
}
