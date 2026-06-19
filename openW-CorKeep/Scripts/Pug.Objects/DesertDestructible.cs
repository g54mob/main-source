using UnityEngine;

public class DesertDestructible : EntityMonoBehaviour
{
	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			Vector3 vector = base.transform.position;
			if (particleOptions.particleSpawnLocations.Capacity > 1)
			{
				ObjectID objectID = base.objectData.objectID;
				vector = ((objectID != ObjectID.DesertDestructible && objectID != ObjectID.GreenDesertDestructible) ? particleOptions.particleSpawnLocations[1].position : particleOptions.particleSpawnLocations[0].position);
			}
			Vector3 vector2 = new Vector3(0f, 3f, -3f);
			Manager.effects.ExploDisc(vector + vector2 + Vector3.up * 0.5f, 0.33f);
			Manager.effects.PlayPuff(PuffID.DesertPlantPuff, vector, 30);
			Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, vector);
			Manager.effects.PlayPuff(PuffID.BrownLeafDebris, vector, 20);
			AudioManager.Sfx(SfxID.dirtImpact, base.transform.position, 0.2f, 1.1f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		}
	}
}
