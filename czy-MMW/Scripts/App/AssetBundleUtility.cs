using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;

public static class AssetBundleUtility
{
	public class AsyncLoadResult
	{
		public Object asset;

		private string _bundleName;

		private string _assetName;

		public bool HasValue => asset != null;

		public AsyncLoadResult(string bundleName, string assetName)
		{
			_bundleName = bundleName;
			_assetName = assetName;
		}

		public IEnumerator AsyncLoadAsset()
		{
			string path = Path.Combine(Application.streamingAssetsPath, "AssetBundles", _bundleName);
			AssetBundleCreateRequest bundleLoadRequest = AssetBundle.LoadFromFileAsync(path);
			yield return bundleLoadRequest;
			AssetBundle myLoadedAssetBundle = bundleLoadRequest.assetBundle;
			if (myLoadedAssetBundle == null)
			{
				Log.Warn("Failed to load AssetBundle {0}/{1}!", _bundleName, _assetName);
				yield break;
			}
			AssetBundleRequest assetLoadRequest = myLoadedAssetBundle.LoadAssetAsync(_assetName);
			yield return assetLoadRequest;
			asset = assetLoadRequest.asset;
			if (asset == null)
			{
				DebugMissingAsset(myLoadedAssetBundle, _assetName);
			}
			myLoadedAssetBundle.Unload(unloadAllLoadedObjects: false);
		}
	}

	private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("AssetBundleUtility");

	private static Dictionary<string, AssetBundle> _assetBundles = new Dictionary<string, AssetBundle>();

	public static GameObject LoadPrefab(string bundleName, string prefabName)
	{
		return LoadAsset<GameObject>(bundleName, prefabName);
	}

	public static AssetType LoadAsset<AssetType>(string bundleName, string assetName) where AssetType : Object
	{
		AssetBundle assetBundle = LoadAssetBundle(bundleName);
		if (assetBundle != null)
		{
			AssetType val = assetBundle.LoadAsset<AssetType>(assetName);
			if (val != null)
			{
				return val;
			}
			DebugMissingAsset(assetBundle, assetName);
		}
		return null;
	}

	public static T LoadSubAsset<T>(string bundleName, string assetName) where T : Object
	{
		AssetBundle assetBundle = LoadAssetBundle(bundleName);
		if (assetBundle != null)
		{
			T[] array = assetBundle.LoadAssetWithSubAssets<T>(assetName);
			if (array != null && array.Length != 0)
			{
				return array[0];
			}
			DebugMissingAsset(assetBundle, assetName);
		}
		return null;
	}

	public static AsyncLoadResult LoadPrefabAsync(string bundleName, string prefabName, MonoBehaviour owner)
	{
		if (Application.isEditor)
		{
			return new AsyncLoadResult(bundleName, prefabName)
			{
				asset = LoadPrefab(bundleName, prefabName)
			};
		}
		AsyncLoadResult asyncLoadResult = new AsyncLoadResult(bundleName, prefabName);
		owner.StartCoroutine(asyncLoadResult.AsyncLoadAsset());
		return asyncLoadResult;
	}

	public static AsyncLoadResult LoadAssetAsync(string bundleName, string assetName, MonoBehaviour owner)
	{
		AsyncLoadResult asyncLoadResult = new AsyncLoadResult(bundleName, assetName);
		owner.StartCoroutine(asyncLoadResult.AsyncLoadAsset());
		return asyncLoadResult;
	}

	private static AssetBundle LoadAssetBundle(string bundleName)
	{
		if (_assetBundles.TryGetValue(bundleName, out var value))
		{
			return value;
		}
		if (!Application.isEditor && FeatureToggle.IsFeatureEnabled(Feature.LoadRemotePrefabs))
		{
			string text = "https://build.dinopoloclub.com/asset-bundle?name=" + bundleName;
			Log.Info("Attempting to load bundle '{0}' from {1}.", bundleName, text);
			using UnityWebRequest unityWebRequest = UnityWebRequest.Get(text);
			unityWebRequest.downloadHandler = new DownloadHandlerAssetBundle(text, 0u);
			unityWebRequest.SendWebRequest();
			while (!unityWebRequest.isDone)
			{
				Thread.Sleep(100);
			}
			Log.Info("Request completed with response code {0}.", unityWebRequest.responseCode);
			if (unityWebRequest.result == UnityWebRequest.Result.Success)
			{
				value = DownloadHandlerAssetBundle.GetContent(unityWebRequest);
				if (value != null)
				{
					Log.Info("Fetched remote bundle successfully.");
				}
				else
				{
					Log.Info("Downloaded completed, but the remote bundle could not be loaded.");
				}
			}
			else
			{
				Log.Info("Failed to download remote bundle.\n{0}", unityWebRequest.error);
			}
		}
		if (value == null)
		{
			value = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "AssetBundles", bundleName));
		}
		_assetBundles[bundleName] = value;
		return value;
	}

	private static void DebugMissingAsset(AssetBundle bundle, string missingAssetName)
	{
		Log.Error("Unable to find asset named '{0}' in asset bundle '{1}'.", missingAssetName, bundle.name);
		Log.Info("The asset bundle contains these assets:");
		string[] allAssetNames = bundle.GetAllAssetNames();
		foreach (string text in allAssetNames)
		{
			Log.Info(" - {0}", text);
		}
	}
}
