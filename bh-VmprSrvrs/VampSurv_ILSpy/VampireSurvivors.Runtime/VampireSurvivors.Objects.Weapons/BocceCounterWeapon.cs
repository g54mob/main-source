using System;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class BocceCounterWeapon : BocceWeapon
{
	public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
	{
		//IL_0051: Expected I4, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5080]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_radius = -32;
		_orbFrame = "bubbleSphere";
		base.InitWeapon(characterController, weaponType);
	}

	public BocceCounterWeapon()
	{
		_radius = 32;
		_orbFrame = "bubbleSphere";
		base._angleUnit = (float)Math.PI / 360f;
		((Weapon)this)._002Ector();
	}
}
