using NSEipix.Base;
using NSMedieval.BuildingComponents;

namespace NSMedieval.DevConsole
{
	public class CommandCraftableBuildingsEnabled : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandCraftableBuildingsEnabled()
		{
			Command = "craftableBuildingsEnabled";
			Description = "Toggles craftable buildings in UI.";
			Help = "Use this command to toggle if craftable buildings should appear in the buildings UI to be constructed normally.";
			Argument = CraftableBuildingsEnabled();
		}

		private void CommandMethod()
		{
			MonoSingleton<BuildingPlacementManager>.Instance.CraftableBuildingsEnabledToggle();
			Argument = CraftableBuildingsEnabled();
			string result = "Craftable Buildings Enabled " + Argument;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private string CraftableBuildingsEnabled()
		{
			if (!MonoSingleton<BuildingPlacementManager>.Instance.CraftableBuildingsEnabled)
			{
				return "off";
			}
			return "on";
		}
	}
}
