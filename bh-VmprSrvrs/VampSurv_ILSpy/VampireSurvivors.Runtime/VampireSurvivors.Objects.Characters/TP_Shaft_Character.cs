using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_Shaft_Character : TP_Character
{
	private float _morphDuration = 20000f;

	private float _cooldownBonus;

	private bool _hasBonusApplied;

	private bool _isMorphed;

	private float _mightBonus;

	private float _curseBonus;

	private MorphVFX _morphVFX;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		((CharacterController)this)._isCriticalHPEnabled = true;
		Action onCriticalHP = CriticalHP;
		((CharacterController)this)._onCriticalHP = onCriticalHP;
		_hasBonusApplied = false;
	}

	private void MakeMorphVFX()
	{
		if (_morphVFX == null)
		{
			MorphVFX morphVFX = new MorphVFX();
			_morphVFX = morphVFX;
			MorphVFX morphVFX2 = _morphVFX;
			morphVFX2._burstTint = new uint[4] { 65280u, 255u, 16776960u, 16711680u };
			MorphVFX morphVFX3 = _morphVFX;
			morphVFX3._sparkName = "blurredSharpStar.png";
			MorphVFX morphVFX4 = _morphVFX;
			morphVFX4._diskName = "disc.png";
			_morphVFX.Make();
		}
	}

	private void CriticalHP()
	{
		//IL_002a: Expected O, but got I4
		//IL_006b: Expected O, but got I4
		//IL_00db: Expected I4, but got F4
		//IL_037b: Expected I4, but got F4
		//IL_03e3: Expected I, but got O
		//IL_022c: Expected I4, but got F4
		if (!_isMorphed)
		{
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 0.5f;
			soundConfig.Volume = (float?)(object)1;
			float num = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Morph, soundConfig, 2000f, 1, num);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Rate = 1f;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.Rosary, soundConfig2, 2000f, 1, num);
			MakeMorphVFX();
			_morphVFX.PlaySparkle(this);
			GameManager core = GM.Core;
			Weapon weapon = core._weaponsFacade.AddHiddenWeapon(WeaponType.TP_SHAFTORB, this, removeFromStore: true, (byte)(int)num != 0);
			if ((object)weapon != null && ((UnityEngine.Object)weapon).m_CachedPtr != (IntPtr)0)
			{
				((Equipment)weapon)._003CShowInRecap_003Ek__BackingField = false;
			}
			_isMorphed = true;
			bool flag = _hasBonusApplied;
			bool useRealTime = (byte)(int)num != 0;
			if (!flag)
			{
				PlayerModifierStats playerStats = _playerStats;
				_cooldownBonus = -0.2f;
				_mightBonus = 2f;
				_curseBonus = 0.5f;
				EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
				float value = default(float);
				EggFloat cooldown = new EggFloat(value, eggFloat._eggVal);
				value = eggFloat._val - 0.2f;
				playerStats.Cooldown = cooldown;
				PlayerModifierStats playerStats2 = _playerStats;
				EggFloat eggFloat2 = playerStats2._003CPower_003Ek__BackingField;
				float value2 = default(float);
				EggFloat power = new EggFloat(value2, eggFloat2._eggVal);
				value2 = eggFloat2._val + _mightBonus;
				playerStats2.Power = power;
				PlayerModifierStats playerStats3 = _playerStats;
				EggFloat eggFloat3 = playerStats3._003CCurse_003Ek__BackingField;
				useRealTime = (byte)(int)num != 0;
				float value3 = default(float);
				EggFloat curse = new EggFloat(value3, eggFloat3._eggVal);
				value3 = eggFloat3._val + _curseBonus;
				playerStats3.Curse = curse;
				_hasBonusApplied = true;
			}
			base.IsInvul = true;
			float num2 = _morphDuration * 0.001f;
			float invincibilityTimer = num2 + ((CharacterController)this)._invincibilityTimer;
			((CharacterController)this)._invincibilityTimer = invincibilityTimer;
			base.RestoreTint();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Characters.TP_Shaft_Character>)+620]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num3 = (nint)this;
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer timer = Timers.Register(0.010000001f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			Action onComplete2 = Unmorph;
			float duration = _morphDuration * 0.001f;
			Timer timer2 = Timers.Register(duration, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		}
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
			EggFloat eggFloat5 = playerStats3._003CCurse_003Ek__BackingField;
			float value3 = default(float);
			EggFloat eggFloat6 = new EggFloat(value3, eggFloat5._eggVal);
			value3 = eggFloat5._val - _curseBonus;
			playerStats3._003CCurse_003Ek__BackingField = eggFloat6;
			_hasBonusApplied = false;
		}
		_isMorphed = false;
		GameManager core = GM.Core;
		core._weaponsFacade.RemoveHiddenWeapon(WeaponType.TP_SHAFTORB, this);
	}
}
