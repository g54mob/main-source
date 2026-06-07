using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;

namespace CTS.DevConsole.Commands
{
	public class CommandClearJunkAll : ConsoleCommand, ISubCommand<CommandClearJunk>, ISubCommand
	{
		public override string Command { get; } = "All";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			return "Clears all cleaning chores.";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (!MonoSingleton<ChoreList>.Instance)
			{
				return;
			}
			WorkerChoreDiscardJunk p_outChore;
			while (MonoSingleton<ChoreList>.Instance.TryGetSpecificChore<WorkerChoreDiscardJunk>(out p_outChore))
			{
				if (((object)p_outChore).TryGetField("_junkObject", out JunkObject outObject))
				{
					outObject.SafeDiscard();
				}
			}
			WorkerChoreClean p_outChore2;
			while (MonoSingleton<ChoreList>.Instance.TryGetSpecificChore<WorkerChoreClean>(out p_outChore2))
			{
				p_outChore2.OnComplete();
			}
		}
	}
}
