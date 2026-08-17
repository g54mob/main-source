using System;
using Cpp2ILInjected;
using VampireSurvivors.Data.Weapons;

namespace VampireSurvivors.Objects.Weapons;

public class EX_FlikWeapon : Weapon
{
	public override float PPower()
	{
		//IL_001a: Invalid comparison between F4 and I
		//IL_0049: Expected F4, but got I
		float num = base.PSpeed();
		float num3 = default(float);
		float num2 = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A104DC]");
		bool flag = !(num2 < 0f);
		float num4 = num3;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A104DC]");
			num4 = 0f;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		if (_currentWeaponData != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			num3 = ((Equipment)this)._003COwner_003Ek__BackingField.PPowerFinal();
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				float bloodlineDamage = ((Equipment)this)._003COwner_003Ek__BackingField.BloodlineDamage;
				float num5 = currentWeaponData._003Cpower_003Ek__BackingField * num4;
				float num6 = num5 * num3;
				return num3 + num6;
			}
		}
		throw new NullReferenceException();
	}
}
