using NSEipix.Base;
using NSMedieval.UI;

namespace NSMedieval.DevConsole
{
	public class CommandToggleUI : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandToggleUI()
		{
			Command = "toggleUI";
			Description = "Toggles Ingame UI on/off";
			Help = "Use this commad to toggle UI ingame";
			Argument = ToggleUI();
		}

		private void CommandMethod()
		{
			MonoSingleton<UIController>.Instance.ToggleUI();
			Argument = ToggleUI();
			string result = "ToggleUI " + Argument;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private string ToggleUI()
		{
			if (!MonoSingleton<UIController>.Instance.HideUI)
			{
				return "off";
			}
			return "on";
		}
	}
}
