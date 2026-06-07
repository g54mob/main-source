using UnityEngine;

namespace TriLib
{
	public class AssetLoader : AssetLoaderBase
	{
		public GameObject LoadFromFile(string filename, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, string basePath = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			return null;
		}

		public GameObject LoadFromMemory(byte[] fileBytes, string filename, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, string basePath = null, AssimpInterop.DataCallback dataCallback = null, AssimpInterop.ExistsCallback existsCallback = null, LoadTextureDataCallback loadTextureDataCallback = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			return null;
		}

		public GameObject LoadFromFileWithTextures(string filename, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, string basePath = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			return null;
		}

		public GameObject LoadFromMemoryWithTextures(byte[] fileData, string assetExtension, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, string basePath = null, AssimpInterop.DataCallback dataCallback = null, AssimpInterop.ExistsCallback existsCallback = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			return null;
		}
	}
}
