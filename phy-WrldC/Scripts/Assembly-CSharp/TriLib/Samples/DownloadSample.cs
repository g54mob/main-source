using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace TriLib.Samples
{
	public class DownloadSample : MonoBehaviour
	{
		private string[] urls = new string[4] { "http://ricardoreis.net/trilib/test1.zip", "http://ricardoreis.net/trilib/test2.zip", "http://ricardoreis.net/trilib/test3.zip", "http://ricardoreis.net/trilib/test1.3ds" };

		private UnityWebRequest[] _fileDownloaders;

		private GameObject _loadedGameObject;

		private void Start()
		{
			_fileDownloaders = new UnityWebRequest[urls.Length];
		}

		private void OnGUI()
		{
			for (int i = 0; i < urls.Length; i++)
			{
				string text = urls[i];
				UnityWebRequest unityWebRequest = _fileDownloaders[i];
				GUILayout.BeginHorizontal();
				GUILayout.Label(text);
				if (unityWebRequest == null)
				{
					if (GUILayout.Button("Load"))
					{
						if (_loadedGameObject != null)
						{
							UnityEngine.Object.Destroy(_loadedGameObject);
						}
						string filenameWithoutExtension = FileUtils.GetFilenameWithoutExtension(text);
						string fileExtension = FileUtils.GetFileExtension(text);
						string text2 = $"{Application.persistentDataPath}/{filenameWithoutExtension}";
						string localFilename = $"{text2}/{filenameWithoutExtension}{fileExtension}";
						if (Directory.Exists(text2))
						{
							LoadFile(fileExtension, localFilename);
						}
						else
						{
							StartCoroutine(DownloadFile(text, i, fileExtension, text2, localFilename));
						}
					}
				}
				else
				{
					GUILayout.Label($"Downloaded {((unityWebRequest.downloadedBytes == 0L) ? 0f : unityWebRequest.downloadProgress):P2}");
				}
				GUILayout.EndHorizontal();
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
				_loadedGameObject = assetLoader.LoadFromFile(localFilename);
				Camera.main.FitToBounds(_loadedGameObject.transform, 3f);
			}
		}

		private IEnumerator DownloadFile(string url, int index, string fileExtension, string localFilePath, string localFilename)
		{
			_fileDownloaders[index] = UnityWebRequest.Get(url);
			yield return _fileDownloaders[index].SendWebRequest();
			if (fileExtension == ".zip")
			{
				throw new Exception("Please enable TriLib ZIP loading");
			}
			Directory.CreateDirectory(localFilePath);
			File.WriteAllBytes(localFilename, _fileDownloaders[index].downloadHandler.data);
			LoadFile(fileExtension, localFilename);
			_fileDownloaders[index] = null;
		}
	}
}
