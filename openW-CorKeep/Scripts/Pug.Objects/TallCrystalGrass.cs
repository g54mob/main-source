public class TallCrystalGrass : EntityMonoBehaviour
{
	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, base.transform.position, 8);
			Manager.effects.PlayPuff(PuffID.CrystalGrassDebris, base.transform.position, 20);
			AudioManager.Sfx(SfxID.dirtImpact, base.transform.position, 0.2f, 1.1f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		}
	}

	public void AE_Shake()
	{
		Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, base.transform.position, 4);
		AudioManager.Sfx(SfxID.grassImpact, base.transform.position, 0.3f, 1.15f, 0.125f);
	}

	public override void OnPlayerTriggerEnter(PlayerController pc)
	{
		base.OnPlayerTriggerEnter(pc);
		if (spriteObjects[0] != null)
		{
			PlayShakeAnim(pc.RenderPosition, spriteObjects[0], 2f);
		}
		AudioManager.Sfx(SfxID.grassImpact, base.transform.position, 0.3f, 1.15f, 0.125f);
	}
}
