public class Lifestaff : Weapon
{
	public override void CastSpell()
	{
		owner.dungeon.player.Heal(owner.UPGRADED ? 6 : 3);
		owner.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Heal, 0.9f, 1.1f, 1f);
	}
}
