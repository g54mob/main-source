using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;

namespace NSMedieval.DevConsole
{
	public class CommandCountResources : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandCountResources()
		{
			Command = "countResources";
			Description = "Print resource counters";
			Help = "Use this command for debugging resource counters";
		}

		private void CommandMethod()
		{
			MonoSingleton<DeveloperConsoleController>.Instance.ClearConsole();
			foreach (Resource allItem in Repository<ResourceRepository, Resource>.Instance.GetAllItems())
			{
				ResourcePileCount count = MonoSingleton<ResourcePileTracker>.Instance.GetCount(allItem);
				if (count.TotalCount > 0 || count.UnreachableCount > 0)
				{
					MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(allItem.GetID() + ": " + count);
					MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult("-------------------------------");
				}
			}
		}
	}
}
