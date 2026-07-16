namespace Game.Audio
{
	public class AudioSettings
	{
		public static void SetMasterVolume(float value)
		{
			SoundManager.SetVolume("MasterVolume", value);
		}

		public static void SetMusicVolume(float value)
		{
			SoundManager.SetVolume("MusicVolume", value);
		}

		public static void SetSFXVolume(float value)
		{
			SoundManager.SetVolume("SFXVolume", value);
		}

		public static void SetUIVolume(float value)
		{
			SoundManager.SetVolume("UIVolume", value);
		}

		public static void SetAmbientVolume(float value)
		{
			SoundManager.SetVolume("AmbientVolume", value);
		}
	}
}
