using System.Linq;
using NSMedieval.CommanderAI;
using NSMedieval.Village;

namespace NSMedieval.DevConsole
{
	public class CommandSetManualDigCommanderAgent : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetManualDigCommanderAgent()
		{
			Command = "enableManualDigCommanderInput";
			Description = "Sets the first commander agent to the debug manual dig one";
			Help = "enableManualDigCommanderInput";
		}

		private void CommandMethod()
		{
			CommanderAIManager commanderAIManager = VillageManager.ActiveVillage.Map.CommanderAIManager;
			if (commanderAIManager.Commanders.Any())
			{
				uint id = commanderAIManager.Commanders.First().Id;
				commanderAIManager.ReplaceCommanderAgent(id, new ManualDigCommanderAgent(id, commanderAIManager.Map));
			}
		}
	}
}
