using System;
using System.IO;
using Assets.Scripts.Storage;
using Jundroo.Common.Platform;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Scenes.Startup
{
	public class UrlHandlerScript : MonoBehaviour
	{
		public static UrlHandlerScript Instance { get; private set; }

		public void HandleUrl(string url)
		{
			try
			{
				Debug.Log("HandleUrl: " + ((url == null) ? "(null)" : url));
				SystemUtils.SwitchToThisWindow();
				if (string.IsNullOrEmpty(url))
				{
					return;
				}
				if (url.StartsWith("simpleplanes://view/"))
				{
					string text = url.Replace("simpleplanes://view/", string.Empty);
					if (Utilities.IsValidCraftUrlId(text))
					{
						Debug.Log("UrlHandlerScript: Loading Aircraft ID: " + text);
						Game.Instance.DownloadedAircraftId = text;
						Game.Instance.SceneManager.LoadDesigner();
					}
					else
					{
						Debug.Log("UrlHandlerScript: Invalid Aircraft ID: " + text);
					}
					return;
				}
				if (url.EndsWith(".splane", StringComparison.InvariantCultureIgnoreCase))
				{
					try
					{
						if (File.Exists(url))
						{
							string text2 = File.ReadAllText(url);
							Debug.Log("UrlHandlerScript: Loading Aircraft ID from file: " + text2);
							Game.Instance.DownloadedAircraftId = text2;
							Game.Instance.SceneManager.LoadDesigner();
						}
						else
						{
							Debug.Log("Could not load URL: " + url);
						}
						return;
					}
					catch (Exception ex)
					{
						Debug.Log("UrlHandlerScript: Failed to load url: " + url + "\n Error: " + ex.ToString());
						return;
					}
				}
				if (url.EndsWith(".sp2-mod", StringComparison.InvariantCultureIgnoreCase))
				{
					Game.Instance.ModManagerScript.LoadExternalModFile(url);
				}
				else if (url.EndsWith(".sp2-mod-android", StringComparison.InvariantCultureIgnoreCase))
				{
					string path = GameData.Mods.GetPath(url);
					Game.Instance.ModManagerScript.LoadExternalModFile(path);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		protected virtual void Start()
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			Instance = this;
		}

		private FileInfo CopyModFileToModDirectory(string modFilePath)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(SystemUtils.GetLongPathName(modFilePath));
				if (fileInfo.Exists)
				{
					FileInfo fileInfo2 = new FileInfo(GameData.Mods.GetPath(fileInfo.Name));
					if (!fileInfo2.Directory.Exists)
					{
						fileInfo2.Directory.Create();
					}
					if (fileInfo.FullName != fileInfo2.FullName)
					{
						fileInfo.CopyTo(fileInfo2.FullName, overwrite: true);
					}
					return fileInfo2;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			return null;
		}
	}
}
