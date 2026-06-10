using NSEipix.Base;
using NSMedieval.Manager;

namespace NSMedieval.DevConsole
{
	public class CommandSetProductionSpeed : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetProductionSpeed()
		{
			Command = "productionSpeed";
			Description = "Sets production global multiplier speed (0-50)";
			Help = "Use this command to set production speed global multiplier. It takes one float argument";
		}

		private void CommandMethod(float value)
		{
			MonoSingleton<ProductionManager>.Instance.GlobalSpeedMultiplier = value;
			string result = $"Production speed set global multiplier to {value}";
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}
	}
}
