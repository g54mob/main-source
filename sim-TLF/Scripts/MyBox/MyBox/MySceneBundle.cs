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
			SceneBundleTransferOption = TransferSceneBundleOption.TRANSFER_ON_LAST_SCENE;
			currentSceneBundle = new SceneBundle();
			nextSceneBundle = new SceneBundle();
			SceneManager.sceneUnloaded += PrepareSceneBundleForNextSceneByTransferOptions;
		}

		private static void PrepareSceneBundleForNextSceneByTransferOptions(Scene unloadedScene)
		{
			if (SceneBundleTransferOption == TransferSceneBundleOption.TRANSFER_ON_LAST_SCENE && IsUnloadingLastScene())
			{
				PrepareSceneBundleForNextScene();
			}
			else if (SceneBundleTransferOption == TransferSceneBundleOption.TRANSFER_ON_ANY_SCENE_UNLOADED)
			{
				PrepareSceneBundleForNextScene();
			}
		}

		private static bool IsUnloadingLastScene()
		{
			return SceneManager.sceneCount == 2;
		}

		private static void PrepareSceneBundleForNextScene()
		{
			currentSceneBundle = nextSceneBundle;
			nextSceneBundle = new SceneBundle();
		}

		public static void CarryOverCurrentBundleToNextBundle(bool overrideData = false)
		{
			nextSceneBundle.BoolData.AddBundleData(currentSceneBundle.BoolData, overrideData);
			nextSceneBundle.IntData.AddBundleData(currentSceneBundle.IntData, overrideData);
			nextSceneBundle.FloatData.AddBundleData(currentSceneBundle.FloatData, overrideData);
			nextSceneBundle.StringData.AddBundleData(currentSceneBundle.StringData, overrideData);
			nextSceneBundle.ObjectData.AddBundleData(currentSceneBundle.ObjectData, overrideData);
		}

		public static void AddStringDataToBundle(string dataKey, string data, bool overrideIfExists = true)
		{
			nextSceneBundle.StringData.AddData(dataKey, data, overrideIfExists);
		}

		public static void AddFloatDataToBundle(string dataKey, float data, bool overrideIfExists = true)
		{
			nextSceneBundle.FloatData.AddData(dataKey, data, overrideIfExists);
		}

		public static void AddIntDataToBundle(string dataKey, int data, bool overrideIfExists = true)
		{
			nextSceneBundle.IntData.AddData(dataKey, data, overrideIfExists);
		}

		public static void AddBoolDataToBundle(string dataKey, bool data, bool overrideIfExists = true)
		{
			nextSceneBundle.BoolData.AddData(dataKey, data, overrideIfExists);
		}

		public static void AddObjectDataToBundle(string dataKey, object data, bool overrideIfExists = true)
		{
			nextSceneBundle.ObjectData.AddData(dataKey, data, overrideIfExists);
		}

		public static bool TryGetStringDataFromBundle(string dataKey, out string result)
		{
			return currentSceneBundle.StringData.TryGetData(dataKey, out result);
		}

		public static bool TryGetFloatDataFromBundle(string dataKey, out float result)
		{
			return currentSceneBundle.FloatData.TryGetData(dataKey, out result);
		}

		public static bool TryGetIntDataFromBundle(string dataKey, out int result)
		{
			return currentSceneBundle.IntData.TryGetData(dataKey, out result);
		}

		public static bool TryGetBoolDataFromBundle(string dataKey, out bool result)
		{
			return currentSceneBundle.BoolData.TryGetData(dataKey, out result);
		}

		public static bool TryGetObjectDataFromBundle(string dataKey, out object result)
		{
			return currentSceneBundle.ObjectData.TryGetData(dataKey, out result);
		}
	}
}
