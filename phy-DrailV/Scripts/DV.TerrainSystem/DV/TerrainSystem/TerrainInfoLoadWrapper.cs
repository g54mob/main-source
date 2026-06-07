using System;
using System.Collections;
using UnityEngine;

namespace DV.TerrainSystem
{
	public class TerrainInfoLoadWrapper
	{
		public Action<TerrainInfo> LoadingFinished;

		private string assetBundleFilePath;

		private Func<IEnumerator, Coroutine> _StartCoroutine;

		private Coroutine loadCoro;

		private AssetBundleCreateRequest request;

		public bool IsCancelled { get; private set; }

		public TerrainInfoLoadWrapper(string assetBundleFilePath, Func<IEnumerator, Coroutine> StartCoroutineMethod)
		{
			this.assetBundleFilePath = assetBundleFilePath;
			_StartCoroutine = StartCoroutineMethod;
		}

		public void Load()
		{
			IsCancelled = false;
			if (loadCoro == null)
			{
				loadCoro = _StartCoroutine(LoadFromAssetBundleInternal());
			}
		}

		public void Unload()
		{
			if (loadCoro != null)
			{
				IsCancelled = true;
			}
			else if (request != null)
			{
				UnloadAndReset();
			}
		}

		private void UnloadAndReset()
		{
			request.assetBundle.Unload(unloadAllLoadedObjects: true);
			request = null;
			loadCoro = null;
			IsCancelled = false;
		}

		private IEnumerator LoadFromAssetBundleInternal()
		{
			request = AssetBundle.LoadFromFileAsync(assetBundleFilePath);
			while (!request.isDone)
			{
				yield return null;
			}
			if (IsCancelled)
			{
				UnloadAndReset();
				yield break;
			}
			yield return null;
			yield return null;
			AssetBundleRequest assetsReq = request.assetBundle.LoadAllAssetsAsync();
			while (!assetsReq.isDone)
			{
				yield return null;
			}
			if (IsCancelled)
			{
				UnloadAndReset();
				yield break;
			}
			loadCoro = null;
			IsCancelled = false;
			if (assetsReq.asset == null)
			{
				Debug.LogError("Error while loading '" + assetBundleFilePath + "'");
				Unload();
			}
			else
			{
				TerrainInfo obj = new TerrainInfo
				{
					terrainData = (TerrainData)assetsReq.allAssets[0]
				};
				LoadingFinished?.Invoke(obj);
			}
		}
	}
}
