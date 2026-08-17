using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects.Characters;

public class EME_CharacterControllerShowstopper : CharacterController
{
	private float _mightBonus;

	private float _cooldownBonus;

	private float _luckBonus;

	private float _morphDuration = 13000f;

	private bool _isMorphed;

	private bool _hasBonusApplied;

	private EME_ShowstopperVfx _showStoperVfx;

	private BgmType _playerCurrentMusic;

	private BgmModType _playerCurrentbgmMod;

	private Timer _showstopperTimer;

	private Timer _showstopperMusicTimer;

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		_isMorphed = false;
		_mightBonus = 0f;
		_luckBonus = 0f;
	}

	public override void AfterFullInitialization()
	{
		//IL_0140->IL00b4: Incompatible stack heights: 1 vs 0
		//IL_0062->IL00b4: Incompatible stack heights: 1 vs 0
		//IL_018f->IL00b4: Incompatible stack heights: 2 vs 0
		base.AfterFullInitialization();
		SpriteAnimation spriteAnimation = _spriteAnimation;
		CheckRenderer();
		if ((object)((ArcadeSprite)this)._spriteRenderer != null)
		{
			Sprite sprite = ((ArcadeSprite)this)._spriteRenderer.sprite;
			if ((object)sprite != null)
			{
				bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
				Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
				CheckRenderer();
				if ((object)((ArcadeSprite)this)._spriteRenderer != null)
				{
					Sprite sprite2 = ((ArcadeSprite)this)._spriteRenderer.sprite;
					if ((object)sprite2 != null)
					{
						bool flag2 = ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0;
						Sprite.get_rect_Injected(((UnityEngine.Object)sprite2).m_CachedPtr, out Rect _);
						if ((object)_spriteAnimation != null)
						{
							float2 originalSpriteSize = default(float2);
							spriteAnimation._originalSpriteSize = originalSpriteSize;
							base._isCriticalHPEnabled = true;
							Action onCriticalHP = CriticalHP;
							base._onCriticalHP = onCriticalHP;
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void CriticalHP()
	{
		StartShowstopper();
	}

	protected virtual void OnShowStopperStarted()
	{
	}

	protected unsafe void StartShowstopper()
	{
		//IL_0030: Expected O, but got I4
		//IL_03d7: Expected I4, but got F4
		//IL_0440: Expected O, but got Ref
		//IL_04a4: Expected I4, but got F4
		//IL_07de: Expected I, but got O
		//IL_0520: Expected F4, but got O
		//IL_059b: Expected F4, but got O
		//IL_0608: Expected I4, but got F4
		//IL_061f: Expected F4, but got O
		//IL_0780->IL06ee: Incompatible stack heights: 1 vs 0
		//IL_046d->IL06ee: Incompatible stack heights: 1 vs 0
		//IL_04f7->IL06ee: Incompatible stack heights: 1 vs 0
		//IL_06ee->IL084a: Incompatible stack heights: 1 vs 0
		//IL_0801->IL06ee: Incompatible stack heights: 1 vs 0
		//IL_0572->IL06ee: Incompatible stack heights: 1 vs 0
		//IL_0823->IL06ee: Incompatible stack heights: 1 vs 0
		//IL_05ee->IL06ee: Incompatible stack heights: 1 vs 0
		//IL_0845->IL06ee: Incompatible stack heights: 1 vs 0
		if (_isMorphed)
		{
			return;
		}
		OnShowStopperStarted();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 0.5f;
		soundConfig.Volume = (float?)(object)1;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				if (config._003CSelectedBGM_003Ek__BackingField == BgmType.BGM_EME_SHOW)
				{
					goto IL_0717;
				}
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null && core2._playerOptions != null)
				{
					PlayerOptionsData config2 = core2._playerOptions.Config;
					if (config2 != null)
					{
						_playerCurrentMusic = config2._003CSelectedBGM_003Ek__BackingField;
						GameManager core3 = GM.Core;
						if ((object)GM.Core != null && core3._playerOptions != null)
						{
							PlayerOptionsData config3 = core3._playerOptions.Config;
							if (config3 != null)
							{
								_playerCurrentbgmMod = config3._003CSelectedBGMMod_003Ek__BackingField;
								goto IL_0717;
							}
						}
					}
				}
			}
		}
		goto IL_06ee;
		IL_06ee:
		throw new NullReferenceException();
		IL_0785:
		base.IsInvul = true;
		float num2 = _morphDuration * 0.001f;
		float invincibilityTimer = num2 + base._invincibilityTimer;
		base._invincibilityTimer = invincibilityTimer;
		base.RestoreTint();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1069 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Characters.EME_CharacterControllerShowstopper>)+620]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num3 = (nint)this;
		bool useRealTime;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.010000001f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = Unmorph;
		float duration = _morphDuration * 0.001f;
		Timer timer2 = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		return;
		IL_0717:
		GameManager core4 = GM.Core;
		if ((object)GM.Core != null && core4._playerOptions != null)
		{
			PlayerOptionsData config4 = core4._playerOptions.Config;
			if (config4 != null)
			{
				config4._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_EME_SHOW;
				GameManager core5 = GM.Core;
				if ((object)GM.Core != null && core5._playerOptions != null)
				{
					PlayerOptionsData config5 = core5._playerOptions.Config;
					if (config5 != null)
					{
						config5._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
						if ((object)GM.Core != null)
						{
							GM.Core.SetupMusicBanger();
							if (_showstopperMusicTimer != null)
							{
								_showstopperMusicTimer.Cancel();
							}
							if (_showstopperTimer != null)
							{
								_showstopperTimer.Cancel();
							}
							Action onComplete3 = delegate
							{
								SoundManager.FadeMusic(BgmType.BGM_EME_SHOW, 0f, 3000f);
								if (_showstopperMusicTimer != null)
								{
									_showstopperMusicTimer.Cancel();
								}
								Action onComplete4 = delegate
								{
									GameManager core6 = GM.Core;
									PlayerOptionsData config6 = core6._playerOptions.Config;
									config6._003CSelectedBGM_003Ek__BackingField = _playerCurrentMusic;
									GameManager core7 = GM.Core;
									PlayerOptionsData config7 = core7._playerOptions.Config;
									config7._003CSelectedBGMMod_003Ek__BackingField = _playerCurrentbgmMod;
									GM.Core.SetupMusicBanger();
								};
								bool useRealTime2 = default(bool);
								MonoBehaviour autoDestroyOwner2 = default(MonoBehaviour);
								int repeat2 = default(int);
								TimerType type2 = default(TimerType);
								Timer showstopperMusicTimer = Timers.Register(3.0000002f, onComplete4, null, isLooped: false, useRealTime2, autoDestroyOwner2, repeat2, type2, isOnlineTimer: false, canPause: false);
								_showstopperMusicTimer = showstopperMusicTimer;
							};
							float num4 = _morphDuration - 3000f;
							float duration2 = num4 * 0.001f;
							Timer showstopperTimer = Timers.Register(duration2, onComplete3, null, isLooped: false, (byte)(int)num != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							_showstopperTimer = showstopperTimer;
							ObjectPool pool = HeroVfxManager.GetPool(HeroVfxType.EME_ShowVfx);
							Transform transform = base.transform;
							if ((object)transform != null)
							{
								bool flag = (byte)(~(((SoundManager.SoundConfig)(object)transform).Mute ? 1u : 0u)) != 0;
								Transform.get_position_Injected((IntPtr)(((SoundManager.SoundConfig)(object)transform).Mute ? 1 : 0), out Vector3 _);
								if ((object)pool != null)
								{
									object obj = default(object);
									EME_ShowstopperVfx objectComponent = pool.GetObjectComponent<EME_ShowstopperVfx>((Vector3)(&obj));
									_showStoperVfx = objectComponent;
									if ((object)_showStoperVfx != null)
									{
										_showStoperVfx.Reset();
										_isMorphed = true;
										bool flag2 = _hasBonusApplied;
										useRealTime = (byte)(int)num != 0;
										if (flag2)
										{
											goto IL_0785;
										}
										PlayerModifierStats playerStats = _playerStats;
										_cooldownBonus = -1f;
										_mightBonus = 1f;
										_luckBonus = 1f;
										if (_playerStats != null)
										{
											SoundManager.SoundConfig soundConfig2 = (SoundManager.SoundConfig)(object)playerStats._003CCooldown_003Ek__BackingField;
											if (playerStats._003CCooldown_003Ek__BackingField != null)
											{
												float value = default(float);
												EggFloat cooldown = new EggFloat(value, (float)soundConfig2.Volume);
												value = (float)(soundConfig2.Mute ? 1 : 0) - 1f;
												_playerStats.Cooldown = cooldown;
												PlayerModifierStats playerStats2 = _playerStats;
												if (_playerStats != null)
												{
													SoundManager.SoundConfig soundConfig3 = (SoundManager.SoundConfig)(object)playerStats2._003CPower_003Ek__BackingField;
													if (playerStats2._003CPower_003Ek__BackingField != null)
													{
														float value2 = default(float);
														EggFloat power = new EggFloat(value2, (float)soundConfig3.Volume);
														value2 = (float)(soundConfig3.Mute ? 1 : 0) + _mightBonus;
														_playerStats.Power = power;
														PlayerModifierStats playerStats3 = _playerStats;
														if (_playerStats != null)
														{
															SoundManager.SoundConfig soundConfig4 = (SoundManager.SoundConfig)(object)playerStats3._003CLuck_003Ek__BackingField;
															useRealTime = (byte)(int)num != 0;
															if (playerStats3._003CLuck_003Ek__BackingField != null)
															{
																float value3 = default(float);
																EggFloat luck = new EggFloat(value3, (float)soundConfig4.Volume);
																value3 = (float)(soundConfig4.Mute ? 1 : 0) + _luckBonus;
																_playerStats.Luck = luck;
																_hasBonusApplied = true;
																goto IL_0785;
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
		goto IL_06ee;
	}

	private void Unmorph()
	{
		if (_hasBonusApplied)
		{
			PlayerModifierStats playerStats = _playerStats;
			EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
			float value = default(float);
			EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val - _cooldownBonus;
			playerStats._003CCooldown_003Ek__BackingField = eggFloat2;
			PlayerModifierStats playerStats2 = _playerStats;
			EggFloat eggFloat3 = playerStats2._003CPower_003Ek__BackingField;
			float value2 = default(float);
			EggFloat eggFloat4 = new EggFloat(value2, eggFloat3._eggVal);
			value2 = eggFloat3._val - _mightBonus;
			playerStats2._003CPower_003Ek__BackingField = eggFloat4;
			PlayerModifierStats playerStats3 = _playerStats;
			EggFloat eggFloat5 = playerStats3._003CLuck_003Ek__BackingField;
			float value3 = default(float);
			EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
			value3 = eggFloat5._val - _luckBonus;
			playerStats3._003CLuck_003Ek__BackingField = eggFloat6;
			_hasBonusApplied = false;
		}
		EME_ShowstopperVfx showStoperVfx = _showStoperVfx;
		if ((object)_showStoperVfx != null && ((UnityEngine.Object)showStoperVfx).m_CachedPtr != (IntPtr)0)
		{
			_showStoperVfx.FadeOut();
			_showStoperVfx = null;
		}
		_isMorphed = false;
	}

	private void _003CStartShowstopper_003Eb__15_0()
	{
		SoundManager.FadeMusic(BgmType.BGM_EME_SHOW, 0f, 3000f);
		if (_showstopperMusicTimer != null)
		{
			_showstopperMusicTimer.Cancel();
		}
		Action onComplete = delegate
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			config._003CSelectedBGM_003Ek__BackingField = _playerCurrentMusic;
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			config2._003CSelectedBGMMod_003Ek__BackingField = _playerCurrentbgmMod;
			GM.Core.SetupMusicBanger();
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer showstopperMusicTimer = Timers.Register(3.0000002f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_showstopperMusicTimer = showstopperMusicTimer;
	}

	private void _003CStartShowstopper_003Eb__15_1()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		config._003CSelectedBGM_003Ek__BackingField = _playerCurrentMusic;
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		config2._003CSelectedBGMMod_003Ek__BackingField = _playerCurrentbgmMod;
		GM.Core.SetupMusicBanger();
	}
}
