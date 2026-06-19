public class TallGrass : EntityMonoBehaviour
{
	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == -414722770)
		{
			Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, base.transform.position, 8);
			PlayDebrisPuff(50);
			AudioManager.Sfx(SfxID.dirtImpact, base.transform.position, 0.2f, 1.1f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		}
	}

	public void AE_Shake()
	{
		Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, base.transform.position, 4);
		PlayDebrisPuff(10);
		AudioManager.Sfx(SfxID.grassImpact, base.transform.position, 0.3f, 1.15f, 0.125f);
	}

	private void PlayDebrisPuff(int count)
	{
		if (base.entityExist)
		{
			ObjectID objectID = base.objectData.objectID;
			Manager.effects.PlayPuff(objectID switch
			{
				ObjectID.TallLandKelp => PuffID.KelpDebris, 
				ObjectID.MeadowTallGrass => PuffID.GoldenLeafDebris, 
				_ => PuffID.LeafDebris, 
			}, base.transform.position, count);
		}
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
