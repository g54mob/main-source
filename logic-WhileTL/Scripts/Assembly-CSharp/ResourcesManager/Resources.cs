using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace ResourcesManager
{
	public static class Resources
	{
		private class Bundle
		{
			private List<string> _assets = new List<string>();

			public AssetBundle Data { get; private set; }

			public string Info { get; private set; }

			public int AssetsCount => _assets.Count;

			public Bundle(AssetBundle bundle)
			{
				Data = bundle;
				TextAsset textAsset = Data.LoadAsset("info") as TextAsset;
				if (textAsset != null)
				{
					Info = textAsset.text;
				}
				TextAsset textAsset2 = Data.LoadAsset("content") as TextAsset;
				if (textAsset2 != null)
				{
					string[] collection = textAsset2.text.Replace("\r", "").Split(new string[1] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
					_assets.AddRange(collection);
				}
			}

			public void Unload(bool unloadAllObjects)
			{
				if (Data != null)
				{
					Data.Unload(unloadAllObjects);
				}
			}

			public bool Contains(string assetPath)
			{
				return _assets.Contains(assetPath.ToLowerInvariant());
			}
		}

		public const string INFO_FILE_NAME = "info";

		public const string INFO_FILE_EXTENSION = "txt";

		public const string CONTENT_FILE_NAME = "content";

		public const string CONTENT_FILE_EXTENSION = "txt";

		public const string DATA_EXTENSION = "json";

		private static Dictionary<string, Bundle> _bundles = new Dictionary<string, Bundle>();

		private static string _notBakedResourcesPath;

		public static string NotBakedResourcesPath => _notBakedResourcesPath;

		public static string Register(string bundleFilePath)
		{
			string empty = string.Empty;
			if (_bundles.ContainsKey(bundleFilePath))
			{
				return empty + $"trying to load bundle '{bundleFilePath}', but it already loaded";
			}
			string notBakedResourcesPath = NotBakedResourcesPath;
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			string text = notBakedResourcesPath + bundleFilePath;
			AssetBundle assetBundle = AssetBundle.LoadFromFile(text);
			if (assetBundle == null)
			{
				return empty + $"unable to load '{text}'";
			}
			Bundle bundle = new Bundle(assetBundle);
			_bundles.Add(bundleFilePath, bundle);
			return empty + $"bundle '{bundleFilePath}' with {bundle.AssetsCount} assets was loaded in {Time.realtimeSinceStartup - realtimeSinceStartup}s. info:\n{bundle.Info}";
		}

		private static AssetBundle FindBundleForResource(string resourcePath)
		{
			foreach (KeyValuePair<string, Bundle> bundle in _bundles)
			{
				if (bundle.Value.Contains(resourcePath))
				{
					return bundle.Value.Data;
				}
			}
			return null;
		}

		public static bool LoadNotBakedText(string path, out string text)
		{
			text = string.Empty;
			string path2 = Path.Combine(NotBakedResourcesPath, path);
			if (File.Exists(path2))
			{
				text = File.ReadAllText(path2, Encoding.UTF8);
				return true;
			}
			return false;
		}

		public static bool LoadText(string path, out string text)
		{
			text = string.Empty;
			if (string.IsNullOrEmpty(path))
			{
				return false;
			}
			TextAsset textAsset = Load(GetUniversalPath(EnsurePath(path)), typeof(TextAsset)) as TextAsset;
			if (textAsset != null)
			{
				text = textAsset.text;
				return true;
			}
			return LoadNotBakedText(path, out text);
		}

		public static UnityEngine.Object Load(string path)
		{
			UnityEngine.Object obj = UnityEngine.Resources.Load(path);
			if (obj == null)
			{
				AssetBundle assetBundle = FindBundleForResource(path);
				if (assetBundle != null)
				{
					obj = assetBundle.LoadAsset(path);
				}
			}
			return obj;
		}

		public static UnityEngine.Object Load(string path, Type systemTypeInstance)
		{
			UnityEngine.Object obj = UnityEngine.Resources.Load(path, systemTypeInstance);
			if (obj == null)
			{
				AssetBundle assetBundle = FindBundleForResource(path);
				if (assetBundle != null)
				{
					obj = assetBundle.LoadAsset(path, systemTypeInstance);
				}
			}
			return obj;
		}

		public static AsyncOperation UnloadUnusedAssets()
		{
			return UnityEngine.Resources.UnloadUnusedAssets();
		}

		public static UnityEngine.Object[] LoadAll(string path)
		{
			return UnityEngine.Resources.LoadAll(path);
		}

		public static void UnloadExternalResources()
		{
			foreach (KeyValuePair<string, Bundle> bundle in _bundles)
			{
				bundle.Value.Unload(unloadAllObjects: false);
			}
		}

		public static string GetUniversalPath(string path)
		{
			string extension = Path.GetExtension(path);
			return path.Substring(0, path.Length - extension.Length);
		}

		public static string EnsurePath(string path)
		{
			return path.ToLowerInvariant().Replace("\\", "/");
		}

		public static string GetNotBakedPath(string resource, string extension)
		{
			return EnsurePath(Application.dataPath + "/Resources/" + resource + "." + extension);
		}

		static Resources()
		{
			string dataPath = Application.dataPath;
			char directorySeparatorChar = Path.DirectorySeparatorChar;
			string text = directorySeparatorChar.ToString();
			directorySeparatorChar = Path.DirectorySeparatorChar;
			_notBakedResourcesPath = dataPath + text + "Resources" + directorySeparatorChar;
		}
	}
}
