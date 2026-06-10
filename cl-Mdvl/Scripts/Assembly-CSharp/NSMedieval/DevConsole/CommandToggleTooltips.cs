using NSEipix.Base;

namespace NSMedieval.DevConsole
{
	public class CommandToggleTooltips : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandToggleTooltips()
		{
			Command = "toggleTooltips";
			Description = "Toggles Ingame Tooltips on/off";
			Help = "Use this commad to toggle Tooltips ingame";
			Argument = ToggleTooltips();
		}

		private void CommandMethod()
		{
			if (MonoSingleton<TooltipController>.IsInstantiated())
			{
				MonoSingleton<TooltipController>.Instance.HideTooltips = !MonoSingleton<TooltipController>.Instance.HideTooltips;
				Argument = ToggleTooltips();
				string result = "ToggleTooltips " + Argument;
				MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
			}
		}

		private string ToggleTooltips()
		{
			if (!MonoSingleton<TooltipController>.IsInstantiated())
			{
				return "on";
			}
			if (!MonoSingleton<TooltipController>.Instance.HideTooltips)
			{
				return "on";
			}
			return "off";
		}
	}
}
