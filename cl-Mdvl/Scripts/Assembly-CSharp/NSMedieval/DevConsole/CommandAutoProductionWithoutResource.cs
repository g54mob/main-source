using NSEipix.Base;

namespace NSMedieval.DevConsole
{
	public class CommandAutoProductionWithoutResource : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandAutoProductionWithoutResource()
		{
			Command = "autoprodResources";
			Description = "Toggles automatic production without resources for all production buildings";
			Help = "Use this command to toggle automatic production without need for resources";
			Argument = AutoProd();
		}

		private void CommandMethod()
		{
			Argument = AutoProd();
			string result = "Require resources turned " + Argument;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private string AutoProd()
		{
			return "on";
		}
	}
}
