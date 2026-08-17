using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Holy1_WeaponCounter : TP_Holy1_Weapon
{
	public override bool IsPrimaryWeapon => false;

	public TP_Holy1_WeaponCounter()
	{
		//IL_0010: Expected O, but got I4
		base._cursorTexture = "ThosePeople";
		base._cursorSprite = "TP_VFX_Holy06";
		base._cursorOffset = (Vector2)0;
		_ = 3184315597L;
		base._cursorMinAlpha = 0.15f;
		_counterWeaponType = WeaponType.TP_HOLY1_COUNTER;
		((Weapon)this)._002Ector();
	}
}
