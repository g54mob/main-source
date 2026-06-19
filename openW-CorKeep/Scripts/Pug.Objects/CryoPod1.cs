public class CryoPod1 : Chest
{
	private PoolableAudioSource geigerSound;

	protected override void OnShow()
	{
		geigerSound = AudioManager.Sfx(SfxID.Scary_geiger_loop, base.transform.position, 0.85f, 1f, 0f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: false, useSpatialSound: true, loop: true, 13f, 13f);
		base.OnShow();
	}

	protected override void OnHide()
	{
		if (geigerSound != null)
		{
			geigerSound.FadeOutAndStop();
		}
		base.OnHide();
	}
}
