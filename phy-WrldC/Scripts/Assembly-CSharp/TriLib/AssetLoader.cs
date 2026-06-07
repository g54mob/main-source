using UnityEngine;

namespace TriLib
{
	public class AssetLoader : AssetLoaderBase
	{
		public GameObject LoadFromFile(string filename, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, string basePath = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			if (basePath == null)
			{
				basePath = FileUtils.GetFileDirectory(filename);
			}
			InternalLoadFromFile(filename, basePath, options, wrapperGameObject != null, progressCallback);
			GameObject result = BuildGameObject(options, basePath, wrapperGameObject);
			ReleaseImport();
			return result;
		}

		public GameObject LoadFromMemory(byte[] fileBytes, string filename, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, string basePath = null, AssimpInterop.DataCallback dataCallback = null, AssimpInterop.ExistsCallback existsCallback = null, LoadTextureDataCallback loadTextureDataCallback = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			if (basePath == null)
			{
				basePath = FileUtils.GetFileDirectory(filename);
			}
			InternalLoadFromMemory(fileBytes, filename, basePath, options, wrapperGameObject != null, dataCallback, existsCallback, loadTextureDataCallback, progressCallback);
			GameObject result = BuildGameObject(options, basePath, wrapperGameObject);
			ReleaseImport();
			return result;
		}

		public GameObject LoadFromFileWithTextures(string filename, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, string basePath = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			byte[] data = FileUtils.LoadFileData(filename);
			string fileExtension = FileUtils.GetFileExtension(filename);
			if (basePath == null)
			{
				basePath = FileUtils.GetFileDirectory(filename);
			}
			InternalLoadFromMemoryAndZip(data, fileExtension, basePath, options, wrapperGameObject != null, null, null, null, progressCallback);
			GameObject result = BuildGameObject(options, fileExtension, wrapperGameObject);
			ReleaseImport();
			return result;
		}

		public GameObject LoadFromMemoryWithTextures(byte[] fileData, string assetExtension, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, string basePath = null, AssimpInterop.DataCallback dataCallback = null, AssimpInterop.ExistsCallback existsCallback = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			if (basePath == null)
			{
				basePath = FileUtils.GetFileDirectory(assetExtension);
			}
			InternalLoadFromMemoryAndZip(fileData, assetExtension, basePath, options, wrapperGameObject != null, dataCallback, existsCallback, null, progressCallback);
			GameObject result = BuildGameObject(options, assetExtension, wrapperGameObject);
			ReleaseImport();
			return result;
		}
	}
}
