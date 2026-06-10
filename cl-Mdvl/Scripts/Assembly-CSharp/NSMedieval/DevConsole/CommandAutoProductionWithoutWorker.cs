using NSEipix.Base;

namespace NSMedieval.DevConsole
{
	public class CommandAutoProductionWithoutWorker : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandAutoProductionWithoutWorker()
		{
			Command = "autoprodWorkers";
			Description = "Toggles automatic production without humanoid";
			Help = "Use this command to toggle automatic production without workers.";
			Argument = AutoProd();
		}

		private void CommandMethod()
		{
			Argument = AutoProd();
			string result = "Require humanoid turned " + Argument;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private string AutoProd()
		{
			return "on";
		}
	}
}
