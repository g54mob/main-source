using UnityEngine;

public class GalaxiteTurret : Turret
{
	public Transform particleSpawnPos;

	public override void AE_AttackEffects()
	{
		Vector3 position = particleSpawnPos.position;
		AudioManager.Sfx(SfxID.slingshotFire, position, 0.3f, 1f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		AudioManager.Sfx(SfxID.energy_blast, position, 0.5f, 1f, 0.15f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		Manager.effects.PlayPuff(PuffID.SmallColorfulExplosion, position);
	}
}
