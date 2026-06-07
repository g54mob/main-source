public class Sand : Weapon
{
	public override void CastSpell()
	{
		int num = (base.UPGRADED ? 120 : 60);
		bool flag = false;
		foreach (Module item in owner.GetRow())
		{
			if ((item.PET || item.MODULE) && item.name != Module.Name.Egg && item.name != Module.Name.Rock)
			{
				flag = true;
				item.AddAura(new Aura(Aura.Type.Accel, foreign: false, temp: false, null, 1.6666666f), num);
				item.BuffParticles("EDAB50", num);
			}
		}
		if (flag)
		{
			base.dungeon.audioManager.PlayModSound(owner, 0.8f);
		}
	}
}
