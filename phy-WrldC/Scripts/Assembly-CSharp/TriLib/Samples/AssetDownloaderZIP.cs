using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace TriLib.Samples
{
	public class AssetDownloaderZIP : MonoBehaviour
	{
		private UnityWebRequest _fileDownloader;

		private void Start()
		{
			string url = "http://ricardoreis.net/trilib/test1.zip";
			LoadOrDownload(url);
		}

		private void OnFileDownloaded(GameObject loadedGameObject)
		{
			Camera.main.FitToBounds(loadedGameObject.transform, 3f);
		}

		private void LoadOrDownload(string url)
		{
			string filenameWithoutExtension = FileUtils.GetFilenameWithoutExtension(url);
			string fileExtension = FileUtils.GetFileExtension(url);
			string text = $"{Application.persistentDataPath}/{filenameWithoutExtension}";
			string localFilename = $"{text}/{filenameWithoutExtension}{fileExtension}";
			if (Directory.Exists(text))
			{
				LoadFile(fileExtension, localFilename);
			}
			else
			{
				StartCoroutine(DownloadFile(url, fileExtension, text, localFilename));
			}
		}

		private string GetReadableAssetPath(string path)
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
			foreach (string path2 in files)
			{
				string readableAssetPath = GetReadableAssetPath(path2);
				if (readableAssetPath != null)
				{
					return readableAssetPath;
				}
			}
			return null;
		}

		private void LoadFile(string fileExtension, string localFilename)
		{
			using (AssetLoader assetLoader = new AssetLoader())
			{
				if (fileExtension == ".zip")
				{
					throw new Exception("Please enable TriLib ZIP loading");
				}
				GameObject loadedGameObject = assetLoader.LoadFromFile(localFilename);
				OnFileDownloaded(loadedGameObject);
			}
		}

		private IEnumerator DownloadFile(string url, string fileExtension, string localFilePath, string localFilename)
		{
			_fileDownloader = UnityWebRequest.Get(url);
			yield return _fileDownloader.SendWebRequest();
			if (fileExtension == ".zip")
			{
				throw new Exception("Please enable TriLib ZIP loading");
			}
			Directory.CreateDirectory(localFilePath);
			File.WriteAllBytes(localFilename, _fileDownloader.downloadHandler.data);
			LoadFile(fileExtension, localFilename);
			_fileDownloader = null;
		}
	}
}
