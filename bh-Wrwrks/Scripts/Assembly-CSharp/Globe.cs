public class Globe : Module
{
	protected override void CastSpell()
	{
		base.dungeon.audioManager.PlaySoundRandomized(AudioManager.Sound.Sleighbells, 0.9f, 1.1f, 1f);
		int num = (UPGRADED ? 120 : 60);
		foreach (Module adjacent in GetAdjacents())
		{
			adjacent.AddAura(new Aura(Aura.Type.Damage, foreign: false, temp: true, null, 2f), num);
			adjacent.BuffParticles("EDFDFE", num);
		}
	}
}
