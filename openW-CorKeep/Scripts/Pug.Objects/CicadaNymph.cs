using System.Collections.Generic;

public class CicadaNymph : EntityMonoBehaviour
{
	public ParticleEffectSpawner emergeEffects;

	private readonly List<AudioManager.RunningSfxReference> _walkAudioLoop = new List<AudioManager.RunningSfxReference>();

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	public override void OnOccupied()
	{
		base.OnOccupied();
		if ((bool)emergeEffects)
		{
			emergeEffects.enabled = false;
		}
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		switch (animID)
		{
		case -1878077465:
			if ((bool)emergeEffects)
			{
				emergeEffects.enabled = true;
			}
			AudioManager.SfxFollowTransform(SfxTableID.cicadaEmerge, base.transform, 0.4f, 1.1f);
			return;
		case -281135240:
			AudioManager.SfxFollowTransform(SfxTableID.cicadaWalk, base.transform, 0.35f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _walkAudioLoop);
			break;
		}
		if (animID == 1203776827 || animID == -601574123)
		{
			StopWalkAudio();
		}
	}

	private void StopWalkAudio()
	{
		_walkAudioLoop.ForEach(delegate(AudioManager.RunningSfxReference audioSource)
		{
			audioSource.FadeOutAndStop();
		});
		_walkAudioLoop.Clear();
	}

	protected override void OnDeath()
	{
		StopWalkAudio();
		base.OnDeath();
	}
}
