using NSEipix.Base;
using NSMedieval.Manager;

namespace NSMedieval.DevConsole
{
	public class CommandToggleWeatherDebugView : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public override string Argument { get; protected set; }

		public CommandToggleWeatherDebugView()
		{
			Command = "toggleWeatherView";
			Description = "Toggles weather debug view. It shows weather events for the whole season.";
			Help = "Use this command to toggle weather debug view. It shows incoming and past weather events for the whole season.";
			Argument = DebugViewEnabled();
		}

		private void CommandMethod()
		{
			MonoSingleton<WeatherManager>.Instance.ToggleDebugView();
			Argument = DebugViewEnabled();
			string result = "Weather debug view is turned " + Argument;
			MonoSingleton<DeveloperConsoleController>.Instance.ReturnCommandResult(result);
		}

		private string DebugViewEnabled()
		{
			if (!MonoSingleton<WeatherManager>.Instance.IsDebugViewEnabled())
			{
				return "off";
			}
			return "on";
		}
	}
}
