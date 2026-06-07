using System;
using UnityEngine;

namespace Jundroo.ModTools.Core
{
	public class ModResourceLoader : IModResourceLoader
	{
		private AssetBundle _assetBundle;

		public ModInfo ModInfo { get; private set; }

		public ModResourceLoader(ModInfo mod, ModManifest modManifest, AssetBundle assetBundle)
		{
			if (assetBundle == null)
			{
				throw new ArgumentNullException("assetBundle");
			}
			ModInfo = mod;
			_assetBundle = assetBundle;
		}

		public T LoadAsset<T>(string path) where T : UnityEngine.Object
		{
			return _assetBundle.LoadAsset<T>(path);
		}

		public UnityEngine.Object LoadAsset(string path, Type type)
		{
			return _assetBundle.LoadAsset(path, type);
		}

		public AsyncAssetRequest<UnityEngine.Object> LoadAssetAsync(string path, Type type)
		{
			return new AsyncModAssetRequest<UnityEngine.Object>(_assetBundle.LoadAssetAsync(path), this);
		}

		public AsyncAssetRequest<T> LoadAssetAsync<T>(string path) where T : UnityEngine.Object
		{
			return new AsyncModAssetRequest<T>(_assetBundle.LoadAssetAsync<T>(path), this);
		}
	}
}
