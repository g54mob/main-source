using NSEipix.Base;
using NSMedieval.BuildingComponents;

namespace NSMedieval.DevConsole
{
	public class CommandSpawnMaterialsWithBuilding : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandSpawnMaterialsWithBuilding()
		{
			Command = "spawnMaterialsWithBuilding";
			Description = "Toggles spawning materials next to buildings.";
			Help = "Use this command to toggle materials being spawned when placing buildings.";
			Argument = SpawnMaterialsWithBuilding();
		}

		private void CommandMethod()
		{
			MonoSingleton<BuildingPlacementManager>.Instance.SpawnMaterialsWithBuildingToggle();
			Argument = SpawnMaterialsWithBuilding();
			string result = "Autoconstruct " + Argument;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private string SpawnMaterialsWithBuilding()
		{
			if (!MonoSingleton<BuildingPlacementManager>.Instance.SpawnMaterialsWithBuilding)
			{
				return "off";
			}
			return "on";
		}
	}
}
