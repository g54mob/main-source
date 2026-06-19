using UnityEngine;

public class MushroomEnemy : EntityMonoBehaviour
{
	public ParticleEffectSpawner runParticles;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimOrientation => true;

	public override void OnOccupied()
	{
		base.OnOccupied();
		runParticles.enabled = false;
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		switch (animID)
		{
		case -1634423587:
			runParticles.enabled = false;
			break;
		case 1433117748:
			runParticles.enabled = true;
			break;
		case -1997722203:
		{
			AudioManager.Sfx(SfxID.dirtImpact, base.transform.position, 1f, 1.1f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
			AudioManager.Sfx(SfxID.punch2, base.transform.position, 0.5f, 1.15f, 0.1f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
			runParticles.enabled = false;
			Vector3 position = base.transform.position + new Vector3(0f, 0.5f, 0f);
			Manager.effects.PlayPuff(PuffID.MushroomDebris, position, 20);
			Manager.effects.PlayPuff(PuffID.DirtItemDust, position);
			break;
		}
		case -601574123:
		case -281135240:
		case -210448114:
		case 1352515405:
			runParticles.enabled = false;
			break;
		}
		base.HandleAnimationTrigger(animID);
	}

	protected override bool ShouldPlayAnimTrigger(int animID)
	{
		if ((animID == -1997722203 && lastAnim == -1997722203) || (lastAnim == -1997722203 && animID == -601574123))
		{
			return false;
		}
		return base.ShouldPlayAnimTrigger(animID);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		runParticles.enabled = false;
		Vector3 position = base.transform.position + new Vector3(0f, 0.5f, 0f);
		Manager.effects.PlayPuff(PuffID.MediumPurplePuff, position, 40);
	}
}
