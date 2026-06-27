using System;
using Restory.Audio;
using UnityEngine;
using UnityEngine.Events;

namespace Restory.Gameplay.GameSettings
{
	[Serializable]
	public class AudioFMODSettings
	{
		[Serializable]
		public class AudioTypeSettings
		{
			public UnityEvent<AudioTypeSettings> OnSettingsChanged = new UnityEvent<AudioTypeSettings>();

			public bool Active = true;

			[SerializeField]
			private float volume = 1f;

			public AudioMixerBus AudioBusType { get; private set; }

			public float Volume
			{
				get
				{
					return volume;
				}
				set
				{
					if (volume != Mathf.Clamp01(value))
					{
						volume = value;
						OnSettingsChanged?.Invoke(this);
					}
				}
			}

			public AudioTypeSettings(AudioMixerBus type, bool active = true, float volume = 1f)
			{
				AudioBusType = type;
				Active = active;
				this.volume = volume;
			}

			public void NextVolume(bool isCarousel = true)
			{
				if (Volume >= 1f)
				{
					Volume = (isCarousel ? 0f : 1f);
				}
				else
				{
					Volume += 0.1f;
				}
			}

			public void PreviousVolume(bool isCarousel = true)
			{
				if (Volume <= 0.1f)
				{
					Volume = (isCarousel ? 1f : 0f);
				}
				else
				{
					Volume -= 0.1f;
				}
			}

			public AudioTypeSettings Clone()
			{
				return new AudioTypeSettings(AudioBusType, Active, volume);
			}
		}

		public AudioTypeSettings Master = new AudioTypeSettings(AudioMixerBus.Master);

		public AudioTypeSettings SFX = new AudioTypeSettings(AudioMixerBus.SFX);

		public AudioTypeSettings Music = new AudioTypeSettings(AudioMixerBus.Music);

		public void Debug()
		{
			UnityEngine.Debug.Log("--------------------------------------------------------------------");
			UnityEngine.Debug.Log("Master " + Master.Active + " " + Master.Volume.ToString("F4"));
			UnityEngine.Debug.Log("SFX " + SFX.Active + " " + SFX.Volume.ToString("F4"));
			UnityEngine.Debug.Log("Music " + Music.Active + " " + Music.Volume.ToString("F4"));
			UnityEngine.Debug.Log("--------------------------------------------------------------------");
		}

		public AudioFMODSettings Clone()
		{
			return new AudioFMODSettings
			{
				Master = Master.Clone(),
				SFX = SFX.Clone(),
				Music = Music.Clone()
			};
		}
	}
}
