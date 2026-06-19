using UnityEngine;

public class BirdPoop : EntityMonoBehaviour
{
	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		Vector3 position = base.transform.position;
		if (particleOptions.particleSpawnLocations.Capacity > 0)
		{
			position = particleOptions.particleSpawnLocations[0].position;
		}
		if (animID == -1533413595)
		{
			Manager.effects.PlayPuff(PuffID.SmallWhitePuff, position, 15);
		}
		if (animID == -414722770)
		{
			Manager.effects.PlayPuff(PuffID.SmallWhitePuff, position, 30);
			AudioManager.Sfx(SfxID.dirtImpact, base.transform.position, 0.2f, 1.1f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		}
	}
}
