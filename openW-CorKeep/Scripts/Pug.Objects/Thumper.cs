using UnityEngine;

public class Thumper : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		Transform variationsParticleSpawnLocation = GetVariationsParticleSpawnLocation();
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.SmallBrownPuff, variationsParticleSpawnLocation.position, 15);
		Manager.effects.PlayPuff(PuffID.DirtBlockDebris, variationsParticleSpawnLocation.position);
		Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, variationsParticleSpawnLocation.position, 6);
	}

	public void AE_Thump()
	{
		Transform variationsParticleSpawnLocation = GetVariationsParticleSpawnLocation();
		Manager.effects.PlayPuff(PuffID.SmallBrownPuff, variationsParticleSpawnLocation.position, 15);
		Manager.effects.PlayPuff(PuffID.DirtBlockDebris, variationsParticleSpawnLocation.position);
		Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, variationsParticleSpawnLocation.position, 6);
		AudioManager.Sfx(SfxID.anvil, base.transform.position, 0.5f, 0.45f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
	}
}
