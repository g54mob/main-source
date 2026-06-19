using System;
using System.Collections.Generic;

namespace PugMod
{
	public class ModAPIModLoader : IModLoader
	{
		public IEnumerable<LoadedMod> LoadedMods => Integration.Instance.LoadedMods;

		public string GetDirectory(long modId)
		{
			return Loader.Instance.GetDirectory(modId);
		}

		public LoadedMod GetMod(string name)
		{
			foreach (LoadedMod loadedMod in LoadedMods)
			{
				if (loadedMod.Metadata.name.Equals(name))
				{
					return loadedMod;
				}
			}
			return null;
		}

		public void ApplyHarmonyPatches(long modId)
		{
			foreach (Loader.Mod mod in Loader.Instance.Mods)
			{
				if (mod.ModId == modId)
				{
					Loader.Instance.HarmonyPatch(mod);
					break;
				}
			}
		}

		public void ApplyHarmonyPatch(long modId, Type type)
		{
			foreach (Loader.Mod mod in Loader.Instance.Mods)
			{
				if (mod.ModId == modId)
				{
					Loader.Instance.HarmonyPatchType(mod, type);
					break;
				}
			}
		}

		public void UnloadHarmonyPatches(long modId)
		{
			foreach (Loader.Mod mod in Loader.Instance.Mods)
			{
				if (mod.ModId == modId)
				{
					Loader.Instance.UndoHarmonyPatch(mod);
					break;
				}
			}
		}
	}
}
