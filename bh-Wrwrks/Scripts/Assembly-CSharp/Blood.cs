public class Blood : Weapon
{
	public override void KillTrigger(Monster monster)
	{
		owner.counter++;
		owner.TriggerBounce();
		if (owner.counter % 40 == 0)
		{
			PlaySound(AudioManager.Sound.Blood_Blade);
			owner.AddAura(new Aura(Aura.Type.FoodBuff));
			if (owner.UPGRADED)
			{
				owner.AddAura(new Aura(Aura.Type.FoodBuff));
			}
		}
	}
}
