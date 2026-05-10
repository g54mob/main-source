using System.Collections.Generic;
using CTS.BBT.AI;

namespace CTS.DevConsole.Commands
{
	public class CommandAgentPowerSet : SelectionCommand<Worker>, ISubCommand<CommandAgentPower>, ISubCommand
	{
		public override string Command { get; } = "Set";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { typeof(WorkerPowerFeature.e_PowerFeatures) };

		public override string GetCommandDescription()
		{
			return "Sets the level of a specified Power for a selected Worker";
		}

		protected override void RunCommandOnSelection(Worker selection, List<object> args, string[] rawArgs)
		{
			if (!(args[0] is WorkerPowerFeature.e_PowerFeatures power))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "[e_PowerFeatures]");
			}
			selection.PowerFeatures.SetPower(power);
		}
	}
}
