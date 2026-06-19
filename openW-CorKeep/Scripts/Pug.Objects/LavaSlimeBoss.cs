using UnityEngine;

public class LavaSlimeBoss : SlimeBoss
{
	protected override void DeathParticles()
	{
		Vector3 position = GetVariationsParticleSpawnLocation().position;
		Manager.effects.PlayPuff(PuffID.LavaSlime, position);
		Manager.effects.PlayPuff(PuffID.LavaSlimeSmall, position);
	}
}
