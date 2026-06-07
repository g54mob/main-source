using Jundroo.ModTools;

namespace ModApi.Common.ResourceUtils
{
	public class ResourceData
	{
		public ILoadedMod Mod { get; set; }

		public string Path { get; set; }

		public ResourceData(string path, ILoadedMod mod = null)
		{
			Path = path;
			Mod = mod;
		}
	}
}
