using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Items;

namespace VampireSurvivors.Objects.Characters;

public class SubSkillCard_AddWeapon_Cherry2(ArcanaType type) : CharacterSkillCard_Base(type)
{
	private bool hasGivenWeapon;

	private int weaponLevel = 80;

	public override void OnOwnerLevelUp()
	{
		base.OnOwnerLevelUp();
		if (AccumulatedLevels >= weaponLevel && !hasGivenWeapon)
		{
			PickupWeapon pickupWeapon = GM.Core.TryGiveWeaponToPlayer(WeaponType.CHERRY2, LinkedCharacter);
			hasGivenWeapon = true;
		}
	}
}
