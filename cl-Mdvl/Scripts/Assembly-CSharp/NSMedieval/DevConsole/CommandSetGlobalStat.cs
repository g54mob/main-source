using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSMedieval.GlobalStats;
using NSMedieval.Manager;

namespace NSMedieval.DevConsole
{
	public class CommandSetGlobalStat : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandSetGlobalStat()
		{
			Command = "setGlobalStat";
			Description = "Sets the specified global stat's value.";
			Help = "Usage: setGlobalStat <name:string> <value:float>";
		}

		private static string GetAllGlobalStatsString()
		{
			List<string> values = MonoSingleton<GlobalStatManager>.Instance.GlobalStatInstances.Select((GlobalStatInstance globalStatInstance) => globalStatInstance.BlueprintId).ToList();
			return string.Join(", ", values);
		}

		private void CommandMethod()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Available stats:\n" + GetAllGlobalStatsString());
		}

		private void CommandMethod(string statName)
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Available stats:\n" + GetAllGlobalStatsString());
		}

		private void CommandMethod(string globalStatName, float value)
		{
			GlobalStatInstance globalStatInstance = MonoSingleton<GlobalStatManager>.Instance.GetGlobalStatInstance(globalStatName);
			if (globalStatInstance == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Global stat instance with id " + globalStatName + " not found.\nInstantiated stats:\n" + GetAllGlobalStatsString());
				return;
			}
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult($"Setting global stat {globalStatInstance.BlueprintId} to {value}");
			globalStatInstance.SetValue(value, allowShowBbt: true);
			if (globalStatInstance.Blueprint == null)
			{
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("Cannot set global stat, blueprint is null - it's not present in the json.");
			}
		}
	}
}
