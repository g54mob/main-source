using UnityEngine;

public class LarvaskinTent : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		base.OnDeath();
		Transform variationsParticleSpawnLocation = GetVariationsParticleSpawnLocation();
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, variationsParticleSpawnLocation.position, 8);
		Manager.effects.PlayPuff(PuffID.DirtBlockDebris, variationsParticleSpawnLocation.position, 20);
		Manager.effects.PlayPuff(PuffID.WoodDebris, variationsParticleSpawnLocation.position);
		Manager.effects.PlayPuff(PuffID.WhiteFur, variationsParticleSpawnLocation.position);
	}
}
