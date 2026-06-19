public class RunesongTrail : EntityMonoBehaviour
{
	public override void OnOccupied()
	{
		base.OnOccupied();
		PlayParticleEffect(ParticleSpawnOccasion.OnSpawn, base.RenderPosition);
	}
}
