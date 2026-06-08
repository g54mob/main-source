using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;

	public AudioSource audioPlayer;

	private void Awake()
	{
		Instance = this;
	}

	public void PlaySoundAtPosition(AudioClipOptions audioOptions, Vector3 position)
	{
		if (!(audioOptions == null) && !(audioOptions.audioClip == null))
		{
			AudioSource audioSource = Object.Instantiate(audioPlayer, position, Quaternion.identity);
			SetupAudioPlayer(audioSource, audioOptions);
			audioSource.Play();
			Object.Destroy(audioSource.gameObject, audioOptions.audioClip.length);
		}
	}

	public void PlayGlobalSound(AudioClipOptions audioOptions)
	{
		if (!(audioOptions == null) && !(audioOptions.audioClip == null))
		{
			PlaySoundAtPosition(audioOptions, Vector3.zero);
		}
	}

	public void PlaySoundAtTransform(AudioClipOptions audioOptions, Transform parentTransform)
	{
		if (!(audioOptions == null) && !(audioOptions.audioClip == null))
		{
			AudioSource audioSource = Object.Instantiate(audioPlayer, parentTransform, worldPositionStays: false);
			SetupAudioPlayer(audioSource, audioOptions);
			audioSource.Play();
			if (!audioOptions.looping)
			{
				Object.Destroy(audioSource.gameObject, audioOptions.audioClip.length);
			}
		}
	}

	private void SetupAudioPlayer(AudioSource audioPlayer, AudioClipOptions audioOptions)
	{
		audioPlayer.transform.localPosition = Vector3.zero;
		audioPlayer.pitch = Random.Range(audioOptions.randomPitch.x, audioOptions.randomPitch.y);
		audioPlayer.volume = audioOptions.volume;
		audioPlayer.spatialBlend = audioOptions.spatialBlend;
		audioPlayer.dopplerLevel = audioOptions.dopplerLevel;
		audioPlayer.loop = audioOptions.looping;
		audioPlayer.clip = audioOptions.audioClip;
		if (!audioOptions.useCustom3DSettings)
		{
			return;
		}
		audioPlayer.rolloffMode = audioOptions.rolloffMode;
		audioPlayer.minDistance = audioOptions.minDistance;
		audioPlayer.maxDistance = audioOptions.maxDistance;
		if (audioOptions.useCustomCurves)
		{
			AudioCurveSettings[] audioCurves = audioOptions.audioCurves;
			foreach (AudioCurveSettings audioCurveSettings in audioCurves)
			{
				audioPlayer.SetCustomCurve(audioCurveSettings.curveType, audioCurveSettings.curve);
			}
		}
	}
}
