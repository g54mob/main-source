using Assets.Scripts.Inventory__Items__Pickups.AbilitiesActives.ImplementationsFuckYou;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesActives;

public static class ActiveAbilityFactory
{
	public static ActiveAbility CreateAbility(EAbiltiyActive ability)
	{
		if (ability != EAbiltiyActive.Dash)
		{
			return null;
		}
		AbilityDash abilityDash = new AbilityDash();
		abilityDash.dashDuration = 0.2f;
		abilityDash.dashSpeed = 40f;
		return abilityDash;
	}
}
