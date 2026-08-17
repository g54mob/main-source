using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class BoneWeapon : Weapon
{
	public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
	{
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		base.InitWeapon(characterController, weaponType);
	}

	public override void CheckArcanas()
	{
		if (!_beginningArcana)
		{
			GameManager gameMan = _gameMan;
			List<WeaponType> list = gameMan._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)0 > (nint)0)
			{
				GameManager gameMan2 = _gameMan;
				List<WeaponType> list2 = gameMan2._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				object obj = default(object);
				if (obj != null)
				{
					int beginningAmount = _beginningAmount + 3;
					_beginningAmount = beginningAmount;
					WeaponData currentWeaponData = _currentWeaponData;
					_beginningArcana = true;
					int num = currentWeaponData._003Camount_003Ek__BackingField + 3;
					currentWeaponData._003Camount_003Ek__BackingField = num;
				}
			}
			if (!_beginningArcana)
			{
				GameManager gameMan3 = _gameMan;
				List<WeaponType> list3 = gameMan3._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)0 > (nint)0)
				{
					GameManager gameMan4 = _gameMan;
					List<WeaponType> list4 = gameMan4._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
					object obj2 = default(object);
					if (obj2 == null)
					{
						int beginningAmount2 = _beginningAmount + 1;
						_beginningAmount = beginningAmount2;
						WeaponData currentWeaponData2 = _currentWeaponData;
						_beginningArcana = true;
						int num2 = currentWeaponData2._003Camount_003Ek__BackingField + 1;
						currentWeaponData2._003Camount_003Ek__BackingField = num2;
					}
				}
			}
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list5 = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj3 = default(object);
		if ((nint)obj3 > -1)
		{
			_explodeOnExpire = true;
		}
		GameManager gameMan5 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan5._arcanaManager;
		List<ArcanaType> list6 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			if ((nint)obj4 != -1)
			{
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}
}
