using System.Threading;
using UnityEngine;

namespace TriLib
{
	public class AssetLoaderAsync : AssetLoaderBase
	{
		public Thread LoadFromFile(string filename, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, ObjectLoadedHandle onAssetLoaded = null, string basePath = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			if (basePath == null)
			{
				basePath = FileUtils.GetFileDirectory(filename);
			}
			bool usesWrapperGameObject = wrapperGameObject != null;
			return ThreadUtils.RunThread(delegate
			{
				InternalLoadFromFile(filename, basePath, options, usesWrapperGameObject, progressCallback);
			}, delegate
			{
				GameObject loadedGameObject = BuildGameObject(options, basePath, wrapperGameObject);
				if (onAssetLoaded != null)
				{
					onAssetLoaded(loadedGameObject);
				}
				ReleaseImport();
			});
		}

		public Thread LoadFromMemory(byte[] fileBytes, string filename, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, ObjectLoadedHandle onAssetLoaded = null, string basePath = null, AssimpInterop.DataCallback dataCallback = null, AssimpInterop.ExistsCallback existsCallback = null, LoadTextureDataCallback loadTextureDataCallback = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			if (basePath == null)
			{
				basePath = FileUtils.GetFileDirectory(filename);
			}
			bool usesWrapperGameObject = wrapperGameObject != null;
			return ThreadUtils.RunThread(delegate
			{
				InternalLoadFromMemory(fileBytes, filename, basePath, options, usesWrapperGameObject, dataCallback, existsCallback, loadTextureDataCallback, progressCallback);
			}, delegate
			{
				GameObject loadedGameObject = BuildGameObject(options, filename, wrapperGameObject);
				if (onAssetLoaded != null)
				{
					onAssetLoaded(loadedGameObject);
				}
				ReleaseImport();
			});
		}

		public Thread LoadFromFileWithTextures(string filename, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, ObjectLoadedHandle onAssetLoaded = null, string basePath = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			string extension = FileUtils.GetFileExtension(filename);
			if (basePath == null)
			{
				basePath = FileUtils.GetFileDirectory(filename);
			}
			bool usesWrapperGameObject = wrapperGameObject != null;
			return ThreadUtils.RunThread(delegate
			{
				byte[] data = FileUtils.LoadFileData(filename);
				InternalLoadFromMemoryAndZip(data, extension, basePath, options, usesWrapperGameObject, null, null, null, progressCallback);
			}, delegate
			{
				GameObject loadedGameObject = BuildGameObject(options, extension, wrapperGameObject);
				if (onAssetLoaded != null)
				{
					onAssetLoaded(loadedGameObject);
				}
				ReleaseImport();
			});
		}

		public Thread LoadFromMemoryWithTextures(byte[] fileData, string assetExtension, AssetLoaderOptions options, GameObject wrapperGameObject, ObjectLoadedHandle onAssetLoaded, string basePath = null, AssimpInterop.DataCallback dataCallback = null, AssimpInterop.ExistsCallback existsCallback = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			if (basePath == null)
			{
				basePath = FileUtils.GetFileDirectory(assetExtension);
			}
			bool usesWrapperGameObject = wrapperGameObject != null;
			return ThreadUtils.RunThread(delegate
			{
				InternalLoadFromMemoryAndZip(fileData, assetExtension, basePath, options, usesWrapperGameObject, dataCallback, existsCallback, null, progressCallback);
			}, delegate
			{
				GameObject loadedGameObject = BuildGameObject(options, assetExtension, wrapperGameObject);
				if (onAssetLoaded != null)
				{
					onAssetLoaded(loadedGameObject);
				}
				ReleaseImport();
			});
		}
	}
}
