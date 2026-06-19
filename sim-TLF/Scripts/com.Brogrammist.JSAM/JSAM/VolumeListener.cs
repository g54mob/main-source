using System;
using UnityEngine;

namespace JSAM
{
	public class VolumeListener : MonoBehaviour
	{
		[SerializeField]
		[Range(0f, 1f)]
		protected float relativeVolume = 1f;

		[SerializeField]
		protected VolumeChannel volumeChannel = VolumeChannel.Sound;

		protected VolumeChannel subscribedChannel;

		[SerializeField]
		protected AudioSource audioSource;

		public float RelativeVolume => relativeVolume;

		public AudioSource AudioSource => audioSource;

		protected void SubscribeToVolumeEvents()
		{
			switch (volumeChannel)
			{
			case VolumeChannel.Music:
				AudioManager.OnMusicVolumeChanged = (Action<float, float>)Delegate.Combine(AudioManager.OnMusicVolumeChanged, new Action<float, float>(OnUpdateVolume));
				break;
			case VolumeChannel.Sound:
				AudioManager.OnSoundVolumeChanged = (Action<float, float>)Delegate.Combine(AudioManager.OnSoundVolumeChanged, new Action<float, float>(OnUpdateVolume));
				break;
			case VolumeChannel.Voice:
				AudioManager.OnVoiceVolumeChanged = (Action<float, float>)Delegate.Combine(AudioManager.OnVoiceVolumeChanged, new Action<float, float>(OnUpdateVolume));
				break;
			}
		}

		protected void UnsubscribeFromAudioEvents()
		{
			switch (volumeChannel)
			{
			case VolumeChannel.Music:
				AudioManager.OnMusicVolumeChanged = (Action<float, float>)Delegate.Remove(AudioManager.OnMusicVolumeChanged, new Action<float, float>(OnUpdateVolume));
				break;
			case VolumeChannel.Sound:
				AudioManager.OnSoundVolumeChanged = (Action<float, float>)Delegate.Remove(AudioManager.OnSoundVolumeChanged, new Action<float, float>(OnUpdateVolume));
				break;
			case VolumeChannel.Voice:
				AudioManager.OnVoiceVolumeChanged = (Action<float, float>)Delegate.Remove(AudioManager.OnVoiceVolumeChanged, new Action<float, float>(OnUpdateVolume));
				break;
			}
		}

		protected void OnUpdateVolume(float channelVolume, float realVolume)
		{
			audioSource.volume = realVolume * relativeVolume;
		}

		protected void ForceUpdateVolume()
		{
			switch (subscribedChannel)
			{
			case VolumeChannel.Music:
				OnUpdateVolume(AudioManagerInternal.Instance.MusicVolume, AudioManagerInternal.Instance.ModifiedMusicVolume);
				break;
			case VolumeChannel.Sound:
				OnUpdateVolume(AudioManagerInternal.Instance.SoundVolume, AudioManagerInternal.Instance.ModifiedSoundVolume);
				break;
			case VolumeChannel.Voice:
				OnUpdateVolume(AudioManagerInternal.Instance.VoiceVolume, AudioManagerInternal.Instance.ModifiedVoiceVolume);
				break;
			}
		}
	}
}
