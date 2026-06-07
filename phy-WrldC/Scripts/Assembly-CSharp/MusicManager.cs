using UnityEngine;

public class MusicManager : MonoBehaviour
{
	[SerializeField]
	private GameObject audioSourcePrefab;

	private AudioSource audioSource;

	private AudioClip targetClip;

	private float targetVolume;

	private bool shouldPlay;

	private bool shouldStop;

	private bool shouldChangeVolume;

	private bool shouldAttenuate;

	private float volumeTransitionDuration;

	private float attenuationDuration;

	private float attenuationFadeOutDuration;

	private float timeCounter;

	private float currentVolumeVelocity;

	public static MusicManager Instance => Singleton<MusicManager>.Instance;

	public static bool Exist => Singleton<MusicManager>.Exist;

	private void Awake()
	{
		if (audioSourcePrefab != null)
		{
			GameObject gameObject = Object.Instantiate(audioSourcePrefab, base.transform);
			audioSource = gameObject.GetComponent<AudioSource>();
		}
		shouldPlay = false;
		shouldStop = false;
		shouldAttenuate = false;
		shouldChangeVolume = false;
		currentVolumeVelocity = 0f;
	}

	private void Update()
	{
		if (shouldStop)
		{
			audioSource.volume = Mathf.SmoothDamp(audioSource.volume, 0f, ref currentVolumeVelocity, 0.25f);
			if (audioSource.volume <= 0.001f)
			{
				audioSource.Stop();
				shouldStop = false;
			}
		}
		else if (shouldPlay)
		{
			if (!audioSource.isPlaying)
			{
				audioSource.clip = targetClip;
				audioSource.Play();
			}
			audioSource.volume = Mathf.SmoothDamp(audioSource.volume, targetVolume, ref currentVolumeVelocity, 0.25f);
			if (audioSource.volume >= targetVolume - 0.001f)
			{
				audioSource.volume = targetVolume;
				shouldPlay = false;
			}
		}
		if (!audioSource.isPlaying)
		{
			return;
		}
		if (shouldChangeVolume)
		{
			audioSource.volume = Mathf.SmoothDamp(audioSource.volume, targetVolume, ref currentVolumeVelocity, volumeTransitionDuration);
			if (audioSource.volume >= targetVolume - 0.001f && audioSource.volume <= targetVolume + 0.001f)
			{
				audioSource.volume = targetVolume;
				shouldChangeVolume = false;
			}
		}
		if (!shouldAttenuate)
		{
			return;
		}
		timeCounter += Time.deltaTime;
		if (timeCounter >= attenuationDuration)
		{
			audioSource.volume = Mathf.SmoothDamp(audioSource.volume, targetVolume, ref currentVolumeVelocity, attenuationFadeOutDuration);
			if (audioSource.volume >= targetVolume - 0.001f)
			{
				audioSource.volume = targetVolume;
				shouldAttenuate = false;
			}
		}
	}

	public void PlayMusic(AudioClip musicClip, float linearVolume = 1f)
	{
		if (musicClip == null)
		{
			return;
		}
		if (audioSource.isPlaying)
		{
			if (audioSource.clip == musicClip)
			{
				return;
			}
			shouldStop = true;
		}
		else
		{
			audioSource.volume = 0f;
		}
		targetClip = musicClip;
		targetVolume = linearVolume;
		currentVolumeVelocity = 0f;
		shouldAttenuate = false;
		shouldPlay = true;
	}

	public void StopMusic()
	{
		if (audioSource.isPlaying)
		{
			currentVolumeVelocity = 0f;
			shouldStop = true;
		}
	}

	public void SetVolume(float newLinearVolume, float transitionDuration = 0f)
	{
		if (newLinearVolume != targetVolume)
		{
			targetVolume = newLinearVolume;
			volumeTransitionDuration = transitionDuration;
			currentVolumeVelocity = 0f;
			timeCounter = 0f;
			shouldChangeVolume = true;
		}
	}

	public void MusicAttenuation(float duration, float fadeOutDuration, float attenuationRate = 1f)
	{
		attenuationDuration = duration;
		attenuationFadeOutDuration = fadeOutDuration;
		attenuationRate = Mathf.Clamp(attenuationRate, 0f, 1f);
		audioSource.volume = targetVolume * (1f - attenuationRate);
		currentVolumeVelocity = 0f;
		timeCounter = 0f;
		shouldAttenuate = true;
	}
}
