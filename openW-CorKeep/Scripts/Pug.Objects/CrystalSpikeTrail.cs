public class CrystalSpikeTrail : EntityMonoBehaviour
{
	protected override void Awake()
	{
		base.Awake();
		_ = base.transform.position;
		if (particleOptions.particleSpawnLocations.Capacity > 0)
		{
			_ = particleOptions.particleSpawnLocations[0].position;
		}
	}
}
