using System.IO;
using UnityEngine;

namespace TH20.ExtContent
{
	public class GameItemDataAssetBundle : GameItemDataBase
	{
		private AssetBundle _assetBundle;

		private object _rootAssetObject;

		private string _rootAssetName;

		private string _installedFolderPathSpec;

		private string _assetBundleFileName;

		public AssetBundle AssetBundle => _assetBundle;

		public object RootAssetObject => _rootAssetObject;

		public string RootAssetName => _rootAssetName;

		public string InstalledFolderPathSpec => _installedFolderPathSpec;

		public void Init(string contentID, string installedFolderPathSpec, string assetBundleFileName, string rootAssetName)
		{
			Init(contentID);
			_rootAssetName = rootAssetName;
			_assetBundleFileName = assetBundleFileName;
			_installedFolderPathSpec = installedFolderPathSpec;
		}

		public void DeInit()
		{
			UnloadAllAssets();
		}

		public override bool ReloadAllAssets()
		{
			UnloadAllAssets();
			EnsureRootAssetLoaded();
			return HaveAssetsBeenLoaded();
		}

		public override void UnloadAllAssets()
		{
			UnloadRootAsset();
			UnloadAssetBundle();
		}

		public override bool HaveAssetsBeenLoaded()
		{
			if (!(_assetBundle != null))
			{
				return _rootAssetObject != null;
			}
			return true;
		}

		public override bool AreAssetsUnloadable()
		{
			return false;
		}

		public override GameObject GetRootAssetGameObject()
		{
			EnsureRootAssetLoaded();
			return RootAssetObject as GameObject;
		}

		public bool IsRootAssetLoaded()
		{
			return _rootAssetObject != null;
		}

		public bool EnsureRootAssetLoaded()
		{
			bool result = false;
			if (!IsRootAssetLoaded())
			{
				if (LoadRootAsset())
				{
					result = true;
				}
			}
			else
			{
				result = true;
			}
			return result;
		}

		public bool EnsureAssetBundleLoaded()
		{
			bool result = false;
			if (_assetBundle == null)
			{
				if (LoadAssetBundle())
				{
					result = true;
				}
			}
			else
			{
				result = true;
			}
			return result;
		}

		private bool LoadRootAsset()
		{
			bool result = false;
			if (EnsureAssetBundleLoaded())
			{
				if (!string.IsNullOrEmpty(_rootAssetName))
				{
					_rootAssetObject = _assetBundle.LoadAsset(_rootAssetName);
					if (IsRootAssetLoaded())
					{
						result = true;
						LogMessage(EMessageType.SuccessfullyLoadedRootAsset, _rootAssetName);
					}
					else
					{
						LogError(EMessageType.ErrorLoadingRootAsset, _rootAssetName);
					}
				}
				else
				{
					LogError(EMessageType.MissingRootAssetName);
				}
			}
			return result;
		}

		private bool LoadAssetBundle()
		{
			bool result = false;
			if (Directory.Exists(_installedFolderPathSpec))
			{
				string text = _installedFolderPathSpec + "/" + _assetBundleFileName;
				_assetBundle = AssetBundle.LoadFromFile(text);
				if (_assetBundle != null)
				{
					result = true;
					LogMessage(EMessageType.SuccessfullyLoadedAssetBundle, text);
				}
				else
				{
					LogError(EMessageType.ErrorLoadingAssetBundle, text);
				}
			}
			else
			{
				LogError(EMessageType.ItemInstallFolderDoesNotExist, _installedFolderPathSpec);
			}
			return result;
		}

		private void UnloadRootAsset()
		{
			if (_rootAssetObject != null)
			{
				_rootAssetObject = null;
			}
		}

		private void UnloadAssetBundle()
		{
			if (_assetBundle != null)
			{
				_assetBundle.Unload(unloadAllLoadedObjects: true);
				_assetBundle = null;
			}
		}

		public static void LogAllLoadedAssetBundles(string contextStr)
		{
			bool flag = false;
			foreach (AssetBundle allLoadedAssetBundle in AssetBundle.GetAllLoadedAssetBundles())
			{
				flag = true;
				LogAssetBundle(contextStr, allLoadedAssetBundle);
			}
			if (!flag)
			{
				ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("{0}: {1}: No bundles loaded"), "UNITY ASSET BUNDLE", contextStr));
			}
		}

		public static void LogAssetBundle(string contextStr, AssetBundle assetBundle)
		{
			if (assetBundle != null)
			{
				string[] allAssetNames = assetBundle.GetAllAssetNames();
				string[] allScenePaths = assetBundle.GetAllScenePaths();
				ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("{0}: {1}: Bundle:'{2}', Names:{3}. Scene paths:{4}). "), "UNITY ASSET BUNDLE", contextStr, assetBundle.name, allAssetNames.Length, allScenePaths.Length));
				int i = 0;
				for (int num = allAssetNames.Length; i < num; i++)
				{
					string text = (assetBundle.Contains(allAssetNames[i]) ? "Y" : "N");
					ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("    Asset Name    {0} / {1}: '{2}'. Contained: {3}"), i, num, allAssetNames[i], text));
				}
				int j = 0;
				for (int num2 = allScenePaths.Length; j < num2; j++)
				{
					ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("    Scene Path    {0} / {1}: '{2}'"), j, num2, allAssetNames[j]));
				}
				int k = 0;
				for (int num3 = allAssetNames.Length; k < num3; k++)
				{
					object obj = assetBundle.LoadAsset(allAssetNames[k]);
					ExtContentMessages.LogDebug(string.Format(ExtContentUtils.HiliteParams("    Loaded Object {0} / {1}: '{2}'"), k, num3, (obj != null) ? obj.ToString() : "none"));
				}
			}
		}
	}
}
