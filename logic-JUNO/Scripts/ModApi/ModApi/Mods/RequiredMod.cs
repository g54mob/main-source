using Jundroo.ModTools;

namespace ModApi.Mods
{
	public class RequiredMod
	{
		public ModInfo Mod { get; set; }

		public bool RequiresCodeExecution { get; set; }

		public RequiredMod(ModInfo mod, bool requiresCodeExecution)
		{
			Mod = mod;
			RequiresCodeExecution = requiresCodeExecution;
		}
	}
}
