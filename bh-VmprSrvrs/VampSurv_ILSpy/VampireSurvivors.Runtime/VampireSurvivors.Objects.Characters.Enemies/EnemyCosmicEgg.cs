using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Scripts.Objects.VFX;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyCosmicEgg : EnemyRedBlue
{
	private bool _hasGeneratedSprites;

	private bool _damageDone;

	private float _infiniteCorridorTime;

	private float _infiniteCorridorDelay;

	private float _worldScreenHeight;

	private PhaserSprite _wingL;

	private PhaserSprite _wingR;

	private PhaserSprite _eye;

	private PhaserSprite _corridorBg;

	private PhaserSprite _corridorLight;

	private MultiTargetTween _spritesDeathTween;

	private MultiTargetTween _icLightTween;

	private MultiTargetTween _icAngleTween;

	private MultiTargetTween _icScaleTween;

	private const string FrameNameEyeBlue = "CEye_i01.png";

	private const string FrameNameEyeRed = "CEyeRed_i01.png";

	private const string FrameNameEggBlue = "CEgg_i01.png";

	private const string FrameNameEggRed = "CEggRed_i01.png";

	private const string FrameNameWing = "Wing_i01.png";

	private readonly List<uint> _003CTints_003Ek__BackingField;

	protected override List<uint> Tints => _003CTints_003Ek__BackingField;

	protected override void Awake()
	{
		base.Awake();
		((EnemyController)this)._003CIsTeleportOnCull_003Ek__BackingField = true;
		_isBlue = true;
	}

	protected unsafe override void OnUpdate()
	{
		//IL_002c: Expected O, but got Ref
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		base.OnUpdate();
		if (!((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			UpdateSprites();
			Transform transform = base.transform;
			object obj = default(object);
			transform.localEulerAngles = (Vector3)(&obj);
			bool flag = 0 < (nint)_currentDirection;
			object obj2 = 0 - _currentDirection;
			bool flag2 = obj2 == null;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool flag5 = flag4 & flag3;
			PhaserSprite phaserSprite = _eye.setFlipX(flag5);
			float deltaTime = PauseSystem.DeltaTime;
			if ((_infiniteCorridorTime = deltaTime + _infiniteCorridorTime) > _infiniteCorridorDelay)
			{
				_infiniteCorridorTime = 0f;
				_damageDone = false;
				CastInfiniteCorridor();
				flag5 = false;
			}
			float2 float5 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			float2 float6 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		}
	}

	public override void Disappear()
	{
		base.Disappear();
		PhaserSprite phaserSprite = _wingL.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _wingR.setVisible(visible: false);
		PhaserSprite phaserSprite3 = _eye.setVisible(visible: false);
	}

	protected override void Die()
	{
		//IL_005e: Expected I, but got O
		//IL_00b6: Expected I, but got O
		//IL_010e: Expected I, but got O
		//IL_0172: Expected O, but got I4
		base.Die();
		if (_spritesDeathTween != null)
		{
			_spritesDeathTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[3];
		if ((object)_wingL != null)
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
		if ((object)_wingR != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		if ((object)_eye != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 200f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite = _wingL.setVisible(visible: false);
			PhaserSprite phaserSprite2 = _wingR.setVisible(visible: false);
			PhaserSprite phaserSprite3 = _eye.setVisible(visible: false);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween spritesDeathTween = Tweens.Add(tweenConfig);
		_spritesDeathTween = spritesDeathTween;
	}

	public override void Despawn()
	{
		base.Despawn();
		PhaserSprite phaserSprite = _wingL.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _wingR.setVisible(visible: false);
		PhaserSprite phaserSprite3 = _eye.setVisible(visible: false);
	}

	protected unsafe override void OnRecycleEnemy()
	{
		//IL_034e: Expected I, but got O
		//IL_0136: Expected O, but got I4
		//IL_0173: Expected O, but got I4
		//IL_01ab: Expected O, but got I4
		//IL_023d: Expected O, but got I4
		//IL_0274: Expected O, but got I4
		//IL_02ab: Expected O, but got I4
		//IL_033e->IL02bb: Incompatible stack heights: 1 vs 0
		//IL_025b->IL02bb: Incompatible stack heights: 1 vs 0
		//IL_0292->IL02bb: Incompatible stack heights: 1 vs 0
		((EnemyController)this).OnRecycleEnemy();
		nint num = (nint)this;
		List<uint> tints = Tints;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A570");
		uint num2 = default(uint);
		_saveTint = num2;
		ArcadeSprite arcadeSprite = setTint(num2);
		_isBlue = false;
		_invertFlip = false;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					_worldScreenHeight = renderer.height;
					GenerateSpritesAndAnimations();
					UpdateSprites();
					if ((object)_wingL != null)
					{
						PhaserSprite phaserSprite = _wingL.setVisible(visible: true);
						if ((object)_wingR != null)
						{
							PhaserSprite phaserSprite2 = _wingR.setVisible(visible: true);
							if ((object)_eye != null)
							{
								PhaserSprite phaserSprite3 = _eye.setVisible(visible: true);
								ArcadeSprite arcadeSprite2 = setOrigin(0.5f, (float?)(object)0);
								if ((object)_wingR != null)
								{
									PhaserSprite phaserSprite4 = _wingR.setOrigin(-0.2f, (float?)(object)1);
									if ((object)_wingL != null)
									{
										PhaserSprite phaserSprite5 = _wingL.setOrigin(1.55f, (float?)(object)1);
										if ((object)_wingL != null)
										{
											PhaserSprite phaserSprite6 = _wingL.setFlipX(flipX: true);
											ArcadeSprite arcadeSprite3 = setTint(16777215u);
											object cachedTransform = _cachedTransform;
											if ((object)_cachedTransform != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rsi_v4 (System.Object)+10]");
												bool flag = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ rsi_v4 (System.Object)+10]");
												float ret;
												Transform.get_localScale_Injected((IntPtr)0, out *(Vector3*)(&ret));
												if ((object)_wingL != null)
												{
													PhaserSprite phaserSprite7 = _wingL.setScale(ret, (float?)(object)1);
													if ((object)_wingR != null)
													{
														PhaserSprite phaserSprite8 = _wingR.setScale(ret, (float?)(object)1);
														if ((object)_eye != null)
														{
															PhaserSprite phaserSprite9 = _eye.setScale(ret, (float?)(object)1);
															_infiniteCorridorTime = 0f;
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
				}
			}
		}
		throw new NullReferenceException();
	}

	private void GenerateSpritesAndAnimations()
	{
		//IL_0483: Expected O, but got F4
		int num = default(int);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		if (!_hasGeneratedSprites)
		{
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene = ArcadePhysics.s_scene;
				float2 float5 = base.position;
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite = RenderingExtensions.sprite(s_scene.add, pos, "enemiesM", "Wing_i01.png");
				GameObject gameObject = phaserSprite.gameObject;
				((UnityEngine.Object)gameObject).SetName("CosmicEgg - WingL");
				_wingL = phaserSprite;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene2 = ArcadePhysics.s_scene;
					float2 float6 = base.position;
					PhaserSprite phaserSprite2 = RenderingExtensions.sprite(s_scene2.add, pos, "enemiesM", "Wing_i01.png");
					GameObject gameObject2 = phaserSprite2.gameObject;
					((UnityEngine.Object)gameObject2).SetName("CosmicEgg - WingR");
					_wingR = phaserSprite2;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene3 = ArcadePhysics.s_scene;
						float2 float7 = base.position;
						PhaserSprite phaserSprite3 = RenderingExtensions.sprite(s_scene3.add, pos, "enemiesM", "CEye_i01.png");
						GameObject gameObject3 = phaserSprite3.gameObject;
						((UnityEngine.Object)gameObject3).SetName("CosmicEgg - Eye");
						_eye = phaserSprite3;
						string animName = "Wing_i01.png".Replace("1.png", "");
						List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, 5, "enemiesM", num);
						PhaserSprite wingL = _wingL;
						wingL._spriteAnimation.AddAnimation("idle", animationFrames, 10, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
						PhaserSprite wingR = _wingR;
						wingR._spriteAnimation.AddAnimation("idle", animationFrames, 10, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
						string animName2 = "CEye_i01.png".Replace("1.png", "");
						List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames(animName2, 1, 5, "enemiesM", num);
						PhaserSprite eye = _eye;
						eye._spriteAnimation.AddAnimation("blue", animationFrames2, 10, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
						string animName3 = "CEyeRed_i01.png".Replace("1.png", "");
						List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames(animName3, 1, 5, "enemiesM", num);
						PhaserSprite eye2 = _eye;
						eye2._spriteAnimation.AddAnimation("red", animationFrames3, 10, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene4 = ArcadePhysics.s_scene;
							PhaserSprite phaserSprite4 = RenderingExtensions.sprite(s_scene4.add, pos, "vfx", "corridor_bg");
							PhaserSprite phaserSprite5 = phaserSprite4.setVisible(visible: false);
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene5 = ArcadePhysics.s_scene;
								PhaserScene.Renderer renderer = s_scene5._renderer;
								float num2 = renderer.height ^ -0f;
								PhaserSprite phaserSprite6 = phaserSprite5.setDepth(num2);
								GameObject gameObject4 = phaserSprite6.gameObject;
								((UnityEngine.Object)gameObject4).SetName("CosmicEgg - CorridorBg");
								_corridorBg = phaserSprite6;
								if ((object)GM.Core != null)
								{
									PhaserScene s_scene6 = ArcadePhysics.s_scene;
									PhaserSprite phaserSprite7 = RenderingExtensions.sprite(s_scene6.add, pos, "vfx", "corridor_light");
									PhaserSprite phaserSprite8 = phaserSprite7.setVisible(visible: false);
									if ((object)GM.Core != null)
									{
										PhaserScene s_scene7 = ArcadePhysics.s_scene;
										PhaserScene.Renderer renderer2 = s_scene7._renderer;
										object obj = renderer2.height ^ -0f;
										float num3 = (float)obj + 1f;
										PhaserSprite phaserSprite9 = phaserSprite8.setDepth(num3);
										GameObject gameObject5 = phaserSprite9.gameObject;
										((UnityEngine.Object)gameObject5).SetName("CosmicEgg - CorridorLight");
										_corridorLight = phaserSprite9;
										_hasGeneratedSprites = true;
										goto IL_04e8;
									}
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
		goto IL_04e8;
		IL_04e8:
		string animName4 = "CEggRed_i01.png".Replace("1.png", "");
		List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames(animName4, 1, 5, "enemiesM", num);
		_SpriteAnimation.AddAnimation("idle_red", animationFrames4, 10, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite wingL2 = _wingL;
		wingL2._spriteAnimation.SetAnimation("idle");
		PhaserSprite wingR2 = _wingR;
		wingR2._spriteAnimation.SetAnimation("idle");
		PhaserSprite eye3 = _eye;
		eye3._spriteAnimation.SetAnimation("blue");
	}

	private unsafe void UpdateSprites()
	{
		//IL_0023: Expected O, but got I4
		//IL_005a: Expected O, but got I4
		//IL_0091: Expected O, but got I4
		//IL_03aa->IL0330: Incompatible stack heights: 1 vs 0
		//IL_0041->IL0330: Incompatible stack heights: 1 vs 0
		//IL_0078->IL0330: Incompatible stack heights: 1 vs 0
		//IL_00be->IL0330: Incompatible stack heights: 1 vs 0
		//IL_00e7->IL0330: Incompatible stack heights: 1 vs 0
		//IL_0110->IL0330: Incompatible stack heights: 1 vs 0
		//IL_0138->IL0330: Incompatible stack heights: 1 vs 0
		//IL_03d1->IL0330: Incompatible stack heights: 1 vs 0
		//IL_016c->IL0330: Incompatible stack heights: 1 vs 0
		//IL_01cd->IL0330: Incompatible stack heights: 1 vs 0
		//IL_021c->IL0330: Incompatible stack heights: 1 vs 0
		//IL_026b->IL0330: Incompatible stack heights: 1 vs 0
		//IL_02ba->IL0330: Incompatible stack heights: 1 vs 0
		//IL_0309->IL0330: Incompatible stack heights: 1 vs 0
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			float ret;
			Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)(&ret));
			if ((object)_wingL != null)
			{
				PhaserSprite phaserSprite = _wingL.setScale(ret, (float?)(object)1);
				if ((object)_wingR != null)
				{
					PhaserSprite phaserSprite2 = _wingR.setScale(ret, (float?)(object)1);
					if ((object)_eye != null)
					{
						PhaserSprite phaserSprite3 = _eye.setScale(ret, (float?)(object)1);
						float2 float5 = base.position;
						if ((object)_eye != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
							if ((object)_wingR != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
								if ((object)_wingL != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
									if ((object)GM.Core != null)
									{
										PhaserScene s_scene = ArcadePhysics.s_scene;
										if (ArcadePhysics.s_scene != null)
										{
											PhaserScene.Renderer renderer = s_scene._renderer;
											if (s_scene._renderer != null)
											{
												float num = renderer.height * 0.5f;
												float num2 = num + 2f;
												ArcadeSprite arcadeSprite = setDepth(num2);
												int num3 = base.depth;
												if ((object)_eye != null)
												{
													int num4 = num3 + 1;
													PhaserSprite phaserSprite4 = _eye.setDepth(num4);
													int num5 = base.depth;
													if ((object)_wingR != null)
													{
														int num6 = num5 - 1;
														PhaserSprite phaserSprite5 = _wingR.setDepth(num6);
														int num7 = base.depth;
														if ((object)_wingL != null)
														{
															int num8 = num7 - 1;
															PhaserSprite phaserSprite6 = _wingL.setDepth(num8);
															int num9 = base.depth;
															if ((object)_corridorBg != null)
															{
																int num10 = num9 - 3;
																PhaserSprite phaserSprite7 = _corridorBg.setDepth(num10);
																int num11 = base.depth;
																if ((object)_corridorLight != null)
																{
																	int num12 = num11 - 2;
																	PhaserSprite phaserSprite8 = _corridorLight.setDepth(num12);
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
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void CastInfiniteCorridor()
	{
		//IL_0093: Expected F4, but got I4
		//IL_00df: Expected O, but got I4
		//IL_0109: Expected O, but got Ref
		//IL_013b: Expected O, but got I4
		//IL_01cf: Expected I, but got O
		//IL_0299: Expected O, but got I4
		//IL_02a7: Expected O, but got I4
		//IL_032f: Expected O, but got I4
		//IL_03e8: Expected I, but got O
		//IL_044c: Expected O, but got I4
		//IL_04e5: Expected I, but got O
		//IL_0588: Expected O, but got I4
		//IL_0596: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CFlashingVFXEnabled_003Ek__BackingField)
		{
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		float alpha = ((!config2._003CFlashingVFXEnabled_003Ek__BackingField) ? 0f : 0.75f);
		PhaserSprite phaserSprite = _corridorBg.setVisible(visible: true);
		PhaserSprite phaserSprite2 = _corridorLight.setVisible(visible: true);
		PhaserSprite phaserSprite3 = _corridorBg.setScale(0f, (float?)(object)0);
		Transform transform = _corridorBg.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
		PhaserSprite phaserSprite4 = _corridorBg.setAlpha(alpha);
		PhaserSprite phaserSprite5 = _corridorLight.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite6 = _corridorLight.setAlpha(alpha);
		if (_icScaleTween != null)
		{
			_icScaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_corridorBg != null)
		{
			nint num = (nint)array;
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
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float num2 = renderer.width / 1.28f;
			tweenConfig.duration = 1000f;
			tweenConfig.yoyo = true;
			tweenConfig.ease = Ease.InOutSine;
			tweenConfig.scale = (float?)(object)1;
			tweenConfig.alpha = (float?)(object)1;
			TweenCallback onUpdate = delegate
			{
				//IL_006b: Expected F4, but got O
				//IL_01e8: Expected O, but got I
				//IL_02a3: Expected I, but got O
				//IL_02b5: Expected I, but got O
				//IL_02e4: Expected O, but got F4
				//IL_0223: Unknown result type (might be due to invalid IL or missing references)
				//IL_0228: Expected O, but got Unknown
				//IL_0235: Expected I, but got O
				//IL_0258: Expected O, but got I4
				//IL_0192->IL0363: Incompatible stack heights: 2 vs 0
				//IL_01d3->IL0363: Incompatible stack heights: 2 vs 0
				//IL_02e9->IL0363: Incompatible stack heights: 2 vs 0
				//IL_0266->IL0363: Incompatible stack heights: 2 vs 0
				if (!_damageDone)
				{
					float2 float5 = base.position;
					float2 float6 = base.position;
					float num5 = _corridorBg.scale;
					Circle circle = new Circle();
					circle._x = (float)float5;
					float num6 = default(float);
					circle._y = num6;
					float radius = num5 * 0.64f;
					circle._radius = radius;
					GameManager core3 = GM.Core;
					List<CharacterController> characters = core3._characters;
					List<CharacterController>.Enumerator characters2 = (List<CharacterController>.Enumerator)core3._characters;
					float num7 = num6;
					ArcadeSprite arcadeSprite = null;
					List<CharacterController>.Enumerator characters3 = (List<CharacterController>.Enumerator)core3._characters;
					List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
					ArcadeSprite arcadeSprite3 = default(ArcadeSprite);
					List<CharacterController>.Enumerator enumerator2 = default(List<CharacterController>.Enumerator);
					while (enumerator.MoveNext())
					{
						ArcadeSprite arcadeSprite2 = null;
						Transform cachedTrans = ((ArcadeSprite)null).CachedTrans;
						bool flag = (object)cachedTrans == null;
						bool flag2 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
						float2 ret;
						Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
						if (arcadeSprite2.body != null)
						{
							BaseBody baseBody = arcadeSprite2.body;
							ArcadeTransform arcadeTransform = baseBody._transform;
							arcadeTransform.position = ret;
							arcadeSprite = arcadeSprite3;
						}
						else
						{
							arcadeSprite = arcadeSprite3;
						}
						bool flag3 = circle.Contains((Vector2)enumerator2);
						bool flag4 = !flag3;
						characters3 = enumerator2;
						if (!flag4)
						{
							_damageDone = true;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rbx_v5 (ArcadeSprite)+28A]");
							bool flag5 = (nint)0 != 0;
							characters3 = enumerator2;
							if (!flag5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rbx_v5 (ArcadeSprite)+218]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v980 @ rax_v30+B0]");
								if ((nint)0 <= (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rbx_v5 (ArcadeSprite)+228]");
									characters3 = (List<CharacterController>.Enumerator)(0 * 0.5f);
									nint num8 = (nint)arcadeSprite2;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1047 @ rax_v42 (Il2CppClass<ArcadeSprite>)+608] (should have been resolved before IL gen)");
									GM.Core.FirePlayerXpUpdated();
									characters = (List<CharacterController>)1;
									num7 = 120f;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v980 @ rax_v30+B0]");
									float num9 = 0f - 1f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rbx_v5 (ArcadeSprite)+228]");
									float num10 = 0f * 0.5f;
									nint num11 = (nint)arcadeSprite2;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1054 @ rdx_v15 (Il2CppClass<ArcadeSprite>)+488] (should have been resolved before IL gen)");
									nint num12 = (nint)arcadeSprite2;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1059 @ rax_v33 (Il2CppClass<ArcadeSprite>)+608] (should have been resolved before IL gen)");
									characters = null;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1980");
									num7 = num9;
									characters3 = (List<CharacterController>.Enumerator)num10;
								}
							}
						}
					}
				}
			};
			tweenConfig.onUpdate = onUpdate;
			TweenCallback onComplete = delegate
			{
				PhaserSprite phaserSprite7 = _corridorBg.setVisible(visible: false);
				PhaserSprite phaserSprite8 = _corridorLight.setVisible(visible: false);
			};
			tweenConfig.onComplete = onComplete;
			MultiTargetTween icScaleTween = Tweens.Add(tweenConfig);
			_icScaleTween = icScaleTween;
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			soundConfig.Detune = 500f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Corridor, soundConfig, 400f, 1, time);
			if (_icAngleTween != null)
			{
				_icAngleTween.Kill();
			}
			TweenConfig tweenConfig2 = new TweenConfig();
			object[] array2 = new object[1];
			if ((object)_corridorBg != null)
			{
				nint num3 = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj3 = default(object);
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig2.targets = array2;
			tweenConfig2.duration = 2000f;
			tweenConfig2.angle = (float?)(object)1;
			MultiTargetTween icAngleTween = Tweens.Add(tweenConfig2);
			_icAngleTween = icAngleTween;
			if (_icLightTween != null)
			{
				_icLightTween.Kill();
			}
			TweenConfig tweenConfig3 = new TweenConfig();
			object[] array3 = new object[1];
			if ((object)_corridorLight != null)
			{
				nint num4 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig3.targets = array3;
			if ((object)GM.Core != null)
			{
				tweenConfig3.duration = 1000f;
				tweenConfig3.yoyo = true;
				tweenConfig3.ease = Ease.InOutSine;
				tweenConfig3.scale = (float?)(object)1;
				tweenConfig3.alpha = (float?)(object)1;
				MultiTargetTween icLightTween = Tweens.Add(tweenConfig3);
				_icLightTween = icLightTween;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void TurnBlue()
	{
		//IL_0062: Expected O, but got I4
		//IL_00b5: Expected I4, but got I8
		if (!((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			PhaserSprite eye = _eye;
			_isBlue = true;
			_invertFlip = false;
			eye._spriteAnimation.SetAnimation("blue");
			_SpriteAnimation.SetAnimation("idle");
			ArcadeSprite arcadeSprite = setScale(1.2f, (float?)(object)0);
			GameManager core = GM.Core;
			CommonVfxManager commonVfxManager = core._commonVfxManager;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt(commonVfxManager._pxfEmitterBlue, pos, -1);
		}
	}

	public override void TurnRed()
	{
		//IL_0057: Expected O, but got I4
		//IL_00aa: Expected I4, but got I8
		if (!((EnemyController)this)._003CIsDead_003Ek__BackingField)
		{
			PhaserSprite eye = _eye;
			_isBlue = false;
			eye._spriteAnimation.SetAnimation("red");
			_SpriteAnimation.SetAnimation("idle_red");
			ArcadeSprite arcadeSprite = setScale(1.2f, (float?)(object)0);
			GameManager core = GM.Core;
			CommonVfxManager commonVfxManager = core._commonVfxManager;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			RenderingExtensions.EmitParticleAt(commonVfxManager._pfxEmitterRed, pos, -1);
		}
	}

	public EnemyCosmicEgg()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		_infiniteCorridorDelay = 15.000001f;
		_worldScreenHeight = 1f;
		List<uint> list = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(16777215u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 16777215;
		}
		_003CTints_003Ek__BackingField = list;
		base._002Ector();
	}

	private void _003CDie_003Eb__25_0()
	{
		PhaserSprite phaserSprite = _wingL.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _wingR.setVisible(visible: false);
		PhaserSprite phaserSprite3 = _eye.setVisible(visible: false);
	}

	private unsafe void _003CCastInfiniteCorridor_003Eb__30_0()
	{
		//IL_006b: Expected F4, but got O
		//IL_01e8: Expected O, but got I
		//IL_02a3: Expected I, but got O
		//IL_02b5: Expected I, but got O
		//IL_02e4: Expected O, but got F4
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected O, but got Unknown
		//IL_0235: Expected I, but got O
		//IL_0258: Expected O, but got I4
		//IL_0192->IL0363: Incompatible stack heights: 2 vs 0
		//IL_01d3->IL0363: Incompatible stack heights: 2 vs 0
		//IL_02e9->IL0363: Incompatible stack heights: 2 vs 0
		//IL_0266->IL0363: Incompatible stack heights: 2 vs 0
		if (_damageDone)
		{
			return;
		}
		float2 float5 = base.position;
		float2 float6 = base.position;
		float num = _corridorBg.scale;
		Circle circle = new Circle();
		circle._x = (float)float5;
		float num2 = default(float);
		circle._y = num2;
		float radius = num * 0.64f;
		circle._radius = radius;
		GameManager core = GM.Core;
		List<CharacterController> characters = core._characters;
		List<CharacterController>.Enumerator characters2 = (List<CharacterController>.Enumerator)core._characters;
		float num3 = num2;
		ArcadeSprite arcadeSprite = null;
		List<CharacterController>.Enumerator characters3 = (List<CharacterController>.Enumerator)core._characters;
		List<CharacterController>.Enumerator enumerator = default(List<CharacterController>.Enumerator);
		ArcadeSprite arcadeSprite3 = default(ArcadeSprite);
		List<CharacterController>.Enumerator enumerator2 = default(List<CharacterController>.Enumerator);
		while (enumerator.MoveNext())
		{
			ArcadeSprite arcadeSprite2 = null;
			Transform cachedTrans = ((ArcadeSprite)null).CachedTrans;
			bool flag = (object)cachedTrans == null;
			bool flag2 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
			float2 ret;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
			if (arcadeSprite2.body != null)
			{
				BaseBody baseBody = arcadeSprite2.body;
				ArcadeTransform arcadeTransform = baseBody._transform;
				arcadeTransform.position = ret;
				arcadeSprite = arcadeSprite3;
			}
			else
			{
				arcadeSprite = arcadeSprite3;
			}
			bool flag3 = circle.Contains((Vector2)enumerator2);
			bool flag4 = !flag3;
			characters3 = enumerator2;
			if (flag4)
			{
				continue;
			}
			_damageDone = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rbx_v5 (ArcadeSprite)+28A]");
			bool flag5 = (nint)0 != 0;
			characters3 = enumerator2;
			if (!flag5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rbx_v5 (ArcadeSprite)+218]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v980 @ rax_v30+B0]");
				if ((nint)0 <= (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rbx_v5 (ArcadeSprite)+228]");
					characters3 = (List<CharacterController>.Enumerator)(0 * 0.5f);
					nint num4 = (nint)arcadeSprite2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1047 @ rax_v42 (Il2CppClass<ArcadeSprite>)+608] (should have been resolved before IL gen)");
					GM.Core.FirePlayerXpUpdated();
					characters = (List<CharacterController>)1;
					num3 = 120f;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v980 @ rax_v30+B0]");
					float num5 = 0f - 1f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rbx_v5 (ArcadeSprite)+228]");
					float num6 = 0f * 0.5f;
					nint num7 = (nint)arcadeSprite2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1054 @ rdx_v15 (Il2CppClass<ArcadeSprite>)+488] (should have been resolved before IL gen)");
					nint num8 = (nint)arcadeSprite2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1059 @ rax_v33 (Il2CppClass<ArcadeSprite>)+608] (should have been resolved before IL gen)");
					characters = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1980");
					num3 = num5;
					characters3 = (List<CharacterController>.Enumerator)num6;
				}
			}
		}
	}

	private void _003CCastInfiniteCorridor_003Eb__30_1()
	{
		PhaserSprite phaserSprite = _corridorBg.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _corridorLight.setVisible(visible: false);
	}
}
