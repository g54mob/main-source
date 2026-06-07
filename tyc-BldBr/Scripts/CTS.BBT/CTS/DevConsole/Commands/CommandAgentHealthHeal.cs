using System.Collections.Generic;
using CTS.BBT.AI;

namespace CTS.DevConsole.Commands
{
	internal class CommandAgentHealthHeal : SelectionCommand<Agent>, ISubCommand<CommandAgentHealth>, ISubCommand
	{
		public override string Command { get; } = "Heal";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Int };

		public override string GetCommandDescription()
		{
			return "Heals a selected agent by a specified amount";
		}

		protected override void RunCommandOnSelection(Agent selection, List<object> objects, string[] rawArgs)
		{
			if (!(objects[0] is int p_amount))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "[Int]");
			}
			if (selection.Health.IsDead)
			{
				DeveloperConsole.LogWarning("Agent is dead, cannot heal.");
			}
			selection.Health.Heal(p_amount);
		}
	}
}
