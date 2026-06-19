using UnityEngine;

public class LargeShinyGlimmeringObject : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		Transform variationsParticleSpawnLocation = GetVariationsParticleSpawnLocation();
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.SmallBrownPuff, variationsParticleSpawnLocation.position, 15);
		Manager.effects.PlayPuff(PuffID.DirtBlockDebris, variationsParticleSpawnLocation.position);
		Manager.effects.PlayPuff(PuffID.SmallAncientSmoke, variationsParticleSpawnLocation.position, 6);
		Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, variationsParticleSpawnLocation.position, 6);
		Manager.effects.PlayPuff(PuffID.SmallAncientEnergy, variationsParticleSpawnLocation.position, 8);
	}
}
