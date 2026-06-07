public class Snowball : Weapon
{
	public override void KillTrigger(Monster monster)
	{
		int num = (owner.UPGRADED ? 120 : 60);
		owner.AddAura(new Aura(Aura.Type.Damage), num);
		owner.AddAura(new Aura(Aura.Type.SnowballScale), num);
		owner.BuffParticles("EDFDFE", num);
	}
}
