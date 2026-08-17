using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Weapons;

public class HolyWandWeapon : MagicMissileWeapon
{
	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				_bonusBounces = 3;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				((Weapon)this)._003CFreezeChance_003Ek__BackingField = 0.25f;
			}
		}
		GameManager gameMan3 = _gameMan;
		ArcanaManager arcanaManager3 = gameMan3._arcanaManager;
		List<ArcanaType> list3 = arcanaManager3._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj3 = default(object);
			if ((nint)obj3 != -1)
			{
				WeaponData currentWeaponData = _currentWeaponData;
				currentWeaponData._003Cpenetrating_003Ek__BackingField = 65535;
				_bonusBounces = 3;
			}
		}
		GameManager gameMan4 = _gameMan;
		ArcanaManager arcanaManager4 = gameMan4._arcanaManager;
		List<ArcanaType> list4 = arcanaManager4._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj4 = default(object);
			if ((nint)obj4 != -1)
			{
				((Weapon)this)._003CFreezeChance_003Ek__BackingField = 0.25f;
			}
		}
	}
}
