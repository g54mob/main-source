namespace VampireSurvivors.Objects.Weapons;

public class TP_SacredBeasts2_Weapon : TP_SacredBeasts1_Weapon
{
	protected override bool hasInvulnerabilityBonus => true;

	public TP_SacredBeasts2_Weapon()
	{
		base.OverhealTriggerValue = 8f;
		base.OverhealDelay = 100f;
		base.RetaliationDelay = 1500f;
		base.invulDelay = 500f;
		SlotNumber = 1;
		((Weapon)this)._002Ector();
	}
}
