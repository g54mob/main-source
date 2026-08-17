using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_Death_Character : TP_Character
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__23_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COnDeath_003Eb__23_0()
		{
			//IL_003d: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Victory2, soundConfig, 0f, 10, time);
		}
	}

	private float _cooldownBonus;

	private float _greedBonus;

	private float _mightBonus;

	private bool _isMorphed;

	private PhaserSprite _sparkSprite;

	private PhaserSprite _ringSprite;

	private PhaserSprite _burstSprite;

	private PhaserSprite _darkSprite;

	private SpriteAnimation _burstSpriteAnim;

	private MultiTargetTween _ringTween;

	private MultiTargetTween _sparkTween;

	private MultiTargetTween _darkTween;

	private PhaserSprite _deathMask;

	private PhaserSprite _deathSpine;

	private PhaserSprite _deathCape;

	private PhaserSprite _leftEye;

	private PhaserSprite _rightEye;

	public override bool DrainWeaponsImmunity => true;

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		//IL_0047: Expected O, but got I4
		base.MakeLevelOne();
		bool flag = SpriteLoader.LoadTexture("TP_Death", "Gameplay", (DlcType?)(object)1);
		_isMorphed = false;
		SetupSparkle();
		_cooldownBonus = -0.2f;
		_greedBonus = 1f;
		_mightBonus = 2f;
	}

	public override void LevelUp()
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		base.LevelUp();
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list = config._003CSealedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rcx_v7 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool flag;
		if ((nint)0 == 0)
		{
			flag = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			object obj = obj2 - -1;
			bool flag2 = obj == null;
			flag = !flag2;
		}
		if (((CharacterController)this)._level < 80 || ((CharacterController)this)._isDead || base.IsDisconnectedFromOnlinePlay)
		{
			return;
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		List<ItemType> list2 = config2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rcx_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			if ((nint)obj3 != -1 && !flag)
			{
				Morph();
			}
		}
	}

	public void Morph(bool addBonusStats = true)
	{
		//IL_0037: Expected O, but got I4
		//IL_0095: Expected I4, but got F4
		//IL_011e: Expected O, but got I
		//IL_0133: Expected O, but got I
		//IL_0152: Expected O, but got I
		//IL_018f: Expected O, but got I
		//IL_01a4: Expected O, but got I
		//IL_01be: Expected O, but got I
		if (_isMorphed)
		{
			return;
		}
		_isMorphed = true;
		SetPermanentInvulnerability(on: true);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 0.5f;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
		GameManager core = GM.Core;
		Weapon weapon = core._weaponsFacade.AddHiddenWeapon(WeaponType.TP_DEATHHAND, this, removeFromStore: true, (byte)(int)num != 0);
		PlaySparkle();
		CreateMegaloDeathSprites();
		GameManager core2 = GM.Core;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core2._dataManager.GetConvertedCharacterData();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)276);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v19 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v19 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rax_v20+20]");
			object obj3 = 0;
			CharacterData currentCharacterData = _currentCharacterData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v21+78]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rax_v22+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rax_v22+10]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rcx_v21+20]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rax_v23+68]");
				currentCharacterData._003CheadOffsets_003Ek__BackingField = (List<Vector2>)0;
				if (addBonusStats)
				{
					PlayerModifierStats playerStats = _playerStats;
					EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
					float value = default(float);
					EggFloat cooldown = new EggFloat(value, eggFloat._eggVal);
					value = eggFloat._val + _cooldownBonus;
					playerStats.Cooldown = cooldown;
					PlayerModifierStats playerStats2 = _playerStats;
					EggFloat eggFloat2 = playerStats2._003CGreed_003Ek__BackingField;
					float value2 = default(float);
					EggFloat greed = new EggFloat(value2, eggFloat2._eggVal);
					value2 = eggFloat2._val + _greedBonus;
					playerStats2.Greed = greed;
					PlayerModifierStats playerStats3 = _playerStats;
					EggFloat eggFloat3 = playerStats3._003CPower_003Ek__BackingField;
					float value3 = default(float);
					EggFloat power = new EggFloat(value3, eggFloat3._eggVal);
					value3 = eggFloat3._val + _mightBonus;
					playerStats3.Power = power;
				}
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	protected override void OnUpdate()
	{
		//IL_005c: Invalid comparison between F4 and O
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		base.OnUpdate();
		if (!((CharacterController)this)._isDead && !base.IsDisconnectedFromOnlinePlay)
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
			float num = core._003CSurvivedSeconds_003Ek__BackingField;
			object obj = default(object);
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
			bool flag2 = !flag;
			object obj2 = (_003F?)stageModifiers._003CTimeLimit_003Ek__BackingField & flag2;
			if (obj2 != null)
			{
				PlayerModifierStats playerStats = _playerStats;
				playerStats._003CRevivals_003Ek__BackingField.Val = 0.0;
				TakeDamage(((CharacterController)this)._currentHp);
			}
		}
		if (_isMorphed)
		{
			UpdateMegaloDeathParts();
		}
	}

	public override void OnDeath()
	{
		//IL_06fe: Expected I, but got O
		//IL_0139: Expected O, but got I
		//IL_01ae: Expected I, but got O
		//IL_0234: Expected O, but got I4
		//IL_02d8: Expected I, but got O
		//IL_0342: Expected O, but got I4
		//IL_040b: Expected I, but got O
		//IL_0475: Expected O, but got I4
		//IL_0530: Expected I, but got O
		//IL_05c4: Expected O, but got I4
		//IL_066f->IL05f9: Incompatible stack heights: 1 vs 0
		//IL_0158->IL05f9: Incompatible stack heights: 2 vs 0
		//IL_0184->IL05f9: Incompatible stack heights: 2 vs 0
		//IL_01f3->IL05f9: Incompatible stack heights: 2 vs 0
		//IL_01d1->IL01d1: Incompatible stack heights: 3 vs 2
		//IL_0282->IL05f9: Incompatible stack heights: 2 vs 0
		//IL_02ae->IL05f9: Incompatible stack heights: 2 vs 0
		//IL_031d->IL05f9: Incompatible stack heights: 2 vs 0
		//IL_02fb->IL02fb: Incompatible stack heights: 3 vs 2
		//IL_03b5->IL05f9: Incompatible stack heights: 2 vs 0
		//IL_03e1->IL05f9: Incompatible stack heights: 2 vs 0
		//IL_0450->IL05f9: Incompatible stack heights: 2 vs 0
		//IL_042e->IL042e: Incompatible stack heights: 3 vs 2
		//IL_04da->IL05f9: Incompatible stack heights: 2 vs 0
		//IL_0506->IL05f9: Incompatible stack heights: 2 vs 0
		//IL_0575->IL05f9: Incompatible stack heights: 2 vs 0
		//IL_0553->IL0553: Incompatible stack heights: 3 vs 2
		if (_wiggleTween != null)
		{
			_wiggleTween.Pause();
		}
		if (_regenTimer != null)
		{
			_regenTimer.Cancel();
		}
		if (_blinkTimeoutTimer != null)
		{
			_blinkTimeoutTimer.Cancel();
		}
		if ((object)_CharacterRenderer != null)
		{
			((Renderer)_CharacterRenderer).Internal_GetPropertyBlock(_propBlock);
			MaterialPropertyBlock propBlock = _propBlock;
			if (_propBlock != null)
			{
				bool flag = propBlock.m_Ptr == (IntPtr)0;
				Color value = default(Color);
				MaterialPropertyBlock.SetColorImpl_Injected(propBlock.m_Ptr, RenderingExtensions.TintFillColor, ref value);
				RenderingExtensions.SetTintFillEnabled(_propBlock, isEnabled: true);
				MaterialPropertyBlock characterRenderer = (MaterialPropertyBlock)(object)_CharacterRenderer;
				if ((object)_CharacterRenderer != null)
				{
					MaterialPropertyBlock propBlock2 = _propBlock;
					bool flag2 = characterRenderer.m_Ptr == (IntPtr)0;
					bool flag3 = _propBlock == null;
					MaterialPropertyBlock materialPropertyBlock = null;
					if (!flag3)
					{
						materialPropertyBlock = (MaterialPropertyBlock)(nint)propBlock2.m_Ptr;
					}
					Renderer.Internal_SetPropertyBlock_Injected(characterRenderer.m_Ptr, (IntPtr)materialPropertyBlock);
					TweenConfig tweenConfig = new TweenConfig();
					object[] array = new object[1];
					if ((object)_CharacterRenderer != null)
					{
						Transform transform = _CharacterRenderer.transform;
						if (array != null)
						{
							if ((object)transform != null)
							{
								nint num = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								object obj = default(object);
								bool flag4 = obj == null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							if (tweenConfig != null)
							{
								tweenConfig.targets = array;
								tweenConfig.duration = 750f;
								tweenConfig.ease = Ease.Linear;
								tweenConfig.scaleX = (float?)(object)1;
								MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
								TweenConfig tweenConfig2 = new TweenConfig();
								object[] array2 = new object[1];
								if ((object)_CharacterRenderer != null)
								{
									Transform transform2 = _CharacterRenderer.transform;
									if (array2 != null)
									{
										if ((object)transform2 != null)
										{
											nint num2 = (nint)array2;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj2 = default(object);
											bool flag5 = obj2 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if (tweenConfig2 != null)
										{
											tweenConfig2.targets = array2;
											tweenConfig2.scaleX = (float?)(object)1;
											tweenConfig2.delay = 750f;
											tweenConfig2.duration = 100f;
											tweenConfig2.ease = Ease.Linear;
											MultiTargetTween multiTargetTween2 = Tweens.Add(tweenConfig2);
											TweenConfig tweenConfig3 = new TweenConfig();
											object[] array3 = new object[1];
											if ((object)_CharacterRenderer != null)
											{
												Transform transform3 = _CharacterRenderer.transform;
												if (array3 != null)
												{
													if ((object)transform3 != null)
													{
														nint num3 = (nint)array3;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj3 = default(object);
														bool flag6 = obj3 == null;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if (tweenConfig3 != null)
													{
														tweenConfig3.targets = array3;
														tweenConfig3.scaleY = (float?)(object)1;
														tweenConfig3.duration = 750f;
														tweenConfig3.ease = Ease.Linear;
														MultiTargetTween multiTargetTween3 = Tweens.Add(tweenConfig3);
														TweenConfig tweenConfig4 = new TweenConfig();
														object[] array4 = new object[1];
														if ((object)_CharacterRenderer != null)
														{
															Transform transform4 = _CharacterRenderer.transform;
															if (array4 != null)
															{
																if ((object)transform4 != null)
																{
																	nint num4 = (nint)array4;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																	object obj4 = default(object);
																	bool flag7 = obj4 == null;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
																if (tweenConfig4 != null)
																{
																	tweenConfig4.targets = array4;
																	tweenConfig4.delay = 750f;
																	tweenConfig4.duration = 100f;
																	tweenConfig4.ease = Ease.Linear;
																	tweenConfig4.scaleY = (float?)(object)1;
																	TweenCallback onStart = _003C_003Ec._003C_003E9__23_0;
																	if (_003C_003Ec._003C_003E9__23_0 == null)
																	{
																		onStart = (_003C_003Ec._003C_003E9__23_0 = delegate
																		{
																			//IL_003d: Expected O, but got I4
																			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
																			soundConfig.Volume = (float?)(object)1;
																			soundConfig.Rate = 1f;
																			float time = default(float);
																			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Victory2, soundConfig, 0f, 10, time);
																		});
																	}
																	tweenConfig4.onStart = onStart;
																	MultiTargetTween multiTargetTween4 = Tweens.Add(tweenConfig4);
																	base.ScheduleDeathConsequences();
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

	private void SetupSparkle()
	{
		//IL_009b: Expected O, but got I4
		//IL_01db: Expected O, but got I4
		//IL_031b: Expected O, but got I4
		//IL_039e: Expected O, but got I4
		//IL_0529: Expected O, but got I4
		PhaserSprite sparkSprite = _sparkSprite;
		Vector2 pos = default(Vector2);
		if ((object)_sparkSprite == null || ((UnityEngine.Object)sparkSprite).m_CachedPtr == (IntPtr)0)
		{
			PhaserWorld instance = PhaserWorld.Instance;
			float2 float5 = base.position;
			PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "blurredSharpStar");
			PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0f);
			PhaserSprite phaserSprite3 = phaserSprite2.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite4 = phaserSprite3.setBlendMode(BlendMode.Add);
			if ((object)GM.Core == null)
			{
				goto IL_06a7;
			}
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			PhaserSprite phaserSprite5 = phaserSprite4.setDepth(renderer.height);
			GameObject gameObject = phaserSprite5.gameObject;
			((UnityEngine.Object)gameObject).SetName("sparkSprite");
			_sparkSprite = phaserSprite5;
		}
		PhaserSprite ringSprite = _ringSprite;
		if ((object)_ringSprite == null || ((UnityEngine.Object)ringSprite).m_CachedPtr == (IntPtr)0)
		{
			PhaserWorld instance2 = PhaserWorld.Instance;
			float2 float6 = base.position;
			PhaserSprite phaserSprite6 = instance2.AddPhaserSprite(pos, "vfx", "disc");
			PhaserSprite phaserSprite7 = phaserSprite6.setAlpha(0f);
			PhaserSprite phaserSprite8 = phaserSprite7.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite9 = phaserSprite8.setBlendMode(BlendMode.Add);
			if ((object)GM.Core == null)
			{
				goto IL_06a7;
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer2 = s_scene2._renderer;
			PhaserSprite phaserSprite10 = phaserSprite9.setDepth(renderer2.height);
			GameObject gameObject2 = phaserSprite10.gameObject;
			((UnityEngine.Object)gameObject2).SetName("ringSprite");
			_ringSprite = phaserSprite10;
		}
		PhaserSprite darkSprite = _darkSprite;
		if ((object)_darkSprite != null && ((UnityEngine.Object)darkSprite).m_CachedPtr != (IntPtr)0)
		{
			goto IL_044d;
		}
		PhaserWorld instance3 = PhaserWorld.Instance;
		float2 float7 = base.position;
		PhaserSprite phaserSprite11 = instance3.AddPhaserSprite(pos, "vfx", "blackDot");
		PhaserSprite phaserSprite12 = phaserSprite11.setAlpha(0f);
		PhaserSprite phaserSprite13 = phaserSprite12.setOrigin(0f, (float?)(object)0);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer3 = s_scene3._renderer;
			if ((object)GM.Core != null)
			{
				float xScale = renderer3.width * 100f;
				PhaserSprite phaserSprite14 = phaserSprite13.setScale(xScale, (float?)(object)1);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene4 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer4 = s_scene4._renderer;
					float num = renderer4.height - 1f;
					PhaserSprite component = phaserSprite14.setDepth(num);
					PhaserSprite phaserSprite15 = RenderingExtensions.SetScrollFactor(component, 0f);
					GameObject gameObject3 = phaserSprite15.gameObject;
					((UnityEngine.Object)gameObject3).SetName("darkSprite");
					_darkSprite = phaserSprite15;
					goto IL_044d;
				}
			}
		}
		goto IL_06a7;
		IL_06a7:
		throw new NullReferenceException();
		IL_0657:
		int num2 = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Burst", 1, 6, "vfx", num2);
		bool flag = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_burstSpriteAnim.AddAnimation("enter", animationFrames, 30, (byte)num2 != 0, flag, onComplete, autoSetAnimation);
		return;
		IL_044d:
		PhaserSprite burstSprite = _burstSprite;
		if ((object)_burstSprite == null || ((UnityEngine.Object)burstSprite).m_CachedPtr == (IntPtr)0)
		{
			PhaserWorld instance4 = PhaserWorld.Instance;
			if ((object)GM.Core != null && (object)GM.Core != null)
			{
				PhaserSprite phaserSprite16 = instance4.AddPhaserSprite(pos, "vfx", "Burst1");
				PhaserSprite phaserSprite17 = phaserSprite16.setAlpha(0f);
				PhaserSprite phaserSprite18 = phaserSprite17.setScale(10f, (float?)(object)0);
				PhaserSprite phaserSprite19 = phaserSprite18.setBlendMode(BlendMode.Add);
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene5 = ArcadePhysics.s_scene;
					PhaserScene.Renderer renderer5 = s_scene5._renderer;
					PhaserSprite component2 = phaserSprite19.setDepth(renderer5.height);
					PhaserSprite phaserSprite20 = RenderingExtensions.SetScrollFactor(component2, 0f);
					GameObject gameObject4 = phaserSprite20.gameObject;
					((UnityEngine.Object)gameObject4).SetName("burstSprite");
					PhaserSprite burstSprite2 = phaserSprite20.setTint(65280u, 255u, 16776960u, (uint)num2, flag ? BlendMode.Add : BlendMode.Normal);
					_burstSprite = burstSprite2;
					PhaserSprite burstSprite3 = _burstSprite;
					GameObject gameObject5 = burstSprite3._spriteRenderer.gameObject;
					SpriteAnimation burstSpriteAnim = gameObject5.AddComponent<SpriteAnimation>();
					_burstSpriteAnim = burstSpriteAnim;
					num2 = num2;
					goto IL_0657;
				}
			}
			goto IL_06a7;
		}
		goto IL_0657;
	}

	private unsafe void PlaySparkle()
	{
		//IL_00a6: Expected I, but got O
		//IL_010a: Expected O, but got I4
		//IL_0118: Expected O, but got I4
		//IL_0126: Expected O, but got I4
		//IL_01e7: Expected I, but got O
		//IL_0259: Expected O, but got I4
		//IL_031a: Expected I, but got O
		//IL_0370: Expected O, but got I4
		//IL_037e: Expected O, but got I4
		//IL_038c: Expected O, but got I4
		//IL_03a8: Expected O, but got I4
		_burstSpriteAnim.SetAnimation("enter");
		PhaserSprite phaserSprite = _burstSprite.setAlpha(1f);
		if (_ringTween != null)
		{
			_ringTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_ringSprite != null)
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
		tweenConfig.duration = 200f;
		tweenConfig.scaleX = (float?)(object)1;
		tweenConfig.scaleY = (float?)(object)1;
		tweenConfig.alpha = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			//IL_0015: Expected O, but got I4
			PhaserSprite phaserSprite2 = _ringSprite.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite3 = _ringSprite.setAlpha(1f);
		};
		tweenConfig.onStart = onStart;
		MultiTargetTween ringTween = Tweens.Add(tweenConfig);
		_ringTween = ringTween;
		if (_darkTween != null)
		{
			_darkTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		if ((object)_darkSprite != null)
		{
			nint num2 = (nint)array2;
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
		tweenConfig2.duration = 100f;
		tweenConfig2.yoyo = true;
		tweenConfig2.alpha = (float?)(object)1;
		TweenCallback onStart2 = delegate
		{
			PhaserSprite phaserSprite2 = _darkSprite.setAlpha(0f);
		};
		tweenConfig2.onStart = onStart2;
		MultiTargetTween darkTween = Tweens.Add(tweenConfig2);
		_darkTween = darkTween;
		if (_sparkTween != null)
		{
			_sparkTween.Kill();
		}
		TweenConfig tweenConfig3 = new TweenConfig();
		object[] array3 = new object[1];
		if ((object)_sparkSprite != null)
		{
			nint num3 = (nint)array3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig3.targets = array3;
		tweenConfig3.scaleX = (float?)(object)1;
		tweenConfig3.scaleY = (float?)(object)1;
		tweenConfig3.alpha = (float?)(object)1;
		tweenConfig3.duration = 200f;
		tweenConfig3.angle = (float?)(object)1;
		TweenCallback onStart3 = delegate
		{
			//IL_001a: Expected O, but got I4
			//IL_005d: Expected O, but got Ref
			PhaserSprite phaserSprite2 = _sparkSprite.setScale(0f, (float?)(object)0);
			PhaserSprite phaserSprite3 = _sparkSprite.setAlpha(1f);
			Transform transform = _sparkSprite.transform;
			object obj4 = default(object);
			transform.localEulerAngles = (Vector3)(&obj4);
		};
		tweenConfig3.onStart = onStart3;
		TweenCallback onUpdate = delegate
		{
			//IL_001e: Expected F4, but got O
			//IL_006a: Expected F4, but got O
			float2 float5 = base.position;
			_sparkSprite.X = (float)float5;
			float2 float6 = base.position;
			object obj4 = default(object);
			float y = (float)obj4 + 0.19999999f;
			_sparkSprite.Y = y;
			float2 float7 = base.position;
			_ringSprite.X = (float)float7;
			float2 float8 = base.position;
			float y2 = (float)obj4 + 0.19999999f;
			_ringSprite.Y = y2;
		};
		tweenConfig3.onUpdate = onUpdate;
		TweenCallback onComplete = delegate
		{
			PhaserSprite phaserSprite2 = _ringSprite.setAlpha(0f);
			PhaserSprite phaserSprite3 = _sparkSprite.setAlpha(0f);
		};
		tweenConfig3.onComplete = onComplete;
		MultiTargetTween sparkTween = Tweens.Add(tweenConfig3);
		_sparkTween = sparkTween;
	}

	private unsafe void CreateMegaloDeathSprites()
	{
		//IL_0026: Expected O, but got Ref
		//IL_04d3: Expected O, but got Ref
		//IL_02da: Expected O, but got I4
		//IL_04b6->IL06a9: Incompatible stack heights: 4 vs 2
		CheckRenderer();
		Transform transform = ((ArcadeSprite)this)._spriteRenderer.transform;
		Vector2 ret = default(Vector2);
		transform.localEulerAngles = (Vector3)(&ret);
		PhaserWorld instance = PhaserWorld.Instance;
		float2 float5 = base.position;
		Vector2 vector = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(vector, "TP_Death", "TP_Death_Mask");
		CheckRenderer();
		Transform parent = ((ArcadeSprite)this)._spriteRenderer.transform;
		Transform transform2 = phaserSprite.transform;
		transform2.SetParent(parent, worldPositionStays: true);
		_deathMask = phaserSprite;
		PhaserSprite deathMask = _deathMask;
		GameObject gameObject = deathMask._spriteRenderer.gameObject;
		SpriteTrail spriteTrail = gameObject.AddComponent<SpriteTrail>();
		PhaserSprite deathMask2 = _deathMask;
		spriteTrail._MainSprite = deathMask2._spriteRenderer;
		spriteTrail._DefaultGhostAlpha = 0.65f;
		spriteTrail._AlphaDecayPerGhost = 0.05f;
		spriteTrail._AutoUpdateDepth = true;
		spriteTrail._MaxHistory = 10;
		spriteTrail.InitialiseGhosts(expandExisting: true);
		int num = 0;
		ret = vector;
		bool flag;
		do
		{
			SpriteTrail spriteTrail2 = spriteTrail.SetTint(num, (Color)(&ret));
			num++;
			flag = num < 10;
			ret = vector;
		}
		while (flag);
		PhaserWorld instance2 = PhaserWorld.Instance;
		float2 float6 = base.position;
		PhaserSprite phaserSprite2 = instance2.AddPhaserSprite(vector, "TP_Death", "TP_Death_Spine");
		bool flag2 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
		Transform parent2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
		Transform transform3 = phaserSprite2.transform;
		transform3.SetParent(parent2, worldPositionStays: true);
		_deathSpine = phaserSprite2;
		PhaserWorld instance3 = PhaserWorld.Instance;
		float2 float7 = base.position;
		PhaserSprite phaserSprite3 = instance3.AddPhaserSprite(vector, "TP_Death", "TP_Death_Cape");
		bool flag3 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
		Transform parent3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
		Transform transform4 = phaserSprite3.transform;
		transform4.SetParent(parent3, worldPositionStays: true);
		_deathCape = phaserSprite3;
		PhaserSprite deathCape = _deathCape;
		int num2 = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_Death_Cape", 1, 5, "TP_Death", num2);
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		deathCape._spriteAnimation.AddAnimation("Flutter", animationFrames, 8, (byte)num2 != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite deathCape2 = _deathCape;
		SpriteAnimation spriteAnimation = deathCape2._spriteAnimation;
		spriteAnimation._originalSpriteSize = (float2)1128267776;
		_ = 1125122048;
		PhaserSprite deathCape3 = _deathCape;
		deathCape3._spriteAnimation.SetAnimation("Flutter");
		float2 float8 = base.position;
		GameObject gameObject2 = base.gameObject;
		PhaserSprite leftEye = RenderingExtensions.AddPhaserSprite(gameObject2, vector, "TP_Death", "TP_Death_Eye");
		_leftEye = leftEye;
		float2 float9 = base.position;
		GameObject gameObject3 = base.gameObject;
		PhaserSprite rightEye = RenderingExtensions.AddPhaserSprite(gameObject3, vector, "TP_Death", "TP_Death_Eye");
		_rightEye = rightEye;
		float2 float10 = base.position;
		Component component = _leftEye;
		string text = "TP_Death_Eye";
		int num3 = 0;
		float num5 = default(float);
		float num4 = num5;
		Vector2 vector2 = default(Vector2);
		object obj2 = default(object);
		while (true)
		{
			PhaserSprite deathMask3 = _deathMask;
			bool flag4 = ((UnityEngine.Object)deathMask3).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr3 = Component.get_transform_Injected(((UnityEngine.Object)deathMask3).m_CachedPtr);
			Transform transform5 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
			bool flag5 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
			Transform.TransformPoint_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Vector3*)(&vector2), out *(Vector3*)(&ret));
			object obj = (object)float10 - (object)ret;
			float num6 = num5 - (float)obj2;
			float num7 = (float)obj * 0.025f;
			float num8 = num6 * 0.025f;
			num4 = num7 * num7;
			float num9 = num8 * num8;
			float num10 = num9 + num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
			if (num10 > 0.05f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186252410");
			}
			Transform transform6 = component.transform;
			Transform parent4 = _deathMask.transform;
			transform6.SetParent(parent4, worldPositionStays: true);
			((UnityEngine.Object)component).SetName("Eye");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			PhaserSprite deathMask4 = _deathMask;
			int sortingOrder = deathMask4._spriteRenderer.sortingOrder;
			int num11 = sortingOrder + 1;
			PhaserSprite phaserSprite4 = ((PhaserSprite)component).setDepth(num11);
			component = _rightEye;
			num3++;
			if (num3 < 2)
			{
				text = null;
				continue;
			}
			break;
		}
	}

	private void UpdateMegaloDeathParts()
	{
		//IL_02ba: Expected O, but got I4
		//IL_02c3: Expected O, but got I4
		//IL_02cc: Expected O, but got I4
		//IL_053a: Expected O, but got I
		//IL_0309: Expected O, but got I
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Expected O, but got Unknown
		//IL_056d: Expected O, but got F4
		//IL_057d: Expected F4, but got I
		//IL_036a: Expected F4, but got I4
		//IL_06a7: Expected I, but got O
		//IL_05c1: Expected O, but got F4
		//IL_06e2: Expected F4, but got O
		//IL_06e2: Expected F4, but got I
		//IL_06e6: Expected O, but got F4
		//IL_05d4: Expected F4, but got O
		//IL_05d4: Expected F4, but got I
		//IL_05d8: Expected O, but got F4
		//IL_0708: Expected F4, but got O
		//IL_0708: Expected F4, but got I
		//IL_070c: Expected O, but got F4
		//IL_05fa: Expected F4, but got O
		//IL_05fa: Expected F4, but got I
		//IL_05fe: Expected O, but got F4
		//IL_0665: Expected O, but got F4
		//IL_0388: Expected F4, but got I4
		//IL_0742: Expected O, but got I
		//IL_03c5: Expected O, but got I
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Expected O, but got Unknown
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Expected O, but got Unknown
		//IL_0440->IL0672: Incompatible stack heights: 7 vs 3
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		CheckRenderer();
		SpriteTrail component = ((ArcadeSprite)this)._spriteRenderer.GetComponent<SpriteTrail>();
		SpriteTrail spriteTrail = component.setVisible(b: false);
		PhaserSprite phaserSprite = _deathMask.setVisible(visible: true);
		CheckRenderer();
		Transform parent = ((ArcadeSprite)this)._spriteRenderer.transform;
		Transform transform = _deathMask.transform;
		transform.SetParent(parent, worldPositionStays: true);
		CheckRenderer();
		Transform transform2 = ((ArcadeSprite)this)._spriteRenderer.transform;
		bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
		object obj = default(object);
		float num = (float)obj + 0.55f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		int num2 = base.depth;
		int num3 = num2 + 400;
		PhaserSprite phaserSprite2 = _deathMask.setDepth(num3);
		PhaserSprite phaserSprite3 = _deathCape.setVisible(visible: false);
		int num4 = base.depth;
		int num5 = num4 + 1;
		PhaserSprite phaserSprite4 = _deathCape.setDepth(num5);
		CheckRenderer();
		Transform parent2 = ((ArcadeSprite)this)._spriteRenderer.transform;
		Transform transform3 = _deathCape.transform;
		transform3.SetParent(parent2, worldPositionStays: true);
		CheckRenderer();
		Transform transform4 = ((ArcadeSprite)this)._spriteRenderer.transform;
		bool flag2 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out ret);
		float num6 = (float)obj + 0.9f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		int num7 = base.depth;
		int num8 = num7 + 1;
		PhaserSprite phaserSprite5 = _deathSpine.setDepth(num8);
		CheckRenderer();
		Transform parent3 = ((ArcadeSprite)this)._spriteRenderer.transform;
		Transform transform5 = _deathSpine.transform;
		transform5.SetParent(parent3, worldPositionStays: true);
		CheckRenderer();
		Transform transform6 = ((ArcadeSprite)this)._spriteRenderer.transform;
		bool flag3 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform6).m_CachedPtr, out ret);
		float num9 = (float)obj + 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		PhaserSprite phaserSprite6 = _deathSpine.setVisible(visible: false);
		UpdateEyes();
		PhaserSprite deathMask = _deathMask;
		GameObject gameObject = deathMask._spriteRenderer.gameObject;
		SpriteTrail component2 = gameObject.GetComponent<SpriteTrail>();
		object obj2 = 0;
		object obj3 = 0;
		object obj4 = 0;
		while (true)
		{
			object obj5 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rax_v92 (VampireSurvivors.Graphics.SpriteTrail)+30]");
			if ((nint)obj5 >= 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rax_v92 (VampireSurvivors.Graphics.SpriteTrail)+60]");
			object obj6 = 0;
			object obj7 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rdx_v69+18]");
			bool flag4 = (nint)obj7 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rdx_v69+10]");
			object obj8 = 0;
			object obj9 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rdx_v70+18]");
			bool flag5 = (nint)obj9 >= 0;
			object obj10 = obj4 * 2;
			object obj11 = obj4 + obj10;
			float num10 = (float)obj4 * 3.14f;
			float num11;
			if (PauseSystem._paused)
			{
				num11 = 0f;
			}
			else
			{
				object obj12 = Time.time;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rdx_v70+20+v1732 @ rcx_v89*4]");
				num11 = 0f;
			}
			nint num12 = (nint)typeof(PauseSystem);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1806 @ rax_v100 (Il2CppClass<PauseSystem>)+B8]");
			nint num13 = 0;
			if (!PauseSystem._paused)
			{
				object obj13 = Time.time;
			}
			float num14 = num11 * 0.125f;
			float num15 = num14 + num10;
			float num16 = num15 + 0.1f;
			object obj14 = Mathf.PerlinNoise(num13, (float)obj8);
			float num17 = num15 - 0.1f;
			object obj15 = Mathf.PerlinNoise(num13, (float)obj8);
			object obj16 = Mathf.PerlinNoise(num13, (float)obj8);
			float num18 = num16 - num17;
			object obj17 = Mathf.PerlinNoise(num13, (float)obj8);
			float num19 = num15 - num15;
			float num20;
			if (PauseSystem._paused)
			{
				num20 = 0f;
			}
			else
			{
				object obj18 = Time.deltaTime;
				num20 = num15;
			}
			float num21 = num20 * num18;
			num9 = num20 * num19;
			float num22 = num20 * 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rdx_v70+28+v1732 @ rcx_v89*4]");
			float num23 = 0f + num22;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rax_v92 (VampireSurvivors.Graphics.SpriteTrail)+60]");
			object obj19 = 0;
			object obj20 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rdx_v71+18]");
			bool flag6 = (nint)obj20 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rdx_v71+10]");
			obj2 = 0;
			object obj21 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ r8_v27+18]");
			bool flag7 = (nint)obj21 >= 0;
			object obj22 = obj4 * 2;
			object obj23 = obj4 + obj22;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rdx_v71+1C]");
			_ = (nint)0 + (nint)1;
			obj4++;
			obj3 = obj4;
		}
	}

	private unsafe void UpdateEyes()
	{
		//IL_0076: Expected O, but got Ref
		//IL_0333: Expected O, but got I4
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Expected O, but got Unknown
		//IL_03cd->IL02a0: Incompatible stack heights: 1 vs 0
		//IL_0378->IL0329: Incompatible stack heights: 1 vs 0
		//IL_04be->IL02a0: Incompatible stack heights: 2 vs 0
		//IL_01bf->IL02a0: Incompatible stack heights: 2 vs 0
		//IL_01e1->IL02a0: Incompatible stack heights: 2 vs 0
		//IL_0250->IL04c3: Incompatible stack heights: 2 vs 0
		PhaserSprite phaserSprite = _leftEye;
		float2 float5 = base.position;
		GameManager core = GM.Core;
		Vector3 ret2 = default(Vector3);
		float2 float6;
		if ((object)GM.Core != null && (object)_deathMask != null)
		{
			Transform transform = _deathMask.transform;
			if ((object)transform != null)
			{
				if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
				}
				else
				{
					float2 ret;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
					if ((object)core._stage != null)
					{
						EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&ret2), excludeDead: true);
						bool flag = (object)enemyController == null;
						float6 = float5;
						if (!flag)
						{
							bool flag2 = ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0;
							float6 = float5;
							if (!flag2)
							{
								((ArcadeSprite)enemyController).CheckRenderer();
								if ((object)((ArcadeSprite)enemyController)._spriteRenderer != null)
								{
									Transform transform2 = ((ArcadeSprite)enemyController)._spriteRenderer.transform;
									if ((object)transform2 != null)
									{
										bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
										Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out *(Vector3*)(&ret));
										float2 float7 = default(float2);
										float6 = float7;
										goto IL_0329;
									}
								}
								goto IL_02a0;
							}
						}
						goto IL_0329;
					}
				}
			}
		}
		goto IL_02a0;
		IL_02a0:
		throw new NullReferenceException();
		IL_0329:
		object obj = 0;
		float2 float8 = default(float2);
		object obj4 = default(object);
		object obj5 = default(object);
		object obj6 = default(object);
		while (true)
		{
			Transform deathMask = (Transform)(object)_deathMask;
			if ((object)_deathMask == null)
			{
				break;
			}
			bool flag4 = ((UnityEngine.Object)deathMask).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)deathMask).m_CachedPtr);
			Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			if ((object)transform3 == null)
			{
				break;
			}
			bool flag5 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
			Transform.TransformPoint_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)(&float8), out ret2);
			object obj2 = (object)float6 - (object)ret2;
			object obj3 = obj4 - obj5;
			float num = (float)obj2 * 0.025f;
			float num2 = (float)obj3 * 0.025f;
			float num3 = num * num;
			float num4 = num2 * num2;
			float num5 = num3 + num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
			if (num5 > 0.05f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186252410");
				num2 = (float)obj6 * 0.05f;
			}
			float num6 = (float)obj5 + num2;
			if ((object)phaserSprite == null)
			{
				break;
			}
			float2 float9 = phaserSprite.position;
			float num7 = num6 - (float)obj6;
			float num8 = num7 * 0.1f;
			float num9 = (float)obj6 + num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
			PhaserSprite deathMask2 = _deathMask;
			if ((object)_deathMask == null || (object)deathMask2._spriteRenderer == null)
			{
				break;
			}
			int sortingOrder = deathMask2._spriteRenderer.sortingOrder;
			int num10 = sortingOrder + 1;
			PhaserSprite phaserSprite2 = phaserSprite.setDepth(num10);
			phaserSprite = _rightEye;
			obj++;
			if ((nint)obj >= 2)
			{
				return;
			}
		}
		goto IL_02a0;
	}

	private void _003CPlaySparkle_003Eb__25_0()
	{
		//IL_0015: Expected O, but got I4
		PhaserSprite phaserSprite = _ringSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _ringSprite.setAlpha(1f);
	}

	private void _003CPlaySparkle_003Eb__25_1()
	{
		PhaserSprite phaserSprite = _darkSprite.setAlpha(0f);
	}

	private unsafe void _003CPlaySparkle_003Eb__25_2()
	{
		//IL_001a: Expected O, but got I4
		//IL_005d: Expected O, but got Ref
		PhaserSprite phaserSprite = _sparkSprite.setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite2 = _sparkSprite.setAlpha(1f);
		Transform transform = _sparkSprite.transform;
		object obj = default(object);
		transform.localEulerAngles = (Vector3)(&obj);
	}

	private void _003CPlaySparkle_003Eb__25_3()
	{
		//IL_001e: Expected F4, but got O
		//IL_006a: Expected F4, but got O
		float2 float5 = base.position;
		_sparkSprite.X = (float)float5;
		float2 float6 = base.position;
		object obj = default(object);
		float y = (float)obj + 0.19999999f;
		_sparkSprite.Y = y;
		float2 float7 = base.position;
		_ringSprite.X = (float)float7;
		float2 float8 = base.position;
		float y2 = (float)obj + 0.19999999f;
		_ringSprite.Y = y2;
	}

	private void _003CPlaySparkle_003Eb__25_4()
	{
		PhaserSprite phaserSprite = _ringSprite.setAlpha(0f);
		PhaserSprite phaserSprite2 = _sparkSprite.setAlpha(0f);
	}
}
