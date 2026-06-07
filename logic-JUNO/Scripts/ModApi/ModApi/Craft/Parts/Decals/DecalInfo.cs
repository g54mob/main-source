using System.Text.RegularExpressions;
using Jundroo.ModTools;

namespace ModApi.Craft.Parts.Decals
{
	public class DecalInfo
	{
		public string DisplayName { get; }

		public bool IsHidden { get; }

		public ILoadedMod Mod { get; }

		public string Path { get; }

		public bool Tileable { get; }

		public DecalInfo(string path, bool tileable, bool hidden, ILoadedMod mod)
		{
			Path = path;
			IsHidden = hidden;
			Tileable = tileable;
			Mod = mod;
			string text = path.Replace("\\", "/").Substring(path.LastIndexOf('/') + 1);
			int num = text.LastIndexOf('.');
			if (num >= 0)
			{
				text = text.Remove(num);
			}
			DisplayName = Regex.Replace(text, "([A-Z]+|[0-9|\\.]+)", " $1").TrimStart();
		}
	}
}
