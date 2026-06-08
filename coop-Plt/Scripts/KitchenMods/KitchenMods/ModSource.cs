using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KitchenMods
{
	public abstract class ModSource
	{
		public abstract List<Mod> LoadMods();

		public abstract Task<List<Mod>> PopulateModNames(List<Mod> mods);

		protected List<string> ListModFilePaths(string subfolder, bool include_content = false)
		{
			List<string> list = new List<string> { subfolder };
			if (include_content)
			{
				list.Add(Path.Combine(subfolder, "content"));
			}
			List<string> list2 = new List<string>();
			foreach (string item in list)
			{
				try
				{
					string[] files = Directory.GetFiles(item);
					foreach (string text in files)
					{
						if (!text.StartsWith("._"))
						{
							list2.Add(text);
						}
					}
				}
				catch (DirectoryNotFoundException)
				{
				}
			}
			return list2;
		}

		protected Mod LoadModFromFolder(string subfolder, string name, ulong id = 0uL, bool include_content = false)
		{
			Mod mod = new Mod(id, name);
			foreach (string item in ListModFilePaths(subfolder, include_content))
			{
				if (AssemblyModPack.TryLoadFile(item, out var pack))
				{
					mod.AddPack(pack);
				}
				if (AssetBundleModPack.TryLoadFile(item, out var pack2))
				{
					mod.AddPack(pack2);
				}
			}
			return mod;
		}
	}
}
