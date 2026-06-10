using System.Linq;
using NSMedieval.CommanderAI;
using NSMedieval.Village;

namespace NSMedieval.DevConsole
{
	public class CommandSetManualConstructCommanderAgent : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetManualConstructCommanderAgent()
		{
			Command = "enableManualConstructCommanderInput";
			Description = "Sets the first commander agent to the debug manual construct one";
			Help = "enableManualConstructCommanderInput";
		}

		private void CommandMethod()
		{
			CommanderAIManager commanderAIManager = VillageManager.ActiveVillage.Map.CommanderAIManager;
			if (commanderAIManager.Commanders.Any())
			{
				uint id = commanderAIManager.Commanders.First().Id;
				commanderAIManager.ReplaceCommanderAgent(id, new ManualConstructCommanderAgent(id, commanderAIManager.Map));
			}
		}
	}
}
