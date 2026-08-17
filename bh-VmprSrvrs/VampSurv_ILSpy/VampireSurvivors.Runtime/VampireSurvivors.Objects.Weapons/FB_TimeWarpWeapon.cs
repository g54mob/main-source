using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class FB_TimeWarpWeapon : Weapon
{
	protected WeaponType _counterWeaponType = WeaponType.FB_PRISMCUTLASS_COUNTER;

	protected Weapon _counterWeapon;

	private bool _fireCounterSet;

	private bool _hasCounterSet;

	private FB_PrismCutlassWeapon _counterSet;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		base._003CFreezeChance_003Ek__BackingField = 0.05f;
	}

	public override void CheckArcanas()
	{
		//IL_0122: Expected I, but got O
		//IL_0130: Expected I, but got O
		//IL_0140: Expected O, but got I
		//IL_01c0: Expected O, but got I4
		//IL_017c: Expected O, but got I
		//IL_01b2: Expected O, but got I4
		CheckBeginningArcana();
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj <= -1)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		_fireCounterSet = true;
		Weapon weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		bool allowDuplicates = default(bool);
		Weapon weapon = core2._weaponsFacade.AddHiddenWeapon(_counterWeaponType, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
		bool flag = (object)weapon == null;
		Weapon weapon2 = null;
		if (flag)
		{
			goto IL_0240;
		}
		nint num = (nint)weapon;
		nint num2 = (nint)typeof(FB_PrismCutlassCounterWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_PrismCutlassCounterWeapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_PrismCutlassCounterWeapon>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ r9_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v432 @ rax_v37+FFFFFFF8+v380 @ rax_v33*8]");
			if (0 == (nint)typeof(FB_PrismCutlassCounterWeapon))
			{
				obj4 = 1;
				goto IL_024f;
			}
		}
		obj4 = 0;
		goto IL_024f;
		IL_0240:
		_counterWeapon = weapon2;
		while (((Equipment)weapon2)._003CLevel_003Ek__BackingField < 8)
		{
			bool flag2 = weapon2.LevelUp();
		}
		return;
		IL_024f:
		bool flag3 = obj4 == null;
		weapon2 = null;
		if (!flag3)
		{
			weapon2 = weapon;
		}
		goto IL_0240;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_00a2: Expected I, but got O
		//IL_00aa: Expected I, but got O
		//IL_00ba: Expected O, but got I
		//IL_013a: Expected O, but got I4
		//IL_00f6: Expected O, but got I
		//IL_012c: Expected O, but got I4
		base.Fire(skipTriggers);
		if (!_fireCounterSet)
		{
			return;
		}
		Weapon weaponByType;
		object obj3;
		if (!_hasCounterSet)
		{
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
			weaponByType = characterController._weaponsManager.GetWeaponByType(_counterWeaponType, searchHidden: true);
			if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
			{
				_hasCounterSet = true;
				nint num = (nint)typeof(FB_PrismCutlassWeapon);
				nint num2 = (nint)weaponByType;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_PrismCutlassWeapon>)+130]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.FB_PrismCutlassWeapon>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v452 @ rax_v38+FFFFFFF8+v438 @ rax_v27*8]");
					if (0 == (nint)typeof(FB_PrismCutlassWeapon))
					{
						obj3 = 1;
						goto IL_0223;
					}
				}
				obj3 = 0;
				goto IL_0223;
			}
		}
		goto IL_0183;
		IL_0223:
		bool flag = obj3 == null;
		Weapon counterSet = null;
		if (!flag)
		{
			counterSet = weaponByType;
		}
		_counterSet = (FB_PrismCutlassWeapon)counterSet;
		_counterSet.Cleanup();
		GameObject gameObject = _counterSet.gameObject;
		gameObject.SetActive(value: true);
		goto IL_0183;
		IL_0183:
		FB_PrismCutlassWeapon counterSet2 = _counterSet;
		if ((object)_counterSet != null && ((UnityEngine.Object)counterSet2).m_CachedPtr != (IntPtr)0)
		{
			_counterSet.Fire(skipTriggers);
		}
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}
}
