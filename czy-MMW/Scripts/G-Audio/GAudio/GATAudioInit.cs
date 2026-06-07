using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GAudio
{
	public class GATAudioInit : MonoBehaviour
	{
		[Serializable]
		public class PlatformSettings
		{
			public RuntimePlatform platform;

			public int sampleRate;
		}

		public PlatformSettings[] platformSettings;

		public int levelToLoad = 1;

		public bool requestMic;

		private static GATAudioInit __uniqueInstance;

		private void Awake()
		{
			if (__uniqueInstance != null)
			{
				Debug.LogError("Only one GATAudioInit should exist!");
				UnityEngine.Object.Destroy(this);
				return;
			}
			__uniqueInstance = this;
			RuntimePlatform platform = Application.platform;
			PlatformSettings platformSettings = null;
			PlatformSettings[] array = this.platformSettings;
			foreach (PlatformSettings platformSettings2 in array)
			{
				if (platformSettings2.platform == platform)
				{
					platformSettings = platformSettings2;
					break;
				}
			}
			if (platformSettings != null && AudioSettings.outputSampleRate != platformSettings.sampleRate)
			{
				Debug.LogWarning("GATAudioInit's sample rate setting is obsolete in Unity 5. Target platform samplerate can be configured in project settings.");
			}
		}

		private IEnumerator Start()
		{
			if (requestMic)
			{
				yield return Application.RequestUserAuthorization(UserAuthorization.Microphone);
				if (Application.HasUserAuthorization(UserAuthorization.Microphone))
				{
					SceneManager.LoadScene(levelToLoad);
				}
			}
			else
			{
				SceneManager.LoadScene(levelToLoad);
			}
		}
	}
}
