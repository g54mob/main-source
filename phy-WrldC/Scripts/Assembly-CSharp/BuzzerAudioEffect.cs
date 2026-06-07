using UnityEngine;

[RequireComponent(typeof(Buzzer))]
public class BuzzerAudioEffect : AudioEffectBase
{
	[SerializeField]
	private AudioClip buzzerClip;

	private float buzzerVolume;

	protected override void Initialize()
	{
		GetComponent<Buzzer>().OnBuzzerActiveEvent += OnBuzzerActiveHandler;
		buzzerVolume = 0.4f;
	}

	public override void SetAudiosByGameStyleData(GameStylesData gameStylesData)
	{
		base.SetAudiosByGameStyleData(gameStylesData);
		buzzerClip = gameStylesData.componentStylesData.buzzerClip;
		if (gameStylesData.volumeStylesData != null)
		{
			buzzerVolume = gameStylesData.volumeStylesData.buzzer;
		}
	}

	private void OnBuzzerActiveHandler(bool isActive, float activeSignal, float volume, float pitch)
	{
		if (base.AudioSource == null || base.AudioEffectsManager.IsAudioSourcesInPause)
		{
			return;
		}
		if (isActive)
		{
			base.AudioSource.volume = volume * buzzerVolume * activeSignal;
			base.AudioSource.pitch = pitch;
			if (!base.AudioSource.isPlaying)
			{
				base.AudioSource.clip = buzzerClip;
				base.AudioSource.priority = 128;
				base.AudioSource.loop = true;
				base.AudioSource.Play();
			}
			base.AudioSource.transform.position = base.transform.position;
		}
		else if (base.AudioSource.isPlaying)
		{
			base.AudioSource.Stop();
		}
	}

	private void OnBlockDestroyedHandler()
	{
		RecycleAudioSource();
	}
}
