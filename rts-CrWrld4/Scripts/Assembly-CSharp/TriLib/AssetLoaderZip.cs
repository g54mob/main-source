using System;
using System.Threading;
using UnityEngine;

namespace TriLib
{
	[Obsolete]
	public class AssetLoaderZip : AssetLoaderBase
	{
		public GameObject LoadFromFile(string filename, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			return null;
		}

		public Thread LoadFromFileAsync(string filename, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, ObjectLoadedHandle onAssetLoaded = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			return null;
		}

		private static string GetReadableAssetPath(string path)
		{
			return null;
		}

		private object LoadFileInternal(string filename, AssetLoaderOptions assetLoaderOptions = null, GameObject wrapperGameObject = null, ObjectLoadedHandle onAssetLoaded = null, bool async = false, AssimpInterop.ProgressCallback progressCallback = null)
		{
			return null;
		}

		private object SyncLoadFileInternal(string filename, AssetLoaderOptions options, GameObject wrapperGameObject, AssimpInterop.ProgressCallback progressCallback = null)
		{
			return null;
		}

		private object AsyncLoadFileInternal(string filename, AssetLoaderOptions options, GameObject wrapperGameObject, ObjectLoadedHandle onAssetLoaded, AssimpInterop.ProgressCallback progressCallback = null)
		{
			return null;
		}

		private static string GetSha256(string localFilename)
		{
			return null;
		}
	}
}
