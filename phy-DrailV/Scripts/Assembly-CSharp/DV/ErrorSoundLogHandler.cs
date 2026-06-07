using UnityEngine;

namespace DV
{
	public class ErrorSoundLogHandler : MonoBehaviour
	{
		private const string PREF_KEY = "DV.ErrorSounds";

		private static bool _initialized;

		private static bool _soundEnabled;

		public AudioSource sound;

		public float pitchRandomizeRange = 1f;

		public static bool SoundEnabled
		{
			get
			{
				if (!_initialized)
				{
					_initialized = true;
					_soundEnabled = PlayerPrefs.GetInt("DV.ErrorSounds", 0) != 0;
				}
				return _soundEnabled;
			}
			set
			{
				_soundEnabled = value;
				PlayerPrefs.SetInt("DV.ErrorSounds", value ? 1 : 0);
			}
		}

		private void Awake()
		{
			Object.DontDestroyOnLoad(base.gameObject);
		}

		private void OnEnable()
		{
			Application.logMessageReceived += HandleLog;
		}

		private void OnDisable()
		{
			Application.logMessageReceived -= HandleLog;
		}

		private void HandleLog(string logString, string stackTrace, LogType type)
		{
			if (SoundEnabled && (type == LogType.Error || type == LogType.Exception))
			{
				float num = pitchRandomizeRange * 0.5f;
				sound.pitch = Random.Range(1f - num, 1f + num);
				sound.Play();
			}
		}
	}
}
