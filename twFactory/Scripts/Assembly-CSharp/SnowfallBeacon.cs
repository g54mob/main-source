using UnityEngine;

public class SnowfallBeacon : ResourceActivatedBuilding
{
	[SerializeField]
	private ParticleSystem[] particles;

	[SerializeField]
	private LightAnimation[] lightAnimations;

	[SerializeField]
	private AudioData activationSound;

	[SerializeField]
	private AudioSource loopAS;

	protected override void Start()
	{
		base.Start();
		for (int i = 0; i < particles.Length; i++)
		{
			particles[i].Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		}
	}

	protected override void OnActivate()
	{
		LTFunctionLibrary.GetLTLevelController().GetComponent<SnowfallController>().ActiveBeacons++;
		for (int i = 0; i < particles.Length; i++)
		{
			particles[i].Play();
		}
		for (int j = 0; j < lightAnimations.Length; j++)
		{
			lightAnimations[j].TurnOn();
		}
		if (base.CurrentDuration == 0f)
		{
			AudioSystem.Instance.PlaySound3D(activationSound, base.transform.position, AudioSystem.EAudioMixerGroup.SFX, AudioRolloffMode.Custom, 1f, 50f, null, 0f, 0f, loop: false, 0f, AudioSystem.EAudioPriority.High);
		}
		loopAS.Play();
	}

	protected override void OnDeactivate()
	{
		LTFunctionLibrary.GetLTLevelController().GetComponent<SnowfallController>().ActiveBeacons--;
		for (int i = 0; i < particles.Length; i++)
		{
			particles[i].Stop();
		}
		for (int j = 0; j < lightAnimations.Length; j++)
		{
			lightAnimations[j].TurnOff();
		}
		loopAS.Stop();
	}
}
