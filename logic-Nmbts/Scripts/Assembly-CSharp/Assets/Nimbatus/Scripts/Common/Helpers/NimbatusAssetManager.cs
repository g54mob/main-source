using System.IO;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public class NimbatusAssetManager
	{
		private static AssetBundle _bundle;

		public static T[] LoadAll<T>() where T : Object
		{
			if (_bundle == null)
			{
				_bundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "Windows/mainbundle"));
			}
			return _bundle.LoadAllAssets<T>();
		}
	}
}
