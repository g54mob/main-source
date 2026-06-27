using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace Restory.Audio
{
	public interface IAudioPlayerService
	{
		float GetBusVolume(AudioMixerBus bus);

		void SetBusVolume(AudioMixerBus bus, float volume);

		void PlayTestSoundForBus(AudioMixerBus audioMixerBus);

		void SetSceneVolume(float volume);

		bool TryToStartSoundEvent(EventReference soundEvent, out EventInstance soundEventInstance);

		bool TryToStartSoundEvent(EventReference soundEvent, GameObject soundSourceGameObject, out EventInstance soundEventInstance);

		bool TryToStartSoundEventAttached(EventReference soundEvent, GameObject soundSourceGameObject, out EventInstance soundEventInstance);

		void RestartSoundEventInstance(EventInstance eventInstance);

		void StopSoundEventInstance(EventInstance eventInstance, bool allowFadeOut = true);

		void PlaySoundEventOneShot(EventReference soundEvent, GameObject soundSourceGameObject = null);

		void PlaySoundEventOneShot(EventReference soundEvent, Vector3 soundSourcePosition);

		bool TryToPlaySoundEventOneShotAttached(EventReference soundEvent, GameObject soundSourceGameObject);

		void DetachSoundInstanceFromGameObject(EventInstance soundInstance);

		void PauseAllSFX();

		void ResumeAllPausedSounds();

		float GetSoundEventInstanceParameterValue(EventInstance soundEventInstance, PARAMETER_ID parameterId);

		void SetSoundEventInstanceParameterValue(EventInstance eventInstance, PARAMETER_ID parameterId, float parameterValue);

		PARAMETER_ID GetSoundInstanceParameterIdByName(EventInstance soundEventInstance, string parameterName);

		void SetGlobalParameterValue(string parameterName, float value);

		bool TryToCreateSoundEventAttached(EventReference soundEvent, GameObject soundSourceGameObject, out EventInstance soundEventInstance, bool startSoundEventInstance = true);
	}
}
