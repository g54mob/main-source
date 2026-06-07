using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.DevConsole;

namespace CTS
{
	public class CommandSatisfaction : SelectionCommand<AgentSatisfaction>
	{
		public override string Command { get; } = "Satisfaction";

		public override bool CanHaveNoArguments => true;

		public override bool EnableHelpCommand => true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Int };

		protected override bool CanSearchObjectInSceneIfNothingSelected { get; }

		public override string GetCommandDescription()
		{
			return "Displays or modifies the satisfaction meter of the selected agent";
		}

		protected override void RunCommandOnSelection(AgentSatisfaction selection, List<object> args, string[] rawArgs)
		{
			if (args.Count > 0 && args[0] is int value)
			{
				selection.AddFlatValue(value);
			}
			string text = "Current Modifiers:";
			if (selection.CurrentModifiers.Count <= 0)
			{
				text += "\nNone";
			}
			else
			{
				foreach (KeyValuePair<StringKey, int> currentModifier in selection.CurrentModifiers)
				{
					text += $"\n[{currentModifier.Key.ToString()}]:{currentModifier.Value}";
				}
			}
			DeveloperConsole.Log($"Current Satisfaction: {selection.RawSatisfaction}", text);
		}
	}
}
