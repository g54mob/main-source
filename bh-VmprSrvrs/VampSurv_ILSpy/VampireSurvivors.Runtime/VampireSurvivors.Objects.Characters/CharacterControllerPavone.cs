using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerPavone : CharacterController
{
	public override bool NeedsCart => false;

	public override void LevelUp()
	{
		//IL_007f: Invalid comparison between F4 and I4
		//IL_010b: Invalid comparison between F4 and I4
		base.LevelUp();
		float num = (float)base._level / 5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F7E8");
		Weapon weaponByType = base._weaponsManager.GetWeaponByType(WeaponType.SILF2, searchHidden: true);
		Weapon weaponByType2 = base._weaponsManager.GetWeaponByType(WeaponType.SILF, searchHidden: true);
		if ((object)weaponByType != null && ((UnityEngine.Object)weaponByType).m_CachedPtr != (IntPtr)0)
		{
			if (num > (float)((Equipment)weaponByType)._003CLevel_003Ek__BackingField && ((Equipment)weaponByType)._003CLevel_003Ek__BackingField < 8)
			{
				bool flag = weaponByType.LevelUp();
			}
			weaponByType._skipAddingEvolution = true;
		}
		if ((object)weaponByType2 != null && ((UnityEngine.Object)weaponByType2).m_CachedPtr != (IntPtr)0)
		{
			if (num > (float)((Equipment)weaponByType2)._003CLevel_003Ek__BackingField && ((Equipment)weaponByType2)._003CLevel_003Ek__BackingField < 8)
			{
				bool flag2 = weaponByType2.LevelUp();
			}
			weaponByType2._skipAddingEvolution = true;
		}
	}

	public override void Revive(float percentage = 1f, bool instantRevival = false)
	{
		base.Revive(percentage, instantRevival);
		bool setDark = default(bool);
		GM.Core.RosaryDamage(showVfx: true, 1.8f, WeaponType.ROSARY, setDark);
	}
}
