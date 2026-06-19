public class MinionOrbit : MinionBase
{
	public override void OnOccupied()
	{
		base.OnOccupied();
		Invoke("DelayedEffect", 0.1f);
	}

	private void DelayedEffect()
	{
		PlayParticleEffect(ParticleSpawnOccasion.OnSpawn, base.RenderPosition);
	}
}
