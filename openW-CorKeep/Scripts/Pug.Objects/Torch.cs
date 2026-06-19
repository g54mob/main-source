using System.Collections.Generic;

public class Torch : EntityMonoBehaviour
{
	private List<AudioManager.RunningSfxReference> loopingSfx = new List<AudioManager.RunningSfxReference>();

	protected override void OnShow()
	{
		base.OnShow();
		AudioManager.Sfx(SfxTableID.torchFireSfx, base.transform.position, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, loopingSfx);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.DirtBlockDust, base.transform.position, 2);
		Manager.effects.PlayPuff(PuffID.FireFloaters, particleOptions.particleSpawnLocations[0].position, 5);
		Manager.effects.PlayPuff(PuffID.SparksMachine, particleOptions.particleSpawnLocations[0].position, 2);
		if (loopingSfx == null)
		{
			return;
		}
		foreach (AudioManager.RunningSfxReference item in loopingSfx)
		{
			item.FadeOutAndStop();
		}
		loopingSfx.Clear();
	}

	protected override void OnHide()
	{
		base.OnHide();
		if (loopingSfx == null)
		{
			return;
		}
		foreach (AudioManager.RunningSfxReference item in loopingSfx)
		{
			item.FadeOutAndStop();
		}
		loopingSfx.Clear();
	}
}
