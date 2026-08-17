using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_Eric_Character : TP_Character
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__9_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CCriticalHP_003Eb__9_0()
		{
			SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 500f);
		}
	}

	private BgmType _saveBgm;

	private BgmModType _saveBgmMod;

	private float _morphDuration = 20000f;

	private float _cooldownBonus;

	private bool _hasBonusApplied;

	private bool _isAflame;

	private bool changedBGM;

	private int triggeredAlcardes;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		((CharacterController)this)._isCriticalHPEnabled = true;
		Action onCriticalHP = CriticalHP;
		((CharacterController)this)._onCriticalHP = onCriticalHP;
		_hasBonusApplied = false;
		changedBGM = false;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		_saveBgm = config._003CSelectedBGM_003Ek__BackingField;
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		_saveBgmMod = config2._003CSelectedBGMMod_003Ek__BackingField;
		triggeredAlcardes = 0;
	}

	private void CriticalHP()
	{
		//IL_041b: Expected I, but got O
		if (_isAflame)
		{
			return;
		}
		int num = triggeredAlcardes + 1;
		triggeredAlcardes = num;
		_isAflame = true;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._003CSelectedBGM_003Ek__BackingField == _saveBgm)
		{
			GameManager core2 = GM.Core;
			PlayerOptionsData config2 = core2._playerOptions.Config;
			config2._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_TP_Bloodlines_Pressure;
			GameManager core3 = GM.Core;
			PlayerOptionsData config3 = core3._playerOptions.Config;
			config3._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
			GM.Core.SetupMusicBanger();
			changedBGM = true;
		}
		GameManager core4 = GM.Core;
		bool flag = default(bool);
		Weapon weapon = core4._weaponsFacade.AddHiddenWeapon(WeaponType.TP_BLUEFIRE_WEAPON, this, removeFromStore: true, flag);
		if (!_hasBonusApplied)
		{
			PlayerModifierStats playerStats = _playerStats;
			_cooldownBonus = -0.2f;
			EggFloat eggFloat = playerStats._003CCooldown_003Ek__BackingField;
			float value = default(float);
			EggFloat cooldown = new EggFloat(value, eggFloat._eggVal);
			value = eggFloat._val - 0.2f;
			playerStats.Cooldown = cooldown;
			_hasBonusApplied = true;
		}
		base.IsInvul = true;
		float num2 = _morphDuration * 0.001f;
		float invincibilityTimer = num2 + ((CharacterController)this)._invincibilityTimer;
		((CharacterController)this)._invincibilityTimer = invincibilityTimer;
		base.RestoreTint();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Characters.TP_Eric_Character>)+620]");
		Action onComplete = new Action(this, (IntPtr)0);
		nint num3 = (nint)this;
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.010000001f, onComplete, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = Unmorph;
		float duration = _morphDuration * 0.001f;
		Timer timer2 = Timers.Register(duration, onComplete2, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		float num4 = _morphDuration - 1000f;
		Action onComplete3 = _003C_003Ec._003C_003E9__9_0;
		if (_003C_003Ec._003C_003E9__9_0 == null)
		{
			onComplete3 = (_003C_003Ec._003C_003E9__9_0 = delegate
			{
				SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 500f);
			});
		}
		float duration2 = num4 * 0.001f;
		Timer timer3 = Timers.Register(duration2, onComplete3, null, isLooped: false, flag, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		if (triggeredAlcardes < 3)
		{
			return;
		}
		GameManager core5 = GM.Core;
		PlayerOptionsData config4 = core5._playerOptions.Config;
		List<ItemType> list = config4._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ rcx_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				GameManager core6 = GM.Core;
				PlayerOptionsData config5 = core6._playerOptions.Config;
				bool flag2 = core6._playerOptions.UnlockSecret(SecretType.tp_wind, config5);
				GameManager core7 = GM.Core;
				core7._playerOptions.UnlockCharacter(CharacterType.TP_WIND);
			}
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
			_hasBonusApplied = false;
		}
		if (changedBGM)
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			if (config._003CSelectedBGM_003Ek__BackingField == BgmType.BGM_TP_Bloodlines_Pressure)
			{
				GameManager core2 = GM.Core;
				PlayerOptionsData config2 = core2._playerOptions.Config;
				config2._003CSelectedBGM_003Ek__BackingField = _saveBgm;
				GameManager core3 = GM.Core;
				PlayerOptionsData config3 = core3._playerOptions.Config;
				config3._003CSelectedBGMMod_003Ek__BackingField = _saveBgmMod;
				GM.Core.SetupMusicBanger();
			}
		}
		_isAflame = false;
		GameManager core4 = GM.Core;
		core4._weaponsFacade.RemoveHiddenWeapon(WeaponType.TP_BLUEFIRE_WEAPON, this);
	}
}
