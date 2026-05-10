using System.Collections.Generic;
using CTS.DevConsole;

namespace CTS
{
	public class CommandPower : SelectionCommand<ActionListCanvas>
	{
		public enum EPower
		{
			BloodyVomit = 0,
			CharitableExtortion = 1
		}

		protected override bool CanSearchObjectInSceneIfNothingSelected { get; } = true;

		public override string Command { get; } = "Power";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { typeof(EPower) };

		protected override void RunCommandOnSelection(ActionListCanvas selection, List<object> args, string[] rawArgs)
		{
			if (args.Count == 1 && args[0] is EPower power)
			{
				selection.QuickPlay(EnumToInt(power));
			}
		}

		public override string GetCommandDescription()
		{
			return "Plays a specific power.";
		}

		private int EnumToInt(EPower power)
		{
			return power switch
			{
				EPower.BloodyVomit => 0, 
				EPower.CharitableExtortion => 1, 
				_ => 0, 
			};
		}
	}
}
