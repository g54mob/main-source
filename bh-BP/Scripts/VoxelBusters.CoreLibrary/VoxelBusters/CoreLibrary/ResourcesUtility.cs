using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public static class ResourcesUtility
	{
		public static T LoadBuiltinAsset<T>(string name) where T : Object
		{
			return null;
		}

		public static T LoadAsset<T>(this UnityPackageDefinition package, string name) where T : Object
		{
			return null;
		}
	}
}
