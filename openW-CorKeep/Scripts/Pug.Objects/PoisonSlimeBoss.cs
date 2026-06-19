using UnityEngine;

public class PoisonSlimeBoss : SlimeBoss
{
	protected override void DeathParticles()
	{
		Vector3 position = GetVariationsParticleSpawnLocation().position;
		Manager.effects.PlayPuff(PuffID.PurpleSlime, position);
		Manager.effects.PlayPuff(PuffID.PurpleSlimeSmall, position);
	}
}
