using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class CharacterController_EX_Secretino : CharacterController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__7_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CAfterFullInitialization_003Eb__7_0()
		{
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			config._003CForcedSurvarots_003Ek__BackingField = true;
		}
	}

	private bool _ArcanaGivenLevel1;

	private bool _ArcanaGivenLevel2;

	private bool _ArcanaGivenLevel3;

	private Ex_Magistone2_Weapon _003CMagistone2_Weapon_003Ek__BackingField;

	public Ex_Magistone2_Weapon Magistone2_Weapon
	{
		get
		{
			return _003CMagistone2_Weapon_003Ek__BackingField;
		}
		set
		{
			_003CMagistone2_Weapon_003Ek__BackingField = value;
		}
	}

	public override void AfterFullInitialization()
	{
		//IL_02ec: Expected F4, but got I4
		//IL_007c: Expected O, but got I
		//IL_015c: Expected I, but got O
		//IL_016a: Expected I, but got O
		//IL_017a: Expected O, but got I
		//IL_008e: Expected O, but got I4
		//IL_01fa: Expected O, but got I4
		//IL_00a4: Expected F8, but got I
		//IL_01b6: Expected O, but got I
		//IL_00d9: Invalid comparison between F4 and I4
		//IL_01ec: Expected O, but got I4
		//IL_00f6: Invalid comparison between I4 and F4
		base.AfterFullInitialization();
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		Dictionary<CharacterType, float> dictionary = config._003CCharacterEggCount_003Ek__BackingField;
		int num = config._003CCharacterEggCount_003Ek__BackingField.FindEntry(_characterType);
		bool flag = num < 0;
		int num2 = 1;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rbx_v3 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, System.Single>)+18]");
			object obj = 0;
			object obj2 = num + num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rcx_v45+2C+v369 @ rax_v58*8]");
			double num3 = Math.Log10(0.0);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
			int num4 = ((Dictionary<CharacterType, float>)(object)typeof(Math)).FindEntry(_characterType);
			if (!(1f > (float)num4) && (float)num4 > 10f)
			{
				goto IL_0108;
			}
			int num5 = ((Dictionary<CharacterType, float>)(object)typeof(Math)).FindEntry(_characterType);
			num2 = num5;
		}
		base._003CSkillCards_Mult_003Ek__BackingField = num2;
		goto IL_0108;
		IL_0108:
		Weapon weaponByType = base._weaponsManager.GetWeaponByType(WeaponType.EX_MAGISTONE2);
		bool canPause;
		Weapon weapon;
		if ((object)weaponByType == null)
		{
			canPause = false;
			weapon = null;
			goto IL_0317;
		}
		nint num6 = (nint)weaponByType;
		nint num7 = (nint)typeof(Ex_Magistone2_Weapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Magistone2_Weapon>)+130]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v401 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Magistone2_Weapon>)+130]");
		object obj5;
		if (num8 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ rax_v55+FFFFFFF8+v402 @ rax_v50*8]");
			if (0 == (nint)typeof(Ex_Magistone2_Weapon))
			{
				obj5 = 1;
				goto IL_0326;
			}
		}
		obj5 = 0;
		goto IL_0326;
		IL_0317:
		_003CMagistone2_Weapon_003Ek__BackingField = (Ex_Magistone2_Weapon)weapon;
		Ex_Magistone2_Weapon ex_Magistone2_Weapon = _003CMagistone2_Weapon_003Ek__BackingField;
		if ((object)_003CMagistone2_Weapon_003Ek__BackingField != null && ((UnityEngine.Object)ex_Magistone2_Weapon).m_CachedPtr != (IntPtr)0)
		{
			Ex_Magistone2_Weapon ex_Magistone2_Weapon2 = _003CMagistone2_Weapon_003Ek__BackingField;
			ex_Magistone2_Weapon2.MinDamage = 1f;
		}
		Action onComplete = _003C_003Ec._003C_003E9__7_0;
		if (_003C_003Ec._003C_003E9__7_0 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__7_0 = delegate
			{
				GameManager core2 = GM.Core;
				PlayerOptionsData config2 = core2._playerOptions.Config;
				config2._003CForcedSurvarots_003Ek__BackingField = true;
			});
		}
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause);
		GM.Core.QueueOpenSurvarots(6, this);
		EnableDestroyDestructiblesOnTouch();
		return;
		IL_0326:
		bool flag2 = obj5 == null;
		canPause = false;
		weapon = null;
		if (!flag2)
		{
			canPause = false;
			weapon = weaponByType;
		}
		goto IL_0317;
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		_ArcanaGivenLevel1 = false;
		_ArcanaGivenLevel3 = false;
	}

	public override void LevelUp()
	{
		base.LevelUp();
	}

	private void CheckOpenSurvarots()
	{
		if (!_ArcanaGivenLevel1 && base._level >= 3)
		{
			GM.Core.QueueOpenSurvarots(5, this);
			_ArcanaGivenLevel1 = true;
		}
		if (!_ArcanaGivenLevel2 && base._level >= 7)
		{
			GM.Core.QueueOpenSurvarots(6, this);
			_ArcanaGivenLevel2 = true;
		}
		if (!_ArcanaGivenLevel3 && base._level >= 11)
		{
			GM.Core.QueueOpenSurvarots(6, this);
			_ArcanaGivenLevel3 = true;
		}
	}
}
