using System.Collections.Generic;
using UnityEngine;

namespace FuryStudios.FurySDK.Internal
{
	public class PlatformPlayerPrefs : IPlatformPlayerPrefs
	{
		private class PlayerPrefsSaveData
		{
			public Dictionary<string, int> savedInt;

			public Dictionary<string, float> savedFloat;

			public Dictionary<string, string> savedString;

			public static PlayerPrefsSaveData Deserialize(byte[] bytes)
			{
				return null;
			}

			public static byte[] Serialize(PlayerPrefsSaveData data)
			{
				return null;
			}
		}

		private class PlayerPrefsLoadRequest : AsyncRequest<PlayerPrefsSaveData>
		{
			private readonly ContainerID container;

			private readonly string filename;

			public PlayerPrefsLoadRequest(ContainerID container, string filename)
			{
			}

			protected override void OnStarted()
			{
			}
		}

		private class PlayerPrefsSaveRequest : AsyncRequest
		{
			private readonly ContainerID container;

			private readonly string filename;

			private readonly PlayerPrefsSaveData data;

			public PlayerPrefsSaveRequest(ContainerID container, string filename, PlayerPrefsSaveData data)
			{
			}

			protected override void OnStarted()
			{
			}
		}

		private PlayerPrefsSaveData data;

		private ContainerID container;

		private string filename;

		private AsyncRequestScheduler scheduler;

		[RuntimeInitializeOnLoadMethod]
		public static void RegisterSelf()
		{
		}

		public void Update()
		{
		}

		public IAsyncRequest Load()
		{
			return null;
		}

		public IAsyncRequest Load(ContainerID container, string filename)
		{
			return null;
		}

		public IAsyncRequest Save()
		{
			return null;
		}

		public IAsyncRequest DeleteAll()
		{
			return null;
		}

		public void DeleteKey(string keyToDel)
		{
		}

		public bool HasKey(string key)
		{
			return false;
		}

		public int GetInt(string key, int defaultValue = 0)
		{
			return 0;
		}

		public float GetFloat(string key, float defaultValue = 0f)
		{
			return 0f;
		}

		public string GetString(string key, string defaultValue = "")
		{
			return null;
		}

		public void SetInt(string key, int setValue)
		{
		}

		public void SetFloat(string key, float setValue)
		{
		}

		public void SetString(string key, string setValue)
		{
		}
	}
}
