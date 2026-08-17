using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Objects;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerMegaloMenya : CharacterController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__6_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COnDeath_003Eb__6_0()
		{
			//IL_003d: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Victory2, soundConfig, 0f, 10, time);
		}
	}

	public override bool NeedsCart => false;

	public override void LevelUp()
	{
		base.LevelUp();
		float num = (float)base._level / 10f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		Weapon weaponByType = base._weaponsManager.GetWeaponByType(WeaponType.BOCCE, searchHidden: true);
		object obj = default(object);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0 && ((Equipment)weaponByType)._003CLevel_003Ek__BackingField < (nint)obj && ((Equipment)weaponByType)._003CLevel_003Ek__BackingField < 8)
		{
			bool flag = weaponByType.LevelUp();
		}
	}

	public override bool GetDamaged(float damageAmount)
	{
		base.IsInvul = true;
		return base.GetDamaged(damageAmount);
	}

	protected override void OnStop()
	{
		if (_wiggleTween != null)
		{
			_wiggleTween.Pause();
		}
		base.angle = 0f;
	}

	protected override void OnUpdate()
	{
		//IL_005c: Invalid comparison between F4 and O
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		base.OnUpdate();
		if (!base._isDead && !base.IsDisconnectedFromOnlinePlay)
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
				Die();
			}
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
																	TweenCallback onStart = _003C_003Ec._003C_003E9__6_0;
																	if (_003C_003Ec._003C_003E9__6_0 == null)
																	{
																		onStart = (_003C_003Ec._003C_003E9__6_0 = delegate
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
}
