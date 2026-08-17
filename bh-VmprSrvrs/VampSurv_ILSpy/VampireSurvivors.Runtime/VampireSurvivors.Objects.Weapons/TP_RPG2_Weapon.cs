namespace VampireSurvivors.Objects.Weapons;

public class TP_RPG2_Weapon : TP_RPG1_Weapon
{
	protected override void Awake()
	{
		base.Awake();
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Bazooka;
	}

	public TP_RPG2_Weapon()
	{
		exploRadius = 0.32f;
		((Weapon)this)._002Ector();
	}
}
