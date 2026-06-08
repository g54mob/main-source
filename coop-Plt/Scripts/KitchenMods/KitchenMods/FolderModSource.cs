using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace KitchenMods
{
	public class FolderModSource : ModSource
	{
		public static string ModsFolder => Path.GetFullPath(Path.Combine(Application.dataPath, "..", "Mods"));

		public override List<Mod> LoadMods()
		{
			List<Mod> list = new List<Mod>();
			Debug.LogWarning("Searching for mods in " + ModsFolder);
			string modsFolder = ModsFolder;
			if (Directory.Exists(modsFolder))
			{
				string[] directories = Directory.GetDirectories(modsFolder);
				foreach (string text in directories)
				{
					string fileName = Path.GetFileName(text.TrimEnd(Path.DirectorySeparatorChar));
					if (!string.IsNullOrEmpty(fileName) && !fileName.StartsWith("."))
					{
						Mod mod = LoadModFromFolder(text, fileName, 0uL, include_content: true);
						if (mod != null)
						{
							mod.Source = this;
							list.Add(mod);
						}
					}
				}
			}
			return list;
		}

		public override Task<List<Mod>> PopulateModNames(List<Mod> mods)
		{
			return Task.FromResult(mods);
		}
	}
}
