using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class Enemy_TP_SpecialUnlock_AxeArmor : Enemy_TP_SpecialUnlock
{
	protected override void Awake()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		base.Awake();
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rdx_v5+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1432);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 1432;
		}
		WeaponsToHitWith = list;
	}

	protected override void OnKilledBySelectedWeapon()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		int tP_AxeArmorCount = config.TP_AxeArmorCount + 1;
		config.TP_AxeArmorCount = tP_AxeArmorCount;
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		List<ItemType> list = config2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj != -1)
		{
			GameManager core3 = GM.Core;
			PlayerOptionsData config3 = core3._playerOptions.Config;
			if (config3.TP_AxeArmorCount > 100)
			{
				GameManager core4 = GM.Core;
				PlayerOptionsData config4 = core4._playerOptions.Config;
				bool flag = core4._playerOptions.UnlockSecret(SecretType.tp_axearmor, config4);
				GameManager core5 = GM.Core;
				core5._playerOptions.UnlockCharacter(CharacterType.TP_AXEARMOR);
			}
		}
	}
}
