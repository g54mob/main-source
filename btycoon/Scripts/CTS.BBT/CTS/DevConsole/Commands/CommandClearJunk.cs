using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;

namespace CTS.DevConsole.Commands
{
	public class CommandClearJunk : SelectionCommand<SelectableObject>
	{
		public override string Command => "ClearJunk";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			return "Cleans a selected object";
		}

		protected override void RunCommandOnSelection(SelectableObject selection, List<object> args, string[] rawArgs)
		{
			if (!selection.TryGetComponent<JunkObject>(out var component) && (bool)selection.SelectionTarget)
			{
				selection.SelectionTarget.TryGetComponent<JunkObject>(out component);
			}
			if ((bool)component)
			{
				component.SafeDiscard();
				return;
			}
			if (!selection.TryGetComponent<CleanableObject>(out var component2) && (bool)selection.SelectionTarget)
			{
				selection.SelectionTarget.TryGetComponent<CleanableObject>(out component2);
			}
			if ((bool)component2)
			{
				component2.Clean();
			}
		}
	}
}
