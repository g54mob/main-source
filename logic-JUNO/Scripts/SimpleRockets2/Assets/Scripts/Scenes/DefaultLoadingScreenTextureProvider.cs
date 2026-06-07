using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Scenes;
using UnityEngine;

namespace Assets.Scripts.Scenes
{
	public class DefaultLoadingScreenTextureProvider : ILoadingScreenTextureProvider
	{
		private class LoadingScreenTextureInfo
		{
			public string Author { get; private set; }

			public LoadingScreenTexturePosition Position { get; private set; }

			public LoadingScreenTextureInfo(string author, LoadingScreenTexturePosition position)
			{
				Author = author;
				Position = position;
			}

			public static LoadingScreenTextureInfo Load(string path)
			{
				try
				{
					string text = Game.Instance.ResourceLoader.LoadText(path, logErrors: false);
					if (string.IsNullOrWhiteSpace(text))
					{
						return null;
					}
					XElement xElement = XElement.Parse(text);
					string author = (string)xElement.Attribute("author");
					string text2 = (string)xElement.Attribute("position");
					LoadingScreenTexturePosition position = LoadingScreenTexturePosition.Center;
					try
					{
						if (!string.IsNullOrWhiteSpace(text2))
						{
							position = (LoadingScreenTexturePosition)Enum.Parse(typeof(LoadingScreenTexturePosition), text2, ignoreCase: true);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						Debug.Log("Unable to parse texture position '" + text2 + "' as a value of '" + typeof(LoadingScreenTexturePosition).FullName + "'.");
					}
					return new LoadingScreenTextureInfo(author, position);
				}
				catch (Exception exception2)
				{
					Debug.LogException(exception2);
				}
				return null;
			}
		}

		public static readonly LoadingScreenTextureData DefaultLoadingScreen;

		public static readonly LoadingScreenTextureData StartupLoadingScreen;

		private static List<string> _loadingScreenPathsAll;

		private static Dictionary<string, List<string>> _loadingScreenPathsByPlanet;

		private static Dictionary<string, List<string>> _loadingScreenPathsByScene;

		public static string LastUsedTextureResourcePath { get; private set; }

		public static IReadOnlyList<string> LoadingScreenPaths => _loadingScreenPathsAll;

		static DefaultLoadingScreenTextureProvider()
		{
			Texture2D texture2D = new Texture2D(2, 2, TextureFormat.RGB24, mipChain: false, linear: false);
			texture2D.filterMode = FilterMode.Point;
			texture2D.wrapMode = TextureWrapMode.Clamp;
			texture2D.name = "BlackLoadingScreen";
			Color32 color = new Color32(0, 0, 0, 1);
			texture2D.SetPixels32(new Color32[4] { color, color, color, color });
			texture2D.Apply(updateMipmaps: false, makeNoLongerReadable: true);
			DefaultLoadingScreen = new LoadingScreenTextureData(texture2D, LoadingScreenTextureDisposalMethod.None);
			StartupLoadingScreen = new LoadingScreenTextureData(texture2D, LoadingScreenTextureDisposalMethod.None);
			XDocument xDocument = XDocument.Parse(Game.Instance.ResourceLoader.LoadText("LoadingScreens/LoadingScreens"));
			_loadingScreenPathsAll = new List<string>();
			_loadingScreenPathsByScene = new Dictionary<string, List<string>>();
			foreach (XElement item3 in xDocument.Root.Elements("Scenes").Elements("Scene"))
			{
				string key = (string)item3.Attribute("name");
				List<string> list = new List<string>();
				foreach (XElement item4 in item3.Elements("Texture"))
				{
					string text = (string)item4.Attribute("resourcePath");
					if (!string.IsNullOrWhiteSpace(text))
					{
						string item = "LoadingScreens/" + text;
						list.Add(item);
						if (!_loadingScreenPathsAll.Contains(item))
						{
							_loadingScreenPathsAll.Add(item);
						}
					}
				}
				_loadingScreenPathsByScene[key] = list;
			}
			_loadingScreenPathsByPlanet = new Dictionary<string, List<string>>();
			foreach (XElement item5 in xDocument.Root.Elements("Planets").Elements("Planet"))
			{
				string key2 = (string)item5.Attribute("name");
				List<string> list2 = new List<string>();
				foreach (XElement item6 in item5.Elements("Texture"))
				{
					string text2 = (string)item6.Attribute("resourcePath");
					if (!string.IsNullOrWhiteSpace(text2))
					{
						string item2 = "LoadingScreens/" + text2;
						list2.Add(item2);
						if (!_loadingScreenPathsAll.Contains(item2))
						{
							_loadingScreenPathsAll.Add(item2);
						}
					}
				}
				_loadingScreenPathsByPlanet[key2] = list2;
			}
			_loadingScreenPathsAll.Sort();
		}

		public static LoadingScreenTextureData GetLoadingScreenTexture(string resourcePath)
		{
			Texture2D texture2D = Game.Instance.ResourceLoader.LoadTexture(resourcePath, logErrors: false);
			if (texture2D != null)
			{
				LastUsedTextureResourcePath = resourcePath;
				LoadingScreenTextureInfo loadingScreenTextureInfo = LoadingScreenTextureInfo.Load(resourcePath) ?? new LoadingScreenTextureInfo(null, LoadingScreenTexturePosition.Center);
				return new LoadingScreenTextureData(texture2D, LoadingScreenTextureDisposalMethod.UnloadAsset, loadingScreenTextureInfo.Position, loadingScreenTextureInfo.Author);
			}
			return null;
		}

		public LoadingScreenTextureData GetLoadingScreenTexture(string scene, string previousScene, string flightSceneActivePlanet)
		{
			if (scene == "Startup" || previousScene == "Startup")
			{
				return StartupLoadingScreen;
			}
			LoadingScreenTextureData loadingScreenTextureData = null;
			if (scene == "Flight" && _loadingScreenPathsByPlanet.TryGetValue(flightSceneActivePlanet ?? string.Empty, out var value))
			{
				int index = UnityEngine.Random.Range(0, value.Count);
				loadingScreenTextureData = GetLoadingScreenTexture(value[index]);
			}
			if (loadingScreenTextureData == null && _loadingScreenPathsByScene.TryGetValue(scene, out var value2))
			{
				int index2 = UnityEngine.Random.Range(0, value2.Count);
				loadingScreenTextureData = GetLoadingScreenTexture(value2[index2]);
			}
			if (loadingScreenTextureData == null)
			{
				loadingScreenTextureData = DefaultLoadingScreen;
			}
			return loadingScreenTextureData;
		}
	}
}
