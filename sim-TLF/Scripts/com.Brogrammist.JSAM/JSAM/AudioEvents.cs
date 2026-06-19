using UnityEngine;

namespace JSAM
{
	public class AudioEvents : MonoBehaviour
	{
		public void PlaySoundByReference(SoundFileObject sound)
		{
			AudioManager.PlaySound(sound, base.transform);
		}

		public void PlaySoundByEnum(string enumName)
		{
			BaseAudioFileObject baseAudioFileObject = AudioManagerInternal.Instance.AudioFileFromString(enumName);
			if ((bool)baseAudioFileObject)
			{
				AudioManager.PlaySound(baseAudioFileObject as SoundFileObject, base.transform);
			}
		}

		public void StopSoundByEnum(string enumName)
		{
			BaseAudioFileObject baseAudioFileObject = AudioManagerInternal.Instance.AudioFileFromString(enumName);
			if ((bool)baseAudioFileObject)
			{
				AudioManager.StopSound(baseAudioFileObject as SoundFileObject, base.transform, stopInstantly: false);
			}
		}

		public void StopSoundByEnumInstantly(string enumName)
		{
			BaseAudioFileObject baseAudioFileObject = AudioManagerInternal.Instance.AudioFileFromString(enumName);
			if ((bool)baseAudioFileObject)
			{
				AudioManager.StopSound(baseAudioFileObject as SoundFileObject, base.transform);
			}
		}

		public void SetMasterVolume(float newVal)
		{
			AudioManager.MasterVolume = newVal;
		}

		public void SetMusicVolume(float newVal)
		{
			AudioManager.MusicVolume = newVal;
		}

		public void SetSoundVolume(float newVal)
		{
			AudioManager.SoundVolume = newVal;
		}

		public void SetVoiceVolume(float newVal)
		{
			AudioManager.VoiceVolume = newVal;
		}
	}
}
