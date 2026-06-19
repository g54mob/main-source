using UnityEngine;

public class ClayWormSegment : WormSegment
{
	protected override void SpawnDeathParticles(GameObject segment)
	{
		Vector3 position = segment.transform.position + Vector3.up * 0.25f;
		Manager.effects.PlayPuff(PuffID.SmallBrownPuff, position, 8);
		Manager.effects.PlayPuff(PuffID.MushroomDebris, position, 8);
		Manager.effects.PlayPuff(PuffID.BlackDebris, position, 8);
	}
}
