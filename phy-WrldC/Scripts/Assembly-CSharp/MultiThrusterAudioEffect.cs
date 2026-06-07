using UnityEngine;

[RequireComponent(typeof(MultiThruster))]
public class MultiThrusterAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip thrusterClip;

	private MultiThruster multiThruster;

	private float maxVolume;

	private float maxPitch;

	protected override void Initialize()
	{
		multiThruster = GetComponent<MultiThruster>();
		maxVolume = 0.5f;
		maxPitch = 1f;
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		thrusterClip = gameStylesData.componentStylesData.multiThrusterClip;
	}

	protected override void Update()
	{
		base.Update();
		if (base.AudioSource == null || base.AudioEffectsManager.IsAudioSourcesInPause)
		{
			return;
		}
		base.AudioSource.transform.position = base.transform.position;
		if (multiThruster.CurrentThrustVector.magnitude > 0f)
		{
			if (!base.AudioSource.isPlaying)
			{
				base.AudioSource.clip = thrusterClip;
				base.AudioSource.priority = 128;
				base.AudioSource.loop = true;
				base.AudioSource.Play();
			}
			float num = multiThruster.CurrentThrustVector.magnitude / multiThruster.MaxThrust;
			base.AudioSource.volume = maxVolume * num;
			base.AudioSource.pitch = maxPitch * num;
		}
		else if (base.AudioSource.isPlaying)
		{
			base.AudioSource.Stop();
		}
	}
}
