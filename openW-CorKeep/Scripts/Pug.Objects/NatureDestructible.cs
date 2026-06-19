using UnityEngine;

public class NatureDestructible : EntityMonoBehaviour
{
	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			Transform variationsParticleSpawnLocation = GetVariationsParticleSpawnLocation();
			Vector3 vector = new Vector3(0f, 3f, -3f);
			Manager.effects.ExploDisc(variationsParticleSpawnLocation.position + vector + Vector3.up * 0.5f, 0.33f);
			Manager.effects.PlayPuff(PuffID.NaturePlantPuff, variationsParticleSpawnLocation.position, 30);
			Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, variationsParticleSpawnLocation.position);
			Manager.effects.PlayPuff(PuffID.LeafDebris, variationsParticleSpawnLocation.position, 20);
			AudioManager.Sfx(SfxID.dirtImpact, base.transform.position, 0.2f, 1.1f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		}
	}
}
