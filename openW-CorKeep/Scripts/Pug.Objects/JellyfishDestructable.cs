using UnityEngine;

public class JellyfishDestructable : EntityMonoBehaviour
{
	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			Vector3 vector = center + new Vector3(0f, 0f, -0.25f);
			GetVariationsParticleSpawnLocation();
			Vector3 vector2 = new Vector3(0f, 3f, -3f);
			if (base.objectData.objectID == ObjectID.LargeJellyfishDestructable)
			{
				Manager.effects.PlayTempSprite(SpriteTempEffectID.BlueSplat, vector);
				Manager.effects.PlayPuff(PuffID.SmallWaterSplash, vector, 30);
				Manager.effects.PlayPuff(PuffID.MediumBluePuff, vector, 50);
				Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, vector);
				Manager.effects.ExploDisc(vector + vector2 + new Vector3(0f, 0f, 0.25f), 0.5f);
			}
			else
			{
				Manager.effects.PlayTempSprite(SpriteTempEffectID.BlueSplat, vector + new Vector3(0f, 0f, -0.125f), 0.5f);
				Manager.effects.PlayPuff(PuffID.SmallWaterSplash, vector);
				Manager.effects.PlayPuff(PuffID.MediumBluePuff, vector, 30);
				Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, vector);
				Manager.effects.ExploDisc(vector + vector2, 0.33f);
			}
			AudioManager.Sfx(SfxID.dirtImpact, base.transform.position, 0.2f, 1.1f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		}
	}
}
