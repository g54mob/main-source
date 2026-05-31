using MyBox.Internal;
using UnityEngine.SceneManagement;

namespace MyBox
{
	public static class MySceneBundle
	{
		public enum TransferSceneBundleOption
		{
			TRANSFER_ON_LAST_SCENE = 0,
			TRANSFER_ON_ANY_SCENE_UNLOADED = 1
		}

		private static SceneBundle currentSceneBundle;

		private static SceneBundle nextSceneBundle;

		public static TransferSceneBundleOption SceneBundleTransferOption { get; set; }

		static MySceneBundle()
		{
		}

		private static void PrepareSceneBundleForNextSceneByTransferOptions(Scene unloadedScene)
		{
		}

		private static bool IsUnloadingLastScene()
		{
			return false;
		}

		private static void PrepareSceneBundleForNextScene()
		{
		}

		public static void CarryOverCurrentBundleToNextBundle(bool overrideData = false)
		{
		}

		public static void AddStringDataToBundle(string dataKey, string data, bool overrideIfExists = true)
		{
		}

		public static void AddFloatDataToBundle(string dataKey, float data, bool overrideIfExists = true)
		{
		}

		public static void AddIntDataToBundle(string dataKey, int data, bool overrideIfExists = true)
		{
		}

		public static void AddBoolDataToBundle(string dataKey, bool data, bool overrideIfExists = true)
		{
		}

		public static void AddObjectDataToBundle(string dataKey, object data, bool overrideIfExists = true)
		{
		}

		public static bool TryGetStringDataFromBundle(string dataKey, out string result)
		{
			result = null;
			return false;
		}

		public static bool TryGetFloatDataFromBundle(string dataKey, out float result)
		{
			result = default(float);
			return false;
		}

		public static bool TryGetIntDataFromBundle(string dataKey, out int result)
		{
			result = default(int);
			return false;
		}

		public static bool TryGetBoolDataFromBundle(string dataKey, out bool result)
		{
			result = default(bool);
			return false;
		}

		public static bool TryGetObjectDataFromBundle(string dataKey, out object result)
		{
			result = null;
			return false;
		}
	}
}
