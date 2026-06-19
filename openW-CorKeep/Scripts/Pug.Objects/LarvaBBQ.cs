using UnityEngine;

public class LarvaBBQ : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		base.OnDeath();
		Transform variationsParticleSpawnLocation = GetVariationsParticleSpawnLocation();
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, variationsParticleSpawnLocation.position, 8);
		Manager.effects.PlayPuff(PuffID.DirtBlockDebris, variationsParticleSpawnLocation.position);
		Manager.effects.PlayPuff(PuffID.ClayBlockDebrisBox, variationsParticleSpawnLocation.position);
		Manager.effects.PlayPuff(PuffID.FireFloaters, variationsParticleSpawnLocation.position, 20);
	}
}
