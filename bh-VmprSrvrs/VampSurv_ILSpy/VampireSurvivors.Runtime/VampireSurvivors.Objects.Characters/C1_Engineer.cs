using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Characters;

public class C1_Engineer : CharacterController
{
	public override void LevelUp()
	{
		base.LevelUp();
		if (base._level == 2 || base._level == 12 || base._level == 22)
		{
			GM.Core.QueueOpenWeaponSelection(this, "passive");
		}
	}
}
