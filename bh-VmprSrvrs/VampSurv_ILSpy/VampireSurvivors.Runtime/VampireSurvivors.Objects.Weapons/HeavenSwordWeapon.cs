using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Weapons;

public class HeavenSwordWeapon : Weapon
{
	public override void CheckArcanas()
	{
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_bonusBounces = 2;
			}
		}
		CheckBeginningArcana();
	}

	protected override float CalcCritMul()
	{
		//IL_00c9: Expected O, but got F4
		object obj = UnityEngine.Random.value;
		WeaponData currentWeaponData = _currentWeaponData;
		if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			float num = ((Equipment)this)._003COwner_003Ek__BackingField.PLuck();
			float num3 = default(float);
			float num2 = num3 * currentWeaponData._003CcritChance_003Ek__BackingField;
			if (!(num2 > num3))
			{
				return 1f;
			}
			WeaponData currentWeaponData2 = _currentWeaponData;
			if (_currentWeaponData != null)
			{
				return currentWeaponData2._003CcritMul_003Ek__BackingField * ArcanaManager.CritMul;
			}
		}
		throw new NullReferenceException();
	}
}
