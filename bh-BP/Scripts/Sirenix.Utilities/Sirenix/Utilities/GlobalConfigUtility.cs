using UnityEngine;

namespace Sirenix.Utilities
{
	public static class GlobalConfigUtility<T> where T : ScriptableObject
	{
		private static T instance;

		public static bool HasInstanceLoaded => false;

		public static T GetInstance(string defaultAssetFolderPath, string defaultFileNameWithoutExtension = null)
		{
			return null;
		}

		internal static void LoadInstanceIfAssetExists(string assetPath, string defaultFileNameWithoutExtension = null)
		{
		}
	}
}
