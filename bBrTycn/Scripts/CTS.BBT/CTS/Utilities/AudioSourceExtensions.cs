using System;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.Utilities
{
	public static class AudioSourceExtensions
	{
		public static event Action Pause;

		public static void PlaySoundAsset(this AudioSource source, SoundAsset soundAsset)
		{
		}

		public static void PlayanotherMusicAssec(this AudioSource source, AudioAsset audioAsset, AudioClip lastaudioclip)
		{
			if (source != null)
			{
				source.PlaySoundAsset(audioAsset, audioAsset.VolumeRange.RandomInRange(), lastaudioclip);
			}
		}

		public static void PlaySoundAsset(this AudioSource source, AudioAsset audioAsset)
		{
			if (source != null)
			{
				source.PlaySoundAsset(audioAsset, audioAsset.VolumeRange.RandomInRange());
			}
		}

		public static void PlaySoundAsset(this AudioSource source, SoundAsset soundAsset, float volume)
		{
			if (source.isActiveAndEnabled && soundAsset.AudioClips.Length != 0)
			{
				source.priority = soundAsset.Priority;
				source.pitch = soundAsset.PitchRange.RandomInRange();
				source.loop = soundAsset.Loop;
				source.volume = volume;
				source.PlayOneShot(soundAsset.AudioClips.GetRandom());
			}
		}

		public static void PlaySoundAsset(this AudioSource source, AudioAsset audioAsset, float volume, AudioClip audioClip = null)
		{
			if (!source.isActiveAndEnabled || audioAsset.AudioClips.Length == 0)
			{
				return;
			}
			source.priority = audioAsset.Priority;
			source.pitch = audioAsset.PitchRange.RandomInRange();
			source.loop = audioAsset.Loop;
			source.volume = volume;
			source.spatialBlend = audioAsset.SpatialMix;
			if (source.TryGetComponent<AudioSourceTime>(out var component))
			{
				if (audioAsset.AffectedByTime)
				{
					component.SubscribeEvent();
				}
				else
				{
					component.UnsubscribeEvent();
				}
			}
			if (audioAsset.MixerGroup != null)
			{
				source.outputAudioMixerGroup = audioAsset.MixerGroup;
			}
			if (audioClip == null)
			{
				source.clip = audioAsset.AudioClips.GetRandom();
			}
			else
			{
				source.clip = audioClip;
			}
			source.PlayDelayed(audioAsset.PlaybackDelay);
		}

		public static void LoopSoundAsset(this AudioSource source, SoundAsset soundAsset)
		{
			if (source.isActiveAndEnabled && soundAsset.AudioClips.Length != 0)
			{
				source.priority = soundAsset.Priority;
				source.pitch = soundAsset.PitchRange.RandomInRange();
				source.loop = soundAsset.Loop;
				source.volume = soundAsset.VolumeRange.RandomInRange();
				source.clip = soundAsset.AudioClips.GetRandom();
				source.Play();
			}
		}

		public static void LoopSoundAsset(this AudioSource source, AudioAsset soundAsset)
		{
			if (source.isActiveAndEnabled && soundAsset.AudioClips.Length != 0)
			{
				source.priority = soundAsset.Priority;
				source.pitch = soundAsset.PitchRange.RandomInRange();
				source.loop = soundAsset.Loop;
				source.volume = soundAsset.VolumeRange.RandomInRange();
				source.clip = soundAsset.AudioClips.GetRandom();
				source.Play();
			}
		}
	}
}
