using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using VampireSurvivors.Framework.DLC.Types;

namespace VampireSurvivors.Framework.Loading
{
	public static class AddressableCache
	{
		private static readonly List<AsyncOperationHandle> PersistentOperationHandles;

		private static readonly Dictionary<AssetReference, AsyncOperationHandle> DynamicOperationHandles;

		private static readonly Dictionary<IResourceLocation, AsyncOperationHandle> DynamicLocationOperationHandles;

		private static readonly Dictionary<string, Dictionary<string, AsyncOperationHandle>> CustomOperationHandles;

		private static readonly Dictionary<string, List<string>> TextureCache;

		public static List<AsyncOperationHandle> GetPersistentOperationHandles()
		{
			return null;
		}

		public static Dictionary<AssetReference, AsyncOperationHandle> GetDynamicOperationHandles()
		{
			return null;
		}

		public static Dictionary<IResourceLocation, AsyncOperationHandle> GetDynamicLocationOperationHandles()
		{
			return null;
		}

		public static Dictionary<string, Dictionary<string, AsyncOperationHandle>> GetCustomOperationHandles()
		{
			return null;
		}

		public static void ReleaseAll()
		{
		}

		public static void ReleaseAllCustomOperationHandles()
		{
		}

		public static void ReleaseCustomOperationHandleGroups(List<string> groupNames)
		{
		}

		public static void ReleaseCustomOperationHandleGroup(string groupName)
		{
		}

		public static void ReleaseCustomOperationHandleGroupExcludingKeys(string groupName, List<string> excludedKeys)
		{
		}

		public static void ReleaseCustomOperationHandles(string groupName, List<string> keys)
		{
		}

		public static void ReleaseCustomOperationHandle(string groupName, string key)
		{
		}

		public static List<string> GetCustomOperationHandleKeys(string groupName)
		{
			return null;
		}

		public static void ReleasePersistentOperationHandles()
		{
		}

		public static void ReleaseDynamicOperationHandles()
		{
		}

		public static void SavePersistentHandle(AsyncOperationHandle handle)
		{
		}

		public static AsyncOperationHandle? TryAndGetFromCache(AssetReference assetReference, AddressableType handleType, string customGroupName, string customHandleKey)
		{
			return null;
		}

		public static AsyncOperationHandle? TryAndGetFromCache(IResourceLocation assetResourceLocation, AddressableType handleType, string customGroupName, string customHandleKey)
		{
			return null;
		}

		public static void SaveHandle(AssetReference assetReference, AsyncOperationHandle op, AddressableType handleType, string customGroupName, string customHandleKey)
		{
		}

		public static void SaveHandle(IResourceLocation assetResourceLocation, AsyncOperationHandle op, AddressableType handleType, string customGroupName, string customHandleKey)
		{
		}

		private static AsyncOperationHandle? TryAndGetFromCustomCache(string customGroupName, string customHandleKey)
		{
			return null;
		}

		private static void SaveCustomHandle(AsyncOperationHandle op, string customGroupName, string customHandleKey)
		{
		}

		public static Dictionary<string, List<string>> GetTextureCache()
		{
			return null;
		}

		public static void SaveTexture(string cacheGroup, string textureName)
		{
		}

		public static bool TextureExistsInCache(string cacheGroup, string texture)
		{
			return false;
		}

		public static List<string> GetTexturesInGroup(string cacheGroup)
		{
			return null;
		}

		public static void RemoveTexture(string cacheGroup, string texture)
		{
		}

		public static void RemoveTextures(string cacheGroup, List<string> textures)
		{
		}

		public static void RemoveTextureGroup(string cacheGroup)
		{
		}

		public static void RemoveTexturesFromCacheAndSpriteManager(string cacheGroup)
		{
		}
	}
}
