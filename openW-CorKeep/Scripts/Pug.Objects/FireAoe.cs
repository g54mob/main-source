using Pug.UnityExtensions;
using UnityEngine;

public class FireAoe : EntityMonoBehaviour
{
	public ParticleSystem fireParticles;

	public Light lightSource;

	private TimerSimple lightTimer;

	protected override bool hideDirectlyOnDeath => false;

	public override void OnOccupied()
	{
		base.OnOccupied();
		fireParticles.Play(withChildren: true);
		AudioManager.Sfx(SfxID.fireball, base.transform.position, 0.4f, 1f, 0.1f, reuse: true, AudioManager.MixerGroupEnum.EFFECTS, ignoreAudioIfOutsideOfViewport: true);
		lightTimer.Start(0.5f);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (lightTimer.isTimerElapsed)
		{
			lightSource.intensity = 0f;
		}
		else
		{
			lightSource.intensity = lightTimer.invElapsedRatio;
		}
	}
}
