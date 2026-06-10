using NSEipix.Base;
using NSMedieval.Manager;

namespace NSMedieval.DevConsole
{
	public class CommandSetWeatherEvent : ConsoleCommand
	{
		public override string Command { get; protected set; }

		public override string Description { get; protected set; }

		public override string Help { get; protected set; }

		public CommandSetWeatherEvent()
		{
			Command = "setWeatherEvent";
			Description = "Sets weather event";
			Help = "Use this command with string argument such as rain, fog or snow";
		}

		private void CommandMethod(string weatherEvent)
		{
			MonoSingleton<WeatherManager>.Instance.DebugForceWeatherEvent(weatherEvent);
		}
	}
}
