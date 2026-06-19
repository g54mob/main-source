public class HydraBossBait : EntityMonoBehaviour
{
	private PoolableAudioSource organSound;

	protected override void OnShow()
	{
		SfxID sfxID = base.objectData.objectID switch
		{
			ObjectID.HydraBossNatureBait => SfxID.windOrganNature, 
			ObjectID.HydraBossSeaBait => SfxID.windOrganSea, 
			ObjectID.HydraBossDesertBait => SfxID.windOrganDesert, 
			ObjectID.HydraBossVoidBait => SfxID.windOrganVoid, 
			_ => SfxID.__illegal__, 
		};
		if (sfxID != SfxID.__illegal__)
		{
			organSound = AudioManager.Sfx(sfxID, base.transform.position, 1f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true, 6f, 6f);
		}
		base.OnShow();
	}

	protected override void OnHide()
	{
		if (organSound != null)
		{
			organSound.FadeOutAndStop();
		}
		base.OnHide();
	}
}
