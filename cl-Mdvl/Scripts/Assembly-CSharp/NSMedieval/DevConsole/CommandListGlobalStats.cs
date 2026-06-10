using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.GlobalStats;
using NSMedieval.Manager;
using NSMedieval.Repository;
using NSMedieval.WorldMap;

namespace NSMedieval.DevConsole
{
	public class CommandListGlobalStats : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandListGlobalStats()
		{
			Command = "listGlobalStats";
			Description = "Lists out all global stats.";
			Help = "Usage: listGlobalStats";
		}

		private void CommandMethod()
		{
			List<string> list = new List<string>();
			_ = MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data;
			foreach (GlobalStat allItem in Repository<GlobalStatRepository, GlobalStat>.Instance.GetAllItems())
			{
				GlobalStatInstance globalStatInstance = MonoSingleton<GlobalStatManager>.Instance.GetGlobalStatInstance(allItem.GetID());
				if (globalStatInstance == null)
				{
					list.Add(allItem.ToString() + ". <color=red>[Not Instantiated]</color>");
				}
				else
				{
					list.Add($"{allItem.ToString()}. <color=green>[Value: {globalStatInstance.Value}]</color>");
				}
			}
			list.Sort();
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(string.Join("\n", list));
		}
	}
}
