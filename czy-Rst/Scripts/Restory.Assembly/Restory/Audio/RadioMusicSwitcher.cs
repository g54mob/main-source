using System;
using FMODUnity;
using UnityEngine;

namespace Restory.Audio
{
	public class RadioMusicSwitcher : IDisposable
	{
		private IAudioPlayerService audioPlayer;

		private EventReference radioPowerSwitchSoundEvent;

		private RadioMusicTracksSwitcher musicTracksSwitcher;

		public RadioMusicSwitcher(IAudioPlayerService audioPlayer, RadioMusicTracksSwitcher musicTracksSwitcher, EventReference radioPowerSwitchSoundEvent)
		{
			this.musicTracksSwitcher = musicTracksSwitcher;
			this.radioPowerSwitchSoundEvent = radioPowerSwitchSoundEvent;
			this.audioPlayer = audioPlayer;
		}

		public void Dispose()
		{
			StopRadioSounds();
		}

		public void ToggleRadioSounds(bool isPlaying, GameObject targetObject)
		{
			audioPlayer.PlaySoundEventOneShot(radioPowerSwitchSoundEvent, targetObject);
			if (isPlaying)
			{
				PlayRadioSounds(targetObject);
			}
			else
			{
				StopRadioSounds();
			}
		}

		private void PlayRadioSounds(GameObject soundSourceObject)
		{
			musicTracksSwitcher.StartPlaying(soundSourceObject);
		}

		private void StopRadioSounds()
		{
			musicTracksSwitcher.StopPlaying();
		}
	}
}
