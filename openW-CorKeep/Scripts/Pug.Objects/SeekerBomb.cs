using System.Collections.Generic;

public class SeekerBomb : EntityMonoBehaviour
{
	private readonly List<AudioManager.RunningSfxReference> _loopSounds = new List<AudioManager.RunningSfxReference>();

	protected override void OnShow()
	{
		AudioManager.SfxFollowTransform(SfxTableID.seekerBombFuse, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _loopSounds);
		base.OnShow();
	}

	protected override void OnHide()
	{
		StopAudioLoop();
		base.OnHide();
	}

	private void StopAudioLoop()
	{
		foreach (AudioManager.RunningSfxReference loopSound in _loopSounds)
		{
			loopSound.Stop();
		}
		_loopSounds.Clear();
	}
}
