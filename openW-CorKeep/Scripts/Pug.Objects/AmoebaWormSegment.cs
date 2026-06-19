using UnityEngine;

public class AmoebaWormSegment : WormSegment
{
	protected override void SpawnDeathParticles(GameObject segment)
	{
		PlayParticleEffect(ParticleSpawnOccasion.OnDeath, segment.transform.position);
	}
}
