using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace PugMod
{
	public class SideLoader : IModPlatform
	{
		private struct LoadedMod
		{
			public long ModId;

			public long Timestamp;
		}

		private string _modDirectory;

		private Dictionary<string, LoadedMod> _loadedMods = new Dictionary<string, LoadedMod>();

		public bool Init()
		{
			_modDirectory = Application.streamingAssetsPath + "/Mods";
			Update();
			return true;
		}

		public void Update()
		{
			if (!Directory.Exists(_modDirectory))
			{
				return;
			}
			string[] directories = Directory.GetDirectories(_modDirectory);
			List<string> list = new List<string>();
			foreach (string key in _loadedMods.Keys)
			{
				string text = Path.Combine(key, "ModManifest.json");
				try
				{
					if (!File.Exists(text) || !directories.Contains(key) || File.GetLastWriteTimeUtc(text).Ticks > _loadedMods[key].Timestamp)
					{
						Debug.Log("detected change on " + text + "; reloading");
						Integration.Instance.RemoveMod(_loadedMods[key].ModId);
						list.Add(key);
					}
				}
				catch (Exception exception)
				{
					Debug.LogError("failed to check mod: " + key + ", unloading");
					Debug.LogException(exception);
					Integration.Instance.RemoveMod(_loadedMods[key].ModId);
					list.Add(key);
				}
			}
			foreach (string item in list)
			{
				_loadedMods.Remove(item);
			}
			string[] array = directories;
			foreach (string text2 in array)
			{
				try
				{
					string path = Path.Combine(text2, "ModManifest.json");
					if (File.Exists(path) && !_loadedMods.ContainsKey(text2))
					{
						ModMetadata metadata = JsonUtility.FromJson<ModMetadata>(File.ReadAllText(path));
						LoadedMod value = new LoadedMod
						{
							ModId = -Mathf.Abs(metadata.name.GetHashCode()),
							Timestamp = File.GetLastWriteTimeUtc(path).Ticks
						};
						if (!Integration.Instance.AddMod(metadata, text2, value.ModId, supportsCurrentVersion: true))
						{
							Debug.Log("failed to load mod " + metadata.name + " at " + text2);
							continue;
						}
						Debug.Log("loaded mod " + metadata.name + " at " + text2);
						_loadedMods.Add(text2, value);
					}
				}
				catch (Exception exception2)
				{
					Debug.LogError("failed to load mod: " + text2);
					Debug.LogException(exception2);
				}
			}
		}
	}
}
