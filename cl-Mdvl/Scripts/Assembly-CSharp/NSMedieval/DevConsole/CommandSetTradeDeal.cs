using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.State;
using NSMedieval.WorldMap;

namespace NSMedieval.DevConsole
{
	public class CommandSetTradeDeal : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandSetTradeDeal()
		{
			Command = "setTradeDeal";
			Description = "Sets up or breaks a trade deal with the selected faction.";
			Help = "Usage: setTradeDeal <factionName:string> <setOrBreakDeal:bool>";
		}

		private static string GetAllFactions()
		{
			List<string> values = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionInstances.Select((FactionInstance factionInstance) => factionInstance.BlueprintId).ToList();
			return string.Join(", ", values);
		}

		private void CommandMethod()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("This command needs 2 params. " + Description + "\nAvailable factions:\n" + GetAllFactions());
		}

		private void CommandMethod(string factionName)
		{
			FactionInstance factionInstance = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionInstances.FirstOrDefault((FactionInstance faction) => faction.BlueprintId == factionName);
			if (factionInstance == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("No faction found with name " + factionName + "\nAvailable factions:\n" + GetAllFactions());
				return;
			}
			bool flag = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.AddToTradeDeals(null, factionInstance);
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Trade deal with faction " + factionName + " " + (flag ? "succeeded" : "failed: there is a trade deal already"));
		}

		private void CommandMethod(string factionName, bool makeOrBreak)
		{
			FactionInstance factionInstance = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.FactionInstances.FirstOrDefault((FactionInstance faction) => faction.BlueprintId == factionName);
			if (factionInstance == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("No faction found with name " + factionName + "\nAvailable factions:\n" + GetAllFactions());
				return;
			}
			bool flag = (makeOrBreak ? MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.AddToTradeDeals(null, factionInstance) : MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.RemoveTradeDeal(factionInstance));
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult((makeOrBreak ? "Making " : "Breaking") + " the trade deal with faction " + factionName + " " + (flag ? "succeeded" : "failed: it's probably already done"));
		}
	}
}
