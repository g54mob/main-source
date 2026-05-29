using System.Collections.Generic;
using CTS.BBT.AI;

namespace CTS.DevConsole.Commands
{
	internal class CommandAgentHealthDamage : SelectionCommand<Agent>, ISubCommand<CommandAgentHealth>, ISubCommand
	{
		public override string Command { get; } = "Damage";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Int };

		public override string GetCommandDescription()
		{
			return "Damages a selected agent by a specified amount";
		}

		protected override void RunCommandOnSelection(Agent selection, List<object> objects, string[] rawArgs)
		{
			if (!(objects[0] is int num))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "[Int]");
			}
			if (num == 0)
			{
				selection.Health.ForceDeath();
			}
			else
			{
				selection.Health.Damage(num);
			}
		}
	}
}
