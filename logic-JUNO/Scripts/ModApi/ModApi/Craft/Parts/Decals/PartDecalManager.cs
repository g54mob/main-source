using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Jundroo.ModTools;
using ModApi.Scenes.Events;
using UnityEngine;

namespace ModApi.Craft.Parts.Decals
{
	public class PartDecalManager : MonoBehaviour
	{
		private class LoadedDecal
		{
			public DecalInfo Decal { get; }

			public int RefCount { get; set; }

			public Texture2D Texture { get; }

			public LoadedDecal(DecalInfo decal, Texture2D texture)
			{
				Decal = decal;
				Texture = texture;
				RefCount = 1;
			}
		}

		private List<DecalInfo> _decals;

		private List<LoadedDecal> _loadedDecals;

		public IReadOnlyList<DecalInfo> Decals => _decals;

		public static PartDecalManager Create(GameObject parent)
		{
			PartDecalManager partDecalManager = new GameObject("CraftLoader").AddComponent<PartDecalManager>();
			partDecalManager.transform.SetParent(parent.transform);
			try
			{
				partDecalManager.Initialize();
			}
			catch (Exception exception)
			{
				Debug.LogError("An error occurred initializing the part decal manager");
				Debug.LogException(exception);
			}
			return partDecalManager;
		}

		public DecalInfo GetDecal(string path, bool logError)
		{
			DecalInfo decalInfo = _decals.FirstOrDefault((DecalInfo x) => x.Path == path);
			if (decalInfo == null && logError)
			{
				Debug.LogError("Could not find part decal for path '" + path + "'.");
			}
			return decalInfo;
		}

		public Texture2D LoadDecal(string path)
		{
			return LoadDecal(GetDecal(path, logError: true));
		}

		public Texture2D LoadDecal(DecalInfo decal)
		{
			if (decal == null)
			{
				return null;
			}
			int num = _loadedDecals.FindIndex((LoadedDecal x) => x.Decal == decal);
			if (num < 0)
			{
				Texture2D texture2D = LoadDecalTexture(decal);
				_loadedDecals.Add(new LoadedDecal(decal, texture2D));
				return texture2D;
			}
			_loadedDecals[num].RefCount++;
			return _loadedDecals[num].Texture;
		}

		public void RegisterDecal(string path, bool tileable, bool hidden, ILoadedMod mod)
		{
			DecalInfo decal = GetDecal(path, logError: false);
			if (decal != null)
			{
				Debug.Log("Overriding existing part decal at path '" + path + "'. Mod: " + (mod?.ModInfo.Name ?? "(null)"));
				_decals.Remove(decal);
			}
			_decals.Add(new DecalInfo(path, tileable, hidden, mod));
		}

		public void UnloadDecal(string path)
		{
			UnloadDecal(GetDecal(path, logError: true));
		}

		public void UnloadDecal(DecalInfo decal)
		{
			if (decal == null)
			{
				return;
			}
			int num = _loadedDecals.FindIndex((LoadedDecal x) => x.Decal == decal);
			if (num < 0)
			{
				Debug.LogWarning("Unable to unload decal '" + decal.Path + "' because it could not be found in the list of loaded decals.");
				return;
			}
			LoadedDecal loadedDecal = _loadedDecals[num];
			loadedDecal.RefCount--;
			if (loadedDecal.RefCount <= 0)
			{
				UnloadDecalTexture(decal, loadedDecal.Texture);
				_loadedDecals.RemoveAt(num);
			}
		}

		private void Initialize()
		{
			_decals = new List<DecalInfo>();
			_loadedDecals = new List<LoadedDecal>();
			Game.Instance.SceneManager.SceneUnloaded += OnSceneUnloaded;
			RegisterStockDecals();
			RegisterUserDecals();
			RegisterModDecals();
		}

		private Texture2D LoadDecalTexture(DecalInfo decal)
		{
			if (decal.Mod != null)
			{
				return null;
			}
			if (decal.Path.StartsWith("Decals/"))
			{
				return Game.Instance.ResourceLoader.LoadTexture(decal.Path);
			}
			return null;
		}

		private void OnSceneUnloaded(object sender, SceneEventArgs e)
		{
			if (_loadedDecals.Count > 0)
			{
				Debug.LogWarning($"{_loadedDecals.Count} part decals were not unloaded before the scene was unloaded.");
			}
			foreach (LoadedDecal loadedDecal in _loadedDecals)
			{
				UnloadDecalTexture(loadedDecal.Decal, loadedDecal.Texture);
			}
			_loadedDecals.Clear();
		}

		private void RegisterModDecals()
		{
		}

		private void RegisterStockDecals()
		{
			foreach (XElement item in XDocument.Parse(Game.Instance.ResourceLoader.LoadText("Decals/Decals")).Root.Elements("Decal"))
			{
				string path = (string)item.Attribute("path");
				bool valueOrDefault = (bool?)item.Attribute("tileable") == true;
				bool valueOrDefault2 = (bool?)item.Attribute("hidden") == true;
				RegisterDecal(path, valueOrDefault, valueOrDefault2, null);
			}
		}

		private void RegisterUserDecals()
		{
		}

		private void UnloadDecalTexture(DecalInfo decal, Texture2D texture)
		{
			if (decal.Mod == null)
			{
				if (decal.Path.StartsWith("Decals/"))
				{
					Resources.UnloadAsset(texture);
				}
				else
				{
					UnityEngine.Object.Destroy(texture);
				}
			}
		}
	}
}
