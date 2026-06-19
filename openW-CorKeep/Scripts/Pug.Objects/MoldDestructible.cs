using UnityEngine;

public class MoldDestructible : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		base.OnDeath();
		Transform variationsParticleSpawnLocation = GetVariationsParticleSpawnLocation();
		Manager.effects.PlayPuff(PuffID.SmallWhitePuff, variationsParticleSpawnLocation.position, 24);
		Manager.effects.PlayPuff(PuffID.SlimeExplosion, variationsParticleSpawnLocation.position);
		Manager.effects.PlayPuff(PuffID.StoneBlockDust, variationsParticleSpawnLocation.position);
	}
}
