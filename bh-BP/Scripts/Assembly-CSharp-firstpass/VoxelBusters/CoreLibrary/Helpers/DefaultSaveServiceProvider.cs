using UnityEngine;

namespace VoxelBusters.CoreLibrary.Helpers
{
	public class DefaultSaveServiceProvider : ISaveServiceProvider
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnLoad()
		{
		}

		public int GetInt(string key, int defaultValue = 0)
		{
			return 0;
		}

		public float GetFloat(string key, float defaultValue = 0f)
		{
			return 0f;
		}

		public string GetString(string key, string defaultValue = null)
		{
			return null;
		}

		public string[] GetStringArray(string key, string[] defaultValue = null)
		{
			return null;
		}

		public void SetInt(string key, int value)
		{
		}

		public void SetFloat(string key, float value)
		{
		}

		public void SetString(string key, string value)
		{
		}

		public void SetStringArray(string key, string[] value)
		{
		}

		public void RemoveKey(string key)
		{
		}

		public void Save()
		{
		}
	}
}
