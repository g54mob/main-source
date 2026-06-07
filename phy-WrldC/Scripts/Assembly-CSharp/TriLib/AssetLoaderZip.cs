using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using UnityEngine;

namespace TriLib
{
	[Obsolete("AssetLoader and AssetLoaderAsync supports ZIP files when using the LoadFromMemory With Textures, LoadFromFileWithTextures and LoadFromBrowserFilesWithTextures methods. Please use these classes instead.")]
	public class AssetLoaderZip : AssetLoaderBase
	{
		public GameObject LoadFromFile(string filename, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			return LoadFileInternal(filename, options, wrapperGameObject, null, async: false, progressCallback) as GameObject;
		}

		public Thread LoadFromFileAsync(string filename, AssetLoaderOptions options = null, GameObject wrapperGameObject = null, ObjectLoadedHandle onAssetLoaded = null, AssimpInterop.ProgressCallback progressCallback = null)
		{
			return (Thread)LoadFileInternal(filename, options, wrapperGameObject, onAssetLoaded, async: true, progressCallback);
		}

		private static string GetReadableAssetPath(string path)
		{
			string supportedFileExtensions = AssetLoaderBase.GetSupportedFileExtensions();
			string[] files = Directory.GetFiles(path);
			foreach (string text in files)
			{
				string fileExtension = FileUtils.GetFileExtension(text);
				if (supportedFileExtensions.Contains("*" + fileExtension + ";"))
				{
					return text;
				}
			}
			files = Directory.GetDirectories(path);
			for (int i = 0; i < files.Length; i++)
			{
				string readableAssetPath = GetReadableAssetPath(files[i]);
				if (readableAssetPath != null)
				{
					return readableAssetPath;
				}
			}
			return null;
		}

		private object LoadFileInternal(string filename, AssetLoaderOptions assetLoaderOptions = null, GameObject wrapperGameObject = null, ObjectLoadedHandle onAssetLoaded = null, bool async = false, AssimpInterop.ProgressCallback progressCallback = null)
		{
			if (FileUtils.GetFileExtension(filename) == ".zip")
			{
				throw new Exception("Please enable TriLib ZIP loading");
			}
			if (async)
			{
				return AsyncLoadFileInternal(filename, assetLoaderOptions, wrapperGameObject, onAssetLoaded, progressCallback);
			}
			return SyncLoadFileInternal(filename, assetLoaderOptions, wrapperGameObject, progressCallback);
		}

		private object SyncLoadFileInternal(string filename, AssetLoaderOptions options, GameObject wrapperGameObject, AssimpInterop.ProgressCallback progressCallback = null)
		{
			string fileDirectory = FileUtils.GetFileDirectory(filename);
			InternalLoadFromFile(filename, fileDirectory, options, wrapperGameObject != null, progressCallback);
			GameObject result = BuildGameObject(options, fileDirectory, wrapperGameObject);
			ReleaseImport();
			return result;
		}

		private object AsyncLoadFileInternal(string filename, AssetLoaderOptions options, GameObject wrapperGameObject, ObjectLoadedHandle onAssetLoaded, AssimpInterop.ProgressCallback progressCallback = null)
		{
			string basePath = FileUtils.GetFileDirectory(filename);
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

		private static string GetSha256(string localFilename)
		{
			byte[] array = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(localFilename));
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array2 = array;
			foreach (byte b in array2)
			{
				stringBuilder.Append(b.ToString("x2"));
			}
			return stringBuilder.ToString();
		}
	}
}
