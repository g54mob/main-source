namespace VampireSurvivors.Objects.Weapons;

public class TP_WhipMemory_Weapon : Weapon
{
	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Melee;
	}
}
