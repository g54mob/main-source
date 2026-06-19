using UnityEngine;

public class AncientFeather : EntityMonoBehaviour
{
	public GameObject BlueFeather;

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			bool flag = false;
			if (BlueFeather != null)
			{
				flag = BlueFeather.activeSelf;
			}
			Vector3 position = base.transform.position;
			if (particleOptions.particleSpawnLocations.Capacity > 0)
			{
				position = particleOptions.particleSpawnLocations[0].position;
			}
			if (flag)
			{
				Manager.effects.PlayPuff(PuffID.BlueFur, position, 5);
			}
			else
			{
				Manager.effects.PlayPuff(PuffID.YellowFur, position, 5);
			}
			AudioManager.Sfx(SfxID.dirtImpact, base.transform.position, 0.2f, 1.1f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		}
	}
}
