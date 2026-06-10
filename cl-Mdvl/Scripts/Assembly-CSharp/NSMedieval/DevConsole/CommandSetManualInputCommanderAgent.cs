using System.Linq;
using NSMedieval.CommanderAI;
using NSMedieval.Village;

namespace NSMedieval.DevConsole
{
	public class CommandSetManualInputCommanderAgent : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetManualInputCommanderAgent()
		{
			Command = "enableManualCommanderInput";
			Description = "Sets the first commander agent to the debug manual input one";
			Help = "enableManualCommanderInput";
		}

		private void CommandMethod()
		{
			CommanderAIManager commanderAIManager = VillageManager.ActiveVillage.Map.CommanderAIManager;
			if (commanderAIManager.Commanders.Any())
			{
				uint id = commanderAIManager.Commanders.First().Id;
				commanderAIManager.ReplaceCommanderAgent(id, new ManualInputCommanderAgent(id, commanderAIManager.Map));
			}
		}
	}
}
