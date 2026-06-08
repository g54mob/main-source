using System;
using System.Collections.Generic;
using UnityEngine;

namespace KitchenMods
{
	public static class ModPreload
	{
		public static List<Mod> Mods = new List<Mod>();

		public static ModSource[] Sources = new ModSource[2]
		{
			new SteamWorkshopModSource(),
			new FolderModSource()
		};

		public static bool IsModded => Mods.Count != 0;

		private static void UnloadMods()
		{
			AssetBundle.UnloadAllAssetBundles(unloadAllObjects: true);
		}

		private static bool GetModsEnabled()
		{
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			for (int i = 0; i < commandLineArgs.Length; i++)
			{
				if (commandLineArgs[i] == "-nomods")
				{
					return false;
				}
			}
			return true;
		}

		public static void LoadMods()
		{
			UnloadMods();
			if (!GetModsEnabled())
			{
				Debug.LogWarning("Mods disabled by command line");
				return;
			}
			Debug.Log("Loading mods...");
			Mods.Clear();
			ModSource[] sources = Sources;
			for (int i = 0; i < sources.Length; i++)
			{
				List<Mod> collection = sources[i].LoadMods();
				Mods.AddRange(collection);
			}
			Debug.Log($"Loaded {Mods.Count} mods...");
			foreach (Mod mod in Mods)
			{
				mod.Activate();
			}
			foreach (Mod mod2 in Mods)
			{
				mod2.PostActivate();
			}
		}
	}
}
