using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Weapons;

public class Song2Weapon : Weapon
{
	public override float PAmount()
	{
		return 1f;
	}

	public override float SecondaryPAmount()
	{
		float num = ((Equipment)this)._003COwner_003Ek__BackingField.PAmount();
		float num2 = default(float);
		bool flag = !(10f > num2);
		float num3 = 10f;
		if (!flag)
		{
			num3 = num2;
		}
		WeaponData currentWeaponData = _currentWeaponData;
		return (float)currentWeaponData._003Camount_003Ek__BackingField + num3;
	}

	public override void Fire(bool skipTriggers = false)
	{
		base.Fire(skipTriggers);
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		if (arcanaManager._hasAstronomia)
		{
			GameManager core2 = GM.Core;
			core2._arcanaManager.TriggerAstronomia(this);
		}
	}
}
