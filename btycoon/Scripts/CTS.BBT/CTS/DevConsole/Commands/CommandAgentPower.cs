using System.Collections.Generic;
using CTS.BBT.AI;

namespace CTS.DevConsole.Commands
{
	public class CommandAgentPower : SelectionCommand<Worker>
	{
		public override string Command { get; } = "AgentPowers";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			return "Displays or changes unlocked powers and their level for a selected Worker";
		}

		protected override void RunCommandOnSelection(Worker selection, List<object> args, string[] rawArgs)
		{
			WorkerPowerFeature.e_PowerFeatures power = selection.PowerFeatures.GetPower();
			string text = selection.name + ": ";
			PowerFeatureElement? element = WorkerPowerFeature.PowerFeatureTable.GetElement(power);
			if (element.HasValue)
			{
				text += $"[{element.Value.FeatureTitle}: {power.ToString()}]";
				text += ".";
				DeveloperConsole.Log(text);
			}
		}
	}
}
