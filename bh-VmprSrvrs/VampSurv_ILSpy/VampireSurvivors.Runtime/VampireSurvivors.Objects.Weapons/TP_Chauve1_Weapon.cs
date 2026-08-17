using VampireSurvivors.Data.Weapons;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Chauve1_Weapon : Weapon
{
	public override float PArea()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAreaFinal();
		WeaponData currentWeaponData = _currentWeaponData;
		object obj = default(object);
		float num2 = (float)obj * currentWeaponData._003Carea_003Ek__BackingField;
		bool flag = !(6f > num2);
		float result = 6f;
		if (!flag)
		{
			result = num2;
		}
		return result;
	}
}
