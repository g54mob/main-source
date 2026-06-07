using Reactivity;
using UnityEngine;

namespace FractureField.Managers
{
	public class PlayerPrefsManager
	{
		public RTrigger OnMasterVolumeChanged { get; }

		public float MasterVolume
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public RTrigger OnMusicVolumeChanged { get; }

		public float MusicVolume
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float SoundEffectsVolume
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public FullScreenMode ScreenMode
		{
			get
			{
				return default(FullScreenMode);
			}
			set
			{
			}
		}

		private float GetFloat(string key, float defaultValue)
		{
			return 0f;
		}

		private void SetFloat(string key, float value)
		{
		}

		private int GetInt(string key, int defaultValue)
		{
			return 0;
		}

		private void SetInt(string key, int value)
		{
		}

		private bool GetBool(string key, bool defaultValue)
		{
			return false;
		}

		private void SetBool(string key, bool value)
		{
		}

		public static T Get<T>(string key)
		{
			return default(T);
		}

		public static void Set(string key, object value)
		{
		}
	}
}
