using System;

namespace Game.Audio
{
	[Serializable]
	public class AudioSettingsContainer
	{
		public float masterVolume;

		public float musicVolume;

		public float sfxVolume;

		public float uiVolume;

		public float ambientVolume;

		public AudioSettingsContainer(float master = 0.8f, float music = 0.8f, float sfx = 1f, float ui = 0.7f, float ambient = 1f)
		{
			masterVolume = master;
			musicVolume = music;
			sfxVolume = sfx;
			uiVolume = ui;
			ambientVolume = ambient;
		}

		public static AudioSettingsContainer DefaultSettings()
		{
			return new AudioSettingsContainer();
		}
	}
}
