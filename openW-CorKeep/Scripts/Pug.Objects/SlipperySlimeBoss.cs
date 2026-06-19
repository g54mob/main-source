using UnityEngine;

public class SlipperySlimeBoss : SlimeBoss
{
	protected override void DeathParticles()
	{
		Vector3 position = GetVariationsParticleSpawnLocation().position;
		Manager.effects.PlayPuff(PuffID.BlueSlime, position);
		Manager.effects.PlayPuff(PuffID.BlueSlimeSmall, position);
	}
}
