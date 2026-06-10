using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.Village;

namespace NSMedieval.DevConsole
{
	public class CommandKillPlants : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandKillPlants()
		{
			Command = "killPlants";
			Description = "Kills all plant map resources";
			Help = "Use this to kill all plants on the map";
		}

		private void CommandMethod()
		{
			foreach (PlantMapResourceInstance worldObjects in VillageManager.ActiveVillage.Map.GetWorldObjectsList<PlantMapResourceInstance>(GridDataType.PlantMapResource))
			{
				worldObjects.SetLastPhase();
			}
		}
	}
}
