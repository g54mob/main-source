using UnityEngine;

public class LargeMoldDestructible : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		base.OnDeath();
		Transform variationsParticleSpawnLocation = GetVariationsParticleSpawnLocation();
		Manager.effects.PlayPuff(PuffID.SmallWhitePuff, variationsParticleSpawnLocation.position, 60);
		Manager.effects.PlayPuff(PuffID.SlimeExplosion, variationsParticleSpawnLocation.position, 30);
		Manager.effects.PlayPuff(PuffID.StoneBlockDust, variationsParticleSpawnLocation.position, 20);
		Manager.effects.PlayPuff(PuffID.StoneBlockDebris, variationsParticleSpawnLocation.position, 20);
	}
}
