using UnityEngine;
using UnityEngine.Audio;

namespace ModApi.Audio
{
	public interface IAudioPlayer
	{
		AudioSource CreateAudioSource(AudioFile audioFile, GameObject gameObjectToApplyAudioSourceTo, bool userInterfaceSound = true);

		AudioMixerGroup GetGameMixerGroup();

		AudioMixerGroup GetUiMixerGroup();

		AudioSource PlaySound(AudioFile audioFile, Vector3? position = null, bool userInterfaceSound = true);

		AudioSource PlaySound(AudioFile audioFile, Vector3? position, float volume, float delay = 0f, bool userInterfaceSound = true);

		void SetLowpassValues(float? cutoff, float? resonance);

		void SetMasterVolume(float volume);

		void SetMusicVolume(float volume);

		void SetSoundVolume(float volume);
	}
}
