using Pug.UnityExtensions;
using UnityEngine;

public class DesertBrute : EntityMonoBehaviour
{
	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	protected override float GetAnimSpeed()
	{
		return 1f;
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			Manager.effects.PlayPuff(PuffID.MediumPurplePuff, base.transform.position, 80);
			if (hasShadow)
			{
				shadow.SetActive(value: false);
			}
		}
	}

	private void AE_AnticipationSound()
	{
		AudioManager.Sfx(SfxID.CavelingAnticipation, base.transform.position, 0.5f, 0.4f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
	}

	private void AE_AttackEffects()
	{
		AnimationOrientationCD componentData = EntityUtility.GetComponentData<AnimationOrientationCD>(base.entity, base.world);
		Vector3 position = base.transform.position + componentData.facingDirection.vec3 * 1.5f;
		if (componentData.facingDirection.vec3.z > -0.5f)
		{
			position += componentData.facingDirection.vec3 * 1f;
		}
		if (componentData.facingDirection.vec3.z > 0.5f)
		{
			position += componentData.facingDirection.vec3 * 0.35f;
		}
		AudioManager.Sfx(SfxID.CavelingAttack, base.transform.position, 0.5f, 0.6f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		AudioManager.Sfx(SfxID.whip, base.transform.position, 0.8f, 0.7f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		AudioManager.Sfx(SfxID.bomb2, base.transform.position, 0.75f, 1.2f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		AudioManager.Sfx(SfxID.dirtImpact, base.transform.position, 1f, 0.7f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		AudioManager.Sfx(SfxID.wall, base.transform.position, 1f, 0.7f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		if (Manager.multiMap.GetTileLayerLookup().GetTopTile(base.WorldPosition.RoundToInt2()).tileset == 1)
		{
			Manager.effects.PlayPuff(PuffID.StoneImpact, position);
		}
		else
		{
			Manager.effects.PlayPuff(PuffID.DirtImpact, position);
		}
		WaterSim.AddImpulse(position, 2f, 2f);
	}
}
