using Assets.Scripts.Mods;

namespace Assets.Scripts.Craft.Parts
{
	public class PartCategoryInfo
	{
		public string IconPath { get; set; }

		public LoadedMod Mod { get; set; }

		public string Name { get; private set; }

		public PartCategoryInfo(string name)
		{
			Name = name;
		}
	}
}
