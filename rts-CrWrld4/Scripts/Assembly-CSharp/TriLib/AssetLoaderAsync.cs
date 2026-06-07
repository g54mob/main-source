using System.Threading;
using UnityEngine;

namespace TriLib
{
	public class AssetLoaderAsync : AssetLoaderBase
	{
		public Thread LoadFromFile(string filename, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, ObjectLoadedHandle onAssetLoaded = null, string basePath = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			return null;
		}

		public Thread LoadFromMemory(byte[] fileBytes, string filename, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, ObjectLoadedHandle onAssetLoaded = null, string basePath = null, AssimpInterop.DataCallback dataCallback = null, AssimpInterop.ExistsCallback existsCallback = null, LoadTextureDataCallback loadTextureDataCallback = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			return null;
		}

		public Thread LoadFromFileWithTextures(string filename, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, ObjectLoadedHandle onAssetLoaded = null, string basePath = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			return null;
		}

		public Thread LoadFromMemoryWithTextures(byte[] fileData, string assetExtension, AssetLoaderOptions options, GameObject wrapperGameObject, ObjectLoadedHandle onAssetLoaded, string basePath = null, AssimpInterop.DataCallback dataCallback = null, AssimpInterop.ExistsCallback existsCallback = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			return null;
		}
	}
}
