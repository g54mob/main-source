using UnityEngine;

public class KingSlime : SlimeBoss
{
	protected override void DeathParticles()
	{
		Vector3 position = GetVariationsParticleSpawnLocation().position;
		Manager.effects.PlayPuff(PuffID.BlueSlime, position);
		Manager.effects.PlayPuff(PuffID.BlueSlimeSmall, position);
	}
}
