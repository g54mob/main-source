using NSEipix.Base;
using NSMedieval.Research;

namespace NSMedieval.DevConsole
{
	public class CommandActivateAllResearch : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandActivateAllResearch()
		{
			Command = "activateAllResearch";
			Description = "Instant activation of all research.";
			Help = "Use this command to immediately activate entire research tree (no resources required).";
			Argument = UnlockAllResearch();
		}

		private void CommandMethod()
		{
			MonoSingleton<ResearchController>.Instance.ActivateAllResearch();
			Argument = UnlockAllResearch();
			string result = "Activate all research " + Argument;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private string UnlockAllResearch()
		{
			if (!MonoSingleton<ResearchController>.Instance.DebugAllUnlocked)
			{
				return "off";
			}
			return "on";
		}
	}
}
