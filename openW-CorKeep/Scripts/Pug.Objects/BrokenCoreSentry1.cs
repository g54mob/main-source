public class BrokenCoreSentry1 : EntityMonoBehaviour
{
	protected override void OnDeath()
	{
		AudioManager.Sfx(SfxID.dirtImpact, base.transform.position, 1f, 0.7f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true, useSpatialSound: true, loop: false, 16f, 10f, muteVolumeWhilePaused: true, freeAudioSourceAfterItStoppedPlaying: true, playOnGamepad: true);
		AudioManager.Sfx(SfxID.wall, base.transform.position, 1f, 0.7f, 0.05f, reuse: false, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		Manager.effects.PlayPuff(PuffID.StoneImpact, center);
	}
}
