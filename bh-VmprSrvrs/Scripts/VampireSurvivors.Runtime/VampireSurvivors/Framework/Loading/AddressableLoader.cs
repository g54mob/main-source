using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC.Types;

namespace VampireSurvivors.Framework.Loading
{
	public class AddressableLoader
	{
		public static bool SimulateThrottle;

		public static int ThrottleAmount;

		public static readonly string DefaultPath;

		private static string _currentAssetBundlePath;

		public static bool UseSyncLoad;

		public static string CurrentPath => null;

		private static string ReplaceAssetBundlePaths(IResourceLocation location)
		{
			return null;
		}

		[RuntimeInitializeOnLoadMethod]
		public static void SetInternalIdTransform()
		{
		}

		public static void SetPath(string path)
		{
		}

		public static void PointAtDlc(DlcType dlcType)
		{
		}

		public static T LoadAsset<T>(DlcType? dlcType, AssetReferenceT<T> assetReference, AddressableType handleType = AddressableType.DYNAMIC, string customGroupName = null, string customHandleKey = null) where T : UnityEngine.Object
		{
			return null;
		}

		public static T LoadAsset<T>(DlcType? dlcType, AssetReference assetReference, AddressableType handleType = AddressableType.DYNAMIC, string customGroupName = null, string customHandleKey = null)
		{
			return default(T);
		}

		public static T LoadAsset<T>(DlcType? dlcType, IResourceLocation assetLocation, AddressableType handleType = AddressableType.DYNAMIC, string customGroupName = null, string customHandleKey = null)
		{
			return default(T);
		}

		public static void LoadAssetAsync<T>(DlcType? dlcType, AssetReferenceT<T> assetReference, AddressableType handleType = AddressableType.DYNAMIC, string customGroupName = null, string customHandleKey = null, Action<T> onComplete = null) where T : UnityEngine.Object
		{
		}

		public static void LoadAssetAsync<T>(DlcType? dlcType, AssetReference assetReference, AddressableType handleType = AddressableType.DYNAMIC, string customGroupName = null, string customHandleKey = null, Action<T> onComplete = null)
		{
		}

		public static void LoadAssetAsync<T>(DlcType? dlcType, IResourceLocation assetLocation, AddressableType handleType = AddressableType.DYNAMIC, string customGroupName = null, string customHandleKey = null, Action<T> onComplete = null)
		{
		}

		public static void DoAssetLoad<T>(AsyncOperationHandle<T> op, Action<T> onComplete = null)
		{
		}

		public static bool CheckValidAssetReference(AssetReference assetReference)
		{
			return false;
		}
	}
}
